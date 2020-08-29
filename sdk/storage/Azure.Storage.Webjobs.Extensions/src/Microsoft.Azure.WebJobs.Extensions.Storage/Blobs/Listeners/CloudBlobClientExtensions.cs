// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
{
    internal static class CloudBlobClientExtensions
    {
        public static async Task<(BlobContainerClient, IEnumerable<BlobItem>)> ListBlobsAsync(this BlobServiceClient client,
            string prefix, CancellationToken cancellationToken)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            string containerName;
            string listingPrefix;
            ParseUserPrefix(prefix, out containerName, out listingPrefix);

            BlobContainerClient container = client.GetBlobContainerClient(containerName);

            var blobsPageable = container.GetBlobsAsync(cancellationToken: cancellationToken);

            List<BlobItem> allResults = new List<BlobItem>();
            await foreach (BlobItem blobItem in blobsPageable.ConfigureAwait(false))
            {
                allResults.Add(blobItem);
            }
            return (container, allResults);
        }

        /// <summary>
        /// Parses the user prefix.
        /// </summary>
        /// <param name="prefix">The prefix.</param>
        /// <param name="containerName">Name of the container.</param>
        /// <param name="listingPrefix">The listing prefix.</param>
        private static void ParseUserPrefix(string prefix, out string containerName, out string listingPrefix)
        {
            if (prefix == null)
            {
                throw new ArgumentNullException(nameof(prefix));
            }
            containerName = null;
            listingPrefix = null;

            string[] prefixParts = prefix.Split("/".ToCharArray(), 2, StringSplitOptions.None);
            if (prefixParts.Length == 1)
            {
                // No slash in prefix
                // Case abc => container = $root, prefix=abc; Listing with prefix at root
                listingPrefix = prefixParts[0];
            }
            else
            {
                // Case "/abc" => container=$root, prefix=abc; Listing with prefix at root
                // Case "abc/" => container=abc, no prefix; Listing all under a container
                // Case "abc/def" => container = abc, prefix = def; Listing with prefix under a container
                // Case "/" => container=$root, no prefix; Listing all under root
                containerName = prefixParts[0];
                listingPrefix = prefixParts[1];
            }

            if (string.IsNullOrEmpty(containerName))
            {
                containerName = "$root";
            }

            if (string.IsNullOrEmpty(listingPrefix))
            {
                listingPrefix = null;
            }
        }
    }
}
