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

namespace MapAssist.Types
{
    public class UnitObject : UnitAny
    {
        public ObjectData ObjectData { get; private set; }
        private ObjectTxt ObjectText { get; set; }
        public GameObject GameObject => (GameObject)TxtFileNo;

        public UnitObject(IntPtr ptrUnit) : base(ptrUnit)
        {
        }

        public new UnitObject Update()
        {
            if (base.Update() == UpdateResult.Updated)
            {
                using (var processContext = GameManager.GetProcessContext())
                {
                    ObjectData = processContext.Read<ObjectData>(Struct.pUnitData);

                    if (ObjectData.pObjectTxt != IntPtr.Zero)
                    {
                        ObjectText = processContext.Read<ObjectTxt>(ObjectData.pObjectTxt);
                    }
                }
            }

            return this;
        }

        public bool IsPortal
        {
            get
            {
                var name = Enum.GetName(typeof(GameObject), GameObject);
                return ((!string.IsNullOrWhiteSpace(name) && name.Contains("Portal") && GameObject != GameObject.WaypointPortal) || GameObject == GameObject.HellGate);
            }
        }

        public bool IsWaypoint => GameObject.IsWaypoint();

        public bool IsShrine => UnitType == UnitType.Object && ObjectData.pShrineTxt != IntPtr.Zero && ObjectData.InteractType <= (byte)ShrineType.Poison;

        public bool IsWell => UnitType == UnitType.Object && ObjectData.pObjectTxt != IntPtr.Zero && ObjectText.ObjectType == "Well";

        public bool IsChest => UnitType == UnitType.Object && ObjectData.pObjectTxt != IntPtr.Zero && Struct.Mode == 0 && Chest.NormalChests.Contains(GameObject);

        public override string HashString => GameObject + "/" + Position.X + "/" + Position.Y;
    }
}
