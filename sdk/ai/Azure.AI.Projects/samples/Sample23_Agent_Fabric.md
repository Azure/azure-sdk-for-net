# Sample for use of an Agent with Fabric tool in Azure.AI.Projects.

To enable your Agent to perform search against a Fabric resource, you use `MicrosoftFabricToolDefinition` along with a connection.
1. First we need to create an Agent client and read the environment variables, which will be used in the next steps.

```C# Snippet:Fabric_CreateProject
var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var fabricConnectionName = System.Environment.GetEnvironmentVariable("FABRIC_CONNECTION_NAME");

var projectClient = new AIProjectClient(connectionString, new DefaultAzureCredential());

AgentsClient agentClient = projectClient.GetAgentsClient();
```

2. Next we will get the Fabric connection by name using connection client. This connection will be used to initialize the `MicrosoftFabricToolDefinition`.

Synchronous sample:
```C# Snippet:Fabric_GetConnection
ConnectionResponse fabricConnection = projectClient.GetConnectionsClient().GetConnection(fabricConnectionName);
var connectionId = fabricConnection.Id;

ToolConnectionList connectionList = new()
{
    ConnectionList = { new ToolConnection(connectionId) }
};
MicrosoftFabricToolDefinition fabricTool = new(connectionList);
```

Asynchronous sample:
```C# Snippet:FabricAsync_GetConnection
ConnectionResponse fabricConnection = await projectClient.GetConnectionsClient().GetConnectionAsync(fabricConnectionName);
var connectionId = fabricConnection.Id;

ToolConnectionList connectionList = new()
{
    ConnectionList = { new ToolConnection(connectionId) }
};
MicrosoftFabricToolDefinition fabricTool = new(connectionList);
```

3. We will use the `MicrosoftFabricToolDefinition` during the Agent initialization.

Synchronous sample:
```C# Snippet:Fabric_CreateAgent
Agent agent = agentClient.CreateAgent(
   model: modelDeploymentName,
   name: "my-assistant",
   instructions: "You are a helpful assistant.",
   tools: [fabricTool]);
```

Asynchronous sample:
```C# Snippet:FabricAsync_CreateAgent
Agent agent = await agentClient.CreateAgentAsync(
   model: modelDeploymentName,
   name: "my-assistant",
   instructions: "You are a helpful assistant.",
   tools: [ fabricTool ]);
```

4. Now we will create the thread, add the message containing a question for the Agent and start the run.

Synchronous sample:
```C# Snippet:Fabric_CreateThreadMessage
AgentThread thread = agentClient.CreateThread();

// Create message to thread
ThreadMessage message = agentClient.CreateMessage(
    thread.Id,
    MessageRole.User,
    "What are the top 3 weather events with highest property damage?");

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
```C# Snippet:FabricAsync_CreateThreadMessage
AgentThread thread = await agentClient.CreateThreadAsync();

// Create message to thread
ThreadMessage message = await agentClient.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "What are the top 3 weather events with highest property damage?");

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

5. Print the Agent messages to console in chronological order.

Synchronous sample:
```C# Snippet:Fabric_Print
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
```C# Snippet:FabricAsync_Print
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

6. Clean up resources by deleting the thread and the Agent.

Synchronous sample:
```C# Snippet:FabricCleanup
agentClient.DeleteThread(threadId: thread.Id);
agentClient.DeleteAgent(agentId: agent.Id);
```

Asynchronous sample:
```C# Snippet:FabricCleanupAsync
await agentClient.DeleteThreadAsync(threadId: thread.Id);
await agentClient.DeleteAgentAsync(agentId: agent.Id);
```
