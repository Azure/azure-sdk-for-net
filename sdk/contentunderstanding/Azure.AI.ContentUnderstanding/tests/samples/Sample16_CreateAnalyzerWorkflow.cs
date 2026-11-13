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
        [ServiceVersion(Min = ContentUnderstandingClientOptions.ServiceVersion.V2026_06_01_Preview)]
        public async Task CreateAnalyzerWorkflowAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            string defaultAnalyzerId = Recording.GetVariable(
                "workflowDefaultAnalyzerId",
                $"test_workflow_default_{Recording.Random.NewGuid():N}")!;
            string agenticAnalyzerId = Recording.GetVariable(
                "workflowAgenticAnalyzerId",
                $"test_workflow_agentic_{Recording.Random.NewGuid():N}")!;

            try
            {
                #region Snippet:ContentUnderstandingCreateAnalyzerWorkflowSchema
                var fieldSchema = new ContentFieldSchema(
                    new Dictionary<string, ContentFieldDefinition>
                    {
                        ["InvoiceId"] = new ContentFieldDefinition
                        {
                            Type = ContentFieldType.String,
                            Description = "Invoice identifier printed on the invoice. Return only the identifier value without its label."
                        },
                        ["AverageItemPrice"] = new ContentFieldDefinition
                        {
                            Type = ContentFieldType.Number,
                            Description = "Calculate the arithmetic mean of all values in the UNIT PRICE column. Use only unit prices, not quantities, line amounts, subtotals, taxes, or totals."
                        }
                    })
                {
                    Name = "invoice_workflow_comparison",
                    Description = "Invoice fields used to compare default and agentic workflows"
                };
                #endregion

                #region Snippet:ContentUnderstandingCreateAnalyzerWithDefaultWorkflow
                var defaultWorkflowAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Analyzer using default workflow",
                    FieldSchema = fieldSchema,
                    Config = new ContentAnalyzerConfig
                    {
                        ShouldReturnDetails = true
#if SNIPPET
                        // Workflow = ContentAnalyzerWorkflow.Default
#endif
                    }
                };
#if SNIPPET
                defaultWorkflowAnalyzer.Models["completion"] = "gpt-5.2";
#else
                defaultWorkflowAnalyzer.Models["completion"] = ModelProfile.CompletionModel;
#endif

#if SNIPPET
                Operation<ContentAnalyzer> defaultCreateOperation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    defaultAnalyzerId,
                    defaultWorkflowAnalyzer);
#else
                Operation<ContentAnalyzer> defaultCreateOperation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    defaultAnalyzerId,
                    defaultWorkflowAnalyzer,
                    allowReplace: true);
#endif
                #endregion

                #region Snippet:ContentUnderstandingCreateAnalyzerWithAgenticWorkflow
                var agenticWorkflowAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Analyzer using agentic workflow",
                    FieldSchema = fieldSchema,
                    Config = new ContentAnalyzerConfig
                    {
                        ShouldReturnDetails = true,
                        Workflow = ContentAnalyzerWorkflow.Agentic
                    }
                };
#if SNIPPET
                agenticWorkflowAnalyzer.Models["completion"] = "gpt-5.2";
#else
                agenticWorkflowAnalyzer.Models["completion"] = ModelProfile.CompletionModel;
#endif

#if SNIPPET
                Operation<ContentAnalyzer> agenticCreateOperation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    agenticAnalyzerId,
                    agenticWorkflowAnalyzer);
#else
                Operation<ContentAnalyzer> agenticCreateOperation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    agenticAnalyzerId,
                    agenticWorkflowAnalyzer,
                    allowReplace: true);
#endif
                #endregion

                Response<ContentAnalyzer> defaultAnalyzerResponse = await client.GetAnalyzerAsync(defaultAnalyzerId);
                Response<ContentAnalyzer> agenticAnalyzerResponse = await client.GetAnalyzerAsync(agenticAnalyzerId);

                Console.WriteLine($"Default analyzer workflow: {defaultAnalyzerResponse.Value.Config?.Workflow}");
                Console.WriteLine($"Agentic analyzer workflow: {agenticAnalyzerResponse.Value.Config?.Workflow}");

                #region Snippet:ContentUnderstandingCompareAnalyzerWorkflows
#if SNIPPET
                string invoicePath = "<localInvoiceFilePath>";
#else
                string invoicePath = ContentUnderstandingClientTestEnvironment.CreatePath("workflow_invoice_20_items.pdf");
#endif
                BinaryData invoiceData = BinaryData.FromBytes(File.ReadAllBytes(invoicePath));

                Operation<AnalysisResult> defaultAnalysis = await client.AnalyzeBinaryAsync(
                    WaitUntil.Completed,
                    defaultAnalyzerId,
                    invoiceData);
                Operation<AnalysisResult> agenticAnalysis = await client.AnalyzeBinaryAsync(
                    WaitUntil.Completed,
                    agenticAnalyzerId,
                    invoiceData);

                DocumentContent defaultContent = (DocumentContent)defaultAnalysis.Value.Contents!.First();
                DocumentContent agenticContent = (DocumentContent)agenticAnalysis.Value.Contents!.First();

                string? defaultInvoiceId = (defaultContent.Fields["InvoiceId"] as ContentStringField)?.Value;
                double? defaultAverageItemPrice = (defaultContent.Fields["AverageItemPrice"] as ContentNumberField)?.Value;
                string? agenticInvoiceId = (agenticContent.Fields["InvoiceId"] as ContentStringField)?.Value;
                double? agenticAverageItemPrice = (agenticContent.Fields["AverageItemPrice"] as ContentNumberField)?.Value;

                Console.WriteLine($"Default workflow: InvoiceId={defaultInvoiceId}, AverageItemPrice={defaultAverageItemPrice}");
                Console.WriteLine($"Agentic workflow: InvoiceId={agenticInvoiceId}, AverageItemPrice={agenticAverageItemPrice}");
                #endregion

                #region Assertion:ContentUnderstandingCreateAnalyzerWorkflow
                Assert.IsTrue(defaultCreateOperation.HasCompleted, "Default workflow create operation should complete");
                Assert.IsTrue(agenticCreateOperation.HasCompleted, "Agentic workflow create operation should complete");

                Assert.IsNotNull(defaultAnalyzerResponse.Value.Config, "Default analyzer config should not be null");
                Assert.IsNotNull(agenticAnalyzerResponse.Value.Config, "Agentic analyzer config should not be null");

                string? defaultWorkflow = defaultAnalyzerResponse.Value.Config!.Workflow?.ToString();
                string? agenticWorkflow = agenticAnalyzerResponse.Value.Config!.Workflow?.ToString();
                Assert.That(defaultWorkflow, Is.Not.Null.And.Not.Empty,
                    "Default analyzer should have a resolved workflow");
                Assert.That(defaultWorkflow!, Does.Not.StartWith("agentic").IgnoreCase,
                    $"Omitting Workflow should resolve to a non-agentic workflow (got '{defaultWorkflow}')");
                Assert.That(agenticWorkflow, Does.StartWith("agentic").IgnoreCase,
                    $"Agentic analyzer should resolve to an agentic workflow (got '{agenticWorkflow}')");

                const double expectedAverageItemPrice = 20.5;
                double defaultAverageError = defaultAverageItemPrice.HasValue
                    ? Math.Abs(defaultAverageItemPrice.Value - expectedAverageItemPrice)
                    : double.PositiveInfinity;

                Assert.AreEqual("INV-2048", defaultInvoiceId, "Default workflow should extract the invoice ID");
                Assert.AreEqual("INV-2048", agenticInvoiceId, "Agentic workflow should extract the invoice ID");
                Assert.IsNotNull(agenticAverageItemPrice, "Agentic workflow should return the average item price");
                double agenticAverageError = Math.Abs(agenticAverageItemPrice!.Value - expectedAverageItemPrice);
                Assert.That(agenticAverageItemPrice.Value, Is.EqualTo(expectedAverageItemPrice).Within(0.01),
                    "Agentic workflow should calculate the average item price correctly");

                Console.WriteLine($"Default average: {defaultAverageItemPrice} (abs error {defaultAverageError})");
                Console.WriteLine($"Agentic average: {agenticAverageItemPrice} (abs error {agenticAverageError})");
                #endregion
            }
            finally
            {
                try
                {
                    await client.DeleteAnalyzerAsync(defaultAnalyzerId);
                }
                catch
                {
                    // Ignore cleanup errors in tests.
                }

                try
                {
                    await client.DeleteAnalyzerAsync(agenticAnalyzerId);
                }
                catch
                {
                    // Ignore cleanup errors in tests.
                }
            }
        }
    }
}
