// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System;
using System.CodeDom;
using System.Drawing;

namespace Azure.Communication.CallingServer.Tests
{
    public class CallAutomationClientTests : CallAutomationTestBase
    {
        private const string CreateOrAnswerCallOrGetCallConnectionPayload ="{" +
                                                "\"callConnectionId\": \"af50dd7b-37e7-4cdb-a176-a7c37b71098a\"," +
                                                "\"serverCallId\": \"bf50dd7b-37e7-4cdb-a176-a7c37b71098a\"," +
                                                "\"targets\": [" +
                                                   "{" +
                                                       "\"rawId\":\"rawId2\"," +
                                                       "\"kind\":\"communicationUser\"," +
                                                       "\"communicationUser\":{\"id\":\"a795d01f-f9ad-45e6-99c4-14bf8449ad4b\"}" +
                                                    "}" +
                                                "]," +
                                                "\"source\": {" +
                                                     "\"identifier\":{" +
                                                          "\"rawId\":\"rawId1\"," +
                                                          "\"kind\":\"communicationUser\"," +
                                                          "\"communicationUser\":{\"id\":\"0000000d-5a5f-2db9-ccd7-44482200049a\"}" +
                                                                    "}" +
                                                            "}," +
                                                "\"callConnectionState\": \"connecting\"," +
                                                "\"subject\": \"dummySubject\"," +
                                                "\"callbackUri\": \"https://bot.contoso.com/callback\"" +
                                                "}";

        private const string serverCallId = "bf50dd7b-37e7-4cdb-a176-a7c37b71098a";
        private const string callConnectionId = "af50dd7b-37e7-4cdb-a176-a7c37b71098a";
        [TestCaseSource(nameof(TestData_AnswerCall))]
        public async Task AnswerCallAsync_200OK(string incomingCallContext, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200, CreateOrAnswerCallOrGetCallConnectionPayload);

            var response = await callAutomationClient.AnswerCallAsync(incomingCallContext, callbackUri).ConfigureAwait(false);
            Assert.NotNull(response);
            var callConnectionProperties = response.Value.CallConnectionProperties;
            Assert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            Assert.AreEqual(CallConnectionState.Connecting, callConnectionProperties.CallConnectionState);
            Assert.AreEqual(serverCallId, callConnectionProperties.ServerCallId);
            Assert.AreEqual(callConnectionId, response.Value.CallConnection.CallConnectionId);
        }

        [TestCaseSource(nameof(TestData_AnswerCall))]
        public void AnswerCall_200OK(string incomingCallContext, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(200, CreateOrAnswerCallOrGetCallConnectionPayload);

            var response = callAutomationClient.AnswerCall(incomingCallContext, callbackUri);
            Assert.NotNull(response);
            var callConnectionProperties = response.Value.CallConnectionProperties;
            Assert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            Assert.AreEqual(CallConnectionState.Connecting, callConnectionProperties.CallConnectionState);
            Assert.AreEqual(serverCallId, callConnectionProperties.ServerCallId);
            Assert.AreEqual(callConnectionId, response.Value.CallConnection.CallConnectionId);
        }

        [TestCaseSource(nameof(TestData_AnswerCall))]
        public void AnswerCallAsync_401AuthFailed(string incomingCallContext, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(401);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callAutomationClient.AnswerCallAsync(incomingCallContext, callbackUri).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 401);
        }

        [TestCaseSource(nameof(TestData_AnswerCall))]
        public void AnswerCall_401AuthFailed(string incomingCallContext, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(401);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callAutomationClient.AnswerCall(incomingCallContext, callbackUri));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 401);
        }

        [TestCaseSource(nameof(TestData_RedirectCall))]
        public async Task RedirectCallAsync_204NoContent(string incomingCallContext, CommunicationIdentifier target)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(204);

            var response = await callAutomationClient.RedirectCallAsync(incomingCallContext, target).ConfigureAwait(false);
            Assert.NotNull(response);
            Assert.AreEqual((int)HttpStatusCode.NoContent, response.Status);
        }

        [TestCaseSource(nameof(TestData_RedirectCall))]
        public void RedirectCall_204NoContent(string incomingCallContext, CommunicationIdentifier target)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(204);

            var response = callAutomationClient.RedirectCall(incomingCallContext, target);
            Assert.NotNull(response);
            Assert.AreEqual((int)HttpStatusCode.NoContent, response.Status);
        }

        [TestCaseSource(nameof(TestData_RedirectCall))]
        public void RedirectCallAsync_404NotFound(string incomingCallContext, CommunicationIdentifier target)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async() => await callAutomationClient.RedirectCallAsync(incomingCallContext, target).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_RedirectCall))]
        public void RedirectCall_404NotFound(string incomingCallContext, CommunicationIdentifier target)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callAutomationClient.RedirectCall(incomingCallContext, target));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_RejectCall))]
        public async Task RejectCallAsync_204NoContent(string incomingCallContext, CallRejectReason reason)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(204);

            var response = await callAutomationClient.RejectCallAsync(incomingCallContext, reason).ConfigureAwait(false);
            Assert.NotNull(response);
            Assert.AreEqual((int)HttpStatusCode.NoContent, response.Status);
        }

        [TestCaseSource(nameof(TestData_RejectCall))]
        public void RejectCall_204NoContent(string incomingCallContext, CallRejectReason reason)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(204);

            var response = callAutomationClient.RejectCall(incomingCallContext, reason);
            Assert.NotNull(response);
            Assert.AreEqual((int)HttpStatusCode.NoContent, response.Status);
        }

        [TestCaseSource(nameof(TestData_RejectCall))]
        public void RejectCallAsync_404NotFound(string incomingCallContext, CallRejectReason reason)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async() => await callAutomationClient.RejectCallAsync(incomingCallContext, reason).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_RejectCall))]
        public void RejectCall_404NotFound(string incomingCallContext, CallRejectReason reason)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callAutomationClient.RejectCall(incomingCallContext, reason));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        public async Task CreateCallAsync_201Created(CallSource source, CommunicationIdentifier[] targets, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(201, CreateOrAnswerCallOrGetCallConnectionPayload);

            var response = await callAutomationClient.CreateCallAsync(source, targets, callbackUri).ConfigureAwait(false);
            CreateCallResult result = (CreateCallResult)response;
            Assert.NotNull(result);
            Assert.AreEqual((int)HttpStatusCode.Created, response.GetRawResponse().Status);
            Assert.AreEqual(CallConnectionState.Connecting, result.CallConnectionProperties.CallConnectionState);
            Assert.AreEqual(serverCallId, result.CallConnectionProperties.ServerCallId);
            Assert.AreEqual(callConnectionId, result.CallConnection.CallConnectionId);
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        public void CreateCall_201Created(CallSource source, CommunicationIdentifier[] targets, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(201, CreateOrAnswerCallOrGetCallConnectionPayload);

            var response = callAutomationClient.CreateCall(source, targets, callbackUri);
            CreateCallResult result = (CreateCallResult)response;
            Assert.NotNull(result);
            Assert.AreEqual((int)HttpStatusCode.Created, response.GetRawResponse().Status);
            Assert.AreEqual(CallConnectionState.Connecting, result.CallConnectionProperties.CallConnectionState);
            Assert.AreEqual(serverCallId, result.CallConnectionProperties.ServerCallId);
            Assert.AreEqual(callConnectionId, result.CallConnection.CallConnectionId);
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        public void CreateCallAsync_404NotFound(CallSource source, CommunicationIdentifier[] targets, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callAutomationClient.CreateCallAsync(source, targets, callbackUri).ConfigureAwait(false));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CreateCall))]
        public void CreateCall_404NotFound(CallSource source, CommunicationIdentifier[] targets, Uri callbackUri)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callAutomationClient.CreateCall(source, targets, callbackUri));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_GetCallConnection))]
        public void GetCallConnection(string callConnectionId)
        {
            var response = new CallAutomationClient(connectionString).GetCallConnection(callConnectionId);
            CallConnection result = (CallConnection)response;
            Assert.NotNull(result);
            Assert.AreEqual(callConnectionId, result.CallConnectionId);
        }

        [Test]
        public void GetCallRecording()
        {
            var response = new CallAutomationClient(connectionString).GetCallRecording();
            Assert.NotNull(response);
        }

        // exceptions
        private static IEnumerable<object?[]> TestData_AnswerCall()
        {
            return new[]
            {
                new object?[]
                {
                    "dummyIncomingCallContext",
                    new Uri("https://bot.contoso.com/callback")
                },
            };
        }
        private static IEnumerable<object?[]> TestData_RedirectCall()
        {
            return new[]
            {
                new object?[]
                {
                    "dummyIncomingCallContext",
                    new CommunicationUserIdentifier("12345")
                },
            };
        }

        private static IEnumerable<object?[]> TestData_RejectCall()
        {
            return new[]
            {
                new object?[]
                {
                    "dummyIncomingCallContext",
                    CallRejectReason.Busy
                },
            };
        }
        private static IEnumerable<object?[]> TestData_CreateCall()
        {
            return new[]
            {
                new object?[]
                {
                    new CallSource(new CommunicationUserIdentifier("56789")),
                    new CommunicationIdentifier[] {new CommunicationUserIdentifier("12345") },
                    new Uri("https://bot.contoso.com/callback")
                },
            };
        }

        private static IEnumerable<object?[]> TestData_GetCallConnection()
        {
            return new[]
            {
                new object?[]
                {
                    "12345"
                },
            };
        }
    }
}
