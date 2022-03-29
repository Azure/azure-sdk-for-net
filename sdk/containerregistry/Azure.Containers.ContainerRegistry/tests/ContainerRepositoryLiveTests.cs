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
            var client = CreateClient();
            var repository = client.GetRepository(_repositoryName);

            ContainerRepositoryProperties repositoryProperties = await repository.GetPropertiesAsync();
            ContainerRepositoryProperties originalProperties = repositoryProperties;

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

            // Cleanup
            await repository.UpdatePropertiesAsync(originalProperties);
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
            List<string> tags = new List<string>()
            {
                "latest",
                "v1",
                "v2",
                "v3",
                "v4",
            };

            var client = CreateClient();
            var repository = client.GetRepository(_repositoryName);

            try
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await ImportImageAsync(TestEnvironment.Registry, _repositoryName, tags);
                }

                // Act
                await repository.DeleteAsync();

                // Assert
                Assert.ThrowsAsync<RequestFailedException>(async () => { await repository.GetPropertiesAsync(); });
            }
            finally
            {
                // Clean up - put the repository with tags back.
                if (Mode != RecordedTestMode.Playback)
                {
                    await ImportImageAsync(TestEnvironment.Registry, _repositoryName, tags);
                }
            }
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
            AsyncPageable<ArtifactManifestProperties> manifests = repository.GetAllManifestPropertiesAsync();

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
            AsyncPageable<ArtifactManifestProperties> artifacts = repository.GetAllManifestPropertiesAsync();
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

            AsyncPageable<ArtifactManifestProperties> manifests = repository.GetAllManifestPropertiesAsync();
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
            manifests = repository.GetAllManifestPropertiesAsync();
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
            string repositoryName = $"library/node";
            string tag = "newest";
            var client = CreateClient();
            var repository = client.GetRepository(repositoryName);
            var artifact = client.GetArtifact(repositoryName, tag);

            try
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await ImportImageAsync(TestEnvironment.Registry, repositoryName, tag);
                }

                // Act
                AsyncPageable<ArtifactManifestProperties> manifests = repository.GetAllManifestPropertiesAsync(ArtifactManifestOrder.LastUpdatedOnDescending);

                // Assert
                string digest = null;
                await foreach (ArtifactManifestProperties manifest in manifests)
                {
                    // Make sure we're looking at a manifest list, which has the tag
                    if (manifest.RelatedArtifacts != null && manifest.RelatedArtifacts.Count > 0)
                    {
                        digest = manifest.Digest;
                        Assert.That(manifest.RepositoryName.Contains(repositoryName));
                        Assert.That(manifest.Tags.Contains(tag));
                        break;
                    }
                }
            }
            finally
            {
                // Clean up
                await artifact.DeleteAsync();
            }
        }
    }
}
