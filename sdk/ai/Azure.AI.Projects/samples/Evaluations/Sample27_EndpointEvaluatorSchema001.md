# Sample of using an endpoint-based evaluator with legacy schema 0.0.1 in Azure.AI.Projects.

**Legacy schema 0.0.1:** This sample is for endpoints that already implement this contract. `0.0.1` is also what the service uses when `SchemaVersion` is not set. For new evaluators, use schema version `0.0.2` instead, as shown in [Sample26_EndpointEvaluator](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Projects/samples/Evaluations/Sample26_EndpointEvaluator.md).

**Note:** Endpoint-based evaluators are an experimental feature. To use them, disable the `AAIP001` warning.

```C#
#pragma warning disable AAIP001
```

An endpoint-based evaluator lets you bring your own HTTP scoring endpoint. The service POSTs each evaluation row to your endpoint and expects a JSON response with a score and optional reasoning. The evaluator references an existing project connection by name; the connection's target is the endpoint URL and it stores the credentials (API key or Microsoft Entra ID). See [Sample26_EndpointEvaluator](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Projects/samples/Evaluations/Sample26_EndpointEvaluator.md) for how each authentication type is configured. The identity running the sample needs the **Foundry User** role on the project.

An evaluator version keeps the schema version it was created with, so this sample uses a separate evaluator name from the `0.0.2` sample.

Your endpoint must accept POST requests with a JSON body like:

```json
{
  "schema_version": "0.0.1",
  "evaluator_name": "...",
  "evaluator_version": "...",
  "evaluation_level": "turn",
  "data": {
    "item": {"query": "...", "context": "..."},
    "sample": {"response": "..."}
  }
}
```

The endpoint must return a JSON response like:

```json
{
  "schema_version": "0.0.1",
  "score": 4,
  "reason": "Response is accurate and concise.",
  "status": "Completed",
  "properties": {"model_used": "gpt-4o", "custom_flag": true},
  "threshold": null,
  "passed": true
}
```

`status` is one of `Completed`, `Error` or `Skipped`.

1. First, we need to create project client and read the environment variables which will be used in the next steps. `ENDPOINT_CONNECTION_NAME` is the name of the existing project connection to your scoring endpoint. We will also create an `EvaluationClient` for creating and running evaluations.

```C# Snippet:Sample_CreateClients_EndpointEvaluatorSchema001
var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var connectionName = System.Environment.GetEnvironmentVariable("ENDPOINT_CONNECTION_NAME");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
EvaluationClient evaluationClient = projectClient.ProjectOpenAIClient.GetEvaluationClient();
```

2. Define the `EvaluatorVersion` object. The `EndpointBasedEvaluatorDefinition` references the project connection, sets the schema version to `0.0.1` and defines an ordinal `score` metric from 1 to 5.

```C# Snippet:Sample_EvaluatorVersion_EndpointEvaluatorSchema001
private static EvaluatorVersion GetEndpointEvaluatorVersion(string connectionName)
{
    EndpointBasedEvaluatorDefinition definition = new(connectionName)
    {
        // 0.0.1 is also the service default when SchemaVersion is not set.
        SchemaVersion = EndpointEvaluatorSchemaVersion.V001,
        Metrics =
        {
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
        DisplayName = "Endpoint Evaluator (Schema 0.0.1)",
        Description = "Custom scoring endpoint",
    };
}
```

3. Register the evaluator in the project.

Synchronous sample:
```C# Snippet:Sample_CreateEvaluator_EndpointEvaluatorSchema001_Sync
EvaluatorVersion evaluator = projectClient.Evaluators.CreateVersion(
    name: "myEndpointEvaluatorSchema001",
    evaluatorVersion: GetEndpointEvaluatorVersion(connectionName)
);
Console.WriteLine($"Created evaluator: name={evaluator.Name}, version={evaluator.Version}");
```

Asynchronous sample:
```C# Snippet:Sample_CreateEvaluator_EndpointEvaluatorSchema001_Async
EvaluatorVersion evaluator = await projectClient.Evaluators.CreateVersionAsync(
    name: "myEndpointEvaluatorSchema001",
    evaluatorVersion: GetEndpointEvaluatorVersion(connectionName)
);
Console.WriteLine($"Created evaluator: name={evaluator.Name}, version={evaluator.Version}");
```

4. Define the evaluation. The testing criteria reference the evaluator we have created and map data set fields to the evaluator inputs. `dataSourceConfig` defines the data set schema.

```C# Snippet:Sample_CreateEvaluationData_EndpointEvaluatorSchema001
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
            name = "endpoint-evaluator-v001-test",
            data_source_config = dataSourceConfig,
            testing_criteria = testingCriteria
        }
    );
}
```

5. Create the evaluation. The helper methods `ParseClientResult`, `GetErrorMessageOrEmpty`, `GetResultsCounts` and `GetResultsList` are described in [Sample3_EvaluationsCatalogPromptBased](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Projects/samples/Evaluations/Sample3_EvaluationsCatalogPromptBased.md).

Synchronous sample:
```C# Snippet:Sample_CreateEvaluationObject_EndpointEvaluatorSchema001_Sync
using BinaryContent evaluationDataContent = BinaryContent.Create(GetEvaluationData(evaluator.Name));
ClientResult evaluation = evaluationClient.CreateEvaluation(evaluationDataContent);
Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
string evaluationId = fields["id"];
Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {fields["name"]})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateEvaluationObject_EndpointEvaluatorSchema001_Async
using BinaryContent evaluationDataContent = BinaryContent.Create(GetEvaluationData(evaluator.Name));
ClientResult evaluation = await evaluationClient.CreateEvaluationAsync(evaluationDataContent);
Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
string evaluationId = fields["id"];
Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {fields["name"]})");
```

6. Define the evaluation run data. It contains the inline data set we will send to the endpoint.

```C# Snippet:Sample_CreateRunData_EndpointEvaluatorSchema001
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
            name = "endpoint-v001-run",
            data_source = dataSource,
        }
    );
}
```

7. Create the evaluation run and extract its ID and status.

Synchronous sample:
```C# Snippet:Sample_CreateRun_EndpointEvaluatorSchema001_Sync
using BinaryContent runDataContent = BinaryContent.Create(GetRunData());
ClientResult run = evaluationClient.CreateEvaluationRun(evaluationId: evaluationId, content: runDataContent);
fields = ParseClientResult(run, ["id", "status"]);
string runId = fields["id"];
string runStatus = fields["status"];
Console.WriteLine($"Evaluation run created (id: {runId})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateRun_EndpointEvaluatorSchema001_Async
using BinaryContent runDataContent = BinaryContent.Create(GetRunData());
ClientResult run = await evaluationClient.CreateEvaluationRunAsync(evaluationId: evaluationId, content: runDataContent);
fields = ParseClientResult(run, ["id", "status"]);
string runId = fields["id"];
string runStatus = fields["status"];
Console.WriteLine($"Evaluation run created (id: {runId})");
```

8. Wait for the evaluation run to arrive at the terminal state.

Synchronous sample:
```C# Snippet:Sample_WaitForRun_EndpointEvaluatorSchema001_Sync
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
```C# Snippet:Sample_WaitForRun_EndpointEvaluatorSchema001_Async
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

9. Output the results.

Synchronous sample:
```C# Snippet:Sample_ParseResults_EndpointEvaluatorSchema001_Sync
Console.WriteLine($"Result Counts: {GetResultsCounts(run)}");
List<string> evaluationResults = GetResultsList(client: evaluationClient, evaluationId: evaluationId, evaluationRunId: runId);
Console.WriteLine($"OUTPUT ITEMS (Total: {evaluationResults.Count})");
foreach (string result in evaluationResults)
{
    Console.WriteLine(result);
}
```

Asynchronous sample:
```C# Snippet:Sample_ParseResults_EndpointEvaluatorSchema001_Async
Console.WriteLine($"Result Counts: {GetResultsCounts(run)}");
List<string> evaluationResults = await GetResultsListAsync(client: evaluationClient, evaluationId: evaluationId, evaluationRunId: runId);
Console.WriteLine($"OUTPUT ITEMS (Total: {evaluationResults.Count})");
foreach (string result in evaluationResults)
{
    Console.WriteLine(result);
}
```

10. Finally, delete the evaluation and evaluator we have created in this sample.

Synchronous sample:
```C# Snippet:Sample_Cleanup_EndpointEvaluatorSchema001_Sync
try
{
    evaluationClient.DeleteEvaluation(evaluationId, new System.ClientModel.Primitives.RequestOptions());
}
finally
{
    projectClient.Evaluators.DeleteVersion(name: evaluator.Name, version: evaluator.Version);
}
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_EndpointEvaluatorSchema001_Async
try
{
    await evaluationClient.DeleteEvaluationAsync(evaluationId, new System.ClientModel.Primitives.RequestOptions());
}
finally
{
    await projectClient.Evaluators.DeleteVersionAsync(name: evaluator.Name, version: evaluator.Version);
}
```
