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
        /// <summary>
        /// This is a readonly instance of an Azure Monitor Connection String whose value is an all zero Instrumentation Key.
        /// This is provided for testing.
        /// </summary>
        public const string EmptyConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";

        private const int DefaultCapacityKiloBytes = 50 * 1024;
        private const long StorageCapacity = DefaultCapacityKiloBytes * 1024;

        public string ConnectionString { get; set; }

        public long MaxTransmissionStorageCapacity { get; set; } = StorageCapacity;

        public string StorageFolder { get; set; }

        public bool Test { get; set; }

        public Func<IEnumerable<TelemetryItem>, CancellationToken, Task<Response<TrackResponse>>> OnTrackAsync { get; set; } = null;
    }
}
