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
            Assert.That(managedInstance.Data, Is.Not.Null);

            var collection = managedInstance.GetManagedInstancePrivateLinks();

            // 1.GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);
            string privateLinkName = list.FirstOrDefault().Data.Name;

            // 2.CheckIfExist
            Assert.That((bool)await collection.ExistsAsync(privateLinkName), Is.True);

            // 3.Get
            var getPrivateLink = await collection.GetAsync(privateLinkName);
            Assert.That(getPrivateLink.Value.Data.Name, Is.EqualTo(privateLinkName.ToString()));
            Assert.That(getPrivateLink.Value.Data.ResourceType.ToString(), Is.EqualTo("Microsoft.Sql/managedInstances/privateLinkResources"));

            // 4.GetIfExist
            Assert.That((bool)await collection.ExistsAsync(privateLinkName), Is.True);
        }
    }
}
