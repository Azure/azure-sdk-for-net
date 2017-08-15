// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Collections.Generic;

namespace ManageVirtualMachineScaleSetWithUnmanagedDisks
{
    public class Program
    {
        private readonly static string httpProbe = "httpProbe";
        private readonly static string httpsProbe = "httpsProbe";
        private readonly static string httpLoadBalancingRule = "httpRule";
        private readonly static string httpsLoadBalancingRule = "httpsRule";
        private readonly static string natPool50XXto22 = "natPool50XXto22";
        private readonly static string natPool60XXto23 = "natPool60XXto23";
        private readonly static string userName = "tirekicker";
        private readonly static string sshKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQCfSPC2K7LZcFKEO+/t3dzmQYtrJFZNxOsbVgOVKietqHyvmYGHEC0J2wPdAqQ/63g/hhAEFRoyehM+rbeDri4txB3YFfnOK58jqdkyXzupWqXzOrlKY4Wz9SKjjN765+dqUITjKRIaAip1Ri137szRg71WnrmdP3SphTRlCx1Bk2nXqWPsclbRDCiZeF8QOTi4JqbmJyK5+0UqhqYRduun8ylAwKKQJ1NJt85sYIHn9f1Rfr6Tq2zS0wZ7DHbZL+zB5rSlAr8QyUdg/GQD+cmSs6LvPJKL78d6hMGk84ARtFo4A79ovwX/Fj01znDQkU6nJildfkaolH2rWFG/qttD azjava@javalib.Com";
        private readonly static string apacheInstallScript = "https://raw.githubusercontent.com/Azure/azure-sdk-for-net/Fluent/Samples/Asset/install_apache.sh";
        private readonly static string installCommand = "bash install_apache.sh Abc.123x(";

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
        public static void RunSample(IAzure azure)
        {
            string vmssName = SdkContext.RandomResourceName("vmss", 24);
            string storageAccountName1 = SdkContext.RandomResourceName("stg1", 24);
            string storageAccountName2 = SdkContext.RandomResourceName("stg2", 24);
            string storageAccountName3 = SdkContext.RandomResourceName("stg3", 24);
            string rgName = SdkContext.RandomResourceName("rgCOVS", 15);
            string vnetName = SdkContext.RandomResourceName("vnet", 24);
            string loadBalancerName1 = SdkContext.RandomResourceName("intlb" + "-", 18);
            string publicIpName = "pip-" + loadBalancerName1;
            string frontendName = loadBalancerName1 + "-FE1";
            string backendPoolName1 = loadBalancerName1 + "-BAP1";
            string backendPoolName2 = loadBalancerName1 + "-BAP2";

            try
            {
                //=============================================================
                // Create a virtual network with a frontend subnet
                Utilities.Log("Creating virtual network with a frontend subnet ...");

                var network = azure.Networks.Define(vnetName)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(rgName)
                        .WithAddressSpace("172.16.0.0/16")
                        .DefineSubnet("Front-end")
                            .WithAddressPrefix("172.16.1.0/24")
                            .Attach()
                        .Create();

                Utilities.Log("Created a virtual network");
                // Print the virtual network details
                Utilities.PrintVirtualNetwork(network);

                //=============================================================
                // Create a public IP address
                Utilities.Log("Creating a public IP address...");

                var publicIpAddress = azure.PublicIPAddresses.Define(publicIpName)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(rgName)
                        .WithLeafDomainLabel(publicIpName)
                        .Create();

                Utilities.Log("Created a public IP address");
                // Print the IPAddress details
                Utilities.PrintIPAddress(publicIpAddress);

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
                        // Add two rules that uses above backend and probe
                        .DefineLoadBalancingRule(httpLoadBalancingRule)
                            .WithProtocol(TransportProtocol.Tcp)
                            .FromFrontend(frontendName)
                            .FromFrontendPort(80)
                            .ToBackend(backendPoolName1)
                            .WithProbe(httpProbe)
                            .Attach()
                        .DefineLoadBalancingRule(httpsLoadBalancingRule)
                            .WithProtocol(TransportProtocol.Tcp)
                            .FromFrontend(frontendName)
                            .FromFrontendPort(443)
                            .ToBackend(backendPoolName2)
                            .WithProbe(httpsProbe)
                            .Attach()
                        // Add nat pools to enable direct VM connectivity for
                        //  SSH to port 22 and TELNET to port 23
                        .DefineInboundNatPool(natPool50XXto22)
                            .WithProtocol(TransportProtocol.Tcp)
                            .FromFrontend(frontendName)
                            .FromFrontendPortRange(5000, 5099)
                            .ToBackendPort(22)
                            .Attach()
                        .DefineInboundNatPool(natPool60XXto23)
                            .WithProtocol(TransportProtocol.Tcp)
                            .FromFrontend(frontendName)
                            .FromFrontendPortRange(6000, 6099)
                            .ToBackendPort(23)
                            .Attach()
                        // Explicitly define the frontend
                        .DefinePublicFrontend(frontendName)
                            .WithExistingPublicIPAddress(publicIpAddress)
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
                        .Create();

                // Print load balancer details
                Utilities.Log("Created a load balancer");
                Utilities.PrintLoadBalancer(loadBalancer1);

                //=============================================================
                // Create a virtual machine scale set with three virtual machines
                // And, install Apache Web servers on them

                Utilities.Log("Creating virtual machine scale set with three virtual machines"
                        + " in the frontend subnet ...");

                var t1 = DateTime.UtcNow;

                var fileUris = new List<string>();
                fileUris.Add(apacheInstallScript);

                var virtualMachineScaleSet = azure.VirtualMachineScaleSets
                        .Define(vmssName)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(rgName)
                        .WithSku(VirtualMachineScaleSetSkuTypes.StandardD3v2)
                        .WithExistingPrimaryNetworkSubnet(network, "Front-end")
                        .WithExistingPrimaryInternetFacingLoadBalancer(loadBalancer1)
                        .WithPrimaryInternetFacingLoadBalancerBackends(backendPoolName1, backendPoolName2)
                        .WithPrimaryInternetFacingLoadBalancerInboundNatPools(natPool50XXto22, natPool60XXto23)
                        .WithoutPrimaryInternalLoadBalancer()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
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
                Utilities.Log("Created a virtual machine scale set with "
                        + "3 Linux VMs & Apache Web servers on them: (took "
                        + ((t2 - t1).TotalSeconds) + " seconds) \r\n");

                // Print virtual machine scale set details
                // Utilities.Print(virtualMachineScaleSet);

                //=============================================================
                // Stop the virtual machine scale set

                Utilities.Log("Stopping virtual machine scale set ...");
                virtualMachineScaleSet.PowerOff();
                Utilities.Log("Stopped virtual machine scale set");

                //=============================================================
                // Start the virtual machine scale set

                Utilities.Log("Starting virtual machine scale set ...");
                virtualMachineScaleSet.Start();
                Utilities.Log("Started virtual machine scale set");

                //=============================================================
                // Update the virtual machine scale set
                // - double the no. of virtual machines

                Utilities.Log("Updating virtual machine scale set "
                        + "- double the no. of virtual machines ...");

                virtualMachineScaleSet.Update()
                    .WithCapacity(6)
                    .Apply();

                Utilities.Log("Doubled the no. of virtual machines in "
                        + "the virtual machine scale set");

                //=============================================================
                // re-start virtual machine scale set

                Utilities.Log("re-starting virtual machine scale set ...");
                virtualMachineScaleSet.Restart();
                Utilities.Log("re-started virtual machine scale set");
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
                //=============================================================
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