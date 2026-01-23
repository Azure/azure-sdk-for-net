// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
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
        public async Task CreateAnalyzerAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            #region Snippet:ContentUnderstandingCreateAnalyzer
#if SNIPPET
            // Generate a unique analyzer ID
            string analyzerId = $"my_custom_analyzer_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
#else
            // Generate a unique analyzer ID and record it for playback
            string defaultId = $"test_custom_analyzer_{Recording.Random.NewGuid().ToString("N")}";
            string analyzerId = Recording.GetVariable("analyzerId", defaultId) ?? defaultId;
#endif

            // Define field schema with custom fields
            // This example demonstrates three extraction methods:
            // - extract: Literal text extraction (requires estimateSourceAndConfidence)
            // - generate: AI-generated values based on content interpretation
            // - classify: Classification against predefined categories
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
                    },
                    ["document_summary"] = new ContentFieldDefinition
                    {
                        Type = ContentFieldType.String,
                        Method = GenerationMethod.Generate,
                        Description = "A brief summary of the document content"
                    },
                    ["document_type"] = new ContentFieldDefinition
                    {
                        Type = ContentFieldType.String,
                        Method = GenerationMethod.Classify,
                        Description = "Type of document"
                    }
                })
            {
                Name = "company_schema",
                Description = "Schema for extracting company information"
            };

            // Add enum values for the classify field
            fieldSchema.Fields["document_type"].Enum.Add("invoice");
            fieldSchema.Fields["document_type"].Enum.Add("receipt");
            fieldSchema.Fields["document_type"].Enum.Add("contract");
            fieldSchema.Fields["document_type"].Enum.Add("report");
            fieldSchema.Fields["document_type"].Enum.Add("other");

            // Create analyzer configuration
            var config = new ContentAnalyzerConfig
            {
                EnableFormula = true,
                EnableLayout = true,
                EnableOcr = true,
                EstimateFieldSourceAndConfidence = true,
                ReturnDetails = true
            };

            // Create the custom analyzer
            var customAnalyzer = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-document",
                Description = "Custom analyzer for extracting company information",
                Config = config,
                FieldSchema = fieldSchema
            };

            // Add model mappings for supported large language models (required for custom analyzers)
            // Maps model roles (completion, embedding) to specific model names
            customAnalyzer.Models["completion"] = "gpt-4.1";
            customAnalyzer.Models["embedding"] = "text-embedding-3-large";

            // Create the analyzer
            var operation = await client.CreateAnalyzerAsync(
                WaitUntil.Completed,
                analyzerId,
                customAnalyzer);

            ContentAnalyzer result = operation.Value;
            Console.WriteLine($"Analyzer '{analyzerId}' created successfully!");
            #endregion

            #region Assertion:ContentUnderstandingCreateAnalyzer
            Assert.IsNotNull(analyzerId, "Analyzer ID should not be null");
            Assert.IsFalse(string.IsNullOrWhiteSpace(analyzerId), "Analyzer ID should not be empty");
            Assert.IsNotNull(fieldSchema, "Field schema should not be null");
            Assert.IsNotNull(customAnalyzer, "Custom analyzer should not be null");
            Assert.IsNotNull(operation, "Create analyzer operation should not be null");
            Assert.IsTrue(operation.HasCompleted, "Operation should be completed");
            Assert.IsTrue(operation.HasValue, "Operation should have a value");
            Assert.IsNotNull(operation.GetRawResponse(), "Create analyzer operation should have a raw response");
            Assert.IsTrue(operation.GetRawResponse().Status >= 200 && operation.GetRawResponse().Status < 300,
                $"Response status should be successful, but was {operation.GetRawResponse().Status}");
            Console.WriteLine("Create analyzer operation properties verified");

            Assert.IsNotNull(result, "Analyzer result should not be null");
            Console.WriteLine($"Analyzer '{analyzerId}' created successfully");

            // Verify base analyzer
            Assert.IsNotNull(result.BaseAnalyzerId, "Base analyzer ID should not be null");
            Assert.AreEqual("prebuilt-document", result.BaseAnalyzerId, "Base analyzer ID should match");
            Console.WriteLine($"Base analyzer ID verified: {result.BaseAnalyzerId}");

            // Verify analyzer config
            Assert.IsNotNull(result.Config, "Analyzer config should not be null");
            Assert.IsTrue(result.Config.EnableFormula, "EnableFormula should be true");
            Assert.IsTrue(result.Config.EnableLayout, "EnableLayout should be true");
            Assert.IsTrue(result.Config.EnableOcr, "EnableOcr should be true");
            Assert.IsTrue(result.Config.EstimateFieldSourceAndConfidence, "EstimateFieldSourceAndConfidence should be true");
            Assert.IsTrue(result.Config.ReturnDetails, "ReturnDetails should be true");
            Console.WriteLine("Analyzer config verified");

            // Verify field schema
            Assert.IsNotNull(result.FieldSchema, "Field schema should not be null");
            Assert.IsFalse(string.IsNullOrWhiteSpace(result.FieldSchema.Name), "Field schema name should not be empty");
            Assert.AreEqual("company_schema", result.FieldSchema.Name, "Field schema name should match");
            Assert.IsFalse(string.IsNullOrWhiteSpace(result.FieldSchema.Description), "Field schema description should not be empty");
            Console.WriteLine($"Field schema verified: {result.FieldSchema.Name}");

            // Verify field schema fields
            Assert.IsNotNull(result.FieldSchema.Fields, "Field schema fields should not be null");
            Assert.AreEqual(4, result.FieldSchema.Fields.Count, "Should have 4 custom fields");
            Console.WriteLine($"Field schema contains {result.FieldSchema.Fields.Count} fields");

            // Verify company_name field
            Assert.IsTrue(result.FieldSchema.Fields.ContainsKey("company_name"), "Should contain company_name field");
            var companyNameDef = result.FieldSchema.Fields["company_name"];
            Assert.AreEqual(ContentFieldType.String, companyNameDef.Type, "company_name should be String type");
            Assert.AreEqual(GenerationMethod.Extract, companyNameDef.Method, "company_name should use Extract method");
            Assert.IsFalse(string.IsNullOrWhiteSpace(companyNameDef.Description), "company_name should have description");
            Console.WriteLine("  company_name field verified (String, Extract)");

            // Verify total_amount field
            Assert.IsTrue(result.FieldSchema.Fields.ContainsKey("total_amount"), "Should contain total_amount field");
            var totalAmountDef = result.FieldSchema.Fields["total_amount"];
            Assert.AreEqual(ContentFieldType.Number, totalAmountDef.Type, "total_amount should be Number type");
            Assert.AreEqual(GenerationMethod.Extract, totalAmountDef.Method, "total_amount should use Extract method");
            Assert.IsFalse(string.IsNullOrWhiteSpace(totalAmountDef.Description), "total_amount should have description");
            Console.WriteLine("  total_amount field verified (Number, Extract)");

            // Verify document_summary field
            Assert.IsTrue(result.FieldSchema.Fields.ContainsKey("document_summary"), "Should contain document_summary field");
            var summaryDef = result.FieldSchema.Fields["document_summary"];
            Assert.AreEqual(ContentFieldType.String, summaryDef.Type, "document_summary should be String type");
            Assert.AreEqual(GenerationMethod.Generate, summaryDef.Method, "document_summary should use Generate method");
            Assert.IsFalse(string.IsNullOrWhiteSpace(summaryDef.Description), "document_summary should have description");
            Console.WriteLine("  document_summary field verified (String, Generate)");

            // Verify document_type field
            Assert.IsTrue(result.FieldSchema.Fields.ContainsKey("document_type"), "Should contain document_type field");
            var documentTypeDef = result.FieldSchema.Fields["document_type"];
            Assert.AreEqual(ContentFieldType.String, documentTypeDef.Type, "document_type should be String type");
            Assert.AreEqual(GenerationMethod.Classify, documentTypeDef.Method, "document_type should use Classify method");
            Assert.IsFalse(string.IsNullOrWhiteSpace(documentTypeDef.Description), "document_type should have description");
            Assert.IsNotNull(documentTypeDef.Enum, "document_type should have enum values");
            Assert.AreEqual(5, documentTypeDef.Enum.Count, "document_type should have 5 enum values");
            Assert.IsTrue(documentTypeDef.Enum.Contains("invoice"), "document_type enum should contain 'invoice'");
            Assert.IsTrue(documentTypeDef.Enum.Contains("receipt"), "document_type enum should contain 'receipt'");
            Assert.IsTrue(documentTypeDef.Enum.Contains("contract"), "document_type enum should contain 'contract'");
            Assert.IsTrue(documentTypeDef.Enum.Contains("report"), "document_type enum should contain 'report'");
            Assert.IsTrue(documentTypeDef.Enum.Contains("other"), "document_type enum should contain 'other'");
            Console.WriteLine("  document_type field verified (String, Classify, 5 enum values)");

            // Verify models
            Assert.IsNotNull(result.Models, "Models should not be null");
            Assert.IsTrue(result.Models.Count >= 2, "Should have at least 2 model mappings");
            Assert.IsTrue(result.Models.ContainsKey("completion"), "Should contain 'completion' model mapping");
            Assert.IsTrue(result.Models.ContainsKey("embedding"), "Should contain 'embedding' model mapping");
            Assert.AreEqual("gpt-4.1", result.Models["completion"], "Completion model should be 'gpt-4.1'");
            Assert.AreEqual("text-embedding-3-large", result.Models["embedding"], "Embedding model should be 'text-embedding-3-large'");
            Console.WriteLine($"Model mappings verified: {result.Models.Count} model(s)");

            // Verify description
            if (!string.IsNullOrWhiteSpace(result.Description))
            {
                Console.WriteLine($"Analyzer description: {result.Description}");
            }

            Console.WriteLine("All analyzer creation properties validated successfully");
            #endregion

            #region Snippet:ContentUnderstandingDeleteCreatedAnalyzer
            // Clean up: delete the analyzer (for testing purposes only)
            // In production, analyzers are typically kept and reused
#if SNIPPET
            await client.DeleteAnalyzerAsync(analyzerId);
            Console.WriteLine($"Analyzer '{analyzerId}' deleted successfully.");
#else
            try
            {
                await client.DeleteAnalyzerAsync(analyzerId);
                Console.WriteLine($"Analyzer '{analyzerId}' deleted successfully.");
            }
            catch
            {
                // Ignore cleanup errors in tests
            }
#endif
            #endregion
        }

        [RecordedTest]
        public async Task UseCustomAnalyzerAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            // First create an analyzer
            // Generate a unique analyzer ID and record it for playback
            string defaultId = $"test_analyzer_{Recording.Random.NewGuid().ToString("N")}";
            string analyzerId = Recording.GetVariable("useCustomAnalyzerId", defaultId) ?? defaultId;
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
                    },
                    ["document_summary"] = new ContentFieldDefinition
                    {
                        Type = ContentFieldType.String,
                        Method = GenerationMethod.Generate,
                        Description = "A brief summary of the document content"
                    },
                    ["document_type"] = new ContentFieldDefinition
                    {
                        Type = ContentFieldType.String,
                        Method = GenerationMethod.Classify,
                        Description = "Type of document"
                    }
                })
            {
                Name = "company_schema",
                Description = "Schema for extracting company information"
            };

            // Add enum values for the classify field
            fieldSchema.Fields["document_type"].Enum.Add("invoice");
            fieldSchema.Fields["document_type"].Enum.Add("receipt");
            fieldSchema.Fields["document_type"].Enum.Add("contract");
            fieldSchema.Fields["document_type"].Enum.Add("report");
            fieldSchema.Fields["document_type"].Enum.Add("other");

            var config = new ContentAnalyzerConfig
            {
                EnableFormula = true,
                EnableLayout = true,
                EnableOcr = true
            };

            var customAnalyzer = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-document",
                Description = "Custom analyzer for extracting company information",
                Config = config,
                FieldSchema = fieldSchema
            };

            customAnalyzer.Models["completion"] = "gpt-4.1";
            customAnalyzer.Models["embedding"] = "text-embedding-3-large";

            await client.CreateAnalyzerAsync(
                WaitUntil.Completed,
                analyzerId,
                customAnalyzer,
                allowReplace: true);

            try
            {
                #region Snippet:ContentUnderstandingUseCustomAnalyzer
#if SNIPPET
                var documentUrl = new Uri("<document_url>");
                // Analyze a document using the custom analyzer
                var analyzeOperation = await client.AnalyzeAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    inputs: new[] { new AnalyzeInput { Url = documentUrl } });
#else
                // Analyze a document using the custom analyzer
                var documentUrl = ContentUnderstandingClientTestEnvironment.CreateUri("invoice.pdf");
                var analyzeOperation = await client.AnalyzeAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    inputs: new[] { new AnalyzeInput { Url = documentUrl } });
#endif

                var analyzeResult = analyzeOperation.Value;

                // Extract custom fields from the result
                // Since EstimateFieldSourceAndConfidence is enabled, we can access confidence scores and source information
                if (analyzeResult.Contents?.FirstOrDefault() is DocumentContent content)
                {
                    // Extract field (literal text extraction)
                    if (content.Fields.TryGetValue("company_name", out var companyNameField))
                    {
                        var companyName = companyNameField is StringField sf ? sf.ValueString : null;
                        Console.WriteLine($"Company Name (extract): {companyName ?? "(not found)"}");
                        Console.WriteLine($"  Confidence: {companyNameField.Confidence?.ToString("F2") ?? "N/A"}");
                        Console.WriteLine($"  Source: {companyNameField.Source ?? "N/A"}");
                        if (companyNameField.Spans != null && companyNameField.Spans.Count > 0)
                        {
                            var span = companyNameField.Spans[0];
                            Console.WriteLine($"  Position in markdown: offset={span.Offset}, length={span.Length}");
                        }
                    }

                    // Extract field (literal text extraction)
                    if (content.Fields.TryGetValue("total_amount", out var totalAmountField))
                    {
                        var totalAmount = totalAmountField is NumberField nf ? nf.ValueNumber : null;
                        Console.WriteLine($"Total Amount (extract): {totalAmount?.ToString("F2") ?? "(not found)"}");
                        Console.WriteLine($"  Confidence: {totalAmountField.Confidence?.ToString("F2") ?? "N/A"}");
                        Console.WriteLine($"  Source: {totalAmountField.Source ?? "N/A"}");
                        if (totalAmountField.Spans != null && totalAmountField.Spans.Count > 0)
                        {
                            var span = totalAmountField.Spans[0];
                            Console.WriteLine($"  Position in markdown: offset={span.Offset}, length={span.Length}");
                        }
                    }

                    // Generate field (AI-generated value)
                    if (content.Fields.TryGetValue("document_summary", out var summaryField))
                    {
                        var summary = summaryField is StringField sf ? sf.ValueString : null;
                        Console.WriteLine($"Document Summary (generate): {summary ?? "(not found)"}");
                        Console.WriteLine($"  Confidence: {summaryField.Confidence?.ToString("F2") ?? "N/A"}");
                        // Note: Generated fields may not have source information
                        if (!string.IsNullOrEmpty(summaryField.Source))
                        {
                            Console.WriteLine($"  Source: {summaryField.Source}");
                        }
                    }

                    // Classify field (classification against predefined categories)
                    if (content.Fields.TryGetValue("document_type", out var documentTypeField))
                    {
                        var documentType = documentTypeField is StringField sf ? sf.ValueString : null;
                        Console.WriteLine($"Document Type (classify): {documentType ?? "(not found)"}");
                        Console.WriteLine($"  Confidence: {documentTypeField.Confidence?.ToString("F2") ?? "N/A"}");
                        // Note: Classified fields may not have source information
                        if (!string.IsNullOrEmpty(documentTypeField.Source))
                        {
                            Console.WriteLine($"  Source: {documentTypeField.Source}");
                        }
                    }
                }
                #endregion

                #region Assertion:ContentUnderstandingUseCustomAnalyzer
                Assert.IsNotNull(documentUrl, "Document URL should not be null");
                Assert.IsTrue(documentUrl.IsAbsoluteUri, "Document URL should be absolute");
                Assert.IsNotNull(analyzeOperation, "Analyze operation should not be null");
                Assert.IsTrue(analyzeOperation.HasCompleted, "Operation should be completed");
                Assert.IsTrue(analyzeOperation.HasValue, "Operation should have a value");
                Assert.IsNotNull(analyzeOperation.GetRawResponse(), "Analyze operation should have a raw response");
                Assert.IsTrue(analyzeOperation.GetRawResponse().Status >= 200 && analyzeOperation.GetRawResponse().Status < 300,
                    $"Response status should be successful, but was {analyzeOperation.GetRawResponse().Status}");
                Console.WriteLine("Analyze operation properties verified");

                Assert.IsNotNull(analyzeResult, "Analyze result should not be null");
                Assert.IsNotNull(analyzeResult.Contents, "Result should contain contents");
                Assert.IsTrue(analyzeResult.Contents!.Count > 0, "Result should have at least one content");
                Assert.AreEqual(1, analyzeResult.Contents.Count, "Result should have exactly one content element");
                Console.WriteLine($"Analysis result contains {analyzeResult.Contents.Count} content(s)");

                var documentContent = analyzeResult.Contents?.FirstOrDefault() as DocumentContent;
                Assert.IsNotNull(documentContent, "Content should be DocumentContent");
                Assert.IsNotNull(documentContent!.Fields, "Document content should have fields");
                Console.WriteLine($"Document content has {documentContent.Fields.Count} field(s)");

                // Verify company_name field (Extract method)
                if (documentContent.Fields.TryGetValue("company_name", out var companyNameFieldAssert))
                {
                    Console.WriteLine("company_name field found");
                    Assert.IsTrue(companyNameFieldAssert is StringField, "company_name should be a StringField");

                    if (companyNameFieldAssert is StringField cnf && !string.IsNullOrWhiteSpace(cnf.ValueString))
                    {
                        Console.WriteLine($"  Value: {cnf.ValueString}");
                    }

                    if (companyNameFieldAssert.Confidence.HasValue)
                    {
                        Assert.IsTrue(companyNameFieldAssert.Confidence.Value >= 0 && companyNameFieldAssert.Confidence.Value <= 1,
                            $"company_name confidence should be between 0 and 1, but was {companyNameFieldAssert.Confidence.Value}");
                        Console.WriteLine($"  Confidence: {companyNameFieldAssert.Confidence.Value:F2}");
                    }

                    if (!string.IsNullOrWhiteSpace(companyNameFieldAssert.Source))
                    {
                        Assert.IsTrue(companyNameFieldAssert.Source.StartsWith("D("),
                            "Source should start with 'D(' for extracted fields");
                        Console.WriteLine($"  Source: {companyNameFieldAssert.Source}");
                    }

                    if (companyNameFieldAssert.Spans != null && companyNameFieldAssert.Spans.Count > 0)
                    {
                        Assert.IsTrue(companyNameFieldAssert.Spans.Count > 0, "Spans should not be empty when not null");
                        foreach (var span in companyNameFieldAssert.Spans)
                        {
                            Assert.IsTrue(span.Offset >= 0, $"Span offset should be >= 0, but was {span.Offset}");
                            Assert.IsTrue(span.Length > 0, $"Span length should be > 0, but was {span.Length}");
                        }
                        Console.WriteLine($"  Spans: {companyNameFieldAssert.Spans.Count} span(s)");
                    }
                }
                else
                {
                    Console.WriteLine("⚠️ company_name field not found");
                }

                // Verify total_amount field (Extract method)
                if (documentContent.Fields.TryGetValue("total_amount", out var totalAmountFieldAssert))
                {
                    Console.WriteLine("total_amount field found");
                    Assert.IsTrue(totalAmountFieldAssert is NumberField, "total_amount should be a NumberField");

                    if (totalAmountFieldAssert is NumberField nfAssert && nfAssert.ValueNumber.HasValue)
                    {
                        Assert.IsTrue(nfAssert.ValueNumber.Value >= 0, $"total_amount should be >= 0, but was {nfAssert.ValueNumber.Value}");
                        Console.WriteLine($"  Value: {nfAssert.ValueNumber.Value:F2}");
                    }

                    if (totalAmountFieldAssert.Confidence.HasValue)
                    {
                        Assert.IsTrue(totalAmountFieldAssert.Confidence.Value >= 0 && totalAmountFieldAssert.Confidence.Value <= 1,
                            $"total_amount confidence should be between 0 and 1, but was {totalAmountFieldAssert.Confidence.Value}");
                        Console.WriteLine($"  Confidence: {totalAmountFieldAssert.Confidence.Value:F2}");
                    }

                    if (!string.IsNullOrEmpty(totalAmountFieldAssert.Source))
                    {
                        Assert.IsTrue(totalAmountFieldAssert.Source.StartsWith("D("),
                            "Source should start with 'D(' for extracted fields");
                        Console.WriteLine($"  Source: {totalAmountFieldAssert.Source}");
                    }

                    if (totalAmountFieldAssert.Spans != null && totalAmountFieldAssert.Spans.Count > 0)
                    {
                        Assert.IsTrue(totalAmountFieldAssert.Spans.Count > 0, "Spans should not be empty when not null");
                        foreach (var span in totalAmountFieldAssert.Spans)
                        {
                            Assert.IsTrue(span.Offset >= 0, $"Span offset should be >= 0, but was {span.Offset}");
                            Assert.IsTrue(span.Length > 0, $"Span length should be > 0, but was {span.Length}");
                        }
                        Console.WriteLine($"  Spans: {totalAmountFieldAssert.Spans.Count} span(s)");
                    }
                }
                else
                {
                    Console.WriteLine("⚠️ total_amount field not found");
                }

                // Verify document_summary field (Generate method)
                if (documentContent.Fields.TryGetValue("document_summary", out var summaryFieldAssert))
                {
                    Console.WriteLine("document_summary field found");
                    Assert.IsTrue(summaryFieldAssert is StringField, "document_summary should be a StringField");

                    if (summaryFieldAssert is StringField dsf && !string.IsNullOrWhiteSpace(dsf.ValueString))
                    {
                        Assert.IsTrue(dsf.ValueString.Length > 0, "document_summary should not be empty when present");
                        Console.WriteLine($"  Value: {dsf.ValueString.Substring(0, Math.Min(100, dsf.ValueString.Length))}...");
                    }

                    if (summaryFieldAssert.Confidence.HasValue)
                    {
                        Assert.IsTrue(summaryFieldAssert.Confidence.Value >= 0 && summaryFieldAssert.Confidence.Value <= 1,
                            $"document_summary confidence should be between 0 and 1, but was {summaryFieldAssert.Confidence.Value}");
                        Console.WriteLine($"  Confidence: {summaryFieldAssert.Confidence.Value:F2}");
                    }

                    // Note: Generated fields may not have source or spans
                    if (!string.IsNullOrEmpty(summaryFieldAssert.Source))
                    {
                        Console.WriteLine($"  Source: {summaryFieldAssert.Source}");
                    }
                }
                else
                {
                    Console.WriteLine("⚠️ document_summary field not found");
                }

                // Verify document_type field (Classify method)
                if (documentContent.Fields.TryGetValue("document_type", out var documentTypeFieldAssert))
                {
                    Console.WriteLine("document_type field found");
                    Assert.IsTrue(documentTypeFieldAssert is StringField, "document_type should be a StringField");

                    if (documentTypeFieldAssert.Confidence.HasValue)
                    {
                        Assert.IsTrue(documentTypeFieldAssert.Confidence.Value >= 0 && documentTypeFieldAssert.Confidence.Value <= 1,
                            $"document_type confidence should be between 0 and 1, but was {documentTypeFieldAssert.Confidence.Value}");
                        Console.WriteLine($"  Confidence: {documentTypeFieldAssert.Confidence.Value:F2}");
                    }

                    // Verify the classified value is one of the predefined enum values if present
                    if (documentTypeFieldAssert is StringField sfAssert && !string.IsNullOrWhiteSpace(sfAssert.ValueString))
                    {
                        var validTypes = new[] { "invoice", "receipt", "contract", "report", "other" };
                        Assert.IsTrue(validTypes.Contains(sfAssert.ValueString),
                            $"document_type should be one of the predefined values, but got: {sfAssert.ValueString}");
                        Console.WriteLine($"  Value: {sfAssert.ValueString}");
                    }

                    // Note: Classified fields may not have source or spans
                    if (!string.IsNullOrEmpty(documentTypeFieldAssert.Source))
                    {
                        Console.WriteLine($"  Source: {documentTypeFieldAssert.Source}");
                    }
                }
                else
                {
                    Console.WriteLine("⚠️ document_type field not found");
                }

                Console.WriteLine("All custom analyzer usage properties validated successfully");
                #endregion

                // Clean up: delete the analyzer (for testing purposes only)
                // In production, analyzers are typically kept and reused
#if SNIPPET
                await client.DeleteAnalyzerAsync(analyzerId);
                Console.WriteLine($"Analyzer '{analyzerId}' deleted successfully.");
#else
                try
                {
                    await client.DeleteAnalyzerAsync(analyzerId);
                    Console.WriteLine($"Analyzer '{analyzerId}' deleted successfully.");
                }
                catch
                {
                    // Ignore cleanup errors in tests
                }
#endif
            }
            finally
            {
                // Ensure cleanup even if snippet code fails
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
