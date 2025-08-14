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

// Enable debugging for System.ClientModel
EnableSystemClientModelDebugging();

// Create client with debugging enabled
AIProjectClient projectClient = CreateDebugClient(endpoint);

Console.WriteLine("List all deployments:");
foreach (AssetDeployment deployment in projectClient.Deployments.GetDeployments())
{
    Console.WriteLine(deployment);
}

Console.WriteLine($"List all deployments by the model publisher `{modelPublisher}`:");
foreach (AssetDeployment deployment in projectClient.Deployments.GetDeployments(modelPublisher: modelPublisher))
{
    Console.WriteLine(deployment);
}

Console.WriteLine($"Get a single model deployment named `{modelDeploymentName}`:");
ModelDeployment deploymentDetails = projectClient.Deployments.GetModelDeployment(modelDeploymentName);
Console.WriteLine(deploymentDetails);
```

## Asynchronous Sample

```C# Snippet:AI_Projects_DeploymentExampleAsync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("DEPLOYMENT_NAME");
var modelPublisher = System.Environment.GetEnvironmentVariable("MODEL_PUBLISHER");

// Enable debugging for System.ClientModel
EnableSystemClientModelDebugging();

// Create client with debugging enabled
AIProjectClient projectClient = CreateDebugClient(endpoint);

Console.WriteLine("List all deployments:");
await foreach (AssetDeployment deployment in projectClient.Deployments.GetDeploymentsAsync())
{
    Console.WriteLine(deployment);
}

Console.WriteLine($"List all deployments by the model publisher `{modelPublisher}`:");
await foreach (AssetDeployment deployment in projectClient.Deployments.GetDeploymentsAsync(modelPublisher: modelPublisher))
{
    Console.WriteLine(deployment);
}

Console.WriteLine($"Get a single model deployment named `{modelDeploymentName}`:");
ModelDeployment deploymentDetails = await projectClient.Deployments.GetModelDeploymentAsync(modelDeploymentName);
Console.WriteLine(deploymentDetails);
```
