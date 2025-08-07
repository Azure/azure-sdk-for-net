// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.LiveMetrics
{
    internal sealed class LiveMetricsResource
    {
        internal string? RoleName { get; set; }

        internal string? RoleInstance { get; set; }
    }
}
