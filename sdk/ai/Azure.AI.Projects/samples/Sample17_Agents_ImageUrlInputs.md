# Sample using agents with Image URL as an input.

This sample demonstrates examples of sending an image URL (along with optional text) as a structured content block in a single message. The examples shows how to create an agent, open a thread,  post content blocks combining text and image inputs, and then run the agent to see how it interprets the multimedia input.

1. Create an agent.

Synchronous sample:
```C# Snippet:ImageUrlInMessageCreateAgent_Sync
Agent agent = client.CreateAgent(
    model: modelDeploymentName,
    name: "Image Understanding Agent",
    instructions: "You are an image-understanding assistant. Analyze images and provide textual descriptions."
);
```

Asynchronous sample:
```C# Snippet:ImageUrlInMessageCreateAgent
Agent agent = await client.CreateAgentAsync(
    model: modelDeploymentName,
    name: "Image Understanding Agent",
    instructions: "You are an image-understanding assistant. Analyze images and provide textual descriptions."
);
```

2. Create a thread

Synchronous sample:
```C# Snippet:ImageUrlInMessageCreateThread_Sync
AgentThread thread = client.CreateThread();
```

Asynchronous sample:
```C# Snippet:ImageUrlInMessageCreateThread
AgentThread thread = await client.CreateThreadAsync();
```

3. Create a message using multiple content blocks. Here we combine a short text and an image URL in a single user message.

Synchronous sample:
```C# Snippet:ImageUrlInMessageCreateMessage_Sync
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
```C# Snippet:ImageUrlInMessageCreateMessage
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

4. Run the agent against the thread that now has an image to analyze.

Synchronous sample:
```C# Snippet:ImageUrlInMessageCreateRun_Sync
ThreadRun run = client.CreateRun(
    threadId: thread.Id,
    assistantId: agent.Id
);
```

Asynchronous sample:
```C# Snippet:ImageUrlInMessageCreateRun
ThreadRun run = await client.CreateRunAsync(
    threadId: thread.Id,
    assistantId: agent.Id
);
```

5. Wait for the run to complete.


Synchronous sample:
```C# Snippet:ImageUrlInMessageWaitForRun_Sync
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
```C# Snippet:ImageUrlInMessageWaitForRun
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

6. Retrieve messages (including how the agent responds) and print their contents.

Synchronous sample:
```C# Snippet:ImageUrlInMessageReview_Sync
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
```C# Snippet:ImageUrlInMessageReview
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

7. Finally, we delete all the resources, we have created in this sample.

Synchronous sample:
```C# Snippet:ImageUrlInMessageCleanup_Sync
client.DeleteThread(thread.Id);
client.DeleteAgent(agent.Id);
```

Asynchronous sample:
```C# Snippet:ImageUrlInMessageCleanup
await client.DeleteThreadAsync(thread.Id);
await client.DeleteAgentAsync(agent.Id);
```
