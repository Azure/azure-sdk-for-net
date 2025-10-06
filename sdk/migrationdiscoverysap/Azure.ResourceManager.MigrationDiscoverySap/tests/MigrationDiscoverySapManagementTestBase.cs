// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using Azure.Storage.Blobs;
using NUnit.Framework;
using System.IO;
using System;
using System.Threading.Tasks;

namespace Azure.ResourceManager.MigrationDiscoverySap.Tests
{
    public class MigrationDiscoverySapManagementTestBase
        : ManagementRecordedTestBase<MigrationDiscoverySapManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }

        protected MigrationDiscoverySapManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected MigrationDiscoverySapManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(
            SubscriptionResource subscription,
            string rgNamePrefix,
            AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            var input = new ResourceGroupData(location);
            ArmOperation<ResourceGroupResource> lro =
                await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }
    }
}
