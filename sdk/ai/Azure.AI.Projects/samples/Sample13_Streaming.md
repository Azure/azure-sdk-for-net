# Sample using agents with streaming in Azure.AI.Projects.

In this example we will demonstrate the agent streaming support.

1. First we need to create agent client and read the environment variables that will be used in the next steps.
```C# Snippet:StreamingAsync_CreateClient
var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AgentsClient client = new(connectionString, new DefaultAzureCredential());
```
2. We will create agent with the Interpreter tool support. It is needed to allow fow writing mathematical formulas in [LaTeX](https://en.wikipedia.org/wiki/LaTeX) format.

Synchronous sample:
```C# Snippet:Streaming_CreateAgent
Agent agent = client.CreateAgent(
    model: modelDeploymentName,
    name: "My Friendly Test Assistant",
    instructions: "You politely help with math questions. Use the code interpreter tool when asked to visualize numbers.",
    tools: [new CodeInterpreterToolDefinition()]
);
```

Asynchronous sample:
```C# Snippet:StreamingAsync_CreateAgent
Agent agent = await client.CreateAgentAsync(
    model: modelDeploymentName,
    name: "My Friendly Test Assistant",
    instructions: "You politely help with math questions. Use the code interpreter tool when asked to visualize numbers.",
    tools: [ new CodeInterpreterToolDefinition() ]
);
```

3. Create `Thread` with the message.

Synchronous sample:
```C# Snippet:Streaming_CreateThread
AgentThread thread = client.CreateThread();

ThreadMessage message = client.CreateMessage(
    thread.Id,
    MessageRole.User,
    "Hi, Assistant! Draw a graph for a line with a slope of 4 and y-intercept of 9.");
```

Asynchronous sample:
```C# Snippet:StreamingAsync_CreateThread
AgentThread thread = await client.CreateThreadAsync();

ThreadMessage message = await client.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "Hi, Assistant! Draw a graph for a line with a slope of 4 and y-intercept of 9.");
```

4. Read the output from the stream.

Synchronous sample:
```C# Snippet:Streaming_StreamLoop
foreach (StreamingUpdate streamingUpdate in client.CreateRunStreaming(thread.Id, agent.Id))
{
    if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
    {
        Console.WriteLine($"--- Run started! ---");
    }
    else if (streamingUpdate is MessageContentUpdate contentUpdate)
    {
        Console.Write(contentUpdate.Text);
        if (contentUpdate.ImageFileId is not null)
        {
            Console.WriteLine($"[Image content file ID: {contentUpdate.ImageFileId}");
        }
    }
}
```

Asynchronous sample:
```C# Snippet:StreamingAsync_StreamLoop
await foreach (StreamingUpdate streamingUpdate in client.CreateRunStreamingAsync(thread.Id, agent.Id))
{
    if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
    {
        Console.WriteLine($"--- Run started! ---");
    }
    else if (streamingUpdate is MessageContentUpdate contentUpdate)
    {
        Console.Write(contentUpdate.Text);
        if (contentUpdate.ImageFileId is not null)
        {
            Console.WriteLine($"[Image content file ID: {contentUpdate.ImageFileId}");
        }
    }
}
```

5. Finally, we delete all the resources, we have created in this sample.

Synchronous sample:
```C# Snippet::Streaming_Cleanup
client.DeleteThread(thread.Id);
client.DeleteAgent(agent.Id);
```

Asynchronous sample:
```C# Snippet::StreamingAsync_Cleanup
await client.DeleteThreadAsync(thread.Id);
await client.DeleteAgentAsync(agent.Id);
```
