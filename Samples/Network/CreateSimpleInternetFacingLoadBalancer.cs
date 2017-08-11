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
using System.Diagnostics;

namespace CreateSimpleInternetFacingLoadBalancer
{

    public class Program
    {
        /**
         * Azure Network sample for creating a simple Internet facing load balancer -
         *
         * Summary ...
         *
         * - This sample creates a simple Internet facing load balancer that receives network traffic on
         *   port 80 and sends load-balanced traffic to two virtual machines
         *
         * Details ...
         *
         * 1. Create two virtual machines for the backend...
         * - in the same availability set
         * - in the same virtual network
         *
         * Create an Internet facing load balancer with ...
         * - A public IP address assigned to an implicitly created frontend
         * - One backend address pool with the two virtual machines to receive HTTP network traffic from the load balancer
         * - One load balancing rule for HTTP to map public ports on the load
         *   balancer to ports in the backend address pool

         * Delete the load balancer
         */

        public static void RunSample(IAzure azure)
        {
            string rgName = SdkContext.RandomResourceName("rg", 15);
            string vnetName = SdkContext.RandomResourceName("vnet", 24);
            Region region = Region.USEast;
            string loadBalancerName = SdkContext.RandomResourceName("lb", 18);
            string publicIpName = SdkContext.RandomResourceName("pip", 18);
            string availSetName = SdkContext.RandomResourceName("av", 24);
            string httpLoadBalancingRuleName = "httpRule";
            string userName = "tirekicker";
            string sshKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQCfSPC2K7LZcFKEO+/t3dzmQYtrJFZNxOsbVgOVKietqHyvmYGHEC0J2wPdAqQ/63g/hhAEFRoyehM+rbeDri4txB3YFfnOK58jqdkyXzupWqXzOrlKY4Wz9SKjjN765+dqUITjKRIaAip1Ri137szRg71WnrmdP3SphTRlCx1Bk2nXqWPsclbRDCiZeF8QOTi4JqbmJyK5+0UqhqYRduun8ylAwKKQJ1NJt85sYIHn9f1Rfr6Tq2zS0wZ7DHbZL+zB5rSlAr8QyUdg/GQD+cmSs6LvPJKL78d6hMGk84ARtFo4A79ovwX/Fj01znDQkU6nJildfkaolH2rWFG/qttD azjava@javalib.com";

            try
            {
                //=============================================================
                // Define a common availability set for the backend virtual machines

                ICreatable<IAvailabilitySet> availabilitySetDefinition = azure.AvailabilitySets.Define(availSetName)
                    .WithRegion(region)
                    .WithNewResourceGroup(rgName)
                    .WithSku(AvailabilitySetSkuTypes.Managed);


                //=============================================================
                // Define a common virtual network for the virtual machines

                ICreatable<INetwork> networkDefinition = azure.Networks.Define(vnetName)
                        .WithRegion(region)
                        .WithNewResourceGroup(rgName)
                        .WithAddressSpace("10.0.0.0/28");


                //=============================================================
                // Create two virtual machines for the backend of the load balancer

                Utilities.Log("Creating two virtual machines in the frontend subnet ...\n"
                        + "and putting them in the shared availability set and virtual network.");

                List<ICreatable<IVirtualMachine>> virtualMachineDefinitions = new List<ICreatable<IVirtualMachine>>();

                for (int i = 0; i < 2; i++)
                {
                    virtualMachineDefinitions.Add(
                            azure.VirtualMachines.Define(SdkContext.RandomResourceName("vm", 24))
                                .WithRegion(region)
                                .WithExistingResourceGroup(rgName)
                                .WithNewPrimaryNetwork(networkDefinition)
                                .WithPrimaryPrivateIPAddressDynamic()
                                .WithoutPrimaryPublicIPAddress()
                                .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                                .WithRootUsername(userName)
                                .WithSsh(sshKey)
                                .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                                .WithNewAvailabilitySet(availabilitySetDefinition));
                }


                Stopwatch stopwatch = Stopwatch.StartNew();

                // Create and retrieve the VMs by the interface accepted by the load balancing rule
                var virtualMachines = azure.VirtualMachines.Create(virtualMachineDefinitions);

                stopwatch.Stop();
                Utilities.Log("Created 2 Linux VMs: (took " + (stopwatch.ElapsedMilliseconds / 1000) + " seconds)\n");

                // Print virtual machine details
                foreach(var vm in virtualMachines)
                {
                    Utilities.PrintVirtualMachine((IVirtualMachine)vm);
                }


                //=============================================================
                // Create an Internet facing load balancer
                // - implicitly creating a frontend with the public IP address definition provided for the load balancing rule
                // - implicitly creating a backend and assigning the created virtual machines to it
                // - creating a load balancing rule, mapping public ports on the load balancer to ports in the backend address pool

                Utilities.Log(
                        "Creating a Internet facing load balancer with ...\n"
                        + "- A frontend public IP address\n"
                        + "- One backend address pool with the two virtual machines\n"
                        + "- One load balancing rule for HTTP, mapping public ports on the load\n"
                        + "  balancer to ports in the backend address pool");

                var loadBalancer = azure.LoadBalancers.Define(loadBalancerName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(rgName)

                        // Add a load balancing rule sending traffic from an implicitly created frontend with the public IP address
                        // to an implicitly created backend with the two virtual machines
                        .DefineLoadBalancingRule(httpLoadBalancingRuleName)
                            .WithProtocol(TransportProtocol.Tcp)
                            .FromNewPublicIPAddress(publicIpName)
                            .FromFrontendPort(80)
                            .ToExistingVirtualMachines(new List<IHasNetworkInterfaces>(virtualMachines))   // Convert VMs to the expected interface
                            .Attach()

                        .Create();

                // Print load balancer details
                Utilities.Log("Created a load balancer");
                Utilities.PrintLoadBalancer(loadBalancer);


                //=============================================================
                // Update a load balancer with 15 minute idle time for the load balancing rule

                Utilities.Log("Updating the load balancer ...");

                loadBalancer.Update()
                        .UpdateLoadBalancingRule(httpLoadBalancingRuleName)
                            .WithIdleTimeoutInMinutes(15)
                            .Parent()
                        .Apply();

                Utilities.Log("Updated the load balancer with a TCP idle timeout to 15 minutes");


                //=============================================================
                // Show the load balancer info

                Utilities.PrintLoadBalancer(loadBalancer);


                //=============================================================
                // Remove a load balancer

                Utilities.Log("Deleting load balancer " + loadBalancerName
                        + "(" + loadBalancer.Id + ")");
                azure.LoadBalancers.DeleteById(loadBalancer.Id);
                Utilities.Log("Deleted load balancer" + loadBalancerName);
            }
            finally
            {
                try
                {
                    Utilities.Log("Starting the deletion of the resource group: " + rgName);
                    azure.ResourceGroups.BeginDeleteByName(rgName);
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