// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;

namespace Azure.ResourceManager.OracleDatabase.Tests
{
    public class OracleDatabaseManagementTestBase : ManagementRecordedTestBase<OracleDatabaseManagementTestEnvironment>
    {
        protected const string SubnetIdFormat = "{0}/resourceGroups/{1}/providers/Microsoft.Network/virtualNetworks/{2}/subnets/{3}";
        protected const string VnetIdFormat = "{0}/resourceGroups/{1}/providers/Microsoft.Network/virtualNetworks/{2}";
        protected const string DefaultResourceGroupName = "NetSdkTestRg";
        protected const string DefaultVnetName = "NetSdkTestVnet";
        protected const string DefaultSubnetName = "delegated";

        protected static AzureLocation _location = AzureLocation.EastUS;

        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        protected ResourceGroupCollection ResourceGroupsOperations { get; set; }
        protected string SubscriptionId { get; set; }

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

        protected async Task<AutonomousDatabaseCollection> GetAutonomousDatabaseCollectionAsync(string resourceGroupName) {
            ResourceGroupResource rg = await GetResourceGroupResourceAsync(resourceGroupName);
            return rg.GetAutonomousDatabases();
        }
    }
}