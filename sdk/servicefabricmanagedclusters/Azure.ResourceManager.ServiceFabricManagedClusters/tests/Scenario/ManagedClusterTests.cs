// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.ServiceFabricManagedClusters.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ServiceFabricManagedClusters.Tests
{
    public class ManagedClusterTests : ServiceFabricManagedClustersManagementTestBase
    {
        public ServiceFabricManagedClusterCollection clusterCollection { get; set; }
        public string clusterName;
        private ResourceGroupResource resourceGroupResource;
        public ServiceFabricManagedClusterResource serviceFabricManagedCluster;
        public ManagedClusterTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [RecordedTest]
        public async Task clusterTestAsync()
        {
            resourceGroupResource = await CreateResourceGroupAsync();

            clusterName = Recording.GenerateAssetName("sfmctestcluster");

            // get the collection of this ServiceFabricManagedClusterResource
            clusterCollection = resourceGroupResource.GetServiceFabricManagedClusters();

            ServiceFabricManagedClusterData data = new ServiceFabricManagedClusterData(new AzureLocation("southcentralus"))
            {
                DnsName = clusterName,
                AdminUserName = "Myusername4",
                AdminPassword = "Sfmcpass5!",
                Sku = new ServiceFabricManagedClustersSku(ServiceFabricManagedClustersSkuName.Standard),
                ClientConnectionPort = 19000,
                HttpGatewayConnectionPort = 19080
            };

            serviceFabricManagedCluster = (await clusterCollection.CreateOrUpdateAsync(WaitUntil.Completed, "testClustern1", data)).Value;

            ServiceFabricManagedNodeTypeCollection nodeTypeCollection = serviceFabricManagedCluster.GetServiceFabricManagedNodeTypes();

            string nodeTypeName = "nodetype1";
            ServiceFabricManagedNodeTypeData nodeTypeData = new ServiceFabricManagedNodeTypeData()
            {
                IsPrimary = true,
                VmInstanceCount = 5,
                DataDiskSizeInGB = 100,
                VmSize = "Standard_D2s_v3",
                VmImagePublisher = "MicrosoftWindowsServer",
                VmImageOffer = "WindowsServer",
                VmImageSku = "2022-Datacenter",
                VmImageVersion = "latest",
            };

            ArmOperation<ServiceFabricManagedNodeTypeResource> lroNodeType = await nodeTypeCollection.CreateOrUpdateAsync(WaitUntil.Completed, nodeTypeName, nodeTypeData);

            ServiceFabricManagedClusterData resourceData = serviceFabricManagedCluster.Data;
            Assert.AreEqual(clusterName, resourceData.Name);
            ;
        }
    }
}
