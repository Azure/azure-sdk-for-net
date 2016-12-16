// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
using Microsoft.Azure.Management.Samples.Common;
using System.IO;
using System.Diagnostics;

namespace ManageApplicationGateway
{
    /**
     * Azure network sample for managing application gateways.
     *
     *  - CREATE an application gateway for load balancing
     *    HTTP/HTTPS requests to backend server pools of virtual machines
     *
     *    This application gateway serves traffic for multiple
     *    domain names
     *
     *    Routing Rule 1
     *    Hostname 1 = None
     *    Backend server pool 1 = 4 virtual machines with IP addresses
     *    Backend server pool 1 settings = HTTP:8080
     *    Front end port 1 = HTTP:80
     *    Listener 1 = HTTP
     *    Routing rule 1 = HTTP listener 1 => backend server pool 1
     *    (round-robin load distribution)
     *
     *    Routing Rule 2
     *    Hostname 2 = None
     *    Backend server pool 2 = 4 virtual machines with IP addresses
     *    Backend server pool 2 settings = HTTP:8080
     *    Front end port 2 = HTTPS:443
     *    Listener 2 = HTTPS
     *    Routing rule 2 = HTTPS listener 2 => backend server pool 2
     *    (round-robin load distribution)
     *
     *  - MODIFY the application gateway - re-configure the Routing Rule 1 for SSL offload &
     *    add a host name, www.Contoso.Com
     *
     *    Change listener 1 from HTTP to HTTPS
     *    Add SSL certificate to the listener
     *    Update front end port 1 to HTTPS:1443
     *    Add a host name, www.Contoso.Com
     *    Enable cookie-based affinity
     *
     *    Modified Routing Rule 1
     *    Hostname 1 = www.Contoso.Com
     *    Backend server pool 1 = 4 virtual machines with IP addresses
     *    Backend server pool 1 settings = HTTP:8080
     *    Front end port 1 = HTTPS:1443
     *    Listener 1 = HTTPS
     *    Routing rule 1 = HTTPS listener 1 => backend server pool 1
     *    (round-robin load distribution)
     *
     */
    public class Program
    {
        private static readonly string rgName = ResourceNamer.RandomResourceName("rgNEAG", 15);
        private static readonly string pipName = ResourceNamer.RandomResourceName("pip" + "-", 18);
        private static readonly string userName = "tirekicker";
        private static readonly string sshKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQCfSPC2K7LZcFKEO+/t3dzmQYtrJFZNxOsbVgOVKietqHyvmYGHEC0J2wPdAqQ/63g/hhAEFRoyehM+rbeDri4txB3YFfnOK58jqdkyXzupWqXzOrlKY4Wz9SKjjN765+dqUITjKRIaAip1Ri137szRg71WnrmdP3SphTRlCx1Bk2nXqWPsclbRDCiZeF8QOTi4JqbmJyK5+0UqhqYRduun8ylAwKKQJ1NJt85sYIHn9f1Rfr6Tq2zS0wZ7DHbZL+zB5rSlAr8QyUdg/GQD+cmSs6LvPJKL78d6hMGk84ARtFo4A79ovwX/Fj01znDQkU6nJildfkaolH2rWFG/qttD azjava@javalib.Com";
        private static readonly string sslCertificatePfxPath = "myTest._pfx"; // Relative to project root directory by default
        private static readonly string sslCertificatePfxPath2 = "myTest2._pfx"; // Relative to project root directory by default
        private const int backendPools = 2;
        private const int vmCountInAPool = 4;

        private static List<Region> regions = new List<Region>(){ Region.US_EAST, Region.UK_WEST };
        private static List<string> addressSpaces = new List<string>(){ "172.16.0.0/16", "172.17.0.0/16" };
        private static string[,] publicIpCreatableKeys = new string[backendPools, vmCountInAPool];
        private static string[,] ipAddresses = new string[backendPools,vmCountInAPool];
        public static void Main(string[] args)
        {
            try
            {
                Stopwatch t;

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

                    //=============================================================
                    // Create a resource group (Where all resources gets created)
                    //
                    var resourceGroup = azure.ResourceGroups
                            .Define(rgName)
                            .WithRegion(Region.US_EAST)
                            .Create();

                    Console.WriteLine("Created a new resource group - " + resourceGroup.Id);

                    //=============================================================
                    // Create a public IP address for the Application Gateway
                    Console.WriteLine("Creating a public IP address for the application gateway ...");

                    var publicIpAddress = azure.PublicIpAddresses.Define(pipName)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(rgName)
                            .Create().Refresh();

                    Console.WriteLine("Created a public IP address");

                    // Print the virtual network details
                    Utilities.PrintIpAddress(publicIpAddress);

                    //=============================================================
                    // Create backend pools

                    // Prepare a batch of Creatable definitions
                    var creatableVirtualMachines = new List<ICreatable<IVirtualMachine>>();

                    for (var i = 0; i < backendPools; i++)
                    {
                        //=============================================================
                        // Create 1 network creatable per region
                        // Prepare Creatable Network definition (Where all the virtual machines get added to)
                        var networkName = ResourceNamer.RandomResourceName("vnetNEAG-", 20);

                        var networkCreatable = azure.Networks
                                .Define(networkName)
                                .WithRegion(regions[i])
                                .WithExistingResourceGroup(resourceGroup)
                                .WithAddressSpace(addressSpaces[i]);

                        //=============================================================
                        // Create 1 storage creatable per region (For storing VMs disk)
                        var storageAccountName = ResourceNamer.RandomResourceName("stgneag", 20);
                        var storageAccountCreatable = azure.StorageAccounts
                                .Define(storageAccountName)
                                .WithRegion(regions[i])
                                .WithExistingResourceGroup(resourceGroup);

                        var linuxVMNamePrefix = ResourceNamer.RandomResourceName("vm-", 15);

                        for (int j = 0; j < vmCountInAPool; j++)
                        {
                            //=============================================================
                            // Create 1 public IP address creatable
                            var publicIpAddressCreatable = azure.PublicIpAddresses
                                    .Define(string.Format("{0}-{1}", linuxVMNamePrefix, j))
                                    .WithRegion(regions[i])
                                    .WithExistingResourceGroup(resourceGroup)
                                    .WithLeafDomainLabel(string.Format("{0}-{1}", linuxVMNamePrefix, j));

                            publicIpCreatableKeys[i,j] = publicIpAddressCreatable.Key;

                            //=============================================================
                            // Create 1 virtual machine creatable
                            var virtualMachineCreatable = azure.VirtualMachines
                                    .Define(string.Format("{0}-{1}", linuxVMNamePrefix, j))
                                    .WithRegion(regions[i])
                                    .WithExistingResourceGroup(resourceGroup)
                                    .WithNewPrimaryNetwork(networkCreatable)
                                    .WithPrimaryPrivateIpAddressDynamic()
                                    .WithNewPrimaryPublicIpAddress(publicIpAddressCreatable)
                                    .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UBUNTU_SERVER_16_04_LTS)
                                    .WithRootUsername(userName)
                                    .WithSsh(sshKey)
                                    .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                                    .WithNewStorageAccount(storageAccountCreatable);
                            creatableVirtualMachines.Add(virtualMachineCreatable);
                        }
                    }


                    //=============================================================
                    // Create two backend pools of virtual machines

                    t = Stopwatch.StartNew();
                    Console.WriteLine("Creating virtual machines (two backend pools)");

                    var virtualMachines = azure.VirtualMachines.Create(creatableVirtualMachines.ToArray());

                    t.Stop();
                    Console.WriteLine("Created virtual machines (two backend pools)");

                    foreach (var virtualMachine  in  virtualMachines)
                    {
                        Console.WriteLine(virtualMachine.Id);
                    }

                    Console.WriteLine("Virtual machines created: (took " + (t.ElapsedMilliseconds / 1000) + " seconds) to create == " + virtualMachines.Count()
                            + " == virtual machines (4 virtual machines per backend pool)");


                    //=======================================================================
                    // Get IP addresses from created resources

                    Console.WriteLine("IP Addresses in the backend pools are - ");
                    for (var i = 0; i < backendPools; i++)
                    {
                        for (var j = 0; j < vmCountInAPool; j++)
                        {
                            var pip = (IPublicIpAddress)virtualMachines
                                    .CreatedRelatedResource(publicIpCreatableKeys[i,j]);
                            pip.Refresh();
                            ipAddresses[i,j] = pip.IpAddress;
                            Console.WriteLine("[backend pool ="
                               + i
                               + "][vm = "
                               + j
                               + "] = "
                               + ipAddresses[i,j]);
                        }

                        Console.WriteLine("======");
                    }


                    //=======================================================================
                    // Create an application gateway

                    Console.WriteLine("================= CREATE ======================");
                    Console.WriteLine("Creating an application gateway... (this can take about 20 min)");
                    t = Stopwatch.StartNew();

                    var applicationGateway = azure.ApplicationGateways.Define("myFirstAppGateway")
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(resourceGroup)
                            // Request routing rule for HTTP from public 80 to public 8080
                            .DefineRequestRoutingRule("HTTP-80-to-8080")
                                .FromPublicFrontend()
                                .FromFrontendHttpPort(80)
                                .ToBackendHttpPort(8080)
                                .ToBackendIpAddress(ipAddresses[0,0])
                                .ToBackendIpAddress(ipAddresses[0,1])
                                .ToBackendIpAddress(ipAddresses[0,2])
                                .ToBackendIpAddress(ipAddresses[0,3])
                                .Attach()
                            // Request routing rule for HTTPS from public 443 to public 8080
                            .DefineRequestRoutingRule("HTTPs-443-to-8080")
                                .FromPublicFrontend()
                                .FromFrontendHttpsPort(443)
                                .WithSslCertificateFromPfxFile(new FileInfo(sslCertificatePfxPath))
                                .WithSslCertificatePassword("Abc123")
                                .ToBackendHttpPort(8080)
                                .ToBackendIpAddress(ipAddresses[1,0])
                                .ToBackendIpAddress(ipAddresses[1,1])
                                .ToBackendIpAddress(ipAddresses[1,2])
                                .ToBackendIpAddress(ipAddresses[1,3])
                                .Attach()
                            .WithExistingPublicIpAddress(publicIpAddress)
                            .Create();

                    t.Stop();

                    Console.WriteLine("Application gateway created: (took " + (t.ElapsedMilliseconds / 1000) + " seconds)");
                    Utilities.PrintAppGateway(applicationGateway);


                    //=======================================================================
                    // Update an application gateway
                    // configure the first routing rule for SSL offload

                    Console.WriteLine("================= UPDATE ======================");
                    Console.WriteLine("Updating the application gateway");

                    t = Stopwatch.StartNew();

                    applicationGateway.Update()
                            .WithoutRequestRoutingRule("HTTP-80-to-8080")
                            .DefineRequestRoutingRule("HTTPs-1443-to-8080")
                                .FromPublicFrontend()
                                .FromFrontendHttpsPort(1443)
                                .WithSslCertificateFromPfxFile(new FileInfo(sslCertificatePfxPath2))
                                .WithSslCertificatePassword("Abc123")
                                .ToBackendHttpPort(8080)
                                .ToBackendIpAddress(ipAddresses[0,0])
                                .ToBackendIpAddress(ipAddresses[0,1])
                                .ToBackendIpAddress(ipAddresses[0,2])
                                .ToBackendIpAddress(ipAddresses[0,3])
                                .WithHostName("www.contoso.com")
                                .WithCookieBasedAffinity()
                                .Attach()
                            .Apply();

                    t.Stop();

                    Console.WriteLine("Application gateway updated: (took " + (t.ElapsedMilliseconds / 1000) + " seconds)");
                    Utilities.PrintAppGateway(applicationGateway);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
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
                    catch (Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
