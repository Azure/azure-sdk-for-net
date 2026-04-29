// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Evaluation;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Evals;

namespace Azure.AI.Projects.Tests.Samples.Evaluation;

public class Sample_EvaluationClusterInsight : SamplesBase
{
    #region Snippet:Sample_GetError_EvaluationClusterInsight
    private static string GetErrorMessageOrEmpty(ClientResult result)
    {
        string error = "";
        Utf8JsonReader reader = new(result.GetRawResponse().Content.ToMemory().ToArray());
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        string code = default;
        string message = default;
        foreach (JsonProperty prop in document.RootElement.EnumerateObject())
        {
            if (prop.NameEquals("error"u8) && prop.Value.ValueKind != JsonValueKind.Null && prop.Value is JsonElement countsElement)
            {
                foreach (JsonProperty errorNode in countsElement.EnumerateObject())
                {
                    if (errorNode.Value.ValueKind == JsonValueKind.String)
                    {
                        if (errorNode.NameEquals("code"u8))
                        {
                            code = errorNode.Value.GetString();
                        }
                        else if (errorNode.NameEquals("message"u8))
                        {
                            message = errorNode.Value.GetString();
                        }
                    }
                }
            }
        }
        if (!string.IsNullOrEmpty(message))
        {
            error = $"Message: {message}, Code: {code ?? "<None>"}";
        }
        return error;
    }
    #endregion
    #region Snippet:Sample_GetStringValues_EvaluationClusterInsight
    private static Dictionary<string, string> ParseClientResult(ClientResult result, string[] expectedProperties)
    {
        Dictionary<string, string> results = [];
        Utf8JsonReader reader = new(result.GetRawResponse().Content.ToMemory().ToArray());
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        foreach (JsonProperty prop in document.RootElement.EnumerateObject())
        {
            foreach (string key in expectedProperties)
            {
                if (prop.NameEquals(Encoding.UTF8.GetBytes(key)) && prop.Value.ValueKind == JsonValueKind.String)
                {
                    results[key] = prop.Value.GetString();
                }
            }
        }
        List<string> notFoundItems = [..expectedProperties.Where((key) => !results.ContainsKey(key))];
        if (notFoundItems.Count > 0)
        {
            StringBuilder sbNotFound = new();
            foreach (string value in notFoundItems)
            {
                sbNotFound.Append($"{value}, ");
            }
            if (sbNotFound.Length > 2)
            {
                sbNotFound.Remove(sbNotFound.Length - 2, 2);
            }
            throw new InvalidOperationException($"The next keys were not found in returned result: {sbNotFound}.");
        }
        return results;
    }
    #endregion
    #region Snippet:Sample_GetResultCounts_EvaluationClusterInsight
    private static string GetResultsCounts(ClientResult result)
    {
        Utf8JsonReader reader = new(result.GetRawResponse().Content.ToMemory().ToArray());
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        StringBuilder sbFormattedCounts = new("{\n");
        foreach (JsonProperty prop in document.RootElement.EnumerateObject())
        {
            if (prop.NameEquals("result_counts"u8) && prop.Value is JsonElement countsElement)
            {
                foreach (JsonProperty count in countsElement.EnumerateObject())
                {
                    if (count.Value.ValueKind == JsonValueKind.Number)
                    {
                        sbFormattedCounts.Append($"    {count.Name}: {count.Value.GetInt32()}\n");
                    }
                }
            }
        }
        sbFormattedCounts.Append('}');
        if (sbFormattedCounts.Length == 3)
        {
            throw new InvalidOperationException("The result does not contain the \"result_counts\" field.");
        }
        return sbFormattedCounts.ToString();
    }
    #endregion

    #region Snippet:Sample_ParseClusterResults_EvaluationClusterInsight
    private static void ParseClusterResults(ProjectsInsight clusterInsight)
    {
        if (clusterInsight.State == OperationStatus.Succeeded)
        {
            Console.WriteLine("Cluster insights generated successfully!");
            Console.WriteLine($"Insight ID: {clusterInsight.Id}");
            Console.WriteLine($"Display Name: {clusterInsight.DisplayName}");
            if (clusterInsight.Result is EvaluationRunClusterInsightResult runResult)
            {
                Console.WriteLine($"The results were clustered using {runResult.ClusterInsight.Summary.MethodName} method.");
                Console.WriteLine($"The number of clusters is {runResult.ClusterInsight.Summary.UniqueClusterCount}.");
            }
            else
            {
                throw new InvalidOperationException($"The cluster insights generation has succeeded, but the result of type {clusterInsight.Result.GetType()} is unexpected.");
            }
        }
        else
        {
            throw new InvalidOperationException("Cluster insight generation failed.");
        }
    }
    #endregion

    [Test]
    [AsyncOnly]
    public async Task EvaluationClusterInsightExampleAsync()
    {
        #region Snippet:Sample_CreateClients_EvaluationClusterInsight
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

        #region Snippet:Sample_CreateEvalData_EvaluationClusterInsight
        object dataSourceConfig = new
        {
            type = "custom",
            item_schema = new
            {
                type = "object",
                properties = new
                {
                    query = new
                    {
                        type = "string"
                    }
                },
                required = new[] { "query" }
            },
        };
        object[] testingCriteria = [
            new {
                type = "label_model",
                name = "sentiment_analysis",
                model = modelDeploymentName,
                input = new object[]
                {
                    new {
                        role = "developer",
                        content = "Classify the sentiment of the following statement as one of 'positive', 'neutral', or 'negative'"
                    },
                    new {
                        role = "user",
                        content = "Statement: {{item.query}}"
                    }
                },
                passing_labels = new[] { "positive", "neutral" },
                labels = new[] { "positive", "neutral", "negative" }
            }
        ];
        BinaryData evaluationData = BinaryData.FromObjectAsJson(
            new
            {
                name = "Sentiment Evaluation",
                data_source_config = dataSourceConfig,
                testing_criteria = testingCriteria
            }
        );
        #endregion

        #region Snippet:Sample_CreateEvaluation_EvaluationClusterInsight_Async
        using BinaryContent evaluationDataContent = BinaryContent.Create(evaluationData);
        ClientResult evaluation = await evaluationClient.CreateEvaluationAsync(evaluationDataContent);
        Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
        string evaluationName = fields["name"];
        string evaluationId = fields["id"];
        Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
        #endregion

        #region Snippet:Sample_CreateEvalRun_EvaluationClusterInsight
        object dataSource = new
        {
            type = "jsonl",
            source = new
            {
                type = "file_content",
                content = new[]
                {
                    new { item = new { query = "I love programming!" } },
                    new { item = new { query = "I hate bugs." } },
                    new { item = new { query = "The weather is nice today." } },
                    new { item = new { query = "This is the worst movie ever." } },
                    new { item = new { query = "Python is an amazing language." } },
                    new { item = new { query = "I love programming!" } },
                    new { item = new { query = "I hate bugs." } },
                    new { item = new { query = "The weather is nice today." } },
                    new { item = new { query = "This is the worst movie ever." } },
                    new { item = new { query = "Python is an amazing language." } },
                }
            }
        };
        BinaryData runData = BinaryData.FromObjectAsJson(
            new
            {
                name = "Eval Run with Inline Data",
                data_source = dataSource
            }
        );
        using BinaryContent runDataContent = BinaryContent.Create(runData);
        #endregion

        #region Snippet:Sample_CreateAndWaitRun_EvaluationClusterInsight_Async
        ClientResult run = await evaluationClient.CreateEvaluationRunAsync(evaluationId: evaluationId, content: runDataContent);
        fields = ParseClientResult(run, ["id", "status"]);
        string runId = fields["id"];
        string runStatus = fields["status"];
        Console.WriteLine($"Evaluation run created (id: {runId})");

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
        Console.WriteLine("Evaluation run completed successfully!");
        Console.WriteLine($"Result Counts: {GetResultsCounts(run)}");
        #endregion

        #region Snippet:Sample_GenerateInsight_EvaluationClusterInsight_Async
        ProjectsInsight clusterInsight = await projectClient.Insights.GenerateAsync(
            insight: new ProjectsInsight(
                displayName: "Cluster analysis",
                request: new EvaluationRunClusterInsightRequest(
                    evalId: evaluationId,
                    runIds: [ runId ])
                {
                    ModelConfiguration = new InsightModelConfiguration(modelDeploymentName)
                }));
        Console.WriteLine($"Started insight generation (id: {clusterInsight.Id})");
        #endregion

        #region Snippet:Sample_WaitForInsight_EvaluationClusterInsight_Async
        Console.WriteLine("Waiting for insight to be generated...");
        while (clusterInsight.State != OperationStatus.Succeeded && clusterInsight.State != OperationStatus.Failed)
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            clusterInsight = await projectClient.Insights.GetAsync(id: clusterInsight.Id);
            Console.WriteLine($"Insight status: {clusterInsight.State}");
        }
        ParseClusterResults(clusterInsight);
        #endregion

        #region Snippet:Sample_Cleanup_EvaluationClusterInsight_Async
        await evaluationClient.DeleteEvaluationAsync(evaluationId, new System.ClientModel.Primitives.RequestOptions());
        Console.WriteLine("Evaluation deleted.");
        #endregion
    }

    [Test]
    [SyncOnly]
    public void EvaluationClusterInsightExampleSync()
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

        object dataSourceConfig = new
        {
            type = "custom",
            item_schema = new
            {
                type = "object",
                properties = new
                {
                    query = new
                    {
                        type = "string"
                    }
                },
                required = new[] { "query" }
            },
        };
        object[] testingCriteria = [
            new {
                type = "label_model",
                name = "sentiment_analysis",
                model = modelDeploymentName,
                input = new object[]
                {
                    new {
                        role = "developer",
                        content = "Classify the sentiment of the following statement as one of 'positive', 'neutral', or 'negative'"
                    },
                    new {
                        role = "user",
                        content = "Statement: {{item.query}}"
                    }
                },
                passing_labels = new[] { "positive", "neutral" },
                labels = new[] { "positive", "neutral", "negative" }
            }
        ];
        BinaryData evaluationData = BinaryData.FromObjectAsJson(
            new
            {
                name = "Sentiment Evaluation",
                data_source_config = dataSourceConfig,
                testing_criteria = testingCriteria
            }
        );

        #region Snippet:Sample_CreateEvaluation_EvaluationClusterInsight_Sync
        using BinaryContent evaluationDataContent = BinaryContent.Create(evaluationData);
        ClientResult evaluation = evaluationClient.CreateEvaluation(evaluationDataContent);
        Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
        string evaluationName = fields["name"];
        string evaluationId = fields["id"];
        Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
        #endregion

        object dataSource = new
        {
            type = "jsonl",
            source = new
            {
                type = "file_content",
                content = new[]
                {
                    new { item = new { query = "I love programming!" } },
                    new { item = new { query = "I hate bugs." } },
                    new { item = new { query = "The weather is nice today." } },
                    new { item = new { query = "This is the worst movie ever." } },
                    new { item = new { query = "Python is an amazing language." } },
                }
            }
        };
        BinaryData runData = BinaryData.FromObjectAsJson(
            new
            {
                name = "Eval Run with Inline Data",
                data_source = dataSource
            }
        );
        using BinaryContent runDataContent = BinaryContent.Create(runData);

        #region Snippet:Sample_CreateAndWaitRun_EvaluationClusterInsight_Sync
        ClientResult run = evaluationClient.CreateEvaluationRun(evaluationId: evaluationId, content: runDataContent);
        fields = ParseClientResult(run, ["id", "status"]);
        string runId = fields["id"];
        string runStatus = fields["status"];
        Console.WriteLine($"Evaluation run created (id: {runId})");

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
        Console.WriteLine("Evaluation run completed successfully!");
        Console.WriteLine($"Result Counts: {GetResultsCounts(run)}");
        #endregion

        #region Snippet:Sample_GenerateInsight_EvaluationClusterInsight_Sync
        ProjectsInsight clusterInsight = projectClient.Insights.Generate(
            insight: new ProjectsInsight(
                displayName: "Cluster analysis",
                request: new EvaluationRunClusterInsightRequest(
                    evalId: evaluationId,
                    runIds: [ runId ])
                {
                    ModelConfiguration = new InsightModelConfiguration(modelDeploymentName)
                }));
        Console.WriteLine($"Started insight generation (id: {clusterInsight.Id})");
        #endregion

        #region Snippet:Sample_WaitForInsight_EvaluationClusterInsight_Sync
        while (clusterInsight.State != OperationStatus.Succeeded && clusterInsight.State != OperationStatus.Failed)
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            clusterInsight = projectClient.Insights.Get(id: clusterInsight.Id);
            Console.WriteLine($"Insight status: {clusterInsight.State}");
        }
        ParseClusterResults(clusterInsight);
        #endregion

        #region Snippet:Sample_Cleanup_EvaluationClusterInsight_Sync
        evaluationClient.DeleteEvaluation(evaluationId, new System.ClientModel.Primitives.RequestOptions());
        Console.WriteLine("Evaluation deleted.");
        #endregion
    }

    public Sample_EvaluationClusterInsight(bool isAsync) : base(isAsync)
    {
    }
}
