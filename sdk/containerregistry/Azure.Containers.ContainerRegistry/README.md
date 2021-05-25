# Azure Container Registry client library for .NET

Azure Container Registry allows you to store and manage container images and artifacts in a private registry for all types of container deployments.

Use the client library for Azure Container Registry to:

- List images or artifacts in a registry
- Obtain metadata for images and artifacts, repositories and tags
- Set read/write/delete properties on registry items
- Delete images and artifacts, repositories and tags

[Source code][source] | [Package (NuGet)][package] | [API reference documentation][docs] | [REST API documentation][rest_docs] | [Product documentation][product_docs]

## Getting started

### Install the package

Install the Azure Container Registry client library for .NET with [NuGet][nuget]:

```Powershell
dotnet add package Azure.Containers.ContainerRegistry --prerelease
```

### Prerequisites

You need an [Azure subscription][azure_sub] and a [Container Registry account][container_registry_docs] to use this package.

To create a new Container Registry, you can use the [Azure Portal][container_registry_create_portal],
[Azure PowerShell][container_registry_create_ps], or the [Azure CLI][container_registry_create_cli].
Here's an example using the Azure CLI:

```Powershell
az acr create --name MyContainerRegistry --resource-group MyResourceGroup --location westus --sku Basic
```

### Authenticate the client

The [Azure Identity library][identity] provides easy Azure Active Directory support for authentication.

```C#
// Create a ContainerRegistryClient that will authenticate through Active Directory
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));
ContainerRegistryClient client = new ContainerRegistryClient(endpoint, new DefaultAzureCredential());
```

Note that these samples assume you have a `REGISTRY_ENDPOINT` environment variable set, which is the URL including the name of the login server and the `https://` prefix.

For more information on using AAD with Azure Container Registry, please see the service's [Authentication Overview](https://docs.microsoft.com/azure/container-registry/container-registry-authentication).

## Key concepts

A **registry** stores Docker images and [OCI Artifacts](https://opencontainers.org/).  An image or artifact consists of a **manifest** and **layers**.  An image's manifest describes the layers that make up the image, and is uniquely identified by its **digest**.  An image can also be "tagged" to give it a human-readable alias.  An image or artifact can have zero or more **tags** associated with it, and each tag uniquely identifies the image.  A collection of images that share the same name but have different tags, is referred to as a **repository**.

For more information please see [Container Registry Concepts](https://docs.microsoft.com/azure/container-registry/container-registry-concepts).

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the [recommendation to reuse client instances](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/#client-lifetime) is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

### Sync examples

- [List repositories](#list-repositories)

### Async examples

- [List repositories asynchronously](#list-repositories-asynchronously)

### List repositories

Iterate through the collection of repositories in the registry.

```C# Snippet:ContainerRegistry_Tests_Samples_CreateClient
// Get the service endpoint from the environment
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

// Create a new ContainerRegistryClient
ContainerRegistryClient client = new ContainerRegistryClient(endpoint, new DefaultAzureCredential());

// Perform an operation
Pageable<string> repositories = client.GetRepositoryNames();
foreach (string repository in repositories)
{
    Console.WriteLine(repository);
}
```

### List repositories asynchronously

The asynchronous APIs are identical to their synchronous counterparts, but methods end with the standard .NET "Async" suffix and return a Task.

```C# Snippet:ContainerRegistry_Tests_Samples_CreateClientAsync
// Get the service endpoint from the environment
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

// Create a new ContainerRegistryClient
ContainerRegistryClient client = new ContainerRegistryClient(endpoint, new DefaultAzureCredential());

// Perform an operation
AsyncPageable<string> repositories = client.GetRepositoryNamesAsync();
await foreach (string repository in repositories)
{
    Console.WriteLine(repository);
}
```

## Troubleshooting

All container registry service operations will throw a
[RequestFailedException][RequestFailedException] on failure.

```C# Snippet:ContainerRegistry_Tests_Samples_HandleErrors
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

// Create a ContainerRepository class for an invalid repository
string fakeRepositoryName = "doesnotexist";
ContainerRegistryClient client = new ContainerRegistryClient(endpoint, new DefaultAzureCredential());
ContainerRepository repository = client.GetRepository(fakeRepositoryName);

try
{
    repository.GetProperties();
}
catch (RequestFailedException ex) when (ex.Status == 404)
{
    Console.WriteLine("Repository wasn't found.");
}
```

You can also easily [enable console logging](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md#logging) if you want to dig
deeper into the requests you're making against the service.

## Next steps

- Go further with Azure.Containers.ContainerRegistry and our [samples][samples]
- Watch a [demo or deep dive video](https://azure.microsoft.com/resources/videos/index/?service=container-registry)
- Read more about the [Azure Container Registry service](https://docs.microsoft.com/azure/container-registry/container-registry-intro)

## Contributing

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq]
or contact [opencode@microsoft.com][coc_contact] with any
additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fcontainerregistry%2FAzure.Containers.ContainerRegistry%2FREADME.png)

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/containerregistry/Azure.Containers.ContainerRegistry/src
[package]: https://www.nuget.org/packages/Azure.Containers.ContainerRegistry/
[docs]: https://docs.microsoft.com/dotnet/api/azure.containers.containerregistry
[rest_docs]: https://docs.microsoft.com/rest/api/containerregistry/
[product_docs]:  https://docs.microsoft.com/azure/container-registry
[nuget]: https://www.nuget.org/
[container_registry_docs]: https://docs.microsoft.com/azure/container-registry/container-registry-intro
[container_registry_create_ps]: https://docs.microsoft.com/azure/container-registry/container-registry-get-started-powershell
[container_registry_create_cli]: https://docs.microsoft.com/azure/container-registry/container-registry-get-started-azure-cli
[container_registry_create_portal]: https://docs.microsoft.com/azure/container-registry/container-registry-get-started-portal
[container_registry_concepts]: https://docs.microsoft.com/azure/container-registry/container-registry-concepts
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/
[identity]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity/README.md
[RequestFailedException]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/core/Azure.Core/src/RequestFailedException.cs
[samples]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/containerregistry/Azure.Containers.ContainerRegistry/samples/
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
