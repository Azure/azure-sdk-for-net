// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.CallAutomation.Tests.Infrastructure;
using Microsoft.Azure.Amqp.Framing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace Azure.Communication.CallAutomation.Tests.EventProcessors
{
    public class ResultWithEventProcessorTests : CallAutomationEventProcessorTestBase
    {
        [Test]
        public async Task CreateCallEventResultSuccessTest()
        {
            int successCode = (int)HttpStatusCode.Created;

            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(
                responseCode: successCode,
                responseContent: CreateOrAnswerCallOrGetCallConnectionPayload,
                options: new CallAutomationClientOptions(source: new CommunicationUserIdentifier("12345")));
            CallAutomationEventProcessor handler = callAutomationClient.GetEventProcessor();

            var response = callAutomationClient.CreateCall(new CreateCallOptions(CreateMockInvite(), new Uri(CallBackUri)));
            Assert.AreEqual(successCode, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, new CallConnected(CallConnectionId, ServerCallId, CorelationId, null));

            CreateCallEventResult returnedResult = await response.Value.WaitForEvent();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(true, returnedResult.IsSuccessEvent);
            Assert.NotNull(returnedResult.SuccessEvent);
            Assert.AreEqual(typeof(CallConnected), returnedResult.SuccessEvent.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.SuccessEvent.CallConnectionId);
        }

        [Test]
        public async Task CreateCallEventResultFailedTest()
        {
            // Failed with operation mismatch
            int successCode = (int)HttpStatusCode.Created;

            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(
                responseCode: successCode,
                responseContent: CreateOrAnswerCallOrGetCallConnectionPayload,
                options: new CallAutomationClientOptions(source: new CommunicationUserIdentifier("12345")));
            CallAutomationEventProcessor handler = callAutomationClient.GetEventProcessor();

            var response = callAutomationClient.CreateCall(new CreateCallOptions(CreateMockInvite(), new Uri(CallBackUri)));
            Assert.AreEqual(successCode, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, new CallConnected(CallConnectionId, ServerCallId, CorelationId, "mismatchedOperationId"));

            try
            {
                _ = await response.Value.WaitForEvent();
            }
            catch (TimeoutException)
            {
                // success
                return;
            }
        }

        [Test]
        public async Task AnswerCallEventResultSuccessTest()
        {
            int successCode = (int)HttpStatusCode.OK;

            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(
                responseCode: successCode,
                responseContent: CreateOrAnswerCallOrGetCallConnectionPayload,
                options: new CallAutomationClientOptions(source: new CommunicationUserIdentifier("12345")));
            CallAutomationEventProcessor handler = callAutomationClient.GetEventProcessor();

            var response = callAutomationClient.AnswerCall("incomingCallContext", new Uri(CallBackUri));
            Assert.AreEqual(successCode, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, new CallConnected(CallConnectionId, ServerCallId, CorelationId, null));

            AnswerCallEventResult returnedResult = await response.Value.WaitForEvent();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(true, returnedResult.IsSuccessEvent);
            Assert.NotNull(returnedResult.SuccessEvent);
            Assert.AreEqual(typeof(CallConnected), returnedResult.SuccessEvent.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.SuccessEvent.CallConnectionId);
        }

        [Test]
        public async Task AnswerCallEventResultFailedTest()
        {
            int successCode = (int)HttpStatusCode.OK;

            // Failed with operation mismatch
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(
                responseCode: successCode,
                responseContent: CreateOrAnswerCallOrGetCallConnectionPayload,
                options: new CallAutomationClientOptions(source: new CommunicationUserIdentifier("12345")));
            CallAutomationEventProcessor handler = callAutomationClient.GetEventProcessor();

            var response = callAutomationClient.AnswerCall("incomingCallContext", new Uri(CallBackUri));
            Assert.AreEqual(successCode, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, new CallConnected(CallConnectionId, ServerCallId, CorelationId, "mismatchedOperationId"));

            try
            {
                _ = await response.Value.WaitForEvent();
            }
            catch (TimeoutException)
            {
                // Success
                return;
            }
        }

        [Test]
        public async Task TransferCallEventResultSuccessTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, TransferCallOrRemoveParticipantsPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var callInvite = new CallInvite(new CommunicationUserIdentifier(TargetUser));
            var response = callConnection.TransferCallToParticipant(new TransferToParticipantOptions(callInvite));
            Assert.AreEqual(successCode, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, new CallTransferAccepted(CallConnectionId, ServerCallId, CorelationId, response.Value.OperationContext, null));

            TransferCallToParticipantEventResult returnedResult = await response.Value.WaitForEvent();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(true, returnedResult.IsSuccessEvent);
            Assert.NotNull(returnedResult.SuccessEvent);
            Assert.IsNull(returnedResult.FailureEvent);
            Assert.AreEqual(typeof(CallTransferAccepted), returnedResult.SuccessEvent.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.SuccessEvent.CallConnectionId);
            Assert.AreEqual(response.Value.OperationContext, returnedResult.SuccessEvent.OperationContext);
        }

        [Test]
        public async Task TransferCallEventResultFailedTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, TransferCallOrRemoveParticipantsPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var callInvite = new CallInvite(new CommunicationUserIdentifier(TargetUser));
            var response = callConnection.TransferCallToParticipant(new TransferToParticipantOptions(callInvite));
            Assert.AreEqual(successCode, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, new CallTransferFailed(CallConnectionId, ServerCallId, CorelationId, response.Value.OperationContext, null));

            TransferCallToParticipantEventResult returnedResult = await response.Value.WaitForEvent();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(false, returnedResult.IsSuccessEvent);
            Assert.IsNull(returnedResult.SuccessEvent);
            Assert.NotNull(returnedResult.FailureEvent);
            Assert.AreEqual(typeof(CallTransferFailed), returnedResult.FailureEvent.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.FailureEvent.CallConnectionId);
            Assert.AreEqual(response.Value.OperationContext, returnedResult.FailureEvent.OperationContext);
        }

        [Test]
        public async Task AddParticipantsEventResultSuccessTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, AddParticipantsPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;
            var callInvite = CreateMockInvite();

            var response = callConnection.AddParticipant(new AddParticipantOptions(callInvite));
            Assert.AreEqual(successCode, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, CallAutomationModelFactory.AddParticipantSucceeded(CallConnectionId, ServerCallId, CorelationId, response.Value.OperationContext, null, callInvite.Target));

            AddParticipantsEventResult returnedResult = await response.Value.WaitForEvent();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(true, returnedResult.IsSuccessEvent);
            Assert.NotNull(returnedResult.SuccessEvent);
            Assert.IsNull(returnedResult.FailureEvent);
            Assert.AreEqual(typeof(AddParticipantSucceeded), returnedResult.SuccessEvent.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.SuccessEvent.CallConnectionId);
            Assert.AreEqual(response.Value.OperationContext, returnedResult.SuccessEvent.OperationContext);
        }

        [Test]
        public async Task AddParticipantsEventResultFailedTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, AddParticipantsPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var callInvite = CreateMockInvite();
            var response = callConnection.AddParticipant(new AddParticipantOptions(callInvite));
            Assert.AreEqual(successCode, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, CallAutomationModelFactory.AddParticipantFailed(CallConnectionId, ServerCallId, CorelationId, response.Value.OperationContext, null, callInvite.Target));

            AddParticipantsEventResult returnedResult = await response.Value.WaitForEvent();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(false, returnedResult.IsSuccessEvent);
            Assert.IsNull(returnedResult.SuccessEvent);
            Assert.NotNull(returnedResult.FailureEvent);
            Assert.AreEqual(typeof(AddParticipantFailed), returnedResult.FailureEvent.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.FailureEvent.CallConnectionId);
            Assert.AreEqual(response.Value.OperationContext, returnedResult.FailureEvent.OperationContext);
        }

        [Test]
        public async Task PlayEventResultSuccessTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, AddParticipantsPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var response = callConnection.GetCallMedia().PlayToAll(new FileSource(new Uri(CallBackUri)), new PlayOptions() { OperationContext = OperationContext });
            Assert.AreEqual(successCode, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, new PlayCompleted(CallConnectionId, ServerCallId, CorelationId, OperationContext, new ResultInformation() { }));

            PlayEventResult returnedResult = await response.Value.WaitForEvent();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(true, returnedResult.IsSuccessEvent);
            Assert.NotNull(returnedResult.SuccessEvent);
            Assert.IsNull(returnedResult.FailureEvent);
            Assert.AreEqual(typeof(PlayCompleted), returnedResult.SuccessEvent.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.SuccessEvent.CallConnectionId);
            Assert.AreEqual(OperationContext, returnedResult.SuccessEvent.OperationContext);
        }

        [Test]
        public async Task PlayEventResultFailedTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, AddParticipantsPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var response = callConnection.GetCallMedia().PlayToAll(new FileSource(new Uri(CallBackUri)), new PlayOptions() { OperationContext = OperationContext });
            Assert.AreEqual(successCode, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, new PlayFailed(CallConnectionId, ServerCallId, CorelationId, OperationContext, new ResultInformation() { }));

            PlayEventResult returnedResult = await response.Value.WaitForEvent();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(false, returnedResult.IsSuccessEvent);
            Assert.IsNull(returnedResult.SuccessEvent);
            Assert.NotNull(returnedResult.FailureEvent);
            Assert.AreEqual(typeof(PlayFailed), returnedResult.FailureEvent.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.FailureEvent.CallConnectionId);
            Assert.AreEqual(OperationContext, returnedResult.FailureEvent.OperationContext);
        }

        [Test]
        public async Task CancelMediaEventResultPlayCancelTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, AddParticipantsPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var response = callConnection.GetCallMedia().CancelAllMediaOperations();
            Assert.AreEqual(successCode, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, new PlayCanceled(CallConnectionId, ServerCallId, CorelationId, null));

            CancelAllMediaOperationsEventResult returnedResult = await response.Value.WaitForEvent();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(true, returnedResult.IsSuccessEvent);
            Assert.NotNull(returnedResult.PlayCanceledSucessEvent);
            Assert.IsNull(returnedResult.RecognizeCanceledSucessEvent);
            Assert.AreEqual(typeof(PlayCanceled), returnedResult.PlayCanceledSucessEvent.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.PlayCanceledSucessEvent.CallConnectionId);
        }

        [Test]
        public async Task CancelMediaEventResultRecognizeCancelTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, AddParticipantsPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var response = callConnection.GetCallMedia().CancelAllMediaOperations();
            Assert.AreEqual(successCode, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, new RecognizeCanceled(CallConnectionId, ServerCallId, CorelationId, null));

            CancelAllMediaOperationsEventResult returnedResult = await response.Value.WaitForEvent();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(true, returnedResult.IsSuccessEvent);
            Assert.NotNull(returnedResult.RecognizeCanceledSucessEvent);
            Assert.IsNull(returnedResult.PlayCanceledSucessEvent);
            Assert.AreEqual(typeof(RecognizeCanceled), returnedResult.RecognizeCanceledSucessEvent.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.RecognizeCanceledSucessEvent.CallConnectionId);
        }

        [Test]
        public async Task RecognizeEventResultSuccessTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, AddParticipantsPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var response = callConnection.GetCallMedia().StartRecognizing(new CallMediaRecognizeDtmfOptions(new CommunicationUserIdentifier(TargetId), 1) { OperationContext = OperationContext });
            Assert.AreEqual(successCode, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, new RecognizeCompleted(CallConnectionId, ServerCallId, CorelationId, OperationContext, new ResultInformation(), CallMediaRecognitionType.Dtmf, null, null));

            StartRecognizingEventResult returnedResult = await response.Value.WaitForEvent();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(true, returnedResult.IsSuccessEvent);
            Assert.NotNull(returnedResult.SuccessEvent);
            Assert.IsNull(returnedResult.FailureEvent);
            Assert.AreEqual(typeof(RecognizeCompleted), returnedResult.SuccessEvent.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.SuccessEvent.CallConnectionId);
            Assert.AreEqual(OperationContext, returnedResult.SuccessEvent.OperationContext);
        }

        [Test]
        public async Task RecognizeEventResultFailedTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, AddParticipantsPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var response = callConnection.GetCallMedia().StartRecognizing(new CallMediaRecognizeDtmfOptions(new CommunicationUserIdentifier(TargetId), 1) { OperationContext = OperationContext });
            Assert.AreEqual(successCode, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, new RecognizeFailed(CallConnectionId, ServerCallId, CorelationId, OperationContext, new ResultInformation()));

            StartRecognizingEventResult returnedResult = await response.Value.WaitForEvent();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(false, returnedResult.IsSuccessEvent);
            Assert.NotNull(returnedResult.FailureEvent);
            Assert.IsNull(returnedResult.SuccessEvent);
            Assert.AreEqual(typeof(RecognizeFailed), returnedResult.FailureEvent.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.FailureEvent.CallConnectionId);
            Assert.AreEqual(OperationContext, returnedResult.FailureEvent.OperationContext);
        }
    }
}
