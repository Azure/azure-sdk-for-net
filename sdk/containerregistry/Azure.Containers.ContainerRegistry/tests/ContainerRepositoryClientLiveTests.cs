// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using Microsoft.Azure.Management.ContainerRegistry;
using Microsoft.Azure.Management.ContainerRegistry.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using NUnit.Framework;
using Task = System.Threading.Tasks.Task;

namespace Azure.Containers.ContainerRegistry.Tests
{
    public class ContainerRepositoryClientLiveTests : RecordedTestBase<ContainerRegistryTestEnvironment>
    {
        private readonly string _repositoryName = "library/hello-world";

        public ContainerRepositoryClientLiveTests(bool isAsync) : base(isAsync)
        {
            Sanitizer = new ContainerRegistryRecordedTestSanitizer();
        }

        protected ContainerRepositoryClient CreateClient()
        {
            return InstrumentClient(new ContainerRepositoryClient(
                new Uri(TestEnvironment.Endpoint),
                _repositoryName,
                TestEnvironment.Credential,
                InstrumentClientOptions(new ContainerRegistryClientOptions())
            ));
        }

        public async Task ImportImage(string tag)
        {
            var credential = new AzureCredentials(
                new ServicePrincipalLoginInformation
                {
                    ClientId = TestEnvironment.ClientId,
                    ClientSecret = TestEnvironment.ClientSecret,
                },
                TestEnvironment.TenantId,
                AzureEnvironment.AzureGlobalCloud);

            var _registryClient = new ContainerRegistryManagementClient(credential.WithDefaultSubscription(TestEnvironment.SubscriptionId));
            _registryClient.SubscriptionId = TestEnvironment.SubscriptionId;

            var importSource = new ImportSource
            {
                SourceImage = "library/hello-world",
                RegistryUri = "registry.hub.docker.com"
            };

            await _registryClient.Registries.ImportImageAsync(
                resourceGroupName: TestEnvironment.ResourceGroup,
                registryName: TestEnvironment.Registry,
                parameters:
                    new ImportImageParameters
                    {
                        Mode = ImportMode.Force,
                        Source = importSource,
                        TargetTags = new List<string>()
                        {
                            $"library/hello-world:{tag}"
                        }
                    });
        }

        [RecordedTest]
        public async Task CanGetRepositoryProperties()
        {
            // Arrange
            ContainerRepositoryClient client = CreateClient();

            // Act
            RepositoryProperties properties = await client.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(_repositoryName, properties.Name);
        }

        [RecordedTest, NonParallelizable]
        public async Task CanSetRepositoryProperties()
        {
            // Arrange
            ContainerRepositoryClient client = CreateClient();
            RepositoryProperties repositoryProperties = await client.GetPropertiesAsync();
            ContentProperties originalContentProperties = repositoryProperties.WriteableProperties;

            // Act
            await client.SetPropertiesAsync(
                new ContentProperties()
                {
                    CanList = false,
                    CanRead = false,
                    CanWrite = false,
                    CanDelete = false,
                });

            // Assert
            RepositoryProperties properties = await client.GetPropertiesAsync();

            Assert.IsFalse(properties.WriteableProperties.CanList);
            Assert.IsFalse(properties.WriteableProperties.CanRead);
            Assert.IsFalse(properties.WriteableProperties.CanWrite);
            Assert.IsFalse(properties.WriteableProperties.CanDelete);

            // Cleanup
            await client.SetPropertiesAsync(originalContentProperties);
        }

        [RecordedTest]
        public async Task CanGetTagProperties()
        {
            // Arrange
            ContainerRepositoryClient client = CreateClient();
            string tag = "latest";

            // Act
            TagProperties properties = await client.GetTagPropertiesAsync(tag);

            // Assert
            Assert.AreEqual(tag, properties.Name);
            Assert.AreEqual(_repositoryName, properties.Repository);
        }

        [RecordedTest, NonParallelizable]
        public async Task CanSetTagProperties()
        {
            // Arrange
            ContainerRepositoryClient client = CreateClient();
            string tag = "latest";
            TagProperties tagProperties = await client.GetTagPropertiesAsync(tag);
            ContentProperties originalContentProperties = tagProperties.WriteableProperties;

            // Act
            await client.SetTagPropertiesAsync(
                tag,
                new ContentProperties()
                {
                    CanList = false,
                    CanRead = false,
                    CanWrite = false,
                    CanDelete = false
                });

            // Assert
            TagProperties properties = await client.GetTagPropertiesAsync(tag);

            Assert.IsFalse(properties.WriteableProperties.CanList);
            Assert.IsFalse(properties.WriteableProperties.CanRead);
            Assert.IsFalse(properties.WriteableProperties.CanWrite);
            Assert.IsFalse(properties.WriteableProperties.CanDelete);

            // Cleanup
            await client.SetTagPropertiesAsync(tag, originalContentProperties);
        }

        [RecordedTest, NonParallelizable]
        public async Task CanDeleteTag()
        {
            // Arrange
            ContainerRepositoryClient client = CreateClient();
            string tag = "test-delete";

            if (this.Mode != RecordedTestMode.Playback)
            {
                await ImportImage(tag);
            }

            // Act
            await client.DeleteTagAsync(tag);

            // Assert

            // This will be removed, pending investigation into potential race condition.
            // https://github.com/azure/azure-sdk-for-net/issues/19699
            if (this.Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(5000);
            }

            Assert.ThrowsAsync<RequestFailedException>(async () => { await client.GetTagPropertiesAsync(tag); });
        }
    }
}
