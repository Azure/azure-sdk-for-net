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
    public class RecoverableManagedDatabaseTests : SqlManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;
        public RecoverableManagedDatabaseTests(bool isAsync)
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
        [Ignore("issue:https://github.com/Azure/azure-rest-api-specs/issues/16850")]
        [RecordedTest]
        public async Task GetAll()
        {
            string managedInstanceName = Recording.GenerateAssetName("managed-instance-");
            string vnetName = Recording.GenerateAssetName("vnet-");
            var managedInstance = await CreateDefaultManagedInstance(managedInstanceName, vnetName, AzureLocation.WestUS2, _resourceGroup);
            var collection = managedInstance.GetRecoverableManagedDatabases();
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }

        [Test]
        [Ignore("hard to mock disaster recovery scenario")]
        [RecordedTest]
        public async Task RecoverableManagedDatabaseApiTests()
        {
            // Create Managed Instance
            string managedInstanceName = Recording.GenerateAssetName("managed-instance-");
            string vnetName = Recording.GenerateAssetName("vnet-");
            var managedInstance = await CreateDefaultManagedInstance(managedInstanceName, vnetName, AzureLocation.WestUS2, _resourceGroup);
            Assert.IsNotNull(managedInstance.Data);

            var collection = managedInstance.GetRecoverableManagedDatabases();

            // 1.GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            string recoverableManagedDatabaseName = list.FirstOrDefault().Data.Name;

            // 2.CheckIfExist
            Assert.IsTrue(collection.Exists(recoverableManagedDatabaseName));

            // 3.Get
            var getRecoverableManagedDatabase = await collection.GetAsync(recoverableManagedDatabaseName);
            Assert.AreEqual(recoverableManagedDatabaseName.ToString(), getRecoverableManagedDatabase.Value.Data.Name);

            // 4.GetIfExist
            Assert.IsTrue(await collection.ExistsAsync(recoverableManagedDatabaseName));
        }
    }
}
