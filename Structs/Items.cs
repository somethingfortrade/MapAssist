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

using GameOverlay.Drawing;
using MapAssist.Types;
using System;
using System.Runtime.InteropServices;

namespace MapAssist.Structs
{
    public struct Item
    {
        public Point Position;
        public uint UnitId;
        public ItemQuality Quality;
        public ItemFlags Flags;
        public string BaseItemName;
        public ItemMode Mode;
    }
    [StructLayout(LayoutKind.Explicit)]
    public struct ItemInventory
    {
        [FieldOffset(0x20)] public IntPtr InvGridPtr;
    }
    [StructLayout(LayoutKind.Explicit)]
    public struct ItemData
    {
        [FieldOffset(0x00)] public ItemQuality ItemQuality;
        //[FieldOffset(0x0C)] public StashType StashType; //only works for offline character
        [FieldOffset(0x0C)] public uint dwOwnerID; //which unitId owns this item (online only) - otherwise 0 = body, 1 = personal stash, 2 = sharedstash1, 3 = sharedstash2, 4 = sharedstash3, 5 = belt
        [FieldOffset(0x18)] public ItemFlags ItemFlags;
        [FieldOffset(0x34)] public uint uniqueOrSetId;
        [FieldOffset(0x54)] public BodyLoc BodyLoc;
        [FieldOffset(0x55)] public InvPage InvPage;
        [FieldOffset(0x70)] public IntPtr InvPtr;
        //[FieldOffset(0x88)] public byte nodePos; // char?
        //[FieldOffset(0x89)] public byte nodePosOther; // char?
    }
}
