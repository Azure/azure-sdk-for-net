// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Identity;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Communication.CallingServer.Tests
{
    public class CallingServerLiveTestBase : RecordedTestBase<CallingServerTestEnvironment>
    {
        // Random Gen Guid
        protected const string FROM_USER_IDENTIFIER = "e3560385-776f-41d1-bf04-07ef738f2f23";

        // Random Gen Guid
        protected const string TO_USER_IDENTIFIER = "e3560385-776f-41d1-bf04-07ef738f2fc1";

        // From ACS Resource "immutableResourceId".
        protected const string RESOURCE_IDENTIFIER = "016a7064-0581-40b9-be73-6dde64d69d72";

        // Random Gen Guid
        protected const string GROUP_IDENTIFIER = "650b71d1-ffd1-4b22-bed8-2d5bac545798";

        protected string GetResourceId()
        {
            if (Mode == RecordedTestMode.Live)
            {
                return TestEnvironment.ResourceIdentifier;
            }
            return RESOURCE_IDENTIFIER;
        }

        protected string GetRandomUserId()
        {
            return "8:acs:" + GetResourceId() + "_" + Guid.NewGuid().ToString();
        }

        protected string GetFixedUserId(string userGuid)
        {
            return "8:acs:" + GetResourceId() + "_" + userGuid;
        }

        protected string GetFromUserId()
        {
            if (Mode == RecordedTestMode.Live)
            {
                return GetRandomUserId();
            }
            return GetFixedUserId(FROM_USER_IDENTIFIER);
        }

        protected string GetToUserId()
        {
            if (Mode == RecordedTestMode.Live)
            {
                return GetRandomUserId();
            }
            return GetFixedUserId(TO_USER_IDENTIFIER);
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

        public bool SkipCallingServerInteractionLiveTests
            => TestEnvironment.Mode == RecordedTestMode.Live && Environment.GetEnvironmentVariable("SKIP_CALLINGSERVER_INTERACTION_LIVE_TESTS") == "TRUE";

        /// <summary>
        /// Creates a <see cref="CommunicationIdentityClient" /> with the connectionstring via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="CommunicationIdentityClient" />.</returns>
        protected CommunicationIdentityClient CreateInstrumentedCommunicationIdentityClient()
            => InstrumentClient(
                new CommunicationIdentityClient(
                    TestEnvironment.LiveTestStaticConnectionString,
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

        /// <summary>
        /// Creates a <see cref="CallingServerClient" />.
        /// </summary>
        /// <returns>The instrumented <see cref="CallingServerClient"/>.</returns>
        protected CallingServerClient CreateInstrumentedCallingServerClientWithToken()
        {
            Uri endpoint = TestEnvironment.LiveTestStaticEndpoint;
            TokenCredential tokenCredential;

            if (Mode == RecordedTestMode.Playback)
            {
                tokenCredential = new MockCredential();
            }
            else
            {
                tokenCredential = new DefaultAzureCredential();
            }

            CallingServerClient client = new CallingServerClient(endpoint.ToString(), tokenCredential);
            return InstrumentClient(client);
        }

        #region Api operation functions
        #region Snippet:Azure_Communication_ServerCalling_Tests_CreateGroupCallOperation
        internal async Task<IEnumerable<CallConnection>> CreateGroupCallOperation(CallingServerClient callingServerClient, string groupId, string from, string to, string callBackUri)
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
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_CreateGroupCallOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_CreateCallConnectionOperation
        internal async Task<Response<CallConnection>> CreateCallConnectionOperation(CallingServerClient client)
        {
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var source = await CreateUserAsync(communicationIdentityClient).ConfigureAwait(false);

            var targets = new[] { new PhoneNumberIdentifier(TestEnvironment.TargetPhoneNumber) };
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

        internal async Task PlayAudioOperation(ServerCall serverCall)
        {
            Console.WriteLine("Performing PlayAudio operation");

            var response = await serverCall.PlayAudioAsync(
                audioFileUri: new Uri(TestEnvironment.AudioFileUrl),
                audioFileId: "ebb1d98d-fd86-4204-800c-f7bdfc2e515c",
                callbackUri: new Uri(TestEnvironment.AppCallbackUrl),
                operationContext: "de346f03-7f8d-41ab-a232-cc5e14990769"
                ).ConfigureAwait(false);

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

        internal async Task CancelAllMediaOperationsOperation(IEnumerable<CallConnection> callConnections)
        {
            Console.WriteLine("Performing cancel media processing operation to stop playing audio");

            if (callConnections == null)
            {
                return;
            }
            foreach (CallConnection callConnection in callConnections)
            {
                if (callConnection != null)
                {
                    try
                    {
                        var response = await callConnection.CancelAllMediaOperationsAsync().ConfigureAwait(false);
                        Assert.AreEqual(OperationStatus.Completed, response.Value.Status);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error hanging up: " + ex.Message);
                    }
                }
            }
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_CancelMediaOperationsOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_AddParticipantOperation
        internal async Task<string> AddParticipantOperation(CallConnection callConnection)
        {
            Console.WriteLine("Performing add participant operation to add a participant");

            string invitedUser = GetFixedUserId("0000000a-b200-7a0d-570c-113a0d00288d");

            var response = await callConnection.AddParticipantAsync(new CommunicationUserIdentifier(invitedUser)).ConfigureAwait(false);

            Assert.AreEqual(false, string.IsNullOrEmpty(response.Value.ParticipantId));

            return response.Value.ParticipantId;
        }

        internal async Task<string> AddParticipantOperation(ServerCall serverCall)
        {
            Console.WriteLine("Performing add participant operation to add a participant");

            string invitedUser = GetFixedUserId("0000000a-b200-7a0d-570c-113a0d00288d");

            var response = await serverCall.AddParticipantAsync(
                new CommunicationUserIdentifier(invitedUser),
                callbackUri: new Uri(TestEnvironment.AppCallbackUrl)
                ).ConfigureAwait(false);

            Assert.AreEqual(false, string.IsNullOrEmpty(response.Value.ParticipantId));

            return response.Value.ParticipantId;
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_AddParticipantOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_RemoveParticipantOperation
        internal async Task RemoveParticipantOperation(CallConnection callConnection, string participantId)
        {
            Console.WriteLine("Performing remove participant operation to remove a participant");

            var response = await callConnection.RemoveParticipantAsync(participantId).ConfigureAwait(false);

            Assert.AreEqual(202, response.Status);
        }

        internal async Task RemoveParticipantOperation(ServerCall serverCall, string participantId)
        {
            Console.WriteLine("Performing remove participant operation to remove a participant");

            var response = await serverCall.RemoveParticipantAsync(participantId).ConfigureAwait(false);

            Assert.AreEqual(202, response.Status);
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_RemoveParticipantOperation
        #endregion Api operation functions

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

        protected async Task SleepIfNotInPlaybackModeAsync(int milliSeconds = 10000)
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

        protected async Task ValidateCallRecordingStateAsync(ServerCall serverCall,
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

        private CallingServerClientOptions CreateServerCallingClientOptionsWithCorrelationVectorLogs()
        {
            CallingServerClientOptions callClientOptions = new CallingServerClientOptions();
            callClientOptions.Diagnostics.LoggedHeaderNames.Add("MS-CV");
            return InstrumentClientOptions(callClientOptions);
        }
        #endregion Support functions
    }
}
