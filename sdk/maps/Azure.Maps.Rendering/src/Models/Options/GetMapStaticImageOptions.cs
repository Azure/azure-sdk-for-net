// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core.GeoJson;

namespace Azure.Maps.Rendering
{
    /// <summary> Options for rendering static images. </summary>
    public class GetMapStaticImageOptions
    {
        /// <summary> Render static image options with bounding box. </summary>
        /// <param name="boundingBox"> Minimum coordinates (west, south, east, north) of bounding box in latitude longitude coordinate system. </param>
        /// <param name="imagePushpinStyles"> Add pushpins with styling on the map image. </param>
        /// <param name="imagePathStyles"> Add paths with styling on the map image. </param>
        public GetMapStaticImageOptions(GeoBoundingBox boundingBox, IList<ImagePushpinStyle> imagePushpinStyles = null, IList<ImagePathStyle> imagePathStyles = null)
        {
            BoundingBox = boundingBox;
            ImagePushpinStyles = imagePushpinStyles;
            ImagePathStyles = imagePathStyles;
        }

        /// <summary> Render static image options with center coordinate and the width and height of the image. </summary>
        /// <param name="centerCoordinate"> Center coordinate of the map image. </param>
        /// <param name="widthInPixels"> Width in pixels of the map image. </param>
        /// <param name="heightInPixels"> Height in pixels of the map image. </param>
        /// <param name="imagePushpinStyles"> Add pushpins with styling on the map image. </param>
        /// <param name="imagePathStyles"> Add paths with styling on the map image. </param>
        public GetMapStaticImageOptions(GeoPosition centerCoordinate, int widthInPixels, int heightInPixels, IList<ImagePushpinStyle> imagePushpinStyles = null, IList<ImagePathStyle> imagePathStyles = null)
        {
            CenterCoordinate = centerCoordinate;
            WidthInPixels = widthInPixels;
            HeightInPixels = heightInPixels;
            ImagePushpinStyles = imagePushpinStyles;
            ImagePathStyles = imagePathStyles;
        }

        /// <summary> Desired zoom level of the map. Zoom value must be in the range: 0-20 (inclusive). Default value is 12. Please see <see href="https://docs.microsoft.com/azure/location-based-services/zoom-levels-and-tile-grid">Zoom Levels and Tile Grid</see> for details. </summary>
        public int? ZoomLevel { get; set; }
        /// <summary>
        /// Coordinates of the center point. Format: 'lon,lat'.
        /// Longitude range: -180 to 180. Latitude range: -85 to 85.
        /// Note: Either Center or BoundingBox are required parameters. They are mutually exclusive.
        /// </summary>
        public GeoPosition? CenterCoordinate { get; }
        /// <summary>
        /// Bounding box.
        /// Note: Either BoundingBox or CenterCoordinate are required
        /// parameters. They are mutually exclusive. It shouldn't be used with
        /// HeightInPixels or WidthInPixels.
        /// The maximum allowed ranges for Lat and Lon are defined for each zoom level
        /// in the table at the top of this page.
        /// </summary>
        public GeoBoundingBox BoundingBox { get; }
        /// <summary>
        /// Height of the resulting image in pixels. Range is 1 to 8192. Default
        /// is 512. It shouldn't be used with BoundingBox.
        /// </summary>
        public int? HeightInPixels { get; }
        /// <summary> Width of the resulting image in pixels. Range is 1 to 8192. Default is 512. It shouldn't be used with <see cref="BoundingBox"/>. </summary>
        public int? WidthInPixels { get; }
        /// <summary>
        /// Language in which search results should be returned. Should be one of supported IETF language tags, case insensitive. When data in specified language is not available for a specific field, default language is used.
        ///
        /// Please refer to <see href="https://docs.microsoft.com/azure/azure-maps/supported-languages">Supported Languages</see> for details.
        /// </summary>
        public RenderingLanguage? Language { get; set; }
        /// <summary>
        /// The View parameter (also called the &quot;user region&quot; parameter) allows you to show the correct maps for a certain country/region for geopolitically disputed regions. Different countries have different views of such regions, and the View parameter allows your application to comply with the view required by the country your application will be serving. By default, the View parameter is set to “Unified” even if you haven’t defined it in  the request. It is your responsibility to determine the location of your users, and then set the View parameter correctly for that location. Alternatively, you have the option to set ‘View=Auto’, which will return the map data based on the IP  address of the request. The View parameter in Azure Maps must be used in compliance with applicable laws, including those  regarding mapping, of the country where maps, images and other data and third party content that you are authorized to  access via Azure Maps is made available. Example: view=IN.
        ///
        /// Please refer to <see href="https://aka.ms/AzureMapsLocalizationViews">Supported Views</see> for details and to see the available Views.
        /// </summary>
        public Azure.Maps.LocalizedMapView? LocalizedMapView { get; set; }

        /// <summary>
        /// Pushpin style and instances. Use this parameter to optionally add pushpins to the image.
        /// The pushpin style describes the appearance of the pushpins, and the instances specify
        /// the coordinates of the pushpins and optional labels for each pin.
        /// </summary>
        public IList<ImagePushpinStyle> ImagePushpinStyles { get; }
        /// <summary>
        /// Path style and locations. Use this parameter to optionally add lines, polygons or circles to the image.
        /// The path style describes the appearance of the line and fill.
        /// </summary>
        public IList<ImagePathStyle> ImagePathStyles { get; }
    }
}
