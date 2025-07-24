# Sample using `Azure.AI.OpenAI` Chat Extension in Azure.AI.Projects

This sample demonstrates how to use the synchronous and asynchronous `Azure OpenAI` chat completion methods.

## Prerequisites

- Install the Azure.AI.Projects and Azure.AI.OpenAI package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `MODEL_DEPLOYMENT_NAME`: The name of the deployment to retrieve.
  - `CONNECTION_NAME`: (Optional) The name of the Azure OpenAI connection to use.

## Synchronous Sample

```C# Snippet:AI_Projects_AzureOpenAIChatSync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var connectionName = System.Environment.GetEnvironmentVariable("CONNECTION_NAME");
Console.WriteLine("Create the Azure OpenAI chat client");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
AzureOpenAIClient azureOpenAIClient = (AzureOpenAIClient)projectClient.GetOpenAIClient(connectionName: connectionName, apiVersion: null);
ChatClient chatClient = azureOpenAIClient.GetChatClient(deploymentName: modelDeploymentName);

Console.WriteLine("Complete a chat");
ChatCompletion result = chatClient.CompleteChat("List all the rainbow colors");
Console.WriteLine(result.Content[0].Text);
```

## Asynchronous Sample
```C# Snippet:AI_Projects_AzureOpenAIChatAsync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var connectionName = System.Environment.GetEnvironmentVariable("CONNECTION_NAME");
Console.WriteLine("Create the Azure OpenAI chat client");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
AzureOpenAIClient azureOpenAIClient = (AzureOpenAIClient)projectClient.GetOpenAIClient(connectionName: connectionName, apiVersion: null);
ChatClient chatClient = azureOpenAIClient.GetChatClient(deploymentName: modelDeploymentName);

Console.WriteLine("Complete a chat");
ChatCompletion result = await chatClient.CompleteChatAsync("List all the rainbow colors");
Console.WriteLine(result.Content[0].Text);
```
