// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.LoadTesting.Tests
{
    public class LoadTestingManagementTestBase : ManagementRecordedTestBase<LoadTestingManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        public ResourceGroupCollection ResourceGroupsOperations { get; set; }

        public SubscriptionResource Subscription { get; set; }

        protected const string ResourceGroupNamePrefix = "LoadTestingRG";

        protected LoadTestingManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected LoadTestingManagementTestBase(bool isAsync)
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
        public static async Task TryRegisterResourceGroupAsync(ResourceGroupCollection resourceGroupsOperations, string location, string resourceGroupName)
        {
            await resourceGroupsOperations.CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, new ResourceGroupData(location));
        }
    }
}
