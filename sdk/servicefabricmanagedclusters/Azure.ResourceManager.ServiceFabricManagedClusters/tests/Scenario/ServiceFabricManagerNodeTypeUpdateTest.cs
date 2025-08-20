// Copyright (c) Microsoft Corporation. All rights reserved.
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
    internal class ServiceFabricManagerNodeTypeUpdateTest : ServiceFabricManagedClustersManagementTestBase
    {
        public ServiceFabricManagedClusterCollection clusterCollection { get; set; }
        public string clusterName;
        private ResourceGroupResource resourceGroupResource;
        public ServiceFabricManagedClusterResource serviceFabricManagedCluster;
        private ServiceFabricManagedNodeTypeResource serviveFabricManagedClusterNodeType;
        public ServiceFabricManagerNodeTypeUpdateTest(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
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

        [Test]
        [Ignore("Nee re-record")]
        public async Task UpdateTest()
        {
            //Update
            var updateNodetype_lro = await this.serviveFabricManagedClusterNodeType.UpdateAsync(new ServiceFabricManagedNodeTypePatch()
            {
                Tags =
                {
                    ["UpdateKey1"] = "UpdateValue1",
                    ["UpdateKey2"] = "UpdateValue2",
                }
            });
            var updateNodetype = updateNodetype_lro.Value;
        }
    }
}
