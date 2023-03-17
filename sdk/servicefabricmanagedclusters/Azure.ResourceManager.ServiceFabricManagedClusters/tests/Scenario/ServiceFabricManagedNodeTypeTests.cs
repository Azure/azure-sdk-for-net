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
        public async Task Create()
        {
            string nodeTypeName = Recording.GenerateAssetName("node");

            var list = await _nodeTypeCollection.GetAllAsync().ToEnumerableAsync();
        }

        private async Task<ServiceFabricManagedNodeTypeResource> CreateServiceFabricManagedNodeType(string nodeTypeName)
        {
            var data = new ServiceFabricManagedNodeTypeData()
            {
                Sku = new NodeTypeSku(6)
                {
                    Name = "Standard_P0",
                    Tier = "Standard"
                },
                ApplicationPorts = new EndpointRangeDescription(20000, 30000),
                DataDiskLetter = "S",
                DataDiskSizeInGB = 256,
                DataDiskType = ServiceFabricManagedDataDiskType.StandardSsdLrs,
                EphemeralPorts = new EndpointRangeDescription(49152, 65534),
                IsPrimary = true,
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
    }
}
