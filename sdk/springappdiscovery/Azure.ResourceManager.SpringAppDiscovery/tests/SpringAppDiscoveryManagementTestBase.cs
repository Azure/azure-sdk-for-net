// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.SpringAppDiscovery.Tests
{
    public class SpringAppDiscoveryManagementTestBase : ManagementRecordedTestBase<SpringAppDiscoveryManagementTestEnvironment>
    {
        public static string subId = "baa34aed-361d-43b0-8a60-3322d255ff8e";

        public static string rgName = "rg-test";

        public static string siteName = "site-test";

        public static string serverName = "server-test";

        public static string appName = "app-test";

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

        protected async Task<SpringBootSiteCollection> GetSpringbootsitesModelCollectionAsync(string resourceGroupName)
        {
            ResourceGroupResource rg = await GetResourceGroupAsync(resourceGroupName);
            return rg.GetSpringBootSites();
        }

        protected async Task<SpringBootSiteResource> GetSpringsiteModelResource(string resourceGroupName, string siteName)
        {
            ResourceGroupResource rg = await GetResourceGroupAsync(resourceGroupName);
            return await GetSpringbootsitesModelCollectionAsync(resourceGroupName).Result.GetAsync(siteName);
        }
    }
}
