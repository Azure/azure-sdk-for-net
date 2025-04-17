# Sample using assistants with Image URL as an input in Azure.AI.Assistants.

This sample demonstrates examples of sending an image URL (along with optional text) as a structured content block in a single message. The examples shows how to create an assistant, open a thread,  post content blocks combining text and image inputs, and then run the assistant to see how it interprets the multimedia input.

1. First we need to create an assistant client and read the environment variables, which will be used in the next steps.

```C# Snippet:AssistantImageUrlInMessageCreateClient
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
// Create an AssistantsClient, enabling assistant-management and messaging.
AssistantsClient client = new(projectEndpoint, new DefaultAzureCredential());
```

2. Create an assistant.

Synchronous sample:
```C# Snippet:AssistantImageUrlInMessageCreateAssistant_Sync
Assistant assistant = client.CreateAssistant(
    model: modelDeploymentName,
    name: "Image Understanding Assistant",
    instructions: "You are an image-understanding assistant. Analyze images and provide textual descriptions."
);
```

Asynchronous sample:
```C# Snippet:AssistantImageUrlInMessageCreateAssistant
Assistant assistant = await client.CreateAssistantAsync(
    model: modelDeploymentName,
    name: "Image Understanding Assistant",
    instructions: "You are an image-understanding assistant. Analyze images and provide textual descriptions."
);
```

3. Create a thread

Synchronous sample:
```C# Snippet:AssistantImageUrlInMessageCreateThread_Sync
AssistantThread thread = client.CreateThread();
```

Asynchronous sample:
```C# Snippet:AssistantImageUrlInMessageCreateThread
AssistantThread thread = await client.CreateThreadAsync();
```

4. Create a message using multiple content blocks. Here we combine a short text and an image URL in a single user message.

Synchronous sample:
```C# Snippet:AssistantImageUrlInMessageCreateMessage_Sync
MessageImageUrlParam imageUrlParam = new MessageImageUrlParam(
    url: "https://upload.wikimedia.org/wikipedia/commons/thumb/d/dd/Gfp-wisconsin-madison-the-nature-boardwalk.jpg/2560px-Gfp-wisconsin-madison-the-nature-boardwalk.jpg"
);
imageUrlParam.Detail = ImageDetailLevel.High;

var contentBlocks = new List<MessageInputContentBlock>
{
    new MessageInputTextBlock("Could you describe this image?"),
    new MessageInputImageUrlBlock(imageUrlParam)
};

ThreadMessage imageMessage = client.CreateMessage(
    threadId: thread.Id,
    role: MessageRole.User,
    contentBlocks: contentBlocks
);
```

Asynchronous sample:
```C# Snippet:AssistantImageUrlInMessageCreateMessage
MessageImageUrlParam imageUrlParam = new MessageImageUrlParam(
    url: "https://upload.wikimedia.org/wikipedia/commons/thumb/d/dd/Gfp-wisconsin-madison-the-nature-boardwalk.jpg/2560px-Gfp-wisconsin-madison-the-nature-boardwalk.jpg"
);
imageUrlParam.Detail = ImageDetailLevel.High;
var contentBlocks = new List<MessageInputContentBlock>
{
    new MessageInputTextBlock("Could you describe this image?"),
    new MessageInputImageUrlBlock(imageUrlParam)
};

ThreadMessage imageMessage = await client.CreateMessageAsync(
    threadId: thread.Id,
    role: MessageRole.User,
    contentBlocks: contentBlocks
);
```

5. Run the assistant against the thread that now has an image to analyze.

Synchronous sample:
```C# Snippet:AssistantImageUrlInMessageCreateRun_Sync
ThreadRun run = client.CreateRun(
    threadId: thread.Id,
    assistantId: assistant.Id
);
```

Asynchronous sample:
```C# Snippet:AssistantImageUrlInMessageCreateRun
ThreadRun run = await client.CreateRunAsync(
    threadId: thread.Id,
    assistantId: assistant.Id
);
```

6. Wait for the run to complete.


Synchronous sample:
```C# Snippet:AssistantImageUrlInMessageWaitForRun_Sync
do
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    run = client.GetRun(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued || run.Status == RunStatus.InProgress);

if (run.Status != RunStatus.Completed)
{
    throw new InvalidOperationException($"Run failed or was canceled: {run.LastError?.Message}");
}
```

Asynchronous sample:
```C# Snippet:AssistantImageUrlInMessageWaitForRun
do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    run = await client.GetRunAsync(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued || run.Status == RunStatus.InProgress);

if (run.Status != RunStatus.Completed)
{
    throw new InvalidOperationException($"Run failed or was canceled: {run.LastError?.Message}");
}
```

7. Retrieve messages (including how the assistant responds) and print their contents.

Synchronous sample:
```C# Snippet:AssistantImageUrlInMessageReview_Sync
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
```C# Snippet:AssistantImageUrlInMessageReview
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
```C# Snippet:AssistantImageUrlInMessageCleanup_Sync
client.DeleteThread(thread.Id);
client.DeleteAssistant(assistant.Id);
```

Asynchronous sample:
```C# Snippet:AssistantImageUrlInMessageCleanup
await client.DeleteThreadAsync(thread.Id);
await client.DeleteAssistantAsync(assistant.Id);
```
