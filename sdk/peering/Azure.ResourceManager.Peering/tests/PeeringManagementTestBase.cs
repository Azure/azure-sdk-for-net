// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Peering.Tests
{
    public class PeeringManagementTestBase : ManagementRecordedTestBase<PeeringManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected const string DefaultResourceGroupPrefix = "PeeringRG";
        protected AzureLocation DefaultLocation = AzureLocation.EastUS;

        protected PeeringManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected PeeringManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup()
        {
            var subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName(DefaultResourceGroupPrefix);
            ResourceGroupData input = new ResourceGroupData(DefaultLocation);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }
    }
}
