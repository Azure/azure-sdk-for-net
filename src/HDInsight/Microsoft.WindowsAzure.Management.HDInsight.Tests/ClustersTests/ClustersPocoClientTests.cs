namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.ClustersTests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.PocoClient;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.PocoClient.ClustersResource;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient.ClustersResource;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;

    [TestClass]
    public class ClustersPocoClientTests : ClustersTestsBase
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanCreatePocoClient()
        {
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, ClustersPocoClient.GetSchemaVersion(Capabilities));
            Assert.IsNotNull(restClient);

            using (var clustersPocoClient = new ClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient))
            {
                Assert.IsNotNull(clustersPocoClient);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanListCloudServicesEmpty()
        {
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, ClustersPocoClient.GetSchemaVersion(Capabilities));
            using (var clustersPocoClient = new ClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient))
            {
                var containersList = clustersPocoClient.ListContainers().Result;
                Assert.AreEqual(containersList.Count, 0);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanListCloudServices()
        {
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, ClustersPocoClient.GetSchemaVersion(Capabilities));
            using (var clustersPocoClient = new ClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient))
            {
                CreateCluster("testcluster1", "West US");
                CreateCluster("testcluster2", "West US");
                CreateCluster("testcluster3", "East US");
                var containersList = clustersPocoClient.ListContainers().Result;
                Assert.AreEqual(containersList.Count, 3);
                Assert.IsNotNull(containersList.SingleOrDefault(cluster => cluster.Name.Equals("testcluster1")));
                Assert.IsNotNull(containersList.SingleOrDefault(cluster => cluster.Name.Equals("testcluster2")));
                Assert.IsNotNull(containersList.SingleOrDefault(cluster => cluster.Name.Equals("testcluster3")));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanListCloudServicesWithDuplicateNames()
        {
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, ClustersPocoClient.GetSchemaVersion(Capabilities));
            using (var clustersPocoClient = new ClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient))
            {
                CreateCluster("testcluster1", "West US");
                CreateCluster("testcluster1", "East US");
                var containersList = clustersPocoClient.ListContainers().Result;
                Assert.AreEqual(containersList.Count, 2);
                Assert.IsNotNull(containersList.SingleOrDefault(cluster => cluster.Name.Equals("testcluster1") && cluster.Location.Equals("West US")));
                Assert.IsNotNull(containersList.SingleOrDefault(cluster => cluster.Name.Equals("testcluster1") && cluster.Location.Equals("East US")));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanGetCloudServicesWithDuplicateNames()
        {
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, ClustersPocoClient.GetSchemaVersion(Capabilities));
            using (var clustersPocoClient = new ClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient))
            {
                CreateCluster("testcluster1", "West US");
                CreateCluster("testcluster1", "East US");
                var containersList = clustersPocoClient.ListContainers().Result;
                Assert.AreEqual(containersList.Count, 2);
                // Now list cluster without region name and the first one should always be returned
                Assert.IsNotNull(clustersPocoClient.ListContainer("testcluster1"));
                Assert.IsNotNull(clustersPocoClient.ListContainer("testcluster1").Result.Location.Equals("West US"));
                // Now list cluster with region name 
                Assert.IsNotNull(clustersPocoClient.ListContainer("testcluster1", "West US"));
                Assert.IsNotNull(clustersPocoClient.ListContainer("testcluster1", "West US").Result.Location.Equals("West US"));
                Assert.IsNotNull(clustersPocoClient.ListContainer("testcluster1", "East US"));
                Assert.IsNotNull(clustersPocoClient.ListContainer("testcluster1", "East US").Result.Location.Equals("East US"));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanDeleteCloudServicesWithDuplicateNames()
        {
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, ClustersPocoClient.GetSchemaVersion(Capabilities));
            using (var clustersPocoClient = new ClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient))
            {
                CreateCluster("testcluster1", "West US");
                CreateCluster("testcluster1", "East US");
                var containersList = clustersPocoClient.ListContainers().Result;
                Assert.AreEqual(containersList.Count, 2);
                // Now delete cluster without region name and both should be deleted
                try
                {
                    clustersPocoClient.DeleteContainer("testcluster1").Wait();
                    Assert.Fail("Exception not thrown");
                }
                catch (AggregateException age)
                {
                    Assert.IsTrue(age.InnerException != null, "Inner exception is not null");
                    Assert.IsTrue(age.InnerException is InvalidOperationException, "Exception is not InvalidOperationException");
                    Assert.AreEqual("Multiple clusters found with dnsname 'testcluster1'. Please specify dnsname and location", age.InnerException.Message, "Message not as expected");
                }
                containersList = clustersPocoClient.ListContainers().Result;
                Assert.AreEqual(containersList.Count, 2);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanDeleteCloudServiceWithRegionWithDuplicateNames()
        {
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, ClustersPocoClient.GetSchemaVersion(Capabilities));
            using (var clustersPocoClient = new ClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient))
            {
                CreateCluster("testcluster1", "West US");
                CreateCluster("testcluster1", "East US");
                var containersList = clustersPocoClient.ListContainers().Result;
                Assert.AreEqual(containersList.Count, 2);
                // Now delete cluster without region name and both should be deleted
                clustersPocoClient.DeleteContainer("testcluster1", "West US");
                containersList = clustersPocoClient.ListContainers().Result;
                Assert.AreEqual(containersList.Count, 1);
                Assert.IsNotNull(clustersPocoClient.ListContainer("testcluster1", "East US"));
                Assert.IsNotNull(clustersPocoClient.ListContainer("testcluster1", "East US").Result.Location.Equals("East US"));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(NotSupportedException))]
        public async Task CannotDeserializeClusterWithoutClusterCapability()
        {
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, ClustersPocoClient.GetSchemaVersion(Capabilities));
            var clustersPocoClient = new ClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient);
            CreateClusterWithoutCapability("testcluster", "West US");
            var cluster = clustersPocoClient.ListContainer("testcluster").Result;
            var originalInstanceCount = cluster.ClusterSizeInNodes;
            var expectedNewCount = originalInstanceCount * 2;
            Assert.AreEqual(cluster.ClusterSizeInNodes, originalInstanceCount);
            await clustersPocoClient.ChangeClusterSize("testcluster", cluster.Location, expectedNewCount);
            cluster = clustersPocoClient.ListContainer("testcluster").Result;
            var actualNewCount = cluster.ClusterSizeInNodes;
            Assert.AreEqual(expectedNewCount, actualNewCount);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public async Task CanResizeCluster()
        {
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, ClustersPocoClient.GetSchemaVersion(Capabilities));
            var clustersPocoClient = new ClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient);
            CreateCluster("testcluster", "West US");
            var cluster = clustersPocoClient.ListContainer("testcluster").Result;
            var originalInstanceCount = cluster.ClusterSizeInNodes;
            var expectedNewCount = originalInstanceCount * 2;
            Assert.AreEqual(cluster.ClusterSizeInNodes, originalInstanceCount);
            await clustersPocoClient.ChangeClusterSize("testcluster", cluster.Location, expectedNewCount);
            cluster = clustersPocoClient.ListContainer("testcluster").Result;
            var actualNewCount = cluster.ClusterSizeInNodes;
            Assert.AreEqual(expectedNewCount, actualNewCount);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public async Task ResizeToSameSizeReturnsEmptyGuidOperationId()
        {
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, ClustersPocoClient.GetSchemaVersion(Capabilities));
            var clustersPocoClient = new ClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient);
            CreateCluster("testcluster", "West US");
            var cluster = clustersPocoClient.ListContainer("testcluster").Result;
            var originalInstanceCount = cluster.ClusterSizeInNodes;

            var operationId = await clustersPocoClient.ChangeClusterSize("testcluster", cluster.Location, originalInstanceCount);
            Assert.AreEqual(operationId, Guid.Empty);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public async Task CannotResizeClusterWithoutCapability()
        {
            var capabilities = new List<string>();
            capabilities.Add("CAPABILITY_FEATURE_CLUSTERS_CONTRACT_1_SDK");
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, ClustersPocoClient.GetSchemaVersion(capabilities));
            var clustersPocoClient = new ClustersPocoClient(this.HdInsightCertCred, false, this.Context, capabilities, restClient);
            CreateCluster("testcluster", "West US");
            try
            {
                await clustersPocoClient.ChangeClusterSize("testcluster", "West US", 100);
            }
            catch (NotSupportedException ex)
            {
                Assert.IsNotNull(ex);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public async Task CannotResizeClusterToLessThanOne()
        {
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, ClustersPocoClient.GetSchemaVersion(Capabilities));
            var clustersPocoClient = new ClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient);
            CreateCluster("testcluster", "West US");
            var cluster = clustersPocoClient.ListContainer("testcluster").Result;
            var originalInstanceCount = cluster.ClusterSizeInNodes;
            Assert.AreEqual(cluster.ClusterSizeInNodes, originalInstanceCount);
            try
            {
                await clustersPocoClient.ChangeClusterSize("testcluster", cluster.Location, 0);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsNotNull(ex);
                Assert.AreEqual(ex.ParamName, "newSize");
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public async Task CannotCreateCustomizedClusterWithoutCapability()
        {
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, ClustersPocoClient.GetSchemaVersion(Capabilities));
            var clustersPocoClient = new ClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient);
            try
            {
                var clusterCreateParameters = new HDInsight.ClusterCreateParameters
                {
                    Name = "ConfigActionTest",
                    DefaultStorageAccountKey = IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Key,
                    DefaultStorageAccountName = IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Name,
                    DefaultStorageContainer = "ConfigActionTest",
                    ClusterSizeInNodes = 2,
                    Location = "East US",
                    UserName = "hdinsightuser",
                    Password = "Password1!",
                    Version = "3.1"
                };

                // Add in valid config action.
                clusterCreateParameters.ConfigActions.Add(new ScriptAction("TestScriptAction", new ClusterNodeType[] { ClusterNodeType.HeadNode }, new Uri("http://www.microsoft.com"), null));

                await clustersPocoClient.CreateContainer(clusterCreateParameters);
            }
            catch (NotSupportedException ex)
            {
                Assert.IsNotNull(ex);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ShouldSendClusterConfigActionWithCorrectCapabilities()
        {
            var capabilities = new[] { "CAPABILITY_FEATURE_CLUSTERS_CONTRACT_1_SDK", "CAPABILITY_FEATURE_CLUSTERS_CONTRACT_2_SDK", "CAPABILITY_FEATURE_POWERSHELL_SCRIPT_ACTION_SDK" };
            Assert.IsTrue(ClustersPocoClient.HasCorrectSchemaVersionForConfigAction(capabilities) && ClustersPocoClient.HasClusterConfigActionCapability(capabilities));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ShouldNotSendClusterConfigActionWithoutSchemaVersion2()
        {
            var capabilities = new[] { "CAPABILITY_FEATURE_CLUSTERS_CONTRACT_1_SDK", "CAPABILITY_FEATURE_POWERSHELL_SCRIPT_ACTION_SDK" };
            Assert.IsFalse(ClustersPocoClient.HasCorrectSchemaVersionForConfigAction(capabilities));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ShouldNotSendClusterConfigActionWithoutConfigActionCapability()
        {
            var capabilities = new[] { "CAPABILITY_FEATURE_CLUSTERS_CONTRACT_1_SDK", "CAPABILITY_FEATURE_CLUSTERS_CONTRACT_2_SDK" };
            Assert.IsFalse(ClustersPocoClient.HasClusterConfigActionCapability(capabilities));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public async Task CanAccessPublicUriUsingUriEndpointValidator()
        {
            await UriEndpointValidator.ValidateAndResolveHttpScriptActionEndpointUri(new Uri("http://www.microsoft.com"));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public async Task CanAccessWasbUriInStorageAccountUsingUriEndpointValidator()
        {
            var storageCreds = new WabStorageAccountConfiguration(
                IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Name,
                IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Key);

            var fullPathToContainer = new Uri(string.Format(
                CultureInfo.InvariantCulture,
                "{0}{1}@{2}/hive",
                Constants.WabsProtocolSchemeName,
                IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Container,
                UriEndpointValidator.GetFullyQualifiedStorageAccountName(
                    IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Name)));
            await UriEndpointValidator.ValidateAndResolveWasbScriptActionEndpointUri(fullPathToContainer, storageCreds);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public async Task CanAccessHttpUriInStorageAccountUsingUriEndpointValidator()
        {
            var storageCreds = new WabStorageAccountConfiguration(
                IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Name,
                IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Key);

            var fullPathToContainer = new Uri(string.Format(
                CultureInfo.InvariantCulture,
                "https://{0}/{1}/hive",
                UriEndpointValidator.GetFullyQualifiedStorageAccountName(
                    IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Name),
                IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Container));
            await UriEndpointValidator.ValidateAndResolveWasbScriptActionEndpointUri(fullPathToContainer, storageCreds);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task CannotAccessNonExistentPrivateUriInStorageAccountUsingUriEndpointValidator()
        {
            var storageCreds = new WabStorageAccountConfiguration(
                IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Name,
                IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Key);

            string fullPathToContainer = string.Format(
                "https://{0}/{1}/thisblobshouldnotexist",
                UriEndpointValidator.GetFullyQualifiedStorageAccountName(
                    IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Name),
                IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Container);

            await UriEndpointValidator.ValidateAndResolveWasbScriptActionEndpointUri(new Uri(fullPathToContainer), storageCreds);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task CannotAccessNonExistentPublicUriUsingUriEndpointValidator()
        {
            await UriEndpointValidator.ValidateAndResolveHttpScriptActionEndpointUri(new Uri("http://www.thisurishouldnotexist.mytest"));
        }
    }
}
