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

            CallingServerClient client = CreateInstrumentedCallingServerClient();
            try
            {
                // Establish a Call
                var callConnection = await CreateCallConnectionOperation(client).ConfigureAwait(false);

                // Play Prompt Audio
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await PlayAudioOperation(callConnection).ConfigureAwait(false);

                // Cancel Prompt Audio
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await CancelAllMediaOperationsOperation(callConnection).ConfigureAwait(false);

                // Hang up the Call, there is one call leg in this test case, hangup the call will also delete the call as the result.
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await HangupOperation(callConnection).ConfigureAwait(false);
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

            CallingServerClient client = CreateInstrumentedCallingServerClient();
            try
            {
                // Establish a call
                var callConnection = await CreateCallConnectionOperation(client).ConfigureAwait(false);

                // Add Participant
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                var participantId = await AddParticipantOperation(callConnection).ConfigureAwait(false);

                // Remove Participant
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await RemoveParticipantOperation(callConnection, participantId).ConfigureAwait(false);

                // Hang up the Call, there is one call leg in this test case, hangup the call will also delete the call as the result.
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await HangupOperation(callConnection).ConfigureAwait(false);
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
