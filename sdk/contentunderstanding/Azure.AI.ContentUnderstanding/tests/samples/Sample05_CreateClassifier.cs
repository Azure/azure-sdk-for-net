// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.IO;
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
        public async Task CreateClassifierAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            #region Snippet:ContentUnderstandingCreateClassifier
#if SNIPPET
            // Define content categories for classification
            var categories = new Dictionary<string, ContentCategoryDefinition>
            {
                ["Loan_Application"] = new ContentCategoryDefinition
                {
                    Description = "Documents submitted by individuals or businesses to request funding, typically including personal or business details, financial history, loan amount, purpose, and supporting documentation."
                },
                ["Invoice"] = new ContentCategoryDefinition
                {
                    Description = "Billing documents issued by sellers or service providers to request payment for goods or services, detailing items, prices, taxes, totals, and payment terms."
                },
                ["Bank_Statement"] = new ContentCategoryDefinition
                {
                    Description = "Official statements issued by banks that summarize account activity over a period, including deposits, withdrawals, fees, and balances."
                }
            };

            // Create analyzer configuration
            var config = new ContentAnalyzerConfig
            {
                ReturnDetails = true,
                EnableSegment = true // Enable automatic segmentation by category
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
            string analyzerId = $"my_classifier_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
#else
            // Define content categories for classification
            var categories = new Dictionary<string, ContentCategoryDefinition>
            {
                ["Loan_Application"] = new ContentCategoryDefinition
                {
                    Description = "Documents submitted by individuals or businesses to request funding, typically including personal or business details, financial history, loan amount, purpose, and supporting documentation."
                },
                ["Invoice"] = new ContentCategoryDefinition
                {
                    Description = "Billing documents issued by sellers or service providers to request payment for goods or services, detailing items, prices, taxes, totals, and payment terms."
                },
                ["Bank_Statement"] = new ContentCategoryDefinition
                {
                    Description = "Official statements issued by banks that summarize account activity over a period, including deposits, withdrawals, fees, and balances."
                }
            };

            // Create analyzer configuration
            var config = new ContentAnalyzerConfig
            {
                ReturnDetails = true,
                EnableSegment = true // Enable automatic segmentation by category
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

            // Generate a unique analyzer ID and record it for playback
            string defaultId = $"test_classifier_{Recording.Random.NewGuid().ToString("N")}";
            string analyzerId = Recording.GetVariable("analyzerId", defaultId) ?? defaultId;
#endif
            var operation = await client.CreateAnalyzerAsync(
                WaitUntil.Completed,
                analyzerId,
                classifier);

            ContentAnalyzer result = operation.Value;
            Console.WriteLine($"Classifier '{analyzerId}' created successfully!");
            #endregion

            #region Assertion:ContentUnderstandingCreateClassifier
            Assert.IsNotNull(operation, "Create classifier operation should not be null");
            Assert.IsNotNull(operation.GetRawResponse(), "Create classifier operation should have a raw response");
            TestContext.WriteLine("✅ Create classifier operation properties verified");
            Assert.IsNotNull(result, "Classifier result should not be null");
            Assert.IsNotNull(result.BaseAnalyzerId, "Base analyzer ID should not be null");
            Assert.AreEqual("prebuilt-document", result.BaseAnalyzerId, "Base analyzer ID should match");
            Assert.IsNotNull(result.Config, "Classifier config should not be null");
            Assert.IsTrue(result.Config!.EnableSegment == true, "EnableSegment should be true");
            Assert.IsNotNull(result.Config.ContentCategories, "Content categories should not be null");
            Assert.AreEqual(3, result.Config.ContentCategories.Count, "Should have 3 content categories");
            Assert.IsTrue(result.Config.ContentCategories.ContainsKey("Loan_Application"),
                "Should contain Loan_Application category");
            Assert.IsTrue(result.Config.ContentCategories.ContainsKey("Invoice"),
                "Should contain Invoice category");
            Assert.IsTrue(result.Config.ContentCategories.ContainsKey("Bank_Statement"),
                "Should contain Bank_Statement category");
            Assert.IsNotNull(result.Models, "Models should not be null");
            Assert.IsTrue(result.Models.Count >= 1, "Should have at least 1 model mapping");
            #endregion

            #region Snippet:ContentUnderstandingDeleteAnalyzer
            // Clean up: delete the classifier (for testing purposes only)
            // In production, classifiers are typically kept and reused
#if SNIPPET
            await client.DeleteAnalyzerAsync(analyzerId);
            Console.WriteLine($"Classifier '{analyzerId}' deleted successfully.");
#else
            try
            {
                await client.DeleteAnalyzerAsync(analyzerId);
                Console.WriteLine($"Classifier '{analyzerId}' deleted successfully.");
            }
            catch
            {
                // Ignore cleanup errors in tests
            }
#endif
            #endregion
        }

        [RecordedTest]
        public async Task AnalyzeCategoryAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            // First create a classifier without segmentation
            string defaultId = $"test_classifier_{Recording.Random.NewGuid().ToString("N")}";
            string analyzerId = Recording.GetVariable("analyzerId_no_segment", defaultId) ?? defaultId;
            var config = new ContentAnalyzerConfig
            {
                ReturnDetails = true,
                EnableSegment = false // No automatic segmentation
            };
            config.ContentCategories.Add("Invoice", new ContentCategoryDefinition
            {
                Description = "Billing documents issued by sellers or service providers to request payment for goods or services."
            });

            var classifier = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-document",
                Description = "Custom classifier for financial document categorization without segmentation",
                Config = config
            };
            classifier.Models.Add("completion", "gpt-4.1");

            await client.CreateAnalyzerAsync(
                WaitUntil.Completed,
                analyzerId,
                classifier);

            try
            {
                #region Snippet:ContentUnderstandingAnalyzeCategory
#if SNIPPET
                // Analyze a document (EnableSegment=false means entire document is one category)
                var analyzeOperation = await client.AnalyzeBinaryAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    "application/pdf",
                    BinaryData.FromBytes(fileBytes));
#else
                // Analyze a document (EnableSegment=false means entire document is one category)
                var filePath = ContentUnderstandingClientTestEnvironment.CreatePath("sample_invoice.pdf");
                var fileBytes = await File.ReadAllBytesAsync(filePath);
                var analyzeOperation = await client.AnalyzeBinaryAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    "application/pdf",
                    BinaryData.FromBytes(fileBytes));
#endif

                var analyzeResult = analyzeOperation.Value;

                // Display classification results
                if (analyzeResult.Contents?.FirstOrDefault() is DocumentContent docContent)
                {
                    Console.WriteLine($"Pages: {docContent.StartPageNumber}-{docContent.EndPageNumber}");

                    // With EnableSegment=false, the document is classified as a single unit
                    if (docContent.Segments != null && docContent.Segments.Count > 0)
                    {
                        foreach (var segment in docContent.Segments)
                        {
                            Console.WriteLine($"Category: {segment.Category ?? "(unknown)"}");
                            Console.WriteLine($"Pages: {segment.StartPageNumber}-{segment.EndPageNumber}");
                        }
                    }
                }
                #endregion

                #region Assertion:ContentUnderstandingAnalyzeCategory
                Assert.IsTrue(File.Exists(filePath), $"Sample file not found at {filePath}");
                Assert.IsNotNull(analyzeOperation, "Analyze operation should not be null");
                Assert.IsNotNull(analyzeOperation.GetRawResponse(), "Analyze operation should have a raw response");
                TestContext.WriteLine("✅ Analyze operation properties verified");
                Assert.IsNotNull(analyzeResult, "Analyze result should not be null");
                Assert.IsNotNull(analyzeResult.Contents, "Result should contain contents");
                Assert.IsTrue(analyzeResult.Contents!.Count > 0, "Result should have at least one content");

                var documentContent = analyzeResult.Contents?.FirstOrDefault() as DocumentContent;
                Assert.IsNotNull(documentContent, "Content should be DocumentContent");
                Assert.IsTrue(documentContent!.StartPageNumber >= 1, "Start page should be >= 1");
                Assert.IsTrue(documentContent.EndPageNumber >= documentContent.StartPageNumber,
                    "End page should be >= start page");

                // With EnableSegment=false, we expect the document to be treated as a single segment
                if (documentContent.Segments != null && documentContent.Segments.Count > 0)
                {
                    foreach (var segment in documentContent.Segments)
                    {
                        Assert.IsTrue(segment.StartPageNumber >= 1, "Segment start page should be >= 1");
                        Assert.IsTrue(segment.EndPageNumber >= segment.StartPageNumber,
                            "Segment end page should be >= start page");
                        // Category may be null or unknown for some segments
                    }
                }
                #endregion
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

        [RecordedTest]
        public async Task AnalyzeCategoryWithSegmentsAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            // First create a classifier with segmentation
            string defaultId = $"test_classifier_{Recording.Random.NewGuid().ToString("N")}";
            string analyzerId = Recording.GetVariable("analyzerId_with_segment", defaultId) ?? defaultId;
            var config = new ContentAnalyzerConfig
            {
                ReturnDetails = true,
                EnableSegment = true // Enable automatic segmentation
            };
            config.ContentCategories.Add("Invoice", new ContentCategoryDefinition
            {
                Description = "Billing documents issued by sellers or service providers to request payment for goods or services."
            });

            var classifier = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-document",
                Description = "Custom classifier for financial document categorization with automatic segmentation",
                Config = config
            };
            classifier.Models.Add("completion", "gpt-4.1");

            await client.CreateAnalyzerAsync(
                WaitUntil.Completed,
                analyzerId,
                classifier);

            try
            {
                #region Snippet:ContentUnderstandingAnalyzeCategoryWithSegments
#if SNIPPET
                // Analyze a document (EnableSegment=true automatically segments by category)
                var analyzeOperation = await client.AnalyzeBinaryAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    "application/pdf",
                    BinaryData.FromBytes(fileBytes));
#else
                // Analyze a document (EnableSegment=true automatically segments by category)
                var filePath = ContentUnderstandingClientTestEnvironment.CreatePath("sample_invoice.pdf");
                var fileBytes = await File.ReadAllBytesAsync(filePath);
                var analyzeOperation = await client.AnalyzeBinaryAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    "application/pdf",
                    BinaryData.FromBytes(fileBytes));
#endif

                var analyzeResult = analyzeOperation.Value;

                // Display classification results with automatic segmentation
                if (analyzeResult.Contents?.FirstOrDefault() is DocumentContent docContent)
                {
                    if (docContent.Segments != null && docContent.Segments.Count > 0)
                    {
                        Console.WriteLine($"Found {docContent.Segments.Count} segment(s):");
                        foreach (var segment in docContent.Segments)
                        {
                            Console.WriteLine($"  Category: {segment.Category ?? "(unknown)"}");
                            Console.WriteLine($"  Pages: {segment.StartPageNumber}-{segment.EndPageNumber}");
                            Console.WriteLine($"  Segment ID: {segment.SegmentId ?? "(not available)"}");
                        }
                    }
                }
                #endregion

                #region Assertion:ContentUnderstandingAnalyzeCategoryWithSegments
                Assert.IsTrue(File.Exists(filePath), $"Sample file not found at {filePath}");
                Assert.IsNotNull(analyzeOperation, "Analyze operation with segmentation should not be null");
                Assert.IsNotNull(analyzeOperation.GetRawResponse(), "Analyze operation with segmentation should have a raw response");
                TestContext.WriteLine("✅ Analyze operation with segmentation properties verified");
                Assert.IsNotNull(analyzeResult, "Analyze result should not be null");
                Assert.IsNotNull(analyzeResult.Contents, "Result should contain contents");
                Assert.IsTrue(analyzeResult.Contents!.Count > 0, "Result should have at least one content");

                var documentContent = analyzeResult.Contents?.FirstOrDefault() as DocumentContent;
                Assert.IsNotNull(documentContent, "Content should be DocumentContent");

                // With EnableSegment=true, we expect automatic segmentation
                if (documentContent!.Segments != null && documentContent.Segments.Count > 0)
                {
                    Assert.IsTrue(documentContent.Segments.Count >= 1,
                        "Should have at least one segment with EnableSegment=true");

                    foreach (var segment in documentContent.Segments)
                    {
                        Assert.IsTrue(segment.StartPageNumber >= 1,
                            "Segment start page should be >= 1");
                        Assert.IsTrue(segment.EndPageNumber >= segment.StartPageNumber,
                            "Segment end page should be >= start page");
                        Assert.IsTrue(segment.StartPageNumber >= documentContent.StartPageNumber &&
                                     segment.EndPageNumber <= documentContent.EndPageNumber,
                            "Segment page range should be within document page range");

                        // SegmentId may or may not be available depending on the service response
                        // Category may be null or unknown for some segments
                    }
                }
                #endregion
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
    }
}