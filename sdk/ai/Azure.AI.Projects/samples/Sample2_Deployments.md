# Sample using Deployments in Azure.AI.Projects

This sample demonstrates how to use the synchronous and asynchronous `.deployments` methods to enumerate AI models deployed to your AI Foundry Project.

## Prerequisites

- Install the Azure.AI.Projects package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `DEPLOYMENT_NAME`: The name of the deployment to retrieve.
  - `MODEL_PUBLISHER`: The publisher of the model to filter by.

## Synchronous Sample

```C# Snippet:AI_Projects_DeploymentExampleSync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var modelPublisher = System.Environment.GetEnvironmentVariable("MODEL_PUBLISHER");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
Deployments deployments = projectClient.GetDeploymentsClient();

Console.WriteLine("List all deployments:");
foreach (var deployment in deployments.GetDeployments())
{
    Console.WriteLine(deployment);
}

Console.WriteLine($"List all deployments by the model publisher `{modelPublisher}`:");
foreach (var deployment in deployments.GetDeployments(modelPublisher: modelPublisher))
{
    Console.WriteLine(deployment);
}

Console.WriteLine($"Get a single deployment named `{modelDeploymentName}`:");
var deploymentDetails = deployments.GetDeployment(modelDeploymentName);
Console.WriteLine(deploymentDetails);
```

## Asynchronous Sample

```C# Snippet:AI_Projects_DeploymentExampleAsync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("DEPLOYMENT_NAME");
var modelPublisher = System.Environment.GetEnvironmentVariable("MODEL_PUBLISHER");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
Deployments deployments = projectClient.GetDeploymentsClient();

Console.WriteLine("List all deployments:");
await foreach (var deployment in deployments.GetDeploymentsAsync())
{
    Console.WriteLine(deployment);
}

Console.WriteLine($"List all deployments by the model publisher `{modelPublisher}`:");
await foreach (var deployment in deployments.GetDeploymentsAsync(modelPublisher: modelPublisher))
{
    Console.WriteLine(deployment);
}

Console.WriteLine($"Get a single deployment named `{modelDeploymentName}`:");
var deploymentDetails = deployments.GetDeploymentAsync(modelDeploymentName);
Console.WriteLine(deploymentDetails);
```
