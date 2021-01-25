// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor
{
    public class AzureMonitorExporterOptions : ClientOptions
    {
        public string ConnectionString { get; set; }
    }
}
