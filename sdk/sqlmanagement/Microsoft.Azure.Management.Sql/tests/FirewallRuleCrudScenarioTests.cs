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
    public class FirewallRuleCrudScenarioTests
    {
        [Fact]
        public void TestGetAndListFirewallRule()
        {
            string testPrefix = "firewallrulecrudtest-";

            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Create Firewall Rules
                //
                Dictionary<string, FirewallRule> rules = new Dictionary<string, FirewallRule>();

                for(int i = 0; i < 4; i++)
                {
                    string firewallRuleName = SqlManagementTestUtilities.GenerateName(testPrefix);
                    FirewallRule rule = new FirewallRule()
                    {
                        StartIpAddress = string.Format("0.0.0.{0}",i),
                        EndIpAddress = string.Format("0.0.0.{0}", i)
                    };
                    sqlClient.FirewallRules.CreateOrUpdate(resourceGroup.Name, server.Name, firewallRuleName, rule);
                    rules.Add(firewallRuleName, rule);
                }

                foreach (var rule in rules)
                {
                    FirewallRule response = sqlClient.FirewallRules.Get(resourceGroup.Name, server.Name, rule.Key);
                    SqlManagementTestUtilities.ValidateFirewallRule(rule.Value, response, rule.Key);
                }

                var listResponse = sqlClient.FirewallRules.ListByServer(resourceGroup.Name, server.Name);
                Assert.Equal(rules.Count(), listResponse.Count());

                foreach (var rule in listResponse)
                {
                    SqlManagementTestUtilities.ValidateFirewallRule(rules[rule.Name], rule, rule.Name);
                }

                foreach (var rule in rules)
                {
                    SqlManagementTestUtilities.ValidateFirewallRule(rule.Value, listResponse.Single(r => r.Name == rule.Key), rule.Key);
                }
            }
        }

        [Fact]
        public void TestCreateUpdateDropFirewallRule()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Create and validate Firewall Rule
                //
                string firewallRuleName = SqlManagementTestUtilities.GenerateName();

                FirewallRule toCreate = new FirewallRule()
                {
                    StartIpAddress = "0.0.0.0",
                    EndIpAddress = "0.0.0.0"
                };
                var fr1 = sqlClient.FirewallRules.CreateOrUpdate(resourceGroup.Name, server.Name, firewallRuleName, toCreate);
                SqlManagementTestUtilities.ValidateFirewallRule(toCreate, fr1, firewallRuleName);

                // Create and validate Firewall Rule
                //
                firewallRuleName = SqlManagementTestUtilities.GenerateName();
                toCreate = new FirewallRule()
                {
                    StartIpAddress = "1.1.1.1",
                    EndIpAddress = "1.1.2.2"
                };
                var fr2 = sqlClient.FirewallRules.CreateOrUpdate(resourceGroup.Name, server.Name, firewallRuleName, toCreate);
                SqlManagementTestUtilities.ValidateFirewallRule(toCreate, fr2, firewallRuleName);

                // Create and validate Firewall Rule
                //
                firewallRuleName = SqlManagementTestUtilities.GenerateName();
                toCreate = new FirewallRule()
                {
                    StartIpAddress = "0.0.0.0",
                    EndIpAddress = "255.255.255.255"
                };
                var fr3 = sqlClient.FirewallRules.CreateOrUpdate(resourceGroup.Name, server.Name, firewallRuleName, toCreate);
                SqlManagementTestUtilities.ValidateFirewallRule(toCreate, fr3, firewallRuleName);

                sqlClient.FirewallRules.Delete(resourceGroup.Name, server.Name, fr1.Name);
                sqlClient.FirewallRules.Delete(resourceGroup.Name, server.Name, fr2.Name);
                sqlClient.FirewallRules.Delete(resourceGroup.Name, server.Name, fr3.Name);
            }
        }

        [Fact]
        public void TestCreateAndUpdateFirewallRule()
        {
            string testPrefix = "firewallrulecrudtest-";

            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Create Firewall Rule and Validate
                //
                string firewallRuleName = SqlManagementTestUtilities.GenerateName(testPrefix);

                FirewallRule toCreate = new FirewallRule()
                {
                    StartIpAddress = "0.0.0.0",
                    EndIpAddress = "0.0.0.0"
                };
                var fr1 = sqlClient.FirewallRules.CreateOrUpdate(resourceGroup.Name, server.Name, firewallRuleName, toCreate);
                SqlManagementTestUtilities.ValidateFirewallRule(toCreate, fr1, firewallRuleName);

                // Update Firewall Rule and Validate
                toCreate = new FirewallRule()
                {
                    StartIpAddress = "1.1.1.1",
                    EndIpAddress = "255.255.255.255"
                };
                fr1 = sqlClient.FirewallRules.CreateOrUpdate(resourceGroup.Name, server.Name, firewallRuleName, toCreate);
                SqlManagementTestUtilities.ValidateFirewallRule(toCreate, fr1, firewallRuleName);
            }
        }
    }
}
