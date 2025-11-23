// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.AI.ContentUnderstanding.Tests;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.AI.ContentUnderstanding.Samples
{
    public partial class ContentUnderstandingSamples
    {
        [RecordedTest]
        public async Task AnalyzeInvoiceAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            #region Snippet:ContentUnderstandingAnalyzeInvoice
#if SNIPPET
            Uri invoiceUrl = new Uri("<invoiceUrl>");
#else
            Uri invoiceUrl = ContentUnderstandingClientTestEnvironment.CreateUri("invoice.pdf");
#endif
            Operation<AnalyzeResult> operation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-invoice",
                inputs: new[] { new AnalyzeInput { Url = invoiceUrl } });

            AnalyzeResult result = operation.Value;
            #endregion

            #region Snippet:ContentUnderstandingExtractInvoiceFields
            // Get the document content (invoices are documents)
            if (result.Contents?.FirstOrDefault() is DocumentContent documentContent)
            {
                // Print document unit information
                // The unit indicates the measurement system used for coordinates in the source field
                Console.WriteLine($"Document unit: {documentContent.Unit ?? "unknown"}");
                Console.WriteLine($"Pages: {documentContent.StartPageNumber} to {documentContent.EndPageNumber}");
                Console.WriteLine();

                // Extract simple string fields
                var customerNameField = documentContent["CustomerName"];
                var invoiceDateField = documentContent["InvoiceDate"];

                var customerName = customerNameField?.Value?.ToString();
                var invoiceDate = invoiceDateField?.Value?.ToString();

                Console.WriteLine($"Customer Name: {customerName ?? "(None)"}");
                if (customerNameField != null)
                {
                    Console.WriteLine($"  Confidence: {customerNameField.Confidence?.ToString("F2") ?? "N/A"}");
                    // Source is an encoded identifier containing bounding box coordinates
                    // Format: D(pageNumber, x1, y1, x2, y2, x3, y3, x4, y4)
                    // Coordinates are in the document's unit (e.g., inches for US documents)
                    Console.WriteLine($"  Source: {customerNameField.Source ?? "N/A"}");
                    if (customerNameField.Spans != null && customerNameField.Spans.Count > 0)
                    {
                        var span = customerNameField.Spans[0];
                        Console.WriteLine($"  Position in markdown: offset={span.Offset}, length={span.Length}");
                    }
                }

                Console.WriteLine($"Invoice Date: {invoiceDate ?? "(None)"}");
                if (invoiceDateField != null)
                {
                    Console.WriteLine($"  Confidence: {invoiceDateField.Confidence?.ToString("F2") ?? "N/A"}");
                    Console.WriteLine($"  Source: {invoiceDateField.Source ?? "N/A"}");
                    if (invoiceDateField.Spans != null && invoiceDateField.Spans.Count > 0)
                    {
                        var span = invoiceDateField.Spans[0];
                        Console.WriteLine($"  Position in markdown: offset={span.Offset}, length={span.Length}");
                    }
                }

                // Extract object fields (nested structures)
                if (documentContent["TotalAmount"] is ObjectField totalAmountObj)
                {
                    var amount = totalAmountObj["Amount"]?.Value as double?;
                    var currency = totalAmountObj["CurrencyCode"]?.Value?.ToString();
                    Console.WriteLine($"Total: {currency ?? "$"}{amount?.ToString("F2") ?? "(None)"}");
                    if (totalAmountObj.Confidence.HasValue)
                    {
                        Console.WriteLine($"  Confidence: {totalAmountObj.Confidence.Value:F2}");
                    }
                    if (!string.IsNullOrEmpty(totalAmountObj.Source))
                    {
                        Console.WriteLine($"  Source: {totalAmountObj.Source}");
                    }
                }

                // Extract array fields (collections like line items)
                if (documentContent["LineItems"] is ArrayField lineItems)
                {
                    Console.WriteLine($"Line Items ({lineItems.Count}):");
                    for (int i = 0; i < lineItems.Count; i++)
                    {
                        if (lineItems[i] is ObjectField item)
                        {
                            var description = item["Description"]?.Value?.ToString();
                            var quantity = item["Quantity"]?.Value as double?;
                            Console.WriteLine($"  Item {i + 1}: {description ?? "N/A"} (Qty: {quantity?.ToString() ?? "N/A"})");
                            if (item.Confidence.HasValue)
                            {
                                Console.WriteLine($"    Confidence: {item.Confidence.Value:F2}");
                            }
                        }
                    }
                }
            }
            #endregion
        }
    }
}
