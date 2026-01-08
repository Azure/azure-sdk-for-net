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
            Assert.That(managedInstance.Data, Is.Not.Null);
            Assert.Multiple(async () =>
            {
                Assert.That(managedInstance.Data.Name, Is.EqualTo(managedInstanceName));
                Assert.That(managedInstance.Data.Location.ToString(), Is.EqualTo("westus2"));

                // 2.CheckIfExist
                Assert.That((bool)await _resourceGroup.GetManagedInstances().ExistsAsync(managedInstanceName), Is.True);
                Assert.That((bool)await _resourceGroup.GetManagedInstances().ExistsAsync(managedInstanceName + "0"), Is.False);
            });

            // 3.Get
            var getManagedInstance = await _resourceGroup.GetManagedInstances().GetAsync(managedInstanceName);
            Assert.That(getManagedInstance.Value.Data, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(getManagedInstance.Value.Data.Name, Is.EqualTo(managedInstanceName));
                Assert.That(getManagedInstance.Value.Data.Location.ToString(), Is.EqualTo("westus2"));
            });

            // 4.GetAll
            var list = await _resourceGroup.GetManagedInstances().GetAllAsync().ToEnumerableAsync();
            list = await _resourceGroup.GetManagedInstances().GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);
            Assert.That(list, Has.Count.EqualTo(1));
            Assert.Multiple(() =>
            {
                Assert.That(list.FirstOrDefault().Data.Name, Is.EqualTo(managedInstanceName));
                Assert.That(list.FirstOrDefault().Data.Location.ToString(), Is.EqualTo("westus2"));
            });

            // 5.Delte
            await managedInstance.DeleteAsync(WaitUntil.Completed);
            list = await _resourceGroup.GetManagedInstances().GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Empty);
        }
    }
}
