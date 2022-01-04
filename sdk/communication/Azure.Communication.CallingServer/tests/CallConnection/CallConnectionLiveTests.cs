// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Azure_Communication_ServerCalling_Tests_UsingStatements
using System;
using System.Collections.Generic;
//@@ using Azure.Communication.CallingServer;
#endregion Snippet:Azure_Communication_ServerCalling_Tests_UsingStatements
using Azure.Communication.Identity;

using NUnit.Framework;
using System.Threading.Tasks;
using System.Linq;

namespace Azure.Communication.CallingServer.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="CallConnection"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class CallConnectionLiveTests : CallingServerLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationIdentityClient"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public CallConnectionLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task RunCreatePlayCancelHangupScenarioTests()
        {
            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

            CallingServerClient client = CreateInstrumentedCallingServerClientWithConnectionString();

            CallConnection callConnection = new CallConnection(null, null, null);

            try
            {
                // Establish a Call
                callConnection = await CreateCallConnectionOperation(client).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);

                // Play Prompt Audio
                await PlayAudioOperation(callConnection, true).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);

                // Cancel Prompt Audio
                await CancelAllMediaOperationsOperation(callConnection).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Request failed error: {ex}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                // Hang up the Call, there is one call leg in this test case, hangup the call will also delete the call as the result.
                await HangupOperation(callConnection).ConfigureAwait(false);
            }
        }

        [Test]
        public async Task RunCreateAddRemoveHangupScenarioTests()
        {
            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

            CallingServerClient client = CreateInstrumentedCallingServerClientWithConnectionString();

            CallConnection callConnection = new CallConnection(null, null, null);

            try
            {
                // Establish a Call
                callConnection = await CreateCallConnectionOperation(client).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);

                string userId = GetUserId(USER_IDENTIFIER);

                // Add Participant
                AddParticipantResult addParticipantResult = await AddParticipantOperation(callConnection, userId).ConfigureAwait(false);
                Assert.NotNull(addParticipantResult);
                await WaitForOperationCompletion().ConfigureAwait(false);

                // Remove Participant
                await RemoveParticipantOperation(callConnection, userId).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Request failed error: {ex}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                // Hang up the Call, there is one call leg in this test case, hangup the call will also delete the call as the result.
                await HangupOperation(callConnection).ConfigureAwait(false);
            }
        }

        [Test]
        public async Task RunCreateAddMuteGetParticipntRemoveHangupScenarioTests()
        {
            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

            CallingServerClient client = CreateInstrumentedCallingServerClientWithConnectionString();

            CallConnection callConnection = new CallConnection(null, null, null);

            try
            {
                // Establish a Call
                callConnection = await CreateCallConnectionOperation(client).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);

                string userId = GetUserId(USER_IDENTIFIER);

                // Add Participant
                AddParticipantResult addParticipantResult = await AddParticipantOperation(callConnection, userId).ConfigureAwait(false);
                Assert.NotNull(addParticipantResult);
                await WaitForOperationCompletion().ConfigureAwait(false);

                // Mute Participant
                await MuteParticipant(callConnection, userId).ConfigureAwait(false);

                // Get Muted Participant
                var getMutedParticipant = await GetParticipant(callConnection, userId).ConfigureAwait(false);
                Assert.IsTrue(getMutedParticipant.IsMuted == true);

                // Unmute Participant
                await UnmuteParticipant(callConnection, userId).ConfigureAwait(false);

                // Get Unmuted Participant
                var getUnmutedParticipant = await GetParticipant(callConnection, userId).ConfigureAwait(false);
                Assert.IsTrue(getUnmutedParticipant.IsMuted == false);

                // Get All Participants
                var getParticipants = await GetParticipants(callConnection).ConfigureAwait(false);
                Assert.IsTrue(getParticipants.Count() > 2);

                // Remove Participant
                await RemoveParticipantOperation(callConnection, userId).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Request failed error: {ex}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                // Hang up the Call, there is one call leg in this test case, hangup the call will also delete the call as the result.
                await HangupOperation(callConnection).ConfigureAwait(false);
            }
        }

        [Test]
        public async Task RunCreateAddRemoveFromDefaultAudioGroupAddToDefaultAudioGroupRemoveHangupScenarioTests()
        {
            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

            CallingServerClient client = CreateInstrumentedCallingServerClientWithConnectionString();

            CallConnection callConnection = new CallConnection(null, null, null);

            try
            {
                // Establish a Call
                callConnection = await CreateCallConnectionOperation(client).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);

                string userId = GetUserId(USER_IDENTIFIER);

                // Add Participant
                AddParticipantResult addParticipantResult = await AddParticipantOperation(callConnection, userId).ConfigureAwait(false);
                Assert.NotNull(addParticipantResult);
                await WaitForOperationCompletion().ConfigureAwait(false);

                // Remove Participant from Default Audio Group
                await RemoveParticipantFromDefaultAudioGroupOperation(callConnection, userId).ConfigureAwait(false);

                // Add Participant To Default Audio Group
                var addParticipantToDefaultAudioGroupResult = await AddParticipantToDefaultAudioGroupOperation(callConnection, userId).ConfigureAwait(false);
                Assert.NotNull(addParticipantToDefaultAudioGroupResult);
                await WaitForOperationCompletion().ConfigureAwait(false);

                // Remove Participant
                await RemoveParticipantOperation(callConnection, userId).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Request failed error: {ex}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                // Hang up the Call, there is one call leg in this test case, hangup the call will also delete the call as the result.
                await HangupOperation(callConnection).ConfigureAwait(false);
            }
        }

        [Test]
        public async Task RunCreateKeepAliveHangupScenarioTests()
        {
            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

            CallingServerClient client = CreateInstrumentedCallingServerClientWithConnectionString();

            try
            {
                // Establish a Call
                var callConnection = await CreateCallConnectionOperation(client).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);

                // Keep Alive
                await KeepAlive(callConnection).ConfigureAwait(false);

                // Delete Call
                await DeleteCall(callConnection).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Request failed error: {ex}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task RunCreateTransferToParticipantHangupScenarioTests()
        {
            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

            CallingServerClient client = CreateInstrumentedCallingServerClientWithConnectionString();

            try
            {
                // Establish a Call
                var callConnection = await CreateCallConnectionOperation(client).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);

                string targetParticipant = GetUserId(USER_IDENTIFIER);

                // Transfer Call
                await TransferCallToParticipantOperation(callConnection, targetParticipant).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Request failed error: {ex}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        [Ignore("Skip test as it is not working now")]
        public async Task RunCreateTransferCallScenarioTests()
        {
            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

            CallingServerClient client = CreateInstrumentedCallingServerClientWithConnectionString();

            try
            {
                // Establish a Call
                var callConnection = await CreateCallConnectionOperation(client).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);

                string targetCallConnectionId = GetTargetCallConnectionId();

                // Transfer Call
                var transferCallResult = await TransferCallOperation(callConnection, targetCallConnectionId).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Request failed error: {ex}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task RunCreateAddPlayAudioToParticipantRemoveHangupScenarioTests()
        {
            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

            CallingServerClient client = CreateInstrumentedCallingServerClientWithConnectionString();

            CallConnection callConnection = new CallConnection(null, null, null);

            try
            {
                // Establish a Call
                callConnection = await CreateCallConnectionOperation(client).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);

                string userId = GetUserId(USER_IDENTIFIER);

                // Add Participant
                AddParticipantResult addParticipantResult = await AddParticipantOperation(callConnection, userId).ConfigureAwait(false);
                Assert.NotNull(addParticipantResult);
                await WaitForOperationCompletion().ConfigureAwait(false);

                // Get Call
                var getCallConnection = await GetCall(callConnection).ConfigureAwait(false);
                Assert.AreEqual(getCallConnection.CallConnectionId, callConnection.CallConnectionId);

                // Play Audio To Participant
                var playAudioResult = await PlayAudioToParticipantOperation(callConnection, userId, true).ConfigureAwait(false);
                string mediaOperationId = playAudioResult.OperationId;
                await WaitForOperationCompletion().ConfigureAwait(false);

                // Cancel Participant Media Operation
                await CancelParticipantMediaOperation(callConnection, userId, mediaOperationId).ConfigureAwait(false);

                // Remove Participant
                await RemoveParticipantOperation(callConnection, userId).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Request failed error: {ex}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                // Hang up the Call, there is one call leg in this test case, hangup the call will also delete the call as the result.
                await HangupOperation(callConnection).ConfigureAwait(false);
            }
        }

        [Test]
        public async Task RunCreateAddCreateAudioGroupRemoveHangupScenarioTests()
        {
            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

            CallingServerClient client = CreateInstrumentedCallingServerClientWithConnectionString();

            CallConnection callConnection = new CallConnection(null, null, null);

            try
            {
                // Establish a Call
                callConnection = await CreateCallConnectionOperation(client).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);

                string userId = GetUserId(USER_IDENTIFIER);
                string anotherUserId = GetUserId(ANOTHER_USER_IDENTIFIER);

                // Add Participant
                AddParticipantResult addParticipantResult = await AddParticipantOperation(callConnection, userId).ConfigureAwait(false);
                Assert.NotNull(addParticipantResult);
                await WaitForOperationCompletion().ConfigureAwait(false);

                // Creating List And Adding Participant
                List<CommunicationUserIdentifier> participantList = new List<CommunicationUserIdentifier>();
                participantList.Add(new CommunicationUserIdentifier(userId));

                //Create Audio Group
                var createAudioGroupResult = await CreateAudioGroupOperation(callConnection, participantList).ConfigureAwait(false);
                string audioGroupId = createAudioGroupResult.AudioGroupId;

                // Get Audio Group
                var getAudioGroupResult = await GetAudioGroupOperation(callConnection, audioGroupId).ConfigureAwait(false);
                Assert.IsTrue(getAudioGroupResult.AudioRoutingMode == AudioRoutingMode.Multicast);
                Assert.NotNull(getAudioGroupResult);

                // Add Another Participant
                AddParticipantResult addAnotherParticipantResult = await AddParticipantOperation(callConnection, anotherUserId).ConfigureAwait(false);
                Assert.NotNull(addAnotherParticipantResult);
                await WaitForOperationCompletion().ConfigureAwait(false);

                // Creating Another List And Adding Participant
                List<CommunicationUserIdentifier> participantsList = new List<CommunicationUserIdentifier>();
                participantsList.Add(new CommunicationUserIdentifier(anotherUserId));

                // Update Audio Group
                await UpdateAudioGroupOperation(callConnection, audioGroupId, participantsList).ConfigureAwait(false);

                // Get Audio Group
                var getUpdatedAudioGroupResult = await GetAudioGroupOperation(callConnection, audioGroupId).ConfigureAwait(false);
                Assert.IsTrue(getUpdatedAudioGroupResult.AudioRoutingMode == AudioRoutingMode.Multicast);
                Assert.NotNull(getUpdatedAudioGroupResult);

                // Delete Audio Group
                await DeleteAudioGroupOperation(callConnection, audioGroupId).ConfigureAwait(false);

                // Remove First Added Participant
                await RemoveParticipantOperation(callConnection, userId).ConfigureAwait(false);

                // Remove Another Participant
                await RemoveParticipantOperation(callConnection, anotherUserId).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Request failed error: {ex}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                // Hang up the Call, there is one call leg in this test case, hangup the call will also delete the call as the result.
                await HangupOperation(callConnection).ConfigureAwait(false);
            }
        }
    }
}
