# Sample for use of an agent with Microsoft Fabric in Azure.AI.Agents.Persistent.

To enable your Agent to perform actions using Microsoft Fabric, use `MicrosoftFabricToolDefinition` along with a connection.

1. First, create an agent client and read the environment variables, which will be used in the next steps.

```C# Snippet:AgentsFabric_CreateProject
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var connectionId = System.Environment.GetEnvironmentVariable("AZURE_FABRIC_CONNECTION_ID");
PersistentAgentsClient agentClient = new(projectEndpoint, new DefaultAzureCredential());
```

2. Use the Fabric connection ID to initialize the `MicrosoftFabricToolDefinition`.

```C# Snippet:AgentsFabric_GetConnection
MicrosoftFabricToolDefinition fabricTool = new(
    new FabricDataAgentToolParameters(
        connectionId
    )
);
```

3. Use the `MicrosoftFabricToolDefinition` during the agent initialization.

Synchronous sample:
```C# Snippet:AgentsFabric_CreateAgent
// NOTE: To reuse existing agent, fetch it with agentClient.Administration.GetAgent(agentId)
PersistentAgent agent = agentClient.Administration.CreateAgent(
   model: modelDeploymentName,
   name: "my-agent",
   instructions: "You are a helpful agent.",
   tools: [fabricTool]);
```

Asynchronous sample:
```C# Snippet:AgentsFabricAsync_CreateAgent
// NOTE: To reuse existing agent, fetch it with agentClient.Administration.GetAgent(agentId)
PersistentAgent agent = await agentClient.Administration.CreateAgentAsync(
   model: modelDeploymentName,
   name: "my-agent",
   instructions: "You are a helpful agent.",
   tools: [ fabricTool ]);
```

4. Create the thread, add the message containing a query for the agent, and start the run.

Synchronous sample:
```C# Snippet:AgentsFabric_CreateThreadMessage
PersistentAgentThread thread = agentClient.Threads.CreateThread();

// Create message to thread
PersistentThreadMessage message = agentClient.Messages.CreateMessage(
    thread.Id,
    MessageRole.User,
    "<User query against Fabric resource>");

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
```C# Snippet:AgentsFabricAsync_CreateThreadMessage
PersistentAgentThread thread = await agentClient.Threads.CreateThreadAsync();

// Create message to thread
PersistentThreadMessage message = await agentClient.Messages.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "<User query against Fabric resource>");

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

5. Print the agent messages to console in chronological order.

Synchronous sample:
```C# Snippet:AgentsFabric_Print
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
            string response = textItem.Text;
            if (textItem.Annotations != null)
            {
                foreach (MessageTextAnnotation annotation in textItem.Annotations)
                {
                    if (annotation is MessageTextUriCitationAnnotation uriAnnotation)
                    {
                        response = response.Replace(uriAnnotation.Text, $" [{uriAnnotation.UriCitation.Title}]({uriAnnotation.UriCitation.Uri})");
                    }
                }
            }
            Console.Write($"Agent response: {response}");
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
```C# Snippet:AgentsFabricAsync_Print
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
            string response = textItem.Text;
            if (textItem.Annotations != null)
            {
                foreach (MessageTextAnnotation annotation in textItem.Annotations)
                {
                    if (annotation is MessageTextUriCitationAnnotation uriAnnotation)
                    {
                        response = response.Replace(uriAnnotation.Text, $" [{uriAnnotation.UriCitation.Title}]({uriAnnotation.UriCitation.Uri})");
                    }
                }
            }
            Console.Write($"Agent response: {response}");
        }
        else if (contentItem is MessageImageFileContent imageFileItem)
        {
            Console.Write($"<image from ID: {imageFileItem.FileId}>");
        }
        Console.WriteLine();
    }
}
```

6. Clean up resources by deleting thread and agent.

Synchronous sample:
```C# Snippet:AgentsFabric_Cleanup
// NOTE: Comment out these two lines if you plan to reuse the agent later.
agentClient.Threads.DeleteThread(threadId: thread.Id);
agentClient.Administration.DeleteAgent(agentId: agent.Id);
```

Asynchronous sample:
```C# Snippet:AgentsFabricAsync_Cleanup
// NOTE: Comment out these two lines if you plan to reuse the agent later.
await agentClient.Threads.DeleteThreadAsync(threadId: thread.Id);
await agentClient.Administration.DeleteAgentAsync(agentId: agent.Id);
```
