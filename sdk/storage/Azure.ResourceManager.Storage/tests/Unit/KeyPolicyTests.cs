// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Storage.Tests.Unit
{
    public class KeyPolicyTests
    {
        [Test]
        public void ValidateStorageAccountData()
        {
            var data = new StorageAccountData(AzureLocation.AustraliaCentral);
            Assert.IsNull(data.KeyPolicy);
            Assert.IsNull(data.KeyExpirationPeriodInDays);

            Assert.IsFalse(data.GetType().GetProperty("KeyExpirationPeriodInDays").CanWrite);

            data = new StorageAccountData(
                null,
                null,
                new ResourceType("Microsoft.Storage/storageAccounts"),
                null,
                new Dictionary<string, string>(),
                AzureLocation.AustraliaCentral,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                new KeyPolicy(5),
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                new List<StoragePrivateEndpointConnectionData>(),
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null);

            Assert.IsNotNull(data.KeyPolicy);
            Assert.AreEqual(5, data.KeyExpirationPeriodInDays);
        }

        [Test]
        public void ValidateStorageAccountCreateOrUpdateContent()
        {
            var data = new StorageAccountCreateOrUpdateContent(new StorageSku(StorageSkuName.StandardGRS), StorageKind.Storage, AzureLocation.AustraliaCentral);
            Assert.IsNull(data.KeyPolicy);
            Assert.IsNull(data.KeyExpirationPeriodInDays);

            data.KeyExpirationPeriodInDays = 5;

            Assert.IsNotNull(data.KeyPolicy);
            Assert.AreEqual(5, data.KeyExpirationPeriodInDays);

            data.KeyExpirationPeriodInDays = null;

            Assert.IsNull(data.KeyPolicy);
            Assert.IsNull(data.KeyExpirationPeriodInDays);
        }

        [Test]
        public void ValidateStorageAccountPatch()
        {
            var data = new StorageAccountPatch();
            Assert.IsNull(data.KeyPolicy);
            Assert.IsNull(data.KeyExpirationPeriodInDays);

            data.KeyExpirationPeriodInDays = 5;

            Assert.IsNotNull(data.KeyPolicy);
            Assert.AreEqual(5, data.KeyExpirationPeriodInDays);

            data.KeyExpirationPeriodInDays = null;

            Assert.IsNull(data.KeyPolicy);
            Assert.IsNull(data.KeyExpirationPeriodInDays);
        }
    }
}
