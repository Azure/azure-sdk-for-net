// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.ManagedServiceIdentities.Tests
{
    public class ManagedServiceIdentitiesManagementTestBase : ManagementRecordedTestBase<ManagedServiceIdentitiesManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected ManagedServiceIdentitiesManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected ManagedServiceIdentitiesManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        protected AzureLocation DefaultLocation => AzureLocation.EastUS;

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }
    }
}
