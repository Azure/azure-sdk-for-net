// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

        // TODO: Test DownloadManifest

        // TODO: Test DownloadBlob

        // TODO: Test UploadManifest

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

            // TODO: Make this pass
            //Assert.AreEqual(ManifestMediaType.OciManifest, downloadResult.Value.MediaType);
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

        // TODO: Test full push scenario - for OCI

        // TODO: Test full pull scenario - for OCI

        //[RecordedTest, NonParallelizable]
        //public async Task PushArtifactSample_DockerManifestV2_ByDigest()
        //{
        //    // Arrange
        //    var repository = "library/hello-world";
        //    var digest = "sha256:1b26826f602946860c279fce658f31050cff2c596583af237d971f4629b57792";
        //    string path = @"C:\temp\acr\test-pull";
        //    var client = CreateClient();
        //    var artifact = client.GetArtifact(repository, digest);

        //    var uploadClient = new ContainerRegistryBlobClient(new System.Uri("https://localtestacr1.azurecr.io"), new DefaultAzureCredential());

        //    // Act
        //    var manifestFilePath = Path.Combine(path, "manifest.json");
        //    foreach (var file in Directory.GetFiles(path))
        //    {
        //        using (var fs = File.OpenRead(file))
        //        {
        //            if (file == manifestFilePath)
        //            {
        //                await uploadClient.UploadManifestAsync(fs, new UploadManifestOptions() { Tag = "myTag" });
        //            }
        //            else
        //            {
        //                await uploadClient.UploadBlobAsync(fs);
        //            }
        //        }
        //    }

        //    // Assert
        //    // TODO
        //}

        //[RecordedTest, NonParallelizable]
        //public async Task PullArtifactSample_DockerManifestV2_ByDigest()
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
        //    var repository = "library/hello-world";

        //    // This digest is pulling invalid blobs right now
        //    //var digest = "sha256:90e120baffe5afa60dd5a24abcd051db49bd6aee391174da5e825ee6ee5a12a0";
        //    var digest = "sha256:1b26826f602946860c279fce658f31050cff2c596583af237d971f4629b57792";
        //    var client = CreateClient();
        //    var artifact = client.GetArtifact(repository, digest);
        //    string path = @"C:\temp\acr\test-pull";

        //    var downloadClient = new ContainerRegistryBlobClient(new System.Uri("example.azurecr.io"), new DefaultAzureCredential());

        //    // Act

        //    // Get Manifest

        //    // TODO: do we need digest in this method if artifact was instantiated with it?
        //    // TODO: How should we handle/communicate the difference in semantics between download
        //    // with digest and download with tag?
        //    var manifestResult = await downloadClient.DownloadManifestAsync(digest);

        //    // Write manifest to file
        //    Directory.CreateDirectory(path);
        //    string manifestFile = Path.Combine(path, "manifest.json");
        //    using (FileStream fs = File.Create(manifestFile))
        //    {
        //        Stream stream = manifestResult.Value.Content;
        //        await stream.CopyToAsync(fs).ConfigureAwait(false);
        //    }

        //    // Write Config and Layers
        //    foreach (var artifactFile in manifestResult.Value.ArtifactFiles)
        //    {
        //        string fileName = Path.Combine(path, artifactFile.FileName ?? TrimSha(artifactFile.Digest));

        //        using (FileStream fs = File.Create(fileName))
        //        {
        //            var layerResult = await downloadClient.DownloadBlobAsync(artifactFile.Digest);
        //            Stream stream = layerResult.Value.Content;
        //            await stream.CopyToAsync(fs).ConfigureAwait(false);
        //        }
        //    }
        //}

        private static string TrimSha(string digest)
        {
            int index = digest.IndexOf(':');
            if (index > -1)
            {
                return digest.Substring(index + 1);
            }

            return digest;
        }
    }
}
