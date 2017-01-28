// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ManageApplicationGateway
{
    public class Program
    {
        private static readonly string UserName = "tirekicker";
        private static readonly string SshKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQCfSPC2K7LZcFKEO+/t3dzmQYtrJFZNxOsbVgOVKietqHyvmYGHEC0J2wPdAqQ/63g/hhAEFRoyehM+rbeDri4txB3YFfnOK58jqdkyXzupWqXzOrlKY4Wz9SKjjN765+dqUITjKRIaAip1Ri137szRg71WnrmdP3SphTRlCx1Bk2nXqWPsclbRDCiZeF8QOTi4JqbmJyK5+0UqhqYRduun8ylAwKKQJ1NJt85sYIHn9f1Rfr6Tq2zS0wZ7DHbZL+zB5rSlAr8QyUdg/GQD+cmSs6LvPJKL78d6hMGk84ARtFo4A79ovwX/Fj01znDQkU6nJildfkaolH2rWFG/qttD azjava@javalib.Com";
        private static readonly string SslCertificatePfxPath = "myTest._pfx"; // Relative to project root directory by default
        private static readonly string SslCertificatePfxPath2 = "myTest2._pfx"; // Relative to project root directory by default
        private const int BackendPools = 2;
        private const int VMCountInAPool = 4;

        private static List<Region> Regions = new List<Region>(){ Region.USEast, Region.UKWest };
        private static List<string> AddressSpaces = new List<string>(){ "172.16.0.0/16", "172.17.0.0/16" };
        private static string[,] PublicIpCreatableKeys = new string[BackendPools, VMCountInAPool];
        private static string[,] IPAddresses = new string[BackendPools,VMCountInAPool];

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
        public static void RunSample(IAzure azure)
        {
            string rgName = SdkContext.RandomResourceName("rgNEAG", 15);
            string pipName = SdkContext.RandomResourceName("pip" + "-", 18);

            try
            {

                //=============================================================
                // Create a resource group (Where all resources get created)
                //
                var resourceGroup = azure.ResourceGroups
                        .Define(rgName)
                        .WithRegion(Region.USEast)
                        .Create();

                Utilities.Log("Created a new resource group - " + resourceGroup.Id);

                //=============================================================
                // Create a public IP address for the Application Gateway
                Utilities.Log("Creating a public IP address for the application gateway ...");

                var publicIpAddress = azure.PublicIpAddresses.Define(pipName)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(rgName)
                        .Create().Refresh();

                Utilities.Log("Created a public IP address");

                // Print the public IP details
                Utilities.PrintIpAddress(publicIpAddress);

                //=============================================================
                // Create backend pools

                // Prepare a batch of Creatable definitions
                var creatableVirtualMachines = new List<ICreatable<IVirtualMachine>>();

                for (var i = 0; i < BackendPools; i++)
                {
                    //=============================================================
                    // Create 1 network creatable per region
                    // Prepare Creatable Network definition (Where all the virtual machines get added to)
                    var networkName = SdkContext.RandomResourceName("vnetNEAG-", 20);

                    var networkCreatable = azure.Networks
                            .Define(networkName)
                            .WithRegion(Regions[i])
                            .WithExistingResourceGroup(resourceGroup)
                            .WithAddressSpace(AddressSpaces[i]);

                    //=============================================================
                    // Create 1 storage creatable per region (For storing VMs disk)
                    var storageAccountName = SdkContext.RandomResourceName("stgneag", 20);
                    var storageAccountCreatable = azure.StorageAccounts
                            .Define(storageAccountName)
                            .WithRegion(Regions[i])
                            .WithExistingResourceGroup(resourceGroup);

                    var linuxVMNamePrefix = SdkContext.RandomResourceName("vm-", 15);

                    for (int j = 0; j < VMCountInAPool; j++)
                    {
                        //=============================================================
                        // Create 1 public IP address creatable
                        var publicIpAddressCreatable = azure.PublicIpAddresses
                                .Define(string.Format("{0}-{1}", linuxVMNamePrefix, j))
                                .WithRegion(Regions[i])
                                .WithExistingResourceGroup(resourceGroup)
                                .WithLeafDomainLabel(string.Format("{0}-{1}", linuxVMNamePrefix, j));

                        PublicIpCreatableKeys[i, j] = publicIpAddressCreatable.Key;

                        //=============================================================
                        // Create 1 virtual machine creatable
                        var virtualMachineCreatable = azure.VirtualMachines.Define(string.Format("{0}-{1}", linuxVMNamePrefix, j))
                                .WithRegion(Regions[i])
                                .WithExistingResourceGroup(resourceGroup)
                                .WithNewPrimaryNetwork(networkCreatable)
                                .WithPrimaryPrivateIpAddressDynamic()
                                .WithNewPrimaryPublicIpAddress(publicIpAddressCreatable)
                                .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                                .WithRootUsername(UserName)
                                .WithSsh(SshKey)
                                .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                                .WithNewStorageAccount(storageAccountCreatable);
                        creatableVirtualMachines.Add(virtualMachineCreatable);
                    }
                }


                //=============================================================
                // Create two backend pools of virtual machines

                Stopwatch t = Stopwatch.StartNew();
                Utilities.Log("Creating virtual machines (two backend pools)");

                var virtualMachines = azure.VirtualMachines.Create(creatableVirtualMachines.ToArray());

                t.Stop();
                Utilities.Log("Created virtual machines (two backend pools)");

                foreach (var virtualMachine in virtualMachines)
                {
                    Utilities.Log(virtualMachine.Id);
                }

                Utilities.Log("Virtual machines created: (took " + (t.ElapsedMilliseconds / 1000) + " seconds) to create == " + virtualMachines.Count()
                        + " == virtual machines (4 virtual machines per backend pool)");


                //=======================================================================
                // Get IP addresses from created resources

                Utilities.Log("IP Addresses in the backend pools are - ");
                for (var i = 0; i < BackendPools; i++)
                {
                    for (var j = 0; j < VMCountInAPool; j++)
                    {
                        var pip = (IPublicIpAddress)virtualMachines
                                .CreatedRelatedResource(PublicIpCreatableKeys[i, j]);
                        pip.Refresh();
                        IPAddresses[i, j] = pip.IpAddress;
                        Utilities.Log("[backend pool ="
                           + i
                           + "][vm = "
                           + j
                           + "] = "
                           + IPAddresses[i, j]);
                    }

                    Utilities.Log("======");
                }

                //=======================================================================
                // Create an application gateway

                Utilities.Log("================= CREATE ======================");
                Utilities.Log("Creating an application gateway... (this can take about 20 min)");
                t = Stopwatch.StartNew();

                IApplicationGateway applicationGateway = azure.ApplicationGateways.Define("myFirstAppGateway")
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(resourceGroup)
                        
                        // Request routing rule for HTTP from public 80 to public 8080
                        .DefineRequestRoutingRule("HTTP-80-to-8080")
                            .FromPublicFrontend()
                            .FromFrontendHttpPort(80)
                            .ToBackendHttpPort(8080)
                            .ToBackendIpAddress(IPAddresses[0, 0])
                            .ToBackendIpAddress(IPAddresses[0, 1])
                            .ToBackendIpAddress(IPAddresses[0, 2])
                            .ToBackendIpAddress(IPAddresses[0, 3])
                            .Attach()
                        
                            // Request routing rule for HTTPS from public 443 to public 8080
                        .DefineRequestRoutingRule("HTTPs-443-to-8080")
                            .FromPublicFrontend()
                            .FromFrontendHttpsPort(443)
                            .WithSslCertificateFromPfxFile(new FileInfo(SslCertificatePfxPath))
                            .WithSslCertificatePassword("Abc123")
                            .ToBackendHttpPort(8080)
                            .ToBackendIpAddress(IPAddresses[1, 0])
                            .ToBackendIpAddress(IPAddresses[1, 1])
                            .ToBackendIpAddress(IPAddresses[1, 2])
                            .ToBackendIpAddress(IPAddresses[1, 3])
                            .Attach()
                        .WithExistingPublicIpAddress(publicIpAddress)
                        .Create();

                t.Stop();

                Utilities.Log("Application gateway created: (took " + (t.ElapsedMilliseconds / 1000) + " seconds)");
                Utilities.PrintAppGateway(applicationGateway);


                //=======================================================================
                // Update an application gateway
                // configure the first routing rule for SSL offload

                Utilities.Log("================= UPDATE ======================");
                Utilities.Log("Updating the application gateway");

                t = Stopwatch.StartNew();

                applicationGateway.Update()
                        .WithoutRequestRoutingRule("HTTP-80-to-8080")
                        .DefineRequestRoutingRule("HTTPs-1443-to-8080")
                            .FromPublicFrontend()
                            .FromFrontendHttpsPort(1443)
                            .WithSslCertificateFromPfxFile(new FileInfo(SslCertificatePfxPath2))
                            .WithSslCertificatePassword("Abc123")
                            .ToBackendHttpPort(8080)
                            .ToBackendIpAddress(IPAddresses[0, 0])
                            .ToBackendIpAddress(IPAddresses[0, 1])
                            .ToBackendIpAddress(IPAddresses[0, 2])
                            .ToBackendIpAddress(IPAddresses[0, 3])
                            .WithHostName("www.contoso.com")
                            .WithCookieBasedAffinity()
                            .Attach()
                        .Apply();

                t.Stop();

                Utilities.Log("Application gateway updated: (took " + (t.ElapsedMilliseconds / 1000) + " seconds)");
                Utilities.PrintAppGateway(applicationGateway);
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
                catch (Exception e)
                {
                    Utilities.Log(e.StackTrace);
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
                Utilities.Log(e.Message);
                Utilities.Log(e.StackTrace);
            }
        }
    }
}
