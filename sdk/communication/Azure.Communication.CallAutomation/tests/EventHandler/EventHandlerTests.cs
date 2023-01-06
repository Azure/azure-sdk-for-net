// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.CallAutomation.Tests.Infrastructure;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Azure.Communication.CallAutomation.Tests.EventHandler
{
    public class EventHandlerTests : CallAutomationEventHandlerTestBase
    {
        [Test]
        public async Task ProcessEventAndWaitForIt()
        {
            // Most common case where where you wait for event, then event gets sent with matching CallconnectionId
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient();
            CallAutomationEventHandler handler = callAutomationClient.GetCallAutomationEventHandler();

            // Wait for Event
            Task<CallConnected> baseEventTask = handler.WaitForEvent<CallConnected>(CallConnectionId);

            // create and send event to event processor
            SendAndProcessEvent(handler, new CallConnected(CallConnectionId, ServerCallId, CorelationId, null));

            CallAutomationEventBase returnedBaseEvent = await baseEventTask;

            // assert
            Assert.NotNull(returnedBaseEvent);
            Assert.AreEqual(typeof(CallConnected), returnedBaseEvent.GetType());
            Assert.AreEqual(CallConnectionId, returnedBaseEvent.CallConnectionId);
        }

        [Test]
        public async Task ProcessEventFirstThenWaitForIt()
        {
            // Events arrives first, then waits for it.
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient();
            CallAutomationEventHandler handler = callAutomationClient.GetCallAutomationEventHandler();

            // create and send event to event processor first
            SendAndProcessEvent(handler, new CallConnected(CallConnectionId, ServerCallId, CorelationId, null));

            // Wait for Event after
            CallConnected returnedBaseEvent = await handler.WaitForEvent<CallConnected>(CallConnectionId);

            // assert
            Assert.NotNull(returnedBaseEvent);
            Assert.AreEqual(typeof(CallConnected), returnedBaseEvent.GetType());
            Assert.AreEqual(CallConnectionId, returnedBaseEvent.CallConnectionId);
        }

        [Test]
        public async Task OnGoingHandlerRegistration()
        {
            // ongoing handler with delegate tests
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient();
            CallAutomationEventHandler handler = callAutomationClient.GetCallAutomationEventHandler();
            string callConnectionIdPassedFromOngoingEventHandler = "";

            // Add delegate for call connected event
            handler.SetOngoingEventHandler<CallConnected>(CallConnectionId, passedEvent => callConnectionIdPassedFromOngoingEventHandler = passedEvent.CallConnectionId);

            // create and send event to event processor first
            SendAndProcessEvent(handler, new CallConnected(CallConnectionId, ServerCallId, CorelationId, null));

            // Wait for Event after
            CallConnected returnedBaseEvent = await handler.WaitForEvent<CallConnected>(CallConnectionId);

            // assert
            Assert.NotNull(returnedBaseEvent);
            Assert.AreEqual(typeof(CallConnected), returnedBaseEvent.GetType());
            Assert.AreEqual(CallConnectionId, returnedBaseEvent.CallConnectionId);

            // assert if the delegate was also called
            Assert.AreEqual(CallConnectionId, callConnectionIdPassedFromOngoingEventHandler);
        }

        [Test]
        public async Task NoMatchTimeOutException()
        {
            // check to see Timesout on exception when filter do not match
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient();
            CallAutomationEventHandler handler = callAutomationClient.GetCallAutomationEventHandler();

            // Wait for Event , but mismatched callConnectionId & eventtype
            List<Task> taskList = new List<Task>
            {
                handler.WaitForEvent<CallDisconnected>(CallConnectionId),
                handler.WaitForEvent<CallConnected>("SomeOtherValue")
            };

            // create and send event to event processor
            SendAndProcessEvent(handler, new CallConnected(CallConnectionId, ServerCallId, CorelationId, null));

            try
            {
                await Task.WhenAll(taskList);
            }
            catch (TimeoutException)
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
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient();
            CallAutomationEventHandler handler = callAutomationClient.GetCallAutomationEventHandler();
            int eventsSent = 5;

            // create and send multiple events to event processor
            for (int i = 0; i < eventsSent; i++)
            {
                var task = handler.WaitForEvent<CallConnected>(CallConnectionId);
                SendAndProcessEvent(handler, new CallConnected(CallConnectionId, ServerCallId, CorelationId, null));

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
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient();
            CallAutomationEventHandler handler = callAutomationClient.GetCallAutomationEventHandler();
            int eventsSent = 5;

            var eventAwaiter = handler.WaitForEvent<CallConnected>(CallConnectionId);

            // create and send multiple events to event processor AT ONCE
            for (int i = 0; i < eventsSent; i++)
            {
                SendAndProcessEvent(handler, new CallConnected(CallConnectionId, ServerCallId, CorelationId, null));
            }

            // wait for event in sequence
            for (int i = 0; i < eventsSent; i++)
            {
                // assert
                CallAutomationEventBase returnedBaseEvent = await eventAwaiter;
                Assert.NotNull(returnedBaseEvent);
                Assert.AreEqual(typeof(CallConnected), returnedBaseEvent.GetType());
                Assert.AreEqual(CallConnectionId, returnedBaseEvent.CallConnectionId);

                if (i < eventsSent - 1)
                {
                    eventAwaiter = handler.WaitForEvent<CallConnected>(CallConnectionId);
                }
            }
        }
    }
}
