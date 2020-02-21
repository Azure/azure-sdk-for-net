// ------------------------------------
// Copyright(c) Microsoft Corporation.
// Licensed under the MIT License.
// ------------------------------------
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SmokeTest
{
    class BlobStorageTest
    {
        private static BlobServiceClient serviceClient;
        private static BlockBlobClient blobClient;

        /// <summary>
        /// Test the Storage Blobs SDK
        /// </summary>
        public static async Task RunTests()
        {
            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("STORAGE");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Functionalities to test: 2:");
            Console.WriteLine("1.- Upload Blob Block");
            Console.WriteLine("2.- Delete that Blob Block" + '\n');

            string connectionString = Environment.GetEnvironmentVariable("BLOB_CONNECTION_STRING");
            string containerName = "mycontainer"; //The container must exists, this sample is not creating it.
            string blobName = $"netSmokeTestBlob-{Guid.NewGuid()}.txt";
            serviceClient = new BlobServiceClient(connectionString);
            blobClient = serviceClient.GetBlobContainerClient(containerName).GetBlockBlobClient(blobName);

            await UploadBlob();
            await DeleteBlob();
        }

        private static async Task UploadBlob()
        {
            Console.Write("Uploading blob... ");

            const string content = "This is the content for the sample blob";
            byte[] byteArray = Encoding.UTF8.GetBytes(content);
            MemoryStream stream = new MemoryStream(byteArray);
            await blobClient.UploadAsync(stream);

            Console.WriteLine("\tdone");
        }

        private static async Task DeleteBlob()
        {
            Console.Write("Deleting blob...");
            await blobClient.DeleteAsync();
            Console.WriteLine("\tdone");
        }
    }
}