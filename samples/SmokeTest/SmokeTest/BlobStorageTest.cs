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

        public async Task<bool> PerformFunctionalities()
        {
            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("STORAGE");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Functionalities to test: 2:");
            Console.WriteLine("1.- Upload Blob Block");
            Console.WriteLine("2.- Delete that Blob Block" + '\n');

            //Upload a new Blob (txt file in /BlobFiles folder)
            Console.Write("Uploading blob... ");
            var result1 = await UploadBlob();
            if(result1 != null)
            {
                //If this test failed, then the othe one is going to fail too.
                Console.Error.Write("FAILED.\n");
                Console.Error.WriteLine(result1);
                Console.Error.WriteLine("Cannot delete the Blob.");
                return false;

            }
            else
            {
                Console.Write("Blob uploaded successfully\n");
            }

            //Delete the Blob that was created
            Console.Write("Deleting blob... ");
            var result2 = await DeleteBlob();
            if (result2 != null)
            {
                Console.Error.Write("FAILED.\n");
                Console.Error.WriteLine(result2);
                return false;
            }
            else
            {
                Console.Write("Blob deleted successfully\n");
            }

            return true;
        }

        private async Task<Exception> UploadBlob()
        {
            const string path = "./Resources/BlobTestSource.txt";

            using (FileStream data = File.OpenRead(path))
            {
                try
                {
                    await blob.UploadAsync(data);
                }
                catch (Exception ex)
                {
                    return ex;
                }
            }
            return null;
        }

        private async Task<Exception> DeleteBlob()
        {
            try
            {
                await blob.DeleteAsync();
            }
            catch (Exception ex)
            {
                return ex;
            }
            return null;
        }

    }
}
