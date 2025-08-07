// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.Maps.Common;

namespace Azure.Maps.Rendering
{
    /// <summary> Options for rendering tiles. </summary>
    public class GetMapTileOptions
    {
        /// <summary> GetMapTileOptions constructor. </summary>
        /// <param name="mapTileSetId"> The options for configuring the static image. </param>
        /// <param name="mapTileIndex"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mapTileSetId"/> or <paramref name="mapTileIndex"/> is null. </exception>
        public GetMapTileOptions(MapTileSetId mapTileSetId, MapTileIndex mapTileIndex)
        {
            Argument.AssertNotNull(mapTileSetId, nameof(mapTileSetId));
            Argument.AssertNotNull(mapTileIndex, nameof(mapTileIndex));

            MapTileSetId = mapTileSetId;
            MapTileIndex = mapTileIndex;
        }

        /// <summary> A tileset is a collection of raster or vector data broken up into a uniform grid of square tiles at preset zoom levels. Every tileset has a <see cref="MapTileSetId"/> to use when making requests. The <see cref="MapTileSetId"/> for tilesets created using <see href="https://aka.ms/amcreator">Azure Maps Creator</see> are generated through the <see href="https://docs.microsoft.com/rest/api/maps-creator/tileset">Tileset Create API</see>. The ready-to-use tilesets supplied by Azure Maps are listed below. For example, <c>microsoft.base</c>. </summary>
        public MapTileSetId MapTileSetId { get; }
        /// <summary>
        /// Zoom level, and coordinate of the tile on zoom grid.
        /// The value of X and Y coordinate in <see cref="MapTileIndex"/> must be in the range [0, (2^zoom)-1]].
        /// Please see <see href="https://docs.microsoft.com/azure/location-based-services/zoom-levels-and-tile-grid">Zoom Levels and Tile Grid</see> for details.
        /// </summary>
        public MapTileIndex MapTileIndex { get; }
        /// <summary>
        /// The desired date and time of the requested tile. This parameter must be specified in the standard date-time format (e.g. 2019-11-14T16:03:00-08:00), as defined by <see href="https://en.wikipedia.org/wiki/ISO_8601">ISO 8601</see>. This parameter is only supported when <see cref="MapTileSetId"/> option is set to one of the values below.
        /// <list type="bullet">
        /// <item> <c>microsoft.weather.infrared.main</c>: We provide tiles up to 3 hours in the past. Tiles are available in 10-minute intervals. We round the timeStamp value to the nearest 10-minute time frame. </item>
        /// <item> <c>microsoft.weather.radar.main</c>: We provide tiles up to 1.5 hours in the past and up to 2 hours in the future. Tiles are available in 5-minute intervals. We round the timeStamp value to the nearest 5-minute time frame. </item>
        /// </list>
        /// </summary>
        public DateTimeOffset? TimeStamp { get; set; }
        /// <summary>
        /// The size of the returned map tile in pixels. Possible value: <see cref="MapTileSize.Size256"/> and <see cref="MapTileSize.Size512"/>
        /// </summary>
        public MapTileSize? MapTileSize { get; set; }
        /// <summary>
        /// Language in which search results should be returned. Should be one of supported IETF language tags, case insensitive. When data in specified language is not available for a specific field, default language is used.
        /// Please refer to <see href="https://docs.microsoft.com/azure/azure-maps/supported-languages">Supported Languages</see> for details.
        /// </summary>
        public RenderingLanguage? Language { get; set; }
        /// <summary>
        /// The View parameter (also called the "user region" parameter) allows you to show the correct maps for a certain country/region for geopolitically disputed regions. Different countries have different views of such regions, and the View parameter allows your application to comply with the view required by the country your application will be serving. By default, the View parameter is set to “Unified” even if you haven’t defined it in  the request. It is your responsibility to determine the location of your users, and then set the View parameter correctly for that location. Alternatively, you have the option to set ‘View=Auto’, which will return the map data based on the IP  address of the request. The View parameter in Azure Maps must be used in compliance with applicable laws, including those  regarding mapping, of the country where maps, images and other data and third party content that you are authorized to  access via Azure Maps is made available. Example: view=IN.
        /// Please refer to <see href="https://aka.ms/AzureMapsLocalizationViews">Supported Views</see> for details and to see the available Views.
        /// </summary>
        public Azure.Maps.LocalizedMapView? LocalizedMapView { get; set; }
    }
}
