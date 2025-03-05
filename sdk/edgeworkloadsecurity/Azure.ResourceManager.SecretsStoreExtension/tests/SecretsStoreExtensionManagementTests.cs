// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.SecretsStoreExtension.Tests
{
    public class SecretsStoreExtensionManagementTests : SecretsStoreExtensionManagementTestBase
    {
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
        }

        [Test]
        // Create, view, update, tag, and delete the SPC via the C# APIs.
        public async Task TestSecretProviderClassCrud()
        {
            ResourceGroupResource rg = await GetResourceGroupResourceAsync();
            var spct = new SecretProviderClassTests(Client, DefaultSubscription, rg, TestEnvironment);

            await spct.DoSecretProviderClassTestAsync();
        }

        [Test]
        // Create, view, update, tag, and delete the SecretSync via the C# APIs.
        public async Task TestSecretSyncCrud()
        {
            ResourceGroupResource rg = await GetResourceGroupResourceAsync();
            var spct = new SecretProviderClassTests(Client, DefaultSubscription, rg, TestEnvironment);
            var sst = new SecretSyncTests(Client, DefaultSubscription, rg, TestEnvironment);

            await sst.DoTestSecretSyncCrudAsync(spct.DoSecretProviderClassTestAsync);
        }

        // Helper function returns the resource group which is used to manage the SPC and SS objects.
        private async Task<ResourceGroupResource> GetResourceGroupResourceAsync()
        {
            ResourceGroupCollection rgs = DefaultSubscription.GetResourceGroups();
            Response<ResourceGroupResource> rgrResponse = await rgs.GetAsync(TestEnvironment.ClusterResourceGroup);
            Assert.IsTrue(rgrResponse.HasValue);
            return rgrResponse.Value;
        }
    }
}
