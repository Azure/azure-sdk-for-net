// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.AppService.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.IO;

namespace ManageLinuxWebAppWithDomainSsl
{
    public class Program
    {
        private const string CertificatePassword = "StrongPass!12";

        /**
         * Azure App Service sample for managing web apps.
         *  - app service plan, web app
         *    - Create 2 web apps under the same new app service plan
         *  - domain
         *    - Create a domain
         *  - certificate
         *    - Upload a self-signed wildcard certificate
         *    - update both web apps to use the domain and the created wildcard SSL certificate
         */
        public static void RunSample(IAzure azure)
        {
            string app1Name       = SdkContext.RandomResourceName("webapp1-", 20);
            string app2Name       = SdkContext.RandomResourceName("webapp2-", 20);
            string rgName         = SdkContext.RandomResourceName("rgNEMV_", 24);
            string domainName     = SdkContext.RandomResourceName("jsdkdemo-", 20) + ".com";

            try {
                //============================================================
                // Create a web app with a new app service plan

                Utilities.Log("Creating web app " + app1Name + "...");

                IWebApp app1 = azure.WebApps.Define(app1Name)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(rgName)
                        .WithNewLinuxPlan(PricingTier.StandardS1)
                        .WithBuiltInImage(RuntimeStack.NodeJS_6_9_3)
                        .Create();

                Utilities.Log("Created web app " + app1.Name);
                Utilities.Print(app1);

                //============================================================
                // Create a second web app with the same app service plan

                Utilities.Log("Creating another web app " + app2Name + "...");
                IAppServicePlan plan = azure.AppServices.AppServicePlans.GetById(app1.AppServicePlanId);
                IWebApp app2 = azure.WebApps.Define(app2Name)
                        .WithExistingLinuxPlan(plan)
                        .WithExistingResourceGroup(rgName)
                        .WithBuiltInImage(RuntimeStack.NodeJS_6_9_3)
                        .Create();

                Utilities.Log("Created web app " + app2.Name);
                Utilities.Print(app2);

                //============================================================
                // Purchase a domain (will be canceled for a full refund)

                Utilities.Log("Purchasing a domain " + domainName + "...");

                IAppServiceDomain domain = azure.AppServices.AppServiceDomains.Define(domainName)
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
                // Bind domain to web app 1

                Utilities.Log("Binding http://" + app1Name + "." + domainName + " to web app " + app1Name + "...");

                app1 = app1.Update()
                        .DefineHostnameBinding()
                            .WithAzureManagedDomain(domain)
                            .WithSubDomain(app1Name)
                            .WithDnsRecordType(CustomHostNameDnsRecordType.CName)
                            .Attach()
                        .Apply();

                Utilities.Log("Finished binding http://" + app1Name + "." + domainName + " to web app " + app1Name);
                Utilities.Print(app1);

                //============================================================
                // Create a self-singed SSL certificate

                var pfxPath = domainName + ".pfx";

                Utilities.Log("Creating a self-signed certificate " + pfxPath + "...");

                Utilities.CreateCertificate(domainName, pfxPath, CertificatePassword);

                Utilities.Log("Created self-signed certificate " + pfxPath);

                //============================================================
                // Bind domain to web app 2 and turn on wild card SSL for both

                Utilities.Log("Binding https://" + app1Name + "." + domainName + " to web app " + app1Name + "...");

                app1 = app1.Update()
                        .WithManagedHostnameBindings(domain, app1Name)
                        .DefineSslBinding()
                            .ForHostname(app1Name + "." + domainName)
                            .WithPfxCertificateToUpload(Path.Combine(Utilities.ProjectPath, "Asset", pfxPath), CertificatePassword)
                            .WithSniBasedSsl()
                            .Attach()
                        .Apply();

                Utilities.Log("Finished binding http://" + app1Name + "." + domainName + " to web app " + app1Name);
                Utilities.Print(app1);

                Utilities.Log("Binding https://" + app2Name + "." + domainName + " to web app " + app2Name + "...");

                app2 = app2.Update()
                        .WithManagedHostnameBindings(domain, app2Name)
                        .DefineSslBinding()
                            .ForHostname(app2Name + "." + domainName)
                            .WithPfxCertificateToUpload(Path.Combine(Utilities.ProjectPath, "Asset", pfxPath), CertificatePassword)
                            .WithSniBasedSsl()
                            .Attach()
                        .Apply();

                Utilities.Log("Finished binding http://" + app2Name + "." + domainName + " to web app " + app2Name);
                Utilities.Print(app2);
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.BeginDeleteByName(rgName);
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
    }
}