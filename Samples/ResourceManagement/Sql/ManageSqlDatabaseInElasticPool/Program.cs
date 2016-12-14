// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.Sql.Fluent.Models;
using System;

namespace ManageSqlDatabaseInElasticPool
{
    /**
     * Azure Storage sample for managing SQL Database -
     *  - Create a SQL Server with elastic pool and 2 databases
     *  - Create another database and add it to elastic pool through database update
     *  - Create one more database and add it to elastic pool through elastic pool update.
     *  - List and print databases in the elastic pool
     *  - Remove a database from elastic pool.
     *  - List and print elastic pool activities
     *  - List and print elastic pool database activities
     *  - Delete database, elastic pools and SQL Server
     */
    public class Program
    {
        private static readonly string sqlServerName = Utilities.CreateRandomName("sqlserver");
        private static readonly string rgName = Utilities.CreateRandomName("rgSTMS");
        private static readonly string elasticPoolName = "myElasticPool";

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
                            .WithAdministratorPassword("loepop77ejk~13@@")
                            .WithNewElasticPool(elasticPoolName, ElasticPoolEditions.Standard, "myDatabase1", "myDatabase2")
                            .Create();

                    Utilities.Print(sqlServer);

                    // ============================================================
                    // List and prints the elastic pools
                    foreach (var elasticPoolInList in sqlServer.ElasticPools.List())
                    {
                        Utilities.Print(elasticPoolInList);
                    }

                    // ============================================================
                    // Get and prints the elastic pool
                    var elasticPool = sqlServer.ElasticPools.Get(elasticPoolName);
                    Utilities.Print(elasticPool);

                    // ============================================================
                    // Change DTUs in the elastic pools.
                    elasticPool = elasticPool.Update()
                            .WithDtu(200)
                            .WithDatabaseDtuMin(10)
                            .WithDatabaseDtuMax(50)
                            .Apply();

                    Utilities.Print(elasticPool);

                    Console.WriteLine("Start ------- Current databases in the elastic pool");
                    foreach (var databaseInElasticPool in elasticPool.ListDatabases())
                    {
                        Utilities.Print(databaseInElasticPool);
                    }
                    Console.WriteLine("End --------- Current databases in the elastic pool");

                    // ============================================================
                    // Create a Database in SQL server created above.
                    Console.WriteLine("Creating a database");

                    var database = sqlServer.Databases.Define("myNewDatabase")
                            .WithoutElasticPool()
                            .WithoutSourceDatabaseId()
                            .WithEdition(DatabaseEditions.Basic)
                            .Create();
                    Utilities.Print(database);

                    Console.WriteLine("Start ------- Current databases in the elastic pool");
                    foreach (var databaseInElasticPool in elasticPool.ListDatabases())
                    {
                        Utilities.Print(databaseInElasticPool);
                    }
                    Console.WriteLine("End --------- Current databases in the elastic pool");

                    // ============================================================
                    // Move newly created database to the pool.
                    Console.WriteLine("Updating a database");
                    database = database.Update()
                            .WithExistingElasticPool(elasticPoolName)
                            .Apply();
                    Utilities.Print(database);

                    // ============================================================
                    // Create another database and move it in elastic pool as update to the elastic pool.
                    var anotherDatabase = sqlServer.Databases.Define("myAnotherDatabase")
                            .WithoutElasticPool()
                            .WithoutSourceDatabaseId()
                            .Create();

                    // ============================================================
                    // Update the elastic pool to have newly created database.
                    elasticPool.Update()
                            .WithExistingDatabase(anotherDatabase)
                            .Apply();

                    Console.WriteLine("Start ------- Current databases in the elastic pool");
                    foreach (var databaseInElasticPool in elasticPool.ListDatabases())
                    {
                        Utilities.Print(databaseInElasticPool);
                    }
                    Console.WriteLine("End --------- Current databases in the elastic pool");

                    // ============================================================
                    // Remove the database from the elastic pool.
                    anotherDatabase = anotherDatabase.Update()
                            .WithoutElasticPool()
                            .WithEdition(DatabaseEditions.Standard)
                            .Apply();
                    Utilities.Print(anotherDatabase);

                    Console.WriteLine("Start ------- Current databases in the elastic pool");
                    foreach (var databaseInElasticPool in elasticPool.ListDatabases())
                    {
                        Utilities.Print(databaseInElasticPool);
                    }
                    Console.WriteLine("End --------- Current databases in the elastic pool");

                    // ============================================================
                    // Get list of elastic pool's activities and print the same.
                    Console.WriteLine("Start ------- Activities in a elastic pool");
                    foreach (var activity in elasticPool.ListActivities())
                    {
                        Utilities.Print(activity);
                    }
                    Console.WriteLine("End ------- Activities in a elastic pool");

                    // ============================================================
                    // Get list of elastic pool's database activities and print the same.

                    Console.WriteLine("Start ------- Activities in a elastic pool");
                    foreach (var databaseActivity in elasticPool.ListDatabaseActivities())
                    {
                        Utilities.Print(databaseActivity);
                    }
                    Console.WriteLine("End ------- Activities in a elastic pool");

                    // ============================================================
                    // List databases in the sql server and delete the same.
                    Console.WriteLine("List and delete all databases from SQL Server");
                    foreach (var databaseInServer in sqlServer.Databases.List())
                    {
                        Utilities.Print(databaseInServer);
                        databaseInServer.Delete();
                    }

                    // ============================================================
                    // Deletes the elastic pool.
                    Console.WriteLine("Delete the elastic pool from the SQL Server");
                    sqlServer.ElasticPools.Delete(elasticPoolName);

                    // ============================================================
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