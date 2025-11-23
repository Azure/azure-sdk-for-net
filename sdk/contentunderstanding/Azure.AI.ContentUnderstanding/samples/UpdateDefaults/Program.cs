// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

/// <summary>
/// This sample demonstrates how to configure default model deployment settings for Content Understanding resource.
///
/// Prerequisites:
///     - Azure subscription
///     - Azure Content Understanding resource
///     - .NET 8.0 SDK or later
///
/// Setup:
///     Set the following environment variables or add them to appsettings.json:
///     - AZURE_CONTENT_UNDERSTANDING_ENDPOINT (required)
///     - AZURE_CONTENT_UNDERSTANDING_KEY (optional - DefaultAzureCredential will be used if not set)
///     - GPT_4_1_DEPLOYMENT (required) - Your GPT-4.1 deployment name in Azure AI Foundry
///     - GPT_4_1_MINI_DEPLOYMENT (required) - Your GPT-4.1-mini deployment name in Azure AI Foundry
///     - TEXT_EMBEDDING_3_LARGE_DEPLOYMENT (required) - Your text-embedding-3-large deployment name in Azure AI Foundry
///
/// To run:
///     dotnet run
/// </summary>
class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=============================================================");
        Console.WriteLine("Azure Content Understanding Sample: Update Defaults");
        Console.WriteLine("=============================================================");
        Console.WriteLine();

        try
        {
            // Step 1: Load configuration
            Console.WriteLine("Step 1: Loading configuration...");
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
                Console.Error.WriteLine("Endpoint must be a valid absolute URI (e.g., https://your-resource.cognitiveservices.azure.com/)");
                Environment.Exit(1);
            }

            Console.WriteLine($"  Endpoint: {endpoint}");
            Console.WriteLine();

            // Step 2: Create the client with appropriate authentication
            Console.WriteLine("Step 2: Creating Content Understanding client...");
            var apiKey = configuration["AZURE_CONTENT_UNDERSTANDING_KEY"];
            ContentUnderstandingClient client;

            if (!string.IsNullOrEmpty(apiKey))
            {
                // Use API key authentication
                Console.WriteLine("  Authentication: API Key");
                client = new ContentUnderstandingClient(endpointUri, new AzureKeyCredential(apiKey));
            }
            else
            {
                // Use DefaultAzureCredential
                Console.WriteLine("  Authentication: DefaultAzureCredential");
                client = new ContentUnderstandingClient(endpointUri, new DefaultAzureCredential());
            }
            Console.WriteLine();

            await UpdateModelDeployments(client, configuration);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
            Environment.Exit(1);
        }
    }

    static async Task UpdateModelDeployments(ContentUnderstandingClient client, IConfiguration configuration)
    {
        // Step 3: Get deployment names from configuration
        Console.WriteLine("Step 3: Reading model deployment configuration...");
        var gpt41Deployment = configuration["GPT_4_1_DEPLOYMENT"] ?? string.Empty;
        var gpt41MiniDeployment = configuration["GPT_4_1_MINI_DEPLOYMENT"] ?? string.Empty;
        var textEmbedding3LargeDeployment = configuration["TEXT_EMBEDDING_3_LARGE_DEPLOYMENT"] ?? string.Empty;

        // Check if required deployments are configured
        var missingDeployments = new List<string>();
        if (string.IsNullOrEmpty(gpt41Deployment))
        {
            missingDeployments.Add("GPT_4_1_DEPLOYMENT");
        }
        if (string.IsNullOrEmpty(gpt41MiniDeployment))
        {
            missingDeployments.Add("GPT_4_1_MINI_DEPLOYMENT");
        }
        if (string.IsNullOrEmpty(textEmbedding3LargeDeployment))
        {
            missingDeployments.Add("TEXT_EMBEDDING_3_LARGE_DEPLOYMENT");
        }

        if (missingDeployments.Count > 0)
        {
            Console.WriteLine();
            Console.WriteLine("⚠️  Error: Missing required model deployment configuration(s):");
            foreach (var deployment in missingDeployments)
            {
                Console.WriteLine($"   - {deployment}");
            }
            Console.WriteLine();
            Console.WriteLine("Prebuilt analyzers require these model deployments to function correctly.");
            Console.WriteLine();
            Console.WriteLine("Please complete the following steps:");
            Console.WriteLine("1. Deploy GPT-4.1, GPT-4.1-mini, and text-embedding-3-large models in Azure AI Foundry");
            Console.WriteLine("2. Add the following to your appsettings.json or environment variables:");
            Console.WriteLine("   GPT_4_1_DEPLOYMENT=<your-gpt-4.1-deployment-name>");
            Console.WriteLine("   GPT_4_1_MINI_DEPLOYMENT=<your-gpt-4.1-mini-deployment-name>");
            Console.WriteLine("   TEXT_EMBEDDING_3_LARGE_DEPLOYMENT=<your-text-embedding-3-large-deployment-name>");
            Console.WriteLine("3. Run this sample again");
            return;
        }

        Console.WriteLine($"  GPT-4.1 deployment: {gpt41Deployment}");
        Console.WriteLine($"  GPT-4.1-mini deployment: {gpt41MiniDeployment}");
        Console.WriteLine($"  text-embedding-3-large deployment: {textEmbedding3LargeDeployment}");
        Console.WriteLine();

        try
        {
            // Step 4: Update defaults to map model names to your deployments
            Console.WriteLine("Step 4: Configuring default model deployments...");
            Console.WriteLine("  Updating model deployment mappings...");

            // Create the model deployments dictionary
            var modelDeployments = new Dictionary<string, string>
            {
                ["gpt-4.1"] = gpt41Deployment,
                ["gpt-4.1-mini"] = gpt41MiniDeployment,
                ["text-embedding-3-large"] = textEmbedding3LargeDeployment
            };

            // Create ContentUnderstandingDefaults object
            // Note: ContentUnderstandingDefaults has an internal constructor, so we need to use
            // the protocol method with RequestContent. We'll serialize the dictionary to JSON.
            var requestBody = new Dictionary<string, object>
            {
                ["modelDeployments"] = modelDeployments
            };

            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = false
            };
            var jsonString = JsonSerializer.Serialize(requestBody, jsonOptions);
            var requestContent = RequestContent.Create(BinaryData.FromString(jsonString));

            var response = await client.UpdateDefaultsAsync(requestContent);

            // Parse the response using explicit operator
            ContentUnderstandingDefaults result = (ContentUnderstandingDefaults)response;

            Console.WriteLine("Default model deployments configured successfully!");
            Console.WriteLine();
            Console.WriteLine("Model Mappings:");
            Console.WriteLine(new string('=', 60));

            // Display the configured mappings
            if (result.ModelDeployments != null && result.ModelDeployments.Count > 0)
            {
                foreach (var kvp in result.ModelDeployments)
                {
                    Console.WriteLine($"   {kvp.Key,-30} → {kvp.Value}");
                }
            }
            else
            {
                Console.WriteLine("   No model deployments returned in response");
            }

            Console.WriteLine(new string('=', 60));
            Console.WriteLine();
            Console.WriteLine("These mappings are now configured for your Content Understanding resource.");
            Console.WriteLine("   You can now use prebuilt analyzers like 'prebuilt-invoice' and 'prebuilt-receipt'.");
        }
        catch (RequestFailedException ex)
        {
            Console.WriteLine();
            Console.WriteLine($"❌ Failed to configure defaults: {ex.Message}");
            Console.WriteLine($"  Status: {ex.Status}");
            Console.WriteLine($"  Error Code: {ex.ErrorCode}");
            Console.WriteLine();
            Console.WriteLine("This error may occur if:");
            Console.WriteLine("   - One or more deployment names don't exist in your Azure AI Foundry project");
            Console.WriteLine("   - The deployments exist but use different names than specified");
            Console.WriteLine("   - You don't have permission to update defaults for this resource");
            Console.WriteLine();
            Console.WriteLine("Please verify:");
            Console.WriteLine("   1. All three models are deployed in Azure AI Foundry");
            Console.WriteLine("   2. The deployment names in your appsettings.json match exactly");
            Console.WriteLine("   3. You have the necessary permissions on the Content Understanding resource");
            throw;
        }
        catch (Exception e)
        {
            Console.WriteLine();
            Console.WriteLine($"❌ Failed to configure defaults: {e.Message}");
            Console.WriteLine($"  Type: {e.GetType().Name}");
            throw;
        }
    }
}

