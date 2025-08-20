# Sample using `Chat Completion` in Azure.AI.Projects

This sample demonstrates how to use the synchronous and asynchronous `GetChatCompletionsClient()` method.

## Prerequisites

- Install the Azure.AI.Projects package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `MODEL_DEPLOYMENT_NAME`: The name of the deployment to retrieve.

## Synchronous Sample

```C# Snippet:AI_Projects_ChatClientSync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient client = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
ChatCompletionsClient chatClient = client.GetChatCompletionsClient();

var requestOptions = new ChatCompletionsOptions()
{
    Messages =
        {
            new ChatRequestSystemMessage("You are a helpful assistant."),
            new ChatRequestUserMessage("How many feet are in a mile?"),
        },
    Model = modelDeploymentName
};
Response<ChatCompletions> response = chatClient.Complete(requestOptions);
Console.WriteLine(response.Value.Content);
```
## Asynchronous Sample

```C# Snippet:AI_Projects_ChatClientAsync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient client = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
ChatCompletionsClient chatClient = client.GetChatCompletionsClient();

var requestOptions = new ChatCompletionsOptions()
{
    Messages =
        {
            new ChatRequestSystemMessage("You are a helpful assistant."),
            new ChatRequestUserMessage("How many feet are in a mile?"),
        },
    Model = modelDeploymentName
};
Response<ChatCompletions> response = await chatClient.CompleteAsync(requestOptions);
Console.WriteLine(response.Value.Content);
```
