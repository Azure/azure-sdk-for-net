// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

/// <summary>
/// This sample demonstrates how to analyze a document with prebuilt-invoice and delete the result.
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
        Console.WriteLine("Azure Content Understanding Sample: Delete Result");
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

            await AnalyzeAndDeleteResult(client);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
            Environment.Exit(1);
        }
    }

    static async Task AnalyzeAndDeleteResult(ContentUnderstandingClient client)
    {
        var fileUrl = "https://github.com/Azure-Samples/azure-ai-content-understanding-python/raw/refs/heads/main/data/invoice.pdf";

        Console.WriteLine("Document Analysis Workflow");
        Console.WriteLine(new string('=', 60));
        Console.WriteLine($"   Document URL: {fileUrl}");
        Console.WriteLine($"   Analyzer: prebuilt-invoice");
        Console.WriteLine(new string('=', 60));

        try
        {
            // Step 1: Start the analysis operation
            Console.WriteLine($"\nStep 1: Starting document analysis...");
            var analyzeOperation = await client.AnalyzeAsync(
                WaitUntil.Started,
                "prebuilt-invoice",
                inputs: new[] { new AnalyzeInput { Url = new Uri(fileUrl) } });

            // Extract the operation ID from the operation
            var operationId = analyzeOperation.GetOperationId();
            if (string.IsNullOrEmpty(operationId))
            {
                Console.WriteLine("❌ Error: Could not extract operation ID from response");
                return;
            }

            Console.WriteLine($"Analysis operation started");
            Console.WriteLine($"   Operation ID: {operationId}");

            // Step 2: Wait for analysis to complete
            Console.WriteLine($"\nStep 2: Waiting for analysis to complete...");
            await analyzeOperation.WaitForCompletionAsync();
            var result = analyzeOperation.Value;
            Console.WriteLine($"Analysis completed successfully!");

            // Step 3: Display sample results
            Console.WriteLine($"\nStep 3: Analysis Results Summary");
            Console.WriteLine(new string('=', 60));

            if (result.Contents != null && result.Contents.Count > 0)
            {
                var content = result.Contents[0];
                if (content is DocumentContent docContent && docContent.Fields != null)
                {
                    var fieldsToShow = new[] { "CustomerName", "InvoiceId", "InvoiceDate", "TotalAmount" };
                    Console.WriteLine("   Sample Fields:");
                    foreach (var fieldName in fieldsToShow)
                    {
                        if (docContent.Fields.TryGetValue(fieldName, out var field))
                        {
                            string? displayValue = null;
                            if (field is StringField sf)
                            {
                                displayValue = sf.ValueString;
                            }
                            else if (field is NumberField nf)
                            {
                                displayValue = nf.ValueNumber?.ToString();
                            }
                            else if (field is ObjectField of && fieldName == "TotalAmount")
                            {
                                // TotalAmount is an ObjectField with Amount and CurrencyCode
                                if (of.Value != null)
                                {
                                    displayValue = of.Value.ToString();
                                }
                            }

                            if (displayValue != null)
                            {
                                Console.WriteLine($"   • {fieldName}: {displayValue}");
                            }
                        }
                    }

                    Console.WriteLine($"   Total fields extracted: {docContent.Fields.Count}");
                }
                else
                {
                    Console.WriteLine("   No fields found in analysis result");
                }
            }
            else
            {
                Console.WriteLine("   No content found in analysis result");
            }

            Console.WriteLine(new string('=', 60));

            // Step 4: Delete the analysis result
            Console.WriteLine($"\nStep 4: Deleting analysis result...");
            Console.WriteLine($"   Operation ID: {operationId}");

            await client.DeleteResultAsync(operationId);
            Console.WriteLine($"Analysis result deleted successfully!");

            Console.WriteLine("\nWhy delete results?");
            Console.WriteLine("   • Remove temporary or sensitive analysis results immediately");

            Console.WriteLine("\nNote: Deleting a result marks it for deletion.");
            Console.WriteLine("   The result data will be permanently removed and cannot be recovered.");
            Console.WriteLine("   If not deleted manually, results are automatically deleted after 24 hours.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"\n❌ Error during analysis or deletion: {e.Message}");
            Console.WriteLine("\nThis error may occur if:");
            Console.WriteLine("   - Default model deployments are not configured (run GetDefaults sample)");
            Console.WriteLine("   - The prebuilt-invoice analyzer is not available");
            Console.WriteLine("   - The document URL is not accessible");
            Console.WriteLine("   - You don't have permission to delete results");
            throw;
        }
    }
}

