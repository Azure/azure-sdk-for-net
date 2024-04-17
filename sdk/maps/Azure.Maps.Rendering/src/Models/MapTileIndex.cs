// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.Maps.Rendering
{
    /// <summary> Parameter group. </summary>
    [CodeGenModel("TileIndex")]
    public partial class MapTileIndex
    {
        /// <summary> Initializes a new instance of MapTileIndex. </summary>
        /// <param name="x">
        /// X coordinate of the tile on zoom grid. Value must be in the range [0, (2^zoom)-1]].
        /// Please see <see href="https://docs.microsoft.com/azure/location-based-services/zoom-levels-and-tile-grid">Zoom Levels and Tile Grid</see> for details.
        /// </param>
        /// <param name="y">
        /// Y coordinate of the tile on zoom grid. Value must be in the range [0, (2^zoom)-1]].
        /// Please see <see href="https://docs.microsoft.com/azure/location-based-services/zoom-levels-and-tile-grid">Zoom Levels and Tile Grid</see> for details.
        /// </param>
        /// <param name="z">
        /// Zoom level for the desired tile.
        /// Please see <see href="https://docs.microsoft.com/azure/location-based-services/zoom-levels-and-tile-grid">Zoom Levels and Tile Grid</see> for details.
        /// </param>
        public MapTileIndex(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
