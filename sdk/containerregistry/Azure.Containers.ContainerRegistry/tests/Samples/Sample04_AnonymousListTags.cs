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
    public partial class AnonymousClientSample : ContainerRegistrySamplesBase
    {
        [Test]
        [SyncOnly]
        public void AnonymouslyListTags()
        {
            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.AnonymousAccessEndpoint);

            #region Snippet:ContainerRegistry_Tests_Samples_ListTagsAnonymous
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
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task AnonymouslyListTagsAsync()
        {
            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.AnonymousAccessEndpoint);

            #region Snippet:ContainerRegistry_Tests_Samples_ListTagsAnonymousAsync
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
            #endregion
        }
    }
}
