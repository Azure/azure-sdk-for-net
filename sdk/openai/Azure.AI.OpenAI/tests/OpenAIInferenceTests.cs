// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests
{
    public class OpenAIInferenceTests : OpenAITestBase
    {
        public OpenAIInferenceTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Live)
        {
        }

        [RecordedTest]
        [TestCase(OpenAIClientServiceTarget.Azure)]
        [TestCase(OpenAIClientServiceTarget.NonAzure)]
        public async Task Completions(OpenAIClientServiceTarget serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            string deploymentOrModelName = GetDeploymentOrModelName(serviceTarget, OpenAIClientScenario.Completions);
            Assert.That(client, Is.InstanceOf<OpenAIClient>());
            CompletionsOptions requestOptions = new CompletionsOptions()
            {
                Prompts =
                {
                    "Hello world",
                    "running over the same old ground",
                },
            };
            Assert.That(requestOptions, Is.InstanceOf<CompletionsOptions>());
            Response<Completions> response = await client.GetCompletionsAsync(deploymentOrModelName, requestOptions);
            Assert.That(response, Is.Not.Null);
            Assert.That(response, Is.InstanceOf<Response<Completions>>());
            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices.Count, Is.EqualTo(requestOptions.Prompts.Count));
            Assert.That(response.Value.Choices[0].FinishReason, Is.Not.Null.Or.Empty);
        }

        [RecordedTest]
        [TestCase(OpenAIClientServiceTarget.Azure)]
        [TestCase(OpenAIClientServiceTarget.NonAzure)]
        public async Task SimpleCompletions(OpenAIClientServiceTarget serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            string deploymentOrModelName = GetDeploymentOrModelName(
                serviceTarget,
                OpenAIClientScenario.Completions);
            Response<Completions> response = await client.GetCompletionsAsync(deploymentOrModelName, "Hello world!");
            Assert.That(response, Is.InstanceOf<Response<Completions>>());
        }

        [RecordedTest]
        [TestCase(OpenAIClientServiceTarget.Azure)]
        [TestCase(OpenAIClientServiceTarget.NonAzure, Ignore = "Tokens not supported for non-Azure")]
        public async Task CompletionsWithTokenCredential(OpenAIClientServiceTarget serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget, OpenAIClientAuthenticationType.Token);
            var requestOptions = new CompletionsOptions();
            requestOptions.Prompts.Add("Hello, world!");
            requestOptions.Prompts.Add("I can have multiple prompts");
            Assert.That(requestOptions, Is.InstanceOf<CompletionsOptions>());
            Response<Completions> response = await client.GetCompletionsAsync(CompletionsDeploymentId, requestOptions);
            Assert.That(response, Is.InstanceOf<Response<Completions>>());
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices.Count, Is.EqualTo(2));
        }

        [RecordedTest]
        [TestCase(OpenAIClientServiceTarget.Azure)]
        [TestCase(OpenAIClientServiceTarget.NonAzure)]
        public async Task Embeddings(OpenAIClientServiceTarget serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            string deploymentOrModelName = GetDeploymentOrModelName(serviceTarget, OpenAIClientScenario.Embeddings);
            var embeddingsRequest = new EmbeddingsOptions("Your text string goes here");
            Assert.That(embeddingsRequest, Is.InstanceOf<EmbeddingsOptions>());
            Response<Embeddings> response = await client.GetEmbeddingsAsync(deploymentOrModelName, embeddingsRequest);
            Assert.That(response, Is.InstanceOf<Response<Embeddings>>());
        }

        [RecordedTest]
        [TestCase(OpenAIClientServiceTarget.Azure)]
        [TestCase(OpenAIClientServiceTarget.NonAzure)]
        public async Task CompletionsUsageField(OpenAIClientServiceTarget serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            string deploymentOrModelName = GetDeploymentOrModelName(serviceTarget, OpenAIClientScenario.Completions);
            var requestOptions = new CompletionsOptions()
            {
                Prompts =
                {
                    "Hello world",
                    "This is a test",
                },
                MaxTokens = 1024,
                ChoicesPerPrompt = 3,
                LogProbabilityCount = 1,
            };
            int expectedChoiceCount = (requestOptions.ChoicesPerPrompt ?? 1) * requestOptions.Prompts.Count;
            Response<Completions> response = await client.GetCompletionsAsync(deploymentOrModelName, requestOptions);
            Assert.That(response.GetRawResponse(), Is.Not.Null.Or.Empty);
            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.Id, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Created, Is.GreaterThan(new DateTimeOffset(new DateTime(2023, 1, 1))));
            Assert.That(response.Value.Created, Is.LessThan(DateTimeOffset.UtcNow.AddDays(7)));
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices.Count, Is.EqualTo(expectedChoiceCount), "Each prompt should produce `SnippetCount` choices");
            Assert.That(response.Value.Usage, Is.Not.Null);
            Assert.That(response.Value.Usage.TotalTokens, Is.GreaterThan(0));
            Assert.That(response.Value.Usage.TotalTokens, Is.EqualTo(response.Value.Usage.CompletionTokens + response.Value.Usage.PromptTokens));

            Choice firstChoice = response.Value.Choices[0];
            Assert.That(firstChoice, Is.Not.Null);
            Assert.That(firstChoice.FinishReason, Is.Not.Null.Or.Empty);
            Assert.That(firstChoice.Text, Is.Not.Null.Or.Empty);
            Assert.That(firstChoice.LogProbabilityModel, Is.Not.Null);
            Assert.That(firstChoice.LogProbabilityModel.Tokens, Is.Not.Null.Or.Empty);
            Assert.That(firstChoice.LogProbabilityModel.Tokens.Count, Is.LessThan(response.Value.Usage.TotalTokens));
            Assert.That(firstChoice.LogProbabilityModel.Tokens[0], Is.Not.Null.Or.Empty);

            Assert.That(response.Value.Choices[2].Index, Is.EqualTo(2));
        }

        [RecordedTest]
        [TestCase(OpenAIClientServiceTarget.Azure)]
        [TestCase(OpenAIClientServiceTarget.NonAzure)]
        public async Task ChatCompletions(OpenAIClientServiceTarget serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            string deploymentOrModelName = GetDeploymentOrModelName(
                serviceTarget,
                OpenAIClientScenario.ChatCompletions);
            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatMessage(ChatRole.System, "You are a helpful assistant."),
                    new ChatMessage(ChatRole.User, "Can you help me?"),
                    new ChatMessage(ChatRole.Assistant, "Of course! What do you need help with?"),
                    new ChatMessage(ChatRole.User, "What temperature should I bake pizza at?"),
                },
                MaxTokens = 512,
            };
            Response<ChatCompletions> response = await client.GetChatCompletionsAsync(
                deploymentOrModelName,
                requestOptions);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.InstanceOf<ChatCompletions>());
            Assert.That(response.Value.Id, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Created, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices.Count, Is.EqualTo(1));
            ChatChoice choice = response.Value.Choices[0];
            Assert.That(choice.Index, Is.EqualTo(0));
            Assert.That(choice.FinishReason, Is.EqualTo(CompletionsFinishReason.Stopped));
            Assert.That(choice.Message.Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(choice.Message.Content, Is.Not.Null.Or.Empty);
        }

        [RecordedTest]
        [TestCase(OpenAIClientServiceTarget.Azure)]
        [TestCase(OpenAIClientServiceTarget.NonAzure)]
        public async Task StreamingChatCompletions(OpenAIClientServiceTarget serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            string deploymentOrModelName = GetDeploymentOrModelName(
                serviceTarget,
                OpenAIClientScenario.ChatCompletions);
            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatMessage(ChatRole.System, "You are a helpful assistant."),
                    new ChatMessage(ChatRole.User, "Can you help me?"),
                    new ChatMessage(ChatRole.Assistant, "Of course! What do you need help with?"),
                    new ChatMessage(ChatRole.User, "What temperature should I bake pizza at?"),
                },
                MaxTokens = 512,
            };
            Response<StreamingChatCompletions> streamingResponse
                = await client.GetChatCompletionsStreamingAsync(deploymentOrModelName, requestOptions);
            Assert.That(streamingResponse, Is.Not.Null);
            using StreamingChatCompletions streamingChatCompletions = streamingResponse.Value;
            Assert.That(streamingChatCompletions, Is.InstanceOf<StreamingChatCompletions>());

            int totalMessages = 0;

            await foreach (StreamingChatChoice streamingChoice in streamingChatCompletions.GetChoicesStreaming())
            {
                Assert.That(streamingChoice, Is.Not.Null);
                await foreach (ChatMessage streamingMessage in streamingChoice.GetMessageStreaming())
                {
                    Assert.That(streamingMessage.Role, Is.EqualTo(ChatRole.Assistant));
                    totalMessages++;
                }
            }

            Assert.That(totalMessages, Is.GreaterThan(1));
        }

        private async Task InternalAdvancedCompletionsOptions(OpenAIClientServiceTarget serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            string deploymentOrModelName = GetDeploymentOrModelName(serviceTarget, OpenAIClientScenario.Completions);
            string promptText = "Are bananas especially radioactive?";
            var requestOptions = new CompletionsOptions()
            {
                Prompts = { promptText },
                GenerationSampleCount = 3,
                Temperature = 0.75f,
                User = "AzureSDKOpenAITests",
                Echo = true,
                LogProbabilityCount = 1,
            };
            Response<Completions> response = await client.GetCompletionsAsync(deploymentOrModelName, requestOptions);
            Assert.That(response, Is.Not.Null);
            string rawResponse = response.GetRawResponse().Content.ToString();
            Assert.That(rawResponse, Is.Not.Null.Or.Empty);

            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices.Count, Is.EqualTo(1));
            Assert.That(response.Value.Choices[0].Text.ToLower().StartsWith(promptText.ToLower()));

            Assert.That(response.Value.Choices[0].LogProbabilityModel, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices[0].LogProbabilityModel.Tokens, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Usage.TotalTokens, Is.GreaterThan(response.Value.Choices[0].LogProbabilityModel.Tokens.Count));
        }

        [RecordedTest]
        [TestCase(OpenAIClientServiceTarget.Azure)]
        [TestCase(OpenAIClientServiceTarget.NonAzure, Ignore = "Not applicable to non-Azure OpenAI")]
        public void BadDeploymentFails(OpenAIClientServiceTarget serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            var completionsRequest = new CompletionsOptions();
            completionsRequest.Prompts.Add("Hello world");
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await client.GetCompletionsAsync("BAD_DEPLOYMENT_ID", completionsRequest);
            });
            Assert.AreEqual(404, exception.Status);
            Assert.That(exception.ErrorCode, Is.EqualTo("DeploymentNotFound"));
        }

        [RecordedTest]
        [TestCase(OpenAIClientServiceTarget.Azure)]
        [TestCase(OpenAIClientServiceTarget.NonAzure)]
        public async Task TokenCutoff(OpenAIClientServiceTarget serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            string deploymentOrModelName = GetDeploymentOrModelName(serviceTarget, OpenAIClientScenario.Completions);
            var requestOptions = new CompletionsOptions()
            {
                Prompts =
                {
                    "How long would it take an unladen swallow to travel between Seattle, WA"
                        + " and New York, NY?"
                },
                MaxTokens = 3,
            };
            Response<Completions> response = await client.GetCompletionsAsync(deploymentOrModelName, requestOptions);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices[0].FinishReason, Is.EqualTo(CompletionsFinishReason.TokenLimitReached));
            Assert.IsTrue(response.Value.Choices[0].FinishReason == CompletionsFinishReason.TokenLimitReached);
            Assert.IsTrue(response.Value.Choices[0].FinishReason == "length");
        }

        [RecordedTest]
        [TestCase(OpenAIClientServiceTarget.Azure)]
        [TestCase(OpenAIClientServiceTarget.NonAzure)]
        public async Task StreamingCompletions(OpenAIClientServiceTarget serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            string deploymentOrModelName = GetDeploymentOrModelName(serviceTarget, OpenAIClientScenario.Completions);
            var requestOptions = new CompletionsOptions()
            {
                Prompts =
                {
                    "Tell me some jokes about mangos",
                    "What are some disturbing facts about papayas?"
                },
                MaxTokens = 512,
                LogProbabilityCount = 1,
            };

            Response<StreamingCompletions> response = await client.GetCompletionsStreamingAsync(
                deploymentOrModelName,
                requestOptions);
            Assert.That(response, Is.Not.Null);

            // StreamingCompletions implements IDisposable; capturing the .Value field of `response` with a `using`
            // statement is unusual but properly ensures that `.Dispose()` will be called, as `Response<T>` does *not*
            // implement IDisposable or otherwise ensure that an `IDisposable` underlying `.Value` is disposed.
            using StreamingCompletions responseValue = response.Value;

            int originallyEnumeratedChoices = 0;
            var originallyEnumeratedTextParts = new List<List<string>>();

            await foreach (StreamingChoice choice in responseValue.GetChoicesStreaming())
            {
                List<string> textPartsForChoice = new List<string>();
                StringBuilder choiceTextBuilder = new StringBuilder();
                await foreach (string choiceTextPart in choice.GetTextStreaming())
                {
                    choiceTextBuilder.Append(choiceTextPart);
                    textPartsForChoice.Add(choiceTextPart);
                }
                Assert.That(choiceTextBuilder.ToString(), Is.Not.Null.Or.Empty);
                // Note: needs to be clarified why AOAI sets this and OAI does not
                if (serviceTarget == OpenAIClientServiceTarget.Azure)
                {
                    Assert.That(choice.FinishReason, Is.Not.Null.Or.Empty);
                }
                Assert.That(choice.LogProbabilityModel, Is.Not.Null);
                originallyEnumeratedChoices++;
                originallyEnumeratedTextParts.Add(textPartsForChoice);
            }

            // Note: these top-level values *are likely not yet populated* until *after* at least one streaming
            // choice has arrived.
            Assert.That(response.GetRawResponse(), Is.Not.Null.Or.Empty);
            Assert.That(responseValue.Id, Is.Not.Null.Or.Empty);
            Assert.That(responseValue.Created, Is.GreaterThan(new DateTimeOffset(new DateTime(2023, 1, 1))));
            Assert.That(responseValue.Created, Is.LessThan(DateTimeOffset.UtcNow.AddDays(7)));

            // Validate stability of enumeration (non-cancelled case)
            IReadOnlyList<StreamingChoice> secondPassChoices = await GetBlockingListFromIAsyncEnumerable(
                responseValue.GetChoicesStreaming());
            Assert.AreEqual(originallyEnumeratedChoices, secondPassChoices.Count);
            for (int i = 0; i < secondPassChoices.Count; i++)
            {
                IReadOnlyList<string> secondPassTextParts = await GetBlockingListFromIAsyncEnumerable(
                    secondPassChoices[i].GetTextStreaming());
                Assert.AreEqual(originallyEnumeratedTextParts[i].Count, secondPassTextParts.Count);
                for (int j = 0; j < originallyEnumeratedTextParts[i].Count; j++)
                {
                    Assert.AreEqual(originallyEnumeratedTextParts[i][j], secondPassTextParts[j]);
                }
            }
        }

        // Lightweight reimplementation of .NET 7 .ToBlockingEnumerable().ToList()
        private static async Task<IReadOnlyList<T>> GetBlockingListFromIAsyncEnumerable<T>(
            IAsyncEnumerable<T> asyncValues)
        {
            List<T> result = new List<T>();
            await foreach (T asyncValue in asyncValues)
            {
                result.Add(asyncValue);
            }
            return result;
        }
    }
}
