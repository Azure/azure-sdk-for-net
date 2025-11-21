// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

/// <summary>
/// This sample demonstrates how to analyze a PDF file from disk using the prebuilt-documentSearch.
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
        Console.WriteLine("Azure Content Understanding Sample: Analyze Binary");
        Console.WriteLine("=============================================================");
        Console.WriteLine();

        try
        {
            // Step 1: Load configuration from multiple sources
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

            // Step 3: Read the PDF file
            Console.WriteLine("Step 3: Reading PDF file...");

            // Sample file is copied to the output directory during build
            string pdfPath = Path.Combine(AppContext.BaseDirectory, "sample_files", "sample_invoice.pdf");

            if (!File.Exists(pdfPath))
            {
                Console.Error.WriteLine($"Error: Sample file not found at {pdfPath}");
                Console.Error.WriteLine("Next step: Run 'dotnet build' to copy the sample file to the output directory.");
                Environment.Exit(1);
            }

            byte[] pdfBytes = await File.ReadAllBytesAsync(pdfPath);
            Console.WriteLine($"  File: {pdfPath}");
            Console.WriteLine($"  Size: {pdfBytes.Length:N0} bytes");
            Console.WriteLine();

            // Step 4: Analyze document
            Console.WriteLine("Step 4: Analyzing document...");
            Console.WriteLine("  Analyzer: prebuilt-documentSearch");
            Console.WriteLine("  Analyzing...");

            AnalyzeResult result;
            try
            {
                var operation = await client.AnalyzeBinaryAsync(
                    WaitUntil.Completed,
                    "prebuilt-documentSearch",
                    "application/pdf",
                    BinaryData.FromBytes(pdfBytes));

                result = operation.Value;
                Console.WriteLine("  Analysis completed successfully");
                Console.WriteLine($"  Result: AnalyzerId={result.AnalyzerId}, Contents count={result.Contents?.Count ?? 0}");
                Console.WriteLine();
            }
            catch (RequestFailedException ex)
            {
                Console.Error.WriteLine($"  Failed to analyze document: {ex.Message}");
                Console.Error.WriteLine($"  Status: {ex.Status}, Error Code: {ex.ErrorCode}");
                throw;
            }

            // Step 5: Display markdown content
            Console.WriteLine("Step 5: Displaying markdown content...");
            Console.WriteLine("=============================================================");

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

            Console.WriteLine("=============================================================");
            Console.WriteLine();

            // Step 6: Check if this is document content to access document-specific properties
            if (content is DocumentContent documentContent)
            {
                Console.WriteLine("Step 6: Displaying document information...");
                Console.WriteLine($"  Document type: {documentContent.MimeType ?? "(unknown)"}");
                Console.WriteLine($"  Start page: {documentContent.StartPageNumber}");
                Console.WriteLine($"  End page: {documentContent.EndPageNumber}");
                Console.WriteLine($"  Total pages: {documentContent.EndPageNumber - documentContent.StartPageNumber + 1}");
                Console.WriteLine();

                // Check for pages
                if (documentContent.Pages != null && documentContent.Pages.Count > 0)
                {
                    Console.WriteLine($"Step 7: Displaying page information...");
                    Console.WriteLine($"  Number of pages: {documentContent.Pages.Count}");
                    foreach (var page in documentContent.Pages)
                    {
                        var unit = documentContent.Unit?.ToString() ?? "units";
                        Console.WriteLine($"  Page {page.PageNumber}: {page.Width} x {page.Height} {unit}");
                    }
                    Console.WriteLine();
                }

                // Check for tables
                if (documentContent.Tables != null && documentContent.Tables.Count > 0)
                {
                    Console.WriteLine($"Step 8: Displaying table information...");
                    Console.WriteLine($"  Number of tables: {documentContent.Tables.Count}");
                    int tableCounter = 1;
                    foreach (var table in documentContent.Tables)
                    {
                        Console.WriteLine($"  Table {tableCounter}: {table.RowCount} rows x {table.ColumnCount} columns");
                        tableCounter++;
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Step 6: Content Information:");
                Console.WriteLine("  Not a document content type - document-specific information is not available");
                Console.WriteLine();
            }

            Console.WriteLine("=============================================================");
            Console.WriteLine("✓ Sample completed successfully");
            Console.WriteLine("=============================================================");
        }
        catch (RequestFailedException ex) when (ex.Status == 401)
        {
            Console.Error.WriteLine();
            Console.Error.WriteLine("✗ Authentication failed");
            Console.Error.WriteLine($"  Error: {ex.Message}");
            Console.Error.WriteLine("  Please check your credentials and ensure they are valid.");
            Environment.Exit(1);
        }
        catch (RequestFailedException ex)
        {
            Console.Error.WriteLine();
            Console.Error.WriteLine("✗ Service request failed");
            Console.Error.WriteLine($"  Status: {ex.Status}");
            Console.Error.WriteLine($"  Error Code: {ex.ErrorCode}");
            Console.Error.WriteLine($"  Message: {ex.Message}");
            Environment.Exit(1);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine();
            Console.Error.WriteLine("✗ An unexpected error occurred");
            Console.Error.WriteLine($"  Error: {ex.Message}");
            Console.Error.WriteLine($"  Type: {ex.GetType().Name}");
            Environment.Exit(1);
        }
    }
}

