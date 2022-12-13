// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Containers.ContainerRegistry;
using Azure.Identity;
using NUnit.Framework;
using System.Collections.Generic;

namespace Azure.Containers.ContainerRegistry.Tests.Samples
{
    public partial class SetPropertiesSample : ContainerRegistrySamplesBase
    {
        [Test, NonParallelizable]
        [SyncOnly]
        public void SetImageProperties()
        {
            // Set up
            string repositoryName = "Sample03_DemoImage";
            CreateImage(TestEnvironment.Registry, repositoryName, "v1");
            AddTag(TestEnvironment.Registry, repositoryName, "latest");

            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.Endpoint);

            #region Snippet:ContainerRegistry_Tests_Samples_SetArtifactProperties
            // Get the service endpoint from the environment
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

            // Create a new ContainerRegistryClient and RegistryArtifact to access image operations
            ContainerRegistryClient client = new ContainerRegistryClient(endpoint, new DefaultAzureCredential(),
                new ContainerRegistryClientOptions()
                {
                    Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud
                });
            RegistryArtifact image = client.GetArtifact("library/hello-world", "v1");

            // Set permissions on the v1 image's "latest" tag
            image.UpdateTagProperties("latest", new ArtifactTagProperties()
            {
                CanWrite = false,
                CanDelete = false
            });
            #endregion

            // Reset registry state
            image.UpdateTagProperties("latest", new ArtifactTagProperties()
            {
                CanRead = true,
                CanList = true,
                CanWrite = true,
                CanDelete = true
            });
        }

        [Test, NonParallelizable]
        [AsyncOnly]
        public async Task SetImagePropertiesAsync()
        {
            // Set up
            string repositoryName = "Sample03_DemoImage";
            await CreateImageAsync(new Uri(TestEnvironment.Endpoint), repositoryName, "v1");
            await AddTagAsync(new Uri(TestEnvironment.Endpoint), repositoryName, "v1", "latest");

            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.Endpoint);

            #region Snippet:ContainerRegistry_Tests_Samples_SetArtifactPropertiesAsync
            // Get the service endpoint from the environment
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

            // Create a new ContainerRegistryClient and RegistryArtifact to access image operations
            ContainerRegistryClient client = new ContainerRegistryClient(endpoint, new DefaultAzureCredential(),
                new ContainerRegistryClientOptions()
                {
                    Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud
                });
            RegistryArtifact image = client.GetArtifact("library/hello-world", "v1");

            // Set permissions on the image's "latest" tag
            await image.UpdateTagPropertiesAsync("latest", new ArtifactTagProperties()
            {
                CanWrite = false,
                CanDelete = false
            });
            #endregion

            // Reset registry state
            await image.UpdateTagPropertiesAsync("latest", new ArtifactTagProperties()
            {
                CanRead = true,
                CanList = true,
                CanWrite = true,
                CanDelete = true
            });
        }
    }
}
