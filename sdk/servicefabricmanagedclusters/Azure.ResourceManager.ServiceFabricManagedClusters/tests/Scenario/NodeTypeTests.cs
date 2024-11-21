// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.ServiceFabricManagedClusters.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace Azure.ResourceManager.ServiceFabricManagedClusters.Tests.Scenario
{
    internal class NodeTypeTests : ServiceFabricManagedClustersManagementTestBase
    {
        public ServiceFabricManagedClusterCollection clusterCollection { get; set; }
        public string clusterName;
        private ResourceGroupResource resourceGroupResource;
        public ServiceFabricManagedClusterResource serviceFabricManagedCluster;

        public NodeTypeTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task Setup()
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
                HttpGatewayConnectionPort = 19080
            };
            data.Tags.Add(new KeyValuePair<string, string>("SFRP.EnableDiagnosticMI", "true"));

            serviceFabricManagedCluster = (await clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, clusterName, data)).Value;
        }

        [Test]
        [RecordedTest]
        public async Task SecurityTypeSecureBootTest()
        {
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

            var serviveFabricManagedClusterNodeType = (await nodeTypeCollection.CreateOrUpdateAsync(WaitUntil.Completed, nodeTypeName, nodeTypeData)).Value;

            var resourceData = serviveFabricManagedClusterNodeType.Data;
            Assert.AreEqual(nodeTypeData.SecurityType, resourceData.SecurityType);
            Assert.AreEqual(nodeTypeData.IsSecureBootEnabled, resourceData.IsSecureBootEnabled);
        }
    }
}
