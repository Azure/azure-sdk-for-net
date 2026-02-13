// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.ContentUnderstanding.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Samples
{
    /// <summary>
    /// Sample demonstrates how to build analyzers with training labels (labeled data from Azure Blob Storage).
    ///
    /// This sample is mainly to show the API pattern for creating an analyzer with labeled training data.
    /// For an easier labeling workflow, use Azure AI Content Understanding Studio at
    /// https://contentunderstanding.ai.azure.com/
    ///
    /// Labeled receipt data is available in this repo at <c>tests/samples/sample_files/receipt_labels</c>.
    /// For LIVE mode with real training data: upload that folder to Azure Blob Storage, generate a
    /// container SAS URL with List/Read permissions, then set the environment variables below. Use
    /// <c>CONTENTUNDERSTANDING_TRAINING_DATA_PREFIX</c> if you uploaded into a subfolder
    /// (e.g., "receipt_labels/"); omit or leave unset if files are at the container root.
    ///
    /// Required environment variables:
    ///   CONTENTUNDERSTANDING_ENDPOINT – Azure Content Understanding endpoint URL
    ///
    /// Optional environment variables (for labeled training data; used in LIVE mode):
    ///   CONTENTUNDERSTANDING_TRAINING_DATA_SAS_URL – SAS URL for the Azure Blob container with labeled training data.
    ///   CONTENTUNDERSTANDING_TRAINING_DATA_PREFIX – Path prefix within the container (e.g., "receipt_labels/").
    ///     Omit or leave unset if files are at the container root.
    /// </summary>
    public partial class ContentUnderstandingSamples
    {
        [RecordedTest]
        [Ignore("This test requires recorded session files. Run in Live mode to record.")]
        public async Task CreateAnalyzerWithLabelsAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(
                new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options)
            );

            // Generate a unique analyzer ID (deterministic for playback)
            string defaultId = $"test_receipt_analyzer_{Recording.Random.NewGuid().ToString("N")}";
            string analyzerId = Recording.GetVariable("analyzerWithLabelsId", defaultId) ?? defaultId;

            // Get training data configuration
            string? trainingDataSasUrl = Mode == RecordedTestMode.Playback
                ? "https://placeholder.blob.core.windows.net/container?sv=placeholder"
                : TestEnvironment.TrainingDataSasUrl;
            string? trainingDataPrefix = Mode == RecordedTestMode.Playback
                ? Recording.GetVariable("trainingDataPrefix", null)
                : TestEnvironment.TrainingDataPrefix;

            // Record prefix for playback so request bodies match
            if (Mode == RecordedTestMode.Record)
            {
                Recording.SetVariable("trainingDataPrefix", trainingDataPrefix ?? string.Empty);
            }

            try
            {
                #region Snippet:ContentUnderstandingCreateAnalyzerWithLabels
#if SNIPPET
                // Generate a unique analyzer ID
                string analyzerId = $"receipt_analyzer_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
#endif

                // Step 1: Define field schema for receipt extraction
                var itemDefinition = new ContentFieldDefinition
                {
                    Type = ContentFieldType.Object,
                    Method = GenerationMethod.Extract,
                    Description = "Individual item details",
                };
                itemDefinition.Properties.Add("Quantity", new ContentFieldDefinition
                {
                    Type = ContentFieldType.String,
                    Method = GenerationMethod.Extract,
                    Description = "Quantity of the item",
                });
                itemDefinition.Properties.Add("Name", new ContentFieldDefinition
                {
                    Type = ContentFieldType.String,
                    Method = GenerationMethod.Extract,
                    Description = "Name of the item",
                });
                itemDefinition.Properties.Add("Price", new ContentFieldDefinition
                {
                    Type = ContentFieldType.String,
                    Method = GenerationMethod.Extract,
                    Description = "Price of the item",
                });

                var fieldSchema = new ContentFieldSchema(
                    new Dictionary<string, ContentFieldDefinition>
                    {
                        ["MerchantName"] = new ContentFieldDefinition
                        {
                            Type = ContentFieldType.String,
                            Method = GenerationMethod.Extract,
                            Description = "Name of the merchant",
                        },
                        ["Items"] = new ContentFieldDefinition
                        {
                            Type = ContentFieldType.Array,
                            Method = GenerationMethod.Generate,
                            Description = "List of items purchased",
                            ItemDefinition = itemDefinition,
                        },
                        ["Total"] = new ContentFieldDefinition
                        {
                            Type = ContentFieldType.String,
                            Method = GenerationMethod.Extract,
                            Description = "Total amount",
                        },
                    }
                )
                {
                    Name = "receipt_schema",
                    Description = "Schema for receipt extraction with items",
                };

                // Step 2: Create labeled data knowledge source (optional, based on environment variable)
#if SNIPPET
                string? trainingDataSasUrl = Environment.GetEnvironmentVariable("CONTENTUNDERSTANDING_TRAINING_DATA_SAS_URL");
                string? trainingDataPrefix = Environment.GetEnvironmentVariable("CONTENTUNDERSTANDING_TRAINING_DATA_PREFIX");
#endif

                var knowledgeSources = new List<KnowledgeSource>();
                if (!string.IsNullOrEmpty(trainingDataSasUrl))
                {
                    var knowledgeSource = new LabeledDataKnowledgeSource(new Uri(trainingDataSasUrl));
                    if (!string.IsNullOrEmpty(trainingDataPrefix))
                    {
                        knowledgeSource.Prefix = trainingDataPrefix;
                    }
                    knowledgeSources.Add(knowledgeSource);
                    Console.WriteLine($"Using labeled training data from: {trainingDataSasUrl!.Substring(0, Math.Min(50, trainingDataSasUrl.Length))}...");
                }
                else
                {
                    Console.WriteLine("No CONTENTUNDERSTANDING_TRAINING_DATA_SAS_URL set, creating analyzer without labeled training data");
                }

                // Step 3: Create analyzer (with or without labeled data)
                var customAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Receipt analyzer with labeled training data",
                    Config = new ContentAnalyzerConfig
                    {
                        EnableLayout = true,
                        EnableOcr = true,
                    },
                    FieldSchema = fieldSchema,
                };
                customAnalyzer.Models.Add("completion", "gpt-4.1");
                customAnalyzer.Models.Add("embedding", "text-embedding-3-large");

                if (knowledgeSources.Count > 0)
                {
                    foreach (var ks in knowledgeSources)
                    {
                        customAnalyzer.KnowledgeSources.Add(ks);
                    }
                }

                var operation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    customAnalyzer,
                    allowReplace: true
                );

                ContentAnalyzer result = operation.Value;
                Console.WriteLine($"Analyzer created: {analyzerId}");
                Console.WriteLine($"  Description: {result.Description}");
                Console.WriteLine($"  Base analyzer: {result.BaseAnalyzerId}");
                Console.WriteLine($"  Fields: {result.FieldSchema?.Fields?.Count ?? 0}");
                #endregion

                // Verify analyzer creation
                Assert.IsNotNull(result, "Analyzer should not be null");
                Assert.AreEqual("prebuilt-document", result.BaseAnalyzerId);
                Assert.AreEqual("Receipt analyzer with labeled training data", result.Description);
                Assert.IsNotNull(result.FieldSchema);
                Assert.AreEqual("receipt_schema", result.FieldSchema!.Name);
                Assert.AreEqual(3, result.FieldSchema!.Fields.Count, "Should have 3 custom fields");

                // Verify field schema
                Assert.IsTrue(result.FieldSchema!.Fields.ContainsKey("MerchantName"), "Should have MerchantName field");
                Assert.IsTrue(result.FieldSchema!.Fields.ContainsKey("Items"), "Should have Items field");
                Assert.IsTrue(result.FieldSchema!.Fields.ContainsKey("Total"), "Should have Total field");

                var itemsFieldResult = result.FieldSchema!.Fields["Items"];
                Assert.AreEqual(ContentFieldType.Array, itemsFieldResult.Type);
                Assert.IsNotNull(itemsFieldResult.ItemDefinition);
                Assert.AreEqual(ContentFieldType.Object, itemsFieldResult.ItemDefinition!.Type);
                Assert.AreEqual(3, itemsFieldResult.ItemDefinition!.Properties.Count);

                Console.WriteLine("Analyzer creation with labeled data verified successfully");
            }
            finally
            {
                // Clean up: delete the analyzer
                try
                {
                    await client.DeleteAnalyzerAsync(analyzerId);
                    Console.WriteLine($"Analyzer '{analyzerId}' deleted successfully.");
                }
                catch
                {
                    // Ignore cleanup errors in tests
                }
            }
        }
    }
}
