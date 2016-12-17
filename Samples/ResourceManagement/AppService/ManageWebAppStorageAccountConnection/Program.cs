// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System.Linq;
using Microsoft.Azure.Management.AppService.Fluent.Models;
using System.Threading.Tasks;
using CoreFtp;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace ManageWebAppStorageAccountConnection
{
    /**
     * Azure App Service basic sample for managing web apps.
     *  - Create a storage account and upload a couple blobs
     *  - Create a web app that contains the connection string to the storage account
     *  - Deploy a Tomcat application that reads from the storage account
     *  - Clean up
     */

    public class Program
    {
        private static readonly string suffix = ".azurewebsites.net";
        private static readonly string app1Name = ResourceNamer.RandomResourceName("webapp1-", 20);
        private static readonly string app1Url = app1Name + suffix;
        private static readonly string storageName = ResourceNamer.RandomResourceName("jsdkstore", 20);
        private static readonly string containerName = ResourceNamer.RandomResourceName("jcontainer", 20);
        private static readonly string planName = ResourceNamer.RandomResourceName("jplan_", 15);
        private static readonly string rgName = ResourceNamer.RandomResourceName("rg1NEMV_", 24);

        public static void Main(string[] args)
        {
            try
            {
                //=================================================================
                // Authenticate
                var credentials = AzureCredentials.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.BASIC)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                // Print selected subscription
                Console.WriteLine("Selected subscription: " + azure.SubscriptionId);
                try
                {
                    //============================================================
                    // Create a storage account for the web app to use

                    Console.WriteLine("Creating storage account " + storageName + "...");

                    var storageAccount = azure.StorageAccounts
                            .Define(storageName)
                            .WithRegion(Region.US_WEST)
                            .WithNewResourceGroup(rgName)
                            .Create();

                    var accountKey = storageAccount.GetKeys().FirstOrDefault().Value;

                    string connectionString = String.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}",
                            storageAccount.Name, accountKey);

                    Console.WriteLine("Created storage account " + storageAccount.Name);

                    //============================================================
                    // Upload a few files to the storage account blobs

                    Console.WriteLine("Uploading 2 blobs to container " + containerName + "...");

                    var container = SetUpStorageAccount(connectionString, containerName).GetAwaiter().GetResult();
                    UploadFileToContainer(container, "helloworld.war", "Asset/helloworld.war").GetAwaiter().GetResult();
                    UploadFileToContainer(container, "install_apache.sh", "Asset/install_apache.Sh").GetAwaiter().GetResult();

                    Console.WriteLine("Uploaded 2 blobs to container " + container.Name);

                    //============================================================
                    // Create a web app with a new app service plan

                    Console.WriteLine("Creating web app " + app1Name + "...");

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

                    Console.WriteLine("Created web app " + app1.Name);
                    Utilities.Print(app1);

                    //============================================================
                    // Deploy a web app that connects to the storage account
                    // Source code: https://github.Com/jianghaolu/azure-samples-blob-explorer

                    Console.WriteLine("Deploying azure-samples-blob-traverser.war to " + app1Name + " through FTP...");

                    UploadFileToFtp(app1.GetPublishingProfile(), "azure-samples-blob-traverser.war", "Asset/azure-samples-blob-traverser.war").GetAwaiter().GetResult();

                    Console.WriteLine("Deployment azure-samples-blob-traverser.war to web app " + app1.Name + " completed");
                    Utilities.Print(app1);

                    // warm up
                    Console.WriteLine("Warming up " + app1Url + "/azure-samples-blob-traverser...");
                    CheckAddress("http://" + app1Url + "/azure-samples-blob-traverser");
                    Thread.Sleep(5000);
                    Console.WriteLine("CURLing " + app1Url + "/azure-samples-blob-traverser...");
                    Console.WriteLine(CheckAddress("http://" + app1Url + "/azure-samples-blob-traverser"));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    try
                    {
                        Console.WriteLine("Deleting Resource Group: " + rgName);
                        azure.ResourceGroups.DeleteByName(rgName);
                        Console.WriteLine("Deleted Resource Group: " + rgName);
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("Did not create any resources in Azure. No clean up is necessary");
                    }
                    catch (Exception g)
                    {
                        Console.WriteLine(g);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
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
            Console.WriteLine("1. Creating Container");
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
                Console.WriteLine("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the sample.");
                Console.ReadLine();
                throw;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the sample.");
                Console.ReadLine();
                throw;
            }

            return storageAccount;
        }

    }
}