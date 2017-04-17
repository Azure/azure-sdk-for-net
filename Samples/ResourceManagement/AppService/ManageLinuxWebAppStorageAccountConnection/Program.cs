// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.AppService.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.Storage.Fluent;
using System;
using System.IO;

namespace ManageLinuxWebAppStorageAccountConnection
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
            string app1Name       = SdkContext.RandomResourceName("webapp1-", 20);
            string app1Url        = app1Name + SUFFIX;
            string storageName    = SdkContext.RandomResourceName("jsdkstore", 20);
            string containerName  = SdkContext.RandomResourceName("jcontainer", 20);
            string rgName         = SdkContext.RandomResourceName("rg1NEMV_", 24);

            try {

                //============================================================
                // Create a storage account for the web app to use

                Utilities.Log("Creating storage account " + storageName + "...");

                IStorageAccount storageAccount = azure.StorageAccounts.Define(storageName)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(rgName)
                        .Create();

                string accountKey = storageAccount.GetKeys()[0].Value;

                string connectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}",
                        storageAccount.Name, accountKey);

                Utilities.Log("Created storage account " + storageAccount.Name);

                //============================================================
                // Upload a few files to the storage account blobs

                Utilities.Log("Uploading 2 blobs to container " + containerName + "...");

                Utilities.UploadFilesToContainer(
                    connectionString,
                    containerName,
                    new[]
                    {
                        Path.Combine(Utilities.ProjectPath, "Asset", "helloworld.war"),
                        Path.Combine(Utilities.ProjectPath, "Asset", "install_apache.Sh")
                    });

                Utilities.Log("Uploaded 2 blobs to container " + containerName);

                //============================================================
                // Create a web app with a new app service plan

                Utilities.Log("Creating web app " + app1Name + "...");

                IWebApp app1 = azure.WebApps.Define(app1Name)
                        .WithRegion(Region.USWest)
                        .WithExistingResourceGroup(rgName)
                        .WithNewLinuxPlan(PricingTier.StandardS1)
                        .WithPublicDockerHubImage("tomcat:8-jre8")
                        .WithStartUpCommand("/bin/bash -c \"sed -ie 's/appBase=\\\"webapps\\\"/appBase=\\\"\\\\/home\\\\/site\\\\/wwwroot\\\\/webapps\\\"/g' conf/server.xml && catalina.sh run\"")
                        .WithConnectionString("storage.connectionString", connectionString, ConnectionStringType.Custom)
                        .WithAppSetting("storage.containerName", containerName)
                        .WithAppSetting("PORT", "8080")
                        .Create();

                Utilities.Log("Created web app " + app1.Name);
                Utilities.Print(app1);

                //============================================================
                // Deploy a web app that connects to the storage account
                // Source code: https://github.com/jianghaolu/azure-samples-blob-explorer

                Utilities.Log("Deploying azure-samples-blob-traverser.war to " + app1Name + " through FTP...");

                Utilities.UploadFileToFtp(
                    app1.GetPublishingProfile(),
                    Path.Combine(Utilities.ProjectPath, "Asset", "azure-samples-blob-traverser.war"));

                Utilities.Log("Deployment azure-samples-blob-traverser.war to web app " + app1.Name + " completed");
                Utilities.Print(app1);

                // warm up
                Utilities.Log("Warming up " + app1Url + "/azure-samples-blob-traverser...");
                Utilities.CheckAddress("http://" + app1Url + "/azure-samples-blob-traverser");
                SdkContext.DelayProvider.Delay(5000);
                Utilities.Log("CURLing " + app1Url + "/azure-samples-blob-traverser...");
                Utilities.Log(Utilities.CheckAddress("http://" + app1Url + "/azure-samples-blob-traverser"));
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.BeginDeleteByName(rgName);
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