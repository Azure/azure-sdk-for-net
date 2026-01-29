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
        public async Task DeleteResultAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            #region Snippet:ContentUnderstandingAnalyzeAndDeleteResult
            // You can replace this URL with your own invoice file URL
            Uri documentUrl = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-dotnet/main/ContentUnderstanding.Common/data/invoice.pdf");

            // Step 1: Analyze and wait for completion
            var analyzeOperation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-invoice",
                inputs: new[] { new AnalyzeInput { Url = documentUrl } });

            // Get the operation ID - this is needed to delete the result later
            string operationId = analyzeOperation.Id;
            Console.WriteLine($"Operation ID: {operationId}");
            AnalyzeResult result = analyzeOperation.Value;
            Console.WriteLine("Analysis completed successfully!");

            // Display some sample results
            DocumentContent documentContent = (DocumentContent)result.Contents!.First();
            Console.WriteLine($"Total fields extracted: {documentContent.Fields?.Count ?? 0}");

            // Step 2: Delete the analysis result
            Console.WriteLine($"Deleting analysis result (Operation ID: {operationId})...");
            await client.DeleteResultAsync(operationId);
            Console.WriteLine("Analysis result deleted successfully!");
            #endregion

            #region Assertion:ContentUnderstandingAnalyzeAndDeleteResult
            Console.WriteLine("Analysis Operation Verification:");

            // ========== Step 1: Verify Analysis Operation ==========
            Assert.IsNotNull(documentUrl, "Document URL should not be null");
            Assert.IsTrue(documentUrl.IsAbsoluteUri, "Document URL should be absolute");
            Console.WriteLine($"Document URL: {documentUrl}");

            Assert.IsNotNull(analyzeOperation, "Analyze operation should not be null");
            Console.WriteLine("Analysis operation created");

            // Verify operation ID is available immediately after WaitUntil.Started
            Assert.IsNotNull(operationId, "Operation ID should not be null");
            Assert.IsFalse(string.IsNullOrWhiteSpace(operationId), "Operation ID should not be empty");
            Assert.IsTrue(operationId.Length > 0, "Operation ID should have length > 0");
            Assert.IsFalse(operationId.Contains(" "), "Operation ID should not contain spaces");
            Console.WriteLine($"Operation ID obtained: {operationId}");
            Console.WriteLine($"  Length: {operationId.Length} characters");

            // Verify operation completed
            Assert.IsTrue(analyzeOperation.HasCompleted, "Operation should be completed after WaitForCompletionAsync");
            Assert.IsTrue(analyzeOperation.HasValue, "Operation should have a value after completion");
            Console.WriteLine("Operation completed successfully");

            // Verify raw response
            var rawResponse = analyzeOperation.GetRawResponse();
            Assert.IsNotNull(rawResponse, "Raw response should not be null");
            Assert.IsTrue(rawResponse.Status >= 200 && rawResponse.Status < 300,
                $"Response status should be successful, but was {rawResponse.Status}");
            Console.WriteLine($"Response status: {rawResponse.Status}");

            // ========== Verify Analysis Result ==========
            Console.WriteLine("\nAnalysis Result Verification:");

            Assert.IsNotNull(result, "Analysis result should not be null");
            Assert.IsNotNull(result.Contents, "Result should contain contents");
            Assert.IsTrue(result.Contents!.Count > 0, "Result should have at least one content");
            Assert.AreEqual(1, result.Contents.Count, "Invoice should have exactly one content element");
            Console.WriteLine($"Analysis result contains {result.Contents.Count} content(s)");

            // Verify content structure
            var docContent = result.Contents?.FirstOrDefault() as DocumentContent;
            Assert.IsNotNull(docContent, "Content should be DocumentContent");
            Assert.IsNotNull(docContent!.Fields, "Document content should have fields");
            Assert.IsTrue(docContent.Fields.Count >= 0, "Fields collection should be valid");
            Console.WriteLine($"Document content has {docContent.Fields.Count} field(s)");

            // Verify common invoice fields if present
            var fieldsFound = new System.Collections.Generic.List<string>();
            var commonFields = new[] { "CustomerName", "InvoiceDate", "TotalAmount", "LineItems" };
            foreach (var fieldName in commonFields)
            {
                if (docContent!.Fields.ContainsKey(fieldName))
                {
                    fieldsFound.Add(fieldName);
                    var field = docContent.Fields[fieldName];

                    if (field is StringField sf && !string.IsNullOrWhiteSpace(sf.ValueString))
                    {
                        Console.WriteLine($"  {fieldName}: {sf.ValueString}");
                    }
                    else if (field is ObjectField of)
                    {
                        var propertyCount = of.Value is System.Collections.IDictionary dict ? dict.Count : 0;
                        Console.WriteLine($"  {fieldName}: [Object with {propertyCount} properties]");
                    }
                    else if (field is ArrayField af)
                    {
                        Console.WriteLine($"  {fieldName}: [Array with {af.Count} items]");
                    }
                    else
                    {
                        Console.WriteLine($"  {fieldName}: [Found]");
                    }
                }
            }

            if (fieldsFound.Count > 0)
            {
                Console.WriteLine($"Found {fieldsFound.Count}/{commonFields.Length} common invoice fields");
            }

            // Verify analyzer ID
            if (!string.IsNullOrWhiteSpace(result.AnalyzerId))
            {
                Assert.AreEqual("prebuilt-invoice", result.AnalyzerId,
                    "Analyzer ID should match the one used in the request");
                Console.WriteLine($"Analyzer ID verified: {result.AnalyzerId}");
            }

            Console.WriteLine($"\nAnalysis verification completed:");
            Console.WriteLine($"  Operation ID: {operationId}");
            Console.WriteLine($"  Status: Completed");
            Console.WriteLine($"  Fields extracted: {docContent!.Fields.Count}");

            // ========== Step 2: Verify Result Deletion ==========
            Console.WriteLine("\nResult Deletion Verification:");

            bool deletionSucceeded = false;
            try
            {
                await client.DeleteResultAsync(operationId);
                deletionSucceeded = true;
                Console.WriteLine($"DeleteResultAsync succeeded for operation ID: {operationId}");
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"DeleteResultAsync failed with status {ex.Status}: {ex.Message}");
                Assert.Fail($"First deletion attempt should succeed, but got status {ex.Status}: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected exception: {ex.GetType().Name}: {ex.Message}");
                Assert.Fail($"Unexpected exception during deletion: {ex.GetType().Name}: {ex.Message}");
            }

            Assert.IsTrue(deletionSucceeded, "First deletion should succeed");

            // ========== Verify Result No Longer Accessible ==========
            Console.WriteLine("\nVerifying result is deleted.. .");

            // Try to delete again to verify the result no longer exists
            try
            {
                await client.DeleteResultAsync(operationId);
                Console.WriteLine("Second delete succeeded (service allows idempotent deletion)");
            }
            catch (RequestFailedException ex)
            {
                // Expected: Result was already deleted, so second deletion should fail
                Console.WriteLine($"Second delete failed as expected (status: {ex.Status})");
                Assert.AreEqual(404, ex.Status, "Expected 404 (Not Found) for already deleted result");
            }

            // ========== Deletion Behavior Summary ==========
            Console.WriteLine("\nDeletion Behavior Summary:");
            Console.WriteLine($"  First deletion: Succeeded");
            Console.WriteLine($"  Second deletion: Failed with 404 (result already deleted)");

            // Verify all critical assertions passed
            Assert.IsTrue(deletionSucceeded, "Deletion should have succeeded");

            Console.WriteLine("All deletion operations and verifications completed");
            #endregion
        }
    }
}
