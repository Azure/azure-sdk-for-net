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
    public class ManagedInstanceEncryptionProtectorTests : SqlManagementTestBase
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
            Assert.That(encryption.Value.Data.Name, Is.EqualTo(encryptionProtectorName));
            Assert.That(encryption.Value.Data.ServerKeyName, Is.EqualTo("ServiceManaged"));
            Assert.That(encryption.Value.Data.ServerKeyType.ToString(), Is.EqualTo("ServiceManaged"));
            Assert.That(encryption.Value.Data.IsAutoRotationEnabled, Is.EqualTo(false));

            // 2.CheckIfExist
            Assert.That((bool)await collection.ExistsAsync(encryptionProtectorName), Is.True);

            // 3.Get
            var getEncryption = await collection.GetAsync(encryptionProtectorName);
            Assert.IsNotNull(encryption.Value.Data);
            Assert.That(getEncryption.Value.Data.Name, Is.EqualTo(encryptionProtectorName));
            Assert.That(getEncryption.Value.Data.ServerKeyName, Is.EqualTo("ServiceManaged"));
            Assert.That(getEncryption.Value.Data.ServerKeyType.ToString(), Is.EqualTo("ServiceManaged"));
            Assert.That(getEncryption.Value.Data.IsAutoRotationEnabled, Is.EqualTo(false));

            // 4.GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list.FirstOrDefault().Data.Name, Is.EqualTo(encryptionProtectorName));
        }
    }
}
