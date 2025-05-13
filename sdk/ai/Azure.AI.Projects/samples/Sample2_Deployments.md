# Sample using Deployments in Azure.AI.Projects

This sample demonstrates how to use the synchronous and asynchronous `.deployments` methods to enumerate AI models deployed to your AI Foundry Project.

## Prerequisites

- Install the Azure.AI.Projects package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `DEPLOYMENT_NAME`: The name of the deployment to retrieve.
  - `MODEL_PUBLISHER`: The publisher of the model to filter by.

## Synchronous Sample

```csharp Snippet:DeploymentExampleSync
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var deploymentName = Environment.GetEnvironmentVariable("DEPLOYMENT_NAME");
var modelPublisher = Environment.GetEnvironmentVariable("MODEL_PUBLISHER");

var credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("PROJECT_API_KEY"));
var projectClient = new AIProjectClient(endpoint, credential);

Console.WriteLine("List all deployments:");
foreach (var deployment in projectClient.Deployments.List())
{
    Console.WriteLine(deployment);
}

Console.WriteLine($"List all deployments by the model publisher `{modelPublisher}`:");
foreach (var deployment in projectClient.Deployments.List(modelPublisher: modelPublisher))
{
    Console.WriteLine(deployment);
}

Console.WriteLine($"Get a single deployment named `{deploymentName}`:");
var deploymentDetails = projectClient.Deployments.Get(deploymentName);
Console.WriteLine(deploymentDetails);
```

## Asynchronous Sample

```csharp Snippet:DeploymentExampleAsync
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var deploymentName = Environment.GetEnvironmentVariable("DEPLOYMENT_NAME");
var modelPublisher = Environment.GetEnvironmentVariable("MODEL_PUBLISHER");

var credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("PROJECT_API_KEY"));
var projectClient = new AIProjectClient(endpoint, credential);

Console.WriteLine("List all deployments:");
await foreach (var deployment in projectClient.Deployments.ListAsync())
{
    Console.WriteLine(deployment);
}

Console.WriteLine($"List all deployments by the model publisher `{modelPublisher}`:");
await foreach (var deployment in projectClient.Deployments.ListAsync(modelPublisher: modelPublisher))
{
    Console.WriteLine(deployment);
}

Console.WriteLine($"Get a single deployment named `{deploymentName}`:");
var deploymentDetails = await projectClient.Deployments.GetAsync(deploymentName);
Console.WriteLine(deploymentDetails);
```
