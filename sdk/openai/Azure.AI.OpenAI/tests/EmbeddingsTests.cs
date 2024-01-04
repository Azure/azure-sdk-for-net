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
    public class EmbeddingsTests : OpenAITestBase
    {
        public EmbeddingsTests(bool isAsync)
            : base(Scenario.Embeddings, isAsync) // , RecordedTestMode.Live)
        {
        }

        [RecordedTest]
        [TestCase(Service.Azure)]
        [TestCase(Service.NonAzure)]
        public async Task Embeddings(Service serviceTarget)
        {
            OpenAIClient client = GetTestClient(serviceTarget);
            string deploymentOrModelName = GetDeploymentOrModelName(serviceTarget, Scenario.Embeddings);
            var embeddingsOptions = new EmbeddingsOptions()
            {
                DeploymentName = deploymentOrModelName,
                Input = { "Your text string goes here" },
            };
            Assert.That(embeddingsOptions, Is.InstanceOf<EmbeddingsOptions>());
            Response<Embeddings> response = await client.GetEmbeddingsAsync(embeddingsOptions);
            Assert.That(response, Is.InstanceOf<Response<Embeddings>>());
            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.Data, Is.Not.Null.Or.Empty);

            EmbeddingItem firstItem = response.Value.Data[0];
            Assert.That(firstItem, Is.Not.Null);
            Assert.That(firstItem.Index, Is.EqualTo(0));
            Assert.That(firstItem.Embedding, Is.Not.Null.Or.Empty);
        }
    }
}
