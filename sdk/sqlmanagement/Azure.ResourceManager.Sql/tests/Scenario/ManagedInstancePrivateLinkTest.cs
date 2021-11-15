// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sql.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests.Scenario
{
    public class ManagedInstancePrivateLinkTest : SqlManagementClientBase
    {
        private ResourceGroup _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;
        public ManagedInstancePrivateLinkTest(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().GetAsync("Sql-RG-1100");
            //var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(SessionRecording.GenerateAssetName("Sql-RG-"), new ResourceGroupData(Location.WestUS2));
            ResourceGroup rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            StopSessionRecording();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroup(_resourceGroupIdentifier).GetAsync();
        }

        [Test]
        [Ignore("not debug yet")]
        [RecordedTest]
        public async Task ManagedInstancePrivateLinkApiTests()
        {
            // Create Managed Instance
            //string managedInstanceName = Recording.GenerateAssetName("managed-instance-");
            //var managedInstance = await CreateDefaultManagedInstance(managedInstanceName, Location.WestUS2, _resourceGroup);
            //Assert.IsNotNull(managedInstance.Data);

            //var collection = managedInstance.GetManagedInstancePrivateLinks();
            var collection = _resourceGroup.GetManagedInstances().GetAsync("managed-instance-1100").Result.Value.GetManagedInstancePrivateLinks();

            // 1.GetAll
            var list = await collection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            string privateLinkName = list.FirstOrDefault().Data.Name;

            // 2.CheckIfExist
            Assert.IsTrue(collection.CheckIfExists(privateLinkName));

            // 3.Get
            var getPrivateLink = await collection.GetAsync(privateLinkName);
            Assert.AreEqual(privateLinkName.ToString(), getPrivateLink.Value.Data.Name);

            // 4.GetIfExist
            var GetIfExistPrivateLink = await collection.GetIfExistsAsync(privateLinkName);
            Assert.AreEqual(privateLinkName.ToString(), GetIfExistPrivateLink.Value.Data.Name);
        }
    }
}
