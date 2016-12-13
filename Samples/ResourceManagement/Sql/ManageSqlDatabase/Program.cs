// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.Sql.Fluent.Models;
using System;

namespace ManageSqlDatabase
{
    /**
     * Azure Storage sample for managing SQL Database -
     *  - Create a SQL Server along with 2 firewalls.
     *  - Create a database in SQL server
     *  - Change performance level (SKU) of SQL Database
     *  - List and delete firewalls.
     *  - Create another firewall in the SQlServer
     *  - Delete database, firewall and SQL Server
     */

    public class Program
    {
        private static readonly string sqlServerName = Utilities.CreateRandomName("sqlserver");
        private static readonly string rgName = Utilities.CreateRandomName("rgSTMS");

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

                    var sqlServer = azure.SqlServers.Define(sqlServerName)
                            .WithRegion(Region.US_EAST)
                            .WithNewResourceGroup(rgName)
                            .WithAdministratorLogin("adminlogin123")
                            .WithAdministratorPassword("myS3cureP@ssword")
                            .WithNewFirewallRule("10.0.0.1")
                            .WithNewFirewallRule("10.2.0.1", "10.2.0.10")
                            .Create();

                    Utilities.Print(sqlServer);

                    // ============================================================
                    // Create a Database in SQL server created above.
                    Console.WriteLine("Creating a database");

                    var database = sqlServer.Databases.Define("myNewDatabase")
                            .WithoutElasticPool()
                            .WithoutSourceDatabaseId()
                            .WithEdition(DatabaseEditions.Basic)
                            .Create();
                    Utilities.Print(database);

                    // ============================================================
                    // Update the edition of database.
                    Console.WriteLine("Updating a database");
                    database = database.Update()
                            .WithEdition(DatabaseEditions.Premium)
                            .WithServiceObjective(ServiceObjectiveName.P3)
                            .Apply();
                    Utilities.Print(database);

                    // ============================================================
                    // List and delete all firewall rules.
                    var firewallRules = sqlServer.FirewallRules.List();
                    foreach (var firewallRule in firewallRules)
                    {
                        // Print information of the firewall rule.
                        Utilities.Print(firewallRule);

                        // Delete the firewall rule.
                        Console.WriteLine("Deleting a firewall rule");
                        firewallRule.Delete();
                    }

                    // ============================================================
                    // Add new firewall rules.
                    Console.WriteLine("Creating a firewall rule for SQL Server");
                    var newFirewallRule = sqlServer.FirewallRules.Define("myFirewallRule")
                            .WithIpAddress("10.10.10.10")
                            .Create();

                    Utilities.Print(newFirewallRule);

                    // Delete the database.
                    Console.WriteLine("Deleting a database");
                    database.Delete();

                    // Delete the SQL Server.
                    Console.WriteLine("Deleting a Sql Server");
                    azure.SqlServers.DeleteById(sqlServer.Id);
                }
                catch (Exception f)
                {
                    Console.WriteLine(f.ToString());
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
                Console.WriteLine(e.ToString());
            }
        }
    }
}