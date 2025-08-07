// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Identity;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the Event Hubs
    ///   Sample06_RequestingStorageServiceVersions sample.
    /// </summary>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    public class Sample06_RequestingStorageServiceVersionsLiveTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ProcessEvents()
        {
            await using var eventHubScope = await EventHubScope.CreateAsync(1);
            await using var storageScope = await StorageScope.CreateAsync();

            #region Snippet:EventHubs_Processor_Sample06_ChooseStorageVersion

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
            var consumerGroup = eventHubScope.ConsumerGroups.First();

            var storageAccountEndpoint = $"https://{ StorageTestEnvironment.Instance.StorageAccountName }.blob.{ StorageTestEnvironment.Instance.StorageEndpointSuffix}";
            var blobContainerName = storageScope.ContainerName;
#endif

            var storageClientOptions = new BlobClientOptions();

            storageClientOptions.AddPolicy(
                new StorageApiVersionPolicy(),
                HttpPipelinePosition.PerCall);

            var blobUriBuilder = new BlobUriBuilder(new Uri(storageAccountEndpoint))
            {
                BlobContainerName = blobContainerName
            };

            var storageClient = new BlobContainerClient(
                blobUriBuilder.ToUri(),
                credential,
                storageClientOptions);

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
                // The processor will automatically attempt to recover from any
                // failures, either transient or fatal, and continue processing.
                // Errors in the processor's operation will be surfaced through
                // its error handler.
                //
                // If this block is invoked, then something external to the
                // processor was the source of the exception.
            }
            finally
            {
               // It is encouraged that you unregister your handlers when you have
               // finished using the Event Processor to ensure proper cleanup.  This
               // is especially important when using lambda expressions or handlers
               // in any form that may contain closure scopes or hold other references.

               processor.ProcessEventAsync -= Application.ProcessorEventHandler;
               processor.ProcessErrorAsync -= Application.ProcessorErrorHandler;
            }

            #endregion
        }

        #region Snippet:EventHubs_Processor_Sample06_StorageVersionPolicy

        /// <summary>
        ///   A pipeline policy to be applied to a Blob Container Client.  This policy
        ///   will be applied to every request sent by the client, making it possible
        ///   to specify the Azure Storage version they will target.
        /// </summary>
        ///
        private class StorageApiVersionPolicy : HttpPipelineSynchronousPolicy
        {
            /// <summary>
            ///   The Azure Storage version we want to use.
            /// </summary>
            ///
            /// <remarks>
            ///   2017-11-09 is the latest version available in Azure Stack Hub 2002.
            ///   Other available versions could always be specified as long as all
            ///   operations used by the Event Processor Client are supported.
            /// </remarks>
            ///
            private string Version => @"2017-11-09";

            /// <summary>
            ///   A method that will be called before a request is sent to the Azure
            ///   Storage service.  Here we are overriding this method and injecting
            ///   the version we want to change to into the request headers.
            /// </summary>
            ///
            /// <param name="message">The message to be sent to the Azure Storage service.</param>
            ///
            public override void OnSendingRequest(HttpMessage message)
            {
                base.OnSendingRequest(message);
                message.Request.Headers.SetValue("x-ms-version", Version);
            }
        }

        #endregion

        /// <summary>
        ///   Serves as a simulation of the host application for
        ///   examples.
        /// </summary>
        ///
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
