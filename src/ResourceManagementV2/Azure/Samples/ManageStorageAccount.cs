using Microsoft.Azure.Management.V2.Resource.Authentication;
using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Azure.Management.V2.Storage;
using System;

namespace Samples
{
    /**
     * Azure Storage sample for managing storage accounts -
     *  - Create a storage account
     *  - Get | regenerate storage account access keys
     *  - Create another storage account
     *  - List storage accounts
     *  - Delete a storage account.
     */

    public static class ManageStorageAccount
    {
        public static void TestStorageAccount()
        {
            var storageAccountName = Utilities.createRandomName("sa");
            var storageAccountName2 = Utilities.createRandomName("sa2");
            var rgName = Utilities.createRandomName("rgSTMS");

            try
            {
                var tokenCredentials = new ApplicationTokenCredentials(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var storageManager = StorageManager
                    .Configure()
                    .withLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                    .Authenticate(tokenCredentials, tokenCredentials.DefaultSubscriptionId);

                // Print selected subscription
                Console.WriteLine("Selected subscription: " + tokenCredentials.DefaultSubscriptionId);

                try
                {
                    // ============================================================
                    // Create a storage account

                    Console.WriteLine("Creating a Storage Account");

                    var storageAccount = storageManager.StorageAccounts.Define(storageAccountName)
                            .WithRegion(Region.US_EAST)
                            .WithNewResourceGroup(rgName)
                            .Create();

                    Console.WriteLine("Created a Storage Account:");
                    Utilities.PrintStorageAccount(storageAccount);

                    // ============================================================
                    // Get | regenerate storage account access keys

                    Console.WriteLine("Getting storage account access keys");

                    var storageAccountKeys = storageAccount.Keys;

                    Utilities.PrintStorageAccountKeys(storageAccountKeys);

                    Console.WriteLine("Regenerating first storage account access key");

                    storageAccountKeys = storageAccount.RegenerateKey(storageAccountKeys[0].KeyName);

                    Utilities.PrintStorageAccountKeys(storageAccountKeys);

                    // ============================================================
                    // Create another storage account

                    Console.WriteLine("Creating a 2nd Storage Account");

                    var storageAccount2 = storageManager.StorageAccounts.Define(storageAccountName2)
                            .WithRegion(Region.US_EAST)
                            .WithNewResourceGroup(rgName)
                            .Create();

                    Console.WriteLine("Created a Storage Account:");
                    Utilities.PrintStorageAccount(storageAccount2);

                    // ============================================================
                    // List storage accounts

                    Console.WriteLine("Listing storage accounts");

                    var storageAccounts = storageManager.StorageAccounts;

                    var accounts = storageAccounts.ListByGroup(rgName);

                    foreach (var account in accounts)
                    {
                        Console.WriteLine($"Storage Account {account.Name} created @ {account.CreationTime}");
                    }

                    // ============================================================
                    // Delete a storage account

                    Console.WriteLine($"Deleting a storage account - {accounts[0].Name} created @ {accounts[0].CreationTime}");

                    storageManager.StorageAccounts.Delete(accounts[0].Id);

                    Console.WriteLine("Deleted storage account");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    if (storageManager.ResourceManager.ResourceGroups.GetByName(rgName) != null)
                    {
                        Console.WriteLine("Deleting Resource Group: " + rgName);
                        storageManager.ResourceManager.ResourceGroups.Delete(rgName);
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