// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Communication.CallingServer.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="CallConnection"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class ServerCallLiveTests : CallingServerLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CallingServerClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public ServerCallLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task RunAllRecordingFunctionsScenarioTests()
        {
            CallingServerClient callingServerClient = CreateInstrumentedCallingServerClient();
            var groupId = GetGroupId();
            try
            {
                // Establish a Call
                var callConnections = await CreateGroupCallOperation(callingServerClient, groupId, GetFromUserId(), GetToUserId(), TestEnvironment.AppCallbackUrl).ConfigureAwait(false);
                var serverCall = callingServerClient.InitializeServerCall(groupId);

                // Start Recording
                StartCallRecordingResult startCallRecordingResult = await serverCall.StartRecordingAsync(new Uri(TestEnvironment.AppCallbackUrl)).ConfigureAwait(false);
                var recordingId = startCallRecordingResult.RecordingId;
                await ValidateCallRecordingStateAsync(serverCall, recordingId, CallRecordingState.Active).ConfigureAwait(false);

                // Pause Recording
                await serverCall.PauseRecordingAsync(recordingId).ConfigureAwait(false);
                await ValidateCallRecordingStateAsync(serverCall, recordingId, CallRecordingState.Inactive).ConfigureAwait(false);

                // Resume Recording
                await serverCall.ResumeRecordingAsync(recordingId).ConfigureAwait(false);
                await ValidateCallRecordingStateAsync(serverCall, recordingId, CallRecordingState.Active).ConfigureAwait(false);

                // Stop Recording
                await serverCall.StopRecordingAsync(recordingId).ConfigureAwait(false);

                // Get Recording StateAsync
                Assert.ThrowsAsync<RequestFailedException>(async () => await serverCall.GetRecordingStateAsync(recordingId).ConfigureAwait(false));

                // Hang up the Call, there is one call leg in this test case, hangup the call will also delete the call as the result.
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await CleanUpConnectionsAsync(callConnections).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task RunCreatePlayCancelHangupScenarioTests()
        {
            CallingServerClient callingServerClient = CreateInstrumentedCallingServerClient();
            var groupId = GetGroupId();
            try
            {
                // Establish a Call
                var callConnections = await CreateGroupCallOperation(callingServerClient, groupId, GetFromUserId(), GetToUserId(), TestEnvironment.AppCallbackUrl).ConfigureAwait(false);
                var serverCall = callingServerClient.InitializeServerCall(groupId);

                // Play Prompt Audio
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await PlayAudioOperation(serverCall).ConfigureAwait(false);

                // Cancel Prompt Audio
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await CancelAllMediaOperationsOperation(callConnections).ConfigureAwait(false);

                // Hang up the Call, there is one call leg in this test case, hangup the call will also delete the call as the result.
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await CleanUpConnectionsAsync(callConnections).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task RunCreateAddRemoveHangupScenarioTests()
        {
            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

            CallingServerClient callingServerClient = CreateInstrumentedCallingServerClient();
            var groupId = GetGroupId();
            try
            {
                // Establish a Call
                var callConnections = await CreateGroupCallOperation(callingServerClient, groupId, GetFromUserId(), GetToUserId(), TestEnvironment.AppCallbackUrl).ConfigureAwait(false);
                var serverCall = callingServerClient.InitializeServerCall(groupId);

                // Add Participant
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                var participantId = await AddParticipantOperation(serverCall).ConfigureAwait(false);

                // Remove Participant
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await RemoveParticipantOperation(serverCall, participantId).ConfigureAwait(false);

                // Hang up the Call, there is one call leg in this test case, hangup the call will also delete the call as the result.
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await CleanUpConnectionsAsync(callConnections).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }
    }
}
