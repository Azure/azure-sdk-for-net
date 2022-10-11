using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.Containers.ContainerRegistry.Specialized;
using Azure.Storage.Blobs;

namespace TestApp
{
    public class DataTransferrer
    {
        public static async Task TransferInChunks(
            ContainerRegistryBlobClient acrClient,
            BlobClient blobClient)
        {
            OciManifest manifest = await TransferManifestAsync(acrClient, blobClient);

            await TransferConfigAsync(manifest.Config, acrClient, blobClient);

            foreach (var layerInfo in manifest.Layers)
            {
                await TransferLayerAsync(layerInfo, acrClient, blobClient);
            }
        }

        private static async Task<OciManifest> TransferManifestAsync(ContainerRegistryBlobClient acrClient, BlobClient blobClient)
        {
            throw new NotImplementedException();
        }

        private static async Task TransferConfigAsync(OciBlobDescriptor config, ContainerRegistryBlobClient acrClient, BlobClient blobClient)
        {
            throw new NotImplementedException();
        }

        private static async Task TransferLayerAsync(OciBlobDescriptor layerInfo, ContainerRegistryBlobClient acrClient, BlobClient blobClient)
        {
            var chunks = BreakIntoChunks(layerInfo);
            foreach (var chunk in chunks)
            {
                TransferChunkAsync(chunk, acrClient, blobClient);
            }
        }

        private static IList<HttpRange> BreakIntoChunks(OciBlobDescriptor layerInfo)
        {
            throw new NotImplementedException();
        }

        private static async Task TransferChunkAsync(HttpRange chunk, ContainerRegistryBlobClient acrClient, BlobClient blobClient)
        {
            // TODO: Make it parallel
        }
    }

}
