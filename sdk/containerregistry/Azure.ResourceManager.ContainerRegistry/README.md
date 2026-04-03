# Microsoft Azure Container Registry management client library for .NET

Microsoft Azure Container Registry is a managed, private Docker registry service based on the open-source Docker Registry 2.0. Create and maintain Azure container registries to store and manage your private container images and related artifacts.

This library supports managing Microsoft Azure Container Registry resources, including registries, webhooks, geo-replications, scope maps, tokens, cache rules, private endpoints, and more.

This library follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html) and provides many core capabilities:

- Support MSAL.NET; `Azure.Identity` is built in for MSAL.NET.
- Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
- HTTP pipeline with custom policies.
- Better error-handling.
- Uniform telemetry across all languages.

## Getting started

### Install the package

Install the Microsoft Azure Container Registry management library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.ResourceManager.ContainerRegistry
```

### Prerequisites

- An [Azure subscription](https://azure.microsoft.com/free/dotnet/).
- An existing Azure resource group, or permission to create one.

### Authenticate the client

The default option to create an authenticated client is to use `DefaultAzureCredential`. Since all management APIs go through the same endpoint, only one top-level `ArmClient` is needed.

First, install the Azure Identity package:

```dotnetcli
dotnet add package Azure.Identity
```

Then create the client:

```C# Snippet:Managing_ContainerRegistries_AuthClient
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
```

More information and different authentication approaches using Azure Identity can be found in [this document](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme).

## Key concepts

Key concepts of the Azure SDK for .NET can be found in the [Azure ResourceManager README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/README.md#key-concepts).

### Resource hierarchy

The primary resources in this library are:

| Resource type | Description |
|---|---|
| `ContainerRegistryResource` | Represents a private container registry. Supports CRUD, credential management, and scheduling runs. |
| `ContainerRegistryWebhookResource` | Webhook that fires on registry events such as `push` or `delete`. |
| `ContainerRegistryReplicationResource` | Geo-replication of a registry to another region. |
| `ScopeMapResource` | A set of repository-level permissions that can be assigned to tokens. |
| `ContainerRegistryTokenResource` | A scoped access credential backed by a scope map. |
| `ContainerRegistryCacheRuleResource` | Enables pulling images from an upstream source through the registry. |
| `ContainerRegistryCredentialSetResource` | Stores credentials for accessing upstream registries. |
| `ContainerRegistryPrivateEndpointConnectionResource` | Manages private endpoint connectivity for the registry. |
| `ContainerRegistryExportPipelineResource` | Defines an export pipeline for transferring artifacts out of the registry. |
| `ContainerRegistryImportPipelineResource` | Defines an import pipeline for bringing artifacts into the registry. |
| `ContainerRegistryArchiveResource` | Manages immutable, tagged archives of repository content. |

## Examples

- [Managing Container Registries](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/containerregistry/Azure.ResourceManager.ContainerRegistry/samples/Sample1_ManagingContainerRegistries.md) – create, list, update, and delete registries; manage webhooks, replications, scope maps, and tokens.

### Create a container registry

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

### List container registries

```C# Snippet:Managing_ContainerRegistries_ListRegistries
ContainerRegistryCollection registries = resourceGroup.GetContainerRegistries();
await foreach (ContainerRegistryResource registry in registries.GetAllAsync())
{
    Console.WriteLine($"Registry: {registry.Data.Name}, SKU: {registry.Data.Sku.Name}");
}
```

### Create a geo-replication

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

### Create a scope map and token for repository access control

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

## Troubleshooting

- File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
- Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using the `azure` and `.net` tags.
- For authentication issues, see the [DefaultAzureCredential documentation](https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential).

## Next steps

- [Quickstart guide](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md)
- [API Reference](https://learn.microsoft.com/dotnet/api/?view=azure-dotnet)
- [Azure Container Registry documentation](https://learn.microsoft.com/azure/container-registry/)

## Contributing

For details on contributing to this repository, see the [contributing guide][cg].

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (for example, label, comment). Follow the instructions provided by the bot. You'll only need to do this action once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information, see the [Code of Conduct FAQ][coc_faq] or contact <opencode@microsoft.com> with any other questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
