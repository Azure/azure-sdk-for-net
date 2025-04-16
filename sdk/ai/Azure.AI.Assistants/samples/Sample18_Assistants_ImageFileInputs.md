# Sample using assistants with Image Fileas an input in Azure.AI.Assistants.

Demonstrates examples of sending an image file (along with optional text) as a structured content block in a single message. The examples shows how to create an assistant, open a thread, post content blocks combining text and image inputs, and then run the agent to see how it interprets the multimedia input.

1. First we need to create an assistant client and read the environment variables, which will be used in the next steps.

```C# Snippet:AssistantsImageFileInMessageCreateClient
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var filePath = GetFile();
// 1) Create an AssistantsClient for assistant-management and messaging.
AssistantsClient client = new(projectEndpoint, new DefaultAzureCredential());
```

2. (Optional) Upload a file for referencing in your message:

Synchronous sample:
```C# Snippet:AssistantsImageFileInMessageUpload_Sync
string pathToImage = Path.Combine(
    TestContext.CurrentContext.TestDirectory,
    filePath
);

// The file might be an image or any relevant binary.
// Make sure the server or container is set up for "Assistants" usage if required.
AssistantFile uploadedFile = client.UploadFile(
    filePath: pathToImage,
    purpose: AssistantFilePurpose.Assistants
);
Console.WriteLine($"Uploaded file with ID: {uploadedFile.Id}");
```

Asynchronous sample:
```C# Snippet:AssistantsImageFileInMessageUpload
string pathToImage = Path.Combine(
        TestContext.CurrentContext.TestDirectory,
        filePath
    );

// The file might be an image or any relevant binary.
// Make sure the server or container is set up for "Assistants" usage if required.
AssistantFile uploadedFile = await client.UploadFileAsync(
    filePath: pathToImage,
    purpose: AssistantFilePurpose.Assistants
);
Console.WriteLine($"Uploaded file with ID: {uploadedFile.Id}");
```

3. Create an assistant.

Synchronous sample:
```C# Snippet:AssistantsImageFileInMessageCreateAssistant_Sync
Assistant assistant = client.CreateAssistant(
    model: modelDeploymentName,
    name: "File Image Understanding Assistant",
    instructions: "Analyze images from internally uploaded files."
);
```

Asynchronous sample:
```C# Snippet:AssistantsImageFileInMessageCreateAssistant
Assistant assistant = await client.CreateAssistantAsync(
    model: modelDeploymentName,
    name: "File Image Understanding Assistant",
    instructions: "Analyze images from internally uploaded files."
);
```

4. Create a thread.

Synchronous sample:
```C# Snippet:AssistantsImageFileInMessageCreateThread_Sync
AssistantThread thread = client.CreateThread();
```

Asynchronous sample:
```C# Snippet:AssistantsImageFileInMessageCreateThread
AssistantThread thread = await client.CreateThreadAsync();
```

5. Create a message referencing the uploaded file.

Synchronous sample:
```C# Snippet:AssistantsImageFileInMessageCreateMessage_Sync
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
```C# Snippet:AssistantsImageFileInMessageCreateMessage
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

6. Run the assistant.

Synchronous sample:
```C# Snippet:AssistantsImageFileInMessageCreateRun_Sync
ThreadRun run = client.CreateRun(
    threadId: thread.Id,
    assistantId: assistant.Id
);
```

Asynchronous sample:
```C# Snippet:AssistantsImageFileInMessageCreateRun
ThreadRun run = await client.CreateRunAsync(
    threadId: thread.Id,
    assistantId: assistant.Id
);
```

7. Wait for the run to complete.

Synchronous sample:
```C# Snippet:AssistantsImageFileInMessageWaitForRun_Sync
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
```C# Snippet:AssistantsImageFileInMessageWaitForRun
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

8. Retrieve messages (including any agent responses) and print them.

Synchronous sample:
```C# Snippet:AssistantsImageFileInMessageReview_Sync
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
```C# Snippet:AssistantsImageFileInMessageReview
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

9. Finally, we delete all the resources, we have created in this sample.

Synchronous sample:
```C# Snippet:AssistantsImageFileInMessageCleanup_Sync
client.DeleteThread(thread.Id);
client.DeleteAssistant(assistant.Id);
```

Asynchronous sample:
```C# Snippet:AssistantsImageFileInMessageCleanup
await client.DeleteThreadAsync(thread.Id);
await client.DeleteAssistantAsync(assistant.Id);
```