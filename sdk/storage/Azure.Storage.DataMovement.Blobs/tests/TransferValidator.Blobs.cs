// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias BaseBlobs;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using BaseBlobs::Azure.Storage.Blobs;
using BaseBlobs::Azure.Storage.Blobs.Models;
using BaseBlobs::Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.DataMovement.Tests
{
    public partial class TransferValidator
    {
        public class BlobResourceEnumerationItem : IResourceEnumerationItem
        {
            private readonly BlobBaseClient _client;

            public string RelativePath { get; }

            public BlobResourceEnumerationItem(BlobBaseClient client, string relativePath)
            {
                _client = client;
                RelativePath = relativePath;
            }

            public async Task<Stream> OpenReadAsync(CancellationToken cancellationToken)
            {
                return await _client.OpenReadAsync(cancellationToken: cancellationToken);
            }
        }

        public static ListFilesAsync GetBlobLister(BlobContainerClient container, string blobPrefix)
        {
            async Task<List<IResourceEnumerationItem>> ListBlobs(CancellationToken cancellationToken)
            {
                List<IResourceEnumerationItem> result = new();
                GetBlobsOptions options = new()
                {
                    Prefix = blobPrefix
                };
                await foreach (BlobItem blobItem in container.GetBlobsAsync(options, cancellationToken: cancellationToken))
                {
                    result.Add(new BlobResourceEnumerationItem(container.GetBlobClient(blobItem.Name), blobItem.Name.Substring(blobPrefix.Length)));
                }
                return result;
            }
            return ListBlobs;
        }

        public static ListFilesAsync GetBlobListerSingle(BlobBaseClient blob, string relativePath)
        {
            Task<List<IResourceEnumerationItem>> ListBlobs(CancellationToken cancellationToken)
            {
                return Task.FromResult(new List<IResourceEnumerationItem>
                {
                    new BlobResourceEnumerationItem(blob, relativePath)
                });
            }
            return ListBlobs;
        }
    }
}
