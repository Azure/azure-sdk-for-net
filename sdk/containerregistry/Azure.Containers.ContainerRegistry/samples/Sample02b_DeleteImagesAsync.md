# Azure.Containers.ContainerRegistry Samples - Delete Images (async)

A common use case for Azure Container Registries is to scan the repositories in a registry and delete all but the most recent *n* images, or all images older than a certain date.  This sample illustrates how to use the .NET ACR SDK to delete all but the latest three images.

Please note:

- The `System.Linq.Async` package provides the LINQ `Skip` method. For more information on using this package with AsyncPageable, please see [Using System.Linq.Async with AsyncPageable](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Response.md#using-systemlinqasync-with-asyncpageable).

- The operations in this sample are run in series, but could be parallelized using the new `Parallel.ForEachAsync` method in [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0).

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
