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
    }
}
