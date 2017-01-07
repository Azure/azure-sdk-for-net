// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Text;
using Xunit;

namespace Fluent.Tests.Network
{
    public class NetworkTests
    {

        [Fact]
        public void CreateUpdateTest()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var testId = TestUtilities.GenerateName("");

                string newName = "net" + testId;
                var region = Region.US_WEST;
                var groupName = "rg" + testId;

                // Create an NSG
                var manager = TestHelper.CreateNetworkManager();
                var nsg = manager.NetworkSecurityGroups.Define("nsg" + testId)
                    .WithRegion(region)
                    .WithNewResourceGroup(groupName)
                    .Create();

                // Create a network
                manager.Networks.Define(newName)
                        .WithRegion(region)
                        .WithNewResourceGroup(groupName)
                        .WithAddressSpace("10.0.0.0/28")
                        .WithSubnet("subnetA", "10.0.0.0/29")
                        .DefineSubnet("subnetB")
                            .WithAddressPrefix("10.0.0.8/29")
                            .WithExistingNetworkSecurityGroup(nsg)
                            .Attach()
                        .Create();

                var resource = manager.Networks.GetByGroup(groupName, newName);
                resource = resource.Update()
                    .WithTag("tag1", "value1")
                    .WithTag("tag2", "value2")
                    .WithAddressSpace("141.25.0.0/16")
                    .WithSubnet("subnetC", "141.25.0.0/29")
                    .WithoutSubnet("subnetA")
                    .UpdateSubnet("subnetB")
                        .WithAddressPrefix("141.25.0.8/29")
                        .WithExistingNetworkSecurityGroup(nsg)
                        .Parent()
                    .DefineSubnet("subnetD")
                        .WithAddressPrefix("141.25.0.16/29")
                        .WithExistingNetworkSecurityGroup(nsg)
                        .Attach()
                    .Apply();
                Assert.True(resource.Tags.ContainsKey("tag1"));

                manager.Networks.DeleteById(resource.Id);
                manager.NetworkSecurityGroups.DeleteById(nsg.Id);
                manager.ResourceManager.ResourceGroups.DeleteByName(groupName);
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
                    .Append("\n\tDNS server IPs: ").Append(resource.DnsServerIps);

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
