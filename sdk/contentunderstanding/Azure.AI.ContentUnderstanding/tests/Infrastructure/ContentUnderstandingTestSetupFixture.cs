// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    /// <summary>
    /// One-time setup fixture that configures Content Understanding service defaults before any tests run.
    /// This ensures that GPT model deployments are configured for all tests that depend on them.
    /// </summary>
    /// <remarks>
    /// This fixture runs once per test assembly before any tests execute. It configures the required
    /// model deployments (gpt-4.1, gpt-4.1-mini, text-embedding-3-large) if they are not already configured.
    /// This setup is only performed in Live mode; in Playback mode, the recorded defaults are used.
    /// </remarks>
    [SetUpFixture]
    public class ContentUnderstandingTestSetupFixture : SetUpFixtureBase<ContentUnderstandingClientTestEnvironment>
    {
        /// <summary>
        /// Performs one-time setup to configure Content Understanding service defaults.
        /// </summary>
        public override async Task SetUp()
        {
            // Only configure defaults in Live mode (not in Playback mode)
            if (Environment.Mode == RecordedTestMode.Playback)
            {
                return;
            }

            // Configure defaults asynchronously
            await ConfigureDefaultsAsync();
        }

        /// <summary>
        /// Configures the Content Understanding service defaults with required model deployments.
        /// </summary>
        private async Task ConfigureDefaultsAsync()
        {
            // Check if model deployments are configured in test environment
            string? gpt41Deployment = Environment.Gpt41Deployment;
            string? gpt41MiniDeployment = Environment.Gpt41MiniDeployment;
            string? textEmbeddingDeployment = Environment.TextEmbedding3LargeDeployment;

            if (string.IsNullOrEmpty(gpt41Deployment) || string.IsNullOrEmpty(gpt41MiniDeployment) || string.IsNullOrEmpty(textEmbeddingDeployment))
            {
                var missingDeployments = new List<string>();
                if (string.IsNullOrEmpty(gpt41Deployment))
                {
                    missingDeployments.Add("GPT_4_1_DEPLOYMENT");
                }
                if (string.IsNullOrEmpty(gpt41MiniDeployment))
                {
                    missingDeployments.Add("GPT_4_1_MINI_DEPLOYMENT");
                }
                if (string.IsNullOrEmpty(textEmbeddingDeployment))
                {
                    missingDeployments.Add("TEXT_EMBEDDING_3_LARGE_DEPLOYMENT");
                }

                var errorMessage = $"Content Understanding test setup failed: Required model deployment environment variables are not configured. Missing: {string.Join(", ", missingDeployments)}. " +
                    $"These variables must be set in the test environment for tests to run. " +
                    $"In cloud pipelines, they are typically set by test-resources.bicep outputs. " +
                    $"For local development, set them in your test configuration or environment variables.";

                TestContext.WriteLine(errorMessage);
                throw new InvalidOperationException(errorMessage);
            }

            try
            {
                var endpoint = new Uri(Environment.Endpoint);
                var credential = Environment.Credential;
                var client = new ContentUnderstandingClient(endpoint, credential);

                // Check if defaults are already configured
                Response<ContentUnderstandingDefaults> currentDefaults = await client.GetDefaultsAsync();
                bool needsConfiguration = false;

                if (currentDefaults.Value.ModelDeployments == null || currentDefaults.Value.ModelDeployments.Count == 0)
                {
                    needsConfiguration = true;
                }
                else
                {
                    // Check if all required models are configured
                    needsConfiguration = !currentDefaults.Value.ModelDeployments.ContainsKey("gpt-4.1") ||
                                        !currentDefaults.Value.ModelDeployments.ContainsKey("gpt-4.1-mini") ||
                                        !currentDefaults.Value.ModelDeployments.ContainsKey("text-embedding-3-large") ||
                                        currentDefaults.Value.ModelDeployments["gpt-4.1"] != gpt41Deployment ||
                                        currentDefaults.Value.ModelDeployments["gpt-4.1-mini"] != gpt41MiniDeployment ||
                                        currentDefaults.Value.ModelDeployments["text-embedding-3-large"] != textEmbeddingDeployment;
                }

                if (needsConfiguration)
                {
                    TestContext.WriteLine("Configuring Content Understanding service defaults...");
                    var nonNullGpt41Deployment = gpt41Deployment ?? throw new InvalidOperationException("gpt41Deployment must be configured for test setup.");
                    var nonNullGpt41MiniDeployment = gpt41MiniDeployment ?? throw new InvalidOperationException("gpt41MiniDeployment must be configured for test setup.");
                    var nonNullTextEmbeddingDeployment = textEmbeddingDeployment ?? throw new InvalidOperationException("textEmbeddingDeployment must be configured for test setup.");

                    var modelDeployments = new Dictionary<string, string>
                    {
                        ["gpt-4.1"] = nonNullGpt41Deployment,
                        ["gpt-4.1-mini"] = nonNullGpt41MiniDeployment,
                        ["text-embedding-3-large"] = nonNullTextEmbeddingDeployment
                    };

                    Response<ContentUnderstandingDefaults> response = await client.UpdateDefaultsAsync(modelDeployments);
                    TestContext.WriteLine("Defaults configured successfully:");
                    foreach (var kvp in response.Value.ModelDeployments)
                    {
                        TestContext.WriteLine($"  {kvp.Key}: {kvp.Value}");
                    }
                }
                else
                {
                    TestContext.WriteLine("Content Understanding service defaults are already configured correctly.");
                }
            }
            catch (Exception ex)
            {
                TestContext.WriteLine($"Failed to configure Content Understanding service defaults: {ex.Message}");
                TestContext.WriteLine("Test setup cannot continue without configured defaults.");
                throw;
            }
        }
    }
}
