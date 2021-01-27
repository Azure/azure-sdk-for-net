// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

using Microsoft.OpenTelemetry.Exporter.AzureMonitor.Models;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor.Integration.Tests.TestFramework
{
    internal struct ExpectedTelemetryItemValues
    {
        public string Name;
        public string Message;
        public Dictionary<string, string> CustomProperties;
        public SeverityLevel SeverityLevel;
        public string SpanId;
        public string TraceId;
    }
}
