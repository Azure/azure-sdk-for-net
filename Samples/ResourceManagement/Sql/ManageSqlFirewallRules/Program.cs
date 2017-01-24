﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;

namespace ManageSqlFirewallRules
{
    public class Program
    {
        private static readonly string administratorLogin = "sqladmin3423";
        private static readonly string administratorPassword = "myS3cureP@ssword";
        private static readonly string firewallRuleIpAddress = "10.0.0.1";
        private static readonly string firewallRuleStartIpAddress = "10.2.0.1";
        private static readonly string firewallRuleEndIpAddress = "10.2.0.10";
        private static readonly string myFirewallName = "myFirewallRule";
        private static readonly string myFirewallRuleIpAddress = "10.10.10.10";
        private static readonly string otherFirewallRuleStartIpAddress = "121.12.12.1";
        private static readonly string otherFirewallRuleEndIpAddress = "121.12.12.10";
        
        /**
         * Azure Storage sample for managing SQL Database -
         *  - Create a SQL Server along with 2 firewalls.
         *  - Add another firewall in the SQL Server
         *  - List all firewalls.
         *  - Get a firewall.
         *  - Update a firewall.
         *  - Delete a firewall.
         *  - Add and delete a firewall as part of update of SQL Server
         *  - Delete Sql Server
         */
        public static void RunSample(IAzure azure)
        {
            string sqlServerName = SharedSettings.RandomResourceName("sqlserver", 20);
            string rgName = SharedSettings.RandomResourceName("rgRSSDFW", 20);
            
            try
            {
                // ============================================================
                // Create a SQL Server, with 2 firewall rules.
                Utilities.Log("Create a SQL server with 2 firewall rules adding a single IP Address and a range of IP Addresses");

                var sqlServer = azure.SqlServers.Define(sqlServerName)
                        .WithRegion(Region.US_EAST)
                        .WithNewResourceGroup(rgName)
                        .WithAdministratorLogin(administratorLogin)
                        .WithAdministratorPassword(administratorPassword)
                        .WithNewFirewallRule(firewallRuleIpAddress)
                        .WithNewFirewallRule(firewallRuleStartIpAddress, firewallRuleEndIpAddress)
                        .Create();

                Utilities.PrintSqlServer(sqlServer);

                // ============================================================
                // List and delete all firewall rules.
                Utilities.Log("Listing all firewall rules in SQL Server.");

                var firewallRules = sqlServer.FirewallRules.List();
                foreach (var firewallRule in firewallRules)
                {
                    // Print information of the firewall rule.
                    Utilities.PrintFirewallRule(firewallRule);

                    // Delete the firewall rule.
                    Utilities.Log("Deleting a firewall rule");
                    firewallRule.Delete();
                }

                // ============================================================
                // Add new firewall rules.
                Utilities.Log("Creating a firewall rule in existing SQL Server");
                var newFirewallRule = sqlServer.FirewallRules.Define(myFirewallName)
                        .WithIpAddress(myFirewallRuleIpAddress)
                        .Create();

                Utilities.PrintFirewallRule(newFirewallRule);
                Utilities.Log("Get a particular firewall rule in SQL Server");

                newFirewallRule = sqlServer.FirewallRules.Get(myFirewallName);
                Utilities.PrintFirewallRule(newFirewallRule);

                Utilities.Log("Deleting and adding new firewall rules as part of SQL Server update.");
                sqlServer.Update()
                        .WithoutFirewallRule(myFirewallName)
                        .WithNewFirewallRule(otherFirewallRuleStartIpAddress, otherFirewallRuleEndIpAddress)
                        .Apply();

                foreach (var sqlFirewallRule in sqlServer.FirewallRules.List())
                {
                    // Print information of the firewall rule.
                    Utilities.PrintFirewallRule(sqlFirewallRule);
                }

                // Delete the SQL Server.
                Utilities.Log("Deleting a Sql Server");
                azure.SqlServers.DeleteById(sqlServer.Id);
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.DeleteByName(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
                }
                catch (Exception e)
                {
                    Utilities.Log(e);
                }
            }
        }

        public static void Main(string[] args)
        {
            try
            {
                //=================================================================
                // Authenticate
                var credentials = SharedSettings.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.BASIC)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                // Print selected subscription
                Utilities.Log("Selected subscription: " + azure.SubscriptionId);

                RunSample(azure);
            }
            catch (Exception e)
            {
                Utilities.Log(e);
            }
        }
    }
}