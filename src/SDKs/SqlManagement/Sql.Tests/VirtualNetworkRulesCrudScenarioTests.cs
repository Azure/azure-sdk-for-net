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
    public class VirtualNetworkRulesCrudScenarioTests
    {
        [Fact]
        public void TestGetAndListVirtualNetworkRule()
        {
            // TODO Update SQL VirtualNetworkRules test to be fully automated
            // TODO https://github.com/Azure/azure-sdk-for-net/issues/3388

            string testPrefix = "virtualnetworkrulescrudtest-";
            string suiteName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewV12Server(suiteName, "TestGetAndListVirtualNetworkRule", testPrefix, (resClient, sqlClient, resourceGroup, server) =>
            {
                // Create Firewall Rules
                //
                Dictionary<string, VirtualNetworkRule> rules = new Dictionary<string, VirtualNetworkRule>();

                string vnetfirewallRuleName = SqlManagementTestUtilities.GenerateName(testPrefix);
                VirtualNetworkRule rule = new VirtualNetworkRule()
                {
                    VirtualNetworkSubnetId = string.Format("/subscriptions/d513e2e9-97db-40f6-8d1a-ab3b340cc81a/resourceGroups/TestVnetSdk/providers/Microsoft.Network/virtualNetworks/vnetSdkTest/subnets/subnet1")
                };
                sqlClient.VirtualNetworkRules.CreateOrUpdate(resourceGroup.Name, server.Name, vnetfirewallRuleName, rule);
                rules.Add(vnetfirewallRuleName, rule);

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
            }, SqlManagementTestUtilities.DefaultEuapPrimaryLocation);
        }

        [Fact]
        public void TestCreateAndDropVirtualNetworkRule()
        {
            // TODO Update SQL VirtualNetworkRules test to be fully automated
            // TODO https://github.com/Azure/azure-sdk-for-net/issues/3388

            string testPrefix = "virtualnetworkrulecrudtest-";
            string suiteName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewV12Server(suiteName, "TestCreateAndDropVirtualNetworkRule", testPrefix, (resClient, sqlClient, resourceGroup, server) =>
            {
                // Create and validate Firewall Rule
                //
                string vnetfirewallRuleName = SqlManagementTestUtilities.GenerateName(testPrefix);

                VirtualNetworkRule toCreate = new VirtualNetworkRule()
                {
                    VirtualNetworkSubnetId = string.Format("/subscriptions/d513e2e9-97db-40f6-8d1a-ab3b340cc81a/resourceGroups/TestVnetSdk/providers/Microsoft.Network/virtualNetworks/vnetSdkTest/subnets/subnet1")
                };
                var vfr1 = sqlClient.VirtualNetworkRules.CreateOrUpdate(resourceGroup.Name, server.Name, vnetfirewallRuleName, toCreate);
                SqlManagementTestUtilities.ValidateVirtualNetworkRule(toCreate, vfr1, vnetfirewallRuleName);

                sqlClient.VirtualNetworkRules.Delete(resourceGroup.Name, server.Name, vfr1.Name);
            }, SqlManagementTestUtilities.DefaultEuapPrimaryLocation);
        }

        [Fact]
        public void TestCreateAndUpdateVirtualNetworkRule()
        {
            // TODO Update SQL VirtualNetworkRules test to be fully automated
            // TODO https://github.com/Azure/azure-sdk-for-net/issues/3388

            string testPrefix = "virtualnetworkrulecrudtest-";
            string suiteName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewV12Server(suiteName, "TestCreateAndUpdateVirtualNetworkRule", testPrefix, (resClient, sqlClient, resourceGroup, server) =>
            {
                // Create Firewall Rule and Validate
                //
                string vnetfirewallRuleName = SqlManagementTestUtilities.GenerateName(testPrefix);

                VirtualNetworkRule toCreate = new VirtualNetworkRule()
                {
                    VirtualNetworkSubnetId = string.Format("/subscriptions/d513e2e9-97db-40f6-8d1a-ab3b340cc81a/resourceGroups/TestVnetSdk/providers/Microsoft.Network/virtualNetworks/vnetSdkTest/subnets/subnet1")
                };
                var vfr1 = sqlClient.VirtualNetworkRules.CreateOrUpdate(resourceGroup.Name, server.Name, vnetfirewallRuleName, toCreate);
                SqlManagementTestUtilities.ValidateVirtualNetworkRule(toCreate, vfr1, vnetfirewallRuleName);

                // Update Firewall Rule and Validate
                toCreate = new VirtualNetworkRule()
                {
                    VirtualNetworkSubnetId = string.Format("/subscriptions/d513e2e9-97db-40f6-8d1a-ab3b340cc81a/resourceGroups/TestVnetSdk/providers/Microsoft.Network/virtualNetworks/vnetSdkTest/subnets/subnet1")
                };
                vfr1 = sqlClient.VirtualNetworkRules.CreateOrUpdate(resourceGroup.Name, server.Name, vnetfirewallRuleName, toCreate);
                SqlManagementTestUtilities.ValidateVirtualNetworkRule(toCreate, vfr1, vnetfirewallRuleName);
            }, SqlManagementTestUtilities.DefaultEuapPrimaryLocation);
        }
    }
}
