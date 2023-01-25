// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using Azure.AI.OpenAI.Models;
using Azure.Core.TestFramework;
using System.Threading.Tasks;

namespace Azure.AI.OpenAI.Tests
{
    public class OpenAIInferenceTests : OpenAITestBase
    {
        public OpenAIInferenceTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
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
            var tokenClient = GetClientWithToken();
            Assert.That(tokenClient, Is.InstanceOf<OpenAIClient>());
        }

        /// <summary>
        /// Test Completion.
        /// </summary>
        [RecordedTest]
        public async Task CompletionTest()
        {
            var client = GetClient();
            CompletionsRequest completionsRequest = new CompletionsRequest();
            completionsRequest.Prompt.Add("Hello world");
            completionsRequest.Prompt.Add("running over the same old ground");
            Assert.That(completionsRequest, Is.InstanceOf<CompletionsRequest>());
            var response = await client.CompletionsAsync(DeploymentId, completionsRequest);
            Assert.That(response, Is.InstanceOf<Response<Completion>>());
        }

        /// <summary>
        /// Test Embeddings.
        /// </summary>
        [RecordedTest]
        public async Task EmbeddingTest()
        {
            var client = GetClient();
            EmbeddingsRequest embeddingsRequest = new EmbeddingsRequest("Your text string goes here");
            Assert.That(embeddingsRequest, Is.InstanceOf<EmbeddingsRequest>());
            var response = await client.EmbeddingsAsync(EmbeddingsDeploymentId, embeddingsRequest);
            Assert.That(response, Is.InstanceOf<Response<Embeddings>>());
        }
    }
}
