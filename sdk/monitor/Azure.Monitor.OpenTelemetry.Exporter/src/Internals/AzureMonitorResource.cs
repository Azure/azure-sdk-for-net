// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.Exporter.Models;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal sealed class AzureMonitorResource
    {
        internal string? RoleName { get; set; }

        internal string? RoleInstance { get; set; }

        internal MonitorBase? MonitorBaseData { get; set; }
    }
}
