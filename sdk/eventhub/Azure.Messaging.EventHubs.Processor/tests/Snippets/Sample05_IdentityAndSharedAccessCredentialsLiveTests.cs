// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.Messaging.EventHubs.Processor;
using Azure.Messaging.EventHubs.Processor.Tests;
using Azure.Storage.Blobs;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the Event Hubs
    ///   Sample05_IdentityAndSharedAccessCredentials sample.
    /// </summary>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    [SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Example assignments needed for snippet output content.")]
    public class Sample05_IdentityAndSharedAccessCredentialsLiveTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task DefaultAzureCredential()
        {
            await using var eventHubScope = await EventHubScope.CreateAsync(1);
            await using var storageScope = await StorageScope.CreateAsync();

            #region Snippet:EventHubs_Processor_Sample05_DefaultAzureCredential

            TokenCredential credential = new DefaultAzureCredential();

            var storageEndpoint = "<< STORAGE ENDPOINT (likely similar to {your-account}.blob.core.windows.net) >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";
            /*@@*/
            /*@@*/ storageEndpoint = new BlobServiceClient(StorageTestEnvironment.Instance.StorageConnectionString).Uri.ToString();
            /*@@*/ blobContainerName = storageScope.ContainerName;

            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
            /*@@*/
            /*@@*/ fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            /*@@*/ eventHubName = eventHubScope.EventHubName;
            /*@@*/ consumerGroup = eventHubScope.ConsumerGroups.First();
            /*@@*/ credential = EventHubsTestEnvironment.Instance.Credential;

            var blobUriBuilder = new BlobUriBuilder(new Uri(storageEndpoint));
            blobUriBuilder.BlobContainerName = blobContainerName;

            var storageClient = new BlobContainerClient(
                blobUriBuilder.ToUri(),
                credential);

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                fullyQualifiedNamespace,
                eventHubName,
                credential);

            try
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                // The event handlers are not relevant for this sample; for
                // illustration, they're delegating the implementation to the
                // host application.

                processor.ProcessEventAsync += Application.ProcessorEventHandler;
                processor.ProcessErrorAsync += Application.ProcessorErrorHandler;

                try
                {
                    await processor.StartProcessingAsync(cancellationSource.Token);
                    await Task.Delay(Timeout.Infinite, cancellationSource.Token);
                }
                catch (TaskCanceledException)
                {
                    // This is expected if the cancellation token is
                    // signaled.
                }
                finally
                {
                    // This may take up to the length of time defined
                    // as part of the configured TryTimeout of the processor;
                    // by default, this is 60 seconds.

                    await processor.StopProcessingAsync();
                }
            }
            catch
            {
                // If this block is invoked, then something external to the
                // processor was the source of the exception.
            }
            finally
            {
               // It is encouraged that you unregister your handlers when you have
               // finished using the Event Processor to ensure proper cleanup.

               processor.ProcessEventAsync -= Application.ProcessorEventHandler;
               processor.ProcessErrorAsync -= Application.ProcessorErrorHandler;
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ConnectionStringParse()
        {
            await using var eventHubScope = await EventHubScope.CreateAsync(1);
            await using var storageScope = await StorageScope.CreateAsync();

            #region Snippet:EventHubs_Processor_Sample05_ConnectionStringParse

            TokenCredential credential = new DefaultAzureCredential();

            var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";
            /*@@*/
            /*@@*/ storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
            /*@@*/ blobContainerName = storageScope.ContainerName;

            var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
            /*@@*/
            /*@@*/ eventHubsConnectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = eventHubScope.EventHubName;
            /*@@*/ consumerGroup = eventHubScope.ConsumerGroups.First();
            /*@@*/ credential = EventHubsTestEnvironment.Instance.Credential;

            var storageEndpoint = new BlobServiceClient(storageConnectionString).Uri;
            var blobUriBuilder = new BlobUriBuilder(storageEndpoint);
            blobUriBuilder.BlobContainerName = blobContainerName;

            var storageClient = new BlobContainerClient(
                blobUriBuilder.ToUri(),
                credential);

            EventHubsConnectionStringProperties properties =
                EventHubsConnectionStringProperties.Parse(eventHubsConnectionString);

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                properties.FullyQualifiedNamespace,
                properties.EventHubName ?? eventHubName,
                credential);

            try
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                // The event handlers are not relevant for this sample; for
                // illustration, they're delegating the implementation to the
                // host application.

                processor.ProcessEventAsync += Application.ProcessorEventHandler;
                processor.ProcessErrorAsync += Application.ProcessorErrorHandler;

                try
                {
                    await processor.StartProcessingAsync(cancellationSource.Token);
                    await Task.Delay(Timeout.Infinite, cancellationSource.Token);
                }
                catch (TaskCanceledException)
                {
                    // This is expected if the cancellation token is
                    // signaled.
                }
                finally
                {
                    // This may take up to the length of time defined
                    // as part of the configured TryTimeout of the processor;
                    // by default, this is 60 seconds.

                    await processor.StopProcessingAsync();
                }
            }
            catch
            {
                // If this block is invoked, then something external to the
                // processor was the source of the exception.
            }
            finally
            {
               // It is encouraged that you unregister your handlers when you have
               // finished using the Event Processor to ensure proper cleanup.

               processor.ProcessEventAsync -= Application.ProcessorEventHandler;
               processor.ProcessErrorAsync -= Application.ProcessorErrorHandler;
            }

            #endregion
        }

        /// <summary>
        ///   Serves as a simulation of the host application for
        ///   examples.
        /// </summary>
        ///
        [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Simulated class for illustration in samples.")]
        private static class Application
        {
            /// <summary>
            ///   A simulated method that an application would register as an event handler.
            /// </summary>
            ///
            /// <param name="errorEventArgs">The arguments associated with the event.</param>
            ///
            public static Task ProcessorEventHandler(ProcessEventArgs eventArgs) => Task.CompletedTask;

            /// <summary>
            ///   A simulated method that an application would register as an error handler.
            /// </summary>
            ///
            /// <param name="eventArgs">The arguments associated with the error.</param>
            ///
            public static Task ProcessorErrorHandler(ProcessErrorEventArgs eventArgs) => Task.CompletedTask;
        }
    }
}
