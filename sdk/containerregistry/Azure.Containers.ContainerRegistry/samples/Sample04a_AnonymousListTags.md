# Azure.Search.Documents Samples - List Tags Anonymously (sync)

A common use case for Azure Container Registries is to view the repositories, artifacts, or tags in a public registry that belongs to someone else.  In this case, the user would need to access the registry anonymously.  Anonymous access allows a user to list all the collections there, but they wouldn't also have permissions to modify or delete any of the images in the registry.

This sample shows how to list the tags for an image with anonymous access.

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
