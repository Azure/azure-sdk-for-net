// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
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
            var vlc = GetLiveClient();

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

            Assert.Multiple(() =>
            {
                Assert.That(InputAudioFormat.Pcm16, Is.EqualTo(sessionUpdated.Session.InputAudioFormat));
                Assert.That(sessionUpdated.Session.Id, Is.EqualTo(sessionCreated.Session.Id));
                Assert.That(sessionUpdated.Session.Model, Is.EqualTo(sessionCreated.Session.Model));
                Assert.That(sessionUpdated.Session.Agent, Is.EqualTo(sessionCreated.Session.Agent));
                Assert.That(sessionUpdated.Session.Animation, Is.EqualTo(sessionCreated.Session.Animation));
                Assert.That(sessionUpdated.Session.Avatar, Is.EqualTo(sessionCreated.Session.Avatar));
                Assert.That(sessionUpdated.Session?.InputAudioEchoCancellation, Is.EqualTo(sessionCreated.Session.InputAudioEchoCancellation));
            });

            // Flow audio to the service.
            await SendAudioAsync(session, "What is the weather like?").ConfigureAwait(false);

            // Now we get a speech started
            var speechStarted = await GetNextUpdate<SessionUpdateInputAudioBufferSpeechStarted>(updatesEnum).ConfigureAwait(false);
            Assert.That(speechStarted.AudioStart, Is.GreaterThanOrEqualTo(TimeSpan.Zero));

            var inputAudioId = speechStarted.ItemId;

            var speechEnded = await GetNextUpdate<SessionUpdateInputAudioBufferSpeechStopped>(updatesEnum).ConfigureAwait(false);
            Assert.Multiple(() =>
            {
                Assert.That(speechEnded.ItemId, Is.EqualTo(inputAudioId));
                Assert.That(speechEnded.AudioEnd > speechStarted.AudioStart, Is.True);
            });

            var bufferCommitted = await GetNextUpdate<SessionUpdateInputAudioBufferCommitted>(updatesEnum).ConfigureAwait(false);
            Assert.That(bufferCommitted.ItemId, Is.EqualTo(inputAudioId));

            var transcript = await GetNextUpdate<SessionUpdateConversationItemInputAudioTranscriptionCompleted>(updatesEnum).ConfigureAwait(false);
            Assert.Multiple(() =>
            {
                Assert.That(transcript.ItemId, Is.EqualTo(inputAudioId));
                Assert.That(string.IsNullOrWhiteSpace(transcript.Transcript), Is.False);
            });

            var conversationItemCreated = await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);
            Assert.Multiple(() =>
            {
                Assert.That(conversationItemCreated.PreviousItemId, Is.EqualTo(null));
                Assert.That(conversationItemCreated.Item.Type, Is.EqualTo(ItemType.Message));
            });

            var message = SafeCast<SessionResponseMessageItem>(conversationItemCreated.Item);
            Assert.Multiple(() =>
            {
                Assert.That(message.Role, Is.EqualTo(ResponseMessageRole.User));
                Assert.That(message.Content.Count, Is.EqualTo(1));
            });
            Assert.That(message.Content[0].Type, Is.EqualTo(ContentPartType.InputAudio));

            // TODO: Confusing that this isn't InputAudioContentPart.
            var contentPart = SafeCast<RequestAudioContentPart>(message.Content[0]);
            Assert.That(contentPart.Transcript, Is.EqualTo(transcript.Transcript));

            var responseCreated = await GetNextUpdate<SessionUpdateResponseCreated>(updatesEnum).ConfigureAwait(false);

            var responseItems = await CollectResponseUpdates(updatesEnum, TimeoutToken).ConfigureAwait(false);

            Assert.That(responseItems.Count() > 0, Is.True);

            responseItems.Insert(0, responseCreated);

            ValidateResponseUpdates(responseItems, message.Id);
        }

        [LiveOnly]
        [TestCase]
        public async Task BasicToolCallTest()
        {
            var vlc = GetLiveClient();

            var options = new VoiceLiveSessionOptions()
            {
                Model = "gpt-4o",
                Modalities = { InteractionModality.Text }
            };

            options.Tools.Add(FunctionCalls.AdditionDefinition);

            var session = await vlc.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            // Should get two updates back.
            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();

            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);

            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                Assert.That(InputAudioFormat.Pcm16, Is.EqualTo(sessionUpdated.Session.InputAudioFormat));
                Assert.That(sessionUpdated.Session.Id, Is.EqualTo(sessionCreated.Session.Id));
                Assert.That(sessionUpdated.Session.Model, Is.EqualTo(sessionCreated.Session.Model));
                Assert.That(sessionUpdated.Session.Agent, Is.EqualTo(sessionCreated.Session.Agent));
                Assert.That(sessionUpdated.Session.Animation, Is.EqualTo(sessionCreated.Session.Animation));
                Assert.That(sessionUpdated.Session.Avatar, Is.EqualTo(sessionCreated.Session.Avatar));
                Assert.That(sessionUpdated.Session?.InputAudioEchoCancellation, Is.EqualTo(sessionCreated.Session.InputAudioEchoCancellation));
            });

            var content = new InputTextContentPart("What is 13 plus 29?");

            await session.AddItemAsync(new UserMessageItem(new[] { content }), null, TimeoutToken).ConfigureAwait(false);

            var conversationItemCreated = await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);
            Assert.That(string.IsNullOrEmpty(conversationItemCreated.PreviousItemId), Is.True);
            var message = SafeCast<SessionResponseMessageItem>(conversationItemCreated.Item);
            Assert.Multiple(() =>
            {
                Assert.That(message.Role, Is.EqualTo(ResponseMessageRole.User));
                Assert.That(message.Content.Count, Is.EqualTo(1));
            });
            Assert.That(message.Content[0].Type, Is.EqualTo(ContentPartType.InputText));
            var textPart = SafeCast<RequestTextContentPart>(message.Content[0]);
            Assert.That(textPart.Text, Is.EqualTo(content.Text));

            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);
            var responseCreated = await GetNextUpdate<SessionUpdateResponseCreated>(updatesEnum).ConfigureAwait(false);
            var responseItems = await CollectResponseUpdates(updatesEnum, TimeoutToken).ConfigureAwait(false);
            Assert.That(responseItems.Count() > 0, Is.True);
            responseItems.Insert(0, responseCreated);
            ValidateResponseUpdates(responseItems, string.Empty);

            var callDone = responseItems.Where((s) =>
            {
                return s is SessionUpdateResponseFunctionCallArgumentsDone;
            });

            Assert.That(callDone.Count(), Is.EqualTo(1));
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
            var vlc = GetLiveClient();

            var options = new VoiceLiveSessionOptions()
            {
                Model = "gpt-4o",
                Modalities = { InteractionModality.Text }
            };

            options.Tools.Add(FunctionCalls.AdditionDefinition);

            var session = await vlc.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            // Should get two updates back.
            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();

            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);

            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            Assert.Multiple(() =>
            {
                Assert.That(InputAudioFormat.Pcm16, Is.EqualTo(sessionUpdated.Session.InputAudioFormat));
                Assert.That(sessionUpdated.Session.Id, Is.EqualTo(sessionCreated.Session.Id));
                Assert.That(sessionUpdated.Session.Model, Is.EqualTo(sessionCreated.Session.Model));
                Assert.That(sessionUpdated.Session.Agent, Is.EqualTo(sessionCreated.Session.Agent));
                Assert.That(sessionUpdated.Session.Animation, Is.EqualTo(sessionCreated.Session.Animation));
                Assert.That(sessionUpdated.Session.Avatar, Is.EqualTo(sessionCreated.Session.Avatar));
                Assert.That(sessionUpdated.Session?.InputAudioEchoCancellation, Is.EqualTo(sessionCreated.Session.InputAudioEchoCancellation));
            });

            var content1 = new InputTextContentPart("What is 13 plus 29?");
            var content2 = new InputTextContentPart("What is 87 plus 11?");

            await session.AddItemAsync(new UserMessageItem(new[] { content1, content2 }), null, TimeoutToken).ConfigureAwait(false);

            var conversationItemCreated = await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);
            var message = SafeCast<SessionResponseMessageItem>(conversationItemCreated.Item);
            Assert.Multiple(() =>
            {
                Assert.That(message.Role, Is.EqualTo(ResponseMessageRole.User));
                Assert.That(message.Content.Count, Is.EqualTo(2));
            });
            Assert.That(message.Content[0].Type, Is.EqualTo(ContentPartType.InputText));
            var textPart1 = SafeCast<RequestTextContentPart>(message.Content[0]);
            Assert.Multiple(() =>
            {
                Assert.That(textPart1.Text, Is.EqualTo(content1.Text));
                Assert.That(message.Content[1].Type, Is.EqualTo(ContentPartType.InputText));
            });
            var textPart2 = SafeCast<RequestTextContentPart>(message.Content[1]);
            Assert.That(textPart2.Text, Is.EqualTo(content2.Text));

            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);
            var responseCreated = await GetNextUpdate<SessionUpdateResponseCreated>(updatesEnum).ConfigureAwait(false);
            var responseItems = await CollectResponseUpdates(updatesEnum, TimeoutToken).ConfigureAwait(false);
            Assert.That(responseItems.Count() > 0, Is.True);
            responseItems.Insert(0, responseCreated);
            ValidateResponseUpdates(responseItems, string.Empty);

            var callDones = responseItems.Where((s) =>
            {
                return s is SessionUpdateResponseFunctionCallArgumentsDone;
            });
            Assert.That(callDones.Count(), Is.EqualTo(2));
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
            var vlc = GetLiveClient();

            var options = new VoiceLiveSessionOptions()
            {
                Model = "gpt-4o",
                Modalities = { InteractionModality.Text }
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
            Assert.That(responses.Count > 0, Is.True);
            var responseDone = responses.Where((r) => r is SessionUpdateResponseDone);
            Assert.That(responseDone.Count(), Is.EqualTo(1));
            var response = SafeCast<SessionUpdateResponseDone>(responseDone.First());
            Assert.That(response.Response, Is.Not.Null);
            var outputItems = response.Response.Output.Where((item) =>
                {
                    if (item is not SessionResponseMessageItem)
                    {
                        return false;
                    }
                    var message = SafeCast<SessionResponseMessageItem>(item);
                    return true;
                });
            Assert.That(outputItems.Count(), Is.EqualTo(1));
            var messageItem = SafeCast<SessionResponseMessageItem>(outputItems.First());
            var textParts = messageItem.Content.Where((part) => part.Type == ContentPartType.Text);
            Assert.That(textParts.Count(), Is.EqualTo(1));
            var textPart = SafeCast<ResponseTextContentPart>(textParts.First());
            Assert.That(textPart.Text, Does.Contain("Ted"));
        }

        [LiveOnly]
        [TestCase]
        public async Task DefaultAndUpdateTurnDetectionAzureSemanticVadEnTurnDetection()
        {
            var vlc = GetLiveClient();

            var options = new VoiceLiveSessionOptions()
            {
                Model = "gpt-4o",
                InputAudioFormat = InputAudioFormat.Pcm16,
                TurnDetection = new AzureSemanticVadTurnDetectionEn()
            };

            var session = await vlc.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            // Should get two updates back.
            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();

            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            var defaultTurnDetection = sessionCreated.Session.TurnDetection;
            Assert.That(defaultTurnDetection is ServerVadTurnDetection, Is.True, $"Default turn detection was {defaultTurnDetection.GetType().Name} and not {typeof(ServerVadTurnDetection).Name}");

            var modifiedTurnDetection = sessionUpdated.Session.TurnDetection;
            Assert.That(modifiedTurnDetection is AzureSemanticVadTurnDetectionEn, Is.True, $"Updated turn detection was {modifiedTurnDetection.GetType().Name} and not {typeof(AzureSemanticVadTurnDetectionEn).Name}");
        }

        [LiveOnly]
        [TestCase]
        public async Task InstructionTest()
        {
            var vlc = GetLiveClient();

            var options = new VoiceLiveSessionOptions()
            {
                Model = "gpt-4o",
                Modalities = { InteractionModality.Text },
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
            Assert.That(responses.Count > 0, Is.True);

            var responseDone = responses.Where((r) => r is SessionUpdateResponseDone);
            Assert.That(responseDone.Count(), Is.EqualTo(1));
            var response = SafeCast<SessionUpdateResponseDone>(responseDone.First());
            Assert.That(response.Response, Is.Not.Null);
            var outputItems = response.Response.Output.Where((item) =>
                {
                    if (item is not SessionResponseMessageItem)
                    {
                        return false;
                    }
                    var message = SafeCast<SessionResponseMessageItem>(item);
                    return true;
                });
            Assert.That(outputItems.Count(), Is.EqualTo(1));
            var messageItem = SafeCast<SessionResponseMessageItem>(outputItems.First());
            var textParts = messageItem.Content.Where((part) => part.Type == ContentPartType.Text);
            Assert.That(textParts.Count(), Is.EqualTo(1));
            var textPart = SafeCast<ResponseTextContentPart>(textParts.First());
            Assert.That(textPart.Text, Does.Contain("Frank"));

            // Update the instructions
            options.Instructions = "Your name is Samantha. Never forget that!";
            await session.ConfigureSessionAsync(options, TimeoutToken).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);
            um = new UserMessageItem(new InputTextContentPart("What is your name?"));
            await session.AddItemAsync(um, null, TimeoutToken).ConfigureAwait(false);
            conversationItemCreated = await GetNextUpdate<SessionUpdateConversationItemCreated>(updatesEnum).ConfigureAwait(false);
            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);
            responses = await CollectResponseUpdates(updatesEnum, TimeoutToken).ConfigureAwait(false);
            Assert.That(responses.Count > 0, Is.True);
            responseDone = responses.Where((r) => r is SessionUpdateResponseDone);
            Assert.That(responseDone.Count(), Is.EqualTo(1));
            response = SafeCast<SessionUpdateResponseDone>(responseDone.First());
            Assert.That(response.Response, Is.Not.Null);
            outputItems = response.Response.Output.Where((item) =>
                {
                    if (item is not SessionResponseMessageItem)
                    {
                        return false;
                    }
                    var message = SafeCast<SessionResponseMessageItem>(item);
                    return true;
                });
            Assert.That(outputItems.Count(), Is.EqualTo(1));
            messageItem = SafeCast<SessionResponseMessageItem>(outputItems.First());
            textParts = messageItem.Content.Where((part) => part.Type == ContentPartType.Text);
            Assert.That(textParts.Count(), Is.EqualTo(1));
            textPart = SafeCast<ResponseTextContentPart>(textParts.First());
            Assert.That(textPart.Text, Does.Contain("Samantha"));
        }

        [Ignore("NoTurnDetection nto returned on update, even though it works")]
        [LiveOnly]
        [TestCase]
        public async Task DefaultAndUpdateTurnDetectionNoTurnDetection()
        {
            var vlc = GetLiveClient();

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
            Assert.That(defaultTurnDetection is ServerVadTurnDetection, Is.True, $"Default turn detection was {defaultTurnDetection.GetType().Name} and not {typeof(ServerVadTurnDetection).Name}");

            var modifiedTurnDetection = sessionUpdated.Session.TurnDetection;
            Assert.That(modifiedTurnDetection is NoTurnDetection, Is.True, $"Updated turn detection was {modifiedTurnDetection?.GetType().Name} and not {typeof(NoTurnDetection).Name}");
        }

        [LiveOnly]
        [TestCase]
        public async Task DefaultAndUpdateTurnDetectionAzureSemanticVadMultilingualTurnDetection()
        {
            var vlc = GetLiveClient();

            var options = new VoiceLiveSessionOptions()
            {
                Model = "gpt-4o",
                InputAudioFormat = InputAudioFormat.Pcm16,
                TurnDetection = new AzureSemanticVadTurnDetectionMultilingual()
            };

            var session = await vlc.StartSessionAsync(options, TimeoutToken).ConfigureAwait(false);

            // Should get two updates back.
            var updatesEnum = session.GetUpdatesAsync(TimeoutToken).GetAsyncEnumerator();

            var sessionCreated = await GetNextUpdate<SessionUpdateSessionCreated>(updatesEnum).ConfigureAwait(false);
            var sessionUpdated = await GetNextUpdate<SessionUpdateSessionUpdated>(updatesEnum).ConfigureAwait(false);

            var defaultTurnDetection = sessionCreated.Session.TurnDetection;
            Assert.That(defaultTurnDetection is ServerVadTurnDetection, Is.True, $"Default turn detection was {defaultTurnDetection.GetType().Name} and not {typeof(ServerVadTurnDetection).Name}");

            var modifiedTurnDetection = sessionUpdated.Session.TurnDetection;
            Assert.That(modifiedTurnDetection is AzureSemanticVadTurnDetectionMultilingual, Is.True, $"Updated turn detection was {modifiedTurnDetection.GetType().Name} and not {typeof(AzureSemanticVadTurnDetectionMultilingual).Name}");
        }

        [LiveOnly]
        [TestCase]
        public async Task ClearBufferAndGetResult()
        {
            var vlc = GetLiveClient();

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
            await SendAudioAsync(session, "What is the weather like?").ConfigureAwait(false);
            await session.ClearInputAudioAsync(TimeoutToken).ConfigureAwait(false);

            await SendAudioAsync(session, "Computer, how old are you?").ConfigureAwait(false);

            await session.CommitInputAudioAsync(TimeoutToken).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateInputAudioBufferCommitted>(updatesEnum).ConfigureAwait(false);

            await session.StartResponseAsync(TimeoutToken).ConfigureAwait(false);

            var responses = await CollectResponseUpdates(updatesEnum, TimeoutToken).ConfigureAwait(false);
            Assert.That(responses.Count > 0, Is.True);

            var responseDone = responses.Where((r) => r is SessionUpdateResponseDone);
            Assert.That(responseDone.Count(), Is.EqualTo(1));
            var response = SafeCast<SessionUpdateResponseDone>(responseDone.First());

            Assert.That(response.Response, Is.Not.Null);
            var outputItems = response.Response.Output.Where((item) =>
                {
                    if (item is not SessionResponseMessageItem)
                    {
                        return false;
                    }
                    var message = SafeCast<SessionResponseMessageItem>(item);

                    return true;
                });
        }

        [LiveOnly]
        [TestCase]
        public async Task SendMultipleAudioFrames()
        {
            var vlc = GetLiveClient();

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

            await session.ClearInputAudioAsync(TimeoutToken).ConfigureAwait(false);

            // Now send audio:
            await SendAudioAsync(session, "What is the weather like?").ConfigureAwait(false);

            await session.CommitInputAudioAsync(TimeoutToken).ConfigureAwait(false);
            await GetNextUpdate<SessionUpdateInputAudioBufferCommitted>(updatesEnum).ConfigureAwait(false);

            var speechTranscribed = await GetNextUpdate<SessionUpdateConversationItemInputAudioTranscriptionCompleted>(updatesEnum).ConfigureAwait(false);

            Assert.That(speechTranscribed.Transcript.Length > 0, Is.True);
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
                        Assert.That(responseId, Is.EqualTo(string.Empty));
                        Assert.That(responseCreated.Type, Is.EqualTo(ServerEventType.ResponseCreated));

                        var response = responseCreated.Response;
                        Assert.That(response, Is.Not.Null);
                        Assert.That(response.Status, Is.EqualTo(SessionResponseStatus.InProgress));

                        responseId = response.Id;
                        incompleteOutputItems.Push(new HashSet<string>());
                        incompleteOutputItems.Peek().Add(response.Id);
                        break;

                    case SessionUpdateResponseOutputItemAdded outputItem:
                        Assert.That(outputItem.ResponseId, Is.EqualTo(responseId));
                        Assert.That(outputItem.OutputIndex, Is.EqualTo(0));
                        Assert.That(outputItem.Item, Is.Not.Null);

                        responseItemId = outputItem.Item.Id;

                        switch (outputItem.Item)
                        {
                            case SessionResponseMessageItem messageItem:
                                Assert.That(messageItem.Role, Is.EqualTo(ResponseMessageRole.Assistant));
                                Assert.That(messageItem.Status, Is.EqualTo(SessionResponseItemStatus.Incomplete));
                                break;
                            case ResponseFunctionCallItem functionCallItem:
                                responseItemId = functionCallItem.Id;
                                Assert.That(functionCallItem.Status, Is.EqualTo(SessionResponseItemStatus.InProgress));
                                Assert.That(string.IsNullOrWhiteSpace(functionCallItem.Name), Is.False);

                                deltaBuilders.Add(functionCallItem.CallId, new StringBuilder());
                                break;
                            default:
                                Assert.Fail($"Unknown output item type {outputItem.Item.GetType()}");
                                break;
                        }
                        break;

                    case SessionUpdateConversationItemCreated newConversationItem:
                        Assert.That(newConversationItem.PreviousItemId, Is.EqualTo(previousItemId));
                        Assert.That(newConversationItem.Item, Is.Not.Null);

                        switch (newConversationItem.Item)
                        {
                            case SessionResponseMessageItem messageItem:
                                Assert.That(messageItem.Role, Is.EqualTo(ResponseMessageRole.Assistant));
                                break;

                            case ResponseFunctionCallItem functionCallItem:
                                break;

                            default:
                                Assert.Fail($"Unknown conversation item type {newConversationItem.Item.GetType()}");
                                break;
                        }
                        break;

                    case SessionUpdateResponseContentPartAdded contentPartAdded:
                        Assert.That(contentPartAdded.ResponseId, Is.EqualTo(responseId));
                        Assert.That(contentPartAdded.ItemId, Is.EqualTo(responseItemId));
                        Assert.That(contentPartAdded.Part, Is.Not.Null);
                        Assert.That(contentPartAdded.OutputIndex, Is.EqualTo(0));
                        Assert.That(contentPartAdded.ContentIndex, Is.GreaterThanOrEqualTo(0));

                        deltaBuilders.Add(contentPartAdded.ItemId, new StringBuilder());

                        switch (contentPartAdded.Part)
                        {
                            case ResponseTextContentPart textPart:
                                Assert.That(string.IsNullOrWhiteSpace(textPart.Text), Is.False);
                                break;
                            case ResponseAudioContentPart audioPart:
                                Assert.That(string.IsNullOrWhiteSpace(audioPart.Transcript), Is.True);
                                break;
                            default:
                                Assert.Fail($"Unknown content part type {contentPartAdded.Part.GetType()}");
                                break;
                        }
                        break;

                    case SessionUpdateResponseAudioTranscriptDelta audioTranscriptDelta:
                        Assert.That(audioTranscriptDelta.ResponseId, Is.EqualTo(responseId));
                        Assert.That(audioTranscriptDelta.ItemId, Is.EqualTo(responseItemId));
                        Assert.That(string.IsNullOrEmpty(audioTranscriptDelta.Delta), Is.False);
                        deltaBuilders[audioTranscriptDelta.ItemId].Append(audioTranscriptDelta.Delta);
                        break;

                    case SessionUpdateResponseAudioDelta audioDelta:
                        Assert.That(audioDelta.ResponseId, Is.EqualTo(responseId));
                        Assert.That(audioDelta.ItemId, Is.EqualTo(responseItemId));
                        Assert.That(audioDelta.Delta.ToMemory().IsEmpty, Is.False);
                        Console.WriteLine($"Audio delta length: {audioDelta.Delta.ToMemory().Length}");
                        break;

                    case SessionUpdateResponseAudioDone audioDone:
                        Assert.That(audioDone.ResponseId, Is.EqualTo(responseId));
                        Assert.That(audioDone.ItemId, Is.EqualTo(responseItemId));
                        break;

                    case SessionUpdateResponseAudioTranscriptDone done:
                        Assert.That(done.ResponseId, Is.EqualTo(responseId));
                        Assert.That(done.ItemId, Is.EqualTo(responseItemId));
                        Assert.That(string.IsNullOrEmpty(done.Transcript), Is.False);
                        Assert.That(deltaBuilders[done.ItemId].ToString(), Has.Length.EqualTo(done.Transcript.Length));
                        Assert.That(deltaBuilders[done.ItemId].ToString(), Is.EqualTo(done.Transcript));
                        break;

                    case SessionUpdateResponseContentPartDone contentDone:
                        Assert.That(contentDone.ResponseId, Is.EqualTo(responseId));
                        Assert.That(contentDone.ItemId, Is.EqualTo(responseItemId));

                        switch (contentDone.Part)
                        {
                            case ResponseTextContentPart textPart:
                                Assert.That(string.IsNullOrWhiteSpace(textPart.Text), Is.False);
                                Assert.That(deltaBuilders[contentDone.ItemId].ToString(), Has.Length.EqualTo(textPart.Text.Length));
                                Assert.That(deltaBuilders[contentDone.ItemId].ToString(), Is.EqualTo(textPart.Text));
                                break;
                            case ResponseAudioContentPart audioPart:
                                Assert.That(string.IsNullOrWhiteSpace(audioPart.Transcript), Is.False);
                                Assert.That(deltaBuilders[contentDone.ItemId].ToString(), Is.EqualTo(audioPart.Transcript));
                                break;
                            default:
                                Assert.Fail($"Unknown content part type {contentDone.Part.GetType()}");
                                break;
                        }
                        break;

                    case SessionUpdateResponseOutputItemDone responseOutputDone:
                        Assert.That(responseOutputDone.ResponseId, Is.EqualTo(responseId));

                        switch (responseOutputDone.Item)
                        {
                            case SessionResponseMessageItem messageItem:
                                Assert.That(messageItem.Role, Is.EqualTo(ResponseMessageRole.Assistant));
                                Assert.That(messageItem.Status, Is.EqualTo(SessionResponseItemStatus.Completed));
                                Assert.That(messageItem.Content.Count > 0, Is.True);

                                switch (messageItem.Content[0])
                                {
                                    case ResponseTextContentPart textPart:
                                        Assert.That(string.IsNullOrWhiteSpace(textPart.Text), Is.False);
                                        Assert.That(deltaBuilders[messageItem.Id].ToString(), Has.Length.EqualTo(textPart.Text.Length));
                                        Assert.That(deltaBuilders[messageItem.Id].ToString(), Is.EqualTo(textPart.Text));
                                        break;
                                    case ResponseAudioContentPart audioPart:
                                        Assert.That(string.IsNullOrWhiteSpace(audioPart.Transcript), Is.False);
                                        Assert.That(deltaBuilders[messageItem.Id].ToString(), Is.EqualTo(audioPart.Transcript));
                                        break;
                                    default:
                                        Assert.Fail($"Unknown content part type {messageItem.Content[0].GetType()}");
                                        break;
                                }
                                break;

                            case ResponseFunctionCallItem functionCallItem:
                                Assert.That(functionCallItem.Status, Is.EqualTo(SessionResponseItemStatus.Completed));
                                Assert.That(string.IsNullOrWhiteSpace(functionCallItem.Name), Is.False);
                                Assert.That(deltaBuilders[functionCallItem.CallId].ToString(), Is.EqualTo(functionCallItem.Arguments));
                                break;

                            default:
                                Assert.Fail($"Unknown output item type {responseOutputDone.Item.GetType()}");
                                break;
                        }

                        break;
                    case SessionUpdateResponseDone responseDone:
                        Assert.That(responseDone.Response, Is.Not.Null);

                        Assert.That(responseDone.Response.Status, Is.EqualTo(SessionResponseStatus.Completed));
                        Assert.That(responseDone.Response.Id, Is.EqualTo(responseId));

                        var usage = responseDone.Response.Usage;
                        Assert.That(usage, Is.Not.Null);
                        Assert.That(usage.InputTokenDetails.AudioTokens + usage.InputTokenDetails.TextTokens + usage.InputTokenDetails.CachedTokens,
                            Is.EqualTo(usage.InputTokens));
                        Assert.That(usage.InputTokenDetails.CachedTokensDetails.TextTokens + usage.InputTokenDetails.CachedTokensDetails.AudioTokens,
                            Is.EqualTo(usage.InputTokenDetails.CachedTokens));
                        Assert.That(usage.OutputTokenDetails.AudioTokens + usage.OutputTokenDetails.TextTokens,
                            Is.EqualTo(usage.OutputTokens));
                        Assert.That(usage.InputTokens + usage.OutputTokens, Is.EqualTo(usage.TotalTokens));

                        Assert.That(responseDone.Response.Output.Count > 0, Is.True);
                        switch (responseDone.Response.Output[0])
                        {
                            case SessionResponseMessageItem messageItem:
                                Assert.That(messageItem.Role, Is.EqualTo(ResponseMessageRole.Assistant));
                                Assert.That(messageItem.Status, Is.EqualTo(SessionResponseItemStatus.Completed));
                                Assert.That(messageItem.Id, Is.EqualTo(responseItemId));
                                Assert.That(messageItem.Content.Count > 0, Is.True);
                                switch (messageItem.Content[0])
                                {
                                    case ResponseTextContentPart textPart:
                                        Assert.That(string.IsNullOrWhiteSpace(textPart.Text), Is.False);
                                        Assert.That(deltaBuilders[messageItem.Id].ToString(), Has.Length.EqualTo(textPart.Text.Length));
                                        Assert.That(deltaBuilders[messageItem.Id].ToString(), Is.EqualTo(textPart.Text));
                                        break;
                                    case ResponseAudioContentPart audioPart:
                                        Assert.That(string.IsNullOrWhiteSpace(audioPart.Transcript), Is.False);
                                        Assert.That(deltaBuilders[messageItem.Id].ToString(), Is.EqualTo(audioPart.Transcript));
                                        break;
                                    default:
                                        Assert.Fail($"Unknown content part type {messageItem.Content[0].GetType()}");
                                        break;
                                }
                                break;

                            case ResponseFunctionCallItem functionCallItem:
                                Assert.That(functionCallItem.Status, Is.EqualTo(SessionResponseItemStatus.Completed));
                                Assert.That(functionCallItem.Id, Is.EqualTo(responseItemId));
                                Assert.That(string.IsNullOrWhiteSpace(functionCallItem.Name), Is.False);
                                Assert.That(deltaBuilders[functionCallItem.CallId].ToString(), Is.EqualTo(functionCallItem.Arguments));
                                break;

                            default:
                                Assert.Fail($"Unknown output item type {responseDone.Response.Output[0].GetType()}");
                                break;
                        }
                        break;

                    case SessionUpdateResponseFunctionCallArgumentsDelta functionCallDelta:
                        Assert.That(functionCallDelta.ResponseId, Is.EqualTo(responseId));
                        Assert.That(functionCallDelta.ItemId, Is.EqualTo(responseItemId));
                        Assert.That(string.IsNullOrEmpty(functionCallDelta.Delta), Is.False);
                        deltaBuilders[functionCallDelta.CallId].Append(functionCallDelta.Delta);
                        break;

                    case SessionUpdateResponseFunctionCallArgumentsDone functionCallDone:
                        Assert.That(functionCallDone.ResponseId, Is.EqualTo(responseId));
                        Assert.That(functionCallDone.ItemId, Is.EqualTo(responseItemId));
                        Assert.That(string.IsNullOrEmpty(functionCallDone.Arguments), Is.False);
                        Assert.That(deltaBuilders[functionCallDone.CallId].ToString(), Has.Length.EqualTo(functionCallDone.Arguments.Length));
                        Assert.That(deltaBuilders[functionCallDone.CallId].ToString(), Is.EqualTo(functionCallDone.Arguments));
                        break;

                    default:
                        Assert.Fail($"Unknown output item type {item.GetType()}");
                        break;
                }
            }
        }
    }
}
