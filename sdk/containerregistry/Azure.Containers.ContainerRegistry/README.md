# Azure Container Registry client library for .NET

Azure Container Registry allows you to store and manage container images and artifacts in a private registry for all types of container deployments.

Use the client library for Azure Container Registry to:

- List images or artifacts in a registry
- Obtain metadata for images and artifacts, repositories and tags
- Set read/write/delete properties on registry items
- Delete images and artifacts, repositories and tags

[Source code][source] | [Package (NuGet)][package] | [API reference documentation][docs] | [REST API documentation][rest_docs] | [Product documentation][product_docs]

## Getting started

To develop .NET application code that can connect to an Azure Container Registry instance, you will need the `Azure.Containers.ContainerRegistry` library.

### Install the package

Install the Azure Container Registry client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.Containers.ContainerRegistry
```

### Prerequisites

You will need an [Azure subscription][azure_sub] and a [Container Registry service instance][container_registry_docs] for your application to connect to.

To create a new Container Registry, you can use the [Azure Portal][container_registry_create_portal],
[Azure PowerShell][container_registry_create_ps], or the [Azure CLI][container_registry_create_cli].
Here'a an example of creating a new registry using the Azure CLI:

```Powershell
az acr create --name myregistry --resource-group myresourcegroup --location westus --sku Basic
```

### Authenticate the client

For your application to connect to your registry, you'll need to create a `ContainerRegistryClient` that can authenticate with it.  The [Azure Identity library][identity] makes it easy to add Azure Active Directory support for authenticating Azure SDK clients with their corresponding Azure services.

When you're developing and debugging your application locally, you can use your own user to authenticate with your registry.  One way to accomplish this is to [authenticate your user with the Azure CLI](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity#authenticating-via-the-azure-cli) and run your application from this environment.  If your application is using a client that has been constructed to authenticate with `DefaultAzureCredential`, it will correctly authenticate with the registry at the specified endpoint.

```C#
// Create a ContainerRegistryClient that will authenticate to your registry through Azure Active Directory
Uri endpoint = new Uri("https://myregistry.azurecr.io");
ContainerRegistryClient client = new ContainerRegistryClient(endpoint, new DefaultAzureCredential(),
    new ContainerRegistryClientOptions()
    {
        Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud
    });
```

Please see the [Azure Identity README][identity] for more approaches to authenticating with `DefaultAzureCredential`, both locally and in deployment environments.  To connect to registries in non-public Azure Clouds, see the samples below.

For more information on using AAD with Azure Container Registry, please see the service's [Authentication Overview](https://learn.microsoft.com/azure/container-registry/container-registry-authentication).

## Key concepts

A **registry** stores Docker images and [OCI Artifacts](https://opencontainers.org/).  An image or artifact consists of a **manifest** and **layers**.  An image's manifest describes the layers that make up the image, and is uniquely identified by its **digest**.  An image can also be "tagged" to give it a human-readable alias.  An image or artifact can have zero or more **tags** associated with it, and each tag uniquely identifies the image.  A collection of images that share the same name but have different tags, is referred to as a **repository**.

For more information please see [Container Registry Concepts](https://learn.microsoft.com/azure/container-registry/container-registry-concepts).

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the [recommendation to reuse client instances](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/#client-lifetime) is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

The following snippets show brief samples of common developer scenarios using the ACR SDK library.
Please note that each sample assumes there is a `REGISTRY_ENDPOINT` environment variable set to a string containing the `https://` prefix and the name of the login server, for example "https://myregistry.azurecr.io".

### Sync examples

- Registry operations:
  - [List repositories](#list-repositories)
  - [List tags with anonymous access](#list-tags-with-anonymous-access)
  - [Set artifact properties](#set-artifact-properties)
  - [Delete images](#delete-images)

### Async examples

- Registry operations:
  - [List repositories asynchronously](#list-repositories-asynchronously)
  - [List tags with anonymous access asynchronously](#list-tags-with-anonymous-access)
  - [Set artifact properties asynchronously](#set-artifact-properties)
  - [Delete images asynchronously](#delete-images)
- Blob and manifest operations:
  - [Upload images](#upload-images)
  - [Download images](#download-images)
  - [Delete manifest](#delete-manifest)
  - [Delete blob](#delete-blob)

### Advanced authentication

- [Create a client that can authenticate with a registry in a national cloud](#authenticate-in-a-national-cloud)

### Registry operations

This section contains `ContainerRegistryClient` samples.

#### List repositories

Iterate through the collection of repositories in the registry.

```C# Snippet:ContainerRegistry_Tests_Samples_CreateClient
// Get the service endpoint from the environment
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

// Create a new ContainerRegistryClient
ContainerRegistryClient client = new ContainerRegistryClient(endpoint, new DefaultAzureCredential());

// Get the collection of repository names from the registry
Pageable<string> repositories = client.GetRepositoryNames();
foreach (string repository in repositories)
{
    Console.WriteLine(repository);
}
```

#### List tags with anonymous access

```C# Snippet:ContainerRegistry_Tests_Samples_ListTagsAnonymous
// Get the service endpoint from the environment
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

// Create a new ContainerRegistryClient for anonymous access
ContainerRegistryClient client = new ContainerRegistryClient(endpoint);

// Obtain a RegistryArtifact object to get access to image operations
RegistryArtifact image = client.GetArtifact("library/hello-world", "latest");

// List the set of tags on the hello_world image tagged as "latest"
Pageable<ArtifactTagProperties> tags = image.GetAllTagProperties();

// Iterate through the image's tags, listing the tagged alias for the image
Console.WriteLine($"{image.FullyQualifiedReference} has the following aliases:");
foreach (ArtifactTagProperties tag in tags)
{
    Console.WriteLine($"    {image.RegistryEndpoint.Host}/{image.RepositoryName}:{tag}");
}
```

#### Set artifact properties

```C# Snippet:ContainerRegistry_Tests_Samples_SetArtifactProperties
// Get the service endpoint from the environment
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

// Create a new ContainerRegistryClient and RegistryArtifact to access image operations
ContainerRegistryClient client = new ContainerRegistryClient(endpoint, new DefaultAzureCredential());
RegistryArtifact image = client.GetArtifact("library/hello-world", "latest");

// Set permissions on the v1 image's "latest" tag
image.UpdateTagProperties("latest", new ArtifactTagProperties()
{
    CanWrite = false,
    CanDelete = false
});
```

#### Delete images

```C# Snippet:ContainerRegistry_Tests_Samples_DeleteImage
// Get the service endpoint from the environment
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

// Create a new ContainerRegistryClient
ContainerRegistryClient client = new ContainerRegistryClient(endpoint, new DefaultAzureCredential());

// Iterate through repositories
Pageable<string> repositoryNames = client.GetRepositoryNames();
foreach (string repositoryName in repositoryNames)
{
    ContainerRepository repository = client.GetRepository(repositoryName);

    // Obtain the images ordered from newest to oldest
    Pageable<ArtifactManifestProperties> imageManifests =
        repository.GetAllManifestProperties(manifestOrder: ArtifactManifestOrder.LastUpdatedOnDescending);

    // Delete images older than the first three.
    foreach (ArtifactManifestProperties imageManifest in imageManifests.Skip(3))
    {
        RegistryArtifact image = repository.GetArtifact(imageManifest.Digest);
        Console.WriteLine($"Deleting image with digest {imageManifest.Digest}.");
        Console.WriteLine($"   Deleting the following tags from the image: ");
        foreach (var tagName in imageManifest.Tags)
        {
            Console.WriteLine($"        {imageManifest.RepositoryName}:{tagName}");
            image.DeleteTag(tagName);
        }
        image.Delete();
    }
}
```

#### List repositories asynchronously

The asynchronous APIs are identical to their synchronous counterparts, but methods end with the standard .NET "Async" suffix and return a Task.

```C# Snippet:ContainerRegistry_Tests_Samples_CreateClientAsync
// Get the service endpoint from the environment
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

// Create a new ContainerRegistryClient
ContainerRegistryClient client = new ContainerRegistryClient(endpoint, new DefaultAzureCredential());

// Get the collection of repository names from the registry
AsyncPageable<string> repositories = client.GetRepositoryNamesAsync();
await foreach (string repository in repositories)
{
    Console.WriteLine(repository);
}
```

#### List tags with anonymous access asynchronously

```C# Snippet:ContainerRegistry_Tests_Samples_ListTagsAnonymousAsync
// Get the service endpoint from the environment
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

// Create a new ContainerRegistryClient for anonymous access
ContainerRegistryClient client = new ContainerRegistryClient(endpoint);

// Obtain a RegistryArtifact object to get access to image operations
RegistryArtifact image = client.GetArtifact("library/hello-world", "latest");

// List the set of tags on the hello_world image tagged as "latest"
AsyncPageable<ArtifactTagProperties> tags = image.GetAllTagPropertiesAsync();

// Iterate through the image's tags, listing the tagged alias for the image
Console.WriteLine($"{image.FullyQualifiedReference} has the following aliases:");
await foreach (ArtifactTagProperties tag in tags)
{
    Console.WriteLine($"    {image.RegistryEndpoint.Host}/{image.RepositoryName}:{tag}");
}
```

#### Set artifact properties asynchronously

```C# Snippet:ContainerRegistry_Tests_Samples_SetArtifactPropertiesAsync
// Get the service endpoint from the environment
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

// Create a new ContainerRegistryClient and RegistryArtifact to access image operations
ContainerRegistryClient client = new ContainerRegistryClient(endpoint, new DefaultAzureCredential());
RegistryArtifact image = client.GetArtifact("library/hello-world", "v1");

// Set permissions on the image's "latest" tag
await image.UpdateTagPropertiesAsync("latest", new ArtifactTagProperties()
{
    CanWrite = false,
    CanDelete = false
});
```

#### Delete images asynchronously

```C# Snippet:ContainerRegistry_Tests_Samples_DeleteImageAsync
// Get the service endpoint from the environment
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

// Create a new ContainerRegistryClient
ContainerRegistryClient client = new ContainerRegistryClient(endpoint, new DefaultAzureCredential());

// Iterate through repositories
AsyncPageable<string> repositoryNames = client.GetRepositoryNamesAsync();
await foreach (string repositoryName in repositoryNames)
{
    ContainerRepository repository = client.GetRepository(repositoryName);

    // Obtain the images ordered from newest to oldest
    AsyncPageable<ArtifactManifestProperties> imageManifests =
        repository.GetAllManifestPropertiesAsync(manifestOrder: ArtifactManifestOrder.LastUpdatedOnDescending);

    // Delete images older than the first three.
    await foreach (ArtifactManifestProperties imageManifest in imageManifests.Skip(3))
    {
        RegistryArtifact image = repository.GetArtifact(imageManifest.Digest);
        Console.WriteLine($"Deleting image with digest {imageManifest.Digest}.");
        Console.WriteLine($"   Deleting the following tags from the image: ");
        foreach (var tagName in imageManifest.Tags)
        {
            Console.WriteLine($"        {imageManifest.RepositoryName}:{tagName}");
            await image.DeleteTagAsync(tagName);
        }
        await image.DeleteAsync();
    }
}
```

### Blob and manifest operations

This section contains samples for `ContainerRegistryContentClient` that show how to upload and download images.

First, create a blob client.

```C# Snippet:ContainerRegistry_Samples_CreateContentClient
// Get the service endpoint from the environment
Uri endpoint = new(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

string repository = "sample-oci-image";
string tag = "demo";

// Create a new ContainerRegistryContentClient
ContainerRegistryContentClient client = new(endpoint, repository, new DefaultAzureCredential());
```

#### Upload images

To upload a full image, we need to upload individual layers and configuration. After that we can upload a manifest which describes an image or artifact and assign it a tag.

```C# Snippet:ContainerRegistry_Samples_UploadOciImageAsync
// Create a manifest to list files in this image
OciImageManifest manifest = new(schemaVersion: 2);

// Upload a config file
BinaryData config = BinaryData.FromString("Sample config");
UploadRegistryBlobResult uploadConfigResult = await client.UploadBlobAsync(config);

// Update manifest with config info
manifest.Configuration = new OciDescriptor()
{
    Digest = uploadConfigResult.Digest,
    SizeInBytes = uploadConfigResult.SizeInBytes,
    MediaType = "application/vnd.oci.image.config.v1+json"
};

// Upload a layer file
BinaryData layer = BinaryData.FromString("Sample layer");
UploadRegistryBlobResult uploadLayerResult = await client.UploadBlobAsync(layer);

// Update manifest with layer info
manifest.Layers.Add(new OciDescriptor()
{
    Digest = uploadLayerResult.Digest,
    SizeInBytes = uploadLayerResult.SizeInBytes,
    MediaType = "application/vnd.oci.image.layer.v1.tar"
});

// Finally, upload the manifest file
await client.SetManifestAsync(manifest, tag);
```

#### Download images

To download a full image, we need to download its manifest and then download individual layers and configuration.

```C# Snippet:ContainerRegistry_Samples_DownloadOciImageAsync
// Download the manifest to obtain the list of files in the image
GetManifestResult result = await client.GetManifestAsync(tag);
OciImageManifest manifest = result.Manifest.ToObjectFromJson<OciImageManifest>();

string manifestFile = Path.Combine(path, "manifest.json");
using (FileStream stream = File.Create(manifestFile))
{
    await result.Manifest.ToStream().CopyToAsync(stream);
}

// Download and write out the config
DownloadRegistryBlobResult configBlob = await client.DownloadBlobContentAsync(manifest.Configuration.Digest);

string configFile = Path.Combine(path, "config.json");
using (FileStream stream = File.Create(configFile))
{
    await configBlob.Content.ToStream().CopyToAsync(stream);
}

// Download and write out the layers
foreach (OciDescriptor layerInfo in manifest.Layers)
{
    string layerFile = Path.Combine(path, TrimSha(layerInfo.Digest));
    using (FileStream stream = File.Create(layerFile))
    {
        await client.DownloadBlobToAsync(layerInfo.Digest, stream);
    }
}

static string TrimSha(string digest)
{
    int index = digest.IndexOf(':');
    if (index > -1)
    {
        return digest.Substring(index + 1);
    }

    return digest;
}
```

#### Delete manifest

```C# Snippet:ContainerRegistry_Samples_DeleteManifest
GetManifestResult manifestResult = await client.GetManifestAsync(tag);
await client.DeleteManifestAsync(manifestResult.Digest);
```

#### Delete blob

```C# Snippet:ContainerRegistry_Samples_DeleteBlob
GetManifestResult result = await client.GetManifestAsync(tag);
OciImageManifest manifest = result.Manifest.ToObjectFromJson<OciImageManifest>();

foreach (OciDescriptor layerInfo in manifest.Layers)
{
    await client.DeleteBlobAsync(layerInfo.Digest);
}
```

### Advanced authentication

#### Authenticate in a National Cloud

To authenticate with a registry in a [National Cloud](https://learn.microsoft.com/azure/active-directory/develop/authentication-national-cloud), you will need to make the following additions to your client configuration:

- Set the `AuthorityHost` in the credential options or via the `AZURE_AUTHORITY_HOST` environment variable
- Set the `Audience` in `ContainerRegistryClientOptions`

```C#
// Create a ContainerRegistryClient that will authenticate through AAD in the China national cloud
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));
ContainerRegistryClient client = new ContainerRegistryClient(endpoint,
    new DefaultAzureCredential(
        new DefaultAzureCredentialOptions()
        {
            AuthorityHost = AzureAuthorityHosts.AzureChina
        }),
    new ContainerRegistryClientOptions()
    {
        Audience = ContainerRegistryAudience.AzureChina
    });
```


## Troubleshooting

See our [troubleshooting guide](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/containerregistry/Azure.Containers.ContainerRegistry/TROUBLESHOOTING.md) for details on how to diagnose various failure scenarios.

## Next steps

- Go further with Azure.Containers.ContainerRegistry and our [samples][samples].
- Watch a [demo or deep dive video](https://azure.microsoft.com/resources/videos/index/?service=container-registry).
- Read more about the [Azure Container Registry service](https://learn.microsoft.com/azure/container-registry/container-registry-intro).

## Contributing

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq]
or contact [opencode@microsoft.com][coc_contact] with any
additional questions or comments.

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/containerregistry/Azure.Containers.ContainerRegistry/src
[package]: https://www.nuget.org/packages/Azure.Containers.ContainerRegistry/
[docs]: https://learn.microsoft.com/dotnet/api/azure.containers.containerregistry
[rest_docs]: https://learn.microsoft.com/rest/api/containerregistry/
[product_docs]:  https://learn.microsoft.com/azure/container-registry
[nuget]: https://www.nuget.org/
[container_registry_docs]: https://learn.microsoft.com/azure/container-registry/container-registry-intro
[container_registry_create_ps]: https://learn.microsoft.com/azure/container-registry/container-registry-get-started-powershell
[container_registry_create_cli]: https://learn.microsoft.com/azure/container-registry/container-registry-get-started-azure-cli
[container_registry_create_portal]: https://learn.microsoft.com/azure/container-registry/container-registry-get-started-portal
[container_registry_concepts]: https://learn.microsoft.com/azure/container-registry/container-registry-concepts
[azure_cli]: https://learn.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md
[RequestFailedException]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core/src/RequestFailedException.cs
[samples]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/containerregistry/Azure.Containers.ContainerRegistry/samples/
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
