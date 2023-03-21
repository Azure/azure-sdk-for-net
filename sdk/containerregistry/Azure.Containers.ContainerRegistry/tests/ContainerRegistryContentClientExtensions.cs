// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Containers.ContainerRegistry.Tests
{
    /// <summary>
    /// Extensions to simplify test authoring for ACR tests.
    /// </summary>
    internal static class ContainerRegistryContentClientExtensions
    {
        private static Random _random = new Random();

        public static async Task<string> UploadTestImageAsync(this ContainerRegistryContentClient client, string tag = default)
        {
            OciImageManifest manifest = new()
            {
                SchemaVersion = 2
            };

            // Upload a config file
            BinaryData config = BinaryData.FromString("Sample config");
            var uploadConfigResult = await client.UploadBlobAsync(config);

            manifest.Configuration = new OciDescriptor()
            {
                Digest = uploadConfigResult.Value.Digest,
                SizeInBytes = uploadConfigResult.Value.SizeInBytes,
                MediaType = "application/vnd.oci.image.config.v1+json"
            };

            // Upload a layer file
            BinaryData layer = BinaryData.FromString($"Sample layer {_random.Next()}");
            var uploadLayerResult = await client.UploadBlobAsync(layer);

            manifest.Layers.Add(new OciDescriptor()
            {
                Digest = uploadLayerResult.Value.Digest,
                SizeInBytes = uploadLayerResult.Value.SizeInBytes,
                MediaType = "application/vnd.oci.image.layer.v1.tar"
            });

            // Finally, upload the manifest file
            var result = await client.UploadManifestAsync(manifest, tag);

            // return the manifest's digest
            return result.Value.Digest;
        }

        public static async Task AddTagAsync(this ContainerRegistryContentClient client, string reference, string tag)
        {
            // Get the image manifest
            var manifestResult = await client.DownloadManifestAsync(reference);

            // Upload the manifest with the new tag
            await client.UploadManifestAsync(manifestResult.Value.Content.ToStream(), tag);
        }
    }
}
