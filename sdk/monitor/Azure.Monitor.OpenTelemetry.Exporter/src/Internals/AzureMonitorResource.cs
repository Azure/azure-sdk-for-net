// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable // TODO: remove and fix errors

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal class AzureMonitorResource
    {
        internal string RoleName { get; set; }

        internal string RoleInstance { get; set; }
    }
}
