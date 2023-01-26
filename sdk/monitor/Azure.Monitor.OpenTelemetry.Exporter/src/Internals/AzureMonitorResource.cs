// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal class AzureMonitorResource
    {
        internal string? RoleName { get; set; }

        internal string? RoleInstance { get; set; }
    }
}
