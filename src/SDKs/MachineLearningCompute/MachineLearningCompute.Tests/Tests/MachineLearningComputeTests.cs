using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using MachineLearningCompute.Tests.Helpers;
using Microsoft.Azure.Management.MachineLearningCompute;
using Xunit.Abstractions;
using Microsoft.Azure.Management.MachineLearningCompute.Models;
using System.Linq;

namespace MachineLearningCompute.Tests
{
    public class MachineLearningComputeTests
    {
        private readonly ITestOutputHelper output;
        private const string resourceGroupLocation = "East US 2";
        private const string resourceGroupNameRoot = "mlcrp-dotnet-client-test";
        private const string clusterNameRoot = "mlcrp-test";

        public MachineLearningComputeTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void CreateCluster()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var nameSuffix = "-create";
                var resourceGroupName = resourceGroupNameRoot + nameSuffix;
                var clusterName = clusterNameRoot + nameSuffix;

                var mlcrpMgmtClient = MachineLearningComputeManagementTestUtilities.GetMachineLearningComputeManagementClient(context);

                MachineLearningComputeManagementTestUtilities.CreateResourceGroup(context, resourceGroupName, resourceGroupLocation);
                var createdCluster = MachineLearningComputeManagementTestUtilities.CreateCluster(mlcrpMgmtClient, resourceGroupName, clusterName);

                Assert.NotNull(createdCluster);
                Assert.Equal(clusterName, createdCluster.Name);
            }
        }

        [Fact]
        public void GetCluster()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var nameSuffix = "-get";
                var resourceGroupName = resourceGroupNameRoot + nameSuffix;
                var clusterName = clusterNameRoot + nameSuffix;

                var mlcrpMgmtClient = MachineLearningComputeManagementTestUtilities.GetMachineLearningComputeManagementClient(context);

                MachineLearningComputeManagementTestUtilities.CreateResourceGroup(context, resourceGroupName, resourceGroupLocation);
                var createdCluster = MachineLearningComputeManagementTestUtilities.CreateCluster(mlcrpMgmtClient, resourceGroupName, clusterName);
                var fetchedCluster = mlcrpMgmtClient.OperationalizationClusters.Get(resourceGroupName, clusterName);

                Assert.NotNull(createdCluster);
                Assert.NotNull(fetchedCluster);

                Assert.Equal(createdCluster.Name, fetchedCluster.Name);
                Assert.Equal(createdCluster.Location, fetchedCluster.Location);
                Assert.Equal(createdCluster.ClusterType, fetchedCluster.ClusterType);
                Assert.Equal(createdCluster.Description, fetchedCluster.Description);
                Assert.Equal(createdCluster.ContainerService.OrchestratorType, fetchedCluster.ContainerService.OrchestratorType);
            }
        }

        [Fact]
        public void ListKeys()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var nameSuffix = "-keys";
                var resourceGroupName = resourceGroupNameRoot + nameSuffix;
                var clusterName = clusterNameRoot + nameSuffix;

                var mlcrpMgmtClient = MachineLearningComputeManagementTestUtilities.GetMachineLearningComputeManagementClient(context);

                MachineLearningComputeManagementTestUtilities.CreateResourceGroup(context, resourceGroupName, resourceGroupLocation);
                MachineLearningComputeManagementTestUtilities.CreateCluster(mlcrpMgmtClient, resourceGroupName, clusterName, "East US 2 EUAP", "temp cluster", "ACS", "Kubernetes");

                var keys = mlcrpMgmtClient.OperationalizationClusters.ListKeys(resourceGroupName, clusterName);

                Assert.NotNull(keys.StorageAccount.ResourceId);
                Assert.NotNull(keys.StorageAccount.PrimaryKey);
                Assert.NotNull(keys.StorageAccount.SecondaryKey);
                Assert.NotNull(keys.ContainerRegistry.LoginServer);
                Assert.NotNull(keys.ContainerRegistry.Password);
                Assert.NotNull(keys.ContainerRegistry.Password2);
                Assert.NotNull(keys.ContainerRegistry.Username);
                Assert.NotNull(keys.ContainerService.AcsKubeConfig);
                Assert.NotNull(keys.ContainerService.ImagePullSecretName);
            }
        }

        [Fact]
        public void ListClustersInResourceGroup()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var nameSuffix = "-list-rg";
                var resourceGroupName = resourceGroupNameRoot + nameSuffix;
                var clusterName = clusterNameRoot + nameSuffix;

                var mlcrpMgmtClient = MachineLearningComputeManagementTestUtilities.GetMachineLearningComputeManagementClient(context);
                MachineLearningComputeManagementTestUtilities.CreateResourceGroup(context, resourceGroupName, resourceGroupLocation);
                var createdCluster = MachineLearningComputeManagementTestUtilities.CreateCluster(mlcrpMgmtClient, resourceGroupName, clusterName);

                var clusterNames = mlcrpMgmtClient.OperationalizationClusters.ListByResourceGroup(resourceGroupName).Select(cluster => cluster.Name);

                Assert.True(clusterNames.Contains(createdCluster.Name));
            }
        }

        [Fact]
        public void ListClustersBySubscriptionId()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var nameSuffix = "-list-sub";
                var resourceGroupName = resourceGroupNameRoot + nameSuffix;
                var clusterName = clusterNameRoot + nameSuffix;

                var mlcrpMgmtClient = MachineLearningComputeManagementTestUtilities.GetMachineLearningComputeManagementClient(context);
                MachineLearningComputeManagementTestUtilities.CreateResourceGroup(context, resourceGroupName, resourceGroupLocation);
                var createdCluster = MachineLearningComputeManagementTestUtilities.CreateCluster(mlcrpMgmtClient, resourceGroupName, clusterName);

                var clusterNames = mlcrpMgmtClient.OperationalizationClusters.ListBySubscriptionId().Select(cluster => cluster.Name);

                Assert.True(clusterNames.Contains(createdCluster.Name));
            }
        }

        [Fact]
        public void DeleteCluster()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var nameSuffix = "-delete";
                var resourceGroupName = resourceGroupNameRoot + nameSuffix;
                var clusterName = clusterNameRoot + nameSuffix;

                var mlcrpMgmtClient = MachineLearningComputeManagementTestUtilities.GetMachineLearningComputeManagementClient(context);

                MachineLearningComputeManagementTestUtilities.CreateResourceGroup(context, resourceGroupName, resourceGroupLocation);
                var createdCluster = MachineLearningComputeManagementTestUtilities.CreateCluster(mlcrpMgmtClient, resourceGroupName, clusterName);

                mlcrpMgmtClient.OperationalizationClusters.Delete(resourceGroupName, createdCluster.Name);

                var exception = Assert.Throws<ErrorResponseWrapperException>(() => mlcrpMgmtClient.OperationalizationClusters.Get(resourceGroupName, createdCluster.Name));

                Assert.Contains("NotFound", exception.Message);
            }
        }

        [Fact]
        public void CheckSystemServicesUpdatesAvailable()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var nameSuffix = "-checkupdate";
                var resourceGroupName = resourceGroupNameRoot + nameSuffix;
                var clusterName = clusterNameRoot + nameSuffix;

                var mlcrpMgmtClient = MachineLearningComputeManagementTestUtilities.GetMachineLearningComputeManagementClient(context);

                MachineLearningComputeManagementTestUtilities.CreateResourceGroup(context, resourceGroupName, resourceGroupLocation);
                var createdCluster = MachineLearningComputeManagementTestUtilities.CreateCluster(mlcrpMgmtClient, resourceGroupName, clusterName);

                var updateAvailables = mlcrpMgmtClient.OperationalizationClusters.CheckSystemServicesUpdatesAvailable(resourceGroupName, clusterName);

                Assert.NotNull(updateAvailables);
            }
        }

        [Fact]
        public void UpdateSystemServices()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var nameSuffix = "-update";
                var resourceGroupName = resourceGroupNameRoot + nameSuffix;
                var clusterName = clusterNameRoot + nameSuffix;

                var mlcrpMgmtClient = MachineLearningComputeManagementTestUtilities.GetMachineLearningComputeManagementClient(context);

                MachineLearningComputeManagementTestUtilities.CreateResourceGroup(context, resourceGroupName, resourceGroupLocation);
                var createdCluster = MachineLearningComputeManagementTestUtilities.CreateCluster(mlcrpMgmtClient, resourceGroupName, clusterName);

                var updateResponse = mlcrpMgmtClient.OperationalizationClusters.UpdateSystemServices(resourceGroupName, clusterName);

                Assert.Equal("Succeeded", updateResponse.UpdateStatus);
                Assert.NotNull(updateResponse.UpdateStartedOn);
                Assert.NotNull(updateResponse.UpdateCompletedOn);
            }
        }
    }
}
