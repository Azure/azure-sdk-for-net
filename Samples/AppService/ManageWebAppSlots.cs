// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Net.Http;

namespace ManageWebAppSlots
{
    public class Program
    {
        private const string Suffix = ".azurewebsites.net";
        private const string SlotName = "staging";

        /**
         * Azure App Service basic sample for managing web apps.
         *  - Create 3 web apps in 3 different regions
         *  - Deploy to all 3 web apps
         *  - For each of the web apps, create a staging slot
         *  - For each of the web apps, deploy to staging slot
         *  - For each of the web apps, auto-swap to production slot is triggered
         *  - For each of the web apps, swap back (something goes wrong)
         */
        public static void RunSample(IAzure azure)
        {
            string rgName = SdkContext.RandomResourceName("rg1NEMV_", 24);
            string app1Name = SdkContext.RandomResourceName("webapp1-", 20);
            string app2Name = SdkContext.RandomResourceName("webapp2-", 20);
            string app3Name = SdkContext.RandomResourceName("webapp3-", 20);

            try
            {
                azure.ResourceGroups.Define(rgName)
                    .WithRegion(Region.USWest)
                    .Create();

                //============================================================
                // Create 3 web apps with 3 new app service plans in different regions

                var app1 = CreateWebApp(azure, rgName, app1Name, Region.USWest);
                var app2 = CreateWebApp(azure, rgName, app2Name, Region.EuropeWest);
                var app3 = CreateWebApp(azure, rgName, app3Name, Region.AsiaEast);

                //============================================================
                // Create a deployment slot under each web app with auto swap

                var slot1 = CreateSlot(azure, SlotName, app1);
                var slot2 = CreateSlot(azure, SlotName, app2);
                var slot3 = CreateSlot(azure, SlotName, app3);

                //============================================================
                // Deploy the staging branch to the slot

                DeployToStaging(azure, slot1);
                DeployToStaging(azure, slot2);
                DeployToStaging(azure, slot3);

                // swap back
                SwapProductionBackToSlot(azure, slot1);
                SwapProductionBackToSlot(azure, slot2);
                SwapProductionBackToSlot(azure, slot3);

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
        
        private static IWebApp CreateWebApp(IAzure azure, string rgName, string appName, Region region)
        {
            var appUrl = appName + Suffix;

            Utilities.Log("Creating web app " + appName + " with master branch...");

            var app = azure.WebApps
                    .Define(appName)
                    .WithRegion(region)
                    .WithExistingResourceGroup(rgName)
                    .WithNewWindowsPlan(PricingTier.StandardS1)
                    .WithJavaVersion(JavaVersion.V8Newest)
                    .WithWebContainer(WebContainer.Tomcat8_0Newest)
                    .DefineSourceControl()
                        .WithPublicGitRepository("https://github.com/jianghaolu/azure-site-test.git")
                        .WithBranch("master")
                        .Attach()
                    .Create();

            Utilities.Log("Created web app " + app.Name);
            Utilities.Print(app);

            Utilities.Log("CURLing " + appUrl + "...");
            Utilities.Log(Utilities.CheckAddress("http://" + appUrl));
            return app;
        }

        private static IDeploymentSlot CreateSlot(IAzure azure, String slotName, IWebApp app)
        {
            Utilities.Log("Creating a slot " + slotName + " with auto swap turned on...");

            var slot = app.DeploymentSlots
                    .Define(slotName)
                    .WithConfigurationFromParent()
                    .WithAutoSwapSlotName("production")
                    .Create();

            Utilities.Log("Created slot " + slot.Name);
            Utilities.Print(slot);
            return slot;
        }

        private static void DeployToStaging(IAzure azure, IDeploymentSlot slot)
        {
            var slotUrl = slot.Parent.Name + "-" + slot.Name + Suffix;
            var appUrl = slot.Parent.Name + Suffix;
            Utilities.Log("Deploying staging branch to slot " + slot.Name + "...");

            slot.Update()
                    .DefineSourceControl()
                    .WithPublicGitRepository("https://github.com/jianghaolu/azure-site-test.git")
                    .WithBranch("staging")
                    .Attach()
                    .Apply();

            Utilities.Log("Deployed staging branch to slot " + slot.Name);

            Utilities.Log("CURLing " + slotUrl + "...");
            Utilities.Log(Utilities.CheckAddress("http://" + slotUrl));

            Utilities.Log("CURLing " + appUrl + "...");
            Utilities.Log(Utilities.CheckAddress("http://" + appUrl));
        }

        private static void SwapProductionBackToSlot(IAzure azure, IDeploymentSlot slot)
        {
            var appUrl = slot.Parent.Name + Suffix;
            Utilities.Log("Manually swap production slot back to  " + slot.Name + "...");

            slot.Swap("production");

            Utilities.Log("Swapped production slot back to " + slot.Name);

            Utilities.Log("CURLing " + appUrl + "...");
            Utilities.Log(Utilities.CheckAddress("http://" + appUrl));
        }
    }
}
