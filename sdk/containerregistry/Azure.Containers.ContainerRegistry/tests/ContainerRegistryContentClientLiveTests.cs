// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using NUnit.Framework;

namespace Azure.Containers.ContainerRegistry.Tests
{
    [NonParallelizable]
    public class ContainerRegistryContentClientLiveTests : ContainerRegistryRecordedTestBase
    {
        public ContainerRegistryContentClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task Setup()
        {
            // Handle redirects in the Client pipeline and not in the test proxy.
            await SetProxyOptionsAsync(new ProxyOptions { Transport = new ProxyOptionsTransport { AllowAutoRedirect = false } });
        }

        [RecordedTest]
        public async Task CanSetOciManifest()
        {
            // Arrange
            var client = CreateBlobClient("oci-artifact");

            await SetManifestPrerequisites(client);

            // Act
            var manifest = ContainerRegistryTestDataHelpers.CreateManifest();
            var setResult = await client.SetManifestAsync(manifest);
            string digest = setResult.Value.Digest;

            // Assert
            var downloadResultValue = (await client.GetManifestAsync(digest)).Value;
            Assert.That(downloadResultValue.Digest, Is.EqualTo(digest));
            ValidateManifest(downloadResultValue.Manifest.ToObjectFromJson<OciImageManifest>());

            // Clean up
            await client.DeleteManifestAsync(digest);
        }

        [RecordedTest]
        public async Task CanSetOciManifestBinaryData()
        {
            // Arrange
            var client = CreateBlobClient("oci-artifact");

            await SetManifestPrerequisites(client);

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

            using Stream stream = new MemoryStream(Encoding.ASCII.GetBytes(payload));
            BinaryData manifest = BinaryData.FromStream(stream);

            var setResult = await client.SetManifestAsync(manifest);
            string digest = setResult.Value.Digest;

            // Assert
            var getResultValue = (await client.GetManifestAsync(digest)).Value;
            Assert.That(getResultValue.Digest, Is.EqualTo(digest));
            ValidateManifest(getResultValue.Manifest.ToObjectFromJson<OciImageManifest>());

            // Clean up
            await client.DeleteManifestAsync(digest);
        }

        [RecordedTest]
        [Ignore("We removed the overload that takes a stream from the public API.")]
        public async Task CanSetManifestFromNonSeekableStream()
        {
            // Arrange
            var client = CreateBlobClient("oci-artifact");

            await SetManifestPrerequisites(client);

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

            var setResult = await client.SetManifestAsync(manifest);
            string digest = setResult.Value.Digest;

            // Assert
            var getResultValue = (await client.GetManifestAsync(digest)).Value;
            Assert.That(getResultValue.Digest, Is.EqualTo(digest));
            ValidateManifest(getResultValue.Manifest.ToObjectFromJson<OciImageManifest>());

            // Clean up
            await client.DeleteManifestAsync(digest);
        }

        [RecordedTest]
        public async Task CanSetOciManifestWithTag()
        {
            // Arrange
            string repository = "oci-artifact";
            var client = CreateBlobClient(repository);
            var registryClient = CreateClient();
            string tag = "v1";

            await SetManifestPrerequisites(client);

            // Act
            var manifest = ContainerRegistryTestDataHelpers.CreateManifest();
            var setResult = await client.SetManifestAsync(manifest, tag);
            var digest = setResult.Value.Digest;

            // Assert
            var downloadResultValue = (await client.GetManifestAsync(digest)).Value;
            Assert.That(downloadResultValue.Digest, Is.EqualTo(digest));
            ValidateManifest(downloadResultValue.Manifest.ToObjectFromJson<OciImageManifest>());

            var artifact = registryClient.GetArtifact(repository, digest);
            var tags = artifact.GetTagPropertiesCollectionAsync();
            var count = await tags.CountAsync();
            Assert.That(count, Is.EqualTo(1));
            var firstTag = await tags.FirstAsync();
            Assert.That(firstTag.Name, Is.EqualTo(tag));

            // Clean up
            await client.DeleteManifestAsync(digest);
        }

        [RecordedTest]
        public async Task CanSetOciManifestBinaryDataWithTag()
        {
            // Arrange
            string repository = "oci-artifact";
            var client = CreateBlobClient(repository);
            var registryClient = CreateClient();
            string tag = "v1";

            await SetManifestPrerequisites(client);

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

            using Stream stream = new MemoryStream(Encoding.ASCII.GetBytes(payload));
            BinaryData manifest = BinaryData.FromStream(stream);
            var setResult = await client.SetManifestAsync(manifest, tag);
            var digest = setResult.Value.Digest;

            // Assert
            var getResultValue = (await client.GetManifestAsync(digest)).Value;
            Assert.That(getResultValue.Digest, Is.EqualTo(digest));
            ValidateManifest(getResultValue.Manifest.ToObjectFromJson<OciImageManifest>());

            var artifact = registryClient.GetArtifact(repository, digest);
            var tags = artifact.GetTagPropertiesCollectionAsync();
            var count = await tags.CountAsync();
            Assert.That(count, Is.EqualTo(1));
            var firstTag = await tags.FirstAsync();
            Assert.That(firstTag.Name, Is.EqualTo(tag));

            var getResultValue2 = (await client.GetManifestAsync(tag)).Value;
            Assert.That(getResultValue2.Digest, Is.EqualTo(digest));
            ValidateManifest(getResultValue2.Manifest.ToObjectFromJson<OciImageManifest>());

            // Clean up
            await client.DeleteManifestAsync(digest);
        }

        [RecordedTest]
        public async Task CanSetDockerManifest()
        {
            // Arrange

            // We have imported the library/hello-world image in test set-up,
            // so config and blob files pointed to by the manifest are already in the registry.

            ContainerRegistryContentClient client = CreateBlobClient("library/hello-world");

            await SetDockerManifestPrerequisites(client);

            // Act
            string path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "docker", "manifest.json");
            using FileStream fs = File.OpenRead(path);
            BinaryData manifest = BinaryData.FromStream(fs);

            SetManifestResult result = await client.SetManifestAsync(manifest, mediaType: ManifestMediaType.DockerManifest);

            // Assert
            Assert.That(result.Digest, Is.EqualTo("sha256:721089ae5c4d90e58e3d7f7e6c652a351621fbf37c26eceae23622173ec5a44d"));

            // The following fails because the manifest media type is set to OciImageManifest by default
            fs.Position = 0;
            Assert.ThrowsAsync<RequestFailedException>(async () => await client.SetManifestAsync(manifest));
        }

        [RecordedTest]
        [Ignore("Test recordings serialize and compress message bodies: https://github.com/Azure/azure-sdk-tools/issues/3015")]
        public async Task CanGetDockerManifest()
        {
            // Arrange
            var client = CreateBlobClient("library/hello-world");

            // Act

            // The following is the digest of the linux/amd64 manifest for library/hello-world.
            string digest = "sha256:f54a58bc1aac5ea1a25d796ae155dc228b3f0e11d046ae276b39c4bf2f13d8c4";

            GetManifestResult result = await client.GetManifestAsync(digest);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(result.Digest, Is.EqualTo(digest));
                Assert.That(result.MediaType, Is.EqualTo(ManifestMediaType.DockerManifest));
            });
        }

        private async Task SetManifestPrerequisites(ContainerRegistryContentClient client)
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

        private async Task SetDockerManifestPrerequisites(ContainerRegistryContentClient client)
        {
            var layer = "ec0488e025553d34358768c43e24b1954e0056ec4700883252c74f3eec273016";
            var config = "config.json";
            var basePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "docker");

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

        private static void ValidateManifest(OciImageManifest manifest)
        {
            // These are from the values in the Data\oci-artifact\manifest.json file.
            Assert.That(manifest, Is.Not.Null);

            Assert.That(manifest.Configuration, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(manifest.Configuration.MediaType, Is.EqualTo("application/vnd.acme.rocket.config"));
                Assert.That(manifest.Configuration.Digest, Is.EqualTo("sha256:d25b42d3dbad5361ed2d909624d899e7254a822c9a632b582ebd3a44f9b0dbc8"));
                Assert.That(manifest.Configuration.SizeInBytes, Is.EqualTo(171));

                Assert.That(manifest.Layers, Is.Not.Null);
            });
            Assert.That(manifest.Layers, Has.Count.EqualTo(1));
            Assert.Multiple(() =>
            {
                Assert.That(manifest.Layers[0].MediaType, Is.EqualTo("application/vnd.oci.image.layer.v1.tar"));
                Assert.That(manifest.Layers[0].Digest, Is.EqualTo("sha256:654b93f61054e4ce90ed203bb8d556a6200d5f906cf3eca0620738d6dc18cbed"));
                Assert.That(manifest.Layers[0].SizeInBytes, Is.EqualTo(28));
            });
        }

        #region Upload Blob Tests

        [RecordedTest]
        public async Task CanUploadBlob()
        {
            // Arrange
            var repositoryId = Recording.Random.NewGuid().ToString();
            var client = CreateBlobClient(repositoryId);

            int blobSize = 1024;

            BinaryData data = BinaryData.FromBytes(GetConstantBuffer(blobSize, 1));

            string digest = BlobHelper.ComputeDigest(data.ToStream());
            UploadRegistryBlobResult uploadResult = await client.UploadBlobAsync(data);

            Assert.Multiple(() =>
            {
                Assert.That(uploadResult.Digest, Is.EqualTo(digest));
                Assert.That(uploadResult.SizeInBytes, Is.EqualTo(data.ToMemory().Length));
            });

            // Assert
            var downloadResult = await client.DownloadBlobContentAsync(digest);
            Assert.Multiple(() =>
            {
                Assert.That(downloadResult.Value.Digest, Is.EqualTo(digest));
                Assert.That(downloadResult.Value.Content.ToMemory().Length, Is.EqualTo(data.ToMemory().Length));
            });

            // Clean up
            await client.DeleteBlobAsync(digest);
        }

        [RecordedTest]
        public async Task CanUploadBlobStream()
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
                UploadRegistryBlobResult uploadResult = await client.UploadBlobAsync(stream);
                streamLength = uploadResult.SizeInBytes;

                Assert.That(uploadResult.Digest, Is.EqualTo(digest));
            }

            // Assert
            var downloadResult = await client.DownloadBlobContentAsync(digest);
            Assert.Multiple(() =>
            {
                Assert.That(downloadResult.Value.Digest, Is.EqualTo(digest));
                Assert.That(downloadResult.Value.Content.ToArray().Length, Is.EqualTo(streamLength));
            });

            // Clean up
            await client.DeleteBlobAsync(digest);
        }

        [RecordedTest]
        [Ignore(reason: "We don't currently support configurable chunk size on upload.")]
        public async Task CanUploadBlobInEqualSizeChunks()
        {
            // Arrange
            int blobSize = 1024;
            //int chunkSize = 1024 / 4; // Four equal-sized chunks

            var repositoryId = Recording.Random.NewGuid().ToString();
            var client = CreateBlobClient(repositoryId /*, chunkSize*/);

            var data = GetConstantBuffer(blobSize, 1);
            UploadRegistryBlobResult uploadResult = default;
            string digest = default;

            using (var stream = new MemoryStream(data))
            {
                digest = BlobHelper.ComputeDigest(stream);
                uploadResult = await client.UploadBlobAsync(stream);
            }

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(uploadResult.Digest, Is.EqualTo(digest));
                Assert.That(uploadResult.SizeInBytes, Is.EqualTo(blobSize));
            });

            // Clean up
            await client.DeleteBlobAsync(digest);
        }

        [RecordedTest]
        [Ignore(reason: "We don't currently support configurable chunk size on upload.")]
        public async Task CanUploadBlobInUnequalChunks()
        {
            // Arrange
            int blobSize = 1024;
            //int chunkSize = 1024 / 4;    // Equal-sized chunks
            int remainderChunkSize = 20;
            blobSize += remainderChunkSize;

            var repositoryId = Recording.Random.NewGuid().ToString();
            var client = CreateBlobClient(repositoryId /*, chunkSize*/);

            var data = GetConstantBuffer(blobSize, 2);
            UploadRegistryBlobResult uploadResult = default;
            string digest = default;

            using (var stream = new MemoryStream(data))
            {
                digest = BlobHelper.ComputeDigest(stream);
                uploadResult = await client.UploadBlobAsync(stream);
            }

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(uploadResult.Digest, Is.EqualTo(digest));
                Assert.That(uploadResult.SizeInBytes, Is.EqualTo(blobSize));
            });

            // Clean up
            await client.DeleteBlobAsync(digest);
        }

        [RecordedTest]
        [Ignore(reason: "We don't currently support configurable chunk size on upload.")]
        public async Task CanUploadBlobInSingleChunk()
        {
            // Arrange
            int blobSize = 512;
            //int chunkSize = 1024;

            var repositoryId = Recording.Random.NewGuid().ToString();
            var client = CreateBlobClient(repositoryId /*, chunkSize*/);

            var data = GetConstantBuffer(blobSize, 3);
            UploadRegistryBlobResult uploadResult = default;
            string digest = default;

            using (var stream = new MemoryStream(data))
            {
                digest = BlobHelper.ComputeDigest(stream);
                uploadResult = await client.UploadBlobAsync(stream);
            }

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(uploadResult.Digest, Is.EqualTo(digest));
                Assert.That(uploadResult.SizeInBytes, Is.EqualTo(blobSize));
            });

            // Clean up
            await client.DeleteBlobAsync(digest);
        }

        [RecordedTest]
        public async Task CanUploadBlobFromNonSeekableStream()
        {
            // Arrange
            int blobSize = 1024;
            var repositoryId = Recording.Random.NewGuid().ToString();
            var client = CreateBlobClient(repositoryId);

            var data = GetConstantBuffer(blobSize, 3);
            UploadRegistryBlobResult uploadResult = default;
            string digest = BlobHelper.ComputeDigest(new MemoryStream(data));

            using (var stream = new NonSeekableMemoryStream(data))
            {
                uploadResult = await client.UploadBlobAsync(stream);
            }

            // Assert
            Assert.That(uploadResult.Digest, Is.EqualTo(digest));

            // Clean up
            await client.DeleteBlobAsync(digest);
        }

        #endregion

        #region Download Blob Tests

        [RecordedTest]
        public async Task CanDownloadBlobContent()
        {
            // Arrange
            var repositoryId = Recording.Random.NewGuid().ToString();
            var client = CreateBlobClient(repositoryId);

            int blobSize = 1024;
            var data = GetConstantBuffer(blobSize, 1);

            using var stream = new MemoryStream(data);
            UploadRegistryBlobResult uploadResult = await client.UploadBlobAsync(stream);
            var digest = uploadResult.Digest;

            // Act
            Response<DownloadRegistryBlobResult> downloadResult = await client.DownloadBlobContentAsync(digest);

            Assert.Multiple(() =>
            {
                Assert.That(downloadResult.Value.Digest, Is.EqualTo(digest));
                Assert.That(downloadResult.Value.Content.ToArray().Length, Is.EqualTo(stream.Length));
            });

            // Clean up
            await client.DeleteBlobAsync(digest);
        }

        [RecordedTest]
        public async Task CanDownloadBlobStreaming()
        {
            // Arrange
            string repositoryId = Recording.Random.NewGuid().ToString();
            ContainerRegistryContentClient client = CreateBlobClient(repositoryId);

            int blobSize = 1024;
            byte[] data = GetConstantBuffer(blobSize, 1);

            using Stream stream = new MemoryStream(data);
            UploadRegistryBlobResult uploadResult = await client.UploadBlobAsync(stream);
            string digest = uploadResult.Digest;

            // Act
            Response<DownloadRegistryBlobStreamingResult> downloadResult = await client.DownloadBlobStreamingAsync(digest);
            using Stream downloadedStream = downloadResult.Value.Content;
            BinaryData content = BinaryData.FromStream(downloadedStream);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(downloadResult.Value.Digest, Is.EqualTo(digest));
                Assert.That(content.ToMemory().Length, Is.EqualTo(stream.Length));
                Assert.That(content.ToArray(), Is.EqualTo(data));
            });

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
            UploadRegistryBlobResult uploadResult = await client.UploadBlobAsync(uploadStream);
            var digest = uploadResult.Digest;

            // Act
            using var downloadStream = new MemoryStream();
            await client.DownloadBlobToAsync(digest, downloadStream);
            var digestOfDownload = BlobHelper.ComputeDigest(downloadStream);

            Assert.Multiple(() =>
            {
                Assert.That(digestOfDownload, Is.EqualTo(digest));
                Assert.That(downloadStream.Length, Is.EqualTo(blobSize));
            });

            // Clean up
            await client.DeleteBlobAsync(digest);
        }

        [LiveOnly]
        [IgnoreServiceError(404, "BLOB_UPLOAD_INVALID", Reason = "https://github.com/Azure/azure-sdk-for-net/issues/35322")]
        public async Task CanDownloadBlobToStream_MultipleChunks()
        {
            // Download a blob that is larger than the max chunk size.
            int blobSize = 6 * 1024 * 1024;

            // Arrange
            string repositoryId = Recording.Random.NewGuid().ToString();
            ContainerRegistryContentClient client = CreateBlobClient(repositoryId);

            byte[] data = GetRandomBuffer(blobSize);

            using MemoryStream uploadStream = new(data);
            UploadRegistryBlobResult uploadResult = await client.UploadBlobAsync(uploadStream);
            string digest = uploadResult.Digest;

            // Act
            using var downloadStream = new MemoryStream();
            await client.DownloadBlobToAsync(digest, downloadStream);
            string digestOfDownload = BlobHelper.ComputeDigest(downloadStream);

            Assert.Multiple(() =>
            {
                Assert.That(digestOfDownload, Is.EqualTo(digest));
                Assert.That(downloadStream.Length, Is.EqualTo(blobSize));
            });

            // Clean up
            await client.DeleteBlobAsync(digest);
        }

        [RecordedTest]
        [Ignore(reason: "We don't currently support configurable chunk size on download.")]
        public async Task CanDownloadBlobToStreamInEqualSizeChunks()
        {
            // Arrange
            int blobSize = 1024;
            int chunkSize = 1024 / 4; // Four equal-sized chunks

            var repositoryId = Recording.Random.NewGuid().ToString();
            var client = CreateBlobClient(repositoryId);

            var data = GetConstantBuffer(blobSize, 10);

            using var uploadStream = new MemoryStream(data);
            UploadRegistryBlobResult uploadResult = await client.UploadBlobAsync(uploadStream);
            var digest = uploadResult.Digest;

            // Act
            using var downloadStream = new MemoryStream();
            await client.DownloadBlobToAsync(digest, downloadStream, new DownloadBlobToOptions(chunkSize));
            downloadStream.Position = 0;

            BinaryData downloadedData = BinaryData.FromStream(downloadStream);
            var digestOfDownload = BlobHelper.ComputeDigest(downloadStream);

            Assert.Multiple(() =>
            {
                Assert.That(digestOfDownload, Is.EqualTo(digest));
                Assert.That(downloadStream.Length, Is.EqualTo(blobSize));
                Assert.That(downloadedData.ToMemory().Span.SequenceEqual(data.AsSpan()), Is.True);
            });

            // Clean up
            await client.DeleteBlobAsync(digest);
        }

        [RecordedTest]
        [Ignore(reason: "We don't currently support configurable chunk size on download.")]
        public async Task CanDownloadBlobToStreamInUnequalChunks()
        {
            // Arrange
            int blobSize = 1024;
            int chunkSize = 1024 / 4;    // Equal-sized chunks
            int remainderChunkSize = 20;
            blobSize += remainderChunkSize;

            var repositoryId = Recording.Random.NewGuid().ToString();
            var client = CreateBlobClient(repositoryId);

            var data = GetConstantBuffer(blobSize, 11);

            using var uploadStream = new MemoryStream(data);
            UploadRegistryBlobResult uploadResult = await client.UploadBlobAsync(uploadStream);
            var digest = uploadResult.Digest;

            // Act
            using var downloadStream = new MemoryStream();
            await client.DownloadBlobToAsync(digest, downloadStream, new DownloadBlobToOptions(chunkSize));
            downloadStream.Position = 0;

            BinaryData downloadedData = BinaryData.FromStream(downloadStream);
            var digestOfDownload = BlobHelper.ComputeDigest(downloadStream);

            Assert.Multiple(() =>
            {
                Assert.That(digestOfDownload, Is.EqualTo(digest));
                Assert.That(downloadStream.Length, Is.EqualTo(blobSize));
                Assert.That(downloadedData.ToMemory().Span.SequenceEqual(data.AsSpan()), Is.True);
            });

            // Clean up
            await client.DeleteBlobAsync(digest);
        }

        [RecordedTest]
        public async Task CanCatchDownloadFailure()
        {
            // Arrange
            string repositoryId = Recording.Random.NewGuid().ToString();
            ContainerRegistryContentClient client = CreateBlobClient(repositoryId);

            // Act

            // We don't upload a blob, so we expect 404.
            bool caught = false;

            try
            {
                using var downloadStream = new MemoryStream();
                await client.DownloadBlobToAsync("BadDigest", downloadStream);
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                Console.WriteLine($"Service error: {ex.Message}");
                caught = true;
                Assert.That(ex.Message, Does.Contain("Content:"), "Download failed exception did not contain \"Content:\".");
                Assert.That(ex.Message, Does.Contain("404 page not found"), "Download failed exception did not contain error content \"404 page not found\".");
            }

            Assert.That(caught, Is.True, "Did not catch download failed exception.");
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
            Assert.That(await names.AnyAsync(n => n == "oci-artifact"), Is.True);

            var properties = await registryClient.GetArtifact("oci-artifact", "v1").GetManifestPropertiesAsync();
            Assert.That(properties.Value.Digest, Is.EqualTo(uploadManifestResult.Digest));

            // Clean up
            await registryClient.DeleteRepositoryAsync("oci-artifact");
        }

        [Test]
        [LiveOnly]
        [IgnoreServiceError(404, "BLOB_UPLOAD_INVALID", Reason = "https://github.com/Azure/azure-sdk-for-net/issues/35322")]
        public async Task CanUploadAndDownloadLargeBlob()
        {
            long sizeInMiB = 512;
            var uneven = 20;
            long size = (1024 * 1024 * sizeInMiB) + uneven;

            string repositoryId = Recording.Random.NewGuid().ToString();
            ContainerRegistryContentClient client = CreateBlobClient(repositoryId);

            // Upload the large blob
            Stream uploadStream = RandomStream.Create(size);
            UploadRegistryBlobResult uploadResult = await client.UploadBlobAsync(uploadStream);

            // Download to a file stream
            string path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "LargeFile");
            string downloadFileName = "blob_downloaded.bin";
            string filePath = Path.Combine(path, downloadFileName);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using FileStream downloadFs = File.OpenWrite(filePath);
            await client.DownloadBlobToAsync(uploadResult.Digest, downloadFs);

            Assert.Multiple(() =>
            {
                // Content is validated by the client, so we only need to check length.
                Assert.That(File.Exists(filePath), Is.True);
                Assert.That(new FileInfo(filePath).Length, Is.EqualTo(size));
            });
        }

        [Test]
        [LiveOnly]
        [IgnoreServiceError(404, "BLOB_UPLOAD_INVALID", Reason = "https://github.com/Azure/azure-sdk-for-net/issues/35322")]
        public async Task CanUploadAndDownloadLargeBlobStreaming()
        {
            long size = int.MaxValue;
            size++; // Exceed max to exercise path that would throw with an int.

            string repositoryId = Recording.Random.NewGuid().ToString();
            ContainerRegistryContentClient client = CreateBlobClient(repositoryId);

            // Upload the large blob
            Stream uploadStream = RandomStream.Create(size);
            UploadRegistryBlobResult uploadResult = await client.UploadBlobAsync(uploadStream);

            // Download to a file stream
            string path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "LargeFile");
            string downloadFileName = "blob_downloaded.bin";
            string filePath = Path.Combine(path, downloadFileName);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using FileStream downloadFs = File.OpenWrite(filePath);
            Response<DownloadRegistryBlobStreamingResult> response = await client.DownloadBlobStreamingAsync(uploadResult.Digest);
            using Stream contentStream = response.Value.Content;
            long blobSize = response.GetRawResponse().Headers.ContentLengthLong.Value;
            await CopyNetworkStream(contentStream, downloadFs, blobSize);

            Assert.Multiple(() =>
            {
                // Content is validated by the client, so we only need to check length.
                Assert.That(File.Exists(filePath), Is.True);
                Assert.That(new FileInfo(filePath).Length, Is.EqualTo(size));
            });
            Assert.That(new FileInfo(filePath).Length, Is.EqualTo(blobSize));
        }

        private async Task CopyNetworkStream(Stream source, Stream destination, long size, CancellationToken cancellationToken = default)
        {
            int bufferSize = 4 * 1024 * 1024; // 4MB
            byte[] buffer = ArrayPool<byte>.Shared.Rent(bufferSize);

            long blobBytes = 0;
            long blobSize = size;

            try
            {
                do
                {
                    int bytesRead = await source.ReadAsync(buffer, 0, bufferSize, cancellationToken).ConfigureAwait(false);
                    await destination.WriteAsync(buffer, 0, bytesRead, cancellationToken).ConfigureAwait(false);
                    blobBytes += bytesRead;
                }
                while (blobBytes < blobSize);

                await destination.FlushAsync(cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
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
            Assert.That(response.Status, Is.EqualTo(307));
            Assert.That(response.Headers.TryGetValue("Location", out string value), Is.True);

            Assert.DoesNotThrow(() => { Uri redirectUri = new(value); });

            // Clean up
            await client.DeleteBlobAsync(digest);
        }

        private async Task<SetManifestResult> Push(ContainerRegistryContentClient client)
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "oci-artifact");

            OciImageManifest manifest = new(schemaVersion: 2);

            // Upload config
            var configFilePath = Path.Combine(path, "config.json");
            if (File.Exists(configFilePath))
            {
                using (var fs = File.OpenRead(configFilePath))
                {
                    var uploadResult = await client.UploadBlobAsync(fs);

                    // Update manifest
                    OciDescriptor descriptor = new OciDescriptor();
                    descriptor.Digest = uploadResult.Value.Digest;
                    descriptor.SizeInBytes = uploadResult.Value.SizeInBytes;
                    descriptor.MediaType = "application/vnd.acme.rocket.config";

                    manifest.Configuration = descriptor;
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
                        OciDescriptor descriptor = new OciDescriptor();
                        descriptor.Digest = uploadResult.Value.Digest;
                        descriptor.SizeInBytes = uploadResult.Value.SizeInBytes;
                        descriptor.MediaType = "application/vnd.oci.image.layer.v1.tar";

                        manifest.Layers.Add(descriptor);
                    }
                }
            }

            // Finally, upload manifest
            return await client.SetManifestAsync(manifest, "v1");
        }

        [RecordedTest]
        public async Task CanPullArtifact()
        {
            // Arrange
            var client = CreateBlobClient("oci-artifact");
            await Push(client);

            // Act

            // Get Manifest
            var manifestResult = await client.GetManifestAsync("v1");

            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "validate-pull");
            Directory.CreateDirectory(path);
            string manifestFile = Path.Combine(path, "manifest.json");
            using (FileStream fs = File.Create(manifestFile))
            {
                await manifestResult.Value.Manifest.ToStream().CopyToAsync(fs);
            }
            OciImageManifest manifest = manifestResult.Value.Manifest.ToObjectFromJson<OciImageManifest>();

            // Download Config
            string configFileName = Path.Combine(path, "config.json");
            using (FileStream fs = File.Create(configFileName))
            {
                DownloadRegistryBlobResult layerResult = await client.DownloadBlobContentAsync(manifest.Configuration.Digest);
                await layerResult.Content.ToStream().CopyToAsync(fs);
            }

            // Download Layers
            foreach (var layerFile in manifest.Layers)
            {
                string fileName = Path.Combine(path, TrimSha(layerFile.Digest));

                using (FileStream fs = File.Create(fileName))
                {
                    DownloadRegistryBlobResult layerResult = await client.DownloadBlobContentAsync(manifest.Configuration.Digest);
                    await layerResult.Content.ToStream().CopyToAsync(fs);
                }
            }

            // Assert
            ContainerRegistryClient registryClient = CreateClient();

            var properties = await registryClient.GetArtifact("oci-artifact", "v1").GetManifestPropertiesAsync();
            Assert.That(properties.Value.Digest, Is.EqualTo(manifestResult.Value.Digest));
            var files = Directory.GetFiles(path).Select(f => Path.GetFileName(f)).ToArray();
            Assert.That(files, Does.Contain("manifest.json"));
            Assert.That(files, Does.Contain("config.json"));
            foreach (var file in manifest.Layers)
            {
                Assert.That(files, Does.Contain(TrimSha(file.Digest)));
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
