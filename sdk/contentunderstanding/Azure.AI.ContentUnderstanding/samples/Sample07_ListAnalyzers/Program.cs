// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

/// <summary>
/// This sample demonstrates how to list all available analyzers in your Microsoft Foundry resource.
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

        // === EXTRACTED SNIPPET CODE ===
        // List all analyzers
        var analyzers = new List<ContentAnalyzer>();
        await foreach (var analyzer in client.GetAnalyzersAsync())
        {
            analyzers.Add(analyzer);
        }
        Console.WriteLine($"Found {analyzers.Count} analyzer(s)");
        // Display summary
        var prebuiltCount = analyzers.Count(a => a.AnalyzerId?.StartsWith("prebuilt-") == true);
        var customCount = analyzers.Count(a => a.AnalyzerId?.StartsWith("prebuilt-") != true);
        Console.WriteLine($"  Prebuilt analyzers: {prebuiltCount}");
        Console.WriteLine($"  Custom analyzers: {customCount}");
        // Display details for each analyzer
        foreach (var analyzer in analyzers)
        {
            Console.WriteLine($"  ID: {analyzer.AnalyzerId}");
            Console.WriteLine($"  Description: {analyzer.Description ?? "(none)"}");
            Console.WriteLine($"  Status: {analyzer.Status}");
            if (analyzer.AnalyzerId?.StartsWith("prebuilt-") == true)
            {
                Console.WriteLine("  Type: Prebuilt analyzer");
            }
            else
            {
                Console.WriteLine("  Type: Custom analyzer");
            }
        }
        // === END SNIPPET ===
    }
}
