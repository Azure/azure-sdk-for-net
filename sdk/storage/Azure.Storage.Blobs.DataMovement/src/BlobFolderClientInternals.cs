// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs.DataMovement
{
    /// <summary>
    /// Helper to access protected static members of BlobServiceClient
    /// that should not be exposed directly to customers.
    /// </summary>
    internal class BlobFolderClientInternals : BlobFolderClient
    {
        /// <summary>
        /// Prevent instantiation.
        /// </summary>
        private BlobFolderClientInternals() { }

        /// <summary>
        /// Get a <see cref="BlobFolderClient"/>'s <see cref="HttpPipeline"/>
        /// for creating child clients.
        /// </summary>
        /// <param name="client">The BlobServiceClient.</param>
        /// <returns>The BlobServiceClient's HttpPipeline.</returns>
        public static new HttpPipeline GetHttpPipeline(BlobFolderClient client) =>
            BlobFolderClient.GetHttpPipeline(client);

        /// <summary>
        /// Get a <see cref="BlobFolderClient"/>'s <see cref="BlobClientOptions"/>
        /// for creating child clients.
        /// </summary>
        /// <param name="client">The BlobServiceClient.</param>
        /// <returns>The BlobServiceClient's BlobClientOptions.</returns>
        public static new BlobClientOptions GetClientOptions(BlobFolderClient client) =>
            BlobFolderClient.GetClientOptions(client);
    }
}
