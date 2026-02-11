// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Evals;

namespace Azure.AI.Projects.Tests.Samples.Evaluation;

public class Sample_EvaluatorsCatalog : SamplesBase
{
    #region Snippet:Sampple_PromptEvaluator_EvaluatorsCatalog
    private static EvaluatorVersion GetPromptEvaluatorVersion()
    {
        EvaluatorMetric metric = new() {
            Type = EvaluatorMetricType.Ordinal,
            DesirableDirection = EvaluatorMetricDirection.Increase,
            MinValue=1,
            MaxValue=5
        };
        return new(
            categories: [EvaluatorCategory.Quality],
            definition: new PromptBasedEvaluatorDefinition(
                promptText: """
                    You are an evaluator.
                    Rate the GROUNDEDNESS (factual correctness without unsupported claims) of the system response to the customer query.

                    Scoring (1–5):
                    1 = Mostly fabricated/incorrect
                    2 = Many unsupported claims
                    3 = Mixed: some facts but notable errors/guesses
                    4 = Mostly factual; minor issues
                    5 = Fully factual; no unsupported claims

                    Return ONLY a single integer 1–5 as score in valid json response e.g {\"score\": int}.

                    Query:
                    {query}

                    Response:
                    {response}
                    """,
                initParameters: BinaryData.FromObjectAsJson(
                    new
                    {
                        type = "object",
                        properties = new
                        {
                            deployment_name = new { type = "string" },
                            threshold = new { rtpe = "number" },
                        },
                        required = new[] { "deployment_name", "threshold" }
                    }
                ),
                dataSchema: BinaryData.FromObjectAsJson(
                    new
                    {
                        type = "object",
                        properties = new
                        {
                            query = new { type = "string" },
                            response = new { type = "string" }
                        }
                    }
                ),
                metrics: new Dictionary<string, EvaluatorMetric> { { "score", metric } }
            ),
            evaluatorType: EvaluatorType.Custom
        )
        {
            DisplayName = "my_custom_evaluator",
            Description = "Custom evaluator to detect violent content",
        };
    }
    #endregion
    #region Snippet:Sampple_CodeEvaluator_EvaluatorsCatalog
    private static EvaluatorVersion GetCodeEvaluatorVersion()
    {
        EvaluatorMetric resultMetric = new()
        {
            Type = EvaluatorMetricType.Ordinal,
            DesirableDirection = EvaluatorMetricDirection.Increase,
            MinValue = 0,
            MaxValue = 5
        };
        EvaluatorVersion evaluatorVersion = new(
            categories: [EvaluatorCategory.Quality],
            definition: new CodeBasedEvaluatorDefinition(
                codeText: "def grade(sample, item):\n    return 1.0",
                initParameters: BinaryData.FromObjectAsJson(
                    new
                    {
                        type = "object",
                        properties = new
                        {
                            deployment_name = new { type = "string" },
                        },
                        required = new[] { "deployment_name" },
                    }
                ),
                dataSchema: BinaryData.FromObjectAsJson(
                    new
                    {
                        type = "object",
                        properties = new
                        {
                            item = new { type = "string" },
                            response = new { type = "string" }
                        },
                        required = new[] { "query", "response" },
                    }
                ),
                metrics: new Dictionary<string, EvaluatorMetric> {
                    { "result", resultMetric }
                }
            ),
            evaluatorType: EvaluatorType.Custom
        )
        {
            DisplayName = "my_custom_evaluator",
            Description = "Custom evaluator to detect violent content",
        };
        return evaluatorVersion;
    }
    #endregion
    #region Snippet:Sampple_DisplayEvaluator_EvaluatorsCatalog
    private static void DisplayEvaluatorVersion(EvaluatorVersion evaluator)
    {
        Console.WriteLine($"Evaluator ID: {evaluator.Id}");
        Console.WriteLine($"    Name: {evaluator.Name}");
        Console.WriteLine($"    Version: {evaluator.Version}");
        Console.WriteLine("     Categories:");
        foreach (EvaluatorCategory category in evaluator.Categories)
        {
            Console.WriteLine("         - ${category}");
        }
    }
    #endregion
    [Test]
    [AsyncOnly]
    public async Task EvaluatorsCatalogExampleAsync()
    {
        #region Snippet:Sampple_CreateClients_EvaluatorsCatalog
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
#else
        var endpoint = TestEnvironment.PROJECT_ENDPOINT;
#endif
        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
        #endregion
        #region Snippet:Sample_CreatePromptEvaluator_EvaluatorsCatalog_Async
        Console.WriteLine("Creating prompt-based evaluator.");
        EvaluatorVersion promptEvaluator = await projectClient.Evaluators.CreateVersionAsync(
            name: "myCustomEvaluatorPromptBased",
            evaluatorVersion: GetPromptEvaluatorVersion()
        );
        DisplayEvaluatorVersion(promptEvaluator);
        #endregion
        #region Snippet:Sample_CreateCodeEvaluator_EvaluatorsCatalog_Async
        Console.WriteLine("Creating code-based evaluator.");
        EvaluatorVersion codeEvaluator = await projectClient.Evaluators.CreateVersionAsync(
            name: "myCustomEvaluatorCodeBased",
            evaluatorVersion: GetCodeEvaluatorVersion()
        );
        DisplayEvaluatorVersion(codeEvaluator);
        #endregion
        #region Snippet:Sample_GetCodeEvaluator_EvaluatorsCatalog_Async
        Console.WriteLine("Get code-based evaluator.");
        EvaluatorVersion codeEvaluatorLatest = await projectClient.Evaluators.GetVersionAsync(name: codeEvaluator.Name, version: codeEvaluator.Version);
        DisplayEvaluatorVersion(codeEvaluatorLatest);
        #endregion
        Console.WriteLine("Get prompt-based evaluator.");
        #region Snippet:Sample_GetPromptEvaluator_EvaluatorsCatalog_Async
        EvaluatorVersion promptEvaluatorLatest = await projectClient.Evaluators.GetVersionAsync(name: promptEvaluator.Name, version: promptEvaluator.Version);
        DisplayEvaluatorVersion(promptEvaluatorLatest);
        #endregion
        #region Snippet:Sample_UpdateEvaluator_EvaluatorsCatalog_Async
        Console.WriteLine("Updating code-based evaluator.");
        BinaryData evalustorVersionUpdate = BinaryData.FromObjectAsJson(
            new
            {
                categories = new[] { EvaluatorCategory.Quality.ToString() },
                display_name = "my_custom_evaluator_updated",
                description = "Custom evaluator description changed"
            }
        );
        using BinaryContent evalustorVersionUpdateContent = BinaryContent.Create(evalustorVersionUpdate);
        ClientResult response = await projectClient.Evaluators.UpdateVersionAsync(
            name: codeEvaluator.Name,
            version: codeEvaluator.Version,
            content: evalustorVersionUpdateContent
        );
        EvaluatorVersion updatedEvaluator = ClientResult.FromValue((EvaluatorVersion)response, response.GetRawResponse());
        DisplayEvaluatorVersion(updatedEvaluator);
        #endregion
        #region Snippet:Sample_ListBuiltInEvaluators_EvaluatorsCatalog_Async
        Console.WriteLine("Listing built-in evaluators.");
        await foreach (EvaluatorVersion evaluator in projectClient.Evaluators.GetLatestVersionsAsync(type: ListVersionsRequestType.BuiltIn))
        {
            DisplayEvaluatorVersion(evaluator);
        }
        #endregion
        #region Snippet:Sample_ListCustomEvaluators_EvaluatorsCatalog_Async
        Console.WriteLine("Listing custom evaluators.");
        await foreach (EvaluatorVersion evaluator in projectClient.Evaluators.GetLatestVersionsAsync(type: ListVersionsRequestType.Custom))
        {
            DisplayEvaluatorVersion(evaluator);
        }
        #endregion
        #region Snippet:Sample_Cleanup_EvaluatorsCatalog_Async
        await projectClient.Evaluators.DeleteVersionAsync(name: promptEvaluatorLatest.Name, version: promptEvaluatorLatest.Version);
        await projectClient.Evaluators.DeleteVersionAsync(name: codeEvaluatorLatest.Name, version: codeEvaluatorLatest.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void EvaluatorsCatalogExampleSync()
    {
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
#else
        var endpoint = TestEnvironment.PROJECT_ENDPOINT;
#endif
        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
        #region Snippet:Sample_CreatePromptEvaluator_EvaluatorsCatalog_Sync
        Console.WriteLine("Creating prompt-based evaluator.");
        EvaluatorVersion promptEvaluator = projectClient.Evaluators.CreateVersion(
            name: "myCustomEvaluatorPromptBased",
            evaluatorVersion: GetPromptEvaluatorVersion()
        );
        DisplayEvaluatorVersion(promptEvaluator);
        #endregion
        #region Snippet:Sample_CreateCodeEvaluator_EvaluatorsCatalog_Sync
        Console.WriteLine("Creating code-based evaluator.");
        EvaluatorVersion codeEvaluator = projectClient.Evaluators.CreateVersion(
            name: "myCustomEvaluatorCodeBased",
            evaluatorVersion: GetCodeEvaluatorVersion()
        );
        DisplayEvaluatorVersion(codeEvaluator);
        #endregion
        #region Snippet:Sample_GetCodeEvaluator_EvaluatorsCatalog_Sync
        Console.WriteLine("Get code-based evaluator.");
        EvaluatorVersion codeEvaluatorLatest = projectClient.Evaluators.GetVersion(name: codeEvaluator.Name, version: codeEvaluator.Version);
        DisplayEvaluatorVersion(codeEvaluatorLatest);
        #endregion
        Console.WriteLine("Get prompt-based evaluator.");
        #region Snippet:Sample_GetPromptEvaluator_EvaluatorsCatalog_Sync
        EvaluatorVersion promptEvaluatorLatest = projectClient.Evaluators.GetVersion(name: promptEvaluator.Name, version: promptEvaluator.Version);
        DisplayEvaluatorVersion(promptEvaluatorLatest);
        #endregion
        #region Snippet:Sample_UpdateEvaluator_EvaluatorsCatalog_Sync
        Console.WriteLine("Updating code-based evaluator.");
        BinaryData evalustorVersionUpdate = BinaryData.FromObjectAsJson(
            new
            {
                categories = new[] { EvaluatorCategory.Quality.ToString() },
                display_name = "my_custom_evaluator_updated",
                description = "Custom evaluator description changed"
            }
        );
        using BinaryContent evalustorVersionUpdateContent = BinaryContent.Create(evalustorVersionUpdate);
        ClientResult response = projectClient.Evaluators.UpdateVersion(
            name: codeEvaluator.Name,
            version: codeEvaluator.Version,
            content: evalustorVersionUpdateContent
        );
        EvaluatorVersion updatedEvaluator = ClientResult.FromValue((EvaluatorVersion)response, response.GetRawResponse());
        DisplayEvaluatorVersion(updatedEvaluator);
        #endregion
        #region Snippet:Sample_ListBuiltInEvaluators_EvaluatorsCatalog_Sync
        Console.WriteLine("Listing built-in evaluators.");
        foreach (EvaluatorVersion evaluator in projectClient.Evaluators.GetLatestVersions(type: ListVersionsRequestType.BuiltIn))
        {
            DisplayEvaluatorVersion(evaluator);
        }
        #endregion
        #region Snippet:Sample_ListCustomEvaluators_EvaluatorsCatalog_Sync
        Console.WriteLine("Listing custom evaluators.");
        foreach (EvaluatorVersion evaluator in projectClient.Evaluators.GetLatestVersions(type: ListVersionsRequestType.Custom))
        {
            DisplayEvaluatorVersion(evaluator);
        }
        #endregion
        #region Snippet:Sample_Cleanup_EvaluatorsCatalog_Sync
        projectClient.Evaluators.DeleteVersion(name: promptEvaluatorLatest.Name, version: promptEvaluatorLatest.Version);
        projectClient.Evaluators.DeleteVersion(name: codeEvaluatorLatest.Name, version: codeEvaluatorLatest.Version);
        #endregion
    }

    public Sample_EvaluatorsCatalog(bool isAsync) : base(isAsync)
    {
    }
}
