// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Azure;
using Azure.Core;

using OpenTelemetry.Exporter.AzureMonitor.Models;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    public class AzureMonitorExporterOptions : ClientOptions
    {
        private const int DefaultCapacityKiloBytes = 50 * 1024;
        private const long StorageCapacity = DefaultCapacityKiloBytes * 1024;

        public string ConnectionString { get; set; }

        public long MaxTransmissionStorageCapacity { get; set; } = StorageCapacity;

        public string StorageFolder { get; set; }

        internal IServiceRestClient ServiceRestClient { get; set; } = null;
    }
}
