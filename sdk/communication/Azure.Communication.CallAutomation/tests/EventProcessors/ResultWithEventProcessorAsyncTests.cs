// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.CallAutomation.Tests.Infrastructure;
using Azure.Core.TestFramework;
using Microsoft.Azure.Amqp.Framing;
using NUnit.Framework;

namespace Azure.Communication.CallAutomation.Tests.EventProcessors
{
    public class ResultWithEventProcessorAsyncTests : CallAutomationEventProcessorTestBase
    {
        [Test]
        public async Task CreateCallEventResultSuccessTest()
        {
            int successCode = (int)HttpStatusCode.Created;

            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(
                responseCode: successCode,
                responseContent: CreateOrAnswerCallOrGetCallConnectionPayload,
                options: new CallAutomationClientOptions() { Source = new CommunicationUserIdentifier("12345") }
                );
            CallAutomationEventProcessor handler = callAutomationClient.GetEventProcessor();

            var response = callAutomationClient.CreateCall(new CreateCallOptions(CreateMockInvite(), new Uri(CallBackUri)));
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(successCode));

            // Create and send event to event processor
            SendAndProcessEvent(handler, new CallConnected(CallConnectionId, ServerCallId, CorrelationId, null, null));

            CreateCallEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.That(returnedResult, Is.Not.Null);
            Assert.That(returnedResult.IsSuccess, Is.EqualTo(true));
            Assert.That(returnedResult.SuccessResult, Is.Not.Null);
            Assert.That(returnedResult.SuccessResult.GetType(), Is.EqualTo(typeof(CallConnected)));
            Assert.That(returnedResult.SuccessResult.CallConnectionId, Is.EqualTo(CallConnectionId));
        }

        [Test]
        public async Task CreateCallEventResultFailedTest()
        {
            // Failed with operation mismatch
            int successCode = (int)HttpStatusCode.Created;

            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(
                responseCode: successCode,
                responseContent: CreateOrAnswerCallOrGetCallConnectionPayload,
                options: new CallAutomationClientOptions() { Source = new CommunicationUserIdentifier("12345") });
            CallAutomationEventProcessor handler = callAutomationClient.GetEventProcessor();

            var response = callAutomationClient.CreateCall(new CreateCallOptions(CreateMockInvite(), new Uri(CallBackUri)));
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(successCode));

            SendAndProcessEvent(handler, new CreateCallFailed(new CreateCallFailedInternal(CallConnectionId, ServerCallId, CorrelationId, null, null)));

            CreateCallEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.That(returnedResult, Is.Not.Null);
            Assert.That(returnedResult.IsSuccess, Is.EqualTo(false));
            Assert.That(returnedResult.FailureResult, Is.Not.Null);
            Assert.That(returnedResult.SuccessResult, Is.Null);
            Assert.That(returnedResult.FailureResult.GetType(), Is.EqualTo(typeof(CreateCallFailed)));
            Assert.That(returnedResult.FailureResult.CallConnectionId, Is.EqualTo(CallConnectionId));
        }

        [Test]
        public async Task ConnectCallEventResultSuccessTest()
        {
            int successCode = (int)HttpStatusCode.OK;

            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(
                responseCode: successCode,
                responseContent: CreateOrAnswerCallOrGetCallConnectionPayload,
                options: new CallAutomationClientOptions() { Source = new CommunicationUserIdentifier("12345") }
                );
            CallAutomationEventProcessor handler = callAutomationClient.GetEventProcessor();

            var response = callAutomationClient.ConnectCall(new ConnectCallOptions(new ServerCallLocator(ServerCallId), new Uri(CallBackUri)));
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(successCode));

            // Create and send event to event processor
            SendAndProcessEvent(handler, new CallConnected(CallConnectionId, ServerCallId, CorrelationId, null, null));

            ConnectCallEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.That(returnedResult, Is.Not.Null);
            Assert.That(returnedResult.IsSuccess, Is.EqualTo(true));
            Assert.That(returnedResult.SuccessResult, Is.Not.Null);
            Assert.That(returnedResult.SuccessResult.GetType(), Is.EqualTo(typeof(CallConnected)));
            Assert.That(returnedResult.SuccessResult.CallConnectionId, Is.EqualTo(CallConnectionId));
        }

        [Test]
        public async Task ConnectCallEventResultFailedTest()
        {
            // Failed with operation mismatch
            int successCode = (int)HttpStatusCode.OK;
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(
                responseCode: successCode,
                responseContent: CreateOrAnswerCallOrGetCallConnectionPayload,
                options: new CallAutomationClientOptions() { Source = new CommunicationUserIdentifier("12345") });
            CallAutomationEventProcessor handler = callAutomationClient.GetEventProcessor();
            var response = callAutomationClient.ConnectCall(new ConnectCallOptions(new ServerCallLocator(ServerCallId), new Uri(CallBackUri)));
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(successCode));
            SendAndProcessEvent(handler, new ConnectFailed(CallConnectionId, ServerCallId, CorrelationId, "mismatchedOperationId", null));
            ConnectCallEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();
            // Assert
            Assert.That(returnedResult, Is.Not.Null);
            Assert.That(returnedResult.IsSuccess, Is.EqualTo(false));
            Assert.That(returnedResult.FailureResult, Is.Not.Null);
            Assert.That(returnedResult.SuccessResult, Is.Null);
            Assert.That(returnedResult.FailureResult.GetType(), Is.EqualTo(typeof(ConnectFailed)));
            Assert.That(returnedResult.FailureResult.CallConnectionId, Is.EqualTo(CallConnectionId));
        }

        [Test]
        public async Task AnswerCallEventResultSuccessTest()
        {
            int successCode = (int)HttpStatusCode.OK;

            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(
                responseCode: successCode,
                responseContent: CreateOrAnswerCallOrGetCallConnectionPayload,
                options: new CallAutomationClientOptions() { Source = new CommunicationUserIdentifier("12345") });
            CallAutomationEventProcessor handler = callAutomationClient.GetEventProcessor();

            var response = callAutomationClient.AnswerCall("incomingCallContext", new Uri(CallBackUri));
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(successCode));

            // Create and send event to event processor
            SendAndProcessEvent(handler, new CallConnected(CallConnectionId, ServerCallId, CorrelationId, null, null));

            AnswerCallEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.That(returnedResult, Is.Not.Null);
            Assert.That(returnedResult.IsSuccess, Is.EqualTo(true));
            Assert.That(returnedResult.SuccessResult, Is.Not.Null);
            Assert.That(returnedResult.SuccessResult.GetType(), Is.EqualTo(typeof(CallConnected)));
            Assert.That(returnedResult.SuccessResult.CallConnectionId, Is.EqualTo(CallConnectionId));
        }

        [Test]
        public async Task AnswerCallEventResultFailedTest()
        {
            int successCode = (int)HttpStatusCode.OK;

            // Failed with operation mismatch
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(
                responseCode: successCode,
                responseContent: CreateOrAnswerCallOrGetCallConnectionPayload,
                options: new CallAutomationClientOptions() { Source = new CommunicationUserIdentifier("12345") });
            CallAutomationEventProcessor handler = callAutomationClient.GetEventProcessor();

            var response = callAutomationClient.AnswerCall("incomingCallContext", new Uri(CallBackUri));
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(successCode));

            // Create and send event to event processor
            SendAndProcessEvent(handler, new AnswerFailed(new AnswerFailedInternal(CallConnectionId, ServerCallId, CorrelationId, null, null)));

            AnswerCallEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.That(returnedResult, Is.Not.Null);
            Assert.That(returnedResult.IsSuccess, Is.EqualTo(false));
            Assert.That(returnedResult.FailureResult, Is.Not.Null);
            Assert.That(returnedResult.SuccessResult, Is.Null);
            Assert.That(returnedResult.FailureResult.GetType(), Is.EqualTo(typeof(AnswerFailed)));
            Assert.That(returnedResult.FailureResult.CallConnectionId, Is.EqualTo(CallConnectionId));
        }

        [Test]
        public async Task TransferCallEventResultSuccessTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, TransferCallOrRemoveParticipantsPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var callInvite = new CallInvite(new CommunicationUserIdentifier(TargetUser));
            var response = callConnection.TransferCallToParticipant(new TransferToParticipantOptions(callInvite.Target as CommunicationUserIdentifier));
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(successCode));
            var transferee = new CommunicationIdentifierModel();
            transferee.CommunicationUser = new CommunicationUserIdentifierModel(TransfereeUser);
            transferee.RawId = TransfereeUser;

            var transferTarget = new CommunicationIdentifierModel();
            transferTarget.CommunicationUser = new CommunicationUserIdentifierModel(TargetUser);
            transferTarget.RawId = TargetUser;
            var internalEvent = new CallTransferAcceptedInternal(CallConnectionId, ServerCallId, CorrelationId, response.Value.OperationContext, null, transferTarget, transferee);

            // Create and send event to event processor
            SendAndProcessEvent(handler, new CallTransferAccepted(internalEvent));

            TransferCallToParticipantEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.That(returnedResult, Is.Not.Null);
            Assert.That(returnedResult.IsSuccess, Is.EqualTo(true));
            Assert.That(returnedResult.SuccessResult, Is.Not.Null);
            Assert.That(returnedResult.FailureResult, Is.Null);
            Assert.That(returnedResult.SuccessResult.GetType(), Is.EqualTo(typeof(CallTransferAccepted)));
            Assert.That(returnedResult.SuccessResult.CallConnectionId, Is.EqualTo(CallConnectionId));
            Assert.That(returnedResult.SuccessResult.OperationContext, Is.EqualTo(response.Value.OperationContext));
            Assert.That(returnedResult.SuccessResult.Transferee.RawId, Is.EqualTo(transferee.CommunicationUser.Id));
            Assert.That(returnedResult.SuccessResult.TransferTarget.RawId, Is.EqualTo(transferTarget.CommunicationUser.Id));
        }

        [Test]
        public async Task TransferCallEventResultFailedTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, TransferCallOrRemoveParticipantsPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var callInvite = new CallInvite(new CommunicationUserIdentifier(TargetUser));
            var response = callConnection.TransferCallToParticipant(new TransferToParticipantOptions(callInvite.Target as CommunicationUserIdentifier));
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(successCode));

            // Create and send event to event processor
            SendAndProcessEvent(handler, new CallTransferFailed(CallConnectionId, ServerCallId, CorrelationId, response.Value.OperationContext, null));

            TransferCallToParticipantEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.That(returnedResult, Is.Not.Null);
            Assert.That(returnedResult.IsSuccess, Is.EqualTo(false));
            Assert.That(returnedResult.SuccessResult, Is.Null);
            Assert.That(returnedResult.FailureResult, Is.Not.Null);
            Assert.That(returnedResult.FailureResult.GetType(), Is.EqualTo(typeof(CallTransferFailed)));
            Assert.That(returnedResult.FailureResult.CallConnectionId, Is.EqualTo(CallConnectionId));
            Assert.That(returnedResult.FailureResult.OperationContext, Is.EqualTo(response.Value.OperationContext));
        }

        [Test]
        public async Task AddParticipantsEventResultSuccessTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, AddParticipantsPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;
            var callInvite = CreateMockInvite();

            var response = callConnection.AddParticipant(new AddParticipantOptions(callInvite));
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(successCode));

            // Create and send event to event processor
            SendAndProcessEvent(handler, CallAutomationModelFactory.AddParticipantSucceeded(CallConnectionId, ServerCallId, CorrelationId, response.Value.OperationContext, null, callInvite.Target));

            AddParticipantEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.That(returnedResult, Is.Not.Null);
            Assert.That(returnedResult.IsSuccess, Is.EqualTo(true));
            Assert.That(returnedResult.SuccessResult, Is.Not.Null);
            Assert.That(returnedResult.FailureResult, Is.Null);
            Assert.That(returnedResult.SuccessResult.GetType(), Is.EqualTo(typeof(AddParticipantSucceeded)));
            Assert.That(returnedResult.SuccessResult.CallConnectionId, Is.EqualTo(CallConnectionId));
            Assert.That(returnedResult.SuccessResult.OperationContext, Is.EqualTo(response.Value.OperationContext));
        }

        [Test]
        public async Task AddParticipantsEventResultFailedTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, AddParticipantsPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var callInvite = CreateMockInvite();
            var response = callConnection.AddParticipant(new AddParticipantOptions(callInvite));
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(successCode));

            // Create and send event to event processor
            SendAndProcessEvent(handler, CallAutomationModelFactory.AddParticipantFailed(CallConnectionId, ServerCallId, CorrelationId, response.Value.OperationContext, null, callInvite.Target));

            AddParticipantEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.That(returnedResult, Is.Not.Null);
            Assert.That(returnedResult.IsSuccess, Is.EqualTo(false));
            Assert.That(returnedResult.SuccessResult, Is.Null);
            Assert.That(returnedResult.FailureResult, Is.Not.Null);
            Assert.That(returnedResult.FailureResult.GetType(), Is.EqualTo(typeof(AddParticipantFailed)));
            Assert.That(returnedResult.FailureResult.CallConnectionId, Is.EqualTo(CallConnectionId));
            Assert.That(returnedResult.FailureResult.OperationContext, Is.EqualTo(response.Value.OperationContext));
        }

        [Test]
        public async Task PlayEventResultSuccessTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, AddParticipantsPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var response = callConnection.GetCallMedia().PlayToAll(new PlayToAllOptions(new FileSource(new Uri(CallBackUri))) { OperationContext = OperationContext });
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(successCode));

            // Create and send event to event processor
            SendAndProcessEvent(handler, new PlayStarted(OperationContext, new ResultInformation() { }, CallConnectionId, ServerCallId, CorrelationId));

            PlayEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            AssertReceivedEvent(returnedResult, typeof(PlayStarted));

            SendAndProcessEvent(handler, new PlayCompleted(OperationContext,new ResultInformation() { },CallConnectionId,ServerCallId,CorrelationId));
            returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            AssertReceivedEvent(returnedResult, typeof(PlayCompleted));
        }

        [Test]
        public async Task PlayEventResultInterruptSuccessTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;
            var callConnection = CreateMockCallConnection(
                new MockResponse[] {
                    new MockResponse(successCode, PlayAudioPayload),
                    new MockResponse(successCode, InterruptAudioPayload)
                });
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            // hold participant
            var response = callConnection.GetCallMedia().Play(
                new PlayOptions(new FileSource(new Uri(CallBackUri)), new List<CommunicationIdentifier> { new CommunicationUserIdentifier(TargetUser) })
                { OperationContext = OperationContext, Loop = true });
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(successCode));

            // interrupting the hold
            var interruptOperationContext = "interruptOperationContext";
            var interruptResponse = callConnection.GetCallMedia().InterruptAudioAndAnnounce(
                new InterruptAudioAndAnnounceOptions(new FileSource(new Uri(CallBackUri)), new CommunicationUserIdentifier(TargetUser))
                {
                    OperationContext = interruptOperationContext
                });
            Assert.That(interruptResponse.GetRawResponse().Status, Is.EqualTo(successCode));

            // Hold started
            SendAndProcessEvent(handler, new PlayStarted(OperationContext, new ResultInformation() { }, CallConnectionId, ServerCallId, CorrelationId));
            PlayEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();
            AssertReceivedEvent(returnedResult, typeof(PlayStarted));

            // hold audio paused
            SendAndProcessEvent(handler, new PlayPaused(OperationContext,new ResultInformation() { },CallConnectionId,ServerCallId,CorrelationId));
            returnedResult = await response.Value.WaitForEventProcessorAsync();
            AssertReceivedEvent(returnedResult, typeof(PlayPaused));

            // announcement started
            SendAndProcessEvent(handler, new PlayStarted(interruptOperationContext, new ResultInformation() { }, CallConnectionId, ServerCallId, CorrelationId));
            PlayEventResult returnedInterruptResult = await interruptResponse.Value.WaitForEventProcessorAsync();
            AssertReceivedEvent(returnedInterruptResult, typeof(PlayStarted), interruptOperationContext);

            // announcement completed
            SendAndProcessEvent(handler, new PlayCompleted(interruptOperationContext, new ResultInformation() { }, CallConnectionId, ServerCallId, CorrelationId));
            returnedInterruptResult = await interruptResponse.Value.WaitForEventProcessorAsync();
            AssertReceivedEvent(returnedInterruptResult, typeof(PlayCompleted), interruptOperationContext);

            // hold audio resumed
            SendAndProcessEvent(handler, new PlayResumed(OperationContext, new ResultInformation() { }, CallConnectionId, ServerCallId, CorrelationId));
            returnedResult = await response.Value.WaitForEventProcessorAsync();
            AssertReceivedEvent(returnedResult, typeof(PlayResumed));
        }

        private static void AssertReceivedEvent(PlayEventResult returnedResult, System.Type expectedType, string expectedOperationContext = OperationContext)
        {
            Assert.That(returnedResult, Is.Not.Null);
            Assert.That(returnedResult.IsSuccess, Is.EqualTo(true));

            if (expectedType == typeof(PlayResumed))
            {
                Assert.That(returnedResult.ResumeResult, Is.Not.Null);
                Assert.That(returnedResult.ResumeResult.CallConnectionId, Is.EqualTo(CallConnectionId));
                Assert.That(returnedResult.ResumeResult.OperationContext, Is.EqualTo(expectedOperationContext));
                return;
            }

            if (expectedType == typeof(PlayStarted))
            {
                Assert.That(returnedResult.StartResult, Is.Not.Null);
                Assert.That(returnedResult.StartResult.CallConnectionId, Is.EqualTo(CallConnectionId));
                Assert.That(returnedResult.StartResult.OperationContext, Is.EqualTo(expectedOperationContext));
                return;
            }

            if (expectedType == typeof(PlayCompleted))
            {
                Assert.That(returnedResult.SuccessResult, Is.Not.Null);
                Assert.That(returnedResult.SuccessResult.CallConnectionId, Is.EqualTo(CallConnectionId));
                Assert.That(returnedResult.SuccessResult.OperationContext, Is.EqualTo(expectedOperationContext));
                return;
            }

            if (expectedType == typeof(PlayPaused))
            {
                Assert.That(returnedResult.PauseResult, Is.Not.Null);
                Assert.That(returnedResult.PauseResult.CallConnectionId, Is.EqualTo(CallConnectionId));
                Assert.That(returnedResult.PauseResult.OperationContext, Is.EqualTo(expectedOperationContext));
                return;
            }
        }

        [Test]
        public async Task PlayEventResultFailedTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, AddParticipantsPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var response = callConnection.GetCallMedia().PlayToAll(new PlayToAllOptions(new FileSource(new Uri(CallBackUri))) { OperationContext = OperationContext });
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(successCode));

            // Create and send event to event processor
            SendAndProcessEvent(handler, new PlayFailed(OperationContext, new ResultInformation() { }, CallConnectionId, ServerCallId, CorrelationId));

            PlayEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.That(returnedResult, Is.Not.Null);
            Assert.That(returnedResult.IsSuccess, Is.EqualTo(false));
            Assert.That(returnedResult.SuccessResult, Is.Null);
            Assert.That(returnedResult.FailureResult, Is.Not.Null);
            Assert.That(returnedResult.FailureResult.GetType(), Is.EqualTo(typeof(PlayFailed)));
            Assert.That(returnedResult.FailureResult.CallConnectionId, Is.EqualTo(CallConnectionId));
            Assert.That(returnedResult.FailureResult.OperationContext, Is.EqualTo(OperationContext));
        }

        [Test]
        public async Task CancelMediaEventResultPlayCancelTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, AddParticipantsPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var response = callConnection.GetCallMedia().CancelAllMediaOperations();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(successCode));

            // Create and send event to event processor
            SendAndProcessEvent(handler, new PlayCanceled(null, null, CallConnectionId, ServerCallId, CorrelationId));

            CancelAllMediaOperationsEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.That(returnedResult, Is.Not.Null);
            Assert.That(returnedResult.IsSuccess, Is.EqualTo(true));
            Assert.That(returnedResult.PlayCanceledSucessEvent, Is.Not.Null);
            Assert.That(returnedResult.RecognizeCanceledSucessEvent, Is.Null);
            Assert.That(returnedResult.PlayCanceledSucessEvent.GetType(), Is.EqualTo(typeof(PlayCanceled)));
            Assert.That(returnedResult.PlayCanceledSucessEvent.CallConnectionId, Is.EqualTo(CallConnectionId));
        }

        [Test]
        public async Task CancelMediaEventResultRecognizeCancelTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, AddParticipantsPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var response = callConnection.GetCallMedia().CancelAllMediaOperations();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(successCode));

            // Create and send event to event processor
            SendAndProcessEvent(handler, new RecognizeCanceled(null, null, CallConnectionId, ServerCallId, CorrelationId));

            CancelAllMediaOperationsEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.That(returnedResult, Is.Not.Null);
            Assert.That(returnedResult.IsSuccess, Is.EqualTo(true));
            Assert.That(returnedResult.RecognizeCanceledSucessEvent, Is.Not.Null);
            Assert.That(returnedResult.PlayCanceledSucessEvent, Is.Null);
            Assert.That(returnedResult.RecognizeCanceledSucessEvent.GetType(), Is.EqualTo(typeof(RecognizeCanceled)));
            Assert.That(returnedResult.RecognizeCanceledSucessEvent.CallConnectionId, Is.EqualTo(CallConnectionId));
        }

        [Test]
        public async Task RecognizeEventResultSuccessTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, AddParticipantsPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var response = callConnection.GetCallMedia().StartRecognizing(new CallMediaRecognizeDtmfOptions(new CommunicationUserIdentifier(TargetId), 1) { OperationContext = OperationContext });
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(successCode));

            // Create and send event to event processor
            SendAndProcessEvent(handler, new RecognizeCompleted(CallConnectionId, ServerCallId, CorrelationId, OperationContext, new ResultInformation(), CallMediaRecognitionType.Dtmf, null));

            StartRecognizingEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.That(returnedResult, Is.Not.Null);
            Assert.That(returnedResult.IsSuccess, Is.EqualTo(true));
            Assert.That(returnedResult.SuccessResult, Is.Not.Null);
            Assert.That(returnedResult.FailureResult, Is.Null);
            Assert.That(returnedResult.SuccessResult.GetType(), Is.EqualTo(typeof(RecognizeCompleted)));
            Assert.That(returnedResult.SuccessResult.CallConnectionId, Is.EqualTo(CallConnectionId));
            Assert.That(returnedResult.SuccessResult.OperationContext, Is.EqualTo(OperationContext));
        }

        [Test]
        public async Task RecognizeEventResultFailedTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, AddParticipantsPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var response = callConnection.GetCallMedia().StartRecognizing(new CallMediaRecognizeDtmfOptions(new CommunicationUserIdentifier(TargetId), 1) { OperationContext = OperationContext });
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(successCode));

            // Create and send event to event processor
            SendAndProcessEvent(handler, new RecognizeFailed(OperationContext, new ResultInformation(), CallConnectionId, ServerCallId, CorrelationId));

            StartRecognizingEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.That(returnedResult, Is.Not.Null);
            Assert.That(returnedResult.IsSuccess, Is.EqualTo(false));
            Assert.That(returnedResult.FailureResult, Is.Not.Null);
            Assert.That(returnedResult.SuccessResult, Is.Null);
            Assert.That(returnedResult.FailureResult.GetType(), Is.EqualTo(typeof(RecognizeFailed)));
            Assert.That(returnedResult.FailureResult.CallConnectionId, Is.EqualTo(CallConnectionId));
            Assert.That(returnedResult.FailureResult.OperationContext, Is.EqualTo(OperationContext));
        }

        [Test]
        public async Task RemoveParticipantEventResultSuccessTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, RemoveParticipantPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;
            var callInvite = CreateMockInvite();

            var response = callConnection.RemoveParticipant(new RemoveParticipantOptions(callInvite.Target));
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(successCode));

            // Create and send event to event processor
            SendAndProcessEvent(handler, CallAutomationModelFactory.RemoveParticipantSucceeded(CallConnectionId, ServerCallId, CorrelationId, response.Value.OperationContext, null, callInvite.Target));

            RemoveParticipantEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.That(returnedResult, Is.Not.Null);
            Assert.That(returnedResult.IsSuccess, Is.EqualTo(true));
            Assert.That(returnedResult.SuccessResult, Is.Not.Null);
            Assert.That(returnedResult.FailureResult, Is.Null);
            Assert.That(returnedResult.SuccessResult.GetType(), Is.EqualTo(typeof(RemoveParticipantSucceeded)));
            Assert.That(returnedResult.SuccessResult.CallConnectionId, Is.EqualTo(CallConnectionId));
            Assert.That(returnedResult.SuccessResult.OperationContext, Is.EqualTo(response.Value.OperationContext));
        }

        [Test]
        public async Task RemoveParticipantsEventResultFailedTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, RemoveParticipantPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var callInvite = CreateMockInvite();
            var response = callConnection.RemoveParticipant(new RemoveParticipantOptions(callInvite.Target));
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(successCode));

            // Create and send event to event processor
            SendAndProcessEvent(handler, CallAutomationModelFactory.RemoveParticipantFailed(CallConnectionId, ServerCallId, CorrelationId, response.Value.OperationContext, null, callInvite.Target));

            RemoveParticipantEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.That(returnedResult, Is.Not.Null);
            Assert.That(returnedResult.IsSuccess, Is.EqualTo(false));
            Assert.That(returnedResult.SuccessResult, Is.Null);
            Assert.That(returnedResult.FailureResult, Is.Not.Null);
            Assert.That(returnedResult.FailureResult.GetType(), Is.EqualTo(typeof(RemoveParticipantFailed)));
            Assert.That(returnedResult.FailureResult.CallConnectionId, Is.EqualTo(CallConnectionId));
            Assert.That(returnedResult.FailureResult.OperationContext, Is.EqualTo(response.Value.OperationContext));
        }

        [Test]
        public async Task SendDtmfEventResultSuccessTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, AddParticipantsPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var dtmfOption = new SendDtmfTonesOptions(new DtmfTone[] { DtmfTone.One, DtmfTone.Two, DtmfTone.Three, DtmfTone.Pound }, new CommunicationUserIdentifier("targetUserId"));
            dtmfOption.OperationContext = OperationContext;

            var response = callConnection.GetCallMedia().SendDtmfTones(dtmfOption);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(successCode));

            // Create and send event to event processor
            SendAndProcessEvent(handler, CallAutomationModelFactory.SendDtmfTonesCompleted(CallConnectionId, ServerCallId, CorrelationId, OperationContext, new ResultInformation()));

            SendDtmfTonesEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.That(returnedResult, Is.Not.Null);
            Assert.That(returnedResult.IsSuccess, Is.EqualTo(true));
            Assert.That(returnedResult.SuccessResult, Is.Not.Null);
            Assert.That(returnedResult.FailureResult, Is.Null);
            Assert.That(returnedResult.SuccessResult.GetType(), Is.EqualTo(typeof(SendDtmfTonesCompleted)));
            Assert.That(returnedResult.SuccessResult.CallConnectionId, Is.EqualTo(CallConnectionId));
            Assert.That(returnedResult.SuccessResult.OperationContext, Is.EqualTo(OperationContext));
        }

        [Test]
        public async Task SendDtmfEventResultFailedTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, AddParticipantsPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var dtmfOption = new SendDtmfTonesOptions(new DtmfTone[] { DtmfTone.One, DtmfTone.Two, DtmfTone.Three, DtmfTone.Pound }, new CommunicationUserIdentifier("targetUserId"));
            dtmfOption.OperationContext = OperationContext;

            var response = callConnection.GetCallMedia().SendDtmfTones(dtmfOption);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(successCode));

            // Create and send event to event processor
            SendAndProcessEvent(handler, CallAutomationModelFactory.SendDtmfTonesFailed(CallConnectionId, ServerCallId, CorrelationId, OperationContext, new ResultInformation()));

            SendDtmfTonesEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.That(returnedResult, Is.Not.Null);
            Assert.That(returnedResult.IsSuccess, Is.EqualTo(false));
            Assert.That(returnedResult.FailureResult, Is.Not.Null);
            Assert.That(returnedResult.SuccessResult, Is.Null);
            Assert.That(returnedResult.FailureResult.GetType(), Is.EqualTo(typeof(SendDtmfTonesFailed)));
            Assert.That(returnedResult.FailureResult.CallConnectionId, Is.EqualTo(CallConnectionId));
            Assert.That(returnedResult.FailureResult.OperationContext, Is.EqualTo(OperationContext));
        }

        [Test]
        public async Task StartDialogEventResultSuccessTest()
        {
            int successCode = (int)HttpStatusCode.Created;

            var callConnection = CreateMockCallConnection(successCode, DialogPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var dialogContext = new Dictionary<string, object>();
            var startDialogOptions = new StartDialog(new PowerVirtualAgentsDialog("botAppId", dialogContext))
            {
                OperationContext = OperationContext
            };

            var response = callConnection.GetCallDialog().StartDialog(startDialogOptions);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(successCode));

            // Create and send event to event processor
            SendAndProcessEvent(handler, new DialogStarted(CallConnectionId, ServerCallId, CorrelationId, OperationContext, new ResultInformation(), "dialogId", DialogInputType.PowerVirtualAgents));

            DialogEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.That(returnedResult, Is.Not.Null);
            Assert.That(returnedResult.IsSuccess, Is.EqualTo(true));
            Assert.That(returnedResult.DialogStartedSuccessEvent, Is.Not.Null);
            Assert.That(returnedResult.DialogCompletedSuccessResult, Is.Null);
            Assert.That(returnedResult.DialogConsentSuccessEvent, Is.Null);
            Assert.That(returnedResult.DialogHangupSuccessEvent, Is.Null);
            Assert.That(returnedResult.DialogLanguageChangeEvent, Is.Null);
            Assert.That(returnedResult.DialogSensitivityUpdateEvent, Is.Null);
            Assert.That(returnedResult.DialogTransferSuccessEvent, Is.Null);
            Assert.That(returnedResult.FailureResult, Is.Null);
            Assert.That(returnedResult.DialogStartedSuccessEvent.GetType(), Is.EqualTo(typeof(DialogStarted)));
            Assert.That(returnedResult.DialogStartedSuccessEvent.CallConnectionId, Is.EqualTo(CallConnectionId));
            Assert.That(returnedResult.DialogStartedSuccessEvent.OperationContext, Is.EqualTo(OperationContext));
        }

        [Test]
        public async Task StartDialogEventResultFailedTest()
        {
            int successCode = (int)HttpStatusCode.Created;

            var callConnection = CreateMockCallConnection(successCode, DialogPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var dialogContext = new Dictionary<string, object>();
            var startDialogOptions = new StartDialog(new PowerVirtualAgentsDialog("botAppId", dialogContext))
            {
                OperationContext = OperationContext
            };

            var response = callConnection.GetCallDialog().StartDialog(startDialogOptions);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(successCode));

            // Create and send event to event processor
            SendAndProcessEvent(handler, new DialogFailed(CallConnectionId, ServerCallId, CorrelationId, OperationContext, new ResultInformation(), "dialogId", DialogInputType.PowerVirtualAgents));

            DialogEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.That(returnedResult, Is.Not.Null);
            Assert.That(returnedResult.IsSuccess, Is.EqualTo(false));
            Assert.That(returnedResult.DialogStartedSuccessEvent, Is.Null);
            Assert.That(returnedResult.DialogCompletedSuccessResult, Is.Null);
            Assert.That(returnedResult.DialogConsentSuccessEvent, Is.Null);
            Assert.That(returnedResult.DialogHangupSuccessEvent, Is.Null);
            Assert.That(returnedResult.DialogLanguageChangeEvent, Is.Null);
            Assert.That(returnedResult.DialogSensitivityUpdateEvent, Is.Null);
            Assert.That(returnedResult.DialogTransferSuccessEvent, Is.Null);
            Assert.That(returnedResult.FailureResult, Is.Not.Null);
            Assert.That(returnedResult.FailureResult.GetType(), Is.EqualTo(typeof(DialogFailed)));
            Assert.That(returnedResult.FailureResult.CallConnectionId, Is.EqualTo(CallConnectionId));
            Assert.That(returnedResult.FailureResult.OperationContext, Is.EqualTo(OperationContext));
        }

        [Test]
        public async Task CancelAddParticipantSucceededEventResultFailedTest()
        {
            var invitationId = "invitationId";
            var callConnection = CreateMockCallConnection(202, CancelAddParticipantPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;
            var callInvite = CreateMockInvite();
            var response = callConnection.CancelAddParticipantOperation(invitationId);

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(202));

            // Create and send event to event processor
            SendAndProcessEvent(handler, CallAutomationModelFactory.CancelAddParticipantFailed(
                CallConnectionId,
                ServerCallId,
                CorrelationId,
                invitationId,
                new ResultInformation(400, 4000, "resultInformation", null, null),
                OperationContext));

            CancelAddParticipantEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.That(returnedResult, Is.Not.Null);
            Assert.That(returnedResult.IsSuccess, Is.EqualTo(false));
            Assert.That(returnedResult.FailureResult, Is.Not.Null);
            Assert.That(returnedResult.SuccessResult, Is.Null);
            Assert.That(returnedResult.FailureResult.GetType(), Is.EqualTo(typeof(CancelAddParticipantFailed)));
            Assert.That(returnedResult.FailureResult.CallConnectionId, Is.EqualTo(CallConnectionId));
            Assert.That(returnedResult.FailureResult.InvitationId, Is.EqualTo(invitationId));
        }

        [Test]
        public async Task CancelAddParticipantSucceededEventResultSuccessTest()
        {
            var invitationId = "invitationId";
            var callConnection = CreateMockCallConnection(202, CancelAddParticipantPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;
            var callInvite = CreateMockInvite();
            var response = callConnection.CancelAddParticipantOperation(invitationId);

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(202));

            // Create and send event to event processor
            SendAndProcessEvent(handler, CallAutomationModelFactory.CancelAddParticipantSucceeded(
                CallConnectionId,
                ServerCallId,
                CorrelationId,
                invitationId,
                OperationContext));

            CancelAddParticipantEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.That(returnedResult, Is.Not.Null);
            Assert.That(returnedResult.IsSuccess, Is.EqualTo(true));
            Assert.That(returnedResult.SuccessResult, Is.Not.Null);
            Assert.That(returnedResult.FailureResult, Is.Null);
            Assert.That(returnedResult.SuccessResult.GetType(), Is.EqualTo(typeof(CancelAddParticipantSucceeded)));
            Assert.That(returnedResult.SuccessResult.CallConnectionId, Is.EqualTo(CallConnectionId));
            Assert.That(returnedResult.SuccessResult.InvitationId, Is.EqualTo(invitationId));
        }

        [Test]
        public async Task HoldEventResultSuccessTest()
        {
            int successCode = (int)HttpStatusCode.OK;

            var callConnection = CreateMockCallConnection(successCode, AddParticipantsPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var response = callConnection.GetCallMedia().Hold(new HoldOptions(new CommunicationUserIdentifier(TargetUser)) { PlaySource = new FileSource(new Uri(CallBackUri)),OperationContext= OperationContext });
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(successCode));

            // Create and send event to event processor
            SendAndProcessEvent(handler, new HoldAudioStarted(OperationContext, new ResultInformation() { }, CallConnectionId, ServerCallId, CorrelationId));

            HoldEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            AssertHoldEvent(returnedResult, typeof(HoldAudioStarted));

            SendAndProcessEvent(handler, new HoldAudioCompleted(OperationContext, new ResultInformation() { }, CallConnectionId, ServerCallId, CorrelationId));
            returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            AssertHoldEvent(returnedResult, typeof(HoldAudioCompleted));
        }

        [Test]
        public async Task HoldEventResultFailedTest()
        {
            int successCode = (int)HttpStatusCode.OK;

            var callConnection = CreateMockCallConnection(successCode, AddParticipantsPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var response = callConnection.GetCallMedia().Hold(new HoldOptions(new CommunicationUserIdentifier(TargetUser)) { PlaySource = new FileSource(new Uri(CallBackUri)), OperationContext = OperationContext });
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(successCode));

            // Create and send event to event processor
            SendAndProcessEvent(handler, new HoldFailed(OperationContext, new ResultInformation() { }, CallConnectionId, ServerCallId, CorrelationId));

            HoldEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.That(returnedResult, Is.Not.Null);
            Assert.That(returnedResult.IsSuccess, Is.EqualTo(false));
            Assert.That(returnedResult.SuccessResult, Is.Null);
            Assert.That(returnedResult.FailureResult, Is.Not.Null);
            Assert.That(returnedResult.FailureResult.GetType(), Is.EqualTo(typeof(HoldFailed)));
            Assert.That(returnedResult.FailureResult.CallConnectionId, Is.EqualTo(CallConnectionId));
            Assert.That(returnedResult.FailureResult.OperationContext, Is.EqualTo(OperationContext));
        }
        private static void AssertHoldEvent(HoldEventResult returnedResult, System.Type expectedType, string expectedOperationContext = OperationContext)
        {
            Assert.That(returnedResult, Is.Not.Null);
            Assert.That(returnedResult.IsSuccess, Is.EqualTo(true));

            if (expectedType == typeof(HoldAudioResumed))
            {
                Assert.That(returnedResult.ResumeResult, Is.Not.Null);
                Assert.That(returnedResult.ResumeResult.CallConnectionId, Is.EqualTo(CallConnectionId));
                Assert.That(returnedResult.ResumeResult.OperationContext, Is.EqualTo(expectedOperationContext));
                return;
            }

            if (expectedType == typeof(HoldAudioStarted))
            {
                Assert.That(returnedResult.StartResult, Is.Not.Null);
                Assert.That(returnedResult.StartResult.CallConnectionId, Is.EqualTo(CallConnectionId));
                Assert.That(returnedResult.StartResult.OperationContext, Is.EqualTo(expectedOperationContext));
                return;
            }

            if (expectedType == typeof(HoldAudioCompleted))
            {
                Assert.That(returnedResult.SuccessResult, Is.Not.Null);
                Assert.That(returnedResult.SuccessResult.CallConnectionId, Is.EqualTo(CallConnectionId));
                Assert.That(returnedResult.SuccessResult.OperationContext, Is.EqualTo(expectedOperationContext));
                return;
            }

            if (expectedType == typeof(HoldAudioPaused))
            {
                Assert.That(returnedResult.PauseResult, Is.Not.Null);
                Assert.That(returnedResult.PauseResult.CallConnectionId, Is.EqualTo(CallConnectionId));
                Assert.That(returnedResult.PauseResult.OperationContext, Is.EqualTo(expectedOperationContext));
                return;
            }
        }
    }
}