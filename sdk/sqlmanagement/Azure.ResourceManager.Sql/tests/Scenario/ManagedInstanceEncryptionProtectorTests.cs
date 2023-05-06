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
    public class ManagedInstanceEncryptionProtectorTests : SqlManagementClientBase
    {
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;
        public ManagedInstanceEncryptionProtectorTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("Sql-RG-"), new ResourceGroupData(AzureLocation.WestUS2));
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
        public async Task ManagedInstanceEncryptionProtectorApiTests()
        {
            // Create Managed Instance
            string managedInstanceName = Recording.GenerateAssetName("managed-instance-");
            string vnetName = Recording.GenerateAssetName("vnet-");
            var managedInstance = await CreateDefaultManagedInstance(managedInstanceName, vnetName, AzureLocation.WestUS2, _resourceGroup);
            Assert.IsNotNull(managedInstance.Data);

            string encryptionProtectorName = "current";
            var collection = managedInstance.GetManagedInstanceEncryptionProtectors();

            // 1.CreateOrUpdata
            ManagedInstanceEncryptionProtectorData data = new ManagedInstanceEncryptionProtectorData()
            {
                ServerKeyName = "ServiceManaged",
                ServerKeyType =  "ServiceManaged",
                IsAutoRotationEnabled = false,
            };
            var encryption = await collection.CreateOrUpdateAsync(WaitUntil.Completed, encryptionProtectorName, data);
            Assert.IsNotNull(encryption.Value.Data);
            Assert.AreEqual(encryptionProtectorName, encryption.Value.Data.Name);
            Assert.AreEqual("ServiceManaged", encryption.Value.Data.ServerKeyName);
            Assert.AreEqual("ServiceManaged", encryption.Value.Data.ServerKeyType.ToString());
            Assert.AreEqual(false, encryption.Value.Data.IsAutoRotationEnabled);

            // 2.CheckIfExist
            Assert.IsTrue(await collection.ExistsAsync(encryptionProtectorName));

            // 3.Get
            var getEncryption = await collection.GetAsync(encryptionProtectorName);
            Assert.IsNotNull(encryption.Value.Data);
            Assert.AreEqual(encryptionProtectorName, getEncryption.Value.Data.Name);
            Assert.AreEqual("ServiceManaged", getEncryption.Value.Data.ServerKeyName);
            Assert.AreEqual("ServiceManaged", getEncryption.Value.Data.ServerKeyType.ToString());
            Assert.AreEqual(false, getEncryption.Value.Data.IsAutoRotationEnabled);

            // 4.GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(encryptionProtectorName, list.FirstOrDefault().Data.Name);
        }
    }
}
