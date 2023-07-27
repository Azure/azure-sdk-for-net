// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.Core.GeoJson;

namespace Azure.Maps.Routing.Models
{
    /// <summary> Reachable Range. </summary>
    [CodeGenModel("RouteRange")]
    public partial class RouteRange
    {
        /// <summary> Initializes a new instance of RouteRange. </summary>
        /// <param name="center"> Center point of the reachable range. </param>
        /// <param name="boundary"> Polygon boundary of the reachable range represented as a list of points. </param>
        internal RouteRange(LatLongPair center, IReadOnlyList<LatLongPair> boundary)
        {
            CenterInternal = center;
            Center = new GeoPosition(center.Longitude, center.Latitude);

            boundary ??= new List<LatLongPair>();
            var boundaryList = new List<GeoPosition>();
            foreach (var latlongPair in boundary)
            {
                boundaryList.Add(new GeoPosition(latlongPair.Longitude, latlongPair.Latitude));
            }

            BoundaryInternal = boundary;
            Boundary = boundaryList.AsReadOnly();
        }

        /// <summary> Center point of the reachable range. </summary>
        [CodeGenMember("Center")]
        internal LatLongPair CenterInternal { get; }
        /// <summary> Polygon boundary of the reachable range represented as a list of points. </summary>
        [CodeGenMember("Boundary")]
        internal IReadOnlyList<LatLongPair> BoundaryInternal { get; }

        /// <summary> Center point of the reachable range. </summary>
        public GeoPosition Center { get; }
        /// <summary> Polygon boundary of the reachable range represented as a list of points. </summary>
        public IReadOnlyList<GeoPosition> Boundary { get; }
    }
}
