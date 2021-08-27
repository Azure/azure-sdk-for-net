using System.Net;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Linq;

namespace Networks.Tests
{
    public class NetworkManagerSecurityUserConfigurationTests
    {
        [Fact(Skip = "Disable tests")]
        public void NetworkManagerSecurityUserConfigurationTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                // var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/networkManagers");
                var location = "jioindiacentral";
                string resourceGroupName = TestUtilities.GenerateName("ANMSCRG");
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
                networkManagerScopeAccess.Add("SecurityUser");

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

                string networkmanagerSecurityUserConfigName = TestUtilities.GenerateName("ANMSUC");

                var networkmanagerSecurityUserConfig = new SecurityConfiguration();
                networkmanagerSecurityUserConfig.DisplayName = "Sample DisplayName";
                networkmanagerSecurityUserConfig.Description = "Sample Description";

                // Put NetworkManagerSecurityConfiguration
                var putNmscResponse = networkManagementClient.SecurityUserConfigurations.CreateOrUpdate(networkmanagerSecurityUserConfig, resourceGroupName, networkManagerName, networkmanagerSecurityUserConfigName);
                Assert.Equal("Succeeded", putNmscResponse.ProvisioningState);

                // Get NetworkManagerSecurityConfiguration
                var getNmscResponse = networkManagementClient.SecurityUserConfigurations.Get(resourceGroupName, networkManagerName, networkmanagerSecurityUserConfigName);
                Assert.Equal(networkmanagerSecurityUserConfigName, getNmscResponse.Name);

                // List NetworkManagerSecurityConfigurations
                var listNmUserConfigResponse = networkManagementClient.SecurityUserConfigurations.List(resourceGroupName, networkManagerName);
                Assert.Single(listNmUserConfigResponse);
                Assert.Equal(networkmanagerSecurityUserConfigName, listNmUserConfigResponse.First().Name);

                // Delete NetworkManagerSecurityConfigurations
                networkManagementClient.SecurityUserConfigurations.Delete(resourceGroupName, networkManagerName, networkmanagerSecurityUserConfigName);

                // List NetworkManagerSecurityConfigurations
                listNmUserConfigResponse = networkManagementClient.SecurityUserConfigurations.List(resourceGroupName, networkManagerName);
                Assert.Empty(listNmUserConfigResponse);

                // Delete NetworkManager
                networkManagementClient.NetworkManagers.Delete(resourceGroupName, networkManagerName);
            }
        }

        [Fact(Skip = "Disable tests")]
        public void NetworkManagerSecuirtyUserRuleCollectionsTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                // var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/networkSecurityGroups");
                var location = "jioindiacentral";
                string resourceGroupName = TestUtilities.GenerateName("ANMSCRG");
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
                networkManagerScopeAccess.Add("SecurityUser");

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

                string networkmanagerSecurityUserConfigName = TestUtilities.GenerateName("ANMSUC");
                var networkmanagerSecurityUserConfig = new SecurityConfiguration();
                networkmanagerSecurityUserConfig.DisplayName = "Sample DisplayName";
                networkmanagerSecurityUserConfig.Description = "Sample Description";

                var putNmscResponse = networkManagementClient.SecurityUserConfigurations.CreateOrUpdate(networkmanagerSecurityUserConfig, resourceGroupName, networkManagerName, networkmanagerSecurityUserConfigName);
                Assert.Equal("Succeeded", putNmscResponse.ProvisioningState);

                string groupName = TestUtilities.GenerateName();
                List<GroupMembersItem> groupMember = new List<GroupMembersItem>();
                string vnetId = "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/ANMRG3495/providers/Microsoft.Network/virtualNetworks/testvnet";
                GroupMembersItem groupMembersItem = new GroupMembersItem(vnetId);
                groupMember.Add(groupMembersItem);
                var networkManagerGroup = new NetworkGroup()
                {
                    GroupMembers = groupMember,
                };

                // Put NetworkManagerGroup
                var putNmGroupResponse = networkManagementClient.NetworkGroups.CreateOrUpdate(networkManagerGroup, resourceGroupName, networkManagerName, groupName);
                Assert.Equal(groupName, putNmGroupResponse.Name);
                Assert.Equal("Succeeded", putNmGroupResponse.ProvisioningState);

                NetworkManagerSecurityGroupItem sgItem = new NetworkManagerSecurityGroupItem(putNmGroupResponse.Id);
                List<NetworkManagerSecurityGroupItem> appliesToGroups = new List<NetworkManagerSecurityGroupItem>();
                appliesToGroups.Add(sgItem);

                string networkSecurityRuleCollectionName = TestUtilities.GenerateName("ANMSUCRC");
                var securityConfigurationRuleCollection = new RuleCollection(networkSecurityRuleCollectionName);
                securityConfigurationRuleCollection.AppliesToGroups = appliesToGroups;

                // Put NetworkManagerSecurityRuleCollection
                var putRuleCollectionResponse = networkManagementClient.UserRuleCollections.CreateOrUpdate(securityConfigurationRuleCollection,
                    resourceGroupName,
                    networkManagerName,
                    networkmanagerSecurityUserConfigName,
                    networkSecurityRuleCollectionName);

                // Get NetworkManagerSecurityRuleCollection
                var getRuleCollectionResponse = networkManagementClient.UserRuleCollections.Get(resourceGroupName, networkManagerName, networkmanagerSecurityUserConfigName, networkSecurityRuleCollectionName);
                Assert.Equal(networkSecurityRuleCollectionName, getRuleCollectionResponse.Name);

                // List NetworkManagerSecurityRuleCollection
                var listRuleCollectionResponse = networkManagementClient.UserRuleCollections.List(resourceGroupName, networkManagerName, networkmanagerSecurityUserConfigName);
                Assert.Single(listRuleCollectionResponse);
                Assert.Equal(networkSecurityRuleCollectionName, listRuleCollectionResponse.First().Name);

                // Delete RuleCollection
                networkManagementClient.UserRuleCollections.Delete(resourceGroupName, networkManagerName, networkmanagerSecurityUserConfigName, networkSecurityRuleCollectionName);
                


                // List NetworkManagerSecurityRuleCollection
                listRuleCollectionResponse = networkManagementClient.UserRuleCollections.List(resourceGroupName, networkManagerName, networkmanagerSecurityUserConfigName);
                Assert.Empty(listRuleCollectionResponse);

                // Delete NetworkManagerSecurityConfigurations
                networkManagementClient.SecurityUserConfigurations.Delete(resourceGroupName, networkManagerName, networkmanagerSecurityUserConfigName);

                // Delete NetworkManager NetworkGroup
                networkManagementClient.NetworkGroups.Delete(resourceGroupName, networkManagerName, groupName);

                // Delete NetworkManager
                networkManagementClient.NetworkManagers.Delete(resourceGroupName, networkManagerName);
            }
        }


        [Fact(Skip = "Disable tests")]
        public void NetworkManagerSecuirtyUserRulesTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                // var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/networkSecurityGroups");
                var location = "jioindiacentral";
                string resourceGroupName = TestUtilities.GenerateName("ANMSCRG");
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
                networkManagerScopeAccess.Add("SecurityUser");

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

                string networkSecurityRuleName = TestUtilities.GenerateName("ANMUserRule");
                string networkmanagerSecurityConfigName = TestUtilities.GenerateName("ANMSUC");
                var networkmanagerSecurityUserConfig = new SecurityConfiguration();
                networkmanagerSecurityUserConfig.DisplayName = "Sample DisplayName";
                networkmanagerSecurityUserConfig.Description = "Sample Description";

                var putNmscResponse = networkManagementClient.SecurityUserConfigurations.CreateOrUpdate(networkmanagerSecurityUserConfig, resourceGroupName, networkManagerName, networkmanagerSecurityConfigName);
                Assert.Equal("Succeeded", putNmscResponse.ProvisioningState);

                // Put NetworkManagerGroup
                string groupName = TestUtilities.GenerateName("ANMNG");
                List<GroupMembersItem> groupMember = new List<GroupMembersItem>();
                string vnetId = "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/ANMRG3495/providers/Microsoft.Network/virtualNetworks/testvnet";
                GroupMembersItem groupMembersItem = new GroupMembersItem(vnetId);
                groupMember.Add(groupMembersItem);
                var networkManagerGroup = new NetworkGroup()
                {
                    GroupMembers = groupMember,
                };
                var putNmGroupResponse = networkManagementClient.NetworkGroups.CreateOrUpdate(networkManagerGroup, resourceGroupName, networkManagerName, groupName);
                Assert.Equal(groupName, putNmGroupResponse.Name);
                Assert.Equal("Succeeded", putNmGroupResponse.ProvisioningState);

                NetworkManagerSecurityGroupItem sgItem = new NetworkManagerSecurityGroupItem(putNmGroupResponse.Id);
                List<NetworkManagerSecurityGroupItem> appliesToGroups = new List<NetworkManagerSecurityGroupItem>();
                appliesToGroups.Add(sgItem);

                string networkSecurityRuleCollectionName = TestUtilities.GenerateName("ANMSARC");
                var securityConfigurationRuleCollection = new RuleCollection(networkSecurityRuleCollectionName);
                securityConfigurationRuleCollection.AppliesToGroups = appliesToGroups;

                // Put NetworkManagerSecurityRuleCollection
                var putRuleCollectionResponse = networkManagementClient.UserRuleCollections.CreateOrUpdate(securityConfigurationRuleCollection,
                    resourceGroupName,
                    networkManagerName,
                    networkmanagerSecurityConfigName,
                    networkSecurityRuleCollectionName);
                Assert.Equal("Succeeded", putRuleCollectionResponse.ProvisioningState);

                var securityUserRule = new UserRule(protocol: "Tcp", direction: "Inbound");

                // Put NetworkManagerSecurityRule
                var putRuleResponse = (UserRule)networkManagementClient.UserRules.CreateOrUpdate(securityUserRule, resourceGroupName, networkManagerName, networkmanagerSecurityConfigName, networkSecurityRuleCollectionName, networkSecurityRuleName);

                // Get NetworkManagerSecurityRule
                var getRuleResponse = (UserRule)networkManagementClient.UserRules.Get(resourceGroupName, networkManagerName, networkmanagerSecurityConfigName, networkSecurityRuleCollectionName, networkSecurityRuleName);
                Assert.Equal(networkSecurityRuleName, getRuleResponse.Name);
                Assert.Equal("Tcp", getRuleResponse.Protocol);
                Assert.Equal("Inbound", getRuleResponse.Direction);

                // List NetworkManagerSecurityRule
                var listRuleResponse = networkManagementClient.UserRules.List(resourceGroupName, networkManagerName, networkmanagerSecurityConfigName, networkSecurityRuleCollectionName);
                Assert.Single(listRuleResponse);
                Assert.Equal(networkSecurityRuleName, listRuleResponse.First().Name);

                // Delete Rules
                networkManagementClient.UserRules.Delete(resourceGroupName, networkManagerName, networkmanagerSecurityConfigName, networkSecurityRuleCollectionName, networkSecurityRuleName);

                // List NetworkManagerSecurityRules
                listRuleResponse = networkManagementClient.UserRules.List(resourceGroupName, networkManagerName, networkmanagerSecurityConfigName, networkSecurityRuleCollectionName);
                Assert.Empty(listRuleResponse);

                // Delete RuleCollection
                networkManagementClient.UserRuleCollections.Delete(resourceGroupName, networkManagerName, networkmanagerSecurityConfigName, networkSecurityRuleCollectionName);

                // Delete NetworkManagerSecurityConfigurations
                networkManagementClient.SecurityUserConfigurations.Delete(resourceGroupName, networkManagerName, networkmanagerSecurityConfigName);

                // Delete NetworkManager NetworkGroup
                networkManagementClient.NetworkGroups.Delete(resourceGroupName, networkManagerName, groupName);

                // Delete NetworkManager
                networkManagementClient.NetworkManagers.Delete(resourceGroupName, networkManagerName);
            }
        }
    }
}
