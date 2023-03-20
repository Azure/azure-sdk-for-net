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

namespace Azure.ResourceManager.ServiceFabricManagedClusters.Tests.Scenario
{
    internal class ServiceFabricManagedNodeTypeTests : ServiceFabricManagedClustersManagementTestBase
    {
        private ServiceFabricManagedNodeTypeCollection _nodeTypeCollection;
        public ServiceFabricManagedNodeTypeTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var resourceGroup = await CreateResourceGroup();
            var cluster = await CreateServiceFabricManagedCluster(resourceGroup, Recording.GenerateAssetName("sfmctest"));
            _nodeTypeCollection = cluster.GetServiceFabricManagedNodeTypes();
        }

        [RecordedTest]
        public async Task CreateOrUpdateDelete()
        {
            // CreateOrUpdate
            string primaryNodeTypeName = Recording.GenerateAssetName("node");
            string secondaryNodeTypeName = Recording.GenerateAssetName("node");
            var primaryNodeType = await CreateServiceFabricManagedNodeType(primaryNodeTypeName, true);
            var secondaryNodeType = await CreateServiceFabricManagedNodeType(secondaryNodeTypeName, false);
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
            var nodeType = await CreateServiceFabricManagedNodeType(nodeTypeName, true);

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

        private async Task<ServiceFabricManagedNodeTypeResource> CreateServiceFabricManagedNodeType(string nodeTypeName, bool isPrimaryNode)
        {
            var data = new ServiceFabricManagedNodeTypeData()
            {
                ApplicationPorts = new EndpointRangeDescription(20000, 30000),
                DataDiskLetter = "S",
                DataDiskSizeInGB = 256,
                DataDiskType = ServiceFabricManagedDataDiskType.StandardSsdLrs,
                EphemeralPorts = new EndpointRangeDescription(49152, 65534),
                IsPrimary = isPrimaryNode,
                VmImageOffer = "WindowsServer",
                VmImagePublisher = "MicrosoftWindowsServer",
                VmImageSku = "2019-Datacenter",
                VmImageVersion = "latest",
                VmInstanceCount = 6,
                VmSize = "Standard_D2_v2"
            };
            var noteTypeLro = await _nodeTypeCollection.CreateOrUpdateAsync(WaitUntil.Completed, nodeTypeName, data);
            return noteTypeLro.Value;
        }

        private void ValidatePurviewAccount(ServiceFabricManagedNodeTypeData nodeType, string nodeTypeName)
        {
            Assert.IsNotNull(nodeType);
        }
    }
}
