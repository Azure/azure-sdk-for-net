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
using System;
using System.Threading;

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
                Assert.Equal(networkmanagerSecurityUserConfig.Description, getNmscResponse.Description);
                Assert.Equal(networkmanagerSecurityUserConfig.DisplayName, getNmscResponse.DisplayName);

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

                string networkSecurityRuleCollectionName = TestUtilities.GenerateName("ANMSUCRC");
                var securityConfigurationRuleCollection = new RuleCollection(appliesToGroups, name: networkSecurityRuleCollectionName);
                securityConfigurationRuleCollection.DisplayName = "Sample DisplayName";
                securityConfigurationRuleCollection.Description = "Sample Description";

                // Put NetworkManagerSecurityRuleCollection
                var putRuleCollectionResponse = networkManagementClient.UserRuleCollections.CreateOrUpdate(securityConfigurationRuleCollection,
                    resourceGroupName,
                    networkManagerName,
                    networkmanagerSecurityUserConfigName,
                    networkSecurityRuleCollectionName);
                Assert.Equal("Succeeded", putRuleCollectionResponse.ProvisioningState);

                // Get NetworkManagerSecurityRuleCollection
                var getRuleCollectionResponse = networkManagementClient.UserRuleCollections.Get(resourceGroupName, networkManagerName, networkmanagerSecurityUserConfigName, networkSecurityRuleCollectionName);
                Assert.Equal(networkSecurityRuleCollectionName, getRuleCollectionResponse.Name);
                Assert.Single(getRuleCollectionResponse.AppliesToGroups);
                Assert.Equal(putNmGroupResponse.Id, getRuleCollectionResponse.AppliesToGroups.First().NetworkGroupId);
                Assert.Equal(securityConfigurationRuleCollection.DisplayName, getRuleCollectionResponse.DisplayName);
                Assert.Equal(securityConfigurationRuleCollection.Description, getRuleCollectionResponse.Description);

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

                // Delete NetworkManager Static Member
                networkManagementClient.StaticMembers.Delete(resourceGroupName, networkManagerName, groupName, staticMemberName);

                // Delete NetworkManager NetworkGroup
                networkManagementClient.NetworkGroups.Delete(resourceGroupName, networkManagerName, groupName);

                // Delete NetworkManager
                networkManagementClient.NetworkManagers.Delete(resourceGroupName, networkManagerName);
            }
        }


        [Fact(Skip = "Disable tests")]
        public void NetworkManagerSecurityUserRulesTest()
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

                // Put NetworkManagerSecurityRuleCollection
                var putRuleCollectionResponse = networkManagementClient.UserRuleCollections.CreateOrUpdate(securityConfigurationRuleCollection,
                    resourceGroupName,
                    networkManagerName,
                    networkmanagerSecurityConfigName,
                    networkSecurityRuleCollectionName);
                Assert.Equal("Succeeded", putRuleCollectionResponse.ProvisioningState);

                var securityUserRule = new UserRule(protocol: "Tcp", direction: "Inbound");
                IList<string> sourcePorts = new List<string>();
                sourcePorts.Add("1000");
                IList<string> desPorts = new List<string>();
                desPorts.Add("99");
                securityUserRule.DestinationPortRanges = desPorts;
                securityUserRule.SourcePortRanges = sourcePorts;
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
                securityUserRule.Destinations = new List<AddressPrefixItem>() { destAddressPrefixItem };
                securityUserRule.Sources = new List<AddressPrefixItem>() { sourceAddressPrefixItem };

                // Put NetworkManagerSecurityRule
                var putRuleResponse = (UserRule)networkManagementClient.UserRules.CreateOrUpdate(securityUserRule, resourceGroupName, networkManagerName, networkmanagerSecurityConfigName, networkSecurityRuleCollectionName, networkSecurityRuleName);

                // Get NetworkManagerSecurityRule
                var getRuleResponse = (UserRule)networkManagementClient.UserRules.Get(resourceGroupName, networkManagerName, networkmanagerSecurityConfigName, networkSecurityRuleCollectionName, networkSecurityRuleName);

                Assert.Equal(networkSecurityRuleName, getRuleResponse.Name);
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
                var listRuleResponse = networkManagementClient.UserRules.List(resourceGroupName, networkManagerName, networkmanagerSecurityConfigName, networkSecurityRuleCollectionName);
                Assert.Single(listRuleResponse);
                Assert.Equal(networkSecurityRuleName, listRuleResponse.First().Name);

                /*
                NetworkManagerCommit commit = new NetworkManagerCommit();
                commit.CommitType = "SecurityUser";
                commit.ConfigurationIds = new List<string>();
                commit.TargetLocations = new List<string>();
                commit.TargetLocations.Add(location);
                commit.ConfigurationIds.Add(putNmscResponse.Id);
                networkManagementClient.NetworkManagerCommits.Post(commit, resourceGroupName, networkManagerName);

                Thread.Sleep(100000);

                ActiveConfigurationParameter activeConfigurationParameter = new ActiveConfigurationParameter();
                activeConfigurationParameter.Regions = new List<string>();
                activeConfigurationParameter.Regions.Add(location);
                var activeSecurityUserConfigrautionsResponse = networkManagementClient.ListActiveSecurityUserRules(activeConfigurationParameter, resourceGroupName, networkManagerName);
                try
                {
                    Assert.Single(activeSecurityUserConfigrautionsResponse.Value);
                    Assert.Equal(getRuleResponse.Id, activeSecurityUserConfigrautionsResponse.Value.First().Id);
                    Assert.Single(activeSecurityUserConfigrautionsResponse.Value.First().RuleGroups);
                    Assert.Equal(putNmGroupResponse.Id, activeSecurityUserConfigrautionsResponse.Value.First().RuleGroups.First().Id);
                    Assert.Single(activeSecurityUserConfigrautionsResponse.Value.First().RuleCollectionAppliesToGroups);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                NetworkManagerCommit unCommit = new NetworkManagerCommit();
                unCommit.CommitType = "SecurityUser";
                unCommit.ConfigurationIds = new List<string>();
                unCommit.TargetLocations = new List<string>();
                unCommit.TargetLocations.Add(location);
                networkManagementClient.NetworkManagerCommits.Post(unCommit, resourceGroupName, networkManagerName);

                Thread.Sleep(100000);

                activeSecurityUserConfigrautionsResponse = networkManagementClient.ListActiveSecurityUserRules(activeConfigurationParameter, resourceGroupName, networkManagerName);
                Assert.Empty(activeSecurityUserConfigrautionsResponse.Value);
                */

                // Delete Rules
                networkManagementClient.UserRules.Delete(resourceGroupName, networkManagerName, networkmanagerSecurityConfigName, networkSecurityRuleCollectionName, networkSecurityRuleName);

                // List NetworkManagerSecurityRules
                listRuleResponse = networkManagementClient.UserRules.List(resourceGroupName, networkManagerName, networkmanagerSecurityConfigName, networkSecurityRuleCollectionName);
                Assert.Empty(listRuleResponse);

                // Delete RuleCollection
                networkManagementClient.UserRuleCollections.Delete(resourceGroupName, networkManagerName, networkmanagerSecurityConfigName, networkSecurityRuleCollectionName);

                // Delete NetworkManagerSecurityConfigurations
                networkManagementClient.SecurityUserConfigurations.Delete(resourceGroupName, networkManagerName, networkmanagerSecurityConfigName);

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