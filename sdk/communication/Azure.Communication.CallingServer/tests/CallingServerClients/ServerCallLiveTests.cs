// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        protected string GroupId;
        protected string FromUser;
        protected string ToUser;

        /// <summary>
        /// Initializes a new instance of the <see cref="CallingServerClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public ServerCallLiveTests(bool isAsync) : base(isAsync)
        {
            GroupId = GetGroupId();
            FromUser = GetRandomUserId();
            ToUser = GetRandomUserId();
        }

        [Test]
        public async Task RunJoinPlayCancelHangupScenarioTests()
        {
            CallingServerClient client = CreateInstrumentedCallingServerClient();
            try
            {
                // Establish a Call
                var callConnections = await CreateGroupCallAsync(client, GroupId, FromUser, ToUser, TestEnvironment.AppCallbackUrl).ConfigureAwait(false);

                // Hang up the Call, there is one call leg in this test case, hangup the call will also delete the call as the result.
                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await CleanUpConnectionsAsync(callConnections).ConfigureAwait(false);

                //// Establish a Call
                //var callConnection = await CreateCallConnectionOperation(client).ConfigureAwait(false);

                //// Users join the Call
                //await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                //await AddParticipantOperation(callConnection).ConfigureAwait(false);

                //// Remove Participant
                //await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                //await RemoveParticipantOperation(callConnection).ConfigureAwait(false);

                //// Hang up the Call, there is one call leg in this test case, hangup the call will also delete the call as the result.
                //await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                //await HangupOperation(callConnection).ConfigureAwait(false);
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
