// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Maps.Search.Models
{
    /// <summary> The classification for the POI being returned. </summary>
    [CodeGenModel("Polygon")]
    public partial class Polygon
    {
        /// <summary> ID of the returned entity. </summary>
        [CodeGenMember("ProviderID")]
        public string ProviderId { get; }
        /// <summary> Geometry data in GeoJSON format. Please refer to [RFC 7946](https://tools.ietf.org/html/rfc7946) for details. Present only if &quot;error&quot; is not present. </summary>
        [CodeGenMember("GeometryData")]
        public GeoJsonFeatureCollection GeometryData { get; }
    }
}
