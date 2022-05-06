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

using SharpDX.DirectWrite;
using System;

namespace MapAssist.Files.Font
{
    class FormalFont
    {
        SharpDX.Direct2D1.Factory _factory2D;
        SharpDX.DirectWrite.Factory _factoryDWrite;
        ResourceFontLoader _resourceFontLoader;
        FontCollection _fontCollection { get; set; }

        public string FontFamilyName { get; set; }

        public FormalFont()
        {
            try
            {
                InitDirect2DAndDirectWrite();
                InitCustomFont();
                FontFamilyName = "Formal 436";
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load Formal Font");
            }
        }

        /// <summary>
        /// Inits the direct2D and direct write.
        /// </summary>
        private void InitDirect2DAndDirectWrite()
        {
            _factory2D = new SharpDX.Direct2D1.Factory();
            _factoryDWrite = new SharpDX.DirectWrite.Factory();
        }

        /// <summary>
        /// Inits the custom font.
        /// </summary>
        private void InitCustomFont()
        {
            _resourceFontLoader = new ResourceFontLoader(_factoryDWrite);
            _fontCollection = new FontCollection(_factoryDWrite, _resourceFontLoader, _resourceFontLoader.Key);
        }

        public GameOverlay.Drawing.Font CreateFont(float size)
        {
            return new GameOverlay.Drawing.Font(new TextFormat(_factoryDWrite, FontFamilyName, _fontCollection,
                FontWeight.Regular, FontStyle.Normal, FontStretch.Normal, size));
        }
    }
}
