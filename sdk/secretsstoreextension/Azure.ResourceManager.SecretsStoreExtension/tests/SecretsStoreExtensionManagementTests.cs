// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.SecretsStoreExtension.Tests
{
    public class SecretsStoreExtensionManagementTests : SecretsStoreExtensionManagementTestBase
    {
        private SecretProviderClassTests _spct;
        private SecretSyncTests _sst;
        private ResourceGroupResource _rg;

        public SecretsStoreExtensionManagementTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await CreateCommonClient();
            }
            _rg = await GetResourceGroupResourceAsync();

            KeyVaultSecretProviderClassCollection akvspcc = _rg.GetKeyVaultSecretProviderClasses();
            _spct = new SecretProviderClassTests(Client, DefaultSubscription, _rg, akvspcc, TestEnvironment, Delay);

            SecretSyncCollection ssc = _rg.GetSecretSyncs();
            _sst = new SecretSyncTests(Client, DefaultSubscription, _rg, ssc, TestEnvironment, Delay);
        }

        [Test, Order(1000)]
        public async Task SpcTestCreate()
        {
            await _spct.TestCreateAsync();
        }

        [Test, Order(1100)]
        public async Task SpcTestUpdate()
        {
            await _spct.TestUpdateAsync();
        }

        [Test, Order(1200)]
        public async Task SpcTestTags()
        {
            await _spct.TestTagsAsync();
        }

        [Test, Order(1300)]
        public async Task SpcTestExtensions()
        {
            await _spct.TestExtensionsAsync();
        }

        [Test, Order(2000)]
        public async Task SsTestCreate()
        {
            await _sst.TestCreateAsync();
        }

        [Test, Order(2100)]
        public async Task SsTestUpdate()
        {
            await _sst.TestUpdateAsync();
        }

        [Test, Order(2200)]
        public async Task SsTestTags()
        {
            await _sst.TestTagsAsync();
        }

        [Test, Order(2300)]
        public async Task SsTestExtensions()
        {
            await _sst.TestExtensionsAsync();
        }

        [Test, Order(2400)]
        public async Task SsTestDelete()
        {
            await _sst.TestDeleteAsync();
        }

        [Test, Order(3000)]
        public async Task SpcTestDelete()
        {
            await _spct.TestDeleteAsync();
        }

        // Helper function returns the resource group which is used to manage the SPC and SS objects.
        private async Task<ResourceGroupResource> GetResourceGroupResourceAsync()
        {
            ResourceGroupCollection rgs = DefaultSubscription.GetResourceGroups();
            Response<ResourceGroupResource> rgrResponse = await rgs.GetAsync(TestEnvironment.ClusterResourceGroup);
            Assert.IsTrue(rgrResponse.HasValue);
            return rgrResponse.Value;
        }

        // Short delay to allow server-side resources to update.  Does nothing during playback.
        private async Task Delay(int seconds)
        {
            if (Mode != RecordedTestMode.Playback)
            {
                var t = TimeSpan.FromSeconds(seconds);
                await Task.Delay(t).ConfigureAwait(false);
            }
        }
    }
}
