// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using Azure.Core.TestFramework;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core;
using System;

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
            var client = GetClient();
            CompletionsOptions completionsRequest = new CompletionsOptions();
            completionsRequest.Prompt.Add("Hello world");
            completionsRequest.Prompt.Add("running over the same old ground");
            Assert.That(completionsRequest, Is.InstanceOf<CompletionsOptions>());
            var response = await client.GetCompletionsAsync(CompletionsDeploymentId, completionsRequest);
            Assert.That(response, Is.InstanceOf<Response<Completions>>());
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

        public class SnoopPolicy : HttpPipelinePolicy
        {
            public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                throw new NotImplementedException();
            }

            public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                throw new NotImplementedException();
            }
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
                //GenerationSampleCount = 3,
                //CacheLevel = 0,
                //Temperature = 0.75f,
                //User = "AzureSDKOpenAITests",
                // Echo = true,
                //Model = "this is a bogus model parameter in the body",
                LogProbability = 1,
            };
            Response<Completions> response = await client.GetCompletionsAsync(
                CompletionsDeploymentId,
                requestOptions);
            Assert.That(response, Is.Not.Null);
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
            var client = GetClient();
            CompletionsOptions completionsRequest = new CompletionsOptions();
            completionsRequest.Prompt.Add("Hello world");
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await client.GetCompletionsAsync("BAD_DEPLOYMENT_ID", completionsRequest); });
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
                MaxTokens = 10,
            };
            Response<Completions> response = await client.GetCompletionsAsync(
                CompletionsDeploymentId,
                requestOptions);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices[0].FinishReason, Is.EqualTo("length"));
        }
    }
}
