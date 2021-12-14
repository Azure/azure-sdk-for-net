// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class ComputeTestBase : ManagementRecordedTestBase<ComputeTestEnvironment>
    {
        protected Location DefaultLocation => Location.WestUS2;
        protected ArmClient Client { get; private set; }
        protected Subscription DefaultSubscription { get; private set; }
        public ComputeTestBase(bool isAsync) : base(isAsync, useLegacyTransport: true)
        {
        }

        public ComputeTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode, useLegacyTransport: true)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task<ResourceGroup> CreateResourceGroupAsync()
        {
            var resourceGroupName = Recording.GenerateAssetName("testRG-");
            var rgOp = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
                resourceGroupName,
                new ResourceGroupData(DefaultLocation)
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
