// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor.Integration.Tests.TestFramework
{
    public struct ExpectedTelemetryItemValues
    {
        public string Name;
        public Dictionary<string, string> CustomProperties;
    }
}
