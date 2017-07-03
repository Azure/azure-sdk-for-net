// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Docker.DotNet;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.ContainerRegistry.Fluent;
using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.IO;

namespace ManageLinuxWebAppWithContainerRegistry
{
    public class Program
    {
        /**
         * Azure App Service sample for deploying from an Azure Container Registry.
         *    - Create an Azure Container Registry to be used for holding the Docker images
         *    - If a local Docker engine cannot be found, create a Linux virtual machine that will host a Docker engine
         *        to be used for this sample
         *    - Use Docker Java to create a Docker client that will push/pull an image to/from Azure Container Registry
         *    - Pull a test image from the public Docker repo (tomcat:8-jre8) to be used as a sample for pushing/pulling
         *        to/from an Azure Container Registry
         *    - Deploys to a new web app from the Tomcat image
         */

        public static void RunSample(IAzure azure)
        {
            string rgName = SdkContext.RandomResourceName("rgACR", 15);
            string acrName = SdkContext.RandomResourceName("acrsample", 20);
            string saName = SdkContext.RandomResourceName("sa", 20);
            string appName = SdkContext.RandomResourceName("webapp", 20);
            string appUrl = appName + ".azurewebsites.net";
            Region region = Region.USWest;
            string dockerImageName = "tomcat";
            string dockerImageTag = "8-jre8";
            string dockerContainerName = "tomcat-privates";

            try
            {
                //=============================================================
                // Create an Azure Container Registry to store and manage private Docker container images

                Utilities.Log("Creating an Azure Container Registry");

                IRegistry azureRegistry = azure.ContainerRegistries.Define(acrName)
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .WithNewStorageAccount(saName)
                        .WithRegistryNameAsAdminUser()
                        .Create();

                Utilities.Print(azureRegistry);

                var acrCredentials = azureRegistry.ListCredentials();

                //=============================================================
                // Create a Docker client that will be used to push/pull images to/from the Azure Container Registry

                using (DockerClient dockerClient = DockerUtils.CreateDockerClient(azure, rgName, region))
                {
                    var pullImgResult = dockerClient.Images.PullImage(
                        new Docker.DotNet.Models.ImagesPullParameters()
                        {
                            Parent = dockerImageName,
                            Tag = dockerImageTag
                        },
                        new Docker.DotNet.Models.AuthConfig());

                    Utilities.Log("List Docker images for: " + dockerClient.Configuration.EndpointBaseUri.AbsoluteUri);
                    var listImages = dockerClient.Images.ListImages(
                        new Docker.DotNet.Models.ImagesListParameters()
                        {
                            All = true
                        });
                    foreach (var img in listImages)
                    {
                        Utilities.Log("\tFound image " + img.RepoTags[0] + " (id:" + img.ID + ")");
                    }

                    var createContainerResult = dockerClient.Containers.CreateContainer(
                        new Docker.DotNet.Models.CreateContainerParameters()
                        {
                            Name = dockerContainerName,
                            Image = dockerImageName + ":" + dockerImageTag
                        });
                    Utilities.Log("List Docker containers for: " + dockerClient.Configuration.EndpointBaseUri.AbsoluteUri);
                    var listContainers = dockerClient.Containers.ListContainers(
                        new Docker.DotNet.Models.ContainersListParameters()
                        {
                            All = true
                        });
                    foreach (var container in listContainers)
                    {
                        Utilities.Log("\tFound container " + container.Names[0] + " (id:" + container.ID + ")");
                    }

                    //=============================================================
                    // Commit the new container

                    string privateRepoUrl = azureRegistry.LoginServerUrl + "/samples/" + dockerContainerName;
                    Utilities.Log("Commiting image at: " + privateRepoUrl);

                    var commitContainerResult = dockerClient.Miscellaneous.CommitContainerChanges(
                        new Docker.DotNet.Models.CommitContainerChangesParameters()
                        {
                            ContainerID = dockerContainerName,
                            RepositoryName = privateRepoUrl,
                            Tag = "latest"
                        });

                    //=============================================================
                    // Push the new Docker image to the Azure Container Registry

                    var pushImageResult = dockerClient.Images.PushImage(privateRepoUrl,
                        new Docker.DotNet.Models.ImagePushParameters()
                        {
                            ImageID = privateRepoUrl,
                            Tag = "latest"
                        },
                        new Docker.DotNet.Models.AuthConfig()
                        {
                            Username = acrCredentials.Username,
                            Password = acrCredentials.Passwords[0].Value,
                            ServerAddress = azureRegistry.LoginServerUrl
                        });

                    //============================================================
                    // Create a web app with a new app service plan

                    Utilities.Log("Creating web app " + appName + " in resource group " + rgName + "...");

                    IWebApp app = azure.WebApps.Define(appName)
                            .WithRegion(Region.USWest)
                            .WithExistingResourceGroup(rgName)
                            .WithNewLinuxPlan(PricingTier.StandardS1)
                            .WithPrivateRegistryImage(privateRepoUrl + ":latest", "http://" + azureRegistry.LoginServerUrl)
                            .WithCredentials(acrCredentials.Username, acrCredentials.Passwords[0].Value)
                            .WithAppSetting("PORT", "8080")
                            .Create();

                    Utilities.Log("Created web app " + app.Name);
                    Utilities.Print(app);

                    // warm up
                    Utilities.Log("Warming up " + appUrl + "...");
                    Utilities.CheckAddress("http://" + appUrl);
                    SdkContext.DelayProvider.Delay(5000);
                    Utilities.Log("CURLing " + appUrl + "...");
                    Utilities.Log(Utilities.CheckAddress("http://" + appUrl));

                }
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.BeginDeleteByName(rgName);
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