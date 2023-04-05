// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    ///
    /// </summary>
    public class BlobContainerClientTransferOptions
    {
        /// <summary>
        ///
        /// </summary>
        public BlobStorageResourceContainerOptions BlobContainerOptions { get; set; }

        /// <summary>
        ///
        /// </summary>
        public ContainerTransferOptions TransferOptions { get; set; }
    }
}
