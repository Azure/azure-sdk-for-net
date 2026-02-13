// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.ContentUnderstanding.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Samples
{
    /// <summary>
    /// Demonstrates creating a custom analyzer with labeled training data from Azure Blob Storage.
    ///
    /// For an easier labeling workflow, use Azure AI Content Understanding Studio at
    /// https://contentunderstanding.ai.azure.com/
    ///
    /// Labeled receipt data is available at <c>tests/samples/sample_files/receipt_labels</c>.
    /// To run in LIVE mode: upload that folder to Azure Blob Storage, then set one of:
    ///   Option A – CONTENTUNDERSTANDING_TRAINING_DATA_SAS_URL (pre-generated SAS URL)
    ///   Option B – CONTENTUNDERSTANDING_TRAINING_DATA_STORAGE_ACCOUNT + _CONTAINER (auto-generates SAS)
    ///   Common  – CONTENTUNDERSTANDING_TRAINING_DATA_PREFIX (e.g. "receipt_labels/")
    /// </summary>
    public partial class ContentUnderstandingSamples
    {
        [RecordedTest]
        [Ignore("This test requires recorded session files. Run in Live mode to record.")]
        public async Task CreateAnalyzerWithLabelsAsync()
        {
            // ── Test infrastructure ──────────────────────────────────────────
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(
                new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            string defaultId = $"test_receipt_analyzer_{Recording.Random.NewGuid().ToString("N")}";
            string analyzerId = Recording.GetVariable("analyzerWithLabelsId", defaultId) ?? defaultId;

            string? trainingDataSasUrl = Mode == RecordedTestMode.Playback
                ? "https://placeholder.blob.core.windows.net/container?sv=placeholder"
                : TestEnvironment.TrainingDataSasUrl;
            string? trainingDataPrefix = Mode == RecordedTestMode.Playback
                ? Recording.GetVariable("trainingDataPrefix", null)
                : TestEnvironment.TrainingDataPrefix;

            if (string.IsNullOrEmpty(trainingDataSasUrl) && Mode != RecordedTestMode.Playback)
            {
                string? acct = TestEnvironment.TrainingDataStorageAccountName;
                string? ctr = TestEnvironment.TrainingDataContainerName;
                if (!string.IsNullOrEmpty(acct) && !string.IsNullOrEmpty(ctr))
                {
                    trainingDataSasUrl = await GenerateUserDelegationSasUrlAsync(
                        acct!, ctr!, TestEnvironment.Credential);
                }
            }

            if (Mode == RecordedTestMode.Record)
            {
                Recording.SetVariable("trainingDataPrefix", trainingDataPrefix ?? string.Empty);
            }
            // ─────────────────────────────────────────────────────────────────

            try
            {
                #region Snippet:ContentUnderstandingCreateAnalyzerWithLabels
#if SNIPPET
                string analyzerId = $"receipt_analyzer_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
#endif

                // Step 1: Build the receipt field schema (see helper method below)
                ContentFieldSchema fieldSchema = BuildReceiptFieldSchema();

                // Step 2: Resolve training data SAS URL (optional)
#if SNIPPET
                // Option A: pre-generated SAS URL
                string? trainingDataSasUrl = Environment.GetEnvironmentVariable("CONTENTUNDERSTANDING_TRAINING_DATA_SAS_URL");

                // Option B: auto-generate from storage account + container name
                if (string.IsNullOrEmpty(trainingDataSasUrl))
                {
                    string? storageAccount = Environment.GetEnvironmentVariable("CONTENTUNDERSTANDING_TRAINING_DATA_STORAGE_ACCOUNT");
                    string? container = Environment.GetEnvironmentVariable("CONTENTUNDERSTANDING_TRAINING_DATA_CONTAINER");
                    if (!string.IsNullOrEmpty(storageAccount) && !string.IsNullOrEmpty(container))
                    {
                        trainingDataSasUrl = await GenerateUserDelegationSasUrlAsync(
                            storageAccount, container, new Azure.Identity.DefaultAzureCredential());
                    }
                }

                string? trainingDataPrefix = Environment.GetEnvironmentVariable("CONTENTUNDERSTANDING_TRAINING_DATA_PREFIX");
#endif

                // Step 3: Create knowledge source from labeled data (if available)
                var knowledgeSources = new List<KnowledgeSource>();
                if (!string.IsNullOrEmpty(trainingDataSasUrl))
                {
                    var labeledSource = new LabeledDataKnowledgeSource(new Uri(trainingDataSasUrl));
                    if (!string.IsNullOrEmpty(trainingDataPrefix))
                    {
                        labeledSource.Prefix = trainingDataPrefix;
                    }
                    knowledgeSources.Add(labeledSource);
                }

                // Step 4: Create the analyzer
                var customAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Receipt analyzer with labeled training data",
                    Config = new ContentAnalyzerConfig { EnableLayout = true, EnableOcr = true },
                    FieldSchema = fieldSchema,
                };
                customAnalyzer.Models.Add("completion", "gpt-4.1");
                customAnalyzer.Models.Add("embedding", "text-embedding-3-large");
                foreach (var source in knowledgeSources)
                {
                    customAnalyzer.KnowledgeSources.Add(source);
                }

                var operation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed, analyzerId, customAnalyzer, allowReplace: true);

                ContentAnalyzer result = operation.Value;
                Console.WriteLine($"Analyzer '{analyzerId}' created.");
                Console.WriteLine($"  Base analyzer : {result.BaseAnalyzerId}");
                Console.WriteLine($"  Field count   : {result.FieldSchema?.Fields?.Count ?? 0}");
                Console.WriteLine($"  Knowledge srcs: {result.KnowledgeSources?.Count ?? 0}");
                #endregion

                #region Assertion:ContentUnderstandingCreateAnalyzerWithLabels
                Assert.IsNotNull(result);
                Assert.AreEqual("prebuilt-document", result.BaseAnalyzerId);
                Assert.AreEqual("Receipt analyzer with labeled training data", result.Description);

                Assert.IsNotNull(result.FieldSchema);
                Assert.AreEqual("receipt_schema", result.FieldSchema!.Name);
                Assert.AreEqual(3, result.FieldSchema!.Fields.Count, "Expected MerchantName, Items, Total");
                Assert.IsTrue(result.FieldSchema!.Fields.ContainsKey("MerchantName"));
                Assert.IsTrue(result.FieldSchema!.Fields.ContainsKey("Items"));
                Assert.IsTrue(result.FieldSchema!.Fields.ContainsKey("Total"));

                var itemsField = result.FieldSchema!.Fields["Items"];
                Assert.AreEqual(ContentFieldType.Array, itemsField.Type);
                Assert.IsNotNull(itemsField.ItemDefinition);
                Assert.AreEqual(ContentFieldType.Object, itemsField.ItemDefinition!.Type);
                Assert.AreEqual(3, itemsField.ItemDefinition!.Properties.Count, "Expected Quantity, Name, Price");
                #endregion
            }
            finally
            {
                #region Snippet:ContentUnderstandingDeleteAnalyzerWithLabels
#if SNIPPET
                await client.DeleteAnalyzerAsync(analyzerId);
                Console.WriteLine($"Analyzer '{analyzerId}' deleted.");
#else
                try
                {
                    await client.DeleteAnalyzerAsync(analyzerId);
                    Console.WriteLine($"Analyzer '{analyzerId}' deleted.");
                }
                catch
                {
                    // Ignore cleanup errors in tests
                }
#endif
                #endregion
            }
        }

        #region Snippet:ContentUnderstandingBuildReceiptFieldSchema
        /// <summary>
        /// Builds a <see cref="ContentFieldSchema"/> for receipt extraction
        /// with MerchantName, Items (array of Quantity / Name / Price), and Total.
        /// </summary>
        private static ContentFieldSchema BuildReceiptFieldSchema()
        {
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

            return new ContentFieldSchema(
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
        }
        #endregion

        #region Snippet:ContentUnderstandingGenerateUserDelegationSas
        /// <summary>
        /// Generates a User Delegation SAS URL (Read + List) for an Azure Blob container.
        /// Uses <see cref="TokenCredential"/> so no storage account key is needed.
        /// </summary>
        private static async Task<string> GenerateUserDelegationSasUrlAsync(
            string storageAccountName,
            string containerName,
            TokenCredential credential)
        {
            var blobServiceClient = new BlobServiceClient(
                new Uri($"https://{storageAccountName}.blob.core.windows.net"),
                credential);

            var userDelegationKey = (await blobServiceClient.GetUserDelegationKeyAsync(
                DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddHours(1))).Value;

            var sasBuilder = new BlobSasBuilder
            {
                BlobContainerName = containerName,
                Resource = "c",
                ExpiresOn = DateTimeOffset.UtcNow.AddHours(1),
            };
            sasBuilder.SetPermissions(BlobContainerSasPermissions.Read | BlobContainerSasPermissions.List);

            string sasToken = sasBuilder.ToSasQueryParameters(userDelegationKey, storageAccountName).ToString();
            return $"https://{storageAccountName}.blob.core.windows.net/{containerName}?{sasToken}";
        }
        #endregion
    }
}
