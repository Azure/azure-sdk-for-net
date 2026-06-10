// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat
{
    // Public for the System.Text.Json source generator. Fields are lower-cased to match the
    // server-emitted JSON contract:
    //   { "ver": 1, "enabled": true, "url": "data.stats.monitor.azure.com" }
#pragma warning disable SA1300 // Element should begin with upper-case letter
    internal class SdkStatsConfigResponse
    {
        public int ver { get; set; }

        public bool enabled { get; set; }

        public string? url { get; set; }
    }
#pragma warning restore SA1300
}
