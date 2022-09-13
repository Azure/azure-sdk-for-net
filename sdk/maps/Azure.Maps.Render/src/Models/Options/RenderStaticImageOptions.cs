// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.Maps.Render.Models
{
    // cspell:ignore bbox udid
    /// <summary> Options for rendering static images. </summary>
    public class RenderStaticImageOptions
    {
        /// <summary> Desired format of the response. Possible value: <c>RasterTileFormat.Png</c>. </summary>
        public RasterTileFormat? TileFormat { get; set; }
        /// <summary>
        /// Map layer requested. Possible value: <c>StaticMapLayer.Basic</c>, <c>StaticMapLayer.Labels</c> or <c>StaticMapLayer.Hybrid</c>
        /// If layer is set to <c>StaticMapLayer.Labels</c> or <c>StaticMapLayer.Hybrid</c>, the format should be png.
        /// </summary>
        public StaticMapLayer? TileLayer { get; set; }
        /// <summary> Map style to be returned. Possible values are <c>MapImageStyle.Main</c> and <c>MapImageStyle.Dark</c>. </summary>
        public MapImageStyle? TileStyle { get; set; }
        /// <summary> Desired zoom level of the map. Zoom value must be in the range: 0-20 (inclusive). Default value is 12.&lt;br&gt;&lt;br&gt;Please see <see href="https://docs.microsoft.com/azure/location-based-services/zoom-levels-and-tile-grid">Zoom Levels and Tile Grid</see> for details. </summary>
        public int? ZoomLevel { get; set; }
        /// <summary>
        /// Coordinates of the center point. Format: &apos;lon,lat&apos;. Projection used
        /// - EPSG:3857. Longitude range: -180 to 180. Latitude range: -85 to 85.
        ///
        /// Note: Either Center or BoundingBox are required parameters. They are
        /// mutually exclusive.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be read only
        public IList<double> CenterCoordinate { get; set; }
        /// <summary>
        /// Bounding box. Projection used - EPSG:3857. Format : &apos;minLon, minLat,
        /// maxLon, maxLat&apos;.
        ///
        /// Note: Either BoundingBox or Center are required
        /// parameters. They are mutually exclusive. It shouldn’t be used with
        /// height or width.
        ///
        /// The maximum allowed ranges for Lat and Lon are defined for each zoom level
        /// in the table at the top of this page.
        /// </summary>
        public IList<double> BoundingBox { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
        /// <summary>
        /// Height of the resulting image in pixels. Range is 1 to 8192. Default
        /// is 512. It shouldn’t be used with bbox.
        /// </summary>
        public int? Height { get; set; }
        /// <summary> Width of the resulting image in pixels. Range is 1 to 8192. Default is 512. It shouldn’t be used with bbox. </summary>
        public int? Width { get; set; }
        /// <summary>
        /// Language in which search results should be returned. Should be one of supported IETF language tags, case insensitive. When data in specified language is not available for a specific field, default language is used.
        ///
        /// Please refer to <see href="https://docs.microsoft.com/azure/azure-maps/supported-languages">Supported Languages</see> for details.
        /// </summary>
        public string RenderLanguage { get; set; }
        /// <summary>
        /// The View parameter (also called the &quot;user region&quot; parameter) allows you to show the correct maps for a certain country/region for geopolitically disputed regions. Different countries have different views of such regions, and the View parameter allows your application to comply with the view required by the country your application will be serving. By default, the View parameter is set to “Unified” even if you haven’t defined it in  the request. It is your responsibility to determine the location of your users, and then set the View parameter correctly for that location. Alternatively, you have the option to set ‘View=Auto’, which will return the map data based on the IP  address of the request. The View parameter in Azure Maps must be used in compliance with applicable laws, including those  regarding mapping, of the country where maps, images and other data and third party content that you are authorized to  access via Azure Maps is made available. Example: view=IN.
        ///
        /// Please refer to <see href="https://aka.ms/AzureMapsLocalizationViews">Supported Views</see> for details and to see the available Views.
        /// </summary>
        public LocalizedMapView? LocalizedMapView { get; set; }
        /// <summary>
        /// Pushpin style and instances. Use this parameter to optionally add pushpins to the image.
        /// The pushpin style describes the appearance of the pushpins, and the instances specify
        /// the coordinates of the pushpins and optional labels for each pin. (Be sure to properly URL-encode values of this
        /// parameter since it will contain reserved characters such as pipes and punctuation.)
        ///
        /// The Azure Maps account S0 SKU only supports a single instance of the pins parameter. Other SKUs
        /// allow multiple instances of the pins parameter to specify multiple pin styles.
        ///
        /// To render a pushpin at latitude 45°N and longitude 122°W using the default built-in pushpin style, add the
        /// querystring parameter
        ///
        /// `pins=default||-122 45`
        ///
        /// Note that the longitude comes before the latitude.
        /// After URL encoding this will look like
        ///
        /// `pins=default%7C%7C-122+45`
        ///
        /// All of the examples here show the pins
        /// parameter without URL encoding, for clarity.
        ///
        /// To render a pin at multiple locations, separate each location with a pipe character. For example, use
        ///
        /// `pins=default||-122 45|-119.5 43.2|-121.67 47.12`
        ///
        /// The S0 Azure Maps account SKU only allows five pushpins. Other account SKUs do not have this limitation.
        ///
        /// ### Style Modifiers
        ///
        /// You can modify the appearance of the pins by adding style modifiers. These are added after the style but before
        /// the locations and labels. Style modifiers each have a two-letter name. These abbreviated names are used to help
        /// reduce the length of the URL.
        ///
        /// To change the color of the pushpin, use the &apos;co&apos; style modifier and specify the color using the HTML/CSS RGB color
        /// format which is a six-digit hexadecimal number (the three-digit form is not supported). For example, to use
        /// a deep pink color which you would specify as #FF1493 in CSS, use
        ///
        /// `pins=default|coFF1493||-122 45`
        ///
        /// ### Pushpin Labels
        ///
        /// To add a label to the pins, put the label in single quotes just before the coordinates. For example, to label
        /// three pins with the values &apos;1&apos;, &apos;2&apos;, and &apos;3&apos;, use
        ///
        /// `pins=default||&apos;1&apos;-122 45|&apos;2&apos;-119.5 43.2|&apos;3&apos;-121.67 47.12`
        ///
        /// There is a built in pushpin style called &apos;none&apos; that does not display a pushpin image. You can use this if
        /// you want to display labels without any pin image. For example,
        ///
        /// `pins=none||&apos;A&apos;-122 45|&apos;B&apos;-119.5 43.2`
        ///
        /// To change the color of the pushpin labels, use the &apos;lc&apos; label color style modifier. For example, to use pink
        /// pushpins with black labels, use
        ///
        /// `pins=default|coFF1493|lc000000||-122 45`
        ///
        /// To change the size of the labels, use the &apos;ls&apos; label size style modifier. The label size represents the approximate
        /// height of the label text in pixels. For example, to increase the label size to 12, use
        ///
        /// `pins=default|ls12||&apos;A&apos;-122 45|&apos;B&apos;-119 43`
        ///
        /// The labels are centered at the pushpin &apos;label anchor.&apos; The anchor location is predefined for built-in pushpins and
        /// is at the top center of custom pushpins (see below). To override the label anchor, using the &apos;la&apos; style modifier
        /// and provide X and Y pixel coordinates for the anchor. These coordinates are relative to the top left corner of the
        /// pushpin image. Positive X values move the anchor to the right, and positive Y values move the anchor down. For example,
        /// to position the label anchor 10 pixels right and 4 pixels above the top left corner of the pushpin image,
        /// use
        ///
        /// `pins=default|la10 -4||&apos;A&apos;-122 45|&apos;B&apos;-119 43`
        ///
        /// ### Custom Pushpins
        ///
        /// To use a custom pushpin image, use the word &apos;custom&apos; as the pin style name, and then specify a URL after the
        /// location and label information. Use two pipe characters to indicate that you&apos;re done specifying locations and are
        /// starting the URL. For example,
        ///
        /// `pins=custom||-122 45||http://contoso.com/pushpins/red.png`
        ///
        /// After URL encoding, this would look like
        ///
        /// `pins=custom||-122+45||http://contoso.com/pushpins/red.png`
        ///
        /// By default, custom pushpin images are drawn centered at the pin coordinates. This usually isn&apos;t ideal as it obscures
        /// the location that you&apos;re trying to highlight. To override the anchor location of the pin image, use the &apos;an&apos;
        /// style modifier. This uses the same format as the &apos;la&apos; label anchor style modifier. For example, if your custom
        /// pin image has the tip of the pin at the top left corner of the image, you can set the anchor to that spot by
        /// using
        ///
        /// `pins=custom|an0 0||-122 45||http://contoso.com/pushpins/red.png`
        ///
        /// Note: If you use the &apos;co&apos; color modifier with a custom pushpin image, the specified color will replace the RGB
        /// channels of the pixels in the image but will leave the alpha (opacity) channel unchanged. This would usually
        /// only be done with a solid-color custom image.
        ///
        /// ### Getting Pushpins from Azure Maps Data Storage
        ///
        /// For all Azure Maps account SKUs other than S0,
        /// the pushpin location information can be obtained from Azure Maps Data Storage. After uploading a GeoJSON document containing pin locations, the Data Storage service returns a Unique Data ID (UDID) that you can use
        /// to reference the data in the pins parameter.
        ///
        /// To use the point geometry from an uploaded GeoJSON document as the pin locations, specify the UDID in the locations
        /// section of the pins parameter. For example,
        ///
        /// `pins=default||udid-29dc105a-dee7-409f-a3f9-22b066ae4713`
        ///
        /// Note that
        /// only point and multipoint geometry, points and multipoints from geometry collections, and point geometry from features
        /// will be used. Linestring and polygon geometry will be ignored. If the point comes from a feature and the feature
        /// has a string property called &quot;label&quot;, the value of that property will be used as the label for the pin.
        ///
        /// You can mix pin locations from Data Storage and pin locations specified in the pins parameter. Any of the pipe-delimited
        /// pin locations can be a longitude and latitude or a UDID. For example,
        ///
        /// `pins=default||-122 45|udid-29dc105a-dee7-409f-a3f9-22b066ae4713|-119 43`
        ///
        /// ### Scale, Rotation, and Opacity
        ///
        /// You can make pushpins and their labels larger or smaller by using the &apos;sc&apos; scale style modifier. This is a
        /// value greater than zero. A value of 1 is the standard scale. Values larger than 1 will make the pins larger, and
        /// values smaller than 1 will make them smaller. For example, to draw the pushpins 50% larger than normal, use
        ///
        /// `pins=default|sc1.5||-122 45`
        ///
        /// You can rotate pushpins and their labels by using the &apos;ro&apos; rotation style modifier. This is a number of degrees
        /// of clockwise rotation. Use a negative number to rotate counter-clockwise. For example, to rotate the pushpins
        /// 90 degrees clockwise and double their size, use
        ///
        /// `pins=default|ro90|sc2||-122 45`
        ///
        /// You can make pushpins and their labels partially transparent by specifying the &apos;al&apos; alpha style modifier.
        /// This is a number between 0 and 1 indicating the opacity of the pushpins. Zero makes them completely transparent
        /// (and not visible) and 1 makes them completely opaque (which is the default). For example, to make pushpins
        /// and their labels only 67% opaque, use
        ///
        /// `pins=default|al.67||-122 45`
        ///
        /// ### Style Modifier Summary
        ///
        /// Modifier  | Description     | Range
        /// :--------:|-----------------|------------------
        /// al        | Alpha (opacity) | 0 to 1
        /// an        | Pin anchor      | *
        /// co        | Pin color       | 000000 to FFFFFF
        /// la        | Label anchor    | *
        /// lc        | Label color     | 000000 to FFFFFF
        /// ls        | Label size      | Greater than 0
        /// ro        | Rotation        | -360 to 360
        /// sc        | Scale           | Greater than 0
        ///
        /// * X and Y coordinates can be anywhere within pin image or a margin around it.
        /// The margin size is the minimum of the pin width and height.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be read only
        public IList<string> Pins { get; set; }
        /// <summary>
        /// Path style and locations. Use this parameter to optionally add lines, polygons or circles to the image.
        /// The path style describes the appearance of the line and fill. (Be sure to properly URL-encode values of this
        /// parameter since it will contain reserved characters such as pipes and punctuation.)
        ///
        /// Path parameter is supported in Azure Maps account SKU starting with S1. Multiple instances of the path parameter
        /// allow to specify multiple geometries with their styles. Number of parameters per request is limited to 10 and
        /// number of locations is limited to 100 per path.
        ///
        /// To render a circle with radius 100 meters and center point at latitude 45°N and longitude 122°W using the default style, add the
        /// querystring parameter
        ///
        /// `path=ra100||-122 45`
        ///
        /// Note that the longitude comes before the latitude.
        /// After URL encoding this will look like
        ///
        /// `path=ra100%7C%7C-122+45`
        ///
        /// All of the examples here show the path parameter without URL encoding, for clarity.
        ///
        /// To render a line, separate each location with a pipe character. For example, use
        ///
        /// `path=||-122 45|-119.5 43.2|-121.67 47.12`
        ///
        /// To render a polygon, last location must be equal to the start location. For example, use
        ///
        /// `path=||-122 45|-119.5 43.2|-121.67 47.12|-122 45`
        ///
        /// Longitude and latitude values for locations of lines and polygons can be in the range from -360 to 360 to allow for rendering of geometries crossing the anti-meridian.
        ///
        /// ### Style Modifiers
        ///
        /// You can modify the appearance of the path by adding style modifiers. These are added before the locations.
        /// Style modifiers each have a two-letter name. These abbreviated names are used to help reduce the length
        /// of the URL.
        ///
        /// To change the color of the outline, use the &apos;lc&apos; style modifier and specify the color using the HTML/CSS RGB color
        /// format which is a six-digit hexadecimal number (the three-digit form is not supported). For example, to use
        /// a deep pink color which you would specify as #FF1493 in CSS, use
        ///
        /// `path=lcFF1493||-122 45|-119.5 43.2`
        ///
        /// Multiple style modifiers may be combined together to create a more complex visual style.
        ///
        /// `lc0000FF|lw3|la0.60|fa0.50||-122.2 47.6|-122.2 47.7|-122.3 47.7|-122.3 47.6|-122.2 47.6`
        ///
        /// ### Getting Path locations from Azure Maps Data Storage
        ///
        /// For all Azure Maps account SKUs other than S0, the path location information can be obtained from Azure Maps Data Storage.
        /// After uploading a GeoJSON document containing path locations, the Data Storage service returns a Unique Data ID (UDID) that you can use
        /// to reference the data in the path parameter.
        ///
        /// To use the point geometry from an uploaded GeoJSON document as the path locations, specify the UDID in the locations
        /// section of the path parameter. For example,
        ///
        /// `path=||udid-29dc105a-dee7-409f-a3f9-22b066ae4713`
        ///
        /// Note the it is not allowed to mix path locations from Data Storage with locations specified in the path parameter.
        ///
        /// ### Style Modifier Summary
        ///
        /// Modifier  | Description            | Range
        /// :--------:|------------------------|------------------
        /// lc        | Line color             | 000000 to FFFFFF
        /// fc        | Fill color             | 000000 to FFFFFF
        /// la        | Line alpha (opacity)   | 0 to 1
        /// fa        | Fill alpha (opacity)   | 0 to 1
        /// lw        | Line width             | Greater than 0
        /// ra        | Circle radius (meters) | Greater than 0
        /// </summary>
        public IList<string> Path { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
    }
}
