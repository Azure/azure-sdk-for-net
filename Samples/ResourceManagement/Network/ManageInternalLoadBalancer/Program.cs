// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManageInternalLoadBalancer
{
    /**
     * Azure Network sample for managing internal load balancers -
     *
     * High-level ...
     *
     * - Create an internal load balancer that receives network traffic on
     *   port 1521 (Oracle SQL Node Port) and sends load-balanced traffic
     *   to two virtual machines
     *
     * - Create NAT rules for SSH and TELNET access to virtual
     *   machines behind the load balancer
     *
     * - Create a health probe
     *
     * Details ...
     *
     * Create an internal facing load balancer with ...
     * - A frontend private IP address
     * - One backend address pool which contains network interfaces for the virtual
     *   machines to receive 1521 (Oracle SQL Node Port) network traffic from the load balancer
     * - One load balancing rule fto map port 1521 on the load balancer to
     *   ports in the backend address pool
     * - One probe which contains HTTP health probe used to check availability
     *   of virtual machines in the backend address pool
     * - Two inbound NAT rules which contain rules that map a public port on the load
     *   balancer to a port for a specific virtual machine in the backend address pool
     *   - this provides direct VM connectivity for SSH to port 22 and TELNET to port 23
     *
     * Create two network interfaces in the backend subnet ...
     * - And associate network interfaces to backend pools and NAT rules
     *
     * Create two virtual machines in the backend subnet ...
     * - And assign network interfaces
     *
     * Update an existing load balancer, configure TCP idle timeout
     * Create another load balancer
     * List load balancers
     * Remove an existing load balancer.
     */

    public class Program
    {
        private static readonly string rgName = ResourceNamer.RandomResourceName("rgNEML", 15);
        private static readonly string vnetName = ResourceNamer.RandomResourceName("vnet", 24);
        private static readonly string loadBalancerName3 = ResourceNamer.RandomResourceName("intlb3" + "-", 18);
        private static readonly string loadBalancerName4 = ResourceNamer.RandomResourceName("intlb4" + "-", 18);
        private static readonly string privateFrontEndName = loadBalancerName3 + "-BE";
        private static readonly string backendPoolName3 = loadBalancerName3 + "-BAP3";
        private static readonly string httpProbe = "httpProbe";
        private static readonly string tcpLoadBalancingRule = "tcpRule";
        private static readonly string natRule6000to22forVM3 = "nat6000to22forVM3";
        private static readonly string natRule6001to23forVM3 = "nat6001to23forVM3";
        private static readonly string natRule6002to22forVM4 = "nat6002to22forVM4";
        private static readonly string natRule6003to23forVM4 = "nat6003to23forVM4";
        private static readonly string networkInterfaceName3 = ResourceNamer.RandomResourceName("nic3", 24);
        private static readonly string networkInterfaceName4 = ResourceNamer.RandomResourceName("nic4", 24);
        private static readonly string availSetName = ResourceNamer.RandomResourceName("av2", 24);
        private static readonly string vmName3 = ResourceNamer.RandomResourceName("lVM3", 24);
        private static readonly string vmName4 = ResourceNamer.RandomResourceName("lVM4", 24);
        private static readonly string userName = "tirekicker";
        private static readonly string sshKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQCfSPC2K7LZcFKEO+/t3dzmQYtrJFZNxOsbVgOVKietqHyvmYGHEC0J2wPdAqQ/63g/hhAEFRoyehM+rbeDri4txB3YFfnOK58jqdkyXzupWqXzOrlKY4Wz9SKjjN765+dqUITjKRIaAip1Ri137szRg71WnrmdP3SphTRlCx1Bk2nXqWPsclbRDCiZeF8QOTi4JqbmJyK5+0UqhqYRduun8ylAwKKQJ1NJt85sYIHn9f1Rfr6Tq2zS0wZ7DHbZL+zB5rSlAr8QyUdg/GQD+cmSs6LvPJKL78d6hMGk84ARtFo4A79ovwX/Fj01znDQkU6nJildfkaolH2rWFG/qttD azjava@javalib.Com";

        private static readonly int orcaleSQLNodePort = 1521;

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
                    //=============================================================
                    // Create a virtual network with a frontend and a backend subnets
                    Console.WriteLine("Creating virtual network with a frontend and a backend subnets...");

                    var network = azure.Networks.Define(vnetName)
                            .WithRegion(Region.US_EAST)
                            .WithNewResourceGroup(rgName)
                            .WithAddressSpace("172.16.0.0/16")
                            .DefineSubnet("Front-end")
                                .WithAddressPrefix("172.16.1.0/24")
                                .Attach()
                            .DefineSubnet("Back-end")
                                .WithAddressPrefix("172.16.3.0/24")
                                .Attach()
                            .Create();

                    Console.WriteLine("Created a virtual network");
                    // Print the virtual network details
                    Utilities.PrintVirtualNetwork(network);

                    //=============================================================
                    // Create an internal load balancer
                    // Create a frontend IP address
                    // Two backend address pools which contain network interfaces for the virtual
                    //  machines to receive HTTP and HTTPS network traffic from the load balancer
                    // Two load balancing rules for HTTP and HTTPS to map public ports on the load
                    //  balancer to ports in the backend address pool
                    // Two probes which contain HTTP and HTTPS health probes used to check availability
                    //  of virtual machines in the backend address pool
                    // Two inbound NAT rules which contain rules that map a public port on the load
                    //  balancer to a port for a specific virtual machine in the backend address pool
                    //  - this provides direct VM connectivity for SSH to port 22 and TELNET to port 23

                    Console.WriteLine("Creating an internal facing load balancer with ...");
                    Console.WriteLine("- A private IP address");
                    Console.WriteLine("- One backend address pool which contain network interfaces for the virtual\n"
                            + "  machines to receive 1521 network traffic from the load balancer");
                    Console.WriteLine("- One load balancing rules for 1521 to map public ports on the load\n"
                            + "  balancer to ports in the backend address pool");
                    Console.WriteLine("- One probe which contains HTTP health probe used to check availability\n"
                            + "  of virtual machines in the backend address pool");
                    Console.WriteLine("- Two inbound NAT rules which contain rules that map a port on the load\n"
                            + "  balancer to a port for a specific virtual machine in the backend address pool\n"
                            + "  - this provides direct VM connectivity for SSH to port 22 and TELNET to port 23");

                    var loadBalancer3 = azure.LoadBalancers
                            .Define(loadBalancerName3)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(rgName)
                            .DefinePrivateFrontend(privateFrontEndName)
                                .WithExistingSubnet(network, "Back-end")
                                .WithPrivateIpAddressStatic("172.16.3.5")
                                .Attach()
                            // Add one backend - one per rule
                            .DefineBackend(backendPoolName3)
                                .Attach()
                            // Add one probes - one per rule
                            .DefineHttpProbe("httpProbe")
                                .WithRequestPath("/")
                                .Attach()
                            // Add one rule that uses above backend and probe
                            .DefineLoadBalancingRule(tcpLoadBalancingRule)
                                .WithProtocol(TransportProtocol.Tcp)
                                .WithFrontend(privateFrontEndName)
                                .WithFrontendPort(orcaleSQLNodePort)
                                .WithProbe(httpProbe)
                                .WithBackend(backendPoolName3)
                                .Attach()
                            // Add two nat pools to enable direct VM connectivity for
                            //  SSH to port 22 and TELNET to port 23
                            .DefineInboundNatRule(natRule6000to22forVM3)
                                .WithProtocol(TransportProtocol.Tcp)
                                .WithFrontend(privateFrontEndName)
                                .WithFrontendPort(6000)
                                .WithBackendPort(22)
                                .Attach()
                            .DefineInboundNatRule(natRule6001to23forVM3)
                                .WithProtocol(TransportProtocol.Tcp)
                                .WithFrontend(privateFrontEndName)
                                .WithFrontendPort(6001)
                                .WithBackendPort(23)
                                .Attach()
                            .DefineInboundNatRule(natRule6002to22forVM4)
                                .WithProtocol(TransportProtocol.Tcp)
                                .WithFrontend(privateFrontEndName)
                                .WithFrontendPort(6002)
                                .WithBackendPort(22)
                                .Attach()
                            .DefineInboundNatRule(natRule6003to23forVM4)
                                .WithProtocol(TransportProtocol.Tcp)
                                .WithFrontend(privateFrontEndName)
                                .WithFrontendPort(6003)
                                .WithBackendPort(23)
                                .Attach()
                            .Create();

                    // Print load balancer details
                    Console.WriteLine("Created an internal load balancer");
                    Utilities.PrintLoadBalancer(loadBalancer3);

                    //=============================================================
                    // Create two network interfaces in the backend subnet
                    //  associate network interfaces to NAT rules, backend pools

                    Console.WriteLine("Creating two network interfaces in the backend subnet ...");
                    Console.WriteLine("- And associating network interfaces to backend pools and NAT rules");

                    var networkInterfaceCreatables2 = new List<ICreatable<INetworkInterface>>();

                    ICreatable<INetworkInterface> networkInterface3Creatable;
                    ICreatable<INetworkInterface> networkInterface4Creatable;

                    networkInterface3Creatable = azure.NetworkInterfaces
                            .Define(networkInterfaceName3)
                            .WithRegion(Region.US_EAST)
                            .WithNewResourceGroup(rgName)
                            .WithExistingPrimaryNetwork(network)
                            .WithSubnet("Back-end")
                            .WithPrimaryPrivateIpAddressDynamic()
                            .WithExistingLoadBalancerBackend(loadBalancer3, backendPoolName3)
                            .WithExistingLoadBalancerInboundNatRule(loadBalancer3, natRule6000to22forVM3)
                            .WithExistingLoadBalancerInboundNatRule(loadBalancer3, natRule6001to23forVM3);

                    networkInterfaceCreatables2.Add(networkInterface3Creatable);

                    networkInterface4Creatable = azure.NetworkInterfaces
                            .Define(networkInterfaceName4)
                            .WithRegion(Region.US_EAST)
                            .WithNewResourceGroup(rgName)
                            .WithExistingPrimaryNetwork(network)
                            .WithSubnet("Back-end")
                            .WithPrimaryPrivateIpAddressDynamic()
                            .WithExistingLoadBalancerBackend(loadBalancer3, backendPoolName3)
                            .WithExistingLoadBalancerInboundNatRule(loadBalancer3, natRule6002to22forVM4)
                            .WithExistingLoadBalancerInboundNatRule(loadBalancer3, natRule6003to23forVM4);

                    networkInterfaceCreatables2.Add(networkInterface4Creatable);

                    var networkInterfaces2 = azure.NetworkInterfaces.Create(networkInterfaceCreatables2.ToArray());

                    // Print network interface details
                    Console.WriteLine("Created two network interfaces");
                    Console.WriteLine("Network Interface THREE -");
                    Utilities.PrintNetworkInterface(networkInterfaces2.ElementAt(0));
                    Console.WriteLine();
                    Console.WriteLine("Network Interface FOUR -");
                    Utilities.PrintNetworkInterface(networkInterfaces2.ElementAt(1));

                    //=============================================================
                    // Create an availability set

                    Console.WriteLine("Creating an availability set ...");

                    var availSet2 = azure.AvailabilitySets.Define(availSetName)
                            .WithRegion(Region.US_EAST)
                            .WithNewResourceGroup(rgName)
                            .WithFaultDomainCount(2)
                            .WithUpdateDomainCount(4)
                            .Create();

                    Console.WriteLine("Created first availability set: " + availSet2.Id);
                    Utilities.PrintAvailabilitySet(availSet2);

                    //=============================================================
                    // Create two virtual machines and assign network interfaces

                    Console.WriteLine("Creating two virtual machines in the frontend subnet ...");
                    Console.WriteLine("- And assigning network interfaces");

                    var virtualMachineCreatables2 = new List<ICreatable<IVirtualMachine>>();
                    ICreatable<IVirtualMachine> virtualMachine3Creatable;
                    ICreatable<IVirtualMachine> virtualMachine4Creatable;

                    virtualMachine3Creatable = azure.VirtualMachines
                            .Define(vmName3)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(rgName)
                            .WithExistingPrimaryNetworkInterface(networkInterfaces2.ElementAt(0))
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UBUNTU_SERVER_16_04_LTS)
                            .WithRootUsername(userName)
                            .WithSsh(sshKey)
                            .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                            .WithExistingAvailabilitySet(availSet2);

                    virtualMachineCreatables2.Add(virtualMachine3Creatable);

                    virtualMachine4Creatable = azure.VirtualMachines
                            .Define(vmName4)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(rgName)
                            .WithExistingPrimaryNetworkInterface(networkInterfaces2.ElementAt(1))
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UBUNTU_SERVER_16_04_LTS)
                            .WithRootUsername(userName)
                            .WithSsh(sshKey)
                            .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                            .WithExistingAvailabilitySet(availSet2);

                    virtualMachineCreatables2.Add(virtualMachine4Creatable);

                    var t1 = DateTime.UtcNow;
                    var virtualMachines = azure.VirtualMachines.Create(virtualMachineCreatables2.ToArray());

                    var t2 = DateTime.UtcNow;
                    Console.WriteLine($"Created 2 Linux VMs: (took {(t2 - t1).TotalSeconds} seconds)");
                    Console.WriteLine();

                    // Print virtual machine details
                    Console.WriteLine("Virtual Machine THREE -");
                    Utilities.PrintVirtualMachine(virtualMachines.ElementAt(0));
                    Console.WriteLine();
                    Console.WriteLine("Virtual Machine FOUR - ");
                    Utilities.PrintVirtualMachine(virtualMachines.ElementAt(1));

                    //=============================================================
                    // Update a load balancer
                    //  configure TCP idle timeout to 15 minutes

                    Console.WriteLine("Updating the load balancer ...");

                    loadBalancer3.Update()
                            .UpdateLoadBalancingRule(tcpLoadBalancingRule)
                                .WithIdleTimeoutInMinutes(15)
                                .Parent()
                                .Apply();

                    Console.WriteLine("Update the load balancer with a TCP idle timeout to 15 minutes");

                    //=============================================================
                    // Create another internal load balancer
                    // Create a frontend IP address
                    // Two backend address pools which contain network interfaces for the virtual
                    //  machines to receive HTTP and HTTPS network traffic from the load balancer
                    // Two load balancing rules for HTTP and HTTPS to map public ports on the load
                    //  balancer to ports in the backend address pool
                    // Two probes which contain HTTP and HTTPS health probes used to check availability
                    //  of virtual machines in the backend address pool
                    // Two inbound NAT rules which contain rules that map a public port on the load
                    //  balancer to a port for a specific virtual machine in the backend address pool
                    //  - this provides direct VM connectivity for SSH to port 22 and TELNET to port 23

                    Console.WriteLine("Creating another internal facing load balancer with ...");
                    Console.WriteLine("- A private IP address");
                    Console.WriteLine("- One backend address pool which contain network interfaces for the virtual\n"
                            + "  machines to receive 1521 network traffic from the load balancer");
                    Console.WriteLine("- One load balancing rules for 1521 to map public ports on the load\n"
                            + "  balancer to ports in the backend address pool");
                    Console.WriteLine("- One probe which contains HTTP health probe used to check availability\n"
                            + "  of virtual machines in the backend address pool");
                    Console.WriteLine("- Two inbound NAT rules which contain rules that map a port on the load\n"
                            + "  balancer to a port for a specific virtual machine in the backend address pool\n"
                            + "  - this provides direct VM connectivity for SSH to port 22 and TELNET to port 23");

                    var loadBalancer4 = azure.LoadBalancers
                            .Define(loadBalancerName4)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(rgName)
                            .DefinePrivateFrontend(privateFrontEndName)
                            .WithExistingSubnet(network, "Back-end")
                                .WithPrivateIpAddressStatic("172.16.3.15")
                                .Attach()
                            // Add one backend - one per rule
                            .DefineBackend(backendPoolName3)
                                .Attach()
                            // Add one probes - one per rule
                            .DefineHttpProbe("httpProbe")
                                .WithRequestPath("/")
                                .Attach()
                            // Add one rule that uses above backend and probe
                            .DefineLoadBalancingRule(tcpLoadBalancingRule)
                                .WithProtocol(TransportProtocol.Tcp)
                                .WithFrontend(privateFrontEndName)
                                .WithFrontendPort(orcaleSQLNodePort)
                                .WithProbe(httpProbe)
                                .WithBackend(backendPoolName3)
                                .Attach()
                            // Add two nat pools to enable direct VM connectivity for
                            //  SSH to port 22 and TELNET to port 23
                            .DefineInboundNatRule(natRule6000to22forVM3)
                            .WithProtocol(TransportProtocol.Tcp)
                                .WithFrontend(privateFrontEndName)
                                .WithFrontendPort(6000)
                                .WithBackendPort(22)
                                .Attach()
                            .DefineInboundNatRule(natRule6001to23forVM3)
                                .WithProtocol(TransportProtocol.Tcp)
                                .WithFrontend(privateFrontEndName)
                                .WithFrontendPort(6001)
                                .WithBackendPort(23)
                                .Attach()
                            .DefineInboundNatRule(natRule6002to22forVM4)
                                .WithProtocol(TransportProtocol.Tcp)
                                .WithFrontend(privateFrontEndName)
                                .WithFrontendPort(6002)
                                .WithBackendPort(22)
                                .Attach()
                            .DefineInboundNatRule(natRule6003to23forVM4)
                                .WithProtocol(TransportProtocol.Tcp)
                                .WithFrontend(privateFrontEndName)
                                .WithFrontendPort(6003)
                                .WithBackendPort(23)
                                .Attach()
                            .Create();

                    // Print load balancer details
                    Console.WriteLine("Created an internal load balancer");
                    Utilities.PrintLoadBalancer(loadBalancer4);

                    //=============================================================
                    // List load balancers

                    var loadBalancers = azure.LoadBalancers.List();

                    Console.WriteLine("Walking through the list of load balancers");

                    foreach (var loadBalancer in loadBalancers)
                    {
                        Utilities.PrintLoadBalancer(loadBalancer);
                    }

                    //=============================================================
                    // Remove a load balancer

                    Console.WriteLine("Deleting load balancer " + loadBalancerName4
                            + "(" + loadBalancer4.Id + ")");
                    azure.LoadBalancers.DeleteById(loadBalancer4.Id);
                    Console.WriteLine("Deleted load balancer" + loadBalancerName4);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
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