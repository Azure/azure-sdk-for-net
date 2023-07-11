// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests
{
    [TestFixture]
    public class OpenAIInferenceModelFactoryTests
    {
        [Test]
        public void TestCompletionsLogProbabilityModel()
        {
            var logProbabilityModel = AIOpenAIModelFactory.CompletionsLogProbabilityModel(
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

            var chatChoices = expectedChoices
                .Select(e => AzureOpenAIModelFactory.ChatChoice(
                    new ChatMessage(e.role, e.text),
                    e.index,
                    e.reason))
                .ToArray();
            Assert.That(chatChoices, Is.All.Not.Null);

            for (int i = 0; i < chatChoices.Length; i++)
            {
                var actual = chatChoices[i];
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

            var chatChoices = expectedChoices
                .Select(e => AzureOpenAIModelFactory.ChatChoice(
                    new ChatMessage(e.role, e.text),
                    e.index,
                    e.reason))
                .ToArray();

            var chatCompletions = AzureOpenAIModelFactory.ChatCompletions(
                expectedId,
                expectedCreationTime,
                chatChoices,
                AIOpenAIModelFactory.CompletionsUsage(2, 5, 7));

            Assert.That(chatCompletions, Is.Not.Null);
            Assert.That(chatCompletions.Id, Is.EqualTo(expectedId));
            Assert.That(chatCompletions.Created, Is.EqualTo(expectedCreationTime).Within(TimeSpan.FromSeconds(1))); // Internally we use Unix time with second precision
            Assert.That(chatCompletions.Choices, Is.EquivalentTo(chatChoices));
            Assert.That(chatCompletions.Usage, Is.Not.Null);
            Assert.That(chatCompletions.Usage.CompletionTokens, Is.EqualTo(2));
            Assert.That(chatCompletions.Usage.PromptTokens, Is.EqualTo(5));
            Assert.That(chatCompletions.Usage.TotalTokens, Is.EqualTo(7));
        }
    }
}
