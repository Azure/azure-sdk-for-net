using System.Net;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;

namespace Networks.Tests
{
    using System.Linq;

    public class UsageTests
    {
        [Fact]
        public void UsageTest()
        {
            var handler = new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK};

            using (var context = UndoContext.Current)
            {
                context.Start();
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(handler);
                var networkResourceProviderClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);

                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/networkSecurityGroups");
                
                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                string networkSecurityGroupName = TestUtilities.GenerateName();

                var networkSecurityGroup = new NetworkSecurityGroup()
                {
                    Location = location,
                };

                // Put Nsg
                var putNsgResponse = networkResourceProviderClient.NetworkSecurityGroups.CreateOrUpdate(resourceGroupName, networkSecurityGroupName, networkSecurityGroup);
                Assert.Equal(HttpStatusCode.OK, putNsgResponse.StatusCode);
                Assert.Equal("Succeeded", putNsgResponse.Status);

                var getNsgResponse = networkResourceProviderClient.NetworkSecurityGroups.Get(resourceGroupName, networkSecurityGroupName);
                Assert.Equal(HttpStatusCode.OK, getNsgResponse.StatusCode);

                // Query for usages
                var usagesResponse = networkResourceProviderClient.Usages.List(getNsgResponse.NetworkSecurityGroup.Location.Replace(" ", string.Empty));
                Assert.True(usagesResponse.StatusCode == HttpStatusCode.OK);

                // Verify that the strings are populated
                Assert.NotNull(usagesResponse.Usages);
                Assert.True(usagesResponse.Usages.Any());

                foreach (var usage in usagesResponse.Usages)
                {
                    Assert.True(usage.Limit > 0);
                    Assert.NotNull(usage.Name);
                    Assert.True(!string.IsNullOrEmpty(usage.Name.LocalizedValue));
                    Assert.True(!string.IsNullOrEmpty(usage.Name.Value));
                }
            }
        }
    }
}