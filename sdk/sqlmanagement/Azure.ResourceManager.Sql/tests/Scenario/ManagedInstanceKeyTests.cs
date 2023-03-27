// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests.Scenario
{
    public class ManagedInstanceKeyTests : SqlManagementClientBase
    {
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;
        public ManagedInstanceKeyTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
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
            Assert.IsNotNull(managedInstance.Data);

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
            Assert.IsTrue(await collection.ExistsAsync(keyName));

            // 3.Get
            var getKey =await collection.GetAsync(keyName);
            Assert.IsNotNull(getKey.Value.Data);
            Assert.AreEqual(keyName, getKey.Value.Data.Name);
            Assert.AreEqual("servicemanaged", getKey.Value.Data.Kind);
            Assert.AreEqual("ServiceManaged", getKey.Value.Data.ServerKeyType.ToString());

            // 4.GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(1,list.Count);
            Assert.AreEqual(keyName,list.FirstOrDefault().Data.Name);

            // 5.Delete - Ignore("The operation could not be completed.")
            //var deleteKey =await collection.GetAsync(keyName);
            //await deleteKey.Value.DeleteAsync();
        }
    }
}
