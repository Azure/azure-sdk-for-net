# Sample using assistants with Azure AI Search tool in Azure.AI.Assistants.

Azure AI Search is an enterprise search system for high-performance applications.
It integrates with Azure OpenAI Service and Azure Machine Learning, offering advanced
search technologies like vector search and full-text search. Ideal for knowledge base
insights, information discovery, and automation. Creating an assistant with Azure AI
Search requires an existing Azure AI Search Index. For more information and setup
guides, see [Azure AI Search Tool Guide](https://learn.microsoft.com/azure/ai-services/agents/how-to/tools/azure-ai-search).
In this example we will use the existing Azure AI Search Index as a tool for an assistant.

1. First we need to create an assistant and project client and read the environment variables, which will be used in the next steps.
```C# Snippet:AssistantsAzureAISearchExample_CreateProjectClient
var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var projectClient = new AIProjectClient(connectionString, new DefaultAzureCredential());
```

2. Create an assistant with `AzureAISearchToolDefinition` and `ToolResources` with the only member `AzureAISearchResource` to be able to perform search. We will use `ConnectionsClient` to find the Azure AI Search resource.

Synchronous sample:
```C# Snippet:AssistantsCreateAgentWithAzureAISearchTool_Sync
ListConnectionsResponse connections = projectClient.GetConnectionsClient().GetConnections(ConnectionType.AzureAISearch);

if (connections?.Value == null || connections.Value.Count == 0)
{
    throw new InvalidOperationException("No connections found for the Azure AI Search.");
}

ConnectionResponse connection = connections.Value[0];
var connectionID = connection.Id;
AISearchIndexResource indexList = new(connectionID, "sample_index")
{
    QueryType = AzureAISearchQueryType.VectorSemanticHybrid
};
ToolResources searchResource = new ToolResources
{
    AzureAISearch = new AzureAISearchResource
    {
        IndexList = { indexList }
    }
};

AssistantsClient client = new(connectionString, new DefaultAzureCredential());

Assistant assistant = client.CreateAssistant(
   model: modelDeploymentName,
   name: "my-assistant",
   instructions: "You are a helpful assistant.",
   tools: [new AzureAISearchToolDefinition()],
   toolResources: searchResource);
```

Asynchronous sample:
```C# Snippet:AssistantsCreateAgentWithAzureAISearchTool
ListConnectionsResponse connections = await projectClient.GetConnectionsClient().GetConnectionsAsync(ConnectionType.AzureAISearch).ConfigureAwait(false);

if (connections?.Value == null || connections.Value.Count == 0)
{
    throw new InvalidOperationException("No connections found for the Azure AI Search.");
}

ConnectionResponse connection = connections.Value[0];

var connectionID = connection.Id;
AISearchIndexResource indexList = new(connectionID, "sample_index")
{
    QueryType = AzureAISearchQueryType.VectorSemanticHybrid
};
ToolResources searchResource = new ToolResources
{
    AzureAISearch = new AzureAISearchResource
    {
        IndexList = { indexList }
    }
};

AssistantsClient client = new(connectionString, new DefaultAzureCredential());

Assistant assistant = await client.CreateAssistantAsync(
   model: modelDeploymentName,
   name: "my-assistant",
   instructions: "You are a helpful assistant.",
   tools: [ new AzureAISearchToolDefinition() ],
   toolResources: searchResource);
```

3. Now we will create a `ThreadRun` and wait until it is complete. If the run will not be successful, we will print the last error.

Synchronous sample:
```C# Snippet:AssistantsAzureAISearchExample_CreateRun_Sync
// Create thread for communication
AssistantThread thread = client.CreateThread();

// Create message to thread
ThreadMessage message = client.CreateMessage(
    thread.Id,
    MessageRole.User,
    "What is the temperature rating of the cozynights sleeping bag?");

// Run the agent
Response<ThreadRun> runResponse = client.CreateRun(thread, assistant);

do
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    runResponse = client.GetRun(thread.Id, runResponse.Value.Id);
}
while (runResponse.Value.Status == RunStatus.Queued
    || runResponse.Value.Status == RunStatus.InProgress);

Assert.AreEqual(
    RunStatus.Completed,
    runResponse.Value.Status,
    runResponse.Value.LastError?.Message);
```

Asynchronous sample:
```C# Snippet:AssistantsAzureAISearchExample_CreateRun
// Create thread for communication
AssistantThread thread = await client.CreateThreadAsync();

// Create message to thread
ThreadMessage message = await client.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "What is the temperature rating of the cozynights sleeping bag?");

// Run the agent
ThreadRun run = await client.CreateRunAsync(thread, assistant);

do
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    run = await client.GetRunAsync(thread.Id, run.Id);
}
while (run.Status == RunStatus.Queued
    || run.Status == RunStatus.InProgress);

Assert.AreEqual(
    RunStatus.Completed,
    run.Status,
    run.LastError?.Message);
```

4. In our search we have used an index containing "embedding", "token", "url" and also "title" fields. This allowed us to get reference title and url. In the code below, we iterate messages in chronological order and replace the reference placeholders by url and title.

Synchronous sample:
```C# Snippet:AssistantsPopulateReferencesAgentWithAzureAISearchTool_Sync
PageableList<ThreadMessage> messages = client.GetMessages(
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
            // We need to annotate only Agent messages.
            if (threadMessage.Role == MessageRole.Assistant && textItem.Annotations.Count > 0)
            {
                string annotatedText = textItem.Text;
                foreach (MessageTextAnnotation annotation in textItem.Annotations)
                {
                    if (annotation is MessageTextUrlCitationAnnotation urlAnnotation)
                    {
                        annotatedText = annotatedText.Replace(
                            urlAnnotation.Text,
                            $" [see {urlAnnotation.UrlCitation.Title}] ({urlAnnotation.UrlCitation.Url})");
                    }
                }
                Console.Write(annotatedText);
            }
            else
            {
                Console.Write(textItem.Text);
            }
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
```C# Snippet:AssistantsPopulateReferencesAgentWithAzureAISearchTool
PageableList<ThreadMessage> messages = await client.GetMessagesAsync(
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
            // We need to annotate only Agent messages.
            if (threadMessage.Role == MessageRole.Assistant && textItem.Annotations.Count > 0)
            {
                string annotatedText = textItem.Text;
                foreach (MessageTextAnnotation annotation in textItem.Annotations)
                {
                    if (annotation is MessageTextUrlCitationAnnotation urlAnnotation)
                    {
                        annotatedText = annotatedText.Replace(
                            urlAnnotation.Text,
                            $" [see {urlAnnotation.UrlCitation.Title}] ({urlAnnotation.UrlCitation.Url})");
                    }
                }
                Console.Write(annotatedText);
            }
            else
            {
                Console.Write(textItem.Text);
            }
        }
        else if (contentItem is MessageImageFileContent imageFileItem)
        {
            Console.Write($"<image from ID: {imageFileItem.FileId}");
        }
        Console.WriteLine();
    }
}
```

5. Finally, we delete all the resources, we have created in this sample.

Synchronous sample:
```C# Snippet:AssistantsAzureAISearchExample_Cleanup_Sync
client.DeleteThread(thread.Id);
client.DeleteAssistant(assistant.Id);
```

Asynchronous sample:
```C# Snippet:AssistantsAzureAISearchExample_Cleanup
await client.DeleteThreadAsync(thread.Id);
await client.DeleteAssistantAsync(assistant.Id);
```
