// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.Core.GeoJson;

namespace Azure.Maps.Routing.Models
{
    /// <summary> A set of attributes describing a maneuver, e.g. "Turn right", "Keep left", "Take the ferry", "Take the motorway", "Arrive". </summary>
    public partial class RouteInstruction
    {
        /// <summary> A location represented as a latitude and longitude. </summary>
        [CodeGenMember("Point")]
        internal LatLongPair _Point { get; }

        /// <summary> A location represented as a latitude and longitude. </summary>
        public GeoPosition Point { get; }
    }
}
