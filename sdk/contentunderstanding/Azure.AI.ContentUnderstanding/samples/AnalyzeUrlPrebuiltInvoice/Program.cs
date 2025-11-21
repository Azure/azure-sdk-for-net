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
using Azure.Identity;
using Microsoft.Extensions.Configuration;

/// <summary>
/// This sample demonstrates how to analyze an invoice from a URL using the prebuilt-invoice analyzer.
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
/// This sample demonstrates:
/// 1. Authenticate with Azure AI Content Understanding
/// 2. Analyze an invoice from a remote URL using the prebuilt-invoice analyzer
/// 3. Save the complete analysis result to JSON file
/// 4. Show examples of extracting different field types (string, number, object, array)
/// </summary>
class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=============================================================");
        Console.WriteLine("Azure Content Understanding Sample: Prebuilt Invoice");
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

            // Step 3: Analyze invoice
            await AnalyzeInvoice(client);

            Console.WriteLine("=============================================================");
            Console.WriteLine("Sample completed successfully");
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

    static async Task AnalyzeInvoice(ContentUnderstandingClient client)
    {
        var fileUrl = "https://github.com/Azure-Samples/azure-ai-content-understanding-python/raw/refs/heads/main/data/invoice.pdf";

        Console.WriteLine("Step 3: Analyzing invoice from URL...");
        Console.WriteLine($"  URL: {fileUrl}");
        Console.WriteLine($"  Analyzer: prebuilt-invoice");
        Console.WriteLine($"  Analyzing...");

        AnalyzeResult result;
        try
        {
            var operation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-invoice",
                inputs: new[] { new AnalyzeInput { Url = new Uri(fileUrl) } });

            result = operation.Value;
            Console.WriteLine("  Analysis completed successfully");
            Console.WriteLine();
        }
        catch (RequestFailedException ex)
        {
            Console.Error.WriteLine($"  Failed to analyze invoice: {ex.Message}");
            Console.Error.WriteLine($"  Status: {ex.Status}, Error Code: {ex.ErrorCode}");
            throw;
        }

        Console.WriteLine("Step 4: Displaying invoice field extractions...");
        Console.WriteLine("=============================================================");

        // A PDF file has only one content element even if it contains multiple pages
        if (result.Contents == null || result.Contents.Count == 0)
        {
            Console.WriteLine("(No content returned from analysis)");
            return;
        }

        var content = result.Contents.First();

        // Detailed examples using the new Value property
        if (content is DocumentContent documentContent && documentContent.Fields != null)
        {
            Console.WriteLine();
            Console.WriteLine("Sample Field Extractions (Using Value Property):");
            Console.WriteLine("-".PadRight(40, '-'));

            // Example 1: Simple value fields (StringField, NumberField, DateField, etc.)
            Console.WriteLine();
            Console.WriteLine("Simple Value Fields:");
            // CustomerName is a StringField
            var customerNameField = documentContent["CustomerName"];

            if (customerNameField != null)
            {
                var customerName = customerNameField.Value?.ToString();
                Console.WriteLine($"  Customer Name: {customerName ?? "(None)"}");
                if (customerNameField.Confidence is float conf)
                    Console.WriteLine($"    Confidence: {conf:P2}");
                if (!string.IsNullOrEmpty(customerNameField.Source))
                    Console.WriteLine($"    Source: {customerNameField.Source}");
            }

            // InvoiceDate is a DateField
            var invoiceDateField = documentContent["InvoiceDate"];
            if (invoiceDateField != null)
            {
                var invoiceDate = invoiceDateField.Value?.ToString();
                Console.WriteLine($"  Invoice Date: {invoiceDate ?? "(None)"}");
                if (invoiceDateField.Confidence is float conf)
                    Console.WriteLine($"    Confidence: {conf:P2}");
                if (!string.IsNullOrEmpty(invoiceDateField.Source))
                    Console.WriteLine($"    Source: {invoiceDateField.Source}");
            }

            // Example 2: Object fields (nested structures)
            Console.WriteLine();
            Console.WriteLine("Object Fields (Nested Structures):");
            // TotalAmount is an ObjectField containing nested fields (Amount: NumberField, CurrencyCode: StringField)
            // Using the Value property for nested object access
            if (documentContent["TotalAmount"] is ObjectField totalAmountObj)
            {
                // Access nested fields using the Value property
                // Amount is a NumberField (Value returns double?)
                var amountField = totalAmountObj["Amount"];
                var amount = amountField?.Value as double?;
                // CurrencyCode is a StringField (Value returns string)
                var currencyField = totalAmountObj["CurrencyCode"];
                var currency = currencyField?.Value?.ToString();

                Console.WriteLine($"  TotalAmount (ObjectField):");
                if (amountField != null)
                {
                    Console.WriteLine($"    Amount: {amount?.ToString("F2") ?? "(None)"}");
                    if (amountField.Confidence is float amountConf)
                        Console.WriteLine($"      Confidence: {amountConf:P2}");
                }
                if (currencyField != null)
                {
                    Console.WriteLine($"    CurrencyCode: {currency ?? "(None)"}");
                    if (currencyField.Confidence is float currencyConf)
                        Console.WriteLine($"      Confidence: {currencyConf:P2}");
                }
                Console.WriteLine($"  Combined: {currency ?? "$"}{amount?.ToString("F2") ?? "(None)"}");
                if (totalAmountObj.Confidence is float totalConf)
                    Console.WriteLine($"    Object Confidence: {totalConf:P2}");
            }
            else
            {
                Console.WriteLine($"  Invoice Total: (Not found)");
            }

            // Example 3: Array fields (collections)
            Console.WriteLine();
            Console.WriteLine("Array Fields (Collections):");
            // LineItems is an ArrayField containing ObjectField items
            Console.WriteLine("Invoice Line Items:");
            if (documentContent["LineItems"] is ArrayField arrayField)
            {
                if (arrayField.Count > 0)
                {
                    for (int i = 0; i < arrayField.Count; i++)
                    {
                        var item = arrayField[i];
                        if (item is ObjectField objectField && objectField.Value != null)
                        {
                            Console.WriteLine($"  Item {i + 1}:");

                            // Extract common item fields using the Value property
                            // Description is a StringField (Value returns string)
                            var description = objectField["Description"]?.Value?.ToString();
                            // Quantity is a NumberField (Value returns double?)
                            var quantity = objectField["Quantity"]?.Value as double?;

                            Console.WriteLine($"    Description: {description ?? "N/A"}");
                            Console.WriteLine($"    Quantity: {quantity?.ToString() ?? "N/A"}");

                            // UnitPrice is an ObjectField containing Amount (NumberField) and CurrencyCode (StringField)
                            // Using the Value property for nested access
                            if (objectField["UnitPrice"] is ObjectField unitPriceObj)
                            {
                                // Amount is a NumberField (Value returns double?)
                                var unitAmount = unitPriceObj["Amount"]?.Value as double?;
                                // CurrencyCode is a StringField (Value returns string)
                                var unitCurrency = unitPriceObj["CurrencyCode"]?.Value?.ToString();
                                Console.WriteLine($"    Unit Price: {unitCurrency ?? "$"}{unitAmount?.ToString("F2") ?? "N/A"}");
                            }

                            // Amount is an ObjectField containing Amount (NumberField) and CurrencyCode (StringField)
                            if (objectField["Amount"] is ObjectField amountObj)
                            {
                                // Amount is a NumberField (Value returns double?)
                                var itemAmount = amountObj["Amount"]?.Value as double?;
                                // CurrencyCode is a StringField (Value returns string)
                                var itemCurrency = amountObj["CurrencyCode"]?.Value?.ToString();
                                Console.WriteLine($"    Total Price: {itemCurrency ?? "$"}{itemAmount?.ToString("F2") ?? "N/A"}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"  Item {i + 1}: No item object found");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("  No items found");
                }
            }
            else
            {
                Console.WriteLine("  No items found");
            }

            Console.WriteLine();
            Console.WriteLine($"Total fields extracted: {documentContent.Fields.Count}");
        }

        // Save the full result to JSON for detailed inspection
        Console.WriteLine();
        Console.WriteLine("Step 5: Saving analysis result to JSON...");
        SaveResultToJson(result, "content_analyzers_analyze_url_prebuilt_invoice");
        Console.WriteLine("Invoice fields saved to JSON file for detailed inspection");
        Console.WriteLine();
    }

    /// <summary>
    /// Save the analysis result to a JSON file.
    /// </summary>
    static void SaveResultToJson(AnalyzeResult result, string filenamePrefix)
    {
        string outputDir = "sample_output";
        Directory.CreateDirectory(outputDir);

        string timestamp = DateTime.UtcNow.ToString("yyyyMMdd_HHmmss");
        string filename = $"{filenamePrefix}_{timestamp}.json";
        string outputPath = Path.Combine(outputDir, filename);

        // Serialize using System.Text.Json with indentation
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        };

        // Convert to JSON - note: this requires the model to support serialization
        // For now, we'll serialize the raw BinaryData representation
        string json = JsonSerializer.Serialize(result, options);
        File.WriteAllText(outputPath, json);

        Console.WriteLine($"  Analysis result saved to: {outputPath}");
    }
}

