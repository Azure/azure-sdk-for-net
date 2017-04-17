// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;

namespace ManageFunctionAppBasic
{
    public class Program
    {
        /**
         * Azure App Service basic sample for managing function apps.
         *  - Create 3 function apps under the same new app service plan:
         *    - 1, 2 are in the same resource group, 3 in a different one
         *    - 1, 3 are under the same consumption plan, 2 under a basic app service plan
         *  - List function apps
         *  - Delete a function app
         */

        public static void RunSample(IAzure azure)
        {
            // New resources
            string app1Name = SdkContext.RandomResourceName("webapp1-", 20);
            string app2Name = SdkContext.RandomResourceName("webapp2-", 20);
            string app3Name = SdkContext.RandomResourceName("webapp3-", 20);
            string rg1Name = SdkContext.RandomResourceName("rg1NEMV_", 24);
            string rg2Name = SdkContext.RandomResourceName("rg2NEMV_", 24);

            try
            {


                //============================================================
                // Create a function app with a new app service plan

                Utilities.Log("Creating function app " + app1Name + " in resource group " + rg1Name + "...");

                IFunctionApp app1 = azure.AppServices.FunctionApps
                        .Define(app1Name)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(rg1Name)
                        .Create();

                Utilities.Log("Created function app " + app1.Name);
                Utilities.Print(app1);

                //============================================================
                // Create a second function app with the same app service plan

                Utilities.Log("Creating another function app " + app2Name + " in resource group " + rg1Name + "...");
                IAppServicePlan plan = azure.AppServices.AppServicePlans.GetById(app1.AppServicePlanId);
                IFunctionApp app2 = azure.AppServices.FunctionApps
                        .Define(app2Name)
                        .WithRegion(Region.USWest)
                        .WithExistingResourceGroup(rg1Name)
                        .WithNewAppServicePlan(PricingTier.BasicB1)
                        .Create();

                Utilities.Log("Created function app " + app2.Name);
                Utilities.Print(app2);

                //============================================================
                // Create a third function app with the same app service plan, but
                // in a different resource group

                Utilities.Log("Creating another function app " + app3Name + " in resource group " + rg2Name + "...");
                IFunctionApp app3 = azure.AppServices.FunctionApps
                        .Define(app3Name)
                        .WithExistingAppServicePlan(plan)
                        .WithNewResourceGroup(rg2Name)
                        .Create();

                Utilities.Log("Created function app " + app3.Name);
                Utilities.Print(app3);

                //============================================================
                // stop and start app1, restart app 2
                Utilities.Log("Stopping function app " + app1.Name);
                app1.Stop();
                Utilities.Log("Stopped function app " + app1.Name);
                Utilities.Print(app1);
                Utilities.Log("Starting function app " + app1.Name);
                app1.Start();
                Utilities.Log("Started function app " + app1.Name);
                Utilities.Print(app1);
                Utilities.Log("Restarting function app " + app2.Name);
                app2.Restart();
                Utilities.Log("Restarted function app " + app2.Name);
                Utilities.Print(app2);

                //=============================================================
                // List function apps

                Utilities.Log("Printing list of function apps in resource group " + rg1Name + "...");

                foreach (IFunctionApp functionApp in azure.AppServices.FunctionApps.ListByResourceGroup(rg1Name))
                {
                    Utilities.Print(functionApp);
                }

                Utilities.Log("Printing list of function apps in resource group " + rg2Name + "...");

                foreach (IFunctionApp functionApp in azure.AppServices.FunctionApps.ListByResourceGroup(rg2Name))
                {
                    Utilities.Print(functionApp);
                }

                //=============================================================
                // Delete a function app

                Utilities.Log("Deleting function app " + app1Name + "...");
                azure.AppServices.FunctionApps.DeleteByResourceGroup(rg1Name, app1Name);
                Utilities.Log("Deleted function app " + app1Name + "...");

                Utilities.Log("Printing list of function apps in resource group " + rg1Name + " again...");
                foreach (IFunctionApp functionApp in azure.AppServices.FunctionApps.ListByResourceGroup(rg1Name))
                {
                    Utilities.Print(functionApp);
                }
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rg2Name);
                    azure.ResourceGroups.DeleteByName(rg2Name);
                    Utilities.Log("Deleted Resource Group: " + rg2Name);
                    Utilities.Log("Deleting Resource Group: " + rg1Name);
                    azure.ResourceGroups.DeleteByName(rg1Name);
                    Utilities.Log("Deleted Resource Group: " + rg1Name);
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