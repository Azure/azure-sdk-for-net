// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests.TestFramework
{
    public struct ExpectedTelemetryItemValues
    {
        public string Name;
        public Dictionary<string, string> CustomProperties;
    }
}
