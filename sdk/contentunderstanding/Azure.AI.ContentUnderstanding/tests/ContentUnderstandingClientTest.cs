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

            // Update defaults with configured deployments
            var modelDeployments = new Dictionary<string, string>
            {
                ["gpt-4.1"] = gpt41Deployment!,
                ["gpt-4.1-mini"] = gpt41MiniDeployment!,
                ["text-embedding-3-large"] = textEmbeddingDeployment!
            };

            Response<ContentUnderstandingDefaults> response = await client.UpdateDefaultsAsync(modelDeployments);

            Assert.IsNotNull(response, "Update response should not be null");
            Assert.IsNotNull(response.Value, "Updated defaults should not be null");

            ContentUnderstandingDefaults updatedDefaults = response.Value;

            // Verify the updated defaults
            Assert.IsNotNull(updatedDefaults.ModelDeployments, "Updated model deployments should not be null");
            Assert.IsTrue(updatedDefaults.ModelDeployments.Count >= 3, "Should have at least 3 model deployments");

            // Verify each deployment was set correctly
            Assert.IsTrue(updatedDefaults.ModelDeployments.ContainsKey("gpt-4.1"), "Should contain gpt-4.1 deployment");
            Assert.AreEqual(gpt41Deployment, updatedDefaults.ModelDeployments["gpt-4.1"], "gpt-4.1 deployment should match");

            Assert.IsTrue(updatedDefaults.ModelDeployments.ContainsKey("gpt-4.1-mini"), "Should contain gpt-4.1-mini deployment");
            Assert.AreEqual(gpt41MiniDeployment, updatedDefaults.ModelDeployments["gpt-4.1-mini"], "gpt-4.1-mini deployment should match");

            Assert.IsTrue(updatedDefaults.ModelDeployments.ContainsKey("text-embedding-3-large"), "Should contain text-embedding-3-large deployment");
            Assert.AreEqual(textEmbeddingDeployment, updatedDefaults.ModelDeployments["text-embedding-3-large"], "text-embedding-3-large deployment should match");
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
            AnalyzeResultOperation operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                "application/pdf",
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
            AnalyzeResultOperation operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                "application/pdf",
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
            AnalyzeResultOperation operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                "application/pdf",
                binaryData);

            AnalyzeResult result = operation.Value;

            // Verify contents exist
            Assert.IsNotNull(result.Contents, "Result should contain contents");
            Assert.IsTrue(result.Contents!.Count > 0, "Result should have at least one content");

            MediaContent? content = result.Contents.First();
            Assert.IsNotNull(content, "Content should not be null for document properties validation");

            // Verify document content type and properties
            if (content is DocumentContent docContent)
            {
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

                // Validate pages collection if available
                if (docContent.Pages != null && docContent.Pages.Count > 0)
                {
                    Assert.IsTrue(docContent.Pages.Count > 0, "Pages collection should not be empty when not null");
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
                }

                // Validate tables collection if available
                // Expected table counts from recording: Table 1 (2 rows, 6 columns), Table 2 (4 rows, 8 columns), Table 3 (5 rows, 2 columns)
                int[] expectedRowCounts = { 2, 4, 5 };
                int[] expectedColumnCounts = { 6, 8, 2 };

                if (docContent.Tables != null && docContent.Tables.Count > 0)
                {
                    Assert.IsTrue(docContent.Tables.Count > 0, "Tables collection should not be empty when not null");
                    Assert.AreEqual(expectedRowCounts.Length, docContent.Tables.Count,
                        $"Expected {expectedRowCounts.Length} tables based on recording, but found {docContent.Tables.Count}");

                    int tableCounter = 0;
                    foreach (var table in docContent.Tables)
                    {
                        Assert.IsNotNull(table, $"Table {tableCounter + 1} should not be null");

                        // Verify row and column counts match expected values from recording
                        if (tableCounter < expectedRowCounts.Length)
                        {
                            Assert.AreEqual(expectedRowCounts[tableCounter], table.RowCount,
                                $"Table {tableCounter + 1} row count should be {expectedRowCounts[tableCounter]}, but was {table.RowCount}");
                            Assert.AreEqual(expectedColumnCounts[tableCounter], table.ColumnCount,
                                $"Table {tableCounter + 1} column count should be {expectedColumnCounts[tableCounter]}, but was {table.ColumnCount}");
                        }

                        // Validate table cells if available
                        if (table.Cells != null && table.Cells.Count > 0)
                        {
                            Assert.IsTrue(table.Cells.Count > 0, $"Table {tableCounter + 1} cells collection should not be empty when not null");

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
                        }

                        tableCounter++;
                    }
                }
            }
            else
            {
                Assert.Warn("Expected DocumentContent but got " + content?.GetType().Name);
            }
        }
    }
}
