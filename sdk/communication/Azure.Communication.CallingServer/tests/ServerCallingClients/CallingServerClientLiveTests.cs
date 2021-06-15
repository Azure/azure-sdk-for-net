// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
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
        protected string GroupId;
        protected string FromUser;
        protected string ToUser;

        /// <summary>
        /// Initializes a new instance of the <see cref="CallingServerClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public CallingServerClientLiveTests(bool isAsync) : base(isAsync)
        {
            GroupId = GetGroupId();
            FromUser = GetRandomUserId();
            ToUser = GetRandomUserId();
        }

        //[OneTimeSetUp]
        //public void Setup()
        //{
        //    string groupId = GetGroupId();
        //    string fromUser = GetRandomUserId();
        //    string toUser = GetRandomUserId();
        //}RunCreateJoinHangupScenarioTests

        [Test]
        public async Task RunAllClientFunctionsScenarioTests()
        {
            CallingServerClient callingServerClient = CreateInstrumentedCallingServerClient();
            try
            {
                // Establish a Call
                var callConnections = await CreateGroupCallAsync(callingServerClient, GroupId, FromUser, ToUser, TestEnvironment.AppCallbackUrl).ConfigureAwait(false);
                var serverCall = callingServerClient.InitializeServerCall(GroupId);

                StartCallRecordingResult startCallRecordingResult = await serverCall.StartRecordingAsync(new Uri(TestEnvironment.AppCallbackUrl)).ConfigureAwait(false);
                var recordingId = startCallRecordingResult.RecordingId;
                await ValidateCallRecordingStateAsync(serverCall, recordingId, CallRecordingState.Active).ConfigureAwait(false);

                await serverCall.PauseRecordingAsync(recordingId).ConfigureAwait(false);
                await ValidateCallRecordingStateAsync(serverCall, recordingId, CallRecordingState.Inactive).ConfigureAwait(false);

                await serverCall.ResumeRecordingAsync(recordingId).ConfigureAwait(false);
                await ValidateCallRecordingStateAsync(serverCall, recordingId, CallRecordingState.Active).ConfigureAwait(false);

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

        private async Task ValidateCallRecordingStateAsync(ServerCall serverCall,
            string recordingId,
            CallRecordingState expectedCallRecordingState)
        {
            Assert.NotNull(serverCall);
            Assert.NotNull(recordingId);

            // There is a delay between the action and when the state is available.
            // Waiting to make sure we get the updated state, when we are running
            // against a live service.
            SleepInTest(6000);

            CallRecordingProperties callRecordingProperties = await serverCall.GetRecordingStateAsync(recordingId).ConfigureAwait(false);
            Assert.NotNull(callRecordingProperties);
            Assert.AreEqual(callRecordingProperties.RecordingState, expectedCallRecordingState);
        }

        //#region Support functions
        //#region Snippet:Azure_Communication_ServerCalling_Tests_CreateCallOperation
        //private async Task RemoveParticipantOperation(CallingServerClient callingServerClient)
        //{
        //    Console.WriteLine("Performing cancel media processing operation to stop playing audio");

        //    CommunicationIdentifier source;
        //    JoinCallOptions callOptions;
        //    string groupId = GetGroupId();
        //    ServerCall serverCallAsync = callingServerClient.InitializeServerCall(groupId);

        //    // Remove Participant
        //    /**
        //     * There is an update that we require to beable to get
        //     * the participantId from the service when a user is
        //     * added to a call. Until that is fixed this recorded
        //     * valuse needs to be used.
        //     */
        //    var response = await callingServerClient.JoinCallAsync(serverCallId, source, callOptions).ConfigureAwait(false);

        //    Assert.AreEqual(202, response.Status);
        //}
        //#endregion Snippet:Azure_Communication_ServerCalling_Tests_RemoveParticipantOperation
        //#endregion

        #region Support functions
        #endregion Support functions
    }
}
