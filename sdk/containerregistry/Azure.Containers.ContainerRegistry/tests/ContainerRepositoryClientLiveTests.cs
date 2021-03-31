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
    public class ContainerRepositoryClientLiveTests : ContainerRegistryRecordedTestBase
    {
        private readonly string _repositoryName = "library/hello-world";

        public ContainerRepositoryClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        #region Setup methods
        protected ContainerRepositoryClient CreateClient(string repository = null)
        {
            return InstrumentClient(new ContainerRepositoryClient(
                new Uri(TestEnvironment.Endpoint),
                repository ?? _repositoryName,
                TestEnvironment.Credential,
                InstrumentClientOptions(new ContainerRegistryClientOptions())
            ));
        }

        #endregion

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

            try
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await ImportImage(_repositoryName, tags);
                }

                // Act
                await client.DeleteAsync();

                // This will be removed, pending investigation into potential race condition.
                // https://github.com/azure/azure-sdk-for-net/issues/19699
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(5000);
                }

                // Assert
                Assert.ThrowsAsync<RequestFailedException>(async () => { await client.GetPropertiesAsync(); });
            }
            finally
            {
                // Clean up - put the repository with tags back.
                if (Mode != RecordedTestMode.Playback)
                {
                    await ImportImage(_repositoryName, tags);
                }
            }
        }
        #endregion

        #region Registry Artifact Tests
        [RecordedTest]
        public async Task CanGetMultiArchitectureImageProperties()
        {
            // Arrange
            ContainerRepositoryClient client = CreateClient();
            string tag = "v1";
            int helloWorldManifestReferences = 9;

            // Act
            RegistryArtifactProperties properties = await client.GetRegistryArtifactPropertiesAsync(tag);

            // Assert
            Assert.Contains(tag, properties.Tags.ToList());
            Assert.AreEqual(_repositoryName, properties.Repository);
            Assert.GreaterOrEqual(helloWorldManifestReferences, properties.RegistryArtifacts.Count);

            Assert.IsTrue(properties.RegistryArtifacts.Any(
                artifact =>
                    artifact.CpuArchitecture == "arm64" &&
                    artifact.OperatingSystem == "linux"));

            Assert.IsTrue(properties.RegistryArtifacts.Any(
                artifact =>
                    artifact.CpuArchitecture == "amd64" &&
                    artifact.OperatingSystem == "windows"));
        }

        [RecordedTest]
        public async Task CanGetArtifactProperties()
        {
            // Arrange
            ContainerRepositoryClient client = CreateClient();
            string tag = "v1";

            // Act
            RegistryArtifactProperties listProperties = await client.GetRegistryArtifactPropertiesAsync(tag);
            var arm64LinuxImage = listProperties.RegistryArtifacts.First(
                artifact =>
                    artifact.CpuArchitecture == "arm64" &&
                    artifact.OperatingSystem == "linux");
            RegistryArtifactProperties properties = await client.GetRegistryArtifactPropertiesAsync(arm64LinuxImage.Digest);

            // Assert
            Assert.AreEqual(_repositoryName, properties.Repository);
            Assert.IsNotNull(properties.Digest);
            Assert.AreEqual("arm64", properties.CpuArchitecture);
            Assert.AreEqual("linux", properties.OperatingSystem);
        }

        [RecordedTest, NonParallelizable]
        public async Task CanSetManifestProperties()
        {
            // Arrange
            ContainerRepositoryClient client = CreateClient();
            string tag = "latest";
            TagProperties tagProperties = await client.GetTagPropertiesAsync(tag);
            string digest = tagProperties.Digest;
            RegistryArtifactProperties artifactProperties = await client.GetRegistryArtifactPropertiesAsync(digest);
            ContentProperties originalContentProperties = artifactProperties.WriteableProperties;

            // Act
            await client.SetManifestPropertiesAsync(
                digest,
                new ContentProperties()
                {
                    CanList = false,
                    CanRead = false,
                    CanWrite = false,
                    CanDelete = false
                });

            // Assert
            RegistryArtifactProperties properties = await client.GetRegistryArtifactPropertiesAsync(digest);

            Assert.IsFalse(properties.WriteableProperties.CanList);
            Assert.IsFalse(properties.WriteableProperties.CanRead);
            Assert.IsFalse(properties.WriteableProperties.CanWrite);
            Assert.IsFalse(properties.WriteableProperties.CanDelete);

            // Cleanup
            await client.SetManifestPropertiesAsync(digest, originalContentProperties);
        }

        [RecordedTest, NonParallelizable]
        public async Task CanDeleteRegistryArtifact()
        {
            // Arrange
            string repository = $"library/node";
            string tag = "test-delete-image";
            ContainerRepositoryClient client = CreateClient(repository);

            if (Mode != RecordedTestMode.Playback)
            {
                await ImportImage(repository, tag);
            }

            TagProperties tagProperties = await client.GetTagPropertiesAsync(tag);
            string digest = tagProperties.Digest;

            // Act
            await client.DeleteRegistryArtifactAsync(digest);

            // Assert

            // This will be removed, pending investigation into potential race condition.
            // https://github.com/azure/azure-sdk-for-net/issues/19699
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(5000);
            }

            Assert.ThrowsAsync<RequestFailedException>(async () => { await client.GetRegistryArtifactPropertiesAsync(tag); });
        }

        [RecordedTest]
        public async Task CanGetArtifacts()
        {
            // Arrange
            var client = CreateClient();

            // Act
            AsyncPageable<RegistryArtifactProperties> images = client.GetRegistryArtifactsAsync();

            RegistryArtifactProperties latest = null;
            await foreach (RegistryArtifactProperties image in images)
            {
                if (image.Tags.Count > 0 && image.Tags.Contains("latest"))
                {
                    latest = image;
                    break;
                }
            }

            // Assert
            Assert.IsNotNull(latest);
            Assert.AreEqual(_repositoryName, latest.Repository);
        }

        [RecordedTest]
        public async Task CanGetArtifactsWithCustomPageSize()
        {
            // Arrange
            var client = CreateClient();
            int pageSize = 2;
            int minExpectedPages = 2;

            // Act
            AsyncPageable<RegistryArtifactProperties> artifacts = client.GetRegistryArtifactsAsync();
            var pages = artifacts.AsPages(pageSizeHint: pageSize);

            int pageCount = 0;
            await foreach (var page in pages)
            {
                Assert.GreaterOrEqual(page.Values.Count, pageSize);
                pageCount++;
            }

            // Assert
            Assert.IsTrue(pageCount >= minExpectedPages);
        }

        [RecordedTest]
        public async Task CanGetArtifactsStartingMidCollection()
        {
            // Arrange
            var client = CreateClient();
            int pageSize = 1;
            int minExpectedPages = 2;

            AsyncPageable<RegistryArtifactProperties> artifacts = client.GetRegistryArtifactsAsync();
            string firstDigest = null;
            string secondDigest = null;
            int artifactCount = 0;
            await foreach (var artifact in artifacts)
            {
                if (artifactCount == 0)
                {
                    firstDigest = artifact.Digest;
                }

                if (artifactCount == 1)
                {
                    secondDigest = artifact.Digest;
                    break;
                }

                artifactCount++;
            }

            // Act
            artifacts = client.GetRegistryArtifactsAsync();
            var pages = artifacts.AsPages($"</acr/v1/{_repositoryName}/_manifests?last={firstDigest}&n={pageSize}>");

            int pageCount = 0;
            Page<RegistryArtifactProperties> firstPage = null;
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
        public async Task CanGetArtifactsOrdered()
        {
            // Arrange
            string repository = $"library/node";
            string tag = "newest";
            var client = CreateClient(repository);

            try
            {
                if (Mode != RecordedTestMode.Playback)
                {
                    await ImportImage(repository, tag);
                }

                // Act
                AsyncPageable<RegistryArtifactProperties> artifacts = client.GetRegistryArtifactsAsync(new GetRegistryArtifactOptions(RegistryArtifactOrderBy.LastUpdatedOnDescending));

                // Assert
                string digest = null;
                await foreach (RegistryArtifactProperties artifact in artifacts)
                {
                    digest = artifact.Digest;
                    Assert.That(artifact.Repository.Contains(repository));
                    Assert.That(artifact.Tags.Contains(tag));
                    break;
                }
            }
            finally
            {
                // Clean up
                var properties = await client.GetTagPropertiesAsync(tag).ConfigureAwait(false);
                await client.DeleteRegistryArtifactAsync(properties.Value.Digest);
            }
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
            Assert.GreaterOrEqual(pageCount, minExpectedPages);
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
            if (Mode != RecordedTestMode.Playback)
            {
                await ImportImage(_repositoryName, "newest");
            }

            // Act
            AsyncPageable<TagProperties> tags = client.GetTagsAsync(new GetTagOptions(TagOrderBy.LastUpdatedOnDescending));

            // Assert
            await foreach (TagProperties tag in tags)
            {
                Assert.That(tag.Name.Contains("newest"));
                break;
            }
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
            string tag = "test-delete-tag";

            if (Mode != RecordedTestMode.Playback)
            {
                await ImportImage(_repositoryName, tag);
            }

            // Act
            await client.DeleteTagAsync(tag);

            // Assert

            // This will be removed, pending investigation into potential race condition.
            // https://github.com/azure/azure-sdk-for-net/issues/19699
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(5000);
            }

            Assert.ThrowsAsync<RequestFailedException>(async () => { await client.GetTagPropertiesAsync(tag); });
        }
        #endregion
    }
}
