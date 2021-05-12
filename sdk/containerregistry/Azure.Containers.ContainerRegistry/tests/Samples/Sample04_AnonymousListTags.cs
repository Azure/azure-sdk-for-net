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
    public partial class AnonymousClientSample : SamplesBase<ContainerRegistryTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void AnonymouslyListTags()
        {
            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.Endpoint);

            // Get the service endpoint from the environment
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

            // Create a new ContainerRegistryClient for anonymous access
            ContainerRegistryClient client = new ContainerRegistryClient(endpoint);

            // List the set of tags on the hello_world image tagged as "latest"
            RegistryArtifact image = client.GetArtifact("hello_world", "latest");

            Pageable<ArtifactTagProperties> tags = image.GetTags();

            // Iterate through the image's tags, listing the tagged alias for the image
            Console.WriteLine($"{image.FullyQualifiedName} has the following aliases:");
            foreach (ArtifactTagProperties tag in tags)
            {
                Console.WriteLine($"    {image.RegistryUri.Host}/{image.RepositoryName}:{tag}");
            }
        }

        [Test]
        [AsyncOnly]
        public async Task AnonymouslyListTagsAsync()
        {
            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.Endpoint);

            // Get the service endpoint from the environment
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

            // Create a new ContainerRegistryClient for anonymous access
            ContainerRegistryClient client = new ContainerRegistryClient(endpoint);

            // List the set of tags on the hello_world image tagged as "latest"
            RegistryArtifact image = client.GetArtifact("hello_world", "latest");

            AsyncPageable<ArtifactTagProperties> tags = image.GetTagsAsync();

            // Iterate through the image's tags, listing the tagged alias for the image
            Console.WriteLine($"{image.FullyQualifiedName} has the following aliases:");
            await foreach (ArtifactTagProperties tag in tags)
            {
                Console.WriteLine($"    {image.RegistryUri.Host}/{image.RepositoryName}:{tag}");
            }
        }
    }
}
