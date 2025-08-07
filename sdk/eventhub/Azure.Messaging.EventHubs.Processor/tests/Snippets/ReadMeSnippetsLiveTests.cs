// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the Event Hubs
    ///   README.
    /// </summary>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    public class ReadMeSnippetsLiveTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void Create()
        {
            #region Snippet:EventHubs_Processor_ReadMe_Create

#if SNIPPET
            // The container specified when creating the BlobContainerClient must exist; it will
            // not be implicitly created.

            var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

            var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
#else
            var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
            var blobContainerName = "not-real";
            var eventHubsConnectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = "fakeHub";
            var consumerGroup = "fakeConsumer";
#endif

            var storageClient = new BlobContainerClient(storageConnectionString, blobContainerName);
            var processor = new EventProcessorClient(storageClient, consumerGroup, eventHubsConnectionString, eventHubName);

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void ConfigureHandlers()
        {
            #region Snippet:EventHubs_Processor_ReadMe_ConfigureHandlers

#if SNIPPET
            var credential = new DefaultAzureCredential();

            var storageAccountEndpoint = "<< Account Uri (likely similar to https://{your-account}.blob.core.windows.net) >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
#else
            var credential = EventHubsTestEnvironment.Instance.Credential;

            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = "fake-hub";
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

            var storageAccountEndpoint = $"https://{ StorageTestEnvironment.Instance.StorageAccountName }.blob.{ StorageTestEnvironment.Instance.StorageEndpointSuffix}";
            var blobContainerName = "fake";
#endif

            async Task processEventHandler(ProcessEventArgs eventArgs)
            {
                try
                {
                    // Perform the application-specific processing for an event.  This method
                    // is intended for illustration and is not defined in this snippet.

                    await DoSomethingWithTheEvent(eventArgs.Partition, eventArgs.Data);
                }
                catch
                {
                    // Handle the exception from handler code
                }
            }

            async Task processErrorHandler(ProcessErrorEventArgs eventArgs)
            {
                try
                {
                    // Perform the application-specific processing for an error.  This method
                    // is intended for illustration and is not defined in this snippet.

                    await DoSomethingWithTheError(eventArgs.Exception);
                }
                catch
                {
                    // Handle the exception from handler code
                }
            }

            var blobUriBuilder = new BlobUriBuilder(new Uri(storageAccountEndpoint))
            {
                BlobContainerName = blobContainerName
            };

            var storageClient = new BlobContainerClient(
                blobUriBuilder.ToUri(),
                credential);

            var processor = new EventProcessorClient
            (
                storageClient,
                consumerGroup,
                fullyQualifiedNamespace,
                eventHubName,
                credential
            );

            processor.ProcessEventAsync += processEventHandler;
            processor.ProcessErrorAsync += processErrorHandler;

            #endregion

            Task DoSomethingWithTheEvent(PartitionContext partition, EventData data) => Task.CompletedTask;
            Task DoSomethingWithTheError(Exception ex) => Task.CompletedTask;
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ProcessUntilCanceled()
        {
            await using var eventHubScope = await EventHubScope.CreateAsync(2);
            await using var storageScope = await StorageScope.CreateAsync();

            #region Snippet:EventHubs_Processor_ReadMe_ProcessUntilCanceled

            var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(45));

#if SNIPPET
            var credential = new DefaultAzureCredential();

            var storageAccountEndpoint = "<< Account Uri (likely similar to https://{your-account}.blob.core.windows.net) >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
#else
            var credential = EventHubsTestEnvironment.Instance.Credential;

            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = eventHubScope.EventHubName;
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

            var storageAccountEndpoint = $"https://{ StorageTestEnvironment.Instance.StorageAccountName }.blob.{ StorageTestEnvironment.Instance.StorageEndpointSuffix}";
            var blobContainerName = storageScope.ContainerName;
#endif

            Task processEventHandler(ProcessEventArgs eventArgs) => Task.CompletedTask;
            Task processErrorHandler(ProcessErrorEventArgs eventArgs) => Task.CompletedTask;

            var blobUriBuilder = new BlobUriBuilder(new Uri(storageAccountEndpoint))
            {
                BlobContainerName = blobContainerName
            };

            var storageClient = new BlobContainerClient(
                blobUriBuilder.ToUri(),
                credential);

            var processor = new EventProcessorClient
            (
                storageClient,
                consumerGroup,
                fullyQualifiedNamespace,
                eventHubName,
                credential
            );

            processor.ProcessEventAsync += processEventHandler;
            processor.ProcessErrorAsync += processErrorHandler;

            await processor.StartProcessingAsync();

            try
            {
                // The processor performs its work in the background; block until cancellation
                // to allow processing to take place.

                await Task.Delay(Timeout.Infinite, cancellationSource.Token);
            }
            catch (TaskCanceledException)
            {
                // This is expected when the delay is canceled.
            }

            try
            {
                await processor.StopProcessingAsync();
            }
            finally
            {
                // To prevent leaks, the handlers should be removed when processing is complete.

                processor.ProcessEventAsync -= processEventHandler;
                processor.ProcessErrorAsync -= processErrorHandler;
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void CreateWithIdentity()
        {
            #region Snippet:EventHubs_Processor_ReadMe_CreateWithIdentity

#if SNIPPET
            var credential = new DefaultAzureCredential();

            var storageAccountEndpoint = "<< Account Uri (likely similar to https://{your-account}.blob.core.windows.net) >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
#else
            var credential = EventHubsTestEnvironment.Instance.Credential;

            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = "fake-hub";
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

            var storageAccountEndpoint = $"https://{ StorageTestEnvironment.Instance.StorageAccountName }.blob.{ StorageTestEnvironment.Instance.StorageEndpointSuffix}";
            var blobContainerName = "fake";
#endif

            var blobUriBuilder = new BlobUriBuilder(new Uri(storageAccountEndpoint))
            {
                BlobContainerName = blobContainerName
            };

            var storageClient = new BlobContainerClient(
                blobUriBuilder.ToUri(),
                credential);

            var processor = new EventProcessorClient
            (
                storageClient,
                consumerGroup,
                fullyQualifiedNamespace,
                eventHubName,
                credential
            );

            #endregion
        }
    }
}
