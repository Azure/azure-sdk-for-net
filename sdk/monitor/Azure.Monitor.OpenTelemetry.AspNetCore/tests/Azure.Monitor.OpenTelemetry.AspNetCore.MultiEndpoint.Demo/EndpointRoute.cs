// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.AspNetCore.MultiEndpoint.Demo;

internal sealed class EndpointRoute
{
    public EndpointRoute(string name, string instrumentationKey, string ingestionEndpoint)
    {
        Name = name;
        InstrumentationKey = instrumentationKey;
        IngestionEndpoint = ingestionEndpoint;
    }

    public string Name { get; }

    public string InstrumentationKey { get; }

    public string IngestionEndpoint { get; }
}
