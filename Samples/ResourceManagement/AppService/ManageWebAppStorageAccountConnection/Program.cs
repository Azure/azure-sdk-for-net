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
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Linq;
using Microsoft.Azure.Management.AppService.Fluent.Models;

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
        private static readonly string suffix = ".Azurewebsites.Net";
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

                    string connectionString = String.Format("DefaultEndpointsProtocol=https;AccountName=%s;AccountKey=%s",
                            storageAccount.Name, accountKey);

                    Console.WriteLine("Created storage account " + storageAccount.Name);

                    //============================================================
                    // Upload a few files to the storage account blobs

                    Console.WriteLine("Uploading 2 blobs to container " + containerName + "...");

                    //var container = SetUpStorageAccount(connectionString, containerName);
                    //UploadFileToContainer(container, "helloworld.War", ManageWebAppStorageAccountConnection.Class.GetResource("/helloworld.War").GetPath());
                    //UploadFileToContainer(container, "install_apache.Sh", ManageWebAppStorageAccountConnection.Class.GetResource("/install_apache.Sh").GetPath());

                    //Console.WriteLine("Uploaded 2 blobs to container " + container.GetName());

                    //============================================================
                    // Create a web app with a new app service plan

                    Console.WriteLine("Creating web app " + app1Name + "...");

                    var app1 = azure.WebApps
                            .Define(app1Name)
                            .WithExistingResourceGroup(rgName)
                            .WithNewAppServicePlan(planName)
                            .WithRegion(Region.US_WEST)
                            .WithPricingTier(AppServicePricingTier.STANDARD_S1)
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

                    Console.WriteLine("Deploying azure-samples-blob-traverser.War to " + app1Name + " through FTP...");

                    //UploadFileToFtp(app1.GetPublishingProfile(), "azure-samples-blob-traverser.War", ManageWebAppStorageAccountConnection.Class.GetResourceAsStream("/azure-samples-blob-traverser.War"));

                    Console.WriteLine("Deployment azure-samples-blob-traverser.War to web app " + app1.Name + " completed");
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

        //private static void UploadFileToFtp(IPublishingProfile profile, string fileName, InputStream file)
        //{
            //var ftpClient = new FTPClient();
            //var ftpUrlSegments = profile.FtpUrl().Split("/", 2);
            //var server = ftpUrlSegments[0];
            //var path = "./site/wwwroot/webapps";
            //ftpClient.Connect(server);
            //ftpClient.Login(profile.FtpUsername(), profile.FtpPassword());
            //ftpClient.SetFileType(FTP.BINARY_FILE_TYPE);
            //ftpClient.ChangeWorkingDirectory(path);
            //ftpClient.StoreFile(fileName, file);
            //ftpClient.Disconnect();
        //}

        //private static CloudBlobContainer SetUpStorageAccount(string connectionString, string containerName)
        //{
            //try
            //{
            //    var account = CloudStorageAccount.Parse(connectionString);
            //    // Create a blob service client
            //    var blobClient = account.CreateCloudBlobClient();
            //    var container = blobClient.GetContainerReference(containerName);
            //    container.CreateIfNotExists();
            //    var containerPermissions = new BlobContainerPermissions();
            //    // Include public access in the permissions object
            //    containerPermissions.SetPublicAccess(BlobContainerPublicAccessType.CONTAINER);
            //    // Set the permissions on the container
            //    container.UploadPermissions(containerPermissions);
            //    return container;
            //}
            //catch (StorageException)
            //{
            //}
            //catch (URISyntaxException)
            //{
            //}
            //catch (InvalidKeyException e)
            //{
            //    throw new RuntimeException(e);
            //}
        //}

        //private static void UploadFileToContainer(CloudBlobContainer container, string fileName, string filePath)
        //{
            //try
            //{
            //    var blob = container.GetBlockBlobReference(fileName);
            //    blob.UploadFromFile(filePath);
            //}
            //catch (StorageException)
            //{
            //}
            //catch (URISyntaxException)
            //{
            //}
            //catch (IOException e)
            //{
            //    throw new RuntimeException(e);
            //}
        //}
    }
}