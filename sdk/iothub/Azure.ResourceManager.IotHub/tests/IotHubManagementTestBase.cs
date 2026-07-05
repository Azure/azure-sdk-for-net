// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.IotHub.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.IotHub.Tests
{
    public class IotHubManagementTestBase : ManagementRecordedTestBase<IotHubManagementTestEnvironment>
    {
        private const string RecordedApiVersion = "2021-07-02";

        protected ArmClient Client { get; private set; }

        protected IotHubManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected IotHubManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient(CreateRecordedClientOptions());
        }

        private static ArmClientOptions CreateRecordedClientOptions()
        {
            ArmClientOptions options = new ArmClientOptions();
            options.SetApiVersion(IotHubDescriptionResource.ResourceType, RecordedApiVersion);
            options.SetApiVersion(IotHubCertificateDescriptionResource.ResourceType, RecordedApiVersion);
            options.SetApiVersion(EventHubConsumerGroupInfoResource.ResourceType, RecordedApiVersion);
            options.SetApiVersion(IotHubPrivateEndpointConnectionResource.ResourceType, RecordedApiVersion);
            options.SetApiVersion(IotHubPrivateEndpointGroupInformationResource.ResourceType, RecordedApiVersion);
            return options;
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<IotHubDescriptionResource> CreateIotHub(ResourceGroupResource resourceGroup, string iotHubName)
        {
            var sku = new IotHubSkuInfo("S1")
            {
                Name = "S1",
                Capacity = 1
            };
            IotHubDescriptionData data = new IotHubDescriptionData(resourceGroup.Data.Location, sku) { };
            var iotHub = await resourceGroup.GetIotHubDescriptions().CreateOrUpdateAsync(WaitUntil.Completed, iotHubName, data);
            return iotHub.Value;
        }
    }
}
