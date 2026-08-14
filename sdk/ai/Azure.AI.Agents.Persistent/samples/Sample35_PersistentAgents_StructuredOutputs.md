# Sample for generation of structured output by Agent in Azure.AI.Agents.Persistent.

In this example we will demonstrate generation of structured JSON output from an Agent, compliant with a provided schema.

1. First we need to create agent client and read the environment variables, which will be used in the next steps.

```C# Snippet:StructuredOutputs_CreateAgentClient
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
```

2. Define the schema of Agents expected output.

```C# Snippet:StructuredOutputs_CreateAgent_CreateSchema
private static readonly BinaryData s_calendarSchema = BinaryData.FromObjectAsJson(
new
{
    additionalProperties = false,
    properties = new
    {
        name = new
        {
            title = "Name",
            type = "string"
        },
        date = new
        {
            description = "Date in YYYY-MM-DD format",
            title = "Date",
            type = "string"
        },
        participants = new
        {
            items = new { type = "string" },
            title = "Participants",
            type = "array"
        }
    },
    required = new List<string> { "name", "date", "participants" },
    title = "CalendarEvent",
    type = "object",
});
```

3. Next we will need to create an Agent and provide it with the schema and instruction on how to generate the JSON.

Synchronous sample:
```C# Snippet:StructuredOutputs_CreateAgent_Sync
ResponseFormatJsonSchemaType responseSchemaType = new(
    new ResponseFormatJsonSchema(name: "Calendar", schema: s_calendarSchema)
);
BinaryData responseFormat = ((IJsonModel<ResponseFormatJsonSchemaType>)responseSchemaType).Write(ModelReaderWriterOptions.Json);

// NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
PersistentAgent agent = client.Administration.CreateAgent(
    model: modelDeploymentName,
    name: "Calendar events",
    instructions: "You are a helpful assistant that extracts calendar event information from the input user messages," +
                  "and returns it in the desired structured output format.",
    responseFormat: responseFormat
);
```

Asynchronous sample:
```C# Snippet:StructuredOutputs_CreateAgent_Async
ResponseFormatJsonSchemaType responseSchemaType = new(
    new ResponseFormatJsonSchema(name: "Calendar", schema: s_calendarSchema)
);
BinaryData responseFormat = ((IJsonModel<ResponseFormatJsonSchemaType>)responseSchemaType).Write(ModelReaderWriterOptions.Json);

// NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
PersistentAgent agent = await client.Administration.CreateAgentAsync(
    model: modelDeploymentName,
    name: "Calendar events",
    instructions: "You are a helpful assistant that extracts calendar event information from the input user messages," +
                  "and returns it in the desired structured output format.",
    responseFormat: responseFormat
);
```

4. Create thread as a separate resource.

Synchronous sample:
```C# Snippet:StructuredOutputs_CreateThread_Sync
PersistentAgentThread thread = client.Threads.CreateThread();
```

Asynchronous sample:
```C# Snippet:StructuredOutputs_CreateThread_Async
PersistentAgentThread thread = await client.Threads.CreateThreadAsync();
```

5. Add the message to the thread, containing a question for agent. This message must have `User` role.

Synchronous sample:
```C# Snippet:StructuredOutputs_CreateMessage_Sync
PersistentThreadMessage message = client.Messages.CreateMessage(
    thread.Id,
    MessageRole.User,
    "Alice and Bob are going to a science fair this Friday, November 7, 2025.");
```

Asynchronous sample:
```C# Snippet:StructuredOutputs_CreateMessage_Async
PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "Alice and Bob are going to a science fair this Friday, November 7, 2025.");
```

6. Now we will need to create the run, which will assign agent to the thread.

Synchronous sample:
```C# Snippet:StructuredOutputs_CreateRun_Sync
ThreadRun run = client.Runs.CreateRun(
    thread.Id,
    agent.Id,
    additionalInstructions: "Please address the user as Jane Doe. The user has a premium account.");
```

Asynchronous sample:
```C# Snippet:StructuredOutputs_CreateRun_Async
ThreadRun run = await client.Runs.CreateRunAsync(
    thread.Id,
    agent.Id,
    additionalInstructions: "Please address the user as Jane Doe. The user has a premium account.");
```

7. It may take some time to get the response from agent, so we will wait, when it will get to the terminal state. If the run is not successful, we will raise the assertion error with the last error message.

Synchronous sample:
```C# Snippet:StructuredOutputs_WaitForRun_Sync
do
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    run = client.Runs.GetRun(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress);
Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```

Asynchronous sample:
```C# Snippet:StructuredOutputs_WaitForRun_Async
do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    run = await client.Runs.GetRunAsync(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress);
Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```

8. Print the agent's messages to console in chronological order.

Synchronous sample:
```C# Snippet:StructuredOutputs_ListUpdatedMessages_Sync
Pageable<PersistentThreadMessage> messages
    = client.Messages.GetMessages(
        threadId: thread.Id, order: ListSortOrder.Ascending);

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
```C# Snippet:StructuredOutputs_ListUpdatedMessages_Async
AsyncPageable<PersistentThreadMessage> messages
    = client.Messages.GetMessagesAsync(
        threadId: thread.Id, order: ListSortOrder.Ascending);

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

9. Clean up resources by deleting thread and agent.

Synchronous sample:
```C# Snippet:StructuredOutputs_Cleanup_Sync
// NOTE: Comment out these two lines if you plan to reuse the agent later.
client.Threads.DeleteThread(threadId: thread.Id);
client.Administration.DeleteAgent(agentId: agent.Id);
```

Asynchronous sample:
```C# Snippet:StructuredOutputs_Cleanup_Async
// NOTE: Comment out these two lines if you plan to reuse the agent later.
await client.Threads.DeleteThreadAsync(threadId: thread.Id);
await client.Administration.DeleteAgentAsync(agentId: agent.Id);
```
