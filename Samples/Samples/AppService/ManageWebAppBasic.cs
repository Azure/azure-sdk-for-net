// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;

namespace ManageWebAppBasic
{
    public class Program
    {
        /**
         * Azure App Service basic sample for managing web apps.
         *  - Create 3 web apps under the same new app service plan:
         *    - 1, 2 are in the same resource group, 3 in a different one
         *    - Stop and start 1, restart 2
         *    - Add Java support to app 3
         *  - List web apps
         *  - Delete a web app
         */

        public static void RunSample(IAzure azure)
        {
            string app1Name = SdkContext.RandomResourceName("webapp1-", 20);
            string app2Name = SdkContext.RandomResourceName("webapp2-", 20);
            string app3Name = SdkContext.RandomResourceName("webapp3-", 20);
            string rg1Name = SdkContext.RandomResourceName("rg1NEMV_", 24);
            string rg2Name = SdkContext.RandomResourceName("rg2NEMV_", 24);

            try
            {
                //============================================================
                // Create a web app with a new app service plan

                Utilities.Log("Creating web app " + app1Name + " in resource group " + rg1Name + "...");

                var app1 = azure.WebApps
                        .Define(app1Name)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(rg1Name)
                        .WithNewWindowsPlan(PricingTier.StandardS1)
                        .Create();

                Utilities.Log("Created web app " + app1.Name);
                Utilities.Print(app1);

                //============================================================
                // Create a second web app with the same app service plan

                Utilities.Log("Creating another web app " + app2Name + " in resource group " + rg1Name + "...");
                var plan = azure.AppServices.AppServicePlans.GetById(app1.AppServicePlanId);
                var app2 = azure.WebApps
                        .Define(app2Name)
                        .WithExistingWindowsPlan(plan)
                        .WithExistingResourceGroup(rg1Name)
                        .Create();

                Utilities.Log("Created web app " + app2.Name);
                Utilities.Print(app2);

                //============================================================
                // Create a third web app with the same app service plan, but
                // in a different resource group

                Utilities.Log("Creating another web app " + app3Name + " in resource group " + rg2Name + "...");
                var app3 = azure.WebApps
                        .Define(app3Name)
                        .WithExistingWindowsPlan(plan)
                        .WithNewResourceGroup(rg2Name)
                        .Create();

                Utilities.Log("Created web app " + app3.Name);
                Utilities.Print(app3);

                //============================================================
                // stop and start app1, restart app 2
                Utilities.Log("Stopping web app " + app1.Name);
                app1.Stop();
                Utilities.Log("Stopped web app " + app1.Name);
                Utilities.Print(app1);
                Utilities.Log("Starting web app " + app1.Name);
                app1.Start();
                Utilities.Log("Started web app " + app1.Name);
                Utilities.Print(app1);
                Utilities.Log("Restarting web app " + app2.Name);
                app2.Restart();
                Utilities.Log("Restarted web app " + app2.Name);
                Utilities.Print(app2);

                //============================================================
                // Configure app 3 to have Java 8 enabled
                Utilities.Log("Adding Java support to web app " + app3Name + "...");
                app3.Update()
                        .WithJavaVersion(JavaVersion.V8Newest)
                        .WithWebContainer(WebContainer.Tomcat8_0Newest)
                        .Apply();
                Utilities.Log("Java supported on web app " + app3Name + "...");

                //=============================================================
                // List web apps

                Utilities.Log("Printing list of web apps in resource group " + rg1Name + "...");

                foreach (var webApp in azure.WebApps.ListByResourceGroup(rg1Name))
                {
                    Utilities.Print(webApp);
                }

                Utilities.Log("Printing list of web apps in resource group " + rg2Name + "...");

                foreach (var webApp in azure.WebApps.ListByResourceGroup(rg2Name))
                {
                    Utilities.Print(webApp);
                }

                //=============================================================
                // Delete a web app

                Utilities.Log("Deleting web app " + app1Name + "...");
                azure.WebApps.DeleteByResourceGroup(rg1Name, app1Name);
                Utilities.Log("Deleted web app " + app1Name + "...");

                Utilities.Log("Printing list of web apps in resource group " + rg1Name + " again...");
                foreach (var webApp in azure.WebApps.ListByResourceGroup(rg1Name))
                {
                    Utilities.Print(webApp);
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