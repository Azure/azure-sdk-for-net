// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable // TODO: remove and fix errors

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal class VmMetadataResponse
    {
        public string osType { get; set; }

        public string subscriptionId { get; set; }

        public string vmId { get; set; }
    }
}
