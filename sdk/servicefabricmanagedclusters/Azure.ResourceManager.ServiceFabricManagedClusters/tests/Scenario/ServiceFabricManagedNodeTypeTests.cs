// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ServiceFabricManagedClusters.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ServiceFabricManagedClusters.Tests
{
    internal class ServiceFabricManagedNodeTypeTests : ServiceFabricManagedClustersManagementTestBase
    {
        private ServiceFabricManagedClusterResource _cluster;
        private ServiceFabricManagedNodeTypeCollection _nodeTypeCollection;
        public ServiceFabricManagedNodeTypeTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var resourceGroup = await CreateResourceGroup();
            _cluster = await CreateServiceFabricManagedCluster(resourceGroup, Recording.GenerateAssetName("sfmctest"));
            _nodeTypeCollection = _cluster.GetServiceFabricManagedNodeTypes();
        }

        [RecordedTest]
        public async Task CreateOrUpdateDelete()
        {
            // CreateOrUpdate
            string primaryNodeTypeName = Recording.GenerateAssetName("node");
            string secondaryNodeTypeName = Recording.GenerateAssetName("node");
            var primaryNodeType = await CreateServiceFabricManagedNodeType(_cluster, primaryNodeTypeName, true);
            var secondaryNodeType = await CreateServiceFabricManagedNodeType(_cluster, secondaryNodeTypeName, false);
            ValidatePurviewAccount(primaryNodeType.Data, primaryNodeTypeName);
            ValidatePurviewAccount(secondaryNodeType.Data, secondaryNodeTypeName);
            // Delete
            await secondaryNodeType.DeleteAsync(WaitUntil.Completed);
            var flag = await _nodeTypeCollection.ExistsAsync(secondaryNodeTypeName);
            Assert.IsFalse(flag);
        }

        [RecordedTest]
        public async Task ExistGetGetAll()
        {
            string nodeTypeName = Recording.GenerateAssetName("node");
            var nodeType = await CreateServiceFabricManagedNodeType(_cluster, nodeTypeName, true);

            // Exist
            var flag = await _nodeTypeCollection.ExistsAsync(nodeTypeName);
            Assert.IsTrue(flag);

            // Get
            var getNodeType = await _nodeTypeCollection.GetAsync(nodeTypeName);
            ValidatePurviewAccount(getNodeType.Value.Data, nodeTypeName);

            // GetAll
            var list = await _nodeTypeCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidatePurviewAccount(list.FirstOrDefault().Data, nodeTypeName);
        }

        private void ValidatePurviewAccount(ServiceFabricManagedNodeTypeData nodeType, string nodeTypeName)
        {
            Assert.IsNotNull(nodeType);
            Assert.IsNotEmpty(nodeType.Id);
            Assert.AreEqual(nodeTypeName, nodeType.Name);
            Assert.AreEqual("S", nodeType.DataDiskLetter);
            Assert.AreEqual(256, nodeType.DataDiskSizeInGB);
            Assert.AreEqual(ServiceFabricManagedDataDiskType.StandardSsdLrs, nodeType.DataDiskType);
            Assert.AreEqual("WindowsServer", nodeType.VmImageOffer);
            Assert.AreEqual("MicrosoftWindowsServer", nodeType.VmImagePublisher);
            Assert.AreEqual("2019-Datacenter", nodeType.VmImageSku);
            Assert.AreEqual("latest", nodeType.VmImageVersion);
            Assert.AreEqual(6, nodeType.VmInstanceCount);
            Assert.AreEqual("Standard_D2_v2", nodeType.VmSize);
        }
    }
}
