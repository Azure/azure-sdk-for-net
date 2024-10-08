// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;

namespace ClientModel.ReferenceClients.SimpleClient;

public class SimpleClientOptions : ClientPipelineOptions
{
    private const ServiceVersion LatestVersion = ServiceVersion.V1;

    // TODO: Change to generated code pattern needed to support DI binding
    // from IConfiguration settings.
    public SimpleClientOptions() : this(LatestVersion)
    {
        Logging.AllowedHeaderNames.Add("x-client-allowed");
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
