// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal class AzureMonitorResource
    {
        internal string? RoleName { get; set; }

        internal string? RoleInstance { get; set; }

        internal string? RoleVersion { get; set; } = "Unknown";

        internal IDictionary<string, string> CustomTags { get; } = new ChangeTrackingDictionary<string, string>();
    }
}
