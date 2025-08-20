# Sample using agents with OpenAPI tool in Azure.AI.Agents.Persistent.

In this example we will demonstrate the possibility to use services with [OpenAPI Specification](https://en.wikipedia.org/wiki/OpenAPI_Specification) with the agent. We will use [wttr.in](https://wttr.in) service to get weather and its specification file [weather_openapi.json](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Agents.Persistent/tests/Samples/weather_openapi.json). To get this file we will use the utility function `GetFile`, which takes file located in the `C#` source directory.
```C# Snippet:AgentsOpenAPICallingExample_GetFile
private static string GetFile([CallerFilePath] string pth = "")
{
    var dirName = Path.GetDirectoryName(pth) ?? "";
    return Path.Combine(dirName, "weather_openapi.json");
}
```

1. First we need to create agent client and read the environment variables, which will be used in the next steps.
```C# Snippet:AgentsOpenAPICallingExample_CreateClient
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
var file_path = GetFile();
```

2. Next we will create the agent with `OpenApiToolDefinition` and anonymous authentication.

Synchronous sample:
```C# Snippet:AgentsOpenAPISyncDefineFunctionTools
OpenApiAnonymousAuthDetails oaiAuth = new();
OpenApiToolDefinition openapiTool = new(
    name: "get_weather",
    description: "Retrieve weather information for a location",
    spec: BinaryData.FromBytes(System.IO.File.ReadAllBytes(file_path)),
    openApiAuthentication: oaiAuth,
    defaultParams: ["format"]
);

PersistentAgent agent = client.Administration.CreateAgent(
    model: modelDeploymentName,
    name: "azure-function-agent-foo",
    instructions: "You are a helpful agent.",
    tools: [openapiTool]
);
```

Asynchronous sample:
```C# Snippet:AgentsOpenAPIDefineFunctionTools
OpenApiAnonymousAuthDetails oaiAuth = new();
OpenApiToolDefinition openapiTool = new(
    name: "get_weather",
    description: "Retrieve weather information for a location",
    spec: BinaryData.FromBytes(System.IO.File.ReadAllBytes(file_path)),
    openApiAuthentication: oaiAuth,
    defaultParams: [ "format" ]
);

PersistentAgent agent = await client.Administration.CreateAgentAsync(
    model: modelDeploymentName,
    name: "azure-function-agent-foo",
    instructions: "You are a helpful agent.",
    tools: [ openapiTool ]
);
```

3. Now we will create a run and wait until it is complete. If the run will not be successful, we will print the last error.

Synchronous sample:
```C# Snippet:AgentsOpenAPISyncHandlePollingWithRequiredAction
PersistentAgentThread thread = client.Threads.CreateThread();
PersistentThreadMessage message = client.Messages.CreateMessage(
    thread.Id,
    MessageRole.User,
    "What's the weather in Seattle?");

ThreadRun run = client.Runs.CreateRun(thread, agent);

do
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    run = client.Runs.GetRun(thread.Id, run.Id);
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
```C# Snippet:AgentsOpenAPIHandlePollingWithRequiredAction
PersistentAgentThread thread = await client.Threads.CreateThreadAsync();
PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "What's the weather in Seattle?");

ThreadRun run = await client.Runs.CreateRunAsync(thread, agent);

do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    run = await client.Runs.GetRunAsync(thread.Id, run.Id);
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
```C# Snippet:AgentsOpenAPISync_Print
Pageable<PersistentThreadMessage> messages = client.Messages.GetMessages(
    threadId: thread.Id,
    order: ListSortOrder.Ascending
);

foreach (PersistentThreadMessage threadMessage in messages)
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
```C# Snippet:AgentsOpenAPI_Print
AsyncPageable<PersistentThreadMessage> messages = client.Messages.GetMessagesAsync(
    threadId: thread.Id,
    order: ListSortOrder.Ascending
);

await foreach (PersistentThreadMessage threadMessage in messages)
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

5. Finally, delete all the resources, we have created in this sample.

Synchronous sample:
```C# Snippet:AgentsOpenAPISync_Cleanup
client.Threads.DeleteThread(thread.Id);
client.Administration.DeleteAgent(agent.Id);
```

Asynchronous sample:
```C# Snippet:AgentsOpenAPI_Cleanup
await client.Threads.DeleteThreadAsync(thread.Id);
await client.Administration.DeleteAgentAsync(agent.Id);
```
