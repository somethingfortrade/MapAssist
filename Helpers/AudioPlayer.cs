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
using System;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;

namespace MapAssist.Helpers
{
    public class AudioPlayer
    {
        private static DateTime _itemAlertLastPlayed = DateTime.MinValue;
        private static SoundPlayer _itemAlertPlayer = null;

        public static void PlayItemAlert()
        {
            LoadNewSound();
            var now = DateTime.Now;
            if (now - _itemAlertLastPlayed >= TimeSpan.FromSeconds(1))
            {
                SetSoundVolume();
                _itemAlertLastPlayed = now;
                try
                {
                    _itemAlertPlayer.Play();
                }
                catch
                {
                    _itemAlertPlayer = new SoundPlayer(Properties.Resources.Ching);
                    _itemAlertPlayer.Play();
                }
            }
        }

        public static void LoadNewSound(bool ignoreIfAlreadyLoaded = false)
        {
            if (ignoreIfAlreadyLoaded)
            {
                _itemAlertPlayer = new SoundPlayer(Properties.Resources.Ching);
            }

            if (!string.IsNullOrEmpty(MapAssistConfiguration.Loaded.ItemLog.SoundFile) && (_itemAlertPlayer == null || ignoreIfAlreadyLoaded))
            {
                var exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                var directory = Path.GetDirectoryName(exePath);
                var soundPath = Path.Combine(directory, MapAssistConfiguration.Loaded.ItemLog.SoundFile);
                _itemAlertPlayer = new SoundPlayer(soundPath);
                Console.Write("Loaded new sound file");
            }
            if (_itemAlertPlayer == null) { _itemAlertPlayer = new SoundPlayer(Properties.Resources.Ching); }
        }

        private static void SetSoundVolume()
        {
            var NewVolume = (ushort.MaxValue * Math.Max(Math.Min(MapAssistConfiguration.Loaded.ItemLog.SoundVolume, 100), 0) / 100);
            var NewVolumeAllChannels = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));
            waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);
        }

        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);
    }
}
