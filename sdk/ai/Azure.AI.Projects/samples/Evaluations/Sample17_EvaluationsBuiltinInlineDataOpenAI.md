# Sample of using Built-in Evaluators with Inline Data in OpenAI

In this example we demonstrate how to use built-in evaluators (violence, F1 score, coherence) with inline JSONL data to evaluate model responses containing query, response, context, and ground truth fields.

1. Define the custom policy to provide the headers, needed by Azure OpenAI.

```C# Snippet:Sample_HeaderPolicy_EvaluationsBuiltinInlineDataOpenAI
internal class HeaderPolicy : PipelinePolicy
{
    private const string FEATURE_HEADER = "Foundry-Features";
    private const string FEATURE_VALUE = "Evaluations=V1Preview";
    private const string X_REQUEST_ID = "x-ms-client-request-id";
    private readonly string _xRequestIdVlue = Guid.NewGuid().ToString().ToLowerInvariant();

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        message.Request.Headers.Add(FEATURE_HEADER, FEATURE_VALUE);
        message.Request.Headers.Add(X_REQUEST_ID, _xRequestIdVlue);
        ProcessNext(message, pipeline, currentIndex);
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        message.Request.Headers.Add(FEATURE_HEADER, FEATURE_VALUE);
        message.Request.Headers.Add(X_REQUEST_ID, _xRequestIdVlue);
        await ProcessNextAsync(message, pipeline, currentIndex);
    }
}
```

2. Define helper methods for parsing protocol-level responses. The `ParseClientResult` method extracts string values from the JSON response.

```C# Snippet:Sample_GetStringValues_EvaluationsBuiltinInlineDataOpenAI
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

3. Define a helper to extract error messages from the response.

```C# Snippet:Sample_GetError_EvaluationsBuiltinInlineDataOpenAI
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
```

4. Create the `OpenAI` client and the `EvaluationClient` for managing evaluations. We also need to provide custom headers and authorization scope.

```C# Snippet:Sample_CreateClients_EvaluationsBuiltinInlineDataOpenAI
var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
Dictionary<string, object>[] flows =
[
    new Dictionary<string, object>
    {
        { GetTokenOptions.ScopesPropertyName, new string[] { "https://ai.azure.com/.default" } },
        { GetTokenOptions.AuthorizationUrlPropertyName, "https://login.microsoftonline.com/common/oauth2/v2.0/authorize" }
    }
];
AuthenticationPolicy auth = new BearerTokenPolicy(new DefaultAzureCredential(), flows);
OpenAIClientOptions options = new()
{
    Endpoint = new(new Uri(endpoint).AbsoluteUri.TrimEnd('/') + "/openai/v1")
};
options.AddPolicy(new HeaderPolicy(), PipelinePosition.PerCall);
OpenAIClient client = new(authenticationPolicy: auth, options: options);
EvaluationClient evaluationClient = client.GetEvaluationClient();
```

5. Define the data source configuration and testing criteria. The data source schema includes `query`, `response`, `context`, and `ground_truth` fields with `include_sample_schema` set to `true`. The testing criteria uses three built-in evaluators: **violence** (safety evaluator requiring a model deployment), **f1_score** (text similarity without additional configuration), and **coherence** (quality evaluator requiring a model deployment).

```C# Snippet:Sample_CreateData_EvaluationsBuiltinInlineDataOpenAI
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
```

6. Create the evaluation object.

Synchronous sample:
```C# Snippet:Sample_CreateEvaluation_EvaluationsBuiltinInlineDataOpenAI_Sync
Console.WriteLine("Creating Evaluation");
using BinaryContent evaluationDataContent = BinaryContent.Create(GetDataConfig(modelDeploymentName));
ClientResult evaluation = evaluationClient.CreateEvaluation(evaluationDataContent);
Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
string evaluationName = fields["name"];
string evaluationId = fields["id"];
Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateEvaluation_EvaluationsBuiltinInlineDataOpenAI_Async
Console.WriteLine("Creating Evaluation");
using BinaryContent evaluationDataContent = BinaryContent.Create(GetDataConfig(modelDeploymentName));
ClientResult evaluation = await evaluationClient.CreateEvaluationAsync(evaluationDataContent);
Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
string evaluationName = fields["name"];
string evaluationId = fields["id"];
Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
```

7. Retrieve the evaluation by ID to verify it was created successfully.

Synchronous sample:
```C# Snippet:Sample_GetEvaluation_EvaluationsBuiltinInlineDataOpenAI_Sync
Console.WriteLine("Get Evaluation by Id");
ClientResult evaluationResponse = evaluationClient.GetEvaluation(evaluationId, new());
Console.WriteLine($"Retrieved evaluation: {evaluationResponse.GetRawResponse().Content}");
```

Asynchronous sample:
```C# Snippet:Sample_GetEvaluation_EvaluationsBuiltinInlineDataOpenAI_Async
Console.WriteLine("Get Evaluation by Id");
ClientResult evaluationResponse = await evaluationClient.GetEvaluationAsync(evaluationId, new());
Console.WriteLine($"Retrieved evaluation: {evaluationResponse.GetRawResponse().Content}");
```

8. Define the inline JSONL data source with query/response/context/ground_truth items for the evaluation run.

```C# Snippet:Sample_CreateDataSource_EvaluationsBuiltinInlineDataOpenAI
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
```

9. Create and start the evaluation run.

Synchronous sample:
```C# Snippet:Sample_CreateRun_EvaluationsBuiltinInlineDataOpenAI_Sync
Console.WriteLine("Creating Eval Run with Inline Data");
using BinaryContent runDataContent = BinaryContent.Create(GetData());
ClientResult run = evaluationClient.CreateEvaluationRun(evaluationId: evaluationId, content: runDataContent);
fields = ParseClientResult(run, ["id", "status"]);
string runId = fields["id"];
string runStatus = fields["status"];
Console.WriteLine($"Evaluation run created (id: {runId})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateRun_EvaluationsBuiltinInlineDataOpenAI_Async
Console.WriteLine("Creating Eval Run with Inline Data");
using BinaryContent runDataContent = BinaryContent.Create(GetData());
ClientResult run = await evaluationClient.CreateEvaluationRunAsync(evaluationId: evaluationId, content: runDataContent);
fields = ParseClientResult(run, ["id", "status"]);
string runId = fields["id"];
string runStatus = fields["status"];
Console.WriteLine($"Evaluation run created (id: {runId})");
```

10. Retrieve the evaluation run by ID.

Synchronous sample:
```C# Snippet:Sample_GetRun_EvaluationsBuiltinInlineDataOpenAI_Sync
Console.WriteLine("Get Eval Run by Id");
ClientResult evalRunResponse = evaluationClient.GetEvaluationRun(evaluationId: evaluationId, evaluationRunId: runId, options: new());
Console.WriteLine($"Eval Run Response: {evalRunResponse.GetRawResponse().Content}");
```

Asynchronous sample:
```C# Snippet:Sample_GetRun_EvaluationsBuiltinInlineDataOpenAI_Async
Console.WriteLine("Get Eval Run by Id");
ClientResult evalRunResponse = await evaluationClient.GetEvaluationRunAsync(evaluationId: evaluationId, evaluationRunId: runId, options: new());
Console.WriteLine($"Eval Run Response: {evalRunResponse.GetRawResponse().Content}");
```

11. Wait for the evaluation run to complete by polling the run status.

Synchronous sample:
```C# Snippet:Sample_WaitForRun_EvaluationsBuiltinInlineDataOpenAI_Sync
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
```

Asynchronous sample:
```C# Snippet:Sample_WaitForRun_EvaluationsBuiltinInlineDataOpenAI_Async
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
```

12. Like the `ParseClientResult` we will define the method, getting the result counts `GetResultsCounts`, which formats the `result_counts` property of the output JSON.

```C# Snippet:Sample_GetResultCounts_EvaluationsBuiltinInlineDataOpenAI
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
```

13. To get the results JSON we will define two methods `GetResultsList` and `GetResultsListAsync`, which are iterating over the pages containing results.

Synchronous sample:
```C# Snippet:Sample_GetResultsList_EvaluationsBuiltinInlineDataOpenAI_Sync
private static List<string> GetResultsList(EvaluationClient client, string evaluationId, string evaluationRunId)
{
    List<string> resultJsons = [];
    bool hasMore = false;
    string after = default;
    do
    {
        ClientResult resultList = client.GetEvaluationRunOutputItems(evaluationId: evaluationId, evaluationRunId: evaluationRunId, limit: null, order: "asc", after: after, outputItemStatus: default, options: new());
        Utf8JsonReader reader = new(resultList.GetRawResponse().Content.ToMemory().ToArray());
        using JsonDocument document = JsonDocument.ParseValue(ref reader);

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
            else if (topProperty.NameEquals("last_id"u8))
            {
                after = topProperty.Value.GetString();
            }
        }
    } while (hasMore);
    return resultJsons;
}
```

Asynchronous sample:
```C# Snippet:Sample_GetResultsList_EvaluationsBuiltinInlineDataOpenAI_Async
private static async Task<List<string>> GetResultsListAsync(EvaluationClient client, string evaluationId, string evaluationRunId)
{
    List<string> resultJsons = [];
    bool hasMore = false;
    string after = default;
    do
    {
        ClientResult resultList = await client.GetEvaluationRunOutputItemsAsync(evaluationId: evaluationId, evaluationRunId: evaluationRunId, limit: null, order: "asc", after: after, outputItemStatus: default, options: new());
        Utf8JsonReader reader = new(resultList.GetRawResponse().Content.ToMemory().ToArray());
        using JsonDocument document = JsonDocument.ParseValue(ref reader);

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
            else if (topProperty.NameEquals("last_id"u8))
            {
                after = topProperty.Value.GetString();
            }
        }
    } while (hasMore);
    return resultJsons;
}
```

14. Parse and display the evaluation results including result counts and individual output items.

Synchronous sample:
```C# Snippet:Sample_ParseResults_EvaluationsBuiltinInlineDataOpenAI_Sync
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
```C# Snippet:Sample_ParseResults_EvaluationsBuiltinInlineDataOpenAI_Async
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

15. Clean up by deleting the evaluation.

Synchronous sample:
```C# Snippet:Sample_Cleanup_EvaluationsBuiltinInlineDataOpenAI_Sync
evaluationClient.DeleteEvaluation(evaluationId, new System.ClientModel.Primitives.RequestOptions());
Console.WriteLine("Evaluation deleted");
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_EvaluationsBuiltinInlineDataOpenAI_Async
await evaluationClient.DeleteEvaluationAsync(evaluationId, new System.ClientModel.Primitives.RequestOptions());
Console.WriteLine("Evaluation deleted");
```
