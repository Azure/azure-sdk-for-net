// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Experimental.Tests;

public class SimpleClientOptions : ClientOptions
{
    private const ServiceVersion LatestVersion = ServiceVersion.V1;

    public SimpleClientOptions() : this(LatestVersion)
    {
        Diagnostics.LoggedHeaderNames.Add("x-simple-client-allowed");
    }

    public SimpleClientOptions(ServiceVersion version)
    {
        Version = version switch
        {
            ServiceVersion.V1 => "1.0",
            _ => throw new NotSupportedException()
        };
    }

    internal string Version { get; }

    public enum ServiceVersion
    {
        V1 = 1
    }
}
