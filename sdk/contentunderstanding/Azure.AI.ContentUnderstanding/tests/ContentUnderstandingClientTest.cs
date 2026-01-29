// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.ContentUnderstanding;
using Azure.AI.ContentUnderstanding.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    public class ContentUnderstandingClientTest : RecordedTestBase<ContentUnderstandingClientTestEnvironment>
    {
        public ContentUnderstandingClientTest(bool isAsync)
            : base(isAsync)
        {
            ContentUnderstandingTestBase.ConfigureCommonSanitizers(this);
        }

        private ContentUnderstandingClient GetClient()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            return InstrumentClient(new ContentUnderstandingClient(
                new Uri(endpoint),
                TestEnvironment.Credential,
                options));
        }

        /// <summary>
        /// Tests updating default model deployments for the Content Understanding service.
        /// Verifies that model deployments (gpt-4.1, gpt-4.1-mini, text-embedding-3-large) can be updated and are correctly persisted.
        /// Also verifies that incremental updates work correctly (updating one model preserves others).
        /// </summary>
        [RecordedTest]
        public async Task UpdateDefaultsAsync()
        {
            ContentUnderstandingClient client = GetClient();

            // Check if model deployments are configured in test environment
            string? gpt41Deployment = TestEnvironment.Gpt41Deployment;
            string? gpt41MiniDeployment = TestEnvironment.Gpt41MiniDeployment;
            string? textEmbeddingDeployment = TestEnvironment.TextEmbedding3LargeDeployment;

            if (string.IsNullOrEmpty(gpt41Deployment) || string.IsNullOrEmpty(gpt41MiniDeployment) || string.IsNullOrEmpty(textEmbeddingDeployment))
            {
                Assert.Inconclusive("Model deployments are not configured in test environment. Skipping UpdateDefaultsAsync test.");
                return;
            }

            // Step 1: Set initial defaults with all three models
            var initialModelDeployments = new Dictionary<string, string>
            {
                ["gpt-4.1"] = gpt41Deployment!,
                ["gpt-4.1-mini"] = gpt41MiniDeployment!,
                ["text-embedding-3-large"] = textEmbeddingDeployment!
            };

            Response<ContentUnderstandingDefaults> initialResponse = await client.UpdateDefaultsAsync(initialModelDeployments);

            Assert.IsNotNull(initialResponse, "Initial update response should not be null");
            Assert.IsNotNull(initialResponse.Value, "Initial updated defaults should not be null");

            ContentUnderstandingDefaults initialDefaults = initialResponse.Value;

            // Verify the initial defaults were set correctly
            Assert.IsNotNull(initialDefaults.ModelDeployments, "Initial model deployments should not be null");
            Assert.IsTrue(initialDefaults.ModelDeployments.Count >= 3, "Should have at least 3 model deployments initially");

            Assert.IsTrue(initialDefaults.ModelDeployments.ContainsKey("gpt-4.1"), "Should contain gpt-4.1 deployment");
            Assert.AreEqual(gpt41Deployment, initialDefaults.ModelDeployments["gpt-4.1"], "gpt-4.1 deployment should match");

            Assert.IsTrue(initialDefaults.ModelDeployments.ContainsKey("gpt-4.1-mini"), "Should contain gpt-4.1-mini deployment");
            Assert.AreEqual(gpt41MiniDeployment, initialDefaults.ModelDeployments["gpt-4.1-mini"], "gpt-4.1-mini deployment should match");

            Assert.IsTrue(initialDefaults.ModelDeployments.ContainsKey("text-embedding-3-large"), "Should contain text-embedding-3-large deployment");
            Assert.AreEqual(textEmbeddingDeployment, initialDefaults.ModelDeployments["text-embedding-3-large"], "text-embedding-3-large deployment should match");

            // Step 2: Verify initial state by getting defaults
            Response<ContentUnderstandingDefaults> getInitialResponse = await client.GetDefaultsAsync();
            Assert.IsNotNull(getInitialResponse.Value, "Get defaults response should not be null");
            Assert.IsNotNull(getInitialResponse.Value.ModelDeployments, "Model deployments should not be null");
            Assert.IsTrue(getInitialResponse.Value.ModelDeployments.Count >= 3, "Should have at least 3 model deployments after initial update");

            // Step 3: Perform incremental update - update only one model
            // Use a different deployment name to verify the update actually happened
            var incrementalUpdate = new Dictionary<string, string>
            {
                ["gpt-4.1"] = gpt41Deployment! // Update only gpt-4.1 (using same value, but this verifies incremental update preserves others)
            };

            Response<ContentUnderstandingDefaults> incrementalResponse = await client.UpdateDefaultsAsync(incrementalUpdate);

            Assert.IsNotNull(incrementalResponse, "Incremental update response should not be null");
            Assert.IsNotNull(incrementalResponse.Value, "Incremental updated defaults should not be null");

            ContentUnderstandingDefaults incrementalDefaults = incrementalResponse.Value;

            // Step 4: Verify incremental update - all three models should still be present
            Assert.IsNotNull(incrementalDefaults.ModelDeployments, "Incremental updated model deployments should not be null");
            Assert.AreEqual(3, incrementalDefaults.ModelDeployments.Count,
                "All three models should still be present after incremental update (verifies incremental update works)");

            // Verify gpt-4.1 was updated (or remains the same)
            Assert.IsTrue(incrementalDefaults.ModelDeployments.ContainsKey("gpt-4.1"), "Should contain gpt-4.1 deployment after incremental update");
            Assert.AreEqual(gpt41Deployment, incrementalDefaults.ModelDeployments["gpt-4.1"], "gpt-4.1 deployment should match after incremental update");

            // Verify gpt-4.1-mini was preserved (this is the key test for incremental update)
            Assert.IsTrue(incrementalDefaults.ModelDeployments.ContainsKey("gpt-4.1-mini"), "Should contain gpt-4.1-mini deployment after incremental update");
            Assert.AreEqual(gpt41MiniDeployment, incrementalDefaults.ModelDeployments["gpt-4.1-mini"],
                "gpt-4.1-mini should be preserved after incremental update (verifies incremental update works)");

            // Verify text-embedding-3-large was preserved (this is the key test for incremental update)
            Assert.IsTrue(incrementalDefaults.ModelDeployments.ContainsKey("text-embedding-3-large"), "Should contain text-embedding-3-large deployment after incremental update");
            Assert.AreEqual(textEmbeddingDeployment, incrementalDefaults.ModelDeployments["text-embedding-3-large"],
                "text-embedding-3-large should be preserved after incremental update (verifies incremental update works)");

            // Step 5: Verify by getting defaults again to ensure persistence
            Response<ContentUnderstandingDefaults> getAfterIncrementalResponse = await client.GetDefaultsAsync();
            Assert.IsNotNull(getAfterIncrementalResponse.Value, "Get defaults after incremental update response should not be null");
            Assert.IsNotNull(getAfterIncrementalResponse.Value.ModelDeployments, "Model deployments should not be null");
            Assert.AreEqual(3, getAfterIncrementalResponse.Value.ModelDeployments.Count,
                "All three models should still be present when getting defaults after incremental update");

            Assert.AreEqual(gpt41Deployment, getAfterIncrementalResponse.Value.ModelDeployments["gpt-4.1"],
                "gpt-4.1 deployment should match when getting defaults after incremental update");
            Assert.AreEqual(gpt41MiniDeployment, getAfterIncrementalResponse.Value.ModelDeployments["gpt-4.1-mini"],
                "gpt-4.1-mini should be preserved when getting defaults after incremental update");
            Assert.AreEqual(textEmbeddingDeployment, getAfterIncrementalResponse.Value.ModelDeployments["text-embedding-3-large"],
                "text-embedding-3-large should be preserved when getting defaults after incremental update");
        }

        /// <summary>
        /// Tests retrieving default model deployments from the Content Understanding service.
        /// Verifies that the returned defaults contain the expected model deployment configurations.
        /// </summary>
        [RecordedTest]
        public async Task GetDefaultsAsync()
        {
            ContentUnderstandingClient client = GetClient();

            // Load expected model values from test environment
            string? gpt41Deployment = TestEnvironment.Gpt41Deployment;
            string? gpt41MiniDeployment = TestEnvironment.Gpt41MiniDeployment;
            string? textEmbeddingDeployment = TestEnvironment.TextEmbedding3LargeDeployment;

            Response<ContentUnderstandingDefaults> response = await client.GetDefaultsAsync();

            Assert.IsNotNull(response, "Response should not be null");
            Assert.IsNotNull(response.Value, "Response value should not be null");

            ContentUnderstandingDefaults defaults = response.Value;

            // Verify defaults structure
            Assert.IsNotNull(defaults, "Defaults should not be null");

            // ModelDeployments may be null or empty if not configured
            if (defaults.ModelDeployments != null && defaults.ModelDeployments.Count > 0)
            {
                Assert.IsTrue(defaults.ModelDeployments.Count > 0, "Model deployments dictionary should not be empty if not null");

                // Verify expected keys exist if deployments are configured
                foreach (var kvp in defaults.ModelDeployments)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(kvp.Key), "Model deployment key should not be null or empty");
                    Assert.IsFalse(string.IsNullOrWhiteSpace(kvp.Value), "Model deployment value should not be null or empty");
                }

                // Verify specific model values if they are configured in test environment
                if (!string.IsNullOrEmpty(gpt41Deployment))
                {
                    Assert.IsTrue(defaults.ModelDeployments.ContainsKey("gpt-4.1"), "Should contain gpt-4.1 deployment");
                    Assert.AreEqual(gpt41Deployment, defaults.ModelDeployments["gpt-4.1"], "gpt-4.1 deployment should match test environment value");
                }

                if (!string.IsNullOrEmpty(gpt41MiniDeployment))
                {
                    Assert.IsTrue(defaults.ModelDeployments.ContainsKey("gpt-4.1-mini"), "Should contain gpt-4.1-mini deployment");
                    Assert.AreEqual(gpt41MiniDeployment, defaults.ModelDeployments["gpt-4.1-mini"], "gpt-4.1-mini deployment should match test environment value");
                }

                if (!string.IsNullOrEmpty(textEmbeddingDeployment))
                {
                    Assert.IsTrue(defaults.ModelDeployments.ContainsKey("text-embedding-3-large"), "Should contain text-embedding-3-large deployment");
                    Assert.AreEqual(textEmbeddingDeployment, defaults.ModelDeployments["text-embedding-3-large"], "text-embedding-3-large deployment should match test environment value");
                }
            }
        }

        /// <summary>
        /// Tests basic binary document analysis using the prebuilt-documentSearch analyzer.
        /// Verifies that the analysis operation completes successfully and returns content results.
        /// </summary>
        [RecordedTest]
        public async Task AnalyzeBinaryAsync_Basic()
        {
            ContentUnderstandingClient client = GetClient();

            // Get test file path
            string filePath = ContentUnderstandingClientTestEnvironment.CreatePath("sample_invoice.pdf");
            Assert.IsTrue(File.Exists(filePath), $"Sample file should exist at {filePath}");

            byte[] fileBytes = File.ReadAllBytes(filePath);
            Assert.IsTrue(fileBytes.Length > 0, "File should not be empty");

            BinaryData binaryData = BinaryData.FromBytes(fileBytes);
            Assert.IsNotNull(binaryData, "Binary data should not be null");

            // Analyze the document
            Operation<AnalyzeResult> operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                binaryData);

            // Verify operation completed successfully
            Assert.IsNotNull(operation, "Analysis operation should not be null");
            Assert.IsTrue(operation.HasCompleted, "Operation should be completed");
            Assert.IsNotNull(operation.GetRawResponse(), "Operation should have a raw response");
            Assert.IsTrue(operation.GetRawResponse().Status >= 200 && operation.GetRawResponse().Status < 300,
                $"Response status should be successful, but was {operation.GetRawResponse().Status}");

            // Verify result
            AnalyzeResult result = operation.Value;
            Assert.IsNotNull(result, "Analysis result should not be null");
            Assert.IsNotNull(result.Contents, "Result contents should not be null");
            Assert.IsTrue(result.Contents.Count > 0, "Result should contain at least one content element");
        }

        /// <summary>
        /// Tests extracting markdown content from analyzed binary documents.
        /// Verifies that markdown is successfully extracted and is non-empty.
        /// </summary>
        [RecordedTest]
        public async Task AnalyzeBinaryAsync_ExtractMarkdown()
        {
            ContentUnderstandingClient client = GetClient();

            // Get test file path
            string filePath = ContentUnderstandingClientTestEnvironment.CreatePath("sample_invoice.pdf");
            Assert.IsTrue(File.Exists(filePath), $"Sample file should exist at {filePath}");

            byte[] fileBytes = File.ReadAllBytes(filePath);
            BinaryData binaryData = BinaryData.FromBytes(fileBytes);

            // Analyze the document
            Operation<AnalyzeResult> operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                binaryData);

            AnalyzeResult result = operation.Value;

            // Verify contents exist
            Assert.IsNotNull(result.Contents, "Result should contain contents");
            Assert.IsTrue(result.Contents!.Count > 0, "Result should have at least one content");
            Assert.AreEqual(1, result.Contents.Count, "PDF file should have exactly one content element");

            // Extract markdown from first content
            MediaContent? content = result.Contents.First();
            Assert.IsNotNull(content, "Content should not be null");
            Assert.IsInstanceOf<MediaContent>(content, "Content should be of type MediaContent");

            if (content is MediaContent mediaContent)
            {
                Assert.IsNotNull(mediaContent.Markdown, "Markdown content should not be null");
                Assert.IsTrue(mediaContent.Markdown.Length > 0, "Markdown content should not be empty");
                Assert.IsFalse(string.IsNullOrWhiteSpace(mediaContent.Markdown),
                    "Markdown content should not be just whitespace");
            }
        }

        /// <summary>
        /// Tests extracting document properties from analyzed binary documents, including MIME type, page information, and table structures.
        /// Verifies page numbers, dimensions, table row/column counts, and cell indices are correctly extracted.
        /// </summary>
        [RecordedTest]
        public async Task AnalyzeBinaryAsync_DocumentProperties()
        {
            ContentUnderstandingClient client = GetClient();

            // Get test file path
            string filePath = ContentUnderstandingClientTestEnvironment.CreatePath("sample_invoice.pdf");
            Assert.IsTrue(File.Exists(filePath), $"Sample file should exist at {filePath}");

            byte[] fileBytes = File.ReadAllBytes(filePath);
            BinaryData binaryData = BinaryData.FromBytes(fileBytes);

            // Analyze the document
            Operation<AnalyzeResult> operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                binaryData);

            AnalyzeResult result = operation.Value;

            // Verify contents exist
            Assert.IsNotNull(result.Contents, "Result should contain contents");
            Assert.IsTrue(result.Contents!.Count > 0, "Result should have at least one content");

            MediaContent? content = result.Contents.First();
            Assert.IsNotNull(content, "Content should not be null for document properties validation");

            // Verify document content type and properties
            Assert.IsInstanceOf<DocumentContent>(content, "Content should be DocumentContent");
            DocumentContent docContent = (DocumentContent)content;

            // Validate MIME type
            Assert.IsNotNull(docContent.MimeType, "MIME type should not be null");
            Assert.IsFalse(string.IsNullOrWhiteSpace(docContent.MimeType), "MIME type should not be empty");
            Assert.AreEqual("application/pdf", docContent.MimeType, "MIME type should be application/pdf");

            // Validate page numbers
            Assert.IsTrue(docContent.StartPageNumber >= 1, "Start page should be >= 1");
            Assert.IsTrue(docContent.EndPageNumber >= docContent.StartPageNumber,
                "End page should be >= start page");
            int totalPages = docContent.EndPageNumber - docContent.StartPageNumber + 1;
            Assert.IsTrue(totalPages > 0, "Total pages should be positive");

            // Validate pages collection
            Assert.IsNotNull(docContent.Pages, "Pages collection should not be null");
            Assert.IsTrue(docContent.Pages.Count > 0, "Pages collection should not be empty");
            Assert.AreEqual(totalPages, docContent.Pages.Count,
                "Pages collection count should match calculated total pages");

            var pageNumbers = new HashSet<int>();

            foreach (var page in docContent.Pages)
            {
                Assert.IsNotNull(page, "Page object should not be null");
                Assert.IsTrue(page.PageNumber >= 1, "Page number should be >= 1");
                Assert.IsTrue(page.PageNumber >= docContent.StartPageNumber &&
                            page.PageNumber <= docContent.EndPageNumber,
                    $"Page number {page.PageNumber} should be within document range [{docContent.StartPageNumber}, {docContent.EndPageNumber}]");
                Assert.IsTrue(page.Width > 0, $"Page {page.PageNumber} width should be > 0, but was {page.Width}");
                Assert.IsTrue(page.Height > 0, $"Page {page.PageNumber} height should be > 0, but was {page.Height}");

                // Ensure page numbers are unique
                Assert.IsTrue(pageNumbers.Add(page.PageNumber),
                    $"Page number {page.PageNumber} appears multiple times");
            }

            // Validate tables collection
            // Expected table counts from recording: Table 1 (2 rows, 6 columns), Table 2 (4 rows, 8 columns), Table 3 (5 rows, 2 columns)
            int[] expectedRowCounts = { 2, 4, 5 };
            int[] expectedColumnCounts = { 6, 8, 2 };

            Assert.IsNotNull(docContent.Tables, "Tables collection should not be null");
            Assert.IsTrue(docContent.Tables.Count > 0, "Tables collection should not be empty");
            Assert.AreEqual(expectedRowCounts.Length, docContent.Tables.Count,
                $"Expected {expectedRowCounts.Length} tables based on recording, but found {docContent.Tables.Count}");

            int tableCounter = 0;
            foreach (var table in docContent.Tables)
            {
                Assert.IsNotNull(table, $"Table {tableCounter + 1} should not be null");

                // Verify row and column counts match expected values from recording
                Assert.IsTrue(tableCounter < expectedRowCounts.Length,
                    $"Table counter {tableCounter} should be < expected row counts length {expectedRowCounts.Length}");
                Assert.AreEqual(expectedRowCounts[tableCounter], table.RowCount,
                    $"Table {tableCounter + 1} row count should be {expectedRowCounts[tableCounter]}, but was {table.RowCount}");
                Assert.AreEqual(expectedColumnCounts[tableCounter], table.ColumnCount,
                    $"Table {tableCounter + 1} column count should be {expectedColumnCounts[tableCounter]}, but was {table.ColumnCount}");

                // Validate table cells
                Assert.IsNotNull(table.Cells, $"Table {tableCounter + 1} cells collection should not be null");
                Assert.IsTrue(table.Cells.Count > 0, $"Table {tableCounter + 1} cells collection should not be empty");

                foreach (var cell in table.Cells)
                {
                    Assert.IsNotNull(cell, "Table cell should not be null");
                    Assert.IsTrue(cell.RowIndex >= 0, $"Cell row index should be >= 0, but was {cell.RowIndex}");
                    Assert.IsTrue(cell.ColumnIndex >= 0, $"Cell column index should be >= 0, but was {cell.ColumnIndex}");

                    // RowSpan and ColumnSpan are nullable, default to 1 if null
                    int rowSpan = cell.RowSpan ?? 1;
                    int columnSpan = cell.ColumnSpan ?? 1;
                    Assert.IsTrue(rowSpan >= 1, $"Cell row span should be >= 1, but was {rowSpan}");
                    Assert.IsTrue(columnSpan >= 1, $"Cell column span should be >= 1, but was {columnSpan}");

                    // Verify cell indices are within declared table bounds
                    int cellEndRow = cell.RowIndex + rowSpan - 1;
                    int cellEndColumn = cell.ColumnIndex + columnSpan - 1;
                    Assert.IsTrue(cell.RowIndex < table.RowCount,
                        $"Cell row index {cell.RowIndex} should be < table row count {table.RowCount}");
                    Assert.IsTrue(cellEndRow < table.RowCount,
                        $"Cell end row {cellEndRow} (row {cell.RowIndex} + span {rowSpan}) should be < table row count {table.RowCount}");
                    Assert.IsTrue(cell.ColumnIndex < table.ColumnCount,
                        $"Cell column index {cell.ColumnIndex} should be < table column count {table.ColumnCount}");
                    Assert.IsTrue(cellEndColumn < table.ColumnCount,
                        $"Cell end column {cellEndColumn} (column {cell.ColumnIndex} + span {columnSpan}) should be < table column count {table.ColumnCount}");
                }

                tableCounter++;
            }
        }

        /// <summary>
        /// Tests analyzing a document from a URL using the prebuilt-documentSearch analyzer.
        /// Verifies that the analysis operation completes successfully and returns content results.
        /// </summary>
        [RecordedTest]
        public async Task AnalyzeUrlAsync()
        {
            ContentUnderstandingClient client = GetClient();

            // Get test file URI
            Uri uriSource = ContentUnderstandingClientTestEnvironment.CreateUri("invoice.pdf");
            Assert.IsNotNull(uriSource, "URI source should not be null");
            Assert.IsTrue(uriSource.IsAbsoluteUri, "URI should be absolute");

            // Analyze the document from URL
            Operation<AnalyzeResult> operation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                inputs: new[] { new AnalyzeInput { Url = uriSource } });

            // Verify operation completed successfully
            Assert.IsNotNull(operation, "Analysis operation should not be null");
            Assert.IsTrue(operation.HasCompleted, "Operation should be completed");
            Assert.IsTrue(operation.HasValue, "Operation should have a value");
            Assert.IsNotNull(operation.GetRawResponse(), "Analysis operation should have a raw response");
            Assert.IsTrue(operation.GetRawResponse().Status >= 200 && operation.GetRawResponse().Status < 300,
                $"Response status should be successful, but was {operation.GetRawResponse().Status}");

            // Verify result
            AnalyzeResult result = operation.Value;
            Assert.IsNotNull(result, "Analysis result should not be null");
            Assert.IsNotNull(result.Contents, "Result contents should not be null");
            Assert.IsTrue(result.Contents.Count > 0, "Result should contain at least one content element");
            Assert.AreEqual(1, result.Contents.Count, "PDF file should have exactly one content element");

            // Verify markdown content
            MediaContent? content = result.Contents.First();
            Assert.IsNotNull(content, "Content should not be null");
            Assert.IsInstanceOf<MediaContent>(content, "Content should be of type MediaContent");

            if (content is MediaContent mediaContent)
            {
                Assert.IsNotNull(mediaContent.Markdown, "Markdown content should not be null");
                Assert.IsTrue(mediaContent.Markdown.Length > 0, "Markdown content should not be empty");
            }
        }

        /// <summary>
        /// Tests analyzing an invoice using the prebuilt-invoice analyzer and extracting invoice fields.
        /// Verifies that invoice-specific fields (CustomerName, InvoiceDate, TotalAmount, LineItems) are extracted correctly.
        /// </summary>
        [RecordedTest]
        public async Task AnalyzeInvoiceAsync()
        {
            ContentUnderstandingClient client = GetClient();

            // Get test file URI
            Uri invoiceUrl = ContentUnderstandingClientTestEnvironment.CreateUri("invoice.pdf");
            Assert.IsNotNull(invoiceUrl, "Invoice URL should not be null");
            Assert.IsTrue(invoiceUrl.IsAbsoluteUri, "Invoice URL should be absolute");

            // Analyze the invoice
            Operation<AnalyzeResult> operation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-invoice",
                inputs: new[] { new AnalyzeInput { Url = invoiceUrl } });

            // Verify operation completed successfully
            Assert.IsNotNull(operation, "Analysis operation should not be null");
            Assert.IsTrue(operation.HasCompleted, "Operation should be completed");
            Assert.IsTrue(operation.HasValue, "Operation should have a value");
            Assert.IsNotNull(operation.GetRawResponse(), "Analysis operation should have a raw response");
            Assert.IsTrue(operation.GetRawResponse().Status >= 200 && operation.GetRawResponse().Status < 300,
                $"Response status should be successful, but was {operation.GetRawResponse().Status}");

            // Verify result
            AnalyzeResult result = operation.Value;
            Assert.IsNotNull(result, "Analysis result should not be null");
            Assert.IsNotNull(result.Contents, "Result should contain contents");
            Assert.IsTrue(result.Contents!.Count > 0, "Result should have at least one content");
            Assert.AreEqual(1, result.Contents.Count, "Invoice should have exactly one content element");

            // Verify document content
            var content = result.Contents?.FirstOrDefault();
            Assert.IsNotNull(content, "Content should not be null");
            Assert.IsInstanceOf<DocumentContent>(content, "Content should be of type DocumentContent");

            if (content is DocumentContent docContent)
            {
                // Verify basic document properties
                Assert.IsTrue(docContent.StartPageNumber >= 1, "Start page should be >= 1");
                Assert.IsTrue(docContent.EndPageNumber >= docContent.StartPageNumber,
                    "End page should be >= start page");

                // Verify invoice fields exist (at least one should be present)
                bool hasAnyField = docContent.Fields.ContainsKey("CustomerName") ||
                                   docContent.Fields.ContainsKey("InvoiceDate") ||
                                   docContent.Fields.ContainsKey("TotalAmount") ||
                                   docContent.Fields.ContainsKey("LineItems");

                Assert.IsTrue(hasAnyField, "Invoice should have at least one standard invoice field");

                // Verify CustomerName field with expected value
                // Note: LLM can return different variations, so we accept multiple possible values
                if (docContent.Fields.TryGetValue("CustomerName", out var customerNameField))
                {
                    Assert.IsTrue(customerNameField is StringField, "CustomerName should be a StringField");
                    if (customerNameField is StringField customerNameStr)
                    {
                        Assert.IsFalse(string.IsNullOrWhiteSpace(customerNameStr.ValueString),
                            "CustomerName value should not be empty");
                        // Accept multiple possible values as LLM can return different variations
                        var customerName = customerNameStr.ValueString;
                        var acceptedValues = new[] { "MICROSOFT CORPORATION", "Microsoft Corp" };
                        Assert.IsTrue(acceptedValues.Contains(customerName),
                            $"CustomerName should be one of the accepted values: {string.Join(", ", acceptedValues)}, but was '{customerName}'");
                        Assert.IsTrue(customerNameStr.Confidence.HasValue,
                            "CustomerName should have confidence value");
                        if (customerNameStr.Confidence.HasValue)
                        {
                            Assert.IsTrue(customerNameStr.Confidence.Value >= 0 && customerNameStr.Confidence.Value <= 1,
                                "CustomerName confidence should be between 0 and 1");
                        }
                    }
                }

                // Verify InvoiceDate field with expected value
                if (docContent.Fields.TryGetValue("InvoiceDate", out var invoiceDateField))
                {
                    Assert.IsTrue(invoiceDateField is DateField, "InvoiceDate should be a DateField");
                    if (invoiceDateField is DateField invoiceDate)
                    {
                        Assert.IsTrue(invoiceDate.ValueDate.HasValue,
                            "InvoiceDate should have a date value");
                        // Expected value from recording: "2019-11-15"
                        var expectedDate = new DateTime(2019, 11, 15);
                        Assert.AreEqual(expectedDate, invoiceDate.ValueDate!.Value.Date,
                            "InvoiceDate should match expected value");
                        Assert.IsTrue(invoiceDate.Confidence.HasValue,
                            "InvoiceDate should have confidence value");
                        if (invoiceDate.Confidence.HasValue)
                        {
                            Assert.IsTrue(invoiceDate.Confidence.Value >= 0 && invoiceDate.Confidence.Value <= 1,
                                "InvoiceDate confidence should be between 0 and 1");
                        }
                    }
                }

                // Verify TotalAmount field with expected value
                if (docContent.Fields.TryGetValue("TotalAmount", out var totalAmountField))
                {
                    Assert.IsTrue(totalAmountField is ObjectField, "TotalAmount should be an ObjectField");
                    if (totalAmountField is ObjectField totalAmountObj)
                    {
                        // Verify Amount sub-field - field is known to exist based on recording
                        var amountField = totalAmountObj["Amount"];  // Throws KeyNotFoundException if not found
                        Assert.IsNotNull(amountField, "TotalAmount.Amount should not be null");
                        Assert.IsTrue(amountField is NumberField, "TotalAmount.Amount should be a NumberField");
                        if (amountField is NumberField amountNum)
                        {
                            Assert.IsTrue(amountNum.ValueNumber.HasValue,
                                "TotalAmount.Amount should have a numeric value");
                            // Expected value from recording: 110
                            Assert.AreEqual(110.0, amountNum.ValueNumber!.Value,
                                "TotalAmount.Amount should match expected value");
                        }

                        // Verify CurrencyCode sub-field - field is known to exist based on recording
                        // Note: LLM can return different values or null at different runs, so we accept multiple possibilities
                        var currencyField = totalAmountObj["CurrencyCode"];  // Throws KeyNotFoundException if not found
                        Assert.IsNotNull(currencyField, "TotalAmount.CurrencyCode should not be null");
                        Assert.IsTrue(currencyField is StringField, "TotalAmount.CurrencyCode should be a StringField");
                        if (currencyField is StringField currencyStr)
                        {
                            // Accept both "USD" and null/empty as valid values since LLM may not always extract it
                            var currencyValue = currencyStr.ValueString;
                            if (!string.IsNullOrWhiteSpace(currencyValue))
                            {
                                // If value is present, it should be "USD"
                                var acceptedValues = new[] { "USD" };
                                Assert.IsTrue(acceptedValues.Contains(currencyValue),
                                    $"TotalAmount.CurrencyCode should be one of the accepted values: {string.Join(", ", acceptedValues)}, but was '{currencyValue}'");
                            }
                            // If currencyValue is null or empty, that's also acceptable as LLM may not always extract it consistently
                        }
                    }
                }

                // Verify LineItems field with expected values
                if (docContent.Fields.TryGetValue("LineItems", out var lineItemsField))
                {
                    Assert.IsTrue(lineItemsField is ArrayField, "LineItems should be an ArrayField");
                    if (lineItemsField is ArrayField lineItems)
                    {
                        // Expected count from recording: 3
                        Assert.AreEqual(3, lineItems.Count,
                            "LineItems should have expected count");

                        // Verify first line item (Consulting Services)
                        if (lineItems[0] is ObjectField item1)
                        {
                            // Fields known to exist based on recording - using indexer which throws if not found
                            var desc1 = item1["Description"];
                            Assert.IsNotNull(desc1, "Item 1 Description should not be null");
                            if (desc1 is StringField desc1Str)
                            {
                                // Expected value from recording: "Consulting Services"
                                Assert.AreEqual("Consulting Services", desc1Str.ValueString,
                                    "Item 1 Description should match expected value");
                            }

                            var qty1 = item1["Quantity"];
                            Assert.IsNotNull(qty1, "Item 1 Quantity should not be null");
                            if (qty1 is NumberField qty1Num && qty1Num.ValueNumber.HasValue)
                            {
                                // Expected value from recording: 2
                                Assert.AreEqual(2.0, qty1Num.ValueNumber.Value,
                                    "Item 1 Quantity should match expected value");
                            }

                            // UnitPrice may or may not exist - using GetFieldOrDefault for null-safe access
                            if (item1.ValueObject?.GetFieldOrDefault("UnitPrice") is ObjectField unitPrice1Obj)
                            {
                                var unitPrice1Amount = unitPrice1Obj.ValueObject?.GetFieldOrDefault("Amount");
                                if (unitPrice1Amount is NumberField unitPrice1Num && unitPrice1Num.ValueNumber.HasValue)
                                {
                                    // Expected value from recording: 30
                                    Assert.AreEqual(30.0, unitPrice1Num.ValueNumber.Value,
                                        "Item 1 UnitPrice.Amount should match expected value");
                                }
                            }
                        }

                        // Verify second line item (Document Fee)
                        if (lineItems[1] is ObjectField item2)
                        {
                            // Fields known to exist based on recording - using indexer which throws if not found
                            var desc2 = item2["Description"];
                            Assert.IsNotNull(desc2, "Item 2 Description should not be null");
                            if (desc2 is StringField desc2Str)
                            {
                                // Expected value from recording: "Document Fee"
                                Assert.AreEqual("Document Fee", desc2Str.ValueString,
                                    "Item 2 Description should match expected value");
                            }

                            var qty2 = item2["Quantity"];
                            Assert.IsNotNull(qty2, "Item 2 Quantity should not be null");
                            if (qty2 is NumberField qty2Num && qty2Num.ValueNumber.HasValue)
                            {
                                // Expected value from recording: 3
                                Assert.AreEqual(3.0, qty2Num.ValueNumber.Value,
                                    "Item 2 Quantity should match expected value");
                            }

                            // TotalAmount may or may not exist - using GetFieldOrDefault for null-safe access
                            if (item2.ValueObject?.GetFieldOrDefault("TotalAmount") is ObjectField totalAmount2Obj)
                            {
                                var totalAmount2Amount = totalAmount2Obj.ValueObject?.GetFieldOrDefault("Amount");
                                if (totalAmount2Amount is NumberField totalAmount2Num && totalAmount2Num.ValueNumber.HasValue)
                                {
                                    // Expected value from recording: 30
                                    Assert.AreEqual(30.0, totalAmount2Num.ValueNumber.Value,
                                        "Item 2 TotalAmount.Amount should match expected value");
                                }
                            }
                        }

                        // Verify third line item (Printing Fee)
                        if (lineItems[2] is ObjectField item3)
                        {
                            // Fields known to exist based on recording - using indexer which throws if not found
                            var desc3 = item3["Description"];
                            Assert.IsNotNull(desc3, "Item 3 Description should not be null");
                            if (desc3 is StringField desc3Str)
                            {
                                // Expected value from recording: "Printing Fee"
                                Assert.AreEqual("Printing Fee", desc3Str.ValueString,
                                    "Item 3 Description should match expected value");
                            }

                            var qty3 = item3["Quantity"];
                            Assert.IsNotNull(qty3, "Item 3 Quantity should not be null");
                            if (qty3 is NumberField qty3Num && qty3Num.ValueNumber.HasValue)
                            {
                                // Expected value from recording: 10
                                Assert.AreEqual(10.0, qty3Num.ValueNumber.Value,
                                    "Item 3 Quantity should match expected value");
                            }

                            // UnitPrice may or may not exist - using GetFieldOrDefault for null-safe access
                            if (item3.ValueObject?.GetFieldOrDefault("UnitPrice") is ObjectField unitPrice3Obj)
                            {
                                var unitPrice3Amount = unitPrice3Obj.ValueObject?.GetFieldOrDefault("Amount");
                                if (unitPrice3Amount is NumberField unitPrice3Num && unitPrice3Num.ValueNumber.HasValue)
                                {
                                    // Expected value from recording: 1
                                    Assert.AreEqual(1.0, unitPrice3Num.ValueNumber.Value,
                                        "Item 3 UnitPrice.Amount should match expected value");
                                }
                            }

                            // TotalAmount may or may not exist - using GetFieldOrDefault for null-safe access
                            if (item3.ValueObject?.GetFieldOrDefault("TotalAmount") is ObjectField totalAmount3Obj)
                            {
                                var totalAmount3Amount = totalAmount3Obj.ValueObject?.GetFieldOrDefault("Amount");
                                if (totalAmount3Amount is NumberField totalAmount3Num && totalAmount3Num.ValueNumber.HasValue)
                                {
                                    // Expected value from recording: 10
                                    Assert.AreEqual(10.0, totalAmount3Num.ValueNumber.Value,
                                        "Item 3 TotalAmount.Amount should match expected value");
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Assert.Fail("Content should be DocumentContent for invoice analysis");
            }
        }

        /// <summary>
        /// Tests creating a custom analyzer with field schema.
        /// Verifies that the analyzer is created successfully with the specified configuration and fields.
        /// </summary>
        [RecordedTest]
        public async Task CreateAnalyzerAsync()
        {
            ContentUnderstandingClient client = GetClient();

            // Generate a unique analyzer ID
            string defaultId = $"test_custom_analyzer_{Recording.Random.NewGuid().ToString("N")}";
            string analyzerId = Recording.GetVariable("analyzerId", defaultId) ?? defaultId;

            // Define field schema with custom fields
            var fieldSchema = new ContentFieldSchema(
                new Dictionary<string, ContentFieldDefinition>
                {
                    ["company_name"] = new ContentFieldDefinition
                    {
                        Type = ContentFieldType.String,
                        Method = GenerationMethod.Extract,
                        Description = "Name of the company"
                    },
                    ["total_amount"] = new ContentFieldDefinition
                    {
                        Type = ContentFieldType.Number,
                        Method = GenerationMethod.Extract,
                        Description = "Total amount on the document"
                    }
                })
            {
                Name = "test_schema",
                Description = "Test schema for custom analyzer"
            };

            // Create analyzer configuration
            var config = new ContentAnalyzerConfig
            {
                EnableFormula = true,
                EnableLayout = true,
                EnableOcr = true,
                ReturnDetails = true
            };

            // Create the custom analyzer
            var customAnalyzer = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-document",
                Description = "Test custom analyzer",
                Config = config,
                FieldSchema = fieldSchema
            };

            // Add model mappings (required for custom analyzers)
            customAnalyzer.Models.Add("completion", "gpt-4.1");
            customAnalyzer.Models.Add("embedding", "text-embedding-3-large");

            // Create the analyzer
            var operation = await client.CreateAnalyzerAsync(
                WaitUntil.Completed,
                analyzerId,
                customAnalyzer,
                allowReplace: true);

            // Verify operation completed successfully
            Assert.IsNotNull(operation, "Create analyzer operation should not be null");
            Assert.IsTrue(operation.HasCompleted, "Operation should be completed");
            Assert.IsTrue(operation.HasValue, "Operation should have a value");
            Assert.IsNotNull(operation.GetRawResponse(), "Create analyzer operation should have a raw response");
            Assert.IsTrue(operation.GetRawResponse().Status >= 200 && operation.GetRawResponse().Status < 300,
                $"Response status should be successful, but was {operation.GetRawResponse().Status}");

            // Verify result
            ContentAnalyzer result = operation.Value;
            Assert.IsNotNull(result, "Analyzer result should not be null");
            Assert.IsNotNull(result.BaseAnalyzerId, "Base analyzer ID should not be null");
            Assert.AreEqual("prebuilt-document", result.BaseAnalyzerId, "Base analyzer ID should match");
            Assert.IsNotNull(result.Config, "Analyzer config should not be null");
            Assert.IsNotNull(result.FieldSchema, "Field schema should not be null");
            Assert.AreEqual(2, result.FieldSchema.Fields.Count, "Should have 2 custom fields");
            Assert.IsTrue(result.FieldSchema.Fields.ContainsKey("company_name"), "Should contain company_name field");
            Assert.IsTrue(result.FieldSchema.Fields.ContainsKey("total_amount"), "Should contain total_amount field");

            // Clean up: delete the analyzer
            try
            {
                await client.DeleteAnalyzerAsync(analyzerId);
            }
            catch
            {
                // Ignore cleanup errors in tests
            }
        }

        /// <summary>
        /// Tests creating a classifier with content categories.
        /// Verifies that the classifier is created successfully with the specified categories and configuration.
        /// </summary>
        [RecordedTest]
        public async Task CreateClassifierAsync()
        {
            ContentUnderstandingClient client = GetClient();

            // Generate a unique analyzer ID
            string defaultId = $"test_classifier_{Recording.Random.NewGuid().ToString("N")}";
            string analyzerId = Recording.GetVariable("analyzerId", defaultId) ?? defaultId;

            // Define content categories for classification
            var categories = new Dictionary<string, ContentCategoryDefinition>
            {
                ["Loan_Application"] = new ContentCategoryDefinition
                {
                    Description = "Documents submitted by individuals or businesses to request funding"
                },
                ["Invoice"] = new ContentCategoryDefinition
                {
                    Description = "Billing documents issued by sellers or service providers to request payment"
                },
                ["Bank_Statement"] = new ContentCategoryDefinition
                {
                    Description = "Official statements issued by banks that summarize account activity"
                }
            };

            // Create analyzer configuration
            var config = new ContentAnalyzerConfig
            {
                ReturnDetails = true,
                EnableSegment = true
            };

            // Add categories to config
            foreach (var kvp in categories)
            {
                config.ContentCategories.Add(kvp.Key, kvp.Value);
            }

            // Create the classifier analyzer
            var classifier = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-document",
                Description = "Custom classifier for financial document categorization",
                Config = config
            };
            classifier.Models.Add("completion", "gpt-4.1");

            // Create the classifier
            var operation = await client.CreateAnalyzerAsync(
                WaitUntil.Completed,
                analyzerId,
                classifier);

            // Verify operation completed successfully
            Assert.IsNotNull(operation, "Create classifier operation should not be null");
            Assert.IsTrue(operation.HasCompleted, "Operation should be completed");
            Assert.IsTrue(operation.HasValue, "Operation should have a value");
            Assert.IsNotNull(operation.GetRawResponse(), "Create classifier operation should have a raw response");
            Assert.IsTrue(operation.GetRawResponse().Status >= 200 && operation.GetRawResponse().Status < 300,
                $"Response status should be successful, but was {operation.GetRawResponse().Status}");

            // Verify result
            ContentAnalyzer result = operation.Value;
            Assert.IsNotNull(result, "Classifier result should not be null");
            Assert.IsNotNull(result.BaseAnalyzerId, "Base analyzer ID should not be null");
            Assert.AreEqual("prebuilt-document", result.BaseAnalyzerId, "Base analyzer ID should match");
            Assert.IsNotNull(result.Config, "Classifier config should not be null");
            Assert.IsNotNull(result.Config.ContentCategories, "Content categories should not be null");
            Assert.AreEqual(3, result.Config.ContentCategories.Count, "Should have 3 content categories");
            Assert.IsTrue(result.Config.ContentCategories.ContainsKey("Loan_Application"), "Should contain Loan_Application category");
            Assert.IsTrue(result.Config.ContentCategories.ContainsKey("Invoice"), "Should contain Invoice category");
            Assert.IsTrue(result.Config.ContentCategories.ContainsKey("Bank_Statement"), "Should contain Bank_Statement category");

            try
            {
                // Analyze mixed financial document with segmentation enabled
                string filePath = ContentUnderstandingClientTestEnvironment.CreatePath("mixed_financial_docs.pdf");
                Assert.IsTrue(File.Exists(filePath), $"Sample file should exist at {filePath}");

                byte[] fileBytes = File.ReadAllBytes(filePath);
                Assert.IsTrue(fileBytes.Length > 0, "File should not be empty");

                BinaryData binaryData = BinaryData.FromBytes(fileBytes);

                // Analyze the document using the classifier
                Operation<AnalyzeResult> analyzeOperation = await client.AnalyzeBinaryAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    binaryData);

                // Verify analysis operation completed successfully
                Assert.IsNotNull(analyzeOperation, "Analysis operation should not be null");
                Assert.IsTrue(analyzeOperation.HasCompleted, "Operation should be completed");
                Assert.IsTrue(analyzeOperation.HasValue, "Operation should have a value");
                Assert.IsNotNull(analyzeOperation.GetRawResponse(), "Analysis operation should have a raw response");
                Assert.IsTrue(analyzeOperation.GetRawResponse().Status >= 200 && analyzeOperation.GetRawResponse().Status < 300,
                    $"Response status should be successful, but was {analyzeOperation.GetRawResponse().Status}");

                // Verify analysis result
                AnalyzeResult analyzeResult = analyzeOperation.Value;
                Assert.IsNotNull(analyzeResult, "Analysis result should not be null");
                Assert.IsNotNull(analyzeResult.Contents, "Result should contain contents");
                Assert.IsTrue(analyzeResult.Contents.Count > 0, "Result should have at least one content");
                Assert.AreEqual(1, analyzeResult.Contents.Count, "Result should have exactly one content element");

                // Verify document content and segments
                var documentContent = analyzeResult.Contents?.FirstOrDefault() as DocumentContent;
                Assert.IsNotNull(documentContent, "Content should be DocumentContent");
                Assert.IsTrue(documentContent!.StartPageNumber >= 1, "Start page should be >= 1");
                Assert.IsTrue(documentContent.EndPageNumber >= documentContent.StartPageNumber,
                    "End page should be >= start page");

                // With EnableSegment=true, we expect automatic segmentation into 3 sections
                Assert.IsNotNull(documentContent.Segments, "Segments should not be null when EnableSegment=true");
                Assert.IsTrue(documentContent.Segments!.Count > 0, "Should have at least one segment with EnableSegment=true");
                // Expected: 3 segments (one for each category: Loan_Application, Invoice, Bank_Statement)
                Assert.AreEqual(3, documentContent.Segments.Count,
                    "Mixed financial document should be segmented into 3 sections (one per category)");

                // Verify each segment with expected values from recording
                var sortedSegments = documentContent.Segments.OrderBy(s => s.StartPageNumber).ToList();

                // Expected segment values from recording:
                // Segment 1: Invoice, Pages 1-1, segmentId: segment1
                // Segment 2: Bank_Statement, Pages 2-3, segmentId: segment2
                // Segment 3: Loan_Application, Pages 4-4, segmentId: segment3
                var expectedSegments = new[]
                {
                    new { Category = "Invoice", StartPage = 1, EndPage = 1, SegmentId = "segment1" },
                    new { Category = "Bank_Statement", StartPage = 2, EndPage = 3, SegmentId = "segment2" },
                    new { Category = "Loan_Application", StartPage = 4, EndPage = 4, SegmentId = "segment3" }
                };

                for (int i = 0; i < sortedSegments.Count; i++)
                {
                    var segment = sortedSegments[i];
                    Assert.IsNotNull(segment, $"Segment {i + 1} should not be null");
                    Assert.IsTrue(segment.StartPageNumber >= 1,
                        $"Segment {i + 1} start page should be >= 1, but was {segment.StartPageNumber}");
                    Assert.IsTrue(segment.EndPageNumber >= segment.StartPageNumber,
                        $"Segment {i + 1} end page should be >= start page");
                    Assert.IsTrue(segment.StartPageNumber >= documentContent.StartPageNumber &&
                                segment.EndPageNumber <= documentContent.EndPageNumber,
                        $"Segment {i + 1} page range [{segment.StartPageNumber}, {segment.EndPageNumber}] should be within document range [{documentContent.StartPageNumber}, {documentContent.EndPageNumber}]");

                    // Verify expected values from recording
                    if (i < expectedSegments.Length)
                    {
                        var expected = expectedSegments[i];

                        // Verify category matches expected value
                        Assert.AreEqual(expected.Category, segment.Category,
                            $"Segment {i + 1} category should match expected value");

                        // Verify page numbers match expected values
                        Assert.AreEqual(expected.StartPage, segment.StartPageNumber,
                            $"Segment {i + 1} start page should match expected value");
                        Assert.AreEqual(expected.EndPage, segment.EndPageNumber,
                            $"Segment {i + 1} end page should match expected value");

                        // Verify segment ID matches expected value
                        if (!string.IsNullOrEmpty(segment.SegmentId))
                        {
                            Assert.AreEqual(expected.SegmentId, segment.SegmentId,
                                $"Segment {i + 1} ID should match expected value");
                        }
                    }
                }

                // Verify segments cover the entire document without gaps
                var minSegmentPage = sortedSegments.Min(s => s.StartPageNumber);
                var maxSegmentPage = sortedSegments.Max(s => s.EndPageNumber);
                Assert.IsTrue(minSegmentPage <= documentContent.StartPageNumber,
                    "Segments should start at or before document start page");
                Assert.IsTrue(maxSegmentPage >= documentContent.EndPageNumber,
                    "Segments should end at or after document end page");
            }
            finally
            {
                // Clean up: delete the classifier
                try
                {
                    await client.DeleteAnalyzerAsync(analyzerId);
                }
                catch
                {
                    // Ignore cleanup errors in tests
                }
            }
        }

        /// <summary>
        /// Tests retrieving analyzer information for both prebuilt and custom analyzers.
        /// Verifies that analyzer details are returned correctly.
        /// </summary>
        [RecordedTest]
        public async Task GetAnalyzerAsync()
        {
            ContentUnderstandingClient client = GetClient();

            // Test getting a prebuilt analyzer
            var prebuiltResponse = await client.GetAnalyzerAsync("prebuilt-documentSearch");
            Assert.IsNotNull(prebuiltResponse, "Response should not be null");
            Assert.IsTrue(prebuiltResponse.HasValue, "Response should have a value");
            Assert.IsNotNull(prebuiltResponse.Value, "Analyzer should not be null");

            ContentAnalyzer prebuiltAnalyzer = prebuiltResponse.Value;
            Assert.IsNotNull(prebuiltAnalyzer, "Prebuilt analyzer should not be null");

            // Verify raw response
            var rawResponse = prebuiltResponse.GetRawResponse();
            Assert.IsNotNull(rawResponse, "Raw response should not be null");
            Assert.AreEqual(200, rawResponse.Status, "Response status should be 200");

            // Test getting prebuilt-invoice analyzer (should have field schema)
            var invoiceResponse = await client.GetAnalyzerAsync("prebuilt-invoice");
            Assert.IsNotNull(invoiceResponse, "Invoice response should not be null");
            Assert.IsTrue(invoiceResponse.HasValue, "Invoice response should have a value");
            Assert.IsNotNull(invoiceResponse.Value, "Invoice analyzer should not be null");

            ContentAnalyzer invoiceAnalyzer = invoiceResponse.Value;
            Assert.IsNotNull(invoiceAnalyzer.FieldSchema, "Invoice analyzer should have field schema");
            Assert.IsNotNull(invoiceAnalyzer.FieldSchema!.Fields, "Invoice analyzer should have fields");
            Assert.IsTrue(invoiceAnalyzer.FieldSchema.Fields.Count > 0,
                "Invoice analyzer should have at least one field");
        }

        /// <summary>
        /// Tests listing all analyzers.
        /// Verifies that the list includes prebuilt analyzers and optionally custom analyzers.
        /// </summary>
        [RecordedTest]
        public async Task ListAnalyzersAsync()
        {
            ContentUnderstandingClient client = GetClient();

            // List all analyzers
            var analyzers = new List<ContentAnalyzer>();
            await foreach (var analyzer in client.GetAnalyzersAsync())
            {
                analyzers.Add(analyzer);
            }

            // Verify we got analyzers
            Assert.IsNotNull(analyzers, "Analyzers list should not be null");
            Assert.IsTrue(analyzers.Count > 0, "Should have at least one analyzer");

            // Verify counts
            var prebuiltCount = analyzers.Count(a => a.AnalyzerId?.StartsWith("prebuilt-") == true);
            var customCount = analyzers.Count(a => a.AnalyzerId?.StartsWith("prebuilt-") != true);
            Assert.IsTrue(prebuiltCount > 0, "Should have at least one prebuilt analyzer");
            Assert.AreEqual(analyzers.Count, prebuiltCount + customCount,
                "Total count should equal prebuilt + custom count");

            // Verify each analyzer has required properties
            foreach (var analyzer in analyzers)
            {
                Assert.IsNotNull(analyzer, "Analyzer should not be null");
                Assert.IsNotNull(analyzer.AnalyzerId, "Analyzer ID should not be null");
                Assert.IsFalse(string.IsNullOrWhiteSpace(analyzer.AnalyzerId),
                    $"Analyzer ID should not be empty or whitespace");
            }

            // Verify common prebuilt analyzers exist
            var analyzerIds = analyzers.Select(a => a.AnalyzerId).Where(id => id != null).ToList();
            var commonPrebuiltAnalyzers = new[]
            {
                "prebuilt-document",
                "prebuilt-documentSearch",
                "prebuilt-invoice"
            };

            foreach (var prebuiltId in commonPrebuiltAnalyzers)
            {
                Assert.IsTrue(analyzerIds.Contains(prebuiltId),
                    $"Should contain common prebuilt analyzer: {prebuiltId}");
            }

            // Verify no duplicate analyzer IDs
            var duplicateIds = analyzerIds
                .GroupBy(id => id)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            Assert.AreEqual(0, duplicateIds.Count,
                $"Should not have duplicate analyzer IDs: {string.Join(", ", duplicateIds)}");
        }

        /// <summary>
        /// Tests updating an analyzer's description and tags.
        /// Verifies that the analyzer can be updated successfully and changes are persisted.
        /// </summary>
        [RecordedTest]
        public async Task UpdateAnalyzerAsync()
        {
            ContentUnderstandingClient client = GetClient();

            // First create an analyzer to update
            string defaultId = $"test_analyzer_{Recording.Random.NewGuid().ToString("N")}";
            string analyzerId = Recording.GetVariable("updateAnalyzerId", defaultId) ?? defaultId;

            var initialAnalyzer = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-document",
                Description = "Initial description",
                Config = new ContentAnalyzerConfig
                {
                    ReturnDetails = true
                }
            };
            initialAnalyzer.Models.Add("completion", "gpt-4.1");
            initialAnalyzer.Tags["tag1"] = "tag1_initial_value";
            initialAnalyzer.Tags["tag2"] = "tag2_initial_value";

            await client.CreateAnalyzerAsync(
                WaitUntil.Completed,
                analyzerId,
                initialAnalyzer,
                allowReplace: true);

            try
            {
                // Get the current analyzer to preserve base analyzer ID
                var currentAnalyzer = await client.GetAnalyzerAsync(analyzerId);
                Assert.IsNotNull(currentAnalyzer, "Current analyzer should not be null");
                Assert.IsTrue(currentAnalyzer.HasValue, "Current analyzer should have a value");

                // Create an updated analyzer with new description and tags
                var updatedAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = currentAnalyzer.Value.BaseAnalyzerId,
                    Description = "Updated description"
                };

                // Update tags (empty string sets tag to empty, doesn't remove it)
                updatedAnalyzer.Tags["tag1"] = "tag1_updated_value";
                updatedAnalyzer.Tags["tag2"] = "";  // Set tag2 to empty string
                updatedAnalyzer.Tags["tag3"] = "tag3_value";  // Add tag3

                // Update the analyzer
                await client.UpdateAnalyzerAsync(analyzerId, updatedAnalyzer);

                // Verify the update
                var updated = await client.GetAnalyzerAsync(analyzerId);
                Assert.IsNotNull(updated, "Updated analyzer should not be null");
                Assert.IsTrue(updated.HasValue, "Updated analyzer should have a value");
                Assert.AreEqual("Updated description", updated.Value.Description,
                    "Description should be updated");
                Assert.IsTrue(updated.Value.Tags.ContainsKey("tag1"), "tag1 should exist");
                Assert.AreEqual("tag1_updated_value", updated.Value.Tags["tag1"],
                    "tag1 should have updated value");
                // Note: Setting tag to empty string doesn't remove it, just sets it to empty
                Assert.IsTrue(updated.Value.Tags.ContainsKey("tag2"),
                    "tag2 should still exist (empty string doesn't remove tags)");
                Assert.AreEqual("", updated.Value.Tags["tag2"],
                    "tag2 should have empty string value");
                Assert.IsTrue(updated.Value.Tags.ContainsKey("tag3"), "tag3 should exist");
                Assert.AreEqual("tag3_value", updated.Value.Tags["tag3"],
                    "tag3 should have correct value");
                Assert.AreEqual(3, updated.Value.Tags.Count,
                    "Should have 3 tags after update (tag1 updated, tag2 set to empty, tag3 added)");
            }
            finally
            {
                // Clean up
                try
                {
                    await client.DeleteAnalyzerAsync(analyzerId);
                }
                catch
                {
                    // Ignore cleanup errors
                }
            }
        }

        /// <summary>
        /// Tests deleting an analyzer.
        /// Verifies that an analyzer can be deleted successfully.
        /// </summary>
        [RecordedTest]
        public async Task DeleteAnalyzerAsync()
        {
            ContentUnderstandingClient client = GetClient();

            // First create an analyzer to delete
            string defaultId = $"test_analyzer_{Recording.Random.NewGuid().ToString("N")}";
            string analyzerId = Recording.GetVariable("deleteAnalyzerId", defaultId) ?? defaultId;

            var analyzer = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-document",
                Description = "Simple analyzer for deletion example",
                Config = new ContentAnalyzerConfig
                {
                    ReturnDetails = true
                }
            };
            analyzer.Models.Add("completion", "gpt-4.1");

            await client.CreateAnalyzerAsync(
                WaitUntil.Completed,
                analyzerId,
                analyzer,
                allowReplace: true);

            // Verify the analyzer was created
            var getResponse = await client.GetAnalyzerAsync(analyzerId);
            Assert.IsNotNull(getResponse, "Get analyzer response should not be null");
            Assert.IsTrue(getResponse.HasValue, "Get analyzer response should have a value");

            // Delete the analyzer
            await client.DeleteAnalyzerAsync(analyzerId);

            // Verify the analyzer was deleted (should throw 404 or similar)
            try
            {
                var deletedResponse = await client.GetAnalyzerAsync(analyzerId);
                // If we get here, the analyzer still exists (unexpected)
                Assert.Fail("Analyzer should have been deleted, but GetAnalyzerAsync succeeded");
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                // Expected: analyzer not found after deletion
                Assert.Pass("Analyzer was successfully deleted (404 as expected)");
            }
        }

        /// <summary>
        /// Tests analyzing a document with specific configurations enabled (formulas, layout, OCR).
        /// Verifies that document features like charts, annotations, and formulas can be extracted.
        /// </summary>
        [RecordedTest]
        public async Task AnalyzeConfigsAsync()
        {
            ContentUnderstandingClient client = GetClient();

            // Get test file path
            string filePath = ContentUnderstandingClientTestEnvironment.CreatePath("sample_document_features.pdf");
            Assert.IsTrue(File.Exists(filePath), $"Test file should exist at {filePath}");

            byte[] fileBytes = File.ReadAllBytes(filePath);
            Assert.IsTrue(fileBytes.Length > 0, "File should not be empty");

            BinaryData binaryData = BinaryData.FromBytes(fileBytes);

            // Analyze with prebuilt-documentSearch which has formulas, layout, and OCR enabled
            Operation<AnalyzeResult> operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                binaryData);

            // Verify operation completed successfully
            Assert.IsNotNull(operation, "Analysis operation should not be null");
            Assert.IsTrue(operation.HasCompleted, "Operation should be completed");
            Assert.IsTrue(operation.HasValue, "Operation should have a value");
            Assert.IsNotNull(operation.GetRawResponse(), "Analysis operation should have a raw response");
            Assert.IsTrue(operation.GetRawResponse().Status >= 200 && operation.GetRawResponse().Status < 300,
                $"Response status should be successful, but was {operation.GetRawResponse().Status}");

            // Verify result
            AnalyzeResult result = operation.Value;
            Assert.IsNotNull(result, "Analysis result should not be null");
            Assert.IsNotNull(result.Contents, "Result should contain contents");
            Assert.IsTrue(result.Contents.Count > 0, "Result should have at least one content");
            Assert.AreEqual(1, result.Contents.Count, "PDF file should have exactly one content element");

            // Verify document content
            var documentContent = result.Contents?.FirstOrDefault() as DocumentContent;
            Assert.IsNotNull(documentContent, "Content should be DocumentContent");
            Assert.IsTrue(documentContent!.StartPageNumber >= 1, "Start page should be >= 1");
            Assert.IsTrue(documentContent.EndPageNumber >= documentContent.StartPageNumber,
                "End page should be >= start page");
        }

        /// <summary>
        /// Tests analyzing a document and returning raw JSON response.
        /// Verifies that the raw JSON response can be retrieved and parsed.
        /// </summary>
        [RecordedTest]
        public async Task AnalyzeReturnRawJsonAsync()
        {
            ContentUnderstandingClient client = GetClient();

            // Get test file path
            string filePath = ContentUnderstandingClientTestEnvironment.CreatePath("sample_invoice.pdf");
            Assert.IsTrue(File.Exists(filePath), $"Sample file should exist at {filePath}");

            byte[] fileBytes = File.ReadAllBytes(filePath);
            Assert.IsTrue(fileBytes.Length > 0, "File should not be empty");

            // Use protocol method to get raw JSON response
            var operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                RequestContent.Create(BinaryData.FromBytes(fileBytes)),
                "application/pdf");

            // Verify operation completed successfully
            Assert.IsNotNull(operation, "Analysis operation should not be null");
            Assert.IsTrue(operation.HasCompleted, "Operation should be completed");
            Assert.IsTrue(operation.HasValue, "Operation should have a value");
            Assert.IsNotNull(operation.GetRawResponse(), "Analysis operation should have a raw response");
            Assert.IsTrue(operation.GetRawResponse().Status >= 200 && operation.GetRawResponse().Status < 300,
                $"Response status should be successful, but was {operation.GetRawResponse().Status}");

            // Verify response data
            BinaryData responseData = operation.Value;
            Assert.IsNotNull(responseData, "Response data should not be null");
            Assert.IsTrue(responseData.ToMemory().Length > 0, "Response data should not be empty");

            // Verify response is valid JSON
            using var jsonDocument = System.Text.Json.JsonDocument.Parse(responseData);
            Assert.IsNotNull(jsonDocument, "Response should be valid JSON");
            Assert.IsNotNull(jsonDocument.RootElement, "JSON should have root element");
        }

        /// <summary>
        /// Tests deleting an analysis result.
        /// Verifies that an analysis result can be deleted using its operation ID.
        /// </summary>
        [RecordedTest]
        public async Task DeleteResultAsync()
        {
            ContentUnderstandingClient client = GetClient();

            // Get test file URI
            Uri documentUrl = ContentUnderstandingClientTestEnvironment.CreateUri("invoice.pdf");
            Assert.IsNotNull(documentUrl, "Document URL should not be null");
            Assert.IsTrue(documentUrl.IsAbsoluteUri, "Document URL should be absolute");

            // Start the analysis operation
            var analyzeOperation = await client.AnalyzeAsync(
                WaitUntil.Started,
                "prebuilt-invoice",
                inputs: new[] { new AnalyzeInput { Url = documentUrl } });

            // Get the operation ID from the operation
            string operationId = analyzeOperation.Id;
            Assert.IsNotNull(operationId, "Operation ID should not be null");
            Assert.IsFalse(string.IsNullOrWhiteSpace(operationId), "Operation ID should not be empty");

            // Wait for completion
            await analyzeOperation.WaitForCompletionAsync();
            AnalyzeResult result = analyzeOperation.Value;

            // Verify analysis completed successfully
            Assert.IsNotNull(result, "Analysis result should not be null");
            Assert.IsNotNull(result.Contents, "Result should contain contents");
            Assert.IsTrue(result.Contents!.Count > 0, "Result should have at least one content");

            // Delete the analysis result
            await client.DeleteResultAsync(operationId);

            // Verify deletion succeeded (no exception means deletion was successful)
            // Note: There's no direct way to verify deletion by querying the result,
            // but if DeleteResultAsync completes without throwing, the deletion was successful
            Assert.Pass("Analysis result deletion completed successfully");
        }

        /// <summary>
        /// Tests retrieving result files (keyframe images) from video analysis.
        /// Verifies that keyframes can be retrieved using GetResultFileAsync.
        /// </summary>
        [RecordedTest]
        public async Task GetResultFileAsync()
        {
            ContentUnderstandingClient client = GetClient();

            // Use video URL from sample
            Uri videoUrl = new Uri("https://github.com/Azure-Samples/azure-ai-content-understanding-assets/raw/refs/heads/main/videos/sdk_samples/FlightSimulator.mp4");
            Assert.IsNotNull(videoUrl, "Video URL should not be null");
            Assert.IsTrue(videoUrl.IsAbsoluteUri, "Video URL should be absolute");

            // Start the analysis operation
            var analyzeOperation = await client.AnalyzeAsync(
                WaitUntil.Started,
                "prebuilt-videoSearch",
                inputs: new[] { new AnalyzeInput { Url = videoUrl } });

            // Get the operation ID from the operation
            string operationId = analyzeOperation.Id;
            Assert.IsNotNull(operationId, "Operation ID should not be null");
            Assert.IsFalse(string.IsNullOrWhiteSpace(operationId), "Operation ID should not be empty");

            // Wait for completion
            await analyzeOperation.WaitForCompletionAsync();
            AnalyzeResult result = analyzeOperation.Value;

            // Verify analysis completed successfully
            Assert.IsNotNull(result, "Analysis result should not be null");
            Assert.IsNotNull(result.Contents, "Result should contain contents");
            Assert.IsTrue(result.Contents!.Count > 0, "Result should have at least one content");

            // Find video content with keyframes
            var videoContent = result.Contents?.FirstOrDefault(c => c is AudioVisualContent) as AudioVisualContent;
            Assert.IsNotNull(videoContent, "Test requires AudioVisualContent (video content) for GetResultFile");
            Assert.IsNotNull(videoContent!.KeyFrameTimesMs, "KeyFrameTimesMs should not be null");
            Assert.IsTrue(videoContent.KeyFrameTimesMs!.Count > 0,
                $"Video content should have at least one keyframe, but found {videoContent.KeyFrameTimesMs.Count}");

            // Get the first keyframe
            long firstFrameTimeMs = videoContent.KeyFrameTimesMs[0];
            string framePath = $"keyframes/{firstFrameTimeMs}";

            // Get the result file (keyframe image)
            Response<BinaryData> fileResponse = await client.GetResultFileAsync(operationId, framePath);

            // Verify response
            Assert.IsNotNull(fileResponse, "File response should not be null");
            Assert.IsTrue(fileResponse.HasValue, "File response should have a value");
            Assert.IsNotNull(fileResponse.Value, "File response value should not be null");

            // Verify raw response
            var rawResponse = fileResponse.GetRawResponse();
            Assert.IsNotNull(rawResponse, "Raw response should not be null");
            Assert.IsTrue(rawResponse.Status >= 200 && rawResponse.Status < 300,
                $"Response status should be successful, but was {rawResponse.Status}");

            // Verify file data
            byte[] imageBytes = fileResponse.Value.ToArray();
            Assert.IsTrue(imageBytes.Length > 0, "Keyframe image should not be empty");
        }
    }
}
