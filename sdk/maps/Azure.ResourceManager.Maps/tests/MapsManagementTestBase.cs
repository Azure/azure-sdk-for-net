// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Maps.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Maps.Tests
{
    public class MapsManagementTestBase : ManagementRecordedTestBase<MapsManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        public SubscriptionResource DefaultSubscription { get; private set; }

        public AzureLocation DefaultLocation => AzureLocation.EastUS;
        public const string ResourceGroupNamePrefix = "MapsRG";

        protected MapsManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected MapsManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            string rgName = Recording.GenerateAssetName(ResourceGroupNamePrefix);
            ResourceGroupData input = new ResourceGroupData(DefaultLocation);
            var lro = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected MapsAccountData GetDefaultMapsAccountData()
        {
            var account = new MapsAccountData(DefaultLocation, new MapsSku(Name.S0))
            {
                Tags = { { "key1", "value1" }, { "key2", "value2" } }
            };

            return account;
        }

        public void VerifyAccountProperties(MapsAccountData account, bool useDefaults, Name skuName)
        {
            Assert.NotNull(account.Id);
            Assert.NotNull(account.Location);
            Assert.NotNull(account.Name);

            Assert.NotNull(account.Sku);
            Assert.NotNull(account.Sku.Tier);

            if (useDefaults)
            {
                Assert.AreEqual(DefaultLocation, account.Location);
                Assert.AreEqual(Name.S0, account.Sku.Name);

                Assert.NotNull(account.Tags);
                Assert.NotNull(account.Properties.UniqueId);
                Assert.AreEqual(2, account.Tags.Count);
                Assert.AreEqual("value1", account.Tags["key1"]);
                Assert.AreEqual("value2", account.Tags["key2"]);
            }
            else
            {
                Assert.AreEqual(skuName, account.Sku.Name);
                Assert.AreEqual(DefaultLocation, account.Location);
            }
        }

        public async Task<string> CreateDefaultMapsAccount(MapsAccountCollection mapCollection, string rgname)
        {
            var accountName = Recording.GenerateAssetName("maps");
            var parameters = GetDefaultMapsAccountData();
            var newAccount = (await mapCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            VerifyAccountProperties(newAccount.Data, true, Name.S0);

            return accountName;
        }
    }
}
