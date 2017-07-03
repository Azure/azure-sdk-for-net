// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.TrafficManager.Fluent;
using System;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Net.Http;

namespace ManageWebAppWithTrafficManager
{
    /**
     * Azure App Service sample for managing web apps.
     *  - Create a domain
     *  - Create a self-signed certificate for the domain
     *  - Create 3 app service plans in 3 different regions
     *  - Create 5 web apps under the 3 plans, bound to the domain and the certificate
     *  - Create a traffic manager in front of the web apps
     *  - Scale up the app service plans to twice the capacity
     */

    public class Program
    {
        private static string CERT_PASSWORD = "StrongPass!12";
        private static string pfxPath;

        public static void RunSample(IAzure azure)
        {
            string resourceGroupName = SdkContext.RandomResourceName("rgNEMV_", 24);
            string app1Name = SdkContext.RandomResourceName("webapp1-", 20);
            string app2Name = SdkContext.RandomResourceName("webapp2-", 20);
            string app3Name = SdkContext.RandomResourceName("webapp3-", 20);
            string app4Name = SdkContext.RandomResourceName("webapp4-", 20);
            string app5Name = SdkContext.RandomResourceName("webapp5-", 20);
            string plan1Name = SdkContext.RandomResourceName("jplan1_", 15);
            string plan2Name = SdkContext.RandomResourceName("jplan2_", 15);
            string plan3Name = SdkContext.RandomResourceName("jplan3_", 15);
            string domainName = SdkContext.RandomResourceName("jsdkdemo-", 20) + ".com";
            string trafficManagerName = SdkContext.RandomResourceName("jsdktm-", 20);

            try
            {
                //============================================================
                // Purchase a domain (will be canceled for a full refund)

                Utilities.Log("Purchasing a domain " + domainName + "...");

                azure.ResourceGroups.Define(resourceGroupName)
                        .WithRegion(Region.USWest)
                        .Create();

                var domain = azure.AppServices.AppServiceDomains.Define(domainName)
                        .WithExistingResourceGroup(resourceGroupName)
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

                pfxPath = domainName + ".pfx";

                Utilities.Log("Creating a self-signed certificate " + pfxPath + "...");

                Utilities.CreateCertificate(domainName, pfxPath, CERT_PASSWORD);

                //============================================================
                // Create 3 app service plans in 3 regions

                Utilities.Log("Creating app service plan " + plan1Name + " in US West...");

                var plan1 = CreateAppServicePlan(azure, resourceGroupName, plan1Name, Region.USWest);

                Utilities.Log("Created app service plan " + plan1.Name);
                Utilities.Print(plan1);

                Utilities.Log("Creating app service plan " + plan2Name + " in Europe West...");

                var plan2 = CreateAppServicePlan(azure, resourceGroupName, plan2Name, Region.EuropeWest);

                Utilities.Log("Created app service plan " + plan2.Name);
                Utilities.Print(plan1);

                Utilities.Log("Creating app service plan " + plan3Name + " in Asia East...");

                var plan3 = CreateAppServicePlan(azure, resourceGroupName, plan3Name, Region.AsiaEast);

                Utilities.Log("Created app service plan " + plan2.Name);
                Utilities.Print(plan1);

                //============================================================
                // Create 5 web apps under these 3 app service plans

                Utilities.Log("Creating web app " + app1Name + "...");

                var app1 = CreateWebApp(azure, domain, resourceGroupName, app1Name, plan1);

                Utilities.Log("Created web app " + app1.Name);
                Utilities.Print(app1);

                Utilities.Log("Creating another web app " + app2Name + "...");
                var app2 = CreateWebApp(azure, domain, resourceGroupName, app2Name, plan2);

                Utilities.Log("Created web app " + app2.Name);
                Utilities.Print(app2);

                Utilities.Log("Creating another web app " + app3Name + "...");
                var app3 = CreateWebApp(azure, domain, resourceGroupName, app3Name, plan3);

                Utilities.Log("Created web app " + app3.Name);
                Utilities.Print(app3);

                Utilities.Log("Creating another web app " + app3Name + "...");
                var app4 = CreateWebApp(azure, domain, resourceGroupName, app4Name, plan1);

                Utilities.Log("Created web app " + app4.Name);
                Utilities.Print(app4);

                Utilities.Log("Creating another web app " + app3Name + "...");
                var app5 = CreateWebApp(azure, domain, resourceGroupName, app5Name, plan1);

                Utilities.Log("Created web app " + app5.Name);
                Utilities.Print(app5);

                //============================================================
                // Create a traffic manager

                Utilities.Log("Creating a traffic manager " + trafficManagerName + " for the web apps...");

                var trafficManager = azure.TrafficManagerProfiles
                        .Define(trafficManagerName)
                        .WithExistingResourceGroup(resourceGroupName)
                        .WithLeafDomainLabel(trafficManagerName)
                        .WithTrafficRoutingMethod(TrafficRoutingMethod.Weighted)
                        .DefineAzureTargetEndpoint("endpoint1")
                            .ToResourceId(app1.Id)
                            .Attach()
                        .DefineAzureTargetEndpoint("endpoint2")
                            .ToResourceId(app2.Id)
                            .Attach()
                        .DefineAzureTargetEndpoint("endpoint3")
                            .ToResourceId(app3.Id)
                            .Attach()
                        .Create();

                Utilities.Log("Created traffic manager " + trafficManager.Name);

                //============================================================
                // Scale up the app service plans

                Utilities.Log("Scaling up app service plan " + plan1Name + "...");

                plan1.Update()
                                .WithCapacity(plan1.Capacity * 2)
                                .Apply();

                Utilities.Log("Scaled up app service plan " + plan1Name);
                Utilities.Print(plan1);

                Utilities.Log("Scaling up app service plan " + plan2Name + "...");

                plan2.Update()
                                .WithCapacity(plan2.Capacity * 2)
                                .Apply();

                Utilities.Log("Scaled up app service plan " + plan2Name);
                Utilities.Print(plan2);

                Utilities.Log("Scaling up app service plan " + plan3Name + "...");

                plan3.Update()
                                .WithCapacity(plan3.Capacity * 2)
                                .Apply();

                Utilities.Log("Scaled up app service plan " + plan3Name);
                Utilities.Print(plan3);
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + resourceGroupName);
                    azure.ResourceGroups.DeleteByName(resourceGroupName);
                    Utilities.Log("Deleted Resource Group: " + resourceGroupName);
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

        private static IAppServicePlan CreateAppServicePlan(IAzure azure, string rgName, string name, Region region)
        {
            return azure.AppServices.AppServicePlans
                    .Define(name)
                    .WithRegion(region)
                    .WithExistingResourceGroup(rgName)
                    .WithPricingTier(PricingTier.BasicB1)
                    .WithOperatingSystem(Microsoft.Azure.Management.AppService.Fluent.OperatingSystem.Windows)
                    .Create();
        }

        private static IWebApp CreateWebApp(IAzure azure, IAppServiceDomain domain, string rgName, string name, IAppServicePlan plan)
        {
            return azure.WebApps.Define(name)
                    .WithExistingWindowsPlan(plan)
                    .WithExistingResourceGroup(rgName)
                    .WithManagedHostnameBindings(domain, name)
                    .DefineSslBinding()
                        .ForHostname(name + "." + domain.Name)
                        .WithPfxCertificateToUpload(Path.Combine(Utilities.ProjectPath, "Asset", pfxPath), CERT_PASSWORD)
                        .WithSniBasedSsl()
                        .Attach()
                    .DefineSourceControl()
                        .WithPublicGitRepository("https://github.Com/jianghaolu/azure-site-test")
                        .WithBranch("master")
                        .Attach()
                    .Create();
        }
    }
}