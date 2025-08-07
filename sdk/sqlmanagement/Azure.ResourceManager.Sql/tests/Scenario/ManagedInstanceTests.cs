// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sql.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests
{
    public class ManagedInstanceTests : SqlManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;

        public ManagedInstanceTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            var rgLro = await client.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("Sql-RG-"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource resourceGroup = rgLro.Value;
            _resourceGroupIdentifier = resourceGroup.Id;
            _resourceGroup = await client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            var list = await _resourceGroup.GetManagedInstances().GetAllAsync().ToEnumerableAsync();
            foreach (var item in list)
            {
                await item.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        [RecordedTest]
        public async Task ManagedInstanceApiTests()
        {
            //Because MangedInstance deployment takes a lot of time(more than 4.5 hours), the test cases are not separated separately
            // 1.CreateOrUpdate
            string managedInstanceName = Recording.GenerateAssetName("managed-instance-");
            string vnetName = Recording.GenerateAssetName("vnet-");
            var managedInstance = await CreateDefaultManagedInstance(managedInstanceName,vnetName,DefaultLocation,_resourceGroup);
            Assert.IsNotNull(managedInstance.Data);
            Assert.AreEqual(managedInstanceName, managedInstance.Data.Name);
            Assert.AreEqual("westus2", managedInstance.Data.Location.ToString());

            // 2.CheckIfExist
            Assert.IsTrue(await _resourceGroup.GetManagedInstances().ExistsAsync(managedInstanceName));
            Assert.IsFalse(await _resourceGroup.GetManagedInstances().ExistsAsync(managedInstanceName + "0"));

            // 3.Get
            var getManagedInstance = await _resourceGroup.GetManagedInstances().GetAsync(managedInstanceName);
            Assert.IsNotNull(getManagedInstance.Value.Data);
            Assert.AreEqual(managedInstanceName, getManagedInstance.Value.Data.Name);
            Assert.AreEqual("westus2", getManagedInstance.Value.Data.Location.ToString());

            // 4.GetAll
            var list = await _resourceGroup.GetManagedInstances().GetAllAsync().ToEnumerableAsync();
            list = await _resourceGroup.GetManagedInstances().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(managedInstanceName, list.FirstOrDefault().Data.Name);
            Assert.AreEqual("westus2", list.FirstOrDefault().Data.Location.ToString());

            // 5.Delte
            await managedInstance.DeleteAsync(WaitUntil.Completed);
            list = await _resourceGroup.GetManagedInstances().GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
