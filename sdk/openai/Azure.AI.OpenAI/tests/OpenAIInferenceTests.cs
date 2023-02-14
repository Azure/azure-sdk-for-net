// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using Azure.Core.TestFramework;
using System.Threading.Tasks;
using Azure.AI.OpenAI.Custom;
using System.Diagnostics;
using System;
using System.IO;
using System.Text;

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
            var client = GetClient();
            Assert.That(client, Is.InstanceOf<OpenAIClient>());
            var tokenClient = GetClientWithCredential();
            Assert.That(tokenClient, Is.InstanceOf<OpenAIClient>());
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
            var client = GetClientWithCredential();
            var response = await client.GetCompletionsAsync(CompletionsDeploymentId, "Hello World!");
            Assert.That(response, Is.InstanceOf<Response<Completions>>());
        }

        /// <summary>
        /// Test Embeddings.
        /// </summary>
        [RecordedTest]
        public async Task EmbeddingTest()
        {
            var client = GetClient();
            EmbeddingsOptions embeddingsRequest = new EmbeddingsOptions("Your text string goes here");
            Assert.That(embeddingsRequest, Is.InstanceOf<EmbeddingsOptions>());
            var response = await client.GetEmbeddingsAsync(EmbeddingsDeploymentId, embeddingsRequest);
            Assert.That(response, Is.InstanceOf<Response<Embeddings>>());
        }

        /// <summary>
        /// Test Exception throw.
        /// </summary>
        [RecordedTest]
        public void RequestFailedExceptionTest()
        {
            var client = GetClient();
            CompletionsOptions completionsRequest = new CompletionsOptions();
            completionsRequest.Prompt.Add("Hello world");
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await client.GetCompletionsAsync("BAD_DEPLOYMENT_ID", completionsRequest); });
            Assert.AreEqual(404, exception.Status);
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

            Response<StreamingCompletions> response = await client.GetStreamingCompletionsAsync(
                CompletionsDeploymentId,
                requestOptions);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.Not.Null);

            await foreach (StreamingChoice choice in response.Value.GetChoicesStreaming())
            {
                StringBuilder choiceTextBuilder = new StringBuilder();
                await foreach (string choiceTextPart in choice.GetTextStreaming())
                {
                    choiceTextBuilder.Append(choiceTextPart);
                }
                Assert.That(choiceTextBuilder.ToString(), Is.Not.Null.Or.Empty);
                Assert.That(choice.FinishReason, Is.Not.Null.Or.Empty);
                Assert.That(choice.Logprobs, Is.Not.Null);
            }

            Assert.That(response.Value.Id, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Model, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Created, Is.GreaterThan(0));
        }
    }
}
