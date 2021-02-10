// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

using Azure.Core;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    public class AzureMonitorExporterOptions : ClientOptions
    {
        public string ConnectionString { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public ServiceVersion ServiceVersion { get; set; } = ServiceVersion.V2020_09_15_Preview;
    }
}
