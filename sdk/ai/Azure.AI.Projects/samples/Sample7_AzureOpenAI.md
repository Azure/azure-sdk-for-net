# Sample using `Azure.AI.OpenAI` Extension in Azure.AI.Projects

This sample demonstrates how to use the synchronous and asynchronous `Azure OpenAI` methods.

## Prerequisites

- Install the Azure.AI.Projects and Azure.AI.OpenAI package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `MODEL_DEPLOYMENT_NAME`: The name of the deployment to retrieve.

## Synchronous Sample

```C# Snippet:AI_Projects_AzureOpenAISync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
ChatClient chatClient = projectClient.GetAzureOpenAIChatClient(deploymentName: modelDeploymentName, connectionName: null, apiVersion: null);

ChatCompletion result = chatClient.CompleteChat("List all the rainbow colors");
Console.WriteLine(result.Content[0].Text);
```

## Asynchronous Sample
```C# Snippet:AI_Projects_AzureOpenAIAsync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
ChatClient chatClient = projectClient.GetAzureOpenAIChatClient(deploymentName: modelDeploymentName, connectionName: null, apiVersion: null);

ChatCompletion result = await chatClient.CompleteChatAsync("List all the rainbow colors");
Console.WriteLine(result.Content[0].Text);
```
