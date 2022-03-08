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
using System;

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
                var location = "eastus2euap";
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
                List<string> NIPList = new List<string>();
                NIPList.Add("None");
                networkmanagerSecurityAdminConfig.ApplyOnNetworkIntentPolicyBasedServices = NIPList;

                // Put NetworkManagerSecurityConfiguration
                var putNmscResponse = networkManagementClient.SecurityAdminConfigurations.CreateOrUpdate(networkmanagerSecurityAdminConfig, resourceGroupName, networkManagerName, networkmanagerSecurityAdminConfigName);
                Assert.Equal("Succeeded", putNmscResponse.ProvisioningState);

                // Get NetworkManagerSecurityConfiguration
                var getNmscResponse = networkManagementClient.SecurityAdminConfigurations.Get(resourceGroupName, networkManagerName, networkmanagerSecurityAdminConfigName);
                Assert.Equal(networkmanagerSecurityAdminConfigName, getNmscResponse.Name);
                Assert.Equal(networkmanagerSecurityAdminConfig.Description, getNmscResponse.Description);
                Assert.Equal(networkmanagerSecurityAdminConfig.DisplayName, getNmscResponse.DisplayName);
                Assert.Equal(NIPList, getNmscResponse.ApplyOnNetworkIntentPolicyBasedServices);

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
                var location = "eastus2euap";
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
                networkmanagerSecurityAdminConfig.DisplayName = "SampleDisplayName";

                // Put SecurityAdminConfig
                var putNmscResponse = networkManagementClient.SecurityAdminConfigurations.CreateOrUpdate(networkmanagerSecurityAdminConfig, resourceGroupName, networkManagerName, networkmanagerSecurityAdminConfigName);
                Assert.Equal("Succeeded", putNmscResponse.ProvisioningState);

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

                NetworkManagerSecurityGroupItem sgItem = new NetworkManagerSecurityGroupItem(putNmGroupResponse.Id);
                List<NetworkManagerSecurityGroupItem> appliesToGroups = new List<NetworkManagerSecurityGroupItem>();
                appliesToGroups.Add(sgItem);

                string networkSecurityRuleCollectionName = TestUtilities.GenerateName("ANMSACRC");
                var securityConfigurationRuleCollection = new RuleCollection(appliesToGroups, name: networkSecurityRuleCollectionName);
                securityConfigurationRuleCollection.DisplayName = "Sample DisplayName";
                securityConfigurationRuleCollection.Description = "Sample Description";

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
                Assert.Single(getRuleCollectionResponse.AppliesToGroups);
                Assert.Equal(putNmGroupResponse.Id, getRuleCollectionResponse.AppliesToGroups.First().NetworkGroupId);
                Assert.Equal(securityConfigurationRuleCollection.DisplayName, getRuleCollectionResponse.DisplayName);
                Assert.Equal(securityConfigurationRuleCollection.Description, getRuleCollectionResponse.Description);

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

                // Delete NetworkManager Static Member
                networkManagementClient.StaticMembers.Delete(resourceGroupName, networkManagerName, groupName, staticMemberName);

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
                var location = "eastus2euap";

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
                networkmanagerSecurityAdminConfig.DisplayName = "TestDisplayName";

                // Put secAdminconfig
                var putNmscResponse = networkManagementClient.SecurityAdminConfigurations.CreateOrUpdate(networkmanagerSecurityAdminConfig, resourceGroupName, networkManagerName, networkmanagerSecurityConfigName);
                Assert.Equal("Succeeded", putNmscResponse.ProvisioningState);

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

                NetworkManagerSecurityGroupItem sgItem = new NetworkManagerSecurityGroupItem(putNmGroupResponse.Id);
                List<NetworkManagerSecurityGroupItem> appliesToGroups = new List<NetworkManagerSecurityGroupItem>();
                appliesToGroups.Add(sgItem);

                string networkSecurityRuleCollectionName = TestUtilities.GenerateName("ANMSARC");
                var securityConfigurationRuleCollection = new RuleCollection(appliesToGroups, name: networkSecurityRuleCollectionName);
                securityConfigurationRuleCollection.AppliesToGroups = appliesToGroups;

                // Put NetworkManagerSecurityRuleCollection
                var putRuleCollectionResponse = networkManagementClient.AdminRuleCollections.CreateOrUpdate(securityConfigurationRuleCollection,
                    resourceGroupName,
                    networkManagerName,
                    networkmanagerSecurityConfigName,
                    networkSecurityRuleCollectionName);
                Assert.Equal("Succeeded", putRuleCollectionResponse.ProvisioningState);

                var securityAdminRule = new AdminRule(protocol: "Tcp", direction: "Inbound", access: "Allow", priority: 100);
                IList<string> sourcePorts = new List<string>();
                sourcePorts.Add("1000");
                IList<string> desPorts = new List<string>();
                desPorts.Add("99");
                securityAdminRule.DestinationPortRanges = desPorts;
                securityAdminRule.SourcePortRanges = sourcePorts;
                AddressPrefixItem sourceAddressPrefixItem = new AddressPrefixItem()
                {
                    AddressPrefix = "Internet",
                    AddressPrefixType = "ServiceTag",
                };

                AddressPrefixItem destAddressPrefixItem = new AddressPrefixItem()
                {
                    AddressPrefix = "10.0.0.1",
                    AddressPrefixType = "IPPrefix",
                };
                securityAdminRule.Destinations = new List<AddressPrefixItem>() { destAddressPrefixItem };
                securityAdminRule.Sources = new List<AddressPrefixItem>() { sourceAddressPrefixItem };

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
                Assert.Equal(1, getRuleResponse.Sources.Count);
                Assert.Equal(1, getRuleResponse.Destinations.Count);
                Assert.Equal(1, getRuleResponse.DestinationPortRanges.Count);
                Assert.Equal(1, getRuleResponse.SourcePortRanges.Count);
                Assert.Equal(sourceAddressPrefixItem.AddressPrefix, getRuleResponse.Sources.First().AddressPrefix);
                Assert.Equal(sourceAddressPrefixItem.AddressPrefixType, getRuleResponse.Sources.First().AddressPrefixType);
                Assert.Equal(destAddressPrefixItem.AddressPrefix, getRuleResponse.Destinations.First().AddressPrefix);
                Assert.Equal(0, string.Compare(destAddressPrefixItem.AddressPrefixType, getRuleResponse.Destinations.First().AddressPrefixType, ignoreCase: true));
                Assert.Equal("1000", getRuleResponse.SourcePortRanges.First());
                Assert.Equal("99", getRuleResponse.DestinationPortRanges.First());


                // List NetworkManagerSecurityRule
                var listRuleResponse = networkManagementClient.AdminRules.List(resourceGroupName, networkManagerName, networkmanagerSecurityConfigName, networkSecurityRuleCollectionName);
                Assert.Single(listRuleResponse);
                Assert.Equal(networkSecurityRuleName, listRuleResponse.First().Name);

                NetworkManagerCommit commit = new NetworkManagerCommit();
                commit.CommitType = "SecurityAdmin";
                commit.ConfigurationIds = new List<string>();
                commit.TargetLocations = new List<string>();
                commit.TargetLocations.Add(location);
                commit.ConfigurationIds.Add(putNmscResponse.Id);
                networkManagementClient.NetworkManagerCommits.Post(commit, resourceGroupName, networkManagerName);

                Thread.Sleep(100000);

                ActiveConfigurationParameter activeConfigurationParameter = new ActiveConfigurationParameter();
                activeConfigurationParameter.Regions = new List<string>();
                activeConfigurationParameter.Regions.Add(location);
                var activeSecurityAdminConfigrautionsResponse = networkManagementClient.ListActiveSecurityAdminRules(activeConfigurationParameter, resourceGroupName, networkManagerName);
                Assert.Single(activeSecurityAdminConfigrautionsResponse.Value);
                Assert.Equal(getRuleResponse.Id, activeSecurityAdminConfigrautionsResponse.Value.First().Id);
                Assert.Single(activeSecurityAdminConfigrautionsResponse.Value.First().RuleGroups);
                Assert.Equal(putNmGroupResponse.Id, activeSecurityAdminConfigrautionsResponse.Value.First().RuleGroups.First().Id);
                Assert.Single(activeSecurityAdminConfigrautionsResponse.Value.First().RuleCollectionAppliesToGroups);

                NetworkManagerCommit unCommit = new NetworkManagerCommit();
                unCommit.CommitType = "SecurityAdmin";
                unCommit.ConfigurationIds = new List<string>();
                unCommit.TargetLocations = new List<string>();
                unCommit.TargetLocations.Add(location);
                networkManagementClient.NetworkManagerCommits.Post(unCommit, resourceGroupName, networkManagerName);

                Thread.Sleep(100000);

                activeSecurityAdminConfigrautionsResponse = networkManagementClient.ListActiveSecurityAdminRules(activeConfigurationParameter, resourceGroupName, networkManagerName);
                Assert.Empty(activeSecurityAdminConfigrautionsResponse.Value);

                // Delete Admin Rule
                networkManagementClient.AdminRules.Delete(resourceGroupName, networkManagerName, networkmanagerSecurityConfigName, networkSecurityRuleCollectionName, networkSecurityRuleName);

                // Lit Admin Rule and Assert Empty
                var newListCollectionsResponse = networkManagementClient.AdminRules.List(resourceGroupName, networkManagerName, networkmanagerSecurityConfigName, networkSecurityRuleCollectionName);
                Assert.Empty(newListCollectionsResponse);

                // Delete NetworkManagerSecurityCollections
                networkManagementClient.AdminRuleCollections.Delete(resourceGroupName, networkManagerName, networkmanagerSecurityConfigName, networkSecurityRuleCollectionName);

                // Delete NetworkManagerSecurityConfigurations
                networkManagementClient.SecurityAdminConfigurations.Delete(resourceGroupName, networkManagerName, networkmanagerSecurityConfigName);

                // Delete NetworkManager Static Member
                networkManagementClient.StaticMembers.Delete(resourceGroupName, networkManagerName, groupName, staticMemberName);

                // Delete NetworkManager NetworkGroup
                networkManagementClient.NetworkGroups.Delete(resourceGroupName, networkManagerName, groupName);

                // Delete NetworkManager
                networkManagementClient.NetworkManagers.Delete(resourceGroupName, networkManagerName);
            }
        }
    }
}