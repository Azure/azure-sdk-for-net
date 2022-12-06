# Azure.Containers.ContainerRegistry Samples - Delete Images (sync)

A common use case for Azure Container Registries is to scan the repositories in a registry and delete all but the most recent *n* images, or all images older than a certain date.  This sample illustrates how to use the .NET ACR SDK to delete all but the latest three images.

```C# Snippet:ContainerRegistry_Tests_Samples_DeleteImage
// Get the service endpoint from the environment
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

// Create a new ContainerRegistryClient
ContainerRegistryClient client = new ContainerRegistryClient(endpoint, new DefaultAzureCredential(),
    new ContainerRegistryClientOptions()
    {
        Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud
    });

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
