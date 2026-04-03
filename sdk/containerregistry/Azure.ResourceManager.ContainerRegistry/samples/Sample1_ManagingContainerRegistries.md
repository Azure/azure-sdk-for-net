# Example: Managing Azure Container Registries

> **Note:** Before getting started, review the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

## Namespaces

```C# Snippet:Managing_ContainerRegistries_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.ContainerRegistry;
using Azure.ResourceManager.ContainerRegistry.Models;
using Azure.ResourceManager.Resources;
```

## Authenticate the client

```C# Snippet:Managing_ContainerRegistries_AuthClient
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
```

## Create a resource group

```C# Snippet:Managing_ContainerRegistries_CreateResourceGroup
string rgName = "myContainerRegistryRG";
AzureLocation location = AzureLocation.WestUS;
ArmOperation<ResourceGroupResource> rgOperation = await subscription.GetResourceGroups()
    .CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
ResourceGroupResource resourceGroup = rgOperation.Value;
```

## Create a container registry

```C# Snippet:Managing_ContainerRegistries_CreateRegistry
// Create a container registry with Premium SKU
string registryName = "myContainerRegistry";
ContainerRegistryData registryData = new ContainerRegistryData(
    AzureLocation.WestUS,
    new ContainerRegistrySku(ContainerRegistrySkuName.Premium))
{
    IsAdminUserEnabled = true,
    Tags = { ["environment"] = "production" }
};

ArmOperation<ContainerRegistryResource> lro = await resourceGroup.GetContainerRegistries()
    .CreateOrUpdateAsync(WaitUntil.Completed, registryName, registryData);
ContainerRegistryResource registry = lro.Value;
Console.WriteLine($"Created registry: {registry.Data.LoginServer}");
```

## List container registries in a resource group

```C# Snippet:Managing_ContainerRegistries_ListRegistries
ContainerRegistryCollection registries = resourceGroup.GetContainerRegistries();
await foreach (ContainerRegistryResource registry in registries.GetAllAsync())
{
    Console.WriteLine($"Registry: {registry.Data.Name}, SKU: {registry.Data.Sku.Name}");
}
```

## Get a container registry

```C# Snippet:Managing_ContainerRegistries_GetRegistry
ContainerRegistryResource registry = await resourceGroup.GetContainerRegistries()
    .GetAsync("myContainerRegistry");
Console.WriteLine($"Registry login server: {registry.Data.LoginServer}");
```

## Update a container registry

```C# Snippet:Managing_ContainerRegistries_UpdateRegistry
ContainerRegistryPatch patch = new ContainerRegistryPatch()
{
    Tags = { ["environment"] = "staging" },
    Sku = new ContainerRegistrySku(ContainerRegistrySkuName.Standard)
};
ArmOperation<ContainerRegistryResource> updateLro = await registry.UpdateAsync(WaitUntil.Completed, patch);
ContainerRegistryResource updatedRegistry = updateLro.Value;
Console.WriteLine($"Updated registry SKU: {updatedRegistry.Data.Sku.Name}");
```

## Delete a container registry

```C# Snippet:Managing_ContainerRegistries_DeleteRegistry
await registry.DeleteAsync(WaitUntil.Completed);
Console.WriteLine("Registry deleted.");
```

## Manage webhooks

```C# Snippet:Managing_ContainerRegistries_CreateWebhook
string webhookName = "myWebhook";
ContainerRegistryWebhookCreateOrUpdateContent webhookContent = new ContainerRegistryWebhookCreateOrUpdateContent(
    registry.Data.Location)
{
    ServiceUri = new Uri("https://myapp.example.com/webhook"),
    Actions = { ContainerRegistryWebhookAction.Push, ContainerRegistryWebhookAction.Delete },
    Tags = { ["purpose"] = "ci-cd" }
};

ArmOperation<ContainerRegistryWebhookResource> webhookLro = await registry.GetContainerRegistryWebhooks()
    .CreateOrUpdateAsync(WaitUntil.Completed, webhookName, webhookContent);
ContainerRegistryWebhookResource webhook = webhookLro.Value;
Console.WriteLine($"Created webhook: {webhook.Data.Name}");
```

## Replicate a registry for geo-redundancy

```C# Snippet:Managing_ContainerRegistries_CreateReplication
// Replicate the registry to East US for geo-redundancy
string replicationName = AzureLocation.EastUS.ToString();
ArmOperation<ContainerRegistryReplicationResource> replicationLro =
    await registry.GetContainerRegistryReplications()
        .CreateOrUpdateAsync(WaitUntil.Completed, replicationName,
            new ContainerRegistryReplicationData(AzureLocation.EastUS));
ContainerRegistryReplicationResource replication = replicationLro.Value;
Console.WriteLine($"Created replication: {replication.Data.Name}, Status: {replication.Data.Status?.DisplayStatus}");
```

## Manage scope maps and tokens

Scope maps and tokens allow fine-grained, repository-level access control for a container registry.

```C# Snippet:Managing_ContainerRegistries_CreateScopeMap
// Create a scope map granting read/write access to a repository
string repositoryName = "hello-world";
ScopeMapData scopeMapData = new ScopeMapData()
{
    Description = "Read/write access to hello-world repository",
    Actions =
    {
        $"repositories/{repositoryName}/content/read",
        $"repositories/{repositoryName}/content/write",
        $"repositories/{repositoryName}/metadata/read"
    }
};

ArmOperation<ScopeMapResource> scopeMapLro = await registry.GetScopeMaps()
    .CreateOrUpdateAsync(WaitUntil.Completed, "myScopeMap", scopeMapData);
ScopeMapResource scopeMap = scopeMapLro.Value;
Console.WriteLine($"Created scope map: {scopeMap.Data.Name}");
```

```C# Snippet:Managing_ContainerRegistries_CreateToken
// Create a token associated with the scope map
ContainerRegistryTokenData tokenData = new ContainerRegistryTokenData()
{
    ScopeMapId = scopeMap.Id
};

ArmOperation<ContainerRegistryTokenResource> tokenLro = await registry.GetContainerRegistryTokens()
    .CreateOrUpdateAsync(WaitUntil.Completed, "myRegistryToken", tokenData);
ContainerRegistryTokenResource token = tokenLro.Value;
Console.WriteLine($"Created token: {token.Data.Name}, Status: {token.Data.Status}");
```
