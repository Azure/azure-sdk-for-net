// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.StorageMover.Tests
{
    public class StorageMoverManagementTestBase : ManagementRecordedTestBase<StorageMoverManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }

        protected StorageMoverManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected StorageMoverManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        // Existing resources required for tests as Agent cannot be created by RP
        protected readonly string ResourceGroupName = "teststomover";
        protected readonly string StorageMoverName = "testsm1";
        protected readonly string ProjectName = "testp1";
        protected readonly string AgentName = "testagent1";
        protected readonly string StorageAccountName = "testsomoveraccount";
        protected readonly string ContainerName = "testsmcontainer";
        protected readonly string NfsEndpointName = "testnfsendpoint";
        protected readonly string ContainerEndpointName = "testsmcontainerendpoint";
        protected readonly string AgentName2 = "testagent3";
        protected readonly string JobDefinitionName = "testjobdef2";
        protected readonly string ResourceGroupNamePrefix = "testsmrg-";
        protected readonly string StorageMoverPrefix = "testsm-";
        protected readonly string JobName = "6e8c0dfe-821a-427d-8d11-a9ed7f1c9c13";
        protected AzureLocation TestLocation = new("eastus");

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        public async Task<ResourceGroupResource> GetResourceGroupAsync(string resourceGroupName)
        {
            ResourceGroupResource resourceGroup = (await DefaultSubscription.GetResourceGroups().GetAsync(resourceGroupName)).Value;
            return resourceGroup;
        }
    }
}
