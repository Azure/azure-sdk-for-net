// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Communication.CallAutomation.Tests.Infrastructure;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Azure.Communication.CallAutomation.Tests.CallConnections
{
    public class CallConnectionTests : CallAutomationTestBase
    {
        private const string OperationContextPayload = "{" +
                                        "\"operationContext\": \"someOperationContext\"" +
                                        "}";

        private const string AddParticipantPayload = "{\"participant\":{\"identifier\":{\"rawId\":\"participantId1\",\"kind\":\"communicationUser\",\"communicationUser\":{\"id\":\"participantId1\"}},\"isMuted\":false},\"operationContext\":\"someOperationContext\"}";

        private const string GetParticipantPayload = "{" +
            "\"identifier\":{" +
            "\"rawId\":\"participantId1\",\"kind\":\"communicationUser\",\"communicationUser\":{\"id\":\"participantId1\"}" +
            "}," +
            "\"isMuted\":false" +
            "}";

        private const string GetParticipantsPayload = "{" +
            "\"value\":[" +
               "{\"identifier\":{\"rawId\":\"participantId1\",\"kind\":\"communicationUser\",\"communicationUser\":{\"id\":\"participantId1\"}},\"isMuted\":false}," +
               "{\"identifier\":{\"rawId\":\"participantId2\",\"kind\":\"phoneNumber\",\"phoneNumber\":{\"value\":\"+11234567\"}},\"isMuted\":true}" +
               "]" +
            "}";

        private const string CancelAddParticipantPayload = "{" +
                                    "\"operationContext\": \"someOperationContext\"," +
                                    "\"invitationId\": \"invitationId\"" +
                                    "}";

        private const string OperationContext = "someOperationContext";
        private const string ParticipantUserId = "participantId1";
        private const string PhoneNumber = "+11234567";

        [Test]
        public async Task GetCallConnectionPropertiesAsync_200OK()
        {
            var callConnection = CreateMockCallConnection(200, CreateOrAnswerCallOrGetCallConnectionPayload);

            var response = await callConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);

            ClassicAssert.NotNull(response);
            ClassicAssert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            verifyCallConnectionProperties(response);
        }

        [Test]
        public void GetCallConnectionProperties_200OK()
        {
            var callConnection = CreateMockCallConnection(200, CreateOrAnswerCallOrGetCallConnectionPayload);

            var response = callConnection.GetCallConnectionProperties();

            ClassicAssert.NotNull(response);
            ClassicAssert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            verifyCallConnectionProperties(response);
        }
        [Test]
        public void GetCallConnectionPropertiesAsync_404NotFound()
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = ClassicAssert.ThrowsAsync<RequestFailedException>(async () => await callConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false));
            ClassicAssert.NotNull(ex);
            ClassicAssert.AreEqual(ex?.Status, 404);
        }

        [Test]
        public void GetCallConnectionProperties_404NotFound()
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = ClassicAssert.Throws<RequestFailedException>(() => callConnection.GetCallConnectionProperties());
            ClassicAssert.NotNull(ex);
            ClassicAssert.AreEqual(ex?.Status, 404);
        }

        [Test]
        public async Task HangupCallAsync_204NoContent()
        {
            var callConnection = CreateMockCallConnection(204);

            var response = await callConnection.HangUpAsync(false).ConfigureAwait(false);
            ClassicAssert.AreEqual((int)HttpStatusCode.NoContent, response.Status);
        }

        [Test]
        public void HangupCall_204NoContent()
        {
            var callConnection = CreateMockCallConnection(204);

            var response = callConnection.HangUp(false);
            ClassicAssert.AreEqual((int)HttpStatusCode.NoContent, response.Status);
        }

        [Test]
        public void HangUpCallAsync_404NotFound()
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = ClassicAssert.ThrowsAsync<RequestFailedException>(async () => await callConnection.HangUpAsync(false).ConfigureAwait(false));
            ClassicAssert.NotNull(ex);
            ClassicAssert.AreEqual(ex?.Status, 404);
        }

        [Test]
        public void HangUpCall_404NotFound()
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = ClassicAssert.Throws<RequestFailedException>(() => callConnection.HangUp(false));
            ClassicAssert.NotNull(ex);
            ClassicAssert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        public async Task TransferCallToParticipantAsync_simpleMethod_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = await callConnection.TransferCallToParticipantAsync(callInvite.Target).ConfigureAwait(false);
            ClassicAssert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyOperationContext(response);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant_PhoneNumberIdentifier))]
        public async Task TransferCallToParticipantAsync_simpleMethod_PhoneNumberIdentifier_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);
            var response = await callConnection.TransferCallToParticipantAsync(callInvite.Target).ConfigureAwait(false);
            ClassicAssert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyOperationContext(response);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant_PhoneNumberIdentifier_MS))]
        public async Task TransferCallToParticipantAsync_simpleMethod_PhoneNumberIdentifier_MSAsTarget_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);
            var response = await callConnection.TransferCallToParticipantAsync(callInvite.Target).ConfigureAwait(false);
            ClassicAssert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyOperationContext(response);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        public async Task TransferCallToParticipantAsync_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = await callConnection.TransferCallToParticipantAsync(new TransferToParticipantOptions(callInvite.Target as CommunicationUserIdentifier)).ConfigureAwait(false);
            ClassicAssert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyOperationContext(response);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        public async Task TransferCallToParticipantAsyncWithTransferee_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);
            var options = new TransferToParticipantOptions(callInvite.Target as CommunicationUserIdentifier);
            options.Transferee = new CommunicationUserIdentifier("transfereeid");

            var response = await callConnection.TransferCallToParticipantAsync(options).ConfigureAwait(false);
            ClassicAssert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyOperationContext(response);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        public void TransferCallToParticipant_simpleMethod_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = callConnection.TransferCallToParticipant(callInvite.Target);
            ClassicAssert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyOperationContext(response);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        public void TransferCallToParticipant_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = callConnection.TransferCallToParticipant(new TransferToParticipantOptions(callInvite.Target as CommunicationUserIdentifier));
            ClassicAssert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyOperationContext(response);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        public void TransferCallToParticipantWithTransferee_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);
            var options = new TransferToParticipantOptions(callInvite.Target as CommunicationUserIdentifier);
            options.Transferee = new CommunicationUserIdentifier("transfereeid");

            var response = callConnection.TransferCallToParticipant(options);
            ClassicAssert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyOperationContext(response);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        public void TransferCallToParticipantAsync_404NotFound(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = ClassicAssert.ThrowsAsync<RequestFailedException>(async () => await callConnection.TransferCallToParticipantAsync(new TransferToParticipantOptions(callInvite.Target as CommunicationUserIdentifier)).ConfigureAwait(false));
            ClassicAssert.NotNull(ex);
            ClassicAssert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        public void TransferCallToParticipant_404NotFound(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = ClassicAssert.Throws<RequestFailedException>(() => callConnection.TransferCallToParticipant(new TransferToParticipantOptions(callInvite.Target as CommunicationUserIdentifier)));
            ClassicAssert.NotNull(ex);
            ClassicAssert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipant))]
        public async Task AddParticipantsAsync_202Accepted(CommunicationIdentifier participantToAdd)
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantPayload);
            var callInvite = new CallInvite((CommunicationUserIdentifier)participantToAdd);

            var response = await callConnection.AddParticipantAsync(new AddParticipantOptions(callInvite)).ConfigureAwait(false);
            ClassicAssert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyAddParticipantsResult(response);
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipant))]
        public void AddParticipants_202Accepted(CommunicationIdentifier participantToAdd)
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantPayload);
            var callInvite = new CallInvite((CommunicationUserIdentifier)participantToAdd);

            var response = callConnection.AddParticipant(new AddParticipantOptions(callInvite));
            ClassicAssert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyAddParticipantsResult(response);
        }

        [TestCaseSource(nameof(TestData_AddParticipant_MicrosoftTeamsApp))]
        public async Task AddParticipantAsync_MicrosoftTeamsAppIdentifier_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantPayload);

            var response = await callConnection.AddParticipantAsync(new AddParticipantOptions(callInvite)).ConfigureAwait(false);
            ClassicAssert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyAddParticipantsResult(response);

            // Verify the target is correctly typed as MicrosoftTeamsAppIdentifier
            ClassicAssert.IsInstanceOf<MicrosoftTeamsAppIdentifier>(callInvite.Target);
            var teamsApp = callInvite.Target as MicrosoftTeamsAppIdentifier;
            ClassicAssert.IsNotNull(teamsApp);
            ClassicAssert.AreEqual("testAppId", teamsApp!.AppId);
        }

        [TestCaseSource(nameof(TestData_AddParticipant_MicrosoftTeamsApp))]
        public void AddParticipant_MicrosoftTeamsAppIdentifier_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantPayload);

            var response = callConnection.AddParticipant(new AddParticipantOptions(callInvite));
            ClassicAssert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyAddParticipantsResult(response);

            // Verify the target is correctly typed as MicrosoftTeamsAppIdentifier
            ClassicAssert.IsInstanceOf<MicrosoftTeamsAppIdentifier>(callInvite.Target);
            var teamsApp = callInvite.Target as MicrosoftTeamsAppIdentifier;
            ClassicAssert.IsNotNull(teamsApp);
            ClassicAssert.AreEqual("testAppId", teamsApp!.AppId);
        }

        [TestCaseSource(nameof(TestData_AddParticipant_MicrosoftTeamsAppWithCloud))]
        public async Task AddParticipantAsync_MicrosoftTeamsAppIdentifier_DifferentClouds_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantPayload);

            var response = await callConnection.AddParticipantAsync(new AddParticipantOptions(callInvite)).ConfigureAwait(false);
            ClassicAssert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyAddParticipantsResult(response);

            // Verify the target maintains the correct cloud environment
            ClassicAssert.IsInstanceOf<MicrosoftTeamsAppIdentifier>(callInvite.Target);
            var teamsApp = callInvite.Target as MicrosoftTeamsAppIdentifier;
            ClassicAssert.IsNotNull(teamsApp);
            ClassicAssert.AreEqual("testAppId", teamsApp!.AppId);
            ClassicAssert.IsTrue(teamsApp.Cloud == CommunicationCloudEnvironment.Public ||
                         teamsApp.Cloud == CommunicationCloudEnvironment.Dod ||
                         teamsApp.Cloud == CommunicationCloudEnvironment.Gcch);
        }

        [TestCaseSource(nameof(TestData_AddParticipant_MicrosoftTeamsAppWithCloud))]
        public void AddParticipant_MicrosoftTeamsAppIdentifier_DifferentClouds_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantPayload);

            var response = callConnection.AddParticipant(new AddParticipantOptions(callInvite));
            ClassicAssert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyAddParticipantsResult(response);

            // Verify the target maintains the correct cloud environment
            ClassicAssert.IsInstanceOf<MicrosoftTeamsAppIdentifier>(callInvite.Target);
            var teamsApp = callInvite.Target as MicrosoftTeamsAppIdentifier;
            ClassicAssert.IsNotNull(teamsApp);
            ClassicAssert.AreEqual("testAppId", teamsApp!.AppId);
            ClassicAssert.IsTrue(teamsApp.Cloud == CommunicationCloudEnvironment.Public ||
                         teamsApp.Cloud == CommunicationCloudEnvironment.Dod ||
                         teamsApp.Cloud == CommunicationCloudEnvironment.Gcch);
        }

        [TestCaseSource(nameof(TestData_AddParticipant_MicrosoftTeamsApp))]
        public async Task AddParticipantAsync_MicrosoftTeamsAppIdentifier_WithAllOptions_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantPayload);

            var options = new AddParticipantOptions(callInvite)
            {
                OperationContext = "custom-context",
                InvitationTimeoutInSeconds = 60,
                OperationCallbackUri = new Uri("https://example.com/callback")
            };

            var response = await callConnection.AddParticipantAsync(options).ConfigureAwait(false);
            ClassicAssert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyAddParticipantsResult(response);

            // Verify all optional properties can be set
            ClassicAssert.AreEqual("custom-context", options.OperationContext);
            ClassicAssert.AreEqual(60, options.InvitationTimeoutInSeconds);
            ClassicAssert.IsNotNull(options.OperationCallbackUri);
        }

        [TestCaseSource(nameof(TestData_AddParticipant_MicrosoftTeamsApp))]
        public void AddParticipant_MicrosoftTeamsAppIdentifier_WithAllOptions_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantPayload);

            var options = new AddParticipantOptions(callInvite)
            {
                OperationContext = "custom-context",
                InvitationTimeoutInSeconds = 60,
                OperationCallbackUri = new Uri("https://example.com/callback")
            };

            var response = callConnection.AddParticipant(options);
            ClassicAssert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyAddParticipantsResult(response);

            // Verify all optional properties can be set
            ClassicAssert.AreEqual("custom-context", options.OperationContext);
            ClassicAssert.AreEqual(60, options.InvitationTimeoutInSeconds);
            ClassicAssert.IsNotNull(options.OperationCallbackUri);
        }

        [TestCaseSource(nameof(TestData_AddParticipant_MicrosoftTeamsApp))]
        public void AddParticipantAsync_MicrosoftTeamsAppIdentifier_404NotFound(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = ClassicAssert.ThrowsAsync<RequestFailedException>(async () => await callConnection.AddParticipantAsync(new AddParticipantOptions(callInvite)).ConfigureAwait(false));
            ClassicAssert.NotNull(ex);
            ClassicAssert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_AddParticipant_MicrosoftTeamsApp))]
        public void AddParticipant_MicrosoftTeamsAppIdentifier_404NotFound(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = ClassicAssert.Throws<RequestFailedException>(() => callConnection.AddParticipant(new AddParticipantOptions(callInvite)));
            ClassicAssert.NotNull(ex);
            ClassicAssert.AreEqual(ex?.Status, 404);
        }

        [Test]
        public void AddParticipantAsync_NullMicrosoftTeamsAppCallInvite_ThrowsArgumentNullException()
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantPayload);
            CallInvite? nullCallInvite = null;

            ArgumentNullException? ex = ClassicAssert.ThrowsAsync<ArgumentNullException>(async () => await callConnection.AddParticipantAsync(new AddParticipantOptions(nullCallInvite!)).ConfigureAwait(false));
            ClassicAssert.IsNotNull(ex);
            ClassicAssert.IsTrue(ex!.Message.Contains("Value cannot be null"));
        }

        [Test]
        public void AddParticipant_NullMicrosoftTeamsAppCallInvite_ThrowsArgumentNullException()
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantPayload);
            CallInvite? nullCallInvite = null;

            ArgumentNullException? ex = ClassicAssert.Throws<ArgumentNullException>(() => callConnection.AddParticipant(new AddParticipantOptions(nullCallInvite!)));
            ClassicAssert.IsNotNull(ex);
            ClassicAssert.IsTrue(ex!.Message.Contains("Value cannot be null"));
        }

        [Test]
        public void AddParticipantsAsync_NullParticipantToAdd()
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantPayload);

            ArgumentNullException? ex = ClassicAssert.ThrowsAsync<ArgumentNullException>(async () => await callConnection.AddParticipantAsync(new AddParticipantOptions(null)).ConfigureAwait(false));
            ClassicAssert.NotNull(ex);
            ClassicAssert.True(ex?.Message.Contains("Value cannot be null."));
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipant))]
        public void AddParticipantsAsync_404NotFound(CommunicationIdentifier participantToAdd)
        {
            var callConnection = CreateMockCallConnection(404);
            var callInvite = new CallInvite((CommunicationUserIdentifier)participantToAdd);

            RequestFailedException? ex = ClassicAssert.ThrowsAsync<RequestFailedException>(async () => await callConnection.AddParticipantAsync(new AddParticipantOptions(callInvite)).ConfigureAwait(false));
            ClassicAssert.NotNull(ex);
            ClassicAssert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipant))]
        public void AddParticipants_404NotFound(CommunicationIdentifier participantToAdd)
        {
            var callConnection = CreateMockCallConnection(404);
            var callInvite = new CallInvite((CommunicationUserIdentifier)participantToAdd);

            RequestFailedException? ex = ClassicAssert.Throws<RequestFailedException>(() => callConnection.AddParticipant(new AddParticipantOptions(callInvite)));
            ClassicAssert.NotNull(ex);
            ClassicAssert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_GetParticipant))]
        public async Task GetParticipantAsync_200OK(string participantMri)
        {
            var callConnection = CreateMockCallConnection(200, GetParticipantPayload);
            var participantIdentifier = new CommunicationUserIdentifier(participantMri);

            var response = await callConnection.GetParticipantAsync(participantIdentifier).ConfigureAwait(false);
            ClassicAssert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            verifyGetParticipantResult(response);
        }

        [TestCaseSource(nameof(TestData_GetParticipant))]
        public void GetParticipant_200OK(string participantMri)
        {
            var callConnection = CreateMockCallConnection(200, GetParticipantPayload);
            var participantIdentifier = new CommunicationUserIdentifier(participantMri);

            var response = callConnection.GetParticipant(participantIdentifier);
            ClassicAssert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            verifyGetParticipantResult(response);
        }

        [TestCaseSource(nameof(TestData_GetParticipant))]
        public void GetParticipantAsync_404NotFound(string participantMri)
        {
            var callConnection = CreateMockCallConnection(404);
            var participantIdentifier = new CommunicationUserIdentifier(participantMri);

            RequestFailedException? ex = ClassicAssert.ThrowsAsync<RequestFailedException>(async () => await callConnection.GetParticipantAsync(participantIdentifier).ConfigureAwait(false));
            ClassicAssert.NotNull(ex);
            ClassicAssert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_GetParticipant))]
        public void GetParticipant_404NotFound(string participantMri)
        {
            var callConnection = CreateMockCallConnection(404);
            var participantIdentifier = new CommunicationUserIdentifier(participantMri);

            RequestFailedException? ex = ClassicAssert.Throws<RequestFailedException>(() => callConnection.GetParticipant(participantIdentifier));
            ClassicAssert.NotNull(ex);
            ClassicAssert.AreEqual(ex?.Status, 404);
        }

        [Test]
        public async Task GetParticipantsAsync_200OK()
        {
            var callConnection = CreateMockCallConnection(200, GetParticipantsPayload);

            var response = await callConnection.GetParticipantsAsync().ConfigureAwait(false);
            ClassicAssert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            verifyGetParticipantsResult(response.Value);
        }

        [Test]
        public void GetParticipants_200OK()
        {
            var callConnection = CreateMockCallConnection(200, GetParticipantsPayload);

            var response = callConnection.GetParticipants();
            ClassicAssert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            verifyGetParticipantsResult(response.Value);
        }

        [Test]
        public void GetParticipantsAsync_404NotFound()
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = ClassicAssert.ThrowsAsync<RequestFailedException>(async () => await callConnection.GetParticipantsAsync().ConfigureAwait(false));
            ClassicAssert.NotNull(ex);
            ClassicAssert.AreEqual(ex?.Status, 404);
        }

        [Test]
        public void GetParticipants_404NotFound()
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = ClassicAssert.Throws<RequestFailedException>(() => callConnection.GetParticipants());
            ClassicAssert.NotNull(ex);
            ClassicAssert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipant))]
        public async Task RemoveParticipantsAsync_202Accepted(CommunicationIdentifier participantToRemove)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = await callConnection.RemoveParticipantAsync(participantToRemove).ConfigureAwait(false);
            ClassicAssert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            ClassicAssert.AreEqual(OperationContext, response.Value.OperationContext);
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipant))]
        public void RemoveParticipants_202Accepted(CommunicationIdentifier participantToRemove)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = callConnection.RemoveParticipant(participantToRemove);
            ClassicAssert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            ClassicAssert.AreEqual(OperationContext, response.Value.OperationContext);
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipant))]
        public void RemoveParticipantsAsync_404NotFound(CommunicationIdentifier participantToRemove)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = ClassicAssert.ThrowsAsync<RequestFailedException>(async () => await callConnection.RemoveParticipantAsync(participantToRemove).ConfigureAwait(false));
            ClassicAssert.NotNull(ex);
            ClassicAssert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipant))]
        public void RemoveParticipants_404NotFound(CommunicationIdentifier participantToRemove)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = ClassicAssert.Throws<RequestFailedException>(() => callConnection.RemoveParticipant(participantToRemove));
            ClassicAssert.NotNull(ex);
            ClassicAssert.AreEqual(ex?.Status, 404);
        }

        [Test]
        public void GetCallMediaTest()
        {
            var connectionId = "someId";
            var callConnection = CreateMockCallConnection(200, null, connectionId);

            var response = callConnection.GetCallMedia();
            ClassicAssert.IsNotNull(response);
            ClassicAssert.AreEqual(connectionId, response.CallConnectionId);
        }

        [TestCaseSource(nameof(TestData_MuteParticipant))]
        public void MuteParticipant_200Ok(CommunicationIdentifier participant)
        {
            var callConnection = CreateMockCallConnection(200, OperationContextPayload);

            var response = callConnection.MuteParticipant(participant);
            ClassicAssert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
        }

        [TestCaseSource(nameof(TestData_MuteParticipant))]
        public void MuteParticipant_WithOptions_200Ok(CommunicationIdentifier participant)
        {
            var callConnection = CreateMockCallConnection(200, OperationContextPayload);
            var options = new MuteParticipantOptions(participant)
            {
                OperationContext = OperationContext
            };
            var response = callConnection.MuteParticipant(options);
            ClassicAssert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            ClassicAssert.AreEqual(OperationContext, response.Value.OperationContext);
        }

        [TestCaseSource(nameof(TestData_MuteParticipant))]
        public async Task MuteParticipantAsync_200Accepted(CommunicationIdentifier participant)
        {
            var callConnection = CreateMockCallConnection(200, OperationContextPayload);

            var response = await callConnection.MuteParticipantAsync(participant);
            ClassicAssert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
        }

        [Test]
        public void MuteParticipantAsync_NotAcsUser_400BadRequest()
        {
            var callConnection = CreateMockCallConnection(400);
            var participant = new PhoneNumberIdentifier("+15559501234");
            ClassicAssert.ThrowsAsync(typeof(RequestFailedException), async () => await callConnection.MuteParticipantAsync(participant));
        }

        [TestCaseSource(nameof(TestData_MuteParticipant))]
        public async Task MuteParticipantAsync_WithOptions_200OK(CommunicationIdentifier participant)
        {
            var callConnection = CreateMockCallConnection(200, OperationContextPayload);
            var options = new MuteParticipantOptions(participant)
            {
                OperationContext = OperationContext,
            };

            var response = await callConnection.MuteParticipantAsync(options);
            ClassicAssert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            ClassicAssert.AreEqual(OperationContext, response.Value.OperationContext);
        }

        [TestCaseSource(nameof(TestData_MuteParticipant))]
        public void MuteParticipantAsync_WithOptions_MoreThanOneParticipant_400BadRequest(CommunicationIdentifier participant)
        {
            var callConnection = CreateMockCallConnection(400);
            var options = new MuteParticipantOptions(participant)
            {
                OperationContext = OperationContext,
            };

            ClassicAssert.ThrowsAsync(typeof(RequestFailedException), async () => await callConnection.MuteParticipantAsync(options));
        }

        [Test]
        public async Task CancelAddParticipantAsync_202Accepted()
        {
            var callConnection = CreateMockCallConnection(202, CancelAddParticipantPayload);
            var invitationId = "invitationId";

            var response = await callConnection.CancelAddParticipantOperationAsync(invitationId).ConfigureAwait(false);
            ClassicAssert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            ClassicAssert.AreEqual(invitationId, response.Value.InvitationId);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant_MicrosoftTeamsApp))]
        public async Task TransferCallToParticipantAsync_MicrosoftTeamsAppIdentifier_simpleMethod_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = await callConnection.TransferCallToParticipantAsync(callInvite.Target).ConfigureAwait(false);
            ClassicAssert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyOperationContext(response);

            // Verify the target is correctly typed as MicrosoftTeamsAppIdentifier
            ClassicAssert.IsInstanceOf<MicrosoftTeamsAppIdentifier>(callInvite.Target);
            var teamsApp = callInvite.Target as MicrosoftTeamsAppIdentifier;
            ClassicAssert.IsNotNull(teamsApp);
            ClassicAssert.AreEqual("testAppId", teamsApp!.AppId);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant_MicrosoftTeamsApp))]
        public void TransferCallToParticipant_MicrosoftTeamsAppIdentifier_simpleMethod_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = callConnection.TransferCallToParticipant(callInvite.Target);
            ClassicAssert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyOperationContext(response);

            // Verify the target is correctly typed as MicrosoftTeamsAppIdentifier
            ClassicAssert.IsInstanceOf<MicrosoftTeamsAppIdentifier>(callInvite.Target);
            var teamsApp = callInvite.Target as MicrosoftTeamsAppIdentifier;
            ClassicAssert.IsNotNull(teamsApp);
            ClassicAssert.AreEqual("testAppId", teamsApp!.AppId);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant_MicrosoftTeamsApp))]
        public async Task TransferCallToParticipantAsync_MicrosoftTeamsAppIdentifier_WithOptions_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var options = new TransferToParticipantOptions(callInvite.Target as MicrosoftTeamsAppIdentifier);

            var response = await callConnection.TransferCallToParticipantAsync(options).ConfigureAwait(false);
            ClassicAssert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyOperationContext(response);

            // Verify the options were created correctly
            ClassicAssert.IsInstanceOf<MicrosoftTeamsAppIdentifier>(options.Target);
            ClassicAssert.IsNotNull(options.CustomCallingContext);
            ClassicAssert.IsEmpty(options.CustomCallingContext.SipHeaders);
            ClassicAssert.IsNotNull(options.CustomCallingContext.VoipHeaders);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant_MicrosoftTeamsApp))]
        public void TransferCallToParticipant_MicrosoftTeamsAppIdentifier_WithOptions_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var options = new TransferToParticipantOptions(callInvite.Target as MicrosoftTeamsAppIdentifier);

            var response = callConnection.TransferCallToParticipant(options);
            ClassicAssert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyOperationContext(response);

            // Verify the options were created correctly
            ClassicAssert.IsInstanceOf<MicrosoftTeamsAppIdentifier>(options.Target);
            ClassicAssert.IsNotNull(options.CustomCallingContext);
            ClassicAssert.IsEmpty(options.CustomCallingContext.SipHeaders);
            ClassicAssert.IsNotNull(options.CustomCallingContext.VoipHeaders);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant_MicrosoftTeamsAppWithCloud))]
        public async Task TransferCallToParticipantAsync_MicrosoftTeamsAppIdentifier_DifferentClouds_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = await callConnection.TransferCallToParticipantAsync(callInvite.Target).ConfigureAwait(false);
            ClassicAssert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyOperationContext(response);

            // Verify the target maintains the correct cloud environment
            ClassicAssert.IsInstanceOf<MicrosoftTeamsAppIdentifier>(callInvite.Target);
            var teamsApp = callInvite.Target as MicrosoftTeamsAppIdentifier;
            ClassicAssert.IsNotNull(teamsApp);
            ClassicAssert.AreEqual("testAppId", teamsApp!.AppId);
            ClassicAssert.IsTrue(teamsApp.Cloud == CommunicationCloudEnvironment.Public ||
                         teamsApp.Cloud == CommunicationCloudEnvironment.Dod ||
                         teamsApp.Cloud == CommunicationCloudEnvironment.Gcch);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant_MicrosoftTeamsAppWithCloud))]
        public void TransferCallToParticipant_MicrosoftTeamsAppIdentifier_DifferentClouds_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = callConnection.TransferCallToParticipant(callInvite.Target);
            ClassicAssert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyOperationContext(response);

            // Verify the target maintains the correct cloud environment
            ClassicAssert.IsInstanceOf<MicrosoftTeamsAppIdentifier>(callInvite.Target);
            var teamsApp = callInvite.Target as MicrosoftTeamsAppIdentifier;
            ClassicAssert.IsNotNull(teamsApp);
            ClassicAssert.AreEqual("testAppId", teamsApp!.AppId);
            ClassicAssert.IsTrue(teamsApp.Cloud == CommunicationCloudEnvironment.Public ||
                         teamsApp.Cloud == CommunicationCloudEnvironment.Dod ||
                         teamsApp.Cloud == CommunicationCloudEnvironment.Gcch);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant_MicrosoftTeamsApp))]
        public async Task TransferCallToParticipantAsync_MicrosoftTeamsAppIdentifier_WithTransferee_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);
            var options = new TransferToParticipantOptions(callInvite.Target as MicrosoftTeamsAppIdentifier);
            options.Transferee = new CommunicationUserIdentifier("transfereeId");
            options.OperationContext = "custom-context";
            options.OperationCallbackUri = new Uri("https://example.com/callback");
            options.SourceCallerIdNumber = new PhoneNumberIdentifier("+14255551234");

            var response = await callConnection.TransferCallToParticipantAsync(options).ConfigureAwait(false);
            ClassicAssert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyOperationContext(response);

            // Verify all optional properties can be set
            ClassicAssert.IsNotNull(options.Transferee);
            ClassicAssert.IsNotNull(options.OperationCallbackUri);
            ClassicAssert.IsNotNull(options.SourceCallerIdNumber);
            ClassicAssert.AreEqual("custom-context", options.OperationContext);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant_MicrosoftTeamsApp))]
        public void TransferCallToParticipant_MicrosoftTeamsAppIdentifier_WithTransferee_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);
            var options = new TransferToParticipantOptions(callInvite.Target as MicrosoftTeamsAppIdentifier);
            options.Transferee = new CommunicationUserIdentifier("transfereeId");
            options.OperationContext = "custom-context";
            options.OperationCallbackUri = new Uri("https://example.com/callback");
            options.SourceCallerIdNumber = new PhoneNumberIdentifier("+14255551234");

            var response = callConnection.TransferCallToParticipant(options);
            ClassicAssert.AreEqual((int)HttpStatusCode.Accepted, response.GetRawResponse().Status);
            verifyOperationContext(response);

            // Verify all optional properties can be set
            ClassicAssert.IsNotNull(options.Transferee);
            ClassicAssert.IsNotNull(options.OperationCallbackUri);
            ClassicAssert.IsNotNull(options.SourceCallerIdNumber);
            ClassicAssert.AreEqual("custom-context", options.OperationContext);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant_MicrosoftTeamsApp))]
        public void TransferCallToParticipantAsync_MicrosoftTeamsAppIdentifier_404NotFound(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = ClassicAssert.ThrowsAsync<RequestFailedException>(async () => await callConnection.TransferCallToParticipantAsync(new TransferToParticipantOptions(callInvite.Target as MicrosoftTeamsAppIdentifier)).ConfigureAwait(false));
            ClassicAssert.NotNull(ex);
            ClassicAssert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant_MicrosoftTeamsApp))]
        public void TransferCallToParticipant_MicrosoftTeamsAppIdentifier_404NotFound(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = ClassicAssert.Throws<RequestFailedException>(() => callConnection.TransferCallToParticipant(new TransferToParticipantOptions(callInvite.Target as MicrosoftTeamsAppIdentifier)));
            ClassicAssert.NotNull(ex);
            ClassicAssert.AreEqual(ex?.Status, 404);
        }

        [Test]
        public void TransferCallToParticipantAsync_NullMicrosoftTeamsAppIdentifier_ThrowsArgumentNullException()
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);
            MicrosoftTeamsAppIdentifier? nullTeamsAppIdentifier = null;

            ArgumentNullException? ex = ClassicAssert.ThrowsAsync<ArgumentNullException>(async () => await callConnection.TransferCallToParticipantAsync(nullTeamsAppIdentifier!).ConfigureAwait(false));
            ClassicAssert.IsNotNull(ex);
            ClassicAssert.AreEqual("targetParticipant", ex!.ParamName);
        }

        [Test]
        public void TransferCallToParticipant_NullMicrosoftTeamsAppIdentifier_ThrowsArgumentNullException()
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);
            MicrosoftTeamsAppIdentifier? nullTeamsAppIdentifier = null;

            ArgumentNullException? ex = ClassicAssert.Throws<ArgumentNullException>(() => callConnection.TransferCallToParticipant(nullTeamsAppIdentifier!));
            ClassicAssert.IsNotNull(ex);
            ClassicAssert.AreEqual("targetParticipant", ex!.ParamName);
        }

        private CallConnection CreateMockCallConnection(int responseCode, string? responseContent = null, string callConnectionId = "9ec7da16-30be-4e74-a941-285cfc4bffc5")
        {
            return CreateMockCallAutomationClient(responseCode, responseContent).GetCallConnection(callConnectionId);
        }

        private static IEnumerable<object?[]> TestData_TransferCallToParticipant_PhoneNumberIdentifier_MS()
        {
            var callInvite = new CallInvite(new PhoneNumberIdentifier(PhoneNumber), new PhoneNumberIdentifier("+17654321"));
            callInvite.CustomCallingContext.AddSipX("key1", "value1", SipHeaderPrefix.XmsCustom);
            return new[]
            {
                new object?[]
                {
                    callInvite
    },
            };
        }
        private static IEnumerable<object?[]> TestData_TransferCallToParticipant_PhoneNumberIdentifier()
        {
            var callInvite = new CallInvite(new PhoneNumberIdentifier(PhoneNumber), new PhoneNumberIdentifier("+17654321"));
            callInvite.CustomCallingContext.AddSipX("key1", "value1", SipHeaderPrefix.X);
            return new[]
            {
                new object?[]
                {
                    callInvite
                },
            };
        }

        private static IEnumerable<object?[]> TestData_TransferCallToParticipant()
        {
            var callInvite = new CallInvite(new CommunicationUserIdentifier("userId"));
            callInvite.CustomCallingContext.AddVoip("key1", "value1");
            return new[]
            {
                new object?[]
                {
                    callInvite
                },
            };
        }

        private static IEnumerable<object?[]> TestData_TransferCallToParticipant_MicrosoftTeamsApp()
        {
            var callInvite = new CallInvite(new MicrosoftTeamsAppIdentifier("testAppId"));
            callInvite.CustomCallingContext.AddVoip("key1", "value1");
            return new[]
            {
                new object?[]
                {
                    callInvite
                },
            };
        }

        private static IEnumerable<object?[]> TestData_TransferCallToParticipant_MicrosoftTeamsAppWithCloud()
        {
            var callInvitePublic = new CallInvite(new MicrosoftTeamsAppIdentifier("testAppId", CommunicationCloudEnvironment.Public));
            callInvitePublic.CustomCallingContext.AddVoip("key1", "value1");

            var callInviteDod = new CallInvite(new MicrosoftTeamsAppIdentifier("testAppId", CommunicationCloudEnvironment.Dod));
            callInviteDod.CustomCallingContext.AddVoip("key2", "value2");

            var callInviteGcch = new CallInvite(new MicrosoftTeamsAppIdentifier("testAppId", CommunicationCloudEnvironment.Gcch));
            callInviteGcch.CustomCallingContext.AddVoip("key3", "value3");

            return new[]
            {
                new object?[] { callInvitePublic },
                new object?[] { callInviteDod },
                new object?[] { callInviteGcch },
            };
        }

        private static IEnumerable<object?[]> TestData_GetParticipant()
        {
            return new[]
            {
                new object?[]
                {
                    "somemri"
                },
            };
        }

        private static IEnumerable<object?[]> TestData_AddOrRemoveParticipant()
        {
            return new[]
            {
                new object?[]
                {
                    new CommunicationUserIdentifier("userId")
                },
            };
        }

        private static IEnumerable<object?[]> TestData_AddParticipant_MicrosoftTeamsApp()
        {
            var callInvite = new CallInvite(new MicrosoftTeamsAppIdentifier("testAppId"));
            callInvite.CustomCallingContext.AddVoip("key1", "value1");
            return new[]
            {
                new object?[]
                {
                    callInvite
                },
            };
        }

        private static IEnumerable<object?[]> TestData_AddParticipant_MicrosoftTeamsAppWithCloud()
        {
            var callInvitePublic = new CallInvite(new MicrosoftTeamsAppIdentifier("testAppId", CommunicationCloudEnvironment.Public));
            callInvitePublic.CustomCallingContext.AddVoip("key1", "value1");

            var callInviteDod = new CallInvite(new MicrosoftTeamsAppIdentifier("testAppId", CommunicationCloudEnvironment.Dod));
            callInviteDod.CustomCallingContext.AddVoip("key2", "value2");

            var callInviteGcch = new CallInvite(new MicrosoftTeamsAppIdentifier("testAppId", CommunicationCloudEnvironment.Gcch));
            callInviteGcch.CustomCallingContext.AddVoip("key3", "value3");

            return new[]
            {
                new object?[] { callInvitePublic },
                new object?[] { callInviteDod },
                new object?[] { callInviteGcch },
            };
        }

        private static IEnumerable<object?[]> TestData_MuteParticipant()
        {
            return new[]
            {
                new object?[]
                {
                    new CommunicationUserIdentifier("userId")
                },
            };
        }

        private void verifyOperationContext(TransferCallToParticipantResult result)
        {
            ClassicAssert.AreEqual(OperationContext, result.OperationContext);
        }

        private void verifyAddParticipantsResult(AddParticipantResult result)
        {
            var identifier = (CommunicationUserIdentifier)result.Participant.Identifier;
            ClassicAssert.AreEqual(ParticipantUserId, identifier.Id);
            ClassicAssert.IsFalse(result.Participant.IsMuted);
            ClassicAssert.AreEqual(OperationContext, result.OperationContext);
        }

        private void verifyGetParticipantResult(CallParticipant participant)
        {
            var identifier = (CommunicationUserIdentifier)participant.Identifier;
            ClassicAssert.AreEqual(ParticipantUserId, identifier.Id);
            ClassicAssert.IsFalse(participant.IsMuted);
        }

        private void verifyGetParticipantsResult(IReadOnlyList<CallParticipant> participants)
        {
            ClassicAssert.AreEqual(2, participants.Count);
            var identifier = (CommunicationUserIdentifier)participants[0].Identifier;
            ClassicAssert.AreEqual(ParticipantUserId, identifier.Id);
            ClassicAssert.IsFalse(participants[0].IsMuted);
            var identifier2 = (PhoneNumberIdentifier)participants[1].Identifier;
            ClassicAssert.AreEqual(PhoneNumber, identifier2.PhoneNumber);
            ClassicAssert.IsTrue(participants[1].IsMuted);
        }
    }
}
