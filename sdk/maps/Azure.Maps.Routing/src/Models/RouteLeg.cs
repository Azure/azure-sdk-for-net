// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.Core.GeoJson;

namespace Azure.Maps.Routing.Models
{
    /// <summary> A description of a part of a route, comprised of a list of points. Each additional waypoint provided in the request will result in an additional leg in the returned route. </summary>
    public partial class RouteLeg
    {
        /// <summary> Initializes a new instance of RouteLeg. </summary>
        internal RouteLeg()
        {
            _Points = new ChangeTrackingList<LatLongPair>();
            Points = new ChangeTrackingList<GeoPosition>();
        }

        /// <summary> Initializes a new instance of RouteLeg. </summary>
        /// <param name="summary"> Summary object for route section. </param>
        /// <param name="points"> Points array. </param>
        internal RouteLeg(RouteLegSummary summary, IReadOnlyList<LatLongPair> points)
        {
            Summary = summary;
            _Points = points;
            var pointList = new List<GeoPosition>();
            foreach (var point in points)
            {
                pointList.Add(new GeoPosition(point.Longitude, point.Latitude));
            }
            Points = pointList.AsReadOnly();
        }

        /// <summary> Points array. </summary>
        [CodeGenMember("Points")]
        internal IReadOnlyList<LatLongPair> _Points { get; }

        /// <summary> Points array. </summary>
        public IReadOnlyList<GeoPosition> Points { get; }
    }
}
