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

AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());

Console.WriteLine("List all deployments:");
foreach (AIProjectDeployment deployment in projectClient.Deployments.GetDeployments())
{
    Console.WriteLine(deployment);
}

Console.WriteLine($"List all deployments by the model publisher `{modelPublisher}`:");
foreach (AIProjectDeployment deployment in projectClient.Deployments.GetDeployments(modelPublisher: modelPublisher))
{
    Console.WriteLine(deployment);
}

Console.WriteLine($"Get a single model deployment named `{modelDeploymentName}`:");
ModelDeployment deploymentDetails = (ModelDeployment)projectClient.Deployments.GetDeployment(modelDeploymentName);
Console.WriteLine(deploymentDetails);
```

## Asynchronous Sample

```C# Snippet:AI_Projects_DeploymentExampleAsync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var modelPublisher = System.Environment.GetEnvironmentVariable("MODEL_PUBLISHER");

AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());

Console.WriteLine("List all deployments:");
await foreach (AIProjectDeployment deployment in projectClient.Deployments.GetDeploymentsAsync())
{
    Console.WriteLine(deployment);
}

Console.WriteLine($"List all deployments by the model publisher `{modelPublisher}`:");
await foreach (AIProjectDeployment deployment in projectClient.Deployments.GetDeploymentsAsync(modelPublisher: modelPublisher))
{
    Console.WriteLine(deployment);
}

Console.WriteLine($"Get a single model deployment named `{modelDeploymentName}`:");
ModelDeployment deploymentDetails = (ModelDeployment)await projectClient.Deployments.GetDeploymentAsync(modelDeploymentName);
Console.WriteLine(deploymentDetails);
```
