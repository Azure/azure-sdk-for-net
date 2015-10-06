using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data;

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
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.PocoClient.PaasClusters;
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
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, SchemaVersionUtils.GetSchemaVersion(Capabilities));

            Assert.IsNotNull(restClient);

            using (var paasClustersPocoClient = new PaasClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient))
            {
                Assert.IsNotNull(paasClustersPocoClient);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanListCloudServicesEmpty()
        {
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, SchemaVersionUtils.GetSchemaVersion(Capabilities));
            using (var paasClustersPocoClient = new PaasClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient))
            {
                var containersList = paasClustersPocoClient.ListContainers().Result;
                Assert.AreEqual(containersList.Count, 0);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanListCloudServices()
        {
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, SchemaVersionUtils.GetSchemaVersion(Capabilities));
            using (var paasClustersPocoClient = new PaasClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient))
            {
                CreateCluster("testcluster1", "West US");
                CreateCluster("testcluster2", "West US");
                CreateCluster("testcluster3", "East US");
                var containersList = paasClustersPocoClient.ListContainers().Result;
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
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, SchemaVersionUtils.GetSchemaVersion(Capabilities));
            using (var paasClustersPocoClient = new PaasClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient))
            {
                CreateCluster("testcluster1", "West US");
                CreateCluster("testcluster1", "East US");
                var containersList = paasClustersPocoClient.ListContainers().Result;
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
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, SchemaVersionUtils.GetSchemaVersion(Capabilities));
            using (var paasClustersPocoClient = new PaasClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient))
            {
                CreateCluster("testcluster1", "West US");
                CreateCluster("testcluster1", "East US");
                var containersList = paasClustersPocoClient.ListContainers().Result;
                Assert.AreEqual(containersList.Count, 2);
                // Now list cluster without region name and the first one should always be returned
                Assert.IsNotNull(paasClustersPocoClient.ListContainer("testcluster1"));
                Assert.IsNotNull(paasClustersPocoClient.ListContainer("testcluster1").Result.Location.Equals("West US"));
                // Now list cluster with region name 
                Assert.IsNotNull(paasClustersPocoClient.ListContainer("testcluster1", "West US"));
                Assert.IsNotNull(paasClustersPocoClient.ListContainer("testcluster1", "West US").Result.Location.Equals("West US"));
                Assert.IsNotNull(paasClustersPocoClient.ListContainer("testcluster1", "East US"));
                Assert.IsNotNull(paasClustersPocoClient.ListContainer("testcluster1", "East US").Result.Location.Equals("East US"));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanDeleteCloudServicesWithDuplicateNames()
        {
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, SchemaVersionUtils.GetSchemaVersion(Capabilities));
            using (var paasClustersPocoClient = new PaasClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient))
            {
                CreateCluster("testcluster1", "West US");
                CreateCluster("testcluster1", "East US");
                var containersList = paasClustersPocoClient.ListContainers().Result;
                Assert.AreEqual(containersList.Count, 2);
                // Now delete cluster without region name and both should be deleted
                try
                {
                    paasClustersPocoClient.DeleteContainer("testcluster1").Wait();
                    Assert.Fail("Exception not thrown");
                }
                catch (AggregateException age)
                {
                    Assert.IsTrue(age.InnerException != null, "Inner exception is not null");
                    Assert.IsTrue(age.InnerException is InvalidOperationException, "Exception is not InvalidOperationException");
                    Assert.AreEqual("Multiple clusters found with dnsname 'testcluster1'. Please specify dnsname and location", age.InnerException.Message, "Message not as expected");
                }
                containersList = paasClustersPocoClient.ListContainers().Result;
                Assert.AreEqual(containersList.Count, 2);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanDeleteCloudServiceWithRegionWithDuplicateNames()
        {
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, SchemaVersionUtils.GetSchemaVersion(Capabilities));
            using (var paasClustersPocoClient = new PaasClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient))
            {
                CreateCluster("testcluster1", "West US");
                CreateCluster("testcluster1", "East US");
                var containersList = paasClustersPocoClient.ListContainers().Result;
                Assert.AreEqual(containersList.Count, 2);
                // Now delete cluster without region name and both should be deleted
                paasClustersPocoClient.DeleteContainer("testcluster1", "West US");
                containersList = paasClustersPocoClient.ListContainers().Result;
                Assert.AreEqual(containersList.Count, 1);
                Assert.IsNotNull(paasClustersPocoClient.ListContainer("testcluster1", "East US"));
                Assert.IsNotNull(paasClustersPocoClient.ListContainer("testcluster1", "East US").Result.Location.Equals("East US"));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(NotSupportedException))]
        public async Task CannotDeserializeClusterWithoutClusterCapability()
        {
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, SchemaVersionUtils.GetSchemaVersion(Capabilities));
            var paasClustersPocoClient = new PaasClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient);
            CreateClusterWithoutCapability("testcluster", "West US");
            var cluster = paasClustersPocoClient.ListContainer("testcluster").Result;
            var originalInstanceCount = cluster.ClusterSizeInNodes;
            var expectedNewCount = originalInstanceCount * 2;
            Assert.AreEqual(cluster.ClusterSizeInNodes, originalInstanceCount);
            await paasClustersPocoClient.ChangeClusterSize("testcluster", cluster.Location, expectedNewCount);
            cluster = paasClustersPocoClient.ListContainer("testcluster").Result;
            var actualNewCount = cluster.ClusterSizeInNodes;
            Assert.AreEqual(expectedNewCount, actualNewCount);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public async Task CanEnableAndDisableRdpUser()
        {
            Capabilities.Add("CAPABILITY_FEATURE_CLUSTERS_CONTRACT_1_SDK");
            Capabilities.Add("CAPABILITY_FEATURE_CLUSTERS_CONTRACT_VERSION_3_SDK");
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, SchemaVersionUtils.GetSchemaVersion(Capabilities));
            var clusterDnsName = "rdpTestCluster";
            var clustersPocoClient = new PaasClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient);
            var clusterCreateParameters = new HDInsight.ClusterCreateParametersV2
            {
                Name = clusterDnsName,
                DefaultStorageAccountKey = IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Key,
                DefaultStorageAccountName = IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Name,
                DefaultStorageContainer = "EnableDisableRdpTest",
                ClusterSizeInNodes = 2,
                Location = "East US",
                UserName = "hdinsightuser",
                Password = "Password1!",
                Version = "3.1",
                ClusterType = ClusterType.Hadoop,
            };

            await clustersPocoClient.CreateContainer(clusterCreateParameters);
            var cluster = clustersPocoClient.ListContainer(clusterDnsName).Result;
            var rdpUsername = "testRdpUser";
            await clustersPocoClient.EnableRdp(clusterDnsName, cluster.Location, rdpUsername, "Had00p!123", DateTime.Now.AddHours(1));
            cluster = clustersPocoClient.ListContainer(clusterDnsName).Result;
            var actualRdpUserName = cluster.RdpUserName;
            Assert.AreEqual(rdpUsername, actualRdpUserName);
            await clustersPocoClient.DisableRdp(clusterDnsName, cluster.Location);
            cluster = clustersPocoClient.ListContainer(clusterDnsName).Result;
            Assert.IsNull(cluster.RdpUserName);
            await clustersPocoClient.DeleteContainer(cluster.Name, cluster.Location);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public async Task CanCreateRdpUserDuringClusterCreate()
        {
            Capabilities.Add("CAPABILITY_FEATURE_CLUSTERS_CONTRACT_1_SDK");
            Capabilities.Add("CAPABILITY_FEATURE_CLUSTERS_CONTRACT_VERSION_3_SDK");
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, SchemaVersionUtils.GetSchemaVersion(Capabilities));
            var clusterDnsName = "rdpTestCluster";
            var clustersPocoClient = new PaasClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient);
            var clusterCreateParameters = new HDInsight.ClusterCreateParametersV2
            {
                Name = clusterDnsName,
                DefaultStorageAccountKey = IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Key,
                DefaultStorageAccountName = IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Name,
                DefaultStorageContainer = "EnableDisableRdpTest",
                ClusterSizeInNodes = 2,
                Location = "East US",
                UserName = "hdinsightuser",
                Password = "Password1!",
                Version = "3.1",
                ClusterType = ClusterType.Hadoop,
                RdpUsername = "testRdpUser",
                RdpPassword = "Had00p!123",
                RdpAccessExpiry = DateTime.Now.AddDays(6)
            };
            await clustersPocoClient.CreateContainer(clusterCreateParameters);
            var cluster = clustersPocoClient.ListContainer(clusterDnsName).Result;
            var rdpUsername = "testRdpUser";
            var actualRdpUserName = cluster.RdpUserName;
            Assert.AreEqual(rdpUsername, actualRdpUserName);
            await clustersPocoClient.DisableRdp(clusterDnsName, cluster.Location);
            cluster = clustersPocoClient.ListContainer(clusterDnsName).Result;
            Assert.IsNull(cluster.RdpUserName);
            await clustersPocoClient.DeleteContainer(cluster.Name, cluster.Location);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public async Task CanCannotClusterCreateWithInvalidRdpCredentials()
        {
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, SchemaVersionUtils.GetSchemaVersion(Capabilities));
            var clusterDnsName = "rdpTestCluster";
            var clustersPocoClient = new PaasClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient);
            var clusterCreateParameters = new HDInsight.ClusterCreateParametersV2
            {
                Name = clusterDnsName,
                DefaultStorageAccountKey = IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Key,
                DefaultStorageAccountName = IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Name,
                DefaultStorageContainer = "EnableDisableRdpTest",
                ClusterSizeInNodes = 2,
                Location = "East US",
                UserName = "hdinsightuser",
                Password = "Password1!",
                Version = "3.1",
                ClusterType = ClusterType.Hadoop,
                RdpUsername = "",
                RdpPassword = "Had00p!123",
                RdpAccessExpiry = DateTime.Now.AddDays(6)
            };
            try
            {
                await clustersPocoClient.CreateContainer(clusterCreateParameters);
                throw new Exception("CreateContainer should have thrown an ArgumentException");
            }
            catch (ArgumentException exp)
            {
                Assert.AreEqual(exp.Message,
                    @"clusterCreateParameters.RdpUsername cannot be null or empty in case either RdpPassword or RdpAccessExpiry is specified
Parameter name: clusterCreateParameters");
            }
            clusterCreateParameters.RdpUsername = "rdpuser";
            clusterCreateParameters.RdpPassword = "";
            try
            {
                await clustersPocoClient.CreateContainer(clusterCreateParameters);
                throw new Exception("CreateContainer should have thrown an ArgumentException");
            }
            catch (ArgumentException exp)
            {
                Assert.AreEqual(exp.Message,
                    @"clusterCreateParameters.RdpPassword cannot be null or empty in case either RdpUsername or RdpAccessExpiry is specified
Parameter name: clusterCreateParameters");
            }
            clusterCreateParameters.RdpPassword = "Had00p!123";
            clusterCreateParameters.RdpAccessExpiry = null;
            try
            {
                await clustersPocoClient.CreateContainer(clusterCreateParameters);
                throw new Exception("CreateContainer should have thrown an ArgumentException");
            }
            catch (ArgumentException exp)
            {
                Assert.AreEqual(exp.Message,
                    @"clusterCreateParameters.RdpAccessExpiry cannot be null or empty in case either RdpUsername or RdpPassword is specified
Parameter name: clusterCreateParameters");
            }
            clusterCreateParameters.RdpAccessExpiry = DateTime.MinValue;
            try
            {
                await clustersPocoClient.CreateContainer(clusterCreateParameters);
                throw new Exception("CreateContainer should have thrown an ArgumentException");
            }
            catch (ArgumentException exp)
            {
                Assert.AreEqual(exp.Message,
                    @"clusterCreateParameters.RdpAccessExpiry should be a time in future.
Parameter name: clusterCreateParameters");
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public async Task CanResizeCluster()
        {
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, SchemaVersionUtils.GetSchemaVersion(Capabilities));
            var paasClustersPocoClient = new PaasClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient);
            CreateCluster("testcluster", "West US");
            var cluster = paasClustersPocoClient.ListContainer("testcluster").Result;
            var originalInstanceCount = cluster.ClusterSizeInNodes;
            var expectedNewCount = originalInstanceCount * 2;
            Assert.AreEqual(cluster.ClusterSizeInNodes, originalInstanceCount);
            await paasClustersPocoClient.ChangeClusterSize("testcluster", cluster.Location, expectedNewCount);
            cluster = paasClustersPocoClient.ListContainer("testcluster").Result;
            var actualNewCount = cluster.ClusterSizeInNodes;
            Assert.AreEqual(expectedNewCount, actualNewCount);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public async Task ResizeToSameSizeReturnsEmptyGuidOperationId()
        {
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, SchemaVersionUtils.GetSchemaVersion(Capabilities));
            var paasClustersPocoClient = new PaasClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient);
            CreateCluster("testcluster", "West US");
            var cluster = paasClustersPocoClient.ListContainer("testcluster").Result;
            var originalInstanceCount = cluster.ClusterSizeInNodes;

            var operationId = await paasClustersPocoClient.ChangeClusterSize("testcluster", cluster.Location, originalInstanceCount);
            Assert.AreEqual(operationId, Guid.Empty);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public async Task CannotResizeClusterWithoutCapability()
        {
            var capabilities = new List<string>();
            capabilities.Add("CAPABILITY_FEATURE_CLUSTERS_CONTRACT_1_SDK");
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, SchemaVersionUtils.GetSchemaVersion(capabilities));
            var paasClustersPocoClient = new PaasClustersPocoClient(this.HdInsightCertCred, false, this.Context, capabilities, restClient);
            CreateCluster("testcluster", "West US");
            try
            {
                await paasClustersPocoClient.ChangeClusterSize("testcluster", "West US", 100);
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
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, SchemaVersionUtils.GetSchemaVersion(Capabilities));
            var paasClustersPocoClient = new PaasClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient);
            CreateCluster("testcluster", "West US");
            var cluster = paasClustersPocoClient.ListContainer("testcluster").Result;
            var originalInstanceCount = cluster.ClusterSizeInNodes;
            Assert.AreEqual(cluster.ClusterSizeInNodes, originalInstanceCount);
            try
            {
                await paasClustersPocoClient.ChangeClusterSize("testcluster", cluster.Location, 0);
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
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, SchemaVersionUtils.GetSchemaVersion(Capabilities));
            var paasClustersPocoClient = new PaasClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient);
            try
            {
                var clusterCreateParameters = new HDInsight.ClusterCreateParametersV2
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

                await paasClustersPocoClient.CreateContainer(clusterCreateParameters);
            }
            catch (NotSupportedException ex)
            {
                Assert.IsNotNull(ex);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public async Task CanCreateSparkCluster()
        {
            Capabilities.Add("CAPABILITY_FEATURE_CLUSTERS_CONTRACT_1_SDK");
            Capabilities.Add("CAPABILITY_FEATURE_CLUSTERS_CONTRACT_VERSION_3_SDK");
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, SchemaVersionUtils.GetSchemaVersion(Capabilities));
            var clustersPocoClient = new PaasClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient);
            var clusterCreateParameters = new HDInsight.ClusterCreateParametersV2
            {
                Name = "SparkCreationTest",
                DefaultStorageAccountKey = IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Key,
                DefaultStorageAccountName = IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Name,
                DefaultStorageContainer = "SparkCreationTest",
                ClusterSizeInNodes = 2,
                Location = "East US",
                UserName = "hdinsightuser",
                Password = "Password1!",
                Version = "3.1",
                ClusterType = ClusterType.Spark,
            };

            await clustersPocoClient.CreateContainer(clusterCreateParameters);

            var containersList = clustersPocoClient.ListContainers().Result;
            Assert.AreEqual(containersList.Count, 1);
            Assert.IsNotNull(containersList.SingleOrDefault(cluster => cluster.Name.Equals("SparkCreationTest")));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public async Task CanCreateClusterWithHwxPrivateVersion()
        {
            Capabilities.Add("CAPABILITY_FEATURE_CLUSTERS_CONTRACT_1_SDK");
            Capabilities.Add("CAPABILITY_FEATURE_CLUSTERS_CONTRACT_VERSION_3_SDK");
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, SchemaVersionUtils.GetSchemaVersion(Capabilities));
            var clustersPocoClient = new PaasClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient);
            var clusterCreateParameters = new HDInsight.ClusterCreateParametersV2
            {
                Name = "HwxVersionTest",
                DefaultStorageAccountKey = IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Key,
                DefaultStorageAccountName = IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Name,
                DefaultStorageContainer = "HwxVersionTest",
                ClusterSizeInNodes = 2,
                Location = "East US",
                UserName = "hdinsightuser",
                Password = "Password1!",
                Version = "3.2-hwx-trunk",
                ClusterType = ClusterType.Hadoop,
            };

            await clustersPocoClient.CreateContainer(clusterCreateParameters);

            var containersList = clustersPocoClient.ListContainers().Result;
            Assert.AreEqual(containersList.Count, 1);
            Assert.IsNotNull(containersList.SingleOrDefault(cluster => cluster.Name.Equals("HwxVersionTest")));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public async Task ICanCreateACluster_WithNewVmSizes_Headnode_Specified()
        {
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                    .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, SchemaVersionUtils.GetSchemaVersion(Capabilities));
            var clustersPocoClient = new PaasClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient);
            try
            {
                var clusterCreateParameters = new HDInsight.ClusterCreateParametersV2
                {
                    Name = "ConfigActionTest",
                    DefaultStorageAccountKey = IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Key,
                    DefaultStorageAccountName = IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Name,
                    DefaultStorageContainer = "ConfigActionTest",
                    ClusterSizeInNodes = 2,
                    Location = "East US",
                    UserName = "hdinsightuser",
                    Password = "Password1!",
                    Version = "3.1",
                    HeadNodeSize = "A6",
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
        public async Task ICanCreateACluster_WithNewVmSizes_Datanode_Specified()
        {
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                     .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, SchemaVersionUtils.GetSchemaVersion(Capabilities));
            var clustersPocoClient = new PaasClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient);
            try
            {
                var clusterCreateParameters = new HDInsight.ClusterCreateParametersV2
                {
                    Name = "ConfigActionTest",
                    DefaultStorageAccountKey = IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Key,
                    DefaultStorageAccountName = IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Name,
                    DefaultStorageContainer = "ConfigActionTest",
                    ClusterSizeInNodes = 2,
                    Location = "East US",
                    UserName = "hdinsightuser",
                    Password = "Password1!",
                    Version = "3.1",
                    DataNodeSize = "A5",
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
        public async Task ICanCreateACluster_WithNewVmSizes_Zookeeper_Specified()
        {
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                    .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, SchemaVersionUtils.GetSchemaVersion(Capabilities));
            var clustersPocoClient = new PaasClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient);
            try
            {
                var clusterCreateParameters = new HDInsight.ClusterCreateParametersV2
                {
                    Name = "ConfigActionTest",
                    DefaultStorageAccountKey = IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Key,
                    DefaultStorageAccountName = IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Name,
                    DefaultStorageContainer = "ConfigActionTest",
                    ClusterSizeInNodes = 2,
                    Location = "East US",
                    UserName = "hdinsightuser",
                    Password = "Password1!",
                    Version = "3.1",
                    ZookeeperNodeSize = "Large",
                    ClusterType = ClusterType.HBase,
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
        public async Task ICanCreateACluster_WithNewVmSizes_All_Specified()
        {
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                     .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, SchemaVersionUtils.GetSchemaVersion(Capabilities));
            var clustersPocoClient = new PaasClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient);
            try
            {
                var clusterCreateParameters = new HDInsight.ClusterCreateParametersV2
                {
                    Name = "ConfigActionTest",
                    DefaultStorageAccountKey = IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Key,
                    DefaultStorageAccountName = IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Name,
                    DefaultStorageContainer = "ConfigActionTest",
                    ClusterSizeInNodes = 2,
                    Location = "East US",
                    UserName = "hdinsightuser",
                    Password = "Password1!",
                    Version = "3.1",
                    HeadNodeSize = "A6",
                    DataNodeSize = "A5",
                    ZookeeperNodeSize = "Large",
                    ClusterType = ClusterType.HBase,
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
        public async Task ICanCreateACluster_WithOldVmSizes_All_Specified()
        {
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                     .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, SchemaVersionUtils.GetSchemaVersion(Capabilities));
            var clustersPocoClient = new PaasClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient);
            try
            {
                var clusterCreateParameters = new HDInsight.ClusterCreateParametersV2
                {
                    Name = "ConfigActionTest",
                    DefaultStorageAccountKey = IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Key,
                    DefaultStorageAccountName = IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Name,
                    DefaultStorageContainer = "ConfigActionTest",
                    ClusterSizeInNodes = 2,
                    Location = "East US",
                    UserName = "hdinsightuser",
                    Password = "Password1!",
                    Version = "3.1",
                    HeadNodeSize = "ExtraLarge",
                    DataNodeSize = "Large",
                    ZookeeperNodeSize = "Medium",
                    ClusterType = ClusterType.HBase,
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
        public async Task ICanCreateACluster_WithVmSizes_All_Specified_NonHBase_Negative()
        {
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                     .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, SchemaVersionUtils.GetSchemaVersion(Capabilities));
            var clustersPocoClient = new PaasClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient);
            try
            {
                var clusterCreateParameters = new HDInsight.ClusterCreateParametersV2
                {
                    Name = "ConfigActionTest",
                    DefaultStorageAccountKey = IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Key,
                    DefaultStorageAccountName = IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Name,
                    DefaultStorageContainer = "ConfigActionTest",
                    ClusterSizeInNodes = 2,
                    Location = "East US",
                    UserName = "hdinsightuser",
                    Password = "Password1!",
                    Version = "3.1",
                    HeadNodeSize = "ExtraLarge",
                    DataNodeSize = "Large",
                    ZookeeperNodeSize = "Medium",
                    ClusterType = ClusterType.Spark,
                };

                // Add in valid config action.
                clusterCreateParameters.ConfigActions.Add(new ScriptAction("TestScriptAction", new ClusterNodeType[] { ClusterNodeType.HeadNode }, new Uri("http://www.microsoft.com"), null));

                await clustersPocoClient.CreateContainer(clusterCreateParameters);

                //this should not work for non hbase clusters
                Assert.Fail("Zookeeper node size should not be settable for non-hbase clusters");
            }
            catch (ArgumentException aex)
            {
                Assert.AreEqual(aex.Message,
                    "clusterCreateParameters.ZookeeperNodeSize must be null for Spark clusters.");
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ShouldSendClusterConfigActionWithCorrectCapabilities()
        {
            var capabilities = new[] { "CAPABILITY_FEATURE_CLUSTERS_CONTRACT_1_SDK", "CAPABILITY_FEATURE_CLUSTERS_CONTRACT_2_SDK", "CAPABILITY_FEATURE_POWERSHELL_SCRIPT_ACTION_SDK" };
            Assert.IsTrue(PaasClustersPocoClient.HasCorrectSchemaVersionForConfigAction(capabilities) && PaasClustersPocoClient.HasClusterConfigActionCapability(capabilities));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ShouldNotSendClusterConfigActionWithoutSchemaVersion2()
        {
            var capabilities = new[] { "CAPABILITY_FEATURE_CLUSTERS_CONTRACT_1_SDK", "CAPABILITY_FEATURE_POWERSHELL_SCRIPT_ACTION_SDK" };
            Assert.IsFalse(PaasClustersPocoClient.HasCorrectSchemaVersionForConfigAction(capabilities));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ShouldNotSendClusterConfigActionWithoutConfigActionCapability()
        {
            var capabilities = new[] { "CAPABILITY_FEATURE_CLUSTERS_CONTRACT_1_SDK", "CAPABILITY_FEATURE_CLUSTERS_CONTRACT_2_SDK" };
            Assert.IsFalse(PaasClustersPocoClient.HasClusterConfigActionCapability(capabilities));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public async Task CanAccessPublicUriUsingUriEndpointValidator()
        {
            await UriEndpointValidator.ValidateAndResolveHttpScriptActionEndpointUri(new Uri("http://www.microsoft.com"));
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

        [TestMethod]
        [TestCategory("CheckIn")]
        public async Task CanCreateIaasClusterWithD12Headnode()
        {
            var restClient = ServiceLocator.Instance.Locate<IRdfeClustersResourceRestClientFactory>()
                                                      .Create(this.DefaultHandler, this.HdInsightCertCred, this.Context, false, SchemaVersionUtils.GetSchemaVersion(Capabilities));
            var clustersPocoClient = new PaasClustersPocoClient(this.HdInsightCertCred, false, this.Context, Capabilities, restClient);
            var clusterCreateParameters = new HDInsight.ClusterCreateParametersV2
            {
                Name = "D12HeadnodeCreationTest",
                DefaultStorageAccountKey = IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Key,
                DefaultStorageAccountName = IntegrationTestBase.TestCredentials.Environments[0].DefaultStorageAccount.Name,
                DefaultStorageContainer = "D12HeadnodeCreationTest",
                ClusterSizeInNodes = 2,
                Location = "East US",
                UserName = "admin",
                Password = "Password1!",
                OSType = OSType.Linux,
                Version = "3.2",
                ClusterType = ClusterProvisioning.Data.ClusterType.Hadoop,
                HeadNodeSize = "Standard_D12"
            };

            await clustersPocoClient.CreateContainer(clusterCreateParameters);

            var containersList = clustersPocoClient.ListContainers().Result;
            Assert.AreEqual(containersList.Count, 1);
            Assert.IsNotNull(containersList.SingleOrDefault(cluster => cluster.Name.Equals("D12HeadnodeCreationTest")));
        }
    }
}
