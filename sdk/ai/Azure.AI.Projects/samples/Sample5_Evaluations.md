# Sample using `Evaluations` in Azure.AI.Projects

In this example, we will demonstrate creating, listing and retrieving evaluations using the `Evaluations` client in `Azure.AI.Projects`. This uses a Dataset as the input data for the evaluation and an Evaluator ID for the evaluation type.

## Prerequisites

- Install the Azure.AI.Projects package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `DATASET_NAME`: The name of the dataset to use as input data.

## Synchronous sample:
```C# Snippet:AI_Projects_EvaluationsExampleSync
Console.WriteLine("Create the Azure OpenAI chat client");
```

## Asynchronous sample:
```C# Snippet:AI_Projects_EvaluationsExampleAsync
Console.WriteLine("Create the Azure OpenAI chat client");
```
