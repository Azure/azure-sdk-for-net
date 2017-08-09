// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Text;
using Xunit;

namespace Fluent.Tests.Network
{
    public class Network
    {

        [Fact]
        public void CreateUpdate()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var testId = TestUtilities.GenerateName("");

                string newName = "net" + testId;
                var region = Region.USWest;
                var groupName = "rg" + testId;

                // Create an NSG
                var manager = TestHelper.CreateNetworkManager();
                var nsg = manager.NetworkSecurityGroups.Define("nsg" + testId)
                    .WithRegion(region)
                    .WithNewResourceGroup(groupName)
                    .Create();

                // Create a network
                INetwork network = manager.Networks.Define(newName)
                        .WithRegion(region)
                        .WithNewResourceGroup(groupName)
                        .WithAddressSpace("10.0.0.0/28")
                        .WithSubnet("subnetA", "10.0.0.0/29")
                        .DefineSubnet("subnetB")
                            .WithAddressPrefix("10.0.0.8/29")
                            .WithExistingNetworkSecurityGroup(nsg)
                            .Attach()
                        .Create();

                // Verify subnets
                Assert.Equal(2, network.Subnets.Count);
                ISubnet subnet = network.Subnets["subnetA"];
                Assert.Equal("10.0.0.0/29", subnet.AddressPrefix);
                subnet = network.Subnets["subnetB"];
                Assert.Equal("10.0.0.8/29", subnet.AddressPrefix);
                Assert.True(nsg.Id.Equals(subnet.NetworkSecurityGroupId,  StringComparison.OrdinalIgnoreCase));

                // Verify NSG
                var subnets = nsg.Refresh().ListAssociatedSubnets();
                Assert.Equal(1, subnets.Count);
                subnet = subnets[0];
                Assert.True(subnet.Name.Equals("subnetB", StringComparison.OrdinalIgnoreCase));
                Assert.True(subnet.Parent.Name.Equals(newName, StringComparison.OrdinalIgnoreCase));
                Assert.NotNull(subnet.NetworkSecurityGroupId);
                INetworkSecurityGroup nsg2 = subnet.GetNetworkSecurityGroup();
                Assert.NotNull(nsg2);
                Assert.True(nsg2.Id.Equals(nsg.Id, StringComparison.OrdinalIgnoreCase));

                network = manager.Networks.GetByResourceGroup(groupName, newName);
                network = network.Update()
                    .WithTag("tag1", "value1")
                    .WithTag("tag2", "value2")
                    .WithAddressSpace("141.25.0.0/16")
                    .WithSubnet("subnetC", "141.25.0.0/29")
                    .WithoutSubnet("subnetA")
                    .UpdateSubnet("subnetB")
                        .WithAddressPrefix("141.25.0.8/29")
                        .WithoutNetworkSecurityGroup()
                        .Parent()
                    .DefineSubnet("subnetD")
                        .WithAddressPrefix("141.25.0.16/29")
                        .WithExistingNetworkSecurityGroup(nsg)
                        .Attach()
                    .Apply();

                // Verify subnets
                Assert.Equal(3, network.Subnets.Count);
                Assert.False(network.Subnets.ContainsKey("subnetA"));

                Assert.True(network.Subnets.ContainsKey("subnetB"));
                subnet = network.Subnets["subnetB"];
                Assert.Equal("141.25.0.8/29", subnet.AddressPrefix);
                Assert.Null(subnet.NetworkSecurityGroupId);

                Assert.True(network.Subnets.ContainsKey("subnetC"));
                subnet = network.Subnets["subnetC"];
                Assert.Equal("141.25.0.0/29", subnet.AddressPrefix);
                Assert.Null(subnet.NetworkSecurityGroupId);

                Assert.True(network.Subnets.ContainsKey("subnetD"));
                subnet = network.Subnets["subnetD"];
                Assert.NotNull(subnet);
                Assert.Equal("141.25.0.16/29", subnet.AddressPrefix);
                Assert.True(nsg.Id.Equals(subnet.NetworkSecurityGroupId, StringComparison.OrdinalIgnoreCase));

                Assert.True(network.Tags.ContainsKey("tag1"));

                manager.Networks.DeleteById(network.Id);
                manager.NetworkSecurityGroups.DeleteById(nsg.Id);
                manager.ResourceManager.ResourceGroups.BeginDeleteByName(groupName);
            }
        }


        public void print(INetwork resource)
        {
            var info = new StringBuilder();
            info.Append("INetwork: ").Append(resource.Id)
                    .Append("Name: ").Append(resource.Name)
                    .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(resource.Region)
                    .Append("\n\tTags: ").Append(resource.Tags)
                    .Append("\n\tAddress spaces: ").Append(resource.AddressSpaces)
                    .Append("\n\tDNS server IPs: ").Append(resource.DnsServerIPs);

            // Output subnets
            foreach (ISubnet subnet in resource.Subnets.Values)
            {
                info.Append("\n\tSubnet: ").Append(subnet.Name)
                    .Append("\n\t\tAddress prefix: ").Append(subnet.AddressPrefix)
                    .Append("\n\tAssociated NSG: ");

                INetworkSecurityGroup nsg;
                try
                {
                    nsg = subnet.GetNetworkSecurityGroup();
                }
                catch
                {
                    nsg = null;
                }

                if (null == nsg)
                {
                    info.Append("(None)");
                }
                else
                {
                    info.Append(nsg.ResourceGroupName + "/" + nsg.Name);
                }
            }

            TestHelper.WriteLine(info.ToString());
        }
    }
}
