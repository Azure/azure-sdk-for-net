// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.Network.Fluent;
using System;
using System.Text;

namespace Azure.Tests.Common
{
    public static class NetworkInterfaceHelper
    {
        public static void PrintNic(INetworkInterface resource)
        {
            var info = new StringBuilder();
            info.Append("NetworkInterface: ").Append(resource.Id)
                    .Append("Name: ").Append(resource.Name)
                    .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(resource.Region)
                    .Append("\n\tTags: ").Append(resource.Tags)
                    .Append("\n\tInternal DNS name label: ").Append(resource.InternalDnsNameLabel)
                    .Append("\n\tInternal FQDN: ").Append(resource.InternalFqdn)
                    .Append("\n\tInternal domain name suffix: ").Append(resource.InternalDomainNameSuffix)
                    .Append("\n\tVirtual machine ID: ").Append(resource.VirtualMachineId)
                    .Append("\n\tApplied DNS servers: ").Append(string.Join(", ", resource.AppliedDnsServers))
                    .Append("\n\tDNS server IPs: ");

            // Output dns servers
            foreach (var dnsServerIP in resource.DnsServers)
            {
                info.Append("\n\t\t").Append(dnsServerIP);
            }

            info.Append("\n\tIP forwarding enabled: ").Append(resource.IsIPForwardingEnabled)
                    .Append("\n\tMAC Address:").Append(resource.MacAddress)
                    .Append("\n\tPrivate IP:").Append(resource.PrimaryPrivateIP)
                    .Append("\n\tPrivate allocation method:").Append(resource.PrimaryPrivateIPAllocationMethod)
                    .Append("\n\tPrimary virtual network ID: ").Append(resource.PrimaryIPConfiguration.NetworkId)
                    .Append("\n\tPrimary subnet name: ").Append(resource.PrimaryIPConfiguration.SubnetName)
                    .Append("\n\tIP configurations: ");

            // Output IP configs
            foreach (var ipConfig in resource.IPConfigurations.Values)
            {
                info.Append("\n\t\tName: ").Append(ipConfig.Name)
                    .Append("\n\t\tPrivate IP: ").Append(ipConfig.PrivateIPAddress)
                    .Append("\n\t\tPrivate IP allocation method: ").Append(ipConfig.PrivateIPAllocationMethod)
                    .Append("\n\t\tPrivate IP version: ").Append(ipConfig.PrivateIPAddressVersion)
                    .Append("\n\t\tPIP id: ").Append(ipConfig.PublicIPAddressId)
                    .Append("\n\t\tAssociated network ID: ").Append(ipConfig.NetworkId)
                    .Append("\n\t\tAssociated subnet name: ").Append(ipConfig.SubnetName);

                // Show associated load balancer backends
                var backends = ipConfig.ListAssociatedLoadBalancerBackends();
                info.Append("\n\t\tAssociated load balancer backends: ").Append(backends.Count);
                foreach ( var backend in backends)
                {
                    info.Append("\n\t\t\tLoad balancer ID: ").Append(backend.Parent.Id)
                        .Append("\n\t\t\t\tBackend name: ").Append(backend.Name);
                }

                // Show associated load balancer inbound NAT rules
                var natRules = ipConfig.ListAssociatedLoadBalancerInboundNatRules();
                info.Append("\n\t\tAssociated load balancer inbound NAT rules: ").Append(natRules.Count);
                foreach ( var natRule in natRules)
                {
                    info.Append("\n\t\t\tLoad balancer ID: ").Append(natRule.Parent.Id)
                        .Append("\n\t\t\tInbound NAT rule name: ").Append(natRule.Name);
                }
            }

            TestHelper.WriteLine(info.ToString());
        }
    }
}
