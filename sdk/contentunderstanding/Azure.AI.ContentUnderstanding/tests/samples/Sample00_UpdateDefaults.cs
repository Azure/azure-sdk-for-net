// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.AI.ContentUnderstanding.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Samples
{
    public partial class ContentUnderstandingSamples
    {
        [RecordedTest]
        public async Task UpdateDefaultsAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            #region Snippet:ContentUnderstandingGetDefaults
#if SNIPPET
            // Step 1: Get current defaults to see what's configured
            Console.WriteLine("Getting current default configuration...");
            var getResponse = await client.GetDefaultsAsync();
            ContentUnderstandingDefaults currentDefaults = getResponse.Value;
            Console.WriteLine("Current defaults retrieved successfully.");
            Console.WriteLine($"Current model deployments: {currentDefaults.ModelDeployments?.Count ?? 0} configured");
#else
            // Step 1: Get current defaults to see what's configured
            Console.WriteLine("Getting current default configuration...");
            var getResponse = await client.GetDefaultsAsync();
            ContentUnderstandingDefaults currentDefaults = getResponse.Value;
            Console.WriteLine("Current defaults retrieved successfully.");
            Console.WriteLine($"Current model deployments: {currentDefaults.ModelDeployments?.Count ?? 0} configured");
#endif
            #endregion

            #region Assertion:ContentUnderstandingGetDefaults
            Assert.IsNotNull(currentDefaults, "Current defaults should not be null");
            Assert.IsNotNull(currentDefaults.ModelDeployments, "Model deployments should not be null");
            #endregion

            #region Snippet:ContentUnderstandingUpdateDefaults
#if SNIPPET
            // Step 2: Configure model deployments
            // Map your deployed models to the models required by prebuilt analyzers
            var modelDeployments = new Dictionary<string, string>
            {
                ["gpt-4.1"] = "<your-gpt-4.1-deployment-name>",
                ["gpt-4.1-mini"] = "<your-gpt-4.1-mini-deployment-name>",
                ["text-embedding-3-large"] = "<your-text-embedding-3-large-deployment-name>"
            };

            Console.WriteLine("\nUpdating default configuration...");
            var updateResponse = await client.UpdateDefaultsAsync(modelDeployments);
            ContentUnderstandingDefaults updatedDefaults = updateResponse.Value;

            Console.WriteLine("Defaults updated successfully.");
            Console.WriteLine("Updated model deployments:");
            foreach (var kvp in updatedDefaults.ModelDeployments)
            {
                Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
            }
#else
            // Step 2: Configure model deployments from environment variables
            string? gpt41Deployment = TestEnvironment.Gpt41Deployment;
            string? gpt41MiniDeployment = TestEnvironment.Gpt41MiniDeployment;
            string? textEmbeddingDeployment = TestEnvironment.TextEmbedding3LargeDeployment;

            Assert.IsFalse(string.IsNullOrEmpty(gpt41Deployment), "GPT_4_1_DEPLOYMENT environment variable must be set");
            Assert.IsFalse(string.IsNullOrEmpty(gpt41MiniDeployment), "GPT_4_1_MINI_DEPLOYMENT environment variable must be set");
            Assert.IsFalse(string.IsNullOrEmpty(textEmbeddingDeployment), "TEXT_EMBEDDING_3_LARGE_DEPLOYMENT environment variable must be set");

            var modelDeployments = new Dictionary<string, string>
            {
                ["gpt-4.1"] = gpt41Deployment!,
                ["gpt-4.1-mini"] = gpt41MiniDeployment!,
                ["text-embedding-3-large"] = textEmbeddingDeployment!
            };

            Console.WriteLine("\nModel deployments to configure:");
            Console.WriteLine($"  gpt-4.1 -> {gpt41Deployment}");
            Console.WriteLine($"  gpt-4.1-mini -> {gpt41MiniDeployment}");
            Console.WriteLine($"  text-embedding-3-large -> {textEmbeddingDeployment}");

            Console.WriteLine("\nUpdating default configuration...");
            var updateResponse = await client.UpdateDefaultsAsync(modelDeployments);
            ContentUnderstandingDefaults updatedDefaults = updateResponse.Value;

            Console.WriteLine("Defaults updated successfully.");
            Console.WriteLine("Updated model deployments:");
            foreach (var kvp in updatedDefaults.ModelDeployments)
            {
                Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
            }
#endif
            #endregion

            #region Assertion:ContentUnderstandingUpdateDefaults
            Assert.IsNotNull(updatedDefaults, "Updated defaults should not be null");
            Assert.IsNotNull(updatedDefaults.ModelDeployments, "Updated model deployments should not be null");
            Assert.IsTrue(updatedDefaults.ModelDeployments.Count > 0, "Updated model deployments should not be empty");
            #endregion

            #region Snippet:ContentUnderstandingVerifyDefaults
#if SNIPPET
            // Step 3: Verify the updated configuration
            Console.WriteLine("\nVerifying updated configuration...");
            var verifyResponse = await client.GetDefaultsAsync();
            ContentUnderstandingDefaults verifiedDefaults = verifyResponse.Value;

            Console.WriteLine("Verified model deployments:");
            foreach (var kvp in verifiedDefaults.ModelDeployments)
            {
                Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
            }
#else
            // Step 3: Verify the updated configuration
            Console.WriteLine("\nVerifying updated configuration...");
            var verifyResponse = await client.GetDefaultsAsync();
            ContentUnderstandingDefaults verifiedDefaults = verifyResponse.Value;

            Console.WriteLine("Verified model deployments:");
            foreach (var kvp in verifiedDefaults.ModelDeployments)
            {
                Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
            }
#endif
            #endregion

            #region Assertion:ContentUnderstandingVerifyDefaults
            Assert.IsNotNull(verifiedDefaults, "Verified defaults should not be null");
            Assert.IsNotNull(verifiedDefaults.ModelDeployments, "Verified model deployments should not be null");
            Assert.IsTrue(verifiedDefaults.ModelDeployments.Count > 0, "Verified model deployments should not be empty");

            // Verify the model deployments contain the expected keys
            Assert.IsTrue(verifiedDefaults.ModelDeployments.ContainsKey("gpt-4.1"),
                "Model deployments should contain gpt-4.1");
            Assert.IsTrue(verifiedDefaults.ModelDeployments.ContainsKey("gpt-4.1-mini"),
                "Model deployments should contain gpt-4.1-mini");
            Assert.IsTrue(verifiedDefaults.ModelDeployments.ContainsKey("text-embedding-3-large"),
                "Model deployments should contain text-embedding-3-large");

#if !SNIPPET
            // Verify the values match what we set
            Assert.AreEqual(gpt41Deployment, verifiedDefaults.ModelDeployments["gpt-4.1"],
                "gpt-4.1 deployment should match configured value");
            Assert.AreEqual(gpt41MiniDeployment, verifiedDefaults.ModelDeployments["gpt-4.1-mini"],
                "gpt-4.1-mini deployment should match configured value");
            Assert.AreEqual(textEmbeddingDeployment, verifiedDefaults.ModelDeployments["text-embedding-3-large"],
                "text-embedding-3-large deployment should match configured value");
#endif
            #endregion

            Console.WriteLine("\nConfiguration management completed.");
        }
    }
}
