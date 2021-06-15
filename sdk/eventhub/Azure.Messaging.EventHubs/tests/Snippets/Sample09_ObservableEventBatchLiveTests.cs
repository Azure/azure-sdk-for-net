// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
using System.Linq;
using System.Threading.Tasks;
=======
using System.Diagnostics.CodeAnalysis;
using System.Linq;
=======
using System.Diagnostics.CodeAnalysis;
<<<<<<< HEAD
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
using System.Linq;
>>>>>>> 08a0c24d4f (Cleaning up tests.)
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
<<<<<<< HEAD
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
using System.Linq;
using System.Threading.Tasks;
>>>>>>> e32a1e522b (realigning with main)
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
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    public class Sample09_ObservableEventBatchLiveTests
    {
=======
    [SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Example assignments needed for snippet output content.")]
    public class Sample09_ObservableEventBatchLiveTests
    {
<<<<<<< HEAD
<<<<<<< HEAD
=======
    [SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Example assignments needed for snippet output content.")]
    public class Sample09_ObservableEventBatchLiveTests
    {
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
        #region Snippet:Sample09_ObservableEventBatch

        public class ObservableEventDataBatch : IDisposable
        {
            // The set of events that have been accepted into the batch
<<<<<<< HEAD
<<<<<<< HEAD
            private List<EventData> _events = new List<EventData>();
=======
            private List<EventData> _events = new();
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
            private List<EventData> _events = new List<EventData>();
>>>>>>> bb8025dfab (Updated tests and markdown to respond to comments.)

            /// The EventDataBatch being observed
            private EventDataBatch _batch;

            // These events are the source of what is held in the batch.  Though
            // these instances are mutable, any changes made will NOT be reflected to
<<<<<<< HEAD
<<<<<<< HEAD
            // those that had been accepted into the batch
=======
            // those that had been accepted into the batch.
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
            // those that had been accepted into the batch
>>>>>>> bb8025dfab (Updated tests and markdown to respond to comments.)
            public IReadOnlyList<EventData> Events { get; }

            public int Count => _batch.Count;
            public long SizeInBytes => _batch.SizeInBytes;
            public long MaximumSizeInBytes => _batch.MaximumSizeInBytes;

            // The constructor requires that sourceBatch is an empty batch so that it can track the events
<<<<<<< HEAD
<<<<<<< HEAD
            // that are being added
=======
            // that are being added.
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
            // that are being added
>>>>>>> bb8025dfab (Updated tests and markdown to respond to comments.)
            public ObservableEventDataBatch(EventDataBatch sourceBatch)
            {
                _batch = sourceBatch ?? throw new ArgumentNullException(nameof(sourceBatch));
                if (_batch.Count > 0)
                {
<<<<<<< HEAD
<<<<<<< HEAD
                    throw new ArgumentException("The sourceBatch is not empty.", nameof(sourceBatch));
=======
                    throw new ArgumentException("sourceBatch is not an empty EventBatch");
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
                    throw new ArgumentException("The sourceBatch is not empty.", nameof(sourceBatch));
>>>>>>> bb8025dfab (Updated tests and markdown to respond to comments.)
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
<<<<<<< HEAD
<<<<<<< HEAD
            // implicitly converted to an EventDataBatch
=======
            // implicitly converted to an EventDataBatch.
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
            // implicitly converted to an EventDataBatch
>>>>>>> bb8025dfab (Updated tests and markdown to respond to comments.)
            public static implicit operator EventDataBatch(ObservableEventDataBatch observable) => observable._batch;
        }

        #endregion

<<<<<<< HEAD
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
>>>>>>> 473fb122c9 (Moving the class)
=======
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
>>>>>>> 473fb122c9 (Moving the class)
=======
    public class Sample09_ObservableEventBatchLiveTests
    {
>>>>>>> e32a1e522b (realigning with main)
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task Sample09_AccessingEventData()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:Sample09_AccessingEventData
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
#if SNIPPET
            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
#else
            var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = scope.EventHubName;
#endif
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)

            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;
<<<<<<< HEAD
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
            #if SNIPPET
=======
=======
>>>>>>> e32a1e522b (realigning with main)
#if SNIPPET
            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
#else
            var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = scope.EventHubName;
#endif

<<<<<<< HEAD
=======
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======

>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
            #if SNIPPET
=======
#if SNIPPET
>>>>>>> 93a7e9a8a1 (Updating formatting)
            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
#else
            var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = scope.EventHubName;
#endif

>>>>>>> 08f15d3176 (Updating snippet definitions)
=======
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======
>>>>>>> e32a1e522b (realigning with main)
            var producer = new EventHubProducerClient(connectionString, eventHubName);

            try
            {
                using var eventBatch = await producer.CreateBatchAsync();
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> e32a1e522b (realigning with main)
                var observableBatch = new ObservableEventDataBatch(eventBatch);

                // Attempt to add events to the batch.

                for (var index = 0; index < 5; ++index)
                {
                    var eventData = new EventData($"Event #{ index }");

                    if (!observableBatch.TryAdd(eventData))
<<<<<<< HEAD
=======
                ObservableEventDataBatch newbatch = new ObservableEventDataBatch(eventBatch);
=======
                var newBatch = new ObservableEventDataBatch(eventBatch);
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)

                // Adding events to the batch
=======
                ObservableEventDataBatch newbatch = new ObservableEventDataBatch(eventBatch);

>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
                var newBatch = new ObservableEventDataBatch(eventBatch);

                // Adding events to the batch
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
                for (var index = 0; index < 5; ++index)
                {
                    var eventBody = new BinaryData($"Event #{ index }");
                    var eventData = new EventData(eventBody);

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
                    if (!newbatch.TryAdd(eventData))
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
                    if (!newBatch.TryAdd(eventData))
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======
                    if (!newbatch.TryAdd(eventData))
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
                    if (!newBatch.TryAdd(eventData))
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======
>>>>>>> e32a1e522b (realigning with main)
                    {
                        throw new Exception($"The event at { index } could not be added.");
                    }
                }

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
                // Events in the batch can be inspected using the "Events" collection.

                foreach (var singleEvent in observableBatch.Events)
=======
                foreach (var singleEvent in newbatch.Events)
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
                // Looping through the events to demonstrate how to access them
                foreach (var singleEvent in newBatch.Events)
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======
                foreach (var singleEvent in newbatch.Events)
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
                // Looping through the events to demonstrate how to access them
                foreach (var singleEvent in newBatch.Events)
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======
                // Events in the batch can be inspected using the "Events" collection.

                foreach (var singleEvent in observableBatch.Events)
>>>>>>> e32a1e522b (realigning with main)
                {
                    Debug.WriteLine($"Added event { singleEvent.EventBody } at time { singleEvent.EnqueuedTime }");
                }

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
                await producer.SendAsync(observableBatch);
=======
                await producer.SendAsync(newbatch);
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
                await producer.SendAsync(newBatch);
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======
                await producer.SendAsync(newbatch);
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
                await producer.SendAsync(newBatch);
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======
                await producer.SendAsync(observableBatch);
>>>>>>> e32a1e522b (realigning with main)
            }
            finally
            {
                await producer.CloseAsync();
            }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
            #endregion
=======
=======
>>>>>>> 1a38d9b5fe (Fixing some formatting, spelling, and details)
<<<<<<< HEAD
=======
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
#endregion
=======

<<<<<<< HEAD
            #endregion
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
<<<<<<< HEAD
>>>>>>> 1b7d8c7eff (Created Sample 9: ObservableEventDataBatch)
=======
=======
=======
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
#endregion
>>>>>>> 08f15d3176 (Updating snippet definitions)
>>>>>>> a8de57caec (Updating snippet definitions)
=======

<<<<<<< HEAD
            #endregion
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
#endregion
>>>>>>> 08f15d3176 (Updating snippet definitions)
=======
            #endregion
>>>>>>> e32a1e522b (realigning with main)
=======
#endregion
>>>>>>> a1e267428d (ALIGNING)
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

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
#if SNIPPET
            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
#else
            var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = scope.EventHubName;
#endif
=======
=======
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            /*@@*/
            /*@@*/ connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            /*@@*/ eventHubName = scope.EventHubName;
<<<<<<< HEAD
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
            #if SNIPPET
=======
=======
>>>>>>> e32a1e522b (realigning with main)
#if SNIPPET
            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
#else
            var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = scope.EventHubName;
#endif

<<<<<<< HEAD
=======
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======

>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
            #if SNIPPET
=======
#if SNIPPET
>>>>>>> 93a7e9a8a1 (Updating formatting)
            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
#else
            var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = scope.EventHubName;
#endif
<<<<<<< HEAD

>>>>>>> 08f15d3176 (Updating snippet definitions)
=======
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======
>>>>>>> e32a1e522b (realigning with main)
            var producer = new EventHubProducerClient(connectionString, eventHubName);

            try
            {
                using var eventBatch = await producer.CreateBatchAsync();
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> e32a1e522b (realigning with main)
                var observableBatch = new ObservableEventDataBatch(eventBatch);

                // Attempt to add events to the batch.

                for (var index = 0; index < 5; ++index)
                {
                    var eventData = new EventData($"Event #{ index }")
                    {
                        MessageId = index.ToString()
                    };

                    if (!observableBatch.TryAdd(eventData))
<<<<<<< HEAD
=======
                ObservableEventDataBatch newbatch = new ObservableEventDataBatch(eventBatch);
=======
                var newBatch = new ObservableEventDataBatch(eventBatch);
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)

                // Adding events to the batch
=======
                ObservableEventDataBatch newbatch = new ObservableEventDataBatch(eventBatch);

>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
                var newBatch = new ObservableEventDataBatch(eventBatch);

                // Adding events to the batch
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
                for (var index = 0; index < 5; ++index)
                {
                    var eventBody = new BinaryData($"Event #{ index }");
                    var eventData = new EventData(eventBody);
<<<<<<< HEAD
<<<<<<< HEAD
                    eventData.Properties.Add("ApplicationId", index);

<<<<<<< HEAD
                    if (!newbatch.TryAdd(eventData))
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
                    if (!newBatch.TryAdd(eventData))
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======
                    eventData.Properties.Add("ApplicationID", index);
=======
                    eventData.Properties.Add("ApplicationId", index);
>>>>>>> 08a0c24d4f (Cleaning up tests.)

<<<<<<< HEAD
                    if (!newbatch.TryAdd(eventData))
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
                    if (!newBatch.TryAdd(eventData))
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======
>>>>>>> e32a1e522b (realigning with main)
                    {
                        throw new Exception($"The event at { index } could not be added.");
                    }
                }

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> e32a1e522b (realigning with main)
                // The "Events" collection can be used to validate that a specific event
                // is in the batch.  In this example, we'll ensure that an event with
                // id "1" was added.

                var contains = observableBatch.Events
                    .Any(eventData => eventData.MessageId == "1");
<<<<<<< HEAD
=======
                //check if event 1 is in the batch
<<<<<<< HEAD
=======
                //check if event 1 is in the batch
<<<<<<< HEAD
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
                var contains = false;
                foreach (var singleEvent in newbatch.Events)
                {
                    contains = contains || (Int32.TryParse(singleEvent.Properties["ApplicationID"].ToString(), out Int32 id) && id == 1);
                }
<<<<<<< HEAD
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
=======
                // Verify that the expected event is in the batch
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> bb8025dfab (Updated tests and markdown to respond to comments.)
                var contains = newbatch.Events.Any(eventData => int
                .TryParse(eventData.Properties["ApplicationId"].ToString(), out var id) && id == 1);
>>>>>>> 08a0c24d4f (Cleaning up tests.)
=======
                var contains = newBatch.Events.Any(eventData => int.TryParse(eventData.Properties["ApplicationId"].ToString(), out var id) && id == 1);
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
=======
                // Verify that the expected event is in the batch
>>>>>>> bb8025dfab (Updated tests and markdown to respond to comments.)
                var contains = newbatch.Events.Any(eventData => int
                .TryParse(eventData.Properties["ApplicationId"].ToString(), out var id) && id == 1);
>>>>>>> 08a0c24d4f (Cleaning up tests.)
=======
                var contains = newBatch.Events.Any(eventData => int.TryParse(eventData.Properties["ApplicationId"].ToString(), out var id) && id == 1);
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======
>>>>>>> e32a1e522b (realigning with main)
            }
            finally
            {
                await producer.CloseAsync();
            }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
            #endregion
=======
=======
>>>>>>> a8de57caec (Updating snippet definitions)
<<<<<<< HEAD
#endregion
>>>>>>> 1b7d8c7eff (Created Sample 9: ObservableEventDataBatch)
        }

<<<<<<< HEAD
<<<<<<< HEAD
        /// <summary>
        ///   Live test of the ObservableEventBatch class. This checks that events are successfully being added
=======
=======
>>>>>>> e32a1e522b (realigning with main)
            #endregion
=======
#endregion
>>>>>>> a1e267428d (ALIGNING)
        }
<<<<<<< HEAD
=======
>>>>>>> bb8025dfab (Updated tests and markdown to respond to comments.)
=======
>>>>>>> bb8025dfab (Updated tests and markdown to respond to comments.)
        /// <summary>
<<<<<<< HEAD
<<<<<<< HEAD
        ///   Live test of the ObservableEventBatch Class. This checks that events are successfully being added
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
        ///   Live test of the ObservableEventBatch class. This checks that events are successfully being added
>>>>>>> 1221125230 (Fixing some formatting, spelling, and details)
=======
            #endregion
=======
#endregion
>>>>>>> 08f15d3176 (Updating snippet definitions)
        }
        /// <summary>
        ///   Live test of the ObservableEventBatch Class. This checks that events are successfully being added
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======
=======

        /// <summary>
>>>>>>> e32a1e522b (realigning with main)
        ///   Live test of the ObservableEventBatch class. This checks that events are successfully being added
        ///   to both the internal and external batch.
        /// </summary>
        ///
        [Test]
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> e32a1e522b (realigning with main)
        public async Task ObservableEventBatchIsPublishable()
        {
            await using var scope = await EventHubScope.CreateAsync(1);
            await using var producer = new EventHubProducerClient(EventHubsTestEnvironment.Instance.EventHubsConnectionString, scope.EventHubName);

            using var eventBatch = await producer.CreateBatchAsync();
            var observableBatch = new ObservableEventDataBatch(eventBatch);

            // Adding events to the batch

            for (var index = 0; index < 5; ++index)
            {
                var eventData = new EventData($"Event #{ index }");
                eventData.Properties.Add("ApplicationId", index);

                if (!observableBatch.TryAdd(eventData))
                {
                    throw new Exception($"The event at { index } could not be added.");
                }
            }

            var contains = observableBatch.Events.Any(eventData => int.TryParse(eventData.Properties["ApplicationId"].ToString(), out var id) && id == 1);
            Assert.That(contains, Is.True, "The batch should contain the event with the expected application identifier.");

            Assert.That(observableBatch.Count, Is.GreaterThan(0), "Events were not successfully added to the batch");
            Assert.That(observableBatch.Count, Is.EqualTo(observableBatch.Events.Count), "The observable batch events are out of sync with the event batch data");

            // Check implicit casting by verifying batch can be sent using built in
            // producer method

            await producer.SendAsync(observableBatch);
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

            // Performs the needed translation to allow an ObservableEventDataBatch to be
            // implicitly converted to an EventDataBatch
            public static implicit operator EventDataBatch(ObservableEventDataBatch observable) => observable._batch;
        }

        #endregion
<<<<<<< HEAD
=======
        public async Task ObservableEventBatch_LiveTest()
=======
        public async Task ObservableEventBatchIsPublishable()
>>>>>>> bb8025dfab (Updated tests and markdown to respond to comments.)
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
<<<<<<< HEAD
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======

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
>>>>>>> 473fb122c9 (Moving the class)
=======
        public async Task ObservableEventBatch_LiveTest()
=======
        public async Task ObservableEventBatchIsPublishable()
>>>>>>> bb8025dfab (Updated tests and markdown to respond to comments.)
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
<<<<<<< HEAD
>>>>>>> c9cc1b2812 (Created Sample 9: ObservableEventDataBatch)
=======

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
>>>>>>> 473fb122c9 (Moving the class)
=======
>>>>>>> e32a1e522b (realigning with main)
    }
}
