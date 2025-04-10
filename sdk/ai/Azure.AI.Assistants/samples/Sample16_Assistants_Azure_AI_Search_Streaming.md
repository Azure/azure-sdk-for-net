# Sample using assistants with Azure AI Search tool with streaming in Azure.AI.Assistants.

Azure AI Search is an enterprise search system for high-performance applications.
It integrates with Azure OpenAI Service and Azure Machine Learning, offering advanced
search technologies like vector search and full-text search. Ideal for knowledge base
insights, information discovery, and automation. Creating an assistant with Azure AI
Search requires an existing Azure AI Search Index. For more information and setup
guides, see [Azure AI Search Tool Guide](https://learn.microsoft.com/azure/ai-services/agents/how-to/tools/azure-ai-search).
In this example we will use the existing Azure AI Search Index as a tool for an assistant in streaming scenario.

1. First we need to create an assistant and read the environment variables, which will be used in the next steps.
```C# Snippet:AssistantsAzureAISearchStreamingExample_CreateProjectClient
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var connectionID = System.Environment.GetEnvironmentVariable("AZURE_AI_CONNECTION_ID");
```

2. Create an assistant with `AzureAISearchToolDefinition` and `ToolResources` with the only member `AzureAISearchResource` to be able to perform search. We will use `connectionID` to get the Azure AI Search resource.

Synchronous sample:
```C# Snippet:AssistantsAzureAISearchStreamingExample_CreateTool
AzureAISearchResource searchResource = new(
    connectionID,
    "sample_index",
    5,
    "category eq 'sleeping bag'",
    AzureAISearchQueryType.Simple
);
ToolResources toolResource = new()
{
    AzureAISearch = searchResource
};

AssistantsClient client = new(projectEndpoint, new DefaultAzureCredential());

Assistant assistant = client.CreateAssistant(
   model: modelDeploymentName,
   name: "my-assistant",
   instructions: "You are a helpful assistant.",
   tools: [new AzureAISearchToolDefinition()],
   toolResources: toolResource);
```

Asynchronous sample:
```C# Snippet:AssistantsAzureAISearchStreamingExample_CreateTool_Async
AzureAISearchResource searchResource = new(
    connectionID,
    "sample_index",
    5,
    "category eq 'sleeping bag'",
    AzureAISearchQueryType.Simple
);
ToolResources toolResource = new()
{
    AzureAISearch = searchResource
};

AssistantsClient client = new(projectEndpoint, new DefaultAzureCredential());

Assistant assistant = await client.CreateAssistantAsync(
   model: modelDeploymentName,
   name: "my-assistant",
   instructions: "You are a helpful assistant.",
   tools: [ new AzureAISearchToolDefinition() ],
   toolResources: toolResource);
```

3. Now we will create a `ThreadRun`.

Synchronous sample:
```C# Snippet:AssistantsAzureAISearchStreamingExample_CreateThread
// Create thread for communication
AssistantThread thread = client.CreateThread();

// Create message to thread
ThreadMessage message = client.CreateMessage(
    thread.Id,
    MessageRole.User,
    "What is the temperature rating of the cozynights sleeping bag?");
```

Asynchronous sample:
```C# Snippet:AssistantsAzureAISearchStreamingExample_CreateThread_Async
// Create thread for communication
AssistantThread thread = await client.CreateThreadAsync();

// Create message to thread
ThreadMessage message = await client.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "What is the temperature rating of the cozynights sleeping bag?");
```

4. In our search we have used an index containing "embedding", "token", "category" and also "title" fields. This allowed us to get reference title and url. In the code below, we iterate messages in chronological order and replace the reference placeholders by url and title.

Synchronous sample:
```C# Snippet:AssistantsAzureAISearchStreamingExample_PrintMessages
foreach (StreamingUpdate streamingUpdate in client.CreateRunStreaming(thread.Id, assistant.Id))
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
```C# Snippet:AssistantsAzureAISearchStreamingExample_PrintMessages_Async
await foreach (StreamingUpdate streamingUpdate in client.CreateRunStreamingAsync(thread.Id, assistant.Id))
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
```C# Snippet:AssistantsAzureAISearchStreamingExample_Cleanup
client.DeleteThread(thread.Id);
client.DeleteAssistant(assistant.Id);
```

Asynchronous sample:
```C# Snippet:AssistantsAzureAISearchStreamingExample_Cleanup_Async
await client.DeleteThreadAsync(thread.Id);
await client.DeleteAssistantAsync(assistant.Id);
```
