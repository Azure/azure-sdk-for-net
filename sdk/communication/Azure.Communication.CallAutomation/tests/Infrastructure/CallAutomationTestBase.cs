// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using Microsoft.Azure.Amqp.Framing;
using NUnit.Framework;

namespace Azure.Communication.CallAutomation.Tests.Infrastructure
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
                                        "\"sourceDisplayName\": \"displayName\"," +
                                        "\"source\":{{" +
                                                  "\"rawId\":\"sourceId\"," +
                                                  "\"kind\":\"communicationUser\"," +
                                                  "\"communicationUser\":{{\"id\":\"sourceId\"}}" +
                                                            "}}," +
                                        "\"callConnectionState\": \"connecting\"," +
                                        "\"subject\": \"dummySubject\"," +
                                        "\"callbackUri\": \"https://bot.contoso.com/callback\"," +
                                        "\"mediaStreamingSubscription\": {0}," +
                                        "\"transcriptionSubscription\": {1}" +
                                        "}}";
        protected const string DummyConnectPayload = "{" +
                                        "\"callConnectionId\": \"someCallConnectionId\"," +
                                        "\"serverCallId\": \"someServerCallId\"," +
                                        "\"targets\": []," +
                                        "\"callConnectionState\": \"connecting\"," +
                                        "\"callbackUri\": \"https://bot.contoso.com/callback\"" +
                                        "}";
        protected const string DummyOPSPayload = "{{" +
                                        "\"callConnectionId\": \"someCallConnectionId\"," +
                                        "\"serverCallId\": \"someServerCallId\"," +
                                        "\"targets\": [" +
                                           "{{" +
                                               "\"rawId\":\"targetId\"," +
                                               "\"kind\":\"communicationUser\"," +
                                               "\"communicationUser\":{{\"id\":\"targetId\"}}" +
                                            "}}" +
                                        "]," +
                                        "\"sourceDisplayName\": \"displayName\"," +
                                        "\"source\":{{" +
                                                  "\"rawId\":\"sourceId\"," +
                                                  "\"kind\":\"microsoftTeamsApp\"," +
                                                  "\"microsoftTeamsApp\":{{\"appId\":\"sourceId\"," +
                                                                            "\"cloud\": \"public\"}}" +
                                                  "}}," +
                                        "\"callConnectionState\": \"connecting\"," +
                                        "\"subject\": \"dummySubject\"," +
                                        "\"callbackUri\": \"https://bot.contoso.com/callback\"," +
                                        "\"mediaSubscriptionId\": {0}," +
                                        "\"dataSubscriptionId\": {1}" +
                                        "}}";
        protected const string SourceId = "sourceId";
        protected const string TargetId = "targetId";
        protected const string ServerCallId = "someServerCallId";
        protected const string CallConnectionId = "someCallConnectionId";
        protected const string Subject = "dummySubject";
        protected const string CallBackUri = "https://bot.contoso.com/callback";
        protected const string DisplayName = "displayName";
        protected static readonly CallLocator _serverCallLocator = new ServerCallLocator(ServerCallId);

        private const string NoneMediaStreamingSubscription = "null";
        private const string MediaSubscriptionId = "\"mediaSubscriptionId\"";
        private const string MediaStreamingSubscription = "{" +
                                        " \"id\": \"22c3a25a-aed5-47df-9ef9-5ba5c7b6d08e\"," +
                                        "\"state\": \"disabled\",\"subscribedContentTypes\": [" +
                                        "\"audio\"] }";
        private const string TranscriptionSubscription = "{" +
                                        "\"id\": \"81c66a1b-12eb-4d89-ab99-c9f0de59e893\"," +
                                        "\"state\": \"inactive\"," +
                                        "\"subscribedResultTypes\": [\"final\"]}";
        private const string NoneTranscriptionSubscription = "null";
        private const string DataSubscriptionId = "\"dataSubscriptionId\"";
        protected string CreateOrAnswerCallOrGetCallConnectionPayload = string.Format(DummyPayload, NoneMediaStreamingSubscription, NoneTranscriptionSubscription);
        protected string CreateOrAnswerCallOrGetCallConnectionWithMediaSubscriptionAndTranscriptionPayload = string.Format(DummyPayload, MediaStreamingSubscription, TranscriptionSubscription);
        protected string CreateOrAnswerCallOrGetCallConnectionPayloadWithTeamsAppSource = string.Format(DummyOPSPayload, NoneMediaStreamingSubscription, NoneTranscriptionSubscription);

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

            var callAutomationClientOptions = new CallAutomationClientOptions()
            {
                Source = new CommunicationUserIdentifier(SourceId),
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

        protected void verifyCallConnectionProperties(CallConnectionProperties callConnectionProperties, bool isConnectApi = false)
        {
            Assert.AreEqual(CallConnectionId, callConnectionProperties.CallConnectionId);
            Assert.AreEqual(ServerCallId, callConnectionProperties.ServerCallId);
            if (!isConnectApi)
            {
                var sourceUser = (CommunicationUserIdentifier)callConnectionProperties.Source;
                Assert.AreEqual(SourceId, sourceUser.Id);
                Assert.AreEqual(callConnectionProperties.Targets.Count, 1);
                var targetUser = (CommunicationUserIdentifier)callConnectionProperties.Targets[0];
                Assert.AreEqual(TargetId, targetUser.Id);
                Assert.AreEqual(DisplayName, callConnectionProperties.SourceDisplayName);
            }

            Assert.AreEqual(CallConnectionState.Connecting, callConnectionProperties.CallConnectionState);
            Assert.AreEqual(CallBackUri, callConnectionProperties.CallbackUri.ToString());
        }

        protected void verifyOPSCallConnectionProperties(CallConnectionProperties callConnectionProperties)
        {
            Assert.AreEqual(CallConnectionId, callConnectionProperties.CallConnectionId);
            Assert.AreEqual(ServerCallId, callConnectionProperties.ServerCallId);
            var teamsAppSourceUser = (MicrosoftTeamsAppIdentifier)callConnectionProperties.Source;
            Assert.AreEqual(SourceId, teamsAppSourceUser.AppId);
            Assert.AreEqual(callConnectionProperties.Targets.Count, 1);
            var targetUser = (CommunicationUserIdentifier)callConnectionProperties.Targets[0];
            Assert.AreEqual(TargetId, targetUser.Id);
            Assert.AreEqual(CallConnectionState.Connecting, callConnectionProperties.CallConnectionState);
            Assert.AreEqual(CallBackUri, callConnectionProperties.CallbackUri.ToString());
            Assert.AreEqual(DisplayName, callConnectionProperties.SourceDisplayName);
        }
    }
}
