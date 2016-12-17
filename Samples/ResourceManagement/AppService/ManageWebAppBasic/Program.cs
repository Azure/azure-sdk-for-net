// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;

namespace ManageWebAppBasic
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

    public class Program
    {
        private static readonly string app1Name = ResourceNamer.RandomResourceName("webapp1-", 20);
        private static readonly string app2Name = ResourceNamer.RandomResourceName("webapp2-", 20);
        private static readonly string app3Name = ResourceNamer.RandomResourceName("webapp3-", 20);
        private static readonly string planName = ResourceNamer.RandomResourceName("jplan_", 15);
        private static readonly string rg1Name = ResourceNamer.RandomResourceName("rg1NEMV_", 24);
        private static readonly string rg2Name = ResourceNamer.RandomResourceName("rg2NEMV_", 24);

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
                    //============================================================
                    // Create a web app with a new app service plan

                    Console.WriteLine("Creating web app " + app1Name + " in resource group " + rg1Name + "...");

                    var app1 = azure.WebApps
                            .Define(app1Name)
                            .WithNewResourceGroup(rg1Name)
                            .WithNewAppServicePlan(planName)
                            .WithRegion(Region.US_WEST)
                            .WithPricingTier(AppServicePricingTier.Standard_S1)
                            .Create();

                    Console.WriteLine("Created web app " + app1.Name);
                    Utilities.Print(app1);

                    //============================================================
                    // Create a second web app with the same app service plan

                    Console.WriteLine("Creating another web app " + app2Name + " in resource group " + rg1Name + "...");
                    var plan = azure.AppServices.AppServicePlans.GetByGroup(rg1Name, planName);
                    var app2 = azure.WebApps
                            .Define(app2Name)
                            .WithExistingResourceGroup(rg1Name)
                            .WithExistingAppServicePlan(plan)
                            .Create();

                    Console.WriteLine("Created web app " + app2.Name);
                    Utilities.Print(app2);

                    //============================================================
                    // Create a third web app with the same app service plan, but
                    // in a different resource group

                    Console.WriteLine("Creating another web app " + app3Name + " in resource group " + rg2Name + "...");
                    var app3 = azure.WebApps
                            .Define(app3Name)
                            .WithNewResourceGroup(rg2Name)
                            .WithExistingAppServicePlan(plan)
                            .Create();

                    Console.WriteLine("Created web app " + app3.Name);
                    Utilities.Print(app3);

                    //============================================================
                    // stop and start app1, restart app 2
                    Console.WriteLine("Stopping web app " + app1.Name);
                    app1.Stop();
                    Console.WriteLine("Stopped web app " + app1.Name);
                    Utilities.Print(app1);
                    Console.WriteLine("Starting web app " + app1.Name);
                    app1.Start();
                    Console.WriteLine("Started web app " + app1.Name);
                    Utilities.Print(app1);
                    Console.WriteLine("Restarting web app " + app2.Name);
                    app2.Restart();
                    Console.WriteLine("Restarted web app " + app2.Name);
                    Utilities.Print(app2);

                    //============================================================
                    // Configure app 3 to have Java 8 enabled
                    Console.WriteLine("Adding Java support to web app " + app3Name + "...");
                    app3.Update()
                            .WithJavaVersion(JavaVersion.Java_8_Newest)
                            .WithWebContainer(WebContainer.Tomcat_8_0_Newest)
                            .Apply();
                    Console.WriteLine("Java supported on web app " + app3Name + "...");

                    //=============================================================
                    // List web apps

                    Console.WriteLine("Printing list of web apps in resource group " + rg1Name + "...");

                    foreach (var webApp in azure.WebApps.ListByGroup(rg1Name))
                    {
                        Utilities.Print(webApp);
                    }

                    Console.WriteLine("Printing list of web apps in resource group " + rg2Name + "...");

                    foreach (var webApp in azure.WebApps.ListByGroup(rg2Name))
                    {
                        Utilities.Print(webApp);
                    }

                    //=============================================================
                    // Delete a web app

                    Console.WriteLine("Deleting web app " + app1Name + "...");
                    azure.WebApps.DeleteByGroup(rg1Name, app1Name);
                    Console.WriteLine("Deleted web app " + app1Name + "...");

                    Console.WriteLine("Printing list of web apps in resource group " + rg1Name + " again...");
                    foreach (var webApp in azure.WebApps.ListByGroup(rg1Name))
                    {
                        Utilities.Print(webApp);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    try
                    {
                        Console.WriteLine("Deleting Resource Group: " + rg1Name);
                        azure.ResourceGroups.DeleteByName(rg1Name);
                        Console.WriteLine("Deleted Resource Group: " + rg1Name);
                        Console.WriteLine("Deleting Resource Group: " + rg2Name);
                        azure.ResourceGroups.DeleteByName(rg2Name);
                        Console.WriteLine("Deleted Resource Group: " + rg2Name);
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
    }
}