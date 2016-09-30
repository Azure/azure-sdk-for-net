// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent.Network;
using Microsoft.Azure.Management.Fluent.Resource;
using Microsoft.Azure.Management.Fluent.Resource.Core;
using Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions;
using System;
using System.Linq;
using System.Text;
using Xunit;

namespace Fluent.Tests
{
    public class NetworkInterfaceTests
    {
        string testId = "" + System.DateTime.Now.Ticks % 100000L;

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void CreateUpdateTest()
        {
            var manager = TestHelper.CreateNetworkManager();
            manager.NetworkInterfaces.Define("nic" + testId)
                    .WithRegion(Region.US_EAST)
                    .WithNewResourceGroup("rg" + this.testId)
                    .WithNewPrimaryNetwork("10.0.0.0/28")
                    .WithPrimaryPrivateIpAddressDynamic()
                    .WithNewPrimaryPublicIpAddress("pipdns" + this.testId)
                    .WithIpForwarding()
                    .Create();

            var resource = manager.NetworkInterfaces.GetByGroup("rg" + this.testId, "nic" + testId);
            resource = resource.Update()
                .WithoutIpForwarding()
                .UpdateIpConfiguration("primary-nic-config") // Updating the primary ip configuration
                    .WithPrivateIpAddressDynamic() // Equivalent to ..update().withPrimaryPrivateIpAddressDynamic()
                    .WithoutPublicIpAddress()      // Equivalent to ..update().withoutPrimaryPublicIpAddress()
                    .Parent()
                .WithTag("tag1", "value1")
                .WithTag("tag2", "value2")
                .Apply();
            Assert.True(resource.Tags.ContainsKey("tag1"));

            manager.NetworkInterfaces.Delete(resource.Id);
        }

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void CreateBatchOfNetworkInterfaces()
        {
            var azure = TestHelper.CreateRollupClient();
            var region = Region.US_EAST;

            ICreatable<IResourceGroup> rgCreatable = azure.ResourceGroups
                .Define("rg" + testId)
                .WithRegion(region);

            string vnetName = "vnet1212";
            ICreatable<INetwork> networkCreatable = azure.Networks
                .Define(vnetName)
                .WithRegion(region)
                .WithNewResourceGroup(rgCreatable)
                .WithAddressSpace("10.0.0.0/28");

            string nic1Name = "nic1";
            ICreatable<INetworkInterface> nic1Creatable = azure.NetworkInterfaces
                .Define(nic1Name)
                .WithRegion(region)
                .WithNewResourceGroup(rgCreatable)
                .WithNewPrimaryNetwork(networkCreatable)
                .WithPrimaryPrivateIpAddressStatic("10.0.0.5");

            string nic2Name = "nic2";
            ICreatable<INetworkInterface> nic2Creatable = azure.NetworkInterfaces
            .Define(nic2Name)
            .WithRegion(region)
            .WithNewResourceGroup(rgCreatable)
            .WithNewPrimaryNetwork(networkCreatable)
            .WithPrimaryPrivateIpAddressStatic("10.0.0.6");

            string nic3Name = "nic3";
            ICreatable<INetworkInterface> nic3Creatable = azure.NetworkInterfaces
            .Define(nic3Name)
            .WithRegion(region)
            .WithNewResourceGroup(rgCreatable)
            .WithNewPrimaryNetwork(networkCreatable)
            .WithPrimaryPrivateIpAddressStatic("10.0.0.7");

            string nic4Name = "nic4";
            ICreatable<INetworkInterface> nic4Creatable = azure.NetworkInterfaces
            .Define(nic4Name)
            .WithRegion(region)
            .WithNewResourceGroup(rgCreatable)
            .WithNewPrimaryNetwork(networkCreatable)
            .WithPrimaryPrivateIpAddressStatic("10.0.0.8");

            ICreatedResources<INetworkInterface> batchNics = azure.NetworkInterfaces
                                                                .Create(nic1Creatable, nic2Creatable, nic3Creatable, nic4Creatable);

            Assert.True(batchNics.Count() == 4);
            Assert.True(batchNics.Any(nic => nic.Name.Equals(nic1Name, StringComparison.OrdinalIgnoreCase)));
            Assert.True(batchNics.Any(nic => nic.Name.Equals(nic2Name, StringComparison.OrdinalIgnoreCase)));
            Assert.True(batchNics.Any(nic => nic.Name.Equals(nic3Name, StringComparison.OrdinalIgnoreCase)));
            Assert.True(batchNics.Any(nic => nic.Name.Equals(nic4Name, StringComparison.OrdinalIgnoreCase)));

            IResourceGroup resourceGroup = (IResourceGroup)batchNics.CreatedRelatedResource(rgCreatable.Key);
            Assert.NotNull(resourceGroup);
            INetwork network = (INetwork)batchNics.CreatedRelatedResource(networkCreatable.Key);
            Assert.NotNull(network);
        }

        public void print(INetworkInterface resource)
        {
            var info = new StringBuilder();
            info.Append("NetworkInterface: ").Append(resource.Id)
                    .Append("Name: ").Append(resource.Name)
                    .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(resource.Region)
                    .Append("\n\tTags: ").Append(resource.Tags)
                    .Append("\n\tInternal DNS name label: ").Append(resource.InternalDnsNameLabel)
                    .Append("\n\tInternal FQDN: ").Append(resource.InternalFqdn)
                    .Append("\n\tDNS server IPs: ");

            // Output dns servers
            foreach (string dnsServerIp in resource.DnsServers)
            {
                info.Append("\n\t\t").Append(dnsServerIp);
            }

            info.Append("\n\t IP forwarding enabled: ").Append(resource.IsIpForwardingEnabled)
                    .Append("\n\tMAC Address:").Append(resource.MacAddress)
                    .Append("\n\tPrivate IP:").Append(resource.PrimaryPrivateIp)
                    .Append("\n\tPrivate allocation method:").Append(resource.PrimaryPrivateIpAllocationMethod)
                    .Append("\n\tSubnet Name:").Append(resource.PrimaryIpConfiguration().SubnetName)
                    .Append("\n\tIP configurations: ");

            // Output IP configs
            foreach (INicIpConfiguration ipConfig in resource.IpConfigurations().Values)
            {
                info.Append("\n\t\tName: ").Append(ipConfig.Name)
                    .Append("\n\t\tPrivate IP: ").Append(ipConfig.PrivateIpAddress)
                    .Append("\n\t\tPrivate IP allocation method: ").Append(ipConfig.PrivateIpAllocationMethod)
                    .Append("\n\t\tPIP id: ").Append(ipConfig.PublicIpAddressId)
                    .Append("\n\t\tSubnet Name: ").Append(ipConfig.SubnetName);
            }

            Console.WriteLine(info.ToString());
        }
    }
}