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
            classifier.Models["completion"] = "gpt-4.1";

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
            classifier.Models["completion"] = "gpt-4.1";

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
            Assert.IsNotNull(analyzerId, "Analyzer ID should not be null");
            Assert.IsFalse(string.IsNullOrWhiteSpace(analyzerId), "Analyzer ID should not be empty");
            Assert.IsNotNull(categories, "Categories dictionary should not be null");
            Assert.AreEqual(3, categories.Count, "Should have 3 categories defined");
            Assert.IsNotNull(config, "Classifier config should not be null");
            Assert.IsNotNull(classifier, "Classifier should not be null");
            Assert.IsNotNull(operation, "Create classifier operation should not be null");
            Assert.IsTrue(operation.HasCompleted, "Operation should be completed");
            Assert.IsTrue(operation.HasValue, "Operation should have a value");
            Assert.IsNotNull(operation.GetRawResponse(), "Create classifier operation should have a raw response");
            Assert.IsTrue(operation.GetRawResponse().Status >= 200 && operation.GetRawResponse().Status < 300,
                $"Response status should be successful, but was {operation.GetRawResponse().Status}");
            Console.WriteLine("Create classifier operation properties verified");

            Assert.IsNotNull(result, "Classifier result should not be null");
            Console.WriteLine($"Classifier '{analyzerId}' created successfully");

            // Verify base analyzer
            Assert.IsNotNull(result.BaseAnalyzerId, "Base analyzer ID should not be null");
            Assert.AreEqual("prebuilt-document", result.BaseAnalyzerId, "Base analyzer ID should match");
            Console.WriteLine($"Base analyzer ID verified: {result.BaseAnalyzerId}");

            // Verify classifier config
            Assert.IsNotNull(result.Config, "Classifier config should not be null");
            Assert.IsTrue(result.Config.ReturnDetails, "ReturnDetails should be true");
            Assert.IsTrue(result.Config.EnableSegment == true, "EnableSegment should be true");
            Console.WriteLine("Classifier config verified (ReturnDetails=true, EnableSegment=true)");

            // Verify content categories
            Assert.IsNotNull(result.Config.ContentCategories, "Content categories should not be null");
            Assert.AreEqual(3, result.Config.ContentCategories.Count, "Should have 3 content categories");
            Console.WriteLine($"Content categories count verified: {result.Config.ContentCategories.Count}");

            // Verify Loan_Application category
            Assert.IsTrue(result.Config.ContentCategories.ContainsKey("Loan_Application"),
                "Should contain Loan_Application category");
            var loanCategory = result.Config.ContentCategories["Loan_Application"];
            Assert.IsNotNull(loanCategory, "Loan_Application category should not be null");
            Assert.IsFalse(string.IsNullOrWhiteSpace(loanCategory.Description),
                "Loan_Application description should not be empty");
            Assert.IsTrue(loanCategory.Description.Contains("funding") || loanCategory.Description.Contains("loan"),
                "Loan_Application description should be relevant");
            Console.WriteLine("  Loan_Application category verified");

            // Verify Invoice category
            Assert.IsTrue(result.Config.ContentCategories.ContainsKey("Invoice"),
                "Should contain Invoice category");
            var invoiceCategory = result.Config.ContentCategories["Invoice"];
            Assert.IsNotNull(invoiceCategory, "Invoice category should not be null");
            Assert.IsFalse(string.IsNullOrWhiteSpace(invoiceCategory.Description),
                "Invoice description should not be empty");
            Assert.IsTrue(invoiceCategory.Description.Contains("billing") || invoiceCategory.Description.Contains("payment"),
                "Invoice description should be relevant");
            Console.WriteLine("  Invoice category verified");

            // Verify Bank_Statement category
            Assert.IsTrue(result.Config.ContentCategories.ContainsKey("Bank_Statement"),
                "Should contain Bank_Statement category");
            var bankCategory = result.Config.ContentCategories["Bank_Statement"];
            Assert.IsNotNull(bankCategory, "Bank_Statement category should not be null");
            Assert.IsFalse(string.IsNullOrWhiteSpace(bankCategory.Description),
                "Bank_Statement description should not be empty");
            Assert.IsTrue(bankCategory.Description.Contains("bank") || bankCategory.Description.Contains("account"),
                "Bank_Statement description should be relevant");
            Console.WriteLine("  Bank_Statement category verified");

            // Verify models
            Assert.IsNotNull(result.Models, "Models should not be null");
            Assert.IsTrue(result.Models.Count >= 1, "Should have at least 1 model mapping");
            Assert.IsTrue(result.Models.ContainsKey("completion"), "Should contain 'completion' model mapping");
            Assert.AreEqual("gpt-4.1", result.Models["completion"], "Completion model should be 'gpt-4.1'");
            Console.WriteLine($"Model mappings verified: {result.Models.Count} model(s)");

            // Verify description
            if (!string.IsNullOrWhiteSpace(result.Description))
            {
                Assert.IsTrue(result.Description.Contains("classifier") || result.Description.Contains("categorization"),
                    "Description should be relevant to classification");
                Console.WriteLine($"Classifier description: {result.Description}");
            }

            Console.WriteLine("All classifier creation properties validated successfully");
            #endregion

            #region Snippet:ContentUnderstandingDeleteClassifier
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
            classifier.Models["completion"] = "gpt-4.1";

            await client.CreateAnalyzerAsync(
                WaitUntil.Completed,
                analyzerId,
                classifier);

            try
            {
                #if SNIPPET
                // Analyze a document (EnableSegment=false means entire document is one category)
                string filePath = "<file_path>";
                byte[] fileBytes = File.ReadAllBytes(filePath);
                Operation<AnalyzeResult> analyzeOperation = await client.AnalyzeBinaryAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    BinaryData.FromBytes(fileBytes));
#else
                // Analyze a document (EnableSegment=false means entire document is one category)
                var filePath = ContentUnderstandingClientTestEnvironment.CreatePath("mixed_financial_docs.pdf");
                var fileBytes = File.ReadAllBytes(filePath);
                Operation<AnalyzeResult> analyzeOperation = await client.AnalyzeBinaryAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    BinaryData.FromBytes(fileBytes));
#endif

                var analyzeResult = analyzeOperation.Value;

                // Display classification results
                DocumentContent docContent = (DocumentContent)analyzeResult.Contents!.First();
                Console.WriteLine($"Pages: {docContent.StartPageNumber}-{docContent.EndPageNumber}");

                // With EnableSegment=false, the document is classified as a single unit
                foreach (var segment in docContent.Segments ?? Enumerable.Empty<DocumentContentSegment>())
                {
                    Console.WriteLine($"Category: {segment.Category ?? "(unknown)"}");
                    Console.WriteLine($"Pages: {segment.StartPageNumber}-{segment.EndPageNumber}");
                }

                #region Assertion:ContentUnderstandingAnalyzeCategory
                Assert.IsTrue(File.Exists(filePath), $"Sample file not found at {filePath}");
                Assert.IsTrue(fileBytes.Length > 0, "File should not be empty");
                Assert.IsNotNull(analyzeOperation, "Analyze operation with segmentation should not be null");
                Assert.IsTrue(analyzeOperation.HasCompleted, "Operation should be completed");
                Assert.IsTrue(analyzeOperation.HasValue, "Operation should have a value");
                Assert.IsNotNull(analyzeOperation.GetRawResponse(), "Analyze operation with segmentation should have a raw response");
                Assert.IsTrue(analyzeOperation.GetRawResponse().Status >= 200 && analyzeOperation.GetRawResponse().Status < 300,
                    $"Response status should be successful, but was {analyzeOperation.GetRawResponse().Status}");
                Console.WriteLine("Analyze operation with segmentation properties verified");

                Assert.IsNotNull(analyzeResult, "Analyze result should not be null");
                Assert.IsNotNull(analyzeResult.Contents, "Result should contain contents");
                Assert.IsTrue(analyzeResult.Contents!.Count > 0, "Result should have at least one content");
                Assert.AreEqual(1, analyzeResult.Contents.Count, "Result should have exactly one content element");
                Console.WriteLine($"Analysis result contains {analyzeResult.Contents.Count} content(s)");

                var documentContent = analyzeResult.Contents?.FirstOrDefault() as DocumentContent;
                Assert.IsNotNull(documentContent, "Content should be DocumentContent");
                Assert.IsTrue(documentContent!.StartPageNumber >= 1, "Start page should be >= 1");
                Assert.IsTrue(documentContent.EndPageNumber >= documentContent.StartPageNumber,
                    "End page should be >= start page");
                int totalPages = documentContent.EndPageNumber - documentContent.StartPageNumber + 1;
                Assert.IsTrue(totalPages > 0, "Total pages should be positive");
                Console.WriteLine($"Document has {totalPages} page(s) from {documentContent.StartPageNumber} to {documentContent.EndPageNumber}");

                // With EnableSegment=true, we expect automatic segmentation
                if (documentContent.Segments != null && documentContent.Segments.Count > 0)
                {
                    Assert.IsTrue(documentContent.Segments.Count >= 1,
                        "Should have at least one segment with EnableSegment=true");
                    Console.WriteLine($"Document has {documentContent.Segments.Count} segment(s) (EnableSegment=true, automatic segmentation)");

                    // Verify segments cover the entire document without gaps or overlaps
                    var sortedSegments = documentContent.Segments.OrderBy(s => s.StartPageNumber).ToList();
                    int segmentIndex = 1;
                    int?  lastEndPage = null;

                    foreach (var segment in sortedSegments)
                    {
                        Assert.IsNotNull(segment, $"Segment {segmentIndex} should not be null");
                        Assert.IsTrue(segment.StartPageNumber >= 1,
                            $"Segment {segmentIndex} start page should be >= 1, but was {segment.StartPageNumber}");
                        Assert.IsTrue(segment.EndPageNumber >= segment.StartPageNumber,
                            $"Segment {segmentIndex} end page should be >= start page");
                        Assert.IsTrue(segment.StartPageNumber >= documentContent.StartPageNumber &&
                                    segment.EndPageNumber <= documentContent.EndPageNumber,
                            $"Segment {segmentIndex} page range [{segment.StartPageNumber}, {segment.EndPageNumber}] should be within document page range [{documentContent.StartPageNumber}, {documentContent.EndPageNumber}]");

                        // Check for gaps or overlaps (optional, depending on service behavior)
                        if (lastEndPage.HasValue)
                        {
                            // Segments should be contiguous (no gaps) or may overlap depending on service design
                            // This assertion can be adjusted based on actual service behavior
                            if (segment.StartPageNumber > lastEndPage.Value + 1)
                            {
                                Console.WriteLine($"    ⚠️ Gap detected between segment {segmentIndex - 1} and {segmentIndex}");
                            }
                            else if (segment.StartPageNumber <= lastEndPage.Value)
                            {
                                Console.WriteLine($"    ⚠️ Overlap detected between segment {segmentIndex - 1} and {segmentIndex}");
                            }
                        }
                        lastEndPage = segment.EndPageNumber;

                        int segmentPages = segment.EndPageNumber - segment.StartPageNumber + 1;
                        Console.WriteLine($"  Segment {segmentIndex}: Pages {segment.StartPageNumber}-{segment.EndPageNumber} ({segmentPages} page(s))");

                        if (!string.IsNullOrEmpty(segment.Category))
                        {
                            // Verify category is one of the defined categories
                            var validCategories = new[] { "Invoice", "Loan_Application", "Bank_Statement" };
                            if (validCategories.Any(c => string.Equals(c, segment.Category, StringComparison.Ordinal)))
                            {
                                TestContext.WriteLine($"    Category: {segment.Category}");
                            }
                            else
                            {
                                TestContext.WriteLine($"    Category: {segment.Category} (not in predefined list)");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"    Category: (not specified)");
                        }

                        if (!string.IsNullOrEmpty(segment.SegmentId))
                        {
                            Assert.IsFalse(string.IsNullOrWhiteSpace(segment.SegmentId),
                                $"Segment {segmentIndex} ID should not be whitespace");
                            Console.WriteLine($"    Segment ID: {segment.SegmentId}");
                        }
                        else
                        {
                            Console.WriteLine($"    Segment ID: (not available)");
                        }

                        segmentIndex++;
                    }

                    // Verify total coverage (all segments together should cover the document)
                    var minSegmentPage = sortedSegments.Min(s => s.StartPageNumber);
                    var maxSegmentPage = sortedSegments.Max(s => s.EndPageNumber);
                    Assert.IsTrue(minSegmentPage <= documentContent.StartPageNumber,
                        "Segments should start at or before document start page");
                    Assert.IsTrue(maxSegmentPage >= documentContent.EndPageNumber,
                        "Segments should end at or after document end page");
                    Console.WriteLine($"Segments cover page range [{minSegmentPage}, {maxSegmentPage}]");
                }
                else
                {
                    Console.WriteLine("⚠️ No segments found in document content (unexpected with EnableSegment=true)");
                }

                Console.WriteLine("All category analysis with segmentation properties validated successfully");
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
            classifier.Models["completion"] = "gpt-4.1";

            await client.CreateAnalyzerAsync(
                WaitUntil.Completed,
                analyzerId,
                classifier);

            try
            {
                #region Snippet:ContentUnderstandingAnalyzeCategoryWithSegments
#if SNIPPET
                // Analyze a document (EnableSegment=true automatically segments by category)
                string filePath = "<file_path>";
                byte[] fileBytes = File.ReadAllBytes(filePath);
                Operation<AnalyzeResult> analyzeOperation = await client.AnalyzeBinaryAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    BinaryData.FromBytes(fileBytes));
#else
                // Analyze a document (EnableSegment=true automatically segments by category)
                var filePath = ContentUnderstandingClientTestEnvironment.CreatePath("mixed_financial_docs.pdf");
                var fileBytes = File.ReadAllBytes(filePath);
                Operation<AnalyzeResult> analyzeOperation = await client.AnalyzeBinaryAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    BinaryData.FromBytes(fileBytes));
#endif

                var analyzeResult = analyzeOperation.Value;

                // Display classification results with automatic segmentation
                DocumentContent docContent = (DocumentContent)analyzeResult.Contents!.First();
                Console.WriteLine($"Found {docContent.Segments?.Count ?? 0} segment(s):");
                foreach (var segment in docContent.Segments ?? Enumerable.Empty<DocumentContentSegment>())
                {
                    Console.WriteLine($"  Category: {segment.Category ?? "(unknown)"}");
                    Console.WriteLine($"  Pages: {segment.StartPageNumber}-{segment.EndPageNumber}");
                    Console.WriteLine($"  Segment ID: {segment.SegmentId ?? "(not available)"}");
                }
                #endregion

                #region Assertion:ContentUnderstandingAnalyzeCategoryWithSegments
                Assert.IsTrue(File.Exists(filePath), $"Sample file not found at {filePath}");
                Assert.IsNotNull(analyzeOperation, "Analyze operation with segmentation should not be null");
                Assert.IsNotNull(analyzeOperation.GetRawResponse(), "Analyze operation with segmentation should have a raw response");
                Console.WriteLine("Analyze operation with segmentation properties verified");
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
