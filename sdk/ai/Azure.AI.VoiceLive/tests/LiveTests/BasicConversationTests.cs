// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.VoiceLive.Tests.Infrastructure;
using Azure.Core.TestFramework;
using Azure.Identity;
//using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    public class BasicConversationTests : VoiceLiveTestBase
    {
        public BasicConversationTests() : base(true)
        { }

        public BasicConversationTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Test case to send audio to the VoiceLive Service and validate the response.
        /// </summary>
        /// <remarks>
        /// The goal of the test is not to validate the content of the result for transcription accuracy or the quality
        /// of the response, but rather for the correct sequence of events and that the events are well formed.
        /// </remarks>
        /// <returns></returns>
        [LiveOnly]
        [TestCase]
        public async Task BasicHelloTest()
        {
            var vlc = string.IsNullOrEmpty(TestEnvironment.ApiKey) ?
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new DefaultAzureCredential(true)) :
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));

            var options = new VoiceLiveSessionOptions()
            {
                Model = "gpt-4o",
                InputAudioFormat = InputAudioFormat.Pcm16
            };

            var session = await vlc.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            // Should get two updates back.
            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();

            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            Assert.AreEqual(sessionUpdated.Session.InputAudioFormat, InputAudioFormat.Pcm16);
            Assert.AreEqual(sessionCreated.Session.Id, sessionUpdated.Session.Id);
            Assert.AreEqual(sessionCreated.Session.Model, sessionUpdated.Session.Model);
            Assert.AreEqual(sessionCreated.Session.Agent, sessionUpdated.Session.Agent);
            Assert.AreEqual(sessionCreated.Session.Animation, sessionUpdated.Session.Animation);
            Assert.AreEqual(sessionCreated.Session.Avatar, sessionUpdated.Session.Avatar);
            Assert.AreEqual(sessionCreated.Session.InputAudioEchoCancellation, sessionUpdated.Session?.InputAudioEchoCancellation);

            // Flow audio to the service.
            await SendAudioAsync(session, "Weather.wav").ConfigureAwait(false);

            // Now we get a speech started
            var speechStarted = await GetNextUpdate<SessionUpdateInputAudioBufferSpeechStarted>(updatesEnum).ConfigureAwait(false);
            Assert.IsTrue(speechStarted.AudioStart >= TimeSpan.Zero);

            var inputAudioId = speechStarted.ItemId;

            var speechEnded = await GetNextUpdate<SessionUpdateInputAudioBufferSpeechStopped>(updatesEnum).ConfigureAwait(false);
            Assert.AreEqual(inputAudioId, speechEnded.ItemId);
            Assert.IsTrue(speechEnded.AudioEnd > speechStarted.AudioStart);

            var bufferCommitted = await GetNextUpdate<SessionUpdateInputAudioBufferCommitted>(updatesEnum).ConfigureAwait(false);
            Assert.AreEqual(inputAudioId, bufferCommitted.ItemId);

            var transcript = await GetNextUpdate<SessionUpdateConversationItemInputAudioTranscriptionCompleted>(updatesEnum).ConfigureAwait(false);
            Assert.AreEqual(inputAudioId, transcript.ItemId);
            Assert.IsFalse(string.IsNullOrWhiteSpace(transcript.Transcript));

            var conversationItemCreated = await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);
            Assert.IsTrue(conversationItemCreated.PreviousItemId == null);
            Assert.IsTrue(conversationItemCreated.Item.Type == ItemType.Message);

            var message = SafeCast<ResponseMessageItem>(conversationItemCreated.Item);
            Assert.AreEqual(ResponseMessageRole.User, message.Role);
            Assert.AreEqual(1, message.Content.Count);
            Assert.AreEqual(ContentPartType.InputAudio, message.Content[0].Type);

            // TODO: Confusing that this isn't InputAudioContentPart.
            var contentPart = SafeCast<RequestAudioContentPart>(message.Content[0]);
            Assert.AreEqual(transcript.Transcript, contentPart.Transcript);

            var responseCreated = await GetNextUpdate<SessionUpdateResponseCreated>(updatesEnum).ConfigureAwait(false);

            var responseItems = await CollectResponseUpdates(updatesEnum, TimeoutToken).ConfigureAwait(false);

            Assert.IsTrue(responseItems.Count() > 0);

            responseItems.Insert(0, responseCreated);

            ValidateResponseUpdates(responseItems, message.Id);
        }

        [LiveOnly]
        [TestCase]
        public async Task BasicToolCallTest()
        {
            var vlc = string.IsNullOrEmpty(TestEnvironment.ApiKey) ?
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new DefaultAzureCredential(true)) :
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));

            var options = new VoiceLiveSessionOptions()
            {
                Model = "gpt-4o",
                Modalities = { InputModality.Text }
            };

            options.Tools.Add(FunctionCalls.AdditionDefinition);

            var session = await vlc.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            // Should get two updates back.
            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();

            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);

            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            Assert.AreEqual(sessionUpdated.Session.InputAudioFormat, InputAudioFormat.Pcm16);
            Assert.AreEqual(sessionCreated.Session.Id, sessionUpdated.Session.Id);
            Assert.AreEqual(sessionCreated.Session.Model, sessionUpdated.Session.Model);
            Assert.AreEqual(sessionCreated.Session.Agent, sessionUpdated.Session.Agent);
            Assert.AreEqual(sessionCreated.Session.Animation, sessionUpdated.Session.Animation);
            Assert.AreEqual(sessionCreated.Session.Avatar, sessionUpdated.Session.Avatar);
            Assert.AreEqual(sessionCreated.Session.InputAudioEchoCancellation, sessionUpdated.Session?.InputAudioEchoCancellation);

            var content = new InputTextContentPart("What is 13 plus 29?");

            await session.AddItemAsync(new UserMessageItem(new[] { content }), null, TimeoutToken).ConfigureAwait(false);

            var conversationItemCreated = await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);
            Assert.IsTrue(string.IsNullOrEmpty(conversationItemCreated.PreviousItemId));
            var message = SafeCast<ResponseMessageItem>(conversationItemCreated.Item);
            Assert.AreEqual(ResponseMessageRole.User, message.Role);
            Assert.AreEqual(1, message.Content.Count);
            Assert.AreEqual(ContentPartType.InputText, message.Content[0].Type);
            var textPart = SafeCast<RequestTextContentPart>(message.Content[0]);
            Assert.AreEqual(content.Text, textPart.Text);

            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);
            var responseCreated = await GetNextUpdate<SessionUpdateResponseCreated>(updatesEnum).ConfigureAwait(false);
            var responseItems = await CollectResponseUpdates(updatesEnum, TimeoutToken).ConfigureAwait(false);
            Assert.IsTrue(responseItems.Count() > 0);
            responseItems.Insert(0, responseCreated);
            ValidateResponseUpdates(responseItems, string.Empty);

            var callDone = responseItems.Where((s) =>
            {
                return s is SessionUpdateResponseFunctionCallArgumentsDone;
            });

            Assert.IsTrue(callDone.Count() == 1);
            var callInfo = SafeCast<SessionUpdateResponseFunctionCallArgumentsDone>(callDone.First());

            await session.AddItemAsync(new FunctionCallOutputItem(callInfo.CallId, "42"), TimeoutToken).ConfigureAwait(false);
            var conversationItemCreated2 = await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);

            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);

            var functionResponses = await CollectResponseUpdates(updatesEnum, TimeoutToken).ConfigureAwait(false);
        }

        [LiveOnly]
        [TestCase]
        public async Task PrallelToolCallTest()
        {
            var vlc = string.IsNullOrEmpty(TestEnvironment.ApiKey) ?
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new DefaultAzureCredential(true)) :
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));

            var options = new VoiceLiveSessionOptions()
            {
                Model = "gpt-4o",
                Modalities = { InputModality.Text }
            };

            options.Tools.Add(FunctionCalls.AdditionDefinition);

            var session = await vlc.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            // Should get two updates back.
            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();

            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);

            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            Assert.AreEqual(sessionUpdated.Session.InputAudioFormat, InputAudioFormat.Pcm16);
            Assert.AreEqual(sessionCreated.Session.Id, sessionUpdated.Session.Id);
            Assert.AreEqual(sessionCreated.Session.Model, sessionUpdated.Session.Model);
            Assert.AreEqual(sessionCreated.Session.Agent, sessionUpdated.Session.Agent);
            Assert.AreEqual(sessionCreated.Session.Animation, sessionUpdated.Session.Animation);
            Assert.AreEqual(sessionCreated.Session.Avatar, sessionUpdated.Session.Avatar);
            Assert.AreEqual(sessionCreated.Session.InputAudioEchoCancellation, sessionUpdated.Session?.InputAudioEchoCancellation);

            var content1 = new InputTextContentPart("What is 13 plus 29?");
            var content2 = new InputTextContentPart("What is 87 plus 11?");

            await session.AddItemAsync(new UserMessageItem(new[] { content1, content2 }), null, TimeoutToken).ConfigureAwait(false);

            var conversationItemCreated = await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);
            var message = SafeCast<ResponseMessageItem>(conversationItemCreated.Item);
            Assert.AreEqual(ResponseMessageRole.User, message.Role);
            Assert.AreEqual(2, message.Content.Count);
            Assert.AreEqual(ContentPartType.InputText, message.Content[0].Type);
            var textPart1 = SafeCast<RequestTextContentPart>(message.Content[0]);
            Assert.AreEqual(content1.Text, textPart1.Text);
            Assert.AreEqual(ContentPartType.InputText, message.Content[1].Type);
            var textPart2 = SafeCast<RequestTextContentPart>(message.Content[1]);
            Assert.AreEqual(content2.Text, textPart2.Text);

            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);
            var responseCreated = await GetNextUpdate<SessionUpdateResponseCreated>(updatesEnum).ConfigureAwait(false);
            var responseItems = await CollectResponseUpdates(updatesEnum, TimeoutToken).ConfigureAwait(false);
            Assert.IsTrue(responseItems.Count() > 0);
            responseItems.Insert(0, responseCreated);
            ValidateResponseUpdates(responseItems, string.Empty);

            var callDones = responseItems.Where((s) =>
            {
                return s is SessionUpdateResponseFunctionCallArgumentsDone;
            });
            Assert.IsTrue(callDones.Count() == 2);
            var callInfo1 = SafeCast<SessionUpdateResponseFunctionCallArgumentsDone>(callDones.First());
            var callInfo2 = SafeCast<SessionUpdateResponseFunctionCallArgumentsDone>(callDones.Last());
            await session.AddItemAsync(new FunctionCallOutputItem(callInfo1.CallId, "42"), TimeoutToken).ConfigureAwait(false);
            await session.AddItemAsync(new FunctionCallOutputItem(callInfo2.CallId, "98"), TimeoutToken).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);

            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);
            var functionResponses = await CollectResponseUpdates(updatesEnum, TimeoutToken).ConfigureAwait(false);
        }

        [Ignore("Truncate isn't currently supported")]
        [LiveOnly]
        [TestCase]
        public async Task Truncate()
        {
            var vlc = string.IsNullOrEmpty(TestEnvironment.ApiKey) ?
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new DefaultAzureCredential(true)) :
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));

            var options = new VoiceLiveSessionOptions()
            {
                Model = "gpt-4o",
                Modalities = { InputModality.Text }
            };

            var session = await vlc.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            // Should get two updates back.
            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();

            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            await session.AddItemAsync(new UserMessageItem(new InputTextContentPart("Hello")), null, TimeoutToken).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);

            await session.AddItemAsync(new AssistantMessageItem(new OutputTextContentPart("Hello, how can I help you?")), null, TimeoutToken).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);

            await session.AddItemAsync(new UserMessageItem(new InputTextContentPart("My name is Bill")), null, TimeoutToken).ConfigureAwait(false);
            var q1 = await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);

            await session.AddItemAsync(new AssistantMessageItem(new OutputTextContentPart("Hello Bill")), null, TimeoutToken).ConfigureAwait(false);
            var q2 = await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);

            await session.AddItemAsync(new UserMessageItem(new InputTextContentPart("My name is Ted")), null, TimeoutToken).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);

            await session.AddItemAsync(new AssistantMessageItem(new OutputTextContentPart("ok")), null, TimeoutToken).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);

            await session.TruncateConversationAsync(q1.Item.Id, 0, default, TimeoutToken).ConfigureAwait(false);
            //await session.DeleteItemAsync(q1.Item.Id, TimeoutToken).ConfigureAwait(false);

            await session.AddItemAsync(new UserMessageItem(new InputTextContentPart("What's my name?")), null, TimeoutToken).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);
            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);
            var responses = await CollectResponseUpdates(updatesEnum, TimeoutToken).ConfigureAwait(false);
            Assert.IsTrue(responses.Count > 0);
            var responseDone = responses.Where((r) => r is SessionUpdateResponseDone);
            Assert.IsTrue(responseDone.Count() == 1);
            var response = SafeCast<SessionUpdateResponseDone>(responseDone.First());
            Assert.IsNotNull(response.Response);
            var outputItems = response.Response.Output.Where((item) =>
                {
                    if (item is not ResponseMessageItem)
                    {
                        return false;
                    }
                    var message = SafeCast<ResponseMessageItem>(item);
                    return true;
                });
            Assert.IsTrue(outputItems.Count() == 1);
            var messageItem = SafeCast<ResponseMessageItem>(outputItems.First());
            var textParts = messageItem.Content.Where((part) => part.Type == ContentPartType.Text);
            Assert.IsTrue(textParts.Count() == 1);
            var textPart = SafeCast<ResponseTextContentPart>(textParts.First());
            StringAssert.Contains("Ted", textPart.Text);
        }

        [LiveOnly]
        [TestCase]
        public async Task DefaultAndUpdateTurnDetectionAzureSemanticVadEnTurnDetection()
        {
            var vlc = string.IsNullOrEmpty(TestEnvironment.ApiKey) ?
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new DefaultAzureCredential(true)) :
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));

            var options = new VoiceLiveSessionOptions()
            {
                Model = "gpt-4o",
                InputAudioFormat = InputAudioFormat.Pcm16,
                TurnDetection = new AzureSemanticVadEnTurnDetection()
            };

            var session = await vlc.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            // Should get two updates back.
            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();

            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            var defaultTurnDetection = sessionCreated.Session.TurnDetection;
            Assert.IsTrue(defaultTurnDetection is ServerVadTurnDetection, $"Default turn detection was {defaultTurnDetection.GetType().Name} and not {typeof(ServerVadTurnDetection).Name}");

            var modifiedTurnDetection = sessionUpdated.Session.TurnDetection;
            Assert.IsTrue(modifiedTurnDetection is AzureSemanticVadEnTurnDetection, $"Updated turn detection was {modifiedTurnDetection.GetType().Name} and not {typeof(AzureSemanticVadEnTurnDetection).Name}");
        }

        [LiveOnly]
        [TestCase]
        public async Task InstructionTest()
        {
            var vlc = string.IsNullOrEmpty(TestEnvironment.ApiKey) ?
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new DefaultAzureCredential(true)) :
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));

            var options = new VoiceLiveSessionOptions()
            {
                Model = "gpt-4o",
                Modalities = { InputModality.Text },
                Instructions = "Your name is Frank. Never forget that!"
            };

            var session = await vlc.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            // Should get two updates back.
            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();

            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            var um = new UserMessageItem(new InputTextContentPart("What is your name?"));
            await session.AddItemAsync(um, null, TimeoutToken).ConfigureAwait(false);
            var conversationItemCreated = await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);

            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);
            var responses = await CollectResponseUpdates(updatesEnum, TimeoutToken).ConfigureAwait(false);
            Assert.IsTrue(responses.Count > 0);

            var responseDone = responses.Where((r) => r is SessionUpdateResponseDone);
            Assert.IsTrue(responseDone.Count() == 1);
            var response = SafeCast<SessionUpdateResponseDone>(responseDone.First());
            Assert.IsNotNull(response.Response);
            var outputItems = response.Response.Output.Where((item) =>
                {
                    if (item is not ResponseMessageItem)
                    {
                        return false;
                    }
                    var message = SafeCast<ResponseMessageItem>(item);
                    return true;
                });
            Assert.IsTrue(outputItems.Count() == 1);
            var messageItem = SafeCast<ResponseMessageItem>(outputItems.First());
            var textParts = messageItem.Content.Where((part) => part.Type == ContentPartType.Text);
            Assert.IsTrue(textParts.Count() == 1);
            var textPart = SafeCast<ResponseTextContentPart>(textParts.First());
            StringAssert.Contains("Frank", textPart.Text);

            // Update the instructions
            options.Instructions = "Your name is Samantha. Never forget that!";
            await session.ConfigureSessionAsync(options, TimeoutToken).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);
            um = new UserMessageItem(new InputTextContentPart("What is your name?"));
            await session.AddItemAsync(um, null, TimeoutToken).ConfigureAwait(false);
            conversationItemCreated = await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);
            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);
            responses = await CollectResponseUpdates(updatesEnum, TimeoutToken).ConfigureAwait(false);
            Assert.IsTrue(responses.Count > 0);
            responseDone = responses.Where((r) => r is SessionUpdateResponseDone);
            Assert.IsTrue(responseDone.Count() == 1);
            response = SafeCast<SessionUpdateResponseDone>(responseDone.First());
            Assert.IsNotNull(response.Response);
            outputItems = response.Response.Output.Where((item) =>
                {
                    if (item is not ResponseMessageItem)
                    {
                        return false;
                    }
                    var message = SafeCast<ResponseMessageItem>(item);
                    return true;
                });
            Assert.IsTrue(outputItems.Count() == 1);
            messageItem = SafeCast<ResponseMessageItem>(outputItems.First());
            textParts = messageItem.Content.Where((part) => part.Type == ContentPartType.Text);
            Assert.IsTrue(textParts.Count() == 1);
            textPart = SafeCast<ResponseTextContentPart>(textParts.First());
            StringAssert.Contains("Samantha", textPart.Text);
        }

        [Ignore("NoTurnDetection nto returned on update, even though it works")]
        [LiveOnly]
        [TestCase]
        public async Task DefaultAndUpdateTurnDetectionNoTurnDetection()
        {
            var vlc = string.IsNullOrEmpty(TestEnvironment.ApiKey) ?
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new DefaultAzureCredential(true)) :
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));

            var options = new VoiceLiveSessionOptions()
            {
                Model = "gpt-4o",
                InputAudioFormat = InputAudioFormat.Pcm16,
                TurnDetection = new NoTurnDetection()
            };

            var session = await vlc.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            // Should get two updates back.
            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();

            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            var defaultTurnDetection = sessionCreated.Session.TurnDetection;
            Assert.IsTrue(defaultTurnDetection is ServerVadTurnDetection, $"Default turn detection was {defaultTurnDetection.GetType().Name} and not {typeof(ServerVadTurnDetection).Name}");

            var modifiedTurnDetection = sessionUpdated.Session.TurnDetection;
            Assert.IsTrue(modifiedTurnDetection is NoTurnDetection, $"Updated turn detection was {modifiedTurnDetection?.GetType().Name} and not {typeof(NoTurnDetection).Name}");
        }

        [LiveOnly]
        [TestCase]
        public async Task DefaultAndUpdateTurnDetectionAzureSemanticVadMultilingualTurnDetection()
        {
            var vlc = string.IsNullOrEmpty(TestEnvironment.ApiKey) ?
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new DefaultAzureCredential(true)) :
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));

            var options = new VoiceLiveSessionOptions()
            {
                Model = "gpt-4o",
                InputAudioFormat = InputAudioFormat.Pcm16,
                TurnDetection = new AzureSemanticVadMultilingualTurnDetection()
            };

            var session = await vlc.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            // Should get two updates back.
            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();

            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            var defaultTurnDetection = sessionCreated.Session.TurnDetection;
            Assert.IsTrue(defaultTurnDetection is ServerVadTurnDetection, $"Default turn detection was {defaultTurnDetection.GetType().Name} and not {typeof(ServerVadTurnDetection).Name}");

            var modifiedTurnDetection = sessionUpdated.Session.TurnDetection;
            Assert.IsTrue(modifiedTurnDetection is AzureSemanticVadMultilingualTurnDetection, $"Updated turn detection was {modifiedTurnDetection.GetType().Name} and not {typeof(AzureSemanticVadMultilingualTurnDetection).Name}");
        }

        [LiveOnly]
        [TestCase]
        public async Task ClearBufferAndGetResult()
        {
            var vlc = string.IsNullOrEmpty(TestEnvironment.ApiKey) ?
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new DefaultAzureCredential(true)) :
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));

            var options = new VoiceLiveSessionOptions()
            {
                Model = "gpt-4o",
                InputAudioFormat = InputAudioFormat.Pcm16,
                TurnDetection = new NoTurnDetection()
            };

            var session = await vlc.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            // Should get two updates back.
            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();

            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            // Now send audio:
            await SendAudioAsync(session, "Weather.wav").ConfigureAwait(false);
            await session.ClearInputAudioAsync(TimeoutToken).ConfigureAwait(false);

            await SendAudioAsync(session, "kws_howoldareyou.wav").ConfigureAwait(false);

            await session.CommitInputAudioAsync(TimeoutToken).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateInputAudioBufferCommitted>(updatesEnum).ConfigureAwait(false);

            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);

            var responses = await CollectResponseUpdates(updatesEnum, TimeoutToken).ConfigureAwait(false);
            Assert.IsTrue(responses.Count > 0);

            var responseDone = responses.Where((r) => r is SessionUpdateResponseDone);
            Assert.IsTrue(responseDone.Count() == 1);
            var response = SafeCast<SessionUpdateResponseDone>(responseDone.First());

            Assert.IsNotNull(response.Response);
            var outputItems = response.Response.Output.Where((item) =>
                {
                    if (item is not ResponseMessageItem)
                    {
                        return false;
                    }
                    var message = SafeCast<ResponseMessageItem>(item);

                    return true;
                });
        }

        [LiveOnly]
        [TestCase]
        public async Task SendMultipleAudioFrames()
        {
            var vlc = string.IsNullOrEmpty(TestEnvironment.ApiKey) ?
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new DefaultAzureCredential(true)) :
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));

            var options = new VoiceLiveSessionOptions()
            {
                Model = "gpt-4o",
                InputAudioFormat = InputAudioFormat.Pcm16,
                TurnDetection = new NoTurnDetection()
            };

            var session = await vlc.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            // Should get two updates back.
            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();

            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            for (int i = 0; i < 300; i++)
            {
                await session.SendInputAudioAsync(BinaryData.FromBytes(new byte[3200]), TimeoutToken).ConfigureAwait(false);
            }

            // error
            await session.CommitInputAudioAsync(TimeoutToken).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateInputAudioBufferCommitted>(updatesEnum).ConfigureAwait(false);

            await session.ClearInputAudioAsync(TimeoutToken).ConfigureAwait(false);

            // Now send audio:
            await SendAudioAsync(session, "Weather.wav").ConfigureAwait(false);

            var speechDetected = await GetNextUpdate<SessionUpdateInputAudioBufferSpeechStarted>(updatesEnum).ConfigureAwait(false);
        }

        private void ValidateResponseUpdates(List<SessionUpdate> responseItems, string previousItemId)
        {
            var responseId = string.Empty;
            var responseItemId = string.Empty;

            Dictionary<string, StringBuilder> deltaBuilders = new Dictionary<string, StringBuilder>();

            Stack<HashSet<string>> incompleteOutputItems = new Stack<HashSet<string>>();

            foreach (var item in responseItems)
            {
                switch (item)
                {
                    case SessionUpdateResponseCreated responseCreated:
                        Assert.AreEqual(string.Empty, responseId);
                        Assert.AreEqual(ServerEventType.ResponseCreated, responseCreated.Type);

                        var response = responseCreated.Response;
                        Assert.IsNotNull(response);
                        Assert.AreEqual(VoiceLiveResponseStatus.InProgress, response.Status);

                        responseId = response.Id;
                        incompleteOutputItems.Push(new HashSet<string>());
                        incompleteOutputItems.Peek().Add(response.Id);
                        break;

                    case SessionUpdateResponseOutputItemAdded outputItem:
                        Assert.AreEqual(responseId, outputItem.ResponseId);
                        Assert.AreEqual(0, outputItem.OutputIndex);
                        Assert.IsNotNull(outputItem.Item);

                        responseItemId = outputItem.Item.Id;

                        switch (outputItem.Item)
                        {
                            case ResponseMessageItem messageItem:
                                Assert.AreEqual(ResponseMessageRole.Assistant, messageItem.Role);
                                Assert.AreEqual(VoiceLiveResponseItemStatus.Incomplete, messageItem.Status);
                                break;
                            case ResponseFunctionCallItem functionCallItem:
                                responseItemId = functionCallItem.Id;
                                Assert.AreEqual(VoiceLiveResponseItemStatus.InProgress, functionCallItem.Status);
                                Assert.IsFalse(string.IsNullOrWhiteSpace(functionCallItem.Name));

                                deltaBuilders.Add(functionCallItem.CallId, new StringBuilder());
                                break;
                            default:
                                Assert.Fail($"Unknown output item type {outputItem.Item.GetType()}");
                                break;
                        }
                        break;

                    case SessionUpdateConversationItemCreated newConversationItem:
                        Assert.AreEqual(previousItemId, newConversationItem.PreviousItemId);
                        Assert.IsNotNull(newConversationItem.Item);

                        switch (newConversationItem.Item)
                        {
                            case ResponseMessageItem messageItem:
                                Assert.AreEqual(ResponseMessageRole.Assistant, messageItem.Role);
                                break;

                            case ResponseFunctionCallItem functionCallItem:
                                break;

                            default:
                                Assert.Fail($"Unknown conversation item type {newConversationItem.Item.GetType()}");
                                break;
                        }
                        break;

                    case SessionUpdateResponseContentPartAdded contentPartAdded:
                        Assert.AreEqual(responseId, contentPartAdded.ResponseId);
                        Assert.AreEqual(responseItemId, contentPartAdded.ItemId);
                        Assert.IsNotNull(contentPartAdded.Part);
                        Assert.IsTrue(contentPartAdded.OutputIndex == 0);
                        Assert.IsTrue(contentPartAdded.ContentIndex >= 0);

                        deltaBuilders.Add(contentPartAdded.ItemId, new StringBuilder());

                        switch (contentPartAdded.Part)
                        {
                            case ResponseTextContentPart textPart:
                                Assert.IsFalse(string.IsNullOrWhiteSpace(textPart.Text));
                                break;
                            case ResponseAudioContentPart audioPart:
                                Assert.IsTrue(string.IsNullOrWhiteSpace(audioPart.Transcript));
                                break;
                            default:
                                Assert.Fail($"Unknown content part type {contentPartAdded.Part.GetType()}");
                                break;
                        }
                        break;

                    case SessionUpdateResponseAudioTranscriptDelta audioTranscriptDelta:
                        Assert.AreEqual(responseId, audioTranscriptDelta.ResponseId);
                        Assert.AreEqual(responseItemId, audioTranscriptDelta.ItemId);
                        Assert.IsFalse(string.IsNullOrEmpty(audioTranscriptDelta.Delta));
                        deltaBuilders[audioTranscriptDelta.ItemId].Append(audioTranscriptDelta.Delta);
                        break;

                    case SessionUpdateResponseAudioDelta audioDelta:
                        Assert.AreEqual(responseId, audioDelta.ResponseId);
                        Assert.AreEqual(responseItemId, audioDelta.ItemId);
                        Assert.IsFalse(audioDelta.Delta.ToMemory().IsEmpty);
                        Console.WriteLine($"Audio delta length: {audioDelta.Delta.ToMemory().Length}");
                        break;

                    case SessionUpdateResponseAudioDone audioDone:
                        Assert.AreEqual(responseId, audioDone.ResponseId);
                        Assert.AreEqual(responseItemId, audioDone.ItemId);
                        break;

                    case SessionUpdateResponseAudioTranscriptDone done:
                        Assert.AreEqual(responseId, done.ResponseId);
                        Assert.AreEqual(responseItemId, done.ItemId);
                        Assert.IsFalse(string.IsNullOrEmpty(done.Transcript));
                        Assert.AreEqual(done.Transcript.Length, deltaBuilders[done.ItemId].ToString().Length);
                        Assert.AreEqual(done.Transcript, deltaBuilders[done.ItemId].ToString());
                        break;

                    case SessionUpdateResponseContentPartDone contentDone:
                        Assert.AreEqual(responseId, contentDone.ResponseId);
                        Assert.AreEqual(responseItemId, contentDone.ItemId);

                        switch (contentDone.Part)
                        {
                            case ResponseTextContentPart textPart:
                                Assert.IsFalse(string.IsNullOrWhiteSpace(textPart.Text));
                                Assert.AreEqual(textPart.Text.Length, deltaBuilders[contentDone.ItemId].ToString().Length);
                                Assert.AreEqual(textPart.Text, deltaBuilders[contentDone.ItemId].ToString());
                                break;
                            case ResponseAudioContentPart audioPart:
                                Assert.IsFalse(string.IsNullOrWhiteSpace(audioPart.Transcript));
                                Assert.AreEqual(audioPart.Transcript, deltaBuilders[contentDone.ItemId].ToString());
                                break;
                            default:
                                Assert.Fail($"Unknown content part type {contentDone.Part.GetType()}");
                                break;
                        }
                        break;

                    case SessionUpdateResponseOutputItemDone responseOutputDone:
                        Assert.AreEqual(responseId, responseOutputDone.ResponseId);

                        switch (responseOutputDone.Item)
                        {
                            case ResponseMessageItem messageItem:
                                Assert.AreEqual(ResponseMessageRole.Assistant, messageItem.Role);
                                Assert.AreEqual(VoiceLiveResponseItemStatus.Completed, messageItem.Status);
                                Assert.IsTrue(messageItem.Content.Count > 0);

                                switch (messageItem.Content[0])
                                {
                                    case ResponseTextContentPart textPart:
                                        Assert.IsFalse(string.IsNullOrWhiteSpace(textPart.Text));
                                        Assert.AreEqual(textPart.Text.Length, deltaBuilders[messageItem.Id].ToString().Length);
                                        Assert.AreEqual(textPart.Text, deltaBuilders[messageItem.Id].ToString());
                                        break;
                                    case ResponseAudioContentPart audioPart:
                                        Assert.IsFalse(string.IsNullOrWhiteSpace(audioPart.Transcript));
                                        Assert.AreEqual(audioPart.Transcript, deltaBuilders[messageItem.Id].ToString());
                                        break;
                                    default:
                                        Assert.Fail($"Unknown content part type {messageItem.Content[0].GetType()}");
                                        break;
                                }
                                break;

                            case ResponseFunctionCallItem functionCallItem:
                                Assert.AreEqual(VoiceLiveResponseItemStatus.Completed, functionCallItem.Status);
                                Assert.IsFalse(string.IsNullOrWhiteSpace(functionCallItem.Name));
                                Assert.AreEqual(functionCallItem.Arguments, deltaBuilders[functionCallItem.CallId].ToString());
                                break;

                            default:
                                Assert.Fail($"Unknown output item type {responseOutputDone.Item.GetType()}");
                                break;
                        }

                        break;
                    case SessionUpdateResponseDone responseDone:
                        Assert.IsNotNull(responseDone.Response);

                        Assert.AreEqual(VoiceLiveResponseStatus.Completed, responseDone.Response.Status);
                        Assert.AreEqual(responseId, responseDone.Response.Id);

                        var usage = responseDone.Response.Usage;
                        Assert.IsNotNull(usage);
                        Assert.AreEqual(usage.InputTokens,
                            usage.InputTokenDetails.AudioTokens + usage.InputTokenDetails.TextTokens + usage.InputTokenDetails.CachedTokens);
                        Assert.AreEqual(usage.InputTokenDetails.CachedTokens,
                            usage.InputTokenDetails.CachedTokensDetails.TextTokens + usage.InputTokenDetails.CachedTokensDetails.AudioTokens);
                        Assert.AreEqual(usage.OutputTokens,
                            usage.OutputTokenDetails.AudioTokens + usage.OutputTokenDetails.TextTokens);
                        Assert.AreEqual(usage.TotalTokens, usage.InputTokens + usage.OutputTokens);

                        Assert.IsTrue(responseDone.Response.Output.Count > 0);
                        switch (responseDone.Response.Output[0])
                        {
                            case ResponseMessageItem messageItem:
                                Assert.AreEqual(ResponseMessageRole.Assistant, messageItem.Role);
                                Assert.AreEqual(VoiceLiveResponseItemStatus.Completed, messageItem.Status);
                                Assert.AreEqual(responseItemId, messageItem.Id);
                                Assert.IsTrue(messageItem.Content.Count > 0);
                                switch (messageItem.Content[0])
                                {
                                    case ResponseTextContentPart textPart:
                                        Assert.IsFalse(string.IsNullOrWhiteSpace(textPart.Text));
                                        Assert.AreEqual(textPart.Text.Length, deltaBuilders[messageItem.Id].ToString().Length);
                                        Assert.AreEqual(textPart.Text, deltaBuilders[messageItem.Id].ToString());
                                        break;
                                    case ResponseAudioContentPart audioPart:
                                        Assert.IsFalse(string.IsNullOrWhiteSpace(audioPart.Transcript));
                                        Assert.AreEqual(audioPart.Transcript, deltaBuilders[messageItem.Id].ToString());
                                        break;
                                    default:
                                        Assert.Fail($"Unknown content part type {messageItem.Content[0].GetType()}");
                                        break;
                                }
                                break;

                            case ResponseFunctionCallItem functionCallItem:
                                Assert.AreEqual(VoiceLiveResponseItemStatus.Completed, functionCallItem.Status);
                                Assert.AreEqual(responseItemId, functionCallItem.Id);
                                Assert.IsFalse(string.IsNullOrWhiteSpace(functionCallItem.Name));
                                Assert.AreEqual(functionCallItem.Arguments, deltaBuilders[functionCallItem.CallId].ToString());
                                break;

                            default:
                                Assert.Fail($"Unknown output item type {responseDone.Response.Output[0].GetType()}");
                                break;
                        }
                        break;

                    case SessionUpdateResponseFunctionCallArgumentsDelta functionCallDelta:
                        Assert.AreEqual(responseId, functionCallDelta.ResponseId);
                        Assert.AreEqual(responseItemId, functionCallDelta.ItemId);
                        Assert.IsFalse(string.IsNullOrEmpty(functionCallDelta.Delta));
                        deltaBuilders[functionCallDelta.CallId].Append(functionCallDelta.Delta);
                        break;

                    case SessionUpdateResponseFunctionCallArgumentsDone functionCallDone:
                        Assert.AreEqual(responseId, functionCallDone.ResponseId);
                        Assert.AreEqual(responseItemId, functionCallDone.ItemId);
                        Assert.IsFalse(string.IsNullOrEmpty(functionCallDone.Arguments));
                        Assert.AreEqual(functionCallDone.Arguments.Length, deltaBuilders[functionCallDone.CallId].ToString().Length);
                        Assert.AreEqual(functionCallDone.Arguments, deltaBuilders[functionCallDone.CallId].ToString());
                        break;

                    default:
                        Assert.Fail($"Unknown output item type {item.GetType()}");
                        break;
                }
            }
        }
    }
}
