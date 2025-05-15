# Sample using agents with Image Fileas an input in Azure.AI.Agents.Persistent.

Demonstrates examples of sending an image file (along with optional text) as a structured content block in a single message. The examples shows how to create an agent, open a thread, post content blocks combining text and image inputs, and then run the agent to see how it interprets the multimedia input.

1. First we need to create an agent client and read the environment variables, which will be used in the next steps.

```C# Snippet:AgentsImageFileInMessageCreateClient
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var filePath = GetFile();
// 1) Create an PersistentAgentsClient for agent-management and messaging.
PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
```

2. (Optional) Upload a file for referencing in your message:

Synchronous sample:
```C# Snippet:AgentsImageFileInMessageUpload_Sync
string pathToImage = Path.Combine(
    TestContext.CurrentContext.TestDirectory,
    filePath
);

// The file might be an image or any relevant binary.
// Make sure the server or container is set up for "Agents" usage if required.
PersistentAgentFileInfo uploadedFile = client.Files.UploadFile(
    filePath: pathToImage,
    purpose: PersistentAgentFilePurpose.Agents
);
Console.WriteLine($"Uploaded file with ID: {uploadedFile.Id}");
```

Asynchronous sample:
```C# Snippet:AgentsImageFileInMessageUpload
string pathToImage = Path.Combine(
        TestContext.CurrentContext.TestDirectory,
        filePath
    );

// The file might be an image or any relevant binary.
// Make sure the server or container is set up for "Agents" usage if required.
PersistentAgentFileInfo uploadedFile = await client.Files.UploadFileAsync(
    filePath: pathToImage,
    purpose: PersistentAgentFilePurpose.Agents
);
Console.WriteLine($"Uploaded file with ID: {uploadedFile.Id}");
```

3. Create an agent.

Synchronous sample:
```C# Snippet:AgentsImageFileInMessageCreateAgent_Sync
PersistentAgent agent = client.Administration.CreateAgent(
    model: modelDeploymentName,
    name: "File Image Understanding Agent",
    instructions: "Analyze images from internally uploaded files."
);
```

Asynchronous sample:
```C# Snippet:AgentsImageFileInMessageCreateAgent
PersistentAgent agent = await client.Administration.CreateAgentAsync(
    model: modelDeploymentName,
    name: "File Image Understanding Agent",
    instructions: "Analyze images from internally uploaded files."
);
```

4. Create a thread.

Synchronous sample:
```C# Snippet:AgentsImageFileInMessageCreateThread_Sync
PersistentAgentThread thread = client.Threads.CreateThread();
```

Asynchronous sample:
```C# Snippet:AgentsImageFileInMessageCreateThread
PersistentAgentThread thread = await client.Threads.CreateThreadAsync();
```

5. Create a message referencing the uploaded file.

Synchronous sample:
```C# Snippet:AgentsImageFileInMessageCreateMessage_Sync
var contentBlocks = new List<MessageInputContentBlock>
{
    new MessageInputTextBlock("Here is an uploaded file. Please describe it:"),
    new MessageInputImageFileBlock(new MessageImageFileParam(uploadedFile.Id))
};

PersistentThreadMessage imageMessage = client.Messages.CreateMessage(
    threadId: thread.Id,
    role: MessageRole.User,
    contentBlocks: contentBlocks
);
```

Asynchronous sample:
```C# Snippet:AgentsImageFileInMessageCreateMessage
var contentBlocks = new List<MessageInputContentBlock>
{
    new MessageInputTextBlock("Here is an uploaded file. Please describe it:"),
    new MessageInputImageFileBlock(new MessageImageFileParam(uploadedFile.Id))
};

PersistentThreadMessage imageMessage = await client.Messages.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    contentBlocks: contentBlocks
);
```

6. Run the agent.

Synchronous sample:
```C# Snippet:AgentsImageFileInMessageCreateRun_Sync
ThreadRun run = client.Runs.CreateRun(
    threadId: thread.Id,
    assistantId: agent.Id
);
```

Asynchronous sample:
```C# Snippet:AgentsImageFileInMessageCreateRun
ThreadRun run = await client.Runs.CreateRunAsync(
    threadId: thread.Id,
    assistantId: agent.Id
);
```

7. Wait for the run to complete.

Synchronous sample:
```C# Snippet:AgentsImageFileInMessageWaitForRun_Sync
do
{
    Thread.Sleep(500);
    run = client.Runs.GetRun(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued || run.Status == RunStatus.InProgress);

if (run.Status != RunStatus.Completed)
{
    throw new InvalidOperationException($"Run failed or was canceled: {run.LastError?.Message}");
}
```

Asynchronous sample:
```C# Snippet:AgentsImageFileInMessageWaitForRun
do
{
    await Task.Delay(500);
    run = await client.Runs.GetRunAsync(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued || run.Status == RunStatus.InProgress);

if (run.Status != RunStatus.Completed)
{
    throw new InvalidOperationException($"Run failed or was canceled: {run.LastError?.Message}");
}
```

8. Retrieve messages (including any agent responses) and print them.

Synchronous sample:
```C# Snippet:AgentsImageFileInMessageReview_Sync
Pageable<PersistentThreadMessage> messages = client.Messages.GetMessages(thread.Id);

foreach (PersistentThreadMessage msg in messages)
{
    Console.WriteLine($"{msg.CreatedAt:yyyy-MM-dd HH:mm:ss} - {msg.Role,10}:");

    foreach (MessageContent content in msg.ContentItems)
    {
        switch (content)
        {
            case MessageTextContent textItem:
                Console.WriteLine($"  Text: {textItem.Text}");
                break;

            case MessageImageFileContent fileItem:
                Console.WriteLine($"  Image File (internal ID): {fileItem.FileId}");
                break;
        }
    }
}
```

Asynchronous sample:
```C# Snippet:AgentsImageFileInMessageReview
AsyncPageable<PersistentThreadMessage> messages = client.Messages.GetMessagesAsync(thread.Id);

await foreach (PersistentThreadMessage msg in messages)
{
    Console.WriteLine($"{msg.CreatedAt:yyyy-MM-dd HH:mm:ss} - {msg.Role,10}:");

    foreach (MessageContent content in msg.ContentItems)
    {
        switch (content)
        {
            case MessageTextContent textItem:
                Console.WriteLine($"  Text: {textItem.Text}");
                break;

            case MessageImageFileContent fileItem:
                Console.WriteLine($"  Image File (internal ID): {fileItem.FileId}");
                break;
        }
    }
}
```

9. Finally, we delete all the resources, we have created in this sample.

Synchronous sample:
```C# Snippet:AgentsImageFileInMessageCleanup_Sync
client.Threads.DeleteThread(thread.Id);
client.Administration.DeleteAgent(agent.Id);
```

Asynchronous sample:
```C# Snippet:AgentsImageFileInMessageCleanup
await client.Threads.DeleteThreadAsync(thread.Id);
await client.Administration.DeleteAgentAsync(agent.Id);
```