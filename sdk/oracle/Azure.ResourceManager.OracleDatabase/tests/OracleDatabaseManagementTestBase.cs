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
        protected const string DefaultResourceGroupName = "Netsdk";
        protected const string DefaultVnetName = "netsdk";
        protected const string DefaultSubnetName = "delegated";
        protected const string DefaultZone = "2";
        protected const string DefaultSSHKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQDAIdCVcZiGBSybKTvFBfrfVhYWRImneQB9ovsU/GYqPLyDpXkpdGusYc5OL6zHq27uKtJ+//0wCoENJmvBjiRMUWMKZ4NcUkxVWj+ipJTFDO1t3KRkpDCLQEBEihOaNHHN9j2ZggUxOQBgCIwjjH+B+6Z1KpvpmvDhbMhmmZJ6R4yJI+fE80SFCV0G5sZuq38W+eK6FQRNINCmayWLNYw8sk1cBzqxMTo7OeVRxjyfQYRS1o+sC1CkxT7BYw30qY/xzR45yxkRZ5FkugPR5MQ1NApRPGNOuZD1MRwcG1AZ5JfiX9ckz5xaKjfm0hhfwh/qT7mH6fXiX7nAmkvLxu6Xnzy3aign4e99QSWPkpjJ0X1gluLzR7/gwYMjA6sfflRNe/FP937kJTIa1F5BonWe9eS580IXoTUNaiAanOEf5fBdji4JEDk7nXKV7kTECkCX9ZDWwB8q/ayIXwmNMCgxCpdx2F6UWOGvF5UWJkyD3BxTgMOiPwxMMEvCGIIdaGU= generated-by-azure";

        protected static AzureLocation _location = AzureLocation.EastUS;

        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        protected ResourceGroupCollection ResourceGroupsOperations { get; set; }
        protected string SubscriptionId { get; set; }

        protected OracleDatabaseManagementTestBase(bool isAsync, RecordedTestMode
        mode) : base(isAsync, mode)
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
        public async Task<ResourceGroupResource> GetResourceGroupResourceAsync(string name)
        {
            return await DefaultSubscription.GetResourceGroups().GetAsync(name);
        }
        protected async Task<CloudExadataInfrastructureCollection> GetCloudExadataInfrastructureCollectionAsync(string resourceGroupName)
        {
            ResourceGroupResource rg = await GetResourceGroupResourceAsync(resourceGroupName);
            return rg.GetCloudExadataInfrastructures();
        }

        protected async Task<CloudVmClusterCollection> GetCloudVmClusterCollectionAsync(string resourceGroupName)
        {
            ResourceGroupResource rg = await GetResourceGroupResourceAsync(resourceGroupName);
            return rg.GetCloudVmClusters();
        }

        protected async Task<AutonomousDatabaseCollection> GetAutonomousDatabaseCollectionAsync(string resourceGroupName)
        {
            ResourceGroupResource rg = await GetResourceGroupResourceAsync(resourceGroupName);
            return rg.GetAutonomousDatabases();
        }
        protected async Task<ExadbVmClusterCollection> GetExadbVmClusterCollectionAsync(string resourceGroupName)
        {
            ResourceGroupResource rg = await GetResourceGroupResourceAsync(resourceGroupName);
            return rg.GetExadbVmClusters();
        }
         protected async Task<ExascaleDBStorageVaultCollection> GetExascaleDBStorageVaultCollectionAsync(string resourceGroupName)
        {
            ResourceGroupResource rg = await GetResourceGroupResourceAsync(resourceGroupName);
            return rg.GetExascaleDBStorageVaults();
        }
    }
}
