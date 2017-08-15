// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.CosmosDB.Fluent;
using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace HACosmosDB
{
    public class Program
    {
        const String DATABASE_ID = "TestDB";
        const String COLLECTION_ID = "TestCollection";

        /**
         * Azure CosmosDB sample -
         *  - Create a CosmosDB configured with a single read location
         *  - Get the credentials for the CosmosDB
         *  - Update the CosmosDB with additional read locations
         *  - add collection to the CosmosDB with throughput 4000
         *  - Delete the CosmosDB
         */
        public static void RunSample(IAzure azure)
        {
            string docDBName = SdkContext.RandomResourceName("docDb", 10);
            string rgName = SdkContext.RandomResourceName("rgNEMV", 24);

            try
            {
                //============================================================
                // Create a CosmosDB.

                Console.WriteLine("Creating a CosmosDB...");
                ICosmosDBAccount cosmosDBAccount = azure.CosmosDBAccounts.Define(docDBName)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(rgName)
                        .WithKind(DatabaseAccountKind.GlobalDocumentDB)
                        .WithSessionConsistency()
                        .WithWriteReplication(Region.USEast)
                        .WithReadReplication(Region.USCentral)
                        .WithIpRangeFilter("13.91.6.132,13.91.6.1/24")
                        .Create();

                Console.WriteLine("Created CosmosDB");
                Utilities.Print(cosmosDBAccount);

                //============================================================
                // Update document db with three additional read regions

                Console.WriteLine("Updating CosmosDB with three additional read replication regions");
                cosmosDBAccount = cosmosDBAccount.Update()
                        .WithReadReplication(Region.AsiaEast)
                        .WithReadReplication(Region.AsiaSouthEast)
                        .WithReadReplication(Region.UKSouth)
                        .Apply();

                Console.WriteLine("Updated CosmosDB");
                Utilities.Print(cosmosDBAccount);

                //============================================================
                // Get credentials for the CosmosDB.

                Console.WriteLine("Get credentials for the CosmosDB");
                DatabaseAccountListKeysResultInner databaseAccountListKeysResult = cosmosDBAccount.ListKeys();
                string masterKey = databaseAccountListKeysResult.PrimaryMasterKey;
                string endPoint = cosmosDBAccount.DocumentEndpoint;

                //============================================================
                // Connect to CosmosDB and add a collection

                Console.WriteLine("Connecting and adding collection");
                //CreateDBAndAddCollection(masterKey, endPoint);

                //============================================================
                // Delete CosmosDB
                Console.WriteLine("Deleting the CosmosDB");
                azure.CosmosDBAccounts.DeleteById(cosmosDBAccount.Id);
                Console.WriteLine("Deleted the CosmosDB");
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting resource group: " + rgName);
                    azure.ResourceGroups.DeleteByName(rgName);
                    Utilities.Log("Deleted resource group: " + rgName);
                }
                catch (NullReferenceException)
                {
                    Utilities.Log("Did not create any resources in Azure. No clean up is necessary");
                }
                catch (Exception e)
                {
                    Utilities.Log(e.StackTrace);
                }
            }
        }

        private void CreateDBAndAddCollection(string masterKey, string endPoint)
        {
            DocumentClient documentClient = new DocumentClient(new System.Uri(endPoint),
                    masterKey, ConnectionPolicy.Default,
                    ConsistencyLevel.Session);

            // Define a new database using the id above.
            Database myDatabase = new Database();
            myDatabase.Id = DATABASE_ID;

            myDatabase = documentClient.CreateDatabaseAsync(myDatabase, null)
                    .GetAwaiter().GetResult();

            Console.WriteLine("Created a new database:");
            Console.WriteLine(myDatabase.ToString());

            // Define a new collection using the id above.
            DocumentCollection myCollection = new DocumentCollection();
            myCollection.Id = COLLECTION_ID;

            // Set the provisioned throughput for this collection to be 1000 RUs.
            RequestOptions requestOptions = new RequestOptions();
            requestOptions.OfferThroughput = 4000;

            // Create a new collection.
            myCollection = documentClient.CreateDocumentCollectionAsync(
                    "dbs/" + DATABASE_ID, myCollection, requestOptions)
                    .GetAwaiter().GetResult();
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
                Utilities.Log(e.Message);
                Utilities.Log(e.StackTrace);
            }
        }
    }
}
