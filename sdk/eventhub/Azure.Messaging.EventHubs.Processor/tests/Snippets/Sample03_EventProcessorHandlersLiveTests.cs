// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the Event Hubs
    ///   Sample03_EventProcessorHandlers sample.
    /// </summary>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    public class Sample03_EventProcessorHandlersLiveTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void EventHandlerExceptionHandling()
        {
            #region Snippet:EventHubs_Processor_Sample03_EventHandlerExceptionHandling

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
            var eventHubName = "fake";
            var consumerGroup = "$Default";

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

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                fullyQualifiedNamespace,
                eventHubName,
                credential);

            Task processEventHandler(ProcessEventArgs args)
            {
                try
                {
                    // TODO:
                    //   Process the event according to application needs.
                }
                catch
                {
                    // TODO:
                    //   Take action to handle the exception.
                    //
                    //   It is important that all exceptions are
                    //   handled and none are permitted to bubble up.
                }

                return Task.CompletedTask;
            }

            try
            {
                processor.ProcessEventAsync += processEventHandler;

                // Starting and stopping the processor are not
                // shown in this example.
            }
            finally
            {
                processor.ProcessEventAsync -= processEventHandler;
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void EventHandlerCancellation()
        {
            #region Snippet:EventHubs_Processor_Sample03_EventHandlerCancellation

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
            var eventHubName = "fake";
            var consumerGroup = "$Default";

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

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                fullyQualifiedNamespace,
                eventHubName,
                credential);

            Task processEventHandler(ProcessEventArgs args)
            {
                try
                {
                    if (args.CancellationToken.IsCancellationRequested)
                    {
                        return Task.CompletedTask;
                    }

                    // TODO:
                    //   Process the event according to application needs.
                }
                catch
                {
                    // TODO:
                    //   Take action to handle the exception.
                    //
                    //   It is important that all exceptions are
                    //   handled and none are permitted to bubble up.
                }

                return Task.CompletedTask;
            }

            try
            {
                processor.ProcessEventAsync += processEventHandler;

                // Starting and stopping the processor are not
                // shown in this example.
            }
            finally
            {
                processor.ProcessEventAsync -= processEventHandler;
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task EventHandlerStopOnException()
        {
            await using var eventHubScope = await EventHubScope.CreateAsync(1);
            await using var storageScope = await StorageScope.CreateAsync();

            #region Snippet:EventHubs_Processor_Sample03_EventHandlerStopOnException

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
            var consumerGroup = "$Default";

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

            // This token is used to control processing,
            // if signaled, then processing will be stopped.

            using var cancellationSource = new CancellationTokenSource();
#if !SNIPPET
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));
#endif

            Task processEventHandler(ProcessEventArgs args)
            {
                try
                {
                    if (args.CancellationToken.IsCancellationRequested)
                    {
                        return Task.CompletedTask;
                    }

                    // TODO:
                    //   Process the event according to application needs.
                }
                catch
                {
                    // TODO:
                    //   Take action to handle the exception.
                    //
                    //   It is important that all exceptions are
                    //   handled and none are permitted to bubble up.

                    cancellationSource.Cancel();
                }

                return Task.CompletedTask;
            }

            async Task processErrorHandler(ProcessErrorEventArgs args)
            {
                // Allow the application to handle the exception according to
                // its business logic.

                await HandleExceptionAsync(args.Exception, args.CancellationToken);
            }

            try
            {
                processor.ProcessEventAsync += processEventHandler;
                processor.ProcessErrorAsync += processErrorHandler;

                try
                {
                    // Once processing has started, the delay will
                    // block to allow processing until cancellation
                    // is requested.

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
            finally
            {
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
        public void ErrorHandlerArgs()
        {
            #region Snippet:EventHubs_Processor_Sample03_ErrorHandlerArgs

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
            var eventHubName = "fake";
            var consumerGroup = "$Default";

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

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                fullyQualifiedNamespace,
                eventHubName,
                credential);

            Task processErrorHandler(ProcessErrorEventArgs args)
            {
                try
                {
                    if (args.CancellationToken.IsCancellationRequested)
                    {
                        return Task.CompletedTask;
                    }

                    Debug.WriteLine("Error in the EventProcessorClient");
                    Debug.WriteLine($"\tOperation: { args.Operation ?? "Unknown" }");
                    Debug.WriteLine($"\tPartition: { args.PartitionId ?? "None" }");
                    Debug.WriteLine($"\tException: { args.Exception }");
                    Debug.WriteLine("");
                }
                catch
                {
                    // TODO:
                    //   Take action to handle the exception.
                    //
                    //   It is important that all exceptions are
                    //   handled and none are permitted to bubble up.
                }

                return Task.CompletedTask;
            }

            try
            {
                processor.ProcessErrorAsync += processErrorHandler;

                // Starting and stopping the processor are not
                // shown in this example.
            }
            finally
            {
                processor.ProcessErrorAsync -= processErrorHandler;
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ErrorHandlerCancellationRecovery()
        {
            await using var eventHubScope = await EventHubScope.CreateAsync(1);
            await using var storageScope = await StorageScope.CreateAsync();

            #region Snippet:EventHubs_Processor_Sample03_ErrorHandlerCancellationRecovery

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
            var consumerGroup = "$Default";

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

            // This token is used to control processing,
            // if signaled, then processing will be stopped.

            using var cancellationSource = new CancellationTokenSource();
#if !SNIPPET
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(10));
#endif

            Task processEventHandler(ProcessEventArgs args)
            {
                try
                {
                    // TODO:
                    //   Process the event according to application needs.
                }
                catch
                {
                    // TODO:
                    //   Take action to handle the exception.
                    //
                    //   It is important that all exceptions are
                    //   handled and none are permitted to bubble up.
                }

                return Task.CompletedTask;
            }

            async Task processErrorHandler(ProcessErrorEventArgs args)
            {
                try
                {
                    // Always log the exception.

                    Debug.WriteLine("Error in the EventProcessorClient");
                    Debug.WriteLine($"\tOperation: { args.Operation ?? "Unknown" }");
                    Debug.WriteLine($"\tPartition: { args.PartitionId ?? "None" }");
                    Debug.WriteLine($"\tException: { args.Exception }");
                    Debug.WriteLine("");

                    // If cancellation was requested, assume that
                    // it was in response to an application request
                    // and take no action.

                    if (args.CancellationToken.IsCancellationRequested)
                    {
                        return;
                    }

                    // Allow the application to handle the exception according to
                    // its business logic.

                    await HandleExceptionAsync(args.Exception, args.CancellationToken);
                }
                catch
                {
                    // Handle the exception.  If fatal, signal
                    // for cancellation.
                }
            }

            try
            {
                processor.ProcessEventAsync += processEventHandler;
                processor.ProcessErrorAsync += processErrorHandler;

                try
                {
                    // Once processing has started, the delay will
                    // block to allow processing until cancellation
                    // is requested.

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
            finally
            {
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
        public void InitializeHandlerArgs()
        {
            #region Snippet:EventHubs_Processor_Sample03_InitializeHandlerArgs

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
            var eventHubName = "fake";
            var consumerGroup = "$Default";

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

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                fullyQualifiedNamespace,
                eventHubName,
                credential);

            Task initializeEventHandler(PartitionInitializingEventArgs args)
            {
                try
                {
                    if (args.CancellationToken.IsCancellationRequested)
                    {
                        return Task.CompletedTask;
                    }

                    Debug.WriteLine($"Initialize partition: { args.PartitionId }");

                    // If no checkpoint was found, start processing
                    // events enqueued now or in the future.

                    EventPosition startPositionWhenNoCheckpoint =
                        EventPosition.FromEnqueuedTime(DateTimeOffset.UtcNow);

                    args.DefaultStartingPosition = startPositionWhenNoCheckpoint;
                }
                catch
                {
                    // Take action to handle the exception.
                    // It is important that all exceptions are
                    // handled and none are permitted to bubble up.
                }

                return Task.CompletedTask;
            }

            try
            {
                processor.PartitionInitializingAsync += initializeEventHandler;

                // Starting and stopping the processor are not
                // shown in this example.
            }
            finally
            {
                processor.PartitionInitializingAsync -= initializeEventHandler;
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public void CloseHandlerArgs()
        {
            #region Snippet:EventHubs_Processor_Sample03_CloseHandlerArgs

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
            var eventHubName = "fake";
            var consumerGroup = "$Default";

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

            var processor = new EventProcessorClient(
                storageClient,
                consumerGroup,
                fullyQualifiedNamespace,
                eventHubName,
                credential);

            Task closeEventHandler(PartitionClosingEventArgs args)
            {
                try
                {
                    if (args.CancellationToken.IsCancellationRequested)
                    {
                        return Task.CompletedTask;
                    }

                    string description = args.Reason switch
                    {
                        ProcessingStoppedReason.OwnershipLost =>
                            "Another processor claimed ownership",

                        ProcessingStoppedReason.Shutdown =>
                            "The processor is shutting down",

                        _ => args.Reason.ToString()
                    };

                    Debug.WriteLine($"Closing partition: { args.PartitionId }");
                    Debug.WriteLine($"\tReason: { description }");
                }
                catch
                {
                    // Take action to handle the exception.
                    // It is important that all exceptions are
                    // handled and none are permitted to bubble up.
                }

                return Task.CompletedTask;
            }

            try
            {
                processor.PartitionClosingAsync += closeEventHandler;

                // Starting and stopping the processor are not
                // shown in this example.
            }
            finally
            {
                processor.PartitionClosingAsync -= closeEventHandler;
            }

            #endregion
        }

        /// <summary>
        ///   Serves as a demonstrative shim to illustrate an application
        ///   handling an exception.
        /// </summary>
        ///
        /// <param name="ex">The exception to be handled.</param>
        ///
        private Task HandleExceptionAsync(Exception ex,
                                          CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
