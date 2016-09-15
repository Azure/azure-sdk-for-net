using Microsoft.Azure.Management.V2.Network;
using Microsoft.Azure.Management.V2.Resource.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Azure.Tests
{
    public class IPublicIpAddressTests
    {
        string testId = "" + System.DateTime.Now.Ticks % 100000L;

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void CreateUpdateTest()
        {
            var newPipName = "pip" + this.testId;
            var newRG = "rg" + this.testId;
            var manager = TestHelper.CreateNetworkManager();
            var pip = manager.PublicIpAddresses.Define(newPipName)
                .WithRegion(Region.US_WEST)
                .WithNewResourceGroup(newRG)
                .WithDynamicIp()
                .WithLeafDomainLabel(newPipName)
                .WithIdleTimeoutInMinutes(10)
                .Create();

            var resource = manager.PublicIpAddresses.GetByGroup(newRG, newPipName);
            var updatedDnsName = resource.LeafDomainLabel + "xx";
            var updatedIdleTimeout = 15;
            resource = resource.Update()
                    .WithStaticIp()
                    .WithLeafDomainLabel(updatedDnsName)
                    .WithReverseFqdn(resource.LeafDomainLabel + "." + resource.RegionName + ".cloudapp.azure.com")
                    .WithIdleTimeoutInMinutes(updatedIdleTimeout)
                    .WithTag("tag1", "value1")
                    .WithTag("tag2", "value2")
                    .Apply();
            Assert.True(resource.LeafDomainLabel.Equals(updatedDnsName, StringComparison.OrdinalIgnoreCase));
            Assert.True(resource.IdleTimeoutInMinutes == updatedIdleTimeout);

            manager.PublicIpAddresses.Delete(pip.Id);

        }


        public void print(IPublicIpAddress resource)
        {
            System.Console.WriteLine(new StringBuilder().Append("Public IP Address: ").Append(resource.Id)
                    .Append("Name: ").Append(resource.Name)
                    .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(resource.Region)
                    .Append("\n\tTags: ").Append(resource.Tags)
                    .Append("\n\tIP Address: ").Append(resource.IpAddress)
                    .Append("\n\tLeaf domain label: ").Append(resource.LeafDomainLabel)
                    .Append("\n\tFQDN: ").Append(resource.Fqdn)
                    .Append("\n\tReverse FQDN: ").Append(resource.ReverseFqdn)
                    .Append("\n\tIdle timeout (minutes): ").Append(resource.IdleTimeoutInMinutes)
                    .Append("\n\tIP allocation method: ").Append(resource.IpAllocationMethod.ToString())
                    .ToString());
        }
    }
}
