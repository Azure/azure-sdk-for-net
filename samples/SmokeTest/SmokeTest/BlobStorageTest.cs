using Azure.Storage.Blobs;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace SmokeTest
{
    class BlobStorageTest
    {
        private BlobServiceClient service;
        private BlockBlobClient blob;

        public BlobStorageTest(string connectionString,string containerName, string blobName)
        {
            this.service = new BlobServiceClient(connectionString);
            this.blob = service.GetBlobContainerClient(containerName).GetBlockBlobClient(blobName);
        }

        /// <summary>
        /// Test the Storage Blobs SDK
        /// </summary>
        /// <returns>true if passes, false if fails</returns>
        public async Task<bool> RunTests()
        {
            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("STORAGE");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Functionalities to test: 2:");
            Console.WriteLine("1.- Upload Blob Block");
            Console.WriteLine("2.- Delete that Blob Block" + '\n');

            Console.Write("Uploading blob... ");
            await UploadBlob();
            Console.WriteLine("done");

            Console.Write("Deleting blob... ");
            await DeleteBlob();
            Console.WriteLine("done");

            return true;
        }

        private async Task UploadBlob()
        {
            //This will upload an existing file into the container previously created
            const string path = "./Resources/BlobTestSource.txt";

            using (FileStream data = File.OpenRead(path))
            {
                await blob.UploadAsync(data);
            }
        }

        private async Task DeleteBlob()
        {
            await blob.DeleteAsync();
        }
    }
}