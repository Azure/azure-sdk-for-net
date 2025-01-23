// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.CallAutomation.Tests.Infrastructure;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Communication.CallAutomation.Tests.EventProcessors
{
    public class EventProcessorAsyncTests : CallAutomationEventProcessorTestBase
    {
        [Test]
        public async Task ProcessEventAndWaitForIt()
        {
            // Most common case where you wait for an event, then the event gets sent with a matching CallconnectionId
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200);
            CallAutomationEventProcessor handler = callAutomationClient.GetEventProcessor();

            // Wait for Event
            Task<CallAutomationEventBase> baseEventTask = handler.WaitForEventProcessorAsync(ev
                => ev.CallConnectionId == CallConnectionId
                && ev.GetType() == typeof(CallConnected));

            // Create and send event to event processor
            SendAndProcessEvent(handler, new CallConnected(CallConnectionId, ServerCallId, CorelationId, null, null));

            CallAutomationEventBase returnedBaseEvent = await baseEventTask;

            // Assert
            Assert.NotNull(returnedBaseEvent);
            Assert.AreEqual(typeof(CallConnected), returnedBaseEvent.GetType());
            Assert.AreEqual(CallConnectionId, returnedBaseEvent.CallConnectionId);
        }

        [Test]
        public async Task ProcessEventFirstThenWaitForIt()
        {
            // Events arrives first, then waits for it.
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200);
            CallAutomationEventProcessor handler = callAutomationClient.GetEventProcessor();

            // Create and send event to event processor first
            SendAndProcessEvent(handler, new CallConnected(CallConnectionId, ServerCallId, CorelationId, null, null));

            // Wait for Event after
            CallAutomationEventBase returnedBaseEvent = await handler.WaitForEventProcessorAsync(ev
                => ev.CallConnectionId == CallConnectionId
                && ev.GetType() == typeof(CallConnected));

            // Assert
            Assert.NotNull(returnedBaseEvent);
            Assert.AreEqual(typeof(CallConnected), returnedBaseEvent.GetType());
            Assert.AreEqual(CallConnectionId, returnedBaseEvent.CallConnectionId);
        }

        [Test]
        public async Task NoMatchTimeOutException()
        {
            // Check to see Timesout on exception when predicate do not match
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200);
            CallAutomationEventProcessor handler = callAutomationClient.GetEventProcessor();

            CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
            CancellationToken token = cts.Token;

            // Wait for Event , but mismatched callConnectionId & eventtype
            List<Task> taskList = new List<Task>
            {
                handler.WaitForEventProcessorAsync(ev
                => ev.CallConnectionId == "SOMEOTHERID"
                && ev.GetType() == typeof(CallConnected), token),
                handler.WaitForEventProcessorAsync(ev
                => ev.CallConnectionId == CallConnectionId
                && ev.GetType() == typeof(CallDisconnected), token)
            };

            // Create and send event to event processor
            SendAndProcessEvent(handler, new CallConnected(CallConnectionId, ServerCallId, CorelationId, null, null));

            try
            {
                await Task.WhenAll(taskList);
            }
            catch (OperationCanceledException)
            {
                // success
                return;
            }

            Assert.Fail();
        }

        [Test]
        public async Task WaitForMultipleEventsInSequence()
        {
            // Sending multiple events with multiple wait for event
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200);
            CallAutomationEventProcessor handler = callAutomationClient.GetEventProcessor();
            int eventsSent = 5;

            // Create and send multiple events to event processor
            for (int i = 0; i < eventsSent; i++)
            {
                var task = handler.WaitForEventProcessorAsync(ev
                    => ev.CallConnectionId == CallConnectionId
                    && ev.GetType() == typeof(CallConnected));
                SendAndProcessEvent(handler, new CallConnected(CallConnectionId, ServerCallId, CorelationId, null, null));

                // assert
                CallAutomationEventBase returnedBaseEvent = await task;
                Assert.NotNull(returnedBaseEvent);
                Assert.AreEqual(typeof(CallConnected), returnedBaseEvent.GetType());
                Assert.AreEqual(CallConnectionId, returnedBaseEvent.CallConnectionId);
            }
        }

        [Test]
        public async Task WaitForMultipleEventsSentAllAtOnce()
        {
            // Sending multiple events at once, but waits events in sequence with delay
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200);
            CallAutomationEventProcessor handler = callAutomationClient.GetEventProcessor();
            int eventsSent = 5;

            Task<CallAutomationEventBase> eventAwaiter = handler.WaitForEventProcessorAsync(ev
                => ev.CallConnectionId == CallConnectionId
                && ev.GetType() == typeof(CallConnected));

            // Create and send multiple events to event processor AT ONCE
            for (int i = 0; i < eventsSent; i++)
            {
                SendAndProcessEvent(handler, new CallConnected(CallConnectionId, ServerCallId, CorelationId, null, null));
            }

            // Wait for event in sequence
            for (int i = 0; i < eventsSent; i++)
            {
                // Assert
                CallAutomationEventBase returnedBaseEvent = await eventAwaiter;
                Assert.NotNull(returnedBaseEvent);
                Assert.AreEqual(typeof(CallConnected), returnedBaseEvent.GetType());
                Assert.AreEqual(CallConnectionId, returnedBaseEvent.CallConnectionId);

                if (i < eventsSent - 1)
                {
                    eventAwaiter = handler.WaitForEventProcessorAsync(ev
                        => ev.CallConnectionId == CallConnectionId
                        && ev.GetType() == typeof(CallConnected));
                }
            }
        }
    }
}
