// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using Microsoft.AspNetCore.Http.Features;
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
            var vlc = GetLiveClient();

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
            Assert.That(standardVoice.Name, Is.EqualTo(voice.Name));
        }

        [LiveOnly]
        [TestCase]
        public async Task DisableToolCalls()
        {
            var vlc = GetLiveClient();

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
            Assert.That(responseDone.Count() == 0, Is.True);
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
            Assert.That(responseDone.Count() == 1, Is.True);
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

            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            var content = new InputTextContentPart("What is 6 minus 3?");

            await session.AddItemAsync(new UserMessageItem(new[] { content }), null, TimeoutToken).ConfigureAwait(false);

            var conversationItemCreated = await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);
            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);
            var responseCreated = await GetNextUpdate<SessionUpdateResponseCreated>(updatesEnum).ConfigureAwait(false);
            var responseItems = await CollectResponseUpdates(updatesEnum, TimeoutToken).ConfigureAwait(false);

            // Ensure a tool call was made
            var responseDone = responseItems.Where((r) => r is SessionUpdateResponseDone);
            Assert.That(responseDone.Count() == 1, Is.True);

            var response = SafeCast<SessionUpdateResponseDone>(responseDone.First());
            var item = SafeCast<ResponseFunctionCallItem>(response.Response.Output[0]);

            Assert.That(item.Name, Is.EqualTo(FunctionCalls.AdditionDefinition.Name));
        }

        [LiveOnly]
        [TestCase]
        public async Task AnimationOutputs()
        {
            var vlc = string.IsNullOrEmpty(TestEnvironment.ApiKey) ?
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new DefaultAzureCredential(true)) :
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));

            var options = new VoiceLiveSessionOptions()
            {
                Model = "gpt-4o",
                Modalities = { InteractionModality.Text, InteractionModality.Animation },
                Animation = new AnimationOptions()
                {
                    ModelName = "default",
                    Outputs = { AnimationOutputType.VisemeId }
                },
            };

            var session = await vlc.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            // Should get two updates back.
            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();
            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);

            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            await session.AddItemAsync(new UserMessageItem("Tell me a joke"), null, TimeoutToken).ConfigureAwait(false);
            var conversationItemCreated = await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);
            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);
            var responseCreated = await GetNextUpdate<SessionUpdateResponseCreated>(updatesEnum).ConfigureAwait(false);
            var responseItems = await CollectResponseUpdates(updatesEnum, TimeoutToken).ConfigureAwait(false);
            var responseDone = responseItems.Where((r) => r is SessionUpdateResponseDone);
            Assert.That(responseDone.Count() == 1, Is.True);

            var visimeDeltas = responseItems.Where((r) =>
            {
                return r is SessionUpdateResponseAnimationVisemeDelta;
            });
            Assert.That(visimeDeltas.Count() > 0, Is.True);

            int lastOffset = 0;
            foreach (var delta in visimeDeltas)
            {
                var visemeDelta = SafeCast<SessionUpdateResponseAnimationVisemeDelta>(delta);
                Assert.That(visemeDelta.VisemeId >= 0 && visemeDelta.VisemeId <= 21, Is.True, $"VisemeId {visemeDelta.VisemeId} was not between 0 & 21");
                Assert.That(visemeDelta.AudioOffsetMs >= 0, Is.True, $"Audio offset {visemeDelta.AudioOffset} was < 0");
                Assert.That(visemeDelta.AudioOffsetMs > lastOffset, Is.True, $"Audio offset {visemeDelta.AudioOffset} was not > last offset {lastOffset}");
                lastOffset = visemeDelta.AudioOffsetMs;
            }

            var visemeDone = responseItems.Where((r) => r is SessionUpdateResponseAnimationVisemeDone);
            Assert.That(visemeDone.Count() == 1, Is.True);
        }

        [Ignore("Investigating")]
        [LiveOnly]
        [TestCase]
        public async Task AnimationOutputs_blend()
        {
            var vlc = string.IsNullOrEmpty(TestEnvironment.ApiKey) ?
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new DefaultAzureCredential(true)) :
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));

            var options = new VoiceLiveSessionOptions()
            {
                Model = "gpt-4o",
                Modalities = { InteractionModality.Text, InteractionModality.Animation },
                Animation = new AnimationOptions()
                {
                    ModelName = "default",
                    Outputs = { AnimationOutputType.Blendshapes }
                },
            };

            var session = await vlc.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            // Should get two updates back.
            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();
            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);

            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            await session.AddItemAsync(new UserMessageItem("Tell me a joke"), null, TimeoutToken).ConfigureAwait(false);
            var conversationItemCreated = await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);
            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);
            var responseCreated = await GetNextUpdate<SessionUpdateResponseCreated>(updatesEnum).ConfigureAwait(false);
            var responseItems = await CollectResponseUpdates(updatesEnum, TimeoutToken).ConfigureAwait(false);
            var responseDone = responseItems.Where((r) => r is SessionUpdateResponseDone);
            Assert.That(responseDone.Count() == 1, Is.True);

            var blendDeltas = responseItems.Where((r) =>
            {
                return r is SessionUpdateResponseAnimationBlendshapeDelta;
            });
            Assert.That(blendDeltas.Count() > 0, Is.True);

            int lastIndex = 0;
            foreach (var delta in blendDeltas)
            {
                var blendDelta = SafeCast<SessionUpdateResponseAnimationBlendshapeDelta>(delta);
                Assert.That(blendDelta.FrameIndex > lastIndex, Is.True);
                lastIndex = blendDelta.FrameIndex;
            }
        }

        [LiveOnly]
        [TestCase]
        public async Task MaxTokens()
        {
            var vlc = string.IsNullOrEmpty(TestEnvironment.ApiKey) ?
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new DefaultAzureCredential(true)) :
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));

            var options = new VoiceLiveSessionOptions()
            {
                Model = "gpt-4o",
                Modalities = { InteractionModality.Text },
                MaxResponseOutputTokens = 20
            };

            var session = await vlc.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            // Should get two updates back.
            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();
            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            Assert.That(sessionCreated.Session.MaxResponseOutputTokens.NumericValue.HasValue, Is.False);
            Assert.That(sessionCreated.Session.MaxResponseOutputTokens, Is.EqualTo(MaxResponseOutputTokensOption.CreateInfiniteMaxTokensOption()));

            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);
            Assert.That(sessionUpdated.Session.MaxResponseOutputTokens.NumericValue.HasValue, Is.True);
            Assert.That(sessionUpdated.Session.MaxResponseOutputTokens.NumericValue, Is.EqualTo(20));

            await session.AddItemAsync(new UserMessageItem("Tell me a joke"), null, TimeoutToken).ConfigureAwait(false);
            var conversationItemCreated = await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);
            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);
            var responseCreated = await GetNextUpdate<SessionUpdateResponseCreated>(updatesEnum).ConfigureAwait(false);
            var responseItems = await CollectResponseUpdates(updatesEnum, TimeoutToken).ConfigureAwait(false);
            var responseDone = responseItems.Where((r) => r is SessionUpdateResponseDone);
            Assert.That(responseDone.Count() == 1, Is.True);

            var response = SafeCast<SessionUpdateResponseDone>(responseDone.First());
            Assert.That(response.Response.Usage.OutputTokens <= 20, Is.True, $"Number of tokens used {response.Response.Usage.OutputTokens} > 20");
        }

        [LiveOnly]
        [TestCase]
        public async Task SpeechRecoOptions()
        {
            var vlc = string.IsNullOrEmpty(TestEnvironment.ApiKey) ?
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new DefaultAzureCredential(true)) :
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));

            var options = new VoiceLiveSessionOptions()
            {
                Model = "gpt-4o",
                Modalities = { InteractionModality.Text },
                InputAudioEchoCancellation = new AudioEchoCancellation(),
                InputAudioNoiseReduction = new AudioNoiseReduction()
                {
                    Type = AudioNoiseReductionType.FarField
                }
            };

            var session = await vlc.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            // Should get two updates back.
            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();
            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            Assert.That(sessionCreated.Session.MaxResponseOutputTokens.NumericValue.HasValue, Is.False);
            Assert.That(sessionCreated.Session.MaxResponseOutputTokens, Is.EqualTo(MaxResponseOutputTokensOption.CreateInfiniteMaxTokensOption()));

            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);
        }

        [LiveOnly]
        [TestCase]
        public async Task MultipleModalities()
        {
            var vlc = string.IsNullOrEmpty(TestEnvironment.ApiKey) ?
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new DefaultAzureCredential(true)) :
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));

            var options = new VoiceLiveSessionOptions()
            {
                Model = "gpt-4o",
                Modalities = { InteractionModality.Audio, InteractionModality.Avatar, InteractionModality.Animation },
            };

            var session = await vlc.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            // Should get two updates back.
            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();
            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            await session.AddItemAsync(new UserMessageItem("Tell me a joke"), null, TimeoutToken).ConfigureAwait(false);
            var conversationItemCreated = await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);

            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);
            var responseCreated = await GetNextUpdate<SessionUpdateResponseCreated>(updatesEnum).ConfigureAwait(false);
            var responseItems = await CollectResponseUpdates(updatesEnum, TimeoutToken).ConfigureAwait(false);
            var responseDone = responseItems.Where((r) => r is SessionUpdateResponseDone);
            Assert.That(responseDone.Count() == 1, Is.True);
        }
        /*
        [TestCase]
        [LiveOnly]
        public async Task BOYMWithHeaders()
        {

        }
        */
    }
}
