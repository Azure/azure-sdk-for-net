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
    internal class BlobScanner
    {
        /// <summary>
        /// User-provided container client to be used for scanning.
        /// </summary>
        private readonly BlobContainerClient _containerClient;

        /// <summary>
        /// Constructor for AzureContainerScanner.
        /// </summary>
        /// <param name="client">A <see cref="BlobContainerClient"/> targeting the container to be scanned.</param>
        public BlobScanner(BlobContainerClient client)
        {
            _containerClient = client;
        }

        /// <summary>
        /// Scans the blob container passed to the scanner.
        /// </summary>
        /// <returns>An <see cref="IAsyncEnumerable{String}"/> containing the names of all blobs in the container.</returns>
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
