// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.SpringAppDiscovery.Tests
{
    public class SpringAppDiscoveryManagementTestBase : ManagementRecordedTestBase<SpringAppDiscoveryManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource Subscription { get; private set; }

        protected SpringAppDiscoveryManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected SpringAppDiscoveryManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            Subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        public async Task<ResourceGroupResource> GetResourceGroupAsync(string name)
        {
            return await Subscription.GetResourceGroups().GetAsync(name);
        }

        protected async Task<SpringbootsitesModelCollection> GetSpringbootsitesModelCollectionAsync(string resourceGroupName)
        {
            ResourceGroupResource rg = await GetResourceGroupAsync(resourceGroupName);
            return rg.GetSpringbootsitesModels();
        }

        protected async Task<SpringbootsitesModelResource> GetSpringsiteModelResource(string resourceGroupName, string siteName)
        {
            ResourceGroupResource rg = await GetResourceGroupAsync(resourceGroupName);
            return await GetSpringbootsitesModelCollectionAsync(resourceGroupName).Result.GetAsync(siteName);
        }
    }
}
