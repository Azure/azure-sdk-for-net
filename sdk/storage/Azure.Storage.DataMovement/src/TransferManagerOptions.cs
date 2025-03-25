using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Options for TransferManager that apply to all transfers.
    /// </summary>
    public class TransferManagerOptions
    {
        // Fields
        internal TransferManagerClientOptions ClientOptions { get; } = new();

        // Properties
        /// <summary>
        /// Optional. Defines the options for creating a checkpoint which is used for saving
        /// transfer state so transfers can be resumed.
        /// </summary>
        public TransferCheckpointStoreOptions CheckpointStoreOptions { get; set; }

        /// <summary>
        /// Gets the transfer manager diagnostic options.
        /// </summary>
        public DiagnosticsOptions Diagnostics => ClientOptions.Diagnostics;

        /// <summary>
        /// Optional. Sets the way errors during a transfer will be handled.
        /// </summary>
        public TransferErrorMode ErrorMode { get; set; }

        /// <summary>
        /// The initial number of workers that may be used in a parallel transfer.
        /// </summary>
        public int InitialConcurrency { get; set; } = 1;

        /// <summary>
        /// The maximum CPU usage allowed for the transfer manager.
        /// This is a float between 0 and 1.
        /// </summary>
        public float? MaximumCpuUsage { get; set; } = 1.0F;

        /// <summary>
        /// The maximum number of workers that may be used in a parallel transfer.
        /// </summary>
        public int? MaximumConcurrency { get; set; }

        /// <summary>
        /// Specifies the maximum memory usage allowed for the transfer manager, in bytes.
        /// If no limit is set, the system will use as much memory as possible, potentially leading to increased page faults.
        /// This can slow down transfers as the system moves data between RAM and virtual memory, and handles context switches.
        /// </summary>
        public double? MaximumMemoryUsage { get; set; }

        /// <summary>
        /// Specifies the interval at which the monitor checks the system, represented as a TimeSpan.
        /// This value must be greater than zero. Using an interval below one second can result in significant overhead
        /// for the monitor and negatively impact the performance of any application using this library.
        /// </summary>
        public TimeSpan? MonitoringInterval { get; set; }

        /// <summary>
        /// Indicates whether the user wants to tune the concurrency.
        /// </summary>
        public bool EnableConcurrencyTuner { get; set; }

        /// <summary>
        /// Resource providers for the transfer manager to use in resuming a transfer.
        /// Expects one provider for each storage provider in use. E.g. when transfering
        /// between local storage and Azure Blob Storage, you can set this value to the
        /// following:
        /// <code>
        /// new List&lt;StorageResourceProvider&gt;()
        /// {
        ///     new LocalFilesStorageResourceProvider(),
        ///     new BlobsStorageResourceProvider()
        /// };
        /// </code>
        /// More information is available about instantiating these and other
        /// <see cref="StorageResourceProvider"/> implementations.
        /// </summary>
        public IList<StorageResourceProvider> ProvidersForResuming { get; set; }

        // Nested Classes
        /// <summary>
        /// Define an implementation of ClientOptions such that DiagnosticOptions can be used.
        /// Don't want to expose full ClientOptions.
        /// </summary>
        internal class TransferManagerClientOptions : ClientOptions
        {
        }
    }
}
