// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.Blobs.Tests
{
    public static class ClientBuilderExtensions
    {
        public static string GetGarbageLeaseId(this ClientBuilder<BlobServiceClient, BlobClientOptions> clientBuilder)
            => clientBuilder.Recording.Random.NewGuid().ToString();
        public static string GetNewContainerName(this ClientBuilder<BlobServiceClient, BlobClientOptions> clientBuilder)
            => $"test-container-{clientBuilder.Recording.Random.NewGuid()}";
        public static string GetNewBlobName(this ClientBuilder<BlobServiceClient, BlobClientOptions> clientBuilder)
            => $"test-blob-{clientBuilder.Recording.Random.NewGuid()}";
        public static string GetNewBlockName(this ClientBuilder<BlobServiceClient, BlobClientOptions> clientBuilder)
            => $"test-block-{clientBuilder.Recording.Random.NewGuid()}";
        public static string GetNewNonAsciiBlobName(this ClientBuilder<BlobServiceClient, BlobClientOptions> clientBuilder)
            => $"test-β£©þ‽%3A-{clientBuilder.Recording.Random.NewGuid()}";

        public static async Task<DisposingContainer> GetTestContainerAsync(
            this ClientBuilder<BlobServiceClient, BlobClientOptions> clientBuilder,
            BlobServiceClient service = default,
            string containerName = default,
            IDictionary<string, string> metadata = default,
            PublicAccessType? publicAccessType = default,
            bool premium = default)
        {
            containerName ??= clientBuilder.GetNewContainerName();
            service ??= clientBuilder.GetServiceClient_SharedKey();

            if (publicAccessType == default)
            {
                publicAccessType = premium ? PublicAccessType.None : PublicAccessType.BlobContainer;
            }

            BlobContainerClient container = clientBuilder.AzureCoreRecordedTestBase.InstrumentClient(service.GetBlobContainerClient(containerName));
            await container.CreateIfNotExistsAsync(metadata: metadata, publicAccessType: publicAccessType.Value);
            return new DisposingContainer(container);
        }

        public class DisposingContainer : IAsyncDisposable
        {
            public BlobContainerClient Container;

            public DisposingContainer(BlobContainerClient client)
            {
                Container = client;
            }

            public async ValueTask DisposeAsync()
            {
                if (Container != null)
                {
                    try
                    {
                        await Container.DeleteIfExistsAsync();
                        Container = null;
                    }
                    catch
                    {
                        // swallow the exception to avoid hiding another test failure
                    }
                }
            }
        }
    }
}
