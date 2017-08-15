// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManageInternalLoadBalancer
{
    public class Program
    {
        private static readonly string HttpProbe = "httpProbe";
        private static readonly string TcpLoadBalancingRule = "tcpRule";
        private static readonly string NatRule6000to22forVM3 = "nat6000to22forVM3";
        private static readonly string NatRule6001to23forVM3 = "nat6001to23forVM3";
        private static readonly string NatRule6002to22forVM4 = "nat6002to22forVM4";
        private static readonly string NatRule6003to23forVM4 = "nat6003to23forVM4";
        private static readonly string UserName = "tirekicker";
        private static readonly string SshKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQCfSPC2K7LZcFKEO+/t3dzmQYtrJFZNxOsbVgOVKietqHyvmYGHEC0J2wPdAqQ/63g/hhAEFRoyehM+rbeDri4txB3YFfnOK58jqdkyXzupWqXzOrlKY4Wz9SKjjN765+dqUITjKRIaAip1Ri137szRg71WnrmdP3SphTRlCx1Bk2nXqWPsclbRDCiZeF8QOTi4JqbmJyK5+0UqhqYRduun8ylAwKKQJ1NJt85sYIHn9f1Rfr6Tq2zS0wZ7DHbZL+zB5rSlAr8QyUdg/GQD+cmSs6LvPJKL78d6hMGk84ARtFo4A79ovwX/Fj01znDQkU6nJildfkaolH2rWFG/qttD azjava@javalib.Com";

        private static readonly int OracleSQLNodePort = 1521;

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
        public static void RunSample(IAzure azure)
        {
            string rgName = SdkContext.RandomResourceName("rgNEML", 15);
            string vnetName = SdkContext.RandomResourceName("vnet", 24);
            string loadBalancerName3 = SdkContext.RandomResourceName("intlb3" + "-", 18);
            string loadBalancerName4 = SdkContext.RandomResourceName("intlb4" + "-", 18);
            string privateFrontEndName = loadBalancerName3 + "-BE";
            string backendPoolName3 = loadBalancerName3 + "-BAP3";
            string networkInterfaceName3 = SdkContext.RandomResourceName("nic3", 24);
            string networkInterfaceName4 = SdkContext.RandomResourceName("nic4", 24);
            string availSetName = SdkContext.RandomResourceName("av2", 24);
            string vmName3 = SdkContext.RandomResourceName("lVM3", 24);
            string vmName4 = SdkContext.RandomResourceName("lVM4", 24);

            try
            {
                //=============================================================
                // Create a virtual network with a frontend and a backend subnets
                Utilities.Log("Creating virtual network with a frontend and a backend subnets...");

                var network = azure.Networks.Define(vnetName)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(rgName)
                        .WithAddressSpace("172.16.0.0/16")
                        .DefineSubnet("Front-end")
                            .WithAddressPrefix("172.16.1.0/24")
                            .Attach()
                        .DefineSubnet("Back-end")
                            .WithAddressPrefix("172.16.3.0/24")
                            .Attach()
                        .Create();

                Utilities.Log("Created a virtual network");
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

                Utilities.Log("Creating an internal facing load balancer with ...");
                Utilities.Log("- A private IP address");
                Utilities.Log("- One backend address pool which contain network interfaces for the virtual\n"
                        + "  machines to receive 1521 network traffic from the load balancer");
                Utilities.Log("- One load balancing rules for 1521 to map public ports on the load\n"
                        + "  balancer to ports in the backend address pool");
                Utilities.Log("- One probe which contains HTTP health probe used to check availability\n"
                        + "  of virtual machines in the backend address pool");
                Utilities.Log("- Two inbound NAT rules which contain rules that map a port on the load\n"
                        + "  balancer to a port for a specific virtual machine in the backend address pool\n"
                        + "  - this provides direct VM connectivity for SSH to port 22 and TELNET to port 23");

                var loadBalancer3 = azure.LoadBalancers.Define(loadBalancerName3)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(rgName)
                        // Add one rule that uses above backend and probe
                        .DefineLoadBalancingRule(TcpLoadBalancingRule)
                            .WithProtocol(TransportProtocol.Tcp)
                            .FromFrontend(privateFrontEndName)
                            .FromFrontendPort(OracleSQLNodePort)
                            .ToBackend(backendPoolName3)
                            .WithProbe(HttpProbe)
                            .Attach()
                        // Add two nat pools to enable direct VM connectivity for
                        //  SSH to port 22 and TELNET to port 23
                        .DefineInboundNatRule(NatRule6000to22forVM3)
                            .WithProtocol(TransportProtocol.Tcp)
                            .FromFrontend(privateFrontEndName)
                            .FromFrontendPort(6000)
                            .ToBackendPort(22)
                            .Attach()
                        .DefineInboundNatRule(NatRule6001to23forVM3)
                            .WithProtocol(TransportProtocol.Tcp)
                            .FromFrontend(privateFrontEndName)
                            .FromFrontendPort(6001)
                            .ToBackendPort(23)
                            .Attach()
                        .DefineInboundNatRule(NatRule6002to22forVM4)
                            .WithProtocol(TransportProtocol.Tcp)
                            .FromFrontend(privateFrontEndName)
                            .FromFrontendPort(6002)
                            .ToBackendPort(22)
                            .Attach()
                        .DefineInboundNatRule(NatRule6003to23forVM4)
                            .WithProtocol(TransportProtocol.Tcp)
                            .FromFrontend(privateFrontEndName)
                            .FromFrontendPort(6003)
                            .ToBackendPort(23)
                            .Attach()
                        // Explicitly define the frontend
                        .DefinePrivateFrontend(privateFrontEndName)
                            .WithExistingSubnet(network, "Back-end")
                            .WithPrivateIPAddressStatic("172.16.3.5")
                            .Attach()
                        // Add one probes - one per rule
                        .DefineHttpProbe("httpProbe")
                            .WithRequestPath("/")
                            .Attach()
                        .Create();

                // Print load balancer details
                Utilities.Log("Created an internal load balancer");
                Utilities.PrintLoadBalancer(loadBalancer3);

                //=============================================================
                // Create two network interfaces in the backend subnet
                //  associate network interfaces to NAT rules, backend pools

                Utilities.Log("Creating two network interfaces in the backend subnet ...");
                Utilities.Log("- And associating network interfaces to backend pools and NAT rules");

                var networkInterfaceCreatables2 = new List<ICreatable<INetworkInterface>>();

                ICreatable<INetworkInterface> networkInterface3Creatable;
                ICreatable<INetworkInterface> networkInterface4Creatable;

                networkInterface3Creatable = azure.NetworkInterfaces.Define(networkInterfaceName3)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(rgName)
                        .WithExistingPrimaryNetwork(network)
                        .WithSubnet("Back-end")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithExistingLoadBalancerBackend(loadBalancer3, backendPoolName3)
                        .WithExistingLoadBalancerInboundNatRule(loadBalancer3, NatRule6000to22forVM3)
                        .WithExistingLoadBalancerInboundNatRule(loadBalancer3, NatRule6001to23forVM3);

                networkInterfaceCreatables2.Add(networkInterface3Creatable);

                networkInterface4Creatable = azure.NetworkInterfaces.Define(networkInterfaceName4)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(rgName)
                        .WithExistingPrimaryNetwork(network)
                        .WithSubnet("Back-end")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithExistingLoadBalancerBackend(loadBalancer3, backendPoolName3)
                        .WithExistingLoadBalancerInboundNatRule(loadBalancer3, NatRule6002to22forVM4)
                        .WithExistingLoadBalancerInboundNatRule(loadBalancer3, NatRule6003to23forVM4);

                networkInterfaceCreatables2.Add(networkInterface4Creatable);

                var networkInterfaces2 = azure.NetworkInterfaces.Create(networkInterfaceCreatables2.ToArray());

                // Print network interface details
                Utilities.Log("Created two network interfaces");
                Utilities.Log("Network Interface THREE -");
                Utilities.PrintNetworkInterface(networkInterfaces2.ElementAt(0));
                Utilities.Log();
                Utilities.Log("Network Interface FOUR -");
                Utilities.PrintNetworkInterface(networkInterfaces2.ElementAt(1));

                //=============================================================
                // Create an availability set

                Utilities.Log("Creating an availability set ...");

                var availSet2 = azure.AvailabilitySets.Define(availSetName)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(rgName)
                        .WithFaultDomainCount(2)
                        .WithUpdateDomainCount(4)
                        .Create();

                Utilities.Log("Created first availability set: " + availSet2.Id);
                Utilities.PrintAvailabilitySet(availSet2);

                //=============================================================
                // Create two virtual machines and assign network interfaces

                Utilities.Log("Creating two virtual machines in the frontend subnet ...");
                Utilities.Log("- And assigning network interfaces");

                var virtualMachineCreatables2 = new List<ICreatable<IVirtualMachine>>();
                ICreatable<IVirtualMachine> virtualMachine3Creatable;
                ICreatable<IVirtualMachine> virtualMachine4Creatable;

                virtualMachine3Creatable = azure.VirtualMachines.Define(vmName3)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(rgName)
                        .WithExistingPrimaryNetworkInterface(networkInterfaces2.ElementAt(0))
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername(UserName)
                        .WithSsh(SshKey)
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .WithExistingAvailabilitySet(availSet2);

                virtualMachineCreatables2.Add(virtualMachine3Creatable);

                virtualMachine4Creatable = azure.VirtualMachines.Define(vmName4)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(rgName)
                        .WithExistingPrimaryNetworkInterface(networkInterfaces2.ElementAt(1))
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername(UserName)
                        .WithSsh(SshKey)
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .WithExistingAvailabilitySet(availSet2);

                virtualMachineCreatables2.Add(virtualMachine4Creatable);

                var t1 = DateTime.UtcNow;
                var virtualMachines = azure.VirtualMachines.Create(virtualMachineCreatables2.ToArray());

                var t2 = DateTime.UtcNow;
                Utilities.Log($"Created 2 Linux VMs: (took {(t2 - t1).TotalSeconds} seconds)");
                Utilities.Log();

                // Print virtual machine details
                Utilities.Log("Virtual Machine THREE -");
                Utilities.PrintVirtualMachine(virtualMachines.ElementAt(0));
                Utilities.Log();
                Utilities.Log("Virtual Machine FOUR - ");
                Utilities.PrintVirtualMachine(virtualMachines.ElementAt(1));

                //=============================================================
                // Update a load balancer
                //  configure TCP idle timeout to 15 minutes

                Utilities.Log("Updating the load balancer ...");

                loadBalancer3.Update()
                        .UpdateLoadBalancingRule(TcpLoadBalancingRule)
                            .WithIdleTimeoutInMinutes(15)
                            .Parent()
                            .Apply();

                Utilities.Log("Update the load balancer with a TCP idle timeout to 15 minutes");

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

                Utilities.Log("Creating another internal facing load balancer with ...");
                Utilities.Log("- A private IP address");
                Utilities.Log("- One backend address pool which contain network interfaces for the virtual\n"
                        + "  machines to receive 1521 network traffic from the load balancer");
                Utilities.Log("- One load balancing rules for 1521 to map public ports on the load\n"
                        + "  balancer to ports in the backend address pool");
                Utilities.Log("- One probe which contains HTTP health probe used to check availability\n"
                        + "  of virtual machines in the backend address pool");
                Utilities.Log("- Two inbound NAT rules which contain rules that map a port on the load\n"
                        + "  balancer to a port for a specific virtual machine in the backend address pool\n"
                        + "  - this provides direct VM connectivity for SSH to port 22 and TELNET to port 23");

                var loadBalancer4 = azure.LoadBalancers.Define(loadBalancerName4)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(rgName)

                        // Add one rule that uses above backend and probe
                        .DefineLoadBalancingRule(TcpLoadBalancingRule)
                            .WithProtocol(TransportProtocol.Tcp)
                            .FromFrontend(privateFrontEndName)
                            .FromFrontendPort(OracleSQLNodePort)
                            .ToBackend(backendPoolName3)
                            .WithProbe(HttpProbe)
                            .Attach()

                        // Add two nat pools to enable direct VM connectivity for
                        //  SSH to port 22 and TELNET to port 23
                        .DefineInboundNatRule(NatRule6000to22forVM3)
                            .WithProtocol(TransportProtocol.Tcp)
                            .FromFrontend(privateFrontEndName)
                            .FromFrontendPort(6000)
                            .ToBackendPort(22)
                            .Attach()
                        .DefineInboundNatRule(NatRule6001to23forVM3)
                            .WithProtocol(TransportProtocol.Tcp)
                            .FromFrontend(privateFrontEndName)
                            .FromFrontendPort(6001)
                            .ToBackendPort(23)
                            .Attach()
                        .DefineInboundNatRule(NatRule6002to22forVM4)
                            .WithProtocol(TransportProtocol.Tcp)
                            .FromFrontend(privateFrontEndName)
                            .FromFrontendPort(6002)
                            .ToBackendPort(22)
                            .Attach()
                        .DefineInboundNatRule(NatRule6003to23forVM4)
                            .WithProtocol(TransportProtocol.Tcp)
                            .FromFrontend(privateFrontEndName)
                            .FromFrontendPort(6003)
                            .ToBackendPort(23)
                            .Attach()

                        // Explicitly define the frontend
                        .DefinePrivateFrontend(privateFrontEndName)
                            .WithExistingSubnet(network, "Back-end")
                            .WithPrivateIPAddressStatic("172.16.3.15")
                            .Attach()

                        // Add one probes - one per rule
                        .DefineHttpProbe("httpProbe")
                            .WithRequestPath("/")
                            .Attach()
                        .Create();

                // Print load balancer details
                Utilities.Log("Created an internal load balancer");
                Utilities.PrintLoadBalancer(loadBalancer4);

                //=============================================================
                // List load balancers

                var loadBalancers = azure.LoadBalancers.List();

                Utilities.Log("Walking through the list of load balancers");

                foreach (var loadBalancer in loadBalancers)
                {
                    Utilities.PrintLoadBalancer(loadBalancer);
                }

                //=============================================================
                // Remove a load balancer

                Utilities.Log("Deleting load balancer " + loadBalancerName4
                        + "(" + loadBalancer4.Id + ")");
                azure.LoadBalancers.DeleteById(loadBalancer4.Id);
                Utilities.Log("Deleted load balancer" + loadBalancerName4);
            }
            catch (Exception ex)
            {
                Utilities.Log(ex);
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
                catch (Exception ex)
                {
                    Utilities.Log(ex);
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

                var azure = Azure.Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                // Print selected subscription
                Utilities.Log("Selected subscription: " + azure.SubscriptionId);

                RunSample(azure);
            }
            catch (Exception ex)
            {
                Utilities.Log(ex);
            }
        }
    }
}