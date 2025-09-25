// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
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
                InputAudioFormat = InputAudioFormat.Pcm16,
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

        [LiveOnly]
        [TestCase]
        public async Task DisableToolCalls()
        {
            var vlc = string.IsNullOrEmpty(TestEnvironment.ApiKey) ?
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new DefaultAzureCredential(true)) :
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));

            var options = new VoiceLiveSessionOptions()
            {
                Model = "gpt-4o",
                Modalities = { InteractionModality.Text },
                ToolChoice = ToolChoiceLiteral.None
            };

            options.Tools.Add(FunctionCalls.AdditionDefinition);

            var session = await vlc.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            // Should get two updates back.
            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();
            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            await Task.Delay(TimeSpan.FromSeconds(5)).ConfigureAwait(false);

            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            var content = new InputTextContentPart("What is 13 plus 29?");

            await session.AddItemAsync(new UserMessageItem(new[] { content }), null, TimeoutToken).ConfigureAwait(false);

            var conversationItemCreated = await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);
            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);
            var responseCreated = await GetNextUpdate<SessionUpdateResponseCreated>(updatesEnum).ConfigureAwait(false);
            var responseItems = await CollectResponseUpdates(updatesEnum, TimeoutToken).ConfigureAwait(false);

            // Ensure no tool call was made
            var responseDone = responseItems.Where((r) => r is SessionUpdateResponseFunctionCallArgumentsDone);
            Assert.IsTrue(responseDone.Count() == 0);
        }

        [LiveOnly]
        [TestCase]
        public async Task RequireToolCalls()
        {
            var vlc = string.IsNullOrEmpty(TestEnvironment.ApiKey) ?
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new DefaultAzureCredential(true)) :
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));

            var options = new VoiceLiveSessionOptions()
            {
                Model = "gpt-4o",
                Modalities = { InteractionModality.Text },
                ToolChoice = ToolChoiceLiteral.Required
            };

            options.Tools.Add(FunctionCalls.AdditionDefinition);

            var session = await vlc.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            // Should get two updates back.
            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();
            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            await Task.Delay(TimeSpan.FromSeconds(5)).ConfigureAwait(false);

            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            var content = new InputTextContentPart("Tell me a joke");

            await session.AddItemAsync(new UserMessageItem(new[] { content }), null, TimeoutToken).ConfigureAwait(false);

            var conversationItemCreated = await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);
            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);
            var responseCreated = await GetNextUpdate<SessionUpdateResponseCreated>(updatesEnum).ConfigureAwait(false);
            var responseItems = await CollectResponseUpdates(updatesEnum, TimeoutToken).ConfigureAwait(false);

            // Ensure a tool call was made
            var responseDone = responseItems.Where((r) => r is SessionUpdateResponseFunctionCallArgumentsDone);
            Assert.IsTrue(responseDone.Count() == 1);
        }

        [LiveOnly]
        [TestCase]
        public async Task RequireToolCallByName()
        {
            var vlc = string.IsNullOrEmpty(TestEnvironment.ApiKey) ?
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new DefaultAzureCredential(true)) :
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));

            var options = new VoiceLiveSessionOptions()
            {
                Model = "gpt-4o",
                Modalities = { InteractionModality.Text },
                ToolChoice = FunctionCalls.AdditionDefinition.Name
            };

            options.Tools.Add(FunctionCalls.AdditionDefinition);
            options.Tools.Add(FunctionCalls.SubtractionDefinition);

            var session = await vlc.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            // Should get two updates back.
            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();
            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            await Task.Delay(TimeSpan.FromSeconds(5)).ConfigureAwait(false);

            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            var content = new InputTextContentPart("What is 6 minus 3?");

            await session.AddItemAsync(new UserMessageItem(new[] { content }), null, TimeoutToken).ConfigureAwait(false);

            var conversationItemCreated = await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);
            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);
            var responseCreated = await GetNextUpdate<SessionUpdateResponseCreated>(updatesEnum).ConfigureAwait(false);
            var responseItems = await CollectResponseUpdates(updatesEnum, TimeoutToken).ConfigureAwait(false);

            // Ensure a tool call was made
            var responseDone = responseItems.Where((r) => r is SessionUpdateResponseDone);
            Assert.IsTrue(responseDone.Count() == 1);

            var response = SafeCast<SessionUpdateResponseDone>( responseDone.First());
            var item = SafeCast<ResponseFunctionCallItem>(response.Response.Output[0]);

            Assert.AreEqual(FunctionCalls.AdditionDefinition.Name, item.Name);
        }
    }
}
