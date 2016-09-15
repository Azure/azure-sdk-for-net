using Microsoft.Azure.Management.V2.Network;
using Microsoft.Azure.Management.V2.Resource.Authentication;
using Microsoft.Azure.Management.V2.Resource.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Azure.Tests
{
    public class NetworkTests
    {
        string testId = "" + System.DateTime.Now.Ticks % 100000L;

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void CreateUpdateTest()
        {
            string newName = "net" + this.testId;
            var region = Region.US_WEST;
            var groupName = "rg" + this.testId;

            // Create an NSG
            var manager = TestHelper.CreateNetworkManager();
            var nsg = manager.NetworkSecurityGroups.Define("nsg" + this.testId)
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

            manager.Networks.Delete(resource.Id);
            manager.NetworkSecurityGroups.Delete(nsg.Id);
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
            foreach (ISubnet subnet in resource.Subnets().Values)
            {
                info.Append("\n\tSubnet: ").Append(subnet.Name)
                    .Append("\n\t\tAddress prefix: ").Append(subnet.AddressPrefix)
                    .Append("\n\tAssociated NSG: ");

                INetworkSecurityGroup nsg;
                try
                {
                    nsg = subnet.NetworkSecurityGroup();
                }
                catch (Exception e)
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

            Console.WriteLine(info.ToString());
        }
    }
}
