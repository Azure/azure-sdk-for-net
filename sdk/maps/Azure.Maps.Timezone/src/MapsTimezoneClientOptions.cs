// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using System;

namespace Azure.Maps.Timezone
{
    /// <summary> Client options for TimezoneClient. </summary>
    public partial class MapsTimezoneClientOptions : ClientOptions
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

        /// <summary> Initializes new instance of MapsTimezoneClientOptions. </summary>
        /// <param name="version"> Timezone service version. </param>
        public MapsTimezoneClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V1 => "1.0",
                _ => throw new NotSupportedException()
            };
        }
    }
}
