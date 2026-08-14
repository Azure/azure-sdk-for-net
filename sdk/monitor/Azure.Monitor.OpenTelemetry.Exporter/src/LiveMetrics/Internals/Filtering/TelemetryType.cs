// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Filtering
{
    internal class TelemetryType
    {
        public const string Request = "Request";
        public const string Dependency = "Dependency";
        public const string Exception = "Exception";
        public const string Event = "Event";
        public const string Trace = "Trace";
    }
}
