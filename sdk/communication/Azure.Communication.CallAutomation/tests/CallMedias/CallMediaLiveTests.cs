// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Communication.CallAutomation.Tests.Infrastructure;

namespace Azure.Communication.CallAutomation.Tests.CallMedias
{
    internal class CallMediaLiveTests : CallAutomationClientLiveTestsBase
    {
        public CallMediaLiveTests(bool isAsync) : base(isAsync)
        { }

        [Test]
        public async Task PlayAudio()
        {
            if (SkipCallAutomationInteractionLiveTests)
                Assert.Ignore("Skip CallAutomation interaction live tests flag is on.");

            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString();
            string callConnectionId = "";
            try
            {
                var user = await CreateIdentityUserAsync().ConfigureAwait(false);
                var targetUserId = TestEnvironment.TargetUserId;
                var targetUser = new CommunicationUserIdentifier(targetUserId);
                string ngrok = "https://localhost";
                string playAudioUri = "https://localhost/bot-hold-music-2.wav";
                var targets = new CommunicationIdentifier[] { targetUser };
                var createCallOptions = new CreateCallOptions(new CallSource(user), targets, new Uri(ngrok))
                {
                    RepeatabilityHeaders = new RepeatabilityHeaders(new Guid("619e45a5-41f2-40bd-a20e-98b13944e146"), new DateTimeOffset(2022, 9, 19, 22, 20, 00, new TimeSpan(0, 0, 0)))
                };
                var callResponse = await client.CreateCallAsync(createCallOptions).ConfigureAwait(false);
                Assert.NotNull(callResponse);
                Assert.NotNull(callResponse.Value);
                await WaitForOperationCompletion().ConfigureAwait(false);

                var callConnection = callResponse.Value.CallConnection;
                callConnectionId = callConnection.CallConnectionId;
                var playResponse = await callConnection.GetCallMedia().PlayAsync(
                    new FileSource(new Uri(playAudioUri)) { PlaySourceId = "playSourceId" },
                    new CommunicationUserIdentifier[] { targetUser });
                Assert.NotNull(playResponse);
                Assert.AreEqual(202, playResponse.Status);
            }
            catch (RequestFailedException ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                var callConnection = client.GetCallConnection(callConnectionId);
                var hangUpOptions = new HangUpOptions(true) {
                    RepeatabilityHeaders = new RepeatabilityHeaders(new Guid("fed6e917-f1df-4e21-b7de-c26d0947124b"), new DateTimeOffset(2022, 9, 19, 22, 20, 00, new TimeSpan(0, 0, 0)))
                };
                await callConnection.HangUpAsync(hangUpOptions).ConfigureAwait(false);
            }
        }

        [Test]
        public async Task RecognizeDtmf()
        {
            if (SkipCallAutomationInteractionLiveTests)
                Assert.Ignore("Skip CallAutomation interaction live tests flag is on.");

            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString();
            string callConnectionId = "";
            try
            {
                var user = await CreateIdentityUserAsync().ConfigureAwait(false);
                var targetUserId = TestEnvironment.TargetUserId;
                var targetUser = new CommunicationUserIdentifier(targetUserId);
                string callbackUri = TestEnvironment.AppCallbackUrl;
                string promptUrl = "https://localhost/audio/bot-hold-music-2.wav";
                var targets = new CommunicationIdentifier[] { targetUser };
                var createCallOptions = new CreateCallOptions(new CallSource(user), targets, new Uri(callbackUri))
                {
                    RepeatabilityHeaders = new RepeatabilityHeaders(new Guid("619e45a5-41f2-40bd-a20e-98b13944e146"), new DateTimeOffset(2022, 9, 19, 22, 20, 00, new TimeSpan(0, 0, 0)))
                };
                var callResponse = await client.CreateCallAsync(createCallOptions).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);
                Assert.NotNull(callResponse);
                Assert.NotNull(callResponse.Value);
                var callConnection = callResponse.Value.CallConnection;
                callConnectionId = callConnection.CallConnectionId;
                var dtmfResponse = await callConnection.GetCallMedia().StartRecognizingAsync(new CallMediaRecognizeDtmfOptions(targetUser, 5)
                {
                    InitialSilenceTimeout = TimeSpan.FromSeconds(15),
                    InterToneTimeout = TimeSpan.FromSeconds(5),
                    StopTones = new DtmfTone[] { DtmfTone.Pound },
                    Prompt = new FileSource(new Uri(promptUrl)) { PlaySourceId = "playSourceId" }
                });
                Assert.NotNull(dtmfResponse);
                Assert.AreEqual(202, dtmfResponse.Status);
            }
            catch (RequestFailedException ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                var callConnection = client.GetCallConnection(callConnectionId);
                var hangUpOptions = new HangUpOptions(true)
                {
                    RepeatabilityHeaders = new RepeatabilityHeaders(new Guid("fed6e917-f1df-4e21-b7de-c26d0947124b"), new DateTimeOffset(2022, 9, 19, 22, 20, 00, new TimeSpan(0, 0, 0)))
                };
                await callConnection.HangUpAsync(hangUpOptions).ConfigureAwait(false);
            }
        }
    }
}
