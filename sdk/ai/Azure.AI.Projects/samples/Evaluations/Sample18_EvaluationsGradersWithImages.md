# Sample: Evaluations with Graders and Images in Azure.AI.Projects

This sample demonstrates how to use graders with images.

1. First, create the project client and obtain an `EvaluationClient` for creating and running evaluations.

```C# Snippet:Sample_CreateClients_EvaluationsGradersWithImages
var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
EvaluationClient evaluationClient = projectClient.ProjectOpenAIClient.GetEvaluationClient();
```

2. In the testing criteria define one grader, which will evaluate how well the image matches caption.

```C# Snippet:Sample_CreateData_EvaluationsGradersWithImages
private static BinaryData GetDatasetConfig(string modelDeploymentName)
{
    object[] testingCriteria = [
        new {
            type = "score_model",
            name = "score_grader",
            model = modelDeploymentName,
            input = new object[] {
                new { role = "system", content = "You are an expert grader. Judge how well the model response {{sample.output_text}} describes the image as well as matches the caption {{item.caption}}. Output a score of 1 if it's an excellent match with both. If it's somewhat compatible, output a score around 0.5. Otherwise, give a score of 0." },
                new {
                    role = "user",
                    content = new
                    {
                        type = "input_image",
                        image_url = "{{item.image_url}}",
                        detail = "auto"
                    }
                }
            },
            range = new float[] { 0.0f, 1.0f },
            pass_threshold = 0.5f
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
                image_url = new { type = "string", description = "The URL of the image to be evaluated." },
                caption = new { type = "string", description = "The caption describing the image." },
            },
            required = new string[] { "image_url", "caption" }
        },
        include_sample_schema = true
    };
    return BinaryData.FromObjectAsJson(
        new
        {
            name = "OpenAI graders test",
            data_source_config = dataSourceConfig,
            testing_criteria = testingCriteria
        }
    );
}
```

3. Create the evaluation with the defined graders and data source configuration.

Synchronous sample:
```C# Snippet:Sample_CreateEvaluation_EvaluationsGradersWithImages_Sync
using BinaryContent evaluationDataContent = BinaryContent.Create(GetDatasetConfig(modelDeploymentName));
ClientResult evaluation = evaluationClient.CreateEvaluation(evaluationDataContent);
Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
string evaluationName = fields["name"];
string evaluationId = fields["id"];
Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateEvaluation_EvaluationsGradersWithImages_Async
using BinaryContent evaluationDataContent = BinaryContent.Create(GetDatasetConfig(modelDeploymentName));
ClientResult evaluation = await evaluationClient.CreateEvaluationAsync(evaluationDataContent);
Dictionary<string, string> fields = ParseClientResult(evaluation, ["name", "id"]);
string evaluationName = fields["name"];
string evaluationId = fields["id"];
Console.WriteLine($"Evaluation created (id: {evaluationId}, name: {evaluationName})");
```

4. Define the utility method to get the image and encode it as `base64` Uri.

```C# Snippet:Sample_ImageToUri_EvaluationsGradersWithImages
private static string GetImageDataAsUri(string fileName, [CallerFilePath] string pth = "")
{
    var dirName = Path.GetDirectoryName(pth) ?? "";
    byte[] imageData = File.ReadAllBytes(Path.Combine([dirName, fileName]));
    return $"data:image/png;base64,{Convert.ToBase64String(imageData)}";
}
```

5. Create the inline data source, containing two images and their captions. We provide the model to be graded and the prompt for image description generation.

```C# Snippet:Sample_CreateRunDataSource_EvaluationsGradersWithImages
public static BinaryData GetData(string evaluationId, string modelDeploymentName, string filePath)
{
    object input_messages = new
    {
        type = "template",
        template = new object[]
        {
            new
            {
                type = "message",
                role = "system",
                content = "You are an assistant that analyzes images and provides captions that accurately describe the content of the image."
            },
            new
            {
                type = "message",
                role = "user",
                content = new
                {
                    type = "input_image",
                    image_url = "{{item.image_url}}",
                    detail = "auto",
                }
            }
        }
    };
    string imageUrl = filePath.StartsWith("data") ? GetImageDataAsUri(fileName: filePath) : GetImageDataAsUri(fileName: Path.GetFileName(filePath), pth: filePath.Substring(0, filePath.Length - Path.GetFileName(filePath).Length));
    object dataSource = new
    {
        type = "completions",
        source = new
        {
            type = "file_content",
            content = new object[] {
                new
                {
                    item = new
                    {
                        image_url = imageUrl,
                        caption = "industrial plants in the distance at night",
                    }
                },
                new
                {
                    item = new
                    {
                        image_url = "https://ep1.pinkbike.org/p4pb6973204/p4pb6973204.jpg",
                        caption = "all shots by person and rider shots can be found on his website.",
                    }
                },
            }
        },
        model = modelDeploymentName,
        input_messages = input_messages,
        sampling_params = new
        {
            temperature = 0.8f
        },
    };
    return BinaryData.FromObjectAsJson(
        new
        {
            eval_id = evaluationId,
            name = "Eval",
            metadata = new { team = "eval-exp", scenario = "notifications-v1" },
            data_source = dataSource
        }
    );
}
```

6. Define helper method for parsing results from the protocol-based API responses.

```C# Snippet:Sample_GetStringValues_EvaluationsGradersWithImages
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

7. Define the method to extract error messages from failed responses.

```C# Snippet:Sample_GetError_EvaluationsGradersWithImages
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

8. Create the evaluation run using the inline data.

Synchronous sample:
```C# Snippet:Sample_CreateRun_EvaluationsGradersWithImages_Sync
using BinaryContent runDataContent = BinaryContent.Create(GetData(evaluationId, modelDeploymentName, Path.Combine("data", "sample_evaluations_score_model_grader_with_image.jpg")));
ClientResult run = evaluationClient.CreateEvaluationRun(evaluationId: evaluationId, content: runDataContent);
fields = ParseClientResult(run, ["id", "status"]);
string runId = fields["id"];
string runStatus = fields["status"];
Console.WriteLine($"Evaluation run created (id: {runId})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateRun_EvaluationsGradersWithImages_Async
using BinaryContent runDataContent = BinaryContent.Create(GetData(evaluationId, modelDeploymentName, Path.Combine("data", "sample_evaluations_score_model_grader_with_image.jpg")));
ClientResult run = await evaluationClient.CreateEvaluationRunAsync(evaluationId: evaluationId, content: runDataContent);
fields = ParseClientResult(run, ["id", "status"]);
string runId = fields["id"];
string runStatus = fields["status"];
Console.WriteLine($"Evaluation run created (id: {runId})");
```

9. Wait for the evaluation run to reach a terminal state (completed or failed).

Synchronous sample:
```C# Snippet:Sample_WaitForRun_EvaluationsGradersWithImages_Sync
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
```C# Snippet:Sample_WaitForRun_EvaluationsGradersWithImages_Async
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

10. Like the `ParseClientResult` we will define the method, getting the result counts `GetResultsCounts`, which formats the `result_counts` property of the output JSON.

```C# Snippet:Sample_GetResultCounts_EvaluationsGradersWithImages
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

11. To get the results JSON we will define two methods `GetResultsList` and `GetResultsListAsync`, which are iterating over the pages containing results.

Synchronous sample:
```C# Snippet:Sample_GetResultsList_EvaluationsGradersWithImages_Sync
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
```C# Snippet:Sample_GetResultsList_EvaluationsGradersWithImages_Async
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

12. Retrieve and display the evaluation results.

Synchronous sample:
```C# Snippet:Sample_ParseResults_EvaluationsGradersWithImages_Sync
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
```C# Snippet:Sample_ParseResults_EvaluationsGradersWithImages_Async
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

13. Clean up by deleting the evaluation.

Synchronous sample:
```C# Snippet:Sample_Cleanup_EvaluationsGradersWithImages_Sync
evaluationClient.DeleteEvaluation(evaluationId, new System.ClientModel.Primitives.RequestOptions());
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_EvaluationsGradersWithImages_Async
await evaluationClient.DeleteEvaluationAsync(evaluationId, new System.ClientModel.Primitives.RequestOptions());
```
