// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

/// <summary>
/// This sample demonstrates how to delete analysis results.
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

        try
        {
            // Use a sample invoice document URL
            Uri documentUrl = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-dotnet/main/ContentUnderstanding.Common/data/invoice.pdf");

            // Step 1: Start the analysis operation
        var analyzeOperation = await client.AnalyzeAsync(
            WaitUntil.Started,
            "prebuilt-invoice",
            inputs: new[] { new AnalyzeInput { Url = documentUrl } });
        // Get the operation ID from the operation (available after Started)
        string operationId = analyzeOperation.Id;
        Console.WriteLine($"Operation ID: {operationId}");
        // Wait for completion
        await analyzeOperation.WaitForCompletionAsync();
        AnalyzeResult result = analyzeOperation.Value;
        Console.WriteLine("Analysis completed successfully!");
        // Display some sample results
        if (result.Contents?.FirstOrDefault() is DocumentContent docContent && docContent.Fields != null)
        {
            Console.WriteLine($"Total fields extracted: {docContent.Fields.Count}");
            if (docContent.Fields.TryGetValue("CustomerName", out var customerNameField) && customerNameField is StringField sf)
            {
                Console.WriteLine($"Customer Name: {sf.ValueString ?? "(not found)"}");
            }
        }
            // Step 2: Delete the analysis result
            Console.WriteLine($"Deleting analysis result (Operation ID: {operationId})...");
            await client.DeleteResultAsync(operationId);
            Console.WriteLine("Analysis result deleted successfully!");
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
