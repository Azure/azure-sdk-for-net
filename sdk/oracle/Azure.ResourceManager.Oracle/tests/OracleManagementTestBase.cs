// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Azure.ResourceManager.Oracle.Models;
namespace Azure.ResourceManager.Oracle.Tests
{
    public class OracleManagementTestBase :ManagementRecordedTestBase<OracleManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        public ResourceGroupCollection ResourceGroupsOperations { get; set; }
        public string SubscriptionId { get; set; }
        protected OracleManagementTestBase(bool isAsync, RecordedTestMode
        mode): base(isAsync, mode)
        {
        }
        protected OracleManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await
            Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            ResourceGroupsOperations = DefaultSubscription.GetResourceGroups();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix,
        AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await
            subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed,
            rgName, input);
            return lro.Value;
        }

        public async Task<ResourceGroupResource> GetResourceGroupResourceAsync(String name) {
            return await DefaultSubscription.GetResourceGroups().GetAsync(name);
        }

        protected async Task<CloudExadataInfrastructureCollection> GetCloudExadataInfrastructureCollectionAsync(String resourceGroupName) {
            ResourceGroupResource rg = await
            GetResourceGroupResourceAsync(resourceGroupName);
            return rg.GetCloudExadataInfrastructures();
        }

        protected static CloudExadataInfrastructureData GetDefaultCloudExadataInfrastructureData() {
            return new CloudExadataInfrastructureData(AzureLocation.EastUS, new
            List<string>{ "2" }) {
            ComputeCount = 2,
            StorageCount = 3,
            Shape = "Exadata.X9M",
            DisplayName = "OFake_SdkExadata_test_1"
            };
        }
    }
}