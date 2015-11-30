// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.

namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.Scenario
{
    using System;
    using System.Collections.ObjectModel;
    using System.Data.SqlClient;
    using Microsoft.Hadoop.Hive;
    using Microsoft.WindowsAzure.Management.Framework;
    using Microsoft.WindowsAzure.Management.Framework.InversionOfControl;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient;
    
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Client;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities.RestSimulator;
    using Microsoft.WindowsAzure.Management.HDInsight.Tests.ConnectionCredentials;
    using Microsoft.WindowsAzure.Management.HDInsight.Tests.RestSimulator;

    [TestClass]
    public class SyncClientScenarioTests : IntegrationTestBase
    {
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }
        
        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Scenario")]
        [Timeout(30 * 1000)] // ms
        public void CreateDeleteContainer_SyncClientWithTimeouts()
        {
            // Creates the client
            IHDInsightCertificateConnectionCredentials credentials = IntegrationTestBase.GetValidCredentials();
            var client = new HDInsightSyncClient(credentials.SubscriptionId, credentials.Certificate);
            client.PollingInterval = TimeSpan.FromMilliseconds(100);
            TestValidAdvancedCluster(
                client.ListContainers,
                client.ListContainer,
                cluster => client.CreateContainer(cluster, TimeSpan.FromMinutes(25)),
                dnsName => client.DeleteContainer(dnsName, TimeSpan.FromMinutes(5)));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Scenario")]
        [Timeout(30 * 1000)] // ms
        public void CreateDeleteContainer_SyncClient()
        {
            // Creates the client
            IHDInsightCertificateConnectionCredentials credentials = IntegrationTestBase.GetValidCredentials();
            var client = new HDInsightSyncClient(credentials.SubscriptionId, credentials.Certificate);
            client.PollingInterval = TimeSpan.FromMilliseconds(100);
            TestValidAdvancedCluster(
                client.ListContainers,
                client.ListContainer,
                client.CreateContainer,
                client.DeleteContainer);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Scenario")]
        [Timeout(30 * 1000)] // ms
        public void CreateDeleteContainer_AsyncClient()
        {
            // Creates the client
            IHDInsightCertificateConnectionCredentials credentials = IntegrationTestBase.GetValidCredentials();
            var client = new ClusterProvisioningClient(credentials.SubscriptionId, credentials.Certificate);
            client.PollingInterval = TimeSpan.FromMilliseconds(100);

            TestValidAdvancedCluster(
                () => client.ListContainers().WaitForResult(),
                dnsName => client.ListContainer(dnsName).WaitForResult(),
                cluster => client.CreateContainer(cluster).WaitForResult(),
                dnsName => client.DeleteContainer(dnsName).WaitForResult());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Scenario")]
        [Timeout(30 * 1000)] // ms
        public void CreateDeleteContainer_BasicClusterAsyncClient()
        {
            // Creates the client
            IHDInsightCertificateConnectionCredentials credentials = IntegrationTestBase.GetValidCredentials();
            var client = new ClusterProvisioningClient(credentials.SubscriptionId, credentials.Certificate);
            client.PollingInterval = TimeSpan.FromMilliseconds(100);

            TestClusterEndToEnd(
                base.GetRandomCluster(),
                () => client.ListContainers().WaitForResult(),
                dnsName => client.ListContainer(dnsName).WaitForResult(),
                cluster => client.CreateContainer(cluster).WaitForResult(),
                dnsName => client.DeleteContainer(dnsName).WaitForResult());
        }

        [TestMethod]
        [TestCategory("Manual")]
        [TestCategory("Scenario")]
        [TestCategory("LongRunning")]
        [Timeout(30 * 60 * 1000)]  // ms
        public void CreateDeleteContainer_SyncClient_AgainstManualEnvironment()
        {
            // Dissables the simulator
            this.ApplyIndividualTestMockingOnly();

            // Sets the simulator
            var runManager = ServiceLocator.Instance.Locate<IServiceLocationIndividualTestManager>();
            runManager.Override<IConnectionCredentialsFactory>(new AlternativeEnvironmentConnectionCredentialsFactory());

            // Creates the client
            if (IntegrationTestBase.TestCredentials.AlternativeEnvironment == null)
                Assert.Inconclusive("Alternative Azure Endpoint wasn't set up");
            var client = new HDInsightSyncClient(
                IntegrationTestBase.TestCredentials.AlternativeEnvironment.SubscriptionId,
                IntegrationTestBase.GetValidCredentials().Certificate);
            client.PollingInterval = TimeSpan.FromSeconds(1);

            // Runs the test
            TestValidAdvancedCluster(
                client.ListContainers,
                client.ListContainer,
                client.CreateContainer,
                client.DeleteContainer);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Scenario")]
        [Timeout(30 * 1000)] // ms
        [ExpectedException(typeof(OperationCanceledException))]
        public void InvalidCreateDeleteContainer_FailsOnSdk_AgainstAzure()
        {
            this.ApplyIndividualTestMockingOnly();
            InvalidCreateDeleteContainer_FailsOnSdk();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Scenario")]
        [Timeout(30 * 1000)] // ms
        [ExpectedException(typeof(OperationCanceledException))]
        public void InvalidCreateDeleteContainer_FailsOnSdk()
        {            
            var clusterRequest = base.GetRandomCluster();
            clusterRequest.HiveMetastore = new ComponentMetastore(TestCredentials.HiveStores[0].SqlServer,
                                                           TestCredentials.HiveStores[0].Database,
                                                           TestCredentials.HiveStores[0].Username,
                                                           TestCredentials.HiveStores[0].Password);
            IHDInsightCertificateConnectionCredentials credentials = IntegrationTestBase.GetValidCredentials();
            var client = new ClusterProvisioningClient(credentials.SubscriptionId, credentials.Certificate);
            client.PollingInterval = TimeSpan.FromMilliseconds(100);

            TestClusterEndToEnd(
                clusterRequest,
                () => client.ListContainers().WaitForResult(),
                dnsName => client.ListContainer(dnsName).WaitForResult(),
                cluster => client.CreateContainer(cluster).WaitForResult(),
                dnsName => client.DeleteContainer(dnsName).WaitForResult());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Scenario")]
        [Timeout(30 * 1000)] // ms
        [ExpectedException(typeof(InvalidOperationException))]
        public void InvalidCreateDeleteContainer_FailsOnServer_AgainstAzure()
        {
            this.ApplyIndividualTestMockingOnly();
            InvalidCreateDeleteContainer_FailsOnServer();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Scenario")]
        [Timeout(30 * 1000)] // ms
        [ExpectedException(typeof(InvalidOperationException))]
        public void InvalidCreateDeleteContainer_FailsOnServer()
        {
            var clusterRequest = base.GetRandomCluster();
            clusterRequest.AsvAccounts.Add(new AsvAccountConfiguration("invalid", TestCredentials.AdditionalStorageAccounts[0].Key));

            IHDInsightCertificateConnectionCredentials credentials = IntegrationTestBase.GetValidCredentials();
            var client = new HDInsightSyncClient(credentials.SubscriptionId, credentials.Certificate);
            client.PollingInterval = TimeSpan.FromMilliseconds(100);

            TestClusterEndToEnd( 
                clusterRequest,
                client.ListContainers,
                client.ListContainer,
                client.CreateContainer,
                client.DeleteContainer);
        }
    
        private void TestValidAdvancedCluster(
            Func<Collection<ListClusterContainerResult>> getClusters,
            Func<string, ListClusterContainerResult> getCluster,
            Func<CreateClusterRequest, ListClusterContainerResult> createCluster,
            Action<string> deleteCluster)
        {
            // ClusterName
            var cluster = base.GetRandomCluster();
            cluster.AsvAccounts.Add(new AsvAccountConfiguration(TestCredentials.AdditionalStorageAccounts[0].Name, TestCredentials.AdditionalStorageAccounts[0].Key));
            cluster.OozieMetastore = new ComponentMetastore(TestCredentials.OozieStores[0].SqlServer,
                                                            TestCredentials.OozieStores[0].Database,
                                                            TestCredentials.OozieStores[0].Username,
                                                            TestCredentials.OozieStores[0].Password);
            cluster.HiveMetastore = new ComponentMetastore(TestCredentials.HiveStores[0].SqlServer,
                                                           TestCredentials.HiveStores[0].Database,
                                                           TestCredentials.HiveStores[0].Username,
                                                           TestCredentials.HiveStores[0].Password);

            this.TestClusterEndToEnd(cluster, getClusters, getCluster, createCluster, deleteCluster);
        }


        private void TestClusterEndToEnd(
            CreateClusterRequest cluster,
            Func<Collection<ListClusterContainerResult>> getClusters,
            Func<string, ListClusterContainerResult> getCluster,
            Func<CreateClusterRequest, ListClusterContainerResult> createCluster,
            Action<string> deleteCluster)
        {
            // Identifies if it needs to validate Metastores
            var restClientType = ServiceLocator.Instance.Locate<IHDInsightManagementRestClientFactory>().GetType();
            var validateMetastores = cluster.OozieMetastore != null && cluster.HiveMetastore != null &&
                                     restClientType != typeof(HDInsightManagementRestSimulatorClientFactory);

            //// Deletes previous metastore schema data
            //if (validateMetastores)
            //{
            //    DeleteAllTables(cluster.OozieMetastore);
            //    DeleteAllTables(cluster.HiveMetastore);
            //}

            //// Verifies it doesn't exist
            //var listResult = getClusters();
            //int matchingContainers = listResult.Count(container => container.DnsName.Equals(cluster.DnsName));
            //Assert.AreEqual(0, matchingContainers);

            cluster.DnsName = "clitest-pudev2-050100-106c62b3f1c644f4a5f747d428985547";
            cluster.ClusterUserPassword = "a5521F627F524ba980107894a8b47aE1forTest!";
            var result = getCluster(cluster.DnsName);

            //// Creates the cluster
            //var result = createCluster(cluster);
            //Assert.IsNotNull(result);
            //Assert.IsNotNull(getCluster(cluster.DnsName));

            // Validates the cluster
            var tableName = "newtable" + Guid.NewGuid().ToString("N");
            CreateTable(tableName, result.ConnectionUrl, cluster.ClusterUserName, cluster.ClusterUserPassword, cluster.DefaultAsvAccountName, cluster.DefaultAsvAccountKey);
            RunJob(tableName, result.ConnectionUrl, cluster.ClusterUserName, cluster.ClusterUserPassword, cluster.DefaultAsvAccountName, cluster.DefaultAsvAccountKey);
            if (validateMetastores)
            {
                Assert.AreNotEqual(0, GetTables(cluster.HiveMetastore).Count);
                Assert.AreNotEqual(0, GetTables(cluster.OozieMetastore).Count);
                ValidateTable(tableName, cluster.HiveMetastore);
            }

            // Deletes the cluster
            deleteCluster(cluster.DnsName);

            // Verifies it doesn't exist
            Assert.IsNull(getCluster(cluster.DnsName));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Helper method that creates a connection")]
        private SqlConnection CreateDbConnection(ComponentMetastore metastore)
        {
            SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder
            {
                DataSource = metastore.Server,
                InitialCatalog = metastore.Database,
                UserID = metastore.User,
                Password = metastore.Password,
                IntegratedSecurity = false,
            };

            var connection = new SqlConnection(connectionString.ConnectionString);
            connection.Open();
            return connection;
        }

        private Collection<string> GetTables(ComponentMetastore componentMetastore)
        {
            var tables = new Collection<string>();
             
            using (var connection = CreateDbConnection(componentMetastore))
            using (var command = new SqlCommand("select name from sys.objects where type = 'U'", connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    tables.Add(reader.GetString(0));
                }
            }

            return tables;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "Not Needed")]
        private void DeleteAllTables(ComponentMetastore componentMetastore)
        {
            var tables = this.GetTables(componentMetastore);
            using (var connection = CreateDbConnection(componentMetastore))
            {
                foreach (var table in tables)
                using (var command = new SqlCommand(string.Format("DROP TABLE {0}", table), connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void RunJob(string tableName, string clusterUrl, string username, string password, string storage, string key)
        {
            string command = string.Format(@"SELECT COUNT(*), column1 FROM {0} GROUP BY column1", tableName);
            using (var hiveConnection = new HiveConnection(new Uri(clusterUrl), username, password, storage, key))
            {
                hiveConnection.ExecuteHiveQuery(command).WaitForResult();
            }
        }

        
        private void CreateTable(string tableName, string clusterUrl, string username, string password, string storage, string key)
        {
            string command = string.Format(@"CREATE TABLE {0} (column1 STRING, column2 STRING, column3 STRING) STORED AS TEXTFILE", tableName);
            using (var hiveConnection = new HiveConnection(new Uri(clusterUrl), username, password, storage, key))
            {
                hiveConnection.ExecuteHiveQuery(command).WaitForResult();
            }
        }

        private void ValidateTable(string tableName, ComponentMetastore componentMetastore)
        {
            throw new NotImplementedException();
        }

        // Negative tests mocking the Create\List\Delete poco layers and making sure I don't get AggregateExceptions with WaitForResult or await

        // Negative tests mocking the Create\List\Delete poco layers and making sure I don't get AggregateExceptions

    }
}