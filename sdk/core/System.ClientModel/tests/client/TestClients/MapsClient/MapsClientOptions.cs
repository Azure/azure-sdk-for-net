// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;

namespace ClientModel.ReferenceClients.MapsClient;

public class MapsClientOptions : ClientPipelineOptions
{
    private const ServiceVersion LatestVersion = ServiceVersion.V1;

    public MapsClientOptions() : this(LatestVersion)
    {
        Observability.AllowedHeaderNames.Add("x-maps-client-allowed");
    }

    public MapsClientOptions(ServiceVersion version = LatestVersion)
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
