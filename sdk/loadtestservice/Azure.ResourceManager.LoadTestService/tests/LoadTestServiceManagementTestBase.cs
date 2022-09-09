// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.LoadTestService.Tests
{
    public class LoadTestServiceManagementTestBase : ManagementRecordedTestBase<LoadTestServiceManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        public string SubscriptionId { get; set; }
        public ResourceGroupCollection ResourceGroupsOperations { get; set; }
        public SubscriptionResource Subscription { get; set; }

        protected const string ResourceGroupNamePrefix = "LoadTestServiceRG";

        protected LoadTestServiceManagementTestBase(bool isAsync, RecordedTestMode mode)
            : base(isAsync, mode)
        {
        }

        protected LoadTestServiceManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            Subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupsOperations = Subscription.GetResourceGroups();
        }

        public async Task<ResourceGroupResource> GetResourceGroupAsync(string name)
        {
            return await Subscription.GetResourceGroups().GetAsync(name);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(AzureLocation location)
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName(ResourceGroupNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<LoadTestResource> CreateLoadTestResource(ResourceGroupResource resourceGroup, string loadTestResourceName)
        {
            LoadTestResourceData data = new LoadTestResourceData(resourceGroup.Data.Location);
            // TODO: Add LoadTest Resource properties in the creationRequest
            ArmOperation<LoadTestResource> loadTestServiceResource = await resourceGroup.GetLoadTestResources().CreateOrUpdateAsync(WaitUntil.Completed, loadTestResourceName, data);
            return loadTestServiceResource.Value;
        }

        protected LoadTestResourceCollection CreateLoadTestCollection(ResourceGroupResource resourceGroup, string loadTestResourceName)
        {
            LoadTestResourceCollection loadTestServiceResourceCollection = resourceGroup.GetLoadTestResources();
            return loadTestServiceResourceCollection;
        }
    }
}
