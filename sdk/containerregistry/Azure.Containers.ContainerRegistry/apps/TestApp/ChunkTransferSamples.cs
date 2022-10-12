using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.Containers.ContainerRegistry.Specialized;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace TestApp
{
    public class ChunkTransferSamples
    {
        public static long DefaultChunkSize = 128 * 1024;

        public static async Task TransferInChunksAsync(
            ContainerRegistryBlobClient acrClient,
            BlobContainerClient blobContainerClient)
        {
            OciManifest manifest = await TransferManifestAsync(acrClient, blobContainerClient);

            await TransferConfigAsync(manifest.Config, acrClient, blobContainerClient);

            foreach (var layerInfo in manifest.Layers)
            {
                await TransferLayerAsync(layerInfo, acrClient, blobContainerClient);
            }
        }

        private static async Task<OciManifest> TransferManifestAsync(ContainerRegistryBlobClient acrClient, BlobContainerClient blobContainerClient)
        {
            DownloadManifestResult manifestResult = await acrClient.DownloadManifestAsync(new DownloadManifestOptions("v1"));

            await blobContainerClient.UploadBlobAsync("manifest.json", manifestResult.ManifestStream);

            return manifestResult.Manifest;
        }

        private static async Task TransferConfigAsync(OciBlobDescriptor config, ContainerRegistryBlobClient acrClient, BlobContainerClient blobContainerClient)
        {
            DownloadBlobResult configResult = await acrClient.DownloadBlobAsync(config.Digest);

            await blobContainerClient.UploadBlobAsync("config.json", configResult.Content);
        }

        // TODO: add parallelization to sample
        private static async Task TransferLayerAsync(OciBlobDescriptor layerInfo, ContainerRegistryBlobClient acrClient, BlobContainerClient blobContainerClient)
        {
            string digest = OciBlobDescriptor.TrimSha(layerInfo.Digest);
            BlockBlobClient blockBlobClient = blobContainerClient.GetBlockBlobClient(digest);

            List<string> blockIds = new();

            // Note: if size is not set, we would need to get it a different way
            foreach (var range in GetRanges(layerInfo.Size!.Value))
            {
                string blockId = await TransferChunkAsync(digest, range, acrClient, blockBlobClient);
                blockIds.Add(blockId);
            }

            await blockBlobClient.CommitBlockListAsync(blockIds);
        }

        private static async Task<string> TransferChunkAsync(string digest, HttpRange range, ContainerRegistryBlobClient acrClient, BlockBlobClient blockBlobClient)
        {
            Response response = await acrClient.GetChunkAsync(acrClient.RepositoryName, digest, range.ToString());

            string blockId = GenerateBlockId(range.Offset);

            await blockBlobClient.StageBlockAsync(blockId, response.ContentStream);

            return blockId;
        }

        private static IEnumerable<HttpRange> GetRanges(long fileSize, long? maxChunkSize = null)
        {
            long chunkSize = maxChunkSize ?? DefaultChunkSize;

            int count = (int)Math.Ceiling(fileSize / (double)chunkSize);

            for (int i = 0; i < count; i++)
            {
                if (i == (count - 1))
                {
                    yield return new HttpRange(i * chunkSize);
                    yield break;
                }

                yield return new HttpRange(i * chunkSize, chunkSize);
            }
        }

        // Block IDs must be 64 byte Base64 encoded strings
        private static string GenerateBlockId(long offset)
        {
            byte[] id = new byte[48]; // 48 raw bytes => 64 byte string once Base64 encoded
            BitConverter.GetBytes(offset).CopyTo(id, 0);
            return Convert.ToBase64String(id);
        }
    }
}
