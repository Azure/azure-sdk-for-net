// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
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
        #region Snippet:Sample09_ObservableEventBatch

        public class ObservableEventDataBatch : IDisposable
        {
            // The set of events that have been accepted into the batch
            private List<EventData> _events = new();

            /// The EventDataBatch being observed
            private EventDataBatch _batch;

            // These events are the source of what is held in the batch.  Though
            // these instances are mutable, any changes made will NOT be reflected to
            // those that had been accepted into the batch.
            public IReadOnlyList<EventData> Events { get; }

            public int Count => _batch.Count;
            public long SizeInBytes => _batch.SizeInBytes;
            public long MaximumSizeInBytes => _batch.MaximumSizeInBytes;

            // The constructor requires that sourceBatch is an empty batch so that it can track the events
            // that are being added.
            public ObservableEventDataBatch(EventDataBatch sourceBatch)
            {
                _batch = sourceBatch ?? throw new ArgumentNullException(nameof(sourceBatch));
                if (_batch.Count > 0)
                {
                    throw new ArgumentException("sourceBatch is not an empty EventBatch");
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
            // implicitly converted to an EventDataBatch.
            public static implicit operator EventDataBatch(ObservableEventDataBatch observable) => observable._batch;
        }

        #endregion

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task Sample09_AccessingEventData()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:Sample09_AccessingEventData

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

            var producer = new EventHubProducerClient(connectionString, eventHubName);

            try
            {
                using var eventBatch = await producer.CreateBatchAsync();
                ObservableEventDataBatch newbatch = new ObservableEventDataBatch(eventBatch);

                for (var index = 0; index < 5; ++index)
                {
                    var eventBody = new BinaryData($"Event #{ index }");
                    var eventData = new EventData(eventBody);

                    if (!newbatch.TryAdd(eventData))
                    {
                        throw new Exception($"The event at { index } could not be added.");
                    }
                }

                foreach (var singleEvent in newbatch.Events)
                {
                    Debug.WriteLine($"Added event { singleEvent.EventBody } at time { singleEvent.EnqueuedTime }");
                }

                await producer.SendAsync(newbatch);
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

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;

            var producer = new EventHubProducerClient(connectionString, eventHubName);

            try
            {
                using var eventBatch = await producer.CreateBatchAsync();
                ObservableEventDataBatch newbatch = new ObservableEventDataBatch(eventBatch);

                for (var index = 0; index < 5; ++index)
                {
                    var eventBody = new BinaryData($"Event #{ index }");
                    var eventData = new EventData(eventBody);
                    eventData.Properties.Add("ApplicationID", index);

                    if (!newbatch.TryAdd(eventData))
                    {
                        throw new Exception($"The event at { index } could not be added.");
                    }
                }

                //check if event 1 is in the batch
                var contains = false;
                foreach (var singleEvent in newbatch.Events)
                {
                    contains = contains || (Int32.TryParse(singleEvent.Properties["ApplicationID"].ToString(), out Int32 id) && id == 1);
                }
            }
            finally
            {
                await producer.CloseAsync();
            }
            #endregion
        }
        /// <summary>
        ///   Live test of the ObservableEventBatch Class. This checks that events are successfully being added
        ///   to both the internal and external batch.
        /// </summary>
        ///
        [Test]
        public async Task ObservableEventBatch_LiveTest()
        {
            await using var scope = await EventHubScope.CreateAsync(1);
            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;
            var producer = new EventHubProducerClient(connectionString, eventHubName);

            try
            {
                using var eventBatch = await producer.CreateBatchAsync();
                ObservableEventDataBatch newbatch = new ObservableEventDataBatch(eventBatch);

                for (var index = 0; index < 5; ++index)
                {
                    var eventBody = new BinaryData($"Event #{ index }");
                    var eventData = new EventData(eventBody);
                    eventData.Properties.Add("ApplicationID", index);

                    if (!newbatch.TryAdd(eventData))
                    {
                        throw new Exception($"The event at { index } could not be added.");
                    }
                }

                var contains = false;
                foreach (var singleEvent in newbatch.Events)
                {
                      contains |= (int.TryParse(singleEvent.Properties["ApplicationId"].ToString(), out int id) && id == 1);
                }
                Assert.That(contains, Is.True, "The batch should contain the event with the expected application identifier.");

                // check count is set, this means that events were successfully added to _batch
                Assert.Greater(newbatch.Count, 0);

                // check that the number of events is the same in both the observable wrapper
                // class and the internal EventDataBatch class
                Assert.AreEqual(newbatch.Count, newbatch.Events.Count);

                // check implicit casting by verifying batch can be sent using built in
                // producer method
                await producer.SendAsync(newbatch);
            }
            finally
            {
                await producer.CloseAsync();
            }
        }
    }
}
