// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.AppService.Fluent.Models;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Linq;
using System.Threading;

namespace ManageDns
{
    public class Program
    {
        private const string CustomDomainName = "THE CUSTOM DOMAIN THAT YOU OWN (e.g. contoso.com)";
        
        /**
         * Azure DNS sample for managing DNS zones.
         *  - Create a root DNS zone (contoso.com)
         *  - Create a web application
         *  - Add a CNAME record (www) to root DNS zone and bind it to web application host name
         *  - Creates a virtual machine with public IP
         *  - Add a A record (employees) to root DNS zone that points to virtual machine public IPV4 address
         *  - Creates a child DNS zone (partners.contoso.com)
         *  - Creates a virtual machine with public IP
         *  - Add a A record (partners) to child DNS zone that points to virtual machine public IPV4 address
         *  - Delegate from root domain to child domain by adding NS records
         *  - Remove A record from the root DNS zone
         *  - Delete the child DNS zone
         */
        public static void RunSample(IAzure azure)
        {
            string rgName = SdkContext.RandomResourceName("rgNEMV_", 24);
            string appServicePlanName = SdkContext.RandomResourceName("jplan1_", 15);
            string webAppName = SdkContext.RandomResourceName("webapp1-", 20);
            
            try
            {
                var resourceGroup = azure.ResourceGroups.Define(rgName)
                    .WithRegion(Region.USWest)
                    .Create();

                //============================================================
                // Creates root DNS Zone

                Utilities.Log("Creating root DNS zone " + CustomDomainName + "...");
                var rootDnsZone = azure.DnsZones.Define(CustomDomainName)
                    .WithExistingResourceGroup(resourceGroup)
                    .Create();
                Utilities.Log("Created root DNS zone " + rootDnsZone.Name);
                Utilities.Print(rootDnsZone);

                //============================================================
                // Sets NS records in the parent zone (hosting custom domain) to make Azure DNS the authoritative
                // source for name resolution for the zone

                Utilities.Log("Go to your registrar portal and configure your domain " + CustomDomainName
                        + " with following name server addresses");
                foreach (var nameServer in rootDnsZone.NameServers)
                {
                    Utilities.Log(" " + nameServer);
                }
                Utilities.Log("Press [ENTER] after finishing above step");
                Utilities.ReadLine();

                //============================================================
                // Creates a web App

                Utilities.Log("Creating Web App " + webAppName + "...");
                var webApp = azure.WebApps.Define(webAppName)
                        .WithExistingResourceGroup(rgName)
                        .WithNewAppServicePlan(appServicePlanName)
                        .WithRegion(Region.USEast2)
                        .WithPricingTier(AppServicePricingTier.BasicB1)
                        .DefineSourceControl()
                            .WithPublicGitRepository("https://github.com/jianghaolu/azure-site-test")
                            .WithBranch("master")
                            .Attach()
                        .Create();
                Utilities.Log("Created web app " + webAppName);
                Utilities.Print(webApp);

                //============================================================
                // Creates a CName record and bind it with the web app

                // Step 1: Adds CName Dns record to root DNS zone that specify web app host domain as an
                // alias for www.[customDomainName]

                Utilities.Log("Updating DNS zone by adding a CName record...");
                rootDnsZone = rootDnsZone.Update()
                        .WithCnameRecordSet("www", webApp.DefaultHostName)
                        .Apply();
                Utilities.Log("DNS zone updated");
                Utilities.Print(rootDnsZone);

                // Waiting for a minute for DNS CName entry to propagate
                Utilities.Log("Waiting a minute for CName record entry to propagate...");
                Thread.Sleep(60 * 1000);

                // Step 2: Adds a web app host name binding for www.[customDomainName]
                //         This binding action will fail if the CName record propagation is not yet completed

                Utilities.Log("Updating Web app with host name binding...");
                webApp.Update()
                        .DefineHostnameBinding()
                            .WithThirdPartyDomain(CustomDomainName)
                            .WithSubDomain("www")
                            .WithDnsRecordType(CustomHostNameDnsRecordType.CName)
                            .Attach()
                        .Apply();
                Utilities.Log("Web app updated");
                Utilities.Print(webApp);



                //============================================================
                // Creates a virtual machine with public IP

                Utilities.Log("Creating a virtual machine with public IP...");
                var virtualMachine1 = azure.VirtualMachines
                        .Define(SdkContext.RandomResourceName("employeesvm-", 20))
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIpAddressDynamic()
                        .WithNewPrimaryPublicIpAddress(SdkContext.RandomResourceName("empip-", 20))
                        .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WindowsServer2012R2Datacenter)
                        .WithAdminUsername("testuser")
                        .WithAdminPassword("12NewPA$$w0rd!")
                        .WithSize(VirtualMachineSizeTypes.StandardD12V2)
                        .Create();
                Utilities.Log("Virtual machine created");

                //============================================================
                // Update DNS zone by adding a A record in root DNS zone pointing to virtual machine IPv4 address

                var vm1PublicIpAddress = virtualMachine1.GetPrimaryPublicIpAddress();
                Utilities.Log("Updating root DNS zone " + CustomDomainName + "...");
                rootDnsZone = rootDnsZone.Update()
                        .DefineARecordSet("employees")
                            .WithIpv4Address(vm1PublicIpAddress.IpAddress)
                            .Attach()
                        .Apply();
                Utilities.Log("Updated root DNS zone " + rootDnsZone.Name);
                Utilities.Print(rootDnsZone);

                // Prints the CName and A Records in the root DNS zone
                //
                Utilities.Log("Getting CName record set in the root DNS zone " + CustomDomainName + "...");
                var cnameRecordSets = rootDnsZone
                        .CnameRecordSets
                        .List();

                foreach (var cnameRecordSet in cnameRecordSets)
                {
                    Utilities.Log("Name: " + cnameRecordSet.Name + " Canonical Name: " + cnameRecordSet.CanonicalName);
                }

                Utilities.Log("Getting ARecord record set in the root DNS zone " + CustomDomainName + "...");
                var aRecordSets = rootDnsZone
                        .ARecordSets
                        .List();

                foreach (var aRecordSet in aRecordSets)
                {
                    Utilities.Log("Name: " + aRecordSet.Name);
                    foreach (var ipv4Address in aRecordSet.Ipv4Addresses)
                    {
                        Utilities.Log("  " + ipv4Address);
                    }
                }

                //============================================================
                // Creates a child DNS zone

                var partnerSubDomainName = "partners." + CustomDomainName;
                Utilities.Log("Creating child DNS zone " + partnerSubDomainName + "...");
                var partnersDnsZone = azure.DnsZones
                        .Define(partnerSubDomainName)
                        .WithExistingResourceGroup(resourceGroup)
                        .Create();
                Utilities.Log("Created child DNS zone " + partnersDnsZone.Name);
                Utilities.Print(partnersDnsZone);

                //============================================================
                // Adds NS records in the root dns zone to delegate partners.[customDomainName] to child dns zone

                Utilities.Log("Updating root DNS zone " + rootDnsZone + "...");
                var nsRecordStage = rootDnsZone
                        .Update()
                        .DefineNsRecordSet("partners")
                        .WithNameServer(partnersDnsZone.NameServers[0]);
                for (int i = 1; i < partnersDnsZone.NameServers.Count(); i++)
                {
                    nsRecordStage = nsRecordStage.WithNameServer(partnersDnsZone.NameServers[i]);
                }
                nsRecordStage
                        .Attach()
                        .Apply();
                Utilities.Log("Root DNS zone updated");
                Utilities.Print(rootDnsZone);

                //============================================================
                // Creates a virtual machine with public IP

                Utilities.Log("Creating a virtual machine with public IP...");
                var virtualMachine2 = azure.VirtualMachines
                        .Define(SdkContext.RandomResourceName("partnersvm-", 20))
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIpAddressDynamic()
                        .WithNewPrimaryPublicIpAddress(SdkContext.RandomResourceName("ptnerpip-", 20))
                        .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WindowsServer2012R2Datacenter)
                        .WithAdminUsername("testuser")
                        .WithAdminPassword("12NewPA$$w0rd!")
                        .WithSize(VirtualMachineSizeTypes.StandardD12V2)
                        .Create();
                Utilities.Log("Virtual machine created");

                //============================================================
                // Update child Dns zone by adding a A record pointing to virtual machine IPv4 address

                var vm2PublicIpAddress = virtualMachine2.GetPrimaryPublicIpAddress();
                Utilities.Log("Updating child DNS zone " + partnerSubDomainName + "...");
                partnersDnsZone = partnersDnsZone.Update()
                        .DefineARecordSet("@")
                            .WithIpv4Address(vm2PublicIpAddress.IpAddress)
                            .Attach()
                        .Apply();
                Utilities.Log("Updated child DNS zone " + partnersDnsZone.Name);
                Utilities.Print(partnersDnsZone);

                //============================================================
                // Removes A record entry from the root DNS zone

                Utilities.Log("Removing A Record from root DNS zone " + rootDnsZone.Name + "...");
                rootDnsZone = rootDnsZone.Update()
                        .WithoutARecordSet("employees")
                        .Apply();
                Utilities.Log("Removed A Record from root DNS zone");
                Utilities.Print(rootDnsZone);

                //============================================================
                // Deletes the Dns zone

                Utilities.Log("Deleting child DNS zone " + partnersDnsZone.Name + "...");
                azure.DnsZones.DeleteById(partnersDnsZone.Id);
                Utilities.Log("Deleted child DNS zone " + partnersDnsZone.Name);
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.DeleteByName(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
                }
                catch (Exception)
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
    }
}
