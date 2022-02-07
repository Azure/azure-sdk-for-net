﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        private ResourceGroup _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;
        public ManagedInstanceEncryptionProtectorTests(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(true, SessionRecording.GenerateAssetName("Sql-RG-"), new ResourceGroupData(AzureLocation.WestUS2));
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
        public async Task ManagedInstanceEncryptionProtectorApiTests()
        {
            // Create Managed Instance
            string managedInstanceName = Recording.GenerateAssetName("managed-instance-");
            string networkSecurityGroupName = Recording.GenerateAssetName("network-security-group-");
            string routeTableName = Recording.GenerateAssetName("route-table-");
            string vnetName = Recording.GenerateAssetName("vnet-");
            var managedInstance = await CreateDefaultManagedInstance(managedInstanceName, networkSecurityGroupName, routeTableName, vnetName, AzureLocation.WestUS2, _resourceGroup);
            Assert.IsNotNull(managedInstance.Data);

            string encryptionProtectorName = "current";
            var collection = managedInstance.GetManagedInstanceEncryptionProtectors();

            // 1.CreateOrUpdata
            ManagedInstanceEncryptionProtectorData data = new ManagedInstanceEncryptionProtectorData()
            {
                ServerKeyName = "ServiceManaged",
                ServerKeyType =  "ServiceManaged",
                AutoRotationEnabled = false,
            };
            var encryption = await collection.CreateOrUpdateAsync(true, encryptionProtectorName, data);
            Assert.IsNotNull(encryption.Value.Data);
            Assert.AreEqual(encryptionProtectorName, encryption.Value.Data.Name);
            Assert.AreEqual("ServiceManaged", encryption.Value.Data.ServerKeyName);
            Assert.AreEqual("ServiceManaged", encryption.Value.Data.ServerKeyType.ToString());
            Assert.AreEqual(false, encryption.Value.Data.AutoRotationEnabled);

            // 2.CheckIfExist
            Assert.IsTrue(await collection.ExistsAsync(encryptionProtectorName));

            // 3.Get
            var getEncryption = await collection.GetAsync(encryptionProtectorName);
            Assert.IsNotNull(encryption.Value.Data);
            Assert.AreEqual(encryptionProtectorName, getEncryption.Value.Data.Name);
            Assert.AreEqual("ServiceManaged", getEncryption.Value.Data.ServerKeyName);
            Assert.AreEqual("ServiceManaged", getEncryption.Value.Data.ServerKeyType.ToString());
            Assert.AreEqual(false, getEncryption.Value.Data.AutoRotationEnabled);

            // 4.GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(encryptionProtectorName, list.FirstOrDefault().Data.Name);
        }
    }
}
