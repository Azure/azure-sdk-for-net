# Sample: Evaluations with Graders in Azure.AI.Projects

This sample demonstrates how to create and run evaluations using various graders.

1. First, create the project client and obtain an `EvaluationClient` for creating and running evaluations.

```C# Snippet:Sample_CreateClients_EvaluationsGraders
var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
EvaluationClient evaluationClient = projectClient.ProjectOpenAIClient.GetEvaluationClient();
```

2. Define the testing criteria using four different grader types and the data source configuration. The `label_model` grader classifies sentiment, `text_similarity` uses BLEU metric for comparison, `string_check` performs exact string matching, and `score_model` evaluates similarity on a 1-5 scale using a model.

```C# Snippet:Sample_CreateData_EvaluationsGraders
object[] testingCriteria = [
    new {
        type = "label_model",
        name = "label_grader",
        model = modelDeploymentName,
        input = new object[] {
            new { role = "developer", content = "Classify the sentiment of the following statement as one of 'positive', 'neutral', or 'negative'" },
            new { role = "user", content = "Statement: {{item.query}}" }
        },
        passing_labels = new[] { "positive", "neutral" },
        labels = new[] { "positive", "neutral", "negative" }
    },
    new {
        type = "text_similarity",
        name = "text_check_grader",
        input = "{{item.ground_truth}}",
        evaluation_metric = "bleu",
        reference = "{{item.response}}",
        pass_threshold = 1
    },
    new {
        type = "string_check",
        name = "string_check_grader",
        input = "{{item.ground_truth}}",
        reference = "{{item.ground_truth}}",
        operation = "eq"
    },
    new {
        type = "score_model",
        name = "score",
        model = modelDeploymentName,
        input = new object[] {
            new { role = "system", content = "Evaluate the degree of similarity between the given output and the ground truth on a scale from 1 to 5, using a chain of thought to ensure step-by-step reasoning before reaching the conclusion.\n\nConsider the following criteria:\n\n- 5: Highly similar - The output and ground truth are nearly identical, with only minor, insignificant differences.\n- 4: Somewhat similar - The output is largely similar to the ground truth but has few noticeable differences.\n- 3: Moderately similar - There are some evident differences, but the core essence is captured in the output.\n- 2: Slightly similar - The output only captures a few elements of the ground truth and contains several differences.\n- 1: Not similar - The output is significantly different from the ground truth, with few or no matching elements.\n\n# Steps\n\n1. Identify and list the key elements present in both the output and the ground truth.\n2. Compare these key elements to evaluate their similarities and differences, considering both content and structure.\n3. Analyze the semantic meaning conveyed by both the output and the ground truth, noting any significant deviations.\n4. Based on these comparisons, categorize the level of similarity according to the defined criteria above.\n5. Write out the reasoning for why a particular score is chosen, to ensure transparency and correctness.\n6. Assign a similarity score based on the defined criteria above.\n\n# Output Format\n\nProvide the final similarity score as an integer (1, 2, 3, 4, or 5).\n\n# Examples\n\n**Example 1:**\n\n- Output: \"The cat sat on the mat.\"\n- Ground Truth: \"The feline is sitting on the rug.\"\n- Reasoning: Both sentences describe a cat sitting on a surface, but they use different wording. The structure is slightly different, but the core meaning is preserved. There are noticeable differences, but the overall meaning is conveyed well.\n- Similarity Score: 3\n\n**Example 2:**\n\n- Output: \"The quick brown fox jumps over the lazy dog.\"\n- Ground Truth: \"A fast brown animal leaps over a sleeping canine.\"\n- Reasoning: The meaning of both sentences is very similar, with only minor differences in wording. The structure and intent are well preserved.\n- Similarity Score: 4\n\n# Notes\n\n- Always aim to provide a fair and balanced assessment.\n- Consider both syntactic and semantic differences in your evaluation.\n- Consistency in scoring similar pairs is crucial for accurate measurement." },
            new { role = "user", content = "Output: {{item.response}}\nGround Truth: {{item.ground_truth}}" }
        },
        image_tag = "2025-05-08",
        pass_threshold = 0.5
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
            query = new { type = "string" },
            response = new { type = "string" },
            context = new { type = "string" },
            ground_truth = new { type = "string" }
        },
        required = new string[] { }
    },
    include_sample_schema = true
};
BinaryData evaluationData = BinaryData.FromObjectAsJson(
    new
    {
        name = "OpenAI graders test",
        data_source_config = dataSourceConfig,
        testing_criteria = testingCriteria
    }
);
```

3. Define helper method for parsing results from the protocol-based API responses.

```C# Snippet:Sample_GetStringValues_EvaluationsGraders
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
```

4. Define the method to extract error messages from failed responses.

```C# Snippet:Sample_GetError_EvaluationsGraders
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

5. Create the evaluation with the defined graders and data source configuration.

Synchronous sample:
```C# Snippet:Sample_CreateEvaluation_EvaluationsGraders_Sync
using BinaryContent evaluationDataContent = BinaryContent.Create(evaluationData);
ClientResult evaluation = evaluationClient.CreateEvaluation(evaluationDataContent);
Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
string evaluationName = fields["name"];
string evaluationId = fields["id"];
Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateEvaluation_EvaluationsGraders_Async
using BinaryContent evaluationDataContent = BinaryContent.Create(evaluationData);
ClientResult evaluation = await evaluationClient.CreateEvaluationAsync(evaluationDataContent);
Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
string evaluationName = fields["name"];
string evaluationId = fields["id"];
Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
```

6. Define the inline JSONL data source with sample items containing query, context, ground truth, and response fields that the graders will evaluate.

```C# Snippet:Sample_CreateRunDataSource_EvaluationsGraders
object dataSource = new
{
    type = "jsonl",
    source = new
    {
        type = "file_content",
        content = new[] {
            new { item = new { query = "I love this product! It works great.", context = "Product review context", ground_truth = "The product is excellent and performs well.", response = "The product is amazing and works perfectly." } },
            new { item = new { query = "The weather is cloudy today.", context = "Weather observation", ground_truth = "Today's weather is overcast.", response = "The sky is covered with clouds today." } },
            new { item = new { query = "What is the capital of France?", context = "Geography question about European capitals", ground_truth = "Paris", response = "The capital of France is Paris." } },
            new { item = new { query = "Explain quantum computing", context = "Complex scientific concept explanation", ground_truth = "Quantum computing uses quantum mechanics principles", response = "Quantum computing leverages quantum mechanical phenomena like superposition and entanglement to process information." } },
        }
    }
};
BinaryData runData = BinaryData.FromObjectAsJson(
    new
    {
        eval_id = evaluationId,
        name = "inline_data_graders_run",
        metadata = new { team = "eval-exp", scenario = "graders-inline-v1" },
        data_source = dataSource
    }
);
using BinaryContent runDataContent = BinaryContent.Create(runData);
```

7. Create the evaluation run using the inline data.

Synchronous sample:
```C# Snippet:Sample_CreateRun_EvaluationsGraders_Sync
ClientResult run = evaluationClient.CreateEvaluationRun(evaluationId: evaluationId, content: runDataContent);
fields = ParseClientResult(run, ["id", "status"]);
string runId = fields["id"];
string runStatus = fields["status"];
Console.WriteLine($"Evaluation run created (id: {runId})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateRun_EvaluationsGraders_Async
ClientResult run = await evaluationClient.CreateEvaluationRunAsync(evaluationId: evaluationId, content: runDataContent);
fields = ParseClientResult(run, ["id", "status"]);
string runId = fields["id"];
string runStatus = fields["status"];
Console.WriteLine($"Evaluation run created (id: {runId})");
```

8. Wait for the evaluation run to reach a terminal state (completed or failed).

Synchronous sample:
```C# Snippet:Sample_WaitForRun_EvaluationsGraders_Sync
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
```C# Snippet:Sample_WaitForRun_EvaluationsGraders_Async
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

9. Like the `ParseClientResult` we will define the method, getting the result counts `GetResultsCounts`, which formats the `result_counts` property of the output JSON.

```C# Snippet:Sample_GetResultCounts_EvaluationsGraders
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

10. To get the results JSON we will define two methods `GetResultsList` and `GetResultsListAsync`, which are iterating over the pages containing results.

Synchronous sample:
```C# Snippet:Sample_GetResultsList_EvaluationsGraders_Sync
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
```C# Snippet:Sample_GetResultsList_EvaluationsGraders_Async
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

11. Retrieve and display the evaluation results.

Synchronous sample:
```C# Snippet:Sample_ParseResults_EvaluationsGraders_Sync
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
```C# Snippet:Sample_ParseResults_EvaluationsGraders_Async
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

12. Clean up by deleting the evaluation.

Synchronous sample:
```C# Snippet:Sample_Cleanup_EvaluationsGraders_Sync
evaluationClient.DeleteEvaluation(evaluationId, new System.ClientModel.Primitives.RequestOptions());
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_EvaluationsGraders_Async
await evaluationClient.DeleteEvaluationAsync(evaluationId, new System.ClientModel.Primitives.RequestOptions());
```
