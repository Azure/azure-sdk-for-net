// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Task = System.Threading.Tasks.Task;

namespace Azure.Containers.ContainerRegistry.Tests
{
    public class ContainerRepositoryLiveTests : ContainerRegistryRecordedTestBase
    {
        private readonly string _repositoryName = "library/hello-world";

        public ContainerRepositoryLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CanGetRepositoryProperties()
        {
            // Arrange
            var client = CreateClient();
            var repository = client.GetRepository(_repositoryName);

            // Act
            ContainerRepositoryProperties properties = await repository.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(_repositoryName, properties.Name);
        }

        [RecordedTest, NonParallelizable]
        public async Task CanSetRepositoryProperties()
        {
            // Arrange
            string registry = TestEnvironment.Registry;
            string sourceRepository = $"library/hello-world";
            string targetRepository = $"hello-world-3{GetPlatformSuffix()}";
            List<string> tags = new List<string>()
            {
                "test-set-repo-properties"
            };

            var client = CreateClient();
            var repository = client.GetRepository(targetRepository);

            try
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await ImportImageAsync(registry, sourceRepository, tags, targetRepository);
                }

                // Act
                ContainerRepositoryProperties properties = await repository.UpdatePropertiesAsync(
                    new ContainerRepositoryProperties()
                    {
                        CanList = false,
                        CanRead = false,
                        CanWrite = false,
                        CanDelete = false,
                    });

                // Assert
                Assert.IsFalse(properties.CanList);
                Assert.IsFalse(properties.CanRead);
                Assert.IsFalse(properties.CanWrite);
                Assert.IsFalse(properties.CanDelete);

                ContainerRepositoryProperties updatedProperties = await repository.GetPropertiesAsync();

                Assert.IsFalse(updatedProperties.CanList);
                Assert.IsFalse(updatedProperties.CanRead);
                Assert.IsFalse(updatedProperties.CanWrite);
                Assert.IsFalse(updatedProperties.CanDelete);
            }
            finally
            {
                // Clean up
                ContainerRepositoryProperties properties = await repository.UpdatePropertiesAsync(
                    new ContainerRepositoryProperties()
                    {
                        CanList = true,
                        CanRead = true,
                        CanWrite = true,
                        CanDelete = true,
                    });

                await repository.DeleteAsync();
            }
        }

        [RecordedTest, NonParallelizable]
        public void CanSetRepositoryProperties_Anonymous()
        {
            // Arrange
            var client = CreateClient(anonymousAccess: true);
            var repository = client.GetRepository(_repositoryName);

            // Act
            Assert.ThrowsAsync<RequestFailedException>((AsyncTestDelegate)(() =>
                repository.UpdatePropertiesAsync(
                    new ContainerRepositoryProperties()
                    {
                        CanList = false,
                        CanRead = false,
                        CanWrite = false,
                        CanDelete = false,
                    })));
        }

        [RecordedTest, NonParallelizable]
        public async Task CanDeleteRepository()
        {
            // Arrange
            string registry = TestEnvironment.Registry;
            string sourceRepository = $"library/hello-world";
            string targetRepository = $"hello-world-2{GetPlatformSuffix()}";
            List<string> tags = new List<string>()
            {
                "test-delete-repo"
            };

            var client = CreateClient();
            var repository = client.GetRepository(targetRepository);

            if (Mode != RecordedTestMode.Playback)
            {
                await ImportImageAsync(registry, sourceRepository, tags, targetRepository);
            }

            // Act
            await repository.DeleteAsync();

            // Assert
            Assert.ThrowsAsync<RequestFailedException>(async () => { await repository.GetPropertiesAsync(); });
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CanGetManifests(bool anonymous)
        {
            // Arrange
            var client = CreateClient(anonymous);
            var repository = client.GetRepository(_repositoryName);

            // Act
            AsyncPageable<ArtifactManifestProperties> manifests = repository.GetManifestPropertiesCollectionAsync();

            ArtifactManifestProperties latest = null;
            await foreach (ArtifactManifestProperties manifest in manifests)
            {
                if (manifest.Tags.Count > 0 && manifest.Tags.Contains("latest"))
                {
                    latest = manifest;
                    break;
                }
            }

            // Assert
            Assert.IsNotNull(latest);
            Assert.AreEqual(_repositoryName, latest.RepositoryName);
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CanGetManifestsWithCustomPageSize(bool anonymous)
        {
            // Arrange
            var client = CreateClient(anonymous);
            var repository = client.GetRepository(_repositoryName);
            int pageSize = 2;
            int minExpectedPages = 2;

            // Act
            AsyncPageable<ArtifactManifestProperties> artifacts = repository.GetManifestPropertiesCollectionAsync();
            var pages = artifacts.AsPages(pageSizeHint: pageSize);

            // Assert
            int pageCount = await pages.CountAsync();
            Assert.GreaterOrEqual(pageCount, minExpectedPages);
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CanGetArtifactsStartingMidCollection(bool anonymous)
        {
            // Arrange
            var client = CreateClient(anonymous);
            var repository = client.GetRepository(_repositoryName);
            int pageSize = 1;
            int minExpectedPages = 2;

            AsyncPageable<ArtifactManifestProperties> manifests = repository.GetManifestPropertiesCollectionAsync();
            string firstDigest = null;
            string secondDigest = null;
            int artifactCount = 0;
            await foreach (var manifest in manifests)
            {
                if (artifactCount == 0)
                {
                    firstDigest = manifest.Digest;
                }

                if (artifactCount == 1)
                {
                    secondDigest = manifest.Digest;
                    break;
                }

                artifactCount++;
            }

            // Act
            manifests = repository.GetManifestPropertiesCollectionAsync();
            var pages = manifests.AsPages($"</acr/v1/{_repositoryName}/_manifests?last={firstDigest}&n={pageSize}>");

            int pageCount = 0;
            Page<ArtifactManifestProperties> firstPage = null;
            await foreach (var page in pages)
            {
                if (pageCount == 0)
                {
                    firstPage = page;
                }

                Assert.LessOrEqual(page.Values.Count, pageSize);
                pageCount++;
            }

            // Assert
            Assert.AreNotEqual(null, firstPage);
            Assert.AreEqual(secondDigest, firstPage.Values[0].Digest);
            Assert.GreaterOrEqual(pageCount, minExpectedPages);
        }

        [RecordedTest]
        public async Task CanGetManifestsOrdered()
        {
            // Arrange
            string registry = TestEnvironment.Registry;
            string sourceRepository = $"library/node";
            string targetRepository = $"node-1{GetPlatformSuffix()}";

            var client = CreateClient();
            var repository = client.GetRepository(targetRepository);

            string oldDigest = "sha256:b2e85fe0e037a625d601a81ce962d196bec948cab3d68278ab4a5dd177da59e2";
            string newDigest = "sha256:5e5d07de2101ee559c51656ddfe9f78b8ee5f02932979a6b60343dc1e3abeebb";

            try
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await ImportImageByDigestAsync(registry, sourceRepository, oldDigest, targetRepository, "oldest");

                    await Task.Delay(1000);

                    await ImportImageByDigestAsync(registry, sourceRepository, newDigest, targetRepository, "newest");
                }

                // Act
                AsyncPageable<ArtifactManifestProperties> manifests = repository.GetManifestPropertiesCollectionAsync(ArtifactManifestOrderBy.LastUpdatedOnDescending);

                // Assert
                await foreach (ArtifactManifestProperties manifest in manifests)
                {
                    // The newer manifest should appear first given the sort order we specified
                    Assert.AreEqual(targetRepository, manifest.RepositoryName);
                    Assert.AreEqual(newDigest, manifest.Digest);
                    break;
                }
            }
            finally
            {
                // Clean up
                await repository.DeleteAsync();
            }
        }
    }
}
