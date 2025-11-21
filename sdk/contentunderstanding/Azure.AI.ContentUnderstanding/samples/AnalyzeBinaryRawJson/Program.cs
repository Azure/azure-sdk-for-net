// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

/// <summary>
/// This sample demonstrates how to analyze a PDF file and save the raw JSON response.
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
///
/// IMPORTANT NOTES:
/// - The SDK returns analysis results with an object model, which is easier to navigate and retrieve
///   the desired results compared to parsing raw JSON
/// - This sample is ONLY for demonstration purposes to show how to access raw JSON responses
/// - For production use, prefer the object model approach shown in:
///   - AnalyzeUrl sample
///   - AnalyzeBinary sample
/// </summary>
class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=============================================================");
        Console.WriteLine("Azure Content Understanding Sample: Analyze Binary (Raw JSON)");
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

            // Step 4: Analyze document using protocol method to get raw response
            Console.WriteLine("Step 4: Analyzing document...");
            Console.WriteLine("  Analyzer: prebuilt-documentSearch");
            Console.WriteLine("  Using protocol method to access raw JSON response");
            Console.WriteLine("  Analyzing...");

            BinaryData responseData;
            try
            {
                // Use the protocol method to get raw response
                var operation = await client.AnalyzeBinaryAsync(
                    WaitUntil.Completed,
                    "prebuilt-documentSearch",
                    "application/pdf",
                    RequestContent.Create(BinaryData.FromBytes(pdfBytes)));

                responseData = operation.Value;
                Console.WriteLine("  Analysis completed successfully");
                Console.WriteLine();
            }
            catch (RequestFailedException ex)
            {
                Console.Error.WriteLine($"  Failed to analyze document: {ex.Message}");
                Console.Error.WriteLine($"  Status: {ex.Status}, Error Code: {ex.ErrorCode}");
                throw;
            }

            // Step 5: Parse and pretty-print the raw JSON
            Console.WriteLine("Step 5: Processing raw JSON response...");

            using var jsonDocument = JsonDocument.Parse(responseData);

            // Pretty-print the JSON
            string prettyJson = JsonSerializer.Serialize(
                jsonDocument.RootElement,
                new JsonSerializerOptions { WriteIndented = true });

            // Create output directory if it doesn't exist
            string outputDir = "sample_output";
            Directory.CreateDirectory(outputDir);

            // Save to file
            string outputFileName = $"analyze_result_{DateTime.UtcNow:yyyyMMdd_HHmmss}.json";
            string outputPath = Path.Combine(outputDir, outputFileName);
            await File.WriteAllTextAsync(outputPath, prettyJson);

            Console.WriteLine($"  Raw JSON response saved to: {outputPath}");
            Console.WriteLine($"  File size: {prettyJson.Length:N0} characters");
            Console.WriteLine();

            // Display some key information from the response
            Console.WriteLine("Step 6: Displaying key information from response...");
            var resultElement = jsonDocument.RootElement.GetProperty("result");

            if (resultElement.TryGetProperty("analyzerId", out var analyzerIdElement))
            {
                Console.WriteLine($"  Analyzer ID: {analyzerIdElement.GetString()}");
            }

            if (resultElement.TryGetProperty("contents", out var contentsElement) &&
                contentsElement.ValueKind == JsonValueKind.Array)
            {
                Console.WriteLine($"  Contents count: {contentsElement.GetArrayLength()}");

                if (contentsElement.GetArrayLength() > 0)
                {
                    var firstContent = contentsElement[0];
                    if (firstContent.TryGetProperty("kind", out var kindElement))
                    {
                        Console.WriteLine($"  Content kind: {kindElement.GetString()}");
                    }
                    if (firstContent.TryGetProperty("mimeType", out var mimeTypeElement))
                    {
                        Console.WriteLine($"  MIME type: {mimeTypeElement.GetString()}");
                    }
                }
            }
            Console.WriteLine();

            Console.WriteLine("=============================================================");
            Console.WriteLine("✓ Sample completed successfully");
            Console.WriteLine("=============================================================");
            Console.WriteLine();
            Console.WriteLine("NOTE: For easier data access, prefer using the object model");
            Console.WriteLine("      approach shown in the AnalyzeUrl and AnalyzeBinary samples");
            Console.WriteLine("      instead of parsing raw JSON manually.");
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

