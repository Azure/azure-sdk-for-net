// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using System;
using System.Linq;
using System.Text;
using Xunit;
using Fluent.Tests.Common;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Azure.Tests;

namespace Fluent.Tests.Network
{
    public class NetworkInterfaceTests
    {
        [Fact]
        public void CreateUpdateTest()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var testId = TestUtilities.GenerateName("");

                var manager = TestHelper.CreateNetworkManager();
                var nic = manager.NetworkInterfaces.Define("nic" + testId)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup("rg" + testId)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithNewPrimaryPublicIPAddress("pipdns" + testId)
                        .WithIPForwarding()
                        .Create();

                // Verify NIC is properly referenced by a subnet
                var ipConfig = nic.PrimaryIPConfiguration;
                Assert.NotNull(ipConfig);
                var network = nic.PrimaryIPConfiguration.GetNetwork();
                Assert.NotNull(network);
                ISubnet subnet;
                Assert.True(network.Subnets.TryGetValue(ipConfig.SubnetName, out subnet));
                Assert.Equal(1, subnet.NetworkInterfaceIPConfigurationCount);
                var ipConfigs = subnet.GetNetworkInterfaceIPConfigurations();
                Assert.NotNull(ipConfigs);
                Assert.Equal(1, ipConfigs.Count);
                var ipConfig2 = ipConfigs.First();
                Assert.Equal(ipConfig.Name.ToLower(), ipConfig2.Name.ToLower());

                var resource = manager.NetworkInterfaces.GetByResourceGroup("rg" + testId, "nic" + testId);
                resource = resource.Update()
                    .WithoutIPForwarding()
                    .UpdateIPConfiguration(resource.PrimaryIPConfiguration.Name) // Updating the primary IP configuration
                        .WithPrivateIPAddressDynamic() // Equivalent to ..update().withPrimaryPrivateIPAddressDynamic()
                        .WithoutPublicIPAddress()      // Equivalent to ..update().withoutPrimaryPublicIPAddress()
                        .Parent()
                    .WithTag("tag1", "value1")
                    .WithTag("tag2", "value2")
                    .Apply();
                Assert.True(resource.Tags.ContainsKey("tag1"));

                manager.NetworkInterfaces.DeleteById(resource.Id);
            }
        }

        [Fact]
        public void CreateBatchOfNetworkInterfaces()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var testId = TestUtilities.GenerateName("");

                var azure = TestHelper.CreateRollupClient();
                var region = Region.USEast;

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
                    .WithPrimaryPrivateIPAddressStatic("10.0.0.5");

                string nic2Name = "nic2";
                ICreatable<INetworkInterface> nic2Creatable = azure.NetworkInterfaces
                .Define(nic2Name)
                .WithRegion(region)
                .WithNewResourceGroup(rgCreatable)
                .WithNewPrimaryNetwork(networkCreatable)
                .WithPrimaryPrivateIPAddressStatic("10.0.0.6");

                string nic3Name = "nic3";
                ICreatable<INetworkInterface> nic3Creatable = azure.NetworkInterfaces
                .Define(nic3Name)
                .WithRegion(region)
                .WithNewResourceGroup(rgCreatable)
                .WithNewPrimaryNetwork(networkCreatable)
                .WithPrimaryPrivateIPAddressStatic("10.0.0.7");

                string nic4Name = "nic4";
                ICreatable<INetworkInterface> nic4Creatable = azure.NetworkInterfaces
                .Define(nic4Name)
                .WithRegion(region)
                .WithNewResourceGroup(rgCreatable)
                .WithNewPrimaryNetwork(networkCreatable)
                .WithPrimaryPrivateIPAddressStatic("10.0.0.8");

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
                azure.ResourceGroups.DeleteByName(resourceGroup.Name);
            }
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
            foreach (string dnsServerIP in resource.DnsServers)
            {
                info.Append("\n\t\t").Append(dnsServerIP);
            }

            info.Append("\n\t IP forwarding enabled: ").Append(resource.IsIPForwardingEnabled)
                    .Append("\n\tMAC Address:").Append(resource.MacAddress)
                    .Append("\n\tPrivate IP:").Append(resource.PrimaryPrivateIP)
                    .Append("\n\tPrivate allocation method:").Append(resource.PrimaryPrivateIPAllocationMethod)
                    .Append("\n\tSubnet Name:").Append(resource.PrimaryIPConfiguration.SubnetName)
                    .Append("\n\tIP configurations: ");

            // Output IP configs
            foreach (INicIPConfiguration ipConfig in resource.IPConfigurations.Values)
            {
                info.Append("\n\t\tName: ").Append(ipConfig.Name)
                    .Append("\n\t\tPrivate IP: ").Append(ipConfig.PrivateIPAddress)
                    .Append("\n\t\tPrivate IP allocation method: ").Append(ipConfig.PrivateIPAllocationMethod)
                    .Append("\n\t\tPIP id: ").Append(ipConfig.PublicIPAddressId)
                    .Append("\n\t\tSubnet Name: ").Append(ipConfig.SubnetName);
            }

            TestHelper.WriteLine(info.ToString());
        }
    }
}