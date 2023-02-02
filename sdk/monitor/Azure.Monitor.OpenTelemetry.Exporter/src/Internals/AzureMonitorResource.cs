// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal class AzureMonitorResource
    {
        internal string? RoleName { get; set; }

        internal string? RoleInstance { get; set; }
    }
}
