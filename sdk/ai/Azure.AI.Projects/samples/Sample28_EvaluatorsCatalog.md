# Sample demonstrating CRUD operations on the Evaluators using in Azure.AI.Projects.

In this example we will demonstrate how to create, get, delete, list and update the evaluators.

1. Define two helper methods `GetPromptEvaluatorVersion` and `GetCodeEvaluatorVersion`, returning `EvaluatorVersion` objects for prompt-based and code-based evaluator respectively.

Return prompt-based evaluator:
```C# Snippet:Sampple_PromptEvaluator_EvaluatorsCatalog
private static EvaluatorVersion GetPromptEvaluatorVersion()
{
    EvaluatorMetric metric = new() {
        Type = EvaluatorMetricType.Ordinal,
        DesirableDirection = EvaluatorMetricDirection.Increase,
        MinValue=1,
        MaxValue=5
    };
    return new(
        categories: [EvaluatorCategory.Quality],
        definition: new PromptBasedEvaluatorDefinition(
            promptText: """
                You are an evaluator.
                Rate the GROUNDEDNESS (factual correctness without unsupported claims) of the system response to the customer query.

                Scoring (1–5):
                1 = Mostly fabricated/incorrect
                2 = Many unsupported claims
                3 = Mixed: some facts but notable errors/guesses
                4 = Mostly factual; minor issues
                5 = Fully factual; no unsupported claims

                Return ONLY a single integer 1–5 as score in valid json response e.g {\"score\": int}.

                Query:
                {query}

                Response:
                {response}
                """,
            initParameters: BinaryData.FromObjectAsJson(
                new
                {
                    type = "object",
                    properties = new
                    {
                        deployment_name = new { type = "string" },
                        threshold = new { rtpe = "number" },
                    },
                    required = new[] { "deployment_name", "threshold" }
                }
            ),
            dataSchema: BinaryData.FromObjectAsJson(
                new
                {
                    type = "object",
                    properties = new
                    {
                        query = new { type = "string" },
                        response = new { type = "string" }
                    }
                }
            ),
            metrics: new Dictionary<string, EvaluatorMetric> { { "score", metric } }
        ),
        evaluatorType: EvaluatorType.Custom
    )
    {
        DisplayName = "my_custom_evaluator",
        Description = "Custom evaluator to detect violent content",
    };
}
```

Return code-based evaluator:
```C# Snippet:Sampple_CodeEvaluator_EvaluatorsCatalog
private static EvaluatorVersion GetCodeEvaluatorVersion()
{
    EvaluatorMetric resultMetric = new()
    {
        Type = EvaluatorMetricType.Ordinal,
        DesirableDirection = EvaluatorMetricDirection.Increase,
        MinValue = 0,
        MaxValue = 5
    };
    EvaluatorVersion evaluatorVersion = new(
        categories: [EvaluatorCategory.Quality],
        definition: new CodeBasedEvaluatorDefinition(
            codeText: "def grade(sample, item):\n    return 1.0",
            initParameters: BinaryData.FromObjectAsJson(
                new
                {
                    type = "object",
                    properties = new
                    {
                        deployment_name = new { type = "string" },
                    },
                    required = new[] { "deployment_name" },
                }
            ),
            dataSchema: BinaryData.FromObjectAsJson(
                new
                {
                    type = "object",
                    properties = new
                    {
                        item = new { type = "string" },
                        response = new { type = "string" }
                    },
                    required = new[] { "query", "response" },
                }
            ),
            metrics: new Dictionary<string, EvaluatorMetric> {
                { "result", resultMetric }
            }
        ),
        evaluatorType: EvaluatorType.Custom
    )
    {
        DisplayName = "my_custom_evaluator",
        Description = "Custom evaluator to detect violent content",
    };
    return evaluatorVersion;
}
```

2. Create a helper method to print information about `EvaluatorVersion` object.

```C# Snippet:Sampple_DisplayEvaluator_EvaluatorsCatalog
private static void DisplayEvaluatorVersion(EvaluatorVersion evaluator)
{
    Console.WriteLine($"Evaluator ID: {evaluator.Id}");
    Console.WriteLine($"    Name: {evaluator.Name}");
    Console.WriteLine($"    Version: {evaluator.Version}");
    Console.WriteLine("     Categories:");
    foreach (EvaluatorCategory category in evaluator.Categories)
    {
        Console.WriteLine("         - ${category}");
    }
}
```

3. We need to create project client and read the environment variables which will be used in the next steps.

```C# Snippet:Sampple_CreateClients_EvaluatorsCatalog
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
```

4.  Create prompt-based evaluator in the catalog.

Synchronous sample:
```C# Snippet:Sample_CreatePromptEvaluator_EvaluatorsCatalog_Sync
Console.WriteLine("Creating prompt-based evaluator.");
EvaluatorVersion promptEvaluator = projectClient.Evaluators.CreateVersion(
    name: "myCustomEvaluatorPromptBased",
    evaluatorVersion: GetPromptEvaluatorVersion()
);
DisplayEvaluatorVersion(promptEvaluator);
```

Asynchronous sample:
```C# Snippet:Sample_CreatePromptEvaluator_EvaluatorsCatalog_Async
Console.WriteLine("Creating prompt-based evaluator.");
EvaluatorVersion promptEvaluator = await projectClient.Evaluators.CreateVersionAsync(
    name: "myCustomEvaluatorPromptBased",
    evaluatorVersion: GetPromptEvaluatorVersion()
);
DisplayEvaluatorVersion(promptEvaluator);
```

5. Create code-based evaluator in the catalog.

Synchronous sample:
```C# Snippet:Sample_CreateCodeEvaluator_EvaluatorsCatalog_Sync
Console.WriteLine("Creating code-based evaluator.");
EvaluatorVersion codeEvaluator = projectClient.Evaluators.CreateVersion(
    name: "myCustomEvaluatorCodeBased",
    evaluatorVersion: GetCodeEvaluatorVersion()
);
DisplayEvaluatorVersion(codeEvaluator);
```

Asynchronous sample:
```C# Snippet:Sample_CreateCodeEvaluator_EvaluatorsCatalog_Async
Console.WriteLine("Creating code-based evaluator.");
EvaluatorVersion codeEvaluator = await projectClient.Evaluators.CreateVersionAsync(
    name: "myCustomEvaluatorCodeBased",
    evaluatorVersion: GetCodeEvaluatorVersion()
);
DisplayEvaluatorVersion(codeEvaluator);
```

6. Get code-based agent from catalog.

Synchronous sample:
```C# Snippet:Sample_GetCodeEvaluator_EvaluatorsCatalog_Sync
Console.WriteLine("Get code-based evaluator.");
EvaluatorVersion codeEvaluatorLatest = projectClient.Evaluators.GetVersion(name: codeEvaluator.Name, version: codeEvaluator.Version);
DisplayEvaluatorVersion(codeEvaluatorLatest);
```

Asynchronous sample:
```C# Snippet:Sample_GetCodeEvaluator_EvaluatorsCatalog_Async
Console.WriteLine("Get code-based evaluator.");
EvaluatorVersion codeEvaluatorLatest = await projectClient.Evaluators.GetVersionAsync(name: codeEvaluator.Name, version: codeEvaluator.Version);
DisplayEvaluatorVersion(codeEvaluatorLatest);
```

6. Get prompt-based agent from catalog.

Synchronous sample:
```C# Snippet:Sample_GetPromptEvaluator_EvaluatorsCatalog_Sync
EvaluatorVersion promptEvaluatorLatest = projectClient.Evaluators.GetVersion(name: promptEvaluator.Name, version: promptEvaluator.Version);
DisplayEvaluatorVersion(promptEvaluatorLatest);
```

Asynchronous sample:
```C# Snippet:Sample_GetPromptEvaluator_EvaluatorsCatalog_Async
EvaluatorVersion promptEvaluatorLatest = await projectClient.Evaluators.GetVersionAsync(name: promptEvaluator.Name, version: promptEvaluator.Version);
DisplayEvaluatorVersion(promptEvaluatorLatest);
```

7. Update the code-based evaluator with new category, display name and description.

Synchronous sample:
```C# Snippet:Sample_UpdateEvaluator_EvaluatorsCatalog_Sync
Console.WriteLine("Updating code-based evaluator.");
BinaryData evalustorVersionUpdate = BinaryData.FromObjectAsJson(
    new
    {
        categories = new[] { EvaluatorCategory.Quality.ToString() },
        display_name = "my_custom_evaluator_updated",
        description = "Custom evaluator description changed"
    }
);
using BinaryContent evalustorVersionUpdateContent = BinaryContent.Create(evalustorVersionUpdate);
ClientResult response = projectClient.Evaluators.UpdateVersion(
    name: codeEvaluator.Name,
    version: codeEvaluator.Version,
    content: evalustorVersionUpdateContent
);
EvaluatorVersion updatedEvaluator = ClientResult.FromValue((EvaluatorVersion)response, response.GetRawResponse());
DisplayEvaluatorVersion(updatedEvaluator);
```

Asynchronous sample:
```C# Snippet:Sample_UpdateEvaluator_EvaluatorsCatalog_Async
Console.WriteLine("Updating code-based evaluator.");
BinaryData evalustorVersionUpdate = BinaryData.FromObjectAsJson(
    new
    {
        categories = new[] { EvaluatorCategory.Quality.ToString() },
        display_name = "my_custom_evaluator_updated",
        description = "Custom evaluator description changed"
    }
);
using BinaryContent evalustorVersionUpdateContent = BinaryContent.Create(evalustorVersionUpdate);
ClientResult response = await projectClient.Evaluators.UpdateVersionAsync(
    name: codeEvaluator.Name,
    version: codeEvaluator.Version,
    content: evalustorVersionUpdateContent
);
EvaluatorVersion updatedEvaluator = ClientResult.FromValue((EvaluatorVersion)response, response.GetRawResponse());
DisplayEvaluatorVersion(updatedEvaluator);
```

8. List the built-in evaluators.

Synchronous sample:
```C# Snippet:Sample_ListBuiltInEvaluators_EvaluatorsCatalog_Sync
Console.WriteLine("Listing built-in evaluators.");
foreach (EvaluatorVersion evaluator in projectClient.Evaluators.GetLatestVersions(type: ListVersionsRequestType.BuiltIn))
{
    DisplayEvaluatorVersion(evaluator);
}
```

Asynchronous sample:
```C# Snippet:Sample_ListBuiltInEvaluators_EvaluatorsCatalog_Async
Console.WriteLine("Listing built-in evaluators.");
await foreach (EvaluatorVersion evaluator in projectClient.Evaluators.GetLatestVersionsAsync(type: ListVersionsRequestType.BuiltIn))
{
    DisplayEvaluatorVersion(evaluator);
}
```

9. List custom evaluators, which we have added in the code above.

Synchronous sample:
```C# Snippet:Sample_ListCustomEvaluators_EvaluatorsCatalog_Sync
Console.WriteLine("Listing custom evaluators.");
foreach (EvaluatorVersion evaluator in projectClient.Evaluators.GetLatestVersions(type: ListVersionsRequestType.Custom))
{
    DisplayEvaluatorVersion(evaluator);
}
```

Asynchronous sample:
```C# Snippet:Sample_ListCustomEvaluators_EvaluatorsCatalog_Async
Console.WriteLine("Listing custom evaluators.");
await foreach (EvaluatorVersion evaluator in projectClient.Evaluators.GetLatestVersionsAsync(type: ListVersionsRequestType.Custom))
{
    DisplayEvaluatorVersion(evaluator);
}
```

13. Finally, delete evaluators, we have created in this sample.

Synchronous sample:
```C# Snippet:Sample_Cleanup_EvaluatorsCatalog_Sync
projectClient.Evaluators.DeleteVersion(name: promptEvaluatorLatest.Name, version: promptEvaluatorLatest.Version);
projectClient.Evaluators.DeleteVersion(name: codeEvaluatorLatest.Name, version: codeEvaluatorLatest.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_EvaluatorsCatalog_Async
await projectClient.Evaluators.DeleteVersionAsync(name: promptEvaluatorLatest.Name, version: promptEvaluatorLatest.Version);
await projectClient.Evaluators.DeleteVersionAsync(name: codeEvaluatorLatest.Name, version: codeEvaluatorLatest.Version);
```
