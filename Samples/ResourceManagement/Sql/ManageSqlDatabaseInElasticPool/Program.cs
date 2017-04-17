// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
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
     *  - Add another elastic pool in existing SQL Server.
     *  - Delete database, elastic pools and SQL Server
     */
    public class Program
    {
        private static readonly string elasticPoolName = "myElasticPool";
        private static readonly string elasticPool2Name = "secondElasticPool";
        private static readonly string administratorLogin = "sqladmin3423";
        private static readonly string administratorPassword = "myS3cureP@ssword";
        private static readonly string database1Name = "myDatabase1";
        private static readonly string database2Name = "myDatabase2";
        private static readonly string anotherDatabaseName = "myAnotherDatabase";
        private static readonly string elasticPoolEdition = ElasticPoolEditions.Standard;

        public static void RunSample(IAzure azure)
        {
            string sqlServerName = SdkContext.RandomResourceName("sqlserver", 20);
            string rgName = SdkContext.RandomResourceName("rgRSSDEP", 20);
            
            try
            {
                // ============================================================
                // Create a SQL Server, with 2 firewall rules.

                var sqlServer = azure.SqlServers.Define(sqlServerName)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(rgName)
                        .WithAdministratorLogin(administratorLogin)
                        .WithAdministratorPassword(administratorPassword)
                        .WithNewElasticPool(elasticPoolName, elasticPoolEdition, database1Name, database2Name)
                        .Create();

                Utilities.PrintSqlServer(sqlServer);

                // ============================================================
                // List and prints the elastic pools
                foreach (var elasticPoolInList in sqlServer.ElasticPools.List())
                {
                    Utilities.PrintElasticPool(elasticPoolInList);
                }

                // ============================================================
                // Get and prints the elastic pool
                var elasticPool = sqlServer.ElasticPools.Get(elasticPoolName);
                Utilities.PrintElasticPool(elasticPool);

                // ============================================================
                // Change DTUs in the elastic pools.
                elasticPool = elasticPool.Update()
                        .WithDtu(200)
                        .WithStorageCapacity(204800)
                        .WithDatabaseDtuMin(10)
                        .WithDatabaseDtuMax(50)
                        .Apply();

                Utilities.PrintElasticPool(elasticPool);

                Utilities.Log("Start ------- Current databases in the elastic pool");
                foreach (var databaseInElasticPool in elasticPool.ListDatabases())
                {
                    Utilities.PrintDatabase(databaseInElasticPool);
                }
                Utilities.Log("End --------- Current databases in the elastic pool");

                // ============================================================
                // Create a Database in SQL server created above.
                Utilities.Log("Creating a database");

                var database = sqlServer.Databases
                        .Define("myNewDatabase")
                        .Create();
                Utilities.PrintDatabase(database);

                Utilities.Log("Start ------- Current databases in the elastic pool");
                foreach (var databaseInElasticPool in elasticPool.ListDatabases())
                {
                    Utilities.PrintDatabase(databaseInElasticPool);
                }
                Utilities.Log("End --------- Current databases in the elastic pool");

                // ============================================================
                // Move newly created database to the pool.
                Utilities.Log("Updating a database");
                database = database.Update()
                        .WithExistingElasticPool(elasticPoolName)
                        .Apply();
                Utilities.PrintDatabase(database);

                // ============================================================
                // Create another database and move it in elastic pool as update to the elastic pool.
                var anotherDatabase = sqlServer.Databases.Define(anotherDatabaseName)
                        .Create();

                // ============================================================
                // Update the elastic pool to have newly created database.
                elasticPool.Update()
                        .WithExistingDatabase(anotherDatabase)
                        .Apply();

                Utilities.Log("Start ------- Current databases in the elastic pool");
                foreach (var databaseInElasticPool in elasticPool.ListDatabases())
                {
                    Utilities.PrintDatabase(databaseInElasticPool);
                }
                Utilities.Log("End --------- Current databases in the elastic pool");

                // ============================================================
                // Remove the database from the elastic pool.
                Utilities.Log("Remove the database from the pool.");
                anotherDatabase = anotherDatabase.Update()
                        .WithoutElasticPool()
                        .WithEdition(DatabaseEditions.Standard)
                        .Apply();
                Utilities.PrintDatabase(anotherDatabase);

                Utilities.Log("Start ------- Current databases in the elastic pool");
                foreach (var databaseInElasticPool in elasticPool.ListDatabases())
                {
                    Utilities.PrintDatabase(databaseInElasticPool);
                }
                Utilities.Log("End --------- Current databases in the elastic pool");

                // ============================================================
                // Get list of elastic pool's activities and print the same.
                Utilities.Log("Start ------- Activities in a elastic pool");
                foreach (var activity in elasticPool.ListActivities())
                {
                    Utilities.PrintElasticPoolActivity(activity);
                }
                Utilities.Log("End ------- Activities in a elastic pool");

                // ============================================================
                // Get list of elastic pool's database activities and print the same.

                Utilities.Log("Start ------- Activities in a elastic pool");
                foreach (var databaseActivity in elasticPool.ListDatabaseActivities())
                {
                    Utilities.PrintDatabaseActivity(databaseActivity);
                }
                Utilities.Log("End ------- Activities in a elastic pool");

                // ============================================================
                // List databases in the sql server and delete the same.
                Utilities.Log("List and delete all databases from SQL Server");
                foreach (var databaseInServer in sqlServer.Databases.List())
                {
                    Utilities.PrintDatabase(databaseInServer);
                    databaseInServer.Delete();
                }

                // ============================================================
                // Create another elastic pool in SQL Server
                Utilities.Log("Create ElasticPool in existing SQL Server");
                var elasticPool2 = sqlServer.ElasticPools.Define(elasticPool2Name)
                        .WithEdition(elasticPoolEdition)
                        .Create();

                Utilities.PrintElasticPool(elasticPool2);
                // ============================================================
                // Deletes the elastic pool.
                Utilities.Log("Delete the elastic pool from the SQL Server");
                sqlServer.ElasticPools.Delete(elasticPoolName);
                sqlServer.ElasticPools.Delete(elasticPool2Name);

                // ============================================================
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
                var credentials = SdkContext.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
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