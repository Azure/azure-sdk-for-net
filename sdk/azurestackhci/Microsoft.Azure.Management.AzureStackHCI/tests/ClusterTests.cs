using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.AzureStackHCI;
using Microsoft.Azure.Management.AzureStackHCI.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.Azure;
using System;
using Xunit;

namespace AzureStackHCI.Tests
{
    public class ClusterTests
    {
        [Fact]
        public void TestClusterLifeCycle()
        {
            using (var context = MockContext.Start(GetType()))
            {
                string rgName = TestUtilities.GenerateName("hci-cluster-rg");
                string clusterName = TestUtilities.GenerateName("hci-cluster");

                CreateResourceGroup(context, rgName);
                Cluster cluster = CreateCluster(context, rgName, clusterName);
                Assert.NotNull(cluster);

                DeleteCluster(context, rgName, clusterName);
                AssertNoCluster(context, rgName);

                DeleteResourceGroup(context, rgName);
            }
        }

        private ResourceGroup CreateResourceGroup(MockContext context, string rgName)
        {
            ResourceManagementClient client = GetResourceManagementClient(context);
            return client.ResourceGroups.CreateOrUpdate(
                rgName,
                new ResourceGroup
                {
                    Location = "eastus"
                });
        }

        private void DeleteResourceGroup(MockContext context, String rgName)
        {
            ResourceManagementClient client = GetResourceManagementClient(context);
            client.ResourceGroups.Delete(rgName);
        }

        private Cluster CreateCluster(MockContext context, string rgName, string clusterName)
        {
            AzureStackHCIClient client = GetAzureStackHCIClient(context);
            return client.Clusters.Create(
                rgName,
                clusterName,
                new Cluster(location: "eastus", aadClientId: "104a5669-0106-4718-9e06-c69f5a881d86", aadTenantId: "c76bd4d1-bea3-45ea-be1b-4a745a675d07")
            );
        }

        private void DeleteCluster(MockContext context, string rgName, string clusterName)
        {
            AzureStackHCIClient client = GetAzureStackHCIClient(context);
            client.Clusters.Delete(rgName, clusterName);
        }

        private void AssertNoCluster(MockContext context, string rgName)
        {
            IPage<Cluster> clusters = ListClusters(context, rgName);
            Assert.Null(clusters.GetEnumerator().Current);
        }

        private IPage<Cluster> ListClusters(MockContext context, string rgName)
        {
            AzureStackHCIClient client = GetAzureStackHCIClient(context);
            return client.Clusters.ListByResourceGroup(rgName);
        }

        private String CreateName(String prefix) => TestUtilities.GenerateName(prefix);

        private ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>();
        }

        private AzureStackHCIClient GetAzureStackHCIClient(MockContext context)
        {
            return context.GetServiceClient<AzureStackHCIClient>();
        }
    }
}