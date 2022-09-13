// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Maps.GeoLocation
{
    /// <summary> Client options for GeoLocationClient. </summary>
    public partial class MapsGeoLocationClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V1;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "1.0". </summary>
            V1 = 1
        }

        internal string Version { get; }

        internal Uri Endpoint { get; }

        /// <summary> Initializes new instance of GeoLocationClientOptions. </summary>
        /// <param name="version"> GeoLocation service version. </param>
        public MapsGeoLocationClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V1 => "1.0",
                _ => throw new NotSupportedException()
            };
        }
    }
}
