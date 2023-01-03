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
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient();
            CallAutomationEventHandler handler = callAutomationClient.GetCallAutomationEventHandler();

            // Wait for Event
            Task<CallAutomationEventBase> baseEventTask = handler.WaitForEvent(new List<Type>() { typeof(CallConnected) }, CallConnectionId);

            // create and send event to event processor
            SendAndProcessEvent(handler, new CallConnected(CallConnectionId, ServerCallId, CorelationId, null));

            CallAutomationEventBase returnedBaseEvent = await baseEventTask;

            // assert
            Assert.NotNull(returnedBaseEvent);
            Assert.AreEqual(typeof(CallConnected), returnedBaseEvent.GetType());
            Assert.AreEqual(CallConnectionId, ((CallConnected)returnedBaseEvent).CallConnectionId);
        }
    }
}
