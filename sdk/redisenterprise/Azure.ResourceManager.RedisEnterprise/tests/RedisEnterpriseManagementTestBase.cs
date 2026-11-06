// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.RedisEnterprise.Tests
{
    public class RedisEnterpriseManagementTestBase : ManagementRecordedTestBase<RedisEnterpriseManagementTestEnvironment>
    {
        protected AzureLocation DefaultLocation => new("eastus2euap");

        protected ArmClient Client { get; private set; }

        protected SubscriptionResource DefaultSubscription { get; private set; }

        protected RedisEnterpriseManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected RedisEnterpriseManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = Client.GetSubscriptionResource(
                new ResourceIdentifier($"/subscriptions/{TestEnvironment.SubscriptionId}"));
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync(AzureLocation? location = null)
        {
            var resourceGroupName = Recording.GenerateAssetName("testRG-");
            var rgOp = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceGroupName,
                new ResourceGroupData(location ?? DefaultLocation)
                {
                    Tags =
                    {
                        { "test", "env" }
                    }
                });
            return rgOp.Value;
        }
    }
}
