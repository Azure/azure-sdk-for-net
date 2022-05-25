﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Storage.Experimental
{
    /// <summary>
    /// Options for the StorageTransferManager.
    /// </summary>
    public class StorageTransferManagerOptions
    {
        /// <summary>
        /// Optional event handler containing all possible status event status holders
        /// </summary>
        public IProgress<StorageTransferProgress> ProgressHandler { get; set; }

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
    }
}
