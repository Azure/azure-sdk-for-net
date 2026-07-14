// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;

namespace Azure.Maps.Rendering
{
    /// <summary> Model factory for models. </summary>
    public static partial class MapsRenderingModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="MapTileSet"/> for mocking. </summary>
        /// <param name="tileJsonVersion"> Describes the version of the TileJSON spec that is implemented by this JSON object. </param>
        /// <param name="name"> A name describing the tileset. </param>
        /// <param name="description"> Text description of the tileset. </param>
        /// <param name="version"> A semver.org style version number for the tiles contained within the tileset. </param>
        /// <param name="attribution"> Copyright attribution to be displayed on the map. </param>
        /// <param name="template"> A mustache template to be used to format data from grids for interaction. </param>
        /// <param name="legend"> A legend to be displayed with the map. </param>
        /// <param name="scheme"> Influences the y direction of the tile coordinates. </param>
        /// <param name="tiles"> An array of tile endpoints. </param>
        /// <param name="grids"> An array of interactivity endpoints. </param>
        /// <param name="data"> An array of data files in GeoJSON format. </param>
        /// <param name="minZoom"> The minimum zoom level. </param>
        /// <param name="maxZoom"> The maximum zoom level. </param>
        /// <param name="bounds"> The maximum extent of available map tiles. </param>
        /// <param name="center"> The default location of the tileset in the form [longitude, latitude, zoom]. </param>
        /// <returns> A new <see cref="MapTileSet"/> instance for mocking. </returns>
        public static MapTileSet MapTileSet(string tileJsonVersion = null, string name = null, string description = null, string version = null, string attribution = null, string template = null, string legend = null, string scheme = null, IEnumerable<string> tiles = null, IEnumerable<string> grids = null, IEnumerable<string> data = null, int? minZoom = null, int? maxZoom = null, IEnumerable<float> bounds = null, IEnumerable<float> center = null)
        {
            tiles ??= new List<string>();
            grids ??= new List<string>();
            data ??= new List<string>();
            bounds ??= new List<float>();
            center ??= new List<float>();
            return new MapTileSet(tileJsonVersion, name, description, version, attribution, template, legend, scheme, tiles.ToList(), grids.ToList(), data.ToList(), minZoom, maxZoom, bounds.ToList(), center.ToList());
        }
    }
}
