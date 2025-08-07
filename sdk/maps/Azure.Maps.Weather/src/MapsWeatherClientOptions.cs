// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Maps.Weather
{
    /// <summary> Client options for MapsWeatherClient. </summary>
    public partial class MapsWeatherClientOptions : ClientOptions
    {
        internal const ServiceVersion LatestVersion = ServiceVersion.V1_1;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "1.1". </summary>
            V1_1 = 1,
        }

        internal string Version { get; }

        /// <summary> The Azure Maps endpoint for requests. </summary>
        public Uri Endpoint { get; set; }

        /// <summary> Initializes new instance of MapsWeatherClientOptions. </summary>
        public MapsWeatherClientOptions(ServiceVersion version = LatestVersion,  Uri endpoint = null)
        {
            Version = version switch
            {
                ServiceVersion.V1_1 => "1.1",
                _ => throw new NotSupportedException()
            };
            Endpoint = endpoint;
        }

        /// <summary> Specifies which account is intended for usage in conjunction with the Microsoft Entra ID security model.  It represents a unique ID for the Azure Maps account and can be retrieved from the Azure Maps management  plane Account API. To use Microsoft Entra ID security in Azure Maps see the following <see href="https://aka.ms/amauthdetails">articles</see> for guidance. </summary>
        public string ClientId { get; set; }
    }
}
