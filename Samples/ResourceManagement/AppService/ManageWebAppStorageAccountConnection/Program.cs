// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using CoreFtp;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.AppService.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ManageWebAppStorageAccountConnection
{
    public class Program
    {
        private const string SUFFIX = ".azurewebsites.net";

        /**
         * Azure App Service basic sample for managing web apps.
         *  - Create a storage account and upload a couple blobs
         *  - Create a web app that contains the connection string to the storage account
         *  - Deploy a Tomcat application that reads from the storage account
         *  - Clean up
         */
        public static void RunSample(IAzure azure)
        {
            string app1Name = SharedSettings.RandomResourceName("webapp1-", 20);
            string app1Url = app1Name + SUFFIX;
            string storageName = SharedSettings.RandomResourceName("jsdkstore", 20);
            string containerName = SharedSettings.RandomResourceName("jcontainer", 20);
            string planName = SharedSettings.RandomResourceName("jplan_", 15);
            string rgName = SharedSettings.RandomResourceName("rg1NEMV_", 24);

            try
            {
                //============================================================
                // Create a storage account for the web app to use

                Utilities.Log("Creating storage account " + storageName + "...");

                var storageAccount = azure.StorageAccounts
                        .Define(storageName)
                        .WithRegion(Region.US_WEST)
                        .WithNewResourceGroup(rgName)
                        .Create();

                var accountKey = storageAccount.GetKeys().FirstOrDefault().Value;

                string connectionString = String.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}",
                        storageAccount.Name, accountKey);

                Utilities.Log("Created storage account " + storageAccount.Name);

                //============================================================
                // Upload a few files to the storage account blobs

                Utilities.Log("Uploading 2 blobs to container " + containerName + "...");

                var container = SetUpStorageAccount(connectionString, containerName).GetAwaiter().GetResult();
                UploadFileToContainer(container, "helloworld.war", "Asset/helloworld.war").GetAwaiter().GetResult();
                UploadFileToContainer(container, "install_apache.sh", "Asset/install_apache.Sh").GetAwaiter().GetResult();

                Utilities.Log("Uploaded 2 blobs to container " + container.Name);

                //============================================================
                // Create a web app with a new app service plan

                Utilities.Log("Creating web app " + app1Name + "...");

                var app1 = azure.WebApps
                        .Define(app1Name)
                        .WithExistingResourceGroup(rgName)
                        .WithNewAppServicePlan(planName)
                        .WithRegion(Region.US_WEST)
                        .WithPricingTier(AppServicePricingTier.Standard_S1)
                        .WithJavaVersion(JavaVersion.Java_8_Newest)
                        .WithWebContainer(WebContainer.Tomcat_8_0_Newest)
                        .WithConnectionString("storage.ConnectionString", connectionString, ConnectionStringType.Custom)
                        .WithAppSetting("storage.ContainerName", containerName)
                        .Create();

                Utilities.Log("Created web app " + app1.Name);
                Utilities.Print(app1);

                //============================================================
                // Deploy a web app that connects to the storage account
                // Source code: https://github.Com/jianghaolu/azure-samples-blob-explorer

                Utilities.Log("Deploying azure-samples-blob-traverser.war to " + app1Name + " through FTP...");

                UploadFileToFtp(app1.GetPublishingProfile(), "azure-samples-blob-traverser.war", "Asset/azure-samples-blob-traverser.war").GetAwaiter().GetResult();

                Utilities.Log("Deployment azure-samples-blob-traverser.war to web app " + app1.Name + " completed");
                Utilities.Print(app1);

                // warm up
                Utilities.Log("Warming up " + app1Url + "/azure-samples-blob-traverser...");
                CheckAddress("http://" + app1Url + "/azure-samples-blob-traverser");
                SharedSettings.DelayProvider.Delay(5000, CancellationToken.None).Wait();
                Utilities.Log("CURLing " + app1Url + "/azure-samples-blob-traverser...");
                Utilities.Log(CheckAddress("http://" + app1Url + "/azure-samples-blob-traverser"));
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.DeleteByName(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
                }
                catch (NullReferenceException)
                {
                    Utilities.Log("Did not create any resources in Azure. No clean up is necessary");
                }
                catch (Exception g)
                {
                    Utilities.Log(g);
                }
            }
        }

        public static void Main(string[] args)
        {
            try
            {
                //=================================================================
                // Authenticate
                var credentials = SharedSettings.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.BASIC)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                // Print selected subscription
                Utilities.Log("Selected subscription: " + azure.SubscriptionId);

                RunSample(azure);
            }
            catch (Exception e)
            {
                Utilities.Log(e);
            }
        }

        private static HttpResponseMessage CheckAddress(string url)
        {
            using (var client = new HttpClient())
            {
                return client.GetAsync(url).Result;
            }
        }

        public static async Task UploadFileToFtp(IPublishingProfile profile, string fileName, string filePath)
        {
            string host = profile.FtpUrl.Split(new char[] { '/' }, 2)[0];

            using (var ftpClient = new FtpClient(new FtpClientConfiguration
            {
                Host = host,
                Username = profile.FtpUsername,
                Password = profile.FtpPassword
            }))
            {
                var fileinfo = new FileInfo(filePath);
                await ftpClient.LoginAsync();
                await ftpClient.ChangeWorkingDirectoryAsync("./site/wwwroot/webapps");

                using (var writeStream = await ftpClient.OpenFileWriteStreamAsync(fileName))
                {
                    var fileReadStream = fileinfo.OpenRead();
                    await fileReadStream.CopyToAsync(writeStream);
                }
            }
        }

        private static async Task<CloudBlobContainer> SetUpStorageAccount(string connectionString, string containerName)
        {
            var storageAccount = CreateStorageAccountFromConnectionString(connectionString);

            // Create a blob client for interacting with the blob service.
            var blobClient = storageAccount.CreateCloudBlobClient();

            // Create a container for organizing blobs within the storage account.
            Utilities.Log("1. Creating Container");
            var container = blobClient.GetContainerReference(containerName);
            await container.CreateIfNotExistsAsync();

            var containerPermissions = new BlobContainerPermissions();
            // Include public access in the permissions object
            containerPermissions.PublicAccess = BlobContainerPublicAccessType.Container;
            // Set the permissions on the container
            await container.SetPermissionsAsync(containerPermissions);
            return container;
        }

        private static async Task UploadFileToContainer(CloudBlobContainer container, string fileName, string filePath)
        {
            var blob = container.GetBlockBlobReference(fileName);
            await blob.UploadFromFileAsync(filePath);
        }

        private static CloudStorageAccount CreateStorageAccountFromConnectionString(string storageConnectionString)
        {
            CloudStorageAccount storageAccount;
            try
            {
                storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            }
            catch (FormatException)
            {
                Utilities.Log("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the sample.");
                Utilities.ReadLine();
                throw;
            }
            catch (ArgumentException)
            {
                Utilities.Log("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the sample.");
                Utilities.ReadLine();
                throw;
            }

            return storageAccount;
        }

    }
}