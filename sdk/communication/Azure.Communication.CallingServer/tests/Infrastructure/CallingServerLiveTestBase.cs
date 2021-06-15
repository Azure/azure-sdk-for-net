// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Identity;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.CallingServer.Tests
{
    public class CallingServerLiveTestBase : RecordedTestBase<CallingServerTestEnvironment>
    {
        protected const string RESOURCE_IDENTIFIER = "02665c56-277e-4c59-bab4-c475caa3ee80";

        protected const string GROUP_IDENTIFIER = "1400789f-e11b-4ceb-88cb-bc8df2a01568";

        protected string GetRandomUserId()
        {
            return "8:acs:" + RESOURCE_IDENTIFIER + "_" + Guid.NewGuid().ToString();
        }

        protected string GetFixedUserId(string userGuid)
        {
            return "8:acs:" + RESOURCE_IDENTIFIER + "_" + userGuid;
        }

        protected string GetGroupId()
        {
            /**
             * If tests are running in live mode, we want them to all
             * have unique groupId's so they do not conflict with other
             * recording tests running in live mode.
             */
            if (Mode == RecordedTestMode.Live)
            {
                return Guid.NewGuid().ToString();
            }

            /**
             * For recording tests we need to make sure the groupId
             * matches the recorded groupId, or the call will fail.
             */
            return GROUP_IDENTIFIER;
        }

        public CallingServerLiveTestBase(bool isAsync) : base(isAsync)
            => Sanitizer = new CallingServerRecordedTestSanitizer();

        /// <summary>
        /// Creates a <see cref="CommunicationIdentityClient" /> with the connectionstring via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="CommunicationIdentityClient" />.</returns>
        protected CommunicationIdentityClient CreateInstrumentedCommunicationIdentityClient()
            => InstrumentClient(
                new CommunicationIdentityClient(
                    TestEnvironment.LiveTestDynamicConnectionString,
                    InstrumentClientOptions(new CommunicationIdentityClientOptions(CommunicationIdentityClientOptions.ServiceVersion.V2021_03_07))));

        /// <summary>
        /// Creates a <see cref="CallingServerClient" />
        /// </summary>
        /// <returns>The instrumented <see cref="CallingServerClient" />.</returns>
        protected CallingServerClient CreateInstrumentedCallingServerClient()
        {
            var connectionString = TestEnvironment.LiveTestStaticConnectionString;
            CallingServerClient callingServerClient = new CallingServerClient(connectionString, CreateServerCallingClientOptionsWithCorrelationVectorLogs());

            #region Snippet:Azure_Communication_ServerCalling_Tests_Samples_CreateServerCallingClient
            //@@var connectionString = "<connection_string>"; // Find your Communication Services resource in the Azure portal
            //@@CallingServerClient callingServerClient = new CallingServerClient(connectionString);
            #endregion Snippet:Azure_Communication_ServerCalling_Tests_Samples_CreateServerCallingClient

            return InstrumentClient(callingServerClient);
        }

        protected async Task<IEnumerable<CallConnection>> CreateGroupCallAsync(CallingServerClient callingServerClient, string groupId, string from, string to, string callBackUri)
        {
            CallConnection? fromCallConnection = null;
            CallConnection? toCallConnection = null;

            try
            {
                CommunicationIdentifier fromParticipant = new CommunicationUserIdentifier(from);
                CommunicationIdentifier toParticipant = new CommunicationUserIdentifier(to);

                JoinCallOptions fromCallOptions = new JoinCallOptions(
                    new Uri(callBackUri),
                    new MediaType[] { MediaType.Audio },
                    new EventSubscriptionType[] { EventSubscriptionType.ParticipantsUpdated });
                fromCallConnection = await callingServerClient.JoinCallAsync(groupId, fromParticipant, fromCallOptions).ConfigureAwait(false);
                SleepInTest(1000);
                Assert.IsFalse(string.IsNullOrWhiteSpace(fromCallConnection.CallConnectionId));

                JoinCallOptions joinCallOptions = new JoinCallOptions(
                    new Uri(callBackUri),
                    new MediaType[] { MediaType.Audio },
                    new EventSubscriptionType[] { EventSubscriptionType.ParticipantsUpdated});

                toCallConnection = await callingServerClient.JoinCallAsync(groupId, toParticipant, joinCallOptions).ConfigureAwait(false);
                SleepInTest(1000);
                Assert.IsFalse(string.IsNullOrWhiteSpace(toCallConnection.CallConnectionId));

                return new CallConnection[] { fromCallConnection, toCallConnection };
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
                throw;
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");

                if (fromCallConnection != null)
                {
                    await fromCallConnection.HangupAsync().ConfigureAwait(false);
                }

                if (toCallConnection != null)
                {
                    await toCallConnection.HangupAsync().ConfigureAwait(false);
                }
                throw;
            }
        }

        #region Support functions
        #region Snippet:Azure_Communication_ServerCalling_Tests_CreateCallConnectionOperation
        internal async Task<Response<CallConnection>> CreateCallConnectionOperation(CallingServerClient client)
        {
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var source = await CreateUserAsync(communicationIdentityClient).ConfigureAwait(false);

            var targets = new[] { new PhoneNumberIdentifier("+11111111111") };
            var createCallOption = new CreateCallOptions(
                   new Uri(TestEnvironment.AppCallbackUrl),
                   new[] { MediaType.Audio },
                   new[] { EventSubscriptionType.ParticipantsUpdated, EventSubscriptionType.DtmfReceived });
            createCallOption.AlternateCallerId = new PhoneNumberIdentifier(TestEnvironment.SourcePhoneNumber);

            Console.WriteLine("Performing CreateCall operation");

            var callConnection = await client.CreateCallConnectionAsync(source: source, targets: targets, options: createCallOption).ConfigureAwait(false);

            Console.WriteLine("Call initiated with Call connection id: {0}", callConnection.Value.CallConnectionId);

            Assert.IsFalse(string.IsNullOrWhiteSpace(callConnection.Value.CallConnectionId));
            return callConnection;
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_CreateCallConnectionOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_PlayAudioOperation
        internal async Task PlayAudioOperation(CallConnection callConnection)
        {
            var playAudioOptions = new PlayAudioOptions()
            {
                AudioFileUri = new Uri(TestEnvironment.AudioFileUrl),
                OperationContext = "de346f03-7f8d-41ab-a232-cc5e14990769",
                Loop = false,
                AudioFileId = "ebb1d98d-fd86-4204-800c-f7bdfc2e515c"
            };

            Console.WriteLine("Performing PlayAudio operation");

            var response = await callConnection.PlayAudioAsync(playAudioOptions).ConfigureAwait(false);

            Assert.AreEqual(response.Value.Status, OperationStatus.Running);
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_PlayAudioOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_HangupCallOperation
        internal async Task HangupOperation(CallConnection callConnection)
        {
            Console.WriteLine("Performing Hangup operation");

            var response = await callConnection.HangupAsync().ConfigureAwait(false);

            Assert.AreEqual(202, response.Status);
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_HangupCallOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_CancelMediaOperationsOperation
        internal async Task CancelAllMediaOperationsOperation(CallConnection callConnection)
        {
            Console.WriteLine("Performing cancel media processing operation to stop playing audio");

            var response = await callConnection.CancelAllMediaOperationsAsync().ConfigureAwait(false);

            Assert.AreEqual(OperationStatus.Completed, response.Value.Status);
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_CancelMediaOperationsOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_AddParticipantOperation
        internal async Task AddParticipantOperation(CallConnection callConnection)
        {
            Console.WriteLine("Performing cancel media processing operation to stop playing audio");

            string invitedUser = GetFixedUserId("e3560385-776f-41d1-bf04-07ef738f2fc1");

            var response = await callConnection.AddParticipantAsync(new CommunicationUserIdentifier(invitedUser)).ConfigureAwait(false);

            Assert.AreEqual(202, response.Status);
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_AddParticipantOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_RemoveParticipantOperation
        internal async Task RemoveParticipantOperation(CallConnection callConnection)
        {
            Console.WriteLine("Performing cancel media processing operation to stop playing audio");

            // Remove Participant
            /**
             * There is an update that we require to beable to get
             * the participantId from the service when a user is
             * added to a call. Until that is fixed this recorded
             * valuse needs to be used.
             */
            var response = await callConnection.RemoveParticipantAsync("e3560385-776f-41d1-bf04-07ef738f2fc1").ConfigureAwait(false);

            Assert.AreEqual(202, response.Status);
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_RemoveParticipantOperation
        #endregion

        #region Support functions
        private CommunicationUserIdentifier CreateUser(CommunicationIdentityClient communicationIdentityClient)
        {
            // reserve for living test, expect adding more content in the future.
            return communicationIdentityClient.CreateUser();
        }

        private async Task<CommunicationUserIdentifier> CreateUserAsync(CommunicationIdentityClient communicationIdentityClient)
        {
            // reserve for living test, expect adding more content in the future.
            return await communicationIdentityClient.CreateUserAsync();
        }
        protected async Task CleanUpConnectionsAsync(IEnumerable<CallConnection> connections)
        {
            if (connections == null)
            {
                return;
            }
            foreach (CallConnection connection in connections)
            {
                if (connection != null)
                {
                    try
                    {
                        await connection.HangupAsync().ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error hanging up: " + ex.Message);
                    }
                }
            }
        }

        protected async Task SleepIfNotInPlaybackModeAsync()
        {
            if (TestEnvironment.Mode != RecordedTestMode.Playback)
                await Task.Delay(10000);
        }

        protected void SleepInTest(int milliSeconds)
        {
            if (Mode == RecordedTestMode.Playback)
                return;
            Thread.Sleep(milliSeconds);
        }

        private CallingServerClientOptions CreateServerCallingClientOptionsWithCorrelationVectorLogs()
        {
            CallingServerClientOptions callClientOptions = new CallingServerClientOptions();
            callClientOptions.Diagnostics.LoggedHeaderNames.Add("MS-CV");
            return InstrumentClientOptions(callClientOptions);
        }
        #endregion Support functions
    }
}
