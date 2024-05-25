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
using Azure.ResourceManager.OracleDatabase.Models;
namespace Azure.ResourceManager.OracleDatabase.Tests
{
    public class OracleDatabaseManagementTestBase : ManagementRecordedTestBase<OracleDatabaseManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        public SubscriptionResource DefaultSubscription { get; private set; }
        public ResourceGroupCollection ResourceGroupsOperations { get; set; }
        public string SubscriptionId { get; set; }
        protected OracleDatabaseManagementTestBase(bool isAsync, RecordedTestMode
        mode): base(isAsync, mode)
        {
        }
        protected OracleDatabaseManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Console.WriteLine("HERE: CreateCommonClient");
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            ResourceGroupsOperations = DefaultSubscription.GetResourceGroups();
        }

        public static async Task TryRegisterResourceGroupAsync(ResourceGroupCollection resourceGroupsOperations, string location, string resourceGroupName)
        {
            await resourceGroupsOperations.CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, new ResourceGroupData(location));
        }

        public async Task<ResourceGroupResource> GetResourceGroupResourceAsync(string name) {
            return await DefaultSubscription.GetResourceGroups().GetAsync(name);
        }

        protected async Task<CloudExadataInfrastructureCollection> GetCloudExadataInfrastructureCollectionAsync(string resourceGroupName) {
            ResourceGroupResource rg = await GetResourceGroupResourceAsync(resourceGroupName);
            return rg.GetCloudExadataInfrastructures();
        }

        protected async Task<CloudVmClusterCollection> GetCloudVmClusterCollectionAsync(string resourceGroupName) {
            ResourceGroupResource rg = await GetResourceGroupResourceAsync(resourceGroupName);
            return rg.GetCloudVmClusters();
        }

        protected static CloudExadataInfrastructureData GetDefaultCloudExadataInfrastructureData(string exaInfraName) {
            return new CloudExadataInfrastructureData(AzureLocation.EastUS, new
            List<string>{ "2" }) {
                ComputeCount = 2,
                StorageCount = 3,
                Shape = "Exadata.X9M",
                DisplayName = exaInfraName
            };
        }
    }
}