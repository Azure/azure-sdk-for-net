# Sample for use of an Agent with Computer Use tool in Azure.AI.Extensions.OpenAI.

To enable your Agent to Computer Use tool, you need to use `ComputerTool` while creating `DeclarativeAgentDefinition`.
1. First, we need to create clients and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClient_ComputerUse
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("COMPUTER_USE_DEPLOYMENT_NAME");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
OpenAIFileClient fileClient = projectClient.ProjectOpenAIClient.GetOpenAIFileClient();
```

2. To use the tool, we need to read and upload image files using `UploadImageFile` and `UploadImageFileAsync` methods.

Synchronous sample:
```C# Snippet:Sample_ReadImageFile_ComputerUse_Sync
private static string UploadImageFile(OpenAIFileClient fileClient, string name, [CallerFilePath] string pth = "")
{
    var dirName = Path.GetDirectoryName(pth) ?? "";
    OpenAIFile uploadedFile = fileClient.UploadFile(Path.Combine(dirName, name), FileUploadPurpose.Assistants);
    return uploadedFile.Id;
}
```

Asynchronous sample:
```C# Snippet:Sample_ReadImageFile_ComputerUse_Async
private static async Task<string> UploadImageFileAsync(OpenAIFileClient fileClient, string name, [CallerFilePath] string pth = "")
{
    var dirName = Path.GetDirectoryName(pth) ?? "";
    OpenAIFile uploadedFile = await fileClient.UploadFileAsync(Path.Combine(dirName, name), FileUploadPurpose.Assistants);
    return uploadedFile.Id;
}
```

3. In this example we will read in three example screenshots and place them into a dictionary.

Synchronous sample:
```C# Snippet:Sample_ReadImageFilesToDictionaries_ComputerUse_Sync
Dictionary<string, string> screenshots = new() {
    { "browser_search", UploadImageFile(fileClient, "Assets/cua_browser_search.png")},
    { "search_typed", UploadImageFile(fileClient, "Assets/cua_search_typed.png")},
    { "search_results", UploadImageFile(fileClient, "Assets/cua_search_results.png")},
};
```

Asynchronous sample:
```C# Snippet:Sample_ReadImageFilesToDictionaries_ComputerUse_Async
Dictionary<string, string> screenshots = new() {
    { "browser_search", await UploadImageFileAsync(fileClient, "Assets/cua_browser_search.png")},
    { "search_typed", await UploadImageFileAsync(fileClient, "Assets/cua_search_typed.png")},
    { "search_results", await UploadImageFileAsync(fileClient, "Assets/cua_search_results.png")},
};
```

4. Create a `DeclarativeAgentDefinition` with `ComputerTool`.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_ComputerUse_Sync
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a computer automation assistant.\n\n" +
                   "Be direct and efficient. When you reach the search results page, read and describe the actual search result titles and descriptions you can see.",
    Tools = {
        ModelReaderWriter.Read<ResponseTool>(
            BinaryData.FromBytes("""{"type":"computer"}"""u8.ToArray()),
            ModelReaderWriterOptions.Json,
            OpenAIContext.Default
        )!,
    }
};
ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
    agentName: "myAgent",
    options: new(agentDefinition)
);
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_ComputerUse_Async
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a computer automation assistant.\n\n" +
                   "Be direct and efficient. When you reach the search results page, read and describe the actual search result titles and descriptions you can see.",
    Tools = {
        ModelReaderWriter.Read<ResponseTool>(
            BinaryData.FromBytes("""{"type":"computer"}"""u8.ToArray()),
            ModelReaderWriterOptions.Json,
            OpenAIContext.Default
        )!,
    }
};
ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition)
);
```

4. Create a helper method to parse the ComputerTool outputs and to respond to Agents queries with new screenshots. Please note that throughout this sample we set the media type for image. Agents support `image/jpeg`, `image/png`, `image/gif` and `image/webp` media types.

```C# Snippet:Sample_ProcessComputerUseCall_ComputerUse
private static string ProcessComputerUseCall(ComputerCallResponseItem item, string oldScreenshot)
{
    string currentScreenshot = oldScreenshot;
    List<ComputerCallAction> actions = [];
    if (item.Patch.TryGetJson("$.actions"u8, out ReadOnlyMemory<byte> actionsJson))
    {
        using JsonDocument doc = JsonDocument.Parse(actionsJson);
        foreach (JsonElement element in doc.RootElement.EnumerateArray())
        {
            ComputerCallAction? parsed = ModelReaderWriter.Read<ComputerCallAction>(
                BinaryData.FromString(element.GetRawText()),
                ModelReaderWriterOptions.Json,
                OpenAIContext.Default);
            if (parsed is not null)
            {
                actions.Add(parsed);
            }
        }
    }
    else if (item.Action is not null)
    {
        actions.Add(item.Action);
    }

    foreach (ComputerCallAction action in actions)
    {
        switch (action.Kind)
        {
            case ComputerCallActionKind.Type:
                Console.WriteLine($"  Typing text \"{action.TypeText}\" - Simulating keyboard input");
                currentScreenshot = "search_typed";
                break;
            case ComputerCallActionKind.KeyPress:
                HashSet<string> codes = [.. action.KeyPressKeyCodes];
                if (codes.Contains("Return") || codes.Contains("ENTER"))
                {
                    // If we have typed the value to the search field, go to search results.
                    if (string.Equals(currentScreenshot, "search_typed"))
                    {
                        Console.WriteLine("  -> Detected ENTER key press, when search field was populated, displaying results.");
                        currentScreenshot = "search_results";
                    }
                    else
                    {
                        Console.WriteLine("  -> Detected ENTER key press, on results or unpopulated search, do nothing.");
                    }
                }
                else
                {
                    Console.WriteLine($"  Key press: {action.KeyPressKeyCodes.Aggregate("", (agg, next) => agg + "+" + next)} - Simulating key combination");
                }
                break;
            case ComputerCallActionKind.Click:
                Console.WriteLine($"  Click at ({action.ClickCoordinates.Value.X}, {action.ClickCoordinates.Value.Y}) - Simulating click on UI element");
                if (string.Equals(currentScreenshot, "search_typed"))
                {
                    Console.WriteLine("  -> Assuming click on Search button when search field was populated, displaying results.");
                    currentScreenshot = "search_results";
                }
                else
                {
                    Console.WriteLine("  -> Assuming click on Search on results or when search was not populated, do nothing.");
                }
                break;
            case ComputerCallActionKind.Drag:
                string pathStr = action.DragPath.ToArray().Select(p => $"{p.X}, {p.Y}").Aggregate("", (agg, next) => $"{agg} -> {next}");
                Console.WriteLine($"  Drag path: {pathStr} - Simulating drag operation");
                break;
            case ComputerCallActionKind.Scroll:
                Console.WriteLine($"  Scroll at ({action.ScrollCoordinates.Value.X}, {action.ScrollCoordinates.Value.Y}) - Simulating scroll action");
                break;
            case ComputerCallActionKind.Screenshot:
                Console.WriteLine("  Taking screenshot - Capturing current screen state");
                break;
            default:
                break;
        }
        Console.WriteLine($"  -> Action processed: {action.Kind}");
    }

    return currentScreenshot;
}
```

5. For brevity create the methods to get the response.

Synchronous sample:
```C# Snippet:Sample_CreateNextResponse_ComputerUse_Sync
public static ResponseResult CreateResponse(ResponsesClient responseClient, CreateResponseOptions options)
{
    ResponseResult response = responseClient.CreateResponse(options);
    Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
    return response;
}
```

Asynchronous sample:
```C# Snippet:Sample_CreateNextResponse_ComputerUse_Async
public static async Task<ResponseResult> CreateResponseAsync(ResponsesClient responseClient, CreateResponseOptions options)
{
    ResponseResult response = await responseClient.CreateResponseAsync(options);
    Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
    return response;
}
```

6. Create an `ResponseResult` using `ResponseItem`, containing two `ResponseContentPart`: one with the image and another with the text. In the loop we will request Agent while it is continuing to browse web. Finally, print the tool output message.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_ComputerUse_Sync
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);
CreateResponseOptions responseOptions = new()
{
    TruncationMode = ResponseTruncationMode.Auto,
    InputItems =
    {
        ResponseItem.CreateUserMessageItem(
        [
            ResponseContentPart.CreateInputTextPart("I need you to help me search for 'OpenAI news'. Please type 'OpenAI news' and submit the search. Once you see search results, the task is complete."),
            ResponseContentPart.CreateInputImagePart(imageFileId: screenshots["browser_search"], imageDetailLevel: ResponseImageDetailLevel.High)
        ]),
    },
};
string currentScreenshot = "browser_search";
int limitIteration = 10;
ResponseResult response;
do
{
    response = CreateResponse(responseClient, responseOptions);
    responseOptions.InputItems.Clear();
    responseOptions.PreviousResponseId = response.Id;
    foreach (ResponseItem responseItem in response.OutputItems)
    {
        if (responseItem is ComputerCallResponseItem computerCall)
        {
            currentScreenshot = ProcessComputerUseCall(computerCall, currentScreenshot);
            responseOptions.InputItems.Add(ResponseItem.CreateComputerCallOutputItem(callId: computerCall.CallId, output: ComputerCallOutput.CreateScreenshotOutput(screenshotImageFileId: screenshots[currentScreenshot])));
        }
    }
    limitIteration--;
} while (responseOptions.InputItems.Count > 0 && limitIteration > 0);
Console.WriteLine(response.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_ComputerUse_Async
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);
CreateResponseOptions responseOptions = new()
{
    TruncationMode = ResponseTruncationMode.Auto,
    InputItems =
    {
        ResponseItem.CreateUserMessageItem(
        [
            ResponseContentPart.CreateInputTextPart("I need you to help me search for 'OpenAI news'. Please type 'OpenAI news' and submit the search. Once you see search results, the task is complete."),
            ResponseContentPart.CreateInputImagePart(imageFileId: screenshots["browser_search"], imageDetailLevel: ResponseImageDetailLevel.High)
        ]),
    },
};
string currentScreenshot = "browser_search";
int limitIteration = 10;
ResponseResult response;
do
{
    response = await CreateResponseAsync(
        responseClient,
        responseOptions
    );
    responseOptions.PreviousResponseId = response.Id;
    responseOptions.InputItems.Clear();
    foreach (ResponseItem responseItem in response.OutputItems)
    {
        if (responseItem is ComputerCallResponseItem computerCall)
        {
            currentScreenshot = ProcessComputerUseCall(computerCall, currentScreenshot);
            responseOptions.InputItems.Add(ResponseItem.CreateComputerCallOutputItem(callId: computerCall.CallId, output: ComputerCallOutput.CreateScreenshotOutput(screenshotImageFileId: screenshots[currentScreenshot])));
        }
    }
    limitIteration--;
} while (responseOptions.InputItems.Count > 0 && limitIteration > 0);
Console.WriteLine(response.GetOutputText());
```

7. Clean up resources by deleting Agent and files.

Synchronous sample:
```C# Snippet:Sample_Cleanup_ComputerUse_Sync
projectClient.AgentAdministrationClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
foreach (string fileId in screenshots.Values)
{
    fileClient.DeleteFile(fileId);
}
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_ComputerUse_Async
await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
foreach (string fileId in screenshots.Values)
{
    await fileClient.DeleteFileAsync(fileId);
}
```
