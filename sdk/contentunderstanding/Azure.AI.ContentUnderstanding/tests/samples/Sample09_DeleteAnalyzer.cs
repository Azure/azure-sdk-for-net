// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
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
        public async Task DeleteAnalyzerAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            #region Snippet:ContentUnderstandingCreateSimpleAnalyzer
            // First create a simple analyzer to delete
#if SNIPPET
            // Generate a unique analyzer ID
            string analyzerId = $"my_analyzer_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
#else
            // Generate a unique analyzer ID and record it for playback
            string defaultId = $"test_analyzer_{Recording.Random.NewGuid().ToString("N")}";
            string analyzerId = Recording.GetVariable("deleteAnalyzerId", defaultId) ?? defaultId;
#endif

            // Create a simple analyzer
            var analyzer = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-document",
                Description = "Simple analyzer for deletion example",
                Config = new ContentAnalyzerConfig
                {
                    ReturnDetails = true
                }
            };
            analyzer.Models["completion"] = "gpt-4.1";

            await client.CreateAnalyzerAsync(
                WaitUntil.Completed,
                analyzerId,
                analyzer,
                allowReplace: true);

            Console.WriteLine($"Analyzer '{analyzerId}' created successfully.");
            #endregion

            #region Assertion:ContentUnderstandingCreateSimpleAnalyzer
            Assert.IsNotNull(analyzerId, "Analyzer ID should not be null");
            Assert.IsFalse(string.IsNullOrWhiteSpace(analyzerId), "Analyzer ID should not be empty");
            Console.WriteLine($"Analyzer ID generated: {analyzerId}");

            Assert.IsNotNull(analyzer, "Analyzer object should not be null");
            Assert.AreEqual("prebuilt-document", analyzer.BaseAnalyzerId, "Base analyzer ID should match");
            Assert.AreEqual("Simple analyzer for deletion example", analyzer.Description, "Description should match");
            Assert.IsNotNull(analyzer.Config, "Config should not be null");
            Assert.IsTrue(analyzer.Config.ReturnDetails, "ReturnDetails should be true");
            Assert.IsNotNull(analyzer.Models, "Models should not be null");
            Assert.IsTrue(analyzer.Models.ContainsKey("completion"), "Should have completion model");
            Assert.AreEqual("gpt-4.1", analyzer.Models["completion"], "Completion model should be gpt-4.1");
            Console.WriteLine("Analyzer object configured correctly");

            // Verify the analyzer was created successfully
            var getResponse = await client.GetAnalyzerAsync(analyzerId);
            Assert.IsNotNull(getResponse, "Get analyzer response should not be null");
            Assert.IsTrue(getResponse.HasValue, "Get analyzer response should have a value");
            Assert.IsNotNull(getResponse.Value, "Created analyzer should not be null");
            Console.WriteLine("Analyzer retrieved successfully after creation");

            // Verify raw response
            var getRawResponse = getResponse.GetRawResponse();
            Assert.IsNotNull(getRawResponse, "Raw response should not be null");
            Assert.AreEqual(200, getRawResponse.Status, "Response status should be 200");
            Console.WriteLine($"Get analyzer response status: {getRawResponse.Status}");

            // Verify analyzer properties
            Assert.IsNotNull(getResponse.Value.BaseAnalyzerId, "Base analyzer ID should not be null");
            Assert.AreEqual("prebuilt-document", getResponse.Value.BaseAnalyzerId,
                "Base analyzer ID should match");
            Console.WriteLine($"Base analyzer ID verified: {getResponse.Value.BaseAnalyzerId}");

            Assert.IsNotNull(getResponse.Value.Description, "Description should not be null");
            Assert.AreEqual("Simple analyzer for deletion example", getResponse.Value.Description,
                "Description should match");
            Console.WriteLine($"Description verified: '{getResponse.Value.Description}'");

            // Verify config
            if (getResponse.Value.Config != null)
            {
                Console.WriteLine("Config exists");
                if (getResponse.Value.Config.ReturnDetails.HasValue)
                {
                    Assert.AreEqual(true, getResponse.Value.Config.ReturnDetails.Value,
                        "ReturnDetails should be true");
                    Console.WriteLine($"  ReturnDetails: {getResponse.Value.Config.ReturnDetails.Value}");
                }
            }

            // Verify models
            if (getResponse.Value.Models != null)
            {
                Assert.IsTrue(getResponse.Value.Models.Count >= 1, "Should have at least 1 model");
                Console.WriteLine($"Models verified: {getResponse.Value.Models.Count} model(s)");

                if (getResponse.Value.Models.ContainsKey("completion"))
                {
                    Assert.AreEqual("gpt-4.1", getResponse.Value.Models["completion"],
                        "Completion model should be gpt-4.1");
                    Console.WriteLine($"  completion: {getResponse.Value.Models["completion"]}");
                }
            }

            Console.WriteLine($"Verified analyzer '{analyzerId}' exists and is correctly configured before deletion");
            #endregion

            #region Snippet:ContentUnderstandingDeleteAnalyzer
            #if SNIPPET
            // Delete an analyzer
            await client.DeleteAnalyzerAsync(analyzerId);
            Console.WriteLine($"Analyzer '{analyzerId}' deleted successfully.");
            #else
            // Delete an analyzer
            await client.DeleteAnalyzerAsync(analyzerId);
            Console.WriteLine($"Analyzer '{analyzerId}' deleted successfully.");
            #endif
            #endregion

            #region Assertion:ContentUnderstandingDeleteAnalyzer
            Console.WriteLine($"Attempting to verify deletion of analyzer '{analyzerId}'.. .");

            // Verify the analyzer was deleted by trying to get it
            bool deletionVerified = false;
            int?  statusCode = null;
            string? errorMessage = null;

            try
            {
                var deletedResponse = await client.GetAnalyzerAsync(analyzerId);

                // If we reach here, the call succeeded which is unexpected
                Console.WriteLine($"⚠️ Unexpected: Get analyzer call succeeded after deletion");
                Console.WriteLine($"  Response status: {deletedResponse.GetRawResponse().Status}");
                Console.WriteLine($"  Analyzer exists: {deletedResponse.HasValue}");

                if (deletedResponse.HasValue && deletedResponse.Value != null)
                {
                    Console.WriteLine($"  Analyzer ID: {deletedResponse.Value.AnalyzerId ??  "(null)"}");
                    Console.WriteLine($"  Description: {deletedResponse.Value.Description ?? "(null)"}");
                }

                Assert.Fail($"Expected RequestFailedException when getting deleted analyzer '{analyzerId}', but call succeeded with status {deletedResponse.GetRawResponse().Status}");
            }
            catch (RequestFailedException ex)
            {
                // Expected exception - analyzer should not exist
                deletionVerified = true;
                statusCode = ex.Status;
                errorMessage = ex.Message;

                Console.WriteLine($"RequestFailedException caught as expected");
                Console.WriteLine($"  Status code: {ex.Status}");
                Console.WriteLine($"  Error code: {ex.ErrorCode ??  "(none)"}");
                Console.WriteLine($"  Message: {ex.Message}");

                // Verify status code is 404 (Not Found) or 400 (Bad Request)
                Assert.IsTrue(ex.Status == 404 || ex.Status == 400,
                    $"Expected 404 (Not Found) or 400 (Bad Request) status code for deleted analyzer, but got {ex.Status}");

                // Verify error message contains relevant information
                Assert.IsFalse(string.IsNullOrWhiteSpace(ex.Message),
                    "Error message should not be empty");

                if (ex.Status == 404)
                {
                    Console.WriteLine("Status 404 (Not Found) confirms analyzer was deleted");
                }
                else if (ex.Status == 400)
                {
                    Console.WriteLine("Status 400 (Bad Request) confirms analyzer does not exist");
                }
            }
            catch (Exception ex)
            {
                // Unexpected exception type
                Console.WriteLine($"❌ Unexpected exception type: {ex.GetType().Name}");
                Console.WriteLine($"  Message: {ex.Message}");
                Console.WriteLine($"  Stack trace: {ex.StackTrace}");

                Assert.Fail($"Expected RequestFailedException when getting deleted analyzer, but got {ex.GetType().Name}: {ex.Message}");
            }

            // Final verification
            Assert.IsTrue(deletionVerified, "Deletion should be verified by catching RequestFailedException");
            Assert.IsNotNull(statusCode, "Status code should be captured");
            Assert.IsTrue(statusCode == 404 || statusCode == 400,
                $"Status code should be 404 or 400, but was {statusCode}");

            Console.WriteLine($"\nDeletion verification completed successfully:");
            Console.WriteLine($"  Analyzer ID: {analyzerId}");
            Console.WriteLine($"  Deletion verified: Yes");
            Console.WriteLine($"  Verification method: RequestFailedException with status {statusCode}");
            Console.WriteLine($"  Status code: {statusCode} ({(statusCode == 404 ? "Not Found" : "Bad Request")})");

            // Additional verification: Try to list analyzers and ensure deleted one is not present
            Console.WriteLine($"\nAdditional verification: Checking analyzer list.. .");
            var allAnalyzers = new List<ContentAnalyzer>();
            await foreach (var a in client.GetAnalyzersAsync())
            {
                allAnalyzers.Add(a);
            }

            var deletedAnalyzerInList = allAnalyzers.Find(a => a.AnalyzerId == analyzerId);
            Assert.IsNull(deletedAnalyzerInList,
                $"Deleted analyzer '{analyzerId}' should not appear in the list of analyzers");

            if (deletedAnalyzerInList == null)
            {
                Console.WriteLine($"Confirmed: Analyzer '{analyzerId}' not found in list of {allAnalyzers.Count} analyzer(s)");
            }
            else
            {
                Console.WriteLine($"❌ Warning: Deleted analyzer '{analyzerId}' still appears in list");
                Console.WriteLine($"  Analyzer status: {(deletedAnalyzerInList.Status != null ? deletedAnalyzerInList.Status.ToString() : "(none)")}");
                Console.WriteLine($"  This may indicate eventual consistency delay");
            }

            Console.WriteLine($"All deletion verifications passed for analyzer '{analyzerId}'");
            #endregion
        }
    }
}
