// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.Blobs.Specialized;
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
        public static StorageResource GenerateBlockBlobResource(BlockBlobClient blobClient)
        {
            return new BlockBlobStorageResource(blobClient);
        }

        /// <summary>
        /// Generate blob virtual directory client
        /// </summary>
        /// <param name="containerClient">Container CLient</param>
        /// <param name="encodedPath">Encoded Directory Path</param>
        /// <returns></returns>
        public static StorageResourceContainer GetBlobDirectoryResource(BlobContainerClient containerClient, List<string> encodedPath)
        {
            return new BlobDirectoryStorageResourceContainer(containerClient, encodedPath);
        }

        /// <summary>
        /// Generate blob container client. Container to container copy is not currently supported.
        /// </summary>
        /// <param name="containerClient"></param>
        /// <returns></returns>
        public static StorageResourceContainer GetBlobContainerResource(BlobContainerClient containerClient)
        {
            return new BlobStorageResourceContainer(containerClient);
        }
    }
}
