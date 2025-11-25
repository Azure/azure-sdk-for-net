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
        public async Task GrantCopyAuthAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var sourceClient = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            #region Snippet:ContentUnderstandingGrantCopyAuth
#if SNIPPET
            // Get source endpoint from configuration
            // Note: configuration is already loaded in Main method
            string sourceEndpoint = configuration["AZURE_CONTENT_UNDERSTANDING_ENDPOINT"] ?? throw new InvalidOperationException("AZURE_CONTENT_UNDERSTANDING_ENDPOINT is required");
            string? sourceKey = configuration["AZURE_CONTENT_UNDERSTANDING_KEY"];

            // Create source client
            var sourceClientOptions = new ContentUnderstandingClientOptions();
            ContentUnderstandingClient sourceClient = !string.IsNullOrEmpty(sourceKey)
                ? new ContentUnderstandingClient(new Uri(sourceEndpoint), new AzureKeyCredential(sourceKey), sourceClientOptions)
                : new ContentUnderstandingClient(new Uri(sourceEndpoint), new DefaultAzureCredential(), sourceClientOptions);

            // Generate unique analyzer IDs
            string sourceAnalyzerId = $"my_analyzer_source_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
            string targetAnalyzerId = $"my_analyzer_target_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

            // Get source and target resource information from configuration
            string sourceResourceId = configuration["AZURE_CONTENT_UNDERSTANDING_SOURCE_RESOURCE_ID"] ?? throw new InvalidOperationException("AZURE_CONTENT_UNDERSTANDING_SOURCE_RESOURCE_ID is required");
            string sourceRegion = configuration["AZURE_CONTENT_UNDERSTANDING_SOURCE_REGION"] ?? throw new InvalidOperationException("AZURE_CONTENT_UNDERSTANDING_SOURCE_REGION is required");
            string targetEndpoint = configuration["AZURE_CONTENT_UNDERSTANDING_TARGET_ENDPOINT"] ?? throw new InvalidOperationException("AZURE_CONTENT_UNDERSTANDING_TARGET_ENDPOINT is required");
            string targetResourceId = configuration["AZURE_CONTENT_UNDERSTANDING_TARGET_RESOURCE_ID"] ?? throw new InvalidOperationException("AZURE_CONTENT_UNDERSTANDING_TARGET_RESOURCE_ID is required");
            string targetRegion = configuration["AZURE_CONTENT_UNDERSTANDING_TARGET_REGION"] ?? throw new InvalidOperationException("AZURE_CONTENT_UNDERSTANDING_TARGET_REGION is required");
            string? targetKey = configuration["AZURE_CONTENT_UNDERSTANDING_TARGET_KEY"];

            // Create target client
            var targetClientOptions = new ContentUnderstandingClientOptions();
            ContentUnderstandingClient targetClient = !string.IsNullOrEmpty(targetKey)
                ? new ContentUnderstandingClient(new Uri(targetEndpoint), new AzureKeyCredential(targetKey), targetClientOptions)
                : new ContentUnderstandingClient(new Uri(targetEndpoint), new DefaultAzureCredential(), targetClientOptions);
#else
            // For testing, we'll use the same endpoint for both source and target
            // In production, these would be different resources
            string defaultSourceId = $"test_analyzer_source_{Recording.Random.NewGuid().ToString("N")}";
            string defaultTargetId = $"test_analyzer_target_{Recording.Random.NewGuid().ToString("N")}";
            string sourceAnalyzerId = Recording.GetVariable("grantCopySourceAnalyzerId", defaultSourceId) ?? defaultSourceId;
            string targetAnalyzerId = Recording.GetVariable("grantCopyTargetAnalyzerId", defaultTargetId) ?? defaultTargetId;

            // Get source and target resource information from test environment
            // Note: For testing, we use the same endpoint for both source and target
            // In production, these would be different resources
            string sourceResourceId = TestEnvironment.SourceResourceId ?? throw new InvalidOperationException("SOURCE_RESOURCE_ID is required");
            string sourceRegion = TestEnvironment.SourceRegion ?? throw new InvalidOperationException("SOURCE_REGION is required");
            string targetEndpoint = TestEnvironment.TargetEndpoint;
            string targetResourceId = TestEnvironment.TargetResourceId ?? throw new InvalidOperationException("TARGET_RESOURCE_ID is required");
            string targetRegion = TestEnvironment.TargetRegion ?? throw new InvalidOperationException("TARGET_REGION is required");
            string? targetKey = TestEnvironment.TargetKey;

            // Create target client
            var targetClientOptions = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            ContentUnderstandingClient targetClient = !string.IsNullOrEmpty(targetKey)
                ? InstrumentClient(new ContentUnderstandingClient(new Uri(targetEndpoint), new AzureKeyCredential(targetKey!), targetClientOptions))
                : InstrumentClient(new ContentUnderstandingClient(new Uri(targetEndpoint), TestEnvironment.Credential, targetClientOptions));
#endif

            // Step 1: Create the source analyzer
            var sourceConfig = new ContentAnalyzerConfig
            {
                EnableFormula = false,
                EnableLayout = true,
                EnableOcr = true,
                EstimateFieldSourceAndConfidence = true,
                ReturnDetails = true
            };

            var sourceFieldSchema = new ContentFieldSchema(
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

            var sourceAnalyzer = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-document",
                Description = "Source analyzer for cross-resource copying",
                Config = sourceConfig,
                FieldSchema = sourceFieldSchema
            };
            sourceAnalyzer.Models.Add("completion", "gpt-4.1");

            var createOperation = await sourceClient.CreateAnalyzerAsync(
                WaitUntil.Completed,
                sourceAnalyzerId,
                sourceAnalyzer);
            var sourceResult = createOperation.Value;
            Console.WriteLine($"Source analyzer '{sourceAnalyzerId}' created successfully!");

            try
            {
                // Step 2: Grant copy authorization
                var copyAuth = await sourceClient.GrantCopyAuthorizationAsync(
                    sourceAnalyzerId,
                    targetResourceId,
                    targetRegion);

                Console.WriteLine("Copy authorization granted successfully!");
                Console.WriteLine($"  Target Azure Resource ID: {copyAuth.Value.TargetAzureResourceId}");
                Console.WriteLine($"  Target Region: {targetRegion}");
                Console.WriteLine($"  Expires at: {copyAuth.Value.ExpiresAt}");

                // Step 3: Copy the analyzer to target resource
                var copyOperation = await targetClient.CopyAnalyzerAsync(
                    WaitUntil.Completed,
                    targetAnalyzerId,
                    sourceAnalyzerId,
                    sourceResourceId,
                    sourceRegion);

                var targetResult = copyOperation.Value;
                Console.WriteLine($"Target analyzer '{targetAnalyzerId}' copied successfully to target resource!");
                Console.WriteLine($"Target analyzer description: {targetResult.Description}");
            }
            finally
            {
                // Clean up: delete both analyzers
                try
                {
                    await sourceClient.DeleteAnalyzerAsync(sourceAnalyzerId);
                    Console.WriteLine($"Source analyzer '{sourceAnalyzerId}' deleted successfully.");
                }
                catch
                {
                    // Ignore cleanup errors
                }

                try
                {
                    await targetClient.DeleteAnalyzerAsync(targetAnalyzerId);
                    Console.WriteLine($"Target analyzer '{targetAnalyzerId}' deleted successfully.");
                }
                catch
                {
                    // Ignore cleanup errors
                }
            }
            #endregion
        }
    }
}
