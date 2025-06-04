// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.GeoJson;

namespace Azure.Maps.Weather.Models
{
    /// <summary> Weather along route waypoint. </summary>
    public class WeatherAlongRouteWaypoint {
        /// <summary> Coordinates of the waypoint. </summary>
        public GeoPosition Coordinates { get; set; }
        /// <summary> The number of minutes from the present time that it will take for the vehicle to reach the waypoint. Allowed range is from 0.0 to 120.0 minutes. </summary>
        public double EtaInMinutes { get; set; }
        /// <summary> Indicates the vehicle heading as it passes the waypoint. Expressed in clockwise degrees relative to true north. This is issued to calculate sun glare as a driving hazard. Allowed range is from 0.0 to 360.0 degrees. If not provided, a heading will automatically be derived based on the position of neighboring waypoints. </summary>
        public double? Heading { get; set; } = null;
    }
}