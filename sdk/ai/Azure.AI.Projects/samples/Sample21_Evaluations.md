# Sample of using Agent evaluation in Azure.AI.Projects.

In this example we will demonstrate how to evaluate the Agent based on several testing criteria.

1. First, we need to create project client and read the environment variables which will be used in the next steps. We will also create an `EvaluationClient` for creating and running evaluations.

```C# Snippet:Sampple_CreateClients_Evaluations
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
EvaluationClient evaluationClient = projectClient.OpenAI.GetEvaluationClient();
```

2. Create a target Agent for evaluation.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_Evaluations_Sync
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent."
};
AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
    agentName: "evalAgent",
    options: new(agentDefinition));
Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_Evaluations_Async
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent."
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "evalAgent",
    options: new(agentDefinition));
Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
```

3. Define the evaluation criteria and the data source config. Testing criteria lists all the evaluators and data mappings for them. In this example we will use three built in evaluators: "violence", "fluency" and "task_adherence". We will use Agent's string and structured JSON outputs, named `sample.output_text` and `sample.output_items` respectively as response parameter for the evaluation and take query property from the data set, using `item.query` placeholder.

```C# Snippet:Sample_CreateData_Evaluations
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
```

4. The `EvaluationClient` uses protocol methods i.e. they take in JSON in the form of `BinaryData` and return `ClientResult`, containing binary encoded JSON response, which can be retrieved using `GetRawResponse()` method. To simplify parsing JSON we will create helper methods. One of the methods is named `ParseClientResult`. It gets string values of the top-level JSON properties. In the next section we will use this method to get evaluation name and ID.

```C# Snippet:Sampple_GetStringValues_Evaluations
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
```

5. Use `EvaluationClient` to create the evaluation with provided parameters.

Synchronous sample:
```C# Snippet:Sample_CreateEvaluationObject_Evaluations_Sync
using BinaryContent evaluationDataContent = BinaryContent.Create(evaluationData);
ClientResult evaluation = evaluationClient.CreateEvaluation(evaluationDataContent);
Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
string evaluationName = fields["name"];
string evaluationId = fields["id"];
Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateEvaluationObject_Evaluations_Async
using BinaryContent evaluationDataContent = BinaryContent.Create(evaluationData);
ClientResult evaluation = await evaluationClient.CreateEvaluationAsync(evaluationDataContent);
Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
string evaluationName = fields["name"];
string evaluationId = fields["id"];
Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
```

6. Create the `runData` object. It contains name and ID of the evaluation we have created above, and data source, consisting of target agent name and version, two queries for an agent and the template, mapping these questions to the text field of the user messages, which will be sent to Agent.


```C# Snippet:Sample_CreateDataSource_Evaluations
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
```

7. Create the evaluation run and extract its ID and status.

Synchronous sample:
```C# Snippet:Sample_CreateRun_Evaluations_Sync
ClientResult run = evaluationClient.CreateEvaluationRun(evaluationId: evaluationId, content: runDataContent);
fields = ParseClientResult(run, ["id", "status"]);
string runId = fields["id"];
string runStatus = fields["status"];
Console.WriteLine($"Evaluation run created (id: {runId})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateRun_Evaluations_Async
ClientResult run = await evaluationClient.CreateEvaluationRunAsync(evaluationId: evaluationId, content: runDataContent);
fields = ParseClientResult(run, ["id", "status"]);
string runId = fields["id"];
string runStatus = fields["status"];
Console.WriteLine($"Evaluation run created (id: {runId})");
```

8. Wait for evaluation run to arrive at the terminal state.

Synchronous sample:
```C# Snippet:Sample_WaitForRun_Evaluations_Sync
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
```

Asynchronous sample:
```C# Snippet:Sample_WaitForRun_Evaluations_Async
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
```

9. Like the `ParseClientResult` we will define the method, getting the result counts `GetResultsCounts`, which formats the `result_counts` property of the output JSON.

```C# Snippet:Sampple_GetResultCounts_Evaluations
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
```

10. To get the results JSON we will define two methods `GetResultsList` and `GetResultsListAsync`, which are iterating over the pages containing results.

Synchronous sample:
```C# Snippet:Sampple_GetResultsList_Evaluations_Sync
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
```

Asynchronous sample:
```C# Snippet:Sampple_GetResultsList_Evaluations_Async
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
```

11. Output the results.

Synchronous sample:
```C# Snippet:Sample_ParseEvaluations_Evaluations_Sync
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
```

Asynchronous sample:
```C# Snippet:Sample_ParseEvaluations_Evaluations_Async
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
```

12. Finally, delete evaluation and Agent used in this sample.

Synchronous sample:
```C# Snippet:Sample_Cleanup_Evaluations_Sync
evaluationClient.DeleteEvaluation(evaluationId, new System.ClientModel.Primitives.RequestOptions());
projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_Evaluations_Async
await evaluationClient.DeleteEvaluationAsync(evaluationId, new System.ClientModel.Primitives.RequestOptions());
await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```
