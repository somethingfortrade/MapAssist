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

using MapAssist.Helpers;
using MapAssist.Settings;
using MapAssist.Structs;
using System;
using System.Drawing;

namespace MapAssist.Types
{
    public class UnitItem : UnitAny
    {
        public ItemData ItemData { get; private set; }
        public new bool IsPlayerOwned { get; set; } = false;
        public Npc VendorOwner { get; set; } = Npc.Invalid;
        public Item Item => (Item)TxtFileNo;
        public ItemMode ItemMode => (ItemMode)Struct.Mode;
        public string ItemBaseName => Items.GetItemBaseName(this);
        public Color ItemBaseColor => Items.GetItemBaseColor(this);

        public UnitItem(IntPtr ptrUnit) : base(ptrUnit)
        {
        }

        public new UnitItem Update()
        {
            if (base.Update() == UpdateResult.InvalidUpdate) return this;

            if (IsValidUnit && MapAssistConfiguration.Loaded.ItemLog.Enabled)
            {
                using (var processContext = GameManager.GetProcessContext())
                {
                    ItemData = processContext.Read<ItemData>(Struct.pUnitData);
                }
            }

            return this;
        }

        private bool _isInvalid = false;

        public void MarkValid() => _isInvalid = false;

        public void MarkInvalid() => _isInvalid = true;

        public bool IsValidItem => !_isInvalid && UnitId != uint.MaxValue;

        public bool IsIdentified => ItemData.ItemQuality >= ItemQuality.MAGIC && (ItemData.ItemFlags & ItemFlags.IFLAG_IDENTIFIED) == ItemFlags.IFLAG_IDENTIFIED;

        public bool IsIdentifiedForLog { get; set; }

        public bool IsDropped => ItemModeMapped == ItemModeMapped.Ground;

        public bool IsInStore => ItemModeMapped == ItemModeMapped.Vendor;

        public bool IsInSocket => ItemModeMapped == ItemModeMapped.Socket;

        public StashTab StashTab { get; set; } = StashTab.None;

        public bool IsAnyPlayerHolding
        {
            get
            {
                switch (ItemModeMapped)
                {
                    case ItemModeMapped.Belt:
                    case ItemModeMapped.Inventory:
                    case ItemModeMapped.Cube:
                    case ItemModeMapped.Stash:
                    case ItemModeMapped.Player:
                    case ItemModeMapped.Mercenary:
                        return true;
                }
                return false;
            }
        }

        public ItemModeMapped ItemModeMapped
        {
            get
            {
                switch (ItemMode)
                {
                    case ItemMode.INBELT: return ItemModeMapped.Belt;
                    case ItemMode.DROPPING: return ItemModeMapped.Ground;
                    case ItemMode.ONGROUND: return ItemModeMapped.Ground;
                    case ItemMode.SOCKETED: return ItemModeMapped.Socket;
                    case ItemMode.EQUIP:
                        if (ItemData.dwOwnerID != uint.MaxValue) return ItemModeMapped.Player;
                        else return ItemModeMapped.Mercenary;
                }

                if (ItemData.dwOwnerID == uint.MaxValue && (ItemData.ItemFlags & ItemFlags.IFLAG_INSTORE) == ItemFlags.IFLAG_INSTORE && ItemData.InvPage != InvPage.NULL) return ItemModeMapped.Vendor;
                if (ItemData.dwOwnerID == uint.MaxValue) return ItemModeMapped.Selected;
                if (ItemData.dwOwnerID != uint.MaxValue && ItemData.InvPage == InvPage.EQUIP) return ItemModeMapped.Trade; // Other player's trade window

                switch (ItemData.InvPage)
                {
                    case InvPage.INVENTORY: return ItemModeMapped.Inventory;
                    case InvPage.TRADE: return ItemModeMapped.Trade;
                    case InvPage.CUBE: return ItemModeMapped.Cube;
                    case InvPage.STASH: return ItemModeMapped.Stash;
                }

                return ItemModeMapped.Unknown; // Items that appeared in the trade window before will appear here
            }
        }

        public override string HashString => Item + "/" + Position.X + "/" + Position.Y;
    }
}
