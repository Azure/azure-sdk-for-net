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

public class Sample_EvaluationsBuiltinInlineData : EvaluationSampleBase
{
    #region Snippet:Sample_CreateData_EvaluationsBuiltinInlineData
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
                    query = new { type = "string" },
                    response = new { type = "string" },
                    context = new { type = "string" },
                    ground_truth = new { type = "string" }
                },
                required = Array.Empty<string>()
            },
            include_sample_schema = true
        };

        object[] testingCriteria = [
            new {
                type = "azure_ai_evaluator",
                name = "violence",
                evaluator_name = "builtin.violence",
                data_mapping = new { query = "{{item.query}}", response = "{{item.response}}" },
                initialization_parameters = new { deployment_name = modelDeploymentName }
            },
            new {
                type = "azure_ai_evaluator",
                name = "f1",
                evaluator_name = "builtin.f1_score",
            },
            new {
                type = "azure_ai_evaluator",
                name = "coherence",
                evaluator_name = "builtin.coherence",
                initialization_parameters = new { deployment_name = modelDeploymentName }
            },
        ];

        return BinaryData.FromObjectAsJson(
            new
            {
                name = "label model test with inline data",
                data_source_config = dataSourceConfig,
                testing_criteria = testingCriteria
            }
        );
    }
    #endregion
    #region Snippet:Sample_CreateDataSource_EvaluationsBuiltinInlineData
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
                            query = "What are some tips for staying healthy?",
                            context = "Health and wellness advice",
                            ground_truth = "Exercise regularly, eat balanced meals, and get enough sleep",
                            response = "To stay healthy, focus on regular exercise, a balanced diet, adequate sleep, and stress management."
                        }
                    },
                    new {
                        item = new {
                            query = "How do I improve my writing skills?",
                            context = "Writing improvement techniques",
                            ground_truth = "Practice regularly and read widely",
                            response = "Read extensively, write daily, seek feedback, and study grammar fundamentals."
                        }
                    },
                    new {
                        item = new {
                            query = "What is the capital of France?",
                            context = "Geography question about European capitals",
                            ground_truth = "Paris",
                            response = "The capital of France is Paris."
                        }
                    },
                    new {
                        item = new {
                            query = "Explain quantum computing",
                            context = "Complex scientific concept explanation",
                            ground_truth = "Quantum computing uses quantum mechanics principles",
                            response = "Quantum computing leverages quantum mechanical phenomena like superposition and entanglement to process information."
                        }
                    },
                }
            }
        };

        return BinaryData.FromObjectAsJson(
            new
            {
                name = "inline_data_run",
                metadata = new { team = "eval-exp", scenario = "inline-data-v1" },
                data_source = dataSource
            }
        );
    }
    #endregion

    [Test]
    [AsyncOnly]
    public async Task EvaluationsBuiltinInlineDataExampleAsync()
    {
        #region Snippet:Sample_CreateClients_EvaluationsBuiltinInlineData
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
        #region Snippet:Sample_CreateEvaluation_EvaluationsBuiltinInlineData_Async
        Console.WriteLine("Creating Evaluation");
        using BinaryContent evaluationDataContent = BinaryContent.Create(GetDataConfig(modelDeploymentName));
        ClientResult evaluation = await evaluationClient.CreateEvaluationAsync(evaluationDataContent);
        Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
        string evaluationName = fields["name"];
        string evaluationId = fields["id"];
        Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
        #endregion
        #region Snippet:Sample_GetEvaluation_EvaluationsBuiltinInlineData_Async
        Console.WriteLine("Get Evaluation by Id");
        ClientResult evaluationResponse = await evaluationClient.GetEvaluationAsync(evaluationId, new());
        Console.WriteLine($"Retrieved evaluation: {evaluationResponse.GetRawResponse().Content}");
        #endregion
        #region Snippet:Sample_CreateRun_EvaluationsBuiltinInlineData_Async
        Console.WriteLine("Creating Eval Run with Inline Data");
        using BinaryContent runDataContent = BinaryContent.Create(GetData());
        ClientResult run = await evaluationClient.CreateEvaluationRunAsync(evaluationId: evaluationId, content: runDataContent);
        fields = ParseClientResult(run, ["id", "status"]);
        string runId = fields["id"];
        string runStatus = fields["status"];
        Console.WriteLine($"Evaluation run created (id: {runId})");
        #endregion
        #region Snippet:Sample_GetRun_EvaluationsBuiltinInlineData_Async
        Console.WriteLine("Get Eval Run by Id");
        ClientResult evalRunResponse = await evaluationClient.GetEvaluationRunAsync(evaluationId: evaluationId, evaluationRunId: runId, options: new());
        Console.WriteLine($"Eval Run Response: {evalRunResponse.GetRawResponse().Content}");
        #endregion
        #region Snippet:Sample_WaitForRun_EvaluationsBuiltinInlineData_Async
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
        #region Snippet:Sample_ParseResults_EvaluationsBuiltinInlineData_Async
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
        #region Snippet:Sample_Cleanup_EvaluationsBuiltinInlineData_Async
        await evaluationClient.DeleteEvaluationAsync(evaluationId, new System.ClientModel.Primitives.RequestOptions());
        Console.WriteLine("Evaluation deleted");
        #endregion
    }

    [Test]
    [SyncOnly]
    public void EvaluationsBuiltinInlineDataExample()
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
        #region Snippet:Sample_CreateEvaluation_EvaluationsBuiltinInlineData_Sync
        Console.WriteLine("Creating Evaluation");
        using BinaryContent evaluationDataContent = BinaryContent.Create(GetDataConfig(modelDeploymentName));
        ClientResult evaluation = evaluationClient.CreateEvaluation(evaluationDataContent);
        Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
        string evaluationName = fields["name"];
        string evaluationId = fields["id"];
        Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
        #endregion
        #region Snippet:Sample_GetEvaluation_EvaluationsBuiltinInlineData_Sync
        Console.WriteLine("Get Evaluation by Id");
        ClientResult evaluationResponse = evaluationClient.GetEvaluation(evaluationId, new());
        Console.WriteLine($"Retrieved evaluation: {evaluationResponse.GetRawResponse().Content}");
        #endregion
        #region Snippet:Sample_CreateRun_EvaluationsBuiltinInlineData_Sync
        Console.WriteLine("Creating Eval Run with Inline Data");
        using BinaryContent runDataContent = BinaryContent.Create(GetData());
        ClientResult run = evaluationClient.CreateEvaluationRun(evaluationId: evaluationId, content: runDataContent);
        fields = ParseClientResult(run, ["id", "status"]);
        string runId = fields["id"];
        string runStatus = fields["status"];
        Console.WriteLine($"Evaluation run created (id: {runId})");
        #endregion
        #region Snippet:Sample_GetRun_EvaluationsBuiltinInlineData_Sync
        Console.WriteLine("Get Eval Run by Id");
        ClientResult evalRunResponse = evaluationClient.GetEvaluationRun(evaluationId: evaluationId, evaluationRunId: runId, options: new());
        Console.WriteLine($"Eval Run Response: {evalRunResponse.GetRawResponse().Content}");
        #endregion
        #region Snippet:Sample_WaitForRun_EvaluationsBuiltinInlineData_Sync
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
        #region Snippet:Sample_ParseResults_EvaluationsBuiltinInlineData_Sync
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
        #region Snippet:Sample_Cleanup_EvaluationsBuiltinInlineData_Sync
        evaluationClient.DeleteEvaluation(evaluationId, new System.ClientModel.Primitives.RequestOptions());
        Console.WriteLine("Evaluation deleted");
        #endregion
    }

    public Sample_EvaluationsBuiltinInlineData(bool isAsync) : base(isAsync)
    {
    }
}
