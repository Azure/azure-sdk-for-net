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
            Assert.That(managedInstance.Data, Is.Not.Null);

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
            Assert.That(admin.Value.Data, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(admin.Value.Data.Name, Is.EqualTo(adminName));

                // 2.CheckIfExist
                Assert.That((bool)collection.Exists(adminName), Is.True);
                Assert.That((bool)collection.Exists(adminName + "0"), Is.False);
            });

            // 3.Get
            var getAdmin = await collection.GetAsync(adminName);
            Assert.Multiple(() =>
            {
                Assert.That(getAdmin.Value.Data, Is.Not.Null);
                Assert.That(admin.Value.Data.Name, Is.EqualTo(getAdmin));
            });

            // 4.GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);

            // 5.Delete
            var deleteAdmin = await collection.GetAsync(adminName);
            await   deleteAdmin.Value.DeleteAsync(WaitUntil.Completed);
            list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Empty);
        }
    }
}
