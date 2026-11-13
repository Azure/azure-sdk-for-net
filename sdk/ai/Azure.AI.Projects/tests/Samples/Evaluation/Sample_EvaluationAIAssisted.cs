// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Evals;

namespace Azure.AI.Projects.Tests.Samples.Evaluation;

public class Sample_EvaluationsAIAssisted : EvaluationSampleBase
{
    #region Snippet:Sample_CreateData_EvaluationsAIAssisted
    private static BinaryData GetDataConfig(string modelDeploymentName)
    {
        object dataSourceConfig = new
        {
            type = "custom",
            item_schema = new
            {
                type = "object",
                properties = new
                {
                    response = new { type = "string" },
                    ground_truth = new { type = "string" }
                },
                required = Array.Empty<string>()
            },
            include_sample_schema = false
        };

        object[] testingCriteria = [
            new {
                type = "azure_ai_evaluator",
                name = "Similarity",
                evaluator_name = "builtin.similarity",
                data_mapping = new { response = "{{item.response}}", ground_truth = "{{item.ground_truth}}" },
                initialization_parameters = new { deployment_name = modelDeploymentName, threshold = 3 }
            },
            new {
                type = "azure_ai_evaluator",
                name = "ROUGEScore",
                evaluator_name = "builtin.rouge_score",
                data_mapping = new { response = "{{item.response}}", ground_truth = "{{item.ground_truth}}" },
                initialization_parameters = new { rouge_type = "rouge1", f1_score_threshold = 0.5, precision_threshold = 0.5, recall_threshold = 0.5 }
            },
            new {
                type = "azure_ai_evaluator",
                name = "METEORScore",
                evaluator_name = "builtin.meteor_score",
                data_mapping = new { response = "{{item.response}}", ground_truth = "{{item.ground_truth}}" },
                initialization_parameters = new { threshold = 0.5 }
            },
            new {
                type = "azure_ai_evaluator",
                name = "GLEUScore",
                evaluator_name = "builtin.gleu_score",
                data_mapping = new { response = "{{item.response}}", ground_truth = "{{item.ground_truth}}" },
                initialization_parameters = new { threshold = 0.5 }
            },
            new {
                type = "azure_ai_evaluator",
                name = "F1Score",
                evaluator_name = "builtin.f1_score",
                data_mapping = new { response = "{{item.response}}", ground_truth = "{{item.ground_truth}}" },
                initialization_parameters = new { threshold = 0.5 }
            },
            new {
                type = "azure_ai_evaluator",
                name = "BLEUScore",
                evaluator_name = "builtin.bleu_score",
                data_mapping = new { response = "{{item.response}}", ground_truth = "{{item.ground_truth}}" },
                initialization_parameters = new { threshold = 0.5 }
            },
        ];

        return BinaryData.FromObjectAsJson(
            new
            {
                name = "AI assisted evaluators test",
                data_source_config = dataSourceConfig,
                testing_criteria = testingCriteria
            }
        );
    }
    #endregion
    #region Snippet:Sample_CreateDataSource_EvaluationsAIAssisted
    private static BinaryData GetData()
    {
        object dataSource = new
        {
            type = "jsonl",
            source = new
            {
                type = "file_content",
                content = new[]
                {
                    new {
                        item = new {
                            response = "The capital of France is Paris, which is also known as the City of Light.",
                            ground_truth = "Paris is the capital of France."
                        }
                    },
                    new {
                        item = new {
                            response = "Python is a high-level programming language known for its simplicity and readability.",
                            ground_truth = "Python is a popular programming language that is easy to learn."
                        }
                    },
                    new {
                        item = new {
                            response = "Machine learning is a subset of artificial intelligence that enables systems to learn from data.",
                            ground_truth = "Machine learning allows computers to learn from data without being explicitly programmed."
                        }
                    },
                    new {
                        item = new {
                            response = "The sun rises in the east and sets in the west due to Earth's rotation.",
                            ground_truth = "The sun appears to rise in the east and set in the west because of Earth's rotation."
                        }
                    },
                }
            }
        };
        return BinaryData.FromObjectAsJson(
            new
            {
                name = "inline_data_ai_assisted_run",
                metadata = new { team = "eval-exp", scenario = "ai-assisted-inline-v1" },
                data_source = dataSource
            }
        );
    }
    #endregion

    [Test]
    [AsyncOnly]
    public async Task EvaluationsAIAssistedExampleAsync()
    {
        #region Snippet:Sample_CreateClients_EvaluationsAIAssisted
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var endpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
        EvaluationClient evaluationClient = projectClient.ProjectOpenAIClient.GetEvaluationClient();
        #endregion
        #region Snippet:Sample_CreateEvaluation_EvaluationsAIAssisted_Async
        using BinaryContent evaluationDataContent = BinaryContent.Create(GetDataConfig(modelDeploymentName));
        ClientResult evaluation = await evaluationClient.CreateEvaluationAsync(evaluationDataContent);
        Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
        string evaluationName = fields["name"];
        string evaluationId = fields["id"];
        Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
        #endregion
        #region Snippet:Sample_GetEvaluation_EvaluationsAIAssisted_Async
        ClientResult evaluationResponse = await evaluationClient.GetEvaluationAsync(evaluationId, new());
        Console.WriteLine($"Retrieved evaluation: {evaluationResponse.GetRawResponse().Content}");
        #endregion
        #region Snippet:Sample_CreateRun_EvaluationsAIAssisted_Async
        using BinaryContent runDataContent = BinaryContent.Create(GetData());
        ClientResult run = await evaluationClient.CreateEvaluationRunAsync(evaluationId: evaluationId, content: runDataContent);
        fields = ParseClientResult(run, ["id", "status"]);
        string runId = fields["id"];
        string runStatus = fields["status"];
        Console.WriteLine($"Evaluation run created (id: {runId})");
        #endregion
        #region Snippet:Sample_WaitForRun_EvaluationsAIAssisted_Async
        while (runStatus != "failed" && runStatus != "completed")
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            run = await evaluationClient.GetEvaluationRunAsync(evaluationId: evaluationId, evaluationRunId: runId, options: new());
            runStatus = ParseClientResult(run, ["status"])["status"];
            Console.WriteLine($"Waiting for eval run to complete... current status: {runStatus}");
        }
        if (runStatus == "failed")
        {
            throw new InvalidOperationException($"Evaluation run failed with error: {GetErrorMessageOrEmpty(run)}");
        }
        #endregion
        #region Snippet:Sample_ParseResults_EvaluationsAIAssisted_Async
        Console.WriteLine("Evaluation run completed successfully!");
        Console.WriteLine($"Result Counts: {GetResultsCounts(run)}");
        List<string> evaluationResults = await GetResultsListAsync(client: evaluationClient, evaluationId: evaluationId, evaluationRunId: runId);
        Console.WriteLine($"OUTPUT ITEMS (Total: {evaluationResults.Count})");
        Console.WriteLine($"------------------------------------------------------------");
        foreach (string result in evaluationResults)
        {
            Console.WriteLine(result);
        }
        Console.WriteLine($"------------------------------------------------------------");
        #endregion
        #region Snippet:Sample_Cleanup_EvaluationsAIAssisted_Async
        await evaluationClient.DeleteEvaluationAsync(evaluationId, new System.ClientModel.Primitives.RequestOptions());
        Console.WriteLine("Evaluation deleted");
        #endregion
    }

    [Test]
    [SyncOnly]
    public void EvaluationsAIAssistedExample()
    {
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var endpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
        EvaluationClient evaluationClient = projectClient.ProjectOpenAIClient.GetEvaluationClient();
        #region Snippet:Sample_CreateEvaluation_EvaluationsAIAssisted_Sync
        using BinaryContent evaluationDataContent = BinaryContent.Create(GetDataConfig(modelDeploymentName));
        ClientResult evaluation = evaluationClient.CreateEvaluation(evaluationDataContent);
        Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
        string evaluationName = fields["name"];
        string evaluationId = fields["id"];
        Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
        #endregion
        #region Snippet:Sample_GetEvaluation_EvaluationsAIAssisted_Sync
        ClientResult evaluationResponse = evaluationClient.GetEvaluation(evaluationId, new());
        Console.WriteLine($"Retrieved evaluation: {evaluationResponse.GetRawResponse().Content}");
        #endregion
        #region Snippet:Sample_CreateRun_EvaluationsAIAssisted_Sync
        using BinaryContent runDataContent = BinaryContent.Create(GetData());
        ClientResult run = evaluationClient.CreateEvaluationRun(evaluationId: evaluationId, content: runDataContent);
        fields = ParseClientResult(run, ["id", "status"]);
        string runId = fields["id"];
        string runStatus = fields["status"];
        Console.WriteLine($"Evaluation run created (id: {runId})");
        #endregion
        #region Snippet:Sample_WaitForRun_EvaluationsAIAssisted_Sync
        while (runStatus != "failed" && runStatus != "completed")
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            run = evaluationClient.GetEvaluationRun(evaluationId: evaluationId, evaluationRunId: runId, options: new());
            runStatus = ParseClientResult(run, ["status"])["status"];
            Console.WriteLine($"Waiting for eval run to complete... current status: {runStatus}");
        }
        if (runStatus == "failed")
        {
            throw new InvalidOperationException($"Evaluation run failed with error: {GetErrorMessageOrEmpty(run)}");
        }
        #endregion
        #region Snippet:Sample_ParseResults_EvaluationsAIAssisted_Sync
        Console.WriteLine("Evaluation run completed successfully!");
        Console.WriteLine($"Result Counts: {GetResultsCounts(run)}");
        List<string> evaluationResults = GetResultsList(client: evaluationClient, evaluationId: evaluationId, evaluationRunId: runId);
        Console.WriteLine($"OUTPUT ITEMS (Total: {evaluationResults.Count})");
        Console.WriteLine($"------------------------------------------------------------");
        foreach (string result in evaluationResults)
        {
            Console.WriteLine(result);
        }
        Console.WriteLine($"------------------------------------------------------------");
        #endregion
        #region Snippet:Sample_Cleanup_EvaluationsAIAssisted_Sync
        evaluationClient.DeleteEvaluation(evaluationId, new System.ClientModel.Primitives.RequestOptions());
        Console.WriteLine("Evaluation deleted");
        #endregion
    }

    public Sample_EvaluationsAIAssisted(bool isAsync) : base(isAsync)
    {
    }
}
