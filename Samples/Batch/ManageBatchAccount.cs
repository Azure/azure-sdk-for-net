// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Batch.Fluent.Models;
using Microsoft.Azure.Management.Batch.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Linq;
using Microsoft.Azure.Management.ResourceManager.Fluent;

namespace ManageBatchAccount
{
    public class Program
    {
        private const string AppName = "application";
        private const string AppDisplayName = "My application display name";
        private const string AppPackageName = "app_package";
        private static readonly Region Region = Region.AustraliaSouthEast;
        private static readonly Region Region2 = Region.USCentral;


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
        public static void RunSample(IAzure azure)
        {
            string batchAccountName = Utilities.CreateRandomName("ba");
            string storageAccountName = Utilities.CreateRandomName("sa");
            string batchAccountName2 = Utilities.CreateRandomName("ba2");
            string rgName = Utilities.CreateRandomName("rgBAMB");

            try
            {
                // ===========================================================
                // Get how many batch accounts can be created in specified region.

                int allowedNumberOfBatchAccounts = azure.BatchAccounts.GetBatchAccountQuotaByLocation(Region);

                // ===========================================================
                // List all the batch accounts in subscription.

                var batchAccounts = azure.BatchAccounts.List();
                int batchAccountsAtSpecificRegion = batchAccounts.Count(x => x.Region == Region);

                if (batchAccountsAtSpecificRegion >= allowedNumberOfBatchAccounts)
                {
                    Utilities.Log("No more batch accounts can be created at "
                            + Region + " region, this region already have "
                            + batchAccountsAtSpecificRegion
                            + " batch accounts, current quota to create batch account in "
                            + Region + " region is " + allowedNumberOfBatchAccounts + ".");
                    return;
                }

                // ============================================================
                // Create a batch account

                Utilities.Log("Creating a batch Account");

                var batchAccount = azure.BatchAccounts.Define(batchAccountName)
                        .WithRegion(Region)
                        .WithNewResourceGroup(rgName)
                            .DefineNewApplication(AppName)
                                .DefineNewApplicationPackage(AppPackageName)
                            .WithAllowUpdates(true)
                            .WithDisplayName(AppDisplayName)
                            .Attach()
                        .WithNewStorageAccount(storageAccountName)
                        .Create();

                Utilities.Log("Created a batch Account:");
                Utilities.PrintBatchAccount(batchAccount);

                // ============================================================
                // Get | regenerate batch account access keys

                Utilities.Log("Getting batch account access keys");

                var batchAccountKeys = batchAccount.GetKeys();

                Utilities.PrintBatchAccountKey(batchAccountKeys);

                Utilities.Log("Regenerating primary batch account primary access key");

                batchAccountKeys = batchAccount.RegenerateKeys(AccountKeyType.Primary);

                Utilities.PrintBatchAccountKey(batchAccountKeys);

                // ============================================================
                // Regenerate the keys for storage account
                var storageAccount = azure.StorageAccounts.GetByResourceGroup(rgName, storageAccountName);
                var storageAccountKeys = storageAccount.GetKeys();

                Utilities.PrintStorageAccountKeys(storageAccountKeys);

                Utilities.Log("Regenerating first storage account access key");

                storageAccountKeys = storageAccount.RegenerateKey(storageAccountKeys[0].KeyName);

                Utilities.PrintStorageAccountKeys(storageAccountKeys);

                // ============================================================
                // Synchronize storage account keys with batch account

                batchAccount.SynchronizeAutoStorageKeys();

                // ============================================================
                // Update name of application.
                batchAccount
                    .Update()
                        .UpdateApplication(AppName)
                        .WithDisplayName("New application display name")
                        .Parent()
                    .Apply();

                batchAccount.Refresh();
                Utilities.PrintBatchAccount(batchAccount);

                // ============================================================
                // Create another batch account

                Utilities.Log("Creating another Batch Account");

                allowedNumberOfBatchAccounts = azure.BatchAccounts.GetBatchAccountQuotaByLocation(Region2);

                // ===========================================================
                // List all the batch accounts in subscription.

                batchAccounts = azure.BatchAccounts.List();
                batchAccountsAtSpecificRegion = batchAccounts.Count(x => x.Region == Region2);

                IBatchAccount batchAccount2 = null;
                if (batchAccountsAtSpecificRegion < allowedNumberOfBatchAccounts)
                {
                    batchAccount2 = azure.BatchAccounts.Define(batchAccountName2)
                            .WithRegion(Region2)
                            .WithExistingResourceGroup(rgName)
                            .WithExistingStorageAccount(storageAccount)
                            .Create();

                    Utilities.Log("Created second Batch Account:");
                    Utilities.PrintBatchAccount(batchAccount2);
                }

                // ============================================================
                // List batch accounts

                Utilities.Log("Listing Batch accounts");

                var accounts = azure.BatchAccounts.ListByResourceGroup(rgName);
                foreach (var account in accounts)
                {
                    Utilities.Log("Batch Account - " + account.Name);
                }

                // ============================================================
                // Refresh a batch account.
                batchAccount.Refresh();
                Utilities.PrintBatchAccount(batchAccount);

                // ============================================================
                // Delete a batch account

                Utilities.Log("Deleting a batch account - " + batchAccount.Name);

                foreach (var applicationEntry in batchAccount.Applications)
                {
                    foreach (var applicationPackageEntry in applicationEntry.Value.ApplicationPackages)
                    {
                        Utilities.Log("Deleting a application package - " + applicationPackageEntry.Key);
                        applicationPackageEntry.Value.Delete();
                    }
                    Utilities.Log("Deleting a application - " + applicationEntry.Key);
                    batchAccount.Update().WithoutApplication(applicationEntry.Key).Apply();
                }

                try
                {
                    azure.BatchAccounts.DeleteById(batchAccount.Id);
                }
                catch
                {
                }

                Utilities.Log("Deleted batch account");

                if (batchAccount2 != null)
                {
                    Utilities.Log("Deleting second batch account - " + batchAccount2.Name);
                    try
                    {
                        azure.BatchAccounts.DeleteById(batchAccount2.Id);
                    }
                    catch
                    {
                    }

                    Utilities.Log("Deleted second batch account");
                }
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.DeleteByName(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
                }
                catch (Exception)
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
                AzureCredentials credentials = SdkContext.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                // Print selected subscription
                Utilities.Log("Selected subscription: " + azure.SubscriptionId);

                RunSample(azure);
            }
            catch (Exception ex)
            {
                Utilities.Log(ex);
            }
        }
    }
}