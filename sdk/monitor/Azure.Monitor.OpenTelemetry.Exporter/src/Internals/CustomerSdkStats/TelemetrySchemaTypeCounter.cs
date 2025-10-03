// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats
{
    internal sealed class TelemetrySchemaTypeCounter
    {
        internal int _requestCount;
        internal int _dependencyCount;
        internal int _exceptionCount;
        internal int _eventCount;
        internal int _metricCount;
        internal int _traceCount;
    }
}
