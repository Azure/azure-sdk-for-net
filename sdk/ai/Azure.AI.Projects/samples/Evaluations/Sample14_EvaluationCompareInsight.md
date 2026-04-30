# Sample: Compare Evaluation Runs and Generate Comparison Insights

This sample demonstrates how to compare two evaluation runs and generate comparison insights using the `AIProjectClient`. The comparison insight analyzes a baseline run against one or more treatment runs to identify differences.

1. Define helper methods for parsing protocol-level responses. The `ParseClientResult` method extracts string values from the JSON response.

```C# Snippet:Sample_GetStringValues_EvaluationCompareInsight
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

2. Define a helper to extract error messages from the response.

```C# Snippet:Sample_GetError_EvaluationCompareInsight
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

3. Create the project client, evaluation client, and read the environment variables.

```C# Snippet:Sample_CreateClients_EvaluationCompareInsight
var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
EvaluationClient evaluationClient = projectClient.ProjectOpenAIClient.GetEvaluationClient();
```

4. Define the evaluation data source config and testing criteria. We use a `label_model` criterion for sentiment analysis.

```C# Snippet:Sample_CreateEvalData_EvaluationCompareInsight
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
```

5. Create the evaluation using the `EvaluationClient`.

Synchronous sample:
```C# Snippet:Sample_CreateEvaluation_EvaluationCompareInsight_Sync
using BinaryContent evaluationDataContent = BinaryContent.Create(evaluationData);
ClientResult evaluation = evaluationClient.CreateEvaluation(evaluationDataContent);
Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
string evaluationName = fields["name"];
string evaluationId = fields["id"];
Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateEvaluation_EvaluationCompareInsight_Async
using BinaryContent evaluationDataContent = BinaryContent.Create(evaluationData);
ClientResult evaluation = await evaluationClient.CreateEvaluationAsync(evaluationDataContent);
Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
string evaluationName = fields["name"];
string evaluationId = fields["id"];
Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
```

6. Create two evaluation runs: a baseline run and a treatment run, each with different inline data.

Synchronous sample:
```C# Snippet:Sample_CreateTwoRuns_EvaluationCompareInsight_Sync
// Create evaluation run 1 (baseline)
object dataSource1 = new
{
    type = "jsonl",
    source = new
    {
        type = "file_content",
        content = new[]
        {
            new { item = new { query = "I love programming!" } },
            new { item = new { query = "I hate bugs." } },
        }
    }
};
BinaryData runData1 = BinaryData.FromObjectAsJson(
    new { name = "Evaluation Run 1", data_source = dataSource1 }
);
using BinaryContent runDataContent1 = BinaryContent.Create(runData1);
ClientResult run1 = evaluationClient.CreateEvaluationRun(evaluationId: evaluationId, content: runDataContent1);
fields = ParseClientResult(run1, ["id", "status"]);
string run1Id = fields["id"];
Console.WriteLine($"Evaluation run 1 created (id: {run1Id})");

// Create evaluation run 2 (treatment)
object dataSource2 = new
{
    type = "jsonl",
    source = new
    {
        type = "file_content",
        content = new[]
        {
            new { item = new { query = "The weather is nice today." } },
            new { item = new { query = "This is the worst movie ever." } },
        }
    }
};
BinaryData runData2 = BinaryData.FromObjectAsJson(
    new { name = "Evaluation Run 2", data_source = dataSource2 }
);
using BinaryContent runDataContent2 = BinaryContent.Create(runData2);
ClientResult run2 = evaluationClient.CreateEvaluationRun(evaluationId: evaluationId, content: runDataContent2);
fields = ParseClientResult(run2, ["id", "status"]);
string run2Id = fields["id"];
Console.WriteLine($"Evaluation run 2 created (id: {run2Id})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateTwoRuns_EvaluationCompareInsight_Async
// Create evaluation run 1 (baseline)
object dataSource1 = new
{
    type = "jsonl",
    source = new
    {
        type = "file_content",
        content = new[]
        {
            new { item = new { query = "I love programming!" } },
            new { item = new { query = "I hate bugs." } },
        }
    }
};
BinaryData runData1 = BinaryData.FromObjectAsJson(
    new { name = "Evaluation Run 1", data_source = dataSource1 }
);
using BinaryContent runDataContent1 = BinaryContent.Create(runData1);
ClientResult run1 = await evaluationClient.CreateEvaluationRunAsync(evaluationId: evaluationId, content: runDataContent1);
fields = ParseClientResult(run1, ["id", "status"]);
string run1Id = fields["id"];
Console.WriteLine($"Evaluation run 1 created (id: {run1Id})");

// Create evaluation run 2 (treatment)
object dataSource2 = new
{
    type = "jsonl",
    source = new
    {
        type = "file_content",
        content = new[]
        {
            new { item = new { query = "The weather is nice today." } },
            new { item = new { query = "This is the worst movie ever." } },
        }
    }
};
BinaryData runData2 = BinaryData.FromObjectAsJson(
    new { name = "Evaluation Run 2", data_source = dataSource2 }
);
using BinaryContent runDataContent2 = BinaryContent.Create(runData2);
ClientResult run2 = await evaluationClient.CreateEvaluationRunAsync(evaluationId: evaluationId, content: runDataContent2);
fields = ParseClientResult(run2, ["id", "status"]);
string run2Id = fields["id"];
Console.WriteLine($"Evaluation run 2 created (id: {run2Id})");
```

7. Wait for both evaluation runs to complete.

Synchronous sample:
```C# Snippet:Sample_WaitForRuns_EvaluationCompareInsight_Sync
// Wait for both runs to complete
Dictionary<string, string> runStatuses = new()
{
    { run1Id, ParseClientResult(run1, ["status"])["status"] },
    { run2Id, ParseClientResult(run2, ["status"])["status"] }
};

while (runStatuses.Values.Any(s => s != "completed" && s != "failed"))
{
    Thread.Sleep(TimeSpan.FromSeconds(5));
    foreach (string runId in runStatuses.Keys.ToList())
    {
        if (runStatuses[runId] != "completed" && runStatuses[runId] != "failed")
        {
            ClientResult run = evaluationClient.GetEvaluationRun(evaluationId: evaluationId, evaluationRunId: runId, options: new());
            runStatuses[runId] = ParseClientResult(run, ["status"])["status"];
        }
    }
    Console.WriteLine($"Waiting for evaluation runs to complete...");
}
if (runStatuses.Values.Any(s => s == "failed"))
{
    ClientResult run = evaluationClient.GetEvaluationRun(evaluationId: evaluationId, evaluationRunId: string.Equals(runStatuses[run1Id], "failed") ? run1Id : run2Id, options: new());
    throw new InvalidOperationException($"Evaluation run failed with error: {GetErrorMessageOrEmpty(run)}");
}
Console.WriteLine("Both evaluation runs completed successfully!");
```

Asynchronous sample:
```C# Snippet:Sample_WaitForRuns_EvaluationCompareInsight_Async
// Wait for both runs to complete
Dictionary<string, string> runStatuses = new()
{
    { run1Id, ParseClientResult(run1, ["status"])["status"] },
    { run2Id, ParseClientResult(run2, ["status"])["status"] }
};

while (runStatuses.Values.Any(s => s != "completed" && s != "failed"))
{
    await Task.Delay(TimeSpan.FromSeconds(5));
    foreach (string runId in runStatuses.Keys.ToList())
    {
        if (runStatuses[runId] != "completed" && runStatuses[runId] != "failed")
        {
            ClientResult run = await evaluationClient.GetEvaluationRunAsync(evaluationId: evaluationId, evaluationRunId: runId, options: new());
            runStatuses[runId] = ParseClientResult(run, ["status"])["status"];
        }
    }
    Console.WriteLine($"Waiting for evaluation runs to complete...");
}
if (runStatuses.Values.Any(s => s == "failed"))
{
    ClientResult run = await evaluationClient.GetEvaluationRunAsync(evaluationId: evaluationId, evaluationRunId: string.Equals(runStatuses[run1Id], "failed") ? run1Id : run2Id, options: new());
    throw new InvalidOperationException($"Evaluation run failed with error: {GetErrorMessageOrEmpty(run)}");
}
Console.WriteLine("Both evaluation runs completed successfully!");
```

8. Generate comparison insights using the `ProjectInsights` client, specifying the baseline run and treatment run(s).

Synchronous sample:
```C# Snippet:Sample_GenerateInsight_EvaluationCompareInsight_Sync
ProjectsInsight compareInsight = projectClient.Insights.Generate(
    insight: new ProjectsInsight(
        displayName: "Comparison of Evaluation Runs",
        request: new EvaluationComparisonInsightRequest(
            evalId: evaluationId,
            baselineRunId: run1Id,
            treatmentRunIds: [run2Id])));
Console.WriteLine($"Started insight generation (id: {compareInsight.Id})");
```

Asynchronous sample:
```C# Snippet:Sample_GenerateInsight_EvaluationCompareInsight_Async
ProjectsInsight compareInsight = await projectClient.Insights.GenerateAsync(
    insight: new ProjectsInsight(
        displayName: "Comparison of Evaluation Runs",
        request: new EvaluationComparisonInsightRequest(
            evalId: evaluationId,
            baselineRunId: run1Id,
            treatmentRunIds: [run2Id])));
Console.WriteLine($"Started insight generation (id: {compareInsight.Id})");
```

9. To parse the comparison results, we will use the `ParseCompareResults` method.

```C# Snippet:Sample_ParseCompareResults_EvaluationCompareInsight
private static void ParseCompareResults(ProjectsInsight compareInsight)
{
    if (compareInsight.State == OperationStatus.Succeeded)
    {
        Console.WriteLine("Evaluation comparison generated successfully!");
        Console.WriteLine($"Insight ID: {compareInsight.Id}");
        Console.WriteLine($"Display Name: {compareInsight.DisplayName}");
        if (compareInsight.Result is EvaluationComparisonInsightResult runResult)
        {
            Console.WriteLine("Comparison results:");
            foreach (EvalRunResultComparison comparison in runResult.Comparisons)
            {
                Console.WriteLine($"    Evaluator name {comparison.EvaluatorName}, Testing criteria {comparison.TestingCriteria}, average metric value {comparison.BaselineRunSummary.Average}, SD: {comparison.BaselineRunSummary.StandardDeviation}.");
                foreach (EvalRunResultCompareItem item in comparison.CompareItems)
                {
                    Console.WriteLine($"        Treatment RunID: \"{item.TreatmentRunId}\", p-value: {item.PValue}, {item.TreatmentEffect}");
                }
            }
        }
        else
        {
            throw new InvalidOperationException($"Evaluation comparison generation has succeeded, but the result of type {compareInsight.Result.GetType()} is unexpected.");
        }
    }
    else
    {
        throw new InvalidOperationException("Evaluation comparison generation failed.");
    }
}
```

10. Wait for the comparison insight generation to complete and display the results.

Synchronous sample:
```C# Snippet:Sample_WaitForInsight_EvaluationCompareInsight_Sync
while (compareInsight.State != OperationStatus.Succeeded && compareInsight.State != OperationStatus.Failed)
{
    Thread.Sleep(TimeSpan.FromSeconds(5));
    compareInsight = projectClient.Insights.Get(id: compareInsight.Id);
    Console.WriteLine($"Insight status: {compareInsight.State}");
}
ParseCompareResults(compareInsight);
```

Asynchronous sample:
```C# Snippet:Sample_WaitForInsight_EvaluationCompareInsight_Async
while (compareInsight.State != OperationStatus.Succeeded && compareInsight.State != OperationStatus.Failed)
{
    await Task.Delay(TimeSpan.FromSeconds(5));
    compareInsight = await projectClient.Insights.GetAsync(id: compareInsight.Id);
    Console.WriteLine($"Insight status: {compareInsight.State}");
}
ParseCompareResults(compareInsight);
```

11. Clean up by deleting the evaluation.

Synchronous sample:
```C# Snippet:Sample_Cleanup_EvaluationCompareInsight_Sync
evaluationClient.DeleteEvaluation(evaluationId, new System.ClientModel.Primitives.RequestOptions());
Console.WriteLine("Evaluation deleted.");
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_EvaluationCompareInsight_Async
await evaluationClient.DeleteEvaluationAsync(evaluationId, new System.ClientModel.Primitives.RequestOptions());
Console.WriteLine("Evaluation deleted.");
```
