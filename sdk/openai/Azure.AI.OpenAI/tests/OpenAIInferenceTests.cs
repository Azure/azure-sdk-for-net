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

        /// <summary>
        /// Test an instance of OpenAIClient.
        /// </summary>
        [RecordedTest]
        public void InstanceTest()
        {
            OpenAIClient client = GetClient();
            Assert.That(client, Is.InstanceOf<OpenAIClient>());
            OpenAIClient tokenClient = GetClientWithCredential();
            Assert.That(tokenClient, Is.InstanceOf<OpenAIClient>());
        }

        [Test]
        public void PublicOpenAICompletionsTest()
        {
            var client = GetPublicOpenAIClient();
            Assert.That(client, Is.InstanceOf<OpenAIClient>());
            CompletionsOptions requestOptions = new CompletionsOptions()
            {
                Prompt =
                {
                    "Hello world",
                    "running over the same old ground",
                },
                Model = "text-ada-003",
            };
            Assert.That(requestOptions, Is.InstanceOf<CompletionsOptions>());
            Response<Completions> response = client.GetCompletions("", requestOptions);
            Assert.That(response, Is.Not.Null);
            Assert.That(response, Is.InstanceOf<Response<Completions>>());
            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices.Count, Is.EqualTo(1));
            Assert.That(response.Value.Choices[0].FinishReason, Is.Not.Null.Or.Empty);
        }

        /// <summary>
        /// Test Completion.
        /// </summary>
        [RecordedTest]
        public async Task CompletionTest()
        {
            OpenAIClient client = GetClient();
            CompletionsOptions requestOptions = new CompletionsOptions()
            {
                Prompt =
                {
                    "Hello world",
                    "running over the same old ground",
                },
            };
            Assert.That(requestOptions, Is.InstanceOf<CompletionsOptions>());
            Response<Completions> response = await client.GetCompletionsAsync(
                CompletionsDeploymentId,
                requestOptions);
            Assert.That(response, Is.Not.Null);
            Assert.That(response, Is.InstanceOf<Response<Completions>>());
            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices.Count, Is.EqualTo(requestOptions.Prompt.Count));
            Assert.That(response.Value.Choices[0].FinishReason, Is.Not.Null.Or.Empty);
        }

        /// <summary>
        /// Test Completions using a TokenCredential.
        /// </summary>
        [RecordedTest]
        public async Task CompletionTestWithTokenCredential()
        {
            OpenAIClient client = GetClientWithCredential();
            CompletionsOptions requestOptions = new CompletionsOptions();
            requestOptions.Prompt.Add("Hello, world!");
            requestOptions.Prompt.Add("I can have multiple prompts");
            Assert.That(requestOptions, Is.InstanceOf<CompletionsOptions>());
            Response<Completions> response = await client.GetCompletionsAsync(CompletionsDeploymentId, requestOptions);
            Assert.That(response, Is.InstanceOf<Response<Completions>>());
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices.Count, Is.EqualTo(2));
        }

        /// <summary>
        /// Test Simplified Completion API.
        /// </summary>
        [RecordedTest]
        public async Task SimpleCompletionTest()
        {
            OpenAIClient client = GetClientWithCredential();
            Response<Completions> response = await client.GetCompletionsAsync(CompletionsDeploymentId, "Hello World!");
            Assert.That(response, Is.InstanceOf<Response<Completions>>());
        }

        /// <summary>
        /// Test Embeddings.
        /// </summary>
        [RecordedTest]
        public async Task EmbeddingTest()
        {
            OpenAIClient client = GetClient();
            EmbeddingsOptions embeddingsRequest = new EmbeddingsOptions("Your text string goes here");
            Assert.That(embeddingsRequest, Is.InstanceOf<EmbeddingsOptions>());
            Response<Embeddings> response = await client.GetEmbeddingsAsync(EmbeddingsDeploymentId, embeddingsRequest);
            Assert.That(response, Is.InstanceOf<Response<Embeddings>>());
        }

        /// <summary>
        /// Exercises usage information within a completions response.
        /// </summary>
        /// <returns></returns>
        [RecordedTest]
        public async Task CompletionUsageTest()
        {
            OpenAIClient client = GetClient();
            CompletionsOptions requestOptions = new CompletionsOptions()
            {
                Prompt =
                {
                    "Hello world",
                    "This is a test",
                },
                MaxTokens = 1024,
                SnippetCount = 3,
                LogProbability = 1,
            };
            int expectedChoiceCount = (requestOptions.SnippetCount ?? 1) * requestOptions.Prompt.Count;
            Response<Completions> response = await client.GetCompletionsAsync(CompletionsDeploymentId, requestOptions);
            Assert.That(response.GetRawResponse(), Is.Not.Null.Or.Empty);
            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.Id, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Model, Is.EqualTo(CompletionsDeploymentId));
            Assert.That(response.Value.Created, Is.GreaterThan(0));
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices.Count, Is.EqualTo(expectedChoiceCount), "Each prompt should produce `SnippetCount` choices");
            Assert.That(response.Value.Usage, Is.Not.Null);
            Assert.That(response.Value.Usage.TotalTokens, Is.GreaterThan(0));
            Assert.That(response.Value.Usage.TotalTokens, Is.EqualTo(response.Value.Usage.CompletionTokens + response.Value.Usage.PromptTokens));

            Choice firstChoice = response.Value.Choices[0];
            Assert.That(firstChoice, Is.Not.Null);
            Assert.That(firstChoice.FinishReason, Is.EqualTo("stop"));
            Assert.That(firstChoice.Text, Is.Not.Null.Or.Empty);
            Assert.That(firstChoice.Logprobs, Is.Not.Null);
            Assert.That(firstChoice.Logprobs.Tokens, Is.Not.Null.Or.Empty);
            Assert.That(firstChoice.Logprobs.Tokens.Count, Is.LessThan(response.Value.Usage.TotalTokens));
            Assert.That(firstChoice.Logprobs.Tokens[0], Is.Not.Null.Or.Empty);

            Assert.That(response.Value.Choices[2].Index, Is.EqualTo(2));
        }

        [RecordedTest]
        public async Task TestLogProbs()
        {
            OpenAIClient client = GetClient();
            CompletionsOptions requestOptions = new CompletionsOptions()
            {
                Prompt = { "Hello world" },
                Echo = true,
                LogProbability = 1,
            };
            Response<Completions> response = await client.GetCompletionsAsync(
                CompletionsDeploymentId,
                requestOptions);
        }

        [RecordedTest]
        public async Task TestAdvancedCompletionsOptions()
        {
            OpenAIClient client = GetClient();
            string promptText = "Are bananas especially radioactive?";
            CompletionsOptions requestOptions = new CompletionsOptions()
            {
                Prompt = { promptText },
                GenerationSampleCount = 3,
                CacheLevel = 0,
                Temperature = 0.75f,
                User = "AzureSDKOpenAITests",
                Echo = true,
                Model = "this is a bogus model parameter in the body",
                LogProbability = 1,
            };
            Response<Completions> response = await client.GetCompletionsAsync(
                CompletionsDeploymentId,
                requestOptions);
            Assert.That(response, Is.Not.Null);
            string rawResponse = response.GetRawResponse().Content.ToString();
            Assert.That(rawResponse, Is.Not.Null.Or.Empty);

            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices.Count, Is.EqualTo(1));
            Assert.That(response.Value.Choices[0].Text.ToLower().StartsWith(promptText.ToLower()));

            Assert.That(response.Value.Choices[0].Logprobs, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices[0].Logprobs.Tokens, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Usage.TotalTokens, Is.GreaterThan(response.Value.Choices[0].Logprobs.Tokens.Count));
        }

        /// <summary>
        /// Test Exception throw.
        /// </summary>
        [RecordedTest]
        public void RequestFailedExceptionTest()
        {
            OpenAIClient client = GetClient();
            CompletionsOptions completionsRequest = new CompletionsOptions();
            completionsRequest.Prompt.Add("Hello world");
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await client.GetCompletionsAsync("BAD_DEPLOYMENT_ID", completionsRequest);
            });
            Assert.AreEqual(404, exception.Status);
            Assert.That(exception.ErrorCode, Is.EqualTo("DeploymentNotFound"));
        }

        [RecordedTest]
        public async Task TestTokenCutoff()
        {
            OpenAIClient client = GetClient();
            CompletionsOptions requestOptions = new CompletionsOptions()
            {
                Prompt =
                {
                    "How long would it take an unladen swallow to travel between Seattle, WA"
                        + " and New York, NY?"
                },
                MaxTokens = 3,
            };
            Response<Completions> response = await client.GetCompletionsAsync(
                CompletionsDeploymentId,
                requestOptions);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices[0].FinishReason, Is.EqualTo("length"));
        }

        [RecordedTest]
        public async Task StreamingCompletionsTest()
        {
            OpenAIClient client = GetClient();
            CompletionsOptions requestOptions = new CompletionsOptions()
            {
                Prompt =
                {
                    "Tell me some jokes about mangos",
                    "What are some disturbing facts about papayas?"
                },
                MaxTokens = 512,
                LogProbability = 1,
            };

            Response<StreamingCompletions> response = await client.GetCompletionsStreamingAsync(
                    CompletionsDeploymentId,
                    requestOptions);
            Assert.That(response, Is.Not.Null);

            // StreamingCompletions implements IDisposable; capturing the .Value field of `response` with a `using`
            // statement is unusual but properly ensures that `.Dispose()` will be called, as `Response<T>` does *not*
            // implement IDisposable or otherwise ensure that an `IDisposable` underlying `.Value` is disposed.
            using StreamingCompletions responseValue = response.Value;

            int originallyEnumeratedChoices = 0;
            List<List<string>> originallyEnumeratedTextParts = new List<List<string>>();

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
                Assert.That(choice.FinishReason, Is.Not.Null.Or.Empty);
                Assert.That(choice.Logprobs, Is.Not.Null);
                originallyEnumeratedChoices++;
                originallyEnumeratedTextParts.Add(textPartsForChoice);
            }

            // Note: these top-level values *are likely not yet populated* until *after* at least one streaming
            // choice has arrived.
            Assert.That(response.GetRawResponse(), Is.Not.Null.Or.Empty);
            Assert.That(responseValue.Id, Is.Not.Null.Or.Empty);
            Assert.That(responseValue.Created, Is.GreaterThan(new DateTime(2022, 1, 1)));
            Assert.That(responseValue.Created, Is.LessThan(DateTime.Now.AddDays(2)));

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
