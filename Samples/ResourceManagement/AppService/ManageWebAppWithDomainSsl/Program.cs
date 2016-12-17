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
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading;

namespace ManageWebAppWithDomainSsl
{
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

    public class Program
    {
        private static readonly string app1Name = ResourceNamer.RandomResourceName("webapp1-", 20);
        private static readonly string app2Name = ResourceNamer.RandomResourceName("webapp2-", 20);
        private static readonly string planName = ResourceNamer.RandomResourceName("jplan_", 15);
        private static readonly string rgName = ResourceNamer.RandomResourceName("rgNEMV_", 24);
        private static readonly string domainName = ResourceNamer.RandomResourceName("jsdkdemo-", 20) + ".com";
        private static readonly string certPassword = "StrongPass!12";

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

                    Console.WriteLine("Creating web app " + app1Name + "...");

                    var app1 = azure.WebApps
                            .Define(app1Name)
                            .WithNewResourceGroup(rgName)
                            .WithNewAppServicePlan(planName)
                            .WithRegion(Region.US_WEST)
                            .WithPricingTier(AppServicePricingTier.Standard_S1)
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
                    Console.WriteLine("Purchased domain " + domain.Name);
                    Utilities.Print(domain);

                    //============================================================
                    // Bind domain to web app 1

                    Console.WriteLine("Binding http://" + app1Name + "." + domainName + " to web app " + app1Name + "...");

                    app1 = app1.Update()
                            .DefineHostnameBinding()
                                .WithAzureManagedDomain(domain)
                                .WithSubDomain(app1Name)
                                .WithDnsRecordType(CustomHostNameDnsRecordType.CName)
                                .Attach()
                            .Apply();

                    Console.WriteLine("Finished binding http://" + app1Name + "." + domainName + " to web app " + app1Name);
                    Utilities.Print(app1);

                    //============================================================
                    // Create a self-singed SSL certificate

                    var pfxPath = domainName + ".pfx";

                    Console.WriteLine("Creating a self-signed certificate " + pfxPath + "...");

                    CreateCertificate(domainName, pfxPath, certPassword);

                    Console.WriteLine("Created self-signed certificate " + pfxPath);

                    //============================================================
                    // Bind domain to web app 2 and turn on wild card SSL for both

                    Console.WriteLine("Binding https://" + app1Name + "." + domainName + " to web app " + app1Name + "...");

                    app1 = app1.Update()
                                    .WithManagedHostnameBindings(domain, app1Name)
                                    .DefineSslBinding()
                                        .ForHostname(app1Name + "." + domainName)
                                        .WithPfxCertificateToUpload("Asset/" + pfxPath, certPassword)
                                        .WithSniBasedSsl()
                                        .Attach()
                                    .Apply();

                    Console.WriteLine("Finished binding https://" + app1Name + "." + domainName + " to web app " + app1Name);
                    Utilities.Print(app1);

                    Console.WriteLine("Binding https://" + app2Name + "." + domainName + " to web app " + app2Name + "...");

                    app2 = app2.Update()
                                    .WithManagedHostnameBindings(domain, app2Name)
                                    .DefineSslBinding()
                                        .ForHostname(app2Name + "." + domainName)
                                        .WithPfxCertificateToUpload("Asset/" + pfxPath, certPassword)
                                        .WithSniBasedSsl()
                                        .Attach()
                                    .Apply();

                    Console.WriteLine("Finished binding https://" + app2Name + "." + domainName + " to web app " + app2Name);
                    Utilities.Print(app2);
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

        private static void CreateCertificate(string domainName, string pfxPath, string password)
        {
            string args = string.Format(@".\createCert.ps1 -pfxFileName {0} -pfxPassword ""{1}"" -domainName ""{2}""", pfxPath, password, domainName);
            ProcessStartInfo info = new ProcessStartInfo("powershell", args);
            info.WorkingDirectory = "Asset";
            Process.Start(info).WaitForExit();
        }
    }
}