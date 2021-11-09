// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sql.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests.Scenario
{
    public class VirtualClusterTests : SqlManagementClientBase
    {
        private ResourceGroup _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;

        public VirtualClusterTests(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(SessionRecording.GenerateAssetName("Sql-RG-"), new ResourceGroupData(Location.WestUS2));
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
        [RecordedTest]
        public async Task CheckIfExist()
        {
            string managedInstanceName = Recording.GenerateAssetName("Managed-Instance-");
            await CreateDefaultManagedInstance(managedInstanceName, _resourceGroup);
            var list = await _resourceGroup.GetVirtualClusters().GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(_resourceGroup.GetVirtualClusters().CheckIfExists(list[0].Data.Name));
            Assert.IsNotEmpty(list);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string managedInstanceName = Recording.GenerateAssetName("Managed-Instance-");
            await CreateDefaultManagedInstance(managedInstanceName, _resourceGroup);
            var list = await _resourceGroup.GetVirtualClusters().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);

            await list[0].DeleteAsync();
            list = await _resourceGroup.GetVirtualClusters().GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string managedInstanceName = Recording.GenerateAssetName("Managed-Instance-");
            await CreateDefaultManagedInstance(managedInstanceName, _resourceGroup);
            var list = await _resourceGroup.GetVirtualClusters().GetAllAsync().ToEnumerableAsync();
            string virtualClusterName = list[0].Data.Name;
            var virtualCluster =await _resourceGroup.GetVirtualClusters().GetAsync(virtualClusterName);
            Assert.IsNotNull(virtualCluster.Value.Data);
            Assert.AreEqual(virtualClusterName,virtualCluster.Value.Data.Name);
            Assert.AreEqual("westus2",virtualCluster.Value.Data.Location.ToString());
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _resourceGroup.GetVirtualClusters().GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);

            string managedInstanceName = Recording.GenerateAssetName("Managed-Instance-");
            await CreateDefaultManagedInstance(managedInstanceName, _resourceGroup);
            list = await _resourceGroup.GetVirtualClusters().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }
    }
}
