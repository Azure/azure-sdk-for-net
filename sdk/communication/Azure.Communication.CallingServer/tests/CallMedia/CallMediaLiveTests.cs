// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Communication.CallingServer
{
    internal class CallMediaLiveTests : CallAutomationClientLiveTestsBase
    {
        public CallMediaLiveTests(bool isAsync) : base(isAsync)
        { }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task PlayAudio()
        {
            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

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
                var callResponse = await client.CreateCallAsync(new CallSource(user), targets, new Uri(ngrok)).ConfigureAwait(false);
                Assert.NotNull(callResponse);
                Assert.NotNull(callResponse.Value);
                var callConnection = callResponse.Value.CallConnection;
                callConnectionId = callConnection.CallConnectionId;
                var playResponse = await callConnection.GetCallMedia().PlayAsync(
                    new FileSource(new Uri(playAudioUri)) { PlaySourceId = "playSourceId"},
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
                await callConnection.HangUpAsync(true).ConfigureAwait(false);
            }
        }
    }
}
