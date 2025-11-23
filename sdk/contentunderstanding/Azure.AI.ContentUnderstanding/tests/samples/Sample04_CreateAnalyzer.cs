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

            // Add model mappings (required for custom analyzers)
            customAnalyzer.Models.Add("completion", "gpt-4.1");
            customAnalyzer.Models.Add("embedding", "text-embedding-3-large");

            // Create the analyzer
            var operation = await client.CreateAnalyzerAsync(
                WaitUntil.Completed,
                analyzerId,
                customAnalyzer,
                allowReplace: true);

            ContentAnalyzer result = operation.Value;
            Console.WriteLine($"Analyzer '{analyzerId}' created successfully!");
            #endregion

            #region Snippet:ContentUnderstandingDeleteAnalyzer
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

            customAnalyzer.Models.Add("completion", "gpt-4.1");
            customAnalyzer.Models.Add("embedding", "text-embedding-3-large");

            await client.CreateAnalyzerAsync(
                WaitUntil.Completed,
                analyzerId,
                customAnalyzer,
                allowReplace: true);

            try
            {
                #region Snippet:ContentUnderstandingUseCustomAnalyzer
#if SNIPPET
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
                        if (companyNameField != null)
                        {
                            Console.WriteLine($"  Confidence: {companyNameField.Confidence?.ToString("F2") ?? "N/A"}");
                            Console.WriteLine($"  Source: {companyNameField.Source ?? "N/A"}");
                            if (companyNameField.Spans != null && companyNameField.Spans.Count > 0)
                            {
                                var span = companyNameField.Spans[0];
                                Console.WriteLine($"  Position in markdown: offset={span.Offset}, length={span.Length}");
                            }
                        }
                    }

                    // Extract field (literal text extraction)
                    if (content.Fields.TryGetValue("total_amount", out var totalAmountField))
                    {
                        var totalAmount = totalAmountField is NumberField nf ? nf.ValueNumber : null;
                        Console.WriteLine($"Total Amount (extract): {totalAmount?.ToString("F2") ?? "(not found)"}");
                        if (totalAmountField != null)
                        {
                            Console.WriteLine($"  Confidence: {totalAmountField.Confidence?.ToString("F2") ?? "N/A"}");
                            Console.WriteLine($"  Source: {totalAmountField.Source ?? "N/A"}");
                            if (totalAmountField.Spans != null && totalAmountField.Spans.Count > 0)
                            {
                                var span = totalAmountField.Spans[0];
                                Console.WriteLine($"  Position in markdown: offset={span.Offset}, length={span.Length}");
                            }
                        }
                    }

                    // Generate field (AI-generated value)
                    if (content.Fields.TryGetValue("document_summary", out var summaryField))
                    {
                        var summary = summaryField is StringField sf ? sf.ValueString : null;
                        Console.WriteLine($"Document Summary (generate): {summary ?? "(not found)"}");
                        if (summaryField != null)
                        {
                            Console.WriteLine($"  Confidence: {summaryField.Confidence?.ToString("F2") ?? "N/A"}");
                            // Note: Generated fields may not have source information
                            if (!string.IsNullOrEmpty(summaryField.Source))
                            {
                                Console.WriteLine($"  Source: {summaryField.Source}");
                            }
                        }
                    }

                    // Classify field (classification against predefined categories)
                    if (content.Fields.TryGetValue("document_type", out var documentTypeField))
                    {
                        var documentType = documentTypeField is StringField sf ? sf.ValueString : null;
                        Console.WriteLine($"Document Type (classify): {documentType ?? "(not found)"}");
                        if (documentTypeField != null)
                        {
                            Console.WriteLine($"  Confidence: {documentTypeField.Confidence?.ToString("F2") ?? "N/A"}");
                            // Note: Classified fields may not have source information
                            if (!string.IsNullOrEmpty(documentTypeField.Source))
                            {
                                Console.WriteLine($"  Source: {documentTypeField.Source}");
                            }
                        }
                    }
                }
                #endregion

                #region Snippet:ContentUnderstandingDeleteAnalyzer
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
