// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageVirtualMachineScaleSetAsync
{
    public class Program
    {
        /**
         * Azure Compute sample for managing virtual machine scale sets with un-managed disks -
         *  - Create a virtual machine scale set behind an Internet facing load balancer
         *  - Install Apache Web servers in virtual machines in the virtual machine scale set
         *  - List scale set virtual machine instances and SSH collection string
         *  - Stop a virtual machine scale set
         *  - Start a virtual machine scale set
         *  - Update a virtual machine scale set
         *    - Double the no. of virtual machines
         *  - Restart a virtual machine scale set
         */
        public async static Task RunSampleAsync(IAzure azure)
        {
            var region = Region.USWestCentral;
            var rgName = SdkContext.RandomResourceName("rgCOVS", 15);
            var vnetName = SdkContext.RandomResourceName("vnet", 24);
            var loadBalancerName1 = SdkContext.RandomResourceName("intlb" + "-", 18);
            var publicIpName = "pip-" + loadBalancerName1;
            var frontendName = loadBalancerName1 + "-FE1";
            var backendPoolName1 = loadBalancerName1 + "-BAP1";
            var backendPoolName2 = loadBalancerName1 + "-BAP2";

            var httpProbe = "httpProbe";
            var httpsProbe = "httpsProbe";
            var httpLoadBalancingRule = "httpRule";
            var httpsLoadBalancingRule = "httpsRule";
            var natPool50XXto22 = "natPool50XXto22";
            var natPool60XXto23 = "natPool60XXto23";
            var vmssName = SdkContext.RandomResourceName("vmss", 24);

            var userName = "tirekicker";
            var sshKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQCfSPC2K7LZcFKEO+/t3dzmQYtrJFZNxOsbVgOVKietqHyvmYGHEC0J2wPdAqQ/63g/hhAEFRoyehM+rbeDri4txB3YFfnOK58jqdkyXzupWqXzOrlKY4Wz9SKjjN765+dqUITjKRIaAip1Ri137szRg71WnrmdP3SphTRlCx1Bk2nXqWPsclbRDCiZeF8QOTi4JqbmJyK5+0UqhqYRduun8ylAwKKQJ1NJt85sYIHn9f1Rfr6Tq2zS0wZ7DHbZL+zB5rSlAr8QyUdg/GQD+cmSs6LvPJKL78d6hMGk84ARtFo4A79ovwX/Fj01znDQkU6nJildfkaolH2rWFG/qttD azjava@javalib.Com";

            var apacheInstallScript = "https://raw.githubusercontent.com/Azure/azure-sdk-for-java/master/azure-samples/src/main/resources/install_apache.sh";
            var installCommand = "bash install_apache.sh";
            var fileUris = new List<string>();
            fileUris.Add(apacheInstallScript);
            try
            {
                //=============================================================
                // Create a virtual network with a frontend subnet
                Utilities.Log("Creating virtual network with a frontend subnet ...");
                Utilities.Log("Creating a public IP address...");

                INetwork network = null;
                IPublicIPAddress publicIPAddress = null;

                await Task.WhenAll(azure.Networks.Define(vnetName)
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .WithAddressSpace("172.16.0.0/16")
                        .DefineSubnet("Front-end")
                        .WithAddressPrefix("172.16.1.0/24")
                        .Attach()
                        .CreateAsync()
                        .ContinueWith(n =>
                        {
                            network = n.Result;
                            Utilities.Log("Created a virtual network");
                            // Print the virtual network details
                            Utilities.PrintVirtualNetwork(network);
                            return network;
                        }),
                        azure.PublicIPAddresses.Define(publicIpName)
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .WithLeafDomainLabel(publicIpName)
                        .CreateAsync()
                        .ContinueWith(pip =>
                        {
                            publicIPAddress = pip.Result;
                            Utilities.Log("Created a public IP address");
                            // Print the virtual network details
                            Utilities.PrintIPAddress(publicIPAddress);
                            return pip;
                        }));
                                

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

                var loadBalancer1 = await azure.LoadBalancers.Define(loadBalancerName1)
                        .WithRegion(region)
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
                            .WithExistingPublicIPAddress(publicIPAddress)
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

                        .CreateAsync();

                // Print load balancer details
                Utilities.Log("Created a load balancer");
                Utilities.PrintLoadBalancer(loadBalancer1);

                //=============================================================
                // Create a virtual machine scale set with three virtual machines
                // And, install Apache Web servers on them

                Utilities.Log("Creating virtual machine scale set with three virtual machines"
                        + "in the frontend subnet ...");

                var t1 = new DateTime();

                IVirtualMachineScaleSet virtualMachineScaleSet = null;

                await azure.VirtualMachineScaleSets.Define(vmssName)
                        .WithRegion(region)
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
                        .WithNewDataDisk(100)
                        .WithNewDataDisk(100, 1, CachingTypes.ReadWrite)
                        .WithNewDataDisk(100, 2, CachingTypes.ReadWrite, StorageAccountTypes.StandardLRS)
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
                        .CreateAsync()
                        .ContinueWith(vmss =>
                        {
                            virtualMachineScaleSet = vmss.Result;
                            var t2 = new DateTime();
                            Utilities.Log("Created a virtual machine scale set with "
                                    + "3 Linux VMs & Apache Web servers on them: (took "
                                    + (t2 - t1).TotalSeconds + " seconds) ");
                            Utilities.Log();
                            return virtualMachineScaleSet;
                        });

                
                //=============================================================
                // List virtual machine scale set instance network interfaces and SSH connection string

                Utilities.Log("Listing scale set virtual machine instance network interfaces and SSH connection string...");
                foreach (var instance in await virtualMachineScaleSet.VirtualMachines.ListAsync())
                {
                    Utilities.Log("Scale set virtual machine instance #" + instance.InstanceId);
                    Utilities.Log(instance.Id);
                    var networkInterfaces = instance.ListNetworkInterfaces();
                    // Pick the first NIC
                    var networkInterface = networkInterfaces.ElementAt(0);
                    foreach (var ipConfig in networkInterface.IPConfigurations.Values)
                    {
                        if (ipConfig.IsPrimary)
                        {
                            var natRules = ipConfig.ListAssociatedLoadBalancerInboundNatRules();
                            foreach (var natRule in natRules)
                            {
                                if (natRule.BackendPort == 22)
                                {
                                    Utilities.Log("SSH connection string: " + userName + "@" + publicIPAddress.Fqdn + ":" + natRule.FrontendPort);
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }

                //=============================================================
                // Stop the virtual machine scale set

                Utilities.Log("Stopping virtual machine scale set ...");
                await virtualMachineScaleSet.PowerOffAsync();
                Utilities.Log("Stopped virtual machine scale set");

                //=============================================================
                // Deallocate the virtual machine scale set

                Utilities.Log("De-allocating virtual machine scale set ...");
                await virtualMachineScaleSet.DeallocateAsync();
                Utilities.Log("De-allocated virtual machine scale set");


                //=============================================================
                // Start the virtual machine scale set

                Utilities.Log("Starting virtual machine scale set ...");
                await virtualMachineScaleSet.StartAsync();
                Utilities.Log("Started virtual machine scale set");

                //=============================================================
                // Update the virtual machine scale set
                // - double the no. of virtual machines

                Utilities.Log("Updating virtual machine scale set "
                        + "- double the no. of virtual machines ...");

                await virtualMachineScaleSet.Update()
                        .WithCapacity(6)
                        .WithoutDataDisk(0)
                        .WithoutDataDisk(200)
                        .ApplyAsync();

                Utilities.Log("Doubled the no. of virtual machines in "
                        + "the virtual machine scale set");

                //=============================================================
                // re-start virtual machine scale set

                Utilities.Log("re-starting virtual machine scale set ...");
                await virtualMachineScaleSet.RestartAsync();
                Utilities.Log("re-started virtual machine scale set");
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    await azure.ResourceGroups.DeleteByNameAsync(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
                }
                catch (NullReferenceException)
                {
                    Utilities.Log("Did not create any resourcesinAzure. No clean up is necessary");
                }
                catch (Exception g)
                {
                    Utilities.Log(g);
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

                RunSampleAsync(azure).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Utilities.Log(ex);
            }
        }
    }
}