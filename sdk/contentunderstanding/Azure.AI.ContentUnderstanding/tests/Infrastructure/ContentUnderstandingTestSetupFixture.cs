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
    /// model deployments (gpt-5.2, text-embedding-3-large) if they are not already configured.
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
            // Only configure defaults in Live mode (skip Playback and Record modes).
            if (Environment.Mode != RecordedTestMode.Live)
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
            string completionModel = Environment.CompletionModel;
            string? completionModelDeployment = Environment.CompletionModelDeployment;
            string? completionMiniDeployment = Environment.CompletionMiniDeployment;
            string? embeddingDeployment = Environment.EmbeddingDeployment;

            if (string.IsNullOrEmpty(completionModelDeployment) ||
                string.IsNullOrEmpty(completionMiniDeployment) ||
                string.IsNullOrEmpty(embeddingDeployment))
            {
                var missingDeployments = new List<string>();
                if (string.IsNullOrEmpty(completionModelDeployment))
                {
                    missingDeployments.Add("CU_COMPLETION_MODEL_DEPLOYMENT");
                }
                if (string.IsNullOrEmpty(completionMiniDeployment))
                {
                    missingDeployments.Add("CU_COMPLETION_MINI_DEPLOYMENT");
                }
                if (string.IsNullOrEmpty(embeddingDeployment))
                {
                    missingDeployments.Add("CU_EMBEDDING_DEPLOYMENT");
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
                var client = new ContentUnderstandingClient(
                    endpoint,
                    Environment.Credential,
                    new ContentUnderstandingClientOptions(ContentUnderstandingClientOptions.ServiceVersion.V2025_11_01));

                TestContext.WriteLine($"Configuring defaults against {endpoint} (mode={Environment.Mode}).");

                // Check if defaults are already configured
                bool needsConfiguration = false;
                Response<ContentUnderstandingDefaults>? currentDefaults = null;

                try
                {
                    currentDefaults = await client.GetDefaultsAsync();
                }
                catch (RequestFailedException ex) when (ex.Status == 400 && ex.ErrorCode == "InvalidRequest" && ex.Message.Contains("DefaultsNotSet", StringComparison.Ordinal))
                {
                    // Fresh resources can return DefaultsNotSet before any PATCH /defaults.
                    needsConfiguration = true;
                }

                IDictionary<string, string>? existingModelDeployments = currentDefaults?.Value.ModelDeployments;

                if (!needsConfiguration && (existingModelDeployments == null || existingModelDeployments.Count == 0))
                {
                    needsConfiguration = true;
                }
                else if (!needsConfiguration)
                {
                    // Check if all required models are configured
                    needsConfiguration = !existingModelDeployments!.ContainsKey(completionModel) ||
                                        !existingModelDeployments.ContainsKey("text-embedding-3-large") ||
                                        !existingModelDeployments.ContainsKey("prebuilt-analyzer-completion") ||
                                        !existingModelDeployments.ContainsKey("prebuilt-analyzer-completion-mini") ||
                                        !existingModelDeployments.ContainsKey("prebuilt-analyzer-embedding") ||
                                        existingModelDeployments[completionModel] != completionModelDeployment ||
                                        existingModelDeployments["text-embedding-3-large"] != embeddingDeployment ||
                                        existingModelDeployments["prebuilt-analyzer-completion"] != completionModelDeployment ||
                                        existingModelDeployments["prebuilt-analyzer-completion-mini"] != completionMiniDeployment ||
                                        existingModelDeployments["prebuilt-analyzer-embedding"] != embeddingDeployment;
                }

                if (needsConfiguration)
                {
                    TestContext.WriteLine("Configuring Content Understanding service defaults...");
                    var nonNullCompletionModelDeployment = completionModelDeployment ?? throw new InvalidOperationException("completionModelDeployment must be configured for test setup.");
                    var nonNullCompletionMiniDeployment = completionMiniDeployment ?? throw new InvalidOperationException("completionMiniDeployment must be configured for test setup.");
                    var nonNullEmbeddingDeployment = embeddingDeployment ?? throw new InvalidOperationException("embeddingDeployment must be configured for test setup.");

                    var modelDeployments = new Dictionary<string, string>
                    {
                        [completionModel] = nonNullCompletionModelDeployment,
                        ["text-embedding-3-large"] = nonNullEmbeddingDeployment,
                        ["prebuilt-analyzer-completion"] = nonNullCompletionModelDeployment,
                        ["prebuilt-analyzer-completion-mini"] = nonNullCompletionMiniDeployment,
                        ["prebuilt-analyzer-embedding"] = nonNullEmbeddingDeployment
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
