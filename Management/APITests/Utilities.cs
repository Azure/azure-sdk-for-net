using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure.ManagementClient.v1_7;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace APITests
{
    //class that does basic function for each class
    //create certs, etc.    
    static class Utilities
    {
        internal static readonly Guid SubscriptionId = new Guid("c05a8d41-95fc-40f7-b16f-9a5b8e86a938");
        internal static AzureHttpClient CreateAzureHttpClient()
        {
            //TODO: Read this from somewhere, so it isn't just mine...
            string thumbprint = "5d 32 e2 84 aa e5 a8 2b c9 85 64 9b ca c5 cf 91 f2 04 43 a5";

            X509Certificate2 cert = LoadCertificate(thumbprint);

            //instantiate client
            return new AzureHttpClient(SubscriptionId, cert);
        }

        internal static X509Certificate2 LoadCertificate(string thumbprint)
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);

            store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadOnly);

            X509Certificate2Collection certs = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false);

            if (certs.Count == 0) throw new FileNotFoundException(string.Format("Certificate with thumbprint {0} does not exist", thumbprint));

            return certs[0];
        }

        //This *always* calls the GetOperationStatus API
        internal static Action<Task<string>> PollUntilComplete(AzureHttpClient client, string operationName, TestContext context, CancellationToken token)
        {
            return (resultTask) =>
                {
                    string requestId = resultTask.Result;
                    context.WriteLine("Polling Operation: \"{0}.\" Request id is: {1}", operationName, requestId);
                    int curWaitTime = 1, lastWaitTime = 1;
                    Task<OperationStatusInfo> opStatus;
                    token.ThrowIfCancellationRequested();
                    do
                    {
                        context.WriteLine("\tOperation with id {0} is not complete, waiting {1} seconds.", requestId, curWaitTime);
                        Thread.Sleep(curWaitTime * 1000);
                        token.ThrowIfCancellationRequested();
                        int cur = curWaitTime;
                        curWaitTime += lastWaitTime;
                        lastWaitTime = cur;
                        context.WriteLine("\tCalling GetOperationStatus");
                        opStatus = client.GetOperationStatusAsync(requestId, token);
                        context.WriteLine(opStatus.Result.ToString());
                    } while (opStatus.Result.Status == OperationStatus.InProgress);

                    opStatus.Result.EnsureSuccessStatus();
                };
        }

        //this *always* calls GetStorageAccountProperties and GetStorageAccountKeys
        internal static Uri UploadToBlob(AzureHttpClient client, TestContext context, string storageAccountName, string fileToUpload, CancellationToken token)
        {
            //container names must be all lowercase...
            //this is the same container vs uses...
            const string blobUploadContainer = "vsdeploy";
            const int MB = 1048576;
            const int kb = 1024;
            const int MaxMBs = 600; //package can't be larger than 600 MB
            const long MaxFileSize = MB * MaxMBs;
            const int MinsPerMB = 3;

            Uri blob, queue, table;

            context.WriteLine("Preparing to upload file {0} to storage account {1}.", fileToUpload, storageAccountName);
            string fileName = Path.GetFileName(fileToUpload);

            context.WriteLine("Calling GetStorageAccountProperties and GetStorageAccountKeys for storage account {0}", storageAccountName);
            var storagePropsTask = client.GetStorageAccountPropertiesAsync(storageAccountName, token);
            var storageKeysTask = client.GetStorageAccountKeysAsync(storageAccountName, token);

            Task.WaitAll(storagePropsTask, storageKeysTask);

            context.WriteLine(storagePropsTask.Result.ToString());
            context.WriteLine(storageKeysTask.Result.ToString());

            FixupEndpoints(storagePropsTask.Result, out blob, out queue, out table);

            using (FileStream stream = File.Open(fileToUpload, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                long fileSize = stream.Length;
                double MBs = ((double)fileSize) / MB;

                context.WriteLine("Ready to upload file {0}, file size {1}", fileName, MBs.ToString("F6", CultureInfo.CurrentCulture));

                if (MBs < 1) MBs = 1; // no shorter than 3 minute timeout

                if (fileSize > MaxFileSize)
                {
                    throw new ArgumentException(string.Format("File {0} is too large.", fileName), "FileToUpload");
                }

                context.WriteLine("Instantiating Cloud Storage Account object.");

                CloudStorageAccount account = new CloudStorageAccount(
                                                new StorageCredentialsAccountAndKey(
                                                    storagePropsTask.Result.Name,
                                                    storageKeysTask.Result.Primary),
                                                    blob, queue, table);

                context.WriteLine("Cloud Storage Account object intantiated.");

                
                //set the timeout based on the size of the file: 3 mins per MB
                TimeSpan timeout = TimeSpan.FromMinutes((double)(MBs * MinsPerMB));
                context.WriteLine("Setting upload timeout to {0} minutes", timeout.Minutes);

                CloudBlobClient blobClient = account.CreateCloudBlobClient();

                blobClient.RetryPolicy = RetryPolicies.Retry(4, TimeSpan.Zero);
                blobClient.Timeout = timeout;

                CloudBlobContainer container = blobClient.GetContainerReference(blobUploadContainer);

                container.CreateIfNotExist();

                //turn off public access to the container
                BlobContainerPermissions perms = new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Off };
                container.SetPermissions(perms);

                CloudBlob blobRef = container.GetBlobReference(Guid.NewGuid().ToString("N", CultureInfo.InvariantCulture));

                DateTime startTime = DateTime.Now;
                context.WriteLine("Beginning upload of file {0} to blob {1} at time: {2}", fileName, blobRef.Uri, startTime.ToString("T", CultureInfo.CurrentCulture));

                IAsyncResult result = blobRef.BeginUploadFromStream(stream, null, null);

                context.WriteLine("Upload Started, waiting...");

                blobRef.EndUploadFromStream(result);

                DateTime endTime = DateTime.Now;
                TimeSpan uploadTime = endTime - startTime;

                double KBytePerSecond = (stream.Length / uploadTime.TotalSeconds) / kb;

                context.WriteLine("Upload of file {0} to blob {1} completed at {2}.", fileName, blobRef.Uri, endTime.ToString("T", CultureInfo.CurrentCulture));
                context.WriteLine("Upload took {0} seconds at an average rate of {1}kb per second.", uploadTime.Seconds.ToString(CultureInfo.CurrentCulture), KBytePerSecond.ToString("F4", CultureInfo.CurrentCulture)); 

                return blobRef.Uri;

            }
        }

        internal static void DeleteBlob(string storageAccountName, Uri blobUri, AzureHttpClient client, TestContext context, CancellationToken token)
        {
            //this *always* calls GetStorageAccountProperties and GetStorageAccountKeys
            Uri blob, queue, table;

            context.WriteLine("Preparing to delete blob: {0}.", blobUri);

            context.WriteLine("Calling GetStorageAccountProperties and GetStorageAccountKeys for storage account {0}", storageAccountName);
            var storagePropsTask = client.GetStorageAccountPropertiesAsync(storageAccountName, token);
            var storageKeysTask = client.GetStorageAccountKeysAsync(storageAccountName, token);

            Task.WaitAll(storagePropsTask, storageKeysTask);

            context.WriteLine(storagePropsTask.Result.ToString());
            context.WriteLine(storageKeysTask.Result.ToString());

            FixupEndpoints(storagePropsTask.Result, out blob, out queue, out table);

            context.WriteLine("Instantiating Cloud Storage Account object.");

            CloudStorageAccount account = new CloudStorageAccount(
                                            new StorageCredentialsAccountAndKey(
                                                storagePropsTask.Result.Name,
                                                storageKeysTask.Result.Primary),
                                                blob, queue, table);

            context.WriteLine("Cloud Storage Account object intantiated.");

            CloudBlobClient blobClient = account.CreateCloudBlobClient();

            CloudBlob blobRef = blobClient.GetBlobReference(blobUri.ToString());

            context.WriteLine("Deleting blob {0}.", blobUri);

            blobRef.DeleteIfExists();

            context.WriteLine("Blob {0} deleted.", blobUri);

        
        }

        private static void FixupEndpoints(StorageAccountProperties info, out Uri blob, out Uri queue, out Uri table)
        {
            blob = FixupEndpoint(info.Endpoints[0]);
            queue = FixupEndpoint(info.Endpoints[1]);
            table = FixupEndpoint(info.Endpoints[2]);
        }

        //make sure endpoint is https
        private static Uri FixupEndpoint(Uri endpoint)
        {
            //We need these endpoints to be https for a couple reasons
            //first, we want to upload CSPackages via https by default, second
            //the new preview portal *only* works with https, http times out.
            //But they come down to us as http (as of now) so
            //change the http to https.
            Uri httpsUri = endpoint;
            if (endpoint.Scheme == "http")
            {
                string newUri = endpoint.ToString();
                newUri = "https" + newUri.Substring(4);
                httpsUri = new Uri(newUri);
            }

            return httpsUri;
        }

        internal const string CertPassword = "Pa$$w0rd";
        private const string CertCN = "CN=AzureTestCertificate";
        internal static X509Certificate2 CreateCert(bool withPassword)
        {
            string password = null;
            if (withPassword) password = CertPassword;
           
            byte[] certBytes = CertificateCreator.CreateSelfSignCertificatePfx(CertCN, DateTime.Now, DateTime.Now + TimeSpan.FromHours(2), password);

            var ret = new X509Certificate2(certBytes, password, X509KeyStorageFlags.Exportable);

            return ret;
        }
    }
}
