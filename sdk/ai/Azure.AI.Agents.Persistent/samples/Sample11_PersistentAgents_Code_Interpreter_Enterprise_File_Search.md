# Sample enterprise file search on agent with message attachment and code interpreter in Azure.AI.Agents.Persistent.

In this example we demonstrate, how the Azure Blob can be utilized for enterprize file search with `MessageAttachment`.

1. First we need to create agent client and read the environment variables, which will be used in the next steps.
```C# Snippet:AgentsCodeInterpreterEnterpriseSearch_CreateClient
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var blobURI = Environment.GetEnvironmentVariable("AZURE_BLOB_URI");
PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
```
2. Create agent.

Synchronous sample:
```C# Snippet:AgentsCodeInterpreterEnterpriseSearch_CreateAgent
List<ToolDefinition> tools = [new CodeInterpreterToolDefinition()];
// NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
PersistentAgent agent = client.Administration.CreateAgent(
    model: modelDeploymentName,
    name: "my-agent",
    instructions: "You are helpful agent.",
    tools: tools
);
```

Asynchronous sample:
```C# Snippet:AgentsCodeInterpreterEnterpriseSearchAsync_CreateAgent
List<ToolDefinition> tools = [ new CodeInterpreterToolDefinition() ];
// NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
PersistentAgent agent = await client.Administration.CreateAgentAsync(
    model: modelDeploymentName,
    name: "my-agent",
    instructions: "You are helpful agent.",
    tools: tools
);
```

3. Create `VectorStoreDataSource`, which will contain the link to Azure Asset ID of our Blob.
```C# Snippet:AgentsCreateMessageAttachmentWithBlobStore
var ds = new VectorStoreDataSource(
    assetIdentifier: blobURI,
    assetType: VectorStoreDataSourceAssetType.UriAsset
);

var attachment = new MessageAttachment(
    ds: ds,
    tools: tools
);
```

4. Create a message, which contains the `VectorStoreDataSource` as an attachment.

Synchronous sample:
```C# Snippet:AgentsCodeInterpreterEnterpriseSearch_CreateThreadRun
PersistentAgentThread thread = client.Threads.CreateThread();

PersistentThreadMessage message = client.Messages.CreateMessage(
    threadId: thread.Id,
    role: MessageRole.User,
    content: "What does the attachment say?",
    attachments: [attachment]
);

ThreadRun run = client.Runs.CreateRun(
    thread,
    agent
);
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
```C# Snippet:AgentsCodeInterpreterEnterpriseSearchAsync_CreateThreadRun
PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
    threadId: thread.Id,
    role: MessageRole.User,
    content: "What does the attachment say?",
    attachments: [ attachment ]
);

ThreadRun run = await client.Runs.CreateRunAsync(
    thread,
    agent
);
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

5. Create the utility function, to print messages to the console.
```C# Snippet:AgentsCodeInterpreterEnterpriseSearch_Print
private static void WriteMessages(IEnumerable<PersistentThreadMessage> messages)
{
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
}
```

6. Wait when the run is completed.

Synchronous sample:
```C# Snippet:AgentsCodeInterpreterEnterpriseSearch_CreateThreadRun
PersistentAgentThread thread = client.Threads.CreateThread();

PersistentThreadMessage message = client.Messages.CreateMessage(
    threadId: thread.Id,
    role: MessageRole.User,
    content: "What does the attachment say?",
    attachments: [attachment]
);

ThreadRun run = client.Runs.CreateRun(
    thread,
    agent
);
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
```C# Snippet:AgentsCodeInterpreterEnterpriseSearchAsync_CreateThreadRun
PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
    threadId: thread.Id,
    role: MessageRole.User,
    content: "What does the attachment say?",
    attachments: [ attachment ]
);

ThreadRun run = await client.Runs.CreateRunAsync(
    thread,
    agent
);
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

7. Print the messages to the console in chronological order.

Synchronous sample:
```C# Snippet:AgentsCodeInterpreterEnterpriseSearch_PrintMessages
Pageable<PersistentThreadMessage> messages = client.Messages.GetMessages(
    threadId: thread.Id,
    order: ListSortOrder.Ascending
);
WriteMessages(messages);
```

Asynchronous sample:
```C# Snippet:AgentsCodeInterpreterEnterpriseSearchAsync_PrintMessages
List<PersistentThreadMessage> messages = await client.Messages.GetMessagesAsync(
    threadId: thread.Id,
    order: ListSortOrder.Ascending
).ToListAsync();
WriteMessages(messages);
```


8. Finally, delete all the resources, we have created in this sample.

Synchronous sample:
```C# Snippet:AgentsCodeInterpreterEnterpriseSearch_Cleanup
// NOTE: Comment out these two lines if you plan to reuse the agent later.
client.Threads.DeleteThread(thread.Id);
client.Administration.DeleteAgent(agent.Id);
```

Asynchronous sample:
```C# Snippet:AgentsCodeInterpreterEnterpriseSearchAsync_Cleanup
// NOTE: Comment out these two lines if you plan to reuse the agent later.
await client.Threads.DeleteThreadAsync(thread.Id);
await client.Administration.DeleteAgentAsync(agent.Id);
```
