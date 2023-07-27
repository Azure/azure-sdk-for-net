// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal enum TelemetryType
    {
        Request,
        Dependency,
        Message,
        Event,
        Metric
    }
}
