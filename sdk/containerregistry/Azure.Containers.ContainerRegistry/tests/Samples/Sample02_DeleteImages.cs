// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Linq;
using Azure.Core.TestFramework;
using Azure.Containers.ContainerRegistry;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Containers.ContainerRegistry.Tests.Samples
{
    public partial class DeleteImagesSample : ContainerRegistrySamplesBase
    {
        [Test, NonParallelizable]
        [SyncOnly]
        public void DeleteImages()
        {
            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.Endpoint);

            #region Snippet:ContainerRegistry_Tests_Samples_DeleteImage
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
            #endregion
        }

        [Test, NonParallelizable]
        [AsyncOnly]
        public async Task DeleteImagesAsync()
        {
            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.Endpoint);

            #region Snippet:ContainerRegistry_Tests_Samples_DeleteImageAsync
            // Get the service endpoint from the environment
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

            // Create a new ContainerRegistryClient
            ContainerRegistryClient client = new ContainerRegistryClient(endpoint, new DefaultAzureCredential(),
                new ContainerRegistryClientOptions()
                {
                    Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud
                });

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
            #endregion
        }
    }
}
