// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

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
        protected readonly string StorageAccountName = "testsmstore24";
        protected readonly string ContainerName = "testsmcontainer";
        protected readonly string NfsEndpointName = "testnfsendpoint";
        protected readonly string ContainerEndpointName = "testsmcontainerendpoint";
        protected readonly string AgentName2 = "testagent3";
        protected readonly string JobDefinitionName = "testjobdef2";
        protected readonly string ResourceGroupNamePrefix = "testsmrg-";
        protected readonly string StorageMoverPrefix = "testsm-";
        protected readonly string JobName = "6e8c0dfe-821a-427d-8d11-a9ed7f1c9c13";
        protected readonly string MultiCloudConnectorId = "/subscriptions/b6b34ad8-ca89-4f85-beb7-c2ec13702dac/resourceGroups/E2E-Management-RGsyn/providers/Microsoft.HybridConnectivity/publicCloudConnectors/e2e-sm-rp-connector";
        protected readonly string AwsS3BucketId = "/subscriptions/b6b34ad8-ca89-4f85-beb7-c2ec13702dac/resourceGroups/aws_640698235822/providers/Microsoft.AWSConnector/s3Buckets/e2e-sm-rp-bucket";
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
