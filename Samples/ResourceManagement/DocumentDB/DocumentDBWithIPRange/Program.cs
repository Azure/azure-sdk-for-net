// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.DocumentDB.Fluent;
using Microsoft.Azure.Management.DocumentDB.Fluent.Models;
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

namespace DocumentDBWithIPRange
{
    public class Program
    {
        public static void RunSample(IAzure azure)
        {
            string docDBName = SdkContext.RandomResourceName("docDb", 10);
            string rgName = SdkContext.RandomResourceName("rgNEMV", 24);

            try
            {
                //============================================================
                // Create a documentdb.

                Console.WriteLine("Creating a documentdb...");
                IDocumentDBAccount documentDBAccount = azure.DocumentDBAccounts.Define(docDBName)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(rgName)
                        .WithKind(DatabaseAccountKind.GlobalDocumentDB)
                        .WithSessionConsistency()
                        .WithWriteReplication(Region.USEast)
                        .WithReadReplication(Region.USCentral)
                        .WithIpRangeFilter("13.91.6.132,13.91.6.1/24")
                        .Create();

                Console.WriteLine("Created documentdb");
                Utilities.Print(documentDBAccount);

                //============================================================
                // Get credentials for the documentdb.

                Console.WriteLine("Get credentials for the documentdb");
                DatabaseAccountListKeysResultInner databaseAccountListKeysResult = documentDBAccount.ListKeys();
                string masterKey = databaseAccountListKeysResult.PrimaryMasterKey;
                string endPoint = documentDBAccount.DocumentEndpoint;

                //============================================================
                // Connect to documentdb and add a collection

                Console.WriteLine("Connecting and adding collection");
                //CreateDBAndAddCollection(masterKey, endPoint);

                //============================================================
                // Delete documentdb
                Console.WriteLine("Deleting the docuemntdb");
                azure.DocumentDBAccounts.DeleteById(documentDBAccount.Id);
                Console.WriteLine("Deleted the documentdb");
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.DeleteByName(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
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
