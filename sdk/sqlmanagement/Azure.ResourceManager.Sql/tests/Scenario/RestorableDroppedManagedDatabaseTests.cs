// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests
{
    public class RestorableDroppedManagedDatabaseTests : SqlManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;
        public RestorableDroppedManagedDatabaseTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
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
        [RecordedTest]
        public async Task GetAll()
        {
            string managedInstanceName = Recording.GenerateAssetName("managed-instance-");
            string vnetName = Recording.GenerateAssetName("vnet-");
            var managedInstance = await CreateDefaultManagedInstance(managedInstanceName, vnetName, AzureLocation.WestUS2, _resourceGroup);
            Assert.IsNotNull(managedInstance.Data);

            var collection = managedInstance.GetRestorableDroppedManagedDatabases();
            var list = collection.GetAllAsync().ToEnumerableAsync().Result;
            Assert.IsEmpty(list);
        }

        [Test]
        [Ignore("Hard to mock Restorable Dropped Managed Database")]
        [RecordedTest]
        public async Task RestorableDroppedManagedDatabaseApiTests()
        {
            // Create Managed Instance
            string managedInstanceName = Recording.GenerateAssetName("managed-instance-");
            string vnetName = Recording.GenerateAssetName("vnet-");
            var managedInstance = await CreateDefaultManagedInstance(managedInstanceName, vnetName, AzureLocation.WestUS2, _resourceGroup);
            Assert.IsNotNull(managedInstance.Data);

            var collection = managedInstance.GetRestorableDroppedManagedDatabases();

            // 1.GetAll
            var list = collection.GetAllAsync().ToEnumerableAsync().Result;
            Assert.IsNotEmpty(list);
            string databaseId = list.FirstOrDefault().Data.Id.ToString();

            // 2.CheckIfExist
            Assert.IsTrue(collection.Exists(databaseId));

            // 3.Get
            var getDatabase = await collection.GetAsync(databaseId);
            Assert.IsNotNull(getDatabase);

            // 4.GetIfExist
            Assert.IsTrue(await collection.ExistsAsync(databaseId));
        }
    }
}
