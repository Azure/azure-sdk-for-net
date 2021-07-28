// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the Event Hubs
    ///   Sample09_EventHubsClients sample.
    /// </summary>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    [SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Example assignments needed for snippet output content.")]
    public class Sample09_ObservableEventBatchLiveTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task Sample09_AccessingEventData()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:Sample09_AccessingEventData
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
                using var eventBatch = await producer.CreateBatchAsync();
                var newBatch = new ObservableEventDataBatch(eventBatch);

                // Adding events to the batch
                for (var index = 0; index < 5; ++index)
                {
                    var eventBody = new BinaryData($"Event #{ index }");
                    var eventData = new EventData(eventBody);

                    if (!newBatch.TryAdd(eventData))
                    {
                        throw new Exception($"The event at { index } could not be added.");
                    }
                }

                // Looping through the events to demonstrate how to access them
                foreach (var singleEvent in newBatch.Events)
                {
                    Debug.WriteLine($"Added event { singleEvent.EventBody } at time { singleEvent.EnqueuedTime }");
                }

                await producer.SendAsync(newBatch);
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
        public async Task Sample09_CheckingBatch()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:Sample09_CheckingBatch

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
                using var eventBatch = await producer.CreateBatchAsync();
                var newBatch = new ObservableEventDataBatch(eventBatch);

                // Adding events to the batch
                for (var index = 0; index < 5; ++index)
                {
                    var eventBody = new BinaryData($"Event #{ index }");
                    var eventData = new EventData(eventBody);
                    eventData.Properties.Add("ApplicationId", index);

                    if (!newBatch.TryAdd(eventData))
                    {
                        throw new Exception($"The event at { index } could not be added.");
                    }
                }

                // Verify that the expected event is in the batch
                var contains = newBatch.Events.Any(eventData => int.TryParse(eventData.Properties["ApplicationId"].ToString(), out var id) && id == 1);
            }
            finally
            {
                await producer.CloseAsync();
            }
#endregion
        }

        /// <summary>
        ///   Live test of the ObservableEventBatch class. This checks that events are successfully being added
        ///   to both the internal and external batch.
        /// </summary>
        ///
        [Test]
        public async Task ObservableEventBatchIsPublishable()
        {
            await using var scope = await EventHubScope.CreateAsync(1);
            var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = scope.EventHubName;
            await using var producer = new EventHubProducerClient(connectionString, eventHubName);
            using var eventBatch = await producer.CreateBatchAsync();
            var newBatch = new ObservableEventDataBatch(eventBatch);

            // Adding events to the batch
            for (var index = 0; index < 5; ++index)
            {
                var eventBody = new BinaryData($"Event #{ index }");
                var eventData = new EventData(eventBody);
                eventData.Properties.Add("ApplicationId", index);

                if (!newBatch.TryAdd(eventData))
                {
                    throw new Exception($"The event at { index } could not be added.");
                }
            }

            var contains = newBatch.Events.Any(eventData => int.TryParse(eventData.Properties["ApplicationId"].ToString(), out var id) && id == 1);
            Assert.That(contains, Is.True, "The batch should contain the event with the expected application identifier.");

            Assert.Greater(newBatch.Count, 0, "Events were not successfully added to the batch");
            Assert.AreEqual(newBatch.Count, newBatch.Events.Count, "The observable batch events are out of sync with the event batch data");

            // Check implicit casting by verifying batch can be sent using built in
            // producer method
            await producer.SendAsync(newBatch);
            await producer.CloseAsync();
        }

        #region Snippet:Sample09_ObservableEventBatch

        public class ObservableEventDataBatch : IDisposable
        {
            // The set of events that have been accepted into the batch
            private List<EventData> _events = new List<EventData>();

            /// The EventDataBatch being observed
            private EventDataBatch _batch;

            // These events are the source of what is held in the batch.  Though
            // these instances are mutable, any changes made will NOT be reflected to
            // those that had been accepted into the batch
            public IReadOnlyList<EventData> Events { get; }

            public int Count => _batch.Count;
            public long SizeInBytes => _batch.SizeInBytes;
            public long MaximumSizeInBytes => _batch.MaximumSizeInBytes;

            // The constructor requires that sourceBatch is an empty batch so that it can track the events
            // that are being added
            public ObservableEventDataBatch(EventDataBatch sourceBatch)
            {
                _batch = sourceBatch ?? throw new ArgumentNullException(nameof(sourceBatch));
                if (_batch.Count > 0)
                {
                    throw new ArgumentException("The sourceBatch is not empty.", nameof(sourceBatch));
                }
                Events = _events.AsReadOnly();
            }

            public bool TryAdd(EventData eventData)
            {
                if (_batch.TryAdd(eventData))
                {
                    _events.Add(eventData);
                    return true;
                }

                return false;
            }

            public void Dispose() => _batch.Dispose();

            // Performs the needed transation to allow an ObservableEventDataBatch to be
            // implicitly converted to an EventDataBatch
            public static implicit operator EventDataBatch(ObservableEventDataBatch observable) => observable._batch;
        }

        #endregion
    }
}
