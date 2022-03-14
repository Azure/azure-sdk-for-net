// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// Helper to access protected static members of BlobServiceClient
    /// that should not be exposed directly to customers.
    /// </summary>
    internal class BlobVirtualDirectoryClientInternals : BlobVirtualDirectoryClient
    {
        /// <summary>
        /// Prevent instantiation.
        /// </summary>
        private BlobVirtualDirectoryClientInternals() { }

        /// <summary>
        /// Get a <see cref="BlobVirtualDirectoryClient"/>'s <see cref="HttpPipeline"/>
        /// for creating child clients.
        /// </summary>
        /// <param name="client">The BlobServiceClient.</param>
        /// <returns>The BlobServiceClient's HttpPipeline.</returns>
        public static new HttpPipeline GetHttpPipeline(BlobVirtualDirectoryClient client) =>
            BlobVirtualDirectoryClient.GetHttpPipeline(client);

        /// <summary>
        /// Get a <see cref="BlobVirtualDirectoryClient"/>'s <see cref="BlobClientOptions"/>
        /// for creating child clients.
        /// </summary>
        /// <param name="client">The BlobServiceClient.</param>
        /// <returns>The BlobServiceClient's BlobClientOptions.</returns>
        public static new BlobClientOptions GetClientOptions(BlobVirtualDirectoryClient client) =>
            BlobVirtualDirectoryClient.GetClientOptions(client);
    }
}
