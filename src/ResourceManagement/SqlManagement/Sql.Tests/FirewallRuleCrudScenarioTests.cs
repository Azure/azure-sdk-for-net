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
    public class FirewallRuleCrudScenarioTests
    {
        [Fact]
        public void TestGetAndListFirewallRule()
        {
            string testPrefix = "firewallrulecrudtest-";
            string testName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewV12Server(testName, "TestGetAndListFirewallRule", testPrefix, (resClient, sqlClient, resourceGroup, server) =>
            {
                // Create Firewall Rules
                //
                Dictionary<string, ServerFirewallRule> rules = new Dictionary<string, ServerFirewallRule>();

                for(int i = 0; i < 4; i++)
                {
                    string firewallRuleName = SqlManagementTestUtilities.GenerateName(testPrefix);
                    ServerFirewallRule rule = new ServerFirewallRule()
                    {
                        StartIpAddress = string.Format("0.0.0.{0}",i),
                        EndIpAddress = string.Format("0.0.0.{0}", i)
                    };
                    sqlClient.Servers.CreateOrUpdateFirewallRule(resourceGroup.Name, server.Name, firewallRuleName, rule);
                    rules.Add(firewallRuleName, rule);
                }

                foreach (var rule in rules)
                {
                    ServerFirewallRule response = sqlClient.Servers.GetFirewallRule(resourceGroup.Name, server.Name, rule.Key);
                    SqlManagementTestUtilities.ValidateFirewallRule(rule.Value, response, rule.Key);
                }

                var listResponse = sqlClient.Servers.ListFirewallRules(resourceGroup.Name, server.Name);
                Assert.Equal(rules.Count(), listResponse.Count());

                foreach (var rule in listResponse)
                {
                    SqlManagementTestUtilities.ValidateFirewallRule(rules[rule.Name], rule, rule.Name);
                }

                foreach (var rule in rules)
                {
                    SqlManagementTestUtilities.ValidateFirewallRule(rule.Value, listResponse.Single(r => r.Name == rule.Key), rule.Key);
                }
            });
        }

        [Fact]
        public void TestCreateAndDropFirewallRule()
        {
            string testPrefix = "firewallrulecrudtest-";
            string testName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewV12Server(testName, "TestCreateUpdateDropFirewallRule", testPrefix, (resClient, sqlClient, resourceGroup, server) =>
            {
                // Create and validate Firewall Rule
                //
                string firewallRuleName = SqlManagementTestUtilities.GenerateName(testPrefix);

                ServerFirewallRule toCreate = new ServerFirewallRule()
                {
                    StartIpAddress = "0.0.0.0",
                    EndIpAddress = "0.0.0.0"
                };
                var fr1 = sqlClient.Servers.CreateOrUpdateFirewallRule(resourceGroup.Name, server.Name, firewallRuleName, toCreate);
                SqlManagementTestUtilities.ValidateFirewallRule(toCreate, fr1, firewallRuleName);

                // Create and validate Firewall Rule
                //
                firewallRuleName = SqlManagementTestUtilities.GenerateName(testPrefix);
                toCreate = new ServerFirewallRule()
                {
                    StartIpAddress = "1.1.1.1",
                    EndIpAddress = "1.1.2.2"
                };
                var fr2 = sqlClient.Servers.CreateOrUpdateFirewallRule(resourceGroup.Name, server.Name, firewallRuleName, toCreate);
                SqlManagementTestUtilities.ValidateFirewallRule(toCreate, fr2, firewallRuleName);

                // Create and validate Firewall Rule
                //
                firewallRuleName = SqlManagementTestUtilities.GenerateName(testPrefix);
                toCreate = new ServerFirewallRule()
                {
                    StartIpAddress = "0.0.0.0",
                    EndIpAddress = "255.255.255.255"
                };
                var fr3 = sqlClient.Servers.CreateOrUpdateFirewallRule(resourceGroup.Name, server.Name, firewallRuleName, toCreate);
                SqlManagementTestUtilities.ValidateFirewallRule(toCreate, fr3, firewallRuleName);

                sqlClient.Servers.DeleteFirewallRule(resourceGroup.Name, server.Name, fr1.Name);
                sqlClient.Servers.DeleteFirewallRule(resourceGroup.Name, server.Name, fr2.Name);
                sqlClient.Servers.DeleteFirewallRule(resourceGroup.Name, server.Name, fr3.Name);
            });
        }

        [Fact]
        public void TestCreateAndUpdateFirewallRule()
        {
            string testPrefix = "firewallrulecrudtest-";
            string testName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewV12Server(testName, "TestCreateAndUpdateFirewallRule", testPrefix, (resClient, sqlClient, resourceGroup, server) =>
            {
                // Create Firewall Rule and Validate
                //
                string firewallRuleName = SqlManagementTestUtilities.GenerateName(testPrefix);

                ServerFirewallRule toCreate = new ServerFirewallRule()
                {
                    StartIpAddress = "0.0.0.0",
                    EndIpAddress = "0.0.0.0"
                };
                var fr1 = sqlClient.Servers.CreateOrUpdateFirewallRule(resourceGroup.Name, server.Name, firewallRuleName, toCreate);
                SqlManagementTestUtilities.ValidateFirewallRule(toCreate, fr1, firewallRuleName);

                // Update Firewall Rule and Validate
                toCreate = new ServerFirewallRule()
                {
                    StartIpAddress = "1.1.1.1",
                    EndIpAddress = "255.255.255.255"
                };
                fr1 = sqlClient.Servers.CreateOrUpdateFirewallRule(resourceGroup.Name, server.Name, firewallRuleName, toCreate);
                SqlManagementTestUtilities.ValidateFirewallRule(toCreate, fr1, firewallRuleName);
            });
        }
    }
}
