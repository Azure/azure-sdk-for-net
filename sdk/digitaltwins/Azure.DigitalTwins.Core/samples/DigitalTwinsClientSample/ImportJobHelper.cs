using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Storage.Blobs;

namespace Azure.DigitalTwins.Core.Samples
{
    internal class ImportJobHelper
    {
        /// <summary>
        /// Loads input blob into existing storage account
        /// </summary>
        /// <param name="options">reference to options passed in by user</param>
        /// <returns>true/false representing status of upload</returns>
        public static async Task<bool> UploadInputBlobToStorageContainerAsync(Options options)
        {
            string filename = "sampleInputBlob.ndjson";
            try
            {
                BlobUriBuilder blobUriBuilder = new BlobUriBuilder(new Uri(options.StorageAccountContainerEndpoint));
                BlobServiceClient serviceClient = new BlobServiceClient(blobUriBuilder.ToUri(), new DefaultAzureCredential());
                BlobContainerClient containerClient = serviceClient.GetBlobContainerClient(blobUriBuilder.BlobContainerName);
                BlobClient blobClient = containerClient.GetBlobClient(filename);

                string localFilePath = "./" + filename;

                // upload the input blob file. overwrite if it already exists
                await blobClient.UploadAsync(localFilePath, overwrite: true);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when uploading input blob to storage container due to: {ex}", ConsoleColor.Red);
                Environment.Exit(0);
                return false;
            }
        }
    }
}
