// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Tests;
using Azure.Storage.Blobs;
using Azure.Test.Perf;

namespace Azure.Messaging.EventHubs.Processor.Perf.Infrastructure
{
    public abstract class ProcessorTest<TOptions> : EventPerfTest<TOptions> where TOptions : ProcessorOptions
    {
        private readonly BlobContainerClient _checkpointStore;

        protected EventProcessorClient EventProcessorClient { get; }

        public ProcessorTest(TOptions options) : base(options)
        {
            _checkpointStore = new BlobContainerClient(StorageTestEnvironment.Instance.StorageConnectionString,
                $"CheckpointStore-{Guid.NewGuid()}".ToLowerInvariant());

            var clientOptions = new EventProcessorClientOptions() {
                LoadBalancingStrategy = options.LoadBalancingStrategy
            };

            if (options.CacheEventCount.HasValue)
            {
                clientOptions.CacheEventCount = options.CacheEventCount.Value;
            }

            if (options.MaximumWaitTimeMs.HasValue)
            {
                clientOptions.MaximumWaitTime = TimeSpan.FromMilliseconds(options.MaximumWaitTimeMs.Value);
            }

            if (options.PrefetchCount.HasValue)
            {
                clientOptions.PrefetchCount = options.PrefetchCount.Value;
            }

            EventProcessorClient = new EventProcessorClient(
                _checkpointStore,
                EventHubConsumerClient.DefaultConsumerGroupName,
                EventHubsTestEnvironment.Instance.EventHubsConnectionString,
                EventHubsTestEnvironment.Instance.EventHubNameOverride,
                clientOptions);
        }

        public override async Task SetupAsync()
        {
            await base.SetupAsync();
            await _checkpointStore.CreateIfNotExistsAsync();
        }

        public override async Task CleanupAsync()
        {
            await _checkpointStore.DeleteIfExistsAsync();
            await base.CleanupAsync();
        }
    }
}
