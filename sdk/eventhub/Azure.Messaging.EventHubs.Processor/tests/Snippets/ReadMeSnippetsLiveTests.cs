﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;
using Azure.Messaging.EventHubs.Processor.Tests;
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
    [SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Example assignments needed for snippet output content.")]
    public class ReadMeSnippetsLiveTests

    {
        /// <summary>The active Event Hub resource scope for the test fixture.</summary>
        private EventHubScope _eventHubScope;

        /// <summary>The active Blob storage resource scope for the test fixture.</summary>
        private StorageScope _storageScope;

        /// <summary>
        ///   Performs the tasks needed to initialize the test fixture.  This
        ///   method runs once for the entire fixture, prior to running any tests.
        /// </summary>
        ///
        [OneTimeSetUp]
        public async Task FixtureSetUp()
        {
            _eventHubScope = await EventHubScope.CreateAsync(2);
            _storageScope = await StorageScope.CreateAsync();
        }

        /// <summary>
        ///   Performs the tasks needed to cleanup the test fixture after all
        ///   tests have run.  This method runs once for the entire fixture.
        /// </summary>
        ///
        [OneTimeTearDown]
        public async Task FixtureTearDown()
        {
            await Task.WhenAll
            (
                _eventHubScope.DisposeAsync().AsTask(),
                _storageScope.DisposeAsync().AsTask()
            );
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void Create()
        {
            #region Snippet:EventHubs_Processor_ReadMe_Create

            var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";
            /*@@*/
            /*@@*/ storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
            /*@@*/ blobContainerName = _storageScope.ContainerName;

            var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
            /*@@*/
            /*@@*/ eventHubsConnectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = _eventHubScope.EventHubName;
            /*@@*/ consumerGroup = _eventHubScope.ConsumerGroups.First();

            BlobContainerClient storageClient = new BlobContainerClient(storageConnectionString, blobContainerName);

            EventProcessorClient processor = new EventProcessorClient
            (
                storageClient,
                consumerGroup,
                eventHubsConnectionString,
                eventHubName
            );

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

            var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";
            /*@@*/
            /*@@*/ storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
            /*@@*/ blobContainerName = _storageScope.ContainerName;

            var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
            /*@@*/
            /*@@*/ eventHubsConnectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = _eventHubScope.EventHubName;
            /*@@*/ consumerGroup = _eventHubScope.ConsumerGroups.First();

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

            var storageClient = new BlobContainerClient(storageConnectionString, blobContainerName);
            var processor = new EventProcessorClient(storageClient, consumerGroup, eventHubsConnectionString, eventHubName);

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
            #region Snippet:EventHubs_Processor_ReadMe_ProcessUntilCanceled

            var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(45));

            var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";
            /*@@*/
            /*@@*/ storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
            /*@@*/ blobContainerName = _storageScope.ContainerName;

            var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
            /*@@*/
            /*@@*/ eventHubsConnectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = _eventHubScope.EventHubName;
            /*@@*/ consumerGroup = _eventHubScope.ConsumerGroups.First();

            Task processEventHandler(ProcessEventArgs eventArgs) => Task.CompletedTask;
            Task processErrorHandler(ProcessErrorEventArgs eventArgs) => Task.CompletedTask;

            var storageClient = new BlobContainerClient(storageConnectionString, blobContainerName);
            var processor = new EventProcessorClient(storageClient, consumerGroup, eventHubsConnectionString, eventHubName);

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

            TokenCredential credential = new DefaultAzureCredential();
            /*@@*/ credential = EventHubsTestEnvironment.Instance.Credential;

            string blobStorageUrl ="<< FULLY-QUALIFIED CONTAINER URL (like https://myaccount.blob.core.windows.net/mycontainer) >>";
            /*@@*/ blobStorageUrl = $"https://{ StorageTestEnvironment.Instance.StorageAccountName }.{ StorageTestEnvironment.Instance.StorageEndpointSuffix }/{ _storageScope.ContainerName }";
            /*@@*/
            BlobContainerClient storageClient = new BlobContainerClient(new Uri(blobStorageUrl), credential);

            var fullyQualifiedNamespace = "<< FULLY-QUALIFIED EVENT HUBS NAMESPACE (like something.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
            /*@@*/
            /*@@*/ fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            /*@@*/ eventHubName = _eventHubScope.EventHubName;
            /*@@*/ consumerGroup = _eventHubScope.ConsumerGroups.First();

            EventProcessorClient processor = new EventProcessorClient
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
