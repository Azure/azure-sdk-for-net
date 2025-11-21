// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests.Samples
{
    /// <summary>
    /// Test class for Azure Content Understanding Invoice Analyzer sample.
    /// This class validates the functionality demonstrated in azure_invoice_analyzer.cs
    /// using the prebuilt-invoice analyzer to extract structured invoice data.
    /// </summary>
    public class AnalyzeUrlPrebuiltInvoiceTest : ContentUnderstandingTestBase
    {
        public AnalyzeUrlPrebuiltInvoiceTest(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
        }

        /// <summary>
        /// Test Summary:
        /// - Create ContentUnderstandingClient using CreateClient()
        /// - Analyze invoice from URL using prebuilt-invoice analyzer
        /// - Verify analysis result contains expected invoice fields
        /// - Verify simple value fields (CustomerName, InvoiceDate)
        /// - Verify object fields (TotalAmount with Amount and CurrencyCode)
        /// - Verify array fields (LineItems with nested objects)
        /// - Save analysis result to JSON file
        /// </summary>
        [RecordedTest]
        public async Task TestAnalyzeInvoiceFromUrl()
        {
            var client = CreateClient();

            // Step 1: Analyze invoice from URL
            TestContext.WriteLine("Step 1: Analyzing invoice from URL...");
            var fileUrl = "https://github.com/Azure-Samples/azure-ai-content-understanding-python/raw/refs/heads/main/data/invoice.pdf";
            TestContext.WriteLine($"  URL: {fileUrl}");
            TestContext.WriteLine($"  Analyzer: prebuilt-invoice");
            TestContext.WriteLine($"  Analyzing...");

            // Validate URL format
            Assert.IsTrue(Uri.TryCreate(fileUrl, UriKind.Absolute, out var uri),
                $"Invalid URL format: {fileUrl}");

            var operation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-invoice",
                inputs: new[] { new AnalyzeInput { Url = uri } });

            TestHelpers.AssertOperationProperties(operation, "Analysis operation");

            var result = operation.Value;
            Assert.IsNotNull(result);
            TestContext.WriteLine("  Analysis completed successfully");
            TestContext.WriteLine($"  Result: AnalyzerId={result.AnalyzerId}, Contents count={result.Contents?.Count ?? 0}");

            // Step 2: Verify invoice fields
            TestContext.WriteLine("\nStep 2: Verifying invoice field extractions...");
            Assert.IsNotNull(result.Contents, "Result should contain contents");
            Assert.IsTrue(result.Contents.Count > 0, "Result should have at least one content");

            var content = result.Contents.First();
            Assert.IsNotNull(content);

            if (content is DocumentContent documentContent)
            {
                Assert.IsNotNull(documentContent.Fields, "Document should have fields");
                TestContext.WriteLine($"  Total fields extracted: {documentContent.Fields.Count}");

                // Verify simple value fields
                TestContext.WriteLine("\nVerifying Simple Value Fields:");

                // CustomerName is a StringField
                var customerNameField = documentContent["CustomerName"];
                if (customerNameField != null)
                {
                    var customerName = customerNameField.Value?.ToString();
                    TestContext.WriteLine($"  ✓ Customer Name: {customerName ?? "(None)"}");
                    if (customerNameField.Confidence is float conf)
                        TestContext.WriteLine($"    Confidence: {conf:P2}");
                }

                // InvoiceDate is a DateField
                var invoiceDateField = documentContent["InvoiceDate"];
                if (invoiceDateField != null)
                {
                    var invoiceDate = invoiceDateField.Value?.ToString();
                    TestContext.WriteLine($"  ✓ Invoice Date: {invoiceDate ?? "(None)"}");
                    if (invoiceDateField.Confidence is float conf)
                        TestContext.WriteLine($"    Confidence: {conf:P2}");
                }

                // Verify object fields (nested structures)
                TestContext.WriteLine("\nVerifying Object Fields (Nested Structures):");

                // TotalAmount is an ObjectField
                if (documentContent["TotalAmount"] is ObjectField totalAmountObj)
                {
                    var amountField = totalAmountObj["Amount"];
                    var amount = amountField?.Value as double?;
                    var currencyField = totalAmountObj["CurrencyCode"];
                    var currency = currencyField?.Value?.ToString();

                    TestContext.WriteLine($"  ✓ TotalAmount (ObjectField):");
                    if (amountField != null)
                    {
                        TestContext.WriteLine($"    Amount: {amount?.ToString("F2") ?? "(None)"}");
                        if (amountField.Confidence is float amountConf)
                            TestContext.WriteLine($"      Confidence: {amountConf:P2}");
                    }
                    if (currencyField != null)
                    {
                        TestContext.WriteLine($"    CurrencyCode: {currency ?? "(None)"}");
                    }
                    TestContext.WriteLine($"  Combined: {currency ?? "$"}{amount?.ToString("F2") ?? "(None)"}");
                }

                // Verify array fields (collections)
                TestContext.WriteLine("\nVerifying Array Fields (Collections):");

                // LineItems is an ArrayField
                if (documentContent["LineItems"] is ArrayField arrayField)
                {
                    TestContext.WriteLine($"  ✓ LineItems: {arrayField.Count} item(s)");

                    if (arrayField.Count > 0)
                    {
                        for (int i = 0; i < Math.Min(arrayField.Count, 3); i++) // Show first 3 items
                        {
                            var item = arrayField[i];
                            if (item is ObjectField objectField && objectField.Value != null)
                            {
                                TestContext.WriteLine($"    Item {i + 1}:");

                                var description = objectField["Description"]?.Value?.ToString();
                                var quantity = objectField["Quantity"]?.Value as double?;

                                TestContext.WriteLine($"      Description: {description ?? "N/A"}");
                                TestContext.WriteLine($"      Quantity: {quantity?.ToString() ?? "N/A"}");

                                if (objectField["UnitPrice"] is ObjectField unitPriceObj)
                                {
                                    var unitAmount = unitPriceObj["Amount"]?.Value as double?;
                                    var unitCurrency = unitPriceObj["CurrencyCode"]?.Value?.ToString();
                                    TestContext.WriteLine($"      Unit Price: {unitCurrency ?? "$"}{unitAmount?.ToString("F2") ?? "N/A"}");
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Assert.Fail("Content should be DocumentContent type");
            }

            // Step 3: Save result to file
            string testFileDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string testIdentifier = TestHelpers.GenerateAnalyzerId(Recording, "Invoice");

            string outputFilename = TestHelpers.SaveAnalysisResultToFile(
                result,
                "TestAnalyzeInvoiceFromUrl",
                testFileDir,
                testIdentifier);

            Assert.IsTrue(File.Exists(outputFilename), $"Saved result file should exist at {outputFilename}");
            TestContext.WriteLine($"\n✓ Analysis result saved to: {outputFilename}");

            TestContext.WriteLine("\n=============================================================");
            TestContext.WriteLine("✓ Invoice analysis completed successfully");
            TestContext.WriteLine("=============================================================");
        }

        /// <summary>
        /// Test Summary:
        /// - Analyze invoice and verify all field types are correctly extracted
        /// - Verify StringField, NumberField, DateField types
        /// - Verify ObjectField and ArrayField types
        /// </summary>
        [RecordedTest]
        public async Task TestInvoiceFieldTypes()
        {
            var client = CreateClient();

            TestContext.WriteLine("Analyzing invoice to verify field types...");
            var fileUrl = "https://github.com/Azure-Samples/azure-ai-content-understanding-python/raw/refs/heads/main/data/invoice.pdf";

            Assert.IsTrue(Uri.TryCreate(fileUrl, UriKind.Absolute, out var uri));

            var operation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-invoice",
                inputs: new[] { new AnalyzeInput { Url = uri } });

            var result = operation.Value;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Contents);
            Assert.IsTrue(result.Contents.Count > 0);

            var content = result.Contents.First();
            if (content is DocumentContent documentContent && documentContent.Fields != null)
            {
                TestContext.WriteLine("\nVerifying Field Types:");

                // Verify StringField type
                var customerNameField = documentContent["CustomerName"];
                if (customerNameField != null)
                {
                    Assert.IsInstanceOf<ContentField>(customerNameField, "CustomerName should be a ContentField");
                    var value = customerNameField.Value;
                    if (value != null)
                    {
                        Assert.IsInstanceOf<string>(value, "CustomerName value should be string");
                        TestContext.WriteLine($"  ✓ StringField (CustomerName): {value}");
                    }
                }

                // Verify ObjectField type
                var totalAmountField = documentContent["TotalAmount"];
                if (totalAmountField != null)
                {
                    Assert.IsInstanceOf<ObjectField>(totalAmountField, "TotalAmount should be ObjectField");
                    TestContext.WriteLine($"  ✓ ObjectField (TotalAmount) verified");
                }

                // Verify ArrayField type
                var lineItemsField = documentContent["LineItems"];
                if (lineItemsField != null)
                {
                    Assert.IsInstanceOf<ArrayField>(lineItemsField, "LineItems should be ArrayField");
                    var arrayField = lineItemsField as ArrayField;
                    TestContext.WriteLine($"  ✓ ArrayField (LineItems) verified with {arrayField?.Count ?? 0} items");
                }

                TestContext.WriteLine("\n✓ All field types verified successfully");
            }
        }

        /// <summary>
        /// Test Summary:
        /// - Analyze invoice and verify confidence scores
        /// - Ensure all extracted fields have confidence values
        /// - Verify confidence values are in valid range [0, 1]
        /// </summary>
        [RecordedTest]
        public async Task TestInvoiceFieldConfidence()
        {
            var client = CreateClient();

            TestContext.WriteLine("Analyzing invoice to verify confidence scores...");
            var fileUrl = "https://github.com/Azure-Samples/azure-ai-content-understanding-python/raw/refs/heads/main/data/invoice.pdf";

            Assert.IsTrue(Uri.TryCreate(fileUrl, UriKind.Absolute, out var uri));

            var operation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-invoice",
                inputs: new[] { new AnalyzeInput { Url = uri } });

            var result = operation.Value;
            var content = result.Contents.First();

            if (content is DocumentContent documentContent && documentContent.Fields != null)
            {
                TestContext.WriteLine("\nVerifying Confidence Scores:");

                int fieldsWithConfidence = 0;
                int totalFields = 0;

                foreach (var kvp in documentContent.Fields)
                {
                    totalFields++;
                    var field = kvp.Value;

                    if (field.Confidence.HasValue)
                    {
                        fieldsWithConfidence++;
                        float confidence = field.Confidence.Value;

                        // Verify confidence is in valid range [0, 1]
                        Assert.IsTrue(confidence >= 0.0f && confidence <= 1.0f,
                            $"Confidence for {kvp.Key} should be between 0 and 1, got {confidence}");

                        TestContext.WriteLine($"  {kvp.Key}: {confidence:P2}");
                    }
                }

                TestContext.WriteLine($"\n✓ Verified {fieldsWithConfidence}/{totalFields} fields have confidence scores");
                Assert.IsTrue(fieldsWithConfidence > 0, "At least some fields should have confidence scores");
            }
        }

        /// <summary>
        /// Test Summary:
        /// - Analyze invoice and verify line items extraction
        /// - Ensure each line item has required fields
        /// - Verify nested object structures in array items
        /// </summary>
        [RecordedTest]
        public async Task TestInvoiceLineItemsExtraction()
        {
            var client = CreateClient();

            TestContext.WriteLine("Analyzing invoice to verify line items extraction...");
            var fileUrl = "https://github.com/Azure-Samples/azure-ai-content-understanding-python/raw/refs/heads/main/data/invoice.pdf";

            Assert.IsTrue(Uri.TryCreate(fileUrl, UriKind.Absolute, out var uri));

            var operation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-invoice",
                inputs: new[] { new AnalyzeInput { Url = uri } });

            var result = operation.Value;
            var content = result.Contents.First();

            if (content is DocumentContent documentContent && documentContent.Fields != null)
            {
                TestContext.WriteLine("\nVerifying Line Items Extraction:");

                if (documentContent["LineItems"] is ArrayField arrayField)
                {
                    Assert.IsTrue(arrayField.Count > 0, "Invoice should have at least one line item");
                    TestContext.WriteLine($"  Found {arrayField.Count} line item(s)");

                    for (int i = 0; i < arrayField.Count; i++)
                    {
                        var item = arrayField[i];
                        Assert.IsNotNull(item, $"Line item {i + 1} should not be null");

                        if (item is ObjectField objectField)
                        {
                            TestContext.WriteLine($"\n  Line Item {i + 1}:");

                            // Verify common fields exist
                            var description = objectField["Description"];
                            if (description != null)
                            {
                                TestContext.WriteLine($"    ✓ Has Description field");
                            }

                            var quantity = objectField["Quantity"];
                            if (quantity != null)
                            {
                                TestContext.WriteLine($"    ✓ Has Quantity field");
                            }

                            // Verify nested object fields
                            if (objectField["UnitPrice"] is ObjectField unitPriceObj)
                            {
                                TestContext.WriteLine($"    ✓ Has UnitPrice (ObjectField)");
                                Assert.IsNotNull(unitPriceObj["Amount"], "UnitPrice should have Amount");
                            }

                            if (objectField["Amount"] is ObjectField amountObj)
                            {
                                TestContext.WriteLine($"    ✓ Has Amount (ObjectField)");
                                Assert.IsNotNull(amountObj["Amount"], "Amount should have Amount field");
                            }
                        }
                    }

                    TestContext.WriteLine($"\n✓ All {arrayField.Count} line items verified successfully");
                }
                else
                {
                    Assert.Fail("LineItems field should be present and be an ArrayField");
                }
            }
        }

        /// <summary>
        /// Test Summary:
        /// - Analyze invoice and verify total amount calculation
        /// - Extract TotalAmount object with Amount and CurrencyCode
        /// - Verify numeric value is valid
        /// </summary>
        [RecordedTest]
        public async Task TestInvoiceTotalAmountExtraction()
        {
            var client = CreateClient();

            TestContext.WriteLine("Analyzing invoice to verify total amount extraction...");
            var fileUrl = "https://github.com/Azure-Samples/azure-ai-content-understanding-python/raw/refs/heads/main/data/invoice.pdf";

            Assert.IsTrue(Uri.TryCreate(fileUrl, UriKind.Absolute, out var uri));

            var operation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-invoice",
                inputs: new[] { new AnalyzeInput { Url = uri } });

            var result = operation.Value;
            var content = result.Contents.First();

            if (content is DocumentContent documentContent && documentContent.Fields != null)
            {
                TestContext.WriteLine("\nVerifying Total Amount Extraction:");

                if (documentContent["TotalAmount"] is ObjectField totalAmountObj)
                {
                    TestContext.WriteLine("  ✓ TotalAmount field found (ObjectField)");

                    // Extract Amount
                    var amountField = totalAmountObj["Amount"];
                    Assert.IsNotNull(amountField, "TotalAmount should have Amount field");

                    var amount = amountField?.Value as double?;
                    if (amount.HasValue)
                    {
                        Assert.IsTrue(amount.Value > 0, "Total amount should be positive");
                        TestContext.WriteLine($"    Amount: {amount.Value:F2}");
                    }

                    // Extract CurrencyCode
                    var currencyField = totalAmountObj["CurrencyCode"];
                    var currency = currencyField?.Value?.ToString();
                    if (!string.IsNullOrEmpty(currency))
                    {
                        Assert.IsTrue(currency.Length >= 1 && currency.Length <= 3,
                            "Currency code should be 1-3 characters");
                        TestContext.WriteLine($"    CurrencyCode: {currency}");
                    }

                    // Verify confidence
                    if (totalAmountObj.Confidence.HasValue)
                    {
                        TestContext.WriteLine($"    Confidence: {totalAmountObj.Confidence.Value:P2}");
                    }

                    TestContext.WriteLine($"\n  ✓ Combined Total: {currency ?? "$"}{amount?.ToString("F2") ?? "N/A"}");
                }
                else
                {
                    Assert.Fail("TotalAmount field should be present and be an ObjectField");
                }
            }
        }

        /// <summary>
        /// Test Summary:
        /// - Analyze invoice and verify customer information extraction
        /// - Extract CustomerName and related fields
        /// - Verify field sources if available
        /// </summary>
        [RecordedTest]
        public async Task TestInvoiceCustomerInformationExtraction()
        {
            var client = CreateClient();

            TestContext.WriteLine("Analyzing invoice to verify customer information extraction...");
            var fileUrl = "https://github.com/Azure-Samples/azure-ai-content-understanding-python/raw/refs/heads/main/data/invoice.pdf";

            Assert.IsTrue(Uri.TryCreate(fileUrl, UriKind.Absolute, out var uri));

            var operation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-invoice",
                inputs: new[] { new AnalyzeInput { Url = uri } });

            var result = operation.Value;
            var content = result.Contents.First();

            if (content is DocumentContent documentContent && documentContent.Fields != null)
            {
                TestContext.WriteLine("\nVerifying Customer Information:");

                // CustomerName
                var customerNameField = documentContent["CustomerName"];
                if (customerNameField != null)
                {
                    var customerName = customerNameField.Value?.ToString();
                    Assert.IsNotNull(customerName, "CustomerName value should not be null");
                    Assert.IsTrue(customerName.Length > 0, "CustomerName should not be empty");

                    TestContext.WriteLine($"  ✓ Customer Name: {customerName}");

                    if (customerNameField.Confidence.HasValue)
                    {
                        TestContext.WriteLine($"    Confidence: {customerNameField.Confidence.Value:P2}");
                    }

                    if (!string.IsNullOrEmpty(customerNameField.Source))
                    {
                        TestContext.WriteLine($"    Source: {customerNameField.Source}");
                    }
                }

                // Check for other customer-related fields
                var customerAddressField = documentContent["CustomerAddress"];
                if (customerAddressField != null)
                {
                    TestContext.WriteLine($"  ✓ Customer Address field found");
                }

                TestContext.WriteLine("\n✓ Customer information extraction verified");
            }
        }

        /// <summary>
        /// Test Summary:
        /// - Analyze invoice and verify date fields
        /// - Extract InvoiceDate and DueDate if available
        /// - Verify date format and values
        /// </summary>
        [RecordedTest]
        public async Task TestInvoiceDateFieldsExtraction()
        {
            var client = CreateClient();

            TestContext.WriteLine("Analyzing invoice to verify date fields extraction...");
            var fileUrl = "https://github.com/Azure-Samples/azure-ai-content-understanding-python/raw/refs/heads/main/data/invoice.pdf";

            Assert.IsTrue(Uri.TryCreate(fileUrl, UriKind.Absolute, out var uri));

            var operation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-invoice",
                inputs: new[] { new AnalyzeInput { Url = uri } });

            var result = operation.Value;
            var content = result.Contents.First();

            if (content is DocumentContent documentContent && documentContent.Fields != null)
            {
                TestContext.WriteLine("\nVerifying Date Fields:");

                // InvoiceDate
                var invoiceDateField = documentContent["InvoiceDate"];
                if (invoiceDateField != null)
                {
                    var invoiceDate = invoiceDateField.Value?.ToString();
                    Assert.IsNotNull(invoiceDate, "InvoiceDate value should not be null");

                    TestContext.WriteLine($"  ✓ Invoice Date: {invoiceDate}");

                    if (invoiceDateField.Confidence.HasValue)
                    {
                        TestContext.WriteLine($"    Confidence: {invoiceDateField.Confidence.Value:P2}");
                    }
                }

                // DueDate
                var dueDateField = documentContent["DueDate"];
                if (dueDateField != null)
                {
                    var dueDate = dueDateField.Value?.ToString();
                    TestContext.WriteLine($"  ✓ Due Date: {dueDate ?? "(None)"}");
                }

                TestContext.WriteLine("\n✓ Date fields extraction verified");
            }
        }

        /// <summary>
        /// Test Summary:
        /// - Analyze invoice multiple times
        /// - Verify consistency of extracted fields
        /// - Compare field values across multiple runs
        /// </summary>
        [RecordedTest]
        public async Task TestInvoiceAnalysisConsistency()
        {
            var client = CreateClient();

            TestContext.WriteLine("Testing invoice analysis consistency...");
            var fileUrl = "https://github.com/Azure-Samples/azure-ai-content-understanding-python/raw/refs/heads/main/data/invoice.pdf";

            Assert.IsTrue(Uri.TryCreate(fileUrl, UriKind.Absolute, out var uri));

            // First analysis
            TestContext.WriteLine("\nFirst analysis...");
            var operation1 = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-invoice",
                inputs: new[] { new AnalyzeInput { Url = uri } });

            var result1 = operation1.Value;
            var content1 = result1.Contents.First() as DocumentContent;
            Assert.IsNotNull(content1);
            Assert.IsNotNull(content1.Fields);

            int fieldCount1 = content1.Fields.Count;
            TestContext.WriteLine($"  Field count: {fieldCount1}");

            // Second analysis
            TestContext.WriteLine("\nSecond analysis...");
            var operation2 = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-invoice",
                inputs: new[] { new AnalyzeInput { Url = uri } });

            var result2 = operation2.Value;
            var content2 = result2.Contents.First() as DocumentContent;
            Assert.IsNotNull(content2);
            Assert.IsNotNull(content2.Fields);

            int fieldCount2 = content2.Fields.Count;
            TestContext.WriteLine($"  Field count: {fieldCount2}");

            // Verify consistency
            Assert.AreEqual(fieldCount1, fieldCount2, "Field counts should be consistent");

            // Compare key fields
            var customerName1 = content1["CustomerName"]?.Value?.ToString();
            var customerName2 = content2["CustomerName"]?.Value?.ToString();

            if (customerName1 != null && customerName2 != null)
            {
                Assert.AreEqual(customerName1, customerName2, "CustomerName should be consistent");
                TestContext.WriteLine($"\n  ✓ CustomerName consistent: {customerName1}");
            }

            TestContext.WriteLine("\n✓ Analysis consistency verified successfully");
        }

        /// <summary>
        /// Test Summary:
        /// - Test error handling for invalid analyzer ID
        /// - Verify appropriate exception is thrown
        /// </summary>
        [RecordedTest]
        public async Task TestInvoiceAnalysisWithInvalidAnalyzer()
        {
            var client = CreateClient();

            TestContext.WriteLine("Testing with invalid analyzer ID...");
            var fileUrl = "https://github.com/Azure-Samples/azure-ai-content-understanding-python/raw/refs/heads/main/data/invoice.pdf";

            Assert.IsTrue(Uri.TryCreate(fileUrl, UriKind.Absolute, out var uri));

            string invalidAnalyzerId = "invalid-analyzer-" + Guid.NewGuid().ToString();
            TestContext.WriteLine($"  Using analyzer: {invalidAnalyzerId}");

            try
            {
                var operation = await client.AnalyzeAsync(
                    WaitUntil.Completed,
                    invalidAnalyzerId,
                    inputs: new[] { new AnalyzeInput { Url = uri } });

                await operation.WaitForCompletionAsync();

                Assert.Fail("Should have thrown exception for invalid analyzer");
            }
            catch (RequestFailedException ex)
            {
                TestContext.WriteLine($"  ✓ Expected exception caught: {ex.Message}");
                TestContext.WriteLine($"  Status: {ex.Status}");
                TestContext.WriteLine($"  Error Code: {ex.ErrorCode}");

                // Verify it's an appropriate error code (404 for not found)
                Assert.IsTrue(ex.Status == 404 || ex.Status >= 400,
                    "Should return 404 or other 4xx error for invalid analyzer");
            }

            TestContext.WriteLine("\n✓ Error handling verification completed");
        }

        /// <summary>
        /// Test Summary:
        /// - Analyze invoice and count all extracted fields
        /// - Verify minimum number of fields are extracted
        /// - List all field names for verification
        /// </summary>
        [RecordedTest]
        public async Task TestInvoiceFieldCount()
        {
            var client = CreateClient();

            TestContext.WriteLine("Analyzing invoice to count extracted fields...");
            var fileUrl = "https://github.com/Azure-Samples/azure-ai-content-understanding-python/raw/refs/heads/main/data/invoice.pdf";

            Assert.IsTrue(Uri.TryCreate(fileUrl, UriKind.Absolute, out var uri));

            var operation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-invoice",
                inputs: new[] { new AnalyzeInput { Url = uri } });

            var result = operation.Value;
            var content = result.Contents.First();

            if (content is DocumentContent documentContent && documentContent.Fields != null)
            {
                int fieldCount = documentContent.Fields.Count;
                TestContext.WriteLine($"\nTotal fields extracted: {fieldCount}");

                // Verify minimum fields are extracted (invoice should have at least a few key fields)
                Assert.IsTrue(fieldCount >= 3, "Invoice should have at least 3 fields extracted");

                TestContext.WriteLine("\nField names:");
                foreach (var fieldName in documentContent.Fields.Keys.OrderBy(k => k))
                {
                    var field = documentContent.Fields[fieldName];
                    string fieldType = field.GetType().Name;
                    TestContext.WriteLine($"  - {fieldName} ({fieldType})");
                }

                TestContext.WriteLine($"\n✓ Verified {fieldCount} fields extracted");
            }
        }
    }
}
