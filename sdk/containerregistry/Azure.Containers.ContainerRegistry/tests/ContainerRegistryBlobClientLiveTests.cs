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
        public async Task CanDownloadManifest()
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
