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

            #region Snippet:ContainerRegistry_Tests_Samples_UploadArtifactAsync

            // Get the service endpoint from the environment
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

            string repository = "sample-artifact";
            string tag = "demo";

            // Create a new ContainerRegistryBlobClient
            ContainerRegistryBlobClient client = new ContainerRegistryBlobClient(endpoint, repository, new DefaultAzureCredential(), new ContainerRegistryClientOptions()
            {
                Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud
            });

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
            await client.UploadManifestAsync(manifest, new UploadManifestOptions(tag));

            #endregion
        }
    }
}
