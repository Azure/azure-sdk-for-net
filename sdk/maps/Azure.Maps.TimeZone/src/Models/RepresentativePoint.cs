// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.GeoJson;

namespace Azure.Maps.TimeZone.Models
{
    /// <summary> Representative point property. </summary>
    [CodeGenModel("RepresentativePoint")]
    public partial class RepresentativePoint
    {
        [CodeGenMember("Latitude")]
        internal float? Latitude { get; }

        [CodeGenMember("Longitude")]
        internal float? Longitude { get; }

        /// <summary> GeoPosition property. </summary>
        public GeoPosition geoPosition { get; set; }
    }
}
