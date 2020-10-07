// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    public class AzureMonitorExporterOptions : ClientOptions
    {
        private const int DefaultCapacityKiloBytes = 50 * 1024;
        private const long StorageCapacity = DefaultCapacityKiloBytes * 1024;

        public string ConnectionString { get; set; }

        public long MaxTransmissionStorageCapacity { get; set; } = StorageCapacity;

        public string StorageFolder { get; set; }
    }
}
