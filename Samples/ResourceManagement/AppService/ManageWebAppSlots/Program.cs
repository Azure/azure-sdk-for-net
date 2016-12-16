// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Net.Http;

namespace ManageWebAppSlots
{
    /**
     * Azure App Service basic sample for managing web apps.
     *  - Create 3 web apps in 3 different regions
     *  - Deploy to all 3 web apps
     *  - For each of the web apps, create a staging slot
     *  - For each of the web apps, deploy to staging slot
     *  - For each of the web apps, auto-swap to production slot is triggered
     *  - For each of the web apps, swap back (something goes wrong)
     */
    public class Program
    {
        private static readonly string RG_NAME = ResourceNamer.RandomResourceName("rg1NEMV_", 24);
        private static readonly string SUFFIX = ".azurewebsites.net";
        private static readonly string app1Name = ResourceNamer.RandomResourceName("webapp1-", 20);
        private static readonly string app2Name = ResourceNamer.RandomResourceName("webapp2-", 20);
        private static readonly string app3Name = ResourceNamer.RandomResourceName("webapp3-", 20);
        private static readonly string slotName = "staging";

        public static void Main(string[] args)
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

                // Print selected subscription
                Console.WriteLine("Selected subscription: " + azure.SubscriptionId);
                try
                {
                    azure.ResourceGroups.Define(RG_NAME)
                        .WithRegion(Region.US_WEST)
                        .Create();

                    //============================================================
                    // Create 3 web apps with 3 new app service plans in different regions

                    var app1 = CreateWebApp(azure, app1Name, Region.US_WEST);
                    var app2 = CreateWebApp(azure, app2Name, Region.EUROPE_WEST);
                    var app3 = CreateWebApp(azure, app3Name, Region.ASIA_EAST);


                    //============================================================
                    // Create a deployment slot under each web app with auto swap

                    var slot1 = CreateSlot(azure, slotName, app1);
                    var slot2 = CreateSlot(azure, slotName, app2);
                    var slot3 = CreateSlot(azure, slotName, app3);

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
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    try
                    {
                        Console.WriteLine("Deleting Resource Group: " + RG_NAME);
                        azure.ResourceGroups.DeleteByName(RG_NAME);
                        Console.WriteLine("Deleted Resource Group: " + RG_NAME);
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("Did not create any resources in Azure. No clean up is necessary");
                    }
                    catch (Exception g)
                    {
                        Console.WriteLine(g);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static IWebApp CreateWebApp(IAzure azure, string appName, Region region)
        {
            var planName = ResourceNamer.RandomResourceName("jplan_", 15);
            var appUrl = appName + SUFFIX;

            Console.WriteLine("Creating web app " + appName + " with master branch...");

            var app = azure.WebApps
                    .Define(appName)
                    .WithExistingResourceGroup(RG_NAME)
                    .WithNewAppServicePlan(planName)
                    .WithRegion(region)
                    .WithPricingTier(AppServicePricingTier.Standard_S1)
                    .WithJavaVersion(JavaVersion.Java_8_Newest)
                    .WithWebContainer(WebContainer.Tomcat_8_0_Newest)
                    .DefineSourceControl()
                        .WithPublicGitRepository("https://github.com/jianghaolu/azure-site-test.git")
                        .WithBranch("master")
                        .Attach()
                    .Create();

            Console.WriteLine("Created web app " + app.Name);
            Utilities.Print(app);

            Console.WriteLine("CURLing " + appUrl + "...");
            Console.WriteLine(CheckAddress("http://" + appUrl));
            return app;
        }

        private static IDeploymentSlot CreateSlot(IAzure azure, String slotName, IWebApp app)
        {
            Console.WriteLine("Creating a slot " + slotName + " with auto swap turned on...");

            var slot = app.DeploymentSlots
                    .Define(slotName)
                    .WithConfigurationFromParent()
                    .WithAutoSwapSlotName("production")
                    .Create();

            Console.WriteLine("Created slot " + slot.Name);
            Utilities.Print(slot);
            return slot;
        }

        private static void DeployToStaging(IAzure azure, IDeploymentSlot slot)
        {
            var slotUrl = slot.Parent.Name + "-" + slot.Name + SUFFIX;
            var appUrl = slot.Parent.Name + SUFFIX;
            Console.WriteLine("Deploying staging branch to slot " + slot.Name + "...");

            slot.Update()
                    .DefineSourceControl()
                    .WithPublicGitRepository("https://github.com/jianghaolu/azure-site-test.git")
                    .WithBranch("staging")
                    .Attach()
                    .Apply();

            Console.WriteLine("Deployed staging branch to slot " + slot.Name);

            Console.WriteLine("CURLing " + slotUrl + "...");
            Console.WriteLine(CheckAddress("http://" + slotUrl));

            Console.WriteLine("CURLing " + appUrl + "...");
            Console.WriteLine(CheckAddress("http://" + appUrl));
        }

        private static void SwapProductionBackToSlot(IAzure azure, IDeploymentSlot slot)
        {
            var appUrl = slot.Parent.Name + SUFFIX;
            Console.WriteLine("Manually swap production slot back to  " + slot.Name + "...");

            slot.Swap("production");

            Console.WriteLine("Swapped production slot back to " + slot.Name);

            Console.WriteLine("CURLing " + appUrl + "...");
            Console.WriteLine(CheckAddress("http://" + appUrl));
        }

        private static HttpResponseMessage CheckAddress(string url)
        {
            using (var client = new HttpClient())
            {
                return client.GetAsync(url).Result;
            }
        }
    }
}
