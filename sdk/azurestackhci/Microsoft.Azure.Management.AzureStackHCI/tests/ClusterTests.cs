using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.AzureStackHCI;
using Microsoft.Azure.Management.AzureStackHCI.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using Xunit;

namespace AzureStackHCI.Tests
{
    public class ClusterTests
    {
        private const string arcSettingName = "default";
        private const string extensionName = "MicrosoftMonitoringAgent";
        private const string location = "eastus2euap";

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

        [Fact]
        public void TestArcSettingLifeCycle()
        {
            using (var context = MockContext.Start(GetType()))
            {
                string rgName = TestUtilities.GenerateName("hci-cluster-rg");
                string clusterName = TestUtilities.GenerateName("hci-cluster");

                CreateResourceGroup(context, rgName);
                Cluster cluster = CreateCluster(context, rgName, clusterName);
                Assert.NotNull(cluster);
                ArcSetting arcSetting = CreateArcSetting(context, rgName, clusterName);
                Assert.NotNull(arcSetting);

                DeleteArcSetting(context, rgName, clusterName);
                AssertNoArcSetting(context, rgName, clusterName);
                DeleteCluster(context, rgName, clusterName);
                AssertNoCluster(context, rgName);

                DeleteResourceGroup(context, rgName);
            }
        }

        [Fact]
        public void TestArcExtensionLifeCycle()
        {
            using (var context = MockContext.Start(GetType()))
            {
                string rgName = TestUtilities.GenerateName("hci-cluster-rg");
                string clusterName = TestUtilities.GenerateName("hci-cluster");

                CreateResourceGroup(context, rgName);
                Cluster cluster = CreateCluster(context, rgName, clusterName);
                Assert.NotNull(cluster);
                ArcSetting arcSetting = CreateArcSetting(context, rgName, clusterName);
                Assert.NotNull(arcSetting);
                Extension extension = CreateExtension(context, rgName, clusterName);

                DeleteExtension(context, rgName, clusterName);
                AssertNoExtension(context, rgName, clusterName);
                DeleteArcSetting(context, rgName, clusterName);
                AssertNoArcSetting(context, rgName, clusterName);
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
                    Location = location
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
                new Cluster(location: location, aadClientId: "104a5669-0106-4718-9e06-c69f5a881d86", aadTenantId: "c76bd4d1-bea3-45ea-be1b-4a745a675d07")
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

        private ArcSetting CreateArcSetting(MockContext context, string rgName, string clusterName)
        {
            AzureStackHCIClient client = GetAzureStackHCIClient(context);
            return client.ArcSettings.Create(
                rgName,
                clusterName,
                arcSettingName,
                new ArcSetting()
            );
        }

        private void DeleteArcSetting(MockContext context, string rgName, string clusterName)
        {
            AzureStackHCIClient client = GetAzureStackHCIClient(context);
            client.ArcSettings.Delete(rgName, clusterName, arcSettingName);
        }

        private void AssertNoArcSetting(MockContext context, string rgName, string clusterName)
        {
            IPage<ArcSetting> arcSettings = ListArcSettings(context, rgName, clusterName);
            Assert.Null(arcSettings.GetEnumerator().Current);
        }

        private IPage<ArcSetting> ListArcSettings(MockContext context, string rgName, string clusterName)
        {
            AzureStackHCIClient client = GetAzureStackHCIClient(context);
            return client.ArcSettings.ListByCluster(rgName, clusterName);
        }

        private Extension CreateExtension(MockContext context, string rgName, string clusterName)
        {
            AzureStackHCIClient client = GetAzureStackHCIClient(context);
            return client.Extensions.Create(
                rgName,
                clusterName,
                arcSettingName,
                extensionName,
                new Extension(settings: new Dictionary<string, string> { { "WorkspaceId", Guid.NewGuid().ToString() } })
            );
        }

        private void DeleteExtension(MockContext context, string rgName, string clusterName)
        {
            AzureStackHCIClient client = GetAzureStackHCIClient(context);
            client.Extensions.Delete(rgName, clusterName, arcSettingName, extensionName);
        }

        private void AssertNoExtension(MockContext context, string rgName, string clusterName)
        {
            IPage<Extension> extensions = ListExtensions(context, rgName, clusterName);
            Assert.Null(extensions.GetEnumerator().Current);
        }

        private IPage<Extension> ListExtensions(MockContext context, string rgName, string clusterName)
        {
            AzureStackHCIClient client = GetAzureStackHCIClient(context);
            return client.Extensions.ListByArcSetting(rgName, clusterName, arcSettingName);
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