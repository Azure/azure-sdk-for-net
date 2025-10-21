# Sample using agents with Image URL as an input in Azure.AI.Agents.Persistent.

This sample demonstrates examples of sending an image URL (along with optional text) as a structured content block in a single message. The examples shows how to create an agent, open a thread,  post content blocks combining text and image inputs, and then run the agent to see how it interprets the multimedia input.

1. First we need to create an agent client and read the environment variables, which will be used in the next steps.

```C# Snippet:AgentImageUrlInMessageCreateClient
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
// Create an AgentsClient, enabling agent-management and messaging.
PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
```

2. Create an agent.

Synchronous sample:
```C# Snippet:AgentImageUrlInMessageCreateAgent_Sync
// NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
PersistentAgent agent = client.Administration.CreateAgent(
    model: modelDeploymentName,
    name: "Image Understanding Agent",
    instructions: "You are an image-understanding agent. Analyze images and provide textual descriptions."
);
```

Asynchronous sample:
```C# Snippet:AgentImageUrlInMessageCreateAgent
// NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
PersistentAgent agent = await client.Administration.CreateAgentAsync(
    model: modelDeploymentName,
    name: "Image Understanding Agent",
    instructions: "You are an image-understanding agent. Analyze images and provide textual descriptions."
);
```

3. Create a thread

Synchronous sample:
```C# Snippet:AgentImageUrlInMessageCreateThread_Sync
PersistentAgentThread thread = client.Threads.CreateThread();
```

Asynchronous sample:
```C# Snippet:AgentImageUrlInMessageCreateThread
PersistentAgentThread thread = await client.Threads.CreateThreadAsync();
```

4. Create a message using multiple content blocks. Here we combine a short text and an image URL in a single user message.

Synchronous sample:
```C# Snippet:AgentImageUrlInMessageCreateMessage_Sync
MessageImageUriParam imageUrlParam = new(
    uri: "https://upload.wikimedia.org/wikipedia/commons/thumb/d/dd/Gfp-wisconsin-madison-the-nature-boardwalk.jpg/2560px-Gfp-wisconsin-madison-the-nature-boardwalk.jpg"
);
imageUrlParam.Detail = ImageDetailLevel.High;

var contentBlocks = new List<MessageInputContentBlock>
{
    new MessageInputTextBlock("Could you describe this image?"),
    new MessageInputImageUriBlock(imageUrlParam)
};

PersistentThreadMessage imageMessage = client.Messages.CreateMessage(
    threadId: thread.Id,
    role: MessageRole.User,
    contentBlocks: contentBlocks
);
```

Asynchronous sample:
```C# Snippet:AgentImageUrlInMessageCreateMessage
MessageImageUriParam imageUrlParam = new(
    uri: "https://upload.wikimedia.org/wikipedia/commons/thumb/d/dd/Gfp-wisconsin-madison-the-nature-boardwalk.jpg/2560px-Gfp-wisconsin-madison-the-nature-boardwalk.jpg"
);
imageUrlParam.Detail = ImageDetailLevel.High;
var contentBlocks = new List<MessageInputContentBlock>
{
    new MessageInputTextBlock("Could you describe this image?"),
    new MessageInputImageUriBlock(imageUrlParam)
};

PersistentThreadMessage imageMessage = await client.Messages.CreateMessageAsync(
    threadId: thread.Id,
    role: MessageRole.User,
    contentBlocks: contentBlocks
);
```

5. Run the agent against the thread that now has an image to analyze.

Synchronous sample:
```C# Snippet:AgentImageUrlInMessageCreateRun_Sync
ThreadRun run = client.Runs.CreateRun(
    threadId: thread.Id,
    assistantId: agent.Id
);
```

Asynchronous sample:
```C# Snippet:AgentImageUrlInMessageCreateRun
ThreadRun run = await client.Runs.CreateRunAsync(
    threadId: thread.Id,
    assistantId: agent.Id
);
```

6. Wait for the run to complete.


Synchronous sample:
```C# Snippet:AgentImageUrlInMessageWaitForRun_Sync
do
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    run = client.Runs.GetRun(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued || run.Status == RunStatus.InProgress);

if (run.Status != RunStatus.Completed)
{
    throw new InvalidOperationException($"Run failed or was canceled: {run.LastError?.Message}");
}
```

Asynchronous sample:
```C# Snippet:AgentImageUrlInMessageWaitForRun
do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    run = await client.Runs.GetRunAsync(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued || run.Status == RunStatus.InProgress);

if (run.Status != RunStatus.Completed)
{
    throw new InvalidOperationException($"Run failed or was canceled: {run.LastError?.Message}");
}
```

7. Retrieve messages (including how the agent responds) and print their contents.

Synchronous sample:
```C# Snippet:AgentImageUrlInMessageReview_Sync
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
```C# Snippet:AgentImageUrlInMessageReview
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

8. Finally, we delete all the resources, we have created in this sample.

Synchronous sample:
```C# Snippet:AgentImageUrlInMessageCleanup_Sync
// NOTE: Comment out these two lines if you plan to reuse the agent later.
client.Threads.DeleteThread(thread.Id);
client.Administration.DeleteAgent(agent.Id);
```

Asynchronous sample:
```C# Snippet:AgentImageUrlInMessageCleanup
// NOTE: Comment out these two lines if you plan to reuse the agent later.
await client.Threads.DeleteThreadAsync(thread.Id);
await client.Administration.DeleteAgentAsync(agent.Id);
```
