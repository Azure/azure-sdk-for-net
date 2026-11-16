// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Evaluation;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Evals;

namespace Azure.AI.Projects.Tests.Samples.Evaluation;
#pragma warning disable AAIP001

// Needs a customer-hosted scoring endpoint behind an existing project connection, so it is never recorded.
[LiveOnly]
public class Sample_EndpointEvaluator : EvaluationSampleBase
{
    #region Snippet:Sample_EvaluatorVersion_EndpointEvaluator
    private static EvaluatorVersion GetEndpointEvaluatorVersion(string connectionName)
    {
        EndpointBasedEvaluatorDefinition definition = new(connectionName)
        {
            SchemaVersion = EndpointEvaluatorSchemaVersion.V002,
            Metrics =
            {
                // Schema 0.0.2 requires exactly one ordinal or continuous metric.
                ["score"] = new EvaluatorMetric
                {
                    Type = EvaluatorMetricType.Ordinal,
                    MinValue = 1,
                    MaxValue = 5,
                },
            },
        };
        return new EvaluatorVersion(
            evaluatorType: EvaluatorType.Custom,
            categories: [EvaluatorCategory.Quality],
            definition: definition)
        {
            DisplayName = "Endpoint Evaluator",
            Description = "Custom scoring endpoint",
        };
    }
    #endregion

    #region Snippet:Sample_CreateEvaluationData_EndpointEvaluator
    private static BinaryData GetEvaluationData(string evaluatorName)
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
                },
                required = new[] { "query", "response" }
            },
            include_sample_schema = true
        };
        object[] testingCriteria = [
            new {
                type = "azure_ai_evaluator",
                name = "endpoint_eval",
                evaluator_name = evaluatorName,
                data_mapping = new {
                    query = "{{item.query}}",
                    response = "{{item.response}}",
                    context = "{{item.context}}",
                },
            },
        ];
        return BinaryData.FromObjectAsJson(
            new
            {
                name = "endpoint-evaluator-test",
                data_source_config = dataSourceConfig,
                testing_criteria = testingCriteria
            }
        );
    }
    #endregion

    #region Snippet:Sample_CreateRunData_EndpointEvaluator
    private static BinaryData GetRunData()
    {
        object dataSource = new
        {
            type = "jsonl",
            source = new
            {
                type = "file_content",
                content = new[] {
                    new {
                        item = new {
                            query = "What is machine learning?",
                            response = "Machine learning is a subset of AI that enables systems to learn from data.",
                            context = "AI and ML overview",
                        }
                    },
                    new {
                        item = new {
                            query = "What is the capital of France?",
                            response = "The capital of France is Paris.",
                            context = "Geography question about European capitals",
                        }
                    },
                    new {
                        item = new {
                            query = "Explain quantum computing",
                            response = "Quantum computing leverages quantum mechanical phenomena like superposition and entanglement to process information.",
                            context = "Complex scientific concept explanation",
                        }
                    },
                    new {
                        item = new {
                            query = "What are some tips for staying healthy?",
                            response = "To stay healthy, focus on regular exercise, a balanced diet, adequate sleep, and stress management.",
                            context = "Health and wellness advice",
                        }
                    },
                }
            },
        };
        return BinaryData.FromObjectAsJson(
            new
            {
                name = "endpoint-evaluator-run",
                data_source = dataSource,
            }
        );
    }
    #endregion

    [Test]
    [AsyncOnly]
    public async Task EndpointEvaluatorExampleAsync()
    {
        #region Snippet:Sample_CreateClients_EndpointEvaluator
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var connectionName = System.Environment.GetEnvironmentVariable("ENDPOINT_CONNECTION_NAME");
#else
        var endpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var connectionName = TestEnvironment.ENDPOINT_CONNECTION_NAME;
        if (string.IsNullOrEmpty(connectionName))
        {
            Assert.Ignore("ENDPOINT_CONNECTION_NAME is not set.");
        }
#endif
        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
        EvaluationClient evaluationClient = projectClient.ProjectOpenAIClient.GetEvaluationClient();
        #endregion
        #region Snippet:Sample_CreateEvaluator_EndpointEvaluator_Async
        EvaluatorVersion evaluator = await projectClient.Evaluators.CreateVersionAsync(
            name: "myEndpointEvaluator",
            evaluatorVersion: GetEndpointEvaluatorVersion(connectionName)
        );
        Console.WriteLine($"Created evaluator: name={evaluator.Name}, version={evaluator.Version}");
        #endregion
        #region Snippet:Sample_CreateEvaluationObject_EndpointEvaluator_Async
        using BinaryContent evaluationDataContent = BinaryContent.Create(GetEvaluationData(evaluator.Name));
        ClientResult evaluation = await evaluationClient.CreateEvaluationAsync(evaluationDataContent);
        Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
        string evaluationId = fields["id"];
        Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {fields["name"]})");
        #endregion
        #region Snippet:Sample_CreateRun_EndpointEvaluator_Async
        using BinaryContent runDataContent = BinaryContent.Create(GetRunData());
        ClientResult run = await evaluationClient.CreateEvaluationRunAsync(evaluationId: evaluationId, content: runDataContent);
        fields = ParseClientResult(run, ["id", "status"]);
        string runId = fields["id"];
        string runStatus = fields["status"];
        Console.WriteLine($"Evaluation run created (id: {runId})");
        #endregion
        #region Snippet:Sample_WaitForRun_EndpointEvaluator_Async
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
        #region Snippet:Sample_ParseResults_EndpointEvaluator_Async
        Console.WriteLine($"Result Counts: {GetResultsCounts(run)}");
        List<string> evaluationResults = await GetResultsListAsync(client: evaluationClient, evaluationId: evaluationId, evaluationRunId: runId);
        Console.WriteLine($"OUTPUT ITEMS (Total: {evaluationResults.Count})");
        foreach (string result in evaluationResults)
        {
            Console.WriteLine(result);
        }
        #endregion
        #region Snippet:Sample_Cleanup_EndpointEvaluator_Async
        try
        {
            await evaluationClient.DeleteEvaluationAsync(evaluationId, new System.ClientModel.Primitives.RequestOptions());
        }
        finally
        {
            await projectClient.Evaluators.DeleteVersionAsync(name: evaluator.Name, version: evaluator.Version);
        }
        #endregion
    }

    [Test]
    [SyncOnly]
    public void EndpointEvaluatorExample()
    {
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var connectionName = System.Environment.GetEnvironmentVariable("ENDPOINT_CONNECTION_NAME");
#else
        var endpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var connectionName = TestEnvironment.ENDPOINT_CONNECTION_NAME;
        if (string.IsNullOrEmpty(connectionName))
        {
            Assert.Ignore("ENDPOINT_CONNECTION_NAME is not set.");
        }
#endif
        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
        EvaluationClient evaluationClient = projectClient.ProjectOpenAIClient.GetEvaluationClient();
        #region Snippet:Sample_CreateEvaluator_EndpointEvaluator_Sync
        EvaluatorVersion evaluator = projectClient.Evaluators.CreateVersion(
            name: "myEndpointEvaluator",
            evaluatorVersion: GetEndpointEvaluatorVersion(connectionName)
        );
        Console.WriteLine($"Created evaluator: name={evaluator.Name}, version={evaluator.Version}");
        #endregion
        #region Snippet:Sample_CreateEvaluationObject_EndpointEvaluator_Sync
        using BinaryContent evaluationDataContent = BinaryContent.Create(GetEvaluationData(evaluator.Name));
        ClientResult evaluation = evaluationClient.CreateEvaluation(evaluationDataContent);
        Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
        string evaluationId = fields["id"];
        Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {fields["name"]})");
        #endregion
        #region Snippet:Sample_CreateRun_EndpointEvaluator_Sync
        using BinaryContent runDataContent = BinaryContent.Create(GetRunData());
        ClientResult run = evaluationClient.CreateEvaluationRun(evaluationId: evaluationId, content: runDataContent);
        fields = ParseClientResult(run, ["id", "status"]);
        string runId = fields["id"];
        string runStatus = fields["status"];
        Console.WriteLine($"Evaluation run created (id: {runId})");
        #endregion
        #region Snippet:Sample_WaitForRun_EndpointEvaluator_Sync
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
        #region Snippet:Sample_ParseResults_EndpointEvaluator_Sync
        Console.WriteLine($"Result Counts: {GetResultsCounts(run)}");
        List<string> evaluationResults = GetResultsList(client: evaluationClient, evaluationId: evaluationId, evaluationRunId: runId);
        Console.WriteLine($"OUTPUT ITEMS (Total: {evaluationResults.Count})");
        foreach (string result in evaluationResults)
        {
            Console.WriteLine(result);
        }
        #endregion
        #region Snippet:Sample_Cleanup_EndpointEvaluator_Sync
        try
        {
            evaluationClient.DeleteEvaluation(evaluationId, new System.ClientModel.Primitives.RequestOptions());
        }
        finally
        {
            projectClient.Evaluators.DeleteVersion(name: evaluator.Name, version: evaluator.Version);
        }
        #endregion
    }

    public Sample_EndpointEvaluator(bool isAsync) : base(isAsync)
    {
    }
}
