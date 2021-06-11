// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs.DataMovement
{
    /// <summary>
    /// AzureContainerScanner class.
    /// </summary>
    public class BlobScanner
    {
        private readonly BlobContainerClient _containerClient;

        /// <summary>
        /// Constuctor for AzureContainerScanner.
        /// </summary>
        /// <param name="client"></param>
        public BlobScanner(BlobContainerClient client)
        {
            // Hacky deep-clone to prevent client changes mid-operation
            _containerClient = client.GetParentBlobServiceClient().GetBlobContainerClient(client.Name);
        }

        /// <summary>
        /// Constuctor for AzureContainerScanner.
        /// </summary>
        /// <returns>Async enumerable list containing the name of all blobs in the container.</returns>
        public async IAsyncEnumerable<string> Scan()
        {
            // Return the names of all blobs inside the container
            await foreach (Models.BlobItem blob in _containerClient.GetBlobsAsync().ConfigureAwait(false))
            {
                yield return blob.Name;
            }
        }
    }
}
