# Sample for use of an agent with connected agent tool in Azure.AI.Agents.Persistent.

To enable your Agent to use another agent as a tool (sub-agent), you use `ConnectedAgentToolDefinition` along with a connected agent details.
1. First we need to create an agent client and read the environment variables, which will be used in the next steps.

```C# Snippet:AgentsConnectedAgent_CreateProject
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
PersistentAgentsClient agentClient = new(projectEndpoint, new DefaultAzureCredential());
```

2. We will create a sub-agent first that will be used as a connected agent tool.

Synchronous sample:
```C# Snippet:AgentsConnectedAgent_CreateSubAgent
// NOTE: To reuse existing agent, fetch it with agentClient.Administration.GetAgent(agentId)
PersistentAgent subAgent = agentClient.Administration.CreateAgent(
    model: modelDeploymentName,
    name: "math-helper",
    instructions: "You are a helpful assistant specialized in mathematics. Solve mathematical problems step by step and provide clear explanations.");
```

Asynchronous sample:
```C# Snippet:AgentsConnectedAgentAsync_CreateSubAgent
// NOTE: To reuse existing agent, fetch it with agentClient.Administration.GetAgent(agentId)
PersistentAgent subAgent = await agentClient.Administration.CreateAgentAsync(
    model: modelDeploymentName,
    name: "math-helper",
    instructions: "You are a helpful assistant specialized in mathematics. Solve mathematical problems step by step and provide clear explanations.");
```

3. We will use the sub-agent details to initialize the `ConnectedAgentToolDefinition`.

```C# Snippet:AgentsConnectedAgent_GetConnectedAgent
ConnectedAgentToolDefinition connectedAgentTool = new(
    new ConnectedAgentDetails(
        id: subAgent.Id,
        name: "MathHelper",
        description: "A specialized mathematics assistant that can solve complex mathematical problems and provide step-by-step explanations."
    )
);
```

4. We will use the `ConnectedAgentToolDefinition` during the main agent initialization.

Synchronous sample:
```C# Snippet:AgentsConnectedAgent_CreateAgent
// NOTE: To reuse existing agent, fetch it with agentClient.Administration.GetAgent(agentId)
PersistentAgent agent = agentClient.Administration.CreateAgent(
   model: modelDeploymentName,
   name: "main-agent",
   instructions: "You are a helpful assistant. When users ask mathematical questions, use the MathHelper tool to get specialized mathematical assistance.",
   tools: [connectedAgentTool]);
```

Asynchronous sample:
```C# Snippet:AgentsConnectedAgentAsync_CreateAgent
// NOTE: To reuse existing agent, fetch it with agentClient.Administration.GetAgent(agentId)
PersistentAgent agent = await agentClient.Administration.CreateAgentAsync(
   model: modelDeploymentName,
   name: "main-agent",
   instructions: "You are a helpful assistant. When users ask mathematical questions, use the MathHelper tool to get specialized mathematical assistance.",
   tools: [ connectedAgentTool ]);
```

5. Now we will create the thread, add the message containing a question for agent and start the run.

Synchronous sample:
```C# Snippet:AgentsConnectedAgent_CreateThreadMessage
PersistentAgentThread thread = agentClient.Threads.CreateThread();

// Create message to thread
PersistentThreadMessage message = agentClient.Messages.CreateMessage(
    thread.Id,
    MessageRole.User,
    "What is the derivative of x^3 + 2x^2 - 5x + 7? Please explain step by step.");

// Run the agent
ThreadRun run = agentClient.Runs.CreateRun(thread, agent);
do
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    run = agentClient.Runs.GetRun(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress);

Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```

Asynchronous sample:
```C# Snippet:AgentsConnectedAgentAsync_CreateThreadMessage
PersistentAgentThread thread = await agentClient.Threads.CreateThreadAsync();

// Create message to thread
PersistentThreadMessage message = await agentClient.Messages.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "What is the derivative of x^3 + 2x^2 - 5x + 7? Please explain step by step.");

// Run the agent
ThreadRun run = await agentClient.Runs.CreateRunAsync(thread, agent);
do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    run = await agentClient.Runs.GetRunAsync(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress);

Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```

6. Print the agent messages to console in chronological order.

Synchronous sample:
```C# Snippet:AgentsConnectedAgent_Print
Pageable<PersistentThreadMessage> messages = agentClient.Messages.GetMessages(
    threadId: thread.Id,
    order: ListSortOrder.Ascending
);

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
```

Asynchronous sample:
```C# Snippet:AgentsConnectedAgentAsync_Print
AsyncPageable<PersistentThreadMessage> messages = agentClient.Messages.GetMessagesAsync(
    threadId: thread.Id,
    order: ListSortOrder.Ascending
);

await foreach (PersistentThreadMessage threadMessage in messages)
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
```

7. Clean up resources by deleting thread, agent, and sub-agent.

Synchronous sample:
```C# Snippet:AgentsConnectedAgentCleanup
// NOTE: Comment out these three lines if you plan to reuse the agent later.
agentClient.Threads.DeleteThread(threadId: thread.Id);
agentClient.Administration.DeleteAgent(agentId: agent.Id);
agentClient.Administration.DeleteAgent(agentId: subAgent.Id);
```

Asynchronous sample:
```C# Snippet:AgentsConnectedAgentCleanupAsync
// NOTE: Comment out these three lines if you plan to reuse the agent later.
await agentClient.Threads.DeleteThreadAsync(threadId: thread.Id);
await agentClient.Administration.DeleteAgentAsync(agentId: agent.Id);
await agentClient.Administration.DeleteAgentAsync(agentId: subAgent.Id);
```
