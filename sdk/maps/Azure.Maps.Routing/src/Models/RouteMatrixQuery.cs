// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.Core.GeoJson;
using Azure.Maps.Routing.Models;

namespace Azure.Maps.Routing
{
    /// <summary> An object with a matrix of coordinates. </summary>
    [CodeGenModel("RouteMatrixQuery")]
    public partial class RouteMatrixQuery
    {
        /// <summary> A valid `GeoJSON MultiPoint` geometry type. Please refer to <see href="https://tools.ietf.org/html/rfc7946#section-3.1.3">RFC 7946</see> for details. </summary>
        [CodeGenMember("Origins")]
        internal GeoJsonMultiPoint GeoJsonMultiPointOrigins { get; set; }
        /// <summary> A valid `GeoJSON MultiPoint` geometry type. Please refer to <see href="https://tools.ietf.org/html/rfc7946#section-3.1.3">RFC 7946</see> for details. </summary>
        [CodeGenMember("Destinations")]
        internal GeoJsonMultiPoint GeoJsonMultiPointDestinations { get; set; }

        private IList<GeoPosition> _Origins;
        private IList<GeoPosition> _Destinations;

#pragma warning disable CA2227
        /// <summary> A valid `GeoJSON MultiPoint` geometry type. Please refer to <see href="https://tools.ietf.org/html/rfc7946#section-3.1.3">RFC 7946</see> for details. </summary>
        public IList<GeoPosition> Origins {
            get => _Origins;

            set
            {
                _Origins = value;
                List<IList<double>> multiPoint = new List<IList<double>>();
                foreach (var point in value)
                {
                    multiPoint.Add(new List<double>() {
                        point.Longitude, point.Latitude
                    });
                }
                GeoJsonMultiPointOrigins = new GeoJsonMultiPoint(multiPoint);
            }
        }
        /// <summary> A valid `GeoJSON MultiPoint` geometry type. Please refer to <see href="https://tools.ietf.org/html/rfc7946#section-3.1.3">RFC 7946</see> for details. </summary>
        public IList<GeoPosition> Destinations {
            get => _Destinations;

            set
            {
                _Destinations = value;
                List<IList<double>> multiPoint = new List<IList<double>>();
                foreach (var point in value)
                {
                    multiPoint.Add(new List<double>() {
                        point.Longitude, point.Latitude
                    });
                }
                GeoJsonMultiPointDestinations = new GeoJsonMultiPoint(multiPoint);
            }
        }
#pragma warning restore CA2227
    }
}
