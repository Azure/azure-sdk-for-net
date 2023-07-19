// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs.EventHubs.Processor;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;

namespace Microsoft.Azure.WebJobs.EventHubs.Tests
{
    public static class ConfigurationUtilities
    {
        public static IConfiguration CreateConfiguration(params KeyValuePair<string, string>[] data)
        {
            return new ConfigurationBuilder().AddInMemoryCollection(data).Build();
        }

        internal static EventHubClientFactory CreateFactory(IConfiguration configuration, EventHubOptions options, AzureComponentFactory componentFactory = null)
        {
            componentFactory ??= Mock.Of<AzureComponentFactory>();
            var loggerFactory = new NullLoggerFactory();
            var azureEventSourceLogForwarder = new AzureEventSourceLogForwarder(loggerFactory);
            return new EventHubClientFactory(
                configuration,
                componentFactory,
                Options.Create(options),
                new DefaultNameResolver(configuration),
                azureEventSourceLogForwarder,
                new CheckpointClientProvider(configuration, componentFactory, azureEventSourceLogForwarder, loggerFactory.CreateLogger<BlobServiceClient>()));
        }
    }
}