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
        public async Task CopyAnalyzerAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            // Generate unique analyzer IDs (deterministic for playback)
            string defaultSourceId = $"test_analyzer_source_{Recording.Random.NewGuid().ToString("N")}";
            string defaultTargetId = $"test_analyzer_target_{Recording.Random.NewGuid().ToString("N")}";
            string sourceAnalyzerId = Recording.GetVariable("copySourceAnalyzerId", defaultSourceId) ?? defaultSourceId;
            string targetAnalyzerId = Recording.GetVariable("copyTargetAnalyzerId", defaultTargetId) ?? defaultTargetId;

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
                Description = "Source analyzer for copying",
                Config = sourceConfig,
                FieldSchema = sourceFieldSchema
            };
            sourceAnalyzer.Models.Add("completion", "gpt-4.1");
            sourceAnalyzer.Tags.Add("modelType", "in_development");

            var createOperation = await client.CreateAnalyzerAsync(
                WaitUntil.Completed,
                sourceAnalyzerId,
                sourceAnalyzer);
            var sourceResult = createOperation.Value;
            Console.WriteLine($"Source analyzer '{sourceAnalyzerId}' created successfully!");

            #region Assertion:ContentUnderstandingCreateSourceAnalyzer
            Console.WriteLine("📋 Source Analyzer Creation Verification:");

            // Verify analyzer IDs
            Assert.IsNotNull(sourceAnalyzerId, "Source analyzer ID should not be null");
            Assert.IsFalse(string.IsNullOrWhiteSpace(sourceAnalyzerId), "Source analyzer ID should not be empty");
            Assert.IsNotNull(targetAnalyzerId, "Target analyzer ID should not be null");
            Assert.IsFalse(string.IsNullOrWhiteSpace(targetAnalyzerId), "Target analyzer ID should not be empty");
            Assert.AreNotEqual(sourceAnalyzerId, targetAnalyzerId, "Source and target IDs should be different");
            Console.WriteLine($"✅ Source analyzer ID: {sourceAnalyzerId}");
            Console.WriteLine($"✅ Target analyzer ID: {targetAnalyzerId}");

            // Verify source analyzer configuration
            Assert.IsNotNull(sourceConfig, "Source config should not be null");
            Assert.AreEqual(false, sourceConfig.EnableFormula, "EnableFormula should be false");
            Assert.AreEqual(true, sourceConfig.EnableLayout, "EnableLayout should be true");
            Assert.AreEqual(true, sourceConfig.EnableOcr, "EnableOcr should be true");
            Assert.AreEqual(true, sourceConfig.EstimateFieldSourceAndConfidence, "EstimateFieldSourceAndConfidence should be true");
            Assert.AreEqual(true, sourceConfig.ReturnDetails, "ReturnDetails should be true");
            Console.WriteLine("✅ Source config verified");

            // Verify source field schema
            Assert.IsNotNull(sourceFieldSchema, "Source field schema should not be null");
            Assert.AreEqual("company_schema", sourceFieldSchema.Name, "Field schema name should match");
            Assert.AreEqual("Schema for extracting company information", sourceFieldSchema.Description, "Field schema description should match");
            Assert.AreEqual(2, sourceFieldSchema.Fields.Count, "Should have 2 fields");
            Console.WriteLine($"✅ Source field schema verified: {sourceFieldSchema.Name}");

            // Verify individual fields
            Assert.IsTrue(sourceFieldSchema.Fields.ContainsKey("company_name"), "Should contain company_name field");
            var companyNameField = sourceFieldSchema.Fields["company_name"];
            Assert.AreEqual(ContentFieldType.String, companyNameField.Type, "company_name should be String type");
            Assert.AreEqual(GenerationMethod.Extract, companyNameField.Method, "company_name should use Extract method");
            Console.WriteLine("  ✅ company_name field verified");

            Assert.IsTrue(sourceFieldSchema.Fields.ContainsKey("total_amount"), "Should contain total_amount field");
            var totalAmountField = sourceFieldSchema.Fields["total_amount"];
            Assert.AreEqual(ContentFieldType.Number, totalAmountField.Type, "total_amount should be Number type");
            Assert.AreEqual(GenerationMethod.Extract, totalAmountField.Method, "total_amount should use Extract method");
            Console.WriteLine("  ✅ total_amount field verified");

            // Verify source analyzer object
            Assert.IsNotNull(sourceAnalyzer, "Source analyzer object should not be null");
            Assert.AreEqual("prebuilt-document", sourceAnalyzer.BaseAnalyzerId, "Base analyzer ID should match");
            Assert.AreEqual("Source analyzer for copying", sourceAnalyzer.Description, "Description should match");
            Assert.IsTrue(sourceAnalyzer.Models.ContainsKey("completion"), "Should have completion model");
            Assert.AreEqual("gpt-4.1", sourceAnalyzer.Models["completion"], "Completion model should be gpt-4.1");
            Assert.IsTrue(sourceAnalyzer.Tags.ContainsKey("modelType"), "Should have modelType tag");
            Assert.AreEqual("in_development", sourceAnalyzer.Tags["modelType"], "modelType tag should be in_development");
            Console.WriteLine("✅ Source analyzer object verified");

            // Verify create operation
            Assert.IsNotNull(createOperation, "Create source analyzer operation should not be null");
            Assert.IsTrue(createOperation.HasCompleted, "Operation should be completed");
            Assert.IsTrue(createOperation.HasValue, "Operation should have a value");
            Assert.IsNotNull(createOperation.GetRawResponse(), "Create source analyzer operation should have a raw response");
            Assert.IsTrue(createOperation.GetRawResponse().Status >= 200 && createOperation.GetRawResponse().Status < 300,
                $"Response status should be successful, but was {createOperation.GetRawResponse().Status}");
            Console.WriteLine($"✅ Create operation status: {createOperation.GetRawResponse().Status}");

            // Verify source result
            Assert.IsNotNull(sourceResult, "Source analyzer result should not be null");
            Assert.AreEqual("prebuilt-document", sourceResult.BaseAnalyzerId, "Base analyzer ID should match");
            Assert.AreEqual("Source analyzer for copying", sourceResult.Description, "Description should match");
            Console.WriteLine($"✅ Source analyzer created: '{sourceAnalyzerId}'");

            // Verify config in result
            Assert.IsNotNull(sourceResult.Config, "Config should not be null");
            Assert.AreEqual(false, sourceResult.Config.EnableFormula, "EnableFormula should be false");
            Assert.AreEqual(true, sourceResult.Config.EnableLayout, "EnableLayout should be true");
            Assert.AreEqual(true, sourceResult.Config.EnableOcr, "EnableOcr should be true");
            Assert.AreEqual(true, sourceResult.Config.EstimateFieldSourceAndConfidence, "EstimateFieldSourceAndConfidence should be true");
            Assert.AreEqual(true, sourceResult.Config.ReturnDetails, "ReturnDetails should be true");
            Console.WriteLine("✅ Config preserved in result");
            // Verify field schema in result
            Assert.IsNotNull(sourceResult.FieldSchema, "Field schema should not be null");
            Assert.AreEqual("company_schema", sourceResult.FieldSchema.Name, "Field schema name should match");
            Assert.AreEqual(2, sourceResult.FieldSchema.Fields.Count, "Should have 2 fields");
            Assert.IsTrue(sourceResult.FieldSchema.Fields.ContainsKey("company_name"), "Should contain company_name field");
            Assert.IsTrue(sourceResult.FieldSchema.Fields.ContainsKey("total_amount"), "Should contain total_amount field");
            Console.WriteLine($"✅ Field schema preserved in result: {sourceResult.FieldSchema.Fields.Count} fields");

            // Verify tags in result
            Assert.IsNotNull(sourceResult.Tags, "Tags should not be null");
            Assert.IsTrue(sourceResult.Tags.ContainsKey("modelType"), "Should contain modelType tag");
            Assert.AreEqual("in_development", sourceResult.Tags["modelType"], "modelType tag should match");
            Console.WriteLine($"✅ Tags preserved in result: {sourceResult.Tags.Count} tag(s)");

            // Verify models in result
            Assert.IsNotNull(sourceResult.Models, "Models should not be null");
            Assert.IsTrue(sourceResult.Models.ContainsKey("completion"), "Should have completion model");
            Assert.AreEqual("gpt-4.1", sourceResult.Models["completion"], "Completion model should match");
            Console.WriteLine($"✅ Models preserved in result: {sourceResult.Models.Count} model(s)");

            Console.WriteLine($"\n✅ Source analyzer creation completed:");
            Console.WriteLine($"  ID: {sourceAnalyzerId}");
            Console.WriteLine($"  Base: {sourceResult.BaseAnalyzerId}");
            Console.WriteLine($"  Fields: {sourceResult.FieldSchema.Fields.Count}");
            Console.WriteLine($"  Tags: {sourceResult.Tags.Count}");
            Console.WriteLine($"  Models: {sourceResult.Models.Count}");
            #endregion

            // Get the source analyzer to see its description and tags before copying
            var sourceResponse = await client.GetAnalyzerAsync(sourceAnalyzerId);
            ContentAnalyzer sourceAnalyzerInfo = sourceResponse.Value;
            Console.WriteLine($"Source analyzer description: {sourceAnalyzerInfo.Description}");
            Console.WriteLine($"Source analyzer tags: {string.Join(", ", sourceAnalyzerInfo.Tags.Select(kvp => $"{kvp.Key}={kvp.Value}"))}");

            #region Assertion:ContentUnderstandingGetSourceAnalyzer
            Console.WriteLine("\n🔍 Source Analyzer Retrieval Verification:");

            Assert.IsNotNull(sourceResponse, "Source analyzer response should not be null");
            Assert.IsTrue(sourceResponse.HasValue, "Source analyzer response should have a value");
            Assert.IsNotNull(sourceAnalyzerInfo, "Source analyzer info should not be null");
            Console.WriteLine("✅ Source analyzer retrieved successfully");

            // Verify raw response
            var sourceRawResponse = sourceResponse.GetRawResponse();
            Assert.IsNotNull(sourceRawResponse, "Raw response should not be null");
            Assert.AreEqual(200, sourceRawResponse.Status, $"Response status should be 200, but was {sourceRawResponse.Status}");
            Console.WriteLine($"✅ Response status: {sourceRawResponse.Status}");

            // Verify basic properties
            Assert.AreEqual("Source analyzer for copying", sourceAnalyzerInfo.Description,
                "Source description should match");
            Assert.AreEqual("prebuilt-document", sourceAnalyzerInfo.BaseAnalyzerId,
                "Base analyzer ID should match");
            Console.WriteLine($"✅ Description: '{sourceAnalyzerInfo.Description}'");
            Console.WriteLine($"✅ Base analyzer: {sourceAnalyzerInfo.BaseAnalyzerId}");

            // Verify tags
            Assert.IsNotNull(sourceAnalyzerInfo.Tags, "Tags should not be null");
            Assert.IsTrue(sourceAnalyzerInfo.Tags.ContainsKey("modelType"),
                "Source should contain modelType tag");
            Assert.AreEqual("in_development", sourceAnalyzerInfo.Tags["modelType"],
                "Source modelType tag should be 'in_development'");
            Console.WriteLine($"✅ Tags verified: modelType={sourceAnalyzerInfo.Tags["modelType"]}");

            // Verify field schema
            Assert.IsNotNull(sourceAnalyzerInfo.FieldSchema, "Field schema should not be null");
            Assert.AreEqual("company_schema", sourceAnalyzerInfo.FieldSchema.Name, "Field schema name should match");
            Assert.AreEqual(2, sourceAnalyzerInfo.FieldSchema.Fields.Count, "Should have 2 fields");
            Console.WriteLine($"✅ Field schema: {sourceAnalyzerInfo.FieldSchema.Name} ({sourceAnalyzerInfo.FieldSchema.Fields.Count} fields)");

            // Verify config
            Assert.IsNotNull(sourceAnalyzerInfo.Config, "Config should not be null");
            Console.WriteLine("✅ Config present");

            // Verify models
            Assert.IsNotNull(sourceAnalyzerInfo.Models, "Models should not be null");
            Assert.IsTrue(sourceAnalyzerInfo.Models.ContainsKey("completion"), "Should have completion model");
            Console.WriteLine($"✅ Models: {sourceAnalyzerInfo.Models.Count} model(s)");

            Console.WriteLine($"✅ Source analyzer retrieval verification completed");
            #endregion

            try
            {
                // Step 2: Copy the source analyzer to target
                // Note: This copies within the same resource. For cross-resource copying, use GrantCopyAuth sample.
                #region Snippet:ContentUnderstandingCopyAnalyzer
#if SNIPPET
                await client.CopyAnalyzerAsync(
                    WaitUntil.Completed,
                    targetAnalyzerId,
                    sourceAnalyzerId);
#else
                await client.CopyAnalyzerAsync(
                    WaitUntil.Completed,
                    targetAnalyzerId,
                    sourceAnalyzerId);
#endif
                #endregion

                #region Assertion:ContentUnderstandingCopyAnalyzer
                Console.WriteLine("\n📋 Analyzer Copy Verification:");

                // Verify the target analyzer was created by copying
                var copiedResponse = await client.GetAnalyzerAsync(targetAnalyzerId);
                Assert.IsNotNull(copiedResponse, "Copied analyzer response should not be null");
                Assert.IsTrue(copiedResponse.HasValue, "Copied analyzer response should have a value");
                Console.WriteLine($"✅ Target analyzer '{targetAnalyzerId}' retrieved successfully");

                // Verify raw response
                var copiedRawResponse = copiedResponse.GetRawResponse();
                Assert.IsNotNull(copiedRawResponse, "Raw response should not be null");
                Assert.AreEqual(200, copiedRawResponse.Status, $"Response status should be 200, but was {copiedRawResponse.Status}");
                Console.WriteLine($"✅ Response status: {copiedRawResponse.Status}");

                ContentAnalyzer copiedAnalyzer = copiedResponse.Value;
                Assert.IsNotNull(copiedAnalyzer, "Copied analyzer should not be null");

                // ========== Verify Base Properties ==========
                Console.WriteLine("\n🔍 Verifying copied properties.. .");

                Assert.IsNotNull(sourceAnalyzerInfo.BaseAnalyzerId, "Source base analyzer ID should not be null");
                Assert.IsNotNull(copiedAnalyzer.BaseAnalyzerId, "Copied base analyzer ID should not be null");
                Assert.AreEqual(sourceAnalyzerInfo.BaseAnalyzerId, copiedAnalyzer.BaseAnalyzerId,
                    $"Copied analyzer should have same base analyzer ID, but got '{copiedAnalyzer.BaseAnalyzerId}' instead of '{sourceAnalyzerInfo.BaseAnalyzerId}'");
                Console.WriteLine($"✅ Base analyzer ID: {copiedAnalyzer.BaseAnalyzerId}");

                Assert.IsNotNull(sourceAnalyzerInfo.Description, "Source description should not be null");
                Assert.IsNotNull(copiedAnalyzer.Description, "Copied description should not be null");
                Assert.AreEqual(sourceAnalyzerInfo.Description, copiedAnalyzer.Description,
                    $"Copied analyzer should have same description, but got '{copiedAnalyzer.Description}' instead of '{sourceAnalyzerInfo.Description}'");
                Console.WriteLine($"✅ Description: '{copiedAnalyzer.Description}'");

                // ========== Verify Field Schema ==========
                Console.WriteLine("\n📊 Verifying field schema...");

                Assert.IsNotNull(copiedAnalyzer.FieldSchema, "Copied analyzer should have field schema");
                Assert.IsNotNull(sourceAnalyzerInfo.FieldSchema, "Source analyzer should have field schema");
                Assert.AreEqual(sourceAnalyzerInfo.FieldSchema.Name, copiedAnalyzer.FieldSchema.Name,
                    "Field schema name should match");
                Assert.AreEqual(sourceAnalyzerInfo.FieldSchema.Fields.Count, copiedAnalyzer.FieldSchema.Fields.Count,
                    $"Copied analyzer should have same number of fields ({sourceAnalyzerInfo.FieldSchema.Fields.Count}), but got {copiedAnalyzer.FieldSchema.Fields.Count}");
                Console.WriteLine($"✅ Field schema: {copiedAnalyzer.FieldSchema.Name} ({copiedAnalyzer.FieldSchema.Fields.Count} fields)");

                // Verify individual fields
                Assert.IsTrue(copiedAnalyzer.FieldSchema.Fields.ContainsKey("company_name"),
                    "Copied analyzer should contain company_name field");
                var copiedCompanyNameField = copiedAnalyzer.FieldSchema.Fields["company_name"];
                var sourceCompanyNameField = sourceAnalyzerInfo.FieldSchema.Fields["company_name"];
                Assert.AreEqual(sourceCompanyNameField.Type, copiedCompanyNameField.Type,
                    "company_name field type should match");
                Assert.AreEqual(sourceCompanyNameField.Method, copiedCompanyNameField.Method,
                    "company_name field method should match");
                Assert.AreEqual(sourceCompanyNameField.Description, copiedCompanyNameField.Description,
                    "company_name field description should match");
                Console.WriteLine("  ✅ company_name field copied correctly");

                Assert.IsTrue(copiedAnalyzer.FieldSchema.Fields.ContainsKey("total_amount"),
                    "Copied analyzer should contain total_amount field");
                var copiedTotalAmountField = copiedAnalyzer.FieldSchema.Fields["total_amount"];
                var sourceTotalAmountField = sourceAnalyzerInfo.FieldSchema.Fields["total_amount"];
                Assert.AreEqual(sourceTotalAmountField.Type, copiedTotalAmountField.Type,
                    "total_amount field type should match");
                Assert.AreEqual(sourceTotalAmountField.Method, copiedTotalAmountField.Method,
                    "total_amount field method should match");
                Assert.AreEqual(sourceTotalAmountField.Description, copiedTotalAmountField.Description,
                    "total_amount field description should match");
                Console.WriteLine("  ✅ total_amount field copied correctly");

                // ========== Verify Tags ==========
                Console.WriteLine("\n🏷️ Verifying tags.. .");

                Assert.IsNotNull(copiedAnalyzer.Tags, "Copied analyzer should have tags");
                Assert.IsTrue(copiedAnalyzer.Tags.ContainsKey("modelType"),
                    "Copied analyzer should contain modelType tag");
                Assert.AreEqual("in_development", copiedAnalyzer.Tags["modelType"],
                    $"Copied analyzer should have same tag value 'in_development', but got '{copiedAnalyzer.Tags["modelType"]}'");
                Console.WriteLine($"✅ Tags copied: modelType={copiedAnalyzer.Tags["modelType"]}");

                // Verify tag counts match
                Assert.AreEqual(sourceAnalyzerInfo.Tags.Count, copiedAnalyzer.Tags.Count,
                    $"Copied analyzer should have same number of tags ({sourceAnalyzerInfo.Tags.Count}), but got {copiedAnalyzer.Tags.Count}");
                Console.WriteLine($"✅ Tag count matches: {copiedAnalyzer.Tags.Count}");

                // ========== Verify Config ==========
                Console.WriteLine("\n⚙️ Verifying config...");

                Assert.IsNotNull(copiedAnalyzer.Config, "Copied analyzer should have config");
                Assert.IsNotNull(sourceAnalyzerInfo.Config, "Source analyzer should have config");

                if (sourceAnalyzerInfo.Config.EnableFormula.HasValue && copiedAnalyzer.Config.EnableFormula.HasValue)
                {
                    Assert.AreEqual(sourceAnalyzerInfo.Config.EnableFormula.Value, copiedAnalyzer.Config.EnableFormula.Value,
                        "EnableFormula should match");
                    Console.WriteLine($"  EnableFormula: {copiedAnalyzer.Config.EnableFormula.Value}");
                }

                if (sourceAnalyzerInfo.Config.EnableLayout.HasValue && copiedAnalyzer.Config.EnableLayout.HasValue)
                {
                    Assert.AreEqual(sourceAnalyzerInfo.Config.EnableLayout.Value, copiedAnalyzer.Config.EnableLayout.Value,
                        "EnableLayout should match");
                    Console.WriteLine($"  EnableLayout: {copiedAnalyzer.Config.EnableLayout.Value}");
                }

                if (sourceAnalyzerInfo.Config.EnableOcr.HasValue && copiedAnalyzer.Config.EnableOcr.HasValue)
                {
                    Assert.AreEqual(sourceAnalyzerInfo.Config.EnableOcr.Value, copiedAnalyzer.Config.EnableOcr.Value,
                        "EnableOcr should match");
                    Console.WriteLine($"  EnableOcr: {copiedAnalyzer.Config.EnableOcr.Value}");
                }

                Console.WriteLine("✅ Config copied correctly");

                // ========== Verify Models ==========
                Console.WriteLine("\n🤖 Verifying models...");

                Assert.IsNotNull(copiedAnalyzer.Models, "Copied analyzer should have models");
                Assert.IsNotNull(sourceAnalyzerInfo.Models, "Source analyzer should have models");
                Assert.AreEqual(sourceAnalyzerInfo.Models.Count, copiedAnalyzer.Models.Count,
                    $"Copied analyzer should have same number of models ({sourceAnalyzerInfo.Models.Count}), but got {copiedAnalyzer.Models.Count}");

                if (sourceAnalyzerInfo.Models.ContainsKey("completion") && copiedAnalyzer.Models.ContainsKey("completion"))
                {
                    Assert.AreEqual(sourceAnalyzerInfo.Models["completion"], copiedAnalyzer.Models["completion"],
                        "Completion model should match");
                    Console.WriteLine($"✅ Models copied: completion={copiedAnalyzer.Models["completion"]}");
                }

                // ========== Summary ==========
                Console.WriteLine($"\n✅ Analyzer copy verification completed successfully:");
                Console.WriteLine($"  Source: {sourceAnalyzerId}");
                Console.WriteLine($"  Target: {targetAnalyzerId}");
                Console.WriteLine($"  Base analyzer: {copiedAnalyzer.BaseAnalyzerId}");
                Console.WriteLine($"  Description: {copiedAnalyzer.Description}");
                Console.WriteLine($"  Fields: {copiedAnalyzer.FieldSchema.Fields.Count}");
                Console.WriteLine($"  Tags: {copiedAnalyzer.Tags.Count}");
                Console.WriteLine($"  Models: {copiedAnalyzer.Models.Count}");
                Console.WriteLine($"  All properties verified: ✅");
                #endregion

                // Step 3: Update the target analyzer with a production tag
                // Step 4: Get the target analyzer again to verify the update
                #region Snippet:ContentUnderstandingUpdateAndVerifyAnalyzer
#if SNIPPET
                // Get the target analyzer first to get its BaseAnalyzerId
                var targetResponse = await client.GetAnalyzerAsync(targetAnalyzerId);
                ContentAnalyzer targetAnalyzer = targetResponse.Value;

                // Update the target analyzer with a production tag
                var updatedAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = targetAnalyzer.BaseAnalyzerId
                };
                updatedAnalyzer.Tags["modelType"] = "model_in_production";

                await client.UpdateAnalyzerAsync(targetAnalyzerId, updatedAnalyzer);

                // Get the target analyzer again to verify the update
                var updatedResponse = await client.GetAnalyzerAsync(targetAnalyzerId);
                ContentAnalyzer updatedTargetAnalyzer = updatedResponse.Value;
                Console.WriteLine($"Updated target analyzer description: {updatedTargetAnalyzer.Description}");
                Console.WriteLine($"Updated target analyzer tag: {updatedTargetAnalyzer.Tags["modelType"]}");
#else
                // Get the target analyzer first to get its BaseAnalyzerId
                var targetResponse = await client.GetAnalyzerAsync(targetAnalyzerId);
                ContentAnalyzer targetAnalyzer = targetResponse.Value;

                // Update the target analyzer with a production tag
                var updatedAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = targetAnalyzer.BaseAnalyzerId
                };
                updatedAnalyzer.Tags["modelType"] = "model_in_production";

                await client.UpdateAnalyzerAsync(targetAnalyzerId, updatedAnalyzer);

                // Get the target analyzer again to verify the update
                var updatedResponse = await client.GetAnalyzerAsync(targetAnalyzerId);
                ContentAnalyzer updatedTargetAnalyzer = updatedResponse.Value;
                Console.WriteLine($"Updated target analyzer description: {updatedTargetAnalyzer.Description}");
                Console.WriteLine($"Updated target analyzer tag: {updatedTargetAnalyzer.Tags["modelType"]}");
#endif
                #endregion

                #region Assertion:ContentUnderstandingUpdateAndVerifyAnalyzer
                Console.WriteLine("\n🔄 Analyzer Update Verification:");

                // ========== Verify Target Retrieval Before Update ==========
                Assert.IsNotNull(targetResponse, "Target analyzer response should not be null");
                Assert.IsTrue(targetResponse.HasValue, "Target analyzer response should have a value");
                Assert.IsNotNull(targetAnalyzer, "Target analyzer should not be null");
                Console.WriteLine($"✅ Target analyzer retrieved before update");

                // Verify raw response
                var targetRawResponse = targetResponse.GetRawResponse();
                Assert.IsNotNull(targetRawResponse, "Raw response should not be null");
                Assert.AreEqual(200, targetRawResponse.Status, $"Response status should be 200, but was {targetRawResponse.Status}");

                // ========== Verify Update Object ==========
                Assert.IsNotNull(updatedAnalyzer, "Updated analyzer object should not be null");
                Assert.AreEqual(targetAnalyzer.BaseAnalyzerId, updatedAnalyzer.BaseAnalyzerId,
                    "Updated analyzer should preserve base analyzer ID");
                Assert.IsTrue(updatedAnalyzer.Tags.ContainsKey("modelType"), "Updated analyzer should have modelType tag");
                Assert.AreEqual("model_in_production", updatedAnalyzer.Tags["modelType"],
                    "Updated analyzer should have new tag value");
                Console.WriteLine("✅ Update object created with new tag value");

                // ========== Verify Updated Retrieval ==========
                Assert.IsNotNull(updatedResponse, "Updated analyzer response should not be null");
                Assert.IsTrue(updatedResponse.HasValue, "Updated analyzer response should have a value");
                Assert.IsNotNull(updatedTargetAnalyzer, "Updated target analyzer should not be null");
                Console.WriteLine($"✅ Updated analyzer retrieved successfully");

                // Verify raw response
                var updatedRawResponse = updatedResponse.GetRawResponse();
                Assert.IsNotNull(updatedRawResponse, "Raw response should not be null");
                Assert.AreEqual(200, updatedRawResponse.Status, $"Response status should be 200, but was {updatedRawResponse.Status}");
                Console.WriteLine($"✅ Response status: {updatedRawResponse.Status}");

                // ========== Verify Description Preserved ==========
                Console.WriteLine("\n📝 Verifying preserved properties...");

                Assert.IsNotNull(updatedTargetAnalyzer.Description, "Description should not be null");
                Assert.AreEqual("Source analyzer for copying", updatedTargetAnalyzer.Description,
                    $"Description should be preserved from source, but got '{updatedTargetAnalyzer.Description}'");
                Console.WriteLine($"✅ Description preserved: '{updatedTargetAnalyzer.Description}'");

                // ========== Verify Tag Updated ==========
                Console.WriteLine("\n🏷️ Verifying tag update...");

                Assert.IsNotNull(updatedTargetAnalyzer.Tags, "Tags should not be null");
                Assert.IsTrue(updatedTargetAnalyzer.Tags.ContainsKey("modelType"),
                    "Updated analyzer should contain modelType tag");
                Assert.AreEqual("model_in_production", updatedTargetAnalyzer.Tags["modelType"],
                    $"Tag should be updated to 'model_in_production', but got '{updatedTargetAnalyzer.Tags["modelType"]}'");
                Assert.AreNotEqual("in_development", updatedTargetAnalyzer.Tags["modelType"],
                    "Tag should no longer be 'in_development'");
                Console.WriteLine($"✅ Tag updated: in_development → model_in_production");

                // ========== Verify Field Schema Preserved ==========
                Console.WriteLine("\n📊 Verifying field schema preservation...");

                Assert.IsNotNull(updatedTargetAnalyzer.FieldSchema,
                    "Field schema should still exist after update");
                Assert.AreEqual("company_schema", updatedTargetAnalyzer.FieldSchema.Name,
                    "Field schema name should be preserved");
                Assert.AreEqual(2, updatedTargetAnalyzer.FieldSchema.Fields.Count,
                    $"Should still have 2 fields after update, but got {updatedTargetAnalyzer.FieldSchema.Fields.Count}");
                Assert.IsTrue(updatedTargetAnalyzer.FieldSchema.Fields.ContainsKey("company_name"),
                    "company_name field should still exist");
                Assert.IsTrue(updatedTargetAnalyzer.FieldSchema.Fields.ContainsKey("total_amount"),
                    "total_amount field should still exist");
                Console.WriteLine($"✅ Field schema preserved: {updatedTargetAnalyzer.FieldSchema.Fields.Count} fields");
                // ========== Verify Base Analyzer ID Preserved ==========
                Console.WriteLine("\n🔗 Verifying base analyzer preservation...");

                Assert.IsNotNull(updatedTargetAnalyzer.BaseAnalyzerId, "Base analyzer ID should not be null");
                Assert.AreEqual(sourceAnalyzerInfo.BaseAnalyzerId, updatedTargetAnalyzer.BaseAnalyzerId,
                    $"Base analyzer ID should be preserved, but got '{updatedTargetAnalyzer.BaseAnalyzerId}' instead of '{sourceAnalyzerInfo.BaseAnalyzerId}'");
                Assert.AreEqual("prebuilt-document", updatedTargetAnalyzer.BaseAnalyzerId,
                    "Base analyzer ID should still be 'prebuilt-document'");
                Console.WriteLine($"✅ Base analyzer preserved: {updatedTargetAnalyzer.BaseAnalyzerId}");

                // ========== Verify Config Preserved ==========
                Console.WriteLine("\n⚙️ Verifying config preservation...");

                Assert.IsNotNull(updatedTargetAnalyzer.Config, "Config should still exist after update");
                Console.WriteLine("✅ Config preserved");

                // ========== Verify Models Preserved ==========
                Console.WriteLine("\n🤖 Verifying models preservation...");

                Assert.IsNotNull(updatedTargetAnalyzer.Models, "Models should still exist after update");
                if (updatedTargetAnalyzer.Models.ContainsKey("completion"))
                {
                    Assert.AreEqual("gpt-4.1", updatedTargetAnalyzer.Models["completion"],
                        "Completion model should be preserved");
                    Console.WriteLine($"✅ Models preserved: completion={updatedTargetAnalyzer.Models["completion"]}");
                }

                // ========== Compare Before and After ==========
                Console.WriteLine("\n📊 Update comparison:");
                Console.WriteLine($"  Property          | Before            | After");
                Console.WriteLine($"  ----------------- | ----------------- | -----------------");
                Console.WriteLine($"  Description       | (preserved)       | {updatedTargetAnalyzer.Description}");
                Console.WriteLine($"  Tag modelType     | in_development    | model_in_production");
                Console.WriteLine($"  Fields            | (preserved)       | {updatedTargetAnalyzer.FieldSchema.Fields.Count}");
                Console.WriteLine($"  Base analyzer     | (preserved)       | {updatedTargetAnalyzer.BaseAnalyzerId}");
                Console.WriteLine($"  Config            | (preserved)       | Yes");
                Console.WriteLine($"  Models            | (preserved)       | {updatedTargetAnalyzer.Models.Count}");

                // ========== Summary ==========
                Console.WriteLine($"\n✅ Analyzer update verification completed successfully:");
                Console.WriteLine($"  Analyzer ID: {targetAnalyzerId}");
                Console.WriteLine($"  Description: Preserved ✅");
                Console.WriteLine($"  Tag updated: in_development → model_in_production ✅");
                Console.WriteLine($"  Field schema: Preserved ({updatedTargetAnalyzer.FieldSchema.Fields.Count} fields) ✅");
                Console.WriteLine($"  Base analyzer: Preserved ({updatedTargetAnalyzer.BaseAnalyzerId}) ✅");
                Console.WriteLine($"  Config: Preserved ✅");
                Console.WriteLine($"  Models: Preserved ({updatedTargetAnalyzer.Models.Count}) ✅");
                #endregion
            }
            finally
            {
                // Clean up: delete both analyzers
                #region Snippet:ContentUnderstandingDeleteCopiedAnalyzers
#if SNIPPET
                try
                {
                    await client.DeleteAnalyzerAsync(sourceAnalyzerId);
                    Console.WriteLine($"Source analyzer '{sourceAnalyzerId}' deleted successfully.");
                }
                catch
                {
                    // Ignore cleanup errors
                }

                try
                {
                    await client.DeleteAnalyzerAsync(targetAnalyzerId);
                    Console.WriteLine($"Target analyzer '{targetAnalyzerId}' deleted successfully.");
                }
                catch
                {
                    // Ignore cleanup errors
                }
#else
                try
                {
                    await client.DeleteAnalyzerAsync(sourceAnalyzerId);
                    Console.WriteLine($"Source analyzer '{sourceAnalyzerId}' deleted successfully.");
                }
                catch
                {
                    // Ignore cleanup errors
                }

                try
                {
                    await client.DeleteAnalyzerAsync(targetAnalyzerId);
                    Console.WriteLine($"Target analyzer '{targetAnalyzerId}' deleted successfully.");
                }
                catch
                {
                    // Ignore cleanup errors
                }
#endif
                #endregion
            }
        }
    }
}
