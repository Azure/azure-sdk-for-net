# Sample for use of an agent with Bing grounding in Azure.AI.Projects.

To enable your Agent to perform search through Bing search API, you use `BingGroundingToolDefinition` along with a connection.
1. First we need to create agent client and read the environment variables, which will be used in the next steps.

```C# Snippet:BingGrounding_CreateProject
var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var bingConnectionName = System.Environment.GetEnvironmentVariable("BING_CONNECTION_NAME");

var projectClient = new AIProjectClient(connectionString, new DefaultAzureCredential());

AgentsClient agentClient = projectClient.GetAgentsClient();
```

2. Next we will get the bing connection by name using connection client. This connection will be used to initialize the `BingGroundingToolDefinition`.

Synchronous sample:
```C# Snippet:BingGrounding_GetConnection
ConnectionResponse bingConnection = projectClient.GetConnectionsClient().GetConnection(bingConnectionName);
var connectionId = bingConnection.Id;

ToolConnectionList connectionList = new()
{
    ConnectionList = { new ToolConnection(connectionId) }
};
BingGroundingToolDefinition bingGroundingTool = new(connectionList);
```

Asynchronous sample:
```C# Snippet:BingGroundingAsync_GetConnection
ConnectionResponse bingConnection = await projectClient.GetConnectionsClient().GetConnectionAsync(bingConnectionName);
var connectionId = bingConnection.Id;

ToolConnectionList connectionList = new()
{
    ConnectionList = { new ToolConnection(connectionId) }
};
BingGroundingToolDefinition bingGroundingTool = new(connectionList);
```

3. We will use the `BingGroundingToolDefinition` during the agent initialization.

Synchronous sample:
```C# Snippet:BingGrounding_CreateAgent
Agent agent = agentClient.CreateAgent(
   model: modelDeploymentName,
   name: "my-assistant",
   instructions: "You are a helpful assistant.",
   tools: [bingGroundingTool]);
```

Asynchronous sample:
```C# Snippet:BingGroundingAsync_CreateAgent
Agent agent = await agentClient.CreateAgentAsync(
   model: modelDeploymentName,
   name: "my-assistant",
   instructions: "You are a helpful assistant.",
   tools: [ bingGroundingTool ]);
```

4. Now we will create the thread, add the message , containing a question for agent and start the run.

Synchronous sample:
```C# Snippet:BingGrounding_CreateThreadMessage
AgentThread thread = agentClient.CreateThread();

// Create message to thread
ThreadMessage message = agentClient.CreateMessage(
    thread.Id,
    MessageRole.User,
    "How does wikipedia explain Euler's Identity?");

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
```C# Snippet:BingGroundingAsync_CreateThreadMessage
AgentThread thread = await agentClient.CreateThreadAsync();

// Create message to thread
ThreadMessage message = await agentClient.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "How does wikipedia explain Euler's Identity?");

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
```C# Snippet:BingGrounding_Print
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
```C# Snippet:BingGroundingAsync_Print
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
```C# Snippet:BingGroundingCleanup
agentClient.DeleteThread(threadId: thread.Id);
agentClient.DeleteAgent(agentId: agent.Id);
```

Asynchronous sample:
```C# Snippet:BingGroundingCleanupAsync
await agentClient.DeleteThreadAsync(threadId: thread.Id);
await agentClient.DeleteAgentAsync(agentId: agent.Id);
```
