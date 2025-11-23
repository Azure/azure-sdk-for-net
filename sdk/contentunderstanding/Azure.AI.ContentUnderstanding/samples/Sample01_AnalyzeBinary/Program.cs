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
/// This sample demonstrates how to analyze a PDF file from disk using the prebuilt-documentSearch analyzer.
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
        BinaryData bytesSource = BinaryData.FromBytes(fileBytes);
        Operation<AnalyzeResult> operation = await client.AnalyzeBinaryAsync(
            WaitUntil.Completed,
            "prebuilt-documentSearch",
            "application/pdf",
            bytesSource);
        AnalyzeResult result = operation.Value;

        // A PDF file has only one content element even if it contains multiple pages
        MediaContent? content = null;
        if (result.Contents == null || result.Contents.Count == 0)
        {
            Console.WriteLine("(No content returned from analysis)");
        }
        else
        {
            content = result.Contents.First();
            if (!string.IsNullOrEmpty(content.Markdown))
            {
                Console.WriteLine(content.Markdown);
            }
            else
            {
                Console.WriteLine("(No markdown content available)");
            }
        }

        // Check if this is document content to access document-specific properties
        if (content is DocumentContent documentContent)
        {
            Console.WriteLine($"Document type: {documentContent.MimeType ?? "(unknown)"}");
            Console.WriteLine($"Start page: {documentContent.StartPageNumber}");
            Console.WriteLine($"End page: {documentContent.EndPageNumber}");
            Console.WriteLine($"Total pages: {documentContent.EndPageNumber - documentContent.StartPageNumber + 1}");
            // Check for pages
            if (documentContent.Pages != null && documentContent.Pages.Count > 0)
            {
                Console.WriteLine($"Number of pages: {documentContent.Pages.Count}");
                foreach (var page in documentContent.Pages)
                {
                    var unit = documentContent.Unit?.ToString() ?? "units";
                    Console.WriteLine($"  Page {page.PageNumber}: {page.Width} x {page.Height} {unit}");
                }
            }
            // Check for tables
            if (documentContent.Tables != null && documentContent.Tables.Count > 0)
            {
                Console.WriteLine($"Number of tables: {documentContent.Tables.Count}");
                int tableCounter = 1;
                foreach (var table in documentContent.Tables)
                {
                    Console.WriteLine($"  Table {tableCounter}: {table.RowCount} rows x {table.ColumnCount} columns");
                    tableCounter++;
                }
            }
        }
        // === END SNIPPET ===
    }
}
