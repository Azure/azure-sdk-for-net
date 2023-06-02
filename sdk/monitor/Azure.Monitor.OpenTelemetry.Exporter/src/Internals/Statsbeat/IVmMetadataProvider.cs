// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat
{
    internal interface IVmMetadataProvider
    {
        public VmMetadataResponse? GetVmMetadataResponse();
    }
}
