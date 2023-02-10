// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.Maps.Search
{
    /// <summary> Options. </summary>
    public class SearchGeometryBaseOptions
    {
        /// <summary> Maximum number of responses that will be returned. Default: 10, minimum: 1 and maximum: 100. </summary>
        public int? Top { get; set; }

        /// <summary>
        /// The View parameter (also called the &quot;user region&quot; parameter) allows you to show the correct maps for a certain country/region for geopolitically disputed regions. Different countries have different views of such regions, and the View parameter allows your application to comply with the view required by the country your application will be serving. By default, the View parameter is set to “Unified” even if you haven’t defined it in  the request. It is your responsibility to determine the location of your users, and then set the View parameter correctly for that location. Alternatively, you have the option to set ‘View=Auto’, which will return the map data based on the IP  address of the request. The View parameter in Azure Maps must be used in compliance with applicable laws, including those  regarding mapping, of the country where maps, images and other data and third party content that you are authorized to  access via Azure Maps is made available. Example: view=IN.
        /// Please refer to <see href="https://aka.ms/AzureMapsLocalizationViews">Supported Views</see> for details and to see the available Views.
        /// </summary>
        public Azure.Maps.LocalizedMapView? LocalizedMapView { get; set; }

        /// <summary>
        /// A list of category set IDs which could be used to restrict the result to specific Points of Interest categories. ID order does not matter. When multiple category identifiers are provided, only POIs that belong to (at least) one of the categories from the provided list will be returned. The list of supported categories can be discovered using  <see href="https://aka.ms/AzureMapsPOICategoryTree">POI Categories API</see>.
        /// </summary>
        public IEnumerable<int> CategoryFilter { get; set; }

        /// <summary>
        /// Hours of operation for a POI (Points of Interest). The availability of hours of operation will vary based on the data available. If not passed, then no opening hours information will be returned.
        /// Supported value: nextSevenDays
        /// </summary>
        public OperatingHoursRange? OperatingHours { get; set; }
    }
}
