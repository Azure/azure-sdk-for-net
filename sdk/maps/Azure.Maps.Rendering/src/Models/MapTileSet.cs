// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;
using Azure.Core.GeoJson;

// cspell:ignore tilejson
namespace Azure.Maps.Rendering
{
    /// <summary> Metadata for a tileset in the TileJSON format. </summary>
    [CodeGenSerialization(nameof(TileJsonVersion), "tileJson")]
    [CodeGenSerialization(nameof(MinZoomLevel), "minZoom")]
    [CodeGenSerialization(nameof(MaxZoomLevel), "maxZoom")]
    [CodeGenModel("MapTileset")]
    public partial class MapTileSet
    {
        /// <summary> Initializes a new instance of MapTileSet. </summary>
        /// <param name="tileJsonVersion"> Describes the version of the TileJSON spec that is implemented by this JSON object. </param>
        /// <param name="name"> A name describing the tileset. The name can contain any legal character. Implementations SHOULD NOT interpret the name as HTML. </param>
        /// <param name="description"> Text description of the tileset. The description can contain any legal character. Implementations SHOULD NOT interpret the description as HTML. </param>
        /// <param name="version"> A semver.org style version number for the tiles contained within the tileset. When changes across tiles are introduced, the minor version MUST change. </param>
        /// <param name="attribution"> Copyright attribution to be displayed on the map. Implementations MAY decide to treat this as HTML or literal text. For security reasons, make absolutely sure that this field can't be abused as a vector for XSS or beacon tracking. </param>
        /// <param name="template"> A mustache template to be used to format data from grids for interaction. </param>
        /// <param name="legend"> A legend to be displayed with the map. Implementations MAY decide to treat this as HTML or literal text. For security reasons, make absolutely sure that this field can't be abused as a vector for XSS or beacon tracking. </param>
        /// <param name="scheme"> Default: &quot;xyz&quot;. Either &quot;xyz&quot; or &quot;tms&quot;. Influences the y direction of the tile coordinates. The global-mercator (aka Spherical Mercator) profile is assumed. </param>
        /// <param name="tiles"> An array of tile endpoints. If multiple endpoints are specified, clients may use any combination of endpoints. All endpoints MUST return the same content for the same URL. The array MUST contain at least one endpoint. </param>
        /// <param name="grids"> An array of interactivity endpoints. </param>
        /// <param name="data"> An array of data files in GeoJSON format. </param>
        /// <param name="minZoom"> The minimum zoom level. </param>
        /// <param name="maxZoom"> The maximum zoom level. </param>
        /// <param name="bounds"> The maximum extent of available map tiles. Bounds MUST define an area covered by all zoom levels. The bounds are represented in WGS:84 latitude and longitude values, in the order left, bottom, right, top. Values may be integers or floating point numbers. </param>
        /// <param name="center"> The default location of the tileset in the form [longitude, latitude, zoom]. The zoom level MUST be between minzoom and maxzoom. Implementations can use this value to set the default location. </param>
        internal MapTileSet(string tileJsonVersion, string name, string description, string version, string attribution, string template, string legend, string scheme, IReadOnlyList<string> tiles, IReadOnlyList<string> grids, IReadOnlyList<string> data, int? minZoom, int? maxZoom, IReadOnlyList<float> bounds, IReadOnlyList<float> center)
        {
            TileJsonVersion = tileJsonVersion;
            TileSetName = name;
            TileSetDescription = description;
            TileSetVersion = version;
            CopyrightAttribution = attribution;
            Template = template;
            MapTileLegend = legend;
            SchemeInternal = scheme;
            TileScheme = new MapTileScheme(SchemeInternal);
            TileEndpoints = tiles;
            Grids = grids;
            GeoJsonDataFiles = data;
            MinZoomLevel = minZoom;
            MaxZoomLevel = maxZoom;
            BoundsInternal = bounds;
            if (bounds != null && bounds.Count >= 4)
            {
                BoundingBox = new GeoBoundingBox(bounds[0], bounds[1], bounds[2], bounds[3]);
            }

            CenterInternal = center;
            if (center != null && center.Count >= 3)
            {
                CenterTileIndex = new MapTileIndex(
                    (int)Math.Floor(center[0]),
                    (int)Math.Floor(center[1]),
                    (int)Math.Floor(center[2])
                );
            }
        }

        /// <summary> Describes the version of the TileJSON spec that is implemented by this JSON object. </summary>
        [CodeGenMember("Tilejson")]
        public string TileJsonVersion { get; }
        /// <summary> A name describing the tileset. The name can contain any legal character. Implementations SHOULD NOT interpret the name as HTML. </summary>
        [CodeGenMember("Name")]
        public string TileSetName { get; }
        /// <summary> Text description of the tileset. The description can contain any legal character. Implementations SHOULD NOT interpret the description as HTML. </summary>
        [CodeGenMember("Description")]
        public string TileSetDescription { get; }
        /// <summary> A semver.org style version number for the tiles contained within the tileset. When changes across tiles are introduced, the minor version MUST change. </summary>
        [CodeGenMember("Version")]
        public string TileSetVersion { get; }
        /// <summary> Copyright attribution to be displayed on the map. Implementations MAY decide to treat this as HTML or literal text. For security reasons, make absolutely sure that this field can't be abused as a vector for XSS or beacon tracking. </summary>
        [CodeGenMember("Attribution")]
        public string CopyrightAttribution { get; }
        /// <summary> A mustache template to be used to format data from grids for interaction. </summary>
        [CodeGenMember("Template")]
        internal string Template { get; }
        /// <summary> A legend to be displayed with the map. Implementations MAY decide to treat this as HTML or literal text. For security reasons, make absolutely sure that this field can't be abused as a vector for XSS or beacon tracking. </summary>
        [CodeGenMember("Legend")]
        public string MapTileLegend { get; }
        /// <summary> Default: <c>xyz</c>. Either <c>xyz</c>; or <c>tms</c>;. Influences the y direction of the tile coordinates. The global-mercator (aka Spherical Mercator) profile is assumed. </summary>
        [CodeGenMember("Scheme")]
        internal string SchemeInternal { get; }
        /// <summary> Default: <c>xyz</c>. Either <c>xyz</c>; or <c>tms</c>;. Influences the y direction of the tile coordinates. The global-mercator (aka Spherical Mercator) profile is assumed. </summary>
        public MapTileScheme TileScheme { get; }
        /// <summary> An array of tile endpoints. If multiple endpoints are specified, clients may use any combination of endpoints. All endpoints MUST return the same content for the same URL. The array MUST contain at least one endpoint. </summary>
        [CodeGenMember("Tiles")]
        public IReadOnlyList<string> TileEndpoints { get; }
        /// <summary> An array of interactivity endpoints. </summary>
        [CodeGenMember("Grids")]
        internal IReadOnlyList<string> Grids { get; }
        /// <summary> An array of data files in GeoJSON format. </summary>
        [CodeGenMember("Data")]
        public IReadOnlyList<string> GeoJsonDataFiles { get; }
        /// <summary> The minimum zoom level. </summary>
        [CodeGenMember("MinZoom")]
        public int? MinZoomLevel { get; }
        /// <summary> The maximum zoom level. </summary>
        [CodeGenMember("MaxZoom")]
        public int? MaxZoomLevel { get; }
        /// <summary> The maximum extent of available map tiles. Bounds MUST define an area covered by all zoom levels. The bounds are represented in WGS:84 latitude and longitude values, in the order left, bottom, right, top. Values may be integers or floating point numbers. </summary>
        [CodeGenMember("Bounds")]
        internal IReadOnlyList<float> BoundsInternal { get; }
        /// <summary> The maximum extent of available map tiles. Bounds MUST define an area covered by all zoom levels. The bounds are represented in WGS:84 latitude and longitude values, in the order left, bottom, right, top. Values may be integers or floating point numbers. </summary>
        public GeoBoundingBox? BoundingBox { get; }

        /// <summary> The default location of the tileset in the form [longitude, latitude, zoom]. The zoom level MUST be between minzoom and maxzoom. Implementations can use this value to set the default location. </summary>
        [CodeGenMember("Center")]
        private IReadOnlyList<float> CenterInternal { get; }
        /// <summary> The default location of the tileset in the form [longitude, latitude, zoom]. The zoom level MUST be between minzoom and maxzoom. Implementations can use this value to set the default location. </summary>
        public MapTileIndex? CenterTileIndex { get; }
    }
}
