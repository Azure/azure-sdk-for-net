# Sample for use of an assistant with Bing grounding in Azure.AI.Assistants.

To enable your Assistant to perform search through Bing search API, you use `BingGroundingToolDefinition` along with a connection.
1. First we need to create an assistant and read the environment variables, which will be used in the next steps.

```C# Snippet:AssistantsBingGrounding_CreateProject
var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var connectionId = System.Environment.GetEnvironmentVariable("AZURE_BING_CONECTION_ID");
AssistantsClient assistantClient = new(connectionString, new DefaultAzureCredential());
```

2. We will use the Bing connection ID to initialize the `BingGroundingToolDefinition`.

Synchronous sample:
```C# Snippet:AssistantsBingGrounding_GetConnection
ToolConnectionList connectionList = new()
{
    ConnectionList = { new ToolConnection(connectionId) }
};
BingGroundingToolDefinition bingGroundingTool = new(connectionList);
```

Asynchronous sample:
```C# Snippet:AssistantsBingGroundingAsync_GetConnection
ToolConnectionList connectionList = new()
{
    ConnectionList = { new ToolConnection(connectionId) }
};
BingGroundingToolDefinition bingGroundingTool = new(connectionList);
```

3. We will use the `BingGroundingToolDefinition` during the assistant initialization.

Synchronous sample:
```C# Snippet:AssistantsBingGrounding_CreateAgent
Assistant assistant = assistantClient.CreateAssistant(
   model: modelDeploymentName,
   name: "my-assistant",
   instructions: "You are a helpful assistant.",
   tools: [bingGroundingTool]);
```

Asynchronous sample:
```C# Snippet:AssistantsBingGroundingAsync_CreateAgent
Assistant assistant = await assistantClient.CreateAssistantAsync(
   model: modelDeploymentName,
   name: "my-assistant",
   instructions: "You are a helpful assistant.",
   tools: [ bingGroundingTool ]);
```

4. Now we will create the thread, add the message , containing a question for assistant and start the run.

Synchronous sample:
```C# Snippet:AssistantsBingGrounding_CreateThreadMessage
AssistantThread thread = assistantClient.CreateThread();

// Create message to thread
ThreadMessage message = assistantClient.CreateMessage(
    thread.Id,
    MessageRole.User,
    "How does wikipedia explain Euler's Identity?");

// Run the assistant
ThreadRun run = assistantClient.CreateRun(thread, assistant);
do
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    run = assistantClient.GetRun(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress);

Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```

Asynchronous sample:
```C# Snippet:AssistantsBingGroundingAsync_CreateThreadMessage
AssistantThread thread = await assistantClient.CreateThreadAsync();

// Create message to thread
ThreadMessage message = await assistantClient.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "How does wikipedia explain Euler's Identity?");

// Run the assistant
ThreadRun run = await assistantClient.CreateRunAsync(thread, assistant);
do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    run = await assistantClient.GetRunAsync(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress);

Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```

5. Print the assistant messages to console in chronological order.

Synchronous sample:
```C# Snippet:AssistantsBingGrounding_Print
PageableList<ThreadMessage> messages = assistantClient.GetMessages(
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
            string response = textItem.Text;
            if (textItem.Annotations != null)
            {
                foreach (MessageTextAnnotation annotation in textItem.Annotations)
                {
                    if (annotation is MessageTextUrlCitationAnnotation urlAnnotation)
                    {
                        response = response.Replace(urlAnnotation.Text, $" [{urlAnnotation.UrlCitation.Title}]({urlAnnotation.UrlCitation.Url})");
                    }
                }
            }
            Console.Write($"Assistant response: {response}");
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
```C# Snippet:AssistantsBingGroundingAsync_Print
PageableList<ThreadMessage> messages = await assistantClient.GetMessagesAsync(
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
            string response = textItem.Text;
            if (textItem.Annotations != null)
            {
                foreach (MessageTextAnnotation annotation in textItem.Annotations)
                {
                    if (annotation is MessageTextUrlCitationAnnotation urlAnnotation)
                    {
                        response = response.Replace(urlAnnotation.Text, $" [{urlAnnotation.UrlCitation.Title}]({urlAnnotation.UrlCitation.Url})");
                    }
                }
            }
            Console.Write($"Assistant response: {response}");
        }
        else if (contentItem is MessageImageFileContent imageFileItem)
        {
            Console.Write($"<image from ID: {imageFileItem.FileId}");
        }
        Console.WriteLine();
    }
}
```

6. Clean up resources by deleting thread and assistant.

Synchronous sample:
```C# Snippet:AssistantsBingGroundingCleanup
assistantClient.DeleteThread(threadId: thread.Id);
assistantClient.DeleteAssistant(assistantId: assistant.Id);
```

Asynchronous sample:
```C# Snippet:AssistantsBingGroundingCleanupAsync
await assistantClient.DeleteThreadAsync(threadId: thread.Id);
await assistantClient.DeleteAssistantAsync(assistantId: assistant.Id);
```
