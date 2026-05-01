// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Communication.CallAutomation.Tests.Infrastructure;
using NUnit.Framework;

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

            Assert.That(response, Is.Not.Null);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.OK));
            verifyCallConnectionProperties(response);
        }

        [Test]
        public void GetCallConnectionProperties_200OK()
        {
            var callConnection = CreateMockCallConnection(200, CreateOrAnswerCallOrGetCallConnectionPayload);

            var response = callConnection.GetCallConnectionProperties();

            Assert.That(response, Is.Not.Null);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.OK));
            verifyCallConnectionProperties(response);
        }
        [Test]
        public void GetCallConnectionPropertiesAsync_404NotFound()
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [Test]
        public void GetCallConnectionProperties_404NotFound()
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.GetCallConnectionProperties());
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [Test]
        public async Task HangupCallAsync_204NoContent()
        {
            var callConnection = CreateMockCallConnection(204);

            var response = await callConnection.HangUpAsync(false).ConfigureAwait(false);
            Assert.That(response.Status, Is.EqualTo((int)HttpStatusCode.NoContent));
        }

        [Test]
        public void HangupCall_204NoContent()
        {
            var callConnection = CreateMockCallConnection(204);

            var response = callConnection.HangUp(false);
            Assert.That(response.Status, Is.EqualTo((int)HttpStatusCode.NoContent));
        }

        [Test]
        public void HangUpCallAsync_404NotFound()
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.HangUpAsync(false).ConfigureAwait(false));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [Test]
        public void HangUpCall_404NotFound()
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.HangUp(false));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        public async Task TransferCallToParticipantAsync_simpleMethod_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = await callConnection.TransferCallToParticipantAsync(callInvite.Target).ConfigureAwait(false);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            verifyOperationContext(response);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant_PhoneNumberIdentifier))]
        public async Task TransferCallToParticipantAsync_simpleMethod_PhoneNumberIdentifier_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);
            var response = await callConnection.TransferCallToParticipantAsync(callInvite.Target).ConfigureAwait(false);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            verifyOperationContext(response);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant_PhoneNumberIdentifier_MS))]
        public async Task TransferCallToParticipantAsync_simpleMethod_PhoneNumberIdentifier_MSAsTarget_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);
            var response = await callConnection.TransferCallToParticipantAsync(callInvite.Target).ConfigureAwait(false);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            verifyOperationContext(response);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        public async Task TransferCallToParticipantAsync_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = await callConnection.TransferCallToParticipantAsync(new TransferToParticipantOptions(callInvite.Target as CommunicationUserIdentifier)).ConfigureAwait(false);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            verifyOperationContext(response);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        public async Task TransferCallToParticipantAsyncWithTransferee_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);
            var options = new TransferToParticipantOptions(callInvite.Target as CommunicationUserIdentifier);
            options.Transferee = new CommunicationUserIdentifier("transfereeid");

            var response = await callConnection.TransferCallToParticipantAsync(options).ConfigureAwait(false);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            verifyOperationContext(response);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        public void TransferCallToParticipant_simpleMethod_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = callConnection.TransferCallToParticipant(callInvite.Target);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            verifyOperationContext(response);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        public void TransferCallToParticipant_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = callConnection.TransferCallToParticipant(new TransferToParticipantOptions(callInvite.Target as CommunicationUserIdentifier));
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            verifyOperationContext(response);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        public void TransferCallToParticipantWithTransferee_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);
            var options = new TransferToParticipantOptions(callInvite.Target as CommunicationUserIdentifier);
            options.Transferee = new CommunicationUserIdentifier("transfereeid");

            var response = callConnection.TransferCallToParticipant(options);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            verifyOperationContext(response);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        public void TransferCallToParticipantAsync_404NotFound(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.TransferCallToParticipantAsync(new TransferToParticipantOptions(callInvite.Target as CommunicationUserIdentifier)).ConfigureAwait(false));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant))]
        public void TransferCallToParticipant_404NotFound(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.TransferCallToParticipant(new TransferToParticipantOptions(callInvite.Target as CommunicationUserIdentifier)));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipant))]
        public async Task AddParticipantsAsync_202Accepted(CommunicationIdentifier participantToAdd)
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantPayload);
            var callInvite = new CallInvite((CommunicationUserIdentifier)participantToAdd);

            var response = await callConnection.AddParticipantAsync(new AddParticipantOptions(callInvite)).ConfigureAwait(false);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            verifyAddParticipantsResult(response);
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipant))]
        public void AddParticipants_202Accepted(CommunicationIdentifier participantToAdd)
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantPayload);
            var callInvite = new CallInvite((CommunicationUserIdentifier)participantToAdd);

            var response = callConnection.AddParticipant(new AddParticipantOptions(callInvite));
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            verifyAddParticipantsResult(response);
        }

        [TestCaseSource(nameof(TestData_AddParticipant_MicrosoftTeamsApp))]
        public async Task AddParticipantAsync_MicrosoftTeamsAppIdentifier_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantPayload);

            var response = await callConnection.AddParticipantAsync(new AddParticipantOptions(callInvite)).ConfigureAwait(false);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            verifyAddParticipantsResult(response);

            // Verify the target is correctly typed as MicrosoftTeamsAppIdentifier
            Assert.That(callInvite.Target, Is.InstanceOf<MicrosoftTeamsAppIdentifier>());
            var teamsApp = callInvite.Target as MicrosoftTeamsAppIdentifier;
            Assert.That(teamsApp, Is.Not.Null);
            Assert.That(teamsApp!.AppId, Is.EqualTo("testAppId"));
        }

        [TestCaseSource(nameof(TestData_AddParticipant_MicrosoftTeamsApp))]
        public void AddParticipant_MicrosoftTeamsAppIdentifier_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantPayload);

            var response = callConnection.AddParticipant(new AddParticipantOptions(callInvite));
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            verifyAddParticipantsResult(response);

            // Verify the target is correctly typed as MicrosoftTeamsAppIdentifier
            Assert.That(callInvite.Target, Is.InstanceOf<MicrosoftTeamsAppIdentifier>());
            var teamsApp = callInvite.Target as MicrosoftTeamsAppIdentifier;
            Assert.That(teamsApp, Is.Not.Null);
            Assert.That(teamsApp!.AppId, Is.EqualTo("testAppId"));
        }

        [TestCaseSource(nameof(TestData_AddParticipant_MicrosoftTeamsAppWithCloud))]
        public async Task AddParticipantAsync_MicrosoftTeamsAppIdentifier_DifferentClouds_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantPayload);

            var response = await callConnection.AddParticipantAsync(new AddParticipantOptions(callInvite)).ConfigureAwait(false);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            verifyAddParticipantsResult(response);

            // Verify the target maintains the correct cloud environment
            Assert.That(callInvite.Target, Is.InstanceOf<MicrosoftTeamsAppIdentifier>());
            var teamsApp = callInvite.Target as MicrosoftTeamsAppIdentifier;
            Assert.That(teamsApp, Is.Not.Null);
            Assert.That(teamsApp!.AppId, Is.EqualTo("testAppId"));
            Assert.That(teamsApp.Cloud == CommunicationCloudEnvironment.Public ||
                         teamsApp.Cloud == CommunicationCloudEnvironment.Dod ||
                         teamsApp.Cloud == CommunicationCloudEnvironment.Gcch, Is.True);
        }

        [TestCaseSource(nameof(TestData_AddParticipant_MicrosoftTeamsAppWithCloud))]
        public void AddParticipant_MicrosoftTeamsAppIdentifier_DifferentClouds_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantPayload);

            var response = callConnection.AddParticipant(new AddParticipantOptions(callInvite));
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            verifyAddParticipantsResult(response);

            // Verify the target maintains the correct cloud environment
            Assert.That(callInvite.Target, Is.InstanceOf<MicrosoftTeamsAppIdentifier>());
            var teamsApp = callInvite.Target as MicrosoftTeamsAppIdentifier;
            Assert.That(teamsApp, Is.Not.Null);
            Assert.That(teamsApp!.AppId, Is.EqualTo("testAppId"));
            Assert.That(teamsApp.Cloud == CommunicationCloudEnvironment.Public ||
                         teamsApp.Cloud == CommunicationCloudEnvironment.Dod ||
                         teamsApp.Cloud == CommunicationCloudEnvironment.Gcch, Is.True);
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
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            verifyAddParticipantsResult(response);

            // Verify all optional properties can be set
            Assert.That(options.OperationContext, Is.EqualTo("custom-context"));
            Assert.That(options.InvitationTimeoutInSeconds, Is.EqualTo(60));
            Assert.That(options.OperationCallbackUri, Is.Not.Null);
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
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            verifyAddParticipantsResult(response);

            // Verify all optional properties can be set
            Assert.That(options.OperationContext, Is.EqualTo("custom-context"));
            Assert.That(options.InvitationTimeoutInSeconds, Is.EqualTo(60));
            Assert.That(options.OperationCallbackUri, Is.Not.Null);
        }

        [TestCaseSource(nameof(TestData_AddParticipant_MicrosoftTeamsApp))]
        public void AddParticipantAsync_MicrosoftTeamsAppIdentifier_404NotFound(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.AddParticipantAsync(new AddParticipantOptions(callInvite)).ConfigureAwait(false));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [TestCaseSource(nameof(TestData_AddParticipant_MicrosoftTeamsApp))]
        public void AddParticipant_MicrosoftTeamsAppIdentifier_404NotFound(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.AddParticipant(new AddParticipantOptions(callInvite)));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [Test]
        public void AddParticipantAsync_NullMicrosoftTeamsAppCallInvite_ThrowsArgumentNullException()
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantPayload);
            CallInvite? nullCallInvite = null;

            ArgumentNullException? ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await callConnection.AddParticipantAsync(new AddParticipantOptions(nullCallInvite!)).ConfigureAwait(false));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex!.Message.Contains("Value cannot be null"), Is.True);
        }

        [Test]
        public void AddParticipant_NullMicrosoftTeamsAppCallInvite_ThrowsArgumentNullException()
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantPayload);
            CallInvite? nullCallInvite = null;

            ArgumentNullException? ex = Assert.Throws<ArgumentNullException>(() => callConnection.AddParticipant(new AddParticipantOptions(nullCallInvite!)));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex!.Message.Contains("Value cannot be null"), Is.True);
        }

        [Test]
        public void AddParticipantsAsync_NullParticipantToAdd()
        {
            var callConnection = CreateMockCallConnection(202, AddParticipantPayload);

            ArgumentNullException? ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await callConnection.AddParticipantAsync(new AddParticipantOptions(null)).ConfigureAwait(false));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Message.Contains("Value cannot be null."), Is.True);
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipant))]
        public void AddParticipantsAsync_404NotFound(CommunicationIdentifier participantToAdd)
        {
            var callConnection = CreateMockCallConnection(404);
            var callInvite = new CallInvite((CommunicationUserIdentifier)participantToAdd);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.AddParticipantAsync(new AddParticipantOptions(callInvite)).ConfigureAwait(false));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipant))]
        public void AddParticipants_404NotFound(CommunicationIdentifier participantToAdd)
        {
            var callConnection = CreateMockCallConnection(404);
            var callInvite = new CallInvite((CommunicationUserIdentifier)participantToAdd);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.AddParticipant(new AddParticipantOptions(callInvite)));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [TestCaseSource(nameof(TestData_GetParticipant))]
        public async Task GetParticipantAsync_200OK(string participantMri)
        {
            var callConnection = CreateMockCallConnection(200, GetParticipantPayload);
            var participantIdentifier = new CommunicationUserIdentifier(participantMri);

            var response = await callConnection.GetParticipantAsync(participantIdentifier).ConfigureAwait(false);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.OK));
            verifyGetParticipantResult(response);
        }

        [TestCaseSource(nameof(TestData_GetParticipant))]
        public void GetParticipant_200OK(string participantMri)
        {
            var callConnection = CreateMockCallConnection(200, GetParticipantPayload);
            var participantIdentifier = new CommunicationUserIdentifier(participantMri);

            var response = callConnection.GetParticipant(participantIdentifier);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.OK));
            verifyGetParticipantResult(response);
        }

        [TestCaseSource(nameof(TestData_GetParticipant))]
        public void GetParticipantAsync_404NotFound(string participantMri)
        {
            var callConnection = CreateMockCallConnection(404);
            var participantIdentifier = new CommunicationUserIdentifier(participantMri);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.GetParticipantAsync(participantIdentifier).ConfigureAwait(false));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [TestCaseSource(nameof(TestData_GetParticipant))]
        public void GetParticipant_404NotFound(string participantMri)
        {
            var callConnection = CreateMockCallConnection(404);
            var participantIdentifier = new CommunicationUserIdentifier(participantMri);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.GetParticipant(participantIdentifier));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [Test]
        public async Task GetParticipantsAsync_200OK()
        {
            var callConnection = CreateMockCallConnection(200, GetParticipantsPayload);

            var response = await callConnection.GetParticipantsAsync().ConfigureAwait(false);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.OK));
            verifyGetParticipantsResult(response.Value);
        }

        [Test]
        public void GetParticipants_200OK()
        {
            var callConnection = CreateMockCallConnection(200, GetParticipantsPayload);

            var response = callConnection.GetParticipants();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.OK));
            verifyGetParticipantsResult(response.Value);
        }

        [Test]
        public void GetParticipantsAsync_404NotFound()
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.GetParticipantsAsync().ConfigureAwait(false));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [Test]
        public void GetParticipants_404NotFound()
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.GetParticipants());
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipant))]
        public async Task RemoveParticipantsAsync_202Accepted(CommunicationIdentifier participantToRemove)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = await callConnection.RemoveParticipantAsync(participantToRemove).ConfigureAwait(false);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            Assert.That(response.Value.OperationContext, Is.EqualTo(OperationContext));
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipant))]
        public void RemoveParticipants_202Accepted(CommunicationIdentifier participantToRemove)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = callConnection.RemoveParticipant(participantToRemove);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            Assert.That(response.Value.OperationContext, Is.EqualTo(OperationContext));
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipant))]
        public void RemoveParticipantsAsync_404NotFound(CommunicationIdentifier participantToRemove)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.RemoveParticipantAsync(participantToRemove).ConfigureAwait(false));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [TestCaseSource(nameof(TestData_AddOrRemoveParticipant))]
        public void RemoveParticipants_404NotFound(CommunicationIdentifier participantToRemove)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.RemoveParticipant(participantToRemove));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [Test]
        public void GetCallMediaTest()
        {
            var connectionId = "someId";
            var callConnection = CreateMockCallConnection(200, null, connectionId);

            var response = callConnection.GetCallMedia();
            Assert.That(response, Is.Not.Null);
            Assert.That(response.CallConnectionId, Is.EqualTo(connectionId));
        }

        [TestCaseSource(nameof(TestData_MuteParticipant))]
        public void MuteParticipant_200Ok(CommunicationIdentifier participant)
        {
            var callConnection = CreateMockCallConnection(200, OperationContextPayload);

            var response = callConnection.MuteParticipant(participant);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.OK));
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
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.OK));
            Assert.That(response.Value.OperationContext, Is.EqualTo(OperationContext));
        }

        [TestCaseSource(nameof(TestData_MuteParticipant))]
        public async Task MuteParticipantAsync_200Accepted(CommunicationIdentifier participant)
        {
            var callConnection = CreateMockCallConnection(200, OperationContextPayload);

            var response = await callConnection.MuteParticipantAsync(participant);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.OK));
        }

        [Test]
        public void MuteParticipantAsync_NotAcsUser_400BadRequest()
        {
            var callConnection = CreateMockCallConnection(400);
            var participant = new PhoneNumberIdentifier("+15559501234");
            Assert.ThrowsAsync(typeof(RequestFailedException), async () => await callConnection.MuteParticipantAsync(participant));
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
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.OK));
            Assert.That(response.Value.OperationContext, Is.EqualTo(OperationContext));
        }

        [TestCaseSource(nameof(TestData_MuteParticipant))]
        public void MuteParticipantAsync_WithOptions_MoreThanOneParticipant_400BadRequest(CommunicationIdentifier participant)
        {
            var callConnection = CreateMockCallConnection(400);
            var options = new MuteParticipantOptions(participant)
            {
                OperationContext = OperationContext,
            };

            Assert.ThrowsAsync(typeof(RequestFailedException), async () => await callConnection.MuteParticipantAsync(options));
        }

        [Test]
        public async Task CancelAddParticipantAsync_202Accepted()
        {
            var callConnection = CreateMockCallConnection(202, CancelAddParticipantPayload);
            var invitationId = "invitationId";

            var response = await callConnection.CancelAddParticipantOperationAsync(invitationId).ConfigureAwait(false);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            Assert.That(response.Value.InvitationId, Is.EqualTo(invitationId));
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant_MicrosoftTeamsApp))]
        public async Task TransferCallToParticipantAsync_MicrosoftTeamsAppIdentifier_simpleMethod_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = await callConnection.TransferCallToParticipantAsync(callInvite.Target).ConfigureAwait(false);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            verifyOperationContext(response);

            // Verify the target is correctly typed as MicrosoftTeamsAppIdentifier
            Assert.That(callInvite.Target, Is.InstanceOf<MicrosoftTeamsAppIdentifier>());
            var teamsApp = callInvite.Target as MicrosoftTeamsAppIdentifier;
            Assert.That(teamsApp, Is.Not.Null);
            Assert.That(teamsApp!.AppId, Is.EqualTo("testAppId"));
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant_MicrosoftTeamsApp))]
        public void TransferCallToParticipant_MicrosoftTeamsAppIdentifier_simpleMethod_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = callConnection.TransferCallToParticipant(callInvite.Target);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            verifyOperationContext(response);

            // Verify the target is correctly typed as MicrosoftTeamsAppIdentifier
            Assert.That(callInvite.Target, Is.InstanceOf<MicrosoftTeamsAppIdentifier>());
            var teamsApp = callInvite.Target as MicrosoftTeamsAppIdentifier;
            Assert.That(teamsApp, Is.Not.Null);
            Assert.That(teamsApp!.AppId, Is.EqualTo("testAppId"));
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant_MicrosoftTeamsApp))]
        public async Task TransferCallToParticipantAsync_MicrosoftTeamsAppIdentifier_WithOptions_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var options = new TransferToParticipantOptions(callInvite.Target as MicrosoftTeamsAppIdentifier);

            var response = await callConnection.TransferCallToParticipantAsync(options).ConfigureAwait(false);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            verifyOperationContext(response);

            // Verify the options were created correctly
            Assert.That(options.Target, Is.InstanceOf<MicrosoftTeamsAppIdentifier>());
            Assert.That(options.CustomCallingContext, Is.Not.Null);
            Assert.That(options.CustomCallingContext.SipHeaders, Is.Empty);
            Assert.That(options.CustomCallingContext.VoipHeaders, Is.Not.Null);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant_MicrosoftTeamsApp))]
        public void TransferCallToParticipant_MicrosoftTeamsAppIdentifier_WithOptions_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var options = new TransferToParticipantOptions(callInvite.Target as MicrosoftTeamsAppIdentifier);

            var response = callConnection.TransferCallToParticipant(options);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            verifyOperationContext(response);

            // Verify the options were created correctly
            Assert.That(options.Target, Is.InstanceOf<MicrosoftTeamsAppIdentifier>());
            Assert.That(options.CustomCallingContext, Is.Not.Null);
            Assert.That(options.CustomCallingContext.SipHeaders, Is.Empty);
            Assert.That(options.CustomCallingContext.VoipHeaders, Is.Not.Null);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant_MicrosoftTeamsAppWithCloud))]
        public async Task TransferCallToParticipantAsync_MicrosoftTeamsAppIdentifier_DifferentClouds_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = await callConnection.TransferCallToParticipantAsync(callInvite.Target).ConfigureAwait(false);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            verifyOperationContext(response);

            // Verify the target maintains the correct cloud environment
            Assert.That(callInvite.Target, Is.InstanceOf<MicrosoftTeamsAppIdentifier>());
            var teamsApp = callInvite.Target as MicrosoftTeamsAppIdentifier;
            Assert.That(teamsApp, Is.Not.Null);
            Assert.That(teamsApp!.AppId, Is.EqualTo("testAppId"));
            Assert.That(teamsApp.Cloud == CommunicationCloudEnvironment.Public ||
                         teamsApp.Cloud == CommunicationCloudEnvironment.Dod ||
                         teamsApp.Cloud == CommunicationCloudEnvironment.Gcch, Is.True);
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant_MicrosoftTeamsAppWithCloud))]
        public void TransferCallToParticipant_MicrosoftTeamsAppIdentifier_DifferentClouds_202Accepted(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);

            var response = callConnection.TransferCallToParticipant(callInvite.Target);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            verifyOperationContext(response);

            // Verify the target maintains the correct cloud environment
            Assert.That(callInvite.Target, Is.InstanceOf<MicrosoftTeamsAppIdentifier>());
            var teamsApp = callInvite.Target as MicrosoftTeamsAppIdentifier;
            Assert.That(teamsApp, Is.Not.Null);
            Assert.That(teamsApp!.AppId, Is.EqualTo("testAppId"));
            Assert.That(teamsApp.Cloud == CommunicationCloudEnvironment.Public ||
                         teamsApp.Cloud == CommunicationCloudEnvironment.Dod ||
                         teamsApp.Cloud == CommunicationCloudEnvironment.Gcch, Is.True);
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
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            verifyOperationContext(response);

            // Verify all optional properties can be set
            Assert.That(options.Transferee, Is.Not.Null);
            Assert.That(options.OperationCallbackUri, Is.Not.Null);
            Assert.That(options.SourceCallerIdNumber, Is.Not.Null);
            Assert.That(options.OperationContext, Is.EqualTo("custom-context"));
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
            Assert.That(response.GetRawResponse().Status, Is.EqualTo((int)HttpStatusCode.Accepted));
            verifyOperationContext(response);

            // Verify all optional properties can be set
            Assert.That(options.Transferee, Is.Not.Null);
            Assert.That(options.OperationCallbackUri, Is.Not.Null);
            Assert.That(options.SourceCallerIdNumber, Is.Not.Null);
            Assert.That(options.OperationContext, Is.EqualTo("custom-context"));
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant_MicrosoftTeamsApp))]
        public void TransferCallToParticipantAsync_MicrosoftTeamsAppIdentifier_404NotFound(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(async () => await callConnection.TransferCallToParticipantAsync(new TransferToParticipantOptions(callInvite.Target as MicrosoftTeamsAppIdentifier)).ConfigureAwait(false));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [TestCaseSource(nameof(TestData_TransferCallToParticipant_MicrosoftTeamsApp))]
        public void TransferCallToParticipant_MicrosoftTeamsAppIdentifier_404NotFound(CallInvite callInvite)
        {
            var callConnection = CreateMockCallConnection(404);

            RequestFailedException? ex = Assert.Throws<RequestFailedException>(() => callConnection.TransferCallToParticipant(new TransferToParticipantOptions(callInvite.Target as MicrosoftTeamsAppIdentifier)));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex?.Status, Is.EqualTo(404));
        }

        [Test]
        public void TransferCallToParticipantAsync_NullMicrosoftTeamsAppIdentifier_ThrowsArgumentNullException()
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);
            MicrosoftTeamsAppIdentifier? nullTeamsAppIdentifier = null;

            ArgumentNullException? ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await callConnection.TransferCallToParticipantAsync(nullTeamsAppIdentifier!).ConfigureAwait(false));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex!.ParamName, Is.EqualTo("targetParticipant"));
        }

        [Test]
        public void TransferCallToParticipant_NullMicrosoftTeamsAppIdentifier_ThrowsArgumentNullException()
        {
            var callConnection = CreateMockCallConnection(202, OperationContextPayload);
            MicrosoftTeamsAppIdentifier? nullTeamsAppIdentifier = null;

            ArgumentNullException? ex = Assert.Throws<ArgumentNullException>(() => callConnection.TransferCallToParticipant(nullTeamsAppIdentifier!));
            Assert.That(ex, Is.Not.Null);
            Assert.That(ex!.ParamName, Is.EqualTo("targetParticipant"));
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
            Assert.That(result.OperationContext, Is.EqualTo(OperationContext));
        }

        private void verifyAddParticipantsResult(AddParticipantResult result)
        {
            var identifier = (CommunicationUserIdentifier)result.Participant.Identifier;
            Assert.That(identifier.Id, Is.EqualTo(ParticipantUserId));
            Assert.That(result.Participant.IsMuted, Is.False);
            Assert.That(result.OperationContext, Is.EqualTo(OperationContext));
        }

        private void verifyGetParticipantResult(CallParticipant participant)
        {
            var identifier = (CommunicationUserIdentifier)participant.Identifier;
            Assert.That(identifier.Id, Is.EqualTo(ParticipantUserId));
            Assert.That(participant.IsMuted, Is.False);
        }

        private void verifyGetParticipantsResult(IReadOnlyList<CallParticipant> participants)
        {
            Assert.That(participants.Count, Is.EqualTo(2));
            var identifier = (CommunicationUserIdentifier)participants[0].Identifier;
            Assert.That(identifier.Id, Is.EqualTo(ParticipantUserId));
            Assert.That(participants[0].IsMuted, Is.False);
            var identifier2 = (PhoneNumberIdentifier)participants[1].Identifier;
            Assert.That(identifier2.PhoneNumber, Is.EqualTo(PhoneNumber));
            Assert.That(participants[1].IsMuted, Is.True);
        }
    }
}
