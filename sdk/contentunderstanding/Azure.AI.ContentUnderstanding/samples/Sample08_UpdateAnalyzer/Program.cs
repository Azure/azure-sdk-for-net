// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

/// <summary>
/// This sample demonstrates how to update an existing custom analyzer, including updating its description and tags.
///
/// Prerequisites:
///     - Azure subscription
///     - Microsoft Foundry resource
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

        string analyzerId = $"my_analyzer_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

        try
        {
            // First, create an analyzer to update
            Console.WriteLine($"Creating analyzer '{analyzerId}'...");
            var initialAnalyzer = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-document",
                Description = "Initial description",
                Config = new ContentAnalyzerConfig
                {
                    ReturnDetails = true
                }
            };
            initialAnalyzer.Models.Add("completion", "gpt-4.1");
            initialAnalyzer.Tags["tag1"] = "tag1_initial_value";
            initialAnalyzer.Tags["tag2"] = "tag2_initial_value";

            await client.CreateAnalyzerAsync(
                WaitUntil.Completed,
                analyzerId,
                initialAnalyzer,
                allowReplace: true);

            Console.WriteLine($"Analyzer '{analyzerId}' created successfully.");
            Console.WriteLine();

            // First, get the current analyzer to preserve base analyzer ID
            var currentAnalyzer = await client.GetAnalyzerAsync(analyzerId);

            // Display current analyzer information
            Console.WriteLine("Current analyzer information:");
            Console.WriteLine($"  Description: {currentAnalyzer.Value.Description}");
            Console.WriteLine($"  Tags: {string.Join(", ", currentAnalyzer.Value.Tags.Select(kvp => $"{kvp.Key}={kvp.Value}"))}");
            Console.WriteLine();

            // Create an updated analyzer with new description and tags
            var updatedAnalyzer = new ContentAnalyzer
            {
                BaseAnalyzerId = currentAnalyzer.Value.BaseAnalyzerId,
                Description = "Updated description"
            };

            // Update tags (empty string removes a tag)
            updatedAnalyzer.Tags["tag1"] = "tag1_updated_value";
            updatedAnalyzer.Tags["tag2"] = "";  // Remove tag2
            updatedAnalyzer.Tags["tag3"] = "tag3_value";  // Add tag3

            // Update the analyzer
            Console.WriteLine($"Updating analyzer '{analyzerId}'...");
            await client.UpdateAnalyzerAsync(analyzerId, updatedAnalyzer);
            Console.WriteLine("Analyzer updated successfully.");
            Console.WriteLine();

            // Verify the update
            var updated = await client.GetAnalyzerAsync(analyzerId);
            Console.WriteLine("Updated analyzer information:");
            Console.WriteLine($"  Description: {updated.Value.Description}");
            Console.WriteLine($"  Tags: {string.Join(", ", updated.Value.Tags.Select(kvp => $"{kvp.Key}={kvp.Value}"))}");

            // Clean up: delete the analyzer
            Console.WriteLine($"\nCleaning up: Deleting analyzer '{analyzerId}'...");
            await client.DeleteAnalyzerAsync(analyzerId);
            Console.WriteLine($"Analyzer '{analyzerId}' deleted successfully.");
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
