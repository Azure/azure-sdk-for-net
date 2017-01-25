// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.Sql.Fluent.Models;
using System;

namespace ManageSqlDatabase
{
    public class Program
    {
        private static readonly string administratorLogin = "sqladmin3423";
        private static readonly string administratorPassword = "myS3cureP@ssword";
        private static readonly string firewallRuleIpAddress = "10.0.0.1";
        private static readonly string firewallRuleStartIpAddress = "10.2.0.1";
        private static readonly string firewallRuleEndIpAddress = "10.2.0.10";
        private static readonly string databaseName = "mydatabase";

        /**
         * Azure Storage sample for managing SQL Database -
         *  - Create a SQL Server along with 2 firewalls.
         *  - Create a database in SQL server
         *  - Change performance level (SKU) of SQL Database
         *  - List and delete firewalls.
         *  - Create another firewall in the SQlServer
         *  - Delete database, firewall and SQL Server
         */
        public static void RunSample(IAzure azure)
        {
            string sqlServerName = SharedSettings.RandomResourceName("sqlserver", 20);
            string rgName = SharedSettings.RandomResourceName("rgRSDSI", 20);

            try
            {
                // ============================================================
                // Create a SQL Server, with 2 firewall rules.

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
                // Create a Database in SQL server created above.
                Utilities.Log("Creating a database");

                var database = sqlServer.Databases
                        .Define(databaseName)
                        .Create();
                Utilities.PrintDatabase(database);

                // ============================================================
                // Update the edition of database.
                Utilities.Log("Updating a database");
                database = database.Update()
                        .WithEdition(DatabaseEditions.Standard)
                        .WithServiceObjective(ServiceObjectiveName.S1)
                        .Apply();
                Utilities.PrintDatabase(database);

                // ============================================================
                // List and delete all firewall rules.
                Utilities.Log("Listing all firewall rules");

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
                Utilities.Log("Creating a firewall rule for SQL Server");
                var newFirewallRule = sqlServer.FirewallRules.Define("myFirewallRule")
                        .WithIpAddress("10.10.10.10")
                        .Create();

                Utilities.PrintFirewallRule(newFirewallRule);

                // Delete the database.
                Utilities.Log("Deleting a database");
                database.Delete();

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
                catch(Exception e)
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
                Utilities.Log(e.ToString());
            }
        }
    }
}