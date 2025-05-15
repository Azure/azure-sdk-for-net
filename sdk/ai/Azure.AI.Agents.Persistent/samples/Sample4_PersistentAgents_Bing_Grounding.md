# Sample for use of an agent with Bing grounding in Azure.AI.Agents.Persistent.

To enable your Agent to perform search through Bing search API, you use `BingGroundingToolDefinition` along with a connection.
1. First we need to create an agent client and read the environment variables, which will be used in the next steps.

```C# Snippet:AgentsBingGrounding_CreateProject
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var connectionId = System.Environment.GetEnvironmentVariable("AZURE_BING_CONECTION_ID");
PersistentAgentsClient agentClient = new(projectEndpoint, new DefaultAzureCredential());
```

2. We will use the Bing connection ID to initialize the `BingGroundingToolDefinition`.

```C# Snippet:AgentsBingGrounding_GetConnection
BingGroundingSearchConfigurationList configurationList = new(
    [new BingGroundingSearchConfiguration(connectionId)]
);
BingGroundingToolDefinition bingGroundingTool = new(configurationList);
```

3. We will use the `BingGroundingToolDefinition` during the agent initialization.

Synchronous sample:
```C# Snippet:AgentsBingGrounding_CreateAgent
PersistentAgent agent = agentClient.Administration.CreateAgent(
   model: modelDeploymentName,
   name: "my-agent",
   instructions: "You are a helpful agent.",
   tools: [bingGroundingTool]);
```

Asynchronous sample:
```C# Snippet:AgentsBingGroundingAsync_CreateAgent
PersistentAgent agent = await agentClient.Administration.CreateAgentAsync(
   model: modelDeploymentName,
   name: "my-agent",
   instructions: "You are a helpful agent.",
   tools: [ bingGroundingTool ]);
```

4. Now we will create the thread, add the message , containing a question for agent and start the run.

Synchronous sample:
```C# Snippet:AgentsBingGrounding_CreateThreadMessage
PersistentAgentThread thread = agentClient.Threads.CreateThread();

// Create message to thread
PersistentThreadMessage message = agentClient.Messages.CreateMessage(
    thread.Id,
    MessageRole.User,
    "How does wikipedia explain Euler's Identity?");

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
```C# Snippet:AgentsBingGroundingAsync_CreateThreadMessage
PersistentAgentThread thread = await agentClient.Threads.CreateThreadAsync();

// Create message to thread
PersistentThreadMessage message = await agentClient.Messages.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "How does wikipedia explain Euler's Identity?");

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
```C# Snippet:AgentsBingGrounding_Print
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
            Console.Write($"<image from ID: {imageFileItem.FileId}");
        }
        Console.WriteLine();
    }
}
```

Asynchronous sample:
```C# Snippet:AgentsBingGroundingAsync_Print
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
            Console.Write($"<image from ID: {imageFileItem.FileId}");
        }
        Console.WriteLine();
    }
}
```

6. Clean up resources by deleting thread and agent.

Synchronous sample:
```C# Snippet:AgentsBingGroundingCleanup
agentClient.Threads.DeleteThread(threadId: thread.Id);
agentClient.Administration.DeleteAgent(agentId: agent.Id);
```

Asynchronous sample:
```C# Snippet:AgentsBingGroundingCleanupAsync
await agentClient.Threads.DeleteThreadAsync(threadId: thread.Id);
await agentClient.Administration.DeleteAgentAsync(agentId: agent.Id);
```
