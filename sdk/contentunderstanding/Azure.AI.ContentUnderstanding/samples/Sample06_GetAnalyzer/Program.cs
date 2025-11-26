// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

/// <summary>
/// This sample demonstrates how to retrieve information about analyzers, including prebuilt analyzers and custom analyzers.
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
        // Get information about a prebuilt analyzer
        var response = await client.GetAnalyzerAsync("prebuilt-documentSearch");
        ContentAnalyzer analyzer = response.Value;
        // Display full analyzer JSON
        var jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        };
        string analyzerJson = JsonSerializer.Serialize(analyzer, jsonOptions);
        Console.WriteLine("Prebuilt-documentSearch Analyzer:");
        Console.WriteLine(analyzerJson);

        // Get information about prebuilt-invoice analyzer
        var invoiceResponse = await client.GetAnalyzerAsync("prebuilt-invoice");
        ContentAnalyzer invoiceAnalyzer = invoiceResponse.Value;
        string invoiceAnalyzerJson = JsonSerializer.Serialize(invoiceAnalyzer, jsonOptions);
        Console.WriteLine("Prebuilt-invoice Analyzer:");
        Console.WriteLine(invoiceAnalyzerJson);
        Console.WriteLine();

        // Create a custom analyzer and get its information
        Console.WriteLine("Creating a custom analyzer...");
        // Generate a unique analyzer ID
        string analyzerId = $"my_custom_analyzer_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
        // Define field schema with custom fields
        var fieldSchema = new ContentFieldSchema(
            new Dictionary<string, ContentFieldDefinition>
            {
                ["company_name"] = new ContentFieldDefinition
                {
                    Type = ContentFieldType.String,
                    Method = GenerationMethod.Extract,
                    Description = "Name of the company"
                }
            })
        {
            Name = "test_schema",
            Description = "Test schema for GetAnalyzer sample"
        };
        // Create analyzer configuration
        var config = new ContentAnalyzerConfig
        {
            ReturnDetails = true
        };
        // Create the custom analyzer
        var customAnalyzer = new ContentAnalyzer
        {
            BaseAnalyzerId = "prebuilt-document",
            Description = "Test analyzer for GetAnalyzer sample",
            Config = config,
            FieldSchema = fieldSchema
        };
        customAnalyzer.Models.Add("completion", "gpt-4.1");
        // Create the analyzer
        await client.CreateAnalyzerAsync(
            WaitUntil.Completed,
            analyzerId,
            customAnalyzer);
        try
        {
            // Get information about the custom analyzer
            var customResponse = await client.GetAnalyzerAsync(analyzerId);
            ContentAnalyzer retrievedAnalyzer = customResponse.Value;
            // Display full analyzer JSON
            string customAnalyzerJson = JsonSerializer.Serialize(retrievedAnalyzer, jsonOptions);
            Console.WriteLine("Custom Analyzer:");
            Console.WriteLine(customAnalyzerJson);
            // === END SNIPPET ===
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
            Environment.Exit(1);
        }
    }
}
