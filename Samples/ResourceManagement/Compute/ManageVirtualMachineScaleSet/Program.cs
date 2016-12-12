// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Collections.Generic;

namespace ManageVirtualMachineScaleSet
{
    /**
     * Azure Compute sample for managing virtual machine scale sets -
     *  - Create a virtual machine scale set behind an Internet facing load balancer
     *  - Install Apache Web servers in virtual machines in the virtual machine scale set
     *  - Stop a virtual machine scale set
     *  - Start a virtual machine scale set
     *  - Update a virtual machine scale set
     *    - Double the no. of virtual machines
     *  - Restart a virtual machine scale set
     */

    public class Program
    {
        private readonly static string rgName = ResourceNamer.RandomResourceName("rgCOVS", 15);
        private readonly static string vnetName = ResourceNamer.RandomResourceName("vnet", 24);
        private readonly static string loadBalancerName1 = ResourceNamer.RandomResourceName("intlb" + "-", 18);
        private readonly static string publicIpName = "pip-" + loadBalancerName1;
        private readonly static string frontendName = loadBalancerName1 + "-FE1";
        private readonly static string backendPoolName1 = loadBalancerName1 + "-BAP1";
        private readonly static string backendPoolName2 = loadBalancerName1 + "-BAP2";
        private readonly static string httpProbe = "httpProbe";
        private readonly static string httpsProbe = "httpsProbe";
        private readonly static string httpLoadBalancingRule = "httpRule";
        private readonly static string httpsLoadBalancingRule = "httpsRule";
        private readonly static string natPool50XXto22 = "natPool50XXto22";
        private readonly static string natPool60XXto23 = "natPool60XXto23";
        private readonly static string vmssName = ResourceNamer.RandomResourceName("vmss", 24);
        private readonly static string storageAccountName1 = ResourceNamer.RandomResourceName("stg1", 24);
        private readonly static string storageAccountName2 = ResourceNamer.RandomResourceName("stg2", 24);
        private readonly static string storageAccountName3 = ResourceNamer.RandomResourceName("stg3", 24);
        private readonly static string userName = "tirekicker";
        private readonly static string sshKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQCfSPC2K7LZcFKEO+/t3dzmQYtrJFZNxOsbVgOVKietqHyvmYGHEC0J2wPdAqQ/63g/hhAEFRoyehM+rbeDri4txB3YFfnOK58jqdkyXzupWqXzOrlKY4Wz9SKjjN765+dqUITjKRIaAip1Ri137szRg71WnrmdP3SphTRlCx1Bk2nXqWPsclbRDCiZeF8QOTi4JqbmJyK5+0UqhqYRduun8ylAwKKQJ1NJt85sYIHn9f1Rfr6Tq2zS0wZ7DHbZL+zB5rSlAr8QyUdg/GQD+cmSs6LvPJKL78d6hMGk84ARtFo4A79ovwX/Fj01znDQkU6nJildfkaolH2rWFG/qttD azjava@javalib.Com";
        private readonly static string apacheInstallScript = "https://raw.githubusercontent.com/Azure/azure-sdk-for-net/Fluent/Samples/ResourceManagement/Compute/ManageVirtualMachineScaleSet/Resources/install_apache.sh";
        private readonly static string installCommand = "bash install_apache.sh Abc.123x(";

        public static void Main(string[] args)
        {
            try
            {
                //=============================================================
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
                    // Create a virtual network with a frontend subnet
                    Console.WriteLine("Creating virtual network with a frontend subnet ...");

                    var network = azure.Networks.Define(vnetName)
                            .WithRegion(Region.US_EAST)
                            .WithNewResourceGroup(rgName)
                            .WithAddressSpace("172.16.0.0/16")
                            .DefineSubnet("Front-end")
                                .WithAddressPrefix("172.16.1.0/24")
                                .Attach()
                            .Create();

                    Console.WriteLine("Created a virtual network");
                    // Print the virtual network details
                    Utilities.PrintVirtualNetwork(network);

                    //=============================================================
                    // Create a public IP address
                    Console.WriteLine("Creating a public IP address...");

                    var publicIpAddress = azure.PublicIpAddresses.Define(publicIpName)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(rgName)
                            .WithLeafDomainLabel(publicIpName)
                            .Create();

                    Console.WriteLine("Created a public IP address");
                    // Print the IPAddress details
                    Utilities.PrintIpAddress(publicIpAddress);

                    //=============================================================
                    // Create an Internet facing load balancer with
                    // One frontend IP address
                    // Two backend address pools which contain network interfaces for the virtual
                    //  machines to receive HTTP and HTTPS network traffic from the load balancer
                    // Two load balancing rules for HTTP and HTTPS to map public ports on the load
                    //  balancer to ports in the backend address pool
                    // Two probes which contain HTTP and HTTPS health probes used to check availability
                    //  of virtual machines in the backend address pool
                    // Three inbound NAT rules which contain rules that map a public port on the load
                    //  balancer to a port for a specific virtual machine in the backend address pool
                    //  - this provides direct VM connectivity for SSH to port 22 and TELNET to port 23

                    Console.WriteLine("Creating a Internet facing load balancer with ...");
                    Console.WriteLine("- A frontend IP address");
                    Console.WriteLine("- Two backend address pools which contain network interfaces for the virtual\n"
                            + "  machines to receive HTTP and HTTPS network traffic from the load balancer");
                    Console.WriteLine("- Two load balancing rules for HTTP and HTTPS to map public ports on the load\n"
                            + "  balancer to ports in the backend address pool");
                    Console.WriteLine("- Two probes which contain HTTP and HTTPS health probes used to check availability\n"
                            + "  of virtual machines in the backend address pool");
                    Console.WriteLine("- Two inbound NAT rules which contain rules that map a public port on the load\n"
                            + "  balancer to a port for a specific virtual machine in the backend address pool\n"
                            + "  - this provides direct VM connectivity for SSH to port 22 and TELNET to port 23");

                    var loadBalancer1 = azure.LoadBalancers.Define(loadBalancerName1)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(rgName)
                            .DefinePublicFrontend(frontendName)
                                .WithExistingPublicIpAddress(publicIpAddress)
                                .Attach()
                            // Add two backend one per rule
                            .DefineBackend(backendPoolName1)
                                .Attach()
                            .DefineBackend(backendPoolName2)
                                .Attach()
                            // Add two probes one per rule
                            .DefineHttpProbe(httpProbe)
                                .WithRequestPath("/")
                                .WithPort(80)
                                .Attach()
                            .DefineHttpProbe(httpsProbe)
                                .WithRequestPath("/")
                                .WithPort(443)
                                .Attach()
                            // Add two rules that uses above backend and probe
                            .DefineLoadBalancingRule(httpLoadBalancingRule)
                                .WithProtocol(TransportProtocol.Tcp)
                                .WithFrontend(frontendName)
                                .WithFrontendPort(80)
                                .WithProbe(httpProbe)
                                .WithBackend(backendPoolName1)
                                .Attach()
                            .DefineLoadBalancingRule(httpsLoadBalancingRule)
                                .WithProtocol(TransportProtocol.Tcp)
                                .WithFrontend(frontendName)
                                .WithFrontendPort(443)
                                .WithProbe(httpsProbe)
                                .WithBackend(backendPoolName2)
                                .Attach()
                            // Add nat pools to enable direct VM connectivity for
                            //  SSH to port 22 and TELNET to port 23
                            .DefineInboundNatPool(natPool50XXto22)
                                .WithProtocol(TransportProtocol.Tcp)
                                .WithFrontend(frontendName)
                                .WithFrontendPortRange(5000, 5099)
                                .WithBackendPort(22)
                                .Attach()
                            .DefineInboundNatPool(natPool60XXto23)
                                .WithProtocol(TransportProtocol.Tcp)
                                .WithFrontend(frontendName)
                                .WithFrontendPortRange(6000, 6099)
                                .WithBackendPort(23)
                                .Attach()
                            .Create();

                    // Print load balancer details
                    Console.WriteLine("Created a load balancer");
                    Utilities.PrintLoadBalancer(loadBalancer1);

                    //=============================================================
                    // Create a virtual machine scale set with three virtual machines
                    // And, install Apache Web servers on them

                    Console.WriteLine("Creating virtual machine scale set with three virtual machines"
                            + " in the frontend subnet ...");

                    var t1 = DateTime.UtcNow;

                    var fileUris = new List<string>();
                    fileUris.Add(apacheInstallScript);

                    var virtualMachineScaleSet = azure.VirtualMachineScaleSets
                            .Define(vmssName)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(rgName)
                            .WithSku(VirtualMachineScaleSetSkuTypes.STANDARD_D3_V2)
                            .WithExistingPrimaryNetworkSubnet(network, "Front-end")
                            .WithExistingPrimaryInternetFacingLoadBalancer(loadBalancer1)
                            .WithPrimaryInternetFacingLoadBalancerBackends(backendPoolName1, backendPoolName2)
                            .WithPrimaryInternetFacingLoadBalancerInboundNatPools(natPool50XXto22, natPool60XXto23)
                            .WithoutPrimaryInternalLoadBalancer()
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UBUNTU_SERVER_16_04_LTS)
                            .WithRootUsername(userName)
                            .WithSsh(sshKey)
                            .WithNewStorageAccount(storageAccountName1)
                            .WithNewStorageAccount(storageAccountName2)
                            .WithNewStorageAccount(storageAccountName3)
                            .WithCapacity(3)
                            // Use a VM extension to install Apache Web servers
                            .DefineNewExtension("CustomScriptForLinux")
                                .WithPublisher("Microsoft.OSTCExtensions")
                                .WithType("CustomScriptForLinux")
                                .WithVersion("1.4")
                                .WithMinorVersionAutoUpgrade()
                                .WithPublicSetting("fileUris", fileUris)
                                .WithPublicSetting("commandToExecute", installCommand)
                                .Attach()
                            .Create();

                    var t2 = DateTime.UtcNow;
                    Console.WriteLine("Created a virtual machine scale set with "
                            + "3 Linux VMs & Apache Web servers on them: (took "
                            + ((t2 - t1).TotalSeconds) + " seconds) ");
                    Console.WriteLine();

                    // Print virtual machine scale set details
                    // Utilities.Print(virtualMachineScaleSet);

                    //=============================================================
                    // Stop the virtual machine scale set

                    Console.WriteLine("Stopping virtual machine scale set ...");
                    virtualMachineScaleSet.PowerOff();
                    Console.WriteLine("Stopped virtual machine scale set");

                    //=============================================================
                    // Start the virtual machine scale set

                    Console.WriteLine("Starting virtual machine scale set ...");
                    virtualMachineScaleSet.Start();
                    Console.WriteLine("Started virtual machine scale set");

                    //=============================================================
                    // Update the virtual machine scale set
                    // - double the no. of virtual machines

                    Console.WriteLine("Updating virtual machine scale set "
                            + "- double the no. of virtual machines ...");

                    virtualMachineScaleSet.Update()
                        .WithCapacity(6)
                        .Apply();

                    Console.WriteLine("Doubled the no. of virtual machines in "
                            + "the virtual machine scale set");

                    //=============================================================
                    // re-start virtual machine scale set

                    Console.WriteLine("re-starting virtual machine scale set ...");
                    virtualMachineScaleSet.Restart();
                    Console.WriteLine("re-started virtual machine scale set");
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
                    catch (NullReferenceException npe)
                    {
                        Console.WriteLine("Did not create any resources in Azure. No clean up is necessary");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}