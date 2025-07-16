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
Console.WriteLine("Create the Azure OpenAI chat client");
```

## Asynchronous Sample
```C# Snippet:AI_Projects_AzureOpenAIChatAsync
Console.WriteLine("Create the Azure OpenAI chat client");
```
