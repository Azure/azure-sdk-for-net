// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.TrafficManager.Fluent;
using Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ManageTrafficManager
{
    public class Program
    {
        private static readonly string certPassword             = "StrongPass!12";
        private static readonly List<Region> regions            = new List<Region>();

        /**
         * Azure traffic manager sample for managing profiles.
         *  - Create a domain
         *  - Create a self-signed certificate for the domain
         *  - Create 5 app service plans in 5 different regions
         *  - Create 5 web apps under the each plan, bound to the domain and the certificate
         *  - Create a traffic manager in front of the web apps
         *  - Disable an endpoint
         *  - Delete an endpoint
         *  - Enable an endpoint
         *  - Change/configure traffic manager routing method
         *  - Disable traffic manager profile
         *  - Enable traffic manager profile
         */
        public static void RunSample(IAzure azure)
        {
            string rgName = SdkContext.RandomResourceName("rgNEMV_", 24);
            string domainName = SdkContext.RandomResourceName("jsdkdemo-", 20) + ".com";
            string appServicePlanNamePrefix = SdkContext.RandomResourceName("jplan1_", 15);
            string webAppNamePrefix = SdkContext.RandomResourceName("webapp1-", 20);
            string tmName = SdkContext.RandomResourceName("jsdktm-", 20);
            
            // The regions in which web app needs to be created
            //
            regions.Add(Region.USWest2);
            regions.Add(Region.USEast2);
            regions.Add(Region.AsiaEast);
            regions.Add(Region.IndiaWest);
            regions.Add(Region.USCentral);
            
            try
            {
                azure.ResourceGroups.Define(rgName)
                    .WithRegion(Region.USWest)
                    .Create();

                // ============================================================
                // Purchase a domain (will be canceled for a full refund)

                Utilities.Log("Purchasing a domain " + domainName + "...");
                var domain = azure.AppServices.AppServiceDomains.Define(domainName)
                        .WithExistingResourceGroup(rgName)
                        .DefineRegistrantContact()
                            .WithFirstName("Jon")
                            .WithLastName("Doe")
                            .WithEmail("jondoe@contoso.com")
                            .WithAddressLine1("123 4th Ave")
                            .WithCity("Redmond")
                            .WithStateOrProvince("WA")
                            .WithCountry(CountryISOCode.UnitedStates)
                            .WithPostalCode("98052")
                            .WithPhoneCountryCode(CountryPhoneCode.UnitedStates)
                            .WithPhoneNumber("4258828080")
                        .Attach()
                        .WithDomainPrivacyEnabled(true)
                        .WithAutoRenewEnabled(false)
                        .Create();
                Utilities.Log("Purchased domain " + domain.Name);
                Utilities.Print(domain);

                //============================================================
                // Create a self-singed SSL certificate

                var pfxPath = domainName + ".pfx";
                Utilities.Log("Creating a self-signed certificate " + pfxPath + "...");
                Utilities.CreateCertificate(domainName, pfxPath, certPassword);
                Utilities.Log("Created self-signed certificate " + pfxPath);

                //============================================================
                // Creates app service in 5 different region

                var appServicePlans = new List<IAppServicePlan>();
                int id = 0;
                foreach (var region in regions)
                {
                    var planName = appServicePlanNamePrefix + id;
                    Utilities.Log("Creating an app service plan " + planName + " in region " + region + "...");
                    var appServicePlan = azure.AppServices.AppServicePlans
                            .Define(planName)
                            .WithRegion(region)
                            .WithExistingResourceGroup(rgName)
                            .WithPricingTier(PricingTier.BasicB1)
                            .WithOperatingSystem(Microsoft.Azure.Management.AppService.Fluent.OperatingSystem.Windows)
                            .Create();
                    Utilities.Log("Created app service plan " + planName);
                    Utilities.Print(appServicePlan);
                    appServicePlans.Add(appServicePlan);
                    id++;
                }

                //============================================================
                // Creates websites using previously created plan
                var webApps = new List<IWebApp>();
                id = 0;
                foreach (var appServicePlan in appServicePlans)
                {
                    var webAppName = webAppNamePrefix + id;
                    Utilities.Log("Creating a web app " + webAppName + " using the plan " + appServicePlan.Name + "...");
                    var webApp = azure.WebApps.Define(webAppName)
                            .WithExistingWindowsPlan(appServicePlan)
                            .WithExistingResourceGroup(rgName)
                            .WithManagedHostnameBindings(domain, webAppName)
                            .DefineSslBinding()
                            .ForHostname(webAppName + "." + domain.Name)
                            .WithPfxCertificateToUpload(Path.Combine(Utilities.ProjectPath, "Asset", pfxPath), certPassword)
                            .WithSniBasedSsl()
                            .Attach()
                            .DefineSourceControl()
                                .WithPublicGitRepository("https://github.com/jianghaolu/azure-site-test")
                                .WithBranch("master")
                                .Attach()
                            .Create();
                    Utilities.Log("Created web app " + webAppName);
                    Utilities.Print(webApp);
                    webApps.Add(webApp);
                    id++;
                }
                //============================================================
                // Creates a traffic manager profile

                Utilities.Log("Creating a traffic manager profile " + tmName + " for the web apps...");
                IWithEndpoint tmDefinition = azure.TrafficManagerProfiles
                        .Define(tmName)
                        .WithExistingResourceGroup(rgName)
                        .WithLeafDomainLabel(tmName)
                        .WithPriorityBasedRouting();
                ICreatable<ITrafficManagerProfile> tmCreatable = null;
                int priority = 1;
                foreach (var webApp in webApps)
                {
                    tmCreatable = tmDefinition.DefineAzureTargetEndpoint("endpoint-" + priority)
                            .ToResourceId(webApp.Id)
                            .WithRoutingPriority(priority)
                            .Attach();
                    priority++;
                }

                var trafficManagerProfile = tmCreatable.Create();
                Utilities.Log("Created traffic manager " + trafficManagerProfile.Name);
                Utilities.Print(trafficManagerProfile);

                //============================================================
                // Disables one endpoint and removes another endpoint

                Utilities.Log("Disabling and removing endpoint...");
                trafficManagerProfile = trafficManagerProfile.Update()
                        .UpdateAzureTargetEndpoint("endpoint-1")
                            .WithTrafficDisabled()
                            .Parent()
                        .WithoutEndpoint("endpoint-2")
                        .Apply();
                Utilities.Log("Endpoints updated");

                //============================================================
                // Enables an endpoint

                Utilities.Log("Enabling endpoint...");
                trafficManagerProfile = trafficManagerProfile.Update()
                        .UpdateAzureTargetEndpoint("endpoint-1")
                            .WithTrafficEnabled()
                            .Parent()
                        .Apply();
                Utilities.Log("Endpoint updated");
                Utilities.Print(trafficManagerProfile);

                //============================================================
                // Change/configure traffic manager routing method

                Utilities.Log("Changing traffic manager profile routing method...");
                trafficManagerProfile = trafficManagerProfile.Update()
                        .WithPerformanceBasedRouting()
                        .Apply();
                Utilities.Log("Changed traffic manager profile routing method");

                //============================================================
                // Disables the traffic manager profile

                Utilities.Log("Disabling traffic manager profile...");
                trafficManagerProfile.Update()
                        .WithProfileStatusDisabled()
                        .Apply();
                Utilities.Log("Traffic manager profile disabled");

                //============================================================
                // Enables the traffic manager profile

                Utilities.Log("Enabling traffic manager profile...");
                trafficManagerProfile.Update()
                        .WithProfileStatusDisabled()
                        .Apply();
                Utilities.Log("Traffic manager profile enabled");

                //============================================================
                // Deletes the traffic manager profile

                Utilities.Log("Deleting the traffic manger profile...");
                azure.TrafficManagerProfiles.DeleteById(trafficManagerProfile.Id);
                Utilities.Log("Traffic manager profile deleted");
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.DeleteByName(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
                }
                catch
                {
                    Utilities.Log("Did not create any resources in Azure. No clean up is necessary");
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
