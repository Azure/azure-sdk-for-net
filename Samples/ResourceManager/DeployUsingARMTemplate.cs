// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
using Microsoft.Azure.Management.Samples.Common;
using Newtonsoft.Json.Linq;
using System;

namespace DeployUsingARMTemplate
{
    public class Program
    {
        /**
         * Azure Resource sample for deploying resources using an ARM template.
         */
        public static void RunSample(IAzure azure)
        {
            var rgName = SdkContext.RandomResourceName("rgRSAT", 24);
            var deploymentName = SdkContext.RandomResourceName("dpRSAT", 24);

            try
            {
                var templateJson = Utilities.GetArmTemplate("ArmTemplate.json");

                //=============================================================
                // Create resource group.

                Utilities.Log("Creating a resource group with name: " + rgName);

                azure.ResourceGroups.Define(rgName)
                    .WithRegion(Region.USWest)
                    .Create();

                Utilities.Log("Created a resource group with name: " + rgName);

                //=============================================================
                // Create a deployment for an Azure App Service via an ARM
                // template.

                Utilities.Log("Starting a deployment for an Azure App Service: " + deploymentName);

                azure.Deployments.Define(deploymentName)
                    .WithExistingResourceGroup(rgName)
                    .WithTemplate(templateJson)
                    .WithParameters("{}")
                    .WithMode(DeploymentMode.Incremental)
                    .Create();

                Utilities.Log("Completed the deployment: " + deploymentName);
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.DeleteByName(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
                }
                catch (Exception ex)
                {
                    Utilities.Log(ex);
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

                RunSample(azure);
            }
            catch (Exception ex)
            {
                Utilities.Log(ex);
            }
        }
    }
}