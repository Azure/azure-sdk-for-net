// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Containers.ContainerRegistry.Tests.Samples
{
    public partial class UploadDownloadImageSample : ContainerRegistrySamplesBase
    {
        public async Task UploadOciImageAsync()
        {
            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.Endpoint);

            #region Snippet:ContainerRegistry_Samples_CreateContentClient

            // Get the service endpoint from the environment
            Uri endpoint = new(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

            string repository = "sample-oci-image";
            string tag = "demo";

            // Create a new ContainerRegistryContentClient
            ContainerRegistryContentClient client = new(endpoint, repository, new DefaultAzureCredential());

            #endregion

            #region Snippet:ContainerRegistry_Samples_UploadOciImageAsync

            // Create a manifest to list files in this image
            OciImageManifest manifest = new(schemaVersion: 2);

            // Upload a config file
            BinaryData config = BinaryData.FromString("Sample config");
            UploadRegistryBlobResult uploadConfigResult = await client.UploadBlobAsync(config);

            // Update manifest with config info
            manifest.Configuration = new OciDescriptor()
            {
                Digest = uploadConfigResult.Digest,
                SizeInBytes = uploadConfigResult.SizeInBytes,
                MediaType = "application/vnd.oci.image.config.v1+json"
            };

            // Upload a layer file
            BinaryData layer = BinaryData.FromString("Sample layer");
            UploadRegistryBlobResult uploadLayerResult = await client.UploadBlobAsync(layer);

            // Update manifest with layer info
            manifest.Layers.Add(new OciDescriptor()
            {
                Digest = uploadLayerResult.Digest,
                SizeInBytes = uploadLayerResult.SizeInBytes,
                MediaType = "application/vnd.oci.image.layer.v1.tar"
            });

            // Finally, upload the manifest file
            await client.SetManifestAsync(manifest, tag);

            #endregion
        }

        public async Task DownloadOciImageAsync()
        {
            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.Endpoint);

            // Get the service endpoint from the environment
            Uri endpoint = new(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

            string repository = "sample-oci-image";
            string tag = "demo";

            // Create a new ContainerRegistryContentClient
            ContainerRegistryContentClient client = new ContainerRegistryContentClient(endpoint, repository, new DefaultAzureCredential());

            string path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "validate-pull");
            Directory.CreateDirectory(path);

            #region Snippet:ContainerRegistry_Samples_DownloadOciImageAsync

            // Download the manifest to obtain the list of files in the image
            GetManifestResult result = await client.GetManifestAsync(tag);
            OciImageManifest manifest = result.Manifest.ToObjectFromJson<OciImageManifest>();

            string manifestFile = Path.Combine(path, "manifest.json");
            using (FileStream stream = File.Create(manifestFile))
            {
                await result.Manifest.ToStream().CopyToAsync(stream);
            }

            // Download and write out the config
            DownloadRegistryBlobResult configBlob = await client.DownloadBlobContentAsync(manifest.Configuration.Digest);

            string configFile = Path.Combine(path, "config.json");
            using (FileStream stream = File.Create(configFile))
            {
                await configBlob.Content.ToStream().CopyToAsync(stream);
            }

            // Download and write out the layers
            foreach (OciDescriptor layerInfo in manifest.Layers)
            {
                string layerFile = Path.Combine(path, TrimSha(layerInfo.Digest));
                using (FileStream stream = File.Create(layerFile))
                {
                    await client.DownloadBlobToAsync(layerInfo.Digest, stream);
                }
            }

            static string TrimSha(string digest)
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

        [Test]
        [AsyncOnly]
        public async Task UploadDownloadOciImageAsync()
        {
            await UploadOciImageAsync();
            await DownloadOciImageAsync();

            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.Endpoint);

            // Get the service endpoint from the environment
            Uri endpoint = new(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

            string repository = "sample-oci-image";
            string tag = "demo";

            // Create a new ContainerRegistryContentClient
            ContainerRegistryContentClient client = new(endpoint, repository, new DefaultAzureCredential());

            #region Snippet:ContainerRegistry_Samples_DeleteBlob
            GetManifestResult result = await client.GetManifestAsync(tag);
            OciImageManifest manifest = result.Manifest.ToObjectFromJson<OciImageManifest>();

            foreach (OciDescriptor layerInfo in manifest.Layers)
            {
                await client.DeleteBlobAsync(layerInfo.Digest);
            }
            #endregion

            #region Snippet:ContainerRegistry_Samples_DeleteManifest
            GetManifestResult manifestResult = await client.GetManifestAsync(tag);
            await client.DeleteManifestAsync(manifestResult.Digest);
            #endregion
        }

        public async Task UploadDockerManifestAsync()
        {
            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.Endpoint);

            // Get the service endpoint from the environment
            Uri endpoint = new(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

            string repository = "library/hello-world";

            // Create a new ContainerRegistryContentClient
            ContainerRegistryContentClient client = new ContainerRegistryContentClient(endpoint, repository, new DefaultAzureCredential());
            await SetManifestPrerequisites(client);

            #region Snippet:ContainerRegistry_Samples_UploadCustomManifestAsync

            // Create a manifest file in the Docker v2 Manifest List format
            var manifestList = new
            {
                schemaVersion = 2,
                mediaType = "application/vnd.docker.distribution.manifest.list.v2+json",
                manifests = new[]
                {
                    new
                    {
                        digest = "sha256:721089ae5c4d90e58e3d7f7e6c652a351621fbf37c26eceae23622173ec5a44d",
                        mediaType = ManifestMediaType.DockerManifest.ToString(),
                        platform = new {
                            architecture = ArtifactArchitecture.Amd64.ToString(),
                            os = ArtifactOperatingSystem.Linux.ToString()
                        }
                    }
                }
            };

            // Finally, upload the manifest file
            BinaryData content = BinaryData.FromObjectAsJson(manifestList);
            await client.SetManifestAsync(content, tag: "sample", ManifestMediaType.DockerManifestList);

            #endregion
        }

        private async Task SetManifestPrerequisites(ContainerRegistryContentClient client)
        {
            string layer = "ec0488e025553d34358768c43e24b1954e0056ec4700883252c74f3eec273016";
            string basePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "docker");

            // Upload config
            using (FileStream fs = File.OpenRead(Path.Combine(basePath, "config.json")))
            {
                _ = await client.UploadBlobAsync(fs);
            }

            // Upload layer
            using (FileStream fs = File.OpenRead(Path.Combine(basePath, layer)))
            {
                _ = await client.UploadBlobAsync(fs);
            }

            // Upload manifest
            using (FileStream fs = File.OpenRead(Path.Combine(basePath, "manifest.json")))
            {
                _ = await client.UploadBlobAsync(fs);
            }
        }

        [Test]
        [AsyncOnly]
        public async Task UploadDownloadDockerManifestAsync()
        {
            await UploadDockerManifestAsync();

            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.Endpoint);

            // Get the service endpoint from the environment
            Uri endpoint = new(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

            string repository = "library/hello-world";
            string path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "custom-manifest");
            Directory.CreateDirectory(path);

            // Create a new ContainerRegistryContentClient
            ContainerRegistryContentClient client = new(endpoint, repository, new DefaultAzureCredential());

            #region Snippet:ContainerRegistry_Samples_DownloadCustomManifestAsync
            GetManifestResult result = await client.GetManifestAsync("sample");

            if (result.MediaType == "application/vnd.docker.distribution.manifest.list.v2+json")
            {
                Console.WriteLine("Manifest is a Docker manifest list.");
            }
            else if (result.MediaType == "application/vnd.oci.image.index.v1+json")
            {
                Console.WriteLine("Manifest is an OCI index.");
            }
            #endregion
        }

        [Test]
        public async Task CanCatchUploadFailure()
        {
            Uri endpoint = new("https://example.acr.io");
            string repository = "TestRepository";
            string uploadError = """{"errors":[{"code":"BLOB_UPLOAD_INVALID","message":"blob upload invalid"}]}""";

            ContainerRegistryClientOptions options = new()
            {
                Transport = new MockTransport(new MockResponse(404).SetContent(uploadError).AddHeader("Content-Type", "text/plain; charset=utf-8"))
            };

            ContainerRegistryContentClient client = new(endpoint, repository, new MockCredential(), options);
            bool caught = false;

            #region Snippet:ContainerRegistry_Samples_CanCatchUploadFailure
            try
            {
                BinaryData blob = BinaryData.FromString("Sample blob.");
                UploadRegistryBlobResult uploadResult = await client.UploadBlobAsync(blob);
            }
            catch (RequestFailedException ex) when (ex.Status == 404 && ex.ErrorCode == "BLOB_UPLOAD_INVALID")
            {
                Console.WriteLine("Blob upload failed. Please retry.");
                Console.WriteLine($"Service error: {ex.Message}");
#if !SNIPPET
                caught = true;
#endif
            }
            #endregion

            Assert.IsTrue(caught);
        }
    }
}
