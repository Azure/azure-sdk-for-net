// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ManageStorageAccountAsync
{
    public class Program
    {
        /**
         * Azure Storage sample for managing storage accounts -
         *  - Create a storage account
         *  - Get | regenerate storage account access keys
         *  - Create another storage account
         *  - List storage accounts
         *  - Delete a storage account.
         */
        public async static Task RunSampleAsync(IAzure azure)
        {
            string rgName = SdkContext.RandomResourceName("rgSTMS", 20);
            string storageAccountName = SdkContext.RandomResourceName("sa", 20);
            string storageAccountName2 = SdkContext.RandomResourceName("sa2", 20);

            try
            {
                // ============================================================
                // Create a storage account

                Utilities.Log("Creating a Storage Account");

                var storageAccount = await azure.StorageAccounts.Define(storageAccountName)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(rgName)
                        .CreateAsync();

                Utilities.Log("Created a Storage Account:");
                Utilities.PrintStorageAccount(storageAccount);
                
                // ============================================================
                // Create another storage account

                Utilities.Log("Creating a 2nd Storage Account");

                var storageAccount2 = await azure.StorageAccounts.Define(storageAccountName2)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(rgName)
                        .CreateAsync();

                Utilities.Log("Created a Storage Account:");
                Utilities.PrintStorageAccount(storageAccount2);
                
                // ============================================================
                // List storage accounts

                Utilities.Log("Listing storage accounts");

                var storageAccounts = azure.StorageAccounts;

                var accounts = await storageAccounts.ListByResourceGroupAsync(rgName);

                foreach (var account in accounts)
                {
                    Utilities.Log($"Storage Account {account.Name} created @ {account.CreationTime}");
                    // ============================================================
                    // Get | regenerate storage account access keys

                    Utilities.Log("Getting storage account access keys");
                    var storageAccountKeys = await storageAccount.GetKeysAsync();
                    Utilities.PrintStorageAccountKeys(storageAccountKeys);

                    Utilities.Log("Regenerating first storage account access key");
                    storageAccountKeys = await storageAccount.RegenerateKeyAsync(storageAccountKeys[0].KeyName);
                    Utilities.PrintStorageAccountKeys(storageAccountKeys);
                }

                // ============================================================
                // Delete a storage account

                Utilities.Log($"Deleting a storage account - {accounts.ElementAt(0).Name} created @ {accounts.ElementAt(0).CreationTime}");

                await azure.StorageAccounts.DeleteByIdAsync(accounts.ElementAt(0).Id);

                Utilities.Log("Deleted storage account");
            }
            finally
            {
                if (azure.ResourceGroups.GetByName(rgName) != null)
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    await azure.ResourceGroups.DeleteByNameAsync(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
                }
                else
                {
                    Utilities.Log("Did not create any resources in Azure. No clean up is necessary");
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

                RunSampleAsync(azure).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Utilities.Log(ex);
            }
        }
    }
}