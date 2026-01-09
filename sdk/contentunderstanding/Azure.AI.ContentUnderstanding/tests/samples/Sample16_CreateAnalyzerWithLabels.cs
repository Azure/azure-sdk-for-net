// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.AI.ContentUnderstanding.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Samples
{
    public partial class ContentUnderstandingSamples
    {
        [RecordedTest]
        [Ignore("This test requires recorded session files. Run in Live mode to record.")]
        public async Task CreateAnalyzerWithLabelsAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(
                new ContentUnderstandingClient(
                    new Uri(endpoint),
                    TestEnvironment.Credential,
                    options
                )
            );

            #region Snippet:ContentUnderstandingCreateAnalyzerWithLabels
#if SNIPPET
            // Generate a unique analyzer ID
            string analyzerId = $"receipt_analyzer_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
#else
            // Generate a unique analyzer ID and record it for playback
            string defaultId = $"test_receipt_analyzer_{Recording.Random.NewGuid().ToString("N")}";
            string analyzerId =
                Recording.GetVariable("analyzerWithLabelsId", defaultId) ?? defaultId;
#endif

            // Step 1: Upload training data to Azure Blob Storage
            // Get training data configuration from environment
#if SNIPPET
            string trainingDataSasUrl =
                Environment.GetEnvironmentVariable("TRAINING_DATA_SAS_URL") ?? string.Empty;
            string? storageAccount = Environment.GetEnvironmentVariable(
                "TRAINING_DATA_STORAGE_ACCOUNT"
            );
            string? containerName = Environment.GetEnvironmentVariable(
                "TRAINING_DATA_CONTAINER_NAME"
            );

            // If SAS URL is not provided, generate SAS URL from storage account and container name
            if (
                string.IsNullOrEmpty(trainingDataSasUrl)
                && !string.IsNullOrEmpty(storageAccount)
                && !string.IsNullOrEmpty(containerName)
            )
            {
                // Use DefaultAzureCredential to authenticate and generate SAS token
                var blobServiceClient = new Azure.Storage.Blobs.BlobServiceClient(
                    new Uri($"https://{storageAccount}.blob.core.windows.net"),
                    new DefaultAzureCredential()
                );

                var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

                // Ensure container exists
                await containerClient.CreateIfNotExistsAsync();

                // Generate SAS token valid for 24 hours
                var sasBuilder = new BlobSasBuilder
                {
                    BlobContainerName = containerName,
                    Resource = "c", // Container
                    ExpiresOn = DateTimeOffset.UtcNow.AddHours(24),
                };
                sasBuilder.SetPermissions(
                    BlobContainerSasPermissions.Read
                        | BlobContainerSasPermissions.Write
                        | BlobContainerSasPermissions.List
                        | BlobContainerSasPermissions.Add
                        | BlobContainerSasPermissions.Create
                        | BlobContainerSasPermissions.Delete
                );

                // Get user delegation key for SAS token
                var userDelegationKey = await blobServiceClient.GetUserDelegationKeyAsync(
                    startsOn: DateTimeOffset.UtcNow,
                    expiresOn: DateTimeOffset.UtcNow.AddHours(24)
                );

                var sasToken = sasBuilder
                    .ToSasQueryParameters(userDelegationKey, storageAccount)
                    .ToString();
                trainingDataSasUrl =
                    $"https://{storageAccount}.blob.core.windows.net/{containerName}?{sasToken}";
            }
            else
            {
                throw new InvalidOperationException(
                    "Either TRAINING_DATA_SAS_URL or both TRAINING_DATA_STORAGE_ACCOUNT and TRAINING_DATA_CONTAINER_NAME must be provided"
                );
            }

            string trainingDataPath =
                Environment.GetEnvironmentVariable("TRAINING_DATA_PATH") ?? "training_data/";
#else
            // Get training data SAS URL (from configuration or by generating)
            string trainingDataSasUrl = await GetOrGenerateTrainingDataSasUrlAsync();
            string trainingDataPath = TestEnvironment.TrainingDataPath ?? "training_data/";
#endif

            // Ensure path ends with /
            if (!string.IsNullOrEmpty(trainingDataPath) && !trainingDataPath.EndsWith("/"))
            {
                trainingDataPath += "/";
            }

            // Upload training documents with labels and OCR results
            string trainingDocsFolder = Path.Combine(
                Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
                    ?? string.Empty,
                "TestData",
                "document_training"
            );

            if (Directory.Exists(trainingDocsFolder))
            {
                var containerClient = new BlobContainerClient(new Uri(trainingDataSasUrl));
                var files = Directory.GetFiles(trainingDocsFolder);

                foreach (var file in files)
                {
                    string fileName = Path.GetFileName(file);

                    // Process each main document (filter out .labels.json and .result.json metadata files)
                    if (!fileName.EndsWith(".labels.json") && !fileName.EndsWith(".result.json"))
                    {
                        // Upload the main document
                        string blobPath = trainingDataPath + fileName;
                        var blobClient = containerClient.GetBlobClient(blobPath);

                        using (var fileStream = File.OpenRead(file))
                        {
                            await blobClient.UploadAsync(fileStream, overwrite: true);
                        }

                        // Upload associated labels.json
                        string labelsFile = file + ".labels.json";
                        if (File.Exists(labelsFile))
                        {
                            string labelsBlobPath = trainingDataPath + fileName + ".labels.json";
                            var labelsBlobClient = containerClient.GetBlobClient(labelsBlobPath);
                            using (var labelsStream = File.OpenRead(labelsFile))
                            {
                                await labelsBlobClient.UploadAsync(labelsStream, overwrite: true);
                            }
                        }

                        // Upload associated result.json
                        string resultFile = file + ".result.json";
                        if (File.Exists(resultFile))
                        {
                            string resultBlobPath = trainingDataPath + fileName + ".result.json";
                            var resultBlobClient = containerClient.GetBlobClient(resultBlobPath);
                            using (var resultStream = File.OpenRead(resultFile))
                            {
                                await resultBlobClient.UploadAsync(resultStream, overwrite: true);
                            }
                        }
                    }
                }
                Console.WriteLine("Training data uploaded to blob storage successfully.");
            }

            // Step 2: Define field schema for receipt extraction
            // Create the Items array item definition (object with properties)
            var itemDefinition = new ContentFieldDefinition
            {
                Type = ContentFieldType.Object,
                Method = GenerationMethod.Extract,
                Description = "Individual item details",
            };
            itemDefinition.Properties.Add(
                "Quantity",
                new ContentFieldDefinition
                {
                    Type = ContentFieldType.String,
                    Method = GenerationMethod.Extract,
                    Description = "Quantity of the item",
                }
            );
            itemDefinition.Properties.Add(
                "Name",
                new ContentFieldDefinition
                {
                    Type = ContentFieldType.String,
                    Method = GenerationMethod.Extract,
                    Description = "Name of the item",
                }
            );
            itemDefinition.Properties.Add(
                "Price",
                new ContentFieldDefinition
                {
                    Type = ContentFieldType.String,
                    Method = GenerationMethod.Extract,
                    Description = "Price of the item",
                }
            );

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
                    ["TotalPrice"] = new ContentFieldDefinition
                    {
                        Type = ContentFieldType.String,
                        Method = GenerationMethod.Extract,
                        Description = "Total price on the receipt",
                    },
                }
            )
            {
                Name = "receipt_schema",
                Description = "Schema for receipt extraction with labeled training data",
            };

            // Step 3: Configure knowledge sources with labeled data
            var knowledgeSource = new LabeledDataKnowledgeSource(new Uri(trainingDataSasUrl))
            {
                Prefix = trainingDataPath,
            };

            // Step 4: Create analyzer configuration
            var config = new ContentAnalyzerConfig
            {
                EnableFormula = false,
                EnableLayout = true,
                EnableOcr = true,
                EstimateFieldSourceAndConfidence = true,
                ReturnDetails = true,
            };

            // Step 5: Create the custom analyzer with knowledge sources
            var customAnalyzer = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-document",
                Description = "Receipt analyzer trained with labeled data",
                Config = config,
                FieldSchema = fieldSchema,
            };

            // Add knowledge source
            customAnalyzer.KnowledgeSources.Add(knowledgeSource);

            // Add model mappings (required when using knowledge sources)
            customAnalyzer.Models.Add("completion", "gpt-4.1");
            customAnalyzer.Models.Add("embedding", "text-embedding-3-large");

            // Create the analyzer
            var operation = await client.CreateAnalyzerAsync(
                WaitUntil.Completed,
                analyzerId,
                customAnalyzer,
                allowReplace: true
            );

            ContentAnalyzer result = operation.Value;
            Console.WriteLine(
                $"Analyzer '{analyzerId}' created successfully with labeled training data!"
            );
            #endregion

            #region Assertion:ContentUnderstandingCreateAnalyzerWithLabels
            Assert.IsNotNull(analyzerId, "Analyzer ID should not be null");
            Assert.IsFalse(
                string.IsNullOrWhiteSpace(analyzerId),
                "Analyzer ID should not be empty"
            );
            Assert.IsNotNull(fieldSchema, "Field schema should not be null");
            Assert.IsNotNull(customAnalyzer, "Custom analyzer should not be null");
            Assert.IsNotNull(operation, "Create analyzer operation should not be null");
            Assert.IsTrue(operation.HasCompleted, "Operation should be completed");
            Assert.IsTrue(operation.HasValue, "Operation should have a value");
            Assert.IsNotNull(
                operation.GetRawResponse(),
                "Create analyzer operation should have a raw response"
            );
            Assert.IsTrue(
                operation.GetRawResponse().Status >= 200 && operation.GetRawResponse().Status < 300,
                $"Response status should be successful, but was {operation.GetRawResponse().Status}"
            );
            Console.WriteLine("Create analyzer operation properties verified");

            Assert.IsNotNull(result, "Analyzer result should not be null");
            Console.WriteLine($"Analyzer '{analyzerId}' created successfully with labeled data");

            // Verify base analyzer
            Assert.IsNotNull(result.BaseAnalyzerId, "Base analyzer ID should not be null");
            Assert.AreEqual(
                "prebuilt-document",
                result.BaseAnalyzerId,
                "Base analyzer ID should match"
            );
            Console.WriteLine($"Base analyzer ID verified: {result.BaseAnalyzerId}");

            // Verify analyzer config
            Assert.IsNotNull(result.Config, "Analyzer config should not be null");
            Assert.IsFalse(result.Config.EnableFormula, "EnableFormula should be false");
            Assert.IsTrue(result.Config.EnableLayout, "EnableLayout should be true");
            Assert.IsTrue(result.Config.EnableOcr, "EnableOcr should be true");
            Assert.IsTrue(
                result.Config.EstimateFieldSourceAndConfidence,
                "EstimateFieldSourceAndConfidence should be true"
            );
            Assert.IsTrue(result.Config.ReturnDetails, "ReturnDetails should be true");
            Console.WriteLine("Analyzer config verified");

            // Verify field schema
            Assert.IsNotNull(result.FieldSchema, "Field schema should not be null");
            Assert.IsFalse(
                string.IsNullOrWhiteSpace(result.FieldSchema.Name),
                "Field schema name should not be empty"
            );
            Assert.AreEqual(
                "receipt_schema",
                result.FieldSchema.Name,
                "Field schema name should match"
            );
            Console.WriteLine($"Field schema verified: {result.FieldSchema.Name}");

            // Verify field schema fields
            Assert.IsNotNull(result.FieldSchema.Fields, "Field schema fields should not be null");
            Assert.AreEqual(3, result.FieldSchema.Fields.Count, "Should have 3 custom fields");
            Console.WriteLine($"Field schema contains {result.FieldSchema.Fields.Count} fields");

            // Verify MerchantName field
            Assert.IsTrue(
                result.FieldSchema.Fields.ContainsKey("MerchantName"),
                "Should contain MerchantName field"
            );
            var merchantNameDef = result.FieldSchema.Fields["MerchantName"];
            Assert.AreEqual(
                ContentFieldType.String,
                merchantNameDef.Type,
                "MerchantName should be String type"
            );
            Assert.AreEqual(
                GenerationMethod.Extract,
                merchantNameDef.Method,
                "MerchantName should use Extract method"
            );
            Console.WriteLine("  MerchantName field verified (String, Extract)");

            // Verify Items field (array of objects)
            Assert.IsTrue(
                result.FieldSchema.Fields.ContainsKey("Items"),
                "Should contain Items field"
            );
            var itemsDef = result.FieldSchema.Fields["Items"];
            Assert.AreEqual(ContentFieldType.Array, itemsDef.Type, "Items should be Array type");
            Assert.AreEqual(
                GenerationMethod.Generate,
                itemsDef.Method,
                "Items should use Generate method"
            );
            Assert.IsNotNull(itemsDef.ItemDefinition, "Items should have item definition");
            Assert.AreEqual(
                ContentFieldType.Object,
                itemsDef.ItemDefinition.Type,
                "Items.ItemDefinition should be Object type"
            );
            Assert.IsNotNull(
                itemsDef.ItemDefinition.Properties,
                "Items.ItemDefinition should have properties"
            );
            Assert.AreEqual(
                3,
                itemsDef.ItemDefinition.Properties.Count,
                "Items.ItemDefinition should have 3 properties"
            );
            Assert.IsTrue(
                itemsDef.ItemDefinition.Properties.ContainsKey("Quantity"),
                "Items.ItemDefinition should have Quantity property"
            );
            Assert.IsTrue(
                itemsDef.ItemDefinition.Properties.ContainsKey("Name"),
                "Items.ItemDefinition should have Name property"
            );
            Assert.IsTrue(
                itemsDef.ItemDefinition.Properties.ContainsKey("Price"),
                "Items.ItemDefinition should have Price property"
            );
            Console.WriteLine("  Items field verified (Array of Objects with 3 properties)");

            // Verify TotalPrice field
            Assert.IsTrue(
                result.FieldSchema.Fields.ContainsKey("TotalPrice"),
                "Should contain TotalPrice field"
            );
            var totalPriceDef = result.FieldSchema.Fields["TotalPrice"];
            Assert.AreEqual(
                ContentFieldType.String,
                totalPriceDef.Type,
                "TotalPrice should be String type"
            );
            Assert.AreEqual(
                GenerationMethod.Extract,
                totalPriceDef.Method,
                "TotalPrice should use Extract method"
            );
            Console.WriteLine("  TotalPrice field verified (String, Extract)");

            // Verify knowledge sources
            Assert.IsNotNull(result.KnowledgeSources, "Knowledge sources should not be null");
            Assert.AreEqual(1, result.KnowledgeSources.Count, "Should have 1 knowledge source");
            var ks = result.KnowledgeSources[0];
            Assert.IsInstanceOf<LabeledDataKnowledgeSource>(
                ks,
                "Knowledge source should be LabeledDataKnowledgeSource"
            );
            var labeledKs = (LabeledDataKnowledgeSource)ks;
            Assert.IsNotNull(
                labeledKs.ContainerUrl,
                "Knowledge source container URL should not be null"
            );
            Assert.IsFalse(
                string.IsNullOrWhiteSpace(labeledKs.Prefix),
                "Knowledge source prefix should not be empty"
            );
            Console.WriteLine(
                $"Knowledge source verified: type=LabeledData, prefix={labeledKs.Prefix}"
            );

            // Verify models
            Assert.IsNotNull(result.Models, "Models should not be null");
            Assert.IsTrue(result.Models.Count >= 2, "Should have at least 2 model mappings");
            Assert.IsTrue(
                result.Models.ContainsKey("completion"),
                "Should contain 'completion' model mapping"
            );
            Assert.IsTrue(
                result.Models.ContainsKey("embedding"),
                "Should contain 'embedding' model mapping"
            );
            Assert.AreEqual(
                "gpt-4.1",
                result.Models["completion"],
                "Completion model should be 'gpt-4.1'"
            );
            Assert.AreEqual(
                "text-embedding-3-large",
                result.Models["embedding"],
                "Embedding model should be 'text-embedding-3-large'"
            );
            Console.WriteLine($"Model mappings verified: {result.Models.Count} model(s)");

            Console.WriteLine(
                "All analyzer creation with labeled data properties validated successfully"
            );
            #endregion

            #region Snippet:ContentUnderstandingDeleteAnalyzerWithLabels
            // Clean up: delete the analyzer (for testing purposes only)
            // In production, trained analyzers are typically kept and reused
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

        /// <summary>
        /// Helper method to get or generate training data SAS URL.
        /// </summary>
        private async Task<string> GetOrGenerateTrainingDataSasUrlAsync()
        {
            // If SAS URL is provided directly, use it
            if (!string.IsNullOrEmpty(TestEnvironment.TrainingDataSasUrl))
            {
                return TestEnvironment.TrainingDataSasUrl!;
            }

            // Otherwise, generate from storage account and container name
            string? storageAccount = TestEnvironment.TrainingDataStorageAccount;
            string? containerName = TestEnvironment.TrainingDataContainerName;

            if (string.IsNullOrEmpty(storageAccount) || string.IsNullOrEmpty(containerName))
            {
                throw new InvalidOperationException(
                    "Either TRAINING_DATA_SAS_URL or both TRAINING_DATA_STORAGE_ACCOUNT and TRAINING_DATA_CONTAINER_NAME must be provided"
                );
            }

            // Use DefaultAzureCredential to authenticate
            var blobServiceClient = new BlobServiceClient(
                new Uri($"https://{storageAccount}.blob.core.windows.net"),
                TestEnvironment.Credential
            );

            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            // Ensure container exists
            await containerClient.CreateIfNotExistsAsync();

            // Generate user delegation SAS token valid for 24 hours
            var sasBuilder = new BlobSasBuilder
            {
                BlobContainerName = containerName,
                Resource = "c", // Container
                ExpiresOn = DateTimeOffset.UtcNow.AddHours(24),
            };
            sasBuilder.SetPermissions(
                BlobContainerSasPermissions.Read
                    | BlobContainerSasPermissions.Add
                    | BlobContainerSasPermissions.Create
                    | BlobContainerSasPermissions.Write
                    | BlobContainerSasPermissions.Delete
                    | BlobContainerSasPermissions.List
            );

            // Get user delegation key
            var userDelegationKey = await blobServiceClient.GetUserDelegationKeyAsync(
                startsOn: DateTimeOffset.UtcNow,
                expiresOn: DateTimeOffset.UtcNow.AddHours(24)
            );

            var sasToken = sasBuilder
                .ToSasQueryParameters(userDelegationKey.Value, storageAccount)
                .ToString();
            var sasUrl =
                $"https://{storageAccount}.blob.core.windows.net/{containerName}?{sasToken}";

            // Record the generated SAS URL for playback
            Recording.SetVariable("TRAINING_DATA_SAS_URL", sasUrl);

            return sasUrl;
        }
    }
}
