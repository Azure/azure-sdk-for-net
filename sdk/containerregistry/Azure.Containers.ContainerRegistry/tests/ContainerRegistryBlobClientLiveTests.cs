// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Containers.ContainerRegistry.Specialized;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Containers.ContainerRegistry.Tests
{
    [NonParallelizable]
    public class ContainerRegistryBlobClientLiveTests : ContainerRegistryRecordedTestBase
    {
        public ContainerRegistryBlobClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Create an OciManifest type that matches the contents of the manifest.json test data file.
        /// </summary>
        /// <returns></returns>
        private static OciManifest CreateManifest()
        {
            OciManifest manifest = new OciManifest()
            {
                SchemaVersion = 2,
                Config = new OciBlobDescriptor()
                {
                    MediaType = "application/vnd.acme.rocket.config",
                    Digest = "sha256:d25b42d3dbad5361ed2d909624d899e7254a822c9a632b582ebd3a44f9b0dbc8",
                    Size = 171
                }
            };
            manifest.Layers.Add(new OciBlobDescriptor()
            {
                MediaType = "application/vnd.oci.image.layer.v1.tar",
                Digest = "sha256:654b93f61054e4ce90ed203bb8d556a6200d5f906cf3eca0620738d6dc18cbed",
                Size = 28,
                Annotations = new OciAnnotations()
                {
                    Name = "artifact.txt"
                }
            });

            return manifest;
        }

        [RecordedTest]
        public async Task CanUploadOciManifest()
        {
            // Arrange
            var client = CreateBlobClient("oci-artifact");

            await UploadManifestPrerequisites(client);

            // Act
            var manifest = CreateManifest();
            var uploadResult = await client.UploadManifestAsync(manifest);
            string digest = uploadResult.Value.Digest;

            // Assert
            DownloadManifestOptions downloadOptions = new DownloadManifestOptions(null, digest);
            using var downloadResultValue = (await client.DownloadManifestAsync(downloadOptions)).Value;
            Assert.AreEqual(0, downloadResultValue.ManifestStream.Position);
            Assert.AreEqual(digest, downloadResultValue.Digest);
            ValidateManifest((OciManifest)downloadResultValue.Manifest);

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
            DownloadManifestOptions downloadOptions = new DownloadManifestOptions(null, digest);
            using var downloadResultValue = (await client.DownloadManifestAsync(downloadOptions)).Value;
            Assert.AreEqual(0, downloadResultValue.ManifestStream.Position);
            Assert.AreEqual(digest, downloadResultValue.Digest);
            ValidateManifest((OciManifest)downloadResultValue.Manifest);

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
            var manifest = CreateManifest();
            var uploadResult = await client.UploadManifestAsync(manifest, new UploadManifestOptions(tag));
            var digest = uploadResult.Value.Digest;

            // Assert
            DownloadManifestOptions downloadOptions = new DownloadManifestOptions(null, digest);
            using var downloadResultValue = (await client.DownloadManifestAsync(downloadOptions)).Value;
            Assert.AreEqual(0, downloadResultValue.ManifestStream.Position);
            Assert.AreEqual(digest, downloadResultValue.Digest);
            ValidateManifest((OciManifest)downloadResultValue.Manifest);

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
            var uploadResult = await client.UploadManifestAsync(manifest, new UploadManifestOptions(tag));
            var digest = uploadResult.Value.Digest;

            // Assert
            DownloadManifestOptions downloadOptions = new DownloadManifestOptions(null, digest);
            using var downloadResultValue = (await client.DownloadManifestAsync(downloadOptions)).Value;
            Assert.AreEqual(0, downloadResultValue.ManifestStream.Position);
            Assert.AreEqual(digest, downloadResultValue.Digest);
            ValidateManifest((OciManifest)downloadResultValue.Manifest);

            var artifact = registryClient.GetArtifact(repository, digest);
            var tags = artifact.GetTagPropertiesCollectionAsync();
            var count = await tags.CountAsync();
            Assert.AreEqual(1, count);
            var firstTag = await tags.FirstAsync();
            Assert.AreEqual(tag, firstTag.Name);

            downloadOptions = new DownloadManifestOptions(tag, null);
            using var downloadResultValue2 = (await client.DownloadManifestAsync(downloadOptions)).Value;
            Assert.AreEqual(0, downloadResultValue.ManifestStream.Position);
            Assert.AreEqual(digest, downloadResultValue.Digest);
            ValidateManifest((OciManifest)downloadResultValue.Manifest);

            // Clean up
            await client.DeleteManifestAsync(digest);
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

        [RecordedTest]
        public async Task CanUploadBlob()
        {
            // Arrange
            var client = CreateBlobClient("oci-artifact");
            var blob = "654b93f61054e4ce90ed203bb8d556a6200d5f906cf3eca0620738d6dc18cbed";
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "oci-artifact", blob);

            string digest = default;
            long streamLength;
            // Act
            using (var fs = File.OpenRead(path))
            {
                var uploadResult = await client.UploadBlobAsync(fs);
                digest = uploadResult.Value.Digest;
                streamLength = uploadResult.Value.Size;
            }

            // Assert
            var downloadResult = await client.DownloadBlobAsync(digest);
            Assert.AreEqual(digest, downloadResult.Value.Digest);
            Assert.AreEqual(streamLength, downloadResult.Value.Content.Length);

            //// Clean up
            await client.DeleteBlobAsync(digest);
            downloadResult.Value.Dispose();
        }

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
            return await client.UploadManifestAsync(manifest, new UploadManifestOptions("v1"));
        }

        [RecordedTest]
        public async Task CanPullArtifact()
        {
            // Arrange
            var client = CreateBlobClient("oci-artifact");
            await Push(client);

            // Act

            // Download Manifest
            var manifestResult = await client.DownloadManifestAsync(new DownloadManifestOptions("v1"));

            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "validate-pull");
            Directory.CreateDirectory(path);
            string manifestFile = Path.Combine(path, "manifest.json");
            using (FileStream fs = File.Create(manifestFile))
            {
                Stream stream = manifestResult.Value.ManifestStream;
                await stream.CopyToAsync(fs);
            }
            OciManifest manifest = (OciManifest)manifestResult.Value.Manifest;

            // Download Config
            string configFileName = Path.Combine(path, "config.json");
            using (FileStream fs = File.Create(configFileName))
            {
                var layerResult = await client.DownloadBlobAsync(manifest.Config.Digest);
                Stream stream = layerResult.Value.Content;
                await stream.CopyToAsync(fs);
            }

            // Download Layers
            foreach (var layerFile in manifest.Layers)
            {
                string fileName = Path.Combine(path, TrimSha(layerFile.Digest));

                using (FileStream fs = File.Create(fileName))
                {
                    var layerResult = await client.DownloadBlobAsync(layerFile.Digest);
                    Stream stream = layerResult.Value.Content;
                    await stream.CopyToAsync(fs);
                }
            }

            // Assert
            ContainerRegistryClient registryClient = CreateClient();

            var properties = await registryClient.GetArtifact("oci-artifact", "v1").GetManifestPropertiesAsync();
            Assert.AreEqual(manifestResult.Value.Digest, properties.Value.Digest);
            var files = Directory.GetFiles(path).Select(f => Path.GetFileName(f)).ToArray();
            Assert.Contains("manifest.json", files);
            Assert.Contains("config.json", files);
            foreach (var file in  manifest.Layers)
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
    }
}
