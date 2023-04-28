﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.CallAutomation.Tests.Infrastructure;
using Microsoft.Azure.Amqp.Framing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

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
                options: new CallAutomationClientOptions(source: new CommunicationUserIdentifier("12345")));
            CallAutomationEventProcessor handler = callAutomationClient.GetEventProcessor();

            var response = callAutomationClient.CreateCall(new CreateCallOptions(CreateMockInvite(), new Uri(CallBackUri)));
            Assert.AreEqual(successCode, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, new CallConnectedEventData(CallConnectionId, ServerCallId, CorelationId, null));

            CreateCallEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(true, returnedResult.IsSuccess);
            Assert.NotNull(returnedResult.SuccessResult);
            Assert.AreEqual(typeof(CallConnectedEventData), returnedResult.SuccessResult.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.SuccessResult.CallConnectionId);
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
            SendAndProcessEvent(handler, new CallConnectedEventData(CallConnectionId, ServerCallId, CorelationId, "mismatchedOperationId"));

            try
            {
                CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
                CancellationToken token = cts.Token;
                _ = await response.Value.WaitForEventProcessorAsync(token);
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
            SendAndProcessEvent(handler, new CallConnectedEventData(CallConnectionId, ServerCallId, CorelationId, null));

            AnswerCallEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(true, returnedResult.IsSuccess);
            Assert.NotNull(returnedResult.SuccessResult);
            Assert.AreEqual(typeof(CallConnectedEventData), returnedResult.SuccessResult.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.SuccessResult.CallConnectionId);
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
            SendAndProcessEvent(handler, new CallConnectedEventData(CallConnectionId, ServerCallId, CorelationId, "mismatchedOperationId"));

            try
            {
                CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
                CancellationToken token = cts.Token;
                _ = await response.Value.WaitForEventProcessorAsync();
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
            SendAndProcessEvent(handler, new CallTransferAcceptedEventData(CallConnectionId, ServerCallId, CorelationId, response.Value.OperationContext, null));

            TransferCallToParticipantEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(true, returnedResult.IsSuccess);
            Assert.NotNull(returnedResult.SuccessResult);
            Assert.IsNull(returnedResult.FailureResult);
            Assert.AreEqual(typeof(CallTransferAcceptedEventData), returnedResult.SuccessResult.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.SuccessResult.CallConnectionId);
            Assert.AreEqual(response.Value.OperationContext, returnedResult.SuccessResult.OperationContext);
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
            SendAndProcessEvent(handler, new CallTransferFailedEventData(CallConnectionId, ServerCallId, CorelationId, response.Value.OperationContext, null));

            TransferCallToParticipantEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(false, returnedResult.IsSuccess);
            Assert.IsNull(returnedResult.SuccessResult);
            Assert.NotNull(returnedResult.FailureResult);
            Assert.AreEqual(typeof(CallTransferFailedEventData), returnedResult.FailureResult.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.FailureResult.CallConnectionId);
            Assert.AreEqual(response.Value.OperationContext, returnedResult.FailureResult.OperationContext);
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

            AddParticipantEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(true, returnedResult.IsSuccess);
            Assert.NotNull(returnedResult.SuccessResult);
            Assert.IsNull(returnedResult.FailureResult);
            Assert.AreEqual(typeof(AddParticipantSucceededEventData), returnedResult.SuccessResult.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.SuccessResult.CallConnectionId);
            Assert.AreEqual(response.Value.OperationContext, returnedResult.SuccessResult.OperationContext);
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

            AddParticipantEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(false, returnedResult.IsSuccess);
            Assert.IsNull(returnedResult.SuccessResult);
            Assert.NotNull(returnedResult.FailureResult);
            Assert.AreEqual(typeof(AddParticipantFailedEventData), returnedResult.FailureResult.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.FailureResult.CallConnectionId);
            Assert.AreEqual(response.Value.OperationContext, returnedResult.FailureResult.OperationContext);
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
            SendAndProcessEvent(handler, new PlayCompletedEventData(CallConnectionId, ServerCallId, CorelationId, OperationContext, new ResultInformation() { }));

            PlayEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(true, returnedResult.IsSuccess);
            Assert.NotNull(returnedResult.SuccessResult);
            Assert.IsNull(returnedResult.FailureResult);
            Assert.AreEqual(typeof(PlayCompletedEventData), returnedResult.SuccessResult.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.SuccessResult.CallConnectionId);
            Assert.AreEqual(OperationContext, returnedResult.SuccessResult.OperationContext);
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
            SendAndProcessEvent(handler, new PlayFailedEventData(CallConnectionId, ServerCallId, CorelationId, OperationContext, new ResultInformation() { }));

            PlayEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(false, returnedResult.IsSuccess);
            Assert.IsNull(returnedResult.SuccessResult);
            Assert.NotNull(returnedResult.FailureResult);
            Assert.AreEqual(typeof(PlayFailedEventData), returnedResult.FailureResult.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.FailureResult.CallConnectionId);
            Assert.AreEqual(OperationContext, returnedResult.FailureResult.OperationContext);
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
            SendAndProcessEvent(handler, new PlayCanceledEventData(CallConnectionId, ServerCallId, CorelationId, null));

            CancelAllMediaOperationsEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(true, returnedResult.IsSuccess);
            Assert.NotNull(returnedResult.PlayCanceledSucessEvent);
            Assert.IsNull(returnedResult.RecognizeCanceledSucessEvent);
            Assert.AreEqual(typeof(PlayCanceledEventData), returnedResult.PlayCanceledSucessEvent.GetType());
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
            SendAndProcessEvent(handler, new RecognizeCanceledEventData(CallConnectionId, ServerCallId, CorelationId, null));

            CancelAllMediaOperationsEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(true, returnedResult.IsSuccess);
            Assert.NotNull(returnedResult.RecognizeCanceledSucessEvent);
            Assert.IsNull(returnedResult.PlayCanceledSucessEvent);
            Assert.AreEqual(typeof(RecognizeCanceledEventData), returnedResult.RecognizeCanceledSucessEvent.GetType());
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
            SendAndProcessEvent(handler, new RecognizeCompletedEventData(CallConnectionId, ServerCallId, CorelationId, OperationContext, new ResultInformation(), CallMediaRecognitionType.Dtmf, null, null, null));

            StartRecognizingEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(true, returnedResult.IsSuccess);
            Assert.NotNull(returnedResult.SuccessResult);
            Assert.IsNull(returnedResult.FailureResult);
            Assert.AreEqual(typeof(RecognizeCompletedEventData), returnedResult.SuccessResult.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.SuccessResult.CallConnectionId);
            Assert.AreEqual(OperationContext, returnedResult.SuccessResult.OperationContext);
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
            SendAndProcessEvent(handler, new RecognizeFailedEventData(CallConnectionId, ServerCallId, CorelationId, OperationContext, new ResultInformation()));

            StartRecognizingEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(false, returnedResult.IsSuccess);
            Assert.NotNull(returnedResult.FailureResult);
            Assert.IsNull(returnedResult.SuccessResult);
            Assert.AreEqual(typeof(RecognizeFailedEventData), returnedResult.FailureResult.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.FailureResult.CallConnectionId);
            Assert.AreEqual(OperationContext, returnedResult.FailureResult.OperationContext);
        }

        [Test]
        public async Task RemoveParticipantEventResultSuccessTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, RemoveParticipantPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;
            var callInvite = CreateMockInvite();

            var response = callConnection.RemoveParticipant(new RemoveParticipantOptions(callInvite.Target));
            Assert.AreEqual(successCode, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, CallAutomationModelFactory.RemoveParticipantSucceeded(CallConnectionId, ServerCallId, CorelationId, response.Value.OperationContext, null, callInvite.Target));

            RemoveParticipantEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(true, returnedResult.IsSuccess);
            Assert.NotNull(returnedResult.SuccessResult);
            Assert.IsNull(returnedResult.FailureResult);
            Assert.AreEqual(typeof(RemoveParticipantSucceededEventData), returnedResult.SuccessResult.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.SuccessResult.CallConnectionId);
            Assert.AreEqual(response.Value.OperationContext, returnedResult.SuccessResult.OperationContext);
        }

        [Test]
        public async Task RemoveParticipantsEventResultFailedTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, RemoveParticipantPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var callInvite = CreateMockInvite();
            var response = callConnection.RemoveParticipant(new RemoveParticipantOptions(callInvite.Target));
            Assert.AreEqual(successCode, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, CallAutomationModelFactory.RemoveParticipantFailed(CallConnectionId, ServerCallId, CorelationId, response.Value.OperationContext, null, callInvite.Target));

            RemoveParticipantEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(false, returnedResult.IsSuccess);
            Assert.IsNull(returnedResult.SuccessResult);
            Assert.NotNull(returnedResult.FailureResult);
            Assert.AreEqual(typeof(RemoveParticipantFailedEventData), returnedResult.FailureResult.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.FailureResult.CallConnectionId);
            Assert.AreEqual(response.Value.OperationContext, returnedResult.FailureResult.OperationContext);
        }

        [Test]
        public async Task SendDtmfEventResultSuccessTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, AddParticipantsPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var response = callConnection.GetCallMedia().SendDtmf(
                       new CommunicationUserIdentifier("targetUserId"),
                       new DtmfTone[] { DtmfTone.One, DtmfTone.Two, DtmfTone.Three, DtmfTone.Pound },
                       OperationContext
                );
            Assert.AreEqual(successCode, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, new SendDtmfCompletedEventData(CallConnectionId, ServerCallId, CorelationId, OperationContext, new ResultInformation()));

            SendDtmfEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(true, returnedResult.IsSuccess);
            Assert.NotNull(returnedResult.SuccessResult);
            Assert.IsNull(returnedResult.FailureResult);
            Assert.AreEqual(typeof(SendDtmfCompletedEventData), returnedResult.SuccessResult.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.SuccessResult.CallConnectionId);
            Assert.AreEqual(OperationContext, returnedResult.SuccessResult.OperationContext);
        }

        [Test]
        public async Task SendDtmfEventResultFailedTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, AddParticipantsPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var response = callConnection.GetCallMedia().SendDtmf(
                       new CommunicationUserIdentifier("targetUserId"),
                       new DtmfTone[] { DtmfTone.One, DtmfTone.Two, DtmfTone.Three, DtmfTone.Pound },
                       OperationContext
                );
            Assert.AreEqual(successCode, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, new SendDtmfFailedEventData(CallConnectionId, ServerCallId, CorelationId, OperationContext, new ResultInformation()));

            SendDtmfEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(false, returnedResult.IsSuccess);
            Assert.NotNull(returnedResult.FailureResult);
            Assert.IsNull(returnedResult.SuccessResult);
            Assert.AreEqual(typeof(SendDtmfFailedEventData), returnedResult.FailureResult.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.FailureResult.CallConnectionId);
            Assert.AreEqual(OperationContext, returnedResult.FailureResult.OperationContext);
        }
    }
}
