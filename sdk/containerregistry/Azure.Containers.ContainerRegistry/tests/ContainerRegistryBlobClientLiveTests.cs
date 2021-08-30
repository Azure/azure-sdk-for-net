// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using Azure.Containers.ContainerRegistry.Specialized;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Containers.ContainerRegistry.Tests
{
    public class ContainerRegistryBlobClientLiveTests : ContainerRegistryRecordedTestBase
    {
        public ContainerRegistryBlobClientLiveTests(bool isAsync) : base(isAsync, RecordedTestMode.Live)
        {
        }

        [RecordedTest, NonParallelizable]
        public async Task CanUploadOciManifest()
        {
            // Arrange
            var client = CreateBlobClient("oci-artifact");

            var manifest = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data\\oci-artifact", "manifest.json");
            string digest = default;

            // Act
            using (var fs = File.OpenRead(manifest))
            {
                var uploadResult = await client.UploadManifestAsync(fs, new UploadManifestOptions()
                {
                    MediaType = ManifestMediaType.OciManifest
                });
                digest = uploadResult.Value.Digest;
            }

            // Assert
            var downloadResult = await client.DownloadManifestAsync(digest);
            Assert.AreEqual(digest, downloadResult.Value.Digest);
            Assert.AreEqual(ManifestMediaType.OciManifest, downloadResult.Value.MediaType);

            // TODO: implement delete manifest
        }

        [RecordedTest, NonParallelizable]
        public async Task CanUploadBlob()
        {
            // Arrange
            var client = CreateBlobClient("oci-artifact");
            var blob = "654b93f61054e4ce90ed203bb8d556a6200d5f906cf3eca0620738d6dc18cbed";
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data\\oci-artifact", blob);

            string digest = default;
            // Act
            using (var fs = File.OpenRead(path))
            {
                var uploadResult = await client.UploadBlobAsync(fs, new UploadBlobOptions());
                digest = uploadResult.Value.Digest;
            }

            // Assert
            var downloadResult = await client.DownloadBlobAsync(digest);
            Assert.AreEqual(digest, downloadResult.Value.Digest);
            Assert.AreEqual(28, downloadResult.Value.Content.Length);

            // Clean up
            await client.DeleteBlobAsync(digest);
        }

        [RecordedTest, NonParallelizable]
        public async Task CanDownloadOciManifest()
        {
            // Arrange
            var repository = "oci-artifact";
            var client = CreateBlobClient(repository);
            var manifest = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data\\oci-artifact", "manifest.json");
            string digest = default;

            using (var fs = File.OpenRead(manifest))
            {
                var uploadResult = await client.UploadManifestAsync(fs, new UploadManifestOptions()
                {
                    MediaType = ManifestMediaType.OciManifest
                });
                digest = uploadResult.Value.Digest;
            }

            // Act
            var downloadResult = await client.DownloadManifestAsync(digest);

            // Assert

            Assert.AreEqual(digest, downloadResult.Value.Digest);
            Assert.AreEqual(ManifestMediaType.OciManifest, downloadResult.Value.MediaType);

            // Ensure known artifact files can be parsed from manifest data
            Assert.IsNotNull(downloadResult.Value.ArtifactFiles);
            Assert.AreEqual(2, downloadResult.Value.ArtifactFiles.Count);

            Assert.AreEqual("config.json", downloadResult.Value.ArtifactFiles[0].FileName);
            Assert.AreEqual("sha256:d25b42d3dbad5361ed2d909624d899e7254a822c9a632b582ebd3a44f9b0dbc8", downloadResult.Value.ArtifactFiles[0].Digest);
            Assert.AreEqual(repository, downloadResult.Value.ArtifactFiles[0].RepositoryName);

            Assert.IsNull(downloadResult.Value.ArtifactFiles[0].FileName);
            Assert.AreEqual("sha256:654b93f61054e4ce90ed203bb8d556a6200d5f906cf3eca0620738d6dc18cbed", downloadResult.Value.ArtifactFiles[0].Digest);
            Assert.AreEqual(repository, downloadResult.Value.ArtifactFiles[0].RepositoryName);

            // TODO: implement delete manifest
        }

        [RecordedTest, NonParallelizable]
        public async Task CanDownloadBlob()
        {
            // Arrange
            var client = CreateBlobClient("oci-artifact");
            var blob = "654b93f61054e4ce90ed203bb8d556a6200d5f906cf3eca0620738d6dc18cbed";
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data\\oci-artifact", blob);

            string digest = default;

            // Act
            using (var fs = File.OpenRead(path))
            {
                var uploadResult = await client.UploadBlobAsync(fs, new UploadBlobOptions());
                digest = uploadResult.Value.Digest;
            }

            // Assert
            var downloadResult = await client.DownloadBlobAsync(digest);
            Assert.AreEqual(digest, downloadResult.Value.Digest);
            Assert.AreEqual(28, downloadResult.Value.Content.Length);

            // Clean up
            await client.DeleteBlobAsync(digest);
        }
    }
}
