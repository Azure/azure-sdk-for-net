// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Linq;
using System.Threading;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.AppService.Fluent.Models;
using System.Diagnostics;
using System.IO;
using System.Net.Http;

namespace ManageDns
{
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
    public class Program
    {
        private static readonly string customDomainName = "THE CUSTOM DOMAIN THAT YOU OWN (e.g. contoso.com)";
        private static readonly string rgName = ResourceNamer.RandomResourceName("rgNEMV_", 24);
        private static readonly string appServicePlanName = ResourceNamer.RandomResourceName("jplan1_", 15);
        private static readonly string webAppName = ResourceNamer.RandomResourceName("webapp1-", 20);

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
                    var resourceGroup = azure.ResourceGroups.Define(rgName)
                        .WithRegion(Region.US_WEST)
                        .Create();

                    //============================================================
                    // Creates root DNS Zone

                    Console.WriteLine("Creating root DNS zone " + customDomainName + "...");
                    var rootDnsZone = azure.DnsZones.Define(customDomainName)
                        .WithExistingResourceGroup(resourceGroup)
                        .Create();
                    Console.WriteLine("Created root DNS zone " + rootDnsZone.Name);
                    Utilities.Print(rootDnsZone);

                    //============================================================
                    // Sets NS records in the parent zone (hosting custom domain) to make Azure DNS the authoritative
                    // source for name resolution for the zone

                    Console.WriteLine("Go to your registrar portal and configure your domain " + customDomainName
                            + " with following name server addresses");
                    foreach (var nameServer in rootDnsZone.NameServers)
                    {
                        Console.WriteLine(" " + nameServer);
                    }
                    Console.WriteLine("Press a key after finishing above step");
                    Console.ReadKey();

                    //============================================================
                    // Creates a web App

                    Console.WriteLine("Creating Web App " + webAppName + "...");
                    var webApp = azure.WebApps.Define(webAppName)
                            .WithExistingResourceGroup(rgName)
                            .WithNewAppServicePlan(appServicePlanName)
                            .WithRegion(Region.US_EAST2)
                            .WithPricingTier(AppServicePricingTier.Basic_B1)
                            .DefineSourceControl()
                                .WithPublicGitRepository("https://github.com/jianghaolu/azure-site-test")
                                .WithBranch("master")
                                .Attach()
                            .Create();
                    Console.WriteLine("Created web app " + webAppName);
                    Utilities.Print(webApp);

                    //============================================================
                    // Creates a CName record and bind it with the web app

                    // Step 1: Adds CName Dns record to root DNS zone that specify web app host domain as an
                    // alias for www.[customDomainName]

                    Console.WriteLine("Updating DNS zone by adding a CName record...");
                    rootDnsZone = rootDnsZone.Update()
                            .WithCnameRecordSet("www", webApp.DefaultHostName)
                            .Apply();
                    Console.WriteLine("DNS zone updated");
                    Utilities.Print(rootDnsZone);

                    // Waiting for a minute for DNS CName entry to propagate
                    Console.WriteLine("Waiting a minute for CName record entry to propagate...");
                    Thread.Sleep(60 * 1000);

                    // Step 2: Adds a web app host name binding for www.[customDomainName]
                    //         This binding action will fail if the CName record propagation is not yet completed

                    Console.WriteLine("Updating Web app with host name binding...");
                    webApp.Update()
                            .DefineHostnameBinding()
                                .WithThirdPartyDomain(customDomainName)
                                .WithSubDomain("www")
                                .WithDnsRecordType(CustomHostNameDnsRecordType.CName)
                                .Attach()
                            .Apply();
                    Console.WriteLine("Web app updated");
                    Utilities.Print(webApp);



                    //============================================================
                    // Creates a virtual machine with public IP

                    Console.WriteLine("Creating a virtual machine with public IP...");
                    var virtualMachine1 = azure.VirtualMachines
                            .Define(ResourceNamer.RandomResourceName("employeesvm-", 20))
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIpAddressDynamic()
                            .WithNewPrimaryPublicIpAddress(ResourceNamer.RandomResourceName("empip-", 20))
                            .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WINDOWS_SERVER_2012_R2_DATACENTER)
                            .WithAdminUsername("testuser")
                            .WithAdminPassword("12NewPA$$w0rd!")
                            .WithSize(VirtualMachineSizeTypes.StandardD12V2)
                            .Create();
                    Console.WriteLine("Virtual machine created");

                    //============================================================
                    // Update DNS zone by adding a A record in root DNS zone pointing to virtual machine IPv4 address

                    var vm1PublicIpAddress = virtualMachine1.GetPrimaryPublicIpAddress();
                    Console.WriteLine("Updating root DNS zone " + customDomainName + "...");
                    rootDnsZone = rootDnsZone.Update()
                            .DefineARecordSet("employees")
                                .WithIpv4Address(vm1PublicIpAddress.IpAddress)
                                .Attach()
                            .Apply();
                    Console.WriteLine("Updated root DNS zone " + rootDnsZone.Name);
                    Utilities.Print(rootDnsZone);

                    // Prints the CName and A Records in the root DNS zone
                    //
                    Console.WriteLine("Getting CName record set in the root DNS zone " + customDomainName + "...");
                    var cnameRecordSets = rootDnsZone
                            .CnameRecordSets
                            .List();

                    foreach (var cnameRecordSet in cnameRecordSets)
                    {
                        Console.WriteLine("Name: " + cnameRecordSet.Name + " Canonical Name: " + cnameRecordSet.CanonicalName);
                    }

                    Console.WriteLine("Getting ARecord record set in the root DNS zone " + customDomainName + "...");
                    var aRecordSets = rootDnsZone
                            .ARecordSets
                            .List();

                    foreach (var aRecordSet in aRecordSets)
                    {
                        Console.WriteLine("Name: " + aRecordSet.Name);
                        foreach (var ipv4Address in aRecordSet.Ipv4Addresses)
                        {
                            Console.WriteLine("  " + ipv4Address);
                        }
                    }

                    //============================================================
                    // Creates a child DNS zone

                    var partnerSubDomainName = "partners." + customDomainName;
                    Console.WriteLine("Creating child DNS zone " + partnerSubDomainName + "...");
                    var partnersDnsZone = azure.DnsZones
                            .Define(partnerSubDomainName)
                            .WithExistingResourceGroup(resourceGroup)
                            .Create();
                    Console.WriteLine("Created child DNS zone " + partnersDnsZone.Name);
                    Utilities.Print(partnersDnsZone);

                    //============================================================
                    // Adds NS records in the root dns zone to delegate partners.[customDomainName] to child dns zone

                    Console.WriteLine("Updating root DNS zone " + rootDnsZone + "...");
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
                    Console.WriteLine("Root DNS zone updated");
                    Utilities.Print(rootDnsZone);

                    //============================================================
                    // Creates a virtual machine with public IP

                    Console.WriteLine("Creating a virtual machine with public IP...");
                    var virtualMachine2 = azure.VirtualMachines
                            .Define(ResourceNamer.RandomResourceName("partnersvm-", 20))
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithNewPrimaryNetwork("10.0.0.0/28")
                            .WithPrimaryPrivateIpAddressDynamic()
                            .WithNewPrimaryPublicIpAddress(ResourceNamer.RandomResourceName("ptnerpip-", 20))
                            .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WINDOWS_SERVER_2012_R2_DATACENTER)
                            .WithAdminUsername("testuser")
                            .WithAdminPassword("12NewPA$$w0rd!")
                            .WithSize(VirtualMachineSizeTypes.StandardD12V2)
                            .Create();
                    Console.WriteLine("Virtual machine created");

                    //============================================================
                    // Update child Dns zone by adding a A record pointing to virtual machine IPv4 address

                    var vm2PublicIpAddress = virtualMachine2.GetPrimaryPublicIpAddress();
                    Console.WriteLine("Updating child DNS zone " + partnerSubDomainName + "...");
                    partnersDnsZone = partnersDnsZone.Update()
                            .DefineARecordSet("@")
                                .WithIpv4Address(vm2PublicIpAddress.IpAddress)
                                .Attach()
                            .Apply();
                    Console.WriteLine("Updated child DNS zone " + partnersDnsZone.Name);
                    Utilities.Print(partnersDnsZone);

                    //============================================================
                    // Removes A record entry from the root DNS zone

                    Console.WriteLine("Removing A Record from root DNS zone " + rootDnsZone.Name + "...");
                    rootDnsZone = rootDnsZone.Update()
                            .WithoutARecordSet("employees")
                            .Apply();
                    Console.WriteLine("Removed A Record from root DNS zone");
                    Utilities.Print(rootDnsZone);

                    //============================================================
                    // Deletes the Dns zone

                    Console.WriteLine("Deleting child DNS zone " + partnersDnsZone.Name + "...");
                    azure.DnsZones.DeleteById(partnersDnsZone.Id);
                    Console.WriteLine("Deleted child DNS zone " + partnersDnsZone.Name);
                }
                catch (Exception f)
                {
                    Console.WriteLine(f);
                }
                finally
                {
                    try
                    {
                        Console.WriteLine("Deleting Resource Group: " + rgName);
                        azure.ResourceGroups.DeleteByName(rgName);
                        Console.WriteLine("Deleted Resource Group: " + rgName);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Did not create any resources in Azure. No clean up is necessary");
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
