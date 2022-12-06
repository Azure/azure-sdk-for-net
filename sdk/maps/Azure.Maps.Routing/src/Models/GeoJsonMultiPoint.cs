// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.GeoJson;

namespace Azure.Maps.Routing.Models
{
    /// <summary> A valid `GeoJSON MultiPoint` geometry type. Please refer to <see href="https://tools.ietf.org/html/rfc7946#section-3.1.3">RFC 7946</see> for details. </summary>
    [CodeGenModel("GeoJsonMultiPoint")]
    internal partial class GeoJsonMultiPoint : GeoJsonGeometry
    {
        /// <summary> Initializes a new instance of GeoJsonMultiPoint. </summary>
        /// <param name="geoPoints"> Coordinates for the `GeoPoint`. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="geoPoints"/> is null. </exception>
        public GeoJsonMultiPoint(IEnumerable<GeoPoint> geoPoints)
        {
            if (geoPoints == null)
            {
                throw new ArgumentNullException(nameof(geoPoints));
            }

            IList<IList<double>> coord = new List<IList<double>>();
            foreach (var point in geoPoints)
            {
                coord.Add(new List<double>() {
                    point.Coordinates.Latitude, point.Coordinates.Longitude
                });
            }

            Coordinates = coord;
            Type = GeoJsonObjectType.GeoJsonMultiPoint;
        }
    }
}
