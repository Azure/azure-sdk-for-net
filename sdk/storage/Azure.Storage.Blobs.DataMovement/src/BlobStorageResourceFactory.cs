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
    internal static class BlobStorageResourceFactory
    {
        /// <summary>
        /// Generate block blob resource
        /// </summary>
        /// <param name="blobClient"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static StorageResource GetBlockBlob(BlockBlobClient blobClient, BlockBlobStorageResourceOptions options)
        {
            return new BlockBlobStorageResource(blobClient, options);
        }

        /// <summary>
        /// Generate page blob resource. Currently not supported
        /// </summary>
        /// <param name="blobClient"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static StorageResource GetPageBlob(PageBlobClient blobClient, PageBlobStorageResourceOptions options)
        {
            return new PageBlobStorageResource(blobClient, options);
        }

        /// <summary>
        /// Generate append blob resource. Currently not supported
        /// </summary>
        /// <param name="blobClient"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static StorageResource GetPageBlob(AppendBlobClient blobClient, AppendBlobStorageResourceOptions options)
        {
            return new AppendBlobStorageResource(blobClient, options);
        }

        /// <summary>
        /// Generate blob virtual directory client
        /// </summary>
        /// <param name="containerClient">Container CLient</param>
        /// <param name="encodedPath">Encoded Directory Path</param>
        /// <returns></returns>
        public static StorageResourceContainer GetBlobVirtualDirectory(BlobContainerClient containerClient, string encodedPath)
        {
            return new BlobDirectoryStorageResourceContainer(containerClient, encodedPath);
        }

        /// <summary>
        /// Generate blob container client. Container to container copy is not currently supported.
        /// </summary>
        /// <param name="containerClient"></param>
        /// <returns></returns>
        internal static StorageResourceContainer GetBlobContainer(BlobContainerClient containerClient)
        {
            return new BlobStorageResourceContainer(containerClient);
        }
    }
}
