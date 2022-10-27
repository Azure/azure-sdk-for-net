// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Maps.Search
{
    /// <summary> Options. </summary>
    public class SearchBaseOptions
    {
        /// <summary> Maximum number of responses that will be returned. Default: 10, minimum: 1 and maximum: 100. </summary>
        public int? Top { get; set; }
        /// <summary> Starting offset of the returned results within the full result set. Default: 0, minimum: 0 and maximum: 1900. </summary>
        public int? Skip { get; set; }
        /// <summary>
        /// Language in which search results should be returned. Should be one of supported IETF language tags, case insensitive. When data in specified language is not available for a specific field, default language is used.
        /// Please refer to <see href="https://docs.microsoft.com/azure/azure-maps/supported-languages">Supported Languages</see> for details.
        /// </summary>
        public SearchLanguage Language { get; set; }

        /// <summary>
        /// The View parameter (also called the &quot;user region&quot; parameter) allows you to show the correct maps for a certain country/region for geopolitically disputed regions. Different countries have different views of such regions, and the View parameter allows your application to comply with the view required by the country your application will be serving. By default, the View parameter is set to “Unified” even if you haven’t defined it in  the request. It is your responsibility to determine the location of your users, and then set the View parameter correctly for that location. Alternatively, you have the option to set ‘View=Auto’, which will return the map data based on the IP  address of the request. The View parameter in Azure Maps must be used in compliance with applicable laws, including those  regarding mapping, of the country where maps, images and other data and third party content that you are authorized to  access via Azure Maps is made available. Example: view=IN.
        ///
        /// Please refer to <see href="https://aka.ms/AzureMapsLocalizationViews">Supported Views</see> for details and to see the available Views.
        /// </summary>
        public Azure.Maps.LocalizedMapView? LocalizedMapView { get; set; }
    }
}
