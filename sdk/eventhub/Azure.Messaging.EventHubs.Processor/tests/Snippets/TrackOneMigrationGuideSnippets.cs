// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Tests;
using Microsoft.Azure.EventHubs.Processor;
using NUnit.Framework;

namespace Microsoft.Azure.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the T1 snippets used in the Event Hubs
    ///   migration guides.
    /// </summary>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    public class TrackOneMigrationGuideSnippets
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task BasicEventProcessorHost()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Migrate_T1_BasicEventProcessorHost
#if SNIPPET
            var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER >>";

            var eventHubsConnectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
#else
            var storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
            var blobContainerName = "migragionsample";

            var eventHubsConnectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = scope.EventHubName;
            var consumerGroup = PartitionReceiver.DefaultConsumerGroupName;
#endif

            var eventProcessorHost = new EventProcessorHost(
                eventHubName,
                consumerGroup,
                eventHubsConnectionString,
                storageConnectionString,
                blobContainerName);

            try
            {
                // Registering the processor class will also signal the
                // host to begin processing events.

                await eventProcessorHost.RegisterEventProcessorAsync<SimpleEventProcessor>();

                // The processor runs in the background, to allow it to process,
                // this example will wait for 30 seconds and then trigger
                // cancellation.

                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                await Task.Delay(Timeout.Infinite, cancellationSource.Token);
            }
            catch (TaskCanceledException)
            {
                // This is expected when the cancellation token is
                // signaled.
            }
            finally
            {
                // Unregistering the processor class will signal the
                // host to stop processing.

                await eventProcessorHost.UnregisterEventProcessorAsync();
            }

            #endregion
        }
    }

    #pragma warning disable SA1402 // File may only contain a single type
    #region Snippet:EventHubs_Migrate_T1_SimpleEventProcessor

    public class SimpleEventProcessor : IEventProcessor
    {
        public Task CloseAsync(PartitionContext context, CloseReason reason)
        {
             Debug.WriteLine($"Partition '{context.PartitionId}' is closing.");
             return Task.CompletedTask;
        }

        public Task OpenAsync(PartitionContext context)
        {
            Debug.WriteLine($"Partition: '{context.PartitionId}' was initialized.");
            return Task.CompletedTask;
        }

        public Task ProcessErrorAsync(PartitionContext context, Exception error)
        {
            Debug.WriteLine(
                $"Error for partition: {context.PartitionId}, " +
                $"Error: {error.Message}");

            return Task.CompletedTask;
        }

        public Task ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
        {
            foreach (var eventData in messages)
            {
                var data = Encoding.UTF8.GetString(
                    eventData.Body.Array,
                    eventData.Body.Offset,
                    eventData.Body.Count);

                Debug.WriteLine(
                    $"Event received for partition: '{context.PartitionId}', " +
                    $"Data: '{data}'");
            }

            return Task.CompletedTask;
        }
    }

    #endregion
    #pragma warning restore SA1402 // File may only contain a single type
}
