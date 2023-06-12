// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core.GeoJson;

namespace Azure.Maps.Search
{
    /// <summary> Base Options for Reverse Search API. </summary>
    public class ReverseSearchBaseOptions
    {
        /// <summary> Query is represented by coordinates which is a pair of coordinates to translate. Here it is represented by GeoPosition. </summary>
        public GeoPosition? Coordinates { get; set; }

        /// <summary> The radius in meters to for the results to be constrained to the defined area. </summary>
        public int? RadiusInMeters { get; set; }

        /// <summary>
        /// Language in which search results should be returned. Should be one of supported IETF language tags, case insensitive. When data in specified language is not available for a specific field, default language is used.
        /// Please refer to <see href="https://docs.microsoft.com/azure/azure-maps/supported-languages">Supported Languages</see> for details.
        /// </summary>
        public SearchLanguage Language { get; set; }

        /// <summary>
        /// The View parameter (also called the &quot;user region&quot; parameter) allows you to show the correct maps for a certain country/region for geopolitically disputed regions. Different countries have different views of such regions, and the View parameter allows your application to comply with the view required by the country your application will be serving. By default, the View parameter is set to “Unified” even if you haven’t defined it in  the request. It is your responsibility to determine the location of your users, and then set the View parameter correctly for that location. Alternatively, you have the option to set ‘View=Auto’, which will return the map data based on the IP  address of the request. The View parameter in Azure Maps must be used in compliance with applicable laws, including those  regarding mapping, of the country where maps, images and other data and third party content that you are authorized to  access via Azure Maps is made available. Example: view=IN.
        /// Please refer to <see href="https://aka.ms/AzureMapsLocalizationViews">Supported Views</see> for details and to see the available Views.
        /// </summary>
        public Azure.Maps.LocalizedMapView? LocalizedMapView { get; set; }

        /// <summary> The directional heading of the vehicle in degrees, for travel along a segment of roadway. 0 is North, 90 is East and so on, values range from -360 to 360. The precision can include up to one decimal place. </summary>
        public int? Heading { get; set; }
    }
}
