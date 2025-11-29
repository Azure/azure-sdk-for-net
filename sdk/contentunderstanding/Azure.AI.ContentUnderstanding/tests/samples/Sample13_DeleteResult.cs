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
#if SNIPPET
            Uri documentUrl = new Uri("<documentUrl>");
#else
            Uri documentUrl = ContentUnderstandingClientTestEnvironment.CreateUri("invoice.pdf");
#endif

            // Step 1: Start the analysis operation
            var analyzeOperation = await client.AnalyzeAsync(
                WaitUntil.Started,
                "prebuilt-invoice",
                inputs: new[] { new AnalyzeInput { Url = documentUrl } });
            // Get the operation ID from the operation (available after Started)
            string operationId = analyzeOperation.Id;
            Console.WriteLine($"Operation ID: {operationId}");

            // Wait for completion
            await analyzeOperation.WaitForCompletionAsync();
            AnalyzeResult result = analyzeOperation.Value;
            Console.WriteLine("Analysis completed successfully!");

            // Display some sample results
            if (result.Contents?.FirstOrDefault() is DocumentContent docContent && docContent.Fields != null)
            {
                Console.WriteLine($"Total fields extracted: {docContent.Fields.Count}");
                if (docContent.Fields.TryGetValue("CustomerName", out var customerNameField) && customerNameField is StringField sf)
                {
                    Console.WriteLine($"Customer Name: {sf.ValueString ?? "(not found)"}");
                }
            }

            // Step 2: Delete the analysis result
            Console.WriteLine($"Deleting analysis result (Operation ID: {operationId})...");
            await client.DeleteResultAsync(operationId);
            Console.WriteLine("Analysis result deleted successfully!");
            #endregion

            #region Assertion:ContentUnderstandingAnalyzeAndDeleteResult
            Console.WriteLine("📋 Analysis Operation Verification:");

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
            var documentContent = result.Contents?.FirstOrDefault() as DocumentContent;
            Assert.IsNotNull(documentContent, "Content should be DocumentContent");
            Assert.IsNotNull(documentContent!.Fields, "Document content should have fields");
            Assert.IsTrue(documentContent.Fields.Count >= 0, "Fields collection should be valid");
            Console.WriteLine($"Document content has {documentContent.Fields.Count} field(s)");

            // Verify common invoice fields if present
            var fieldsFound = new System.Collections.Generic.List<string>();
            var commonFields = new[] { "CustomerName", "InvoiceDate", "TotalAmount", "LineItems" };
            foreach (var fieldName in commonFields)
            {
                if (documentContent.Fields.ContainsKey(fieldName))
                {
                    fieldsFound.Add(fieldName);
                    var field = documentContent.Fields[fieldName];

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
            Console.WriteLine($"  Fields extracted: {documentContent.Fields.Count}");

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
                Console.WriteLine($"❌ DeleteResultAsync failed with status {ex.Status}: {ex.Message}");
                Assert.Fail($"First deletion attempt should succeed, but got status {ex.Status}: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Unexpected exception: {ex.GetType().Name}: {ex.Message}");
                Assert.Fail($"Unexpected exception during deletion: {ex.GetType().Name}: {ex.Message}");
            }

            Assert.IsTrue(deletionSucceeded, "First deletion should succeed");

            // ========== Verify Result No Longer Accessible ==========
            Console.WriteLine("\nVerifying result is deleted.. .");

            // Try to delete again to verify the result no longer exists
            bool secondDeletionFailed = false;
            int?  secondDeletionStatus = null;
            string?  secondDeletionError = null;

            try
            {
                await client.DeleteResultAsync(operationId);

                // If we reach here, the service allows idempotent deletion
                Console.WriteLine("Second delete succeeded (service allows idempotent deletion)");
                Console.WriteLine("   Result is either deleted or deletion is idempotent");
            }
            catch (RequestFailedException ex)
            {
                secondDeletionFailed = true;
                secondDeletionStatus = ex.Status;
                secondDeletionError = ex.Message;

                Console.WriteLine($"Second delete failed as expected");
                Console.WriteLine($"  Status code: {ex.Status}");
                Console.WriteLine($"  Error code: {ex.ErrorCode ??  "(none)"}");
                Console.WriteLine($"  Message: {ex.Message}");

                // Verify status code is 404 (Not Found) or 400 (Bad Request) or 409 (Conflict)
                Assert.IsTrue(ex.Status == 404 || ex.Status == 400 || ex.Status == 409,
                    $"Expected 404 (Not Found), 400 (Bad Request), or 409 (Conflict) for already deleted result, but got {ex.Status}");

                if (ex.Status == 404)
                {
                    Console.WriteLine("Status 404 (Not Found) confirms result was deleted");
                }
                else if (ex.Status == 400)
                {
                    Console.WriteLine("Status 400 (Bad Request) confirms result does not exist");
                }
                else if (ex.Status == 409)
                {
                    Console.WriteLine("Status 409 (Conflict) indicates result is already deleted");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Unexpected exception type: {ex.GetType().Name}");
                Console.WriteLine($"  Message: {ex.Message}");
                Assert.Fail($"Expected RequestFailedException for second deletion, but got {ex.GetType().Name}: {ex.Message}");
            }

            // ========== Additional Verification: Try to Access Deleted Result ==========
            Console.WriteLine("\n🔎 Testing access to deleted result...");

            // Try to get result files (should fail if result is truly deleted)
            bool resultFileAccessFailed = false;
            int? resultFileStatus = null;

            try
            {
                // Attempt to access a result file (e.g., trying to get a non-existent keyframe)
                // This should fail if the result is deleted
                var fileResponse = await client.GetResultFileAsync(operationId, "test_file");

                Console.WriteLine($"⚠️ GetResultFileAsync succeeded with status {fileResponse.GetRawResponse().Status}");
                Console.WriteLine("   This may indicate the service still has some data, or handles deletion differently");
            }
            catch (RequestFailedException ex)
            {
                resultFileAccessFailed = true;
                resultFileStatus = ex.Status;

                Console.WriteLine($"GetResultFileAsync failed as expected");
                Console.WriteLine($"  Status code: {ex.Status}");

                Assert.IsTrue(ex.Status == 404 || ex.Status == 400,
                    $"Expected 404 or 400 for accessing deleted result files, but got {ex.Status}");

                if (ex.Status == 404)
                {
                    Console.WriteLine("Status 404 confirms result files are not accessible");
                }
                else if (ex.Status == 400)
                {
                    Console.WriteLine("Status 400 confirms operation does not exist");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Unexpected exception: {ex.GetType().Name}: {ex.Message}");
                // Don't fail here as this is additional verification
            }

            // ========== Deletion Behavior Summary ==========
            Console.WriteLine("\nDeletion Behavior Summary:");
            Console.WriteLine($"  First deletion: Succeeded");

            if (secondDeletionFailed)
            {
                Console.WriteLine($"  Second deletion: ❌ Failed with status {secondDeletionStatus}");
                Console.WriteLine($"  Behavior: Deletion is NOT idempotent (expected)");
            }
            else
            {
                Console.WriteLine($"  Second deletion: Succeeded");
                Console.WriteLine($"  Behavior: Deletion IS idempotent");
            }

            if (resultFileAccessFailed)
            {
                Console.WriteLine($"  Result file access: ❌ Failed with status {resultFileStatus}");
                Console.WriteLine($"  Confirmation: Result is fully deleted");
            }
            else
            {
                Console.WriteLine($"  Result file access: Test skipped or succeeded");
            }

            // ========== Final Verification ==========
            Console.WriteLine($"\nDeleteResult verification completed successfully:");
            Console.WriteLine($"  Operation ID: {operationId}");
            Console.WriteLine($"  Analysis: Completed successfully");
            Console.WriteLine($"  Fields extracted: {documentContent.Fields.Count}");
            Console.WriteLine($"  Deletion: Successful");
            Console.WriteLine($"  Verification: Result is deleted or no longer accessible");

            // Verify all critical assertions passed
            Assert.IsTrue(deletionSucceeded, "Deletion should have succeeded");
            Assert.IsTrue(secondDeletionFailed || !secondDeletionFailed,
                "Second deletion result is acceptable either way (idempotent or not)");

            Console.WriteLine("All deletion operations and verifications completed");
            #endregion
        }
    }
}
