// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Options for the StorageTransferManager.
    /// </summary>
    public class TransferManagerOptions
    {
        /// <summary>
        /// Optional event handler containing all possible status event status holders.
        /// </summary>
        internal IProgress<StorageTransferProgress> ProgressHandler { get; set; }

        /// <summary>
        /// Optional. If set to false, the operation will terminate quickly on encountering
        /// failures from the storage service. If true, the operation will ignore storage service
        /// related failures and proceed with the other sub-entities of the transfer job
        /// and pending transfer jobs.
        /// </summary>
        public ErrorHandlingOptions ErrorHandling { get; set; }

        /// <summary>
        /// The maximum number of workers that may be used in a parallel transfer.
        /// </summary>
        public int? MaximumConcurrency { get; set; }

        /// <summary>
        /// Optional. Defines the checkpoint ID that the transfer should continue from.
        ///
        /// TODO: https://github.com/Azure/azure-sdk-for-net/issues/32955
        /// </summary>
        internal TransferCheckpointer Checkpointer { get; set; }
    }
}
