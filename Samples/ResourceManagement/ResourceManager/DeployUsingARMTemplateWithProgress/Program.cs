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

namespace DeployUsingARMTemplateWithProgress
{
    public class Program
    {
        /**
         * Azure Resource sample for deploying resources using an ARM template and
         * showing progress.
         */
        public static void RunSample(IAzure azure)
        {
            string rgName = SharedSettings.RandomResourceName("rgRSAP", 24);
            string deploymentName = SharedSettings.RandomResourceName("dpRSAP", 24);

            try
            {
                var templateJson = GetTemplate();

                //=============================================================
                // Create resource group.

                Utilities.Log("Creating a resource group with name: " + rgName);

                azure.ResourceGroups.Define(rgName)
                        .WithRegion(Region.US_WEST)
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
                        .BeginCreate();

                Utilities.Log("Started a deployment for an Azure App Service: " + deploymentName);

                var deployment = azure.Deployments.GetByGroup(rgName, deploymentName);
                Utilities.Log("Current deployment status : " + deployment.ProvisioningState);

                while (!(StringComparer.OrdinalIgnoreCase.Equals(deployment.ProvisioningState, "Succeeded") || 
                        StringComparer.OrdinalIgnoreCase.Equals(deployment.ProvisioningState, "Failed") || 
                        StringComparer.OrdinalIgnoreCase.Equals(deployment.ProvisioningState, "Cancelled")))
                {
                    SharedSettings.DelayProvider.Delay(10000, CancellationToken.None).Wait();
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
                var credentials = SharedSettings.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

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
            var hostingPlanName = SharedSettings.RandomResourceName("hpRSAT", 24);
            var webAppName = SharedSettings.RandomResourceName("wnRSAT", 24);
            var armTemplateString = System.IO.File.ReadAllText(@".\ARMTemplate\TemplateValue.json");

            var parsedTemplate = JObject.Parse(armTemplateString);
            parsedTemplate.SelectToken("parameters.hostingPlanName")["defaultValue"] = hostingPlanName;
            parsedTemplate.SelectToken("parameters.webSiteName")["defaultValue"] = webAppName;
            parsedTemplate.SelectToken("parameters.skuName")["defaultValue"] = "F1";
            parsedTemplate.SelectToken("parameters.skuCapacity")["defaultValue"] = 1;

            return parsedTemplate.ToString();
        }
    }
}