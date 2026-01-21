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
using Azure.AI.Projects.OpenAI;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Evals;

namespace Azure.AI.Projects.Tests.Samples.Evaluation;

public class Sample_Evaluations : SamplesBase
{
    #region Snippet:Sampple_GetResultCounts_Evaluations
    private static string GetResultsCounts(ClientResult result)
    {
        Utf8JsonReader reader = new(result.GetRawResponse().Content.ToMemory().ToArray());
        JsonDocument document = JsonDocument.ParseValue(ref reader);
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
    #region Snippet:Sampple_GetStringValues_Evaluations
    private static Dictionary<string, string> ParseClientResult(ClientResult result, string[] expectedProperties)
    {
        Dictionary<string, string> results = [];
        Utf8JsonReader reader = new(result.GetRawResponse().Content.ToMemory().ToArray());
        JsonDocument document = JsonDocument.ParseValue(ref reader);
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
        List<string> notFoundItems = expectedProperties.Where((key) => !results.ContainsKey(key)).ToList();
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
    #region Snippet:Sampple_GetResultsList_Evaluations_Async
    private static async Task<List<string>> GetResultsListAsync(EvaluationClient client, string evaluationId, string evaluationRunId)
    {
        List<string> resultJsons = [];
        bool hasMore = false;
        do
        {
            ClientResult resultList = await client.GetEvaluationRunOutputItemsAsync(evaluationId: evaluationId, evaluationRunId: evaluationRunId, limit: null, order: "asc", after: default, outputItemStatus: default, options: new());
            Utf8JsonReader reader = new(resultList.GetRawResponse().Content.ToMemory().ToArray());
            JsonDocument document = JsonDocument.ParseValue(ref reader);

            foreach (JsonProperty topProperty in document.RootElement.EnumerateObject())
            {
                if (topProperty.NameEquals("has_more"u8))
                {
                    hasMore = topProperty.Value.GetBoolean();
                }
                else if (topProperty.NameEquals("data"u8))
                {
                    if (topProperty.Value.ValueKind == JsonValueKind.Array)
                    {
                        foreach (JsonElement dataElement in topProperty.Value.EnumerateArray())
                        {
                            resultJsons.Add(dataElement.ToString());
                        }
                    }
                }
            }
        } while (hasMore);
        return resultJsons;
    }
    #endregion
    #region Snippet:Sampple_GetResultsList_Evaluations_Sync
    private static List<string> GetResultsList(EvaluationClient client, string evaluationId, string evaluationRunId)
    {
        List<string> resultJsons = [];
        bool hasMore = false;
        do
        {
            ClientResult resultList = client.GetEvaluationRunOutputItems(evaluationId: evaluationId, evaluationRunId: evaluationRunId, limit: null, order: "asc", after: default, outputItemStatus: default, options: new());
            Utf8JsonReader reader = new(resultList.GetRawResponse().Content.ToMemory().ToArray());
            JsonDocument document = JsonDocument.ParseValue(ref reader);
            List<string> data = [];

            foreach (JsonProperty topProperty in document.RootElement.EnumerateObject())
            {
                if (topProperty.NameEquals("has_more"u8))
                {
                    hasMore = topProperty.Value.GetBoolean();
                }
                else if (topProperty.NameEquals("data"u8))
                {
                    if (topProperty.Value.ValueKind == JsonValueKind.Array)
                    {
                        foreach (JsonElement dataElement in topProperty.Value.EnumerateArray())
                        {
                            resultJsons.Add(dataElement.ToString());
                        }
                    }
                }
            }
        } while (hasMore);
        return resultJsons;
    }
    #endregion

    [Test]
    [AsyncOnly]
    public async Task EvaluationsExampleAsync()
    {
        #region Snippet:Sampple_CreateClients_Evaluations
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var endpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
        EvaluationClient evaluationClient = projectClient.OpenAI.GetEvaluationClient();
        #endregion
        #region Snippet:Sample_CreateAgent_Evaluations_Async
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: "evalAgent",
            options: new(agentDefinition));
        Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
        #endregion
        #region Snippet:Sample_CreateData_Evaluations
        object[] testingCriteria = [
            new {
                type = "azure_ai_evaluator",
                name = "violence_detection",
                evaluator_name = "builtin.violence",
                data_mapping = new { query = "{{item.query}}", response = "{{sample.output_text}}"}
            },
            new {
                type = "azure_ai_evaluator",
                name = "fluency",
                evaluator_name = "builtin.fluency",
                initialization_parameters = new { deployment_name = modelDeploymentName},
                data_mapping = new { query = "{{item.query}}", response = "{{sample.output_text}}"}
            },
            new {
                type = "azure_ai_evaluator",
                name = "task_adherence",
                evaluator_name = "builtin.task_adherence",
                initialization_parameters = new { deployment_name = modelDeploymentName},
                data_mapping = new { query = "{{item.query}}", response = "{{sample.output_items}}"}
            },
        ];
        object dataSourceConfig = new {
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
            include_sample_schema = true
        };
        BinaryData evaluationData = BinaryData.FromObjectAsJson(
            new
            {
                name = "Agent Evaluation",
                data_source_config = dataSourceConfig,
                testing_criteria = testingCriteria
            }
        );
        #endregion
        #region Snippet:Sample_CreateEvaluationObject_Evaluations_Async
        using BinaryContent evaluationDataContent = BinaryContent.Create(evaluationData);
        ClientResult evaluation = await evaluationClient.CreateEvaluationAsync(evaluationDataContent);
        Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
        string evaluationName = fields["name"];
        string evaluationId = fields["id"];
        Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
        #endregion
        #region Snippet:Sample_CreateDataSource_Evaluations
        object dataSource = new
        {
            type = "azure_ai_target_completions",
            source = new
            {
                type = "file_content",
                content = new[] {
                    new { item = new { query = "What is the capital of France?" } },
                    new { item = new { query = "How do I reverse a string in Python? "} },
                }
            },
            input_messages = new
            {
                type = "template",
                template = new[] {
                    new {
                        type = "message",
                        role = "user",
                        content = new { type = "input_text", text = "{{item.query}}" }
                    }
                }
            },
            target = new
            {
                type = "azure_ai_agent",
                name = agentVersion.Name,
                // Version is optional. Defaults to latest version if not specified.
                version = agentVersion.Version,
            }
        };
        BinaryData runData = BinaryData.FromObjectAsJson(
            new
            {
                eval_id = evaluationId,
                name = $"Evaluation Run for Agent {agentVersion.Name}",
                data_source = dataSource
            }
        );
        using BinaryContent runDataContent = BinaryContent.Create(runData);
        #endregion
        #region Snippet:Sample_CreateRun_Evaluations_Async
        ClientResult run = await evaluationClient.CreateEvaluationRunAsync(evaluationId: evaluationId, content: runDataContent);
        fields = ParseClientResult(run, ["id", "status"]);
        string runId = fields["id"];
        string runStatus = fields["status"];
        Console.WriteLine($"Evaluation run created (id: {runId})");
        #endregion
        #region Snippet:Sample_WaitForRun_Evaluations_Async
        while (runStatus != "failed" && runStatus != "completed")
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            run = await evaluationClient.GetEvaluationRunAsync(evaluationId: evaluationId, evaluationRunId: runId, options: new());
            runStatus = ParseClientResult(run, ["status"])["status"];
            Console.WriteLine($"Waiting for eval run to complete... current status: {runStatus}");
        }
        if (runStatus == "failed")
        {
            throw new InvalidOperationException("Evaluation run failed.");
        }
        #endregion
        #region Snippet:Sample_ParseEvaluations_Evaluations_Async
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
        #region Snippet:Sample_Cleanup_Evaluations_Async
        await evaluationClient.DeleteEvaluationAsync(evaluationId, new System.ClientModel.Primitives.RequestOptions());
        await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void EvaluationsExample()
    {
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var endpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
        EvaluationClient evaluationClient = projectClient.OpenAI.GetEvaluationClient();
        #region Snippet:Sample_CreateAgent_Evaluations_Sync
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };
        AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
            agentName: "evalAgent",
            options: new(agentDefinition));
        Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
        #endregion

        object[] testingCriteria = [
            new {
                type = "azure_ai_evaluator",
                name = "violence_detection",
                evaluator_name = "builtin.violence",
                data_mapping = new { query = "{{item.query}}", response = "{{sample.output_text}}"}
            },
            new {
                type = "azure_ai_evaluator",
                name = "fluency",
                evaluator_name = "builtin.fluency",
                initialization_parameters = new { deployment_name = modelDeploymentName},
                data_mapping = new { query = "{{item.query}}", response = "{{sample.output_text}}"}
            },
            new {
                type = "azure_ai_evaluator",
                name = "task_adherence",
                evaluator_name = "builtin.task_adherence",
                initialization_parameters = new { deployment_name = modelDeploymentName},
                data_mapping = new { query = "{{item.query}}", response = "{{sample.output_items}}"}
            },
        ];
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
            include_sample_schema = true
        };
        BinaryData evaluationData = BinaryData.FromObjectAsJson(
            new
            {
                name = "Agent Evaluation",
                data_source_config = dataSourceConfig,
                testing_criteria = testingCriteria
            }
        );

        #region Snippet:Sample_CreateEvaluationObject_Evaluations_Sync
        using BinaryContent evaluationDataContent = BinaryContent.Create(evaluationData);
        ClientResult evaluation = evaluationClient.CreateEvaluation(evaluationDataContent);
        Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
        string evaluationName = fields["name"];
        string evaluationId = fields["id"];
        Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
        #endregion
        object dataSource = new
        {
            type = "azure_ai_target_completions",
            source = new
            {
                type = "file_content",
                content = new[] {
                    new { item = new { query = "What is the capital of France?" } },
                    new { item = new { query = "How do I reverse a string in Python? "} },
                }
            },
            input_messages = new
            {
                type = "template",
                template = new[] {
                    new {
                        type = "message",
                        role = "user",
                        content = new { type = "input_text", text = "{{item.query}}" }
                    }
                }
            },
            target = new
            {
                type = "azure_ai_agent",
                name = agentVersion.Name,
                // Version is optional. Defaults to latest version if not specified.
                version = agentVersion.Version,
            }
        };
        BinaryData runData = BinaryData.FromObjectAsJson(
            new
            {
                eval_id = evaluationId,
                name = $"Evaluation Run for Agent {agentVersion.Name}",
                data_source = dataSource
            }
        );
        using BinaryContent runDataContent = BinaryContent.Create(runData);
        #region Snippet:Sample_CreateRun_Evaluations_Sync
        ClientResult run = evaluationClient.CreateEvaluationRun(evaluationId: evaluationId, content: runDataContent);
        fields = ParseClientResult(run, ["id", "status"]);
        string runId = fields["id"];
        string runStatus = fields["status"];
        Console.WriteLine($"Evaluation run created (id: {runId})");
        #endregion
        #region Snippet:Sample_WaitForRun_Evaluations_Sync
        while (runStatus != "failed" && runStatus != "completed")
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            run = evaluationClient.GetEvaluationRun(evaluationId: evaluationId, evaluationRunId: runId, options: new());
            runStatus = ParseClientResult(run, ["status"])["status"];
            Console.WriteLine($"Waiting for eval run to complete... current status: {runStatus}");
        }
        if (runStatus == "failed")
        {
            throw new InvalidOperationException("Evaluation run failed.");
        }
        #endregion
        #region Snippet:Sample_ParseEvaluations_Evaluations_Sync
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
        #region Snippet:Sample_Cleanup_Evaluations_Sync
        evaluationClient.DeleteEvaluation(evaluationId, new System.ClientModel.Primitives.RequestOptions());
        projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    public Sample_Evaluations(bool isAsync) : base(isAsync)
    {
    }
}
