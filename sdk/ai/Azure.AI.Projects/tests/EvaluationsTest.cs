// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.AI.Projects;
using Azure.AI.Projects.OpenAI;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Evals;

namespace Azure.AI.Projects.Tests;

public class EvaluationsTest : ProjectsClientTestBase
{
    public EvaluationsTest(bool isAsync) : base(isAsync)
    {
    }

    [RecordedTest]
    public async Task SearchIndexesTest()
    {
        AIProjectClient projectClient = GetTestProjectClient();
        EvaluationClient evaluationClient = projectClient.OpenAI.GetEvaluationClient();

        PromptAgentDefinition agentDefinition = new(model: TestEnvironment.MODELDEPLOYMENTNAME)
        {
            Instructions = "You are a prompt agent."
        };
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: "evalAgent",
            options: new(agentDefinition));

        object[] testingCriteria = [
            new {
                type = "azure_ai_evaluator",
                name = "violence_detection",
                evaluator_name = "builtin.violence",
                data_mapping = new { query = "{{item.query}}", response = "{{sample.output_text}}"}
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
        using BinaryContent evaluationDataContent = BinaryContent.Create(evaluationData);
        ClientResult evaluation = await evaluationClient.CreateEvaluationAsync(evaluationDataContent);
        string evaluationId = ParseClientResult<string>(evaluation, ["id"])["id"];
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

        ClientResult run = await evaluationClient.CreateEvaluationRunAsync(evaluationId: evaluationId, content: runDataContent);
        Dictionary<string, string> fields = ParseClientResult<string>(run, ["id", "status"]);
        string runId = fields["id"];
        string runStatus = fields["status"];

        while (runStatus != "failed" && runStatus != "completed")
        {
            run = await evaluationClient.GetEvaluationRunAsync(evaluationId: evaluationId, evaluationRunId: runId, options: new());
            runStatus = ParseClientResult<string>(run, ["status"])["status"];
        }
        Assert.That(runStatus, Is.EqualTo("completed"));
        AssertCountsReturnred(run);
        List<string> evaluationResults = await GetResultsListAsync(client: evaluationClient, evaluationId: evaluationId, evaluationRunId: runId);
        Assert.That(evaluationResults.Count, Is.GreaterThan(0));
        ClientResult deletionResult = await evaluationClient.DeleteEvaluationAsync(evaluationId, new System.ClientModel.Primitives.RequestOptions());
        Assert.That(ParseClientResult<bool>(deletionResult, ["deleted"])["deleted"], Is.True);
        await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
    }

    #region Helpers
    private static void AssertCountsReturnred(ClientResult result)
    {
        Utf8JsonReader reader = new(result.GetRawResponse().Content.ToMemory().ToArray());
        JsonDocument document = JsonDocument.ParseValue(ref reader);
        bool wasReturned = false;
        foreach (JsonProperty prop in document.RootElement.EnumerateObject())
        {
            if (prop.NameEquals("result_counts"u8) && prop.Value is JsonElement countsElement)
            {
                foreach (JsonProperty count in countsElement.EnumerateObject())
                {
                    if (count.Value.ValueKind == JsonValueKind.Number)
                    {
                        wasReturned = true;
                        break;
                    }
                }
            }
        }
        Assert.That(wasReturned, $"The JSON {Encoding.UTF8.GetString(result.GetRawResponse().Content.ToMemory().ToArray())} does not contain result_counts.");
    }

    private static Dictionary<string, U> ParseClientResult<U>(ClientResult result, string[] expectedProperties)
    {
        Dictionary<string, U> results = [];
        Utf8JsonReader reader = new(result.GetRawResponse().Content.ToMemory().ToArray());
        JsonDocument document = JsonDocument.ParseValue(ref reader);
        foreach (JsonProperty prop in document.RootElement.EnumerateObject())
        {
            foreach (string key in expectedProperties)
            {
                if (prop.NameEquals(Encoding.UTF8.GetBytes(key)))
                {
                    if (prop.Value.ValueKind == JsonValueKind.String && typeof(U) == typeof(string))
                    {
                        if (prop.Value.GetString() is U val)
                        {
                            results[key] = val;
                        }
                    }
                    else if (typeof(U) == typeof(bool) && prop.Value.ValueKind == JsonValueKind.True || prop.Value.ValueKind == JsonValueKind.False)
                    {
                        if (prop.Value.GetBoolean() is U val)
                        {
                            results[key] = val;
                        }
                    }
                    else if (prop.Value.ValueKind == JsonValueKind.Number && typeof(U) == typeof(int))
                    {
                        if (prop.Value.GetInt32() is U val)
                        {
                            results[key] = val;
                        }
                    }
                }
            }
        }
        List<string> notFoundItems = expectedProperties.Where((key) => !results.ContainsKey(key)).ToList();
        StringBuilder sbNotFound = new();
        foreach (string value in notFoundItems)
        {
            sbNotFound.Append($"{value},");
        }
        if (sbNotFound.Length > 2)
        {
            sbNotFound.Remove(sbNotFound.Length - 2, 2);
        }
        Assert.That(notFoundItems.Count, Is.EqualTo(0), $"The next keys were not found in returned result: {sbNotFound}.");
        return results;
    }

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
}
