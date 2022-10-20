// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Maps.Geolocation
{
    /// <summary> Client options for GeolocationClient. </summary>
    public partial class MapsGeolocationClientOptions : ClientOptions
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

        /// <summary> Initializes new instance of GeolocationClientOptions. </summary>
        /// <param name="version"> Geolocation service version. </param>
        public MapsGeolocationClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V1 => "1.0",
                _ => throw new NotSupportedException()
            };
        }
    }
}
