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

            try
            {
                // Play Prompt Audio
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await PlayAudioOperation(callConnection).ConfigureAwait(false);

                // Cancel Prompt Audio
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
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
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
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

                // Add Participant
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                AddParticipantResult addParticipantResult = await AddParticipantOperation(callConnection, userId).ConfigureAwait(false);
                Assert.NotNull(addParticipantResult);

                // Remove Participant
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
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
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
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

                // Add Participant
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                AddParticipantResult addParticipantResult = await AddParticipantOperation(callConnection, userId).ConfigureAwait(false);
                Assert.NotNull(addParticipantResult);

                // Mute Participant
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await MuteParticipantOperation(callConnection, userId).ConfigureAwait(false);

                // Get Participant
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                var getMutedParticipant = await GetParticipantOperation(callConnection, userId).ConfigureAwait(false);
                Assert.IsTrue(getMutedParticipant.IsMuted == true);

                // Unmute Participant
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await UnmuteParticipantOperation(callConnection, userId).ConfigureAwait(false);

                // Get Participant
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                var getUnmutedParticipant = await GetParticipantOperation(callConnection, userId).ConfigureAwait(false);
                Assert.IsTrue(getUnmutedParticipant.IsMuted == false);

                // Get Participants
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                var getParticipants = await GetParticipantsOperation(callConnection).ConfigureAwait(false);
                Assert.IsTrue(getParticipants.Count() > 2);

                // Remove Participant
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
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
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
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

                // Add Participant
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                AddParticipantResult addParticipantResult = await AddParticipantOperation(callConnection, userId).ConfigureAwait(false);
                Assert.NotNull(addParticipantResult);

                // Get Call
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                var getCallConnection = await GetCallOperation(callConnection).ConfigureAwait(false);
                Assert.AreEqual(getCallConnection.CallConnectionId, callConnection.Value.CallConnectionId);

                // Hold Participant
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await HoldParticipantOperation(callConnection, userId).ConfigureAwait(false);

                // Resume Participant
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await ResumeParticipantOperation(callConnection, userId).ConfigureAwait(false);

                // Remove Participant
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
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
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
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

            try
            {
                // Keep Alive
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await KeepAliveOperation(callConnection).ConfigureAwait(false);

                // Delete Call
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
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

                // Transfer Call
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
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

                // Transfer Call
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
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

                // Add Participant
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                AddParticipantResult addParticipantResult = await AddParticipantOperation(callConnection, userId).ConfigureAwait(false);
                Assert.NotNull(addParticipantResult);

                // Play Audio To Participant
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                var playAudioResult = await PlayAudioToParticipantOperation(callConnection, userId).ConfigureAwait(false);

                // Cancel Participant Media Operation
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                string mediaOperationId = playAudioResult.OperationId;
                await CancelParticipantMediaOperation(callConnection, userId, mediaOperationId).ConfigureAwait(false);

                // Remove Participant
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
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
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await HangupOperation(callConnection).ConfigureAwait(false);
            }
        }
    }
}
