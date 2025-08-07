// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Maps.Weather.Models
{
    /// <summary> Weather along route query. </summary>
    public class WeatherAlongRouteQuery {
        /// <summary> Coordinates through which the route is calculated, separated by colon (:) and entered in chronological order. A minimum of two waypoints is required. A single API call may contain up to 60 waypoints. </summary>
        public List<WeatherAlongRouteWaypoint> Waypoints { get; set; }
    }
}