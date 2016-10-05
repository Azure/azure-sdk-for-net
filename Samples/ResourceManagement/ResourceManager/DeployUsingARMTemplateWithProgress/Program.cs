// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Fluent.Resource;
using Microsoft.Azure.Management.Fluent.Resource.Authentication;
using Microsoft.Azure.Management.Fluent.Resource.Core;
using Microsoft.Azure.Management.ResourceManager.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Threading;

namespace DeployUsingARMTemplateWithProgress
{
    /**
     * Azure Resource sample for deploying resources using an ARM template and
     * showing progress.
     */

    public class Program
    {
        private static readonly string rgName = ResourceNamer.RandomResourceName("rgRSAP", 24);
        private static readonly string deploymentName = ResourceNamer.RandomResourceName("dpRSAP", 24);

        public static void Main(string[] args)
        {
            try
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
                    try
                    {
                        var templateJson = GetTemplate();

                        //=============================================================
                        // Create resource group.

                        Console.WriteLine("Creating a resource group with name: " + rgName);

                        azure.ResourceGroups.Define(rgName)
                                .WithRegion(Region.US_WEST)
                                .Create();

                        Console.WriteLine("Created a resource group with name: " + rgName);

                        //=============================================================
                        // Create a deployment for an Azure App Service via an ARM
                        // template.

                        Console.WriteLine("Starting a deployment for an Azure App Service: " + deploymentName);

                        azure.Deployments.Define(deploymentName)
                                .WithExistingResourceGroup(rgName)
                                .WithTemplate(templateJson)
                                .WithParameters("{}")
                                .WithMode(DeploymentMode.Incremental)
                                .BeginCreate();

                        Console.WriteLine("Started a deployment for an Azure App Service: " + deploymentName);

                        var deployment = azure.Deployments.GetByGroup(rgName, deploymentName);
                        Console.WriteLine("Current deployment status : " + deployment.ProvisioningState);

                        while (!(StringComparer.OrdinalIgnoreCase.Equals(deployment.ProvisioningState, "Succeeded")
                                || StringComparer.OrdinalIgnoreCase.Equals(deployment.ProvisioningState, "Failed")
                                || StringComparer.OrdinalIgnoreCase.Equals(deployment.ProvisioningState, "Cancelled")))
                        {
                            Thread.Sleep(10000);
                            deployment = azure.Deployments.GetByGroup(rgName, deploymentName);
                            Console.WriteLine("Current deployment status : " + deployment.ProvisioningState);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    finally
                    {
                        try
                        {
                            Console.WriteLine("Deleting Resource Group: " + rgName);
                            azure.ResourceGroups.Delete(rgName);
                            Console.WriteLine("Deleted Resource Group: " + rgName);
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Did not create any resources in Azure. No clean up is necessary");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static string GetTemplate()
        {
            var hostingPlanName = ResourceNamer.RandomResourceName("hpRSAT", 24);
            var webAppName = ResourceNamer.RandomResourceName("wnRSAT", 24);
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