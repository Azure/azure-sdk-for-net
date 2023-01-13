// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using NUnit.Framework;
using Azure.OpenAI.Inference.Models;

namespace Azure.OpenAI.Inference.Tests
{
    [TestFixture]
    public class OpenAIInferenceTests : OpenAITestBase
    {
        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
        }

        /// <summary>
        /// Test an instance of OpenAIClient
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            var client = GetClient();
            Assert.That(client, Is.InstanceOf<OpenAIClient>());
        }

        /// <summary>
        /// Test Completion
        /// </summary>
        [Test]
        public void CompletionTest()
        {
            var client = GetClient();
            CompletionsRequest completionsRequest = new CompletionsRequest(new List<string> { "Hello world", "running over the same old ground" });
            Assert.That(completionsRequest, Is.InstanceOf<CompletionsRequest>());
            var response = client.Completions(DeploymentId, completionsRequest);
            Assert.That(response, Is.InstanceOf<Response<Completion>>());
        }
    }
}
