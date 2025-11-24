// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
/// This sample demonstrates how to analyze a document using the prebuilt-documentSearch analyzer.
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
        string filePath = Path.Combine(AppContext.BaseDirectory, "sample_files", "sample_invoice.pdf");
        if (!File.Exists(filePath))
        {
            Console.Error.WriteLine($"Error: Sample file not found at {filePath}");
            Console.Error.WriteLine("Please ensure the sample file is copied to the output directory.");
            Environment.Exit(1);
        }
        byte[] fileBytes = await File.ReadAllBytesAsync(filePath);
        // Use protocol method to get raw JSON response
        // Note: For production use, prefer the object model approach (AnalyzeBinaryAsync with BinaryData)
        // which returns AnalyzeResult objects that are easier to work with
        var operation = await client.AnalyzeBinaryAsync(
            WaitUntil.Completed,
            "prebuilt-documentSearch",
            "application/pdf",
            RequestContent.Create(BinaryData.FromBytes(fileBytes)));
        BinaryData responseData = operation.Value;

        // Parse the raw JSON response
        using var jsonDocument = JsonDocument.Parse(responseData);
        // Pretty-print the JSON
        string prettyJson = JsonSerializer.Serialize(
            jsonDocument.RootElement,
            new JsonSerializerOptions { WriteIndented = true });
        // Create output directory if it doesn't exist
        string outputDir = Path.Combine(AppContext.BaseDirectory, "sample_output");
        Directory.CreateDirectory(outputDir);
        // Save to file
        string outputFileName = $"analyze_result_{DateTime.UtcNow:yyyyMMdd_HHmmss}.json";
        string outputPath = Path.Combine(outputDir, outputFileName);
        await File.WriteAllTextAsync(outputPath, prettyJson);
        Console.WriteLine($"Raw JSON response saved to: {outputPath}");
        Console.WriteLine($"File size: {prettyJson.Length:N0} characters");

        // Extract key information from raw JSON
        var resultElement = jsonDocument.RootElement.GetProperty("result");
        if (resultElement.TryGetProperty("analyzerId", out var analyzerIdElement))
        {
            Console.WriteLine($"Analyzer ID: {analyzerIdElement.GetString()}");
        }
        if (resultElement.TryGetProperty("contents", out var contentsElement) &&
            contentsElement.ValueKind == JsonValueKind.Array)
        {
            Console.WriteLine($"Contents count: {contentsElement.GetArrayLength()}");
            if (contentsElement.GetArrayLength() > 0)
            {
                var firstContent = contentsElement[0];
                if (firstContent.TryGetProperty("kind", out var kindElement))
                {
                    Console.WriteLine($"Content kind: {kindElement.GetString()}");
                }
                if (firstContent.TryGetProperty("mimeType", out var mimeTypeElement))
                {
                    Console.WriteLine($"MIME type: {mimeTypeElement.GetString()}");
                }
            }
        }
        // === END SNIPPET ===
    }
}
