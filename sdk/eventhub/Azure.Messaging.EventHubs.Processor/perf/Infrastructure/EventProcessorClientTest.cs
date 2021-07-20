﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Tests;
using Azure.Storage.Blobs;
using Azure.Test.Perf;

namespace Azure.Messaging.EventHubs.Processor.Perf.Infrastructure
{
    public abstract class EventProcessorClientTest<TOptions> : PerfTest<TOptions> where TOptions : EventProcessorClientPerfOptions
    {
        private readonly BlobContainerClient _checkpointStore;

        protected EventProcessorClient EventProcessorClient { get; }

        public EventProcessorClientTest(TOptions options) : base(options)
        {
            _checkpointStore = new BlobContainerClient(GetEnvironmentVariable("STORAGE_CONNECTION_STRING"),
                $"CheckpointStore-{Guid.NewGuid()}".ToLowerInvariant());

            EventProcessorClient = new EventProcessorClient(
                _checkpointStore,
                EventHubConsumerClient.DefaultConsumerGroupName,
                EventHubsTestEnvironment.Instance.EventHubsConnectionString,
                EventHubsTestEnvironment.Instance.EventHubsNamespace,
                new EventProcessorClientOptions()
                {
                    LoadBalancingStrategy = options.LoadBalancingStrategy,
                });
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
