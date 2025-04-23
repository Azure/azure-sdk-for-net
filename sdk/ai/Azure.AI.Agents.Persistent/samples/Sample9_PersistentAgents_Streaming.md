# Sample using agents with streaming in Azure.AI.Agents.

In this example we will demonstrate the agent streaming support.

1. First we need to create agent client and read the environment variables that will be used in the next steps.
```C# Snippet:AgentsStreamingAsync_CreateClient
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
```
2. We will create agent with the Interpreter tool support. It is needed to allow fow writing mathematical formulas in [LaTeX](https://en.wikipedia.org/wiki/LaTeX) format.

Synchronous sample:
```C# Snippet:AgentsStreaming_CreateAgent
PersistentAgent agent = client.CreateAgent(
    model: modelDeploymentName,
    name: "My Friendly Test Agent",
    instructions: "You politely help with math questions. Use the code interpreter tool when asked to visualize numbers.",
    tools: [new CodeInterpreterToolDefinition()]
);
```

Asynchronous sample:
```C# Snippet:AgentsStreamingAsync_CreateAgent
PersistentAgent agent = await client.CreateAgentAsync(
    model: modelDeploymentName,
    name: "My Friendly Test Agent",
    instructions: "You politely help with math questions. Use the code interpreter tool when asked to visualize numbers.",
    tools: [ new CodeInterpreterToolDefinition() ]
);
```

3. Create `Thread` with the message.

Synchronous sample:
```C# Snippet:AgentsStreaming_CreateThread
PersistentAgentThread thread = client.CreateThread();

ThreadMessage message = client.CreateMessage(
    thread.Id,
    MessageRole.User,
    "Hi, Agent! Draw a graph for a line with a slope of 4 and y-intercept of 9.");
```

Asynchronous sample:
```C# Snippet:AgentsStreamingAsync_CreateThread
PersistentAgentThread thread = await client.CreateThreadAsync();

ThreadMessage message = await client.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "Hi, Agent! Draw a graph for a line with a slope of 4 and y-intercept of 9.");
```

4. Read the output from the stream.

Synchronous sample:
```C# Snippet:AgentsStreaming_StreamLoop
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
```C# Snippet:AgentsStreamingAsync_StreamLoop
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
```C# Snippet:AgentsStreaming_Cleanup
client.DeleteThread(thread.Id);
client.DeleteAgent(agent.Id);
```

Asynchronous sample:
```C# Snippet:AgentsStreamingAsync_Cleanup
await client.DeleteThreadAsync(thread.Id);
await client.DeleteAgentAsync(agent.Id);
```
