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

namespace Azure.AI.ContentUnderstanding.Samples
{
    public partial class ContentUnderstandingSamples
    {
        [RecordedTest]
        public async Task UpdateDefaultsAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions(_serviceVersion));
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            #region Snippet:ContentUnderstandingUpdateDefaults
#if SNIPPET
            // Map your deployed models to the models required by prebuilt analyzers
            var modelDeployments = new Dictionary<string, string>
            {
                ["gpt-5.2"] = "<your-gpt-5.2-deployment-name>",
                ["text-embedding-3-large"] = "<your-text-embedding-3-large-deployment-name>",
                ["prebuilt-analyzer-completion"] = "<your-gpt-5.2-deployment-name>",
                ["prebuilt-analyzer-completion-mini"] = "<your-gpt-5.2-deployment-name>",
                ["prebuilt-analyzer-embedding"] = "<your-text-embedding-3-large-deployment-name>"
            };

            var response = await client.UpdateDefaultsAsync(modelDeployments);
            ContentUnderstandingDefaults updatedDefaults = response.Value;

            Console.WriteLine("Model deployments configured successfully!");
            foreach (var kvp in updatedDefaults.ModelDeployments)
            {
                Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
            }
#else
            // Only update if we have deployment names configured in environment
            string completionModel = ModelProfile.CompletionModel;
            string? completionModelDeployment = ModelProfile.CompletionDeployment;
            string? completionMiniDeployment = ModelProfile.MiniCompletionDeployment;
            string? embeddingDeployment = TestEnvironment.EmbeddingDeployment;

            if (!string.IsNullOrEmpty(completionModelDeployment) &&
                !string.IsNullOrEmpty(completionMiniDeployment) &&
                !string.IsNullOrEmpty(embeddingDeployment))
            {
                var modelDeployments = new Dictionary<string, string>
                {
                    [completionModel] = completionModelDeployment!,
                    ["text-embedding-3-large"] = embeddingDeployment!,
                    ["prebuilt-analyzer-completion"] = completionModelDeployment!,
                    ["prebuilt-analyzer-completion-mini"] = completionMiniDeployment!,
                    ["prebuilt-analyzer-embedding"] = embeddingDeployment!
                };

                var response = await client.UpdateDefaultsAsync(modelDeployments);
                ContentUnderstandingDefaults updatedDefaults = response.Value;

                Console.WriteLine("Model deployments configured successfully!");
                foreach (var kvp in updatedDefaults.ModelDeployments)
                {
                    Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
                }
            }
            else
            {
                Console.WriteLine("Skipping UpdateDefaults - deployment names not configured in test environment");
            }
#endif
            #endregion

            #region Snippet:ContentUnderstandingGetDefaults
#if SNIPPET
            var getResponse = await client.GetDefaultsAsync();
            ContentUnderstandingDefaults defaults = getResponse.Value;
#else
            var getResponse = await client.GetDefaultsAsync();
            ContentUnderstandingDefaults defaults = getResponse.Value;
#endif

            Console.WriteLine("Current model deployment mappings:");
            if (defaults.ModelDeployments != null && defaults.ModelDeployments.Count > 0)
            {
                foreach (var kvp in defaults.ModelDeployments)
                {
                    Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
                }
            }
            else
            {
                Console.WriteLine("  No model deployments configured yet.");
            }
            #endregion
        }
    }
}
