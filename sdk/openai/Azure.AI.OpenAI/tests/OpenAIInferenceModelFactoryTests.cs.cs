// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests
{
    [TestFixture]
    public class OpenAIInferenceModelFactoryTests
    {
        [Test]
        public void TestCompletionsLogProbabilityModel()
        {
            CompletionsLogProbabilityModel logProbabilityModel = AzureOpenAIModelFactory.CompletionsLogProbabilityModel(
                new[] { "one", "two" },
                new float?[] { 0.9f, 0.72f });
            Assert.That(logProbabilityModel, Is.Not.Null);
            Assert.That(logProbabilityModel.Tokens.Count, Is.EqualTo(2));
            Assert.That(logProbabilityModel.Tokens[0], Is.EqualTo("one"));
            Assert.That(logProbabilityModel.Tokens[1], Is.EqualTo("two"));
            Assert.That(logProbabilityModel.TokenLogProbabilities.Count, Is.EqualTo(2));
            Assert.That(logProbabilityModel.TokenLogProbabilities[0], Is.EqualTo(0.9F).Within(2).Percent);
            Assert.That(logProbabilityModel.TokenLogProbabilities[1], Is.EqualTo(0.72F).Within(2).Percent);
            Assert.That(logProbabilityModel.TopLogProbabilities, Is.Empty);
            Assert.That(logProbabilityModel.TextOffsets, Is.Empty);
        }

        [Test]
        public void TestChatChoices()
        {
            var expectedChoices = new[]
            {
                new { role = ChatRole.Assistant, text = "First one",  index = 0,  reason = CompletionsFinishReason.ContentFiltered },
                new { role = ChatRole.System,    text = "Second one", index = -1, reason = CompletionsFinishReason.Stopped },
                new { role = ChatRole.User,      text = "Final one",  index = 3,  reason = CompletionsFinishReason.TokenLimitReached },
            };

            ChatChoice[] chatChoices = expectedChoices
                .Select(e => AzureOpenAIModelFactory.ChatChoice(
                    AzureOpenAIModelFactory.ChatResponseMessage(e.role, e.text),
                    e.index,
                    e.reason))
                .ToArray();
            Assert.That(chatChoices, Is.All.Not.Null);

            for (int i = 0; i < chatChoices.Length; i++)
            {
                ChatChoice actual = chatChoices[i];
                var expected = expectedChoices[i];

                Assert.That(actual.Message, Is.Not.Null);
                Assert.That(actual.Message.Role, Is.EqualTo(expected.role));
                Assert.That(actual.Message.Content, Is.EqualTo(expected.text));
                Assert.That(actual.Index, Is.EqualTo(expected.index));
                Assert.That(actual.FinishReason, Is.EqualTo(expected.reason));
            }
        }

        [Test]
        public void TestChatCompletions()
        {
            string expectedId = Guid.NewGuid().ToString();
            DateTimeOffset expectedCreationTime = DateTimeOffset.Now;

            var expectedChoices = new[]
            {
                new { role = ChatRole.Assistant, text = "First one",  index = 0,  reason = CompletionsFinishReason.ContentFiltered },
                new { role = ChatRole.System,    text = "Second one", index = -1, reason = CompletionsFinishReason.Stopped },
                new { role = ChatRole.User,      text = "Final one",  index = 3,  reason = CompletionsFinishReason.TokenLimitReached },
            };

            ChatChoice[] chatChoices = expectedChoices
                .Select(e => AzureOpenAIModelFactory.ChatChoice(
                    AzureOpenAIModelFactory.ChatResponseMessage(e.role, e.text),
                    e.index,
                    e.reason))
                .ToArray();

            var promptFilterResults = new List<ContentFilterResultsForPrompt>()
            {
                AzureOpenAIModelFactory.ContentFilterResultsForPrompt(
                    0,
                    AzureOpenAIModelFactory.ContentFilterResultDetailsForPrompt(
                        hate: AzureOpenAIModelFactory.ContentFilterResult(
                            ContentFilterSeverity.Medium,
                            filtered: true)))
            };

            ChatCompletions chatCompletions = AzureOpenAIModelFactory.ChatCompletions(
                expectedId,
                expectedCreationTime,
                chatChoices,
                promptFilterResults,
                "system_fingerprint",
                AzureOpenAIModelFactory.CompletionsUsage(2, 5, 7));

            Assert.That(chatCompletions, Is.Not.Null);
            Assert.That(chatCompletions.Id, Is.EqualTo(expectedId));
            Assert.That(chatCompletions.Created, Is.EqualTo(expectedCreationTime).Within(TimeSpan.FromSeconds(1))); // Internally we use Unix time with second precision
            Assert.That(chatCompletions.PromptFilterResults, Is.Not.Null.Or.Empty);
            Assert.That(chatCompletions.PromptFilterResults[0], Is.Not.Null);
            Assert.That(chatCompletions.PromptFilterResults[0].PromptIndex, Is.EqualTo(0));
            Assert.That(chatCompletions.PromptFilterResults[0].ContentFilterResults, Is.Not.Null);
            Assert.That(chatCompletions.PromptFilterResults[0].ContentFilterResults.Hate, Is.Not.Null);
            Assert.That(chatCompletions.PromptFilterResults[0].ContentFilterResults.Hate.Severity, Is.EqualTo(ContentFilterSeverity.Medium));
            Assert.That(chatCompletions.PromptFilterResults[0].ContentFilterResults.Hate.Filtered, Is.EqualTo(true));
            Assert.That(chatCompletions.Choices, Is.EquivalentTo(chatChoices));
            Assert.That(chatCompletions.Usage, Is.Not.Null);
            Assert.That(chatCompletions.Usage.CompletionTokens, Is.EqualTo(2));
            Assert.That(chatCompletions.Usage.PromptTokens, Is.EqualTo(5));
            Assert.That(chatCompletions.Usage.TotalTokens, Is.EqualTo(7));
        }

        [Test]
        public void TestAudioTranscriptionSegment()
        {
            AudioTranscriptionSegment segment = AzureOpenAIModelFactory.AudioTranscriptionSegment(
                id: 42,
                start: TimeSpan.FromSeconds(5.2),
                end: TimeSpan.FromSeconds(9.9),
                text: " test of the emergency",
                tokens: new int[] { 111, 222, 333, 444 });
            Assert.That(segment.Id, Is.EqualTo(42));
            Assert.That(segment.Start, Is.EqualTo(TimeSpan.FromSeconds(5.2)));
            Assert.That(segment.End, Is.EqualTo(TimeSpan.FromSeconds(9.9)));
            Assert.That(segment.Text, Is.EqualTo(" test of the emergency"));
            Assert.That(segment.Tokens, Is.Not.Null.Or.Empty);
            Assert.That(segment.Tokens.Count, Is.EqualTo(4));
            Assert.That(segment.Tokens[2], Is.EqualTo(333));
        }

        [Test]
        public void TestAudioTranscription()
        {
            AudioTranscription audioTranscription = AzureOpenAIModelFactory.AudioTranscription(
                "this is a test of the emergency broadcast system",
                "en",
                TimeSpan.FromSeconds(13.3),
                new AudioTranscriptionSegment[] { AzureOpenAIModelFactory.AudioTranscriptionSegment() });
            Assert.That(audioTranscription, Is.Not.Null);
            Assert.That(audioTranscription.Text, Is.Not.Null.Or.Empty);
            Assert.That(audioTranscription.Language, Is.Not.Null.Or.Empty);
            Assert.That(audioTranscription.Duration, Is.GreaterThan(TimeSpan.FromSeconds(0)));
            Assert.That(audioTranscription.Segments, Is.Not.Null.Or.Empty);
            Assert.That(audioTranscription.Segments.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestAudioTranslationSegment()
        {
            AudioTranslationSegment segment = AzureOpenAIModelFactory.AudioTranslationSegment(
                id: 42,
                start: TimeSpan.FromSeconds(5.2),
                end: TimeSpan.FromSeconds(9.9),
                text: " test of the emergency",
                tokens: new int[] { 111, 222, 333, 444 });
            Assert.That(segment.Id, Is.EqualTo(42));
            Assert.That(segment.Start, Is.EqualTo(TimeSpan.FromSeconds(5.2)));
            Assert.That(segment.End, Is.EqualTo(TimeSpan.FromSeconds(9.9)));
            Assert.That(segment.Text, Is.EqualTo(" test of the emergency"));
            Assert.That(segment.Tokens, Is.Not.Null.Or.Empty);
            Assert.That(segment.Tokens.Count, Is.EqualTo(4));
            Assert.That(segment.Tokens[2], Is.EqualTo(333));
        }

        [Test]
        public void TestAudioTranslation()
        {
            AudioTranslation audioTranslation = AzureOpenAIModelFactory.AudioTranslation(
                "this is a test of the emergency broadcast system",
                "en",
                TimeSpan.FromSeconds(13.3),
                new AudioTranslationSegment[] { AzureOpenAIModelFactory.AudioTranslationSegment() });
            Assert.That(audioTranslation, Is.Not.Null);
            Assert.That(audioTranslation.Text, Is.Not.Null.Or.Empty);
            Assert.That(audioTranslation.Language, Is.Not.Null.Or.Empty);
            Assert.That(audioTranslation.Duration, Is.GreaterThan(TimeSpan.FromSeconds(0)));
            Assert.That(audioTranslation.Segments, Is.Not.Null.Or.Empty);
            Assert.That(audioTranslation.Segments.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task TestStreamingChatCompletions()
        {
            const string expectedId = "expected-id-value";

            StreamingChatCompletionsUpdate[] updates = new[]
            {
                AzureOpenAIModelFactory.StreamingChatCompletionsUpdate(
                    expectedId,
                    DateTime.Now,
                    systemFingerprint: null,
                    role: ChatRole.Assistant,
                    contentUpdate: "hello"),
                AzureOpenAIModelFactory.StreamingChatCompletionsUpdate(
                    expectedId,
                    DateTime.Now,
                    systemFingerprint: null,
                    contentUpdate: " world"),
                AzureOpenAIModelFactory.StreamingChatCompletionsUpdate(
                    expectedId,
                    DateTime.Now,
                    systemFingerprint: null,
                    finishReason: CompletionsFinishReason.Stopped),
            };

            async IAsyncEnumerable<StreamingChatCompletionsUpdate> EnumerateMockUpdates()
            {
                foreach (StreamingChatCompletionsUpdate update in updates)
                {
                    yield return update;
                }
                await Task.Delay(0);
            }

            StringBuilder contentBuilder = new();
            await foreach (StreamingChatCompletionsUpdate update in EnumerateMockUpdates())
            {
                Assert.That(update.Id == expectedId);
                Assert.That(update.Created > new DateTimeOffset(new DateTime(2023, 1, 1)));
                contentBuilder.Append(update.ContentUpdate);
            }
            Assert.That(contentBuilder.ToString() == "hello world");
        }
    }
}
