// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    public class ErrorTests : VoiceLiveTestBase
    {
        private HashSet<string> _eventIDs = new HashSet<string>();

        public ErrorTests() : base(true)
        { }

        public ErrorTests(bool isAsync) : base(isAsync)
        {
        }

        [LiveOnly]
        [TestCase]
        public async Task BadModelName()
        {
            var vlc = string.IsNullOrEmpty(TestEnvironment.ApiKey) ?
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new DefaultAzureCredential(true)) :
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));

            var voice = new AzureStandardVoice("en-US-AriaNeural");

            var options = new VoiceLiveSessionOptions()
            {
                Model = "invalidModelName",
                InputAudioFormat = AudioFormat.Pcm16,
                Voice = voice
            };

            var session = await vlc.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            // Should get two updates back.
            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();

            var sessionUpdated = await GetNextUpdate<SessionUpdateError>(updatesEnum, false).ConfigureAwait(false);
        }

        [LiveOnly]
        [TestCase]
        public async Task BadVoiceName()
        {
            var vlc = string.IsNullOrEmpty(TestEnvironment.ApiKey) ?
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new DefaultAzureCredential(true)) :
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));

            var voice = new AzureStandardVoice("NotARealVoice");

            var options = new VoiceLiveSessionOptions()
            {
                Model = "gpt-4o",
                InputAudioFormat = AudioFormat.Pcm16,
                Voice = voice
            };

            var session = await vlc.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            // Should get two updates back.
            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();

            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            var sessionUpdated = await GetNextUpdate<SessionUpdateError>(updatesEnum).ConfigureAwait(false);
            Assert.IsFalse(await updatesEnum.MoveNextAsync().ConfigureAwait(false));
        }

        [TestCase]
        public void BadEndpoint()
        {
            var vlc = new VoiceLiveClient(new Uri("wss://www.invalid"), new AzureKeyCredential("key"));

            var options = new VoiceLiveSessionOptions()
            {
                Model = "gpt-4o",
                InputAudioFormat = AudioFormat.Pcm16,
            };
            Assert.ThrowsAsync(typeof(WebSocketException), () => vlc.StartSessionAsync(options, TimeoutToken));
        }
    }
}
