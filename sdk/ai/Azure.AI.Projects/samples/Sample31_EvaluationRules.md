# Sample of using evaluation rules in Azure.AI.Projects.

This sample demonstrates how to create and manage evaluation rules using the synchronous `AIProjectClient`. Evaluation rules allow subscribing the evaluation to a specific event. In the example below we create evaluation rule, which launches evaluation each time the Agent sends the response.

## Prerequisites
To enable continuous evaluation, please assign project managed identity with the following steps:

1. Open https://portal.azure.com
2. Search for the AI Foundry project from search bar
3. Choose "Access control (IAM)" -> "Add"
4. In "Add role assignment", search for "Azure AI User"
5. Choose "User, group, or service principal" or "Managed Identity", add your AI Foundry project managed identity

## Run the sample

1. First, we need to create project client and read the environment variables which will be used in the next steps. We will also create an `EvaluationClient` to create evaluation.

```C# Snippet:Sample_CreateClients_EvaluationRules
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
EvaluationClient evaluationClient = projectClient.OpenAI.GetEvaluationClient();
```

2. Create a target Agent to get responses from.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_EvaluationRules_Sync
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant that answers general questions",
};
AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
    agentName: "evalAgent",
    options: new(agentDefinition));
Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_EvaluationRules_Async
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant that answers general questions",
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "evalAgent",
    options: new(agentDefinition));
Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
```

3. Define the evaluation criteria and the data source config. Testing criteria lists all the evaluators. In this example we will use only built-in "violence" evaluator. We will configure the data source to get data from the Agent responses.

```C# Snippet:Sample_CreateData_EvaluationRules
private BinaryData evaluationConfig =  BinaryData.FromObjectAsJson(
    new
    {
        name = "Continuous Evaluation",
        data_source_config = new
        {
            type = "azure_ai_source",
            scenario = "responses"
        },
        testing_criteria = new[]
        {
            new {
                type = "azure_ai_evaluator",
                name = "violence_detection",
                evaluator_name = "builtin.violence",
            },
        }
    }
);
```

4. The `EvaluationClient` uses protocol methods i.e. they take in JSON in the form of `BinaryData` and return `ClientResult`, containing binary encoded JSON response, which can be retrieved using `GetRawResponse()` method. To simplify parsing JSON we will create helper methods. One of the methods is named `ParseClientResult`. It gets string values of the top-level JSON properties. In the next section we will use it to get evaluation name and ID.

```C# Snippet:Sampple_GetStringValues_EvaluationRules
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
```C# Snippet:Sample_CreateEvaluationObject_EvaluationRules_Sync
using BinaryContent evaluationDataContent = BinaryContent.Create(evaluationConfig);
ClientResult evaluation = evaluationClient.CreateEvaluation(evaluationDataContent);
Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
string evaluationName = fields["name"];
string evaluationId = fields["id"];
Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateEvaluationObject_EvaluationRules_Async
using BinaryContent evaluationDataContent = BinaryContent.Create(evaluationConfig);
ClientResult evaluation = await evaluationClient.CreateEvaluationAsync(evaluationDataContent);
Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
string evaluationName = fields["name"];
string evaluationId = fields["id"];
Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
```

6. Create `EvaluationRule` object. Set the maximum number of runs to 100 per hour, subscribe to the `ResponseCompleted` event of an Agent we have created above.

```C# Snippet:Sample_CreateRule_EvaluationRules
ContinuousEvaluationRuleAction continuousAction = new(evaluationId)
{
    MaxHourlyRuns = 100,
};
EvaluationRule continuousRule = new(
    action: continuousAction, eventType: EvaluationRuleEventType.ResponseCompleted, enabled: true)
{
    Filter = new EvaluationRuleFilter(agentName: agentVersion.Name),
    DisplayName = "Continuous evaluation rule."
};
```

7. Apply rule we have just created.

Synchronous sample:
```C# Snippet:Sample_CreateRuleOnAzure_EvaluationRules_Sync
EvaluationRule continuousEvalRule = projectClient.EvaluationRules.CreateOrUpdate(
    id: "my-continuous-eval-rule",
    evaluationRule: continuousRule
);
Console.WriteLine($"Continuous Evaluation Rule created (id: {continuousEvalRule.Id}, name: {continuousEvalRule.DisplayName})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateRuleOnAzure_EvaluationRules_Async
EvaluationRule continuousEvalRule = await projectClient.EvaluationRules.CreateOrUpdateAsync(
    id: "my-continuous-eval-rule",
    evaluationRule: continuousRule
);
Console.WriteLine($"Continuous Evaluation Rule created (id: {continuousEvalRule.Id}, name: {continuousEvalRule.DisplayName})");
```

8. Create conversation.

Synchronous sample:
```C# Snippet:Sample_CreateConversation_EvaluationRules_Sync
ProjectConversation conversation = projectClient.OpenAI.Conversations.CreateProjectConversation();
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion, conversation.Id);
```

Asynchronous sample:
```C# Snippet:Sample_CreateConversation_EvaluationRules_Async
ProjectConversation conversation = await projectClient.OpenAI.Conversations.CreateProjectConversationAsync();
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion, conversation.Id);
```

9. To monitor the evaluation runs we will implement two methods `GetRunIDs` and `GetRunIDsAsync` for synchronous and asynchronous runs respectively.

Synchronous sample:
```C# Snippet:Sample_GetRunIDs_EvaluationRules_Sync
private static Dictionary<string, (string RunUri, string RunStatus)> GetRunIDs(EvaluationClient client, string evaluationId, string evaluationRunStatus = default)
{
    Dictionary<string, (string, string)> runIDs = [];
    bool hasMore = false;
    string lastId = default;
    do
    {
        ClientResult resultList = client.GetEvaluationRuns(evaluationId: evaluationId, limit: 10, order: "desc", after: lastId, evaluationRunStatus: evaluationRunStatus, options: new System.ClientModel.Primitives.RequestOptions());
        Utf8JsonReader reader = new(resultList.GetRawResponse().Content.ToMemory().ToArray());
        JsonDocument document = JsonDocument.ParseValue(ref reader);

        foreach (JsonProperty topProperty in document.RootElement.EnumerateObject())
        {
            if (topProperty.NameEquals("has_more"u8))
            {
                hasMore = topProperty.Value.GetBoolean();
            }
            else if (topProperty.NameEquals("last_id"u8))
            {
                lastId = topProperty.Value.GetString();
            }
            else if (topProperty.NameEquals("data"u8))
            {
                if (topProperty.Value.ValueKind == JsonValueKind.Array)
                {
                    foreach (JsonElement dataElement in topProperty.Value.EnumerateArray())
                    {
                        string runId = default, runUri = default, runStatus = default;
                        foreach (JsonProperty runProperty in dataElement.EnumerateObject())
                        {
                            if (runProperty.Value.ValueKind == JsonValueKind.String)
                            {
                                if (runProperty.NameEquals("id"u8))
                                {
                                    runId = runProperty.Value.GetString();
                                }
                                else if (runProperty.NameEquals("report_url"u8))
                                {
                                    runUri = runProperty.Value.GetString();
                                }
                                else if (runProperty.NameEquals("status"u8))
                                {
                                    runStatus = runProperty.Value.GetString();
                                }
                            }
                            if (!string.IsNullOrEmpty(runId) && !string.IsNullOrEmpty(runUri) && !string.IsNullOrEmpty(runStatus))
                            {
                                break;
                            }
                        }
                        if (!string.IsNullOrEmpty(runId))
                        {
                            runIDs[runId] = (runUri, runStatus);
                        }
                    }
                }
            }
        }
    } while (hasMore);
    return runIDs;
}
```

Asynchronous sample:
```C# Snippet:Sample_GetRunIDs_EvaluationRules_Async
private static async Task<Dictionary<string, (string RunUri, string RunStatus)>> GetRunIDsAsync(EvaluationClient client, string evaluationId, string evaluationRunStatus=default)
{
    Dictionary<string, (string, string)> runIDs = [];
    bool hasMore = false;
    string lastId = default;
    do
    {
        ClientResult resultList = await client.GetEvaluationRunsAsync(evaluationId: evaluationId, limit: 10, order: "desc", after: lastId, evaluationRunStatus: evaluationRunStatus, options: new System.ClientModel.Primitives.RequestOptions());
        Utf8JsonReader reader = new(resultList.GetRawResponse().Content.ToMemory().ToArray());
        JsonDocument document = JsonDocument.ParseValue(ref reader);

        foreach (JsonProperty topProperty in document.RootElement.EnumerateObject())
        {
            if (topProperty.NameEquals("has_more"u8))
            {
                hasMore = topProperty.Value.GetBoolean();
            }
            else if (topProperty.NameEquals("last_id"u8))
            {
                lastId = topProperty.Value.GetString();
            }
            else if (topProperty.NameEquals("data"u8))
            {
                if (topProperty.Value.ValueKind == JsonValueKind.Array)
                {
                    foreach (JsonElement dataElement in topProperty.Value.EnumerateArray())
                    {
                        string runId = default, runUri = default, runStatus = default;
                        foreach (JsonProperty runProperty in dataElement.EnumerateObject())
                        {
                            if (runProperty.Value.ValueKind == JsonValueKind.String)
                            {
                                if (runProperty.NameEquals("id"u8))
                                {
                                    runId = runProperty.Value.GetString();
                                }
                                else if (runProperty.NameEquals("report_url"u8))
                                {
                                    runUri = runProperty.Value.GetString();
                                }
                                else if (runProperty.NameEquals("status"u8))
                                {
                                    runStatus = runProperty.Value.GetString();
                                }
                            }
                            if (!string.IsNullOrEmpty(runId) && !string.IsNullOrEmpty(runUri) && !string.IsNullOrEmpty(runStatus))
                            {
                                break;
                            }
                        }
                        if (!string.IsNullOrEmpty(runId))
                        {
                            runIDs[runId] = (runUri, runStatus);
                        }
                    }
                }
            }
        }
    } while (hasMore);
    return runIDs;
}
```

10. In this example we will ask agent questions and will monitor the evaluation runs.

**Note:** If the evaluations run is not being created, please make sure that the Foundry project's Managed Identity was assigned the "Azure AI User" role with regards to the Foundry project itself, as outlined in Prerequisites section.

Synchronous sample:
```C# Snippet:Sample_AskQuestions_EvaluationRules_Sync
string[] countries = ["France", "Italy", "Ivory Coast", "Kenya", "Uruguay", "Morocco", "Tajikistan", "Somalia", "Brunei", "Belgium"];
HashSet<string> allRuns = [];
foreach (string country in countries)
{
    ResponseResult response = responseClient.CreateResponse($"What is the capital of {country}");
    Console.WriteLine($"Response output: {response.GetOutputText()}.");

    Thread.Sleep(TimeSpan.FromSeconds(10));
    Dictionary<string, (string, string)> newEvaluationRunIds = GetRunIDs(evaluationClient, evaluationId);
    foreach (string runId in newEvaluationRunIds.Keys)
    {
        (_, string runStatus) = newEvaluationRunIds[runId];
        Console.WriteLine($"Run: {runId}, Status: {runStatus}");
    }
}
```

Asynchronous sample:
```C# Snippet:Sample_AskQuestions_EvaluationRules_Async
string[] countries = ["France", "Italy", "Ivory Coast", "Kenya", "Uruguay", "Morocco", "Tajikistan", "Somalia", "Brunei", "Belgium"];
HashSet<string> allRuns = [];
foreach (string country in countries)
{
    ResponseResult response = await responseClient.CreateResponseAsync($"What is the capital of {country}");
    Console.WriteLine($"Response output: {response.GetOutputText()}.");

    await Task.Delay(TimeSpan.FromSeconds(10));
    Dictionary<string, (string, string)> newEvaluationRunIds = await GetRunIDsAsync(evaluationClient, evaluationId);
    foreach (string runId in newEvaluationRunIds.Keys)
    {
        (_, string runStatus) = newEvaluationRunIds[runId];
        Console.WriteLine($"Run: {runId}, Status: {runStatus}");
    }
}
```

11. Wait for all runs to arrive at the terminal state,

Synchronous sample:
```C# Snippet:Sample_WaitForCompletion_EvaluationRules_Sync
bool allDone = false;
Dictionary<string, (string, string)> evaluationRunIds;
do
{
    Thread.Sleep(TimeSpan.FromSeconds(1));
    evaluationRunIds = GetRunIDs(evaluationClient, evaluationId);
    int total = evaluationRunIds.Count, running = 0, completed = 0, failed = 0;
    foreach (string runId in evaluationRunIds.Keys)
    {
        (string Uri, string runStatus) = evaluationRunIds[runId];
        completed += string.Equals(runStatus, "completed") ? 1 : 0;
        failed += string.Equals(runStatus, "failed") ? 1 : 0;
    }
    running = total - completed - failed;
    allDone = running == 0;
    Console.WriteLine($"Running: {running}, completed: {completed}, failed: {failed}, total: {total}.");
}
while (!allDone);
```

Asynchronous sample:
```C# Snippet:Sample_WaitForCompletion_EvaluationRules_Async
bool allDone = false;
Dictionary<string, (string, string)> evaluationRunIds;
do
{
    await Task.Delay(TimeSpan.FromSeconds(1));
    evaluationRunIds = await GetRunIDsAsync(evaluationClient, evaluationId);
    int total = evaluationRunIds.Count, running = 0, completed = 0, failed = 0;
    foreach (string runId in evaluationRunIds.Keys)
    {
        (string Uri, string runStatus) = evaluationRunIds[runId];
        completed += string.Equals(runStatus, "completed") ? 1 : 0;
        failed += string.Equals(runStatus, "failed") ? 1 : 0;
    }
    running = total - completed - failed;
    allDone = running == 0;
    Console.WriteLine($"Running: {running}, completed: {completed}, failed: {failed}, total: {total}.");
}
while (!allDone);
```

12. Define the method to get the error message and code from the response if any.

```C# Snippet:Sampple_GetError_EvaluationRules
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

13. Print the status of each run and Microsoft Foundry portal link to get more information or error if the run was failed, display the link to the whole evaluation.

Synchronous sample:
```C# Snippet:Sample_ParseEvaluations_EvaluationRules_Sync
string lastSuccessfulUri = default;
foreach (string runId in evaluationRunIds.Keys)
{
    (string Uri, string runStatus) = evaluationRunIds[runId];
    if (string.Equals(runStatus, "failed"))
    {
        ClientResult failedRun = evaluationClient.GetEvaluationRun(evaluationId: evaluationId, evaluationRunId: runId, options: new());
        Console.WriteLine($"The run {runId} failed: {GetErrorMessageOrEmpty(failedRun)}");
    }
    else
    {
        lastSuccessfulUri = Uri;
        Console.WriteLine($"To check evaluation run {runId}, please open {Uri} from the browser");
    }
}
Uri lastUri = new(lastSuccessfulUri);
List<string> segments = [.. lastUri.Segments];
// Remove the last 2 URL path segments (run/continuousevalrun_xxx)
segments.RemoveAt(segments.Count - 1);
segments.RemoveAt(segments.Count - 1);
Uri reportUri = new(new Uri($"{lastUri.Scheme}://{lastUri.Host}"), relativeUri: string.Join("", segments));
Console.WriteLine($"To check evaluation runs, please open {reportUri} from the browser");
```

Asynchronous sample:
```C# Snippet:Sample_ParseEvaluations_EvaluationRules_Async
string lastSuccessfulUri = default;
foreach (string runId in evaluationRunIds.Keys)
{
    (string Uri, string runStatus) = evaluationRunIds[runId];
    if (string.Equals(runStatus, "failed"))
    {
        ClientResult failedRun = await evaluationClient.GetEvaluationRunAsync(evaluationId: evaluationId, evaluationRunId: runId, options: new());
        Console.WriteLine($"The run {runId} failed: {GetErrorMessageOrEmpty(failedRun)}");
    }
    else
    {
        lastSuccessfulUri = Uri;
        Console.WriteLine($"To check evaluation run {runId}, please open {Uri} from the browser");
    }
}
Uri lastUri = new(lastSuccessfulUri);
List<string> segments = [.. lastUri.Segments];
// Remove the last 2 URL path segments (run/continuousevalrun_xxx)
segments.RemoveAt(segments.Count - 1);
segments.RemoveAt(segments.Count - 1);
Uri reportUri = new(new Uri($"{lastUri.Scheme}://{lastUri.Host}"), relativeUri: string.Join("", segments));
Console.WriteLine($"To check evaluation runs, please open {reportUri} from the browser");
```

14. Finally, delete evaluation rule and Agent used in this sample. Please be careful by deleting the evaluation as it will remove all the evaluation information from the Microsoft Foundry portal.

Synchronous sample:
```C# Snippet:Sample_Cleanup_EvaluationRules_Sync
projectClient.OpenAI.Conversations.DeleteConversation(conversation.Id);
projectClient.EvaluationRules.Delete(id: continuousEvalRule.Id);
projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
// Warning! After this step the evaluations will be deleted and will not be available on Microsoft Foundry portal.
// First we need to remove all runs.
foreach (string runId in evaluationRunIds.Keys)
{
    evaluationClient.DeleteEvaluationRun(evaluationId: evaluationId, evaluationRunId: runId, options: new());
}
// Remove the evaluation.
evaluationClient.DeleteEvaluation(evaluationId, new System.ClientModel.Primitives.RequestOptions());
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_EvaluationRules_Async
await projectClient.OpenAI.Conversations.DeleteConversationAsync(conversation.Id);
await projectClient.EvaluationRules.DeleteAsync(id: continuousEvalRule.Id);
await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
// Warning! After this step the evaluations will be deleted and will not be available on Microsoft Foundry portal.
// First we need to remove all runs.
foreach (string runId in evaluationRunIds.Keys)
{
    await evaluationClient.DeleteEvaluationRunAsync(evaluationId: evaluationId, evaluationRunId: runId, options: new());
}
// Remove the evaluation.
await evaluationClient.DeleteEvaluationAsync(evaluationId, new System.ClientModel.Primitives.RequestOptions());
```
