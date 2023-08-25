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
    public class ManagedInstancePrivateLinkTest : SqlManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;
        public ManagedInstancePrivateLinkTest(bool isAsync)
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
        public async Task ManagedInstancePrivateLinkApiTests()
        {
            //Create Managed Instance
            string managedInstanceName = Recording.GenerateAssetName("managed-instance-");
            string vnetName = Recording.GenerateAssetName("vnet-");
            var managedInstance = await CreateDefaultManagedInstance(managedInstanceName, vnetName, AzureLocation.WestUS2, _resourceGroup);
            Assert.IsNotNull(managedInstance.Data);

            var collection = managedInstance.GetManagedInstancePrivateLinks();

            // 1.GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            string privateLinkName = list.FirstOrDefault().Data.Name;

            // 2.CheckIfExist
            Assert.IsTrue(await collection.ExistsAsync(privateLinkName));

            // 3.Get
            var getPrivateLink = await collection.GetAsync(privateLinkName);
            Assert.AreEqual(privateLinkName.ToString(), getPrivateLink.Value.Data.Name);
            Assert.AreEqual("Microsoft.Sql/managedInstances/privateLinkResources", getPrivateLink.Value.Data.ResourceType.ToString());

            // 4.GetIfExist
            Assert.IsTrue(await collection.ExistsAsync(privateLinkName));
        }
    }
}
