// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
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
        [Ignore("Nee re-record")]
        public async Task BasicClusterTestAsync()
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

            ServiceFabricManagedClusterData resourceData = serviceFabricManagedCluster.Data;
            Assert.AreEqual(clusterName, resourceData.Name);
        }
    }
}
