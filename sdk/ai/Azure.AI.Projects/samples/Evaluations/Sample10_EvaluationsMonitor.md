# Sample of using evaluation on Agent traces in Azure.AI.Projects.

Given an `AIProjectClient`, this sample demonstrates how to run Azure AI Evaluations
against agent traces collected in Azure Application Insights. The sample fetches
trace IDs for a given agent and time range, creates an evaluation group configured
for trace analysis and monitors the evaluation run until it completes.

## Prerequisites
1. Create the Application Insights and add it as a connection to Azure Foundry.
2. Assign the "Log Analytics Reader" role for AI Foundry and the projects managed identity (this operation may take up to an hour).
3. In this example it is expected that the Application Insights contains traces for the Agent. To make sure that the traces were logged, we recommend running [telemetry sample](https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/ai/azure-ai-projects/samples/agents/telemetry/sample_agent_basic_with_azure_monitor_tracing.py) and saving the agent ID to be used as an environment variable. Please set the environment variable `OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT` to be `true` to save messages to traces. Agent ID has a form of `$"{agent.Name}:{agent.Version}"`. It may be also useful to change the Agent's name, so that it can be separated from Agents, which may not have traces.


## Run the sample

1. First, we need to create project client and read the environment variables which will be used in the next steps. We will also create an `EvaluationClient` for creating and running evaluations.

```C# Snippet:Sampple_CreateClients_EvaluationsMonitor
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var applicationInsightsResourceId = System.Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_RESOURCE_ID");
var agentId = System.Environment.GetEnvironmentVariable("AGENT_ID");
var lookbackHours = int.Parse(System.Environment.GetEnvironmentVariable("TRACE_LOOKBACK_HOURS"));
DateTimeOffset endTime = DateTimeOffset.Now;
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
EvaluationClient evaluationClient = projectClient.OpenAI.GetEvaluationClient();
```

2. To get the traces IDs for the Agent we will create and run the query our Application Insights.

Synchronous sample:
```C# Snippet:Sample_GetTraceIDsFromAppInsights_EvaluationsMonitor_Sync
private static List<string> GetOperationIds(string applicationInsightsId, string agentID, int traceQueryHours, DateTimeOffset endTime)
{
    List<string> results = [];
    string query = "dependencies\n" +
           "| extend agent_id = tostring(customDimensions[\"gen_ai.agent.id\"])\n" +
           $"| where agent_id == \"{agentID}\"\n" +
           "| distinct operation_Id";
    LogsQueryClient client = new(new DefaultAzureCredential());
    LogsQueryTimeRange range = new(
        duration: new TimeSpan(hours: traceQueryHours, minutes: 0, seconds: 0),
        end: endTime
    );
    Response<LogsQueryResult> response = client.QueryResource(resourceId: new(applicationInsightsId), query: query, timeRange: range);
    if (response.GetRawResponse().IsError)
    {
        throw new InvalidOperationException($"The application insights query returned an error: {Encoding.UTF8.GetString(response.GetRawResponse().Content.ToArray())}");
    }
    foreach (LogsTable table in response.Value.AllTables)
    {
        foreach (LogsTableRow tableRow in table.Rows)
        {
            results.Add(tableRow.GetString(0));
        }
    }
    if (results.Count == 0)
    {
        throw new InvalidOperationException("The query returned no results.");
    }
    return results;
}
```

Asynchronous sample:
```C# Snippet:Sample_GetTraceIDsFromAppInsights_EvaluationsMonitor_Async
private static async Task<List<string>> GetOperationIdsAsync(string applicationInsightsId, string agentID, int traceQueryHours, DateTimeOffset endTime)
{
    List<string> results = [];
    string query = "dependencies\n" +
           "| extend agent_id = tostring(customDimensions[\"gen_ai.agent.id\"])\n" +
           $"| where agent_id == \"{agentID}\"\n" +
           "| distinct operation_Id";
    LogsQueryClient client = new(new DefaultAzureCredential());
    LogsQueryTimeRange range = new(
        duration: new TimeSpan(hours: traceQueryHours, minutes: 0, seconds: 0),
        end: endTime
    );
    Response<LogsQueryResult> response = await client.QueryResourceAsync(resourceId: new(applicationInsightsId), query: query, timeRange: range);
    if (response.GetRawResponse().IsError)
    {
        throw new InvalidOperationException($"The application insights query returned an error: {Encoding.UTF8.GetString(response.GetRawResponse().Content.ToArray())}");
    }
    foreach (LogsTable table in response.Value.AllTables)
    {
        foreach (LogsTableRow tableRow in table.Rows)
        {
            results.Add(tableRow.GetString(0));
        }
    }
    if (results.Count == 0)
    {
        throw new InvalidOperationException("The query returned no results.");
    }
    return results;
}
```

3. Get the trace or operation IDs for an agent.

Synchronous sample:
```C# Snippet:Sample_GetTraceIDs_EvaluationsMonitor_Sync
List<string> traceIDs = GetOperationIds(applicationInsightsResourceId, agentId, lookbackHours, endTime);
Console.WriteLine($"Found {traceIDs.Count} operation IDs:");
foreach (string id in traceIDs)
{
    Console.WriteLine($"    {id}");
}
```

Asynchronous sample:
```C# Snippet:Sample_GetTraceIDs_EvaluationsMonitor_Async
List<string> traceIDs = await GetOperationIdsAsync(applicationInsightsResourceId, agentId, lookbackHours, endTime);
Console.WriteLine($"Found {traceIDs.Count} operation IDs:");
foreach (string id in traceIDs)
{
    Console.WriteLine($"    {id}");
}
```

4. Define the evaluation criteria and the data source config. Testing criteria lists all the evaluators and data mappings for them. In this example we will use two built in evaluators: "intent_resolution" and "task_adherence". These evaluators will expect the data set containing fields "query", "response" and "tool_definitions". The data source configuration must have `scenario` field set to `traces`, informing that the data will be generated from Kusto query.

```C# Snippet:Sample_CreateData_EvaluationsMonitor
private static BinaryData GetEvaluationCriteria(string[] names, string modelDeploymentName)
{
    object[] testingCriteria = new object[names.Length];
    for (int i = 0; i < names.Length; i++)
    {
        testingCriteria[i] = new {
            type = "azure_ai_evaluator",
            name = names[i],
            evaluator_name = $"builtin.{names[i]}",
            data_mapping = new { query = "{{query}}", response = "{{response}}", tool_definitions= "{{tool_definitions}}" },
            initialization_parameters = new { deployment_name = modelDeploymentName },
        };
    }
    object dataSourceConfig = new
    {
        type = "azure_ai_source",
        scenario = "traces"
    };
    return BinaryData.FromObjectAsJson(
        new
        {
            name = "Agent Evaluation",
            data_source_config = dataSourceConfig,
            testing_criteria = testingCriteria
        }
    );
}
```

5. The `EvaluationClient` uses protocol methods i.e. they take in JSON in the form of `BinaryData` and return `ClientResult`, containing binary encoded JSON response, which can be retrieved using `GetRawResponse()` method. To simplify parsing JSON we will create helper methods. One of the methods is named `ParseClientResult`. It gets string values of the top-level JSON properties. In the next section we will use this method to get evaluation name and ID.

```C# Snippet:Sampple_GetStringValues_EvaluationsMonitor
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

6. Use `EvaluationClient` to create the evaluation with provided parameters.

Synchronous sample:
```C# Snippet:Sample_CreateEvaluationObject_EvaluationsMonitor_Sync
using BinaryContent evaluationCriteria = BinaryContent.Create(GetEvaluationCriteria(["intent_resolution", "task_adherence"], modelDeploymentName));
ClientResult evaluation = evaluationClient.CreateEvaluation(evaluationCriteria);
Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
string evaluationName = fields["name"];
string evaluationId = fields["id"];
Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateEvaluationObject_EvaluationsMonitor_Async
using BinaryContent evaluationCriteria = BinaryContent.Create(GetEvaluationCriteria(["intent_resolution", "task_adherence"], modelDeploymentName));
ClientResult evaluation = await evaluationClient.CreateEvaluationAsync(evaluationCriteria);
Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
string evaluationName = fields["name"];
string evaluationId = fields["id"];
Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
```

7. Create the `runData` object. It contains name and ID of the evaluation we have created above, and data source. In this scenario it type is `azure_ai_traces`, which informs the service to run the Kusto query on traces and filter it by the trace IDs we have obtained earlier.


```C# Snippet:Sample_CreateDataSource_EvaluationsMonitor
object dataSource = new
{
    type = "azure_ai_traces",
    trace_ids = traceIDs,
    lookback_hours = lookbackHours
};
BinaryData runData = BinaryData.FromObjectAsJson(
    new
    {
        eval_id = evaluationId,
        name = $"agent_trace_eval_{endTime:O}",
        data_source = dataSource,
        metadata = new
        {
            agent_id = agentId,
            start_time = endTime.AddHours(-lookbackHours).ToString("O"),
            end_time = endTime.ToString("O"),
        }
    }
);
using BinaryContent runDataContent = BinaryContent.Create(runData);
```

8. Create the evaluation run and extract its ID and status.

Synchronous sample:
```C# Snippet:Sample_CreateRun_EvaluationsMonitor_Sync
ClientResult run = evaluationClient.CreateEvaluationRun(evaluationId: evaluationId, content: runDataContent);
fields = ParseClientResult(run, ["id", "status"]);
string runId = fields["id"];
string runStatus = fields["status"];
Console.WriteLine($"Evaluation run created (id: {runId})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateRun_EvaluationsMonitor_Async
ClientResult run = await evaluationClient.CreateEvaluationRunAsync(evaluationId: evaluationId, content: runDataContent);
fields = ParseClientResult(run, ["id", "status"]);
string runId = fields["id"];
string runStatus = fields["status"];
Console.WriteLine($"Evaluation run created (id: {runId})");
```

9. Define the method to get the error message and code from the response if any.

```C# Snippet:Sampple_GetError_EvaluationsMonitor
private static string GetErrorMessageOrEmpty(ClientResult result)
{
    string error = "";
    Utf8JsonReader reader = new(result.GetRawResponse().Content.ToMemory().ToArray());
    JsonDocument document = JsonDocument.ParseValue(ref reader);
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
```

10. Wait for evaluation run to arrive at the terminal state.

Synchronous sample:
```C# Snippet:Sample_WaitForRun_EvaluationsMonitor_Sync
while (runStatus != "failed" && runStatus != "completed")
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    run = evaluationClient.GetEvaluationRun(evaluationId: evaluationId, evaluationRunId: runId, options: new());
    runStatus = ParseClientResult(run, ["status"])["status"];
    Console.WriteLine($"Waiting for eval run to complete... current status: {runStatus}");
}
if (runStatus == "failed")
{
    throw new InvalidOperationException($"Evaluation run failed with error: {GetErrorMessageOrEmpty(run)}");
}
```

Asynchronous sample:
```C# Snippet:Sample_WaitForRun_EvaluationsMonitor_Async
while (runStatus != "failed" && runStatus != "completed")
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    run = await evaluationClient.GetEvaluationRunAsync(evaluationId: evaluationId, evaluationRunId: runId, options: new());
    runStatus = ParseClientResult(run, ["status"])["status"];
    Console.WriteLine($"Waiting for eval run to complete... current status: {runStatus}");
}
if (runStatus == "failed")
{
    throw new InvalidOperationException($"Evaluation run failed with error: {GetErrorMessageOrEmpty(run)}");
}
```

11. Like the `ParseClientResult` we will define the method, getting the result counts `GetResultsCounts`, which formats the `result_counts` property of the output JSON.

```C# Snippet:Sampple_GetResultCounts_EvaluationsMonitor
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

12. To get the results JSON we will define two methods `GetResultsList` and `GetResultsListAsync`, which are iterating over the pages containing results.

Synchronous sample:
```C# Snippet:Sampple_GetResultsList_EvaluationsMonitor_Sync
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
```C# Snippet:Sampple_GetResultsList_EvaluationsMonitor_Async
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

12. Output the results.

Synchronous sample:
```C# Snippet:Sample_ParseEvaluations_EvaluationsMonitor_Sync
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
```C# Snippet:Sample_ParseEvaluations_EvaluationsMonitor_Async
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

13. Finally, delete evaluation used in this sample.

Synchronous sample:
```C# Snippet:Sample_Cleanup_EvaluationsMonitor_Sync
evaluationClient.DeleteEvaluation(evaluationId, new System.ClientModel.Primitives.RequestOptions());
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_EvaluationsMonitor_Async
await evaluationClient.DeleteEvaluationAsync(evaluationId, new System.ClientModel.Primitives.RequestOptions());
```
