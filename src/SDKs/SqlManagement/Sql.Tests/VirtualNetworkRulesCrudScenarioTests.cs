﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Sql.Tests
{
    public class VirtualNetworkRulesCrudScenarioTests
    {
        [Fact]
        public void TestGetAndListVirtualNetworkRule()
        {
            string testPrefix = "virtualnetworkrulescrudtest-";

            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                // Basic setup
                var location = SqlManagementTestUtilities.DefaultEuapPrimaryLocationId;
                ResourceGroup resourceGroup = context.CreateResourceGroup(location);
                VirtualNetwork getVnetResponse = CreateVirtualNetwork(context, resourceGroup, subnetCount: 2, location: location);

                Server server = context.CreateServer(resourceGroup, location);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // create virtual network rules
                Dictionary<string, VirtualNetworkRule> rules = new Dictionary<string, VirtualNetworkRule>();

                //rule 1
                string vnetfirewallRuleName1 = SqlManagementTestUtilities.GenerateName(testPrefix);

                VirtualNetworkRule rule1 = new VirtualNetworkRule()
                {
                    VirtualNetworkSubnetId = getVnetResponse.Subnets[0].Id.ToString()
                };
                sqlClient.VirtualNetworkRules.CreateOrUpdate(resourceGroup.Name, server.Name, vnetfirewallRuleName1, rule1);
                rules.Add(vnetfirewallRuleName1, rule1);

                //rule 2
                string vnetfirewallRuleName2 = SqlManagementTestUtilities.GenerateName(testPrefix);
                VirtualNetworkRule rule2 = new VirtualNetworkRule()
                {
                    VirtualNetworkSubnetId = getVnetResponse.Subnets[1].Id.ToString()
                };
                sqlClient.VirtualNetworkRules.CreateOrUpdate(resourceGroup.Name, server.Name, vnetfirewallRuleName2, rule2);
                rules.Add(vnetfirewallRuleName2, rule2);

                foreach (var rul in rules)
                {
                    VirtualNetworkRule response = sqlClient.VirtualNetworkRules.Get(resourceGroup.Name, server.Name, rul.Key);
                    SqlManagementTestUtilities.ValidateVirtualNetworkRule(rul.Value, response, rul.Key);
                }

                var listResponse = sqlClient.VirtualNetworkRules.ListByServer(resourceGroup.Name, server.Name);
                Assert.Equal(rules.Count(), listResponse.Count());

                foreach (var rul in listResponse)
                {
                    SqlManagementTestUtilities.ValidateVirtualNetworkRule(rules[rul.Name], rul, rul.Name);
                }

                foreach (var rul in rules)
                {
                    SqlManagementTestUtilities.ValidateVirtualNetworkRule(rul.Value, listResponse.Single(r => r.Name == rul.Key), rul.Key);
                }

            }
        }

        [Fact]
        public void TestCreateAndDropVirtualNetworkRule()
        {

            string testPrefix = "virtualnetworkrulecrudtest-";

            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                // Basic setup
                var location = SqlManagementTestUtilities.DefaultEuapPrimaryLocationId;
                ResourceGroup resourceGroup = context.CreateResourceGroup(location);
                VirtualNetwork getVnetResponse = CreateVirtualNetwork(context, resourceGroup, subnetCount: 1, location: location);

                Server server = context.CreateServer(resourceGroup, location);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // create virtual network rules
                string vnetfirewallRuleName = SqlManagementTestUtilities.GenerateName(testPrefix);

                VirtualNetworkRule rule = new VirtualNetworkRule()
                {
                    VirtualNetworkSubnetId = getVnetResponse.Subnets[0].Id.ToString()
                };
                VirtualNetworkRule vfr = sqlClient.VirtualNetworkRules.CreateOrUpdate(resourceGroup.Name, server.Name, vnetfirewallRuleName, rule);
                SqlManagementTestUtilities.ValidateVirtualNetworkRule(rule, vfr, vnetfirewallRuleName);

                // delete virtual network rules
                sqlClient.VirtualNetworkRules.Delete(resourceGroup.Name, server.Name, vfr.Name);
            }
        }

        [Fact]
        public void TestCreateAndUpdateVirtualNetworkRule()
        {

            string testPrefix = "virtualnetworkrulecrudtest-";

            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                // Basic setup
                var location = SqlManagementTestUtilities.DefaultEuapPrimaryLocationId;
                ResourceGroup resourceGroup = context.CreateResourceGroup(location);
                VirtualNetwork getVnetResponse = CreateVirtualNetwork(context, resourceGroup, subnetCount: 2, location: location);

                Server server = context.CreateServer(resourceGroup, location);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // create virtual network rules
                string vnetfirewallRuleName = SqlManagementTestUtilities.GenerateName(testPrefix);

                VirtualNetworkRule rule = new VirtualNetworkRule()
                {
                    VirtualNetworkSubnetId = getVnetResponse.Subnets[0].Id.ToString()
                };
                VirtualNetworkRule vfr = sqlClient.VirtualNetworkRules.CreateOrUpdate(resourceGroup.Name, server.Name, vnetfirewallRuleName, rule);
                SqlManagementTestUtilities.ValidateVirtualNetworkRule(rule, vfr, vnetfirewallRuleName);

                // Update Firewall Rule and Validate
                rule = new VirtualNetworkRule()
                {
                    VirtualNetworkSubnetId = getVnetResponse.Subnets[1].Id.ToString()
                };
                vfr = sqlClient.VirtualNetworkRules.CreateOrUpdate(resourceGroup.Name, server.Name, vnetfirewallRuleName, rule);
                SqlManagementTestUtilities.ValidateVirtualNetworkRule(rule, vfr, vnetfirewallRuleName);
            }
        }

        public VirtualNetwork CreateVirtualNetwork(SqlManagementTestContext context, ResourceGroup resourceGroup, int subnetCount = 1, string location = SqlManagementTestUtilities.DefaultLocationId)
        {
            NetworkManagementClient networkClient = context.GetClient<NetworkManagementClient>();

            // Create vnet andinitialize subnets
            string vnetName = SqlManagementTestUtilities.GenerateName();

            List<PrivateAccessServicePropertiesFormat> SqlPrivateAccess = new List<PrivateAccessServicePropertiesFormat>()
            {
                 new PrivateAccessServicePropertiesFormat("Microsoft.Sql")
            };

            List<Subnet> subnetList = new List<Subnet>();
            for (int i = 0; i<subnetCount; i++)
            {
                string subnetName = SqlManagementTestUtilities.GenerateName();
                String addressPrefix = "10.0." + (i + 1) + ".0/24";
                Subnet subnet = new Subnet()
                {
                    Name = subnetName,
                    AddressPrefix = addressPrefix,
                    PrivateAccessServices = SqlPrivateAccess,
                };
                subnetList.Add(subnet);
            }
            
            var vnet = new VirtualNetwork()
            {
                Location = location,

                AddressSpace = new AddressSpace()
                {
                    AddressPrefixes = new List<string>()
                        {
                            "10.0.0.0/16",
                        }
                },
                DhcpOptions = new DhcpOptions()
                {
                    DnsServers = new List<string>()
                        {
                            "10.1.1.1",
                            "10.1.2.4"
                        }
                },
                Subnets = subnetList
            };

            // Put Vnet
            var putVnetResponse = networkClient.VirtualNetworks.CreateOrUpdate(resourceGroup.Name, vnetName, vnet);
            Assert.Equal("Succeeded", putVnetResponse.ProvisioningState);

            // Get Vnet
            var getVnetResponse = networkClient.VirtualNetworks.Get(resourceGroup.Name, vnetName);

            return getVnetResponse;

        }
    }
}
