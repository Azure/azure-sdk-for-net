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
    public partial class SetPropertiesSample : SamplesBase<ContainerRegistryTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void SetImageProperties()
        {
            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.Endpoint);

            // Get the service endpoint from the environment
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

            // Create a new ContainerRegistryClient and RegistryArtifact to access image operations
            ContainerRegistryClient client = new ContainerRegistryClient(endpoint, new DefaultAzureCredential());
            RegistryArtifact image = client.GetArtifact("hello-world", "v1");

            // Set permissions on the v1 image's "latest" tag
            image.SetTagProperties("latest", new ContentProperties()
            {
                CanWrite = false,
                CanDelete = false
            });
        }

        [Test]
        [AsyncOnly]
        public async Task SetImagePropertiesAsync()
        {
            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.Endpoint);

            // Get the service endpoint from the environment
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

            // Create a new ContainerRegistryClient and RegistryArtifact to access image operations
            ContainerRegistryClient client = new ContainerRegistryClient(endpoint, new DefaultAzureCredential());
            RegistryArtifact image = client.GetArtifact("hello-world", "v1");

            // Set permissions on the image's "latest" tag
            await image.SetTagPropertiesAsync("latest", new ContentProperties()
            {
                CanWrite = false,
                CanDelete = false
            });
        }
    }
}
