// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.DataMovement;

namespace Azure.Storage.Blobs.DataMovement
{
    /// <summary>
    /// Factory to create blob storage resources
    /// </summary>
    public static class BlobStorageResourceFactory
    {
        /// <summary>
        /// Generate blob resource
        /// </summary>
        /// <param name="blobClient"></param>
        /// <returns></returns>
        public static StorageResource GenerateBlobResource(BlobClient blobClient)
        {
            return new BlobStorageResource(blobClient);
        }

        /// <summary>
        /// Generate blob container client
        /// </summary>
        /// <param name="containerClient"></param>
        /// <param name="directoryPrefix"></param>
        /// <returns></returns>
        public static StorageResourceContainer GetBlobContainer(BlobContainerClient containerClient, string directoryPrefix = default)
        {
            return new BlobStorageResourceContainer(containerClient, directoryPrefix);
        }
    }
}
