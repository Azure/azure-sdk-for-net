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
                    .Append("\n\tSubnet Id:").Append(resource.PrimarySubnetId)
                    .Append("\n\tIP configurations: ");

            // Output IP configs
            foreach (INicIpConfiguration ipConfig in resource.IpConfigurations())
            {
                info.Append("\n\t\tName: ").Append(ipConfig.Name)
                    .Append("\n\t\tPrivate IP: ").Append(ipConfig.PrivateIp)
                    .Append("\n\t\tPrivate IP allocation method: ").Append(ipConfig.PrivateIpAllocationMethod)
                    .Append("\n\t\tPIP id: ").Append(ipConfig.PublicIpAddressId)
                    .Append("\n\t\tSubnet ID: ").Append(ipConfig.SubnetId);
            }

            System.Console.WriteLine(info.ToString());
        }
    }
}
