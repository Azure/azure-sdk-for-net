// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Storage.DataMovement.Models
{
    /// <summary>
    /// Options for the <see cref="StorageTransferManager"/>.
    /// </summary>
    public class StorageTransferManagerOptions
    {
        /// <summary>
        /// Optional path to set for the Transfer State File.
        ///
        /// If this file is not set and a transfer is started using
        /// the transfer manager, we will default to storing the file in
        /// %USERPROFILE%\.azstoragedml directory on Windows OS
        /// and $HOME$\.azstoragedml directory on Mac and Linux based OS.
        ///
        /// TODO: this will also hold the the information of all exceptions that
        /// have occured during the transfer state. In the case that too many
        /// exceptions happened during a transfer job and the customer wants
        /// to go through each exception and resolve each one.
        /// </summary>
        public string TransferStateDirectoryPath { get; set; }

        /// <summary>
        /// Optional event handler containing all possible status event status holders
        /// </summary>
        public StorageTransferResults TransferResults { get; set; }

        /// <summary>
        /// Optional. If set to false, the operation will terminate quickly on encountering
        /// failures from the storage service. If true, the operation will ignore storage service
        /// related failures and proceed with the other sub-entities of the transfer job
        /// and pending transfer jobs.
        /// </summary>
        public bool ContinueOnStorageFailure { get; set; }

        /// <summary>
        /// Optional. If set to false, the operation will terminate quickly on encountering user filesystem failures.
        /// If true, the operation will ignore local filesytem failures and proceed with the
        /// other sub-entities of the transfer job and pending transfer jobs.
        /// </summary>
        public bool ContinueOnLocalFilesystemFailure { get; set; }

        /// <summary>
        /// Optional. If not set will default to 1.
        ///
        /// TODO: determine if this value is needed. Local filesystems tend to lock the directory they are searching through
        /// so 1 may be enough if the other worker threads are waiting on another thread to let go of the directory
        /// </summary>
        public int ConcurrencyForLocalFilesystemListing { get; set; }

        /// <summary>
        /// Optional. Determines concurrency value for listing calls on the serivce side.
        /// If not set will default to 4.
        /// </summary>
        public int ConcurrencyForServiceListing { get; set; }
    }
}
