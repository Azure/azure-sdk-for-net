# Sample using agents with OpenAPI tool in Azure.AI.Projects.

In this example we will demonstrate the possibility to use services with [OpenAPI Specification](https://en.wikipedia.org/wiki/OpenAPI_Specification) with the agent. We will use [wttr.in](https://wttr.in) service to get weather and its specification file [weather_openapi.json](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Projects/tests/Samples/Agent/weather_openapi.json). To get this file we will use the utility function `GetFile`, which takes file located in the `C#` source directory.
```C# Snippet:OpenAPICallingExample_GetFile
private static string GetFile([CallerFilePath] string pth = "")
{
    var dirName = Path.GetDirectoryName(pth) ?? "";
    return Path.Combine(dirName, "weather_openapi.json");
}
```

1. First we need to create agent client and read the environment variables, which will be used in the next steps.
```C# Snippet:OpenAPICallingExample_CreateClient
var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AgentsClient client = new(connectionString, new DefaultAzureCredential());
var file_path = GetFile();
```

2. Next we will create the agent with `OpenApiToolDefinition` and anonymous authentication.

Synchronous sample:
```C# Snippet:OpenAPISyncDefineFunctionTools
OpenApiAnonymousAuthDetails oaiAuth = new();
OpenApiToolDefinition openapiTool = new(
    name: "get_weather",
    description: "Retrieve weather information for a location",
    spec: BinaryData.FromBytes(File.ReadAllBytes(file_path)),
    auth: oaiAuth
);

Agent agent = client.CreateAgent(
    model: modelDeploymentName,
    name: "azure-function-agent-foo",
    instructions: "You are a helpful assistant.",
    tools: [openapiTool]
);
```

Asynchronous sample:
```C# Snippet:OpenAPIDefineFunctionTools
OpenApiAnonymousAuthDetails oaiAuth = new();
OpenApiToolDefinition openapiTool = new(
    name: "get_weather",
    description: "Retrieve weather information for a location",
    spec: BinaryData.FromBytes(File.ReadAllBytes(file_path)),
    auth: oaiAuth
);

Agent agent = await client.CreateAgentAsync(
    model: modelDeploymentName,
    name: "azure-function-agent-foo",
    instructions: "You are a helpful assistant.",
    tools: [ openapiTool ]
);
```

3. Now we will create a `ThreadRun` and wait until it is complete. If the run will not be successful, we will print the last error.

Synchronous sample:
```C# Snippet:OpenAPISyncHandlePollingWithRequiredAction
AgentThread thread = client.CreateThread();
ThreadMessage message = client.CreateMessage(
    thread.Id,
    MessageRole.User,
    "What's the weather in Seattle?");

ThreadRun run = client.CreateRun(thread, agent);

do
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    run = client.GetRun(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress
    || run.Status == RunStatus.RequiresAction);
Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```

Asynchronous sample:
```C# Snippet:OpenAPIHandlePollingWithRequiredAction
AgentThread thread = await client.CreateThreadAsync();
ThreadMessage message = await client.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "What's the weather in Seattle?");

ThreadRun run = await client.CreateRunAsync(thread, agent);

do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    run = await client.GetRunAsync(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress
    || run.Status == RunStatus.RequiresAction);
Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```

4. Print the messages to the console in chronological order.

Synchronous sample:
```C# Snippet:OpenAPISync_Print
PageableList<ThreadMessage> messages = client.GetMessages(
    threadId: thread.Id,
    order: ListSortOrder.Ascending
);

foreach (ThreadMessage threadMessage in messages)
{
    Console.Write($"{threadMessage.CreatedAt:yyyy-MM-dd HH:mm:ss} - {threadMessage.Role,10}: ");
    foreach (MessageContent contentItem in threadMessage.ContentItems)
    {
        if (contentItem is MessageTextContent textItem)
        {
            Console.Write(textItem.Text);
        }
        else if (contentItem is MessageImageFileContent imageFileItem)
        {
            Console.Write($"<image from ID: {imageFileItem.FileId}");
        }
        Console.WriteLine();
    }
}
```

Asynchronous sample:
```C# Snippet:OpenAPI_Print
PageableList<ThreadMessage> messages = await client.GetMessagesAsync(
    threadId: thread.Id,
    order: ListSortOrder.Ascending
);

foreach (ThreadMessage threadMessage in messages)
{
    Console.Write($"{threadMessage.CreatedAt:yyyy-MM-dd HH:mm:ss} - {threadMessage.Role,10}: ");
    foreach (MessageContent contentItem in threadMessage.ContentItems)
    {
        if (contentItem is MessageTextContent textItem)
        {
            Console.Write(textItem.Text);
        }
        else if (contentItem is MessageImageFileContent imageFileItem)
        {
            Console.Write($"<image from ID: {imageFileItem.FileId}");
        }
        Console.WriteLine();
    }
}
```

5. Finally, we delete all the resources, we have created in this sample.

Synchronous sample:
```C# Snippet:OpenAPISync_Cleanup
client.DeleteThread(thread.Id);
client.DeleteAgent(agent.Id);
```

Asynchronous sample:
```C# Snippet:OpenAPI_Cleanup
await client.DeleteThreadAsync(thread.Id);
await client.DeleteAgentAsync(agent.Id);
```
