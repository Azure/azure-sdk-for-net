﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Communication.Identity;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;
using Azure.Communication.CallingServer.Models;

namespace Azure.Communication.CallingServer.Tests
{
    public class CallingServerLiveTestBase : RecordedTestBase<CallingServerTestEnvironment>
    {
        // Random Gen Guid
        protected const string FROM_USER_IDENTIFIER = "0000000e-77a4-bdce-80f5-8b3a0d007a16";

        // Random Gen Guid
        protected const string TO_USER_IDENTIFIER = "0000000e-77a5-32f6-92fd-8b3a0d00f9a0";

        // From ACS Resource "immutableResourceId".
        protected const string RESOURCE_IDENTIFIER = "016a7064-0581-40b9-be73-6dde64d69d72";

        // Random Gen Guid
        protected const string GROUP_IDENTIFIER = "0000000e-77a5-b543-92fd-8b3a0d00f9a5";

        // Random Gen Guid
        protected const string USER_IDENTIFIER = "0000000e-7616-5525-fa5d-573a0d0064d8";

        // Random Gen Guid
        protected const string ANOTHER_USER_IDENTIFIER = "0000000e-7616-8017-fa5d-573a0d0064da";

        protected const string DOWNLOAD_END_POINT = "https://us-storage.asm.skype.com/v1/objects/0-wus-d8-99b867bd0c3f48c32fe2ddc8aa2e4125/content/acsmetadata";

        protected const string DELETE_END_POINT = "https://us-storage.asm.skype.com/v1/objects/0-wus-d3-416391754a6da60e4861809e301d5ac8";

        protected const string ASYNC_DELETE_END_POINT = "https://us-storage.asm.skype.com/v1/objects/0-wus-d10-182f0234aded83837acb3324f1989c03";

        protected const string INVALID_DELETE_END_POINT = "https://us-storage.asm.skype.com/v1/objects/0-wus-d10-00000000000000000000000000000000";

        protected const string AUDIO_FILE_URL = "https://acsfunctionappstorage.blob.core.windows.net/acs-audio-files/sample-message.wav";

        protected const string TARGET_CALL_CONNECTION_ID = "41201300-4316-4094-b8f0-a2238937273b";

        protected const string PLAYAUDIO_OPERATIONCONTEXT = "de346f03-7f8d-41ab-a232-cc5e14990769";

        protected const string PLAYAUDIO_AUDIOFILEID = "ebb1d98d-fd86-4204-800c-f7bdfc2e515c";

        protected string GetTargetCallConnectionId()
        {
            return TARGET_CALL_CONNECTION_ID;
        }

        protected string GetAudioFileUrl()
        {
            return AUDIO_FILE_URL;
        }

        protected string GetDownloadEndPointUrl()
        {
            return DOWNLOAD_END_POINT;
        }

        protected string GetResourceId()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                return TestEnvironment.ResourceIdentifier;
            }
            return RESOURCE_IDENTIFIER;
        }

        protected string GetRandomUserId()
        {
            return "8:acs:" + GetResourceId() + "_" + Guid.NewGuid().ToString();
        }

        protected string GetUserId(string userGuid)
        {
            return "8:acs:" + GetResourceId() + "_" + userGuid;
        }

        protected string GetFromUserId()
        {
            if (Mode == RecordedTestMode.Live)
            {
                return GetRandomUserId();
            }
            return GetUserId(FROM_USER_IDENTIFIER);
        }

        protected string GetToUserId()
        {
            if (Mode == RecordedTestMode.Live)
            {
                return GetRandomUserId();
            }
            return GetUserId(TO_USER_IDENTIFIER);
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

        protected string GetInvalidDeleteUrl()
        {
            return INVALID_DELETE_END_POINT;
        }

        protected string GetDeleteUrl()
        {
            return DELETE_END_POINT;
        }

        protected string GetAsyncDeleteUrl()
        {
            return ASYNC_DELETE_END_POINT;
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
        protected CallingServerClient CreateInstrumentedCallingServerClientWithConnectionString()
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
                #region Snippet:Azure_Communication_CallingServer_Tests_Samples_CreateCallingServerClientWithToken
                //@@ var endpoint = new Uri("https://my-resource.communication.azure.com");
                //@@ TokenCredential tokenCredential = new DefaultAzureCredential();
                //@@ var client = new CallingServerClient(endpoint, tokenCredential);
                #endregion Snippet:Azure_Communication_CallingServer_Tests_Samples_CreateCallingServerClientWithToken
            }

            CallingServerClient client = new CallingServerClient(endpoint, tokenCredential, CreateServerCallingClientOptionsWithCorrelationVectorLogs());
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
                    new CallMediaType[] { CallMediaType.Audio },
                    new CallingEventSubscriptionType[] { CallingEventSubscriptionType.ParticipantsUpdated });

                var callLocator = new GroupCallLocator(groupId);

                fromCallConnection = await callingServerClient.JoinCallAsync(callLocator, fromParticipant, fromCallOptions).ConfigureAwait(false);
                SleepInTest(1000);
                Assert.IsFalse(string.IsNullOrWhiteSpace(fromCallConnection.CallConnectionId));

                JoinCallOptions joinCallOptions = new JoinCallOptions(
                    new Uri(callBackUri),
                    new CallMediaType[] { CallMediaType.Audio },
                    new CallingEventSubscriptionType[] { CallingEventSubscriptionType.ParticipantsUpdated});

                toCallConnection = await callingServerClient.JoinCallAsync(callLocator, toParticipant, joinCallOptions).ConfigureAwait(false);
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
                   new[] { CallMediaType.Audio },
                   new[] { CallingEventSubscriptionType.ParticipantsUpdated, CallingEventSubscriptionType.ToneReceived });
            createCallOption.AlternateCallerId = new PhoneNumberIdentifier(TestEnvironment.SourcePhoneNumber);

            Console.WriteLine("Performing CreateCall operation");

            var callConnection = await client.CreateCallConnectionAsync(source: source, targets: targets, options: createCallOption).ConfigureAwait(false);

            Console.WriteLine("Call initiated with Call connection id: {0}", callConnection.Value.CallConnectionId);

            Assert.IsFalse(string.IsNullOrWhiteSpace(callConnection.Value.CallConnectionId));
            return callConnection;
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_CreateCallConnectionOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_PlayAudioOperation
        internal async Task PlayAudioOperation(CallConnection callConnection, bool playAudioInLoop=false)
        {
            var playAudioOptions = new PlayAudioOptions()
            {
                OperationContext = PLAYAUDIO_OPERATIONCONTEXT,
                Loop = playAudioInLoop,
                AudioFileId = PLAYAUDIO_AUDIOFILEID
            };

            Console.WriteLine("Performing PlayAudio operation");

            var response = await callConnection.PlayAudioAsync(new Uri(GetAudioFileUrl()), playAudioOptions).ConfigureAwait(false);

            Assert.AreEqual(response.Value.Status, CallingOperationStatus.Running);
        }

        internal async Task<PlayAudioResult> PlayAudioOperation(CallingServerClient callingServerClient, CallLocator callLocator, bool playAudioInLoop = false)
        {
            Console.WriteLine("Performing PlayAudio operation");

            var response = await callingServerClient.PlayAudioAsync(
                callLocator,
                new Uri(GetAudioFileUrl()),
                new PlayAudioOptions()
                {
                    OperationContext = PLAYAUDIO_OPERATIONCONTEXT,
                    Loop = playAudioInLoop,
                    AudioFileId = PLAYAUDIO_AUDIOFILEID,
                    CallbackUri = new Uri(TestEnvironment.AppCallbackUrl)
                }).ConfigureAwait(false);

            Assert.AreEqual(response.Value.Status, CallingOperationStatus.Running);

            return response.Value;
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

            Assert.AreEqual(response.Status, (int)HttpStatusCode.OK);
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
                        Assert.AreEqual(response.Status, (int)HttpStatusCode.OK);
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
        internal async Task<AddParticipantResult> AddParticipantOperation(CallConnection callConnection, string participantUserId)
        {
            Console.WriteLine("Performing add participant operation to add a participant");

            var response = await callConnection.AddParticipantAsync(new CommunicationUserIdentifier(participantUserId)).ConfigureAwait(false);

            Assert.AreEqual(false, string.IsNullOrEmpty(response.Value.OperationId));

            return response.Value;
        }

        internal async Task<AddParticipantResult> AddParticipantOperation(CallingServerClient callingServerClient, CallLocator callLocator, string participantUserId)
        {
            Console.WriteLine("Performing add participant operation to add a participant");

            var response = await callingServerClient.AddParticipantAsync(
                callLocator,
                new CommunicationUserIdentifier(participantUserId),
                callbackUri: new Uri(TestEnvironment.AppCallbackUrl)
                ).ConfigureAwait(false);

            Assert.AreEqual(false, string.IsNullOrEmpty(response.Value.OperationId));

            return response.Value;
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_AddParticipantOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_RemoveParticipantOperation
        internal async Task RemoveParticipantOperation(CallConnection callConnection, string participantUserId)
        {
            Console.WriteLine("Performing remove participant operation to remove a participant");

            var participant = new CommunicationUserIdentifier(participantUserId);

            var response = await callConnection.RemoveParticipantAsync(participant).ConfigureAwait(false);

            Assert.AreEqual(202, response.Status);
        }

        internal async Task RemoveParticipantOperation(CallingServerClient callingServerClient, CallLocator callLocator, string participantUserId)
        {
            Console.WriteLine("Performing remove participant operation to remove a participant");

            var participant = new CommunicationUserIdentifier(participantUserId);

            var response = await callingServerClient.RemoveParticipantAsync(callLocator, participant).ConfigureAwait(false);

            Assert.AreEqual(202, response.Status);
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_RemoveParticipantOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_MuteParticipant
        internal async Task MuteParticipant(CallConnection callConnection, string participantUserId)
        {
            Console.WriteLine("Performing mute participant to mute a participant");

            var response = await callConnection.MuteParticipantAsync(new CommunicationUserIdentifier(participantUserId)).ConfigureAwait(false);

            Assert.AreEqual(200, response.Status);
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_MuteParticipant

        #region Snippet:Azure_Communication_ServerCalling_Tests_UnmuteParticipant
        internal async Task UnmuteParticipant(CallConnection callConnection, string participantUserId)
        {
            Console.WriteLine("Performing unmute participant to unmute a participant");

            var response = await callConnection.UnmuteParticipantAsync(new CommunicationUserIdentifier(participantUserId)).ConfigureAwait(false);

            Assert.AreEqual(200, response.Status);
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_UnmuteParticipant

        #region Snippet:Azure_Communication_ServerCalling_Tests_GetParticipant
        internal async Task<CallParticipant> GetParticipant(CallConnection callConnection, string participantUserId)
        {
            Console.WriteLine("Performing get participant to get a participant");

            var response = await callConnection.GetParticipantAsync(new CommunicationUserIdentifier(participantUserId)).ConfigureAwait(false);

            Assert.IsFalse(string.IsNullOrWhiteSpace(response.Value.ToString()));

            return response.Value;
        }

        internal async Task<CallParticipant> GetParticipant(CallingServerClient callingServerClient, CallLocator callLocator, string participantUserId)
        {
            Console.WriteLine("Performing get participant to get a participant");

            var response = await callingServerClient.GetParticipantAsync(callLocator, new CommunicationUserIdentifier(participantUserId)).ConfigureAwait(false);

            Assert.IsFalse(string.IsNullOrWhiteSpace(response.Value.ToString()));

            return response.Value;
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_GetParticipant

        #region Snippet:Azure_Communication_ServerCalling_Tests_GetParticipants
        internal async Task<IEnumerable<CallParticipant>> GetParticipants(CallConnection callConnection)
        {
            Console.WriteLine("Performing get participants to get participants");

            var response = await callConnection.GetParticipantsAsync().ConfigureAwait(false);

            Assert.IsFalse(string.IsNullOrWhiteSpace(response.Value.ToString()));

            return response.Value;
        }

        internal async Task<IEnumerable<CallParticipant>> GetParticipants(CallingServerClient callingServerClient, CallLocator callLocator)
        {
            Console.WriteLine("Performing get participants to get participants");

            var response = await callingServerClient.GetParticipantsAsync(callLocator).ConfigureAwait(false);

            Assert.IsFalse(string.IsNullOrWhiteSpace(response.Value.ToString()));

            return response.Value;
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_GetParticipants

        #region Snippet:Azure_Communication_ServerCalling_Tests_GetCall
        internal async Task<CallConnectionProperties> GetCall(CallConnection callConnection)
        {
            Console.WriteLine("Performing get call operation");

            var response = await callConnection.GetCallAsync().ConfigureAwait(false);

            Assert.IsFalse(string.IsNullOrWhiteSpace(response.Value.ToString()));

            return response.Value;
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_GetCall

        #region Snippet:Azure_Communication_ServerCalling_Tests_HoldParticipant
        internal async Task HoldParticipant(CallConnection callConnection, string participantUserId)
        {
            Console.WriteLine("Performing hold participant to hold a participant");

            var response = await callConnection.HoldParticipantMeetingAudioAsync(new CommunicationUserIdentifier(participantUserId)).ConfigureAwait(false);

            Assert.AreEqual(200, response.Status);
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_HoldParticipant

        #region Snippet:Azure_Communication_ServerCalling_Tests_ResumeParticipant
        internal async Task ResumeParticipant(CallConnection callConnection, string participantUserId)
        {
            Console.WriteLine("Performing resume participant to resume a participant");

            var response = await callConnection.ResumeParticipantMeetingAudioAsync(new CommunicationUserIdentifier(participantUserId)).ConfigureAwait(false);

            Assert.AreEqual(200, response.Status);
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_ResumeParticipant

        #region Snippet:Azure_Communication_ServerCalling_Tests_KeepAlive
        internal async Task KeepAlive(CallConnection callConnection)
        {
            Console.WriteLine("Performing keep alive operation");

            var response = await callConnection.KeepAliveAsync().ConfigureAwait(false);

            Assert.AreEqual(200, response.Status);
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_KeepAlive

        #region Snippet:Azure_Communication_ServerCalling_Tests_DeleteCall
        internal async Task DeleteCall(CallConnection callConnection)
        {
            Console.WriteLine("Performing delete call operation");

            var response = await callConnection.DeleteAsync().ConfigureAwait(false);

            Assert.AreEqual(202, response.Status);
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_DeleteCall

        #region Snippet:Azure_Communication_ServerCalling_Tests_TransferCallToParticipantOperation
        internal async Task<TransferCallResult> TransferCallToParticipantOperation(CallConnection callConnection, string targetParticipant)
        {
            Console.WriteLine("Performing transfer call to partcipant operation to transfer a call to target participant");

            var response = await callConnection.TransferToParticipantAsync(new CommunicationUserIdentifier(targetParticipant)).ConfigureAwait(false);

            Assert.AreEqual(response.Value.Status, CallingOperationStatus.Running);

            return response.Value;
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_TransferCallToParticipantOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_TransferCallOperation
        internal async Task<Response<TransferCallResult>> TransferCallOperation(CallConnection callConnection, string targetCallConnectionId)
        {
            Console.WriteLine("Performing transfer call operation to transfer a call");

            var response = await callConnection.TransferToCallAsync(targetCallConnectionId).ConfigureAwait(false);

            Assert.AreEqual(response.Value.Status, CallingOperationStatus.Running);

            return response;
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_TransferCallOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_PlayAudioToParticipantOperation
        internal async Task<PlayAudioResult> PlayAudioToParticipantOperation(CallConnection callConnection, string participantUserId, bool playAudioInLoop=false)
        {
            var playAudioOptions = new PlayAudioOptions()
            {
                OperationContext = PLAYAUDIO_OPERATIONCONTEXT,
                Loop = playAudioInLoop,
                AudioFileId = PLAYAUDIO_AUDIOFILEID,
                CallbackUri = new Uri(TestEnvironment.AppCallbackUrl)
            };

            Console.WriteLine("Performing PlayAudio operation");

            var response = await callConnection.PlayAudioToParticipantAsync(new CommunicationUserIdentifier(participantUserId), new Uri(GetAudioFileUrl()), playAudioOptions).ConfigureAwait(false);

            Assert.AreEqual(response.Value.Status, CallingOperationStatus.Running);

            return response.Value;
        }

        internal async Task<PlayAudioResult> PlayAudioToParticipantOperation(CallingServerClient callingServerClient, CallLocator callLocator, string participantUserId, bool playAudioInLoop=false)
        {
            var playAudioOptions = new PlayAudioOptions()
            {
                OperationContext = PLAYAUDIO_OPERATIONCONTEXT,
                Loop = playAudioInLoop,
                AudioFileId = PLAYAUDIO_AUDIOFILEID,
                CallbackUri = new Uri(TestEnvironment.AppCallbackUrl)
            };

            Console.WriteLine("Performing PlayAudio operation");

            var response = await callingServerClient.PlayAudioToParticipantAsync(callLocator, new CommunicationUserIdentifier(participantUserId), new Uri(GetAudioFileUrl()), playAudioOptions).ConfigureAwait(false);

            Assert.AreEqual(response.Value.Status, CallingOperationStatus.Running);

            return response.Value;
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_PlayAudioToParticipantOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_CancelParticipantMediaOperation
        internal async Task CancelParticipantMediaOperation(CallConnection callConnection, string participantUserId, string mediaOperationId)
        {
            Console.WriteLine("Performing Cancel Participant Media operation");

            var response = await callConnection.CancelParticipantMediaOperationAsync(new CommunicationUserIdentifier(participantUserId), mediaOperationId).ConfigureAwait(false);

            Assert.AreEqual(200, response.Status);
        }

        internal async Task CancelParticipantMediaOperation(CallingServerClient callingServerClient, CallLocator callLocator, string participantUserId, string mediaOperationId)
        {
            Console.WriteLine("Performing Cancel Participant Media operation");

            var response = await callingServerClient.CancelParticipantMediaOperationAsync(callLocator, new CommunicationUserIdentifier(participantUserId), mediaOperationId).ConfigureAwait(false);

            Assert.AreEqual(200, response.Status);
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_CancelParticipantMediaOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_CancelMediaOperation
        internal async Task CancelMediaOperation(CallingServerClient callingServerClient, CallLocator callLocator, string mediaOperationId)
        {
            Console.WriteLine("Performing Cancel Media operation");

            var response = await callingServerClient.CancelMediaOperationAsync(callLocator, mediaOperationId).ConfigureAwait(false);

            Assert.AreEqual(200, response.Status);
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_CancelMediaOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_AnswerCallOperation

        internal async Task<CallConnection> AnswerCallOperation(CallingServerClient callingServerClient)
        {
            Console.WriteLine("Performing Answer Call Operation");

            string incomingCallContext = "26fda345-3b5a-4159-b86b-260decaef2ac";

            var response = await callingServerClient.AnswerCallAsync(incomingCallContext, new List<CallMediaType> { CallMediaType.Audio },
                    new List<CallingEventSubscriptionType> { CallingEventSubscriptionType.ParticipantsUpdated }, new Uri(TestEnvironment.AppCallbackUrl)).ConfigureAwait(false);

            Assert.IsFalse(string.IsNullOrWhiteSpace(response.Value.ToString()));

            return response.Value;
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_AnswerCallOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_RejectCallOperation

        internal async Task RejectCallOperation(CallingServerClient callingServerClient)
        {
            Console.WriteLine("Performing Reject Call Operation");

            string incomingCallContext = "26fda345-3b5a-4159-b86b-260decaef2ac";

            var response = await callingServerClient.RejectCallAsync(incomingCallContext, CallRejectReason.None).ConfigureAwait(false);

            Assert.AreEqual(200, response.Status);
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_RejectCallOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_RedirectCallOperation

        internal async Task RedirectCallOperation(CallingServerClient callingServerClient, string target)
        {
            Console.WriteLine("Performing Redirect Call Operation");

            string incomingCallContext = "26fda345-3b5a-4159-b86b-260decaef2ac";

            var response = await callingServerClient.RedirectCallAsync(incomingCallContext, new CommunicationUserIdentifier(target)).ConfigureAwait(false);

            Assert.AreEqual(200, response.Status);
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_RedirectCallOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_CreateAudioRoutingGroupOperation
        internal async Task<CreateAudioRoutingGroupResult> CreateAudioRoutingGroupOperation(CallConnection callConnection, List<CommunicationUserIdentifier> participantUserId)
        {
            Console.WriteLine("Performing Create Audio Routing Group operation");

            var response = await callConnection.CreateAudioRoutingGroupAsync(AudioRoutingMode.Multicast, participantUserId).ConfigureAwait(false);

            Assert.IsFalse(string.IsNullOrWhiteSpace(response.Value.ToString()));

            return response.Value;
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_CreateAudioRoutingGroupOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_GetAudioRoutingGroupOperation
        internal async Task<AudioRoutingGroupResult> GetAudioRoutingGroupOperation(CallConnection callConnection, string audioRoutingGroupId)
        {
            Console.WriteLine("Performing Get Audio Routing Group operation");

            var response = await callConnection.GetAudioRoutingGroupsAsync(audioRoutingGroupId).ConfigureAwait(false);

            Assert.IsFalse(string.IsNullOrWhiteSpace(response.Value.ToString()));

            return response.Value;
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_GetAudioRoutingGroupOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_UpdateAudioRoutingGroupOperation
        internal async Task UpdateAudioRoutingGroupOperation(CallConnection callConnection, string audioRoutingGroupId, List<CommunicationUserIdentifier> participantUserId)
        {
            Console.WriteLine("Performing Update Audio Routing Group operation");

            var response = await callConnection.UpdateAudioRoutingGroupAsync(audioRoutingGroupId, participantUserId).ConfigureAwait(false);

            Assert.AreEqual(200, response.Status);
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_UpdateAudioRoutingGroupOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_DeleteAudioRoutingGroupOperation
        internal async Task DeleteAudioRoutingGroupOperation(CallConnection callConnection, string audioRoutingGroupId)
        {
            Console.WriteLine("Performing Delete Audio Routing Group operation");

            var response = await callConnection.DeleteAudioRoutingGroupAsync(audioRoutingGroupId).ConfigureAwait(false);

            Assert.AreEqual(200, response.Status);
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_DeleteAudioRoutingGroupOperation
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

        protected async Task WaitForOperationCompletion(int milliSeconds = 10000)
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

        protected async Task ValidateCallRecordingStateAsync(CallingServerClient callingServerClient,
            string recordingId,
            CallRecordingState expectedCallRecordingState)
        {
            Assert.NotNull(callingServerClient);
            Assert.NotNull(recordingId);

            // There is a delay between the action and when the state is available.
            // Waiting to make sure we get the updated state, when we are running
            // against a live service.
            SleepInTest(6000);

            CallRecordingProperties callRecordingProperties = await callingServerClient.GetRecordingStateAsync(recordingId).ConfigureAwait(false);
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
