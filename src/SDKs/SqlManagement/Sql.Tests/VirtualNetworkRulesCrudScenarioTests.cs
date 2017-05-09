// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Sql.Tests
{
    public class VnetFirewallRuleCrudScenarioTests
    {
        [Fact]
        public void TestGetAndListVnetFirewallRule()
        {
            string testPrefix = "vnetfirewallrulecrudtest-";
            string suiteName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewV12Server(suiteName, "TestGetAndListVnetFirewallRule", testPrefix, (resClient, sqlClient, resourceGroup, server) =>
            {
                // Create Firewall Rules
                //
                Dictionary<string, VnetFirewallRule> rules = new Dictionary<string, VnetFirewallRule>();

                string vnetfirewallRuleName = SqlManagementTestUtilities.GenerateName(testPrefix);
                VnetFirewallRule rule = new VnetFirewallRule()
                {
                    VirtualNetworkSubnetId = string.Format("/subscriptions/79653d5b-24a0-4728-877c-ba3663c6b93d/resourceGroups/testrgcus/providers/Microsoft.Network/virtualNetworks/vnet2/subnets/subnet1")
                };
                sqlClient.VnetFirewallRules.CreateOrUpdate(resourceGroup.Name, server.Name, vnetfirewallRuleName, rule);
                rules.Add(vnetfirewallRuleName, rule);

                foreach (var rul in rules)
                {
                    VnetFirewallRule response = sqlClient.VnetFirewallRules.Get(resourceGroup.Name, server.Name, rul.Key);
                    SqlManagementTestUtilities.ValidateVnetFirewallRule(rul.Value, response, rul.Key);
                }

                var listResponse = sqlClient.VnetFirewallRules.ListByServer(resourceGroup.Name, server.Name);
                Assert.Equal(rules.Count(), listResponse.Count());

                foreach (var rul in listResponse)
                {
                    SqlManagementTestUtilities.ValidateVnetFirewallRule(rules[rul.Name], rul, rul.Name);
                }

                foreach (var rul in rules)
                {
                    SqlManagementTestUtilities.ValidateVnetFirewallRule(rul.Value, listResponse.Single(r => r.Name == rul.Key), rul.Key);
                }
            });
        }

        [Fact]
        public void TestCreateAndDropVnetFirewallRule()
        {
            string testPrefix = "vnetfirewallrulecrudtest-";
            string suiteName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewV12Server(suiteName, "TestCreateAndDropVnetFirewallRule", testPrefix, (resClient, sqlClient, resourceGroup, server) =>
            {
                // Create and validate Firewall Rule
                //
                string vnetfirewallRuleName = SqlManagementTestUtilities.GenerateName(testPrefix);

                VnetFirewallRule toCreate = new VnetFirewallRule()
                {
                    VirtualNetworkSubnetId = string.Format("/subscriptions/79653d5b-24a0-4728-877c-ba3663c6b93d/resourceGroups/testrgcus/providers/Microsoft.Network/virtualNetworks/vnet2/subnets/subnet1")
                };
                var vfr1 = sqlClient.VnetFirewallRules.CreateOrUpdate(resourceGroup.Name, server.Name, vnetfirewallRuleName, toCreate);
                SqlManagementTestUtilities.ValidateVnetFirewallRule(toCreate, vfr1, vnetfirewallRuleName);

                sqlClient.VnetFirewallRules.Delete(resourceGroup.Name, server.Name, vfr1.Name);
            });
        }

        [Fact]
        public void TestCreateAndUpdateVnetFirewallRule()
        {
            string testPrefix = "vnetfirewallrulecrudtest-";
            string suiteName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewV12Server(suiteName, "TestCreateAndUpdateVnetFirewallRule", testPrefix, (resClient, sqlClient, resourceGroup, server) =>
            {
                // Create Firewall Rule and Validate
                //
                string vnetfirewallRuleName = SqlManagementTestUtilities.GenerateName(testPrefix);

                VnetFirewallRule toCreate = new VnetFirewallRule()
                {
                    VirtualNetworkSubnetId = string.Format("/subscriptions/79653d5b-24a0-4728-877c-ba3663c6b93d/resourceGroups/testrgcus/providers/Microsoft.Network/virtualNetworks/vnet2/subnets/subnet1")
                };
                var vfr1 = sqlClient.VnetFirewallRules.CreateOrUpdate(resourceGroup.Name, server.Name, vnetfirewallRuleName, toCreate);
                SqlManagementTestUtilities.ValidateVnetFirewallRule(toCreate, vfr1, vnetfirewallRuleName);

                // Update Firewall Rule and Validate
                toCreate = new VnetFirewallRule()
                {
                    VirtualNetworkSubnetId = string.Format("/subscriptions/79653d5b-24a0-4728-877c-ba3663c6b93d/resourceGroups/testrgcus/providers/Microsoft.Network/virtualNetworks/vnet3/subnets/subnet1")
                };
                vfr1 = sqlClient.VnetFirewallRules.CreateOrUpdate(resourceGroup.Name, server.Name, vnetfirewallRuleName, toCreate);
                SqlManagementTestUtilities.ValidateVnetFirewallRule(toCreate, vfr1, vnetfirewallRuleName);
            });
        }
    }
}
