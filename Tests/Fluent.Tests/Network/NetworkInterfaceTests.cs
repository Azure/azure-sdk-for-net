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
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fluent.Tests.Network
{
    public class NetworkInterface
    {
        [Fact]
        public void CanUseMultipleIPConfigs()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var testId = TestUtilities.GenerateName("");
                var networkManager = TestHelper.CreateNetworkManager();

                string resourceGroupName = SdkContext.RandomResourceName("rg", 15);
                string networkName = SdkContext.RandomResourceName("net", 15);
                string[] nicNames = new string[3];
                for (int i = 0; i < nicNames.Length; i++)
                {
                    nicNames[i] = SdkContext.RandomResourceName("nic", 15);
                }

                var network = networkManager.Networks.Define(networkName)
                    .WithRegion(Region.USEast)
                    .WithNewResourceGroup(resourceGroupName)
                    .WithAddressSpace("10.0.0.0/27")
                    .WithSubnet("subnet1", "10.0.0.0/28")
                    .WithSubnet("subnet2", "10.0.0.16/28")
                    .Create();

                IList<ICreatable<INetworkInterface>> nicDefinitions = new List<ICreatable<INetworkInterface>> {
                    // 0 - NIC that starts with one IP config and ends with two
                    networkManager.NetworkInterfaces.Define(nicNames[0])
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(resourceGroupName)
                        .WithExistingPrimaryNetwork(network)
                        .WithSubnet("subnet1")
                        .WithPrimaryPrivateIPAddressDynamic(),

                    // 1 - NIC that starts with two IP configs and ends with one
                    networkManager.NetworkInterfaces.Define(nicNames[1])
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(resourceGroupName)
                        .WithExistingPrimaryNetwork(network)
                        .WithSubnet("subnet1")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .DefineSecondaryIPConfiguration("nicip2")
                            .WithExistingNetwork(network)
                            .WithSubnet("subnet1")
                            .WithPrivateIPAddressDynamic()
                            .Attach(),

                    // 2 - NIC that starts with two IP configs and ends with two
                    networkManager.NetworkInterfaces.Define(nicNames[2])
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(resourceGroupName)
                        .WithExistingPrimaryNetwork(network)
                        .WithSubnet("subnet1")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .DefineSecondaryIPConfiguration("nicip2")
                            .WithExistingNetwork(network)
                            .WithSubnet("subnet1")
                            .WithPrivateIPAddressDynamic()
                            .Attach()
                };

                // Create the NICs in parallel
                var createdNics = networkManager.NetworkInterfaces.Create(nicDefinitions);

                INetworkInterface[] nics = new INetworkInterface[nicDefinitions.Count];
                for (int i = 0; i < nicDefinitions.Count; i++)
                {
                    nics[i] = createdNics.FirstOrDefault(n => n.Key == nicDefinitions[i].Key);
                }

                INicIPConfiguration primaryIPConfig, secondaryIPConfig;
                INetworkInterface nic;

                // Verify NIC0
                nic = nics[0];
                Assert.NotNull(nic);
                primaryIPConfig = nic.PrimaryIPConfiguration;
                Assert.NotNull(primaryIPConfig);
                Assert.True("subnet1".Equals(primaryIPConfig.SubnetName, StringComparison.OrdinalIgnoreCase));
                Assert.True(network.Id.Equals(primaryIPConfig.NetworkId, StringComparison.OrdinalIgnoreCase));

                // Verify NIC1
                nic = nics[1];
                Assert.NotNull(nic);
                Assert.Equal(2, nic.IPConfigurations.Count);

                primaryIPConfig = nic.PrimaryIPConfiguration;
                Assert.NotNull(primaryIPConfig);
                Assert.True("subnet1".Equals(primaryIPConfig.SubnetName, StringComparison.OrdinalIgnoreCase));
                Assert.True(network.Id.Equals(primaryIPConfig.NetworkId, StringComparison.OrdinalIgnoreCase));

                Assert.True(nic.IPConfigurations.TryGetValue("nicip2", out secondaryIPConfig));
                Assert.True("subnet1".Equals(primaryIPConfig.SubnetName, StringComparison.OrdinalIgnoreCase));
                Assert.True(network.Id.Equals(secondaryIPConfig.NetworkId, StringComparison.OrdinalIgnoreCase));

                // Verify NIC2
                nic = nics[2];
                Assert.NotNull(nic);
                Assert.Equal(2, nic.IPConfigurations.Count);

                primaryIPConfig = nic.PrimaryIPConfiguration;
                Assert.NotNull(primaryIPConfig);
                Assert.True("subnet1".Equals(primaryIPConfig.SubnetName, StringComparison.OrdinalIgnoreCase));
                Assert.True(network.Id.Equals(primaryIPConfig.NetworkId, StringComparison.OrdinalIgnoreCase));

                Assert.True(nic.IPConfigurations.TryGetValue("nicip2", out secondaryIPConfig));
                Assert.True("subnet1".Equals(secondaryIPConfig.SubnetName, StringComparison.OrdinalIgnoreCase));
                Assert.True(network.Id.Equals(secondaryIPConfig.NetworkId, StringComparison.OrdinalIgnoreCase));

                nic = null;

                // Updates
                IList<Task<INetworkInterface>> nicUpdates = new List<Task<INetworkInterface>>()
                {
                    // Update NIC0
                    nics[0].Update()
                        .DefineSecondaryIPConfiguration("nicip2")
                            .WithExistingNetwork(network)
                            .WithSubnet("subnet1")
                            .WithPrivateIPAddressDynamic()
                            .Attach()
                        .ApplyAsync(),

                    // Update NIC2
                    nics[1].Update()
                        .WithoutIPConfiguration("nicip2")
                        .UpdateIPConfiguration("primary")
                            .WithSubnet("subnet2")
                            .Parent()
                        .ApplyAsync(),

                    // Update NIC2
                    nics[2].Update()
                        .WithoutIPConfiguration("nicip2")
                        .DefineSecondaryIPConfiguration("nicip3")
                            .WithExistingNetwork(network)
                            .WithSubnet("subnet1")
                            .WithPrivateIPAddressDynamic()
                            .Attach()
                        .ApplyAsync()
                };

                var updatedNics = Task.WhenAll(nicUpdates).Result;

                // Verify updated NICs
                foreach (var n in updatedNics)
                {
                    if (n.Id.Equals(nics[0].Id, StringComparison.OrdinalIgnoreCase))
                    {
                        // Verify NIC0
                        Assert.Equal(2, n.IPConfigurations.Count);

                        primaryIPConfig = n.PrimaryIPConfiguration;
                        Assert.NotNull(primaryIPConfig);
                        Assert.True("subnet1".Equals(primaryIPConfig.SubnetName, StringComparison.OrdinalIgnoreCase));
                        Assert.True(network.Id.Equals(primaryIPConfig.NetworkId, StringComparison.OrdinalIgnoreCase));

                        Assert.True(n.IPConfigurations.TryGetValue("nicip2", out secondaryIPConfig));
                        Assert.True("subnet1".Equals(secondaryIPConfig.SubnetName, StringComparison.OrdinalIgnoreCase));
                        Assert.True(network.Id.Equals(secondaryIPConfig.NetworkId, StringComparison.OrdinalIgnoreCase));
                    }
                    else if (n.Id.Equals(nics[1].Id, StringComparison.OrdinalIgnoreCase))
                    {
                        // Verify NIC1
                        Assert.Equal(1, n.IPConfigurations.Count);
                        primaryIPConfig = n.PrimaryIPConfiguration;
                        Assert.NotNull(primaryIPConfig);
                        Assert.False("nicip2".Equals(primaryIPConfig.Name, StringComparison.OrdinalIgnoreCase));
                        Assert.True("subnet2".Equals(primaryIPConfig.SubnetName, StringComparison.OrdinalIgnoreCase));
                        Assert.True(network.Id.Equals(primaryIPConfig.NetworkId, StringComparison.OrdinalIgnoreCase));
                    }
                    else if (n.Id.Equals(nics[2].Id, StringComparison.OrdinalIgnoreCase))
                    {
                        // Verify NIC3
                        Assert.Equal(2, n.IPConfigurations.Count);

                        primaryIPConfig = n.PrimaryIPConfiguration;
                        Assert.NotNull(primaryIPConfig);
                        Assert.False("nicip2".Equals(primaryIPConfig.Name, StringComparison.OrdinalIgnoreCase));
                        Assert.False("nicip3".Equals(primaryIPConfig.Name, StringComparison.OrdinalIgnoreCase));
                        Assert.True("subnet1".Equals(primaryIPConfig.SubnetName, StringComparison.OrdinalIgnoreCase));
                        Assert.True(network.Id.Equals(primaryIPConfig.NetworkId, StringComparison.OrdinalIgnoreCase));

                        Assert.True(n.IPConfigurations.TryGetValue("nicip3", out secondaryIPConfig));
                        Assert.True("subnet1".Equals(secondaryIPConfig.SubnetName));
                        Assert.True(network.Id.Equals(secondaryIPConfig.NetworkId));
                    }
                    else
                    {
                        Assert.True(false); // Unrecognized NIC ID 
                    }
                }
                networkManager.ResourceManager.ResourceGroups.BeginDeleteByName(resourceGroupName);
            }
        }

        [Fact]
        public void CreateUpdate()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var testId = TestUtilities.GenerateName("");
                string nicName = "nic" + testId;
                string vnetName = "net" + testId;
                string pipName = "pip" + testId;
                Region region = Region.USEast;

                var manager = TestHelper.CreateNetworkManager();

                var network = manager.Networks.Define(vnetName)
                    .WithRegion(region)
                    .WithNewResourceGroup()
                    .WithAddressSpace("10.0.0.0/28")
                    .WithSubnet("subnet1", "10.0.0.0/29")
                    .WithSubnet("subnet2", "10.0.0.8/29")
                    .Create();

                var nic = manager.NetworkInterfaces.Define(nicName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(network.ResourceGroupName)
                        .WithExistingPrimaryNetwork(network)
                        .WithSubnet("subnet1")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithNewPrimaryPublicIPAddress(pipName)
                        .WithIPForwarding()
                        .WithAcceleratedNetworking()
                        .Create();

                // Verify NIC settings
                Assert.True(nic.IsAcceleratedNetworkingEnabled);
                Assert.True(nic.IsIPForwardingEnabled);

                // Veirfy IP configs
                var ipConfig = nic.PrimaryIPConfiguration;
                Assert.NotNull(ipConfig);
                network = ipConfig.GetNetwork();
                Assert.NotNull(network);
                ISubnet subnet;
                Assert.True(network.Subnets.TryGetValue(ipConfig.SubnetName, out subnet));
                Assert.Equal(1, subnet.NetworkInterfaceIPConfigurationCount);
                var ipConfigs = subnet.GetNetworkInterfaceIPConfigurations();
                Assert.NotNull(ipConfigs);
                Assert.Equal(1, ipConfigs.Count);

                INicIPConfiguration ipConfig2 = null;
                ipConfig2 = ipConfigs.FirstOrDefault(i => i.Name.Equals(ipConfig.Name, StringComparison.OrdinalIgnoreCase));
                Assert.NotNull(ipConfig2);
                Assert.True(ipConfig.Name.Equals(ipConfig2.Name, StringComparison.OrdinalIgnoreCase));

                var resource = manager.NetworkInterfaces.GetById(nic.Id);
                resource = resource.Update()
                    .WithoutIPForwarding()
                    .WithoutAcceleratedNetworking()
                    .WithSubnet("subnet2")
                    .UpdateIPConfiguration(resource.PrimaryIPConfiguration.Name) // Updating the primary IP configuration
                        .WithPrivateIPAddressDynamic() // Equivalent to ..update().withPrimaryPrivateIPAddressDynamic()
                        .WithoutPublicIPAddress()      // Equivalent to ..update().withoutPrimaryPublicIPAddress()
                        .Parent()
                    .WithTag("tag1", "value1")
                    .WithTag("tag2", "value2")
                    .Apply();
                Assert.True(resource.Tags.ContainsKey("tag1"));

                // Verifications
                Assert.False(resource.IsIPForwardingEnabled);
                Assert.False(resource.IsAcceleratedNetworkingEnabled);
                var primaryIpConfig = resource.PrimaryIPConfiguration;
                Assert.NotNull(primaryIpConfig);
                Assert.True(primaryIpConfig.IsPrimary);
                Assert.True("subnet2" == primaryIpConfig.SubnetName.ToLower());
                Assert.Null(primaryIpConfig.PublicIPAddressId);
                Assert.True(resource.Tags.ContainsKey("tag1"));

                manager.NetworkInterfaces.DeleteById(resource.Id);
                resource.Manager.ResourceManager.ResourceGroups.BeginDeleteByName(resource.ResourceGroupName);

                Assert.Equal(1, resource.IPConfigurations.Count);
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

            info.Append("\n\tIP forwarding enabled: ").Append(resource.IsIPForwardingEnabled)
                    .Append("\n\tAccelerated networking enabled: ").Append(resource.IsAcceleratedNetworkingEnabled)
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