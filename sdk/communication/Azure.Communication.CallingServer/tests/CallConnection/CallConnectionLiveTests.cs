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

            // Establish a Call
            var callConnection = await CreateCallConnectionOperation(client).ConfigureAwait(false);

            await WaitForOperationCompletion().ConfigureAwait(false);

            try
            {
                // Play Prompt Audio
                await PlayAudioOperation(callConnection).ConfigureAwait(false);

                await WaitForOperationCompletion().ConfigureAwait(false);

                // Cancel Prompt Audio
                await CancelAllMediaOperationsOperation(callConnection).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                // Hang up the Call, there is one call leg in this test case, hangup the call will also delete the call as the result.
                await WaitForOperationCompletion().ConfigureAwait(false);
                await HangupOperation(callConnection).ConfigureAwait(false);
            }
        }

        [Test]
        public async Task RunCreateAddRemoveHangupScenarioTests()
        {
            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

            CallingServerClient client = CreateInstrumentedCallingServerClientWithConnectionString();

            // Establish a call
            var callConnection = await CreateCallConnectionOperation(client).ConfigureAwait(false);

            try
            {
                string userId = GetFixedUserId(TestEnvironment.UserIdentifier);
                await WaitForOperationCompletion().ConfigureAwait(false);

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
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                // Hang up the Call, there is one call leg in this test case, hangup the call will also delete the call as the result.
                await WaitForOperationCompletion().ConfigureAwait(false);
                await HangupOperation(callConnection).ConfigureAwait(false);
            }
        }

        [Test]
        public async Task RunCreateAddMuteGetParticipntRemoveHangupScenarioTests()
        {
            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

            CallingServerClient client = CreateInstrumentedCallingServerClientWithConnectionString();

            // Establish a call
            var callConnection = await CreateCallConnectionOperation(client).ConfigureAwait(false);

            try
            {
                string userId = GetFixedUserId(TestEnvironment.UserIdentifier);
                await WaitForOperationCompletion().ConfigureAwait(false);

                // Add Participant
                AddParticipantResult addParticipantResult = await AddParticipantOperation(callConnection, userId).ConfigureAwait(false);
                Assert.NotNull(addParticipantResult);

                await WaitForOperationCompletion().ConfigureAwait(false);

                // Mute Participant
                await MuteParticipantOperation(callConnection, userId).ConfigureAwait(false);

                // Get Muted Participant
                var getMutedParticipant = await GetParticipantOperation(callConnection, userId).ConfigureAwait(false);
                Assert.IsTrue(getMutedParticipant.IsMuted == true);

                // Unmute Participant
                await UnmuteParticipantOperation(callConnection, userId).ConfigureAwait(false);

                // Get Unmuted Participant
                var getUnmutedParticipant = await GetParticipantOperation(callConnection, userId).ConfigureAwait(false);
                Assert.IsTrue(getUnmutedParticipant.IsMuted == false);

                // Get All Participants
                var getParticipants = await GetParticipantsOperation(callConnection).ConfigureAwait(false);
                Assert.IsTrue(getParticipants.Count() > 2);

                // Remove Participant
                await RemoveParticipantOperation(callConnection, userId).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                // Hang up the Call, there is one call leg in this test case, hangup the call will also delete the call as the result.
                await WaitForOperationCompletion().ConfigureAwait(false);
                await HangupOperation(callConnection).ConfigureAwait(false);
            }
        }

        [Test]
        public async Task RunCreateAddHoldResumeAudioRemoveHangupScenarioTests()
        {
            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

            CallingServerClient client = CreateInstrumentedCallingServerClientWithConnectionString();

            // Establish a call
            var callConnection = await CreateCallConnectionOperation(client).ConfigureAwait(false);

            try
            {
                string userId = GetFixedUserId(TestEnvironment.UserIdentifier);
                await WaitForOperationCompletion().ConfigureAwait(false);

                // Add Participant
                AddParticipantResult addParticipantResult = await AddParticipantOperation(callConnection, userId).ConfigureAwait(false);
                Assert.NotNull(addParticipantResult);

                await WaitForOperationCompletion().ConfigureAwait(false);

                // Get Call
                var getCallConnection = await GetCallOperation(callConnection).ConfigureAwait(false);
                Assert.AreEqual(getCallConnection.CallConnectionId, callConnection.Value.CallConnectionId);

                // Hold Participant
                await HoldParticipantOperation(callConnection, userId).ConfigureAwait(false);

                await WaitForOperationCompletion().ConfigureAwait(false);

                // Resume Participant
                await ResumeParticipantOperation(callConnection, userId).ConfigureAwait(false);

                // Remove Participant
                await RemoveParticipantOperation(callConnection, userId).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                // Hang up the Call, there is one call leg in this test case, hangup the call will also delete the call as the result.
                await WaitForOperationCompletion().ConfigureAwait(false);
                await HangupOperation(callConnection).ConfigureAwait(false);
            }
        }

        [Test]
        public async Task RunCreateKeepAliveHangupScenarioTests()
        {
            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

            CallingServerClient client = CreateInstrumentedCallingServerClientWithConnectionString();

            // Establish a call
            var callConnection = await CreateCallConnectionOperation(client).ConfigureAwait(false);

            await WaitForOperationCompletion().ConfigureAwait(false);

            try
            {
                // Keep Alive
                await KeepAliveOperation(callConnection).ConfigureAwait(false);

                await WaitForOperationCompletion().ConfigureAwait(false);

                // Delete Call
                await DeleteCallOperation(callConnection).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
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

            // Establish a call
            var callConnection = await CreateCallConnectionOperation(client).ConfigureAwait(false);

            try
            {
                string targetParticipant = GetFixedUserId(TestEnvironment.UserIdentifier);
                await WaitForOperationCompletion().ConfigureAwait(false);

                // Transfer Call
                await TransferCallToParticipantOperation(callConnection, targetParticipant).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        [Ignore("Skip test as it is not working now")]
        public async Task RunCreateTransferCallHangupScenarioTests()
        {
            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

            CallingServerClient client = CreateInstrumentedCallingServerClientWithConnectionString();

            // Establish a call
            var callConnection = await CreateCallConnectionOperation(client).ConfigureAwait(false);

            try
            {
                string targetCallConnectionId = TestEnvironment.TargetCallConnectionIdentifier;
                await WaitForOperationCompletion().ConfigureAwait(false);

                // Transfer Call
                var transferCallResult = await TransferCallOperation(callConnection, targetCallConnectionId).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
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

            // Establish a call
            var callConnection = await CreateCallConnectionOperation(client).ConfigureAwait(false);

            try
            {
                string userId = GetFixedUserId(TestEnvironment.UserIdentifier);
                await WaitForOperationCompletion().ConfigureAwait(false);

                // Add Participant
                AddParticipantResult addParticipantResult = await AddParticipantOperation(callConnection, userId).ConfigureAwait(false);
                Assert.NotNull(addParticipantResult);

                // Play Audio To Participant
                var playAudioResult = await PlayAudioToParticipantOperation(callConnection, userId).ConfigureAwait(false);

                await WaitForOperationCompletion().ConfigureAwait(false);

                // Cancel Participant Media Operation
                string mediaOperationId = playAudioResult.OperationId;
                await CancelParticipantMediaOperation(callConnection, userId, mediaOperationId).ConfigureAwait(false);

                // Remove Participant
                await RemoveParticipantOperation(callConnection, userId).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                // Hang up the Call, there is one call leg in this test case, hangup the call will also delete the call as the result.
                await WaitForOperationCompletion().ConfigureAwait(false);
                await HangupOperation(callConnection).ConfigureAwait(false);
            }
        }

        [Test]
        [Ignore("Skip test as it is not working now")]
        public async Task RunCreateAddCreateAudioRoutingRemoveHangupScenarioTests()
        {
            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

            CallingServerClient client = CreateInstrumentedCallingServerClientWithConnectionString();

            // Establish a call
            var callConnection = await CreateCallConnectionOperation(client).ConfigureAwait(false);

            try
            {
                string userId = GetFixedUserId(TestEnvironment.UserIdentifier);
                string anotherUserId = GetFixedUserId(TestEnvironment.AnotherUserIdentifier);
                await WaitForOperationCompletion().ConfigureAwait(false);

                // Add Participant
                AddParticipantResult addParticipantResult = await AddParticipantOperation(callConnection, userId).ConfigureAwait(false);
                Assert.NotNull(addParticipantResult);

                await WaitForOperationCompletion().ConfigureAwait(false);

                // Creating List And Adding Participant
                List<CommunicationUserIdentifier> participantList = new List<CommunicationUserIdentifier>();
                participantList.Add(new CommunicationUserIdentifier(userId));

                //Create Audio Routing Group
                var createAudioRoutingResult = await CreateAudioRoutingGroupOperation(callConnection, participantList).ConfigureAwait(false);
                string audioRoutingGroupId = createAudioRoutingResult.AudioRoutingGroupId;

                // Get Audio Routing Group
                var getAudioRoutingResult = await GetAudioRoutingGroupOperation(callConnection, audioRoutingGroupId).ConfigureAwait(false);
                Assert.IsTrue(getAudioRoutingResult.AudioRoutingMode == AudioRoutingMode.Multicast);
                foreach (var target in getAudioRoutingResult.Targets)
                {
                    Assert.IsTrue(target.ToString() == userId);
                }

                await WaitForOperationCompletion().ConfigureAwait(false);

                // Add Another Participant
                AddParticipantResult addAnotherParticipantResult = await AddParticipantOperation(callConnection, anotherUserId).ConfigureAwait(false);
                Assert.NotNull(addAnotherParticipantResult);

                await WaitForOperationCompletion().ConfigureAwait(false);

                // Creating Another List And Adding Participant
                List<CommunicationUserIdentifier> participantsList = new List<CommunicationUserIdentifier>();
                participantsList.Add(new CommunicationUserIdentifier(anotherUserId));

                // Update Audio Routing Group
                await UpdateAudioRoutingGroupOperation(callConnection, audioRoutingGroupId, participantsList).ConfigureAwait(false);

                // Get Audio Routing Group
                var getUpdatedAudioRoutingResult = await GetAudioRoutingGroupOperation(callConnection, audioRoutingGroupId).ConfigureAwait(false);
                Assert.IsTrue(getUpdatedAudioRoutingResult.AudioRoutingMode == AudioRoutingMode.Multicast);
                foreach (var target in getUpdatedAudioRoutingResult.Targets)
                {
                    Assert.IsTrue(target.ToString() == anotherUserId);
                }

                // Delete Audio Routing Group
                await DeleteAudioRoutingGroupOperation(callConnection, audioRoutingGroupId).ConfigureAwait(false);

                // Remove Participant
                await RemoveParticipantOperation(callConnection, userId).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                // Hang up the Call, there is one call leg in this test case, hangup the call will also delete the call as the result.
                await WaitForOperationCompletion().ConfigureAwait(false);
                await HangupOperation(callConnection).ConfigureAwait(false);
            }
        }
    }
}
