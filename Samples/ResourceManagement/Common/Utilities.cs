// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Batch.Fluent;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.KeyVault.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Storage.Fluent;
using Microsoft.Azure.Management.Storage.Fluent.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Management.Samples.Common
{
    public static class Utilities
    {
        public static void PrintVirtualMachine(IVirtualMachine virtualMachine)
        {
            var storageProfile = new StringBuilder().Append("\n\tStorageProfile: ");
            if (virtualMachine.StorageProfile.ImageReference != null)
            {
                storageProfile.Append("\n\t\tImageReference:");
                storageProfile.Append("\n\t\t\tPublisher: ").Append(virtualMachine.StorageProfile.ImageReference.Publisher);
                storageProfile.Append("\n\t\t\tOffer: ").Append(virtualMachine.StorageProfile.ImageReference.Offer);
                storageProfile.Append("\n\t\t\tSKU: ").Append(virtualMachine.StorageProfile.ImageReference.Sku);
                storageProfile.Append("\n\t\t\tVersion: ").Append(virtualMachine.StorageProfile.ImageReference.Version);
            }

            if (virtualMachine.StorageProfile.OsDisk != null)
            {
                storageProfile.Append("\n\t\tOSDisk:");
                storageProfile.Append("\n\t\t\tOSType: ").Append(virtualMachine.StorageProfile.OsDisk.OsType);
                storageProfile.Append("\n\t\t\tName: ").Append(virtualMachine.StorageProfile.OsDisk.Name);
                storageProfile.Append("\n\t\t\tCaching: ").Append(virtualMachine.StorageProfile.OsDisk.Caching);
                storageProfile.Append("\n\t\t\tCreateOption: ").Append(virtualMachine.StorageProfile.OsDisk.CreateOption);
                storageProfile.Append("\n\t\t\tDiskSizeGB: ").Append(virtualMachine.StorageProfile.OsDisk.DiskSizeGB);
                if (virtualMachine.StorageProfile.OsDisk.Image != null)
                {
                    storageProfile.Append("\n\t\t\tImage Uri: ").Append(virtualMachine.StorageProfile.OsDisk.Image.Uri);
                }
                if (virtualMachine.StorageProfile.OsDisk.Vhd != null)
                {
                    storageProfile.Append("\n\t\t\tVhd Uri: ").Append(virtualMachine.StorageProfile.OsDisk.Vhd.Uri);
                }
                if (virtualMachine.StorageProfile.OsDisk.EncryptionSettings != null)
                {
                    storageProfile.Append("\n\t\t\tEncryptionSettings: ");
                    storageProfile.Append("\n\t\t\t\tEnabled: ").Append(virtualMachine.StorageProfile.OsDisk.EncryptionSettings.Enabled);
                    storageProfile.Append("\n\t\t\t\tDiskEncryptionKey Uri: ").Append(virtualMachine
                            .StorageProfile
                            .OsDisk
                            .EncryptionSettings
                            .DiskEncryptionKey.SecretUrl);
                    storageProfile.Append("\n\t\t\t\tKeyEncryptionKey Uri: ").Append(virtualMachine
                            .StorageProfile
                            .OsDisk
                            .EncryptionSettings
                            .KeyEncryptionKey.KeyUrl);
                }
            }

            if (virtualMachine.StorageProfile.DataDisks != null)
            {
                var i = 0;
                foreach (var disk in virtualMachine.StorageProfile.DataDisks)
                {
                    storageProfile.Append("\n\t\tDataDisk: #").Append(i++);
                    storageProfile.Append("\n\t\t\tName: ").Append(disk.Name);
                    storageProfile.Append("\n\t\t\tCaching: ").Append(disk.Caching);
                    storageProfile.Append("\n\t\t\tCreateOption: ").Append(disk.CreateOption);
                    storageProfile.Append("\n\t\t\tDiskSizeGB: ").Append(disk.DiskSizeGB);
                    storageProfile.Append("\n\t\t\tLun: ").Append(disk.Lun);
                    if (disk.Vhd.Uri != null)
                    {
                        storageProfile.Append("\n\t\t\tVhd Uri: ").Append(disk.Vhd.Uri);
                    }
                    if (disk.Image != null)
                    {
                        storageProfile.Append("\n\t\t\tImage Uri: ").Append(disk.Image.Uri);
                    }
                }
            }

            var osProfile = new StringBuilder().Append("\n\tOSProfile: ");
            osProfile.Append("\n\t\tComputerName:").Append(virtualMachine.OsProfile.ComputerName);
            if (virtualMachine.OsProfile.WindowsConfiguration != null)
            {
                osProfile.Append("\n\t\t\tWindowsConfiguration: ");
                osProfile.Append("\n\t\t\t\tProvisionVMAgent: ")
                        .Append(virtualMachine.OsProfile.WindowsConfiguration.ProvisionVMAgent);
                osProfile.Append("\n\t\t\t\tEnableAutomaticUpdates: ")
                        .Append(virtualMachine.OsProfile.WindowsConfiguration.EnableAutomaticUpdates);
                osProfile.Append("\n\t\t\t\tTimeZone: ")
                        .Append(virtualMachine.OsProfile.WindowsConfiguration.TimeZone);
            }

            if (virtualMachine.OsProfile.LinuxConfiguration != null)
            {
                osProfile.Append("\n\t\t\tLinuxConfiguration: ");
                osProfile.Append("\n\t\t\t\tDisablePasswordAuthentication: ")
                        .Append(virtualMachine.OsProfile.LinuxConfiguration.DisablePasswordAuthentication);
            }

            var networkProfile = new StringBuilder().Append("\n\tNetworkProfile: ");
            foreach (var networkInterfaceId in virtualMachine.NetworkInterfaceIds)
            {
                networkProfile.Append("\n\t\tId:").Append(networkInterfaceId);
            }

            Console.WriteLine(new StringBuilder().Append("Virtual Machine: ").Append(virtualMachine.Id)
                    .Append("Name: ").Append(virtualMachine.Name)
                    .Append("\n\tResource group: ").Append(virtualMachine.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(virtualMachine.Region)
                    .Append("\n\tTags: ").Append(FormatDictionary(virtualMachine.Tags))
                    .Append("\n\tHardwareProfile: ")
                    .Append("\n\t\tSize: ").Append(virtualMachine.Size)
                    .Append(storageProfile)
                    .Append(osProfile)
                    .Append(networkProfile)
                    .ToString());
        }

        public static void PrintStorageAccountKeys(IList<StorageAccountKey> storageAccountKeys)
        {
            foreach (var storageAccountKey in storageAccountKeys)
            {
                Console.WriteLine($"Key {storageAccountKey.KeyName} = {storageAccountKey.Value}");
            }
        }

        public static void PrintStorageAccount(IStorageAccount storageAccount)
        {
            Console.WriteLine($"{storageAccount.Name} created @ {storageAccount.CreationTime}");
        }

        public static string CreateRandomName(string namePrefix)
        {
            var root = Guid.NewGuid().ToString().Replace("-", "");
            return $"{namePrefix}{root.ToLower().Substring(0, 3)}{(DateTime.UtcNow.Millisecond % 10000000L)}";
        }

        public static void PrintAvailabilitySet(IAvailabilitySet resource)
        {
            Console.WriteLine(new StringBuilder().Append("Availability Set: ").Append(resource.Id)
                .Append("Name: ").Append(resource.Name)
                .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                .Append("\n\tRegion: ").Append(resource.Region)
                .Append("\n\tTags: ").Append(FormatDictionary(resource.Tags))
                .Append("\n\tFault domain count: ").Append(resource.FaultDomainCount)
                .Append("\n\tUpdate domain count: ").Append(resource.UpdateDomainCount)
                .ToString());
        }

        public static void PrintBatchAccount(IBatchAccount batchAccount)
        {
            var applicationsOutput = new StringBuilder().Append("\n\tapplications: ");

            if (batchAccount.Applications.Count > 0)
            {
                foreach (var applicationEntry in batchAccount.Applications)
                {
                    var application = applicationEntry.Value;
                    var applicationPackages = new StringBuilder().Append("\n\t\t\tapplicationPackages : ");

                    foreach (var applicationPackageEntry in application.ApplicationPackages)
                    {
                        var applicationPackage = applicationPackageEntry.Value;
                        var singleApplicationPackage = new StringBuilder().Append("\n\t\t\t\tapplicationPackage : " + applicationPackage.Name);
                        singleApplicationPackage.Append("\n\t\t\t\tapplicationPackageState : " + applicationPackage.State);

                        applicationPackages.Append(singleApplicationPackage);
                        singleApplicationPackage.Append("\n");
                    }

                    var singleApplication = new StringBuilder().Append("\n\t\tapplication: " + application.Name);
                    singleApplication.Append("\n\t\tdisplayName: " + application.DisplayName);
                    singleApplication.Append("\n\t\tdefaultVersion: " + application.DefaultVersion);
                    singleApplication.Append(applicationPackages);
                    applicationsOutput.Append(singleApplication);
                    applicationsOutput.Append("\n");
                }
            }

            Console.WriteLine(new StringBuilder().Append("BatchAccount: ").Append(batchAccount.Id)
                    .Append("Name: ").Append(batchAccount.Name)
                    .Append("\n\tResource group: ").Append(batchAccount.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(batchAccount.Region)
                    .Append("\n\tTags: ").Append(FormatDictionary(batchAccount.Tags))
                    .Append("\n\tAccountEndpoint: ").Append(batchAccount.AccountEndpoint)
                    .Append("\n\tPoolQuota: ").Append(batchAccount.PoolQuota)
                    .Append("\n\tActiveJobAndJobScheduleQuota: ").Append(batchAccount.ActiveJobAndJobScheduleQuota)
                    .Append("\n\tStorageAccount: ").Append(batchAccount.AutoStorage == null ? "No storage account attached" : batchAccount.AutoStorage.StorageAccountId)
                    .Append(applicationsOutput)
                    .ToString());
        }

        public static void PrintBatchAccountKey(BatchAccountKeys batchAccountKeys)
        {
            Console.WriteLine("Primary Key (" + batchAccountKeys.Primary + ") Secondary key = ("
                    + batchAccountKeys.Secondary + ")");
        }

        public static void PrintNetworkSecurityGroup(INetworkSecurityGroup resource)
        {
            var nsgOutput = new StringBuilder();
            nsgOutput.Append("NSG: ").Append(resource.Id)
                    .Append("Name: ").Append(resource.Name)
                    .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(resource.RegionName)
                    .Append("\n\tTags: ").Append(FormatDictionary(resource.Tags));

            // Output security rules
            foreach (var rule in resource.SecurityRules.Values)
            {
                nsgOutput.Append("\n\tRule: ").Append(rule.Name)
                        .Append("\n\t\tAccess: ").Append(rule.Access)
                        .Append("\n\t\tDirection: ").Append(rule.Direction)
                        .Append("\n\t\tFrom address: ").Append(rule.SourceAddressPrefix)
                        .Append("\n\t\tFrom port range: ").Append(rule.SourcePortRange)
                        .Append("\n\t\tTo address: ").Append(rule.DestinationAddressPrefix)
                        .Append("\n\t\tTo port: ").Append(rule.DestinationPortRange)
                        .Append("\n\t\tProtocol: ").Append(rule.Protocol)
                        .Append("\n\t\tPriority: ").Append(rule.Priority);
            }
            Console.WriteLine(nsgOutput.ToString());
        }

        public static void PrintVirtualNetwork(INetwork network)
        {
            var info = new StringBuilder();
            info.Append("Network: ").Append(network.Id)
                    .Append("Name: ").Append(network.Name)
                    .Append("\n\tResource group: ").Append(network.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(network.Region)
                    .Append("\n\tTags: ").Append(FormatDictionary(network.Tags))
                    .Append("\n\tAddress spaces: ").Append(FormatCollection(network.AddressSpaces))
                    .Append("\n\tDNS server IPs: ").Append(FormatCollection(network.DnsServerIps));

            // Output subnets
            foreach (var subnet in network.Subnets.Values)
            {
                info.Append("\n\tSubnet: ").Append(subnet.Name)
                        .Append("\n\t\tAddress prefix: ").Append(subnet.AddressPrefix);
                var subnetNsg = subnet.GetNetworkSecurityGroup();
                if (subnetNsg != null)
                {
                    info.Append("\n\t\tNetwork security group: ").Append(subnetNsg.Id);
                }
            }

            Console.WriteLine(info.ToString());
        }

        public static void PrintIpAddress(IPublicIpAddress publicIpAddress)
        {
            Console.WriteLine(new StringBuilder().Append("Public IP Address: ").Append(publicIpAddress.Id)
                .Append("Name: ").Append(publicIpAddress.Name)
                .Append("\n\tResource group: ").Append(publicIpAddress.ResourceGroupName)
                .Append("\n\tRegion: ").Append(publicIpAddress.Region)
                .Append("\n\tTags: ").Append(FormatDictionary(publicIpAddress.Tags))
                .Append("\n\tIP Address: ").Append(publicIpAddress.IpAddress)
                .Append("\n\tLeaf domain label: ").Append(publicIpAddress.LeafDomainLabel)
                .Append("\n\tFQDN: ").Append(publicIpAddress.Fqdn)
                .Append("\n\tReverse FQDN: ").Append(publicIpAddress.ReverseFqdn)
                .Append("\n\tIdle timeout (minutes): ").Append(publicIpAddress.IdleTimeoutInMinutes)
                .Append("\n\tIP allocation method: ").Append(publicIpAddress.IpAllocationMethod)
                .ToString());
        }

        public static void PrintNetworkInterface(INetworkInterface resource)
        {
            var info = new StringBuilder();
            info.Append("NetworkInterface: ").Append(resource.Id)
                    .Append("Name: ").Append(resource.Name)
                    .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(resource.Region)
                    .Append("\n\tTags: ").Append(FormatDictionary(resource.Tags))
                    .Append("\n\tInternal DNS name label: ").Append(resource.InternalDnsNameLabel)
                    .Append("\n\tInternal FQDN: ").Append(resource.InternalFqdn)
                    .Append("\n\tInternal domain name suffix: ").Append(resource.InternalDomainNameSuffix)
                    .Append("\n\tNetwork security group: ").Append(resource.NetworkSecurityGroupId)
                    .Append("\n\tApplied DNS servers: ").Append(FormatCollection(resource.AppliedDnsServers))
                    .Append("\n\tDNS server IPs: ");

            // Output dns servers
            foreach (var dnsServerIp in resource.DnsServers)
            {
                info.Append("\n\t\t").Append(dnsServerIp);
            }

            info.Append("\n\t IP forwarding enabled: ").Append(resource.IsIpForwardingEnabled)
                    .Append("\n\tMAC Address:").Append(resource.MacAddress)
                    .Append("\n\tPrivate IP:").Append(resource.PrimaryPrivateIp)
                    .Append("\n\tPrivate allocation method:").Append(resource.PrimaryPrivateIpAllocationMethod)
                    .Append("\n\tPrimary virtual network ID: ").Append(resource.PrimaryIpConfiguration.NetworkId)
                    .Append("\n\tPrimary subnet name:").Append(resource.PrimaryIpConfiguration.SubnetName);

            Console.WriteLine(info.ToString());
        }

        public static void PrintLoadBalancer(ILoadBalancer loadBalancer)
        {
            var info = new StringBuilder();
            info.Append("Load balancer: ").Append(loadBalancer.Id)
                    .Append("Name: ").Append(loadBalancer.Name)
                    .Append("\n\tResource group: ").Append(loadBalancer.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(loadBalancer.Region)
                    .Append("\n\tTags: ").Append(FormatDictionary(loadBalancer.Tags))
                    .Append("\n\tBackends: ").Append(FormatCollection(loadBalancer.Backends.Keys));

            // Show public IP addresses
            info.Append("\n\tPublic IP address IDs: ")
                    .Append(loadBalancer.PublicIpAddressIds.Count);
            foreach (var pipId in loadBalancer.PublicIpAddressIds)
            {
                info.Append("\n\t\tPIP id: ").Append(pipId);
            }

            // Show TCP probes
            info.Append("\n\tTCP probes: ")
                    .Append(loadBalancer.TcpProbes.Count);
            foreach (var probe in loadBalancer.TcpProbes.Values)
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
                    .Append(loadBalancer.HttpProbes.Count);
            foreach (var probe in loadBalancer.HttpProbes.Values)
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
                    .Append(loadBalancer.LoadBalancingRules.Count);
            foreach (var rule in loadBalancer.LoadBalancingRules.Values)
            {
                info.Append("\n\t\tLB rule name: ").Append(rule.Name)
                        .Append("\n\t\t\tProtocol: ").Append(rule.Protocol)
                        .Append("\n\t\t\tFloating IP enabled? ").Append(rule.FloatingIpEnabled)
                        .Append("\n\t\t\tIdle timeout in minutes: ").Append(rule.IdleTimeoutInMinutes)
                        .Append("\n\t\t\tLoad distribution method: ").Append(rule.LoadDistribution.ToString());

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
                    info.Append(probe.Name).Append(" [").Append(probe.Protocol.ToString()).Append("]");
                }
            }

            // Show frontends
            info.Append("\n\tFrontends: ")
                    .Append(loadBalancer.Frontends.Count);
            foreach (var frontend in loadBalancer.Frontends.Values)
            {
                info.Append("\n\t\tFrontend name: ").Append(frontend.Name)
                        .Append("\n\t\t\tInternet facing: ").Append(frontend.IsPublic);
                if (frontend.IsPublic)
                {
                    info.Append("\n\t\t\tPublic IP Address ID: ").Append(((IPublicFrontend)frontend).PublicIpAddressId);
                }
                else
                {
                    info.Append("\n\t\t\tVirtual network ID: ").Append(((IPrivateFrontend)frontend).NetworkId)
                            .Append("\n\t\t\tSubnet name: ").Append(((IPrivateFrontend)frontend).SubnetName)
                            .Append("\n\t\t\tPrivate IP address: ").Append(((IPrivateFrontend)frontend).PrivateIpAddress)
                            .Append("\n\t\t\tPrivate IP allocation method: ").Append(((IPrivateFrontend)frontend).PrivateIpAllocationMethod);
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
                    .Append(loadBalancer.InboundNatRules.Count);
            foreach (var natRule in loadBalancer.InboundNatRules.Values)
            {
                info.Append("\n\t\tInbound NAT rule name: ").Append(natRule.Name)
                        .Append("\n\t\t\tProtocol: ").Append(natRule.Protocol.ToString())
                        .Append("\n\t\t\tFrontend: ").Append(natRule.Frontend.Name)
                        .Append("\n\t\t\tFrontend port: ").Append(natRule.FrontendPort)
                        .Append("\n\t\t\tBackend port: ").Append(natRule.BackendPort)
                        .Append("\n\t\t\tBackend NIC ID: ").Append(natRule.BackendNetworkInterfaceId)
                        .Append("\n\t\t\tBackend NIC IP config name: ").Append(natRule.BackendNicIpConfigurationName)
                        .Append("\n\t\t\tFloating IP? ").Append(natRule.FloatingIpEnabled)
                        .Append("\n\t\t\tIdle timeout in minutes: ").Append(natRule.IdleTimeoutInMinutes);
            }

            // Show inbound NAT pools
            info.Append("\n\tInbound NAT pools: ")
                    .Append(loadBalancer.InboundNatPools.Count);
            foreach (var natPool in loadBalancer.InboundNatPools.Values)
            {
                info.Append("\n\t\tInbound NAT pool name: ").Append(natPool.Name)
                        .Append("\n\t\t\tProtocol: ").Append(natPool.Protocol.ToString())
                        .Append("\n\t\t\tFrontend: ").Append(natPool.Frontend.Name)
                        .Append("\n\t\t\tFrontend port range: ")
                        .Append(natPool.FrontendPortRangeStart)
                        .Append("-")
                        .Append(natPool.FrontendPortRangeEnd)
                        .Append("\n\t\t\tBackend port: ").Append(natPool.BackendPort);
            }

            // Show backends
            info.Append("\n\tBackends: ")
                    .Append(loadBalancer.Backends.Count);
            foreach (var backend in loadBalancer.Backends.Values)
            {
                info.Append("\n\t\tBackend name: ").Append(backend.Name);

                // Show assigned backend NICs
                info.Append("\n\t\t\tReferenced NICs: ")
                        .Append(backend.BackendNicIpConfigurationNames.Count);
                foreach (var entry in backend.BackendNicIpConfigurationNames)
                {
                    info.Append("\n\t\t\t\tNIC ID: ").Append(entry.Key)
                            .Append(" - IP Config: ").Append(entry.Value);
                }

                // Show assigned virtual machines
                var vmIds = backend.GetVirtualMachineIds();
                info.Append("\n\t\t\tReferenced virtual machine ids: ")
                        .Append(vmIds.Count);
                foreach (string vmId in vmIds)
                {
                    info.Append("\n\t\t\t\tVM ID: ").Append(vmId);
                }

                // Show assigned load balancing rules
                info.Append("\n\t\t\tReferenced load balancing rules: ")
                        .Append(FormatCollection(backend.LoadBalancingRules.Keys));
            }

            Console.WriteLine(info.ToString());
        }

        public static void PrintVault(IVault vault)
        {
            var info = new StringBuilder().Append("Key Vault: ").Append(vault.Id)
                .Append("Name: ").Append(vault.Name)
                .Append("\n\tResource group: ").Append(vault.ResourceGroupName)
                .Append("\n\tRegion: ").Append(vault.Region)
                .Append("\n\tSku: ").Append(vault.Sku.Name).Append(" - ").Append(KeyVault.Fluent.Models.Sku.Family)
                .Append("\n\tVault URI: ").Append(vault.VaultUri)
                .Append("\n\tAccess policies: ");
            foreach (var accessPolicy in vault.AccessPolicies)
            {
                info.Append("\n\t\tIdentity:").Append(accessPolicy.ObjectId)
                        .Append("\n\t\tKey permissions: ").Append(FormatCollection(accessPolicy.Permissions.Keys))
                        .Append("\n\t\tSecret permissions: ").Append(FormatCollection(accessPolicy.Permissions.Secrets));
            }

            Console.WriteLine(info.ToString());
        }

        private static string FormatDictionary(IDictionary<string, string> dictionary)
        {
            if (dictionary == null)
            {
                return string.Empty;
            }

            var outputString = new StringBuilder();

            foreach (var entity in dictionary)
            {
                outputString.AppendLine($"{entity.Key}: {entity.Value}");
            }

            return outputString.ToString();
        }

        private static string FormatCollection(IEnumerable<string> collection)
        {
            return string.Join(", ", collection);
        }
    }
}