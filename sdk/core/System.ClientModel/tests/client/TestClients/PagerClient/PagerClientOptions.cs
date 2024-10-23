// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;

namespace ClientModel.ReferenceClients.PagerClient;

public class PagerClientOptions : ClientPipelineOptions
{
    private const ServiceVersion LatestVersion = ServiceVersion.V1;

    // TODO: Change to generated code pattern needed to support DI binding
    // from IConfiguration settings.
    public PagerClientOptions() : this(LatestVersion)
    {
    }

    public PagerClientOptions(ServiceVersion version)
    {
        Version = version switch
        {
            ServiceVersion.V1 => "1.0",
            _ => throw new NotSupportedException()
        };
    }

    internal string Version { get; }

    // TODO: call AssertNotFrozen from setter
    public string? PagerNumber { get; set; }

    public enum ServiceVersion
    {
        V1 = 1
    }
}
