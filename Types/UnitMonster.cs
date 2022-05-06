/**
 *   Copyright (C) 2021-2022
 *
 *   https://github.com/OneXDeveloper/MapAssist/
 *  
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <https://www.gnu.org/licenses/>.
 **/

using MapAssist.Helpers;
using MapAssist.Structs;
using System;
using System.Collections.Generic;

namespace MapAssist.Types
{
    public class UnitMonster : UnitAny
    {
        public MonsterData MonsterData { get; set; }
        public MonStats MonsterStats { get; private set; }
        public List<Resist> Immunities { get; set; }
        public Npc Npc => (Npc)TxtFileNo;

        public UnitMonster(IntPtr ptrUnit) : base(ptrUnit)
        {
        }

        public new UnitMonster Update()
        {
            if (base.Update() == UpdateResult.Updated)
            {
                using (var processContext = GameManager.GetProcessContext())
                {
                    MonsterData = processContext.Read<MonsterData>(Struct.pUnitData);
                    MonsterStats = processContext.Read<MonStats>(MonsterData.pMonStats);
                    Immunities = GetImmunities();
                }

                return this;
            }

            return null;
        }

        private List<Resist> GetImmunities()
        {
            Stats.TryGetValue(Types.Stats.Stat.DamageReduced, out var resistanceDamage);
            Stats.TryGetValue(Types.Stats.Stat.MagicResist, out var resistanceMagic);
            Stats.TryGetValue(Types.Stats.Stat.FireResist, out var resistanceFire);
            Stats.TryGetValue(Types.Stats.Stat.LightningResist, out var resistanceLightning);
            Stats.TryGetValue(Types.Stats.Stat.ColdResist, out var resistanceCold);
            Stats.TryGetValue(Types.Stats.Stat.PoisonResist, out var resistancePoison);

            var resists = new List<int>
            {
                resistanceDamage,
                resistanceMagic,
                resistanceFire,
                resistanceLightning,
                resistanceCold,
                resistancePoison
            };

            var immunities = new List<Resist>();

            for (var i = 0; i < 6; i++)
            {
                if (resists[i] >= 100)
                {
                    immunities.Add((Resist)i);
                }
            }

            return immunities;
        }

        public float HealthPercentage
        {
            get
            {
                if (Stats.TryGetValue(Types.Stats.Stat.Life, out var health) &&
                    Stats.TryGetValue(Types.Stats.Stat.MaxLife, out var maxHp) && maxHp > 0)
                {
                    return (float)health / maxHp;
                }
                return 0.0f;
            }
        }

        public MonsterTypeFlags MonsterType
        {
            get
            {
                var monsterTypes = new List<MonsterTypeFlags>() {
                    MonsterTypeFlags.SuperUnique,
                    MonsterTypeFlags.Champion,
                    MonsterTypeFlags.Minion,
                    MonsterTypeFlags.Unique
                };

                foreach (var monType in monsterTypes)
                {
                    if ((MonsterData.MonsterType & monType) == monType)
                    {
                        return monType;
                    }
                }

                return MonsterTypeFlags.Other;
            }
        }

        public override string HashString => Npc + "/" + Position.X + "/" + Position.Y;
    }
}
