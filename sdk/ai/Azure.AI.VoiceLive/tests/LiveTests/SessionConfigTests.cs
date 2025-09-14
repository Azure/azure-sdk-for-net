// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    public class SessionConfigTests : VoiceLiveTestBase
    {
        private HashSet<string> _eventIDs = new HashSet<string>();

        public SessionConfigTests() : base(true)
        { }

        public SessionConfigTests(bool isAsync) : base(isAsync)
        {
        }

        [Ignore("WIP")]
        [LiveOnly]
        [TestCase]
        public async Task AzureStandardVoice()
        {
            var vlc = string.IsNullOrEmpty(TestEnvironment.ApiKey) ?
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new DefaultAzureCredential(true)) :
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));

            var voice = new AzureStandardVoice("en-US-AriaNeural");

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
            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            var updatedVoice = sessionUpdated.Session.Voice;
            Assert.IsNotNull(updatedVoice);

            var standardVoice = SafeCast<AzureStandardVoice>(updatedVoice);
            Assert.AreEqual(voice.Name, standardVoice.Name);
        }
    }
}
