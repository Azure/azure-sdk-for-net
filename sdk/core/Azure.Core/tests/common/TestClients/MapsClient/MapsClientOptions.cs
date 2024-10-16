// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Core.Experimental.Tests;

public class MapsClientOptions : ClientOptions
{
    private const ServiceVersion LatestVersion = ServiceVersion.V1;

    public enum ServiceVersion
    {
        V1 = 1
    }

    internal string Version { get; }

    internal Uri Endpoint { get; }

    public MapsClientOptions() : this(ServiceVersion.V1)
    {
        Diagnostics.LoggedHeaderNames.Add("x-maps-client-allowed");
    }

    public MapsClientOptions(ServiceVersion version)
    {
        Version = version switch
        {
            ServiceVersion.V1 => "1.0",
            _ => throw new NotSupportedException()
        };
    }
}
