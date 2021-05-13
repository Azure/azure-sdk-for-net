// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
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
                    repository.GetManifests(orderBy: ManifestOrderBy.LastUpdatedOnDescending);

                int imageCount = 0;
                int imagesToKeep = 3;

                // Delete images older than the first three.
                foreach (ArtifactManifestProperties imageManifest in imageManifests)
                {
                    if (imageCount++ >= imagesToKeep)
                    {
                        Console.WriteLine($"Deleting image with digest {imageManifest.Digest}.");
                        Console.WriteLine($"   This image has the following tags: ");
                        foreach (var tagName in imageManifest.Tags)
                        {
                            Console.WriteLine($"        {imageManifest.RepositoryName}:{tagName}");
                        }
                        repository.GetArtifact(imageManifest.Digest).Delete();
                    }
                }
            }
        }

        [Test, NonParallelizable]
        [AsyncOnly]
        public async Task DeleteImagesAsync()
        {
            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.Endpoint);

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
                    repository.GetManifestsAsync(orderBy: ManifestOrderBy.LastUpdatedOnDescending);

                int imageCount = 0;
                int imagesToKeep = 3;

                // Delete images older than the first three.
                await foreach (ArtifactManifestProperties imageManifest in imageManifests)
                {
                    if (imageCount++ >= imagesToKeep)
                    {
                        Console.WriteLine($"Deleting image with digest {imageManifest.Digest}.");
                        Console.WriteLine($"   This image has the following tags: ");
                        foreach (var tagName in imageManifest.Tags)
                        {
                            Console.WriteLine($"        {imageManifest.RepositoryName}:{tagName}");
                        }
                        await repository.GetArtifact(imageManifest.Digest).DeleteAsync();
                    }
                }
            }
        }
    }
}
