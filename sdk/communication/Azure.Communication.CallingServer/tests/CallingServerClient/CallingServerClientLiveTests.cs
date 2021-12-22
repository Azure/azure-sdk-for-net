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
                await CleanUpConnectionsAsync(callConnections).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Request failed error: {ex}");
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
            await WaitForOperationCompletion().ConfigureAwait(false);

            try
            {
                var callLocator = new GroupCallLocator(groupId);

                // Play Prompt Audio
                await PlayAudioOperation(callingServerClient, callLocator).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);

                // Cancel Prompt Audio
                await CancelAllMediaOperationsOperation(callConnections).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Request failed error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                // Hang up the Call, there is one call leg in this test case, hangup the call will also delete the call as the result.
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
            await WaitForOperationCompletion().ConfigureAwait(false);

            try
            {
                var callLocator = new GroupCallLocator(groupId);
                string userId = GetUserId(USER_IDENTIFIER);

                // Add Participant
                AddParticipantResult addParticipantResult = await AddParticipantOperation(callingServerClient, callLocator, userId).ConfigureAwait(false);
                Assert.NotNull(addParticipantResult);
                await WaitForOperationCompletion().ConfigureAwait(false);

                // Remove Participant
                await RemoveParticipantOperation(callingServerClient, callLocator, userId).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Request failed error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                // Hang up the Call, there is one call leg in this test case, hangup the call will also delete the call as the result.
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
                Assert.Fail($"Request failed error: {ex}");
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
                if (ex.Status == 404)
                {
                    Assert.Pass($"Request failed error: {ex}");
                }
                else
                {
                    Assert.Fail($"Request failed error with unmatched status code: {ex}");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
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
            await WaitForOperationCompletion().ConfigureAwait(false);

            try
            {
                var callLocator = new GroupCallLocator(groupId);

                foreach (var callConnection in callConnections)
                {
                    var getCallConnection = callingServerClient.GetCallConnection(callConnection.CallConnectionId);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(getCallConnection.CallConnectionId));
                }

                string userId = GetUserId(USER_IDENTIFIER);

                // Add Participant
                AddParticipantResult addParticipantResult = await AddParticipantOperation(callingServerClient, callLocator, userId).ConfigureAwait(false);
                Assert.NotNull(addParticipantResult);
                await WaitForOperationCompletion().ConfigureAwait(false);

                // Get Participant
                var getParticipant = await GetParticipant(callingServerClient, callLocator, userId).ConfigureAwait(false);
                Assert.NotNull(getParticipant);

                // Get Participants
                var getParticipants = await GetParticipants(callingServerClient, callLocator).ConfigureAwait(false);
                Assert.IsTrue(getParticipants.Count() > 2);

                // Remove Participant
                await RemoveParticipantOperation(callingServerClient, callLocator, userId).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Request failed error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                // Hang up the Call, there is one call leg in this test case, hangup the call will also delete the call as the result.
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
            await WaitForOperationCompletion().ConfigureAwait(false);

            try
            {
                var callLocator = new GroupCallLocator(groupId);
                string userId = GetUserId(USER_IDENTIFIER);

                // Add Participant
                AddParticipantResult addParticipantResult = await AddParticipantOperation(callingServerClient, callLocator, userId).ConfigureAwait(false);
                Assert.NotNull(addParticipantResult);
                await WaitForOperationCompletion().ConfigureAwait(false);

                // Play Audio To Participant
                var playAudioResult = await PlayAudioToParticipantOperation(callingServerClient, callLocator, userId).ConfigureAwait(false);
                string mediaOperationId = playAudioResult.OperationId;
                await WaitForOperationCompletion().ConfigureAwait(false);

                // Cancel Participant Media Operation
                await CancelParticipantMediaOperation(callingServerClient, callLocator, userId, mediaOperationId).ConfigureAwait(false);

                // Remove Participant
                await RemoveParticipantOperation(callingServerClient, callLocator, userId).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Request failed error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                // Hang up the Call, there is one call leg in this test case, hangup the call will also delete the call as the result.
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
            await WaitForOperationCompletion().ConfigureAwait(false);

            try
            {
                var callLocator = new GroupCallLocator(groupId);

                // Play Prompt Audio
                var playAudioResult = await PlayAudioOperation(callingServerClient, callLocator).ConfigureAwait(false);
                string mediaOperatioId = playAudioResult.OperationId;
                await WaitForOperationCompletion().ConfigureAwait(false);

                // Cancel Prompt Audio
                await CancelMediaOperation(callingServerClient, callLocator, mediaOperatioId).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Request failed error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                // Hang up the Call, there is one call leg in this test case, hangup the call will also delete the call as the result.
                await CleanUpConnectionsAsync(callConnections).ConfigureAwait(false);
            }
        }

        [Test]
        [Ignore("Skip test as it is not working now")]
        public async Task RunCreateAddAnswerRemoveHangupScenarioTests()
        {
            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

            CallingServerClient callingServerClient = CreateInstrumentedCallingServerClientWithConnectionString();
            var groupId = GetGroupId();

            // Establish a Call
            var callConnections = await CreateGroupCallOperation(callingServerClient, groupId, GetFromUserId(), GetToUserId(), TestEnvironment.AppCallbackUrl).ConfigureAwait(false);
            await WaitForOperationCompletion().ConfigureAwait(false);

            try
            {
                var callLocator = new GroupCallLocator(groupId);
                string userId = GetUserId(USER_IDENTIFIER);

                // Add Participant
                AddParticipantResult addParticipantResult = await AddParticipantOperation(callingServerClient, callLocator, userId).ConfigureAwait(false);
                Assert.NotNull(addParticipantResult);
                await WaitForOperationCompletion().ConfigureAwait(false);

                // Answer Call
                var answerCallResult = await AnswerCallOperation(callingServerClient).ConfigureAwait(false);

                foreach (var callConnection in callConnections)
                {
                    Assert.IsTrue(answerCallResult.CallConnectionId == callConnection.CallConnectionId);
                }

                // Remove Participant
                await RemoveParticipantOperation(callingServerClient, callLocator, userId).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Request failed error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                // Hang up the Call, there is one call leg in this test case, hangup the call will also delete the call as the result.
                await CleanUpConnectionsAsync(callConnections).ConfigureAwait(false);
            }
        }

        [Test]
        [Ignore("Skip test as it is not working now")]
        public async Task RunCreateAddRejectRemoveHangupScenarioTests()
        {
            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

            CallingServerClient callingServerClient = CreateInstrumentedCallingServerClientWithConnectionString();
            var groupId = GetGroupId();

            // Establish a Call
            var callConnections = await CreateGroupCallOperation(callingServerClient, groupId, GetFromUserId(), GetToUserId(), TestEnvironment.AppCallbackUrl).ConfigureAwait(false);
            await WaitForOperationCompletion().ConfigureAwait(false);

            try
            {
                var callLocator = new GroupCallLocator(groupId);
                string userId = GetUserId(USER_IDENTIFIER);

                // Add Participant
                AddParticipantResult addParticipantResult = await AddParticipantOperation(callingServerClient, callLocator, userId).ConfigureAwait(false);
                Assert.NotNull(addParticipantResult);
                await WaitForOperationCompletion().ConfigureAwait(false);

                // Reject Call
                await RejectCallOperation(callingServerClient).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Request failed error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                // Hang up the Call, there is one call leg in this test case, hangup the call will also delete the call as the result.
                await CleanUpConnectionsAsync(callConnections).ConfigureAwait(false);
            }
        }

        [Test]
        [Ignore("Skip test as it is not working now")]
        public async Task RunCreateRedirectHangupScenarioTests()
        {
            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

            CallingServerClient callingServerClient = CreateInstrumentedCallingServerClientWithConnectionString();
            var groupId = GetGroupId();

            // Establish a Call
            await CreateGroupCallOperation(callingServerClient, groupId, GetFromUserId(), GetToUserId(), TestEnvironment.AppCallbackUrl).ConfigureAwait(false);
            await WaitForOperationCompletion().ConfigureAwait(false);

            try
            {
                string userId = GetUserId(USER_IDENTIFIER);

                // Redirect Call
                await RedirectCallOperation(callingServerClient, userId).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Request failed error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task RunDownloadStreamingScenarioTests()
        {
            CallingServerClient callingServerClient = CreateInstrumentedCallingServerClientWithConnectionString();

            try
            {
                var downloadEndPoint = new Uri(GetDownloadEndPointUrl());

                // Download Recording
                var downloadResponse = await callingServerClient.DownloadStreamingAsync(downloadEndPoint).ConfigureAwait(false);
                Assert.IsTrue(downloadResponse.GetRawResponse().Status == 200);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Request failed error: {ex}");
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
                var downloadEndPoint = new Uri(GetDownloadEndPointUrl());
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
                Assert.Fail($"Request failed error: {ex}");
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
                var downloadEndPoint = new Uri(GetDownloadEndPointUrl());
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
                Assert.Fail($"Request failed error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }
    }
}
