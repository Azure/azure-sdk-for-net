// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sql.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests.Scenario
{
    public class ManagedInstanceAdministratorTests : SqlManagementClientBase
    {
        private ResourceGroup _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;

        public ManagedInstanceAdministratorTests(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(SessionRecording.GenerateAssetName("Sql-RG-"), new ResourceGroupData(Location.WestUS2));
            ResourceGroup rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroup(_resourceGroupIdentifier).GetAsync();
        }

        [Test]
        [Ignore("Need Global Administrator privileges")]
        [RecordedTest]
        public async Task ManagedInstanceAdministratorApiTests()
        {
            // Create Managed Instance
            string managedInstanceName = Recording.GenerateAssetName("managed-instance-");
            string networkSecurityGroupName = Recording.GenerateAssetName("network-security-group-");
            string routeTableName = Recording.GenerateAssetName("route-table-");
            string vnetName = Recording.GenerateAssetName("vnet-");
            var managedInstance = await CreateDefaultManagedInstance(managedInstanceName, networkSecurityGroupName, routeTableName, vnetName, Location.WestUS2, _resourceGroup);
            Assert.IsNotNull(managedInstance.Data);

            string adminName = Recording.GenerateAssetName("admin-");
            var collection = managedInstance.GetManagedInstanceAdministrators();

            //1.CreateOrUpdata
            ManagedInstanceAdministratorData data = new ManagedInstanceAdministratorData()
            {
                AdministratorType = ManagedInstanceAdministratorType.ActiveDirectory,
                Login = "admin-login-0000",
                Sid = Guid.NewGuid(),
                TenantId = Guid.NewGuid(),
            };
            var admin = await collection.CreateOrUpdateAsync(adminName, data);
            Assert.NotNull(admin.Value.Data);
            Assert.AreEqual(adminName, admin.Value.Data.Name);

            // 2.CheckIfExist
            Assert.IsTrue(collection.CheckIfExists(adminName));
            Assert.IsFalse(collection.CheckIfExists(adminName + "0"));

            // 3.Get
            var getAdmin = await collection.GetAsync(adminName);
            Assert.NotNull(getAdmin.Value.Data);
            Assert.AreEqual(getAdmin, admin.Value.Data.Name);

            // 4.GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);

            // 5.Delete
            var deleteAdmin = await collection.GetAsync(adminName);
            await   deleteAdmin.Value.DeleteAsync();
            list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
