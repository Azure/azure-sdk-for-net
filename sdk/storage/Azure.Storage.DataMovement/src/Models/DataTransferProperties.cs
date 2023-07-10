﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Azure.Storage.DataMovement.Models
{
    /// <summary>
    /// Storage Resource Item properties returned by <see cref="TransferManager.GetTransfersAsync(StorageTransferStatus[])"/>
    /// </summary>
    public class DataTransferProperties
    {
        /// <summary>
        /// Contains the checkpointer information to rehydrate the StorageResource from.
        /// </summary>
        public TransferCheckpointerOptions Checkpointer { get; internal set; }

        /// <summary>
        /// Contains the transfer ID which to rehydrate the StorageResource from.
        /// </summary>
        public string TransferId { get; internal set; }

        /// <summary>
        /// Contains the Source Scheme of the Storage Resource to rehydrate the StorageResource from.
        /// </summary>
        public string SourceScheme { get; internal set; }

        /// <summary>
        /// Contains the Source path of the Storage Resource.
        /// </summary>
        public string SourcePath { get; internal set; }

        /// <summary>
        /// Contains the Source Scheme of the Storage Resource to rehydrate the StorageResource from.
        /// </summary>
        public string DestinationScheme { get; internal set; }

        /// <summary>
        /// Contains the Destination path of the Storage Resource.
        /// </summary>
        public string DestinationPath { get; internal set; }

        /// <summary>
        /// Defines whether or not this was a container transfer, in order to rehydrate the StorageResource.
        /// </summary>
        public bool IsContainer { get; internal set; }

        /// <summary>
        /// For mocking.
        /// </summary>
        protected DataTransferProperties() { }
    }
}
