// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.ClientModel;

namespace Maps;

public class MapsClientOptions : RequestOptions
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
    public MapsClientOptions(ServiceVersion version = LatestVersion)
    {
        Version = version switch
        {
            ServiceVersion.V1 => "1.0",
            _ => throw new NotSupportedException()
        };
    }
}
