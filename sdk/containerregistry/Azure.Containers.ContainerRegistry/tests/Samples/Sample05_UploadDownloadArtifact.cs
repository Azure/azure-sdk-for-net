// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Containers.ContainerRegistry.Specialized;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Containers.ContainerRegistry.Tests.Samples
{
    public partial class UploadArtifactSample : ContainerRegistrySamplesBase
    {
        [Test]
        [AsyncOnly]
        public async Task UploadArtifactAsync()
        {
            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.Endpoint);

            #region Snippet:ContainerRegistry_Samples_CreateBlobClient

            // Get the service endpoint from the environment
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

            string repository = "sample-artifact";
            string tag = "demo";

            // Create a new ContainerRegistryBlobClient
            ContainerRegistryBlobClient client = new ContainerRegistryBlobClient(endpoint, repository, new DefaultAzureCredential(), new ContainerRegistryClientOptions()
            {
                Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud
            });

            #endregion

            #region Snippet:ContainerRegistry_Samples_UploadArtifactAsync

            // Create a manifest to list files in this artifact
            OciManifest manifest = new()
            {
                SchemaVersion = 2
            };

            // Upload a config file
            using Stream config = BinaryData.FromString("Sample config").ToStream();
            var uploadConfigResult = await client.UploadBlobAsync(config);

            // Update manifest with config info
            manifest.Config = new OciBlobDescriptor()
            {
                Digest = uploadConfigResult.Value.Digest,
                Size = uploadConfigResult.Value.Size,
                MediaType = OciMediaType.ImageConfig.ToString()
            };

            // Upload a layer file
            using Stream layer = BinaryData.FromString("Sample layer").ToStream();
            var uploadLayerResult = await client.UploadBlobAsync(layer);

            // Update manifest with layer info
            manifest.Layers.Add(new OciBlobDescriptor()
            {
                Digest = uploadLayerResult.Value.Digest,
                Size = uploadLayerResult.Value.Size,
                MediaType = OciMediaType.ImageLayer.ToString()
            });

            // Finally, upload the manifest file
            await client.UploadManifestAsync(manifest, tag);

            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task DownloadArtifactAsync()
        {
            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.Endpoint);

            // Get the service endpoint from the environment
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

            string repository = "sample-artifact";
            string tag = "demo";
            string path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "validate-pull");
            Directory.CreateDirectory(path);

            // Create a new ContainerRegistryBlobClient
            ContainerRegistryBlobClient client = new ContainerRegistryBlobClient(endpoint, repository, new DefaultAzureCredential(), new ContainerRegistryClientOptions()
            {
                Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud
            });

            #region Snippet:ContainerRegistry_Samples_DownloadArtifactAsync

            // Download the manifest to obtain the list of files in the artifact
            DownloadManifestResult result = await client.DownloadManifestAsync(tag);
            OciManifest manifest = result.AsOciManifest();

            await WriteFile(Path.Combine(path, "manifest.json"), result.Content);

            // Download and write out the config
            DownloadBlobResult configBlob = await client.DownloadBlobAsync(manifest.Config.Digest);

            await WriteFile(Path.Combine(path, "config.json"), configBlob.Content);

            // Download and write out the layers
            foreach (var layerFile in manifest.Layers)
            {
                string fileName = Path.Combine(path, TrimSha(layerFile.Digest));
                using (FileStream fs = File.Create(fileName))
                {
                    await client.DownloadBlobToAsync(layerFile.Digest, fs);
                }
            }

            // Helper methods
            async Task WriteFile(string path, BinaryData content)
            {
                using (FileStream fs = File.Create(path))
                {
                    await content.ToStream().CopyToAsync(fs);
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
    }
}
