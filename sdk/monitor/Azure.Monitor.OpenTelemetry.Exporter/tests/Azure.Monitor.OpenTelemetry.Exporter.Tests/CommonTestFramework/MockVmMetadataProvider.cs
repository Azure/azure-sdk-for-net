// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework
{
    internal class MockVmMetadataProvider : IVmMetadataProvider
    {
        public VmMetadataResponse? Response { get; set; } = null;

        public VmMetadataResponse? GetVmMetadataResponse() => Response;
    }
}
