// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Processor;
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

            var blobUriBuilder = new BlobUriBuilder(new Uri(storageAccountEndpoint))
            {
                BlobContainerName = blobContainerName
            };

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
        public async Task SharedAccessSignature()
        {
            await using var eventHubScope = await EventHubScope.CreateAsync(1);
            await using var storageScope = await StorageScope.CreateAsync();

            #region Snippet:EventHubs_Processor_Sample05_SharedAccessSignature

#if SNIPPET
            var credential = new AzureSasCredential("<< SHARED ACCESS KEY STRING >>");

            var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
#else
            var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
            var blobContainerName = storageScope.ContainerName;
            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = eventHubScope.EventHubName;
            var consumerGroup = eventHubScope.ConsumerGroups.First();

            var resource = $"amqps://{ EventHubsTestEnvironment.Instance.FullyQualifiedNamespace }/{ eventHubScope.EventHubName }".ToLowerInvariant();
            var signature = new SharedAccessSignature(resource, EventHubsTestEnvironment.Instance.SharedAccessKeyName, EventHubsTestEnvironment.Instance.SharedAccessKey);
            var credential = new AzureSasCredential(signature.Value);
#endif

             var storageClient = new BlobContainerClient(
                storageConnectionString,
                blobContainerName);

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
        public async Task SharedAccessKey()
        {
            await using var eventHubScope = await EventHubScope.CreateAsync(1);
            await using var storageScope = await StorageScope.CreateAsync();

            #region Snippet:EventHubs_Processor_Sample05_SharedAccessKey

#if SNIPPET
            var credential = new AzureNamedKeyCredential("<< SHARED KEY NAME >>", "<< SHARED KEY >>");

            var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
#else
            var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
            var blobContainerName = storageScope.ContainerName;
            var fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            var eventHubName = eventHubScope.EventHubName;
            var consumerGroup = eventHubScope.ConsumerGroups.First();
            var credential = new AzureNamedKeyCredential(EventHubsTestEnvironment.Instance.SharedAccessKeyName, EventHubsTestEnvironment.Instance.SharedAccessKey);
#endif

             var storageClient = new BlobContainerClient(
                storageConnectionString,
                blobContainerName);

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

#if SNIPPET
            var credential = new DefaultAzureCredential();

            var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";

            var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";
#else
            var credential = EventHubsTestEnvironment.Instance.Credential;
            var eventHubsConnectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = eventHubScope.EventHubName;
            var consumerGroup = eventHubScope.ConsumerGroups.First();
            var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
            var blobContainerName = storageScope.ContainerName;
#endif
            var storageEndpoint = new BlobServiceClient(storageConnectionString).Uri;

            var blobUriBuilder = new BlobUriBuilder(storageEndpoint)
            {
                BlobContainerName = blobContainerName
            };

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
