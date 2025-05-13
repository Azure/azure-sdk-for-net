# Sample for Azure.AI.Projects with AzureOpenAI chat extension.

If `Azure.AI.Openai` package is installed, the project can use AzureOpenAI extension.

## Prerequisites

- Install the Azure.AI.Projects package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `MODEL_DEPLOYMENT_NAME`: The name of the model deployment to use against your endpoint.

## Agent extensions

Synchronous sample: 
```C# Snippet:AzureOpenAISync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
ChatClient chatClient = projectClient.GetAzureOpenAIChatClient(modelDeploymentName);

ChatCompletion result = chatClient.CompleteChat("List all the rainbow colors");
Console.WriteLine(result.Content[0].Text);
```

Asynchronous sample:
```C# Snippet:AzureOpenAIAsync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
ChatClient chatClient = projectClient.GetAzureOpenAIChatClient(modelDeploymentName);

ChatCompletion result = await chatClient.CompleteChatAsync("List all the rainbow colors");
Console.WriteLine(result.Content[0].Text);
```
