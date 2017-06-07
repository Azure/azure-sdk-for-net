// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
//using Microsoft.Azure.Management.ContainerRegistry.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;

namespace ManageContainerRegistry
{
    public class Program
    {
        private static readonly Region Region = Region.USEast2;


        /**
         * Azure Container Registry sample for managing container registry.
         *  - Create an Azure Container Registry to be used for holding the Docker images
         *  - If a local Docker engine cannot be found, create a Linux virtual machine that will host a Docker engine
         *      to be used for this sample
         *  - Use Docker Java to create a Docker client that will push/pull an image to/from Azure Container Registry
         *  - Pull a test image from the public Docker repo (hello-world:latest) to be used as a sample for pushing/pulling
         *      to/from an Azure Container Registry
         *  - Create a new Docker container from an image that was pulled from Azure Container Registry
         */
        public static void RunSample(IAzure azure)
        {
            string rgName = SdkContext.RandomResourceName("rgACR", 15);
            string acrName = SdkContext.RandomResourceName("acrsample", 20);
            string saName = SdkContext.RandomResourceName("sa", 20);
            Region region = Region.USEast2;
            String dockerImageName = "hello-world";
            String dockerImageTag = "latest";
            String dockerContainerName = "sample-hello";

            try
            {
                //=============================================================
                // Create an Azure Container Registry to store and manage private Docker container images

                Utilities.Log("Creating an Azure Container Registry");

                azure.ResourceGroups.Define(rgName)
                    .WithRegion(region)
                    .Create();

                //Registry azureRegistry = azure.containerRegistries().define(acrName)
                //        .withRegion(region)
                //        .withNewResourceGroup(rgName)
                //        .withNewStorageAccount(saName)
                //        .withRegistryNameAsAdminUser()
                //        .create();


                ////=============================================================
                //// Create a Docker client that will be used to push/pull images to/from the Azure Container Registry

                //RegistryListCredentials acrCredentials = azureRegistry.listCredentials();

            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.DeleteByName(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
                }
                catch (Exception)
                {
                    Utilities.Log("Did not create any resources in Azure. No clean up is necessary");
                }
            }
        }

        public static void Main(string[] args)
        {
            try
            {
                //=================================================================
                // Authenticate
                AzureCredentials credentials = SdkContext.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                // Print selected subscription
                Utilities.Log("Selected subscription: " + azure.SubscriptionId);

                RunSample(azure);
            }
            catch (Exception ex)
            {
                Utilities.Log(ex);
            }
        }
    }
}