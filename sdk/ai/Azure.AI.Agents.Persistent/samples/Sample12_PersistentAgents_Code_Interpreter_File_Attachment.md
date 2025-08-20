# Sample file search on agent with message attachment and code interpreter in Azure.AI.Agents.Persistent.

In this example we demonstrate, how to use file search with `MessageAttachment`.

1. First we need to create agent client and read the environment variables, which will be used in the next steps.
```C# Snippet:AgentsCodeInterpreterFileAttachment_CreateClient
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
```

2. We need to create an agent, create and upload file and message with the uploaded file ID in the `MessageAttachment`.

Synchronous sample:
```C# Snippet:AgentsCreateAgentWithInterpreterToolSync
List<ToolDefinition> tools = [new CodeInterpreterToolDefinition()];
PersistentAgent agent = client.Administration.CreateAgent(
    model: modelDeploymentName,
    name: "my-agent",
    instructions: "You are a helpful agent that can help fetch data from files you know about.",
    tools: tools
);

System.IO.File.WriteAllText(
    path: "sample_file_for_upload.txt",
    contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
PersistentAgentFileInfo uploadedAgentFile = client.Files.UploadFile(
    filePath: "sample_file_for_upload.txt",
    purpose: PersistentAgentFilePurpose.Agents);
var fileId = uploadedAgentFile.Id;

var attachment = new MessageAttachment(
    fileId: fileId,
    tools: tools
);

PersistentAgentThread thread = client.Threads.CreateThread();

PersistentThreadMessage message = client.Messages.CreateMessage(
    threadId: thread.Id,
    role: MessageRole.User,
    content: "Can you give me the documented codes for 'banana' and 'orange'?",
    attachments: [attachment]
);
```

Asynchronous sample:
```C# Snippet:AgentsCreateAgentWithInterpreterTool
List<ToolDefinition> tools = [ new CodeInterpreterToolDefinition() ];
PersistentAgent agent = await client.Administration.CreateAgentAsync(
    model: modelDeploymentName,
    name: "my-agent",
    instructions: "You are a helpful agent that can help fetch data from files you know about.",
    tools: tools
);

System.IO.File.WriteAllText(
    path: "sample_file_for_upload.txt",
    contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
PersistentAgentFileInfo uploadedAgentFile = await client.Files.UploadFileAsync(
    filePath: "sample_file_for_upload.txt",
    purpose: PersistentAgentFilePurpose.Agents);
var fileId = uploadedAgentFile.Id;

var attachment = new MessageAttachment(
    fileId: fileId,
    tools: tools
);

PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
    threadId: thread.Id,
    role: MessageRole.User,
    content: "Can you give me the documented codes for 'banana' and 'orange'?",
    attachments: [ attachment ]
);
```

3. Next we will create a run and wait until the run is completed. If the run was not successful we will print the last error message.

Synchronous sample:
```C# Snippet:AgentsCodeInterpreterFileAttachmentSync_CreateRun
ThreadRun run = client.Runs.CreateRun(
    thread.Id,
    agent.Id
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
```C# Snippet:AgentsCodeInterpreterFileAttachment_CreateRun
ThreadRun run = await client.Runs.CreateRunAsync(
    thread.Id,
    agent.Id
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

4. In this example we will use the utility function `WriteMessages`, to print messages to the console.
```C# Snippet:AgentsCodeInterpreterFileAttachment_Print
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

5. Print the messages to the console in chronological order.

Synchronous sample:
```C# Snippet:AgentsCodeInterpreterFileAttachmentSync_PrintMessages
Pageable<PersistentThreadMessage> messages = client.Messages.GetMessages(
    threadId: thread.Id,
    order: ListSortOrder.Ascending
);
WriteMessages(messages);
```

Asynchronous sample:
```C# Snippet:AgentsCodeInterpreterFileAttachment_PrintMessages
List<PersistentThreadMessage> messages = await client.Messages.GetMessagesAsync(
    threadId: thread.Id,
    order: ListSortOrder.Ascending
).ToListAsync();
WriteMessages(messages);
```

6. Finally, delete all the resources, we have created in this sample.

Synchronous sample:
```C# Snippet:AgentsCodeInterpreterFileAttachmentSync_Cleanup
client.Threads.DeleteThread(thread.Id);
client.Administration.DeleteAgent(agent.Id);
```

Asynchronous sample:
```C# Snippet:AgentsCodeInterpreterFileAttachment_Cleanup
await client.Threads.DeleteThreadAsync(thread.Id);
await client.Administration.DeleteAgentAsync(agent.Id);
```
