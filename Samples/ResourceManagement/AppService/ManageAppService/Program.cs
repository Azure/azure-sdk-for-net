// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.AppService.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Net.Http;

namespace ManageAppService
{
    /**
     * Azure App Service sample for managing web apps.
     *  - app service plan, web app
     *    - Create 2 web apps under the same new app service plan
     *  - domain
     *    - Create a domain
     *  - certificate
     *    - Create a Wildcard SSL certificate for the domain
     *    - update 1st web app to use the domain and a new standard SSL certificate
     *    - update 2nd web app to use the domain and the created wildcard SSL certificate
     *  - slots
     *    - create 2 slots under 2nd web app and bind to the domain and the wildcard SSL certificate
     *    - turn on auto-swap for 2nd slot
     *    - set connection strings to a storage account on production slot and make them sticky
     *  - source control
     *    - bind a simple web app in a public GitHub repo to 2nd slot and have it auto-swapped to production
     *    - Verify the web app has access to the storage account
     *  - Delete a slot
     *  - Delete a web app
     */

    public class Program
    {
        // Existing resources
        private static readonly string domainName = "jsdk79877.Com";

        private static readonly string certName = "wild2crt8b42374211";
        private static readonly string domainCertRg = "rgnemv24d683784f51d";

        // New resources
        private static readonly string app1Name = ResourceNamer.RandomResourceName("webapp1", 20);

        private static readonly string app2Name = ResourceNamer.RandomResourceName("webapp2", 20);
        private static readonly string slot1Name = ResourceNamer.RandomResourceName("slot1", 20);
        private static readonly string slot2Name = ResourceNamer.RandomResourceName("slot2", 20);
        private static readonly string planName = ResourceNamer.RandomResourceName("jplan", 15);
        private static readonly string rgName = ResourceNamer.RandomResourceName("rgNEMV", 24);

        public static void Main(string[] args)
        {
            try
            {
                //=================================================================
                // Authenticate
                AzureCredentials credentials = AzureCredentials.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

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

                    Console.WriteLine("Creating web app " + app1Name + "...");

                    var app1 = azure.WebApps
                            .Define(app1Name)
                            .WithNewResourceGroup(rgName)
                            .WithNewAppServicePlan(planName)
                            .WithRegion(Region.US_WEST)
                            .WithPricingTier(AppServicePricingTier.STANDARD_S1)
                            .Create();

                    Console.WriteLine("Created web app " + app1.Name);
                    Utilities.Print(app1);

                    //============================================================
                    // Create a second web app with the same app service plan

                    Console.WriteLine("Creating another web app " + app2Name + "...");
                    var plan = azure.AppServices.AppServicePlans.GetByGroup(rgName, planName);
                    var app2 = azure.WebApps
                            .Define(app2Name)
                            .WithExistingResourceGroup(rgName)
                            .WithExistingAppServicePlan(plan)
                            .Create();

                    Console.WriteLine("Created web app " + app2.Name);
                    Utilities.Print(app2);

                    //============================================================
                    // Purchase a domain (will be canceled for a full refund)

                    Console.WriteLine("Purchasing a domain " + domainName + "...");

                    var domain = azure.AppServices.AppServiceDomains
                            .GetByGroup(domainCertRg, domainName);

                    Console.WriteLine("Purchased domain " + domain.Name);
                    Utilities.Print(domain);

                    //============================================================
                    // Bind domain to web app 1

                    Console.WriteLine("Binding http://" + app1Name + "." + domainName + " to web app " + app1Name + "...");

                    app1 = app1.Update()
                            .DefineHostnameBinding
                                .WithAzureManagedDomain(domain)
                                .WithSubDomain(app1Name)
                                .WithDnsRecordType(CustomHostNameDnsRecordType.CName)
                                .Attach()
                            .Apply();

                    Console.WriteLine("Finish binding http://" + app1Name + "." + domainName + " to web app " + app1Name + "...");
                    Utilities.Print(app1);

                    Console.WriteLine("CURLing http://" + app1Name + "." + domainName);
                    Console.WriteLine(CheckAddress("http://" + app1Name + "." + domainName));

                    //============================================================
                    // Purchase a wild card SSL certificate (will be canceled for a full refund)

                    var certificateOrder = azure.AppServices.AppServiceCertificateOrders
                            .GetByGroup(domainCertRg, certName);

                    Utilities.Print(certificateOrder);

                    //============================================================
                    // Bind domain to web app 2 and turn on wild card SSL

                    Console.WriteLine("Binding https://" + app2Name + "." + domainName + " to web app " + app2Name + "...");
                    app2 = app2.Update()
                            .WithManagedHostnameBindings(domain, app2Name)
                            .DefineSslBinding
                                .ForHostname(app2Name + "." + domainName)
                                .WithExistingAppServiceCertificateOrder(certificateOrder)
                                .WithSniBasedSsl()
                                .Attach()
                            .Apply();

                    Console.WriteLine("Finished binding http://" + app2Name + "." + domainName + " to web app " + app2Name + "...");
                    Utilities.Print(app2);

                    // Make a call to warm up with web app
                    CheckAddress("https://" + app2Name + "." + domainName);

                    Console.WriteLine("CURLing https://" + app2Name + "." + domainName);
                    Console.WriteLine(CheckAddress("https://" + app2Name + "." + domainName));

                    //============================================================
                    // Create 2 slots under web app 2

                    // slot1.DomainName.Com - SSL off - autoswap on
                    Console.WriteLine("Creating slot " + slot1Name + "...");

                    var slot1 = app2.DeploymentSlots.Define(slot1Name)
                            .WithBrandNewConfiguration()
                            .WithManagedHostnameBindings(domain, slot1Name)
                            .WithAutoSwapSlotName("production")
                            .Create();

                    Console.WriteLine("Created slot " + slot1Name + "...");
                    Utilities.Print(slot1);

                    // slot2.DomainName.Com - SSL on - autoswap on - storage account info
                    Console.WriteLine("Creating another slot " + slot2Name + "...");

                    var slot2 = app2.DeploymentSlots.Define(slot2Name)
                            .WithConfigurationFromDeploymentSlot(slot1)
                            .WithManagedHostnameBindings(domain, slot2Name)
                            .DefineSslBinding
                                .ForHostname(slot2Name + "." + domainName)
                                .WithExistingAppServiceCertificateOrder(certificateOrder)
                                .WithSniBasedSsl()
                                .Attach()
                            .WithStickyAppSetting("storageaccount", "account1")
                            .WithStickyAppSetting("storageaccountkey", "key1")
                            .Create();

                    Console.WriteLine("Created slot " + slot2Name + "...");
                    Utilities.Print(slot2);

                    //============================================================
                    // Update slot 1

                    Console.WriteLine("Turning on SSL for slot " + slot1Name + "...");

                    slot1 = slot1.Update()
                            .WithAutoSwapSlotName(null) // this will not affect slot 2
                            .DefineSslBinding
                                .ForHostname(slot1Name + "." + domainName)
                                .WithExistingAppServiceCertificateOrder(certificateOrder)
                                .WithSniBasedSsl()
                                .Attach()
                            .Apply();

                    Console.WriteLine("SSL turned on for slot " + slot1Name + "...");
                    Utilities.Print(slot1);

                    //============================================================
                    // Deploy public GitHub repo to slot 2

                    Console.WriteLine("Deploying public GitHub repo to slot " + slot2Name);

                    slot2 = slot2.Update()
                            .DefineSourceControl()
                                .WithPublicGitRepository("https://github.Com/jianghaolu/azure-site-test")
                                .WithBranch("master")
                                .Attach()
                            .Apply();

                    Console.WriteLine("Finished deploying public GitHub repo to slot " + slot2Name);
                    Utilities.Print(slot2);

                    // Make a call to warm up with web app
                    CheckAddress("https://" + app2Name + "." + domainName);

                    Console.WriteLine("CURLing https://" + app2Name + "." + domainName + ". Should contain auto-swapped slot 2 content.");
                    Console.WriteLine(CheckAddress("https://" + app2Name + "." + domainName));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    try
                    {
                        Console.WriteLine("Deleting Resource Group: " + rgName);
                        azure.ResourceGroups.DeleteByName(rgName);
                        Console.WriteLine("Deleted Resource Group: " + rgName);
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

        private static HttpResponseMessage CheckAddress(string url)
        {
            using (var client = new HttpClient())
            {
                return client.GetAsync(url).Result;
            }
        }
    }
}