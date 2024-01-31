// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.TestFramework;
using Microsoft.Azure.Amqp.Framing;
using Microsoft.Extensions.Options;

namespace Azure.Communication.CallAutomation.Tests.Infrastructure
{
    public abstract class CallAutomationEventProcessorTestBase
    {
        protected const string ConnectionString = "endpoint=https://contoso.azure.com/;accesskey=ZHVtbXlhY2Nlc3NrZXk=";
        protected const string SourceId = "sourceId";
        protected const string TargetId = "targetId";
        protected const string ServerCallId = "someServerCallId";
        protected const string CallConnectionId = "someCallConnectionId";
        protected const string Subject = "dummySubject";
        protected const string CallBackUri = "https://bot.contoso.com/callback";
        protected const string OperationContext = "someOperationContext";
        protected const string CorelationId = "someCorelationId";
        protected const string SourceUser = "SOURCE_USER_ID";
        protected const string TargetUser = "TARGET_USER_ID";
        protected const string TransfereeUser = "TRANSFEREE_USER_ID";
        protected const int defaultTestTimeout = 3;
        private const string NoneMediaSubscriptionId = "null";
        private const string MediaSubscriptionId = "\"mediaSubscriptionId\"";
        protected string CreateOrAnswerCallOrGetCallConnectionPayload = string.Format(DummyPayload, NoneMediaSubscriptionId);
        protected string CreateOrAnswerCallOrGetCallConnectionWithMediaSubscriptionPayload = string.Format(DummyPayload, MediaSubscriptionId);

        protected const string DummyPayload = "{{\"callConnectionId\": \"someCallConnectionId\",\"serverCallId\": \"someServerCallId\",\"targets\": [{{\"rawId\":\"targetId\",\"kind\":\"communicationUser\",\"communicationUser\":{{\"id\":\"targetId\"}}}}],\"source\":{{\"rawId\":\"sourceId\",\"kind\":\"communicationUser\",\"communicationUser\":{{\"id\":\"sourceId\"}}}},\"callConnectionState\": \"connecting\",\"subject\": \"dummySubject\",\"callbackUri\": \"https://bot.contoso.com/callback\",\"mediaSubscriptionId\": {0}}}";

        protected const string TransferCallOrRemoveParticipantsPayload = "{\"operationContext\": \"someOperationContext\"}";

        protected const string AddParticipantsPayload = "{\"participant\":{\"identifier\":{\"rawId\":\"participantId1\",\"kind\":\"communicationUser\",\"communicationUser\":{\"id\":\"participantId1\"}},\"isMuted\":false},\"operationContext\":\"someOperationContext\"}";

        protected const string GetParticipantPayload = "{\"identifier\":{\"rawId\":\"participantId1\",\"kind\":\"communicationUser\",\"communicationUser\":{\"id\":\"participantId1\"}},\"isMuted\":false}";

        protected const string GetParticipantsPayload = "{\"values\":[{\"identifier\":{\"rawId\":\"participantId1\",\"kind\":\"communicationUser\",\"communicationUser\":{\"id\":\"participantId1\"}},\"isMuted\":false},{\"identifier\":{\"rawId\":\"participantId2\",\"kind\":\"phoneNumber\",\"phoneNumber\":{\"value\":\"+11234567\"}},\"isMuted\":true}]}";

        protected const string RemoveParticipantPayload = AddParticipantsPayload;

        protected const string DialogPayload = "{\"dialogId\":\"dialogId\",\"dialogInputType\":\"powerVirtualAgent\"}";

        protected const string CancelAddParticipantPayload = "{" +
                                    "\"operationContext\": \"someOperationContext\"," +
                                    "\"invitationId\": \"invitationId\"" +
                                    "}";

        internal CallAutomationClient CreateMockCallAutomationClient(int responseCode, object? responseContent = null, HttpHeader[]? httpHeaders = null, CallAutomationClientOptions ? options = default)
        {
            var mockResponse = new MockResponse(responseCode);

            if (responseContent != null)
            {
                if (responseContent is string responseContentString)
                {
                    mockResponse.SetContent(responseContentString);
                }
                else if (responseContent is byte[] responseContentObjectArr)
                {
                    mockResponse.SetContent(responseContentObjectArr);
                }
            }

            if (httpHeaders != null)
            {
                for (int i = 0; i < httpHeaders.Length; i++)
                {
                    mockResponse.AddHeader(httpHeaders[i]);
                }
            }

            if (options == default)
            {
                options = new CallAutomationClientOptions();
            }
            options.Transport = new MockTransport(mockResponse);

            return new CallAutomationClient(ConnectionString, options);
        }

        protected CallConnection CreateMoakCallConnection(string? callConnectionId = default)
        {
            CallConnection callconn = new CallConnection(callConnectionId == default ? CallConnectionId : callConnectionId, null, null, null, null, null);

            return callconn;
        }

        protected IEnumerable<CommunicationIdentifier> CreateMoakTargets(IEnumerable<CommunicationIdentifier>? targets = default)
        {
            var targetsOutput = targets == default ? new List<CommunicationIdentifier> { new CommunicationUserIdentifier(TargetUser) } : targets;

            return targetsOutput;
        }

        protected CallInvite CreateMockInvite(CallInvite? target = default)
        {
            return target == default? new CallInvite(new CommunicationUserIdentifier(TargetUser)) : target;
        }

        protected CallConnection CreateMockCallConnection(int responseCode, string? responseContent = default, string? callConnectionId = default)
        {
            return CreateMockCallAutomationClient(responseCode, responseContent).GetCallConnection(callConnectionId == default ? CallConnectionId : callConnectionId);
        }

        protected void SendAndProcessEvent(
            CallAutomationEventProcessor eventProcessor,
            CallAutomationEventBase eventToBeSent)
        {
            eventProcessor.ProcessEvents(new List<CallAutomationEventBase>() { eventToBeSent });
        }
    }
}
