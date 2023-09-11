// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat
{
    internal class VmMetadataResponse
    {
        public string? osType { get; set; }

        public string? subscriptionId { get; set; }

        public string? vmId { get; set; }
    }
}
