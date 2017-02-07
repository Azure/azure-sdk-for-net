// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Resource.Fluent.Models;
using Microsoft.Azure.Management.Samples.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Threading;

namespace DeployVirtualMachineUsingARMTemplate
{
    public class Program
    {
        /**
         * Azure Resource sample for deploying virtual machine with managed disk using an ARM template.
         */
        public static void RunSample(IAzure azure)
        {
            string rgName = SdkContext.RandomResourceName("rgRSAT", 24);
            string deploymentName = SdkContext.RandomResourceName("dpRSAT", 24);

            try
            {
                var templateJson = GetTemplate();

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

                Utilities.Log("Starting a deployment for an Azure Virtual Machine with managed disks: " + deploymentName);

                azure.Deployments.Define(deploymentName)
                        .WithExistingResourceGroup(rgName)
                        .WithTemplate(templateJson)
                        .WithParameters("{}")
                        .WithMode(DeploymentMode.Incremental)
                        .BeginCreate();

                Utilities.Log("Started a deployment for an Azure Virtual Machine with managed disks: " + deploymentName);

                var deployment = azure.Deployments.GetByGroup(rgName, deploymentName);
                Utilities.Log("Current deployment status : " + deployment.ProvisioningState);

                while (!(StringComparer.OrdinalIgnoreCase.Equals(deployment.ProvisioningState, "Succeeded") ||
                        StringComparer.OrdinalIgnoreCase.Equals(deployment.ProvisioningState, "Failed") ||
                        StringComparer.OrdinalIgnoreCase.Equals(deployment.ProvisioningState, "Cancelled")))
                {
                    SdkContext.DelayProvider.Delay(10000, CancellationToken.None).Wait();
                    deployment = azure.Deployments.GetByGroup(rgName, deploymentName);
                    Utilities.Log("Current deployment status : " + deployment.ProvisioningState);
                }
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
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.BASIC)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                RunSample(azure);
            }
            catch (Exception ex)
            {
                Utilities.Log(ex);
            }
        }

        private static string GetTemplate()
        {
            var adminUsername = "tirekicker";
            var adminPassword = "12NewPA$$w0rd!";
            var armTemplateString = System.IO.File.ReadAllText(@".\ARMTemplate\TemplateValue.json");

            var parsedTemplate = JObject.Parse(armTemplateString);
            parsedTemplate.SelectToken("parameters.adminUsername")["defaultValue"] = adminUsername;
            parsedTemplate.SelectToken("parameters.adminPassword")["defaultValue"] = adminPassword;

            return parsedTemplate.ToString();
        }
    }
}
