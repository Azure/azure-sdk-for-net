// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Containers.ContainerRegistry.Specialized;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Microsoft.Extensions.Primitives;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Azure.Containers.ContainerRegistry.Tests
{
    [NonParallelizable]
    public class ContainerRegistryBlobClientLiveTests : ContainerRegistryRecordedTestBase
    {
        public ContainerRegistryBlobClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task Setup()
        {
            // Handle redirects in the Client pipeline and not in the test proxy.
            await SetProxyOptionsAsync(new ProxyOptions { Transport = new ProxyOptionsTransport { AllowAutoRedirect = false } });
        }

        [RecordedTest]
        public async Task CanUploadOciManifest()
        {
            // Arrange
            var client = CreateBlobClient("oci-artifact");

            await UploadManifestPrerequisites(client);

            // Act
            var manifest = ContainerRegistryTestDataHelpers.CreateManifest();
            var uploadResult = await client.UploadManifestAsync(manifest);
            string digest = uploadResult.Value.Digest;

            // Assert
            var downloadResultValue = (await client.DownloadManifestAsync(digest)).Value;
            Assert.AreEqual(digest, downloadResultValue.Digest);
            ValidateManifest(downloadResultValue.AsOciManifest());

            // Clean up
            await client.DeleteManifestAsync(digest);
        }

        [RecordedTest]
        public async Task CanUploadOciManifestStream()
        {
            // Arrange
            var client = CreateBlobClient("oci-artifact");

            await UploadManifestPrerequisites(client);

            // Act
            string payload = "" +
                "{" +
                    "\"schemaVersion\":2," +
                    "\"config\":" +
                    "{" +
                        "\"mediaType\":\"application/vnd.acme.rocket.config\"," +
                        "\"size\":171," +
                        "\"digest\":\"sha256:d25b42d3dbad5361ed2d909624d899e7254a822c9a632b582ebd3a44f9b0dbc8\"" +
                    "}," +
                    "\"layers\":" +
                    "[" +
                        "{" +
                            "\"mediaType\":\"application/vnd.oci.image.layer.v1.tar\"," +
                            "\"size\":28," +
                            "\"digest\":\"sha256:654b93f61054e4ce90ed203bb8d556a6200d5f906cf3eca0620738d6dc18cbed\"" +
                        "}" +
                    "]" +
                "}";

            using Stream manifest = new MemoryStream(Encoding.ASCII.GetBytes(payload));

            var uploadResult = await client.UploadManifestAsync(manifest);
            string digest = uploadResult.Value.Digest;

            // Assert
            var downloadResultValue = (await client.DownloadManifestAsync(digest)).Value;
            Assert.AreEqual(digest, downloadResultValue.Digest);
            ValidateManifest(downloadResultValue.AsOciManifest());

            // Clean up
            await client.DeleteManifestAsync(digest);
        }

        [RecordedTest]
        public async Task CanUploadManifestFromNonSeekableStream()
        {
            // Arrange
            var client = CreateBlobClient("oci-artifact");

            await UploadManifestPrerequisites(client);

            // Act
            string payload = "" +
                "{" +
                    "\"schemaVersion\":2," +
                    "\"config\":" +
                    "{" +
                        "\"mediaType\":\"application/vnd.acme.rocket.config\"," +
                        "\"size\":171," +
                        "\"digest\":\"sha256:d25b42d3dbad5361ed2d909624d899e7254a822c9a632b582ebd3a44f9b0dbc8\"" +
                    "}," +
                    "\"layers\":" +
                    "[" +
                        "{" +
                            "\"mediaType\":\"application/vnd.oci.image.layer.v1.tar\"," +
                            "\"size\":28," +
                            "\"digest\":\"sha256:654b93f61054e4ce90ed203bb8d556a6200d5f906cf3eca0620738d6dc18cbed\"" +
                        "}" +
                    "]" +
                "}";

            using Stream manifest = new NonSeekableMemoryStream(Encoding.ASCII.GetBytes(payload));

            var uploadResult = await client.UploadManifestAsync(manifest);
            string digest = uploadResult.Value.Digest;

            // Assert
            var downloadResultValue = (await client.DownloadManifestAsync(digest)).Value;
            Assert.AreEqual(digest, downloadResultValue.Digest);
            ValidateManifest(downloadResultValue.AsOciManifest());

            // Clean up
            await client.DeleteManifestAsync(digest);
        }

        [RecordedTest]
        public async Task CanUploadOciManifestWithTag()
        {
            // Arrange
            string repository = "oci-artifact";
            var client = CreateBlobClient(repository);
            var registryClient = CreateClient();
            string tag = "v1";

            await UploadManifestPrerequisites(client);

            // Act
            var manifest = ContainerRegistryTestDataHelpers.CreateManifest();
            var uploadResult = await client.UploadManifestAsync(manifest, tag);
            var digest = uploadResult.Value.Digest;

            // Assert
            var downloadResultValue = (await client.DownloadManifestAsync(digest)).Value;
            Assert.AreEqual(digest, downloadResultValue.Digest);
            ValidateManifest(downloadResultValue.AsOciManifest());

            var artifact = registryClient.GetArtifact(repository, digest);
            var tags = artifact.GetTagPropertiesCollectionAsync();
            var count = await tags.CountAsync();
            Assert.AreEqual(1, count);
            var firstTag = await tags.FirstAsync();
            Assert.AreEqual(tag, firstTag.Name);

            // Clean up
            await client.DeleteManifestAsync(digest);
        }

        [RecordedTest]
        public async Task CanUploadOciManifestStreamWithTag()
        {
            // Arrange
            string repository = "oci-artifact";
            var client = CreateBlobClient(repository);
            var registryClient = CreateClient();
            string tag = "v1";

            await UploadManifestPrerequisites(client);

            // Act
            string payload = "" +
                "{" +
                    "\"schemaVersion\":2," +
                    "\"config\":" +
                    "{" +
                        "\"mediaType\":\"application/vnd.acme.rocket.config\"," +
                        "\"size\":171," +
                        "\"digest\":\"sha256:d25b42d3dbad5361ed2d909624d899e7254a822c9a632b582ebd3a44f9b0dbc8\"" +
                    "}," +
                    "\"layers\":" +
                    "[" +
                        "{" +
                            "\"mediaType\":\"application/vnd.oci.image.layer.v1.tar\"," +
                            "\"size\":28," +
                            "\"digest\":\"sha256:654b93f61054e4ce90ed203bb8d556a6200d5f906cf3eca0620738d6dc18cbed\"" +
                        "}" +
                    "]" +
                "}";

            using Stream manifest = new MemoryStream(Encoding.ASCII.GetBytes(payload));
            var uploadResult = await client.UploadManifestAsync(manifest, tag);
            var digest = uploadResult.Value.Digest;

            // Assert
            var downloadResultValue = (await client.DownloadManifestAsync(digest)).Value;
            Assert.AreEqual(digest, downloadResultValue.Digest);
            ValidateManifest(downloadResultValue.AsOciManifest());

            var artifact = registryClient.GetArtifact(repository, digest);
            var tags = artifact.GetTagPropertiesCollectionAsync();
            var count = await tags.CountAsync();
            Assert.AreEqual(1, count);
            var firstTag = await tags.FirstAsync();
            Assert.AreEqual(tag, firstTag.Name);

            var downloadResultValue2 = (await client.DownloadManifestAsync(tag)).Value;
            Assert.AreEqual(digest, downloadResultValue.Digest);
            ValidateManifest(downloadResultValue.AsOciManifest());

            // Clean up
            await client.DeleteManifestAsync(digest);
        }

        [RecordedTest]
        public async Task CanUploadDockerManifest()
        {
            // Arrange

            // We have imported the library/hello-world image in test set-up,
            // so config and blob files pointed to by the manifest are already in the registry.

            var client = CreateBlobClient("library/hello-world");

            // Act
            string path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "docker", "hello-world", "manifest.json");
            using FileStream fs = File.OpenRead(path);

            UploadManifestResult result = await client.UploadManifestAsync(fs, mediaType: ManifestMediaType.DockerManifest);

            // Assert
            Assert.AreEqual("sha256:e6c1c9dcc9c45a3dbfa654f8c8fad5c91529c137c1e2f6eb0995931c0aa74d99", result.Digest);

            // The following fails because the manifest media type is set to OciManifest by default
            fs.Position = 0;
            Assert.ThrowsAsync<RequestFailedException>(async () => await client.UploadManifestAsync(fs));
        }

        [RecordedTest]
        [Ignore("Test recordings serialize and compress message bodies: https://github.com/Azure/azure-sdk-tools/issues/3015")]
        public async Task CanDownloadDockerManifest()
        {
            // Arrange
            var client = CreateBlobClient("library/hello-world");

            // Act

            // The following is the digest of the linux/amd64 manifest for library/hello-world.
            string digest = "sha256:f54a58bc1aac5ea1a25d796ae155dc228b3f0e11d046ae276b39c4bf2f13d8c4";

            DownloadManifestResult result = await client.DownloadManifestAsync(digest);

            // Assert
            Assert.AreEqual(digest, result.Digest);
            Assert.AreEqual(ManifestMediaType.DockerManifest, result.MediaType);
        }

        private async Task UploadManifestPrerequisites(ContainerRegistryBlobClient client)
        {
            var layer = "654b93f61054e4ce90ed203bb8d556a6200d5f906cf3eca0620738d6dc18cbed";
            var config = "config.json";
            var basePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "oci-artifact");

            // Upload config
            using (var fs = File.OpenRead(Path.Combine(basePath, config)))
            {
                var uploadResult = await client.UploadBlobAsync(fs);
            }

            // Upload layer
            using (var fs = File.OpenRead(Path.Combine(basePath, layer)))
            {
                var uploadResult = await client.UploadBlobAsync(fs);
            }
        }

        private static void ValidateManifest(OciManifest manifest)
        {
            // These are from the values in the Data\oci-artifact\manifest.json file.
            Assert.IsNotNull(manifest);

            Assert.IsNotNull(manifest.Config);
            Assert.AreEqual("application/vnd.acme.rocket.config", manifest.Config.MediaType);
            Assert.AreEqual("sha256:d25b42d3dbad5361ed2d909624d899e7254a822c9a632b582ebd3a44f9b0dbc8", manifest.Config.Digest);
            Assert.AreEqual(171, manifest.Config.Size);

            Assert.IsNotNull(manifest.Layers);
            Assert.AreEqual(1, manifest.Layers.Count);
            Assert.AreEqual("application/vnd.oci.image.layer.v1.tar", manifest.Layers[0].MediaType);
            Assert.AreEqual("sha256:654b93f61054e4ce90ed203bb8d556a6200d5f906cf3eca0620738d6dc18cbed", manifest.Layers[0].Digest);
            Assert.AreEqual(28, manifest.Layers[0].Size);
        }

        #region Upload Blob Tests

        [RecordedTest]
        public async Task CanUploadBlob()
        {
            // Arrange
            var repositoryId = Recording.Random.NewGuid().ToString();
            var client = CreateBlobClient(repositoryId);

            string digest = default;
            long streamLength;

            int blobSize = 1024;

            var data = GetConstantBuffer(blobSize, 1);

            using (var stream = new MemoryStream(data))
            {
                digest = BlobHelper.ComputeDigest(stream);
                UploadBlobResult uploadResult = await client.UploadBlobAsync(stream);
                streamLength = uploadResult.Size;

                Assert.AreEqual(digest, uploadResult.Digest);
                Assert.AreEqual(stream.Length, uploadResult.Size);
            }

            // Assert
            var downloadResult = await client.DownloadBlobAsync(digest);
            Assert.AreEqual(digest, downloadResult.Value.Digest);
            Assert.AreEqual(streamLength, downloadResult.Value.Content.ToArray().Length);

            // Clean up
            await client.DeleteBlobAsync(digest);
        }

        [RecordedTest]
        public async Task CanUploadBlobInEqualSizeChunks()
        {
            // Arrange
            var repositoryId = Recording.Random.NewGuid().ToString();
            var client = CreateBlobClient(repositoryId);

            int blobSize = 1024;
            int chunkSize = 1024 / 4; // Four equal-sized chunks

            var data = GetConstantBuffer(blobSize, 1);
            UploadBlobResult uploadResult = default;
            string digest = default;

            using (var stream = new MemoryStream(data))
            {
                digest = BlobHelper.ComputeDigest(stream);
                uploadResult = await client.UploadBlobAsync(stream, new UploadBlobOptions(chunkSize));
            }

            // Assert
            Assert.AreEqual(digest, uploadResult.Digest);
            Assert.AreEqual(blobSize, uploadResult.Size);

            // Clean up
            await client.DeleteBlobAsync(digest);
        }

        [RecordedTest]
        public async Task CanUploadBlobInUnequalChunks()
        {
            // Arrange
            var repositoryId = Recording.Random.NewGuid().ToString();
            var client = CreateBlobClient(repositoryId);

            int blobSize = 1024;
            int chunkSize = 1024 / 4;    // Equal-sized chunks
            int remainderChunkSize = 20;
            blobSize += remainderChunkSize;

            var data = GetConstantBuffer(blobSize, 2);
            UploadBlobResult uploadResult = default;
            string digest = default;

            using (var stream = new MemoryStream(data))
            {
                digest = BlobHelper.ComputeDigest(stream);
                uploadResult = await client.UploadBlobAsync(stream, new UploadBlobOptions(chunkSize));
            }

            // Assert
            Assert.AreEqual(digest, uploadResult.Digest);
            Assert.AreEqual(blobSize, uploadResult.Size);

            // Clean up
            await client.DeleteBlobAsync(digest);
        }

        [RecordedTest]
        public async Task CanUploadBlobInSingleChunk()
        {
            // Arrange
            var repositoryId = Recording.Random.NewGuid().ToString();
            var client = CreateBlobClient(repositoryId);

            int blobSize = 512;
            int chunkSize = 1024;

            var data = GetConstantBuffer(blobSize, 3);
            UploadBlobResult uploadResult = default;
            string digest = default;

            using (var stream = new MemoryStream(data))
            {
                digest = BlobHelper.ComputeDigest(stream);
                uploadResult = await client.UploadBlobAsync(stream, new UploadBlobOptions(chunkSize));
            }

            // Assert
            Assert.AreEqual(digest, uploadResult.Digest);
            Assert.AreEqual(blobSize, uploadResult.Size);

            // Clean up
            await client.DeleteBlobAsync(digest);
        }

        [RecordedTest]
        public async Task CanUploadBlobFromNonSeekableStream()
        {
            // Arrange
            var repositoryId = Recording.Random.NewGuid().ToString();
            var client = CreateBlobClient(repositoryId);

            int blobSize = 1024;
            int chunkSize = 1024 / 4; // Four equal-sized chunks

            var data = GetConstantBuffer(blobSize, 3);
            UploadBlobResult uploadResult = default;
            string digest = BlobHelper.ComputeDigest(new MemoryStream(data));

            using (var stream = new NonSeekableMemoryStream(data))
            {
                uploadResult = await client.UploadBlobAsync(stream, new UploadBlobOptions(chunkSize));
            }

            // Assert
            Assert.AreEqual(digest, uploadResult.Digest);
            Assert.AreEqual(blobSize, uploadResult.Size);

            // Clean up
            await client.DeleteBlobAsync(digest);
        }

        #endregion

        #region Download Blob Tests

        [RecordedTest]
        public async Task CanDownloadBlob()
        {
            // Arrange
            var repositoryId = Recording.Random.NewGuid().ToString();
            var client = CreateBlobClient(repositoryId);

            int blobSize = 1024;
            var data = GetConstantBuffer(blobSize, 1);

            using var stream = new MemoryStream(data);
            UploadBlobResult uploadResult = await client.UploadBlobAsync(stream);
            var digest = uploadResult.Digest;

            // Act
            Response<DownloadBlobResult> downloadResult = await client.DownloadBlobAsync(digest);

            Assert.AreEqual(digest, downloadResult.Value.Digest);
            Assert.AreEqual(stream.Length, downloadResult.Value.Content.ToArray().Length);

            // Clean up
            await client.DeleteBlobAsync(digest);
        }

        [RecordedTest]
        public async Task CanDownloadBlobToStream()
        {
            // Arrange
            var repositoryId = Recording.Random.NewGuid().ToString();
            var client = CreateBlobClient(repositoryId);

            int blobSize = 1024;
            var data = GetConstantBuffer(blobSize, 1);

            using var uploadStream = new MemoryStream(data);
            UploadBlobResult uploadResult = await client.UploadBlobAsync(uploadStream);
            var digest = uploadResult.Digest;

            // Act
            using var downloadStream = new MemoryStream();
            await client.DownloadBlobToAsync(digest, downloadStream);
            var digestOfDownload = BlobHelper.ComputeDigest(downloadStream);

            Assert.AreEqual(digest, digestOfDownload);
            Assert.AreEqual(blobSize, downloadStream.Length);

            // Clean up
            await client.DeleteBlobAsync(digest);
        }

        [RecordedTest]
        public async Task CanDownloadBlobToStreamInEqualSizeChunks()
        {
            // Arrange
            int blobSize = 1024;
            int chunkSize = 1024 / 4; // Four equal-sized chunks

            var repositoryId = Recording.Random.NewGuid().ToString();
            var client = CreateBlobClient(repositoryId, chunkSize);

            var data = GetConstantBuffer(blobSize, 10);

            using var uploadStream = new MemoryStream(data);
            UploadBlobResult uploadResult = await client.UploadBlobAsync(uploadStream);
            var digest = uploadResult.Digest;

            // Act
            using var downloadStream = new MemoryStream();
            await client.DownloadBlobToAsync(digest, downloadStream);
            downloadStream.Position = 0;

            BinaryData downloadedData = BinaryData.FromStream(downloadStream);
            var digestOfDownload = BlobHelper.ComputeDigest(downloadStream);

            Assert.AreEqual(digest, digestOfDownload);
            Assert.AreEqual(blobSize, downloadStream.Length);
            Assert.IsTrue(downloadedData.ToMemory().Span.SequenceEqual(data.AsSpan()));

            // Clean up
            await client.DeleteBlobAsync(digest);
        }

        [RecordedTest]
        public async Task CanDownloadBlobToStreamInUnequalChunks()
        {
            // Arrange
            int blobSize = 1024;
            int chunkSize = 1024 / 4;    // Equal-sized chunks
            int remainderChunkSize = 20;
            blobSize += remainderChunkSize;

            var repositoryId = Recording.Random.NewGuid().ToString();
            var client = CreateBlobClient(repositoryId, chunkSize);

            var data = GetConstantBuffer(blobSize, 11);

            using var uploadStream = new MemoryStream(data);
            UploadBlobResult uploadResult = await client.UploadBlobAsync(uploadStream);
            var digest = uploadResult.Digest;

            // Act
            using var downloadStream = new MemoryStream();
            await client.DownloadBlobToAsync(digest, downloadStream);
            downloadStream.Position = 0;

            BinaryData downloadedData = BinaryData.FromStream(downloadStream);
            var digestOfDownload = BlobHelper.ComputeDigest(downloadStream);

            Assert.AreEqual(digest, digestOfDownload);
            Assert.AreEqual(blobSize, downloadStream.Length);
            Assert.IsTrue(downloadedData.ToMemory().Span.SequenceEqual(data.AsSpan()));

            // Clean up
            await client.DeleteBlobAsync(digest);
        }

        #endregion

        [RecordedTest]
        public async Task CanPushArtifact()
        {
            // Arrange
            var client = CreateBlobClient("oci-artifact");

            // Act
            var uploadManifestResult = await Push(client);

            // Assert
            ContainerRegistryClient registryClient = CreateClient();

            var names = registryClient.GetRepositoryNamesAsync();
            Assert.IsTrue(await names.AnyAsync(n => n == "oci-artifact"));

            var properties = await registryClient.GetArtifact("oci-artifact", "v1").GetManifestPropertiesAsync();
            Assert.AreEqual(uploadManifestResult.Digest, properties.Value.Digest);

            // Clean up
            await registryClient.DeleteRepositoryAsync("oci-artifact");
        }

        [Test]
        [LiveOnly]
        public async Task CanUploadAndDownloadLargeBlob()
        {
            long sizeInGiB = 2;
            var uneven = 20;
            long size = (1024 * 1024 * 1024 * sizeInGiB) + uneven;

            var repositoryId = Recording.Random.NewGuid().ToString();
            var client = CreateBlobClient(repositoryId);

            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "LargeFile");
            string uploadFileName = "blob.bin";

            if (!File.Exists(Path.Combine(path, uploadFileName)))
            {
                WriteLargeFile(path, uploadFileName, size);
            }

            // Upload the large file
            using var fs = File.OpenRead(Path.Combine(path, uploadFileName));
            var uploadResult = await client.UploadBlobAsync(fs);

            // Download the large file
            var downloadFileName = "blob_downloaded.bin";
            var filePath = Path.Combine(path, downloadFileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using var downloadFs = File.OpenWrite(filePath);
            await client.DownloadBlobToAsync(uploadResult.Value.Digest, downloadFs);

            Assert.IsTrue(File.Exists(filePath));
            Assert.AreEqual(size, new FileInfo(filePath).Length);
        }

        private void WriteLargeFile(string path, string fileName, long size)
        {
            Directory.CreateDirectory(path);
            using var fs = File.OpenWrite(Path.Combine(path, fileName));

            int writeBufferSize = 1024 * 1024 * 64; // 64MB

            long bytesWritten = 0;
            while (bytesWritten < size)
            {
                var length = Math.Min(writeBufferSize, size - bytesWritten);
                var buffer = GetRandomBuffer(length);
                fs.Write(buffer, 0, buffer.Length);
                bytesWritten += buffer.Length;
            };
        }

        [RecordedTest]
        public async Task CanGetBlobLocation()
        {
            // Arrange
            var client = CreateBlobClient("oci-artifact");
            var blob = "654b93f61054e4ce90ed203bb8d556a6200d5f906cf3eca0620738d6dc18cbed";
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "oci-artifact", blob);
            string digest = default;
            using (var fs = File.OpenRead(path))
            {
                var uploadResult = await client.UploadBlobAsync(fs);
                digest = uploadResult.Value.Digest;
            }

            // Act
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(client.Endpoint.ToString(), false);
            uri.AppendPath("/v2/", false);
            uri.AppendPath(client.RepositoryName, true);
            uri.AppendPath("/blobs/", false);
            uri.AppendPath(digest, true);

            var message = client.Pipeline.CreateMessage();
            message.Request.Method = RequestMethod.Get;
            message.Request.Uri = uri;
            message.Request.Headers.Add("Accept", "application/octet-stream");
            RedirectPolicy.SetAllowAutoRedirect(message, false);

            await client.Pipeline.SendAsync(message, CancellationToken.None);
            var response = message.Response;

            // Assert
            Assert.AreEqual(307, response.Status);
            Assert.IsTrue(response.Headers.TryGetValue("Location", out string value));
            Assert.DoesNotThrow(() => { Uri redirectUri = new(value); });

            // Clean up
            await client.DeleteBlobAsync(digest);
        }

        private async Task<UploadManifestResult> Push(ContainerRegistryBlobClient client)
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "oci-artifact");

            OciManifest manifest = new OciManifest();
            manifest.SchemaVersion = 2;

            // Upload config
            var configFilePath = Path.Combine(path, "config.json");
            if (File.Exists(configFilePath))
            {
                using (var fs = File.OpenRead(configFilePath))
                {
                    var uploadResult = await client.UploadBlobAsync(fs);

                    // Update manifest
                    OciBlobDescriptor descriptor = new OciBlobDescriptor();
                    descriptor.Digest = uploadResult.Value.Digest;
                    descriptor.Size = uploadResult.Value.Size;
                    descriptor.MediaType = "application/vnd.acme.rocket.config";

                    manifest.Config = descriptor;
                }
            }

            // Upload layers
            var manifestFilePath = Path.Combine(path, "manifest.json");
            foreach (var file in Directory.GetFiles(path))
            {
                if (file != manifestFilePath && file != configFilePath)
                {
                    using (var fs = File.OpenRead(file))
                    {
                        var uploadResult = await client.UploadBlobAsync(fs);

                        // Update manifest
                        OciBlobDescriptor descriptor = new OciBlobDescriptor();
                        descriptor.Digest = uploadResult.Value.Digest;
                        descriptor.Size = uploadResult.Value.Size;
                        descriptor.MediaType = "application/vnd.oci.image.layer.v1.tar";

                        manifest.Layers.Add(descriptor);
                    }
                }
            }

            // Finally, upload manifest
            return await client.UploadManifestAsync(manifest, "v1");
        }

        [RecordedTest]
        public async Task CanPullArtifact()
        {
            // Arrange
            var client = CreateBlobClient("oci-artifact");
            await Push(client);

            // Act

            // Download Manifest
            var manifestResult = await client.DownloadManifestAsync("v1");

            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "validate-pull");
            Directory.CreateDirectory(path);
            string manifestFile = Path.Combine(path, "manifest.json");
            using (FileStream fs = File.Create(manifestFile))
            {
                await manifestResult.Value.Content.ToStream().CopyToAsync(fs);
            }
            OciManifest manifest = manifestResult.Value.AsOciManifest();

            // Download Config
            string configFileName = Path.Combine(path, "config.json");
            using (FileStream fs = File.Create(configFileName))
            {
                DownloadBlobResult layerResult = await client.DownloadBlobAsync(manifest.Config.Digest);
                await layerResult.Content.ToStream().CopyToAsync(fs);
            }

            // Download Layers
            foreach (var layerFile in manifest.Layers)
            {
                string fileName = Path.Combine(path, TrimSha(layerFile.Digest));

                using (FileStream fs = File.Create(fileName))
                {
                    DownloadBlobResult layerResult = await client.DownloadBlobAsync(manifest.Config.Digest);
                    await layerResult.Content.ToStream().CopyToAsync(fs);
                }
            }

            // Assert
            ContainerRegistryClient registryClient = CreateClient();

            var properties = await registryClient.GetArtifact("oci-artifact", "v1").GetManifestPropertiesAsync();
            Assert.AreEqual(manifestResult.Value.Digest, properties.Value.Digest);
            var files = Directory.GetFiles(path).Select(f => Path.GetFileName(f)).ToArray();
            Assert.Contains("manifest.json", files);
            Assert.Contains("config.json", files);
            foreach (var file in manifest.Layers)
            {
                Assert.Contains(TrimSha(file.Digest), files);
            }

            // Clean up
            await registryClient.DeleteRepositoryAsync("oci-artifact");
            Directory.Delete(path, true);
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

        private static byte[] GetRandomBuffer(long size, Random random = null)
        {
            random ??= new Random(Environment.TickCount);
            var buffer = new byte[size];
            random.NextBytes(buffer);
            return buffer;
        }

        private static byte[] GetConstantBuffer(long size, byte value)
        {
            var array = new byte[size];
            var span = new Span<byte>(array);
            span.Fill(value);
            return array;
        }
    }
}
