// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.Blobs.DataMovement
{
    /// <summary>
    /// Optional parameters for <see cref="PageBlobStorageResource"/>.
    /// </summary>
    public class PageBlobStorageResourceServiceCopyOptions
    {
        /// <summary>
        /// Optional. Defines the copy operation to take.
        /// See <see cref="TransferCopyMethod"/>. Defaults to <see cref="TransferCopyMethod.SyncCopy"/>.
        /// </summary>
        public TransferCopyMethod CopyMethod { get; set; }

        /// <summary>
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on the copying of data to this page blob.
        /// </summary>
        public PageBlobRequestConditions DestinationConditions { get; set; }

        /// <summary>
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </summary>
        public PageBlobRequestConditions SourceConditions { get; set; }
    }
}
