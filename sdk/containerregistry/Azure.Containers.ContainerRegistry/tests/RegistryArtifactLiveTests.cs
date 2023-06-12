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
        [Ignore("Known service regression with scheduled fix 01/12/2023.")]
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
            var client = CreateClient();
            string tag = "latest";
            var artifact = client.GetArtifact(_repositoryName, tag);

            ArtifactManifestProperties artifactProperties = await artifact.GetManifestPropertiesAsync();
            ArtifactManifestProperties originalProperties = artifactProperties;

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

            // Cleanup
            await artifact.UpdateManifestPropertiesAsync(originalProperties);
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

        [RecordedTest]
        public async Task CanDeleteRegistryArtifact()
        {
            // Arrange
            var client = CreateClient();
            var repositoryId = Recording.Random.NewGuid().ToString();
            var tag = "v1";
            var artifact = client.GetArtifact(repositoryId, tag);

            try
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await CreateImageAsync(repositoryId, tag);
                }

                var properties = await artifact.GetManifestPropertiesAsync();
                Assert.AreEqual(1, properties.Value.Tags.Count);
                Assert.AreEqual(tag, properties.Value.Tags[0]);

                // Act
                await artifact.DeleteAsync();
                await Delay(5000);

                await Delay(5000);

                // Assert
                Assert.ThrowsAsync<RequestFailedException>(async () => { await artifact.GetManifestPropertiesAsync(); });
            }
            finally
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await DeleteRepositoryAsync(repositoryId);
                }
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
            AsyncPageable<ArtifactTagProperties> tags = artifact.GetAllTagPropertiesAsync();

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
            AsyncPageable<ArtifactTagProperties> tags = artifact.GetAllTagPropertiesAsync();
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
            AsyncPageable<ArtifactTagProperties> tags = artifact.GetAllTagPropertiesAsync();
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
        [TestCase(true)]
        [TestCase(false)]
        public async Task CanGetTagsOrdered(bool anonymous)
        {
            // Arrange
            var client = CreateClient(anonymous);
            var repositoryId = Recording.Random.NewGuid().ToString();
            List<string> tags = new List<string>() { "v1", "v2" };
            var artifact = client.GetArtifact(repositoryId, tags[0]);

            Uri endpoint = anonymous ?
                new Uri(TestEnvironment.AnonymousAccessEndpoint) :
                new Uri(TestEnvironment.Endpoint);

            try
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await CreateImageAsync(endpoint, repositoryId, tags[0]);
                    await AddTagAsync(endpoint, repositoryId, tags[0], tags[1]);
                }

                // Act
                AsyncPageable<ArtifactTagProperties> allTags = artifact.GetAllTagPropertiesAsync(ArtifactTagOrder.LastUpdatedOnAscending);

                // Assert
                int i = 0;
                await foreach (ArtifactTagProperties tag in allTags)
                {
                    Assert.AreEqual(tags[i], tag.Name);
                    i++;
                }

                Assert.AreEqual(2, i);
            }
            finally
            {
                // Clean up
                if (Mode != RecordedTestMode.Playback)
                {
                    await DeleteRepositoryAsync(endpoint, repositoryId);
                }
            }
        }

        [RecordedTest, NonParallelizable]
        public async Task CanSetTagProperties()
        {
            // Arrange
            var client = CreateClient();
            string tag = "latest";
            var artifact = client.GetArtifact(_repositoryName, tag);

            ArtifactTagProperties tagProperties = await artifact.GetTagPropertiesAsync(tag);
            ArtifactTagProperties originalWriteableProperties = tagProperties;

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

            // Cleanup
            await artifact.UpdateTagPropertiesAsync(tag, originalWriteableProperties);
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

        [RecordedTest]
        public async Task CanDeleteTag()
        {
            // Arrange
            var client = CreateClient();
            var repositoryId = Recording.Random.NewGuid().ToString();
            string tag = "test-delete-tag";
            var artifact = client.GetArtifact(repositoryId, tag);

            try
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await CreateImageAsync(repositoryId, tag);
                }

                var properties = await artifact.GetManifestPropertiesAsync();
                Assert.AreEqual(1, properties.Value.Tags.Count);
                Assert.AreEqual(tag, properties.Value.Tags[0]);

                // Act
                await artifact.DeleteTagAsync(tag);

                // Assert
                Assert.ThrowsAsync<RequestFailedException>(async () => { await artifact.GetTagPropertiesAsync(tag); });
            }
            finally
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await DeleteRepositoryAsync(repositoryId);
                }
            }
        }
        #endregion
    }
}
