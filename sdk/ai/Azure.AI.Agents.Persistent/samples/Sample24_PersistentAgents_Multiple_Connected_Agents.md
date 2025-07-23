# Sample for use of an agent with multiple connected agent tools in Azure.AI.Agents.Persistent.

To enable your Agent to use multiple other agents as tools (sub-agents), you use multiple `ConnectedAgentToolDefinition` instances, each with their own connected agent details.
1. First we need to create an agent client and read the environment variables, which will be used in the next steps.

```C# Snippet:AgentsMultipleConnectedAgents_CreateProject
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
PersistentAgentsClient agentClient = new(projectEndpoint, new DefaultAzureCredential());
```

2. We will create multiple sub-agents first that will be used as connected agent tools.

Synchronous sample:
```C# Snippet:AgentsMultipleConnectedAgents_CreateSubAgents
PersistentAgent stockPriceAgent = agentClient.Administration.CreateAgent(
    model: modelDeploymentName,
    name: "stock-price-bot",
    instructions: "Your job is to get the stock price of a company. If asked for the Microsoft stock price, always return $350.");

PersistentAgent weatherAgent = agentClient.Administration.CreateAgent(
    model: modelDeploymentName,
    name: "weather-bot",
    instructions: "Your job is to get the weather for a given location. If asked for the weather in Seattle, always return 60 degrees and cloudy.");
```

Asynchronous sample:
```C# Snippet:AgentsMultipleConnectedAgentsAsync_CreateSubAgents
PersistentAgent stockPriceAgent = await agentClient.Administration.CreateAgentAsync(
    model: modelDeploymentName,
    name: "stock-price-bot",
    instructions: "Your job is to get the stock price of a company. If asked for the Microsoft stock price, always return $350.");

PersistentAgent weatherAgent = await agentClient.Administration.CreateAgentAsync(
    model: modelDeploymentName,
    name: "weather-bot",
    instructions: "Your job is to get the weather for a given location. If asked for the weather in Seattle, always return 60 degrees and cloudy.");
```

3. We will use the sub-agents details to initialize multiple `ConnectedAgentToolDefinition` instances.

```C# Snippet:AgentsMultipleConnectedAgents_GetConnectedAgents
ConnectedAgentToolDefinition stockPriceConnectedAgentTool = new(
    new ConnectedAgentDetails(
        id: stockPriceAgent.Id,
        name: "stock_price_bot",
        description: "Gets the stock price of a company"
    )
);

ConnectedAgentToolDefinition weatherConnectedAgentTool = new(
    new ConnectedAgentDetails(
        id: weatherAgent.Id,
        name: "weather_bot",
        description: "Gets the weather for a given location"
    )
);
```

4. We will use both `ConnectedAgentToolDefinition` instances during the main agent initialization.

Synchronous sample:
```C# Snippet:AgentsMultipleConnectedAgents_CreateAgent
PersistentAgent agent = agentClient.Administration.CreateAgent(
   model: modelDeploymentName,
   name: "my-assistant",
   instructions: "You are a helpful assistant, and use the connected agents to get stock prices and weather.",
   tools: [stockPriceConnectedAgentTool, weatherConnectedAgentTool]);
```

Asynchronous sample:
```C# Snippet:AgentsMultipleConnectedAgentsAsync_CreateAgent
PersistentAgent agent = await agentClient.Administration.CreateAgentAsync(
   model: modelDeploymentName,
   name: "my-assistant",
   instructions: "You are a helpful assistant, and use the connected agents to get stock prices and weather.",
   tools: [stockPriceConnectedAgentTool, weatherConnectedAgentTool]);
```

5. Now we will create the thread, add the message containing a question for agent and start the run.

Synchronous sample:
```C# Snippet:AgentsMultipleConnectedAgents_CreateThreadMessage
PersistentAgentThread thread = agentClient.Threads.CreateThread();

// Create message to thread
PersistentThreadMessage message = agentClient.Messages.CreateMessage(
    thread.Id,
    MessageRole.User,
    "What is the stock price of Microsoft and the weather in Seattle?");

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
```C# Snippet:AgentsMultipleConnectedAgentsAsync_CreateThreadMessage
PersistentAgentThread thread = await agentClient.Threads.CreateThreadAsync();

// Create message to thread
PersistentThreadMessage message = await agentClient.Messages.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "What is the stock price of Microsoft and the weather in Seattle?");

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
```C# Snippet:AgentsMultipleConnectedAgents_Print
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
            Console.Write($"<image from ID: {imageFileItem.FileId}>");
        }
        Console.WriteLine();
    }
}
```

Asynchronous sample:
```C# Snippet:AgentsMultipleConnectedAgentsAsync_Print
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
            Console.Write($"<image from ID: {imageFileItem.FileId}>");
        }
        Console.WriteLine();
    }
}
```

7. Clean up resources by deleting thread, main agent, and all sub-agents.

Synchronous sample:
```C# Snippet:AgentsMultipleConnectedAgentsCleanup
agentClient.Threads.DeleteThread(threadId: thread.Id);
agentClient.Administration.DeleteAgent(agentId: agent.Id);
agentClient.Administration.DeleteAgent(agentId: stockPriceAgent.Id);
agentClient.Administration.DeleteAgent(agentId: weatherAgent.Id);
```

Asynchronous sample:
```C# Snippet:AgentsMultipleConnectedAgentsCleanupAsync
await agentClient.Threads.DeleteThreadAsync(threadId: thread.Id);
await agentClient.Administration.DeleteAgentAsync(agentId: agent.Id);
await agentClient.Administration.DeleteAgentAsync(agentId: stockPriceAgent.Id);
await agentClient.Administration.DeleteAgentAsync(agentId: weatherAgent.Id);
```
