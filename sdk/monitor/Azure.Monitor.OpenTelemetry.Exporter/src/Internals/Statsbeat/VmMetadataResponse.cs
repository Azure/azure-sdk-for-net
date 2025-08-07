// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat
{
    // This class needs to be internal rather than private so that it can be used by the System.Text.Json source generator
    internal class VmMetadataResponse
    {
        public string? osType { get; set; }

        public string? subscriptionId { get; set; }

        public string? vmId { get; set; }
    }
}
