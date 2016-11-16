// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Batch.Fluent.Models;
using Microsoft.Azure.Management.Batch.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Linq;

namespace ManageBatchAccount
{
    /**
     * Azure Batch sample for managing batch accounts -
     *  - Get subscription batch account quota for a particular location.
     *  - List all the batch accounts, look if quota allows you to create a new batch account at specified location by counting batch accounts in that particular location.
     *  - Create a batch account with new application and application package, along with new storage account.
     *  - Get the keys for batch account.
     *  - Regenerate keys for batch account
     *  - Regenerate the keys of storage accounts, sync with batch account.
     *  - Update application's display name.
     *  - Create another batch account using existing storage account.
     *  - List the batch account.
     *  - Delete the batch account.
     *      - Delete the application packages.
     *      - Delete applications.
     */

    public class Program
    {
        private static readonly string batchAccountName = Utilities.CreateRandomName("ba");
        private static readonly string storageAccountName = Utilities.CreateRandomName("sa");
        private static readonly string applicationName = "application";
        private static readonly string applicationDisplayName = "My application display name";
        private static readonly string applicationPackageName = "app_package";
        private static readonly string batchAccountName2 = Utilities.CreateRandomName("ba2");
        private static readonly string rgName = Utilities.CreateRandomName("rgBAMB");
        private static readonly Region region = Region.AUSTRALIA_SOUTHEAST;
        private static readonly Region region2 = Region.US_CENTRAL;

        public static void Main(string[] args)
        {
            try
            {
                //=================================================================
                // Authenticate
                AzureCredentials credentials = AzureCredentials.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.BASIC)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                // Print selected subscription
                Console.WriteLine("Selected subscription: " + azure.SubscriptionId);

                try
                {
                    // ===========================================================
                    // Get how many batch accounts can be created in specified region.

                    int allowedNumberOfBatchAccounts = azure.BatchAccounts.GetBatchAccountQuotaByLocation(region);

                    // ===========================================================
                    // List all the batch accounts in subscription.

                    var batchAccounts = azure.BatchAccounts.List();
                    int batchAccountsAtSpecificRegion = batchAccounts.Count(x => x.Region == region);

                    if (batchAccountsAtSpecificRegion >= allowedNumberOfBatchAccounts)
                    {
                        Console.WriteLine("No more batch accounts can be created at "
                                + region + " region, this region already have "
                                + batchAccountsAtSpecificRegion
                                + " batch accounts, current quota to create batch account in "
                                + region + " region is " + allowedNumberOfBatchAccounts + ".");
                        return;
                    }

                    // ============================================================
                    // Create a batch account

                    Console.WriteLine("Creating a batch Account");

                    var batchAccount = azure.BatchAccounts.Define(batchAccountName)
                            .WithRegion(region)
                            .WithNewResourceGroup(rgName)
                                .DefineNewApplication(applicationName)
                                    .DefineNewApplicationPackage(applicationPackageName)
                                .WithAllowUpdates(true)
                                .WithDisplayName(applicationDisplayName)
                                .Attach()
                            .WithNewStorageAccount(storageAccountName)
                            .Create();

                    Console.WriteLine("Created a batch Account:");
                    Utilities.PrintBatchAccount(batchAccount);

                    // ============================================================
                    // Get | regenerate batch account access keys

                    Console.WriteLine("Getting batch account access keys");

                    var batchAccountKeys = batchAccount.GetKeys();

                    Utilities.PrintBatchAccountKey(batchAccountKeys);

                    Console.WriteLine("Regenerating primary batch account primary access key");

                    batchAccountKeys = batchAccount.RegenerateKeys(AccountKeyType.Primary);

                    Utilities.PrintBatchAccountKey(batchAccountKeys);

                    // ============================================================
                    // Regenerate the keys for storage account
                    var storageAccount = azure.StorageAccounts.GetByGroup(rgName, storageAccountName);
                    var storageAccountKeys = storageAccount.GetKeys();

                    Utilities.PrintStorageAccountKeys(storageAccountKeys);

                    Console.WriteLine("Regenerating first storage account access key");

                    storageAccountKeys = storageAccount.RegenerateKey(storageAccountKeys[0].KeyName);

                    Utilities.PrintStorageAccountKeys(storageAccountKeys);

                    // ============================================================
                    // Synchronize storage account keys with batch account

                    batchAccount.SynchronizeAutoStorageKeys();

                    // ============================================================
                    // Update name of application.
                    batchAccount
                        .Update()
                            .UpdateApplication(applicationName)
                            .WithDisplayName("New application display name")
                            .Parent()
                        .Apply();

                    batchAccount.Refresh();
                    Utilities.PrintBatchAccount(batchAccount);

                    // ============================================================
                    // Create another batch account

                    Console.WriteLine("Creating another Batch Account");

                    allowedNumberOfBatchAccounts = azure.BatchAccounts.GetBatchAccountQuotaByLocation(region2);

                    // ===========================================================
                    // List all the batch accounts in subscription.

                    batchAccounts = azure.BatchAccounts.List();
                    batchAccountsAtSpecificRegion = batchAccounts.Count(x => x.Region == region2);

                    IBatchAccount batchAccount2 = null;
                    if (batchAccountsAtSpecificRegion < allowedNumberOfBatchAccounts)
                    {
                        batchAccount2 = azure.BatchAccounts.Define(batchAccountName2)
                                .WithRegion(region2)
                                .WithExistingResourceGroup(rgName)
                                .WithExistingStorageAccount(storageAccount)
                                .Create();

                        Console.WriteLine("Created second Batch Account:");
                        Utilities.PrintBatchAccount(batchAccount2);
                    }

                    // ============================================================
                    // List batch accounts

                    Console.WriteLine("Listing Batch accounts");

                    var accounts = azure.BatchAccounts.ListByGroup(rgName);
                    IBatchAccount ba;
                    foreach (var account in accounts)
                    {
                        Console.WriteLine("Batch Account - " + account.Name);
                    }

                    // ============================================================
                    // Refresh a batch account.
                    batchAccount.Refresh();
                    Utilities.PrintBatchAccount(batchAccount);

                    // ============================================================
                    // Delete a batch account

                    Console.WriteLine("Deleting a batch account - " + batchAccount.Name);

                    foreach (var applicationEntry in batchAccount.Applications)
                    {
                        foreach (var applicationPackageEntry in applicationEntry.Value.ApplicationPackages)
                        {
                            Console.WriteLine("Deleting a application package - " + applicationPackageEntry.Key);
                            applicationPackageEntry.Value.Delete();
                        }
                        Console.WriteLine("Deleting a application - " + applicationEntry.Key);
                        batchAccount.Update().WithoutApplication(applicationEntry.Key).Apply();
                    }

                    try
                    {
                        azure.BatchAccounts.DeleteById(batchAccount.Id);
                    }
                    catch
                    {
                    }

                    Console.WriteLine("Deleted batch account");

                    if (batchAccount2 != null)
                    {
                        Console.WriteLine("Deleting second batch account - " + batchAccount2.Name);
                        try
                        {
                            azure.BatchAccounts.DeleteById(batchAccount2.Id);
                        }
                        catch
                        {
                        }

                        Console.WriteLine("Deleted second batch account");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    try
                    {
                        Console.WriteLine("Deleting Resource Group: " + rgName);
                        azure.ResourceGroups.DeleteByName(rgName);
                        Console.WriteLine("Deleted Resource Group: " + rgName);
                    }
                    catch (Exception)
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