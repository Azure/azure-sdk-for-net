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
        public static async Task<bool> UploadInputBlobAsync(Options options)
        {
            try
            {
                BlobServiceClient serviceClient = new BlobServiceClient(new Uri(options.StorageAccountEndpoint), new DefaultAzureCredential());
                BlobContainerClient containerClient = serviceClient.GetBlobContainerClient(options.StorageAccountContainerName);
                BlobClient blobClient = containerClient.GetBlobClient("sample-blob");

                string localFilePath = "Blobs/sampleInputBlob.ndjson";

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
