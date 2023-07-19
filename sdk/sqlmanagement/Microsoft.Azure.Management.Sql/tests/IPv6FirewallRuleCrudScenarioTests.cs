// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
    public class IPv6FirewallRuleCrudScenarioTests
    {
        [Fact]
        public void TestGetAndListIPv6FirewallRule()
        {
            string testPrefix = "ipv6firewallrulecrudtest-";

            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Create IPv6 Firewall Rules
                //
                Dictionary<string, IPv6FirewallRule> rules = new Dictionary<string, IPv6FirewallRule>();

                for(int i = 0; i < 4; i++)
                {
                    string ipv6FirewallRuleName = SqlManagementTestUtilities.GenerateName(testPrefix);
                    IPv6FirewallRule rule = new IPv6FirewallRule()
                    {
                        StartIPv6Address = string.Format("0000:0000:0000:0000:0000:ffff:0000:000{0}", i),
                        EndIPv6Address = string.Format("0000:0000:0000:0000:0000:ffff:0000:000{0}", i)
                    };
                    sqlClient.IPv6FirewallRules.CreateOrUpdate(resourceGroup.Name, server.Name, ipv6FirewallRuleName, rule);
                    rules.Add(ipv6FirewallRuleName, rule);
                }

                foreach (var rule in rules)
                {
                    IPv6FirewallRule response = sqlClient.IPv6FirewallRules.Get(resourceGroup.Name, server.Name, rule.Key);
                    SqlManagementTestUtilities.ValidateIPv6FirewallRule(rule.Value, response, rule.Key);
                }

                var listResponse = sqlClient.IPv6FirewallRules.ListByServer(resourceGroup.Name, server.Name);
                Assert.Equal(rules.Count(), listResponse.Count());

                foreach (var rule in listResponse)
                {
                    SqlManagementTestUtilities.ValidateIPv6FirewallRule(rules[rule.Name], rule, rule.Name);
                }

                foreach (var rule in rules)
                {
                    SqlManagementTestUtilities.ValidateIPv6FirewallRule(rule.Value, listResponse.Single(r => r.Name == rule.Key), rule.Key);
                }
            }
        }

        [Fact]
        public void TestCreateUpdateDropIPv6FirewallRule()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Create and validate ipv6 Firewall Rule
                //
                string ipv6FirewallRuleName = SqlManagementTestUtilities.GenerateName();

                IPv6FirewallRule toCreate = new IPv6FirewallRule()
                {
                    StartIPv6Address = "0000:0000:0000:0000:0000:ffff:0000:0000",
                    EndIPv6Address = "0000:0000:0000:0000:0000:ffff:0000:0000" 
                };
                var fr1 = sqlClient.IPv6FirewallRules.CreateOrUpdate(resourceGroup.Name, server.Name, ipv6FirewallRuleName, toCreate);
                SqlManagementTestUtilities.ValidateIPv6FirewallRule(toCreate, fr1, ipv6FirewallRuleName);

                // Create and validate IPv6 Firewall Rule
                //
                ipv6FirewallRuleName = SqlManagementTestUtilities.GenerateName();
                toCreate = new IPv6FirewallRule()
                {
                    StartIPv6Address = "0000:0000:0000:0000:0000:ffff:0101:0101",
                    EndIPv6Address = "0000:0000:0000:0000:0000:ffff:0101:0202"
                };
                var fr2 = sqlClient.IPv6FirewallRules.CreateOrUpdate(resourceGroup.Name, server.Name, ipv6FirewallRuleName, toCreate);
                SqlManagementTestUtilities.ValidateIPv6FirewallRule(toCreate, fr2, ipv6FirewallRuleName);

                // Create and validate IPv6 Firewall Rule
                //
                ipv6FirewallRuleName = SqlManagementTestUtilities.GenerateName();
                toCreate = new IPv6FirewallRule()
                {
                    StartIPv6Address = "0000:0000:0000:0000:0000:ffff:0000:0000",
                    EndIPv6Address = "0000:0000:0000:0000:0000:ffff:ffff:ffff"
                };
                var fr3 = sqlClient.IPv6FirewallRules.CreateOrUpdate(resourceGroup.Name, server.Name, ipv6FirewallRuleName, toCreate);
                SqlManagementTestUtilities.ValidateIPv6FirewallRule(toCreate, fr3, ipv6FirewallRuleName);

                sqlClient.IPv6FirewallRules.Delete(resourceGroup.Name, server.Name, fr1.Name);
                sqlClient.IPv6FirewallRules.Delete(resourceGroup.Name, server.Name, fr2.Name);
                sqlClient.IPv6FirewallRules.Delete(resourceGroup.Name, server.Name, fr3.Name);
            }
        }

        [Fact]
        public void TestCreateAndUpdateIPv6FirewallRule()
        {
            string testPrefix = "ipv6firewallrulecrudtest-";

            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Create IPv6 Firewall Rule and Validate
                string ipv6FirewallRuleName = SqlManagementTestUtilities.GenerateName(testPrefix);

                IPv6FirewallRule toCreate = new IPv6FirewallRule()
                {
                    StartIPv6Address = "0000:0000:0000:0000:0000:ffff:0000:0000",
                    EndIPv6Address = "0000:0000:0000:0000:0000:ffff:0000:0000"
                };
                var fr1 = sqlClient.IPv6FirewallRules.CreateOrUpdate(resourceGroup.Name, server.Name, ipv6FirewallRuleName, toCreate);
                SqlManagementTestUtilities.ValidateIPv6FirewallRule(toCreate, fr1, ipv6FirewallRuleName);

                // Update Firewall Rule and Validate
                toCreate = new IPv6FirewallRule()
                {
                    StartIPv6Address = "0000:0000:0000:0000:0000:ffff:0101:0101",
                    EndIPv6Address = "0000:0000:0000:0000:0000:ffff:ffff:ffff"
                };
                fr1 = sqlClient.IPv6FirewallRules.CreateOrUpdate(resourceGroup.Name, server.Name, ipv6FirewallRuleName, toCreate);
                SqlManagementTestUtilities.ValidateIPv6FirewallRule(toCreate, fr1, ipv6FirewallRuleName);
            }
        }
    }
}
