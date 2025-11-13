# Sample on getting the responses without involving Agent in Azure.AI.Projects.OpenAI.

In this example we will demonstrate how to get a response without an Agent.

1. First, we need to project client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClient_ResponseBasic
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
ProjectOpenAIClient client = GetTestClient();
```

2. Use the client to create a `Responses`, which will be used to create `OpenAIResponse` object.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_Sync
OpenAIResponseClient responseClient = client.GetProjectOpenAIResponseClientForModel(modelDeploymentName);
OpenAIResponse response = responseClient.CreateResponse("What is the size of France in square miles?");
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_Async
OpenAIResponseClient responseClient = client.GetProjectOpenAIResponseClientForModel(modelDeploymentName);
OpenAIResponse response = await responseClient.CreateResponseAsync("What is the size of France in square miles?");
```

3. Wait for request to complete; raise the error if the request was not successful.

Synchronous sample:
```C# Snippet:Sample_WriteOutput_ResponseBasic_Sync
while (response.Status != ResponseStatus.Incomplete || response.Status != ResponseStatus.Failed || response.Status != ResponseStatus.Completed)
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    response = responseClient.GetResponse(responseId: response.Id);
}

Console.WriteLine(response.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_WriteOutput_ResponseBasic_Async
while (response.Status != ResponseStatus.Incomplete || response.Status != ResponseStatus.Failed || response.Status != ResponseStatus.Completed)
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    response = await responseClient.GetResponseAsync(responseId: response.Id);
}

Console.WriteLine(response.GetOutputText());
```
