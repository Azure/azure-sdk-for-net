# Sample on getting the responses in Azure.AI.Projects.OpenAI in streaming scenarios.

In this example we will demonstrate how to get a responsein streaming scenarios.

1. First, we need to create project client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClient_ResponseStreaming
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");

ProjectOpenAIClient client = new(projectEndpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. Use the client to create a `ProjectOpenAIResponseClient`, which will be used to create stream.

Synchronous sample:
```C# Snippet:Sample_CreateResponseStreaming
ProjectOpenAIResponseClient responsesClient = client.GetProjectOpenAIResponseClientForModel(modelDeploymentName);
```

3. Stream the results; raise the error if the request was not successful.

Synchronous sample:
```C# Snippet:Sample_WriteOutput_ResponseStreaming_Sync
foreach (StreamingResponseUpdate streamResponse in responsesClient.CreateResponseStreaming("What is the size of France in square miles?"))
{
    if (streamResponse is StreamingResponseCreatedUpdate createUpdate)
    {
        Console.WriteLine($"Stream response created with ID: {createUpdate.Response.Id}");
    }
    else if (streamResponse is StreamingResponseOutputTextDeltaUpdate textDelta)
    {
        Console.WriteLine($"Delta: {textDelta.Delta}");
    }
    else if (streamResponse is StreamingResponseOutputTextDoneUpdate textDoneUpdate)
    {
        Console.WriteLine($"Response done with full message: {textDoneUpdate.Text}");
    }
    else if (streamResponse is StreamingResponseErrorUpdate errorUpdate)
    {
        throw new InvalidOperationException($"The stream has failed with the error: {errorUpdate.Message}");
    }
}
```

Asynchronous sample:
```C# Snippet:Sample_WriteOutput_ResponseStreaming_Async
await foreach (StreamingResponseUpdate streamResponse in responsesClient.CreateResponseStreamingAsync("What is the size of France in square miles?"))
{
    if (streamResponse is StreamingResponseCreatedUpdate createUpdate)
    {
        Console.WriteLine($"Stream response created with ID: {createUpdate.Response.Id}");
    }
    else if (streamResponse is StreamingResponseOutputTextDeltaUpdate textDelta)
    {
        Console.WriteLine($"Delta: {textDelta.Delta}");
    }
    else if (streamResponse is StreamingResponseOutputTextDoneUpdate textDoneUpdate)
    {
        Console.WriteLine($"Response done with full message: {textDoneUpdate.Text}");
    }
    else if (streamResponse is StreamingResponseErrorUpdate errorUpdate)
    {
        throw new InvalidOperationException($"The stream has failed with the error: {errorUpdate.Message}");
    }
}
```
