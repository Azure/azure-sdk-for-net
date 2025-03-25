# Sample enterprise file search on agent with message attachment and code interpreter in Azure.AI.Projects.

In this example we demonstrate, how the Azure Blob can be utilized for enterprize file search with `MessageAttachment`.

1. First we need to create agent client and read the environment variables, which will be used in the next steps.
```C# Snippet:CodeInterpreterEnterpriseSearch_CreateClient
var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var blobURI = Environment.GetEnvironmentVariable("AZURE_BLOB_URI");
AgentsClient client = new(connectionString, new DefaultAzureCredential());
```
2. Create agent.

Synchronous sample:
```C# Snippet:CodeInterpreterEnterpriseSearch_CreateAgent
List<ToolDefinition> tools = [new CodeInterpreterToolDefinition()];
Agent agent = client.CreateAgent(
    model: modelDeploymentName,
    name: "my-assistant",
    instructions: "You are helpful assistant.",
    tools: tools
);
```

Asynchronous sample:
```C# Snippet:CodeInterpreterEnterpriseSearchAsync_CreateAgent
List<ToolDefinition> tools = [ new CodeInterpreterToolDefinition() ];
Agent agent = await client.CreateAgentAsync(
    model: modelDeploymentName,
    name: "my-assistant",
    instructions: "You are helpful assistant.",
    tools: tools
);
```

3. Create `VectorStoreDataSource`, which will contain the link to Azure Asset ID of our Blob.
```C# Snippet:CreateMessageAttachmentWithBlobStore
var ds = new VectorStoreDataSource(
    assetIdentifier: blobURI,
    assetType: VectorStoreDataSourceAssetType.UriAsset
);

var attachment = new MessageAttachment(
    ds: ds,
    tools: tools
);
```

4. Create a `ThreadMessage`, which contains the `VectorStoreDataSource` as an attachment.

Synchronous sample:
```C# Snippet:CodeInterpreterEnterpriseSearch_CreateThreadRun
AgentThread thread = client.CreateThread();

ThreadMessage message = client.CreateMessage(
    threadId: thread.Id,
    role: MessageRole.User,
    content: "What does the attachment say?",
    attachments: [attachment]
);

ThreadRun run = client.CreateRun(
    thread.Id,
    agent.Id
);
do
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    run = client.GetRun(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress);
Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```

Asynchronous sample:
```C# Snippet:CodeInterpreterEnterpriseSearchAsync_CreateThreadRun
AgentThread thread = await client.CreateThreadAsync();

ThreadMessage message = await client.CreateMessageAsync(
    threadId: thread.Id,
    role: MessageRole.User,
    content: "What does the attachment say?",
    attachments: [ attachment ]
);

ThreadRun run = await client.CreateRunAsync(
    thread.Id,
    agent.Id
);
do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    run = await client.GetRunAsync(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress);
Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```

5. Create the utility function, to print messages to the console.
```C# Snippet:CodeInterpreterEnterpriseSearch_Print
private static void WriteMessages(IEnumerable<ThreadMessage> messages)
{
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
}
```

6. Wait when the run is completed.

Synchronous sample:
```C# Snippet:CodeInterpreterEnterpriseSearch_CreateThreadRun
AgentThread thread = client.CreateThread();

ThreadMessage message = client.CreateMessage(
    threadId: thread.Id,
    role: MessageRole.User,
    content: "What does the attachment say?",
    attachments: [attachment]
);

ThreadRun run = client.CreateRun(
    thread.Id,
    agent.Id
);
do
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    run = client.GetRun(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress);
Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```

Asynchronous sample:
```C# Snippet:CodeInterpreterEnterpriseSearchAsync_CreateThreadRun
AgentThread thread = await client.CreateThreadAsync();

ThreadMessage message = await client.CreateMessageAsync(
    threadId: thread.Id,
    role: MessageRole.User,
    content: "What does the attachment say?",
    attachments: [ attachment ]
);

ThreadRun run = await client.CreateRunAsync(
    thread.Id,
    agent.Id
);
do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    run = await client.GetRunAsync(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress);
Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```

7. Print the messages to the console in chronological order.

Synchronous sample:
```C# Snippet:CodeInterpreterEnterpriseSearch_PrintMessages
PageableList<ThreadMessage> messages = client.GetMessages(
    threadId: thread.Id,
    order: ListSortOrder.Ascending
);
WriteMessages(messages);
```

Asynchronous sample:
```C# Snippet:CodeInterpreterEnterpriseSearchAsync_PrintMessages
PageableList<ThreadMessage> messages = await client.GetMessagesAsync(
    threadId: thread.Id,
    order: ListSortOrder.Ascending
);
WriteMessages(messages);
```


8. Finally, we delete all the resources, we have created in this sample.

Synchronous sample:
```C# Snippet:CodeInterpreterEnterpriseSearch_Cleanup
client.DeleteThread(thread.Id);
client.DeleteAgent(agent.Id);
```

Asynchronous sample:
```C# Snippet:CodeInterpreterEnterpriseSearchAsync_Cleanup
await client.DeleteThreadAsync(thread.Id);
await client.DeleteAgentAsync(agent.Id);
```
