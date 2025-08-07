// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.CallAutomation.Tests.Infrastructure;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace Azure.Communication.CallAutomation.Tests.EventProcessors
{
    public class AttachEventProcessorTests : CallAutomationEventProcessorTestBase
    {
        [Test]
        public void OnGoingHandlerAttach()
        {
            // Ongoing handler with delegate tests
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200);
            CallAutomationEventProcessor handler = callAutomationClient.GetEventProcessor();
            string callConnectionIdPassedFromOngoingEventProcessor = ServerCallId;

            // Add delegate for call connected event
            handler.AttachOngoingEventProcessor<CallConnected>(CallConnectionId, passedEvent => callConnectionIdPassedFromOngoingEventProcessor = passedEvent.CallConnectionId);

            // Create and send event to event processor first
            SendAndProcessEvent(handler, new CallConnected(CallConnectionId, ServerCallId, CorelationId, null, null));

            // Assert if the delegate was also called
            Assert.AreEqual(CallConnectionId, callConnectionIdPassedFromOngoingEventProcessor);
        }

        [Test]
        public void OnGoingHandlerDetach()
        {
            // Ongoing handler with delegate tests
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200);
            CallAutomationEventProcessor handler = callAutomationClient.GetEventProcessor();
            string callConnectionIdPassedFromOngoingEventProcessor = ServerCallId;

            // Add delegate for call connected event
            handler.AttachOngoingEventProcessor<CallConnected>(CallConnectionId, passedEvent => callConnectionIdPassedFromOngoingEventProcessor = passedEvent.CallConnectionId);

            // Then remove
            handler.DetachOngoingEventProcessor<CallConnected>(CallConnectionId);

            // Create and send event to event processor first
            SendAndProcessEvent(handler, new CallConnected(CallConnectionId, ServerCallId, CorelationId, null, null));

            // Assert if the delegate didnt get called
            Assert.AreEqual(ServerCallId, callConnectionIdPassedFromOngoingEventProcessor);
        }

        [Test]
        public void ReplaceExistingOnGoingHandler()
        {
            // Ongoing handler with delegate tests
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200);
            CallAutomationEventProcessor handler = callAutomationClient.GetEventProcessor();
            string callConnectionIdPassedFromOngoingEventProcessor = ServerCallId;

            // Add delegate for call connected event
            handler.AttachOngoingEventProcessor<CallConnected>("UnMatchedID", passedEvent => callConnectionIdPassedFromOngoingEventProcessor = passedEvent.CallConnectionId);

            // Then replace with correct one
            handler.AttachOngoingEventProcessor<CallConnected>(CallConnectionId, passedEvent => callConnectionIdPassedFromOngoingEventProcessor = passedEvent.CallConnectionId);

            SendAndProcessEvent(handler, new CallConnected(CallConnectionId, ServerCallId, CorelationId, null, null));

            // Assert if the delegate was also called
            Assert.AreEqual(CallConnectionId, callConnectionIdPassedFromOngoingEventProcessor);
        }

        [Test]
        public void EventMismatch()
        {
            // Ongoing handler with delegate tests
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200);
            CallAutomationEventProcessor handler = callAutomationClient.GetEventProcessor();
            string callConnectionIdPassedFromOngoingEventProcessor = ServerCallId;

            // Add delegate for call connected event
            handler.AttachOngoingEventProcessor<CallConnected>(CallConnectionId, passedEvent => callConnectionIdPassedFromOngoingEventProcessor = passedEvent.CallConnectionId);
            var internalEvent = new CallTransferAcceptedInternal(CallConnectionId, ServerCallId, CorelationId, null, null, null, null);

            // Create and send event to event processor first
            SendAndProcessEvent(handler, new CallTransferAccepted(internalEvent));

            // Assert if the delegate was never called
            Assert.AreEqual(ServerCallId, callConnectionIdPassedFromOngoingEventProcessor);
        }

        [Test]
        public void CheckIfOngoingProcessorIsDetachedAfterCallDisconnect()
        {
            // Ongoing handler with delegate tests
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200);
            CallAutomationEventProcessor handler = callAutomationClient.GetEventProcessor();
            string callConnectionIdPassedFromOngoingEventProcessor = ServerCallId;

            // Add delegate for call connected event
            handler.AttachOngoingEventProcessor<CallConnected>(CallConnectionId, passedEvent => callConnectionIdPassedFromOngoingEventProcessor = passedEvent.CallConnectionId);

            // Create and send event to event processor first
            SendAndProcessEvent(handler, new CallDisconnected(CallConnectionId, ServerCallId, CorelationId, null, null));

            SendAndProcessEvent(handler, new CallConnected(CallConnectionId, ServerCallId, CorelationId, null, null));

            // Assert if the delegate was never called
            Assert.AreEqual(ServerCallId, callConnectionIdPassedFromOngoingEventProcessor);
        }
    }
}
