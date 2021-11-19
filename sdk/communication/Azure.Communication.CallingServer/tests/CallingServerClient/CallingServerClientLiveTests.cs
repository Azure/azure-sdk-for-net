// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.CallingServer.Models;
using Azure.Communication.Tests;
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
    public class CallingServerClientLiveTests : CallingServerLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CallingServerClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public CallingServerClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [TestCase(AuthMethod.ConnectionString, TestName = "RunAllRecordingFunctionsWithConnectionString")]
        [TestCase(AuthMethod.TokenCredential, TestName = "RunAllRecordingFunctionsWithTokenCredential")]
        public async Task RunAllRecordingFunctionsScenarioTests(AuthMethod authMethod)
        {
            CallingServerClient callingServerClient = authMethod switch
            {
                AuthMethod.ConnectionString => CreateInstrumentedCallingServerClientWithConnectionString(),
                AuthMethod.TokenCredential => CreateInstrumentedCallingServerClientWithToken(),
                _ => throw new ArgumentOutOfRangeException(nameof(authMethod)),
            };

            var groupId = GetGroupId();
            try
            {
                // Establish a Call
                var callConnections = await CreateGroupCallOperation(callingServerClient, groupId, GetFromUserId(), GetToUserId(), TestEnvironment.AppCallbackUrl).ConfigureAwait(false);
                var callLocator = new GroupCallLocator(groupId);

                // Start Recording
                StartCallRecordingResult startCallRecordingResult = await callingServerClient.StartRecordingAsync(callLocator, new Uri(TestEnvironment.AppCallbackUrl)).ConfigureAwait(false);
                var recordingId = startCallRecordingResult.RecordingId;
                await ValidateCallRecordingStateAsync(callingServerClient, recordingId, CallRecordingState.Active).ConfigureAwait(false);

                // Pause Recording
                await callingServerClient.PauseRecordingAsync(recordingId).ConfigureAwait(false);
                await ValidateCallRecordingStateAsync(callingServerClient, recordingId, CallRecordingState.Inactive).ConfigureAwait(false);

                // Resume Recording
                await callingServerClient.ResumeRecordingAsync(recordingId).ConfigureAwait(false);
                await ValidateCallRecordingStateAsync(callingServerClient, recordingId, CallRecordingState.Active).ConfigureAwait(false);

                // Stop Recording
                await callingServerClient.StopRecordingAsync(recordingId).ConfigureAwait(false);

                // Get Recording StateAsync
                Assert.ThrowsAsync<RequestFailedException>(async () => await callingServerClient.GetRecordingStateAsync(recordingId).ConfigureAwait(false));

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
            CallingServerClient callingServerClient = CreateInstrumentedCallingServerClientWithConnectionString();
            var groupId = GetGroupId();

            // Establish a Call
            var callConnections = await CreateGroupCallOperation(callingServerClient, groupId, GetFromUserId(), GetToUserId(), TestEnvironment.AppCallbackUrl).ConfigureAwait(false);

            try
            {
                var callLocator = new GroupCallLocator(groupId);

                // Play Prompt Audio
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await PlayAudioOperation(callingServerClient, callLocator).ConfigureAwait(false);

                // Cancel Prompt Audio
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await CancelAllMediaOperationsOperation(callConnections).ConfigureAwait(false);
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
            finally
            {
                // Hang up the Call, there is one call leg in this test case, hangup the call will also delete the call as the result.
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await CleanUpConnectionsAsync(callConnections).ConfigureAwait(false);
            }
        }

        [Test]
        public async Task RunCreateAddRemoveHangupScenarioTests()
        {
            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

            CallingServerClient callingServerClient = CreateInstrumentedCallingServerClientWithConnectionString();
            var groupId = GetGroupId();

            // Establish a Call
            var callConnections = await CreateGroupCallOperation(callingServerClient, groupId, GetFromUserId(), GetToUserId(), TestEnvironment.AppCallbackUrl).ConfigureAwait(false);
            var callLocator = new GroupCallLocator(groupId);

            try
            {
                string userId = GetFixedUserId("0000000d-5e6a-3252-a808-4548220003b8");

                // Add Participant
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                AddParticipantResult addParticipantResult = await AddParticipantOperation(callingServerClient, callLocator, userId).ConfigureAwait(false);
                Assert.NotNull(addParticipantResult);

                // Remove Participant
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await RemoveParticipantOperation(callingServerClient, callLocator, userId).ConfigureAwait(false);
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
            finally
            {
                // Hang up the Call, there is one call leg in this test case, hangup the call will also delete the call as the result.
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await CleanUpConnectionsAsync(callConnections).ConfigureAwait(false);
            }
        }
    }
}
