# Sample on getting the responses without involving Agent in Azure.AI.Projects.OpenAI.

In this example we will demonstrate how to get a response without an Agent.

1. First, we need to project client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClient_ResponseBasic
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. Use the client to create a `ProjectResponsesClient`, which will be used to create `ResponseResult` object.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_Sync
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForModel(modelDeploymentName);
ResponseResult response = responseClient.CreateResponse("What is the size of France in square miles?");
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_Async
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForModel(modelDeploymentName);
ResponseResult response = await responseClient.CreateResponseAsync("What is the size of France in square miles?");
```

3. Write the response output, raise the error if the request was not successful.

Synchronous sample:
```C# Snippet:Sample_WriteOutput_ResponseBasic_Sync
Console.WriteLine(response.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_WriteOutput_ResponseBasic_Async
Console.WriteLine(response.GetOutputText());
```
