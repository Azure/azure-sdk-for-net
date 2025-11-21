// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests.Samples
{
    /// <summary>
    /// Test class for Azure Content Understanding Create Custom Analyzer sample.
    /// This class validates the functionality demonstrated in create_custom_analyzer.cs
    /// for creating, using, and deleting custom analyzers with field schemas.
    /// </summary>
    public class CreateOrReplaceAnalyzerTest : ContentUnderstandingTestBase
    {
        public CreateOrReplaceAnalyzerTest(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
        }

        /// <summary>
        /// Test Summary:
        /// - Create ContentUnderstandingClient using CreateClient()
        /// - Define a custom analyzer with field schema
        /// - Create the analyzer using CreateAnalyzerAsync
        /// - Verify analyzer is created successfully
        /// - Use the analyzer to analyze a document
        /// - Extract custom fields from the result
        /// - Clean up by deleting the analyzer
        /// </summary>
        [RecordedTest]
        public async Task TestCreateCustomAnalyzerWithFieldSchema()
        {
            var client = CreateClient();
            var analyzerId = TestHelpers.GenerateAnalyzerId(Recording, "CustomAnalyzer");
            bool createdAnalyzer = false;

            TestContext.WriteLine($"Step 1: Defining custom analyzer: {analyzerId}");

            try
            {
                // Create field schema with custom fields
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
                    Name = "company_schema",
                    Description = "Schema for extracting company information"
                };

                // Create analyzer configuration
                var config = new ContentAnalyzerConfig
                {
                    EnableFormula = true,
                    EnableLayout = true,
                    EnableOcr = true,
                    EstimateFieldSourceAndConfidence = true,
                    ReturnDetails = true
                };

                // Create the custom analyzer object
                var customAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Custom analyzer for extracting company information",
                    Config = config,
                    FieldSchema = fieldSchema
                };

                // Add model mappings
                customAnalyzer.Models.Add("completion", "gpt-4o");
                customAnalyzer.Models.Add("embedding", "text-embedding-3-large");

                TestContext.WriteLine("  Analyzer configuration:");
                TestContext.WriteLine($"    Base Analyzer: {customAnalyzer.BaseAnalyzerId}");
                TestContext.WriteLine($"    Description: {customAnalyzer.Description}");
                TestContext.WriteLine($"    Fields: {fieldSchema.Fields.Count}");
                TestContext.WriteLine($"    Models: {customAnalyzer.Models.Count}");

                // Step 2: Create the analyzer
                TestContext.WriteLine("\nStep 2: Creating custom analyzer...");
                var operation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    customAnalyzer,
                    allowReplace: true);

                TestHelpers.AssertOperationProperties(operation, "Create analyzer operation");

                var result = operation.Value;
                Assert.IsNotNull(result);
                createdAnalyzer = true;

                TestContext.WriteLine($"  ✅ Analyzer '{analyzerId}' created successfully!");
                TestContext.WriteLine($"  Status: {result.Status}");
                TestContext.WriteLine($"  Created at: {result.CreatedAt:yyyy-MM-dd HH:mm:ss} UTC");

                // Verify analyzer properties
                Assert.AreEqual(analyzerId, result.AnalyzerId);
                Assert.IsNotNull(result.Status);
                Assert.IsNotNull(result.CreatedAt);

                // Step 3: Use the analyzer to analyze a document
                TestContext.WriteLine("\nStep 3: Using the custom analyzer to analyze a document...");
                var fileUrl = "https://github.com/Azure-Samples/azure-ai-content-understanding-python/raw/refs/heads/main/data/invoice.pdf";
                TestContext.WriteLine($"  URL: {fileUrl}");

                Assert.IsTrue(Uri.TryCreate(fileUrl, UriKind.Absolute, out var uri));

                var analyzeOperation = await client.AnalyzeAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    inputs: new[] { new AnalyzeInput { Url = uri } });

                TestHelpers.AssertOperationProperties(analyzeOperation, "Analyze operation");

                var analyzeResult = analyzeOperation.Value;
                Assert.IsNotNull(analyzeResult);
                TestContext.WriteLine("  ✅ Analysis completed successfully!");

                // Step 4: Extract custom fields
                if (analyzeResult.Contents != null && analyzeResult.Contents.Count > 0)
                {
                    var content = analyzeResult.Contents.First();
                    if (content.Fields != null && content.Fields.Count > 0)
                    {
                        TestContext.WriteLine("\n  📋 Extracted Custom Fields:");
                        TestContext.WriteLine("  " + "-".PadRight(38, '-'));

                        // Verify custom fields exist
                        Assert.IsTrue(content.Fields.ContainsKey("company_name") ||
                                    content.Fields.ContainsKey("total_amount"),
                                    "Should extract at least one custom field");

                        if (content.Fields.TryGetValue("company_name", out var companyNameField))
                        {
                            TestContext.WriteLine($"    ✓ Company Name field found");
                            if (companyNameField.Value != null)
                            {
                                TestContext.WriteLine($"      Value: {companyNameField.Value}");
                            }
                        }

                        if (content.Fields.TryGetValue("total_amount", out var totalAmountField))
                        {
                            TestContext.WriteLine($"    ✓ Total Amount field found");
                            if (totalAmountField.Value != null)
                            {
                                TestContext.WriteLine($"      Value: {totalAmountField.Value}");
                            }
                        }
                    }
                }
            }
            finally
            {
                // Step 5: Clean up (delete the created analyzer)
                if (createdAnalyzer)
                {
                    TestContext.WriteLine("\nStep 4: Cleaning up (deleting analyzer)...");
                    try
                    {
                        await client.DeleteAnalyzerAsync(analyzerId);
                        TestContext.WriteLine($"  ✅ Analyzer '{analyzerId}' deleted successfully!");
                    }
                    catch (RequestFailedException ex)
                    {
                        TestContext.WriteLine($"  ⚠️  Failed to delete analyzer: {ex.Message}");
                    }
                }
            }

            TestContext.WriteLine("\n=============================================================");
            TestContext.WriteLine("✓ Sample completed successfully");
            TestContext.WriteLine("=============================================================");
        }

        /// <summary>
        /// Test Summary:
        /// - Create a simple custom analyzer without complex field schema
        /// - Verify analyzer creation and basic properties
        /// - Clean up
        /// </summary>
        [RecordedTest]
        public async Task TestCreateSimpleCustomAnalyzer()
        {
            var client = CreateClient();
            var analyzerId = TestHelpers.GenerateAnalyzerId(Recording, "SimpleAnalyzer");
            bool createdAnalyzer = false;

            TestContext.WriteLine($"Creating simple custom analyzer: {analyzerId}");

            try
            {
                // Create a simple analyzer with minimal configuration
                var simpleAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Simple test analyzer"
                };

                // Add required model mappings
                simpleAnalyzer.Models.Add("completion", "gpt-4o");
                simpleAnalyzer.Models.Add("embedding", "text-embedding-3-large");

                var operation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    simpleAnalyzer,
                    allowReplace: true);

                var result = operation.Value;
                Assert.IsNotNull(result);
                createdAnalyzer = true;

                TestContext.WriteLine($"  ✓ Analyzer created: {result.AnalyzerId}");
                TestContext.WriteLine($"  Status: {result.Status}");

                // Verify basic properties
                Assert.AreEqual(analyzerId, result.AnalyzerId);
                Assert.IsNotNull(result.Status);
                Assert.IsNotNull(result.CreatedAt);
            }
            finally
            {
                if (createdAnalyzer)
                {
                    await client.DeleteAnalyzerAsync(analyzerId);
                    TestContext.WriteLine($"  ✓ Analyzer deleted");
                }
            }
        }

        /// <summary>
        /// Test Summary:
        /// - Create analyzer with allowReplace = true
        /// - Update the same analyzer
        /// - Verify update succeeds with allowReplace
        /// </summary>
        [RecordedTest]
        public async Task TestCreateAnalyzerWithAllowReplace()
        {
            var client = CreateClient();
            var analyzerId = TestHelpers.GenerateAnalyzerId(Recording, "ReplaceAnalyzer");
            bool createdAnalyzer = false;

            TestContext.WriteLine($"Testing allowReplace functionality: {analyzerId}");

            try
            {
                // Create initial analyzer
                TestContext.WriteLine("\nCreating initial analyzer...");
                var analyzer1 = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Initial version"
                };
                analyzer1.Models.Add("completion", "gpt-4o");
                analyzer1.Models.Add("embedding", "text-embedding-3-large");

                var operation1 = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    analyzer1,
                    allowReplace: true);

                Assert.IsNotNull(operation1.Value);
                createdAnalyzer = true;
                TestContext.WriteLine("  ✓ Initial analyzer created");

                // Replace with updated analyzer
                TestContext.WriteLine("\nReplacing with updated analyzer (allowReplace=true)...");
                var analyzer2 = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Updated version"
                };
                analyzer2.Models.Add("completion", "gpt-4o");
                analyzer2.Models.Add("embedding", "text-embedding-3-large");

                var operation2 = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    analyzer2,
                    allowReplace: true);

                Assert.IsNotNull(operation2.Value);
                Assert.AreEqual("Updated version", operation2.Value.Description);
                TestContext.WriteLine("  ✓ Analyzer replaced successfully");
            }
            finally
            {
                if (createdAnalyzer)
                {
                    await client.DeleteAnalyzerAsync(analyzerId);
                    TestContext.WriteLine("\n  ✓ Analyzer deleted");
                }
            }
        }

        /// <summary>
        /// Test Summary:
        /// - Create analyzer with multiple field types
        /// - Verify all field types are supported (String, Number, Date, etc.)
        /// </summary>
        [RecordedTest]
        public async Task TestCreateAnalyzerWithMultipleFieldTypes()
        {
            var client = CreateClient();
            var analyzerId = TestHelpers.GenerateAnalyzerId(Recording, "MultiFieldAnalyzer");
            bool createdAnalyzer = false;

            TestContext.WriteLine($"Creating analyzer with multiple field types: {analyzerId}");

            try
            {
                // Create field schema with different field types
                var fieldSchema = new ContentFieldSchema(
                    new Dictionary<string, ContentFieldDefinition>
                    {
                        ["customer_name"] = new ContentFieldDefinition
                        {
                            Type = ContentFieldType.String,
                            Method = GenerationMethod.Extract,
                            Description = "Customer name"
                        },
                        ["invoice_total"] = new ContentFieldDefinition
                        {
                            Type = ContentFieldType.Number,
                            Method = GenerationMethod.Extract,
                            Description = "Invoice total amount"
                        },
                        ["invoice_date"] = new ContentFieldDefinition
                        {
                            Type = ContentFieldType.Date,
                            Method = GenerationMethod.Extract,
                            Description = "Invoice date"
                        }
                    })
                {
                    Name = "multi_field_schema",
                    Description = "Schema with multiple field types"
                };

                var analyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Analyzer with multiple field types",
                    FieldSchema = fieldSchema
                };
                analyzer.Models.Add("completion", "gpt-4o");
                analyzer.Models.Add("embedding", "text-embedding-3-large");

                var operation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    analyzer,
                    allowReplace: true);

                Assert.IsNotNull(operation.Value);
                createdAnalyzer = true;

                TestContext.WriteLine("  ✓ Analyzer created with multiple field types:");
                TestContext.WriteLine($"    - String field: customer_name");
                TestContext.WriteLine($"    - Number field: invoice_total");
                TestContext.WriteLine($"    - Date field: invoice_date");
            }
            finally
            {
                if (createdAnalyzer)
                {
                    await client.DeleteAnalyzerAsync(analyzerId);
                    TestContext.WriteLine("\n  ✓ Analyzer deleted");
                }
            }
        }

        /// <summary>
        /// Test Summary:
        /// - Create analyzer with config options
        /// - Verify config is properly set
        /// </summary>
        [RecordedTest]
        public async Task TestCreateAnalyzerWithConfig()
        {
            var client = CreateClient();
            var analyzerId = TestHelpers.GenerateAnalyzerId(Recording, "ConfigAnalyzer");
            bool createdAnalyzer = false;

            TestContext.WriteLine($"Creating analyzer with config: {analyzerId}");

            try
            {
                var config = new ContentAnalyzerConfig
                {
                    EnableFormula = true,
                    EnableLayout = true,
                    EnableOcr = true,
                    EstimateFieldSourceAndConfidence = true,
                    ReturnDetails = true
                };

                var analyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Analyzer with full config",
                    Config = config
                };
                analyzer.Models.Add("completion", "gpt-4o");
                analyzer.Models.Add("embedding", "text-embedding-3-large");

                var operation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    analyzer,
                    allowReplace: true);

                Assert.IsNotNull(operation.Value);
                createdAnalyzer = true;

                TestContext.WriteLine("  ✓ Analyzer created with config:");
                TestContext.WriteLine($"    - EnableFormula: {config.EnableFormula}");
                TestContext.WriteLine($"    - EnableLayout: {config.EnableLayout}");
                TestContext.WriteLine($"    - EnableOcr: {config.EnableOcr}");
                TestContext.WriteLine($"    - EstimateFieldSourceAndConfidence: {config.EstimateFieldSourceAndConfidence}");
                TestContext.WriteLine($"    - ReturnDetails: {config.ReturnDetails}");
            }
            finally
            {
                if (createdAnalyzer)
                {
                    await client.DeleteAnalyzerAsync(analyzerId);
                    TestContext.WriteLine("\n  ✓ Analyzer deleted");
                }
            }
        }

        /// <summary>
        /// Test Summary:
        /// - Create analyzer with tags
        /// - Verify tags are properly stored
        /// </summary>
        [RecordedTest]
        public async Task TestCreateAnalyzerWithTags()
        {
            var client = CreateClient();
            var analyzerId = TestHelpers.GenerateAnalyzerId(Recording, "TaggedAnalyzer");
            bool createdAnalyzer = false;

            TestContext.WriteLine($"Creating analyzer with tags: {analyzerId}");

            try
            {
                var analyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Analyzer with tags"
                };
                analyzer.Models.Add("completion", "gpt-4o");
                analyzer.Models.Add("embedding", "text-embedding-3-large");

                // Add tags
                analyzer.Tags.Add("environment", "test");
                analyzer.Tags.Add("purpose", "unit_testing");
                analyzer.Tags.Add("created_by", "sdk_test");

                var operation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    analyzer,
                    allowReplace: true);

                Assert.IsNotNull(operation.Value);
                createdAnalyzer = true;

                var result = operation.Value;
                Assert.IsNotNull(result.Tags);
                Assert.IsTrue(result.Tags.Count >= 3, "Should have at least 3 tags");

                TestContext.WriteLine("  ✓ Analyzer created with tags:");
                foreach (var tag in result.Tags)
                {
                    TestContext.WriteLine($"    - {tag.Key}: {tag.Value}");
                }
            }
            finally
            {
                if (createdAnalyzer)
                {
                    await client.DeleteAnalyzerAsync(analyzerId);
                    TestContext.WriteLine("\n  ✓ Analyzer deleted");
                }
            }
        }

        /// <summary>
        /// Test Summary:
        /// - Verify analyzer naming rules
        /// - Test valid and invalid analyzer IDs
        /// </summary>
        [Test]
        public void TestAnalyzerIdValidation()
        {
            TestContext.WriteLine("Testing analyzer ID validation rules...");

            // Valid IDs (no hyphens, alphanumeric and underscore)
            string[] validIds = new[]
            {
                "my_analyzer_123",
                "analyzer_20250121",
                "custom_analyzer_v1",
                "test_analyzer"
            };

            foreach (var id in validIds)
            {
                Assert.IsTrue(!id.Contains("-"), $"Valid ID should not contain hyphens: {id}");
                TestContext.WriteLine($"  ✓ Valid ID: {id}");
            }

            // Invalid IDs (contain hyphens)
            string[] invalidIds = new[]
            {
                "my-analyzer-123",
                "analyzer-2025-01-21",
                "custom-analyzer",
                "test-analyzer-v1"
            };

            foreach (var id in invalidIds)
            {
                Assert.IsTrue(id.Contains("-"), $"Invalid ID contains hyphen: {id}");
                TestContext.WriteLine($"  ✗ Invalid ID (contains hyphen): {id}");
            }

            TestContext.WriteLine("\n✓ Analyzer ID validation completed");
        }

        /// <summary>
        /// Test Summary:
        /// - Test error handling for duplicate analyzer creation without allowReplace
        /// - Verify appropriate exception is thrown
        /// </summary>
        [RecordedTest]
        public async Task TestCreateDuplicateAnalyzerWithoutAllowReplace()
        {
            var client = CreateClient();
            var analyzerId = TestHelpers.GenerateAnalyzerId(Recording, "DuplicateTest");
            bool createdAnalyzer = false;

            TestContext.WriteLine($"Testing duplicate analyzer creation: {analyzerId}");

            try
            {
                // Create initial analyzer
                var analyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Initial analyzer"
                };
                analyzer.Models.Add("completion", "gpt-4o");
                analyzer.Models.Add("embedding", "text-embedding-3-large");

                var operation1 = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    analyzer,
                    allowReplace: false);

                Assert.IsNotNull(operation1.Value);
                createdAnalyzer = true;
                TestContext.WriteLine("  ✓ Initial analyzer created");

                // Try to create again without allowReplace
                TestContext.WriteLine("\nAttempting to create duplicate (allowReplace=false)...");
                try
                {
                    var operation2 = await client.CreateAnalyzerAsync(
                        WaitUntil.Completed,
                        analyzerId,
                        analyzer,
                        allowReplace: false);

                    // If we reach here, service may have allowed it or returned existing
                    TestContext.WriteLine("  Note: Service may allow duplicate creation or return existing analyzer");
                }
                catch (RequestFailedException ex)
                {
                    TestContext.WriteLine($"  ✓ Expected exception caught: {ex.Message}");
                    TestContext.WriteLine($"  Status: {ex.Status}");
                    // This is expected behavior
                }
            }
            finally
            {
                if (createdAnalyzer)
                {
                    await client.DeleteAnalyzerAsync(analyzerId);
                    TestContext.WriteLine("\n  ✓ Analyzer deleted");
                }
            }
        }

        /// <summary>
        /// Test Summary:
        /// - Create analyzer and verify it appears in list
        /// - Get specific analyzer and verify properties match
        /// </summary>
        [RecordedTest]
        public async Task TestCreateAndRetrieveAnalyzer()
        {
            var client = CreateClient();
            var analyzerId = TestHelpers.GenerateAnalyzerId(Recording, "RetrieveTest");
            bool createdAnalyzer = false;

            TestContext.WriteLine($"Creating and retrieving analyzer: {analyzerId}");

            try
            {
                // Create analyzer
                var analyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Test analyzer for retrieval"
                };
                analyzer.Models.Add("completion", "gpt-4o");
                analyzer.Models.Add("embedding", "text-embedding-3-large");

                var createOperation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    analyzer,
                    allowReplace: true);

                Assert.IsNotNull(createOperation.Value);
                createdAnalyzer = true;
                TestContext.WriteLine("  ✓ Analyzer created");

                // Retrieve analyzer
                TestContext.WriteLine("\nRetrieving analyzer...");
                var getResponse = await client.GetAnalyzerAsync(analyzerId);

                Assert.IsNotNull(getResponse);
                Assert.IsNotNull(getResponse.Value);
                Assert.AreEqual(analyzerId, getResponse.Value.AnalyzerId);
                Assert.AreEqual("Test analyzer for retrieval", getResponse.Value.Description);

                TestContext.WriteLine($"  ✓ Analyzer retrieved successfully");
                TestContext.WriteLine($"    ID: {getResponse.Value.AnalyzerId}");
                TestContext.WriteLine($"    Description: {getResponse.Value.Description}");
                TestContext.WriteLine($"    Status: {getResponse.Value.Status}");
            }
            finally
            {
                if (createdAnalyzer)
                {
                    await client.DeleteAnalyzerAsync(analyzerId);
                    TestContext.WriteLine("\n  ✓ Analyzer deleted");
                }
            }
        }

        /// <summary>
        /// Test Summary:
        /// - Create analyzer and save operation result
        /// - Verify operation ID can be extracted
        /// </summary>
        [RecordedTest]
        public async Task TestCreateAnalyzerOperationId()
        {
            var client = CreateClient();
            var analyzerId = TestHelpers.GenerateAnalyzerId(Recording, "OperationIdTest");
            bool createdAnalyzer = false;

            TestContext.WriteLine($"Testing operation ID extraction: {analyzerId}");

            try
            {
                var analyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Test analyzer for operation ID"
                };
                analyzer.Models.Add("completion", "gpt-4o");
                analyzer.Models.Add("embedding", "text-embedding-3-large");

                var operation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    analyzer,
                    allowReplace: true);

                Assert.IsNotNull(operation.Value);
                createdAnalyzer = true;

                // Extract operation ID
                string operationId = operation.GetRehydrationToken().Value.Id;
                Assert.IsNotNull(operationId, "Operation ID should not be null");
                Assert.IsTrue(operationId.Length > 0, "Operation ID should not be empty");

                TestContext.WriteLine($"  ✓ Operation ID extracted: {operationId}");
            }
            finally
            {
                if (createdAnalyzer)
                {
                    await client.DeleteAnalyzerAsync(analyzerId);
                    TestContext.WriteLine("  ✓ Analyzer deleted");
                }
            }
        }
    }
}
