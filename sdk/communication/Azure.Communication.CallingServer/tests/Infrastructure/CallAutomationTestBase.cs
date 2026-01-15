// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.CallingServer
{
    public class CallAutomationTestBase
    {
        protected const string ConnectionString = "endpoint=https://contoso.azure.com/;accesskey=ZHVtbXlhY2Nlc3NrZXk=";
        protected const string DummyPayload = "{{" +
                                        "\"callConnectionId\": \"someCallConnectionId\"," +
                                        "\"serverCallId\": \"someServerCallId\"," +
                                        "\"targets\": [" +
                                           "{{" +
                                               "\"rawId\":\"targetId\"," +
                                               "\"kind\":\"communicationUser\"," +
                                               "\"communicationUser\":{{\"id\":\"targetId\"}}" +
                                            "}}" +
                                        "]," +
                                        "\"source\": {{" +
                                             "\"identifier\":{{" +
                                                  "\"rawId\":\"sourceId\"," +
                                                  "\"kind\":\"communicationUser\"," +
                                                  "\"communicationUser\":{{\"id\":\"sourceId\"}}" +
                                                            "}}" +
                                                    "}}," +
                                        "\"callConnectionState\": \"connecting\"," +
                                        "\"subject\": \"dummySubject\"," +
                                        "\"callbackUri\": \"https://bot.contoso.com/callback\"," +
                                        "\"mediaSubscriptionId\": {0}" +
                                        "}}";
        protected const string SourceId = "sourceId";
        protected const string TargetId = "targetId";
        protected const string ServerCallId = "someServerCallId";
        protected const string CallConnectionId = "someCallConnectionId";
        protected const string Subject = "dummySubject";
        protected const string CallBackUri = "https://bot.contoso.com/callback";

        private const string NoneMediaSubscriptionId = "null";
        private const string MediaSubscriptionId = "\"mediaSubscriptionId\"";
        protected string CreateOrAnswerCallOrGetCallConnectionPayload = string.Format(DummyPayload, NoneMediaSubscriptionId);
        protected string CreateOrAnswerCallOrGetCallConnectionWithMediaSubscriptionPayload = string.Format(DummyPayload, MediaSubscriptionId);

        internal CallAutomationClient CreateMockCallAutomationClient(int responseCode, object? responseContent = null, HttpHeader[]? httpHeaders = null)
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

            var callAutomationClientOptions = new CallAutomationClientOptions
            {
                Transport = new MockTransport(mockResponse)
            };

            return new CallAutomationClient(ConnectionString, callAutomationClientOptions);
        }

        internal CallAutomationClient CreateMockCallAutomationClient(params MockResponse[] mockResponses)
        {
            var callAutomationClientOptions = new CallAutomationClientOptions
            {
                Transport = new MockTransport(mockResponses)
            };

            return new CallAutomationClient(ConnectionString, callAutomationClientOptions);
        }

        protected void verifyCallConnectionProperties(CallConnectionProperties callConnectionProperties)
        {
            Assert.That(callConnectionProperties.CallConnectionId, Is.EqualTo(CallConnectionId));
            Assert.That(callConnectionProperties.ServerCallId, Is.EqualTo(ServerCallId));
            var sourceUser = (CommunicationUserIdentifier)callConnectionProperties.CallSource.Identifier;
            Assert.That(sourceUser.Id, Is.EqualTo(SourceId));
            Assert.That(callConnectionProperties.Targets.Count, Is.EqualTo(1));
            var targetUser = (CommunicationUserIdentifier)callConnectionProperties.Targets[0];
            Assert.That(targetUser.Id, Is.EqualTo(TargetId));
            Assert.That(callConnectionProperties.CallConnectionState, Is.EqualTo(CallConnectionState.Connecting));
            Assert.That(callConnectionProperties.Subject, Is.EqualTo(Subject));
            Assert.That(callConnectionProperties.CallbackEndpoint.ToString(), Is.EqualTo(CallBackUri));
        }
    }
}
