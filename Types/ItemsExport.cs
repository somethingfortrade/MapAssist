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


using System.Collections.Generic;

namespace MapAssist.Types
{
    public class Affix
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class JSONItem
    {
        public uint txtFileNo { get; set; }
        public string baseName { get; set; }
        public string quality { get; set; }
        public string fullName { get; set; }
        public bool ethereal { get; set; }
        public bool identified { get; set; }
        public int numSockets { get; set; }
        public Position position { get; set; }
        public string bodyLoc { get; set; }
        public List<Affix> affixes { get; set; }
    }

    public class Position
    {
        public uint x { get; set; }
        public uint y { get; set; }
    }

    public class ExportedItems
    {
        public List<UnitItem> equipped { get; set; }
        public List<UnitItem> inventory { get; set; }
        public List<UnitItem> mercenary { get; set; }
        public List<UnitItem> cube { get; set; }
        public List<UnitItem> personalStash { get; set; }
        public List<UnitItem> sharedStashTab1 { get; set; }
        public List<UnitItem> sharedStashTab2 { get; set; }
        public List<UnitItem> sharedStashTab3 { get; set; }
    }
}
