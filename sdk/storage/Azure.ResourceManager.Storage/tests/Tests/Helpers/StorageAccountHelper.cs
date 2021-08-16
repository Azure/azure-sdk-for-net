// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using System.Collections.Generic;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;
using Sku = Azure.ResourceManager.Storage.Models.Sku;

namespace Azure.ResourceManager.Storage.Tests.Tests.Helpers
{
    public class StorageAccountHelper
    {
        protected static Location DefaultLocation => Location.EastUS2;
        public static string DefaultLocationString = "eastus2";
        public static bool IsTestTenant = false;
        // These are used to create default accounts
        public static Sku DefaultSkuNameStandardGRS = new Sku(SkuName.StandardGRS);
        public static Kind DefaultKindStorage = Kind.Storage;
        public static void VerifyAccountProperties(StorageAccount account, bool useDefaults)
        {
            Assert.NotNull(account);
            Assert.NotNull(account.Id);
            Assert.NotNull(account.Id.Name);
            Assert.NotNull(account.Data.Location);
            Assert.NotNull(account.Data);
            Assert.NotNull(account.Data.CreationTime);
            Assert.NotNull(account.Data.Sku);
            Assert.NotNull(account.Data.Sku.Name);
            Assert.NotNull(account.Data.Sku.Tier);
            Assert.NotNull(account.Data.PrimaryEndpoints);

            if (useDefaults)
            {
                Assert.AreEqual(DefaultLocation, account.Data.Location);
                Assert.AreEqual(DefaultSkuNameStandardGRS.Name, account.Data.Sku.Name);
                Assert.AreEqual(SkuTier.Standard, account.Data.Sku.Tier);
                Assert.AreEqual(DefaultKindStorage, account.Data.Kind);

                Assert.NotNull(account.Data.Tags);
                Assert.AreEqual(2, account.Data.Tags.Count);
                Assert.AreEqual("value1", account.Data.Tags["key1"]);
                Assert.AreEqual("value2", account.Data.Tags["key2"]);
            }
        }
        public static void AssertStorageAccountEqual(StorageAccount account1, StorageAccount account2)
        {
            Assert.AreEqual(account1.Id.Name, account2.Id.Name);
            Assert.AreEqual(account1.Id.Location, account2.Id.Location);
        }
    }
}
