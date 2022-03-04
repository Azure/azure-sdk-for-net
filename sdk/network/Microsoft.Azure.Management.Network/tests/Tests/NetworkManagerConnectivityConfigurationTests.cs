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
using System;

namespace Networks.Tests
{
    public class NetworkManagerConnectivityConfigurationTests
    {
        [Fact(Skip = "Disable tests")]
        public void NetworkManagerConnectivityConfigurationTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                // var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/networkManagers");
                var location = "eastus2euap";

                string resourceGroupName = TestUtilities.GenerateName("ANMCCRG");
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

                IList<string> networkManagerScopeAccess = new List<string>();
                networkManagerScopeAccess.Add("Connectivity");

                var networkManager = new NetworkManager()
                {
                    Location = location,
                    NetworkManagerScopes = scope,
                    NetworkManagerScopeAccesses = networkManagerScopeAccess
                };

                string networkManagerName = TestUtilities.GenerateName("ANM");

                // Put networkManager
                var putNMResponse = networkManagementClient.NetworkManagers.CreateOrUpdate(networkManager, resourceGroupName, networkManagerName);
                Assert.Equal(networkManagerName, putNMResponse.Name);
                Assert.Equal("Succeeded", putNMResponse.ProvisioningState);

                string groupName = TestUtilities.GenerateName("ANMNG");
                var networkManagerGroup = new NetworkGroup()
                {
                    MemberType = "Microsoft.Network/virtualNetworks"
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

                string ngId = $"/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkManagers/{networkManagerName}/networkGroups/{groupName}";
                ConnectivityGroupItem sgItem = new ConnectivityGroupItem(ngId, useHubGateway: "true", groupConnectivity: "None");
                List<ConnectivityGroupItem> appliesToGroups = new List<ConnectivityGroupItem>();
                appliesToGroups.Add(sgItem);

                string connectivityPolicyName = TestUtilities.GenerateName("ANMConn");
                Hub hub = new Hub();
                hub.ResourceId = "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/SDKTestResources/providers/Microsoft.Network/virtualNetworks/SDKTestHub";
                hub.ResourceType = "Microsoft.Network/virtualNetworks";
                List<Hub> hubList = new List<Hub>();
                hubList.Add(hub);
                var connectivityconfig = new ConnectivityConfiguration("HubAndSpoke",
                                                                       name: connectivityPolicyName,
                                                                       hubs: hubList,
                                                                       deleteExistingPeering: "true",
                                                                       appliesToGroups: appliesToGroups);

                // Put NetworkManagerConnectivityConfiguration
                var putNmccResponse = networkManagementClient.ConnectivityConfigurations.CreateOrUpdate(connectivityconfig, resourceGroupName, networkManagerName, connectivityPolicyName);
                Assert.Equal(connectivityPolicyName, putNmccResponse.Name);
                Assert.Equal("Succeeded", putNmccResponse.ProvisioningState);

                // Get NetworkManagerConnectivityConfiguration
                var getNmccResponse = networkManagementClient.ConnectivityConfigurations.Get(resourceGroupName, networkManagerName, connectivityPolicyName);
                Assert.Equal(connectivityPolicyName, getNmccResponse.Name);
                Assert.Equal(hub.ResourceId, getNmccResponse.Hubs.First().ResourceId);
                Assert.Equal("False", getNmccResponse.IsGlobal);
                Assert.Equal("True", getNmccResponse.DeleteExistingPeering);
                Assert.Equal("HubAndSpoke", getNmccResponse.ConnectivityTopology);
                Assert.Equal(1, getNmccResponse.AppliesToGroups.Count);
                Assert.Equal(ngId, getNmccResponse.AppliesToGroups.First().NetworkGroupId);
                Assert.Equal("None", getNmccResponse.AppliesToGroups.First().GroupConnectivity);
                Assert.Equal("True", getNmccResponse.AppliesToGroups.First().UseHubGateway);
                Assert.Equal("False", getNmccResponse.AppliesToGroups.First().IsGlobal);

                // List NetworkManagerConnectivityConfiguration
                var listNmccResponse = networkManagementClient.ConnectivityConfigurations.List(resourceGroupName, networkManagerName);
                Assert.Single(listNmccResponse);
                Assert.Equal(connectivityPolicyName, listNmccResponse.First().Name);

                NetworkManagerCommit commit = new NetworkManagerCommit();
                commit.CommitType = "Connectivity";
                commit.ConfigurationIds = new List<string>();
                commit.ConfigurationIds.Add(getNmccResponse.Id);
                commit.TargetLocations = new List<string>();
                commit.TargetLocations.Add(location);
                networkManagementClient.NetworkManagerCommits.Post(commit, resourceGroupName, networkManagerName);

                Thread.Sleep(100000);

                // Active Connective Configuration Check
                ActiveConfigurationParameter activeConfigurationParameter = new ActiveConfigurationParameter();
                activeConfigurationParameter.Regions = new List<string>();
                activeConfigurationParameter.Regions.Add(location);
                var activeConnectiveConfigrautionsResponse = networkManagementClient.ListActiveConnectivityConfigurations(activeConfigurationParameter, resourceGroupName, networkManagerName);

                Assert.Single(activeConnectiveConfigrautionsResponse.Value);
                Assert.Equal(getNmccResponse.Id, activeConnectiveConfigrautionsResponse.Value.First().Id);
                Assert.Single(activeConnectiveConfigrautionsResponse.Value.First().ConfigurationGroups);
                Assert.Equal(ngId, activeConnectiveConfigrautionsResponse.Value.First().ConfigurationGroups.First().Id);
                Assert.Equal(ngId, activeConnectiveConfigrautionsResponse.Value.First().ConfigurationGroups.First().Id);
                Assert.Equal("HubAndSpoke", activeConnectiveConfigrautionsResponse.Value.First().ConnectivityTopology);
                Assert.Equal(hub.ResourceId, activeConnectiveConfigrautionsResponse.Value.First().Hubs.First().ResourceId);

                NetworkManagerCommit unCommit = new NetworkManagerCommit();
                unCommit.CommitType = "Connectivity";
                unCommit.ConfigurationIds = new List<string>();
                unCommit.TargetLocations = new List<string>();
                unCommit.TargetLocations.Add(location);
                networkManagementClient.NetworkManagerCommits.Post(unCommit, resourceGroupName, networkManagerName);

                Thread.Sleep(100000);

                // Delete NetworkManagerConnectivityConfiguration
                networkManagementClient.ConnectivityConfigurations.Delete(resourceGroupName, networkManagerName, connectivityPolicyName, true);

                // List NetworkManagerConnectivityConfiguration
                listNmccResponse = networkManagementClient.ConnectivityConfigurations.List(resourceGroupName, networkManagerName);
                Assert.Empty(listNmccResponse);

                // Delete NetworkManager StaticMember
                networkManagementClient.StaticMembers.Delete(resourceGroupName, networkManagerName, groupName, staticMemberName);

                // Delete NetworkManager NetworkGroup
                networkManagementClient.NetworkGroups.Delete(resourceGroupName, networkManagerName, groupName);

                // Delete NetworkManager
                networkManagementClient.NetworkManagers.Delete(resourceGroupName, networkManagerName);
            }
        }
    }
}