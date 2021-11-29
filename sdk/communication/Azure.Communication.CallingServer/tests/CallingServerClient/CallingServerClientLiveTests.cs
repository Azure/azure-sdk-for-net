// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Linq;
using Azure.Communication.CallingServer.Models;
using Azure.Communication.Tests;
using NUnit.Framework;
using System.Text.RegularExpressions;

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
                string userId = GetFixedUserId(TestEnvironment.UserIdentifier);

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

        [Test]
        public async Task RunDeleteSuccessScenarioTests()
        {
            CallingServerClient callingServerClient = CreateInstrumentedCallingServerClientWithConnectionString();

            try
            {
                if (IsAsync)
                {
                    var deleteUrl = new Uri(GetAsyncDeleteUrl());

                    // Delete Recording
                    var deleteResponse = await callingServerClient.DeleteRecordingAsync(deleteUrl).ConfigureAwait(false);
                    Assert.NotNull(deleteResponse);
                    Assert.IsTrue(deleteResponse.Status == 200);
                }
                else
                {
                    var deleteUrl = new Uri(GetDeleteUrl());

                    // Delete Recording
                    var deleteResponse = await callingServerClient.DeleteRecordingAsync(deleteUrl).ConfigureAwait(false);
                    Assert.NotNull(deleteResponse);
                    Assert.IsTrue(deleteResponse.Status == 200);
                }
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
        public async Task RunDeleteContentNotExistScenarioTests()
        {
            CallingServerClient callingServerClient = CreateInstrumentedCallingServerClientWithConnectionString();

            try
            {
                var deleteUrl = new Uri(GetInvalidDeleteUrl());

                // Delete Recording
                var deleteResponse = await callingServerClient.DeleteRecordingAsync(deleteUrl).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Pass($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task RunCreateAddGetParticipantHangupScenarioTests()
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
                foreach (var callConnection in callConnections)
                {
                    var getCallConnection = callingServerClient.GetCallConnection(callConnection.CallConnectionId);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(getCallConnection.CallConnectionId));
                }

                string userId = GetFixedUserId(TestEnvironment.UserIdentifier);

                // Add Participant
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                AddParticipantResult addParticipantResult = await AddParticipantOperation(callingServerClient, callLocator, userId).ConfigureAwait(false);
                Assert.NotNull(addParticipantResult);

                // Get Participant
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                var getParticipant = await GetParticipantOperation(callingServerClient, callLocator, userId).ConfigureAwait(false);
                Assert.IsTrue(getParticipant.Identifier.ToString() == userId);

                // Get Participants
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                var getParticipants = await GetParticipantsOperation(callingServerClient, callLocator).ConfigureAwait(false);
                Assert.IsTrue(getParticipants.Count() > 2);

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

        [Test]
        public async Task RunCreateAddPlayAudioToParticipantCancelRemoveHangupScenarioTests()
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
                string userId = GetFixedUserId(TestEnvironment.UserIdentifier);

                // Add Participant
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                AddParticipantResult addParticipantResult = await AddParticipantOperation(callingServerClient, callLocator, userId).ConfigureAwait(false);
                Assert.NotNull(addParticipantResult);

                // Play Audio To Participant
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                var playAudioResult = await PlayAudioToParticipantOperation(callingServerClient, callLocator, userId).ConfigureAwait(false);

                // Cancel Participant Media Operation
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                string mediaOperationId = playAudioResult.OperationId;
                await CancelParticipantMediaOperation(callingServerClient, callLocator, userId, mediaOperationId).ConfigureAwait(false);

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

        [Test]
        public async Task RunCreatePlayCancelMediaHangupScenarioTests()
        {
            CallingServerClient callingServerClient = CreateInstrumentedCallingServerClientWithConnectionString();
            var groupId = GetGroupId();

            //Establish a Call
            var callConnections = await CreateGroupCallOperation(callingServerClient, groupId, GetFromUserId(), GetToUserId(), TestEnvironment.AppCallbackUrl).ConfigureAwait(false);
            var callLocator = new GroupCallLocator(groupId);

            try
            {
                // Play Prompt Audio
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                var playAudioResult = await PlayAudioOperation(callingServerClient, callLocator).ConfigureAwait(false);

                // Cancel Prompt Audio
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                string mediaOperatioId = playAudioResult.OperationId;
                await CancelMediaOperation(callingServerClient, callLocator, mediaOperatioId).ConfigureAwait(false);
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
        public async Task RunCreateAddAnswerRemoveHangupScenarioTests()
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
                string userId = GetFixedUserId(TestEnvironment.UserIdentifier);

                // Add Participant
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                AddParticipantResult addParticipantResult = await AddParticipantOperation(callingServerClient, callLocator, userId).ConfigureAwait(false);
                Assert.NotNull(addParticipantResult);

                // Answer Call
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                var answerCallResult = await AnswerCallOperation(callingServerClient).ConfigureAwait(false);

                foreach (var callConnection in callConnections)
                {
                    Assert.IsTrue(answerCallResult.CallConnectionId == callConnection.CallConnectionId);
                }

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

        [Test]
        public async Task RunCreateAddRejectRemoveHangupScenarioTests()
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
                string userId = GetFixedUserId(TestEnvironment.UserIdentifier);

                // Add Participant
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                AddParticipantResult addParticipantResult = await AddParticipantOperation(callingServerClient, callLocator, userId).ConfigureAwait(false);
                Assert.NotNull(addParticipantResult);

                // Reject Call
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await RejectCallOperation(callingServerClient).ConfigureAwait(false);

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

        [Test]
        public async Task RunCreateRedirectHangupScenarioTests()
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
                string userId = GetFixedUserId(TestEnvironment.UserIdentifier);

                // Redirect Call
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await RedirectCallOperation(callingServerClient, userId).ConfigureAwait(false);
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
        public async Task RunDownloadStreamingScenarioTests()
        {
            CallingServerClient callingServerClient = CreateInstrumentedCallingServerClientWithConnectionString();

            try
            {
                var downloadEndPoint = TestEnvironment.DownloadEndPoint;

                // Download Recording
                var downloadResponse = await callingServerClient.DownloadStreamingAsync(downloadEndPoint).ConfigureAwait(false);
                Assert.IsTrue(downloadResponse.GetRawResponse().Status == 200);
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
        public async Task RunDownloadToStreamScenarioTests()
        {
            CallingServerClient callingServerClient = CreateInstrumentedCallingServerClientWithConnectionString();

            try
            {
                var downloadEndPoint = TestEnvironment.DownloadEndPoint;
                var downloadEndPointMatch = Regex.Match(downloadEndPoint.ToString(), @"(objects/[^/]*)");
                string documentId = string.Empty;

                if (downloadEndPointMatch.Success && downloadEndPointMatch.Groups.Count > 1)
                {
                    documentId = downloadEndPointMatch.Groups[1].Value.Split('/')[1];
                }

                if (IsAsync)
                {
                    documentId = documentId + "async";
                    string filePath = ".\\" + documentId + ".json";
                    var downloadResponse = await callingServerClient.DownloadToAsync(downloadEndPoint, System.IO.File.Open(filePath, System.IO.FileMode.Create)).ConfigureAwait(false);
                    Assert.NotNull(downloadResponse);
                }
                else
                {
                    documentId = documentId + "sync";
                    string filePath = ".\\" + documentId + ".json";
                    var downloadResponse = await callingServerClient.DownloadToAsync(downloadEndPoint, System.IO.File.Open(filePath, System.IO.FileMode.Create)).ConfigureAwait(false);
                    Assert.NotNull(downloadResponse);
                }
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
        public async Task RunDownloadToDestinationcenarioTests()
        {
            CallingServerClient callingServerClient = CreateInstrumentedCallingServerClientWithConnectionString();

            try
            {
                var downloadEndPoint = TestEnvironment.DownloadEndPoint;
                var downloadEndPointMatch = Regex.Match(downloadEndPoint.ToString(), @"(objects/[^/]*)");
                string documentId = string.Empty;

                if (downloadEndPointMatch.Success && downloadEndPointMatch.Groups.Count > 1)
                {
                    documentId = downloadEndPointMatch.Groups[1].Value.Split('/')[1];
                }
                string filePath = ".\\" + documentId + ".json";

                var downloadResponse = await callingServerClient.DownloadToAsync(downloadEndPoint, filePath).ConfigureAwait(false);
                Assert.NotNull(downloadResponse);
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
