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

using System;
using System.IO;
using System.Text;

namespace MapAssist.Files
{
    public class FileManager
    {
        private static readonly NLog.Logger _log = NLog.LogManager.GetCurrentClassLogger();
        private string _filePathRelative;
        private string _fullPath;

        public FileManager(string fileName)
        {
            _filePathRelative = fileName;
            _fullPath = System.IO.Directory.GetCurrentDirectory() + _filePathRelative.Substring(1);
        }

        public string GetPath() { return _filePathRelative; }
        public string GetAbsolutePath() { return _fullPath; }
        public bool FileExists()
        {
            return System.IO.File.Exists(_fullPath);
        }

        public void CreateFile()
        {
            if (FileExists())
            {
                throw new Exception($"Trying to create {_fullPath} even though file exists..");
            }

            try
            {
                System.IO.File.Create(_fullPath).Close();
            }
            catch (Exception e)
            {
                throw new Exception($"Trying to create {_fullPath} : {e.Message}");
            }
        }

        public void DeleteFile()
        {
            try
            {
                if (FileExists())
                {
                    System.IO.File.Delete(_fullPath);
                    _log.Debug($"Removed {_fullPath}");
                }
            }
            catch (Exception e)
            {
                _log.Debug(e, $"Tried to remove {_fullPath} but got error.");
            }
        }

        public string ReadFile()
        {
            var sb = new StringBuilder();
            try
            {
                // Open the file to read from.
                using (StreamReader sr = File.OpenText(GetPath()))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        sb.Append($"{s}\n");
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                _log.Debug(e, $"The file {_filePathRelative} could not be read.");
            }
            if (sb.ToString().Length == 0)
            {
                _log.Debug($"The file {_filePathRelative} was empty...");
            }

            return sb.ToString();
        }

        public bool WriteFile(string content)
        {
            try
            {
                using (StreamWriter sw = File.CreateText(_filePathRelative))
                {
                    sw.WriteLine(content);
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                _log.Debug(e, $"The file {_filePathRelative} could not be written.");
                return false;
            }
            return true;
        }
    }
}
