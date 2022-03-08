using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;
using System.Linq;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.Network.Models;
using System.Threading;


namespace Networks.Tests
{
    public class NetworkManagerGroupTests
    {
        [Fact(Skip = "Disable tests")]
        public void NetworkManagerGroupTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                // var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/networkManagers");
                var location = "eastus2euap";
                string resourceGroupName = TestUtilities.GenerateName("ANMGROUPRG");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                NetworkManagerPropertiesNetworkManagerScopes scope = new NetworkManagerPropertiesNetworkManagerScopes();
                string subscriptionId = "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52";
                List<string> subList = new List<string>();
                subList.Add(subscriptionId);
                scope.Subscriptions = subList;

                IList<string> networkManagerScopeAccesses = new List<string>();
                networkManagerScopeAccesses.Add("SecurityAdmin");

                var networkManager = new NetworkManager()
                {
                    Location = location,
                    NetworkManagerScopes = scope,
                    NetworkManagerScopeAccesses = networkManagerScopeAccesses
                };

                string networkManagerName = TestUtilities.GenerateName("ANM");

                // Put networkManager
                var putNMResponse = networkManagementClient.NetworkManagers.CreateOrUpdate(networkManager, resourceGroupName, networkManagerName);
                Assert.Equal(networkManagerName, putNMResponse.Name);

                string groupName = TestUtilities.GenerateName("ANMNG");
                string memberType = "Microsoft.Network/virtualNetworks";
                var networkManagerGroup = new NetworkGroup()
                {
                    MemberType = memberType
                };

                // Put NetworkManagerGroup
                var putNmGroupResponse = networkManagementClient.NetworkGroups.CreateOrUpdate(networkManagerGroup, resourceGroupName, networkManagerName, groupName);
                Assert.Equal(groupName, putNmGroupResponse.Name);
                Assert.Equal("Succeeded", putNmGroupResponse.ProvisioningState);

                // Get NetworkManagerGroup
                var getNmGroupResponse = networkManagementClient.NetworkGroups.Get(resourceGroupName, networkManagerName, groupName);
                Assert.Equal(groupName, getNmGroupResponse.Name);
                Assert.Equal("Succeeded", getNmGroupResponse.ProvisioningState);

                // List NetworkManagerGroup
                var listNmGroupResponse = networkManagementClient.NetworkGroups.List(resourceGroupName, networkManagerName);
                Assert.Single(listNmGroupResponse);
                Assert.Equal(groupName, listNmGroupResponse.First().Name);

                // Delete NetworkManagerGroup
                networkManagementClient.NetworkGroups.Delete(resourceGroupName, networkManagerName, groupName);

                // List NetworkManagerGroup
                listNmGroupResponse = networkManagementClient.NetworkGroups.List(resourceGroupName, networkManagerName);
                Assert.Empty(listNmGroupResponse);

                // Delete NetworkManager
                networkManagementClient.NetworkManagers.Delete(resourceGroupName, networkManagerName);

                // List networkManager
                var listNMResponse = networkManagementClient.NetworkManagers.List(resourceGroupName);
                Assert.Empty(listNMResponse);
            }
        }

        [Fact(Skip = "Disable tests")]
        public void NetworkManagerStaticMembersTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                // var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/networkManagers");
                var location = "eastus2euap";
                string resourceGroupName = TestUtilities.GenerateName("ANMGROUPRG");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                NetworkManagerPropertiesNetworkManagerScopes scope = new NetworkManagerPropertiesNetworkManagerScopes();
                string subscriptionId = "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52";
                List<string> subList = new List<string>();
                subList.Add(subscriptionId);
                scope.Subscriptions = subList;

                IList<string> networkManagerScopeAccesses = new List<string>();
                networkManagerScopeAccesses.Add("SecurityAdmin");

                var networkManager = new NetworkManager()
                {
                    Location = location,
                    NetworkManagerScopes = scope,
                    NetworkManagerScopeAccesses = networkManagerScopeAccesses
                };

                string networkManagerName = TestUtilities.GenerateName("ANM");

                // Put networkManager
                var putNMResponse = networkManagementClient.NetworkManagers.CreateOrUpdate(networkManager, resourceGroupName, networkManagerName);
                Assert.Equal(networkManagerName, putNMResponse.Name);

                string groupName = TestUtilities.GenerateName("ANMNG");
                string memberType = "Microsoft.Network/virtualNetworks";
                var networkManagerGroup = new NetworkGroup()
                {
                    MemberType = memberType
                };

                // Put NetworkManagerGroup
                var putNmGroupResponse = networkManagementClient.NetworkGroups.CreateOrUpdate(networkManagerGroup, resourceGroupName, networkManagerName, groupName);
                Assert.Equal(groupName, putNmGroupResponse.Name);
                Assert.Equal("Succeeded", putNmGroupResponse.ProvisioningState);


                string staticMemberName = TestUtilities.GenerateName("ANMStatMem");
                string vnetId = "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/SDKTestResources/providers/Microsoft.Network/virtualNetworks/SDKTestVnet";
                var staticMember = new StaticMember()
                {
                    ResourceId = vnetId,
                };

                // Put NetworkManagerStaticMember
                var putStaticMemberResponse = networkManagementClient.StaticMembers.CreateOrUpdate(staticMember, resourceGroupName, networkManagerName, groupName, staticMemberName);
                Assert.Equal(staticMemberName, putStaticMemberResponse.Name);
                Assert.Equal(vnetId, putStaticMemberResponse.ResourceId);

                // Get NetworkManagerStaticMember
                var getStaticMemberResponse = networkManagementClient.StaticMembers.Get(resourceGroupName, networkManagerName, groupName, staticMemberName);
                Assert.Equal(staticMemberName, getStaticMemberResponse.Name);
                Assert.Equal(vnetId, getStaticMemberResponse.ResourceId);

                // List NetworkManagerStaticMember
                var listStaticMemberResponse = networkManagementClient.StaticMembers.List(resourceGroupName, networkManagerName, groupName);
                Assert.Equal(staticMemberName, listStaticMemberResponse.First().Name);
                Assert.Equal(vnetId, listStaticMemberResponse.First().ResourceId);

                // Delete NetworkManagerStaticMember
                networkManagementClient.StaticMembers.Delete(resourceGroupName, networkManagerName, groupName, staticMemberName);

                Thread.Sleep(5000);

                // List NetworkManagerStaticMember
                listStaticMemberResponse = networkManagementClient.StaticMembers.List(resourceGroupName, networkManagerName, groupName);
                Assert.Empty(listStaticMemberResponse);

                // Delete NetworkManagerGroup
                networkManagementClient.NetworkGroups.Delete(resourceGroupName, networkManagerName, groupName);

                // List NetworkManagerGroup
                var listNmGroupResponse = networkManagementClient.NetworkGroups.List(resourceGroupName, networkManagerName);
                Assert.Empty(listNmGroupResponse);

                // Delete NetworkManager
                networkManagementClient.NetworkManagers.Delete(resourceGroupName, networkManagerName);

                // List networkManager
                var listNMResponse = networkManagementClient.NetworkManagers.List(resourceGroupName);
                Assert.Empty(listNMResponse);
            }
        }
    }
}