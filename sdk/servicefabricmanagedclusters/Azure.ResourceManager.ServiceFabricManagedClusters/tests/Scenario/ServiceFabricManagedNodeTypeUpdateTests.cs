﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.ServiceFabricManagedClusters.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ServiceFabricManagedClusters.Tests
{
    internal class ServiceFabricManagedNodeTypeUpdateTests : ServiceFabricManagedClustersManagementTestBase
    {
        public ServiceFabricManagedClusterCollection clusterCollection { get; set; }
        public string clusterName;
        private ResourceGroupResource resourceGroupResource;
        public ServiceFabricManagedClusterResource serviceFabricManagedCluster;
        private ServiceFabricManagedNodeTypeResource serviveFabricManagedClusterNodeType;
        public ServiceFabricManagedNodeTypeUpdateTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            resourceGroupResource = await CreateResourceGroupWithTag();

            clusterName = Recording.GenerateAssetName("sfmctestclusternet");
            clusterCollection = resourceGroupResource.GetServiceFabricManagedClusters();

            ServiceFabricManagedClusterData data = new ServiceFabricManagedClusterData(new AzureLocation("westus"))
            {
                DnsName = clusterName,
                AdminUserName = "Myusername4",
                AdminPassword = "Sfmcpass5!",
                Sku = new ServiceFabricManagedClustersSku(ServiceFabricManagedClustersSkuName.Standard),
                ClientConnectionPort = 19000,
                HttpGatewayConnectionPort = 19080,
            };
            data.Tags.Add(new KeyValuePair<string, string>("SFRP.EnableDiagnosticMI", "true"));

            serviceFabricManagedCluster = (await clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data)).Value;

            var nodeTypeCollection = serviceFabricManagedCluster.GetServiceFabricManagedNodeTypes();

            var nodeTypeName = "nodetype1";
            var nodeTypeData = new ServiceFabricManagedNodeTypeData()
            {
                IsPrimary = true,
                VmInstanceCount = 5,
                DataDiskSizeInGB = 100,
                VmSize = "Standard_D4ds_v5",
                VmImagePublisher = "MicrosoftWindowsServer",
                VmImageOffer = "WindowsServer",
                VmImageSku = "2022-datacenter-azure-edition",
                VmImageVersion = "latest",
                SecurityType = "TrustedLaunch",
                IsSecureBootEnabled = true,
            };

            this.serviveFabricManagedClusterNodeType = (await nodeTypeCollection.CreateOrUpdateAsync(WaitUntil.Completed, nodeTypeName, nodeTypeData)).Value;
        }

        [RecordedTest]
        public async Task UpdateTagsTest()
        {
            //Update
            var updateNodetype_lro = await this.serviveFabricManagedClusterNodeType.UpdateAsync(WaitUntil.Completed, new ServiceFabricManagedNodeTypePatch()
            {
                Tags =
                {
                    ["UpdateKey1"] = "UpdateValue1",
                    ["UpdateKey2"] = "UpdateValue2",
                }
            });

            ServiceFabricManagedNodeTypeResource updateNodetype = updateNodetype_lro.Value;
            var nodeTypeTagsDataValues = updateNodetype.Data.Tags;
            Assert.AreEqual(nodeTypeTagsDataValues["UpdateKey1"], "UpdateValue1");
            Assert.AreEqual(nodeTypeTagsDataValues["UpdateKey2"], "UpdateValue2");
        }

        [RecordedTest]
        public async Task UpdateCapacityTest()
        {
            var targetCount = 7;

            //Update
            var updateNodetype_lro = await this.serviveFabricManagedClusterNodeType.UpdateAsync(WaitUntil.Completed, new ServiceFabricManagedNodeTypePatch()
            {
                Sku = new NodeTypeSku(targetCount)
            });

            ServiceFabricManagedNodeTypeResource updateNodetype = updateNodetype_lro.Value;
            Assert.AreEqual(updateNodetype.Data.Sku.Capacity, targetCount);
        }
    }
}
