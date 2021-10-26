// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the Event Hubs
    ///   Sample03_EventHubMetadata sample.
    /// </summary>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    public class Sample03_EventHubMetadataLiveTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task InspectHub()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample03_InspectHub

#if SNIPPET
            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
#else
            var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = scope.EventHubName;
#endif

            var producer = new EventHubProducerClient(connectionString, eventHubName);

            try
            {
                EventHubProperties properties = await producer.GetEventHubPropertiesAsync();

                Debug.WriteLine("The Event Hub has the following properties:");
                Debug.WriteLine($"\tThe path to the Event Hub from the namespace is: { properties.Name }");
                Debug.WriteLine($"\tThe Event Hub was created at: { properties.CreatedOn }, in UTC.");
                Debug.WriteLine($"\tThe following partitions are available: [{ string.Join(", ", properties.PartitionIds) }]");
            }
            finally
            {
                await producer.CloseAsync();
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task QueryPartitions()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample03_QueryPartitions

#if SNIPPET
            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
#else
            var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = scope.EventHubName;
#endif

            var producer = new EventHubProducerClient(connectionString, eventHubName);

            try
            {
                string[] partitions = await producer.GetPartitionIdsAsync();
                Debug.WriteLine($"The following partitions are available: [{ string.Join(", ", partitions) }]");
            }
            finally
            {
                await producer.CloseAsync();
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task InspectPartition()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample03_InspectPartition

#if SNIPPET
            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
#else
            var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = scope.EventHubName;
#endif
            var consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

            var consumer = new EventHubConsumerClient(consumerGroup, connectionString, eventHubName);

            try
            {
                string[] partitions = await consumer.GetPartitionIdsAsync();
                string firstPartition = partitions.FirstOrDefault();

                PartitionProperties partitionProperties = await consumer.GetPartitionPropertiesAsync(firstPartition);

                Debug.WriteLine($"Partition: { partitionProperties.Id }");
                Debug.WriteLine($"\tThe partition contains no events: { partitionProperties.IsEmpty }");
                Debug.WriteLine($"\tThe first sequence number is: { partitionProperties.BeginningSequenceNumber }");
                Debug.WriteLine($"\tThe last sequence number is: { partitionProperties.LastEnqueuedSequenceNumber }");
                Debug.WriteLine($"\tThe last offset is: { partitionProperties.LastEnqueuedOffset }");
                Debug.WriteLine($"\tThe last enqueued time is: { partitionProperties.LastEnqueuedTime }, in UTC.");
            }
            finally
            {
                await consumer.CloseAsync();
            }

            #endregion
        }
    }
}
