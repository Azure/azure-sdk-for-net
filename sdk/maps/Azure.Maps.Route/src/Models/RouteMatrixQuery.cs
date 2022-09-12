// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.Core.GeoJson;

namespace Azure.Maps.Route.Models
{
    /// <summary> An object with a matrix of coordinates. </summary>
    public partial class RouteMatrixQuery
    {
        /// <summary> A valid `GeoJSON MultiPoint` geometry type. Please refer to [RFC 7946](https://tools.ietf.org/html/rfc7946#section-3.1.3) for details. </summary>
        [CodeGenMember("Origins")]
        internal GeoJsonMultiPoint GeoJsonMultiPointOrigins { get; set; }
        /// <summary> A valid `GeoJSON MultiPoint` geometry type. Please refer to [RFC 7946](https://tools.ietf.org/html/rfc7946#section-3.1.3) for details. </summary>
        [CodeGenMember("Destinations")]
        internal GeoJsonMultiPoint GeoJsonMultiPointDestinations { get; set; }

        private GeoPointCollection _Origins;
        private GeoPointCollection _Destinations;

        /// <summary> A valid `GeoJSON MultiPoint` geometry type. Please refer to [RFC 7946](https://tools.ietf.org/html/rfc7946#section-3.1.3) for details. </summary>
        public GeoPointCollection Origins {
            get => _Origins;

            set
            {
                _Origins = value;
                GeoJsonMultiPointOrigins = new GeoJsonMultiPoint(value);
            }
        }
        /// <summary> A valid `GeoJSON MultiPoint` geometry type. Please refer to [RFC 7946](https://tools.ietf.org/html/rfc7946#section-3.1.3) for details. </summary>
        public GeoPointCollection Destinations {
            get => _Destinations;

            set
            {
                _Destinations = value;
                GeoJsonMultiPointDestinations = new GeoJsonMultiPoint(value);
            }
        }
    }
}
