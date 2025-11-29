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
using NUnit.Framework;

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

            #region Assertion:ContentUnderstandingAnalyzeInvoice
            Assert.IsNotNull(invoiceUrl, "Invoice URL should not be null");
            Assert.IsTrue(invoiceUrl.IsAbsoluteUri, "Invoice URL should be absolute");
            Assert.IsNotNull(operation, "Analysis operation should not be null");
            Assert.IsTrue(operation.HasCompleted, "Operation should be completed");
            Assert.IsTrue(operation.HasValue, "Operation should have a value");
            Assert.IsNotNull(operation.GetRawResponse(), "Analysis operation should have a raw response");
            Assert.IsTrue(operation.GetRawResponse().Status >= 200 && operation.GetRawResponse().Status < 300,
                $"Response status should be successful, but was {operation.GetRawResponse().Status}");
            Console.WriteLine("✅ Analysis operation properties verified");
            Assert.IsNotNull(result, "Analysis result should not be null");
            Assert.IsNotNull(result.Contents, "Result should contain contents");
            Assert.IsTrue(result.Contents!.Count > 0, "Result should have at least one content");
            Assert.AreEqual(1, result.Contents.Count, "Invoice should have exactly one content element");
            Console.WriteLine($"✅ Analysis result contains {result.Contents.Count} content(s)");
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

            #region Assertion:ContentUnderstandingExtractInvoiceFields
            var content = result.Contents?.FirstOrDefault();
            Assert.IsNotNull(content, "Content should not be null");
            Assert.IsInstanceOf<DocumentContent>(content, "Content should be of type DocumentContent");

            if (content is DocumentContent docContent)
            {
                // Verify basic document properties
                Assert.IsTrue(docContent.StartPageNumber >= 1, "Start page should be >= 1");
                Assert.IsTrue(docContent.EndPageNumber >= docContent.StartPageNumber,
                    "End page should be >= start page");
                int totalPages = docContent.EndPageNumber - docContent.StartPageNumber + 1;
                Assert.IsTrue(totalPages > 0, "Total pages should be positive");
                Console.WriteLine($"✅ Document has {totalPages} page(s) from {docContent.StartPageNumber} to {docContent.EndPageNumber}");

                // Verify document unit
                if (docContent.Unit.HasValue)
                {
                    Console.WriteLine($"✅ Document unit: {docContent.Unit.Value}");
                }

                // Verify CustomerName field
                var customerNameField = docContent["CustomerName"];
                if (customerNameField != null)
                {
                    Console.WriteLine($"✅ CustomerName field found");

                    if (customerNameField.Value != null)
                    {
                        Assert.IsFalse(string.IsNullOrWhiteSpace(customerNameField.Value.ToString()),
                            "CustomerName value should not be empty when present");
                        Console.WriteLine($"  Value: {customerNameField.Value}");
                    }

                    if (customerNameField.Confidence.HasValue)
                    {
                        Assert.IsTrue(customerNameField.Confidence.Value >= 0 && customerNameField.Confidence.Value <= 1,
                            $"CustomerName confidence should be between 0 and 1, but was {customerNameField.Confidence.Value}");
                        Console.WriteLine($"  Confidence: {customerNameField.Confidence.Value:F2}");
                    }

                    if (!string.IsNullOrWhiteSpace(customerNameField.Source))
                    {
                        Assert.IsTrue(customerNameField.Source.StartsWith("D("),
                            "Source should start with 'D(' for document fields");
                        Console.WriteLine($"  Source: {customerNameField.Source}");
                    }

                    if (customerNameField.Spans != null && customerNameField.Spans.Count > 0)
                    {
                        Assert.IsTrue(customerNameField.Spans.Count > 0, "Spans should not be empty when not null");
                        foreach (var span in customerNameField.Spans)
                        {
                            Assert.IsTrue(span.Offset >= 0, $"Span offset should be >= 0, but was {span.Offset}");
                            Assert.IsTrue(span.Length > 0, $"Span length should be > 0, but was {span.Length}");
                        }
                        Console.WriteLine($"  Spans: {customerNameField.Spans.Count} span(s)");
                    }
                }
                else
                {
                    Console.WriteLine("⚠️ CustomerName field not found");
                }

                // Verify InvoiceDate field
                var invoiceDateField = docContent["InvoiceDate"];
                if (invoiceDateField != null)
                {
                    Console.WriteLine($"✅ InvoiceDate field found");

                    if (invoiceDateField.Value != null)
                    {
                        Assert.IsFalse(string.IsNullOrWhiteSpace(invoiceDateField.Value.ToString()),
                            "InvoiceDate value should not be empty when present");
                        Console.WriteLine($"  Value: {invoiceDateField.Value}");
                    }

                    if (invoiceDateField.Confidence.HasValue)
                    {
                        Assert.IsTrue(invoiceDateField.Confidence.Value >= 0 && invoiceDateField.Confidence.Value <= 1,
                            $"InvoiceDate confidence should be between 0 and 1, but was {invoiceDateField.Confidence.Value}");
                        Console.WriteLine($"  Confidence: {invoiceDateField.Confidence.Value:F2}");
                    }

                    if (!string.IsNullOrWhiteSpace(invoiceDateField.Source))
                    {
                        Assert.IsTrue(invoiceDateField.Source.StartsWith("D("),
                            "Source should start with 'D(' for document fields");
                        Console.WriteLine($"  Source: {invoiceDateField.Source}");
                    }

                    if (invoiceDateField.Spans != null && invoiceDateField.Spans.Count > 0)
                    {
                        Assert.IsTrue(invoiceDateField.Spans.Count > 0, "Spans should not be empty when not null");
                        foreach (var span in invoiceDateField.Spans)
                        {
                            Assert.IsTrue(span.Offset >= 0, $"Span offset should be >= 0, but was {span.Offset}");
                            Assert.IsTrue(span.Length > 0, $"Span length should be > 0, but was {span.Length}");
                        }
                        Console.WriteLine($"  Spans: {invoiceDateField.Spans.Count} span(s)");
                    }
                }
                else
                {
                    Console.WriteLine("⚠️ InvoiceDate field not found");
                }

                // Verify TotalAmount object field
                if (docContent["TotalAmount"] is ObjectField totalAmountObj)
                {
                    Console.WriteLine($"✅ TotalAmount object field found");

                    if (totalAmountObj.Confidence.HasValue)
                    {
                        Assert.IsTrue(totalAmountObj.Confidence.Value >= 0 && totalAmountObj.Confidence.Value <= 1,
                            $"TotalAmount confidence should be between 0 and 1, but was {totalAmountObj.Confidence.Value}");
                        Console.WriteLine($"  Confidence: {totalAmountObj.Confidence.Value:F2}");
                    }

                    if (!string.IsNullOrEmpty(totalAmountObj.Source))
                    {
                        Console.WriteLine($"  Source: {totalAmountObj.Source}");
                    }

                    // Verify Amount sub-field
                    var amountField = totalAmountObj["Amount"];
                    if (amountField != null)
                    {
                        Console.WriteLine($"  ✅ Amount field found");
                        if (amountField.Value is double amount)
                        {
                            Assert.IsTrue(amount >= 0, $"Amount should be >= 0, but was {amount}");
                            Console.WriteLine($"    Value: {amount:F2}");
                        }
                    }

                    // Verify CurrencyCode sub-field
                    var currencyField = totalAmountObj["CurrencyCode"];
                    if (currencyField != null)
                    {
                        Console.WriteLine($"  ✅ CurrencyCode field found");
                        if (currencyField.Value != null)
                        {
                            var currency = currencyField.Value.ToString();
                            if (!string.IsNullOrWhiteSpace(currency))
                            {
                                // 修复：先检查 null 再使用
                                Assert.AreEqual(3, currency.Length,
                                    $"CurrencyCode should be 3 characters, but was '{currency}'");
                                Console.WriteLine($"    Value: {currency}");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("⚠️ TotalAmount field not found");
                }

                // Verify LineItems array field
                if (docContent["LineItems"] is ArrayField lineItems)
                {
                    Console.WriteLine($"✅ LineItems array field found with {lineItems.Count} item(s)");
                    Assert.IsTrue(lineItems.Count >= 0, "LineItems count should be >= 0");

                    for (int i = 0; i < lineItems.Count; i++)
                    {
                        if (lineItems[i] is ObjectField item)
                        {
                            Console.WriteLine($"  ✅ Line item {i + 1}:");

                            if (item.Confidence.HasValue)
                            {
                                Assert.IsTrue(item.Confidence.Value >= 0 && item.Confidence.Value <= 1,
                                    $"Line item {i + 1} confidence should be between 0 and 1, but was {item.Confidence.Value}");
                                Console.WriteLine($"    Confidence: {item.Confidence.Value:F2}");
                            }

                            // Verify Description field
                            var descriptionField = item["Description"];
                            if (descriptionField?.Value != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(descriptionField.Value.ToString()),
                                    $"Line item {i + 1} description should not be empty when present");
                                Console.WriteLine($"    Description: {descriptionField.Value}");
                            }

                            // Verify Quantity field
                            var quantityField = item["Quantity"];
                            if (quantityField?.Value is double quantity)
                            {
                                Assert.IsTrue(quantity >= 0, $"Line item {i + 1} quantity should be >= 0, but was {quantity}");
                                Console.WriteLine($"    Quantity: {quantity}");
                            }

                            // Verify UnitPrice field if exists
                            var unitPriceField = item["UnitPrice"];
                            if (unitPriceField?.Value is double unitPrice)
                            {
                                Assert.IsTrue(unitPrice >= 0, $"Line item {i + 1} unit price should be >= 0, but was {unitPrice}");
                                Console.WriteLine($"    UnitPrice: {unitPrice:F2}");
                            }

                            // Verify Amount field if exists
                            var itemAmountField = item["Amount"];
                            if (itemAmountField?.Value is double itemAmount)
                            {
                                Assert.IsTrue(itemAmount >= 0, $"Line item {i + 1} amount should be >= 0, but was {itemAmount}");
                                Console.WriteLine($"    Amount: {itemAmount:F2}");
                            }
                        }
                        else
                        {
                            Assert.Fail($"Line item {i + 1} should be an ObjectField");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("⚠️ LineItems field not found");
                }

                Console.WriteLine("✅ All invoice fields validated successfully");
            }
            else
            {
                Assert.Fail("Content should be DocumentContent for invoice analysis");
            }
            #endregion
        }
    }
}
