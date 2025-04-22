# Sample for use of an agent with a connected agent in Azure.AI.Projects.

To enable your Agent to use a connected agent, you use `ConnectedAgentToolDefinition` along with the agent id, name, and a description.
1. First we need to create agent client and read the environment variables, which will be used in the next steps.

```C# Snippet:ConnectedAgent_CreateProject
var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");

var projectClient = new AIProjectClient(connectionString, new DefaultAzureCredential());

AgentsClient agentClient = projectClient.GetAgentsClient();
```

2. Next we will create the connected agent using the agent client. This agent will be used to initialize the `ConnectedAgentToolDefinition`.

Synchronous sample:
```C# Snippet:ConnectedAgent_CreateConnectedAgent
Agent connectedAgent = agentClient.CreateAgent(
   model: modelDeploymentName,
   name: "stock_price_bot",
   instructions: "Your job is to get the stock price of a company. If you don't know the realtime stock price, return the last known stock price.");

ConnectedAgentToolDefinition connectedAgentDefinition = new(new ConnectedAgentDetails(connectedAgent.Id, connectedAgent.Name, "Gets the stock price of a company"));
```

Asynchronous sample:
```C# Snippet:ConnectedAgentAsync_CreateConnectedAgent
Agent connectedAgent = await agentClient.CreateAgentAsync(
   model: modelDeploymentName,
   name: "stock_price_bot",
   instructions: "Your job is to get the stock price of a company. If you don't know the realtime stock price, return the last known stock price.");

ConnectedAgentToolDefinition connectedAgentDefinition = new(new ConnectedAgentDetails(connectedAgent.Id, connectedAgent.Name, "Gets the stock price of a company"));
```

3. We will use the `ConnectedAgentToolDefinition` during the agent initialization.

Synchronous sample:
```C# Snippet:ConnectedAgent_CreateAgent
Agent agent = agentClient.CreateAgent(
   model: modelDeploymentName,
   name: "my-assistant",
   instructions: "You are a helpful assistant, and use the connected agent to get stock prices.",
   tools: [ connectedAgentDefinition ]);
```

Asynchronous sample:
```C# Snippet:ConnectedAgentAsync_CreateAgent
Agent agent = await agentClient.CreateAgentAsync(
   model: modelDeploymentName,
   name: "my-assistant",
   instructions: "You are a helpful assistant, and use the connected agent to get stock prices.",
   tools: [ connectedAgentDefinition ]);
```

4. Now we will create the thread, add the message, containing a question for agent and start the run.

Synchronous sample:
```C# Snippet:ConnectedAgent_CreateThreadMessage
AgentThread thread = agentClient.CreateThread();

// Create message to thread
ThreadMessage message = agentClient.CreateMessage(
    thread.Id,
    MessageRole.User,
    "What is the stock price of Microsoft?");

// Run the agent
ThreadRun run = agentClient.CreateRun(thread, agent);
do
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    run = agentClient.GetRun(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress);

Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```

Asynchronous sample:
```C# Snippet:ConnectedAgentAsync_CreateThreadMessage
AgentThread thread = await agentClient.CreateThreadAsync();

// Create message to thread
ThreadMessage message = await agentClient.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "What is the stock price of Microsoft?");

// Run the agent
ThreadRun run = await agentClient.CreateRunAsync(thread, agent);
do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    run = await agentClient.GetRunAsync(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress);

Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```

5. Print the agent messages to console in chronological order.

Synchronous sample:
```C# Snippet:ConnectedAgent_Print
PageableList<ThreadMessage> messages = agentClient.GetMessages(
    threadId: thread.Id,
    order: ListSortOrder.Ascending
);

foreach (ThreadMessage threadMessage in messages)
{
    Console.Write($"{threadMessage.CreatedAt:yyyy-MM-dd HH:mm:ss} - {threadMessage.Role,10}: ");
    foreach (MessageContent contentItem in threadMessage.ContentItems)
    {
        if (contentItem is MessageTextContent textItem)
        {
            string response = textItem.Text;
            if (textItem.Annotations != null)
            {
                foreach (MessageTextAnnotation annotation in textItem.Annotations)
                {
                    if (annotation is MessageTextUrlCitationAnnotation urlAnnotation)
                    {
                        response = response.Replace(urlAnnotation.Text, $" [{urlAnnotation.UrlCitation.Title}]({urlAnnotation.UrlCitation.Url})");
                    }
                }
            }
            Console.Write($"Agent response: {response}");
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
```C# Snippet:ConnectedAgentAsync_Print
PageableList<ThreadMessage> messages = await agentClient.GetMessagesAsync(
    threadId: thread.Id,
    order: ListSortOrder.Ascending
);

foreach (ThreadMessage threadMessage in messages)
{
    Console.Write($"{threadMessage.CreatedAt:yyyy-MM-dd HH:mm:ss} - {threadMessage.Role,10}: ");
    foreach (MessageContent contentItem in threadMessage.ContentItems)
    {
        if (contentItem is MessageTextContent textItem)
        {
            string response = textItem.Text;
            if (textItem.Annotations != null)
            {
                foreach (MessageTextAnnotation annotation in textItem.Annotations)
                {
                    if (annotation is MessageTextUrlCitationAnnotation urlAnnotation)
                    {
                        response = response.Replace(urlAnnotation.Text, $" [{urlAnnotation.UrlCitation.Title}]({urlAnnotation.UrlCitation.Url})");
                    }
                }
            }
            Console.Write($"Agent response: {response}");
        }
        else if (contentItem is MessageImageFileContent imageFileItem)
        {
            Console.Write($"<image from ID: {imageFileItem.FileId}");
        }
        Console.WriteLine();
    }
}
```

6. Clean up resources by deleting thread and agent.

Synchronous sample:
```C# Snippet:ConnectedAgentCleanup
agentClient.DeleteThread(threadId: thread.Id);
agentClient.DeleteAgent(agentId: agent.Id);
agentClient.DeleteAgent(agentId: connectedAgent.Id);
```

Asynchronous sample:
```C# Snippet:ConnectedAgentCleanupAsync
await agentClient.DeleteThreadAsync(threadId: thread.Id);
await agentClient.DeleteAgentAsync(agentId: agent.Id);
await agentClient.DeleteAgentAsync(agentId: connectedAgent.Id);
```
