// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Snippets extracted from articles/batch/batch-management-dotnet.md.

using System;
using System.Linq;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Batch;
using Azure.ResourceManager.Batch.Models;
using Azure.ResourceManager.Resources;

namespace BatchDocSamples;

internal static class BatchManagement
{
    public static void CreateBatchAccount()
    {
        #region Snippet:mgmt_create_account
         string subscriptionId = "Your SubscriptionID";
         string resourceGroupName = "Your ResourceGroup name";

         var credential = new DefaultAzureCredential();
         ArmClient _armClient = new ArmClient(credential);

         ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
         ResourceGroupResource resourceGroupResource = _armClient.GetResourceGroupResource(resourceGroupResourceId);

         var data = new BatchAccountCreateOrUpdateContent(AzureLocation.EastUS);

         // Create a new batch account
         resourceGroupResource.GetBatchAccounts().CreateOrUpdate(WaitUntil.Completed, "Your BatchAccount name", data);

         // Get an existing batch account
         BatchAccountResource batchAccount = resourceGroupResource.GetBatchAccount("Your BatchAccount name");

         // Delete the batch account
         batchAccount.Delete(WaitUntil.Completed);
        #endregion
    }

    public static void RegenerateAccountKeys()
    {
        #region Snippet:mgmt_account_keys
        string subscriptionId = "Your SubscriptionID";
        string resourceGroupName = "Your ResourceGroup name";

        var credential = new DefaultAzureCredential();
        ArmClient _armClient = new ArmClient(credential);

        ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
        ResourceGroupResource resourceGroupResource = _armClient.GetResourceGroupResource(resourceGroupResourceId);

        // Get an existing batch account
        BatchAccountResource batchAccount = resourceGroupResource.GetBatchAccount("Your BatchAccount name");

        // Get and print the primary and secondary keys
        BatchAccountKeys accountKeys = batchAccount.GetKeys();

        Console.WriteLine("Primary key:   {0}", accountKeys.Primary);
        Console.WriteLine("Secondary key: {0}", accountKeys.Secondary);

        // Regenerate the primary key
        BatchAccountRegenerateKeyContent regenerateKeyContent = new BatchAccountRegenerateKeyContent(BatchAccountKeyType.Primary);
        batchAccount.RegenerateKey(regenerateKeyContent);
        #endregion
    }

    public static void QueryAccountQuotas()
    {
        #region Snippet:mgmt_account_quotas
        string subscriptionId = "Your SubscriptionID";
        ArmClient _armClient = new ArmClient(new DefaultAzureCredential());

        ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
        SubscriptionResource subscriptionResource = _armClient.GetSubscriptionResource(subscriptionResourceId);

        // Get a collection of all Batch accounts within the subscription
        var batchAccounts = subscriptionResource.GetBatchAccounts();
        Console.WriteLine("Total number of Batch accounts under subscription id {0}:  {1}", subscriptionId, batchAccounts.Count());

        // Get a count of all accounts within the target region
        string region = "eastus";
        int accountsInRegion = batchAccounts.Count(o => o.Data.Location == region);

        // Get the account quota for the specified region
        BatchLocationQuota batchLocationQuota = subscriptionResource.GetBatchQuotas(AzureLocation.EastUS);
        Console.WriteLine("Account quota for {0} region: {1}", region, batchLocationQuota.AccountQuota);

        // Determine how many accounts can be created in the target region
        Console.WriteLine("Accounts in {0}: {1}", region, accountsInRegion);
        Console.WriteLine("You can create {0} accounts in the {1} region.", batchLocationQuota.AccountQuota - accountsInRegion, region);
        #endregion
    }

    public static void QueryComputeQuotas()
    {
        #region Snippet:mgmt_compute_quotas
        string subscriptionId = "Your SubscriptionID";
        string resourceGroupName = "Your ResourceGroup name";

        var credential = new DefaultAzureCredential();
        ArmClient _armClient = new ArmClient(credential);

        ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
        ResourceGroupResource resourceGroupResource = _armClient.GetResourceGroupResource(resourceGroupResourceId);

        // Get an existing batch account
        BatchAccountResource batchAccount = resourceGroupResource.GetBatchAccount("Your BatchAccount name");

        // Now print the compute resource quotas for the account
        Console.WriteLine("Core quota: {0}", batchAccount.Data.DedicatedCoreQuota);
        Console.WriteLine("Pool quota: {0}", batchAccount.Data.PoolQuota);
        Console.WriteLine("Active job and job schedule quota: {0}", batchAccount.Data.ActiveJobAndJobScheduleQuota);
        #endregion
    }
}
