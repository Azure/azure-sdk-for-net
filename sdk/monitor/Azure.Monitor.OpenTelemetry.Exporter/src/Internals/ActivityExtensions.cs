// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class ActivityExtensions
    {
        internal static TelemetryType GetTelemetryType(this Activity activity)
        {
            var kind = activity.Kind switch
            {
                ActivityKind.Server => TelemetryType.Request,
                ActivityKind.Client => TelemetryType.Dependency,
                ActivityKind.Producer => TelemetryType.Dependency,
                ActivityKind.Consumer => TelemetryType.Request,
                _ => TelemetryType.Dependency
            };

            return kind;
        }
    }
}
