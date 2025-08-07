// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.GeoJson;
using System.Collections.Generic;
using Azure.Maps.Common;

namespace Azure.Maps.Search.Models
{
    /// <summary> The GeocodePointsItem. </summary>
    public partial class GeocodePointsItem
    {
        /// <summary> Initializes a new instance of <see cref="GeocodePointsItem"/>. </summary>
        internal GeocodePointsItem()
        {
            UsageTypes = new ChangeTrackingList<UsageTypeEnum>();
        }

        /// <summary> Initializes a new instance of <see cref="GeocodePointsItem"/>. </summary>
        /// <param name="geometry"> A valid `GeoJSON Point` geometry type. Please refer to [RFC 7946](https://tools.ietf.org/html/rfc7946#section-3.1.2) for details. </param>
        /// <param name="calculationMethod"> The method that was used to compute the geocode point. </param>
        /// <param name="usageTypes">
        /// The best use for the geocode point.
        /// Each geocode point is defined as a `Route` point, a `Display` point or both.
        /// Use `Route` points if you are creating a route to the location. Use `Display` points if you are showing the location on a map. For example, if the location is a park, a `Route` point may specify an entrance to the park where you can enter with a car, and a `Display` point may be a point that specifies the center of the park.
        /// </param>
        internal GeocodePointsItem(GeoJsonPoint geometry, CalculationMethodEnum? calculationMethod, IReadOnlyList<UsageTypeEnum> usageTypes)
        {
            GeometryInternal = geometry;
            CalculationMethod = calculationMethod;
            UsageTypes = usageTypes;
            Geometry = new GeoPoint(geometry.Coordinates[0], geometry.Coordinates[1]);
        }

        /// <summary> A valid `GeoJSON Point` geometry type. Please refer to [RFC 7946](https://tools.ietf.org/html/rfc7946#section-3.1.2) for details. </summary>
        [CodeGenMember("Geometry")]
        internal GeoJsonPoint GeometryInternal { get; }

        /// <summary> A GeoJson point object for the geocoding result. </summary>
        public GeoPoint Geometry { get; }
    }
}
