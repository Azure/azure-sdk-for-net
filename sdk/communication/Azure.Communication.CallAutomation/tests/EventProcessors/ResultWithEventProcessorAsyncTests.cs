﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.CallAutomation.Tests.Infrastructure;
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
            Assert.AreEqual(successCode, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, new CallConnected(null, CallConnectionId, ServerCallId, CorelationId));

            CreateCallEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(true, returnedResult.IsSuccess);
            Assert.NotNull(returnedResult.SuccessResult);
            Assert.AreEqual(typeof(CallConnected), returnedResult.SuccessResult.GetType());
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
                options: new CallAutomationClientOptions() { Source = new CommunicationUserIdentifier("12345") });
            CallAutomationEventProcessor handler = callAutomationClient.GetEventProcessor();

            var response = callAutomationClient.CreateCall(new CreateCallOptions(CreateMockInvite(), new Uri(CallBackUri)));
            Assert.AreEqual(successCode, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, new CallConnected("mismatchedOperationId", CallConnectionId, ServerCallId, CorelationId));

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
                options: new CallAutomationClientOptions() { Source = new CommunicationUserIdentifier("12345") });
            CallAutomationEventProcessor handler = callAutomationClient.GetEventProcessor();

            var response = callAutomationClient.AnswerCall("incomingCallContext", new Uri(CallBackUri));
            Assert.AreEqual(successCode, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, new CallConnected(null, CallConnectionId, ServerCallId, CorelationId));

            AnswerCallEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(true, returnedResult.IsSuccess);
            Assert.NotNull(returnedResult.SuccessResult);
            Assert.AreEqual(typeof(CallConnected), returnedResult.SuccessResult.GetType());
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
                options: new CallAutomationClientOptions() { Source = new CommunicationUserIdentifier("12345") });
            CallAutomationEventProcessor handler = callAutomationClient.GetEventProcessor();

            var response = callAutomationClient.AnswerCall("incomingCallContext", new Uri(CallBackUri));
            Assert.AreEqual(successCode, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, new CallConnected("mismatchedOperationId", CallConnectionId, ServerCallId, CorelationId));

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
            var response = callConnection.TransferCallToParticipant(new TransferToParticipantOptions(callInvite.Target as CommunicationUserIdentifier));
            Assert.AreEqual(successCode, response.GetRawResponse().Status);
            var transferee = new CommunicationIdentifierModel();
            transferee.CommunicationUser = new CommunicationUserIdentifierModel(TransfereeUser);
            transferee.RawId = TransfereeUser;

            var transferTarget = new CommunicationIdentifierModel();
            transferTarget.CommunicationUser = new CommunicationUserIdentifierModel(TargetUser);
            transferTarget.RawId = TargetUser;
            var internalEvent = new CallTransferAcceptedInternal(response.Value.OperationContext, null, transferTarget, transferee, CallConnectionId, ServerCallId, CorelationId);

            // Create and send event to event processor
            SendAndProcessEvent(handler, new CallTransferAccepted(internalEvent));

            TransferCallToParticipantEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(true, returnedResult.IsSuccess);
            Assert.NotNull(returnedResult.SuccessResult);
            Assert.IsNull(returnedResult.FailureResult);
            Assert.AreEqual(typeof(CallTransferAccepted), returnedResult.SuccessResult.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.SuccessResult.CallConnectionId);
            Assert.AreEqual(response.Value.OperationContext, returnedResult.SuccessResult.OperationContext);
            Assert.AreEqual(transferee.CommunicationUser.Id, returnedResult.SuccessResult.Transferee.RawId);
            Assert.AreEqual(transferTarget.CommunicationUser.Id, returnedResult.SuccessResult.TransferTarget.RawId);
        }

        [Test]
        public async Task TransferCallEventResultFailedTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, TransferCallOrRemoveParticipantsPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var callInvite = new CallInvite(new CommunicationUserIdentifier(TargetUser));
            var response = callConnection.TransferCallToParticipant(new TransferToParticipantOptions(callInvite.Target as CommunicationUserIdentifier));
            Assert.AreEqual(successCode, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, new CallTransferFailed(response.Value.OperationContext, null, CallConnectionId, ServerCallId, CorelationId));

            TransferCallToParticipantEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(false, returnedResult.IsSuccess);
            Assert.IsNull(returnedResult.SuccessResult);
            Assert.NotNull(returnedResult.FailureResult);
            Assert.AreEqual(typeof(CallTransferFailed), returnedResult.FailureResult.GetType());
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
            Assert.AreEqual(typeof(AddParticipantSucceeded), returnedResult.SuccessResult.GetType());
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
            Assert.AreEqual(typeof(AddParticipantFailed), returnedResult.FailureResult.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.FailureResult.CallConnectionId);
            Assert.AreEqual(response.Value.OperationContext, returnedResult.FailureResult.OperationContext);
        }

        [Test]
        public async Task PlayEventResultSuccessTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, AddParticipantsPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var response = callConnection.GetCallMedia().PlayToAll(new PlayToAllOptions(new FileSource(new Uri(CallBackUri))) { OperationContext = OperationContext });
            Assert.AreEqual(successCode, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, new PlayCompleted(new ResultInformation() { }, OperationContext, CallConnectionId, ServerCallId, CorelationId));

            PlayEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(true, returnedResult.IsSuccess);
            Assert.NotNull(returnedResult.SuccessResult);
            Assert.IsNull(returnedResult.FailureResult);
            Assert.AreEqual(typeof(PlayCompleted), returnedResult.SuccessResult.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.SuccessResult.CallConnectionId);
            Assert.AreEqual(OperationContext, returnedResult.SuccessResult.OperationContext);
        }

        [Test]
        public async Task PlayEventResultFailedTest()
        {
            int successCode = (int)HttpStatusCode.Accepted;

            var callConnection = CreateMockCallConnection(successCode, AddParticipantsPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;

            var response = callConnection.GetCallMedia().PlayToAll(new PlayToAllOptions(new FileSource(new Uri(CallBackUri))) { OperationContext = OperationContext });
            Assert.AreEqual(successCode, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, new PlayFailed(OperationContext, new ResultInformation() { }, CallConnectionId, ServerCallId, CorelationId));

            PlayEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(false, returnedResult.IsSuccess);
            Assert.IsNull(returnedResult.SuccessResult);
            Assert.NotNull(returnedResult.FailureResult);
            Assert.AreEqual(typeof(PlayFailed), returnedResult.FailureResult.GetType());
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
            SendAndProcessEvent(handler, new PlayCanceled(null, CallConnectionId, ServerCallId, CorelationId));

            CancelAllMediaOperationsEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(true, returnedResult.IsSuccess);
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
            SendAndProcessEvent(handler, new RecognizeCanceled(null, CallConnectionId, ServerCallId, CorelationId));

            CancelAllMediaOperationsEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(true, returnedResult.IsSuccess);
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
            SendAndProcessEvent(handler, new RecognizeCompleted(CallConnectionId, ServerCallId, CorelationId, OperationContext, new ResultInformation(), CallMediaRecognitionType.Dtmf, null));

            StartRecognizingEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(true, returnedResult.IsSuccess);
            Assert.NotNull(returnedResult.SuccessResult);
            Assert.IsNull(returnedResult.FailureResult);
            Assert.AreEqual(typeof(RecognizeCompleted), returnedResult.SuccessResult.GetType());
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
            SendAndProcessEvent(handler, new RecognizeFailed(OperationContext, new ResultInformation(), CallConnectionId, ServerCallId, CorelationId));

            StartRecognizingEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(false, returnedResult.IsSuccess);
            Assert.NotNull(returnedResult.FailureResult);
            Assert.IsNull(returnedResult.SuccessResult);
            Assert.AreEqual(typeof(RecognizeFailed), returnedResult.FailureResult.GetType());
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
            Assert.AreEqual(typeof(RemoveParticipantSucceeded), returnedResult.SuccessResult.GetType());
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
            Assert.AreEqual(typeof(RemoveParticipantFailed), returnedResult.FailureResult.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.FailureResult.CallConnectionId);
            Assert.AreEqual(response.Value.OperationContext, returnedResult.FailureResult.OperationContext);
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
            Assert.AreEqual(successCode, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, CallAutomationModelFactory.SendDtmfTonesCompleted(CallConnectionId, ServerCallId, CorelationId, OperationContext, new ResultInformation()));

            SendDtmfTonesEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(true, returnedResult.IsSuccess);
            Assert.NotNull(returnedResult.SuccessResult);
            Assert.IsNull(returnedResult.FailureResult);
            Assert.AreEqual(typeof(SendDtmfTonesCompleted), returnedResult.SuccessResult.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.SuccessResult.CallConnectionId);
            Assert.AreEqual(OperationContext, returnedResult.SuccessResult.OperationContext);
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
            Assert.AreEqual(successCode, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, CallAutomationModelFactory.SendDtmfTonesFailed(CallConnectionId, ServerCallId, CorelationId, OperationContext, new ResultInformation()));

            SendDtmfTonesEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(false, returnedResult.IsSuccess);
            Assert.NotNull(returnedResult.FailureResult);
            Assert.IsNull(returnedResult.SuccessResult);
            Assert.AreEqual(typeof(SendDtmfTonesFailed), returnedResult.FailureResult.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.FailureResult.CallConnectionId);
            Assert.AreEqual(OperationContext, returnedResult.FailureResult.OperationContext);
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
            Assert.AreEqual(successCode, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, new DialogStarted(CallConnectionId, ServerCallId, CorelationId, OperationContext, new ResultInformation(), "dialogId", DialogInputType.PowerVirtualAgents));

            DialogEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(true, returnedResult.IsSuccess);
            Assert.NotNull(returnedResult.DialogStartedSuccessEvent);
            Assert.IsNull(returnedResult.DialogCompletedSuccessResult);
            Assert.IsNull(returnedResult.DialogConsentSuccessEvent);
            Assert.IsNull(returnedResult.DialogHangupSuccessEvent);
            Assert.IsNull(returnedResult.DialogLanguageChangeEvent);
            Assert.IsNull(returnedResult.DialogSensitivityUpdateEvent);
            Assert.IsNull(returnedResult.DialogTransferSuccessEvent);
            Assert.IsNull(returnedResult.FailureResult);
            Assert.AreEqual(typeof(DialogStarted), returnedResult.DialogStartedSuccessEvent.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.DialogStartedSuccessEvent.CallConnectionId);
            Assert.AreEqual(OperationContext, returnedResult.DialogStartedSuccessEvent.OperationContext);
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
            Assert.AreEqual(successCode, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, new DialogFailed(CallConnectionId, ServerCallId, CorelationId, OperationContext, new ResultInformation(), "dialogId", DialogInputType.PowerVirtualAgents));

            DialogEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(false, returnedResult.IsSuccess);
            Assert.IsNull(returnedResult.DialogStartedSuccessEvent);
            Assert.IsNull(returnedResult.DialogCompletedSuccessResult);
            Assert.IsNull(returnedResult.DialogConsentSuccessEvent);
            Assert.IsNull(returnedResult.DialogHangupSuccessEvent);
            Assert.IsNull(returnedResult.DialogLanguageChangeEvent);
            Assert.IsNull(returnedResult.DialogSensitivityUpdateEvent);
            Assert.IsNull(returnedResult.DialogTransferSuccessEvent);
            Assert.NotNull(returnedResult.FailureResult);
            Assert.AreEqual(typeof(DialogFailed), returnedResult.FailureResult.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.FailureResult.CallConnectionId);
            Assert.AreEqual(OperationContext, returnedResult.FailureResult.OperationContext);
        }

        [Test]
        public async Task CancelAddParticipantSucceededEventResultFailedTest()
        {
            var invitationId = "invitationId";
            var callConnection = CreateMockCallConnection(202, CancelAddParticipantPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;
            var callInvite = CreateMockInvite();
            var response = callConnection.CancelAddParticipantOperation(invitationId);

            Assert.AreEqual(202, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, CallAutomationModelFactory.CancelAddParticipantFailed(
                CallConnectionId,
                ServerCallId,
                CorelationId,
                invitationId,
                new ResultInformation(400, 4000, "resultInformation"),
                OperationContext));

            CancelAddParticipantEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(false, returnedResult.IsSuccess);
            Assert.NotNull(returnedResult.FailureResult);
            Assert.IsNull(returnedResult.SuccessResult);
            Assert.AreEqual(typeof(CancelAddParticipantFailed), returnedResult.FailureResult.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.FailureResult.CallConnectionId);
            Assert.AreEqual(invitationId, returnedResult.FailureResult.InvitationId);
        }

        [Test]
        public async Task CancelAddParticipantSucceededEventResultSuccessTest()
        {
            var invitationId = "invitationId";
            var callConnection = CreateMockCallConnection(202, CancelAddParticipantPayload);
            CallAutomationEventProcessor handler = callConnection.EventProcessor;
            var callInvite = CreateMockInvite();
            var response = callConnection.CancelAddParticipantOperation(invitationId);

            Assert.AreEqual(202, response.GetRawResponse().Status);

            // Create and send event to event processor
            SendAndProcessEvent(handler, CallAutomationModelFactory.CancelAddParticipantSucceeded(
                CallConnectionId,
                ServerCallId,
                CorelationId,
                invitationId,
                callInvite.Target,
                OperationContext));

            CancelAddParticipantEventResult returnedResult = await response.Value.WaitForEventProcessorAsync();

            // Assert
            Assert.NotNull(returnedResult);
            Assert.AreEqual(true, returnedResult.IsSuccess);
            Assert.NotNull(returnedResult.SuccessResult);
            Assert.IsNull(returnedResult.FailureResult);
            Assert.AreEqual(typeof(CancelAddParticipantSucceeded), returnedResult.SuccessResult.GetType());
            Assert.AreEqual(CallConnectionId, returnedResult.SuccessResult.CallConnectionId);
            Assert.AreEqual(invitationId, returnedResult.SuccessResult.InvitationId);
        }
    }
}
