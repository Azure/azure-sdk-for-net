// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

/*
 * Sample: Analyze a document from a URL using the prebuilt-documentAnalyzer
 *
 * This sample demonstrates:
 * 1. Authenticate with Azure AI Content Understanding
 * 2. Analyze a document from a remote URL using BeginAnalyzeAsync with prebuilt-documentAnalyzer
 * 3. Print the markdown content and document information from the analysis result
 *
 * Prerequisites:
 *     dotnet restore
 *
 * Environment variables:
 *     AZURE_CONTENT_UNDERSTANDING_ENDPOINT   (required)
 *     AZURE_CONTENT_UNDERSTANDING_KEY        (optional - DefaultAzureCredential will be used if not set)
 *
 *     These variables can be set in appsettings.json in the sample directory for repeated use.
 *     Please see appsettings.json.sample for an example.
 *
 * Run:
 *     dotnet run
 */

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Core;
using Azure.Identity;

namespace Azure.AI.ContentUnderstanding.Samples
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Load configuration from appsettings.json or environment variables
            var config = SampleHelper.LoadConfiguration();

            string endpoint = config.Endpoint
                ?? throw new InvalidOperationException("AZURE_CONTENT_UNDERSTANDING_ENDPOINT is required");

            // Create client with appropriate credential type
            ContentUnderstandingClient client;
            if (!string.IsNullOrEmpty(config.Key))
            {
                // Use AzureKeyCredential if key is provided
                client = new ContentUnderstandingClient(new Uri(endpoint), new AzureKeyCredential(config.Key));
            }
            else
            {
                // Use DefaultAzureCredential for enhanced security
                client = new ContentUnderstandingClient(new Uri(endpoint), new DefaultAzureCredential());
            }

            string fileUrl = "https://github.com/Azure-Samples/azure-ai-content-understanding-python/raw/refs/heads/main/data/invoice.pdf";
            Console.WriteLine($"🔍 Analyzing remote document from {fileUrl} with prebuilt-documentAnalyzer...");

            // Start the analyze operation
            var analyzeOperation = await client.GetContentAnalyzersClient()
                .AnalyzeAsync(
                    waitUntil: WaitUntil.Completed,
                    analyzerId: "prebuilt-documentAnalyzer",
                    url: new Uri(fileUrl));

            // Get the result
            AnalyzeResult result = analyzeOperation.Value;

            // Display markdown content
            Console.WriteLine("\n📄 Markdown Content:");
            Console.WriteLine("=" + new string('=', 49));

            // A PDF file has only one content element even if it contains multiple pages
            if (result.Contents.Count > 0)
            {
                var content = result.Contents[0];
                Console.WriteLine(content.Markdown);
                Console.WriteLine("=" + new string('=', 49));

                // Check if this is document content to access document-specific properties
                if (content is DocumentContent documentContent)
                {
                    Console.WriteLine($"\n📚 Document Information:");
                    Console.WriteLine($"Start page: {documentContent.StartPageNumber}");
                    Console.WriteLine($"End page: {documentContent.EndPageNumber}");
                    Console.WriteLine($"Total pages: {documentContent.EndPageNumber - documentContent.StartPageNumber + 1}");

                    // Check for pages
                    if (documentContent.Pages != null && documentContent.Pages.Count > 0)
                    {
                        Console.WriteLine($"\n📄 Pages ({documentContent.Pages.Count}):");
                        foreach (var page in documentContent.Pages)
                        {
                            string unit = documentContent.Unit?.ToString() ?? "units";
                            Console.WriteLine($"  Page {page.PageNumber}: {page.Width} x {page.Height} {unit}");
                        }
                    }

                    // Check if there are tables in the document
                    if (documentContent.Tables != null && documentContent.Tables.Count > 0)
                    {
                        Console.WriteLine($"\n📊 Tables ({documentContent.Tables.Count}):");
                        int tableCounter = 1;
                        foreach (var table in documentContent.Tables)
                        {
                            int rowCount = table.RowCount;
                            int colCount = table.ColumnCount;
                            Console.WriteLine($"  Table {tableCounter}: {rowCount} rows x {colCount} columns");
                            tableCounter++;
                            // You can use the table object model to get detailed information
                            // such as cell content, borders, spans, etc. (not shown to keep code concise)
                        }
                    }

                    // Uncomment the following line to save the response to a file for object model inspection
                    // SampleHelper.SaveJsonToFile(result, "AnalyzeUrl");
                }
            }

            Console.WriteLine("\n✅ Analysis complete!");
        }
    }
}

