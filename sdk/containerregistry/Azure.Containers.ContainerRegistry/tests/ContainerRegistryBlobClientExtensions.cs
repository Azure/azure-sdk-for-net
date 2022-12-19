// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Containers.ContainerRegistry.Specialized;

namespace Azure.Containers.ContainerRegistry.Tests
{
    /// <summary>
    /// Extensions to simplify test authoring for ACR tests.
    /// </summary>
    internal static class ContainerRegistryBlobClientExtensions
    {
        private static Random _random = new Random();

        public static async Task UploadTestImageAsync(this ContainerRegistryBlobClient client, string tag = default)
        {
            OciManifest manifest = new()
            {
                SchemaVersion = 2
            };

            // Upload a config file
            using Stream config = BinaryData.FromString("Sample config").ToStream();
            var uploadConfigResult = await client.UploadBlobAsync(config);

            manifest.Config = new OciBlobDescriptor()
            {
                Digest = uploadConfigResult.Value.Digest,
                Size = uploadConfigResult.Value.Size,
                MediaType = "application/vnd.oci.image.config.v1+json"
            };

            // Upload a layer file
            using Stream layer = BinaryData.FromString($"Sample layer {_random.Next()}").ToStream();
            var uploadLayerResult = await client.UploadBlobAsync(layer);

            manifest.Layers.Add(new OciBlobDescriptor()
            {
                Digest = uploadLayerResult.Value.Digest,
                Size = uploadLayerResult.Value.Size,
                MediaType = "application/vnd.oci.image.layer.v1.tar"
            });

            // Finally, upload the manifest file
            var options = tag != null ? new UploadManifestOptions(tag) : null;
            await client.UploadManifestAsync(manifest, options);
        }

        public static async Task AddTagAsync(this ContainerRegistryBlobClient client, string reference, string tag)
        {
            // Get the image manifest
            var manifestResult = await client.DownloadManifestAsync(new DownloadManifestOptions(reference));
            var stream = manifestResult.Value.ManifestStream;
            stream.Seek(0, SeekOrigin.Begin);

            // Upload the manifest with the new tag
            await client.UploadManifestAsync(stream, new UploadManifestOptions(tag));
        }
    }
}
