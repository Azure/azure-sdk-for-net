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

        #region Repository Tests
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
        #endregion

        #region Tag Tests
        [RecordedTest]
        public async Task CanGetTags()
        {
            // Arrange
            var client = CreateClient();

            // Act
            AsyncPageable<TagProperties> tags = client.GetTagsAsync();

            bool gotV1Tag = false;
            await foreach (TagProperties tag in tags)
            {
                if (tag.Name.Contains("v1"))
                {
                    gotV1Tag = true;
                }
            }

            // Assert
            Assert.IsTrue(gotV1Tag);
        }

        [RecordedTest]
        public async Task CanGetTagsWithCustomPageSize()
        {
            // Arrange
            var client = CreateClient();
            int pageSize = 2;
            int minExpectedPages = 2;

            // Act
            AsyncPageable<TagProperties> tags = client.GetTagsAsync();
            var pages = tags.AsPages(pageSizeHint: pageSize);

            int pageCount = 0;
            await foreach (var page in pages)
            {
                Assert.IsTrue(page.Values.Count <= pageSize);
                pageCount++;
            }

            // Assert
            Assert.IsTrue(pageCount >= minExpectedPages);
        }

        [RecordedTest]
        public async Task CanGetTagsStartingMidCollection()
        {
            // Arrange
            var client = CreateClient();
            int pageSize = 1;
            int minExpectedPages = 2;

            // Act
            AsyncPageable<TagProperties> tags = client.GetTagsAsync();
            var pages = tags.AsPages($"</acr/v1/{_repositoryName}/_tags?last=v1&n={pageSize}>");

            int pageCount = 0;
            Page<TagProperties> firstPage = null;
            await foreach (var page in pages)
            {
                if (pageCount == 0)
                {
                    firstPage = page;
                }

                Assert.IsTrue(page.Values.Count <= pageSize);
                pageCount++;
            }

            // Assert
            Assert.AreNotEqual(null, firstPage);
            Assert.AreEqual("v2", firstPage.Values[0].Name);
            Assert.IsTrue(pageCount >= minExpectedPages);
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

        [RecordedTest]
        public async Task CanGetTagsOrdered()
        {
            // Arrange
            var client = CreateClient();
            if (this.Mode != RecordedTestMode.Playback)
            {
                await ImportImage("newest");
            }

            // Act
            AsyncPageable<TagProperties> tags = client.GetTagsAsync(new GetTagOptions(TagOrderBy.LastUpdatedOnDescending));

            bool newestTagFirst = false;
            await foreach (TagProperties tag in tags)
            {
                if (tag.Name.Contains("newest"))
                {
                    newestTagFirst = true;
                }
                break;
            }

            // Assert
            Assert.IsTrue(newestTagFirst);
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
        #endregion
    }
}
