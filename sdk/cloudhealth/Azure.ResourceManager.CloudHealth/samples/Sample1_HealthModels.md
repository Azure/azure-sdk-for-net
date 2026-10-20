# Azure Monitor Health Models samples for .NET

These samples demonstrate how to use the `Azure.ResourceManager.CloudHealth` library to:

- [Create a health model](#create-a-health-model).
- [Create an entity in a health model and connect it to the root entity](#create-an-entity-in-a-health-model).
- [Push health status to an entity](#push-health-status-to-an-entity).
- [Get an entity's health](#get-an-entitys-health).

Run the samples in order, using the model ID from the first sample in the second, and the entity ID from the second sample in both the third and fourth. You can also use an existing health model or entity.

## Getting started

### Prerequisites

- An Azure subscription and an existing resource group.
- The `Microsoft.CloudHealth` resource provider registered for the subscription, and a region where the service is available. Ask a subscription administrator to register the provider if needed. Registration requires `Microsoft.CloudHealth/register/action` at subscription scope, for example through Contributor or Owner on the subscription; Contributor scoped only to a resource group cannot register a provider.
- Permission to create health models, entities, and relationships and submit health reports, such as Contributor scoped to the resource group. Reading entity health requires read access, such as Reader on the entity, health model, or resource group.
- A .NET SDK. Using a local project reference also requires the repository's [development prerequisites](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md).

### Install the packages

Create a console application and install Azure Identity:

```dotnetcli
dotnet new console --name HealthModelsSample
cd HealthModelsSample
dotnet add package Azure.Identity
```

These samples target the API in this source checkout. Before version 1.0.0 is published to NuGet, reference the local management library project from your console application. Replace `/path/to/azure-sdk-for-net` with the path to this repository:

```dotnetcli
dotnet add reference /path/to/azure-sdk-for-net/sdk/cloudhealth/Azure.ResourceManager.CloudHealth/src/Azure.ResourceManager.CloudHealth.csproj
```

After version 1.0.0 is published, you can install it instead of adding the project reference:

```dotnetcli
dotnet add package Azure.ResourceManager.CloudHealth --version 1.0.0
```

Replace the contents of `Program.cs` with the [shared namespaces](#namespaces) below followed by **one scenario's code block at a time**, as top-level statements. Replace the placeholder subscription, resource group, region, and resource IDs. Each scenario creates its own client; do not paste all four blocks into the same top-level scope. Run the console application with `dotnet run` only when you intend to create or access live Azure resources.

### Authenticate the client

The samples create an `ArmClient` with `DefaultAzureCredential` from the `Azure.Identity` package. For local development, sign in to Azure using a supported developer tool, such as the Azure CLI:

```azurecli
az login
```

The signed-in identity must have the permissions listed above on the target subscription and resources. Authentication does not grant authorization.

### Namespaces

Copy these imports before any one of the scenario blocks. Together they form a standalone `Program.cs` in the console application created above.

```csharp
using System;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.CloudHealth;
using Azure.ResourceManager.CloudHealth.Models;
using Azure.ResourceManager.Resources;
```

## Create a health model

This sample demonstrates how to create a health model in an existing resource group. The model will contain the health configuration for a checkout application.

Use `ArmClient` to get the resource group, then create the model through its health model collection.

```csharp
const string subscriptionId = "<subscription-id>";
const string resourceGroupName = "<existing-resource-group>";
const string location = "<enabled-region>";

var client = new ArmClient(new DefaultAzureCredential(), subscriptionId);
var resourceGroup = client.GetResourceGroupResource(
    ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName));
var modelName = $"checkout-{Guid.NewGuid():N}";

var model = (await resourceGroup.GetHealthModels().CreateOrUpdateAsync(
    WaitUntil.Completed,
    modelName,
    new HealthModelData(new AzureLocation(location)))).Value;

Console.WriteLine($"Health model ID: {model.Id}");
```

`WaitUntil.Completed` waits for resource provisioning, not for application health evaluation. Save the model ID for the next sample.

## Create an entity in a health model

This sample demonstrates how to create an entity representing the checkout API and connect it to the model's root entity. Entities represent the application components whose health you want to monitor.

Replace the model ID below with the ID from the previous sample, then create the entity and relationship through the model's collections. The root entity is created automatically with the health model and has the same resource name as the model, so the relationship uses `model.Id.Name` for its parent.

The root entity is initially positioned at `(0, 0)`. Set `CanvasPosition` to place the child at `(0, 200)`. Use distinct coordinates for additional entities, and adjust them if you move the root.

```csharp
var modelId = new ResourceIdentifier(
    "/subscriptions/<subscription-id>/resourceGroups/<resource-group>/providers/Microsoft.CloudHealth/healthmodels/<model-name>");
var client = new ArmClient(new DefaultAzureCredential(), modelId.SubscriptionId);
var model = client.GetHealthModelResource(modelId);
var entityName = $"checkout-api-{Guid.NewGuid():N}";

var entity = (await model.GetHealthModelEntities().CreateOrUpdateAsync(
    WaitUntil.Completed,
    entityName,
    new HealthModelEntityData
    {
        Properties = new HealthModelEntityProperties
        {
            DisplayName = "Checkout API",
            CanvasPosition = new EntityCoordinates(0, 200)
        }
    })).Value;

var relationship = (await model.GetHealthModelRelationships().CreateOrUpdateAsync(
    WaitUntil.Completed,
    $"root-to-{entityName}",
    new HealthModelRelationshipData
    {
        Properties = new HealthModelRelationshipProperties(
            parentEntityName: model.Id.Name,
            childEntityName: entityName)
    })).Value;

Console.WriteLine($"Entity ID: {entity.Id}");
Console.WriteLine($"Relationship ID: {relationship.Id}");
```

Save the entity ID for the next two samples. The relationship connects the checkout API to the root entity so its health can roll up to the model. Creating an entity and relationship does not configure monitoring signals. `WaitUntil.Completed` waits for provisioning, not health evaluation.

## Push health status to an entity

This sample demonstrates how to submit an externally evaluated health status to an entity. Replace the entity ID below with the ID from the entity creation sample.

Use `IngestHealthReportAsync` to submit a report for a named external signal. The entity must already exist, but the service creates the external signal if it does not exist. This sample sends a demonstration `Healthy` status; replace it with the result of your application's health check.

> **Signal types:** Health models support Azure resource metrics, Log Analytics (KQL) queries, Azure Monitor workspace (PromQL) queries, Azure Resource Health, external health reports, and dependency signals that aggregate child-entity health. This sample uses an external health report. See [Signal types](https://learn.microsoft.com/azure/azure-monitor/health-models/signals#signal-types) for details.

```csharp
var entityId = new ResourceIdentifier(
    "/subscriptions/<subscription-id>/resourceGroups/<resource-group>/providers/Microsoft.CloudHealth/healthmodels/<model-name>/entities/<entity-name>");
var client = new ArmClient(new DefaultAzureCredential(), entityId.SubscriptionId);
var entity = client.GetHealthModelEntityResource(entityId);

var report = new EntityHealthReportContent(
    signalName: "checkout-api-probe",
    healthState: EntityHealthState.Healthy)
{
    ExpiresInMinutes = 15,
    AdditionalContext = "Demonstration checkout API health check result."
};

await entity.IngestHealthReportAsync(report);

Console.WriteLine($"Entity ID: {entity.Id}");
Console.WriteLine($"Submitted {report.HealthState} for signal '{report.SignalName}'.");
```

Reports can contain `Healthy`, `Degraded`, `Unhealthy`, or `Unknown`. Submit another report with the same signal name to update its status, and refresh it before the 15-minute expiry while your health check continues to run. An expired or missing report is not evidence of a healthy component.

Report ingestion does not wait for entity health evaluation. Allow time for the service to evaluate signals; the entity's overall health can also reflect other configured signals.

## Get an entity's health

This sample demonstrates how to get an entity and read its current health state.

Replace the entity ID below with the same ID used to push health status. You can also use an existing monitored entity to view health based on its configured signals.

```csharp
var entityId = new ResourceIdentifier(
    "/subscriptions/<subscription-id>/resourceGroups/<resource-group>/providers/Microsoft.CloudHealth/healthmodels/<model-name>/entities/<entity-name>");
var client = new ArmClient(new DefaultAzureCredential(), entityId.SubscriptionId);
var entity = (await client.GetHealthModelEntityResource(entityId).GetAsync()).Value;

Console.WriteLine($"Entity ID: {entity.Id}");
if (entity.Data.Properties?.HealthState is EntityHealthState healthState)
{
    Console.WriteLine($"Current health: {healthState}");
}
else
{
    Console.WriteLine("A health state is not available for this entity.");
}
```

The service reports `Healthy`, `Degraded`, `Unhealthy`, or `Unknown`. The sample reads the entity's health state, not its provisioning status.

An entity without evaluated signals may have `Unknown` or unavailable health. Neither means `Healthy`, even if provisioning succeeded or a `Healthy` report was accepted. To view evaluated health, submit current reports or configure other monitoring and allow time for signal evaluation. Reading the entity does not trigger evaluation or wait for a particular health state.
