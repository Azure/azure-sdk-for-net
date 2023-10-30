﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.ClientModel;

namespace Maps;

public class MapsClientOptions : RequestOptions
{
    private const ServiceVersion LatestVersion = ServiceVersion.V1;

    public enum ServiceVersion
    {
        V1 = 1
    }

    internal string Version { get; }

    internal Uri Endpoint { get; }

    public MapsClientOptions(ServiceVersion version = LatestVersion)
    {
        Version = version switch
        {
            ServiceVersion.V1 => "1.0",
            _ => throw new NotSupportedException()
        };
    }
}
