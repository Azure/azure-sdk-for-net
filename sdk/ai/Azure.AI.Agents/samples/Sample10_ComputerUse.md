# Sample for use of an agent with Computer Use tool in Azure.AI.Agents.

To enable your Agent to Computer Use tool, you need to use `ComputerTool` while creating `PromptAgentDefinition`.
1. First, we need to create an Agent client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClient_ComputerUse
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("COMPUTER_USE_DEPLOYMENT_NAME");
AgentsClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
OpenAIClient openAIClient = client.GetOpenAIClient();
```

2. To use the tool, we need to upload the files. To get the files from sources directory `GetFile` method will be used.

Synchronous sample:
```C# Snippet:Sample_GetFile_ComputerUse
private static string GetFile(string name, [CallerFilePath] string pth = "")
{
    var dirName = Path.GetDirectoryName(pth) ?? "";
    return Path.Combine(dirName, name);
}
```

3. To get file IDs we will upload files using `OpenAIFileClient` `UploadFile` and `UploadFileAsync` methods for synchronous and asynchronous sample respectively.

Synchronous sample:
```C# Snippet:Sample_UploadFiles_ComputerUse_Sync
OpenAIFileClient fileClient = openAIClient.GetOpenAIFileClient();
Dictionary<string, string> screenshots = new() {
    { "browser_search", fileClient.UploadFile(GetFile("Assets/cua_browser_search.png"), FileUploadPurpose.Assistants).Value.Id },
    { "search_typed", fileClient.UploadFile(GetFile("Assets/cua_search_typed.png"), FileUploadPurpose.Assistants).Value.Id },
    { "search_results", fileClient.UploadFile(GetFile("Assets/cua_search_results.png"), FileUploadPurpose.Assistants).Value.Id },
};
```

Asynchronous sample:
```C# Snippet:Sample_UploadFiles_ComputerUse_Async
OpenAIFileClient fileClient = openAIClient.GetOpenAIFileClient();
Dictionary<string, string> screenshots = new() {
    { "browser_search", (await fileClient.UploadFileAsync(GetFile("Assets/cua_browser_search.png"), FileUploadPurpose.Assistants)).Value.Id },
    { "search_typed", (await fileClient.UploadFileAsync(GetFile("Assets/cua_search_typed.png"), FileUploadPurpose.Assistants)).Value.Id },
    { "search_results", (await fileClient.UploadFileAsync(GetFile("Assets/cua_search_results.png"), FileUploadPurpose.Assistants)).Value.Id },
};
```

4. Create a `PromptAgentDefinition` with `ComputerTool`.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_ComputerUse_Sync
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a computer automation assistant.\n\n" +
                   "Be direct and efficient. When you reach the search results page, read and describe the actual search result titles and descriptions you can see.",
    Tools = {
        ResponseTool.CreateComputerTool(
            environment: new ComputerToolEnvironment("windows"),
            displayWidth: 1026,
            displayHeight: 769
        ),
    }
};
AgentVersion agentVersion = client.CreateAgentVersion(
    agentName: "myAgent",
    definition: agentDefinition,
    options: null);
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_ComputerUse_Async
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a computer automation assistant.\n\n" +
                   "Be direct and efficient. When you reach the search results page, read and describe the actual search result titles and descriptions you can see.",
    Tools = {
        ResponseTool.CreateComputerTool(
            environment: new ComputerToolEnvironment("windows"),
            displayWidth: 1026,
            displayHeight: 769
        ),
    }
};
AgentVersion agentVersion = await client.CreateAgentVersionAsync(
    agentName: "myAgent",
    definition: agentDefinition,
    options: null);
```

4. Create a helper method to parse the ComputerTool outputs and to respond to Agents queries with new screenshots.

```C# Snippet:Sample_ProcessComputerUseCall_ComputerUse
private static ComputerCallOutputResponseItem ProcessComputerUseCall(ComputerCallResponseItem item, IReadOnlyDictionary<string, string> screenshots)
{
    string currentScreenshot = screenshots["browser_search"];
    switch (item.Action.Kind)
    {
        case ComputerCallActionKind.Type:
            Console.WriteLine($"  Typing text\"{item.Action.TypeText}\" - Simulating keyboard input");
            currentScreenshot = screenshots["search_typed"];
            break;
        case ComputerCallActionKind.KeyPress:
            HashSet<string> codes = [.. item.Action.KeyPressKeyCodes];
            if (codes.Contains("Return") || codes.Contains("ENTER"))
            {
                Console.WriteLine("  -> Detected ENTER key press");
                currentScreenshot = screenshots["search_results"];
            }
            else
            {
                Console.WriteLine($"  Key press: {item.Action.KeyPressKeyCodes.Aggregate("", (agg, next) => agg + "+" + next)} - Simulating key combination");
            }
            break;
        case ComputerCallActionKind.Click:
            Console.WriteLine($"  Click at ({item.Action.ClickCoordinates.Value.X}, {item.Action.ClickCoordinates.Value.Y}) - Simulating click on UI element");
            currentScreenshot = screenshots["search_results"];
            break;
        case ComputerCallActionKind.Drag:
            string pathStr = item.Action.DragPath.ToArray().Select(p => $"{p.X}, {p.Y}").Aggregate("", (agg, next) => $"{agg} -> {next}");
            Console.WriteLine($"  Drag path: {pathStr} - Simulating drag operation");
            break;
        case ComputerCallActionKind.Scroll:
            Console.WriteLine($"  Scroll at ({item.Action.ScrollCoordinates.Value.X}, {item.Action.ScrollCoordinates.Value.Y}) - Simulating scroll action");
            break;
        case ComputerCallActionKind.Screenshot:
            Console.WriteLine("  Taking screenshot - Capturing current screen state");
            break;
        default:
            break;
    }
    Console.WriteLine($"  -> Action processed: {item.Action.Kind}");

    return ResponseItem.CreateComputerCallOutputItem(callId: item.CallId, output: ComputerCallOutput.CreateScreenshotOutput(screenshotImageFileId: screenshots["browser_search"]));
}
```

5. For brevity create the methods to wait for response to be returned.

Synchronous sample:
```C# Snippet:Sample_WaitForResponse_ComputerUse_Sync
public static OpenAIResponse CreateAndWaitForResponse(OpenAIResponseClient responseClient, IEnumerable<ResponseItem> items, ResponseCreationOptions options)
{
    OpenAIResponse response = responseClient.CreateResponse(
        inputItems: items,
        options: options);
    while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed)
    {
        Thread.Sleep(TimeSpan.FromMilliseconds(500));
        response = responseClient.GetResponse(responseId: response.Id);
    }
    Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
    return response;
}
```

Asynchronous sample:
```C# Snippet:Sample_WaitForResponse_ComputerUse_Async
public static async Task<OpenAIResponse> CreateAndWaitForResponseAsync(OpenAIResponseClient responseClient, IEnumerable<ResponseItem> items, ResponseCreationOptions options)
{
    OpenAIResponse response = await responseClient.CreateResponseAsync(
        inputItems: items,
        options: options);
    while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(500));
        response = await responseClient.GetResponseAsync(responseId: response.Id);
    }
    Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
    return response;
}
```

6. Create an `OpenAIResponse` using `ResponseItem`, containing two `ResponseContentPart`: one with the image and another with the text. In the loop we will request Agent while it is continuing to browse web. Finally, print the tool output message.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_ComputerUse_Sync
OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(modelDeploymentName);
ResponseCreationOptions responseOptions = new();
responseOptions.SetAgentReference(new AgentReference(name: agentVersion.Name));
responseOptions.TruncationMode = ResponseTruncationMode.Auto;
ResponseItem request = ResponseItem.CreateUserMessageItem(
    [
        ResponseContentPart.CreateInputTextPart("I need you to help me search for 'OpenAI news'. Please type 'OpenAI news' and submit the search. Once you see search results, the task is complete."),
        ResponseContentPart.CreateInputImagePart(imageFileId: screenshots["browser_search"], imageDetailLevel: ResponseImageDetailLevel.High)
    ]
);
List<ResponseItem> inputItems = [request];
bool computerUseCalled = false;
int limitIteration = 10;
OpenAIResponse response;
do
{
    response = CreateAndWaitForResponse(
        responseClient,
        inputItems,
        responseOptions);
    computerUseCalled = false;
    foreach (ResponseItem responseItem in response.OutputItems)
    {
        inputItems.Add(responseItem);
        if (responseItem is ComputerCallResponseItem computerCall)
        {
            inputItems.Add(ProcessComputerUseCall(computerCall, screenshots));
            computerUseCalled = true;
        }
    }
    limitIteration--;
} while (computerUseCalled && limitIteration > 0);
Console.WriteLine(response.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_ComputerUse_Async
OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(modelDeploymentName);
ResponseCreationOptions responseOptions = new();
responseOptions.SetAgentReference(new AgentReference(name: agentVersion.Name));
responseOptions.TruncationMode = ResponseTruncationMode.Auto;
ResponseItem request = ResponseItem.CreateUserMessageItem(
    [
        ResponseContentPart.CreateInputTextPart("I need you to help me search for 'OpenAI news'. Please type 'OpenAI news' and submit the search. Once you see search results, the task is complete."),
        ResponseContentPart.CreateInputImagePart(imageFileId: screenshots["browser_search"], imageDetailLevel: ResponseImageDetailLevel.High)
    ]
);
List<ResponseItem> inputItems = [request];
bool computerUseCalled = false;
int limitIteration = 10;
OpenAIResponse response;
do
{
    response = await CreateAndWaitForResponseAsync(
        responseClient,
        inputItems,
        responseOptions);
    computerUseCalled = false;
    foreach (ResponseItem responseItem in response.OutputItems)
    {
        inputItems.Add(responseItem);
        if (responseItem is ComputerCallResponseItem computerCall)
        {
            inputItems.Add(ProcessComputerUseCall(computerCall, screenshots));
            computerUseCalled = true;
        }
    }
    limitIteration--;
} while (computerUseCalled && limitIteration > 0);
Console.WriteLine(response.GetOutputText());
```

7. Clean up resources by deleting Agent and uploaded files.

Synchronous sample:
```C# Snippet:Sample_Cleanup_ComputerUse_Sync
screenshots.Values.Select(id => fileClient.DeleteFile(id));
client.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_ComputerUse_Async
screenshots.Values.Select(async id => await fileClient.DeleteFileAsync(id));
await client.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```
