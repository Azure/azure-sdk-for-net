// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using CoreFtp;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.AppService.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
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
            string App1Name = SdkContext.RandomResourceName("webapp1-", 20);
            string App1Url = App1Name + SUFFIX;
            string StorageName = SdkContext.RandomResourceName("jsdkstore", 20);
            string ContainerName = SdkContext.RandomResourceName("jcontainer", 20);
            string ResourceGroupName = SdkContext.RandomResourceName("rg1NEMV_", 24);

            try
            {
                //============================================================
                // Create a storage account for the web app to use

                Utilities.Log("Creating storage account " + StorageName + "...");

                var storageAccount = azure.StorageAccounts
                        .Define(StorageName)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(ResourceGroupName)
                        .Create();

                var accountKey = storageAccount.GetKeys().FirstOrDefault().Value;

                var connectionString = $"DefaultEndpointsProtocol=https;AccountName={storageAccount.Name};AccountKey={accountKey}";

                Utilities.Log("Created storage account " + storageAccount.Name);

                //============================================================
                // Upload a few files to the storage account blobs

                Utilities.Log("Uploading 2 blobs to container " + ContainerName + "...");
                
                Utilities.UploadFilesToContainer(
                    connectionString, 
                    ContainerName, 
                    new[] 
                    {
                        Path.Combine(Utilities.ProjectPath, "Asset", "helloworld.war"),
                        Path.Combine(Utilities.ProjectPath, "Asset", "install_apache.Sh")
                    });

                Utilities.Log("Uploaded 2 blobs to container " + ContainerName);

                //============================================================
                // Create a web app with a new app service plan

                Utilities.Log("Creating web app " + App1Name + "...");

                var app1 = azure.WebApps
                        .Define(App1Name)
                        .WithRegion(Region.USWest)
                        .WithExistingResourceGroup(ResourceGroupName)
                        .WithNewWindowsPlan(PricingTier.StandardS1)
                        .WithJavaVersion(JavaVersion.V8Newest)
                        .WithWebContainer(WebContainer.Tomcat8_0Newest)
                        .WithConnectionString("storage.ConnectionString", connectionString, ConnectionStringType.Custom)
                        .WithAppSetting("storage.ContainerName", ContainerName)
                        .Create();

                Utilities.Log("Created web app " + app1.Name);
                Utilities.Print(app1);

                //============================================================
                // Deploy a web app that connects to the storage account
                // Source code: https://github.Com/jianghaolu/azure-samples-blob-explorer

                Utilities.Log("Deploying azure-samples-blob-traverser.war to " + App1Name + " through FTP...");

                Utilities.UploadFileToWebApp(
                    app1.GetPublishingProfile(),
                    Path.Combine(Utilities.ProjectPath, "Asset", "azure-samples-blob-traverser.war"));

                Utilities.Log("Deployment azure-samples-blob-traverser.war to web app " + app1.Name + " completed");
                Utilities.Print(app1);

                // warm up
                Utilities.Log("Warming up " + App1Url + "/azure-samples-blob-traverser...");
                Utilities.CheckAddress("http://" + App1Url + "/azure-samples-blob-traverser");
                SdkContext.DelayProvider.Delay(5000);
                Utilities.Log("CURLing " + App1Url + "/azure-samples-blob-traverser...");
                Utilities.Log(Utilities.CheckAddress("http://" + App1Url + "/azure-samples-blob-traverser"));
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + ResourceGroupName);
                    azure.ResourceGroups.DeleteByName(ResourceGroupName);
                    Utilities.Log("Deleted Resource Group: " + ResourceGroupName);
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
                var credentials = SdkContext.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
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
    }
}