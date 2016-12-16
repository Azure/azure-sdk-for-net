// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;

namespace ManageSqlFirewallRules
{
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

    public class Program
    {
        private static readonly string sqlServerName = Utilities.CreateRandomName("sqlserver");
        private static readonly string rgName = Utilities.CreateRandomName("rgRSSDFW");
        private static readonly string administratorLogin = "sqladmin3423";
        private static readonly string administratorPassword = "myS3cureP@ssword";
        private static readonly string firewallRuleIpAddress = "10.0.0.1";
        private static readonly string firewallRuleStartIpAddress = "10.2.0.1";
        private static readonly string firewallRuleEndIpAddress = "10.2.0.10";
        private static readonly string myFirewallName = "myFirewallRule";
        private static readonly string myFirewallRuleIpAddress = "10.10.10.10";
        private static readonly string otherFirewallRuleStartIpAddress = "121.12.12.1";
        private static readonly string otherFirewallRuleEndIpAddress = "121.12.12.10";

        public static void Main(string[] args)
        {
            try
            {
                //=================================================================
                // Authenticate
                var credentials = AzureCredentials.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.BASIC)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                // Print selected subscription
                Console.WriteLine("Selected subscription: " + azure.SubscriptionId);

                try
                {
                    // ============================================================
                    // Create a SQL Server, with 2 firewall rules.
                    Console.WriteLine("Create a SQL server with 2 firewall rules adding a single IP Address and a range of IP Addresses");

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
                    Console.WriteLine("Listing all firewall rules in SQL Server.");

                    var firewallRules = sqlServer.FirewallRules.List();
                    foreach (var firewallRule in firewallRules)
                    {
                        // Print information of the firewall rule.
                        Utilities.PrintFirewallRule(firewallRule);

                        // Delete the firewall rule.
                        Console.WriteLine("Deleting a firewall rule");
                        firewallRule.Delete();
                    }

                    // ============================================================
                    // Add new firewall rules.
                    Console.WriteLine("Creating a firewall rule in existing SQL Server");
                    var newFirewallRule = sqlServer.FirewallRules.Define(myFirewallName)
                            .WithIpAddress(myFirewallRuleIpAddress)
                            .Create();

                    Utilities.PrintFirewallRule(newFirewallRule);
                    Console.WriteLine("Get a particular firewall rule in SQL Server");

                    newFirewallRule = sqlServer.FirewallRules.Get(myFirewallName);
                    Utilities.PrintFirewallRule(newFirewallRule);

                    Console.WriteLine("Deleting and adding new firewall rules as part of SQL Server update.");
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
                    Console.WriteLine("Deleting a Sql Server");
                    azure.SqlServers.DeleteById(sqlServer.Id);
                }
                catch (Exception f)
                {
                    Console.WriteLine(f);
                }
                finally
                {
                    try
                    {
                        Console.WriteLine("Deleting Resource Group: " + rgName);
                        azure.ResourceGroups.DeleteByName(rgName);
                        Console.WriteLine("Deleted Resource Group: " + rgName);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Did not create any resources in Azure. No clean up is necessary");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}