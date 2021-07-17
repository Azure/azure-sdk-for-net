// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Task = System.Threading.Tasks.Task;

namespace Azure.Containers.ContainerRegistry.Tests
{
    public class RegistryArtifactLiveTests : ContainerRegistryRecordedTestBase
    {
        private readonly string _repositoryName = "library/hello-world";

        public RegistryArtifactLiveTests(bool isAsync) : base(isAsync)
        {
        }

        #region Manifest Tests
        [RecordedTest]
        public async Task CanGetManifestListProperties()
        {
            // Arrange
            var client = CreateClient();
            string tag = "v1";
            var artifact = client.GetArtifact(_repositoryName, tag);
            int helloWorldRelatedArtifacts = 9;

            // Act
            ArtifactManifestProperties properties = await artifact.GetManifestPropertiesAsync();

            // Assert
            Assert.Contains(tag, properties.Tags.ToList());
            Assert.AreEqual(_repositoryName, properties.RepositoryName);
            Assert.GreaterOrEqual(properties.RelatedArtifacts.Count, helloWorldRelatedArtifacts);

            Assert.IsTrue(properties.RelatedArtifacts.Any(
                artifact =>
                    artifact.Architecture == "arm64" &&
                    artifact.OperatingSystem == "linux"));

            Assert.IsTrue(properties.RelatedArtifacts.Any(
                artifact =>
                    artifact.Architecture == "amd64" &&
                    artifact.OperatingSystem == "windows"));
        }

        [RecordedTest]
        public async Task CanGetManifestProperties()
        {
            // Arrange
            var client = CreateClient();
            string tag = "v1";
            var artifact = client.GetArtifact(_repositoryName, tag);

            // Act
            ArtifactManifestProperties manifestListProperties = await artifact.GetManifestPropertiesAsync();
            var arm64LinuxImage = manifestListProperties.RelatedArtifacts.First(
                artifact =>
                    artifact.Architecture == "arm64" &&
                    artifact.OperatingSystem == "linux");
            var childArtifact = client.GetArtifact(_repositoryName, arm64LinuxImage.Digest);
            ArtifactManifestProperties properties = await childArtifact.GetManifestPropertiesAsync();

            // Assert
            Assert.AreEqual(_repositoryName, properties.RepositoryName);
            Assert.IsNotNull(properties.Digest);
            Assert.AreEqual(ArtifactArchitecture.Arm64, properties.Architecture);
            Assert.AreEqual(ArtifactOperatingSystem.Linux, properties.OperatingSystem);
        }

        [RecordedTest, NonParallelizable]
        public async Task CanSetManifestProperties()
        {
            // Arrange
            string registry = TestEnvironment.Registry;
            string sourceRepository = $"library/hello-world";
            string targetRepository = $"hello-world-4{GetPlatformSuffix()}";
            string tag = "test-set-manifest-properties";

            var client = CreateClient();
            var artifact = client.GetArtifact(targetRepository, tag);

            try
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await ImportImageAsync(registry, sourceRepository, tag, targetRepository);
                }

                // Act
                ArtifactManifestProperties properties = await artifact.UpdateManifestPropertiesAsync(
                    new ArtifactManifestProperties()
                    {
                        CanList = false,
                        CanRead = false,
                        CanWrite = false,
                        CanDelete = false
                    });

                // Assert
                Assert.IsFalse(properties.CanList);
                Assert.IsFalse(properties.CanRead);
                Assert.IsFalse(properties.CanWrite);
                Assert.IsFalse(properties.CanDelete);

                ArtifactManifestProperties updatedProperties = await artifact.GetManifestPropertiesAsync();

                Assert.IsFalse(updatedProperties.CanList);
                Assert.IsFalse(updatedProperties.CanRead);
                Assert.IsFalse(updatedProperties.CanWrite);
                Assert.IsFalse(updatedProperties.CanDelete);
            }
            finally
            {
                // Clean up
                await artifact.UpdateManifestPropertiesAsync(
                    new ArtifactManifestProperties()
                    {
                        CanList = true,
                        CanRead = true,
                        CanWrite = true,
                        CanDelete = true
                    });

                var repository = client.GetRepository(targetRepository);
                await repository.DeleteAsync();
            }
        }

        [RecordedTest, NonParallelizable]
        public void CanSetManifestProperties_Anonymous()
        {
            // Arrange
            var client = CreateClient(anonymousAccess: true);
            string tag = "latest";
            var artifact = client.GetArtifact(_repositoryName, tag);

            // Act
            Assert.ThrowsAsync<RequestFailedException>(() => artifact.UpdateManifestPropertiesAsync(
                new ArtifactManifestProperties()
                {
                    CanList = false,
                    CanRead = false,
                    CanWrite = false,
                    CanDelete = false
                }));
        }

        [RecordedTest, NonParallelizable]
        public async Task CanDeleteRegistryArtifact()
        {
            // Arrange
            string repository = $"library/node";
            string targetRepository = $"node-2{GetPlatformSuffix()}";
            string tag = "test-delete-image";
            var client = CreateClient();
            var artifact = client.GetArtifact(targetRepository, tag);

            try
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await ImportImageAsync(TestEnvironment.Registry, repository, tag, targetRepository);
                }

                // Act
                await artifact.DeleteAsync();

                // Assert
                Assert.ThrowsAsync<RequestFailedException>(async () => { await artifact.GetManifestPropertiesAsync(); });
            }
            finally
            {
                // Clean up
                var repositoryClient = client.GetRepository(targetRepository);
                await repositoryClient.DeleteAsync();
            }
        }

        #endregion

        #region Tag Tests
        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CanGetTags(bool anonymous)
        {
            // Arrange
            var client = CreateClient(anonymous);
            string tagName = "latest";
            var artifact = client.GetArtifact(_repositoryName, tagName);

            // Act
            AsyncPageable<ArtifactTagProperties> tags = artifact.GetTagPropertiesCollectionAsync();

            bool gotV1Tag = false;
            await foreach (ArtifactTagProperties tag in tags)
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
        [TestCase(true)]
        [TestCase(false)]
        public async Task CanGetTagsWithCustomPageSize(bool anonymous)
        {
            // Arrange
            var client = CreateClient(anonymous);
            string tagName = "latest";
            var artifact = client.GetArtifact(_repositoryName, tagName);
            int pageSize = 2;
            int minExpectedPages = 2;

            // Act
            AsyncPageable<ArtifactTagProperties> tags = artifact.GetTagPropertiesCollectionAsync();
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
        [TestCase(true)]
        [TestCase(false)]
        public async Task CanGetTagsStartingMidCollection(bool anonymous)
        {
            // Arrange
            var client = CreateClient();
            string tagName = "latest";
            var artifact = client.GetArtifact(_repositoryName, tagName);
            int pageSize = 1;
            int minExpectedPages = 2;

            // Act
            AsyncPageable<ArtifactTagProperties> tags = artifact.GetTagPropertiesCollectionAsync();
            var pages = tags.AsPages($"</acr/v1/{_repositoryName}/_tags?last=v1&n={pageSize}>");

            int pageCount = 0;
            Page<ArtifactTagProperties> firstPage = null;
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
            Assert.GreaterOrEqual(pageCount, minExpectedPages);
        }

        [RecordedTest]
        public async Task CanGetTagProperties()
        {
            // Arrange
            var client = CreateClient();
            string tag = "latest";
            var artifact = client.GetArtifact(_repositoryName, tag);

            // Act
            ArtifactTagProperties properties = await artifact.GetTagPropertiesAsync(tag);

            // Assert
            Assert.AreEqual(tag, properties.Name);
            Assert.AreEqual(_repositoryName, properties.RepositoryName);
        }

        [RecordedTest]
        public async Task CanGetTagsOrdered()
        {
            // Arrange
            string registry = TestEnvironment.Registry;
            string sourceRepository = $"library/node";
            string targetRepository = $"node-3{GetPlatformSuffix()}";

            var client = CreateClient();
            var artifact = client.GetArtifact(targetRepository, "oldest");

            try
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await ImportImageAsync(registry, sourceRepository, "oldest", targetRepository);
                    await Task.Delay(1000);
                    await ImportImageAsync(registry, sourceRepository, "newest", targetRepository);
                }

                // Act
                AsyncPageable<ArtifactTagProperties> tags = artifact.GetTagPropertiesCollectionAsync(ArtifactTagOrderBy.LastUpdatedOnDescending);

                // Assert
                await foreach (ArtifactTagProperties tag in tags)
                {
                    // The newer tag should appear first given the sort order we specified
                    Assert.AreEqual(targetRepository, tag.RepositoryName);
                    Assert.AreEqual("newest", tag.Name);
                    break;
                }
            }
            finally
            {
                // Clean up
                var repository = client.GetRepository(targetRepository);
                await repository.DeleteAsync();
            }
        }

        [RecordedTest, NonParallelizable]
        public async Task CanSetTagProperties()
        {
            // Arrange
            string registry = TestEnvironment.Registry;
            string sourceRepository = $"library/hello-world";
            string targetRepository = $"hello-world-5{GetPlatformSuffix()}";
            string tag = "test-set-tag-properties";

            var client = CreateClient();
            var artifact = client.GetArtifact(targetRepository, tag);

            try
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await ImportImageAsync(registry, sourceRepository, tag, targetRepository);
                }

                // Act
                ArtifactTagProperties properties = await artifact.UpdateTagPropertiesAsync(
                    tag,
                    new ArtifactTagProperties()
                    {
                        CanList = false,
                        CanRead = false,
                        CanWrite = false,
                        CanDelete = false
                    });

                // Assert
                Assert.IsFalse(properties.CanList);
                Assert.IsFalse(properties.CanRead);
                Assert.IsFalse(properties.CanWrite);
                Assert.IsFalse(properties.CanDelete);

                ArtifactTagProperties updatedProperties = await artifact.GetTagPropertiesAsync(tag);

                Assert.IsFalse(updatedProperties.CanList);
                Assert.IsFalse(updatedProperties.CanRead);
                Assert.IsFalse(updatedProperties.CanWrite);
                Assert.IsFalse(updatedProperties.CanDelete);
            }
            finally
            {
                // Clean up
                await artifact.UpdateTagPropertiesAsync(
                    tag,
                    new ArtifactTagProperties()
                    {
                        CanList = true,
                        CanRead = true,
                        CanWrite = true,
                        CanDelete = true,
                    });

                var repository = client.GetRepository(targetRepository);
                await repository.DeleteAsync();
            }
        }

        [RecordedTest, NonParallelizable]
        public void CanSetTagProperties_Anonymous()
        {
            // Arrange
            var client = CreateClient(anonymousAccess: true);
            string tag = "latest";
            var artifact = client.GetArtifact(_repositoryName, tag);

            // Act
            Assert.ThrowsAsync<RequestFailedException>(() => artifact.UpdateTagPropertiesAsync(
                tag,
                new ArtifactTagProperties()
                {
                    CanList = false,
                    CanRead = false,
                    CanWrite = false,
                    CanDelete = false
                }));
        }

        [RecordedTest, NonParallelizable]
        public async Task CanDeleteTag()
        {
            // Arrange
            string registry = TestEnvironment.Registry;
            string sourceRepository = $"library/hello-world";
            string targetRepository = $"hello-world-6{GetPlatformSuffix()}";
            string tag = "test-delete-tag";

            var client = CreateClient();
            var artifact = client.GetArtifact(targetRepository, tag);

            try
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await ImportImageAsync(registry, sourceRepository, tag, targetRepository);
                }

                // Act
                await artifact.DeleteTagAsync(tag);

                // Assert
                Assert.ThrowsAsync<RequestFailedException>(async () => { await artifact.GetTagPropertiesAsync(tag); });
            }
            finally
            {
                // Clean up
                var repositoryClient = client.GetRepository(targetRepository);
                await repositoryClient.DeleteAsync();
            }
        }
        #endregion
    }
}
