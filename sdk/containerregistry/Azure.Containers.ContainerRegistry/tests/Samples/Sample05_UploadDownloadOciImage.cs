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
    public partial class UploadOciImageSample : ContainerRegistrySamplesBase
    {
        [Test]
        [AsyncOnly]
        public async Task UploadOciImageAsync()
        {
            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.Endpoint);

            #region Snippet:ContainerRegistry_Samples_CreateBlobClient

            // Get the service endpoint from the environment
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

            string repository = "sample-oci-image";
            string tag = "demo";

            // Create a new ContainerRegistryBlobClient
            ContainerRegistryBlobClient client = new ContainerRegistryBlobClient(endpoint, repository, new DefaultAzureCredential(), new ContainerRegistryClientOptions()
            {
                Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud
            });

            #endregion

            #region Snippet:ContainerRegistry_Samples_UploadOciImageAsync

            // Create a manifest to list files in this image
            OciImageManifest manifest = new();

            // Upload a config file
            using Stream config = BinaryData.FromString("Sample config").ToStream();
            UploadBlobResult uploadConfigResult = await client.UploadBlobAsync(config);

            // Update manifest with config info
            manifest.Config = new OciBlobDescriptor()
            {
                Digest = uploadConfigResult.Digest,
                SizeInBytes = uploadConfigResult.SizeInBytes,
                MediaType = "application/vnd.oci.image.config.v1+json"
            };

            // Upload a layer file
            using Stream layer = BinaryData.FromString("Sample layer").ToStream();
            UploadBlobResult uploadLayerResult = await client.UploadBlobAsync(layer);

            // Update manifest with layer info
            manifest.Layers.Add(new OciBlobDescriptor()
            {
                Digest = uploadLayerResult.Digest,
                SizeInBytes = uploadLayerResult.SizeInBytes,
                MediaType = "application/vnd.oci.image.layer.v1.tar"
            });

            // Finally, upload the manifest file
            await client.UploadManifestAsync(manifest, tag);

            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task DownloadOciImageAsync()
        {
            Environment.SetEnvironmentVariable("REGISTRY_ENDPOINT", TestEnvironment.Endpoint);

            // Get the service endpoint from the environment
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

            string repository = "sample-oci-image";
            string tag = "demo";
            string path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "validate-pull");
            Directory.CreateDirectory(path);

            // Create a new ContainerRegistryBlobClient
            ContainerRegistryBlobClient client = new ContainerRegistryBlobClient(endpoint, repository, new DefaultAzureCredential(), new ContainerRegistryClientOptions()
            {
                Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud
            });

            #region Snippet:ContainerRegistry_Samples_DownloadOciImageAsync

            // Download the manifest to obtain the list of files in the image
            DownloadManifestResult result = await client.DownloadManifestAsync(tag);
            OciImageManifest manifest = result.AsOciManifest();

            string manifestFile = Path.Combine(path, "manifest.json");
            using (FileStream stream = File.Create(manifestFile))
            {
                await result.Content.ToStream().CopyToAsync(stream);
            }

            // Download and write out the config
            DownloadBlobResult configBlob = await client.DownloadBlobAsync(manifest.Config.Digest);

            string configFile = Path.Combine(path, "config.json");
            using (FileStream stream = File.Create(configFile))
            {
                await configBlob.Content.ToStream().CopyToAsync(stream);
            }

            // Download and write out the layers
            foreach (OciBlobDescriptor layer in manifest.Layers)
            {
                string layerFile = Path.Combine(path, TrimSha(layer.Digest));
                using (FileStream stream = File.Create(layerFile))
                {
                    await client.DownloadBlobToAsync(layer.Digest, stream);
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
