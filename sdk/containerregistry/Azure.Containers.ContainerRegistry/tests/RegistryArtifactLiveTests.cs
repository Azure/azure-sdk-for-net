// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Linq;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Task = System.Threading.Tasks.Task;
using Azure.Containers.ContainerRegistry.Specialized;
using Azure.Identity;

namespace Azure.Containers.ContainerRegistry.Tests
{
    public class RegistryArtifactLiveTests : ContainerRegistryRecordedTestBase
    {
        private readonly string _repositoryName = "library/hello-world";
        //private readonly string _repositoryName = "hello-artifact";

        public RegistryArtifactLiveTests(bool isAsync) : base(isAsync, RecordedTestMode.Live)
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

        [RecordedTest, NonParallelizable]
        public async Task CanDeleteRegistryArtifact()
        {
            // Arrange
            string repository = $"library/node";
            string tag = "test-delete-image";
            var client = CreateClient();
            var artifact = client.GetArtifact(repository, tag);

            if (Mode != RecordedTestMode.Playback)
            {
                await ImportImageAsync(TestEnvironment.Registry, repository, tag);
            }

            // Act
            await artifact.DeleteAsync();

            // Assert
            Assert.ThrowsAsync<RequestFailedException>(async () => { await artifact.GetManifestPropertiesAsync(); });
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
        [TestCase(true)]
        [TestCase(false)]
        public async Task CanGetTagsOrdered(bool anonymous)
        {
            // Arrange
            var client = CreateClient(anonymous);
            string registry = anonymous ? TestEnvironment.AnonymousAccessRegistry : TestEnvironment.Registry;
            string tagName = "latest";
            var artifact = client.GetArtifact(_repositoryName, tagName);

            if (Mode != RecordedTestMode.Playback)
            {
                await ImportImageAsync(registry, _repositoryName, "newest");
            }

            // Act
            AsyncPageable<ArtifactTagProperties> tags = artifact.GetTagPropertiesCollectionAsync(ArtifactTagOrderBy.LastUpdatedOnDescending);

            // Assert
            await foreach (ArtifactTagProperties tag in tags)
            {
                Assert.That(tag.Name.Contains("newest"));
                break;
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

        [RecordedTest, NonParallelizable]
        public async Task CanDeleteTag()
        {
            // Arrange
            var client = CreateClient();
            string tag = "test-delete-tag";
            var artifact = client.GetArtifact(_repositoryName, tag);

            if (Mode != RecordedTestMode.Playback)
            {
                await ImportImageAsync(TestEnvironment.Registry, _repositoryName, tag);
            }

            // Act
            await artifact.DeleteTagAsync(tag);

            // Assert
            Assert.ThrowsAsync<RequestFailedException>(async () => { await artifact.GetTagPropertiesAsync(tag); });
        }
        #endregion

        //#region Push/Pull Tests - for prototype usage only

        //[RecordedTest, NonParallelizable]
        //public async Task CanPushArtifact()
        //{
        //    // Arrange
        //    var client = CreateClient();
        //    var artifact = client.GetArtifact(_repositoryName, "sha256:1b26826f602946860c279fce658f31050cff2c596583af237d971f4629b57792");

        //    // Act
        //    await artifact.PushAsync(@"C:\temp\acr-pull");

        //    // Assert
        //    // TODO
        //}

        //[RecordedTest, NonParallelizable]
        //public async Task CanPullArtifact_DockerManifestV2_ByTagName()
        //{
        //    // Arrange
        //    var client = CreateClient();
        //    var artifact = client.GetArtifact("library/hello-world", "latest");

        //    // Act
        //    await artifact.PullToAsync(@"C:\temp\manifest-list\acr-pull");

        //    // This is V1 -- pulls just the manifest
        //    // Assert
        //    // TODO
        //}

        //[RecordedTest, NonParallelizable]
        //public async Task CanPullArtifact_DockerManifestV2_ByDigest()
        //{
        //    // This is one of the child manifests for the hello-world image, with the arch/os pair "amd64"/"windows"
        //    //
        //    //{
        //    //    "digest": "sha256:90e120baffe5afa60dd5a24abcd051db49bd6aee391174da5e825ee6ee5a12a0",
        //    //    "mediaType": "application/vnd.docker.distribution.manifest.v2+json",
        //    //    "platform": {
        //    //        "architecture": "amd64",
        //    //        "os": "windows",
        //    //        "os.version": "10.0.17763.1999"
        //    //    },
        //    //    "size": 1125
        //    //}
        //    // sha256:90e120baffe5afa60dd5a24abcd051db49bd6aee391174da5e825ee6ee5a12a0

        //    // Arrange
        //    var client = CreateClient();
        //    var artifact = client.GetArtifact("library/hello-world", "sha256:90e120baffe5afa60dd5a24abcd051db49bd6aee391174da5e825ee6ee5a12a0");

        //    // Act
        //    await artifact.PullToAsync(@"C:\temp\manifest-list\acr-pull");

        //    // Assert
        //    // -----------------------------------------------

        //    //// Arrange
        //    //var client = CreateClient();
        //    //var artifact = client.GetArtifact("library/hello-world", "sha256:9f6ad537c5132bcce57f7a0a20e317228d382c3cd61edae14650eec68b2b345c");

        //    //// Act
        //    //await artifact.PullToAsync(@"C:\temp\manifest-list\acr-pull");

        //    //// Assert
        //    //// TODO

        //    //// Note, this pulls the whole manifest list, but nothing else.
        //    //// See: C:\Users\annelo\AppData\Local\Temp\CanPullArtifact_DockerManifestV2_ByDigest-637605637621836360.testlog
        //}

        //[RecordedTest, NonParallelizable]
        //public async Task CanPullArtifact_DockerManifestV1_ByTagName()
        //{
        //    // Arrange
        //    var client = CreateClient();
        //    var artifact = client.GetArtifact("library/hello-world", "latest");

        //    // Act
        //    await artifact.PullToAsync(@"C:\temp\manifest-list\acr-pull");

        //    // This is V1 -- pulls just the manifest. Doesn't pull the layers yet, dependent on Content-Type
        //    //
        //    // Assert
        //    // TODO
        //}

        //[RecordedTest, NonParallelizable]
        //public async Task CanPullArtifact_DockerManifestV1_ByDigest()
        //{
        //    // Arrange
        //    var client = CreateClient();
        //    var artifact = client.GetArtifact("", "sha256:71ecb6edb78c9623d0dd6a2793ec2cae43943f2f335f4fe5c606ffa83bf1fc11");

        //    // Act
        //    await artifact.PullToAsync(@"C:\temp\manifest-list\acr-pull");

        //    // Assert
        //    // TODO
        //}

        //[RecordedTest, NonParallelizable]
        //public async Task CanPullArtifact_OciManifest_ByTagName()
        //{
        //    // Arrange
        //    var client = CreateClient();
        //    var artifact = client.GetArtifact("hello-artifact", "v1");

        //    // Act
        //    await artifact.PullToAsync(@"C:\temp\manifest-list\acr-pull");

        //    // Assert
        //    // TODO
        //}

        //[RecordedTest, NonParallelizable]
        //public async Task CanPullArtifact_OciManifest_ByDigest()
        //{
        //    // Arrange
        //    var client = CreateClient();
        //    var artifact = client.GetArtifact("hello-artifact", "sha256:4059e65a0e90b2562e550dea06d6942791329ab2880e0fff9405389ae1e803b9");

        //    // Act
        //    await artifact.PullToAsync(@"C:\temp\manifest-list\acr-pull");

        //    // Assert
        //    // TODO
        //}

        //[RecordedTest, NonParallelizable]
        //public async Task CanPullArtifact_DockerManifestListV2_ByTagName()
        //{
        //    // Arrange
        //    var client = CreateClient();
        //    var artifact = client.GetArtifact("", "sha256:71ecb6edb78c9623d0dd6a2793ec2cae43943f2f335f4fe5c606ffa83bf1fc11");

        //    // Act
        //    await artifact.PullToAsync(@"C:\temp\manifest-list\acr-pull");

        //    // Assert
        //    // TODO
        //}

        //[RecordedTest, NonParallelizable]
        //public async Task CanPullArtifact_DockerManifestListV2_ByDigest()
        //{
        //    // Arrange
        //    var client = CreateClient();
        //    var artifact = client.GetArtifact("library/node", "sha256:71ecb6edb78c9623d0dd6a2793ec2cae43943f2f335f4fe5c606ffa83bf1fc11");

        //    // Act
        //    await artifact.PullToAsync(@"C:\temp\manifest-list\acr-pull");

        //    // Assert
        //    // TODO
        //}

        //[RecordedTest, NonParallelizable]
        //public async Task CanPullArtifact_OciIndex_ByTagName()
        //{
        //    // Arrange
        //    var client = CreateClient();
        //    var artifact = client.GetArtifact("", "sha256:71ecb6edb78c9623d0dd6a2793ec2cae43943f2f335f4fe5c606ffa83bf1fc11");

        //    // Act
        //    await artifact.PullToAsync(@"C:\temp\manifest-list\acr-pull");

        //    // Assert
        //    // TODO
        //}

        //[RecordedTest, NonParallelizable]
        //public async Task CanPullArtifact_OciIndex_ByDigest()
        //{
        //    // Arrange
        //    var client = CreateClient();
        //    var artifact = client.GetArtifact("", "sha256:71ecb6edb78c9623d0dd6a2793ec2cae43943f2f335f4fe5c606ffa83bf1fc11");

        //    // Act
        //    await artifact.PullToAsync(@"C:\temp\manifest-list\acr-pull");

        //    // Assert
        //    // TODO
        //}

        //#endregion

        #region samples/tests for lower-level endpoints

        [RecordedTest, NonParallelizable]
        public async Task PushArtifactSample_DockerManifestV2_ByDigest()
        {
            // Arrange
            var repository = "library/hello-world";
            var digest = "sha256:1b26826f602946860c279fce658f31050cff2c596583af237d971f4629b57792";
            string path = @"C:\temp\acr\test-pull";
            var client = CreateClient();
            var artifact = client.GetArtifact(repository, digest);

            var uploadClient = new ContainerRegistryArtifactDataClient(new System.Uri("https://localtestacr1.azurecr.io"), new DefaultAzureCredential());

            // Act
            var manifestFilePath = Path.Combine(path, "manifest.json");
            foreach (var file in Directory.GetFiles(path))
            {
                using (var fs = File.OpenRead(file))
                {
                    if (file == manifestFilePath)
                    {
                        await uploadClient.UploadManifestAsync(fs, new UploadManifestOptions() { Tag = "myTag" });
                    }
                    else
                    {
                        await uploadClient.UploadBlobAsync(fs);
                    }
                }
            }

            // Assert
            // TODO
        }

        [RecordedTest, NonParallelizable]
        public async Task PullArtifactSample_DockerManifestV2_ByDigest()
        {
            // This is one of the child manifests for the hello-world image, with the arch/os pair "amd64"/"windows"
            //
            //{
            //    "digest": "sha256:90e120baffe5afa60dd5a24abcd051db49bd6aee391174da5e825ee6ee5a12a0",
            //    "mediaType": "application/vnd.docker.distribution.manifest.v2+json",
            //    "platform": {
            //        "architecture": "amd64",
            //        "os": "windows",
            //        "os.version": "10.0.17763.1999"
            //    },
            //    "size": 1125
            //}
            // sha256:90e120baffe5afa60dd5a24abcd051db49bd6aee391174da5e825ee6ee5a12a0

            // Arrange
            var repository = "library/hello-world";

            // This digest is pulling invalid blobs right now
            //var digest = "sha256:90e120baffe5afa60dd5a24abcd051db49bd6aee391174da5e825ee6ee5a12a0";
            var digest = "sha256:1b26826f602946860c279fce658f31050cff2c596583af237d971f4629b57792";
            var client = CreateClient();
            var artifact = client.GetArtifact(repository, digest);
            string path = @"C:\temp\acr\test-pull";

            var downloadClient = new ContainerRegistryArtifactDataClient(new System.Uri("example.azurecr.io"), new DefaultAzureCredential());

            // Act

            // Get Manifest

            // TODO: do we need digest in this method if artifact was instantiated with it?
            // TODO: How should we handle/communicate the difference in semantics between download
            // with digest and download with tag?
            var manifestResult = await downloadClient.DownloadManifestAsync(digest);

            // Write manifest to file
            Directory.CreateDirectory(path);
            string manifestFile = Path.Combine(path, "manifest.json");
            using (FileStream fs = File.Create(manifestFile))
            {
                Stream stream = manifestResult.Value.Content;
                await stream.CopyToAsync(fs).ConfigureAwait(false);
            }

            // Write Config and Layers
            foreach (var artifactFile in manifestResult.Value.ArtifactFiles)
            {
                string fileName = Path.Combine(path, artifactFile.FileName ?? TrimSha(artifactFile.Digest));

                using (FileStream fs = File.Create(fileName))
                {
                    var layerResult = await downloadClient.DownloadBlobAsync(artifactFile.Digest);
                    Stream stream = layerResult.Value.Content;
                    await stream.CopyToAsync(fs).ConfigureAwait(false);
                }
            }
        }

        private static string TrimSha(string digest)
        {
            int index = digest.IndexOf(':');
            if (index > -1)
            {
                return digest.Substring(index + 1);
            }

            return digest;
        }

        #endregion
    }
}
