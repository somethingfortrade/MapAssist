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

using MapAssist.Types;
using System.Collections.Generic;

namespace MapAssist.Helpers
{
    public class GameDataReader
    {
        private static readonly NLog.Logger _log = NLog.LogManager.GetCurrentClassLogger();
        private volatile GameData _gameData;
        private AreaData _areaData;
        private List<PointOfInterest> _pointsOfInterest;
        private MapApi _mapApi;

        public (GameData, AreaData, List<PointOfInterest>, bool) Get()
        {
            var gameData = GameMemory.GetGameData();
            var changed = false;

            if (gameData != null)
            {
                if (gameData.HasGameChanged(_gameData))
                {
                    _log.Info($"Game changed to {gameData.Difficulty} with {gameData.MapSeed} seed");
                    _mapApi = new MapApi(gameData.Difficulty, gameData.MapSeed);
                }

                if (gameData.HasMapChanged(_gameData) && gameData.Area != Area.None)
                {
                    _log.Info($"Area changed to {gameData.Area}");
                    _areaData = _mapApi.GetMapData(gameData.Area);

                    if (_areaData != null)
                    {
                        _pointsOfInterest = PointOfInterestHandler.Get(_mapApi, _areaData, gameData);
                        _log.Info($"Found {_pointsOfInterest.Count} points of interest");
                    }
                    else
                    {
                        _log.Info($"Area data not loaded");
                    }

                    changed = true;
                }
            }

            _gameData = gameData;

            return (_gameData, _areaData, _pointsOfInterest, changed);
        }
    }
}
