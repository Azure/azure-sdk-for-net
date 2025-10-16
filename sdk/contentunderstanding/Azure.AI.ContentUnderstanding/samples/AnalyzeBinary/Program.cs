// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Core;
using Azure.Identity;
using static Azure.AI.ContentUnderstanding.Samples.SampleHelper;

namespace Azure.AI.ContentUnderstanding.Samples
{
    /// <summary>
    /// Sample: Extract content from PDF using binary file analysis API.
    ///
    /// This sample demonstrates:
    /// 1. Authenticate with Azure AI Content Understanding
    /// 2. Read a PDF file from disk
    /// 3. Analyze the document using binary content with prebuilt-documentAnalyzer
    /// 4. Print the markdown content from the analysis result
    /// </summary>
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Load configuration from appsettings.json and environment variables
            var config = LoadConfiguration();

            string? endpoint = config.Endpoint;
            if (string.IsNullOrEmpty(endpoint))
            {
                Console.WriteLine("❌ Error: AZURE_CONTENT_UNDERSTANDING_ENDPOINT is not set.");
                Console.WriteLine("Please set it in appsettings.json or as an environment variable.");
                return;
            }

            // Create client with appropriate credential
            ContentUnderstandingClient client;
            if (!string.IsNullOrEmpty(config.Key))
            {
                client = new ContentUnderstandingClient(new Uri(endpoint), new AzureKeyCredential(config.Key));
            }
            else
            {
                // Use DefaultAzureCredential for enhanced security
                client = new ContentUnderstandingClient(new Uri(endpoint), new DefaultAzureCredential());
            }

            // Read the PDF file from disk
            string filePath = Path.Combine("..", "sample_files", "sample_invoice.pdf");
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"❌ Error: Sample file not found at {filePath}");
                return;
            }

            byte[] pdfBytes = await File.ReadAllBytesAsync(filePath);
            Console.WriteLine($"🔍 Analyzing {filePath} with prebuilt-documentAnalyzer...");

            // Start the analyze operation with binary content
            BinaryData fileContent = BinaryData.FromBytes(pdfBytes);
            var analyzeOperation = await client.GetContentAnalyzersClient()
                .AnalyzeAsync(
                    waitUntil: WaitUntil.Completed,
                    analyzerId: "prebuilt-documentAnalyzer",
                    data: fileContent);

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
                    Console.WriteLine("\n📚 Document Information:");
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
                            Console.WriteLine($"  Table {tableCounter}: {table.RowCount} rows x {table.ColumnCount} columns");
                            tableCounter++;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\n📚 Document Information: Not available for this content type");
                }
            }
            else
            {
                Console.WriteLine("No content found in the analysis result.");
            }

            Console.WriteLine("\n✅ Analysis complete!");

            // Uncomment to save the full result to a JSON file
            // SaveJsonToFile(result, "analyze_binary_result");
        }
    }
}

