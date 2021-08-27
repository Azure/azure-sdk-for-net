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
using System.Threading;

namespace Networks.Tests
{
    public class NetworkManagerSecurityAdminConfigurationTests
    {
        [Fact(Skip = "Disable tests")]
        public void NetworkManagerSecurityAdminConfigurationTest()
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
                networkManagerScopeAccess.Add("SecurityAdmin");

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

                string networkmanagerSecurityAdminConfigName = TestUtilities.GenerateName("ANMSAC");

                var networkmanagerSecurityAdminConfig = new SecurityConfiguration();
                networkmanagerSecurityAdminConfig.DisplayName = "Sample DisplayName";
                networkmanagerSecurityAdminConfig.Description = "Sample Description";

                // Put NetworkManagerSecurityConfiguration
                var putNmscResponse = networkManagementClient.SecurityAdminConfigurations.CreateOrUpdate(networkmanagerSecurityAdminConfig, resourceGroupName, networkManagerName, networkmanagerSecurityAdminConfigName);
                Assert.Equal("Succeeded", putNmscResponse.ProvisioningState);

                // Get NetworkManagerSecurityConfiguration
                var getNmscResponse = networkManagementClient.SecurityAdminConfigurations.Get(resourceGroupName, networkManagerName, networkmanagerSecurityAdminConfigName);
                Assert.Equal(networkmanagerSecurityAdminConfigName, getNmscResponse.Name);

                // List NetworkManagerSecurityConfigurations
                var listNmAdminConfigResponse = networkManagementClient.SecurityAdminConfigurations.List(resourceGroupName, networkManagerName);
                Assert.Single(listNmAdminConfigResponse);
                Assert.Equal(networkmanagerSecurityAdminConfigName, listNmAdminConfigResponse.First().Name);

                // Delete NetworkManagerSecurityConfigurations
                networkManagementClient.SecurityAdminConfigurations.Delete(resourceGroupName, networkManagerName, networkmanagerSecurityAdminConfigName);

                // List NetworkManagerSecurityConfigurations
                listNmAdminConfigResponse = networkManagementClient.SecurityAdminConfigurations.List(resourceGroupName, networkManagerName);
                Assert.Empty(listNmAdminConfigResponse);

                // Delete NetworkManager
                networkManagementClient.NetworkManagers.Delete(resourceGroupName, networkManagerName);
            }
        }

        [Fact(Skip = "Disable tests")]
        public void NetworkManagerSecuirtyAdminRuleCollectionsTest()
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
                networkManagerScopeAccess.Add("SecurityAdmin");

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

                string networkmanagerSecurityAdminConfigName = TestUtilities.GenerateName("ANMSAC");
                var networkmanagerSecurityAdminConfig = new SecurityConfiguration();
                networkmanagerSecurityAdminConfig.DisplayName = "Sample DisplayName";
                networkmanagerSecurityAdminConfig.Description = "Sample Description";

                var putNmscResponse = networkManagementClient.SecurityAdminConfigurations.CreateOrUpdate(networkmanagerSecurityAdminConfig, resourceGroupName, networkManagerName, networkmanagerSecurityAdminConfigName);
                Assert.Equal("Succeeded", putNmscResponse.ProvisioningState);

                string groupName = TestUtilities.GenerateName("ANMNG");
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

                string networkSecurityRuleCollectionName = TestUtilities.GenerateName("ANMSACRC");
                var securityConfigurationRuleCollection = new RuleCollection(networkSecurityRuleCollectionName);
                securityConfigurationRuleCollection.AppliesToGroups = appliesToGroups;

                // Put NetworkManagerSecurityRuleCollection
                var putRuleCollectionResponse = networkManagementClient.AdminRuleCollections.CreateOrUpdate(securityConfigurationRuleCollection, 
                    resourceGroupName, 
                    networkManagerName, 
                    networkmanagerSecurityAdminConfigName,
                    networkSecurityRuleCollectionName);
                Assert.Equal("Succeeded", putRuleCollectionResponse.ProvisioningState);

                // Get NetworkManagerSecurityRuleCollection
                var getRuleCollectionResponse = networkManagementClient.AdminRuleCollections.Get(resourceGroupName, networkManagerName, networkmanagerSecurityAdminConfigName, networkSecurityRuleCollectionName);
                Assert.Equal(networkSecurityRuleCollectionName, getRuleCollectionResponse.Name);

                // List NetworkManagerSecurityRuleCollection
                var listRuleCollectionResponse = networkManagementClient.AdminRuleCollections.List(resourceGroupName, networkManagerName, networkmanagerSecurityAdminConfigName);
                Assert.Single(listRuleCollectionResponse);
                Assert.Equal(networkSecurityRuleCollectionName, listRuleCollectionResponse.First().Name);

                // Delete RuleCollection
                networkManagementClient.AdminRuleCollections.Delete(resourceGroupName, networkManagerName, networkmanagerSecurityAdminConfigName, networkSecurityRuleCollectionName);

                // List NetworkManagerSecurityRuleCollection
                listRuleCollectionResponse = networkManagementClient.AdminRuleCollections.List(resourceGroupName, networkManagerName, networkmanagerSecurityAdminConfigName);
                Assert.Empty(listRuleCollectionResponse);

                // Delete NetworkManagerSecurityConfigurations
                networkManagementClient.SecurityAdminConfigurations.Delete(resourceGroupName, networkManagerName, networkmanagerSecurityAdminConfigName);

                // Delete NetworkManager NetworkGroup
                networkManagementClient.NetworkGroups.Delete(resourceGroupName, networkManagerName, groupName);

                // Delete NetworkManager
                networkManagementClient.NetworkManagers.Delete(resourceGroupName, networkManagerName);
            }
        }


        [Fact(Skip = "Disable tests")]
        public void NetworkManagerSecuirtyAdminRulesTest()
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
                networkManagerScopeAccess.Add("SecurityAdmin");

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

                string networkSecurityRuleName = TestUtilities.GenerateName("ANMAdminRule");
                string networkmanagerSecurityConfigName = TestUtilities.GenerateName("ANMSAC");
                var networkmanagerSecurityAdminConfig = new SecurityConfiguration();
                networkmanagerSecurityAdminConfig.DisplayName = "Sample DisplayName";
                networkmanagerSecurityAdminConfig.Description = "Sample Description";

                var putNmscResponse = networkManagementClient.SecurityAdminConfigurations.CreateOrUpdate(networkmanagerSecurityAdminConfig, resourceGroupName, networkManagerName, networkmanagerSecurityConfigName);
                Assert.Equal("Succeeded", putNmscResponse.ProvisioningState);

                // Put NetworkManagerGroup
                string groupName = TestUtilities.GenerateName("ANMNG");
                List<GroupMembersItem> groupMember = new List<GroupMembersItem>();
                string vnetId = "/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/ANMRG3495/providers/Microsoft.Network/virtualNetworks/testvnet3";
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
                var putRuleCollectionResponse = networkManagementClient.AdminRuleCollections.CreateOrUpdate(securityConfigurationRuleCollection,
                    resourceGroupName,
                    networkManagerName,
                    networkmanagerSecurityConfigName,
                    networkSecurityRuleCollectionName);
                Assert.Equal("Succeeded", putRuleCollectionResponse.ProvisioningState);

                var securityAdminRule = new AdminRule(protocol: "Tcp", direction: "Inbound", access: "Allow", priority:100);

                // Put NetworkManagerSecurityRule
                var putRuleResponse = (AdminRule)networkManagementClient.AdminRules.CreateOrUpdate(securityAdminRule, resourceGroupName, networkManagerName, networkmanagerSecurityConfigName, networkSecurityRuleCollectionName, networkSecurityRuleName);
                Assert.Equal("Succeeded", putRuleResponse.ProvisioningState);

                // Get NetworkManagerSecurityRule
                var getRuleResponse = (AdminRule)networkManagementClient.AdminRules.Get(resourceGroupName, networkManagerName, networkmanagerSecurityConfigName, networkSecurityRuleCollectionName, networkSecurityRuleName);
                Assert.Equal(networkSecurityRuleName, getRuleResponse.Name);
                Assert.Equal("Allow", getRuleResponse.Access);
                Assert.Equal(100, getRuleResponse.Priority);
                Assert.Equal("Tcp", getRuleResponse.Protocol);
                Assert.Equal("Inbound", getRuleResponse.Direction);

                // List NetworkManagerSecurityRule
                var listRuleResponse = networkManagementClient.AdminRules.List(resourceGroupName, networkManagerName, networkmanagerSecurityConfigName, networkSecurityRuleCollectionName);
                Assert.Single(listRuleResponse);
                Assert.Equal(networkSecurityRuleName, listRuleResponse.First().Name);

                
                NetworkManagerCommit commit = new NetworkManagerCommit();
                commit.CommitType = "SecurityAdmin";
                commit.ConfigurationIds = new List<string>();
                commit.TargetLocations = new List<string>();
                commit.TargetLocations.Add("jioindiacentral");
                commit.ConfigurationIds.Add(putNmscResponse.Id);
                networkManagementClient.NetworkManagerCommits.Post(commit, resourceGroupName, networkManagerName);

                Thread.Sleep(10000);

                ActiveConfigurationParameter activeConfigurationParameter = new ActiveConfigurationParameter();
                activeConfigurationParameter.Regions = new List<string>();
                activeConfigurationParameter.Regions.Add("jioindiacentral");
                var activeSecurityAdminConfigrautionsResponse = networkManagementClient.ActiveSecurityAdminRules.List(resourceGroupName, networkManagerName, activeConfigurationParameter);
                Assert.Single(activeSecurityAdminConfigrautionsResponse.Value);
                Assert.Equal(getRuleResponse.Id, activeSecurityAdminConfigrautionsResponse.Value.First().Id);


                NetworkManagerCommit unCommit = new NetworkManagerCommit();
                unCommit.CommitType = "SecurityAdmin";
                unCommit.ConfigurationIds = new List<string>();
                unCommit.TargetLocations = new List<string>();
                unCommit.TargetLocations.Add("jioindiacentral");
                networkManagementClient.NetworkManagerCommits.Post(unCommit, resourceGroupName, networkManagerName);

                Thread.Sleep(10000);

                // Delete Rules
                networkManagementClient.AdminRules.Delete(resourceGroupName, networkManagerName, networkmanagerSecurityConfigName, networkSecurityRuleCollectionName, networkSecurityRuleName);

                // List NetworkManagerSecurityRules
                listRuleResponse = networkManagementClient.AdminRules.List(resourceGroupName, networkManagerName, networkmanagerSecurityConfigName, networkSecurityRuleCollectionName);
                Assert.Empty(listRuleResponse);

                // Delete RuleCollection
                networkManagementClient.AdminRuleCollections.Delete(resourceGroupName, networkManagerName, networkmanagerSecurityConfigName, networkSecurityRuleCollectionName);

                // Delete NetworkManagerSecurityConfigurations
                networkManagementClient.SecurityAdminConfigurations.Delete(resourceGroupName, networkManagerName, networkmanagerSecurityConfigName);

                // Delete NetworkManager NetworkGroup
                networkManagementClient.NetworkGroups.Delete(resourceGroupName, networkManagerName, groupName);

                // Delete NetworkManager
                networkManagementClient.NetworkManagers.Delete(resourceGroupName, networkManagerName);
            }
        }
    }
}
