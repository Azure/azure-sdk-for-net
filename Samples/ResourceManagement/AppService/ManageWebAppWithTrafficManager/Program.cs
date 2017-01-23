﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.Trafficmanager.Fluent;
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
            string rgName = SharedSettings.RandomResourceName("rgNEMV_", 24);
            string app1Name = SharedSettings.RandomResourceName("webapp1-", 20);
            string app2Name = SharedSettings.RandomResourceName("webapp2-", 20);
            string app3Name = SharedSettings.RandomResourceName("webapp3-", 20);
            string app4Name = SharedSettings.RandomResourceName("webapp4-", 20);
            string app5Name = SharedSettings.RandomResourceName("webapp5-", 20);
            string plan1Name = SharedSettings.RandomResourceName("jplan1_", 15);
            string plan2Name = SharedSettings.RandomResourceName("jplan2_", 15);
            string plan3Name = SharedSettings.RandomResourceName("jplan3_", 15);
            string domainName = SharedSettings.RandomResourceName("jsdkdemo-", 20) + ".com";
            string tmName = SharedSettings.RandomResourceName("jsdktm-", 20);

            try
            {
                //============================================================
                // Purchase a domain (will be canceled for a full refund)

                Utilities.Log("Purchasing a domain " + domainName + "...");

                azure.ResourceGroups.Define(rgName)
                        .WithRegion(Region.US_WEST)
                        .Create();

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

                pfxPath = domainName + ".pfx";

                Utilities.Log("Creating a self-signed certificate " + pfxPath + "...");

                CreateCertificate(domainName, pfxPath, CERT_PASSWORD);

                //============================================================
                // Create 3 app service plans in 3 regions

                Utilities.Log("Creating app service plan " + plan1Name + " in US West...");

                var plan1 = CreateAppServicePlan(azure, rgName, plan1Name, Region.US_WEST);

                Utilities.Log("Created app service plan " + plan1.Name);
                Utilities.Print(plan1);

                Utilities.Log("Creating app service plan " + plan2Name + " in Europe West...");

                var plan2 = CreateAppServicePlan(azure, rgName, plan2Name, Region.EUROPE_WEST);

                Utilities.Log("Created app service plan " + plan2.Name);
                Utilities.Print(plan1);

                Utilities.Log("Creating app service plan " + plan3Name + " in Asia East...");

                var plan3 = CreateAppServicePlan(azure, rgName, plan3Name, Region.ASIA_EAST);

                Utilities.Log("Created app service plan " + plan2.Name);
                Utilities.Print(plan1);

                //============================================================
                // Create 5 web apps under these 3 app service plans

                Utilities.Log("Creating web app " + app1Name + "...");

                var app1 = CreateWebApp(azure, domain, rgName, app1Name, plan1);

                Utilities.Log("Created web app " + app1.Name);
                Utilities.Print(app1);

                Utilities.Log("Creating another web app " + app2Name + "...");
                var app2 = CreateWebApp(azure, domain, rgName, app2Name, plan2);

                Utilities.Log("Created web app " + app2.Name);
                Utilities.Print(app2);

                Utilities.Log("Creating another web app " + app3Name + "...");
                var app3 = CreateWebApp(azure, domain, rgName, app3Name, plan3);

                Utilities.Log("Created web app " + app3.Name);
                Utilities.Print(app3);

                Utilities.Log("Creating another web app " + app3Name + "...");
                var app4 = CreateWebApp(azure, domain, rgName, app4Name, plan1);

                Utilities.Log("Created web app " + app4.Name);
                Utilities.Print(app4);

                Utilities.Log("Creating another web app " + app3Name + "...");
                var app5 = CreateWebApp(azure, domain, rgName, app5Name, plan1);

                Utilities.Log("Created web app " + app5.Name);
                Utilities.Print(app5);

                //============================================================
                // Create a traffic manager

                Utilities.Log("Creating a traffic manager " + tmName + " for the web apps...");

                var trafficManager = azure.TrafficManagerProfiles
                        .Define(tmName)
                        .WithExistingResourceGroup(rgName)
                        .WithLeafDomainLabel(tmName)
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
                        .DefineAzureTargetEndpoint("endpoint4")
                            .ToResourceId(app4.Id)
                            .Attach()
                        .DefineAzureTargetEndpoint("endpoint5")
                            .ToResourceId(app5.Id)
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
                var credentials = SharedSettings.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.BASIC)
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
                    .WithPricingTier(AppServicePricingTier.Basic_B1)
                    .Create();
        }

        private static IWebApp CreateWebApp(IAzure azure, IAppServiceDomain domain, string rgName, string name, IAppServicePlan plan)
        {
            return azure.WebApps.Define(name)
                    .WithExistingResourceGroup(rgName)
                    .WithExistingAppServicePlan(plan)
                    .WithManagedHostnameBindings(domain, name)
                    .DefineSslBinding()
                        .ForHostname(name + "." + domain.Name)
                        .WithPfxCertificateToUpload("Asset/" + pfxPath, CERT_PASSWORD)
                        .WithSniBasedSsl()
                        .Attach()
                    .DefineSourceControl()
                        .WithPublicGitRepository("https://github.Com/jianghaolu/azure-site-test")
                        .WithBranch("master")
                        .Attach()
                    .Create();
        }

        private static void CreateCertificate(string domainName, string pfxPath, string password)
        {
            string args = string.Format(@".\createCert.ps1 -pfxFileName {0} -pfxPassword ""{1}"" -domainName ""{2}""", pfxPath, password, domainName);
            ProcessStartInfo info = new ProcessStartInfo("powershell", args);
            info.WorkingDirectory = "Asset";
            Process.Start(info).WaitForExit();
        }
    }
}