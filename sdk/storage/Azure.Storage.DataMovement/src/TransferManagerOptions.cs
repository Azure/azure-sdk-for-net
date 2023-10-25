// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Options for TransferManager that apply to all transfers.
    /// </summary>
    public class TransferManagerOptions
    {
        /// <summary>
        /// Define an implementation of ClientOptions such that DiagnosticOptions can be used.
        /// Don't want to expose full ClientOptions.
        /// </summary>
        internal class TransferManagerClientOptions : ClientOptions
        {
        }

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
        public List<StorageResourceProvider> ResumeProviders { get; set; }

        /// <summary>
        /// Optional. Sets the way errors during a transfer will be handled.
        /// Default is <see cref="DataTransferErrorMode.StopOnAnyFailure"/>.
        /// </summary>
        public DataTransferErrorMode ErrorHandling { get; set; }

        /// <summary>
        /// The maximum number of workers that may be used in a parallel transfer.
        /// </summary>
        public int? MaximumConcurrency { get; set; }

        /// <summary>
        /// Optional. Defines the options for creating a checkpointer which is used for saving
        /// transfer state so transfers can be resumed.
        /// </summary>
        public TransferCheckpointStoreOptions CheckpointerOptions { get; set; }

        internal TransferManagerClientOptions ClientOptions { get; } = new();

        /// <summary>
        /// Gets the transfer manager diagnostic options.
        /// </summary>
        public DiagnosticsOptions Diagnostics => ClientOptions.Diagnostics;
    }
}
