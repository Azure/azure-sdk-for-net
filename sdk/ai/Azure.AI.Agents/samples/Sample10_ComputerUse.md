# Sample for use of an agent with Computer Use tool in Azure.AI.Agents.

To enable your Agent to Computer Use tool, you need to use `ComputerTool` while creating `PromptAgentDefinition`.
1. First, we need to create an Agent client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClient_ComputerUse
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("COMPUTER_USE_DEPLOYMENT_NAME");
AgentClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
OpenAIClient openAIClient = client.GetOpenAIClient();
```

2. To use the tool, we need to read image files using `ReadImageFile` method.

Synchronous sample:
```C# Snippet:Sample_ReadImageFile_ComputerUse
private static BinaryData ReadImageFile(string name, [CallerFilePath] string pth = "")
{
    var dirName = Path.GetDirectoryName(pth) ?? "";
    return new BinaryData(File.ReadAllBytes(Path.Combine(dirName, name)));
}
```

3. In this example we will read in three toy schreenshots and place them into dictionary.

```C# Snippet:Sample_ReadImageFilesToDictionaries_ComputerUse
Dictionary<string, BinaryData> screenshots = new() {
    { "browser_search", ReadImageFile("Assets/cua_browser_search.png")},
    { "search_typed", ReadImageFile("Assets/cua_search_typed.png")},
    { "search_results", ReadImageFile("Assets/cua_search_results.png")},
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
    options: new(agentDefinition)
);
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
    options: new(agentDefinition)
);
```

4. Create a helper method to parse the ComputerTool outputs and to respond to Agents queries with new screenshots. Please note that throughout this sample we set the media type for image. Agents support `image/jpeg`, `image/png`, `image/gif` and `image/webp` media types.

```C# Snippet:Sample_ProcessComputerUseCall_ComputerUse
private static string ProcessComputerUseCall(ComputerCallResponseItem item, string oldScreenshot)
{
    string currentScreenshot = "browser_search";
    switch (item.Action.Kind)
    {
        case ComputerCallActionKind.Type:
            Console.WriteLine($"  Typing text \"{item.Action.TypeText}\" - Simulating keyboard input");
            currentScreenshot = "search_typed";
            break;
        case ComputerCallActionKind.KeyPress:
            HashSet<string> codes = [.. item.Action.KeyPressKeyCodes];
            if (codes.Contains("Return") || codes.Contains("ENTER"))
            {
                // If we have typed the value to the search field, go to search results.
                if (string.Equals(oldScreenshot, "search_typed"))
                {
                    Console.WriteLine("  -> Detected ENTER key press, when search field was populated, displaying results.");
                    currentScreenshot = "search_results";
                }
                else
                {
                    Console.WriteLine("  -> Detected ENTER key press, on results or unpopulated search, do nothing.");
                    currentScreenshot = oldScreenshot;
                }
            }
            else
            {
                Console.WriteLine($"  Key press: {item.Action.KeyPressKeyCodes.Aggregate("", (agg, next) => agg + "+" + next)} - Simulating key combination");
            }
            break;
        case ComputerCallActionKind.Click:
            Console.WriteLine($"  Click at ({item.Action.ClickCoordinates.Value.X}, {item.Action.ClickCoordinates.Value.Y}) - Simulating click on UI element");
            if (string.Equals(oldScreenshot, "search_typed"))
            {
                Console.WriteLine("  -> Assuming click on Search button when search field was populated, displaying results.");
                currentScreenshot = "search_results";
            }
            else
            {
                Console.WriteLine("  -> Assuming click on Search on results or when search was not populated, do nothing.");
                currentScreenshot = oldScreenshot;
            }
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

    return currentScreenshot;
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
string currentScreenshot = "browser_search";
ResponseItem request = ResponseItem.CreateUserMessageItem(
    [
        ResponseContentPart.CreateInputTextPart("I need you to help me search for 'OpenAI news'. Please type 'OpenAI news' and submit the search. Once you see search results, the task is complete."),
        ResponseContentPart.CreateInputImagePart(imageBytes: screenshots["browser_search"], imageBytesMediaType: "image/png", imageDetailLevel: ResponseImageDetailLevel.High)
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
    inputItems.Clear();
    responseOptions.PreviousResponseId = response.Id;
    foreach (ResponseItem responseItem in response.OutputItems)
    {
        inputItems.Add(responseItem);
        if (responseItem is ComputerCallResponseItem computerCall)
        {
            currentScreenshot = ProcessComputerUseCall(computerCall, currentScreenshot);
            inputItems.Add(ResponseItem.CreateComputerCallOutputItem(callId: computerCall.CallId, output: ComputerCallOutput.CreateScreenshotOutput(screenshotImageBytes: screenshots[currentScreenshot], screenshotImageBytesMediaType: "image/png")));
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
        ResponseContentPart.CreateInputImagePart(imageBytes: screenshots["browser_search"], imageBytesMediaType: "image/png", imageDetailLevel: ResponseImageDetailLevel.High)
    ]
);
List<ResponseItem> inputItems = [request];
bool computerUseCalled = false;
string currentScreenshot = "browser_search";
int limitIteration = 10;
OpenAIResponse response;
do
{
    response = await CreateAndWaitForResponseAsync(
        responseClient,
        inputItems,
        responseOptions
    );
    computerUseCalled = false;
    responseOptions.PreviousResponseId = response.Id;
    inputItems.Clear();
    foreach (ResponseItem responseItem in response.OutputItems)
    {
        inputItems.Add(responseItem);
        if (responseItem is ComputerCallResponseItem computerCall)
        {
            currentScreenshot = ProcessComputerUseCall(computerCall, currentScreenshot);
            inputItems.Add(ResponseItem.CreateComputerCallOutputItem(callId: computerCall.CallId, output: ComputerCallOutput.CreateScreenshotOutput(screenshotImageBytes: screenshots[currentScreenshot], screenshotImageBytesMediaType: "image/png")));
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
client.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_ComputerUse_Async
await client.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```
