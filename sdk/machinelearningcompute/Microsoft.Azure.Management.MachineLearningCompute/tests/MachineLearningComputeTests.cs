using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using Microsoft.Azure.Management.MachineLearningCompute;
using Xunit.Abstractions;
using Microsoft.Azure.Management.MachineLearningCompute.Models;
using System.Linq;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using System;

namespace MachineLearningCompute.Tests
{
    public class MachineLearningComputeTests : TestBase
    {
        private readonly ITestOutputHelper output;
        private const string testNamePrefix = "mlcrp-dotnet-test";

        public MachineLearningComputeTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void CreateCluster()
        {
            using (var context = MockContext.Start(this.GetType().Name))
            using (var testBase = new MachineLearningComputeTestBase(context, testNamePrefix + "-create"))
            {
                testBase.CreateResourceGroup();
                var createdCluster = testBase.CreateCluster();

                Assert.NotNull(createdCluster);
                Assert.Equal(OperationStatus.Succeeded, createdCluster.ProvisioningState);
            }
        }

        [Fact]
        public void CreateClusterWithoutOrchestatorProperties()
        {
            using (var context = MockContext.Start(this.GetType().Name))
            using (var testBase = new MachineLearningComputeTestBase(context, testNamePrefix + "-no-orch-prop"))
            {
                testBase.CreateResourceGroup();
                var createdCluster = testBase.CreateClusterWithoutOrchestratorProperties();

                Assert.NotNull(createdCluster);
                Assert.Equal(OperationStatus.Succeeded, createdCluster.ProvisioningState);
            }
        }

        [Fact]
        public void GetCluster()
        {
            using (var context = MockContext.Start(this.GetType().Name))
            using (var testBase = new MachineLearningComputeTestBase(context, testNamePrefix + "-get"))
            {
                var resourceGroup = testBase.CreateResourceGroup();
                var createdCluster = testBase.CreateCluster();
                var fetchedCluster = testBase.Client.OperationalizationClusters.Get(resourceGroup.Name, createdCluster.Name);

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
            using (var context = MockContext.Start(this.GetType().Name))
            using (var testBase = new MachineLearningComputeTestBase(context, testNamePrefix + "-keys"))
            {
                var resourceGroup = testBase.CreateResourceGroup();
                var createdCluster = testBase.CreateCluster();

                var keys = testBase.Client.OperationalizationClusters.ListKeys(resourceGroup.Name, createdCluster.Name);

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
            using (var context = MockContext.Start(this.GetType().Name))
            using (var testBase = new MachineLearningComputeTestBase(context, testNamePrefix + "-list-rg"))
            {
                var resourceGroup = testBase.CreateResourceGroup();
                var createdCluster = testBase.CreateCluster();

                var clusterNames = testBase.Client.OperationalizationClusters.ListByResourceGroup(resourceGroup.Name).Select(cluster => cluster.Name);

                Assert.Contains(createdCluster.Name, clusterNames);
            }
        }

        [Fact]
        public void ListClustersBySubscriptionId()
        {
            using (var context = MockContext.Start(this.GetType().Name))
            using (var testBase = new MachineLearningComputeTestBase(context, testNamePrefix + "-list-sub"))
            {
                var resourceGroup = testBase.CreateResourceGroup();
                var createdCluster = testBase.CreateCluster();

                var clusterNames = testBase.Client.OperationalizationClusters.ListBySubscriptionId().Select(cluster => cluster.Name);

                Assert.Contains(createdCluster.Name, clusterNames);
            }
        }

        [Fact]
        public void DeleteCluster()
        {
            using (var context = MockContext.Start(this.GetType().Name))
            using (var testBase = new MachineLearningComputeTestBase(context, testNamePrefix + "-delete"))
            {
                var resourceGroup = testBase.CreateResourceGroup();
                var createdCluster = testBase.CreateCluster();

                testBase.Client.OperationalizationClusters.Delete(resourceGroup.Name, createdCluster.Name);

                var exception = Assert.Throws<ErrorResponseWrapperException>(() => testBase.Client.OperationalizationClusters.Get(resourceGroup.Name, createdCluster.Name));

                Assert.Contains("NotFound", exception.Message);
            }
        }

        [Fact]
        public void CheckSystemServicesUpdatesAvailable()
        {
            using (var context = MockContext.Start(this.GetType().Name))
            using (var testBase = new MachineLearningComputeTestBase(context, testNamePrefix + "-checkupdate"))
            {
                var resourceGroup = testBase.CreateResourceGroup();
                var createdCluster = testBase.CreateCluster();

                var updateAvailables = testBase.Client.OperationalizationClusters.CheckSystemServicesUpdatesAvailable(resourceGroup.Name, createdCluster.Name);

                Assert.NotNull(updateAvailables);
            }
        }

        [Fact(Skip = "ReRecord due to CR change")]
        public void UpdateSystemServices()
        {
            using (var context = MockContext.Start(this.GetType().Name))
            using (var testBase = new MachineLearningComputeTestBase(context, testNamePrefix + "-update"))
            {
                var resourceGroup = testBase.CreateResourceGroup();
                var createdCluster = testBase.CreateCluster();

                var updateResponse = testBase.Client.OperationalizationClusters.UpdateSystemServices(resourceGroup.Name, createdCluster.Name);

                Assert.Equal(OperationStatus.Succeeded, updateResponse.UpdateStatus);
                Assert.NotNull(updateResponse.UpdateStartedOn);
                Assert.NotNull(updateResponse.UpdateCompletedOn);
            }
        }

        [Fact]
        public void DeleteAllResources()
        {
            using (var context = MockContext.Start(this.GetType().Name))
            using (var testBase = new MachineLearningComputeTestBase(context, testNamePrefix + "-deleteall"))
            {
                var resourceGroup = testBase.CreateResourceGroup();
                var createdCluster = testBase.CreateCluster(clusterType: "Local");

                var deleteResponse = testBase.Client.OperationalizationClusters.Delete(resourceGroup.Name, createdCluster.Name, deleteAll: true);

                Assert.False(testBase.ResourcesClient.ResourceGroups.CheckExistence(testBase.ManagedByResourceGroupName));
            }
        }
    }
}
