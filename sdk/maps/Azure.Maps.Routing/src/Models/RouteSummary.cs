// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Maps.Routing.Models
{
    /// <summary> Summary object. </summary>
    public partial class RouteSummary
    {
        /// <summary> Initializes a new instance of RouteSummary. </summary>
        /// <param name="lengthInMeters"> Length In Meters property. </param>
        /// <param name="travelTimeInSeconds"> Estimated travel time in seconds property that includes the delay due to real-time traffic. Note that even when traffic=false travelTimeInSeconds still includes the delay due to traffic. If DepartAt is in the future, travel time is calculated using time-dependent historic traffic data. </param>
        /// <param name="trafficDelayInSeconds"> Estimated delay in seconds caused by the real-time incident(s) according to traffic information. For routes planned with departure time in the future, delays is always 0. To return additional travel times using different types of traffic information, parameter computeTravelTimeFor=all needs to be added. </param>
        /// <param name="departureTime"> The estimated departure time for the route or leg. Time is in UTC. </param>
        /// <param name="arrivalTime"> The estimated arrival time for the route or leg. Time is in UTC. </param>
        internal RouteSummary(int? lengthInMeters, int? travelTimeInSeconds, int? trafficDelayInSeconds, DateTimeOffset? departureTime, DateTimeOffset? arrivalTime)
        {
            LengthInMeters = lengthInMeters;
            TravelTimeInSeconds = travelTimeInSeconds;
            TrafficDelayInSeconds = trafficDelayInSeconds;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            TravelTimeDuration = travelTimeInSeconds != null ? new TimeSpan(0, 0, travelTimeInSeconds ?? 0) : null;
            TrafficDelayDuration = trafficDelayInSeconds != null ? new TimeSpan(0, 0, trafficDelayInSeconds ?? 0) : null;
        }

        /// <summary> Estimated travel time in seconds property that includes the delay due to real-time traffic. Note that even when traffic=false travelTimeInSeconds still includes the delay due to traffic. If DepartAt is in the future, travel time is calculated using time-dependent historic traffic data. </summary>
        [CodeGenMember("TravelTimeInSeconds")]
        public int? TravelTimeInSeconds { get; }
        /// <summary> Estimated delay in seconds caused by the real-time incident(s) according to traffic information. For routes planned with departure time in the future, delays is always 0. To return additional travel times using different types of traffic information, parameter computeTravelTimeFor=all needs to be added. </summary>
        [CodeGenMember("TrafficDelayInSeconds")]
        private int? TrafficDelayInSeconds { get; }

        /// <summary> Estimated travel time in <see cref="TimeSpan"/> property that includes the delay due to real-time traffic. Note that even when traffic=false travelTimeInSeconds still includes the delay due to traffic. If DepartAt is in the future, travel time is calculated using time-dependent historic traffic data. </summary>
        public TimeSpan? TravelTimeDuration { get; }
        /// <summary> Estimated delay in <see cref="TimeSpan"/> caused by the real-time incident(s) according to traffic information. For routes planned with departure time in the future, delays is always 0. To return additional travel times using different types of traffic information, parameter computeTravelTimeFor=all needs to be added. </summary>
        private TimeSpan? TrafficDelayDuration { get; }
    }
}
