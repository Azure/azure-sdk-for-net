// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.GeoJson;

namespace Azure.Maps.Search.Models
{
    /// <summary> Options. </summary>
    public class GetPolygonOptions
    {
        /// <summary> The geopolitical concept to return a boundary for. </summary>
        public BoundaryResultTypeEnum? ResultType { get; set; }

        /// <summary> Resolution determines the amount of points to send back. </summary>
        public ResolutionEnum? Resolution { get; set; }

        /// <summary>A string that represents an <see href="https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2">ISO 3166-1 Alpha-2 region/country code</see>. This will alter Geopolitical disputed borders and labels to align with the specified user region. By default, the View parameter is set to “Auto” even if you haven’t defined it in the request. Please refer to <see href="https://aka.ms/AzureMapsLocalizationViews">Supported Views</see> for details and to see the available Views. </summary>
        public LocalizedMapView? LocalizedMapView { get; set; }

        /// <summary>A point on the earth specified as a longitude and latitude. Example: <c>GeoPosition(lon, lat)</c></summary>
        public GeoPosition Coordinates { get; set; }
    }
}
