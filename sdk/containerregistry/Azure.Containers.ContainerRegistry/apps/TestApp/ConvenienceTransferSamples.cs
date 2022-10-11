using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.Containers.ContainerRegistry.Specialized;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace TestApp
{
    public class ConvenienceTransferSamples
    {
        public static async Task TransferArtifactAsync(ContainerRegistryBlobClient acrClient, BlobContainerClient blobContainerClient)
        {
            // Set the directory where the artifact files live
            // and tune the concurrency and chunk size settings
            string path = "<path-to-container-files>";
            int maxWorkers = 4;
            int maxChunkSize = 128 * 1024;

            // Download the files comprising the OCI artifact from ACR
            await acrClient.DownloadToAsync(path, new ArtifactDownloadToOptions
            {
                MaxConcurrency = maxWorkers,
                MaxDownloadSize = maxChunkSize
            });

            // Upload the artifact files to blob storage
            foreach (var file in Directory.GetFiles(path))
            {
                string blobName = Path.GetFileName(file);
                var blob = blobContainerClient.GetBlobClient(blobName);
                await blob.UploadAsync(file, new BlobUploadOptions
                {
                    TransferOptions = new StorageTransferOptions
                    {
                        MaximumConcurrency = maxWorkers,
                        MaximumTransferSize = maxChunkSize
                    }
                });
            }
        }
    }
}
