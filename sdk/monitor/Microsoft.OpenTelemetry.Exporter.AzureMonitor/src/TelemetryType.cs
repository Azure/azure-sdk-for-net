// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor
{
    internal enum TelemetryType
    {
        Request,
        Dependency,
        Message,
        Event
    }
}
