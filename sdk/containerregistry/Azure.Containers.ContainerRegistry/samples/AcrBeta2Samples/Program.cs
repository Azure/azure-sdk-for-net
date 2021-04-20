using System;
using System.Threading.Tasks;
using Azure;
using Azure.Containers.ContainerRegistry;
using Azure.Identity;

namespace AcrBeta2Samples
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static async Task DeleteStaleImages()
        {
            // ### 1. Customer would like to create a script that scans all ACR repositories and deletes all the old docker images, while only keeping the latest three images

            ContainerRegistryClient registryClient = new ContainerRegistryClient(
                new Uri("myacr.azurecr.io"),
                new DefaultAzureCredential());

            AsyncPageable<string> repositories = registryClient.GetRepositoriesAsync();
            await foreach (var repositoryName in repositories)
            {
                ContainerRepository repository = registryClient.GetRepository(repositoryName);

                AsyncPageable<ManifestProperties> images = repository.GetArtifactManifestsAsync(
                        new GetArtifactManifestsOptions(ManifestOrderBy.LastUpdatedOnDescending)
                    );

                int imageCount = 0;
                int imagesToKeep = 3;
                await foreach (ManifestProperties image in images)
                {
                    if (imageCount++ >= imagesToKeep)
                    {
                        Console.WriteLine($"Deleting image with digest {image.Digest}.");
                        Console.WriteLine($"   This image has the following tags: ");
                        foreach (var tagName in image.Tags)
                        {
                            Console.WriteLine($"        {image.Repository}:{tagName}");
                        }

                        await registryClient.GetRegistryArtifact(image.Repository, image.Digest).DeleteAsync();
                    }
                }
            }
        }

        static async Task MakeTagReadOnly()
        {
            // ### 2. Make tagged image read-only

            ContainerRegistryClient registryClient = new ContainerRegistryClient(
                new Uri("myacr.azurecr.io"),
                new DefaultAzureCredential());

            //await registryClient.GetRegistryArtifact(new ArtifactMoniker("myacr.azureacr.io/hello-world:v1")).SetTagPropertiesAsync("v1",
            await registryClient.GetRegistryArtifact("hello-world", "v1").SetTagPropertiesAsync("v1",
                new ContentProperties()
                {
                    CanWrite = false,
                    CanDelete = false
                }
            );
        }
    }
}
