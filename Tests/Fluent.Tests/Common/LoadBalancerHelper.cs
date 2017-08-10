// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using System;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Azure.Tests.Common
{
    public class LoadBalancerHelper : NetworkTestHelperBase
    {
        public LoadBalancerHelper(string testId)
            : base(testId)
        {
            this.LoadBalancerName = "lb" + TestId; ;
        }

        public string LoadBalancerName { get; private set; }

        // Create PIPs for the LB
        public  IEnumerable<IPublicIPAddress> EnsurePIPs(IPublicIPAddresses pips)
        {
            var creatablePips = new List<ICreatable<IPublicIPAddress>>();
            for (int i = 0; i < PipNames.Length; i++)
            {
                creatablePips.Add(pips.Define(PipNames[i])
                                  .WithRegion(Region)
                                  .WithNewResourceGroup(GroupName)
                                  .WithLeafDomainLabel(PipNames[i]));
            }

            return pips.Create(creatablePips.ToArray());
        }

        // Ensure VMs for the LB
        public IEnumerable<IVirtualMachine> EnsureVMs(
            INetworks networks,
            IComputeManager computeManager,
            int count)
        {
            // Create a network for the VMs
            INetwork network = networks.Define("net" + TestId)
                .WithRegion(Region)
                .WithNewResourceGroup(GroupName)
                .WithAddressSpace("10.0.0.0/28")
                .WithSubnet("subnet1", "10.0.0.0/29")
                .WithSubnet("subnet2", "10.0.0.8/29")
                .Create();

            // Define an availability set for the VMs
            var availabilitySetDefinition = computeManager.AvailabilitySets.Define("as" + TestId)
                .WithRegion(Region)
                .WithExistingResourceGroup(GroupName)
                .WithSku(AvailabilitySetSkuTypes.Managed);

            // Create the requested number of VM definitions
            string userName = "testuser" + TestId;
            List<ICreatable<IVirtualMachine>> vmDefinitions = new List<ICreatable<IVirtualMachine>>();

            for (int i = 0; i < count; i++)
            {
                string vmName = TestUtilities.GenerateName("vm");

                var vm = computeManager.VirtualMachines.Define(vmName)
                    .WithRegion(Region)
                    .WithExistingResourceGroup(GroupName)
                    .WithExistingPrimaryNetwork(network)
                    .WithSubnet(network.Subnets.Values.First().Name)
                    .WithPrimaryPrivateIPAddressDynamic()
                    .WithoutPrimaryPublicIPAddress()
                    .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer14_04_Lts)
                    .WithRootUsername(userName)
                    .WithRootPassword("Abcdef.123456")
                    .WithNewAvailabilitySet(availabilitySetDefinition)
                    .WithSize(VirtualMachineSizeTypes.StandardA1);

                vmDefinitions.Add(vm);
            }

            var createdVMs = computeManager.VirtualMachines.Create(vmDefinitions.ToArray()); 

            return createdVMs;
        }

        // Print LB info
        public static void PrintLB(ILoadBalancer resource)
        {
            var info = new StringBuilder();
            info.Append("Load balancer: ").Append(resource.Id)
                    .Append("Name: ").Append(resource.Name)
                    .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(resource.Region)
                    .Append("\n\tTags: ").Append(resource.Tags)
                    .Append("\n\tBackends: ").Append(string.Join(", ", resource.Backends.Keys));

            // Show public IP addresses
            info.Append("\n\tPublic IP address IDs: ")
                .Append(resource.PublicIPAddressIds.Count);
            foreach (string pipId in resource.PublicIPAddressIds)
            {
                info.AppendLine("\n\t\tPIP id: ").Append(pipId);
            }

            // Show TCP probes
            info.Append("\n\tTCP probes: ")
                .Append(resource.TcpProbes.Count);
            foreach (var probe in resource.TcpProbes.Values)
            {
                info.Append("\n\t\tProbe name: ").Append(probe.Name)
                    .Append("\n\t\t\tPort: ").Append(probe.Port)
                    .Append("\n\t\t\tInterval in seconds: ").Append(probe.IntervalInSeconds)
                    .Append("\n\t\t\tRetries before unhealthy: ").Append(probe.NumberOfProbes);

                // Show associated load balancing rules
                info.Append("\n\t\t\tReferenced from load balancing rules: ")
                    .Append(probe.LoadBalancingRules.Count);
                foreach (var rule in probe.LoadBalancingRules.Values)
                {
                    info.Append("\n\t\t\t\tName: ").Append(rule.Name);
                }
            }

            // Show HTTP probes
            info.Append("\n\tHTTP probes: ")
                .Append(resource.HttpProbes.Count);
            foreach (var probe in resource.HttpProbes.Values)
            {
                info.Append("\n\t\tProbe name: ").Append(probe.Name)
                    .Append("\n\t\t\tPort: ").Append(probe.Port)
                    .Append("\n\t\t\tInterval in seconds: ").Append(probe.IntervalInSeconds)
                    .Append("\n\t\t\tRetries before unhealthy: ").Append(probe.NumberOfProbes)
                    .Append("\n\t\t\tHTTP request path: ").Append(probe.RequestPath);

                // Show associated load balancing rules
                info.Append("\n\t\t\tReferenced from load balancing rules: ")
                    .Append(probe.LoadBalancingRules.Count);
                foreach (var rule in probe.LoadBalancingRules.Values)
                {
                    info.Append("\n\t\t\t\tName: ").Append(rule.Name);
                }
            }

            // Show load balancing rules
            info.Append("\n\tLoad balancing rules: ")
                .Append(resource.LoadBalancingRules.Count);
            foreach (var rule in resource.LoadBalancingRules.Values)
            {
                info.Append("\n\t\tLB rule name: ").Append(rule.Name)
                    .Append("\n\t\t\tProtocol: ").Append(rule.Protocol)
                    .Append("\n\t\t\tFloating IP enabled? ").Append(rule.FloatingIPEnabled)
                    .Append("\n\t\t\tIdle timeout in minutes: ").Append(rule.IdleTimeoutInMinutes)
                    .Append("\n\t\t\tLoad distribution method: ").Append(rule.LoadDistribution);

                var frontend = rule.Frontend;
                info.Append("\n\t\t\tFrontend: ");
                if (frontend != null)
                {
                    info.Append(frontend.Name);
                }
                else
                {
                    info.Append("(None)");
                }

                info.Append("\n\t\t\tFrontend port: ").Append(rule.FrontendPort);

                var backend = rule.Backend;
                info.Append("\n\t\t\tBackend: ");
                if (backend != null)
                {
                    info.Append(backend.Name);
                }
                else
                {
                    info.Append("(None)");
                }

                info.Append("\n\t\t\tBackend port: ").Append(rule.BackendPort);

                var probe = rule.Probe;
                info.Append("\n\t\t\tProbe: ");
                if (probe == null)
                {
                    info.Append("(None)");
                }
                else
                {
                    info.Append(probe.Name).Append(" [").Append(probe.Protocol).Append("]");
                }
            }

            // Show frontends
            info.Append("\n\tFrontends: ")
                .Append(resource.Frontends.Count);
            foreach (var frontend in resource.Frontends.Values)
            {
                info.Append("\n\t\tFrontend name: ").Append(frontend.Name)
                    .Append("\n\t\t\tInternet facing: ").Append(frontend.IsPublic);
                if (frontend.IsPublic)
                {
                    info.Append("\n\t\t\tPublic IP Address ID: ").Append(((ILoadBalancerPublicFrontend)frontend).PublicIPAddressId);
                }
                else
                {
                    info.Append("\n\t\t\tVirtual network ID: ").Append(((ILoadBalancerPrivateFrontend)frontend).NetworkId)
                        .Append("\n\t\t\tSubnet name: ").Append(((ILoadBalancerPrivateFrontend)frontend).SubnetName)
                        .Append("\n\t\t\tPrivate IP address: ").Append(((ILoadBalancerPrivateFrontend)frontend).PrivateIPAddress)
                        .Append("\n\t\t\tPrivate IP allocation method: ").Append(((ILoadBalancerPrivateFrontend)frontend).PrivateIPAllocationMethod);
                }

                // Inbound NAT pool references
                info.Append("\n\t\t\tReferenced inbound NAT pools: ")
                    .Append(frontend.InboundNatPools.Count);
                foreach (var pool in frontend.InboundNatPools.Values)
                {
                    info.Append("\n\t\t\t\tName: ").Append(pool.Name);
                }

                // Inbound NAT rule references
                info.Append("\n\t\t\tReferenced inbound NAT rules: ")
                    .Append(frontend.InboundNatRules.Count);
                foreach (var rule in frontend.InboundNatRules.Values)
                {
                    info.Append("\n\t\t\t\tName: ").Append(rule.Name);
                }

                // Load balancing rule references
                info.Append("\n\t\t\tReferenced load balancing rules: ")
                    .Append(frontend.LoadBalancingRules.Count);
                foreach (var rule in frontend.LoadBalancingRules.Values)
                {
                    info.Append("\n\t\t\t\tName: ").Append(rule.Name);
                }
            }

            // Show inbound NAT rules
            info.Append("\n\tInbound NAT rules: ")
                .Append(resource.InboundNatRules.Count);
            foreach (var natRule in resource.InboundNatRules.Values)
            {
                info.Append("\n\t\tInbound NAT rule name: ").Append(natRule.Name)
                    .Append("\n\t\t\tProtocol: ").Append(natRule.Protocol)
                    .Append("\n\t\t\tFrontend: ").Append(natRule.Frontend.Name)
                    .Append("\n\t\t\tFrontend port: ").Append(natRule.FrontendPort)
                    .Append("\n\t\t\tBackend port: ").Append(natRule.BackendPort)
                    .Append("\n\t\t\tBackend NIC ID: ").Append(natRule.BackendNetworkInterfaceId)
                    .Append("\n\t\t\tBackend NIC IP config name: ").Append(natRule.BackendNicIPConfigurationName)
                    .Append("\n\t\t\tFloating IP? ").Append(natRule.FloatingIPEnabled)
                    .Append("\n\t\t\tIdle timeout in minutes: ").Append(natRule.IdleTimeoutInMinutes);
            }

            // Show inbound NAT pools
            info.Append("\n\tInbound NAT pools: ")
                .Append(resource.InboundNatPools.Count);
            foreach (var natPool in resource.InboundNatPools.Values)
            {
                info.Append("\n\t\tInbound NAT pool name: ").Append(natPool.Name)
                    .Append("\n\t\t\tProtocol: ").Append(natPool.Protocol)
                    .Append("\n\t\t\tFrontend: ").Append(natPool.Frontend.Name)
                    .Append("\n\t\t\tFrontend port range: ")
                        .Append(natPool.FrontendPortRangeStart)
                        .Append("-")
                        .Append(natPool.FrontendPortRangeEnd)
                    .Append("\n\t\t\tBackend port: ").Append(natPool.BackendPort);
            }

            // Show backends
            info.Append("\n\tBackends: ")
                .Append(resource.Backends.Count);
            foreach (var backend in resource.Backends.Values)
            {
                info.Append("\n\t\tBackend name: ").Append(backend.Name);

                // Show assigned backend NICs
                info.Append("\n\t\t\tReferenced NICs: ")
                    .Append(backend.BackendNicIPConfigurationNames.Count);
                foreach (var entry in backend.BackendNicIPConfigurationNames)
                {
                    info.Append("\n\t\t\t\tNIC ID: ").Append(entry.Key)
                        .Append(" - IP Config: ").Append(entry.Value);
                }

                // Show assigned virtual machines
                var vmIds = backend.GetVirtualMachineIds();
                info.Append("\n\t\t\tReferenced virtual machine ids: ")
                    .Append(vmIds.Count);
                foreach (var vmId in vmIds)
                {
                    info.Append("\n\t\t\t\tVM ID: ").Append(vmId);
                }

                // Show assigned load balancing rules
                info.Append("\n\t\t\tReferenced load balancing rules: ")
                    .Append(string.Join(", ", backend.LoadBalancingRules.Keys));
            }

            TestHelper.WriteLine(info.ToString());
        }
    }
}