// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Maps.Render
{
    /// <summary> Parameter group. </summary>
    public partial class TileIndex
    {
        /// <summary> Initializes a new instance of TileIndex. </summary>
        /// <param name="x">
        /// X coordinate of the tile on zoom grid. Value must be in the range [0, 2&lt;sup&gt;`zoom`&lt;/sup&gt; -1].
        ///
        /// Please see <see href="https://docs.microsoft.com/en-us/azure/location-based-services/zoom-levels-and-tile-grid">Zoom Levels and Tile Grid</see> for details.
        /// </param>
        /// <param name="y">
        /// Y coordinate of the tile on zoom grid. Value must be in the range [0, 2&lt;sup&gt;`zoom`&lt;/sup&gt; -1].
        ///
        /// Please see <see href="https://docs.microsoft.com/en-us/azure/location-based-services/zoom-levels-and-tile-grid">Zoom Levels and Tile Grid</see> for details.
        /// </param>
        /// <param name="z">
        /// Zoom level for the desired tile.
        ///
        /// Please see <see href="https://docs.microsoft.com/en-us/azure/location-based-services/zoom-levels-and-tile-grid">Zoom Levels and Tile Grid</see> for details.
        /// </param>
        public TileIndex(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
