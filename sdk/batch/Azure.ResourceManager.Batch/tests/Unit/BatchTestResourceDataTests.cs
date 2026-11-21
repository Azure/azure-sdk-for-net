// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.Batch.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Batch.Tests
{
    public class BatchTestResourceDataTests
    {
        [TestCase("eastus")]
        [TestCase("southcentralus")]
        [TestCase("westus2")]
        public void BatchAccountUsesConfiguredLocation(string region)
        {
            var location = new AzureLocation(region);
            var storageId = new ResourceIdentifier("/subscriptions/12345678-1234-1234-1234-123456789012/resourceGroups/test/providers/Microsoft.Storage/storageAccounts/test");

            var account = ResourceDataHelper.GetBatchAccountData(storageId, location);

            Assert.That(account.Location, Is.EqualTo(location));
            Assert.That(account.AutoStorage.StorageAccountId, Is.EqualTo(storageId));
        }

        [TestCase("eastus")]
        [TestCase("southcentralus")]
        [TestCase("westus2")]
        public void StorageAccountUsesConfiguredLocation(string region)
        {
            var location = new AzureLocation(region);

            var storage = ResourceDataHelper.GetStorageAccountData(location);

            Assert.That(storage.Location, Is.EqualTo(location));
        }
    }
}
