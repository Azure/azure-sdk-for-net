// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.RecoveryServices;
using Azure.ResourceManager.RecoveryServices.Models;
using Azure.ResourceManager.RecoveryServicesBackup.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.RecoveryServicesBackup.Tests
{
    public class ProtectedBackupItemsTests : RecoveryServicesBackupManagementTestBase
    {
        public ProtectedBackupItemsTests(bool isAsync) :
            base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        public async Task ListBackupProtectedItems()
        {
            var sub = await Client.GetDefaultSubscriptionAsync();
            var rg = await CreateResourceGroup(sub, "sdktest", AzureLocation.EastUS);
            var resourceGroup = Client.GetResourceGroupResource(new ResourceIdentifier("/subscriptions/4d042dc6-fe17-4698-a23f-ec6a8d1e98f4/resourceGroups/deleteme1218"));
            var backupProtectedItems = resourceGroup.GetBackupProtectedItemsAsync("vaulttest001");
            await foreach (var backupProtectedItem in backupProtectedItems)
            {//test normal and stop backup
                Console.WriteLine(backupProtectedItem.Data.Name);
            }
        }
    }
}
