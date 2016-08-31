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

    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.Azure.Test.HttpRecorder;

    public class UsageTests
    {
        public UsageTests()
        {
            HttpMockServer.RecordsDirectory = "SessionRecords";
        }

        [Fact]
        public void UsageTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

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
                var putNsgResponse = networkManagementClient.NetworkSecurityGroups.CreateOrUpdate(resourceGroupName, networkSecurityGroupName, networkSecurityGroup);
                Assert.Equal("Succeeded", putNsgResponse.ProvisioningState);

                var getNsgResponse = networkManagementClient.NetworkSecurityGroups.Get(resourceGroupName, networkSecurityGroupName);
                
                // Query for usages
                var usagesResponse = networkManagementClient.Usages.List(getNsgResponse.Location.Replace(" ", string.Empty));
                
                // Verify that the strings are populated
                Assert.NotNull(usagesResponse);
                Assert.True(usagesResponse.Any());

                foreach (var usage in usagesResponse)
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