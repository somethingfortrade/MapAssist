﻿/**
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

using System;
using System.Collections.Generic;

namespace MapAssist.Types
{
    class Chest
    {
        public static HashSet<GameObject> NormalChests = new HashSet<GameObject>
        {
            GameObject.Casket5,
            GameObject.Casket6,
            GameObject.LargeChestRight,
            GameObject.LargeChestLeft,
            GameObject.CasketR,
            GameObject.CasketL,
            GameObject.Casket,
            GameObject.RogueCorpse1,
            GameObject.RogueCorpse2,
            GameObject.RogueCorpseRolling,
            GameObject.CorpseOnStick1,
            GameObject.CorpseOnStick2,
            GameObject.Casket3,
            GameObject.TombLargeChestL,
            GameObject.TombLargeChestR,
            GameObject.Sarcophagus,
            GameObject.InnerHellHiddenStash,
            GameObject.InnerHellSkullPile,
            GameObject.InnerHellHiddenStash2,
            GameObject.InnerHellHiddenStash3,
            GameObject.Act1LargeChestRight,
            GameObject.Act1TallChestRight,
            GameObject.Act1MediumChestRight,
            GameObject.Act1LargeChest1,
            GameObject.Act2MediumChestRight,
            GameObject.Act2LargeChestRight,
            GameObject.Act2LargeChestLeft,
            GameObject.GuardCorpse,
            GameObject.HiddenStashRock,
            GameObject.SkeletonCorpseIsAnOxymoron,
            GameObject.HiddenStashRockB,
            GameObject.HollowLog,
            GameObject.SkeletonCorpseIsStillAnOxymoron,
            GameObject.LooseRock,
            GameObject.LooseBoulder,
            GameObject.MediumChestLeft,
            GameObject.LargeChestLeft2,
            GameObject.GuardCorpseOnAStick,
            GameObject.JungleChest,
            GameObject.TombCoffin,
            GameObject.JungleMediumChestLeft,
            GameObject.JungleStashObject1,
            GameObject.JungleStashObject2,
            GameObject.JungleStashObject3,
            GameObject.JungleStashObject4,
            GameObject.TallChestLeft,
            GameObject.MephistoLair,
            GameObject.StashBox,
            GameObject.StashAltar,
            GameObject.Cocoon,
            GameObject.Cocoon2,
            GameObject.SkullPileH1,
            GameObject.Gchest1L,
            GameObject.Gchest2R,
            GameObject.Gchest3R,
            GameObject.GLchest3L,
            GameObject.SewersRatNest,
            GameObject.Act1BedBed1,
            GameObject.Act1BedBed2,
            GameObject.MaggotLairGooPile,
            GameObject.WirtCorpse,
            GameObject.GuardCorpse2,
            GameObject.DeadVillager1,
            GameObject.DeadVillager2,
            GameObject.TinyPixelShapedThingie,
            GameObject.Act2TombAnubisCoffin,
            GameObject.HaremDeadGuard1,
            GameObject.HaremDeadGuard2,
            GameObject.HaremDeadGuard3,
            GameObject.HaremDeadGuard4,
            GameObject.Act3SewerDeadBody,
            GameObject.MafistoLargeChestLeft,
            GameObject.MafistoLargeChestRight,
            GameObject.MafistoMediumChestLeft,
            GameObject.MafistoMediumChestRight,
            GameObject.SpiderLairLargeChestLeft,
            GameObject.SpiderLairTallChestLeft,
            GameObject.SpiderLairMediumChestRight,
            GameObject.SpiderLairTallChestRight,
            GameObject.HoradricCubeChest,
            GameObject.HoradricScrollChest,
            GameObject.StaffOfKingsChest,
            GameObject.DungeonRockPile,
            GameObject.LargeChestR,
            GameObject.InnerHellBoneChest,
            GameObject.BurningTrappedSoul1,
            GameObject.BurningTrappedSoul2,
            GameObject.StuckedTrappedSoul1,
            GameObject.StuckedTrappedSoul2,
            GameObject.ArcaneLargeChestLeft,
            GameObject.ArcaneCasket,
            GameObject.ArcaneLargeChestRight,
            GameObject.ArcaneSmallChestLeft,
            GameObject.ArcaneSmallChestRight,
            GameObject.SparklyChest,
            GameObject.KhalimChest1,
            GameObject.KhalimChest2,
            GameObject.KhalimChest3,
            GameObject.ExpansionChestRight,
            GameObject.ExpansionHiddenStash,
            GameObject.ExpansionWoodChestLeft,
            GameObject.BurialChestLeft,
            GameObject.BurialChestRight,
            GameObject.ExpansionChestLeft,
            GameObject.ExpansionWoodChestRight,
            GameObject.ExpansionSmallChestLeft,
            GameObject.ExpansionSmallChestRight,
            GameObject.ExpansionExplodingChest,
            GameObject.ExpansionSpecialChest,
            GameObject.IceCaveHiddenStash,
            GameObject.IceCaveEvilUrn,
            GameObject.WorldstoneTomb1,
            GameObject.WorldstoneTomb2,
            GameObject.WorldstoneTomb3,
            GameObject.ExpansionSnowyWoodChestLeft,
            GameObject.ExpansionSnowyWoodChestRight,
            GameObject.ExpansionSnowyWoodChest2Left,
            GameObject.ExpansionSnowyWoodChest2Right,
            GameObject.WorldstoneMrBox,
            GameObject.WorldstoneTomb1Left,
            GameObject.WorldstoneTomb2Left,
            GameObject.WorldstoneTomb3Left,
            GameObject.RedBaalsLairTomb1,
            GameObject.RedBaalsLairTomb1Left,
            GameObject.RedBaalsLairTomb2,
            GameObject.RedBaalsLairTomb2Left,
            GameObject.RedBaalsLairTomb3,
            GameObject.RedBaalsLairTomb3Left,
            GameObject.RedBaalsLairMrBox,
            GameObject.ExpansionDeadPerson1,
            GameObject.TempleGroundTomb,
            GameObject.TempleGroundTombLeft,
            GameObject.ExpansionDeadPerson2,
            GameObject.ExpansionDeadPerson3,
            GameObject.GoodChest,
            GameObject.NotSoGoodChest
        };

        [Flags]
        public enum InteractFlags
        {
            None = 0x00,
            Trap = 0x04,
            Locked = 0x80
        }
    }
}
