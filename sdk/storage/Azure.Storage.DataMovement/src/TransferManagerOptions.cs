// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Options for TransferManager that apply to all transfers.
    /// </summary>
    public class TransferManagerOptions
    {
        /// <summary>
        /// Define ClientOptions to get access to Azure.Core functionality
        /// bound to ClientOptions class. Don't want to expose everything
        /// that comes with client options, so keep this private.
        /// </summary>
        internal class TransferManagerClientOptions : ClientOptions
        {
        }
        internal TransferManagerClientOptions ClientOptions { get; } = new();

        /// <summary>
        /// Optional. Sets the way errors during a transfer will be handled.
        /// Default is <see cref="ErrorHandlingOptions.StopOnAllFailures"/>.
        /// </summary>
        public ErrorHandlingOptions ErrorHandling { get; set; }

        /// <summary>
        /// The maximum number of workers that may be used in a parallel transfer.
        /// </summary>
        public int? MaximumConcurrency { get; set; }

        /// <summary>
        /// Optional. Defines the options for creating a checkpointer which is used for saving
        /// transfer state so transfers can be resumed.
        /// </summary>
        public TransferCheckpointerOptions CheckpointerOptions { get; set; }

        /// <summary>
        /// Defines the diagnostic options for transfer management. This is separate from
        /// diagnostic options provided in storage resources.
        /// </summary>
        public DiagnosticsOptions Diagnostics => ClientOptions.Diagnostics;
    }
}
