// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

/// <summary>
/// This sample demonstrates how to configure and retrieve default model deployment settings for your Microsoft Foundry resource.
///
/// Prerequisites:
///     - Azure subscription
///     - Microsoft Foundry resource
///     - .NET 8.0 SDK or later
///     - Deployed GPT-4.1, GPT-4.1-mini, and text-embedding-3-large models in Microsoft Foundry
///
/// Setup:
///     Set the following environment variables or add them to appsettings.json:
///     - AZURE_CONTENT_UNDERSTANDING_ENDPOINT (required)
///     - AZURE_CONTENT_UNDERSTANDING_KEY (optional - DefaultAzureCredential will be used if not set)
///     - GPT_4_1_DEPLOYMENT (optional - required only for UpdateDefaults)
///     - GPT_4_1_MINI_DEPLOYMENT (optional - required only for UpdateDefaults)
///     - TEXT_EMBEDDING_3_LARGE_DEPLOYMENT (optional - required only for UpdateDefaults)
///
/// To run:
///     dotnet run
/// </summary>
class Program
{
    static async Task Main(string[] args)
    {
        // Load configuration
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var endpoint = configuration["AZURE_CONTENT_UNDERSTANDING_ENDPOINT"];
        if (string.IsNullOrEmpty(endpoint))
        {
            Console.Error.WriteLine("Error: AZURE_CONTENT_UNDERSTANDING_ENDPOINT is required.");
            Console.Error.WriteLine("Please set it in environment variables or appsettings.json");
            Environment.Exit(1);
        }

        // Trim and validate endpoint
        endpoint = endpoint.Trim();
        if (!Uri.TryCreate(endpoint, UriKind.Absolute, out var endpointUri))
        {
            Console.Error.WriteLine($"Error: Invalid endpoint URL: {endpoint}");
            Console.Error.WriteLine("Endpoint must be a valid absolute URI (e.g., https://your-resource.services.ai.azure.com/)");
            Environment.Exit(1);
        }

        // Create client with appropriate authentication
        var apiKey = configuration["AZURE_CONTENT_UNDERSTANDING_KEY"];
        ContentUnderstandingClient client;
        if (!string.IsNullOrEmpty(apiKey))
        {
            client = new ContentUnderstandingClient(endpointUri, new AzureKeyCredential(apiKey));
        }
        else
        {
            var credential = new DefaultAzureCredential();
            client = new ContentUnderstandingClient(endpointUri, credential);
        }

        try
        {
            // First, update defaults if deployment names are provided
            var gpt41Deployment = configuration["GPT_4_1_DEPLOYMENT"];
            var gpt41MiniDeployment = configuration["GPT_4_1_MINI_DEPLOYMENT"];
            var textEmbeddingDeployment = configuration["TEXT_EMBEDDING_3_LARGE_DEPLOYMENT"];

            if (!string.IsNullOrEmpty(gpt41Deployment) && !string.IsNullOrEmpty(gpt41MiniDeployment) && !string.IsNullOrEmpty(textEmbeddingDeployment))
            {
                Console.WriteLine("=== Updating Defaults ===");
                // Map your deployed models to the models required by prebuilt analyzers
                var modelDeployments = new Dictionary<string, string>
                {
                    ["gpt-4.1"] = gpt41Deployment,
                    ["gpt-4.1-mini"] = gpt41MiniDeployment,
                    ["text-embedding-3-large"] = textEmbeddingDeployment
                };

                var updateResponse = await client.UpdateDefaultsAsync(modelDeployments);
                ContentUnderstandingDefaults updatedDefaults = updateResponse.Value;

                Console.WriteLine("Model deployments configured successfully!");
                foreach (var kvp in updatedDefaults.ModelDeployments)
                {
                    Console.WriteLine($"  {kvp.Key} → {kvp.Value}");
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("=== Skipping UpdateDefaults ===");
                Console.WriteLine("To update defaults, set the following in appsettings.json or environment variables:");
                Console.WriteLine("  - GPT_4_1_DEPLOYMENT");
                Console.WriteLine("  - GPT_4_1_MINI_DEPLOYMENT");
                Console.WriteLine("  - TEXT_EMBEDDING_3_LARGE_DEPLOYMENT");
                Console.WriteLine();
            }

            // Then, retrieve current defaults to verify
            Console.WriteLine("=== Retrieving Current Defaults ===");
            var getResponse = await client.GetDefaultsAsync();
            ContentUnderstandingDefaults currentDefaults = getResponse.Value;

            Console.WriteLine("Current model deployment mappings:");
            if (currentDefaults.ModelDeployments != null && currentDefaults.ModelDeployments.Count > 0)
            {
                foreach (var kvp in currentDefaults.ModelDeployments)
                {
                    Console.WriteLine($"  {kvp.Key} → {kvp.Value}");
                }
            }
            else
            {
                Console.WriteLine("  No model deployments configured yet.");
                Console.WriteLine("  Run UpdateDefaults to configure model deployments.");
            }
        }
        catch (RequestFailedException ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
            Console.Error.WriteLine($"Status: {ex.Status}");
            Console.Error.WriteLine($"Error Code: {ex.ErrorCode}");
            Environment.Exit(1);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
            Environment.Exit(1);
        }
    }
}
