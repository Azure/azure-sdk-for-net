// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests.Scenario
{
    public class ManagedInstanceOperationTests : SqlManagementClientBase
    {
        private ResourceGroup _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;
        public ManagedInstanceOperationTests(bool isAsync)
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
        [RecordedTest]
        public async Task ManagedInstanceOperationApiTests()
        {
            // Create Managed Instance
            string managedInstanceName = Recording.GenerateAssetName("managed-instance-");
            string networkSecurityGroupName = Recording.GenerateAssetName("network-security-group-");
            string routeTableName = Recording.GenerateAssetName("route-table-");
            string vnetName = Recording.GenerateAssetName("vnet-");
            var managedInstance = await CreateDefaultManagedInstance(managedInstanceName, networkSecurityGroupName, routeTableName, vnetName, Location.WestUS2, _resourceGroup);
            Assert.IsNotNull(managedInstance.Data);

            var collection = managedInstance.GetManagedInstanceOperations();

            // 1.GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Guid operationName = new Guid(list.FirstOrDefault().Data.Name);

            // 2.CheckIfExist
            Assert.IsTrue(collection.CheckIfExists(operationName));

            // 3.Get
            var getOperation = await collection.GetAsync(operationName);
            Assert.AreEqual(operationName.ToString(), getOperation.Value.Data.Name);

            // 4.GetIfExist
            var GetIfExistoperation = await collection.GetIfExistsAsync(operationName);
            Assert.AreEqual(operationName.ToString(), GetIfExistoperation.Value.Data.Name);
        }
    }
}
