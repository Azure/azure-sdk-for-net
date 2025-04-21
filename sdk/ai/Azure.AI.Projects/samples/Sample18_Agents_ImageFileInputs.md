# Sample using agents with Image File as an input.

Demonstrates examples of sending an image file (along with optional text) as a structured content block in a single message. The examples shows how to create an agent, open a thread, post content blocks combining text and image inputs, and then run the agent to see how it interprets the multimedia input.

1. (Optional) Upload a file for referencing in your message:

Synchronous sample:
```C# Snippet:ImageFileInMessageUpload_Sync
string pathToImage = Path.Combine(
    TestContext.CurrentContext.TestDirectory,
    "Samples/Agent/image_file.png"
);

// The file might be an image or any relevant binary.
// Make sure the server or container is set up for "Agents" usage if required.
AgentFile uploadedFile = client.UploadFile(
    filePath: pathToImage,
    purpose: AgentFilePurpose.Agents
);
Console.WriteLine($"Uploaded file with ID: {uploadedFile.Id}");
```

Asynchronous sample:
```C# Snippet:ImageFileInMessageUpload
string pathToImage = Path.Combine(
        TestContext.CurrentContext.TestDirectory,
        "Samples/Agent/image_file.png"
    );

// The file might be an image or any relevant binary.
// Make sure the server or container is set up for "Agents" usage if required.
AgentFile uploadedFile = await client.UploadFileAsync(
    filePath: pathToImage,
    purpose: AgentFilePurpose.Agents
);
Console.WriteLine($"Uploaded file with ID: {uploadedFile.Id}");
```

2. Create an agent.

Synchronous sample:
```C# Snippet:ImageFileInMessageCreateAgent_Sync
Agent agent = client.CreateAgent(
    model: modelDeploymentName,
    name: "File Image Understanding Agent",
    instructions: "Analyze images from internally uploaded files."
);
```

Asynchronous sample:
```C# Snippet:ImageFileInMessageCreateAgent
Agent agent = await client.CreateAgentAsync(
    model: modelDeploymentName,
    name: "File Image Understanding Agent",
    instructions: "Analyze images from internally uploaded files."
);
```

3. Create a thread.

Synchronous sample:
```C# Snippet:ImageFileInMessageCreateThread_Sync
AgentThread thread = client.CreateThread();
```

Asynchronous sample:
```C# Snippet:ImageFileInMessageCreateThread
AgentThread thread = await client.CreateThreadAsync();
```

4. Create a message referencing the uploaded file.

Synchronous sample:
```C# Snippet:ImageFileInMessageCreateMessage_Sync
var contentBlocks = new List<MessageInputContentBlock>
{
    new MessageInputTextBlock("Here is an uploaded file. Please describe it:"),
    new MessageInputImageFileBlock(new MessageImageFileParam(uploadedFile.Id))
};

ThreadMessage imageMessage = client.CreateMessage(
    threadId: thread.Id,
    role: MessageRole.User,
    contentBlocks: contentBlocks
);
```

Asynchronous sample:
```C# Snippet:ImageFileInMessageCreateMessage
var contentBlocks = new List<MessageInputContentBlock>
{
    new MessageInputTextBlock("Here is an uploaded file. Please describe it:"),
    new MessageInputImageFileBlock(new MessageImageFileParam(uploadedFile.Id))
};

ThreadMessage imageMessage = await client.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    contentBlocks: contentBlocks
);
```

5. Run the agent.

Synchronous sample:
```C# Snippet:ImageFileInMessageCreateRun_Sync
ThreadRun run = client.CreateRun(
    threadId: thread.Id,
    assistantId: agent.Id
);
```

Asynchronous sample:
```C# Snippet:ImageFileInMessageCreateRun
ThreadRun run = await client.CreateRunAsync(
    threadId: thread.Id,
    assistantId: agent.Id
);
```

6. Wait for the run to complete.

Synchronous sample:
```C# Snippet:ImageFileInMessageWaitForRun_Sync
do
{
    Thread.Sleep(500);
    run = client.GetRun(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued || run.Status == RunStatus.InProgress);

if (run.Status != RunStatus.Completed)
{
    throw new InvalidOperationException($"Run failed or was canceled: {run.LastError?.Message}");
}
```

Asynchronous sample:
```C# Snippet:ImageFileInMessageWaitForRun
do
{
    await Task.Delay(500);
    run = await client.GetRunAsync(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued || run.Status == RunStatus.InProgress);

if (run.Status != RunStatus.Completed)
{
    throw new InvalidOperationException($"Run failed or was canceled: {run.LastError?.Message}");
}
```

7. Retrieve messages (including any agent responses) and print them.

Synchronous sample:
```C# Snippet:ImageFileInMessageReview_Sync
PageableList<ThreadMessage> messages = client.GetMessages(thread.Id);

foreach (ThreadMessage msg in messages)
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
```C# Snippet:ImageFileInMessageReview
PageableList<ThreadMessage> messages = await client.GetMessagesAsync(thread.Id);

foreach (ThreadMessage msg in messages)
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

8. Finally, we delete all the resources, we have created in this sample.

Synchronous sample:
```C# Snippet:ImageFileInMessageCleanup_Sync
client.DeleteThread(thread.Id);
client.DeleteAgent(agent.Id);
```

Asynchronous sample:
```C# Snippet:ImageFileInMessageCleanup
await client.DeleteThreadAsync(thread.Id);
await client.DeleteAgentAsync(agent.Id);
```