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
            ContainerRegistryClient client = new ContainerRegistryClient(endpoint, new DefaultAzureCredential());

            // Iterate through repositories
            Pageable<string> repositoryNames = client.GetRepositoryNames();
            foreach (string repositoryName in repositoryNames)
            {
                ContainerRepository repository = client.GetRepository(repositoryName);

                // Obtain the images ordered from newest to oldest
                Pageable<ArtifactManifestProperties> imageManifests =
                    repository.GetManifestPropertiesCollection(orderBy: ArtifactManifestOrderBy.LastUpdatedOnDescending);

                // Delete images older than the first three.
                foreach (ArtifactManifestProperties imageManifest in imageManifests.Skip(3))
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
            #endregion
        }

        [Test, NonParallelizable]
        [AsyncOnly]
        public async Task DeleteImagesAsync()
        {
            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.Endpoint);

            # region Snippet:ContainerRegistry_Tests_Samples_DeleteImageAsync
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
                    repository.GetManifestPropertiesCollectionAsync(orderBy: ArtifactManifestOrderBy.LastUpdatedOnDescending);

                // Delete images older than the first three.
                await foreach (ArtifactManifestProperties imageManifest in imageManifests.Skip(3))
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

            #endregion
        }
    }
}
