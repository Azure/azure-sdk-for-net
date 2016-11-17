// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;

namespace ManageStorageAccount
{
    /**
     * Azure Storage sample for managing storage accounts -
     *  - Create a storage account
     *  - Get | regenerate storage account access keys
     *  - Create another storage account
     *  - List storage accounts
     *  - Delete a storage account.
     */

    public class Program
    {
        private static readonly string rgName = Utilities.CreateRandomName("rgSTMS");
        private static readonly string storageAccountName = Utilities.CreateRandomName("sa");
        private static readonly string storageAccountName2 = Utilities.CreateRandomName("sa2");

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
                    // Create a storage account

                    Console.WriteLine("Creating a Storage Account");

                    var storageAccount = azure.StorageAccounts.Define(storageAccountName)
                            .WithRegion(Region.US_EAST)
                            .WithNewResourceGroup(rgName)
                            .Create();

                    Console.WriteLine("Created a Storage Account:");
                    Utilities.PrintStorageAccount(storageAccount);

                    // ============================================================
                    // Get | regenerate storage account access keys

                    Console.WriteLine("Getting storage account access keys");

                    var storageAccountKeys = storageAccount.GetKeys();

                    Utilities.PrintStorageAccountKeys(storageAccountKeys);

                    Console.WriteLine("Regenerating first storage account access key");

                    storageAccountKeys = storageAccount.RegenerateKey(storageAccountKeys[0].KeyName);

                    Utilities.PrintStorageAccountKeys(storageAccountKeys);

                    // ============================================================
                    // Create another storage account

                    Console.WriteLine("Creating a 2nd Storage Account");

                    var storageAccount2 = azure.StorageAccounts.Define(storageAccountName2)
                            .WithRegion(Region.US_EAST)
                            .WithNewResourceGroup(rgName)
                            .Create();

                    Console.WriteLine("Created a Storage Account:");
                    Utilities.PrintStorageAccount(storageAccount2);

                    // ============================================================
                    // List storage accounts

                    Console.WriteLine("Listing storage accounts");

                    var storageAccounts = azure.StorageAccounts;

                    var accounts = storageAccounts.ListByGroup(rgName);

                    foreach (var account in accounts)
                    {
                        Console.WriteLine($"Storage Account {account.Name} created @ {account.CreationTime}");
                    }

                    // ============================================================
                    // Delete a storage account

                    Console.WriteLine($"Deleting a storage account - {accounts[0].Name} created @ {accounts[0].CreationTime}");

                    azure.StorageAccounts.DeleteById(accounts[0].Id);

                    Console.WriteLine("Deleted storage account");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    if (azure.ResourceGroups.GetByName(rgName) != null)
                    {
                        Console.WriteLine("Deleting Resource Group: " + rgName);
                        azure.ResourceGroups.DeleteByName(rgName);
                        Console.WriteLine("Deleted Resource Group: " + rgName);
                    }
                    else
                    {
                        Console.WriteLine("Did not create any resources in Azure. No clean up is necessary");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}