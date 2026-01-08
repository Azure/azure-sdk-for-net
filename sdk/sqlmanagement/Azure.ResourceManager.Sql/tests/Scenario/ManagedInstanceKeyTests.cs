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
    public class ManagedInstanceKeyTests : SqlManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;
        public ManagedInstanceKeyTests(bool isAsync)
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
        public async Task ManagedInstanceKeyApiTests()
        {
            // Create Managed Instance
            string managedInstanceName = Recording.GenerateAssetName("managed-instance-");
            string vnetName = Recording.GenerateAssetName("vnet-");
            var managedInstance = await CreateDefaultManagedInstance(managedInstanceName, vnetName, AzureLocation.WestUS2, _resourceGroup);
            Assert.That(managedInstance.Data, Is.Not.Null);

            string keyName = "ServiceManaged";
            var collection = managedInstance.GetManagedInstanceKeys();

            // 1.CreateOrUpdate - Ignore["Service-managed TDE keys are managed by the service. Service-managed TDE keys don't support Create or Update by the user."]
            //ManagedInstanceKeyData data = new ManagedInstanceKeyData()
            //{
            //    ServerKeyType = "ServiceManaged",
            //};
            //var key  = await collection.CreateOrUpdateAsync(keyName, data);
            //Assert.IsNotNull(key.Value.Data);
            //Assert.AreEqual(keyName,key.Value.Data.Name);

            // 2.CheckIfExist
            Assert.That((bool)await collection.ExistsAsync(keyName), Is.True);

            // 3.Get
            var getKey =await collection.GetAsync(keyName);
            Assert.That(getKey.Value.Data, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(getKey.Value.Data.Name, Is.EqualTo(keyName));
                Assert.That(getKey.Value.Data.Kind, Is.EqualTo("servicemanaged"));
                Assert.That(getKey.Value.Data.ServerKeyType.ToString(), Is.EqualTo("ServiceManaged"));
            });

            // 4.GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);
            Assert.That(list, Has.Count.EqualTo(1));
            Assert.That(list.FirstOrDefault().Data.Name, Is.EqualTo(keyName));

            // 5.Delete - Ignore("The operation could not be completed.")
            //var deleteKey =await collection.GetAsync(keyName);
            //await deleteKey.Value.DeleteAsync();
        }
    }
}
