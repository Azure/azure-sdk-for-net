# Sample of using an endpoint-based evaluator in Azure.AI.Projects.

**Note:** Endpoint-based evaluators are an experimental feature. To use them, disable the `AAIP001` warning.

```C#
#pragma warning disable AAIP001
```

An endpoint-based evaluator lets you bring your own HTTP scoring endpoint. The service POSTs each evaluation row to your endpoint and expects a JSON response with a score and optional reasoning. The evaluator references an existing project connection by name. The connection's target is the endpoint URL, and the service resolves the URL and credentials from it at evaluation time, so the same code works with API key or Microsoft Entra ID authentication:

- **API key:** the connection stores the endpoint's API key, and the service sends it in the `api-key` header.
- **Microsoft Entra ID:** the connection's `Audience` metadata is `api://<app-id>`, where `<app-id>` is the Application (client) ID of the App Registration protecting the endpoint. The service sends a managed identity token as a Bearer token. Your endpoint must validate it (for example, with Azure App Service Easy Auth), and the evaluation service's managed identity must be allowed to call the endpoint (for example, added to `allowedClientApplications` in the Easy Auth configuration).

The identity running the sample needs the **Foundry User** role on the project.

This sample uses endpoint contract schema version `0.0.2`, which is recommended for new evaluators. With `0.0.2`, the evaluator must define exactly one metric, of type ordinal or continuous. For endpoints that still implement schema `0.0.1`, see [Sample27_EndpointEvaluatorSchema001](./Sample27_EndpointEvaluatorSchema001.md).

Your endpoint must accept POST requests with a JSON body like:

```json
{
  "schema_version": "0.0.2",
  "evaluator_name": "...",
  "evaluator_version": "...",
  "evaluation_target": {"type": "last_turn", "response_start_index": 1},
  "context": {"query": "...", "response": "...", "context": "..."},
  "messages": [
    {"role": "user", "content": [{"type": "text", "text": "..."}]},
    {"role": "assistant", "content": [{"type": "text", "text": "..."}]}
  ],
  "agent_definition": {"tool_definitions": []},
  "metadata": {"run_type": "dataset"}
}
```

The messages from `response_start_index` onward are the response to score. For conversation-level evaluators, `evaluation_target` is `{"type": "conversation"}`.

The endpoint must return a JSON response like:

```json
{
  "status": "completed",
  "score": 4,
  "passed": true,
  "reason": "Response is accurate and concise.",
  "properties": {"model_used": "gpt-4o"}
}
```

`status` is one of `completed`, `error` or `skipped`. `score` (within the metric's range) and `passed` are required when the status is `completed`; omit them when the status is `error` or `skipped`. Unknown fields are rejected.

1. First, we need to create project client and read the environment variables which will be used in the next steps. `ENDPOINT_CONNECTION_NAME` is the name of the existing project connection to your scoring endpoint. We will also create an `EvaluationClient` for creating and running evaluations.

```C# Snippet:Sample_CreateClients_EndpointEvaluator
var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var connectionName = System.Environment.GetEnvironmentVariable("ENDPOINT_CONNECTION_NAME");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
EvaluationClient evaluationClient = projectClient.ProjectOpenAIClient.GetEvaluationClient();
```

2. Define the `EvaluatorVersion` object. The `EndpointBasedEvaluatorDefinition` references the project connection, sets the schema version to `0.0.2` and defines a single ordinal `score` metric from 1 to 5.

```C# Snippet:Sample_EvaluatorVersion_EndpointEvaluator
private static EvaluatorVersion GetEndpointEvaluatorVersion(string connectionName)
{
    EndpointBasedEvaluatorDefinition definition = new(connectionName)
    {
        SchemaVersion = EndpointEvaluatorSchemaVersion.V002,
        Metrics =
        {
            // Schema 0.0.2 requires exactly one ordinal or continuous metric.
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
        DisplayName = "Endpoint Evaluator",
        Description = "Custom scoring endpoint",
    };
}
```

3. Register the evaluator in the project.

Synchronous sample:
```C# Snippet:Sample_CreateEvaluator_EndpointEvaluator_Sync
EvaluatorVersion evaluator = projectClient.Evaluators.CreateVersion(
    name: "myEndpointEvaluator",
    evaluatorVersion: GetEndpointEvaluatorVersion(connectionName)
);
Console.WriteLine($"Created evaluator: name={evaluator.Name}, version={evaluator.Version}");
```

Asynchronous sample:
```C# Snippet:Sample_CreateEvaluator_EndpointEvaluator_Async
EvaluatorVersion evaluator = await projectClient.Evaluators.CreateVersionAsync(
    name: "myEndpointEvaluator",
    evaluatorVersion: GetEndpointEvaluatorVersion(connectionName)
);
Console.WriteLine($"Created evaluator: name={evaluator.Name}, version={evaluator.Version}");
```

4. Define the evaluation. The testing criteria reference the evaluator we have created and map data set fields to the evaluator inputs. `dataSourceConfig` defines the data set schema.

```C# Snippet:Sample_CreateEvaluationData_EndpointEvaluator
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
            name = "endpoint-evaluator-test",
            data_source_config = dataSourceConfig,
            testing_criteria = testingCriteria
        }
    );
}
```

5. Create the evaluation. The `EvaluationClient` uses protocol methods, so we use the `ParseClientResult` helper to read the evaluation name and ID. The helper methods `ParseClientResult`, `GetErrorMessageOrEmpty`, `GetResultsCounts` and `GetResultsList` are described in [Sample3_EvaluationsCatalogPromptBased](./Sample3_EvaluationsCatalogPromptBased.md).

Synchronous sample:
```C# Snippet:Sample_CreateEvaluationObject_EndpointEvaluator_Sync
using BinaryContent evaluationDataContent = BinaryContent.Create(GetEvaluationData(evaluator.Name));
ClientResult evaluation = evaluationClient.CreateEvaluation(evaluationDataContent);
Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
string evaluationId = fields["id"];
Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {fields["name"]})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateEvaluationObject_EndpointEvaluator_Async
using BinaryContent evaluationDataContent = BinaryContent.Create(GetEvaluationData(evaluator.Name));
ClientResult evaluation = await evaluationClient.CreateEvaluationAsync(evaluationDataContent);
Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
string evaluationId = fields["id"];
Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {fields["name"]})");
```

6. Define the evaluation run data. It contains the inline data set we will send to the endpoint.

```C# Snippet:Sample_CreateRunData_EndpointEvaluator
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
            name = "endpoint-evaluator-run",
            data_source = dataSource,
        }
    );
}
```

7. Create the evaluation run and extract its ID and status.

Synchronous sample:
```C# Snippet:Sample_CreateRun_EndpointEvaluator_Sync
using BinaryContent runDataContent = BinaryContent.Create(GetRunData());
ClientResult run = evaluationClient.CreateEvaluationRun(evaluationId: evaluationId, content: runDataContent);
fields = ParseClientResult(run, ["id", "status"]);
string runId = fields["id"];
string runStatus = fields["status"];
Console.WriteLine($"Evaluation run created (id: {runId})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateRun_EndpointEvaluator_Async
using BinaryContent runDataContent = BinaryContent.Create(GetRunData());
ClientResult run = await evaluationClient.CreateEvaluationRunAsync(evaluationId: evaluationId, content: runDataContent);
fields = ParseClientResult(run, ["id", "status"]);
string runId = fields["id"];
string runStatus = fields["status"];
Console.WriteLine($"Evaluation run created (id: {runId})");
```

8. Wait for the evaluation run to arrive at the terminal state.

Synchronous sample:
```C# Snippet:Sample_WaitForRun_EndpointEvaluator_Sync
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
```C# Snippet:Sample_WaitForRun_EndpointEvaluator_Async
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
```C# Snippet:Sample_ParseResults_EndpointEvaluator_Sync
Console.WriteLine($"Result Counts: {GetResultsCounts(run)}");
List<string> evaluationResults = GetResultsList(client: evaluationClient, evaluationId: evaluationId, evaluationRunId: runId);
Console.WriteLine($"OUTPUT ITEMS (Total: {evaluationResults.Count})");
foreach (string result in evaluationResults)
{
    Console.WriteLine(result);
}
```

Asynchronous sample:
```C# Snippet:Sample_ParseResults_EndpointEvaluator_Async
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
```C# Snippet:Sample_Cleanup_EndpointEvaluator_Sync
evaluationClient.DeleteEvaluation(evaluationId, new System.ClientModel.Primitives.RequestOptions());
projectClient.Evaluators.DeleteVersion(name: evaluator.Name, version: evaluator.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_EndpointEvaluator_Async
await evaluationClient.DeleteEvaluationAsync(evaluationId, new System.ClientModel.Primitives.RequestOptions());
await projectClient.Evaluators.DeleteVersionAsync(name: evaluator.Name, version: evaluator.Version);
```
