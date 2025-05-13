# Sample using agents with Azure AI Search tool with streaming in Azure.AI.Projects.

Azure AI Search is an enterprise search system for high-performance applications.
It integrates with Azure OpenAI Service and Azure Machine Learning, offering advanced
search technologies like vector search and full-text search. Ideal for knowledge base
insights, information discovery, and automation. Creating an Agent with Azure AI
Search requires an existing Azure AI Search Index. For more information and setup
guides, see [Azure AI Search Tool Guide](https://learn.microsoft.com/azure/ai-services/agents/how-to/tools/azure-ai-search).
In this example we will use the existing Azure AI Search Index as a tool for an agent in streaming scenario.

1. First we need to create project client and read the environment variables, which will be used in the next steps.
```C# Snippet:AzureAISearchStreamingExample_CreateProjectClient
var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var projectClient = new AIProjectClient(connectionString, new DefaultAzureCredential());
```

2. Create an agent with `AzureAISearchToolDefinition` and `ToolResources` with the only member `AzureAISearchResource` to be able to perform search. We will use `ConnectionsClient` to find the Azure AI Search resource.

Synchronous sample:
```C# Snippet:AzureAISearchStreamingExample_CreateTool
ListConnectionsResponse connections = projectClient.GetConnectionsClient().GetConnections(ConnectionType.AzureAISearch);

if (connections?.Value == null || connections.Value.Count == 0)
{
    throw new InvalidOperationException("No connections found for the Azure AI Search.");
}

ConnectionResponse connection = connections.Value[0];

AzureAISearchResource searchResource = new(
    connection.Id,
    "sample_index",
    5,
    "category eq 'sleeping bag'",
    AzureAISearchQueryType.Simple
);
ToolResources toolResource = new()
{
    AzureAISearch = searchResource
};

AgentsClient agentClient = projectClient.GetAgentsClient();

Agent agent = agentClient.CreateAgent(
   model: modelDeploymentName,
   name: "my-assistant",
   instructions: "You are a helpful assistant.",
   tools: [new AzureAISearchToolDefinition()],
   toolResources: toolResource);
```

Asynchronous sample:
```C# Snippet:AzureAISearchStreamingExample_CreateTool_Async
ListConnectionsResponse connections = await projectClient.GetConnectionsClient().GetConnectionsAsync(ConnectionType.AzureAISearch).ConfigureAwait(false);

if (connections?.Value == null || connections.Value.Count == 0)
{
    throw new InvalidOperationException("No connections found for the Azure AI Search.");
}

ConnectionResponse connection = connections.Value[0];

AzureAISearchResource searchResource = new(
    connection.Id,
    "sample_index",
    5,
    "category eq 'sleeping bag'",
    AzureAISearchQueryType.Simple
);
ToolResources toolResource = new()
{
    AzureAISearch = searchResource
};

AgentsClient agentClient = projectClient.GetAgentsClient();

Agent agent = await agentClient.CreateAgentAsync(
   model: modelDeploymentName,
   name: "my-assistant",
   instructions: "You are a helpful assistant.",
   tools: [new AzureAISearchToolDefinition()],
   toolResources: toolResource);
```

3. Now we will create a `ThreadRun`.

Synchronous sample:
```C# Snippet:AzureAISearchStreamingExample_CreateThread
// Create thread for communication
AgentThread thread = agentClient.CreateThread();

// Create message to thread
ThreadMessage message = agentClient.CreateMessage(
    thread.Id,
    MessageRole.User,
    "What is the temperature rating of the cozynights sleeping bag?");
```

Asynchronous sample:
```C# Snippet:AzureAISearchStreamingExample_CreateThread_Async
// Create thread for communication
AgentThread thread = await agentClient.CreateThreadAsync();

// Create message to thread
ThreadMessage message = await agentClient.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "What is the temperature rating of the cozynights sleeping bag?");
```

4. In our search we have used an index containing "embedding", "token", "category" and also "title" fields. This allowed us to get reference title and url. In the code below, we iterate messages in chronological order and replace the reference placeholders by url and title.

Synchronous sample:
```C# Snippet:AzureAISearchStreamingExample_PrintMessages
foreach (StreamingUpdate streamingUpdate in agentClient.CreateRunStreaming(thread.Id, agent.Id))
{
    if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
    {
        Console.WriteLine("--- Run started! ---");
    }
    else if (streamingUpdate is MessageContentUpdate contentUpdate)
    {
        if (contentUpdate.TextAnnotation != null)
        {
            Console.Write($" [see {contentUpdate.TextAnnotation.Title}] ({contentUpdate.TextAnnotation.Url})");
        }
        else
        {
            //Detect the reference placeholder and skip it. Instead we will print the actual reference.
            if (contentUpdate.Text[0] != (char)12304 || contentUpdate.Text[contentUpdate.Text.Length - 1] != (char)12305)
                Console.Write(contentUpdate.Text);
        }
    }
    else if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCompleted)
    {
        Console.WriteLine();
        Console.WriteLine("--- Run completed! ---");
    }
}
```

Asynchronous sample:
```C# Snippet:AzureAISearchStreamingExample_PrintMessages_Async
await foreach (StreamingUpdate streamingUpdate in agentClient.CreateRunStreamingAsync(thread.Id, agent.Id))
{
    if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
    {
        Console.WriteLine("--- Run started! ---");
    }
    else if (streamingUpdate is MessageContentUpdate contentUpdate)
    {
        if (contentUpdate.TextAnnotation != null)
        {
            Console.Write($" [see {contentUpdate.TextAnnotation.Title}] ({contentUpdate.TextAnnotation.Url})");
        }
        else
        {
            //Detect the reference placeholder and skip it. Instead we will print the actual reference.
            if (contentUpdate.Text[0] != (char)12304 || contentUpdate.Text[contentUpdate.Text.Length - 1] != (char)12305)
                Console.Write(contentUpdate.Text);
        }
    }
    else if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCompleted)
    {
        Console.WriteLine();
        Console.WriteLine("--- Run completed! ---");
    }
}
```

5. Finally, we delete all the resources, we have created in this sample.

Synchronous sample:
```C# Snippet:AzureAISearchStreamingExample_Cleanup
agentClient.DeleteThread(thread.Id);
agentClient.DeleteAgent(agent.Id);
```

Asynchronous sample:
```C# Snippet:AzureAISearchStreamingExample_Cleanup_Async
await agentClient.DeleteThreadAsync(thread.Id);
await agentClient.DeleteAgentAsync(agent.Id);
```
