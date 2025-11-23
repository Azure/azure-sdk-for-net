// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

/// <summary>
/// This sample demonstrates how to retrieve default model deployment settings for Content Understanding resource.
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
///
/// To run:
///     dotnet run
/// </summary>
class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=============================================================");
        Console.WriteLine("Azure Content Understanding Sample: Get Defaults");
        Console.WriteLine("=============================================================");
        Console.WriteLine();

        try
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var endpoint = configuration["AZURE_CONTENT_UNDERSTANDING_ENDPOINT"];
            if (string.IsNullOrEmpty(endpoint))
            {
                Console.Error.WriteLine("Error: AZURE_CONTENT_UNDERSTANDING_ENDPOINT is required.");
                Environment.Exit(1);
            }

            if (!Uri.TryCreate(endpoint.Trim(), UriKind.Absolute, out var endpointUri))
            {
                Console.Error.WriteLine($"Error: Invalid endpoint URL: {endpoint}");
                Environment.Exit(1);
            }

            var apiKey = configuration["AZURE_CONTENT_UNDERSTANDING_KEY"];
            ContentUnderstandingClient client = !string.IsNullOrEmpty(apiKey)
                ? new ContentUnderstandingClient(endpointUri, new AzureKeyCredential(apiKey))
                : new ContentUnderstandingClient(endpointUri, new DefaultAzureCredential());

            await GetDeploymentSettings(client);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
            Environment.Exit(1);
        }
    }

    static async Task GetDeploymentSettings(ContentUnderstandingClient client)
    {
        Console.WriteLine("Retrieving default model deployment settings...");

        try
        {
            var defaults = await client.GetDefaultsAsync();

            Console.WriteLine("\nSuccessfully retrieved default settings");
            Console.WriteLine("\nModel Deployment Mappings:");
            Console.WriteLine(new string('=', 60));

            if (defaults.Value.ModelDeployments != null && defaults.Value.ModelDeployments.Count > 0)
            {
                foreach (var kvp in defaults.Value.ModelDeployments)
                {
                    Console.WriteLine($"   {kvp.Key,-30} → {kvp.Value}");
                }

                Console.WriteLine(new string('=', 60));

                Console.WriteLine("\nModel Usage:");
                if (defaults.Value.ModelDeployments.ContainsKey("gpt-4.1"))
                {
                    Console.WriteLine("   • GPT-4.1: Used by most prebuilt analyzers");
                    Console.WriteLine("     (prebuilt-invoice, prebuilt-receipt, prebuilt-idDocument, etc.)");
                }

                if (defaults.Value.ModelDeployments.ContainsKey("gpt-4.1-mini"))
                {
                    Console.WriteLine("   • GPT-4.1-mini: Used by RAG analyzers");
                    Console.WriteLine("     (prebuilt-documentSearch, prebuilt-audioSearch, prebuilt-videoSearch)");
                }

                if (defaults.Value.ModelDeployments.ContainsKey("text-embedding-3-large"))
                {
                    Console.WriteLine("   • text-embedding-3-large: Used for semantic search and embeddings");
                }

                Console.WriteLine("\nYour Content Understanding resource is configured!");
                Console.WriteLine("   You can now use prebuilt analyzers that depend on these models.");
            }
            else
            {
                Console.WriteLine("   No model deployments configured");
                Console.WriteLine(new string('=', 60));
                Console.WriteLine("\n⚠️  Model deployments have not been configured yet.");
                Console.WriteLine("\n   To use prebuilt analyzers, you need to:");
                Console.WriteLine("   1. Deploy GPT-4.1, GPT-4.1-mini, and text-embedding-3-large in Azure AI Foundry");
                Console.WriteLine("   2. Run the UpdateDefaults sample to configure the mappings");
                Console.WriteLine("   3. Run this sample again to verify the configuration");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"\n❌ Error retrieving defaults: {e.Message}");
            Console.WriteLine("\nThis error may occur if:");
            Console.WriteLine("   - The Content Understanding resource is not properly configured");
            Console.WriteLine("   - You don't have permission to read resource settings");
            Console.WriteLine("   - The endpoint URL is incorrect");
            throw;
        }
    }
}

