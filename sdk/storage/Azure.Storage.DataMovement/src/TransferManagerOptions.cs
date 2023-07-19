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
        /// Define an implementation of ClientOptions such that DiagnosticOptions can be used.
        /// Don't want to expose full ClientOptions.
        /// </summary>
        internal class TransferManagerClientOptions : ClientOptions
        {
        }

        /// <summary>
        /// Optional. Sets the way errors during a transfer will be handled.
        /// Default is <see cref="ErrorHandlingBehavior.StopOnAllFailures"/>.
        /// </summary>
        public ErrorHandlingBehavior ErrorHandling { get; set; }

        /// <summary>
        /// The maximum number of workers that may be used in a parallel transfer.
        /// </summary>
        public int? MaximumConcurrency { get; set; }

        /// <summary>
        /// Optional. Defines the options for creating a checkpointer which is used for saving
        /// transfer state so transfers can be resumed.
        /// </summary>
        public TransferCheckpointerOptions CheckpointerOptions { get; set; }

        internal TransferManagerClientOptions ClientOptions { get; } = new();

        /// <summary>
        /// Gets the transfer manager diagnostic options.
        /// </summary>
        public DiagnosticsOptions Diagnostics => ClientOptions.Diagnostics;
    }
}
