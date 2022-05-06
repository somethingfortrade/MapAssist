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

using MapAssist.Settings;
using MapAssist.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MapAssist
{
    public partial class AddAreaForm : Form
    {
        public string listToAddTo;
        public AddAreaForm()
        {
            InitializeComponent();
        }

        private void AddAreaForm_Load(object sender, EventArgs e)
        {
            var areas = new Dictionary<Area, string>();

            foreach (var area in Enum.GetValues(typeof(Area)).Cast<Area>())
            {
                if (area != Area.None && AreaExtensions.IsValid(area) && !MapAssistConfiguration.Loaded.HiddenAreas.Contains(area))
                {
                    areas.Add(area, AreaExtensions.Name(area));
                }
            }

            lstAreas.DataSource = new BindingSource(areas, null);
            lstAreas.ValueMember = "Key";
            lstAreas.DisplayMember = "Value";
        }

        private void AddSelectedArea(Area areaToAdd)
        {
            var areaName = areaToAdd.NameInternal();

            var formParent = (ConfigEditor)Owner;
            var list = formParent.Controls.Find(listToAddTo, true).FirstOrDefault() as ListBox;
            if (!list.Items.Contains(areaName))
            {
                list.Items.Add(areaName);
                switch (listToAddTo)
                {
                    case "lstHidden":
                        MapAssistConfiguration.Loaded.HiddenAreas = MapAssistConfiguration.Loaded.HiddenAreas.Append(areaToAdd).ToArray();
                        break;
                }
                Close();
            }
        }

        private void btnAddArea_Click(object sender, EventArgs e)
        {
            var areaToAdd = (Area)lstAreas.SelectedValue;
            AddSelectedArea(areaToAdd);
        }

        private void lstAreas_MouseDoubleClick(object sender, EventArgs e)
        {
            var areaToAdd = (Area)lstAreas.SelectedValue;
            AddSelectedArea(areaToAdd);
        }
    }
}
