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

namespace ManageInternetFacingLoadBalancer
{

    public class Program
    {
        private static readonly string HttpProbe = "httpProbe";
        private static readonly string HttpsProbe = "httpsProbe";
        private static readonly string HttpLoadBalancingRule = "httpRule";
        private static readonly string HttpsLoadBalancingRule = "httpsRule";
        private static readonly string NatRule5000to22forVM1 = "nat5000to22forVM1";
        private static readonly string NatRule5001to23forVM1 = "nat5001to23forVM1";
        private static readonly string NatRule5002to22forVM2 = "nat5002to22forVM2";
        private static readonly string NatRule5003to23forVM2 = "nat5003to23forVM2";
        private static readonly string UserName = "tirekicker";
        private static readonly string SshKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQCfSPC2K7LZcFKEO+/t3dzmQYtrJFZNxOsbVgOVKietqHyvmYGHEC0J2wPdAqQ/63g/hhAEFRoyehM+rbeDri4txB3YFfnOK58jqdkyXzupWqXzOrlKY4Wz9SKjjN765+dqUITjKRIaAip1Ri137szRg71WnrmdP3SphTRlCx1Bk2nXqWPsclbRDCiZeF8QOTi4JqbmJyK5+0UqhqYRduun8ylAwKKQJ1NJt85sYIHn9f1Rfr6Tq2zS0wZ7DHbZL+zB5rSlAr8QyUdg/GQD+cmSs6LvPJKL78d6hMGk84ARtFo4A79ovwX/Fj01znDQkU6nJildfkaolH2rWFG/qttD azjava@javalib.Com";

        /**
         * Azure Network sample for managing Internet facing load balancers -
         *
         * High-level ...
         *
         * - Create an Internet facing load balancer that receives network traffic on
         *   port 80 & 443 and sends load-balanced traffic to two virtual machines
         *
         * - Create NAT rules for SSH and TELNET access to virtual
         *   machines behind the load balancer
         *
         * - Create health probes
         *
         * Details ...
         *
         * Create an Internet facing load balancer with ...
         * - A frontend public IP address
         * - Two backend address pools which contain network interfaces for the virtual
         *   machines to receive HTTP and HTTPS network traffic from the load balancer
         * - Two load balancing rules for HTTP and HTTPS to map public ports on the load
         *   balancer to ports in the backend address pool
         * - Two probes which contain HTTP and HTTPS health probes used to check availability
         *   of virtual machines in the backend address pool
         * - Two inbound NAT rules which contain rules that map a public port on the load
         *   balancer to a port for a specific virtual machine in the backend address pool
         * - this provides direct VM connectivity for SSH to port 22 and TELNET to port 23
         *
         * Create two network interfaces in the frontend subnet ...
         * - And associate network interfaces to backend pools and NAT rules
         *
         * Create two virtual machines in the frontend subnet ...
         * - And assign network interfaces
         *
         * Update an existing load balancer, configure TCP idle timeout
         * Create another load balancer
         * Remove an existing load balancer
         */
        public static void RunSample(IAzure azure)
        {
            string rgName = SdkContext.RandomResourceName("rgNEML", 15);
            string vnetName = SdkContext.RandomResourceName("vnet", 24);
            string loadBalancerName1 = SdkContext.RandomResourceName("intlb1" + "-", 18);
            string loadBalancerName2 = SdkContext.RandomResourceName("intlb2" + "-", 18);
            string publicIpName1 = "pip1-" + loadBalancerName1;
            string publicIpName2 = "pip2-" + loadBalancerName1;
            string frontendName = loadBalancerName1 + "-FE1";
            string backendPoolName1 = loadBalancerName1 + "-BAP1";
            string backendPoolName2 = loadBalancerName1 + "-BAP2";
            string networkInterfaceName1 = SdkContext.RandomResourceName("nic1", 24);
            string networkInterfaceName2 = SdkContext.RandomResourceName("nic2", 24);
            string availSetName = SdkContext.RandomResourceName("av", 24);
            string vmName1 = SdkContext.RandomResourceName("lVM1", 24);
            string vmName2 = SdkContext.RandomResourceName("lVM2", 24);

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
                // Create a public IP address
                Utilities.Log("Creating a public IP address...");

                var publicIpAddress = azure.PublicIPAddresses.Define(publicIpName1)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(rgName)
                        .WithLeafDomainLabel(publicIpName1)
                        .Create();

                Utilities.Log("Created a public IP address");
                // Print the virtual network details
                Utilities.PrintIPAddress(publicIpAddress);

                //=============================================================
                // Create an Internet facing load balancer
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

                Utilities.Log("Creating a Internet facing load balancer with ...");
                Utilities.Log("- A frontend IP address");
                Utilities.Log("- Two backend address pools which contain network interfaces for the virtual\n"
                                   + "  machines to receive HTTP and HTTPS network traffic from the load balancer");
                Utilities.Log("- Two load balancing rules for HTTP and HTTPS to map public ports on the load\n"
                                   + "  balancer to ports in the backend address pool");
                Utilities.Log("- Two probes which contain HTTP and HTTPS health probes used to check availability\n"
                                   + "  of virtual machines in the backend address pool");
                Utilities.Log("- Two inbound NAT rules which contain rules that map a public port on the load\n"
                                   + "  balancer to a port for a specific virtual machine in the backend address pool\n"
                                   + "  - this provides direct VM connectivity for SSH to port 22 and TELNET to port 23");

                var loadBalancer1 = azure.LoadBalancers.Define(loadBalancerName1)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(rgName)
                        .DefinePublicFrontend(frontendName)
                            .WithExistingPublicIPAddress(publicIpAddress)
                            .Attach()

                        // Add two backend one per rule
                        .DefineBackend(backendPoolName1)
                            .Attach()
                        .DefineBackend(backendPoolName2)
                            .Attach()

                        // Add two probes one per rule
                        .DefineHttpProbe(HttpProbe)
                            .WithRequestPath("/")
                            .WithPort(80)
                            .Attach()

                        .DefineHttpProbe(HttpsProbe)
                            .WithRequestPath("/")
                            .WithPort(443)
                            .Attach()
                        
                        // Add two rules that uses above backend and probe
                        .DefineLoadBalancingRule(HttpLoadBalancingRule)
                            .WithProtocol(TransportProtocol.Tcp)
                            .WithFrontend(frontendName)
                            .WithFrontendPort(80)
                            .WithProbe(HttpProbe)
                            .WithBackend(backendPoolName1)
                            .Attach()
                        .DefineLoadBalancingRule(HttpsLoadBalancingRule)
                            .WithProtocol(TransportProtocol.Tcp)
                            .WithFrontend(frontendName)
                            .WithFrontendPort(443)
                            .WithProbe(HttpsProbe)
                            .WithBackend(backendPoolName2)
                            .Attach()
                        
                        // Add two nat pools to enable direct VM connectivity for
                        //  SSH to port 22 and TELNET to port 23
                        .DefineInboundNatRule(NatRule5000to22forVM1)
                            .WithProtocol(TransportProtocol.Tcp)
                            .WithFrontend(frontendName)
                            .WithFrontendPort(5000)
                            .WithBackendPort(22)
                            .Attach()
                        .DefineInboundNatRule(NatRule5001to23forVM1)
                            .WithProtocol(TransportProtocol.Tcp)
                            .WithFrontend(frontendName)
                            .WithFrontendPort(5001)
                            .WithBackendPort(23)
                            .Attach()
                        .DefineInboundNatRule(NatRule5002to22forVM2)
                            .WithProtocol(TransportProtocol.Tcp)
                            .WithFrontend(frontendName)
                            .WithFrontendPort(5002)
                            .WithBackendPort(22)
                            .Attach()
                        .DefineInboundNatRule(NatRule5003to23forVM2)
                            .WithProtocol(TransportProtocol.Tcp)
                            .WithFrontend(frontendName)
                            .WithFrontendPort(5003)
                            .WithBackendPort(23)
                            .Attach()
                        .Create();

                // Print load balancer details
                Utilities.Log("Created a load balancer");
                Utilities.PrintLoadBalancer(loadBalancer1);

                //=============================================================
                // Create two network interfaces in the frontend subnet
                //  associate network interfaces to NAT rules, backend pools

                Utilities.Log("Creating two network interfaces in the frontend subnet ...");
                Utilities.Log("- And associating network interfaces to backend pools and NAT rules");

                var networkInterfaceCreatables = new List<ICreatable<INetworkInterface>>();

                ICreatable<INetworkInterface> networkInterface1Creatable;
                ICreatable<INetworkInterface> networkInterface2Creatable;

                networkInterface1Creatable = azure.NetworkInterfaces.Define(networkInterfaceName1)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(rgName)
                        .WithExistingPrimaryNetwork(network)
                        .WithSubnet("Front-end")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithExistingLoadBalancerBackend(loadBalancer1, backendPoolName1)
                        .WithExistingLoadBalancerBackend(loadBalancer1, backendPoolName2)
                        .WithExistingLoadBalancerInboundNatRule(loadBalancer1, NatRule5000to22forVM1)
                        .WithExistingLoadBalancerInboundNatRule(loadBalancer1, NatRule5001to23forVM1);

                networkInterfaceCreatables.Add(networkInterface1Creatable);

                networkInterface2Creatable = azure.NetworkInterfaces.Define(networkInterfaceName2)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(rgName)
                        .WithExistingPrimaryNetwork(network)
                        .WithSubnet("Front-end")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithExistingLoadBalancerBackend(loadBalancer1, backendPoolName1)
                        .WithExistingLoadBalancerBackend(loadBalancer1, backendPoolName2)
                        .WithExistingLoadBalancerInboundNatRule(loadBalancer1, NatRule5002to22forVM2)
                        .WithExistingLoadBalancerInboundNatRule(loadBalancer1, NatRule5003to23forVM2);

                networkInterfaceCreatables.Add(networkInterface2Creatable);

                var networkInterfaces1 = azure.NetworkInterfaces.Create(networkInterfaceCreatables.ToArray());

                // Print network interface details
                Utilities.Log("Created two network interfaces");
                Utilities.Log("Network Interface ONE -");
                Utilities.PrintNetworkInterface(networkInterfaces1.ElementAt(0));
                Utilities.Log();
                Utilities.Log("Network Interface TWO -");
                Utilities.PrintNetworkInterface(networkInterfaces1.ElementAt(1));

                //=============================================================
                // Create an availability set

                Utilities.Log("Creating an availability set ...");

                var availSet1 = azure.AvailabilitySets.Define(availSetName)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(rgName)
                        .WithFaultDomainCount(2)
                        .WithUpdateDomainCount(4)
                        .Create();

                Utilities.Log("Created first availability set: " + availSet1.Id);
                Utilities.PrintAvailabilitySet(availSet1);

                //=============================================================
                // Create two virtual machines and assign network interfaces

                Utilities.Log("Creating two virtual machines in the frontend subnet ...");
                Utilities.Log("- And assigning network interfaces");

                var virtualMachineCreatables1 = new List<ICreatable<IVirtualMachine>>();
                ICreatable<IVirtualMachine> virtualMachine1Creatable;
                ICreatable<IVirtualMachine> virtualMachine2Creatable;

                virtualMachine1Creatable = azure.VirtualMachines.Define(vmName1)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(rgName)
                        .WithExistingPrimaryNetworkInterface(networkInterfaces1.ElementAt(0))
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername(UserName)
                        .WithSsh(SshKey)
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .WithExistingAvailabilitySet(availSet1);

                virtualMachineCreatables1.Add(virtualMachine1Creatable);

                virtualMachine2Creatable = azure.VirtualMachines.Define(vmName2)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(rgName)
                        .WithExistingPrimaryNetworkInterface(networkInterfaces1.ElementAt(1))
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername(UserName)
                        .WithSsh(SshKey)
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .WithExistingAvailabilitySet(availSet1);

                virtualMachineCreatables1.Add(virtualMachine2Creatable);

                var t1 = DateTime.UtcNow;
                var virtualMachines = azure.VirtualMachines.Create(virtualMachineCreatables1.ToArray());

                var t2 = DateTime.UtcNow;
                Utilities.Log($"Created 2 Linux VMs: (took {(t2 - t1).TotalSeconds} seconds) ");
                Utilities.Log();

                // Print virtual machine details
                Utilities.Log("Virtual Machine ONE -");
                Utilities.PrintVirtualMachine(virtualMachines.ElementAt(0));
                Utilities.Log();
                Utilities.Log("Virtual Machine TWO - ");
                Utilities.PrintVirtualMachine(virtualMachines.ElementAt(1));

                //=============================================================
                // Update a load balancer
                //  configure TCP idle timeout to 15 minutes

                Utilities.Log("Updating the load balancer ...");

                loadBalancer1.Update()
                        .UpdateLoadBalancingRule(HttpLoadBalancingRule)
                            .WithIdleTimeoutInMinutes(15)
                            .Parent()
                        .UpdateLoadBalancingRule(HttpsLoadBalancingRule)
                            .WithIdleTimeoutInMinutes(15)
                            .Parent()
                        .Apply();

                Utilities.Log("Update the load balancer with a TCP idle timeout to 15 minutes");

                //=============================================================
                // Create another public IP address
                Utilities.Log("Creating another public IP address...");

                var publicIpAddress2 = azure.PublicIPAddresses.Define(publicIpName2)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(rgName)
                        .WithLeafDomainLabel(publicIpName2)
                        .Create();

                Utilities.Log("Created another public IP address");
                // Print the virtual network details
                Utilities.PrintIPAddress(publicIpAddress2);

                //=============================================================
                // Create another Internet facing load balancer
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

                Utilities.Log("Creating another Internet facing load balancer with ...");
                Utilities.Log("- A frontend IP address");
                Utilities.Log("- Two backend address pools which contain network interfaces for the virtual\n"
                        + "  machines to receive HTTP and HTTPS network traffic from the load balancer");
                Utilities.Log("- Two load balancing rules for HTTP and HTTPS to map public ports on the load\n"
                        + "  balancer to ports in the backend address pool");
                Utilities.Log("- Two probes which contain HTTP and HTTPS health probes used to check availability\n"
                        + "  of virtual machines in the backend address pool");
                Utilities.Log("- Two inbound NAT rules which contain rules that map a public port on the load\n"
                        + "  balancer to a port for a specific virtual machine in the backend address pool\n"
                        + "  - this provides direct VM connectivity for SSH to port 22 and TELNET to port 23");

                var loadBalancer2 = azure.LoadBalancers.Define(loadBalancerName2)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(rgName)
                        .DefinePublicFrontend(frontendName)
                            .WithExistingPublicIPAddress(publicIpAddress2)
                            .Attach()
                        // Add two backend one per rule
                        .DefineBackend(backendPoolName1)
                            .Attach()
                        .DefineBackend(backendPoolName2)
                            .Attach()
                        // Add two probes one per rule
                        .DefineHttpProbe(HttpProbe)
                            .WithRequestPath("/")
                            .WithPort(80)
                            .Attach()
                        .DefineHttpProbe(HttpsProbe)
                            .WithRequestPath("/")
                            .WithPort(443)
                            .Attach()
                        // Add two rules that uses above backend and probe
                        .DefineLoadBalancingRule(HttpLoadBalancingRule)
                            .WithProtocol(TransportProtocol.Tcp)
                            .WithFrontend(frontendName)
                            .WithFrontendPort(80)
                            .WithProbe(HttpProbe)
                            .WithBackend(backendPoolName1)
                            .Attach()
                        .DefineLoadBalancingRule(HttpsLoadBalancingRule)
                            .WithProtocol(TransportProtocol.Tcp)
                            .WithFrontend(frontendName)
                            .WithFrontendPort(443)
                            .WithProbe(HttpsProbe)
                            .WithBackend(backendPoolName2)
                            .Attach()
                        // Add two nat pools to enable direct VM connectivity for
                        //  SSH to port 22 and TELNET to port 23
                        .DefineInboundNatRule(NatRule5000to22forVM1)
                            .WithProtocol(TransportProtocol.Tcp)
                            .WithFrontend(frontendName)
                            .WithFrontendPort(5000)
                            .WithBackendPort(22)
                            .Attach()
                        .DefineInboundNatRule(NatRule5001to23forVM1)
                            .WithProtocol(TransportProtocol.Tcp)
                            .WithFrontend(frontendName)
                            .WithFrontendPort(5001)
                            .WithBackendPort(23)
                            .Attach()
                        .DefineInboundNatRule(NatRule5002to22forVM2)
                            .WithProtocol(TransportProtocol.Tcp)
                            .WithFrontend(frontendName)
                            .WithFrontendPort(5002)
                            .WithBackendPort(22)
                            .Attach()
                        .DefineInboundNatRule(NatRule5003to23forVM2)
                            .WithProtocol(TransportProtocol.Tcp)
                            .WithFrontend(frontendName)
                            .WithFrontendPort(5003)
                            .WithBackendPort(23)
                            .Attach()
                        .Create();

                // Print load balancer details
                Utilities.Log("Created another load balancer");
                Utilities.PrintLoadBalancer(loadBalancer2);

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

                Utilities.Log("Deleting load balancer " + loadBalancerName2
                        + "(" + loadBalancer2.Id + ")");
                azure.LoadBalancers.DeleteById(loadBalancer2.Id);
                Utilities.Log("Deleted load balancer" + loadBalancerName2);
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

                var azure = Azure
                    .Configure()
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