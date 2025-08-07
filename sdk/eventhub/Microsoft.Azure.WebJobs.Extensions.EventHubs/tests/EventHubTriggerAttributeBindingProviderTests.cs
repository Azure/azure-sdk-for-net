// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs.EventHubs;
using Microsoft.Azure.WebJobs.EventHubs.Listeners;
using Microsoft.Azure.WebJobs.EventHubs.Processor;
using Microsoft.Azure.WebJobs.EventHubs.Tests;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.EventHubs.UnitTests
{
    public class EventHubTriggerAttributeBindingProviderTests
    {
        private readonly EventHubTriggerAttributeBindingProvider _provider;

        public EventHubTriggerAttributeBindingProviderTests()
        {
            var configuration =
                ConfigurationUtilities.CreateConfiguration(
                    new KeyValuePair<string, string>("connection", "Endpoint=sb://test.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=;"),
                    new KeyValuePair<string, string>("Storage", "Endpoint=sb://test.blob.core.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123="));

            var options = new EventHubOptions();

            Mock<IConverterManager> convertManager = new Mock<IConverterManager>(MockBehavior.Default);

            // mock the BlobServiceClient and BlobContainerClient which are used for the checkpointing
            var blobServiceClient = new Mock<BlobServiceClient>();
            blobServiceClient.Setup(client => client.GetBlobContainerClient(It.IsAny<string>()))
                .Returns(Mock.Of<BlobContainerClient>());
            var componentFactory = new Mock<AzureComponentFactory>();
            componentFactory.Setup(
                factory => factory.CreateClient(
                    typeof(BlobServiceClient),
                    It.IsAny<IConfiguration>(),
                    It.IsAny<TokenCredential>(),
                    It.IsAny<BlobClientOptions>())).Returns(blobServiceClient.Object);

            var factory = ConfigurationUtilities.CreateFactory(configuration, options, componentFactory.Object);
            _provider = new EventHubTriggerAttributeBindingProvider(convertManager.Object, Options.Create(options), NullLoggerFactory.Instance, factory, Mock.Of<IDrainModeManager>());
        }

        [Test]
        [TestCase(nameof(SingleDispatch), 1)]
        [TestCase(nameof(MultipleDispatch), 100)]
        public async Task TryCreateAsync_BatchCountsDefaultedCorrectly(string function, int expectedBatchCount)
        {
            ParameterInfo parameter = GetType().GetMethod(function, BindingFlags.NonPublic | BindingFlags.Static).GetParameters()[0];
            TriggerBindingProviderContext context = new TriggerBindingProviderContext(parameter, CancellationToken.None);

            ITriggerBinding binding = await _provider.TryCreateAsync(context);
            Assert.NotNull(binding);

            var listener = await binding.CreateListenerAsync(new ListenerFactoryContext(new FunctionDescriptor(),
                new Mock<ITriggeredFunctionExecutor>().Object, CancellationToken.None));

            var processorHost = (EventProcessorHost)typeof(EventHubListener)
                .GetField("_eventProcessorHost", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(listener);
            var batchCount = (int) typeof(EventProcessor<EventProcessorHostPartition>).GetProperty("EventBatchMaximumCount", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(processorHost);
            Assert.AreEqual(expectedBatchCount, batchCount);
        }

        internal static void SingleDispatch(
            [EventHubTrigger("test", Connection = "connection")]
            EventData eventData)
        {
        }

        internal static void MultipleDispatch(
            [EventHubTrigger("test", Connection = "connection")]
            EventData[] eventData)
        {
        }
    }
}