// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Testing;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.Blobs.ChangeFeed.Tests
{
    public class ChangeFeedTestBase : StorageTestBase
    {

        public ChangeFeedTestBase(bool async) : this(async, null) { }

        public ChangeFeedTestBase(bool async, RecordedTestMode? mode = null)
            : base(async, RecordedTestMode.Live)
        {
        }

        public string GetNewContainerName() => $"test-container-{Recording.Random.NewGuid()}";
        public string GetNewBlobName() => $"test-blob-{Recording.Random.NewGuid()}";

        public BlobServiceClient GetServiceClient_SharedKey()
            => InstrumentClient(
                new BlobServiceClient(
                    new Uri(TestConfigDefault.BlobServiceEndpoint),
                    new StorageSharedKeyCredential(
                        TestConfigDefault.AccountName,
                        TestConfigDefault.AccountKey),
                    GetOptions()));

        public BlobClientOptions GetOptions()
        {
            var options = new BlobClientOptions
            {
                Diagnostics = { IsLoggingEnabled = true },
                Retry =
                {
                    Mode = RetryMode.Exponential,
                    MaxRetries = Constants.MaxReliabilityRetries,
                    Delay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.01 : 0.5),
                    MaxDelay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.1 : 10)
                },
                Transport = GetTransport()
            };
            if (Mode != RecordedTestMode.Live)
            {
                options.AddPolicy(new RecordedClientRequestIdPolicy(Recording), HttpPipelinePosition.PerCall);
            }

            return Recording.InstrumentClientOptions(options);
        }

        public async Task<DisposingContainer> GetTestContainerAsync(
            BlobServiceClient service = default,
            string containerName = default,
            IDictionary<string, string> metadata = default,
            PublicAccessType? publicAccessType = default,
            bool premium = default)
        {

            containerName ??= GetNewContainerName();
            service ??= GetServiceClient_SharedKey();

            if (publicAccessType == default)
            {
                publicAccessType = premium ? PublicAccessType.None : PublicAccessType.BlobContainer;
            }

            BlobContainerClient container = InstrumentClient(service.GetBlobContainerClient(containerName));
            await container.CreateAsync(metadata: metadata, publicAccessType: publicAccessType.Value);
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
                        await Container.DeleteAsync();
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