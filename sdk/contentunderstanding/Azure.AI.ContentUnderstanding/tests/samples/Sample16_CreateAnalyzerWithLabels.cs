// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.IO;
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
    /// Demonstrates the API pattern for creating an analyzer with labeled training data.
    ///
    /// For an easier labeling workflow, use Azure AI Content Understanding Studio at
    /// https://contentunderstanding.ai.azure.com/
    ///
    /// <para><b>Manual instructions to upload labels into Azure Blob Storage:</b></para>
    /// <list type="number">
    ///   <item>Create an Azure Blob Storage container (or use an existing one).</item>
    ///   <item>Upload the contents of <c>tests/samples/sample_files/receipt_labels</c> into the
    ///         container. You may upload into the root or a subfolder (e.g., "receipt_labels/").</item>
    ///   <item>Generate a SAS URL for the container with at least <b>List</b> and <b>Read</b>
    ///         permissions.</item>
    ///   <item>Set <c>CONTENTUNDERSTANDING_TRAINING_DATA_SAS_URL</c> to that SAS URL.</item>
    ///   <item>If you uploaded into a subfolder, also set
    ///         <c>CONTENTUNDERSTANDING_TRAINING_DATA_PREFIX</c> (e.g., "receipt_labels/").</item>
    /// </list>
    ///
    /// Alternatively, set <c>CONTENTUNDERSTANDING_TRAINING_DATA_STORAGE_ACCOUNT</c> and
    /// <c>CONTENTUNDERSTANDING_TRAINING_DATA_CONTAINER</c> to let the sample auto-upload local
    /// label files and generate a SAS URL via <c>DefaultAzureCredential</c>.
    ///
    /// See Sample16_CreateAnalyzerWithLabels.md for full documentation.
    /// </summary>
    public partial class ContentUnderstandingSamples
    {
        [RecordedTest]
        public async Task CreateAnalyzerWithLabelsAsync()
        {
            // ── Test infrastructure ──────────────────────────────────────────
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(
                new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

#if !SNIPPET
            string defaultId = $"test_receipt_analyzer_{Recording.Random.NewGuid().ToString("N")}";
            string analyzerId = Recording.GetVariable("analyzerWithLabelsId", defaultId) ?? defaultId;

            string? trainingDataSasUrl = Mode == RecordedTestMode.Playback
                ? "https://placeholder.blob.core.windows.net/container?sv=placeholder"
                : TestEnvironment.TrainingDataSasUrl;
            string? trainingDataPrefix = Mode == RecordedTestMode.Playback
                ? Recording.GetVariable("trainingDataPrefix", null)
                : TestEnvironment.TrainingDataPrefix;

            // Option B fallback: upload local label files → generate SAS URL
            if (string.IsNullOrEmpty(trainingDataSasUrl) && Mode != RecordedTestMode.Playback)
            {
                string? acct = TestEnvironment.TrainingDataStorageAccountName;
                string? ctr = TestEnvironment.TrainingDataContainerName;
                if (!string.IsNullOrEmpty(acct) && !string.IsNullOrEmpty(ctr))
                {
                    string localDir = ContentUnderstandingClientTestEnvironment.CreatePath("receipt_labels");
                    await UploadTrainingDataAsync(
                        acct!, ctr!, TestEnvironment.Credential, localDir, trainingDataPrefix);

                    trainingDataSasUrl = await GenerateUserDelegationSasUrlAsync(
                        acct!, ctr!, TestEnvironment.Credential);
                }
            }

            // Save variable values for playback mode
            if (Mode == RecordedTestMode.Record)
            {
                Recording.SetVariable("trainingDataPrefix", trainingDataPrefix ?? string.Empty);
            }
#endif
            // ─────────────────────────────────────────────────────────────────

            try
            {
                #region Snippet:ContentUnderstandingCreateAnalyzerWithLabels
#if SNIPPET
                string analyzerId = $"receipt_analyzer_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
#endif

                // Step 1: Build the receipt field schema
                ContentFieldSchema fieldSchema = BuildReceiptFieldSchema();

                // Step 2: Resolve training data SAS URL
                // You can either provide a pre-generated SAS URL (Option A) or let the sample
                // upload local label files and generate one automatically (Option B).
                // See Sample16_CreateAnalyzerWithLabels.md for manual upload instructions.
#if SNIPPET
                // Option A: use a pre-generated SAS URL with Read + List permissions
                string? trainingDataSasUrl = Environment.GetEnvironmentVariable("CONTENTUNDERSTANDING_TRAINING_DATA_SAS_URL");
                string? trainingDataPrefix = Environment.GetEnvironmentVariable("CONTENTUNDERSTANDING_TRAINING_DATA_PREFIX");

                // Option B: upload local label files and auto-generate a SAS URL
                if (string.IsNullOrEmpty(trainingDataSasUrl))
                {
                    string? storageAccount = Environment.GetEnvironmentVariable("CONTENTUNDERSTANDING_TRAINING_DATA_STORAGE_ACCOUNT");
                    string? container = Environment.GetEnvironmentVariable("CONTENTUNDERSTANDING_TRAINING_DATA_CONTAINER");
                    if (!string.IsNullOrEmpty(storageAccount) && !string.IsNullOrEmpty(container))
                    {
                        var credential = new Azure.Identity.DefaultAzureCredential();
                        string localLabelDir = "<path_to_local_receipt_labels_folder>";
                        await UploadTrainingDataAsync(storageAccount, container, credential, localLabelDir, trainingDataPrefix);
                        trainingDataSasUrl = await GenerateUserDelegationSasUrlAsync(storageAccount, container, credential);
                    }
                }
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
                Console.WriteLine($"Analyzer created: {analyzerId}");
                Console.WriteLine($"  Description: {result.Description}");
                Console.WriteLine($"  Base analyzer: {result.BaseAnalyzerId}");
                Console.WriteLine($"  Fields: {result.FieldSchema?.Fields?.Count ?? 0}");
                Console.WriteLine($"  Knowledge srcs: {result.KnowledgeSources?.Count ?? 0}");
                #endregion

                #region Assertion:ContentUnderstandingCreateAnalyzerWithLabels
                // Verify analyzer creation
                Console.WriteLine();
                Console.WriteLine("Analyzer Creation Verification:");
                Assert.IsNotNull(result);
                Assert.AreEqual("prebuilt-document", result.BaseAnalyzerId);
                Assert.AreEqual("Receipt analyzer with labeled training data", result.Description);

                Assert.IsNotNull(result.FieldSchema);
                Assert.AreEqual("receipt_schema", result.FieldSchema!.Name);
                Assert.AreEqual(3, result.FieldSchema!.Fields.Count, "Expected MerchantName, Items, TotalPrice");
                Console.WriteLine("Analyzer created successfully");

                // Verify field schema
                Assert.IsTrue(result.FieldSchema!.Fields.ContainsKey("MerchantName"));
                Assert.IsTrue(result.FieldSchema!.Fields.ContainsKey("Items"));
                Assert.IsTrue(result.FieldSchema!.Fields.ContainsKey("TotalPrice"));

                var itemsField = result.FieldSchema!.Fields["Items"];
                Assert.AreEqual(ContentFieldType.Array, itemsField.Type);
                Assert.IsNotNull(itemsField.ItemDefinition);
                Assert.AreEqual(ContentFieldType.Object, itemsField.ItemDefinition!.Type);
                Assert.AreEqual(3, itemsField.ItemDefinition!.Properties.Count, "Expected Quantity, Name, Price");

                Console.WriteLine("Field schema verified:");
                Console.WriteLine("  MerchantName: String (Extract)");
                Console.WriteLine("  Items: Array of Objects (Generate)");
                Console.WriteLine("    - Quantity, Name, Price");
                Console.WriteLine("  TotalPrice: String (Extract)");
                #endregion

                // If training data was provided, test the analyzer with a sample document
                if (!string.IsNullOrEmpty(trainingDataSasUrl)
                    && trainingDataSasUrl != "https://placeholder.blob.core.windows.net/container?sv=placeholder")
                {
                    Console.WriteLine();
                    Console.WriteLine("Testing analyzer with sample document...");
                    string testDocUrl =
                        "https://github.com/Azure-Samples/cognitive-services-REST-api-samples/raw/master/curl/form-recognizer/sample-invoice.pdf";

                    var analyzeResult = (await client.AnalyzeAsync(
                        WaitUntil.Completed, analyzerId, new[] { new AnalysisInput { Uri = new Uri(testDocUrl) } })).Value;

                    Console.WriteLine("Analysis completed!");
                    Assert.IsNotNull(analyzeResult);
                    Assert.IsNotNull(analyzeResult.Contents);
                    Assert.IsTrue(analyzeResult.Contents.Count > 0);

                    if (analyzeResult.Contents[0] is DocumentContent docContent)
                    {
                        Console.WriteLine($"Extracted fields: {docContent.Fields.Count}");

                        if (docContent.Fields.TryGetValue("MerchantName", out var merchantField) && merchantField is ContentStringField merchantStringField)
                        {
                            Console.WriteLine($"  MerchantName: {merchantStringField.Value}");
                        }
                        if (docContent.Fields.TryGetValue("TotalPrice", out var totalPriceField) && totalPriceField is ContentStringField totalPriceStringField)
                        {
                            Console.WriteLine($"  TotalPrice: {totalPriceStringField.Value}");
                        }
                    }
                }

                // Display API pattern information
                Console.WriteLine();
                Console.WriteLine("CreateAnalyzerWithLabels API Pattern:");
                Console.WriteLine("   1. Define field schema with nested structures (arrays, objects)");
                Console.WriteLine("   2. Upload training data to Azure Blob Storage:");
                Console.WriteLine("      - Documents: receipt1.jpg, receipt2.jpg, ...");
                Console.WriteLine("      - Labels: receipt1.jpg.labels.json, receipt2.jpg.labels.json, ...");
                Console.WriteLine("      - OCR: receipt1.jpg.result.json, receipt2.jpg.result.json, ...");
                Console.WriteLine("   3. Create LabeledDataKnowledgeSource with storage SAS URL");
                Console.WriteLine("   4. Create analyzer with field schema and knowledge sources");
                Console.WriteLine("   5. Use analyzer for document analysis");

                Console.WriteLine();
                Console.WriteLine("CreateAnalyzerWithLabels pattern demonstration completed");
                if (string.IsNullOrEmpty(trainingDataSasUrl)
                    || trainingDataSasUrl == "https://placeholder.blob.core.windows.net/container?sv=placeholder")
                {
                    Console.WriteLine("   Note: This sample demonstrates the API pattern.");
                    Console.WriteLine("   For actual training, provide CONTENTUNDERSTANDING_TRAINING_DATA_SAS_URL with labeled data.");
                }
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
        /// with MerchantName, Items (array of Quantity / Name / Price), and TotalPrice.
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
                    ["TotalPrice"] = new ContentFieldDefinition
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

        #region Snippet:ContentUnderstandingUploadTrainingData
        /// <summary>
        /// Uploads local training data files (images, .labels.json, .result.json) to an
        /// Azure Blob container. Existing blobs with the same name are overwritten.
        /// </summary>
        /// <param name="storageAccountName">Storage account name.</param>
        /// <param name="containerName">Container name (created if it does not exist).</param>
        /// <param name="credential">Credential with write access to the container.</param>
        /// <param name="localDirectory">Local folder containing the label files.</param>
        /// <param name="prefix">
        /// Optional blob prefix (virtual folder) to prepend, e.g. "receipt_labels/".
        /// </param>
        private static async Task UploadTrainingDataAsync(
            string storageAccountName,
            string containerName,
            TokenCredential credential,
            string localDirectory,
            string? prefix = null)
        {
            var containerClient = new BlobContainerClient(
                new Uri($"https://{storageAccountName}.blob.core.windows.net/{containerName}"),
                credential);

            await containerClient.CreateIfNotExistsAsync();

            foreach (string filePath in Directory.GetFiles(localDirectory))
            {
                string blobName = string.IsNullOrEmpty(prefix)
                    ? Path.GetFileName(filePath)
                    : prefix!.TrimEnd('/') + "/" + Path.GetFileName(filePath);

                Console.WriteLine($"Uploading {Path.GetFileName(filePath)} -> {blobName}");
                await containerClient.GetBlobClient(blobName)
                    .UploadAsync(filePath, overwrite: true);
            }
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
                new BlobGetUserDelegationKeyOptions(DateTimeOffset.UtcNow.AddHours(1))
                {
                    StartsOn = DateTimeOffset.UtcNow
                })).Value;

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
