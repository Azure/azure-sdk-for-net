// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    /// <summary>
    /// TODO.
    /// </summary>
    public class AzureMonitorExporterOptions : ClientOptions
    {
        private const int DefaultCapacityKiloBytes = 50 * 1024;
        private const long StorageCapacity = DefaultCapacityKiloBytes * 1024;

        /// <summary>
        /// TODO.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// TODO.
        /// </summary>
        public bool EnableRequestCollection { get; set; } = true;

        /// <summary>
        /// TODO.
        /// </summary>
        public bool EnableDependencyCollection { get; set; } = true;

        /// <summary>
        /// TODO.
        /// </summary>
        public bool EnableEventCollection { get; set; } = true;

        /// <summary>
        /// TODO.
        /// </summary>
        public bool EnableTraceCollection { get; set; } = true;

        /// <summary>
        /// TODO.
        /// </summary>
        public long MaxTransmissionStorageCapacity { get; set; } = StorageCapacity;

        /// <summary>
        /// TODO.
        /// </summary>
        public string StorageFolder { get; set; }
    }
}
