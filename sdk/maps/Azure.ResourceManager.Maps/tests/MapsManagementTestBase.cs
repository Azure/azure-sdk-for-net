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
            var account = new MapsAccountData(DefaultLocation, new MapsSku(MapsSkuName.G2))
            {
                Tags = { { "key1", "value1" }, { "key2", "value2" } }
            };

            return account;
        }

        public void VerifyAccountProperties(MapsAccountData account, bool useDefaults, MapsSkuName skuName, string location = "East US")
        {
            Assert.That(account.Id, Is.Not.Null);
            Assert.That(account.Location, Is.Not.Null);
            Assert.That(account.Name, Is.Not.Null);

            Assert.That(account.Sku, Is.Not.Null);
            Assert.That(account.Sku.Tier, Is.Not.Null);

            if (useDefaults)
            {
                Assert.That(account.Location.DisplayName, Is.EqualTo("East US"));
                Assert.That(account.Sku.Name, Is.EqualTo(MapsSkuName.G2));

                Assert.That(account.Tags, Is.Not.Null);
                Assert.That(account.Properties.UniqueId, Is.Not.Null);
                Assert.That(account.Tags.Count, Is.EqualTo(2));
                Assert.That(account.Tags["key1"], Is.EqualTo("value1"));
                Assert.That(account.Tags["key2"], Is.EqualTo("value2"));
            }
            else
            {
                Assert.That(account.Sku.Name, Is.EqualTo(skuName));
                Assert.That(account.Location.DisplayName, Is.EqualTo(location));
            }
        }

        public async Task<MapsAccountResource> CreateDefaultMapsAccount(MapsAccountCollection mapCollection)
        {
            var accountName = Recording.GenerateAssetName("maps");
            var parameters = GetDefaultMapsAccountData();
            var newAccount = (await mapCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            VerifyAccountProperties(newAccount.Data, true, MapsSkuName.G2);
            return newAccount;
        }
    }
}
