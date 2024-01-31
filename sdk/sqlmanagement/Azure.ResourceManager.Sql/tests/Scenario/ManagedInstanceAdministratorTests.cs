// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sql.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests
{
    public class ManagedInstanceAdministratorTests : SqlManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;

        public ManagedInstanceAdministratorTests(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("Sql-RG-"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [Test]
        [Ignore("Need Global Administrator privileges")]
        [RecordedTest]
        public async Task ManagedInstanceAdministratorApiTests()
        {
            // Create Managed Instance
            string managedInstanceName = Recording.GenerateAssetName("managed-instance-");
            string vnetName = Recording.GenerateAssetName("vnet-");
            string adminName = Recording.GenerateAssetName("admin-");
            var managedInstance = await CreateDefaultManagedInstance(managedInstanceName, vnetName, AzureLocation.WestUS2, _resourceGroup);
            Assert.IsNotNull(managedInstance.Data);

            var collection = managedInstance.GetManagedInstanceAdministrators();

            //1.CreateOrUpdata
            ManagedInstanceAdministratorData data = new ManagedInstanceAdministratorData()
            {
                AdministratorType = ManagedInstanceAdministratorType.ActiveDirectory,
                Login = "admin-login-0000",
                Sid = Guid.NewGuid(),
                TenantId = Guid.NewGuid(),
            };
            var admin = await collection.CreateOrUpdateAsync(WaitUntil.Completed, adminName, data);
            Assert.NotNull(admin.Value.Data);
            Assert.AreEqual(adminName, admin.Value.Data.Name);

            // 2.CheckIfExist
            Assert.IsTrue(collection.Exists(adminName));
            Assert.IsFalse(collection.Exists(adminName + "0"));

            // 3.Get
            var getAdmin = await collection.GetAsync(adminName);
            Assert.NotNull(getAdmin.Value.Data);
            Assert.AreEqual(getAdmin, admin.Value.Data.Name);

            // 4.GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);

            // 5.Delete
            var deleteAdmin = await collection.GetAsync(adminName);
            await   deleteAdmin.Value.DeleteAsync(WaitUntil.Completed);
            list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
