// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Core;
using Azure.Identity;
using static Azure.AI.ContentUnderstanding.Samples.SampleHelper;

namespace Azure.AI.ContentUnderstanding.Samples
{
    /// <summary>
    /// Sample: Extract invoice fields from URL using prebuilt-invoice analyzer.
    ///
    /// This sample demonstrates:
    /// 1. Authenticate with Azure AI Content Understanding
    /// 2. Analyze an invoice from a remote URL using prebuilt-invoice analyzer
    /// 3. Extract and display structured invoice fields (string, number, object, array)
    /// 4. Save the complete analysis result to JSON file
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

            await AnalyzeInvoiceAsync(client);

            Console.WriteLine("\n✅ Analysis complete!");
        }

        private static async Task AnalyzeInvoiceAsync(ContentUnderstandingClient client)
        {
            string fileUrl = "https://github.com/Azure-Samples/azure-ai-content-understanding-python/raw/refs/heads/main/data/invoice.pdf";
            Console.WriteLine($"🔍 Analyzing invoice from {fileUrl} with prebuilt-invoice analyzer...");

            // Start the analyze operation with prebuilt-invoice analyzer
            var analyzeOperation = await client.GetContentAnalyzersClient()
                .AnalyzeAsync(
                    waitUntil: WaitUntil.Completed,
                    analyzerId: "prebuilt-invoice",
                    url: new Uri(fileUrl));

            // Get the result
            AnalyzeResult result = analyzeOperation.Value;

            Console.WriteLine("\n📄 Invoice Analysis Result:");
            Console.WriteLine("=" + new string('=', 49));

            // A PDF file has only one content element even if it contains multiple pages
            if (result.Contents.Count == 0)
            {
                Console.WriteLine("No content found in the analysis result.");
                return;
            }

            var content = result.Contents[0];

            if (content.Fields == null || content.Fields.Count == 0)
            {
                Console.WriteLine("No fields found in the analysis result");
                return;
            }

            Console.WriteLine("\n📋 Sample Field Extractions:");
            Console.WriteLine("-" + new string('-', 39));

            // Example 1: Simple string fields
            string? customerName = GetFieldValue(content.Fields, "CustomerName");
            string? invoiceTotal = GetFieldValue(content.Fields, "InvoiceTotal");
            string? invoiceDate = GetFieldValue(content.Fields, "InvoiceDate");

            Console.WriteLine($"Customer Name: {customerName ?? "(None)"}");
            Console.WriteLine($"Invoice Total: ${invoiceTotal ?? "(None)"}");
            Console.WriteLine($"Invoice Date: {invoiceDate ?? "(None)"}");

            // Example 2: Array field (Items)
            Console.WriteLine($"\n🛒 Invoice Items (Array):");
            if (content.Fields.TryGetValue("Items", out var itemsField) && itemsField is ArrayField arrayField)
            {
                for (int i = 0; i < arrayField.ValueArray.Count; i++)
                {
                    var item = arrayField.ValueArray[i];
                    Console.WriteLine($"  Item {i + 1}:");

                    if (item is ObjectField itemObject)
                    {
                        // Extract common item fields
                        string? description = GetFieldValue(itemObject.ValueObject, "Description");
                        string? quantity = GetFieldValue(itemObject.ValueObject, "Quantity");
                        string? unitPrice = GetFieldValue(itemObject.ValueObject, "UnitPrice");
                        string? totalPrice = GetFieldValue(itemObject.ValueObject, "TotalPrice");

                        Console.WriteLine($"    Description: {description ?? "N/A"}");
                        Console.WriteLine($"    Quantity: {quantity ?? "N/A"}");
                        Console.WriteLine($"    Unit Price: ${unitPrice ?? "N/A"}");
                        Console.WriteLine($"    Total Price: ${totalPrice ?? "N/A"}");
                    }
                    else
                    {
                        Console.WriteLine($"    No item object found");
                    }
                }
            }
            else
            {
                Console.WriteLine("  No items found");
            }

            Console.WriteLine($"\n📄 Total fields extracted: {content.Fields.Count}");

            // Save the full result to JSON for detailed inspection
            SaveJsonToFile(result, "analyze_invoice_result");
            Console.WriteLine("💾 Invoice fields saved to JSON file for detailed inspection");
        }

        /// <summary>
        /// Helper method to get a field value by name from a dictionary of fields.
        /// Returns the string representation of the field value.
        /// </summary>
        private static string? GetFieldValue(IDictionary<string, ContentField> fields, string fieldName)
        {
            if (!fields.TryGetValue(fieldName, out var field))
            {
                return null;
            }

            // Return the appropriate value based on field type
            return field switch
            {
                StringField stringField => stringField.ValueString,
                NumberField numberField => numberField.ValueNumber.ToString(),
                IntegerField integerField => integerField.ValueInteger.ToString(),
                DateField dateField => dateField.ValueDate?.ToString("d"),
                _ => null
            };
        }
    }
}

