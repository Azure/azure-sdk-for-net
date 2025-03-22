// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;
using Azure.Core;
using System;
using Azure.Identity;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Threading;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Network.Tests.Helpers
{
    public static partial class NetworkManagerHelperExtensions
    {
        public static async Task<(SecurityUserConfigurationResource Configuration, List<SecurityUserRuleCollectionResource> Collections, List<SecurityUserRuleResource> Rules)> CreateSecurityUserConfigurationAsync(
            this NetworkManagerResource networkManager,
            List<ResourceIdentifier> networkGroupIds)
        {
            string securityUserConfigurationName = "securityUserConfiguration-1";

            SecurityUserConfigurationData securityUserConfigurationData = new()
            {
                Description = "My Test SecurityUser Configuration",
            };

            SecurityUserConfigurationCollection securityUserConfigurationResources = networkManager.GetSecurityUserConfigurations();
            ArmOperation<SecurityUserConfigurationResource> securityUserConfigurationResource = await securityUserConfigurationResources.CreateOrUpdateAsync(WaitUntil.Completed, securityUserConfigurationName, securityUserConfigurationData);

            // Create a securityUser rule collection
            List<SecurityUserRuleCollectionResource> collections = new();
            SecurityUserRuleCollectionResource securityUserCollection = await securityUserConfigurationResource.Value.CreateSecurityUserRuleCollectionAsync(networkGroupIds);
            collections.Add(securityUserCollection);

            // Create multiple securityUser rules in parallel
            List<Task<SecurityUserRuleResource>> securityUserRuleTasks = new()
            {
                securityUserCollection.CreateSecurityUserRuleAsync("rule1", SecurityConfigurationRuleProtocol.Tcp, "10.1.1.1/32", new List<string> { "22" }, AddressPrefixType.IPPrefix, "20.1.1.1/32", new List<string> { "22" }, AddressPrefixType.IPPrefix, SecurityConfigurationRuleDirection.Inbound),
            };

            List<SecurityUserRuleResource> securityUserRules = (await Task.WhenAll(securityUserRuleTasks)).ToList();

            return (securityUserConfigurationResource.Value, collections, securityUserRules);
        }

        public static async Task<SecurityUserRuleCollectionResource> CreateSecurityUserRuleCollectionAsync(
            this SecurityUserConfigurationResource securityUserConfiguration,
            List<ResourceIdentifier> networkGroupIds)
        {
            string securityUserCollectionName = "securityUserCollection-1";

            SecurityUserRuleCollectionData securityUserRuleCollectionData = new()
            {
                Description = "My Test SecurityUser Rule Collection",
                AppliesToGroups =
                {
                    new SecurityUserGroupItem(networkGroupIds.First())
                },
            };

            foreach (ResourceIdentifier networkGroupId in networkGroupIds)
            {
                securityUserRuleCollectionData.AppliesToGroups.Add(new SecurityUserGroupItem() { NetworkGroupId = networkGroupId });
            }

            SecurityUserRuleCollectionCollection securityUserRuleCollectionResources = securityUserConfiguration.GetSecurityUserRuleCollections();
            ArmOperation<SecurityUserRuleCollectionResource> securityUserRuleCollectionResource = await securityUserRuleCollectionResources.CreateOrUpdateAsync(WaitUntil.Completed, securityUserCollectionName, securityUserRuleCollectionData);
            return securityUserRuleCollectionResource.Value;
        }

        public static async Task<SecurityUserRuleResource> CreateSecurityUserRuleAsync(
            this SecurityUserRuleCollectionResource securityUserRuleCollection,
            string securityUserRuleName,
            SecurityConfigurationRuleProtocol protocol,
            string sourceAddress,
            List<string> sourcePorts,
            AddressPrefixType sourceAddressPrefixType,
            string destinationAddress,
            List<string> destinationPorts,
            AddressPrefixType destinationAddressPrefixType,
            SecurityConfigurationRuleDirection direction)
        {
            SecurityUserRuleData data = new SecurityUserRuleData
            {
                Description = "Sample User Rule",
                Protocol = protocol,
                Sources =
                {
                    new AddressPrefixItem()
                    {
                        AddressPrefix = sourceAddress,
                        AddressPrefixType = sourceAddressPrefixType,
                    }
                },
                Destinations =
                {
                    new AddressPrefixItem()
                    {
                        AddressPrefix = destinationAddress,
                        AddressPrefixType = destinationAddressPrefixType,
                    }
                },
                Direction = direction,
            };

            foreach (var port in sourcePorts)
            {
                data.SourcePortRanges.Add(port);
            }

            foreach (var port in destinationPorts)
            {
                data.DestinationPortRanges.Add(port);
            }

            SecurityUserRuleCollection ruleCollection = securityUserRuleCollection.GetSecurityUserRules();
            ArmOperation<SecurityUserRuleResource> securityUserRuleResource = await ruleCollection.CreateOrUpdateAsync(WaitUntil.Completed, securityUserRuleName, data);
            return securityUserRuleResource.Value;
        }

        public static async Task DeleteSecurityUserConfigurationAsync(
            this NetworkManagerResource networkManager,
            SecurityUserConfigurationResource securityUserConfiguration)
        {
            SecurityUserRuleCollectionCollection collections = securityUserConfiguration.GetSecurityUserRuleCollections();

            // Delete securityUser rules in parallel
            List<Task> deleteRuleTasks = new();
            await foreach (SecurityUserRuleCollectionResource collection in collections.GetAllAsync())
            {
                await foreach (SecurityUserRuleResource rule in collection.GetSecurityUserRules().GetAllAsync())
                {
                    deleteRuleTasks.Add(DeleteAndVerifyResourceAsync(collection.GetSecurityUserRules(), rule.Data.Name));
                }
            }
            await Task.WhenAll(deleteRuleTasks);

            // Delete securityUser rule collections in parallel
            List<Task> deleteCollectionTasks = new();
            await foreach (SecurityUserRuleCollectionResource collection in collections.GetAllAsync())
            {
                deleteCollectionTasks.Add(DeleteAndVerifyResourceAsync(collections, collection.Data.Name));
            }
            await Task.WhenAll(deleteCollectionTasks);

            // Delete the securityUser configuration
            await DeleteAndVerifyResourceAsync(networkManager.GetSecurityUserConfigurations(), securityUserConfiguration.Data.Name);
        }

        public static void ValidateSecurityUserRule(SecurityUserRuleResource rule1, SecurityUserRuleResource rule2)
        {
            Assert.AreEqual(rule1.Id, rule2.Id);
            Assert.AreEqual(rule1.Data.Name, rule2.Data.Name);
        }

        public static async Task ValidateNsgAsync(
            this ResourceGroupResource resourceGroup,
            SubscriptionResource subscription,
            List<VirtualNetworkResource> vnets,
            bool isEmpty = false)
        {
            // string nsgRgName = $"AVNM_Rg_11434_{subscription.Data.SubscriptionId}";
            // Response<ResourceGroupResource> nsgRg = await subscription.GetResourceGroups().GetAsync(nsgRgName);
            // Assert.IsNotNull(nsgRg);

            List<Task> validationTasks = new();
            foreach (VirtualNetworkResource vnet in vnets)
            {
                validationTasks.Add(ValidateNsgAsync(resourceGroup, resourceGroup, vnet, isEmpty));
            }
            await Task.WhenAll(validationTasks);
        }

        private static async Task ValidateNsgAsync(
            ResourceGroupResource resourceGroup,
            ResourceGroupResource nsgRg,
            VirtualNetworkResource vnet,
            bool isEmpty)
        {
            Response<VirtualNetworkResource> virtualNetworkResource = await resourceGroup.GetVirtualNetworks().GetAsync(vnet.Data.Name);
            Assert.IsNotNull(virtualNetworkResource);

            IList<SubnetData> subnets = virtualNetworkResource.Value.Data.Subnets;
            foreach (SubnetData subnet in subnets)
            {
                if (!isEmpty)
                {
                    Assert.IsNotNull(subnet.NetworkSecurityGroup);
                    string nsgName = subnet.NetworkSecurityGroup?.Id.ToString().Split('/').Last();
                    Response<NetworkSecurityGroupResource> nsg = await nsgRg.GetNetworkSecurityGroups().GetAsync(nsgName);
                    ValidateSecurityRules(nsg.Value.Data.SecurityRules);
                }
                else
                {
                    Assert.IsNull(subnet.NetworkSecurityGroup);
                }
            }
        }

        private static void ValidateSecurityRules(IList<SecurityRuleData> securityRules)
        {
            foreach (SecurityRuleData securityRule in securityRules) {
                Assert.IsNotNull(securityRule.Name);
                Assert.IsNotNull(securityRule.Protocol);
                Assert.IsNotNull(securityRule.SourceAddressPrefixes);
                Assert.IsNotNull(securityRule.DestinationAddressPrefixes);
                Assert.IsNotNull(securityRule.SourcePortRanges);
                Assert.IsNotNull(securityRule.DestinationPortRanges);
                Assert.IsNotNull(securityRule.Direction);
            }
        }
    }
}
