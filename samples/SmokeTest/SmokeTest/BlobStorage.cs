using Azure.Storage.Blobs;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace SmokeTest
{
    class BlobStorage
    {
        /*Create the Blob client with the connection string.
         * The connection string is retreived from an envirmonet variable.
         * The container name for this sample is 'mycontainer', and the Blob name 'SmokeTestBlob'
         */

        private static BlobServiceClient service = new BlobServiceClient(Environment.GetEnvironmentVariable("BLOB_CONNECTION_STRING"));
        private static BlockBlobClient blob = service.GetBlobContainerClient("mycontainer").GetBlockBlobClient("SmokeTestBlob");

        public static async Task performFunctionalities()
        {
            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("STORAGE");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Functionalities to test: 2:");
            Console.WriteLine("1.- Upload Blob Block");
            Console.WriteLine("2.- Delete that Blob Block" + '\n');

            //Upload a new Blob (txt file in /BlobFiles folder)
            Console.Write("Uploading blob... ");
            Console.Write(await UploadBlob() + '\n');

            //Delete the Blob that was created
            Console.Write("Deleting blob... ");
            Console.Write(await DeleteBlob() + '\n');
        }

        private static async Task<string> UploadBlob()
        {
            const string path = "./Resources/BlobTestSource.txt";

            using (FileStream data = File.OpenRead(path))
            {
                await blob.UploadAsync(data);
            }
            return "Blob created successfully";
        }

        private static async Task<string> DeleteBlob()
        {
            await blob.DeleteAsync();
            return "Blob deleted successfully";
        }

    }
}
