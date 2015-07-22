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
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using Microsoft.Hadoop.Client;
    using Microsoft.Hadoop.Client.WebHCatRest;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.VersionFinder;

    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight.JobSubmission;
    using Microsoft.WindowsAzure.Management.HDInsight.JobSubmission.PocoClient;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities.RestSimulator;
    using Microsoft.WindowsAzure.Management.HDInsight.Tests.ConnectionCredentials;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;

    [TestClass]
    public class SyncClientScenarioTests : IntegrationTestBase
    {
        private const int AzureTestTimeout = 35 * 60 * 1000;
        private string customUserAgent = "SyncClient";

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
        [TestCategory(TestRunMode.CheckIn)]
        [TestCategory("Scenario")]
        [TestCategory("Defect(2, 1829869)")]
        public void CreatingAClusterThatDoesNotReturn200ButContinuesDoesNotEnterPolling()
        {
            var credentals = GetValidCredentials();
            var createClient = HDInsightClient.Connect(credentals);
            var createRequest = GetRandomCluster();
            createRequest.Name += "HttpErrorButCreateSucceeds";
            var createTask = createClient.CreateClusterAsync(createRequest);
            var result = createTask.WaitForResult();
        }

        [TestMethod]
        [TestCategory(TestRunMode.CheckIn)]
        [TestCategory("Scenario")]
        [TestCategory("Defect(2, 1829869)")]
        public void CreatingAClusterThatExceptsButContinuesDoesNotEnterPolling()
        {
            var credentals = GetValidCredentials();
            var createClient = HDInsightClient.Connect(credentals);
            var createRequest = GetRandomCluster();
            createRequest.Name += "NetworkExceptionButCreateSucceeds";
            var createTask = createClient.CreateClusterAsync(createRequest);
            var result = createTask.WaitForResult();
        }

        [TestMethod]
        [TestCategory(TestRunMode.CheckIn)]
        [TestCategory("Scenario")]
        [TestCategory("Defect(3, 1829645)")]
        public void DeleteAClusterWhileCreateIsPolling()
        {
            HDInsightManagementRestSimulatorClient.OperationTimeToCompletionInMilliseconds = 20000;
            var credentals = GetValidCredentials();
            var createClient = HDInsightClient.Connect(credentals);
            var deleteClient = HDInsightClient.Connect(credentals);
            var createRequest = GetRandomCluster();
            ClusterDetails cluster = null;
            createClient.ClusterProvisioning += (s, e) => cluster = e.Cluster;
            try
            {
                var createTask = createClient.CreateClusterAsync(createRequest);
                while (cluster == null)
                {
                    createTask.Wait(100);
                }
                deleteClient.DeleteCluster(createRequest.Name);
                createTask.WaitForResult();
            }
            catch (OperationCanceledException ex)
            {
                Assert.IsTrue(ex.Message.Contains("The cluster could not be found"), "The expected exception did not contain the correct string.");
            }
            finally
            {
                HDInsightManagementRestSimulatorClient.ResetConnectivityDefaultsAllClusters();
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ListAvailableLocations()
        {
            // Creates the client
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
            var locations = client.ListAvailableLocations();
            var locationsAsync = client.ListAvailableLocationsAsync().WaitForResult();
            Assert.IsTrue(locations.Contains("East US", StringComparer.Ordinal));
            Assert.IsTrue(locationsAsync.Contains("East US", StringComparer.Ordinal));
            Assert.AreEqual(locations.Count, locationsAsync.Count);
            foreach (var location in locations)
            {
                Assert.IsTrue(locationsAsync.Contains(location, StringComparer.Ordinal));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ListClustersFailsOnTimeout()
        {
            // Creates the client
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate), TimeSpan.FromSeconds(1), RetryPolicyFactory.CreateExponentialRetryPolicy(TimeSpan.FromMilliseconds(0), TimeSpan.FromSeconds(1), TimeSpan.FromMilliseconds(100), 2, 0.2));
            client.ListClusters();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ListClustersFailsOnSpecifiedTimeoutTooSmall()
        {
            // Creates the client
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate), TimeSpan.FromMilliseconds(0), RetryPolicyFactory.CreateExponentialRetryPolicy(TimeSpan.FromMilliseconds(0), TimeSpan.FromSeconds(1), TimeSpan.FromMilliseconds(100), 2, 0.2));
            client.ListClusters();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ListAvailableVersions()
        {
            // Creates the client
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
            var versions = client.ListAvailableVersions();
            var expectedVersions = VersionFinderClient.ParseVersions(IntegrationTestBase.TestCredentials.ResourceProviderProperties.Select(rp => new KeyValuePair<string, string>(rp.Key, rp.Value)));
            var versionsAsync = client.ListAvailableVersionsAsync().WaitForResult();
            foreach (var knownVersion in expectedVersions)
            {
                Assert.IsTrue(versions.Select(v => v.Version).Contains(knownVersion.Version, StringComparer.Ordinal));
            }

            Assert.AreEqual(versions.Count, versionsAsync.Count);
            foreach (var version in expectedVersions)
            {
                Assert.IsTrue(versionsAsync.Select(v => v.Version).Contains(version.Version, StringComparer.Ordinal));
            }
        }

        [TestMethod]
        [TestCategory("ApiSec")]
        [TestCategory(TestRunMode.CheckIn)]
        public void EnableHttpServices()
        {
            var testCluster = GetHttpAccessEnabledCluster(true);
            Assert.AreEqual(testCluster.HttpUserName, IntegrationTestBase.TestCredentials.AzureUserName);
            Assert.AreEqual(testCluster.HttpPassword, IntegrationTestBase.TestCredentials.AzurePassword);
        }

        [TestMethod]
        [TestCategory("ApiSec")]
        [TestCategory(TestRunMode.CheckIn)]
        public void EnableHttpServices_GetJobHistory()
        {
            var testCluster = GetHttpAccessEnabledCluster(false);
            var connectionCredentials = new BasicAuthCredential()
            {
                Server = new Uri(testCluster.ConnectionUrl),
                Password = testCluster.HttpPassword,
                UserName = testCluster.HttpUserName
            };
            var jobSubmissionClient = new HDInsightJobSubmissionPocoClient(connectionCredentials, GetAbstractionContext(), false, customUserAgent);
            var jobHistory = jobSubmissionClient.ListJobs().WaitForResult();
            var expectedJobHistory = SyncClientScenarioTests.GetJobHistory(connectionCredentials.Server.OriginalString);
            Assert.AreEqual(jobHistory.Jobs.Count, expectedJobHistory.Jobs.Count);
        }

        [TestMethod]
        [TestCategory("ApiSec")]
        [TestCategory(TestRunMode.CheckIn)]
        public void DisableHttpServices()
        {
            var testCluster = GetHttpAccessDisabledCluster();
            Assert.IsTrue(String.IsNullOrEmpty(testCluster.HttpUserName));
            Assert.IsTrue(String.IsNullOrEmpty(testCluster.HttpPassword));
        }

        [TestMethod]
        [TestCategory("ApiSec")]
        [TestCategory(TestRunMode.CheckIn)]
        [ExpectedException(typeof(UnauthorizedAccessException))]
        public void DisableHttpServices_GetJobHistory()
        {
            var testCluster = GetHttpAccessDisabledCluster();
            var connectionCredentials = new BasicAuthCredential()
            {
                Server = new Uri(testCluster.ConnectionUrl),
                Password = testCluster.HttpPassword,
                UserName = testCluster.HttpUserName
            };
            var jobSubmissionClient = new HDInsightJobSubmissionPocoClient(connectionCredentials, GetAbstractionContext(), false, customUserAgent);
            jobSubmissionClient.ListJobs().WaitForResult();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Scenario")]
        [Timeout(30 * 1000)] // ms
        public void CreateDeleteContainer_SyncClientWithTimeouts()
        {
            // Creates the client
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
            client.PollingInterval = TimeSpan.FromMilliseconds(100);
            TestValidAdvancedCluster(
                client.ListClusters,
                client.GetCluster,
                cluster => client.CreateCluster(cluster, TimeSpan.FromMinutes(25)),
                dnsName => client.DeleteCluster(dnsName, TimeSpan.FromMinutes(5)));
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Scenario")]
        [Timeout(30 * 1000)] // ms
        public void CreateDeleteContainer_SyncClient()
        {
            // Creates the client
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
            client.PollingInterval = TimeSpan.FromMilliseconds(100);
            TestValidAdvancedCluster(
                client.ListClusters,
                client.GetCluster,
                client.CreateCluster,
                client.DeleteCluster);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Scenario")]
        [Timeout(30 * 1000)] // ms
        public void CreateDeleteContainer_SyncClient_OldAPI()
        {
            // Creates the client
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
            client.PollingInterval = TimeSpan.FromMilliseconds(100);
            TestValidAdvancedClusterOldAPI(
                client.ListClusters,
                client.GetCluster,
#pragma warning disable 618
                client.CreateCluster,
#pragma warning restore 618
                client.DeleteCluster);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Scenario")]
        [Timeout(30 * 1000)] // ms
        public void CreateDeleteContainer_AsyncClient()
        {
            // Creates the client
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
            client.PollingInterval = TimeSpan.FromMilliseconds(100);

            TestValidAdvancedCluster(
                () => client.ListClustersAsync().WaitForResult(),
                dnsName => client.GetClusterAsync(dnsName).WaitForResult(),
                cluster => client.CreateClusterAsync(cluster).WaitForResult(),
                dnsName => client.DeleteClusterAsync(dnsName).WaitForResult());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Scenario")]
        [Timeout(30 * 1000)] // ms
        public void CreateDeleteContainer_AsyncClient_DeprecatedAPI()
        {
            // Creates the client
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
            client.PollingInterval = TimeSpan.FromMilliseconds(100);

            TestValidAdvancedClusterOldAPI(
                () => client.ListClustersAsync().WaitForResult(),
                dnsName => client.GetClusterAsync(dnsName).WaitForResult(),
#pragma warning disable 618
                cluster => client.CreateClusterAsync(cluster).WaitForResult(),
#pragma warning restore 618
                dnsName => client.DeleteClusterAsync(dnsName).WaitForResult());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Scenario")]
        [Timeout(30 * 1000)] // ms
        public void AttemptCreateContainerWhenClusterAlreadyExists_AsyncClient()
        {
            // Creates the client
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
            client.PollingInterval = TimeSpan.FromMilliseconds(100);

            ClusterCreateParametersV2 cluster = GetRandomCluster();
            cluster.DefaultStorageContainer = "thiscontainerdoesnotexist";
            client.CreateClusterAsync(cluster).WaitForResult();

            try
            {
                client.CreateCluster(cluster);
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual(
                    e.Message, string.Format("Cluster {0} already exists.", cluster.Name));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Scenario")]
        [Timeout(30 * 1000)] // ms
        public void CreateDeleteContainer_BasicClusterAsyncClient()
        {
            // Creates the client
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
            client.PollingInterval = TimeSpan.FromMilliseconds(100);

            TestClusterEndToEnd(
                GetRandomCluster(),
                () => client.ListClustersAsync().WaitForResult(),
                dnsName => client.GetClusterAsync(dnsName).WaitForResult(),
                cluster => client.CreateClusterAsync(cluster).WaitForResult(),
                dnsName => client.DeleteClusterAsync(dnsName).WaitForResult());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Scenario")]
        [Timeout(30 * 1000)] // ms
        public void CreateDeleteContainer_BasicClusterAsyncClient_DeprecatedAPI()
        {
            // Creates the client
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
            client.PollingInterval = TimeSpan.FromMilliseconds(100);

            TestClusterEndToEndOldAPI(
                GetRandomClusterOldSchema(),
                () => client.ListClustersAsync().WaitForResult(),
                dnsName => client.GetClusterAsync(dnsName).WaitForResult(),
#pragma warning disable 618
                cluster => client.CreateClusterAsync(cluster).WaitForResult(),
#pragma warning restore 618
                dnsName => client.DeleteClusterAsync(dnsName).WaitForResult());
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Scenario")]
        [Timeout(30 * 1000)] // ms
        public void ValidCreateDeleteContainerWithOnlyHiveMetastore_WorksOnSdk()
        {
            var clusterRequest = GetRandomCluster();
            clusterRequest.HiveMetastore = new Metastore(TestCredentials.Environments[0].HiveStores[0].SqlServer,
                                                           TestCredentials.Environments[0].HiveStores[0].Database,
                                                           TestCredentials.AzureUserName,
                                                           TestCredentials.AzurePassword);
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
            client.PollingInterval = TimeSpan.FromMilliseconds(100);

            try
            {
                TestClusterEndToEnd(
                    clusterRequest,
                    () => client.ListClustersAsync().WaitForResult(),
                    dnsName => client.GetClusterAsync(dnsName).WaitForResult(),
                    cluster => client.CreateClusterAsync(cluster).WaitForResult(),
                    dnsName => client.DeleteClusterAsync(dnsName).WaitForResult());
            }
            finally
            {
                if (client.GetCluster(clusterRequest.Name) != null)
                {
                    client.DeleteCluster(clusterRequest.Name);
                }
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Scenario")]
        [Timeout(30 * 1000)] // ms
        public void InvalidCreateDeleteContainer_FailsOnServer()
        {
            var clusterRequest = GetRandomCluster();
            clusterRequest.AdditionalStorageAccounts.Add(new WabStorageAccountConfiguration("invalid", null));

            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
            client.PollingInterval = TimeSpan.FromMilliseconds(100);

            try
            {
                TestClusterEndToEnd(clusterRequest, client.ListClusters, client.GetCluster, client.CreateCluster, client.DeleteCluster);
                Assert.Fail("Expected exception.");
            }
            catch (InvalidOperationException e)
            {
                Assert.IsNotNull(e.Message);
            }
            finally
            {
                if (client.GetCluster(clusterRequest.Name) != null)
                {
                    client.DeleteCluster(clusterRequest.Name);
                }
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Scenario")]
        [Timeout(30 * 1000)] // ms
        public void InvalidCreateDeleteContainer_UnknownState()
        {
            var clusterRequest = GetRandomCluster();
            clusterRequest.Name = "unknownclustername";
            clusterRequest.AdditionalStorageAccounts.Add(new WabStorageAccountConfiguration(TestCredentials.Environments[0].AdditionalStorageAccounts[0].Name, TestCredentials.Environments[0].AdditionalStorageAccounts[0].Key));

            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
            client.PollingInterval = TimeSpan.FromMilliseconds(100);

            client.CreateCluster(clusterRequest);
            var retCluster = client.GetCluster(clusterRequest.Name);
            Assert.AreEqual(retCluster.State, ClusterState.Unknown);
            client.DeleteCluster(clusterRequest.Name);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Scenario")]
        [Timeout(30 * 1000)] // ms
        public void InvalidCreateDeleteContainer_UnknownState_DeprecatedAPI()
        {
            var clusterRequest = GetRandomClusterOldSchema();
            clusterRequest.Name = "unknownclustername";
            clusterRequest.AdditionalStorageAccounts.Add(new WabStorageAccountConfiguration(TestCredentials.Environments[0].AdditionalStorageAccounts[0].Name, TestCredentials.Environments[0].AdditionalStorageAccounts[0].Key));

            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
            client.PollingInterval = TimeSpan.FromMilliseconds(100);

#pragma warning disable 618
            client.CreateCluster(clusterRequest);
#pragma warning restore 618
            var retCluster = client.GetCluster(clusterRequest.Name);
            Assert.AreEqual(retCluster.State, ClusterState.Unknown);
            client.DeleteCluster(clusterRequest.Name);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void EnableHttpAccess_VersionTooLow()
        {
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
            var clusterVersionTooLowClusters = from cluster in client.ListClusters()
                                               where cluster.VersionNumber < HDInsightSDKSupportedVersions.MinVersion
                                               select cluster;
            var clusterVersionTooLowCluster = clusterVersionTooLowClusters.FirstOrDefault();
            Assert.IsNotNull(clusterVersionTooLowCluster);

            try
            {
                client.EnableHttp(clusterVersionTooLowCluster.Name, clusterVersionTooLowCluster.Location, Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
            }
            catch (NotSupportedException c)
            {
                Assert.IsTrue(c.Message.Equals(String.Format(HDInsightConstants.ClusterVersionTooLowForClusterOperations, clusterVersionTooLowCluster.VersionNumber, HDInsightSDKSupportedVersions.MinVersion, HDInsightSDKSupportedVersions.MaxVersion)));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void EnableHttpAccess_VersionTooHigh()
        {
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
            var clusterVersionTooHighClusters = from cluster in client.ListClusters()
                                                where cluster.VersionNumber > HDInsightSDKSupportedVersions.MaxVersion
                                                select cluster;
            var clusterVersionTooHighCluster = clusterVersionTooHighClusters.FirstOrDefault();
            Assert.IsNotNull(clusterVersionTooHighCluster);

            try
            {
                client.EnableHttp(clusterVersionTooHighCluster.Name, clusterVersionTooHighCluster.Location, Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
            }
            catch (NotSupportedException c)
            {
                Assert.IsTrue(c.Message.Equals(String.Format(HDInsightConstants.ClusterVersionTooHighForClusterOperations, clusterVersionTooHighCluster.VersionNumber, HDInsightSDKSupportedVersions.MinVersion, HDInsightSDKSupportedVersions.MaxVersion)));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void EnableRdpAccess_ExpiryDateInPast()
        {
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
            var expiry = DateTime.Now.Subtract(TimeSpan.FromMilliseconds(1));
            try
            {
                client.EnableRdp("randomDnsName", "randomLocation", "randomRdpUsername", "randomRdpPassword",
                    DateTime.Now.Subtract(TimeSpan.FromMilliseconds(1)));
                throw new Exception("EnableRdp should have thrown");
            }
            catch (ArgumentOutOfRangeException c)
            {
                Assert.IsTrue(c.Message.Equals(string.Format("DateTime expiry needs to be sometime in future. Given expiry: {0}\r\nParameter name: expiry", expiry.ToString())));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CreateClusterWithNewVMSizes_VersionTooLow()
        {
            var clusterRequest = GetRandomCluster();
            Version version = new Version(3, 0);
            clusterRequest.Version = version.ToString();
            clusterRequest.DataNodeSize = "Medium";

            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
            try
            {
                client.CreateCluster(clusterRequest);
            }
            catch (InvalidOperationException ioex)
            {
                Assert.AreEqual(ioex.Message,
                    "Cannot use various VM sizes with cluster version '3.0'. Custom VM sizes are only supported for cluster versions 3.1 and above.");
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ListJobs_VersionTooLow()
        {
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
            var clusterVersionTooLowClusters = from cluster in client.ListClusters()
                                               where cluster.VersionNumber < HDInsightSDKSupportedVersions.MinVersion
                                               select cluster;
            var clusterVersionTooLowCluster = clusterVersionTooLowClusters.FirstOrDefault();
            Assert.IsNotNull(clusterVersionTooLowCluster);

            try
            {
                using (var jobsClient = new HDInsightHadoopClient(new JobSubmissionCertificateCredential(credentials.SubscriptionId,
                                                                                                            credentials.Certificate,
                                                                                                            clusterVersionTooLowCluster.Name)))
                {
                    jobsClient.ListJobs();
                }
            }
            catch (NotSupportedException c)
            {
                Assert.IsTrue(c.Message.Equals(String.Format(HDInsightConstants.ClusterVersionTooLowForJobSubmissionOperations, clusterVersionTooLowCluster.VersionNumber, HDInsightSDKSupportedVersions.MinVersion, HDInsightSDKSupportedVersions.MaxVersion)));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ListJobs_VersionTooHigh()
        {
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
            var clusterVersionTooHighClusters = from cluster in client.ListClusters()
                                                where cluster.VersionNumber > HDInsightSDKSupportedVersions.MaxVersion
                                                select cluster;
            var clusterVersionTooHighCluster = clusterVersionTooHighClusters.FirstOrDefault();
            Assert.IsNotNull(clusterVersionTooHighCluster);

            try
            {
                using (var jobsClient = new HDInsightHadoopClient(new JobSubmissionCertificateCredential(credentials.SubscriptionId,
                                                                                                            credentials.Certificate,
                                                                                                            clusterVersionTooHighCluster.Name)))
                {
                    jobsClient.ListJobs();
                }
            }
            catch (NotSupportedException c)
            {
                Assert.IsTrue(c.Message.Equals(String.Format(HDInsightConstants.ClusterVersionTooHighForJobSubmissionOperations, clusterVersionTooHighCluster.VersionNumber, HDInsightSDKSupportedVersions.MinVersion, HDInsightSDKSupportedVersions.MaxVersion)));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void DisableHttpAccess_VersionTooLow()
        {
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
            var clusterVersionTooLowClusters = from cluster in client.ListClusters()
                                               where cluster.VersionNumber < HDInsightSDKSupportedVersions.MinVersion
                                               select cluster;
            var clusterVersionTooLowCluster = clusterVersionTooLowClusters.FirstOrDefault();
            Assert.IsNotNull(clusterVersionTooLowCluster);

            try
            {
                client.DisableHttp(clusterVersionTooLowCluster.Name, clusterVersionTooLowCluster.Location);
            }
            catch (NotSupportedException c)
            {
                Assert.IsTrue(c.Message.Equals(String.Format(HDInsightConstants.ClusterVersionTooLowForClusterOperations, clusterVersionTooLowCluster.VersionNumber, HDInsightSDKSupportedVersions.MinVersion, HDInsightSDKSupportedVersions.MaxVersion)));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void DisableHttpAccess_VersionTooHigh()
        {
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
            var clusterVersionTooHighClusters = from cluster in client.ListClusters()
                                                where cluster.VersionNumber > HDInsightSDKSupportedVersions.MaxVersion
                                                select cluster;
            var clusterVersionTooHighCluster = clusterVersionTooHighClusters.FirstOrDefault();
            Assert.IsNotNull(clusterVersionTooHighCluster);

            try
            {
                client.DisableHttp(clusterVersionTooHighCluster.Name, clusterVersionTooHighCluster.Location);
            }
            catch (NotSupportedException c)
            {
                Assert.IsTrue(c.Message.Equals(String.Format(HDInsightConstants.ClusterVersionTooHighForClusterOperations, clusterVersionTooHighCluster.VersionNumber, HDInsightSDKSupportedVersions.MinVersion, HDInsightSDKSupportedVersions.MaxVersion)));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CreateCluster_VersionTooLow()
        {
            var clusterRequest = GetRandomCluster();
            Version version = new Version(HDInsightSDKSupportedVersions.MinVersion.Major, HDInsightSDKSupportedVersions.MinVersion.Minor - 1);
            clusterRequest.Version = version.ToString();
            clusterRequest.AdditionalStorageAccounts.Add(new WabStorageAccountConfiguration("invalid", TestCredentials.Environments[0].AdditionalStorageAccounts[0].Key));
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
            try
            {
                client.CreateCluster(clusterRequest);
            }
            catch (Exception c)
            {
                Assert.IsTrue(c.Message.Equals(String.Format(HDInsightConstants.ClusterVersionTooLowForClusterOperations, version, HDInsightSDKSupportedVersions.MinVersion, HDInsightSDKSupportedVersions.MaxVersion)));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void SubmitJobs_ClusterVersionTooLow()
        {
            var clusterRequest = GetRandomCluster();
            Version version = new Version(HDInsightSDKSupportedVersions.MinVersion.Major, HDInsightSDKSupportedVersions.MinVersion.Minor - 1);
            clusterRequest.Version = version.ToString();
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
            try
            {
                client.CreateCluster(clusterRequest);
            }
            catch (Exception c)
            {
                Assert.IsTrue(c.Message.Equals(String.Format(HDInsightConstants.ClusterVersionTooLowForClusterOperations, version, HDInsightSDKSupportedVersions.MinVersion, HDInsightSDKSupportedVersions.MaxVersion)));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CreateCluster_VersionTooHigh()
        {
            var clusterRequest = GetRandomCluster();
            Version version = new Version(HDInsightSDKSupportedVersions.MaxVersion.Major, HDInsightSDKSupportedVersions.MaxVersion.Minor + 1);
            clusterRequest.Version = version.ToString();
            clusterRequest.AdditionalStorageAccounts.Add(new WabStorageAccountConfiguration("invalid", TestCredentials.Environments[0].AdditionalStorageAccounts[0].Key));
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
            try
            {
                client.CreateCluster(clusterRequest);
            }
            catch (Exception c)
            {
                Assert.IsTrue(c.Message.Equals(String.Format(HDInsightConstants.ClusterVersionTooHighForClusterOperations, version, HDInsightSDKSupportedVersions.MinVersion, HDInsightSDKSupportedVersions.MaxVersion)));
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CreateCluster_VersionValid()
        {
            var clusterRequest = GetRandomCluster();
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
            client.CreateCluster(clusterRequest);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CreateCluster_VersionValid_DeprecatedAPI()
        {
            var clusterRequest = GetRandomClusterOldSchema();
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
#pragma warning disable 618
            client.CreateCluster(clusterRequest);
#pragma warning restore 618
        }
        
        [TestMethod]
        [TestCategory("CheckIn")]
        public void CreateCluster_RaisesEvents()
        {
            var clusterRequest = GetRandomCluster();
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
            bool acceptedEventFired = false;
            bool hdConfigurationEventFired = false;
            bool clusterStorageProvisionedEventFired = false;
            bool azureConfigurationEventFired = false;
            bool operationalEventFired = false;
            client.ClusterProvisioning += (sender, args) =>
            {
                acceptedEventFired = acceptedEventFired || args.State == ClusterState.Accepted;
                clusterStorageProvisionedEventFired = clusterStorageProvisionedEventFired || args.State == ClusterState.ClusterStorageProvisioned;
                azureConfigurationEventFired = azureConfigurationEventFired || args.State == ClusterState.AzureVMConfiguration;
                hdConfigurationEventFired = hdConfigurationEventFired || args.State == ClusterState.HDInsightConfiguration;
                operationalEventFired = operationalEventFired || args.State == ClusterState.Operational;
            };

            client.CreateCluster(clusterRequest);

            Assert.IsTrue(acceptedEventFired);
            Assert.IsTrue(clusterStorageProvisionedEventFired);
            Assert.IsTrue(azureConfigurationEventFired);
            Assert.IsTrue(hdConfigurationEventFired);
            Assert.IsTrue(operationalEventFired);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CreateCluster_DoesnotRaisesInvalidEvents()
        {
            var clusterRequest = GetRandomCluster();
            IHDInsightCertificateCredential credentials = IntegrationTestBase.GetValidCredentials();
            var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
            bool otherEventsRaised = false;

            client.ClusterProvisioning += (sender, args) =>
            {
                otherEventsRaised = otherEventsRaised ||
                                     (args.State != ClusterState.Accepted &&
                                     args.State != ClusterState.ClusterStorageProvisioned &&
                                     args.State != ClusterState.AzureVMConfiguration &&
                                     args.State != ClusterState.HDInsightConfiguration &&
                                     args.State != ClusterState.Operational &&
                                     args.State != ClusterState.PatchQueued &&
                                     args.State != ClusterState.CertRolloverQueued);
            };

            client.CreateCluster(clusterRequest);
            Assert.IsFalse(otherEventsRaised);
        }

        [TestMethod]
        [TestCategory("Scenario")]
        public void ValidMapReduceJobSubmissionTest()
        {
            var remoteConnectionCredentials = new BasicAuthCredential()
            {
                UserName = IntegrationTestBase.TestCredentials.AzureUserName,
                Password = IntegrationTestBase.TestCredentials.AzurePassword,
                Server = new Uri(IntegrationTestBase.TestCredentials.WellKnownCluster.Cluster)
            };

            var hadoopClient = JobSubmissionClientFactory.Connect(remoteConnectionCredentials);
            var mapReduceJob = new MapReduceJobCreateParameters()
            {
                ClassName = "pi",
                JobName = "pi estimation jobDetails",
                JarFile = "/example/hadoop-examples.jar",
                StatusFolder = "/piresults"
            };

            mapReduceJob.Arguments.Add("16");
            mapReduceJob.Arguments.Add("10000");
            var jobCreationDetails = hadoopClient.CreateMapReduceJob(mapReduceJob);
            Assert.IsNull(jobCreationDetails.ErrorCode, "Should not fail mr jobDetails submission");
            Assert.IsNotNull(jobCreationDetails.JobId, "Should have a non-null jobDetails id");
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Scenario")]
        [TestCategory("Defect")]
        public void PayloadConverterFailsToParseCreateTableResponse()
        {
            string createTableJsonResponse =
                "{\"status\":{\"startTime\":1376594952660,\"jobPriority\":\"NORMAL\",\"jobID\":{\"jtIdentifier\":\"201307101453\",\"id\":189},\"runState\":2,\"jobId\":\"job_201307101453_0189\",\"username\":\"hadoop\",\"schedulingInfo\":\"1 running map tasks using 1 map slots. 0 additional slots reserved. 0 running reduce tasks using 0 reduce slots. 0 additional slots reserved.\",\"failureInfo\":\"NA\",\"jobACLs\":{},\"jobComplete\":true},\"profile\":{\"url\":\"http://localhost:50030/jobdetails.jsp?jobid=job_201307101453_0189\",\"user\":\"hadoop\",\"jobName\":\"TempletonControllerJob\",\"queueName\":\"joblauncher\",\"jobID\":{\"jtIdentifier\":\"201307101453\",\"id\":189},\"jobId\":\"job_201307101453_0189\",\"jobFile\":\"hdfs://localhost:8020/hadoop/hdfs/tmp/mapred/staging/hadoop/.staging/job_201307101453_0189/jobDetails.xml\"},\"id\":\"job_201307101453_0189\",\"parentId\":null,\"percentComplete\":null,\"exitValue\":0,\"user\":\"hadoop\",\"callback\":null,\"completed\":\"done\",\"userargs\":{\"statusdir\":\"/CreateTableOutput\",\"define\":[\"hdInsightJobName=CreateTable\"],\"arg\":[],\"files\":\"\",\"enablelog\":\"true\",\"execute\":\"CREATE EXTERNAL TABLE locationone (DateBP INT, Loc STRING, Coordinates STRING, Samples STRING, UserPlace STRING, Laboratory STRING) ROW FORMAT DELIMITED FIELDS TERMINATED BY '\\t' STORED AS TEXTFILE LOCATION '/locationone/';\",\"user.name\":\"hadoop\",\"file\":null,\"callback\":null}}";
            var converter = new Hadoop.Client.Data.PayloadConverter();
            var jobDetailsObject = converter.DeserializeJobDetails(createTableJsonResponse);
            Assert.AreEqual(jobDetailsObject.JobId, "job_201307101453_0189");
        }

        private void TestValidAdvancedCluster(Func<ICollection<ClusterDetails>> getClusters, Func<string, ClusterDetails> getCluster, Func<ClusterCreateParametersV2, ClusterDetails> createCluster, Action<string> deleteCluster)
        {
            // ClusterName
            var cluster = GetRandomCluster();
            cluster.AdditionalStorageAccounts.Add(new WabStorageAccountConfiguration(TestCredentials.Environments[0].AdditionalStorageAccounts[0].Name,
                                                                                  TestCredentials.Environments[0].AdditionalStorageAccounts[0].Key));
            cluster.OozieMetastore = new Metastore(TestCredentials.Environments[0].OozieStores[0].SqlServer,
                                                            TestCredentials.Environments[0].OozieStores[0].Database,
                                                            TestCredentials.AzureUserName,
                                                            TestCredentials.AzurePassword.Replace("-", ""));
            cluster.HiveMetastore = new Metastore(TestCredentials.Environments[0].HiveStores[0].SqlServer,
                                                           TestCredentials.Environments[0].HiveStores[0].Database,
                                                           TestCredentials.AzureUserName,
                                                           TestCredentials.AzurePassword.Replace("-", ""));

            this.TestClusterEndToEnd(cluster, getClusters, getCluster, createCluster, deleteCluster);
        }

        private void TestValidAdvancedClusterOldAPI(Func<ICollection<ClusterDetails>> getClusters, Func<string, ClusterDetails> getCluster, Func<ClusterCreateParameters, ClusterDetails> createCluster, Action<string> deleteCluster)
        {
            // ClusterName
            var cluster = GetRandomClusterOldSchema();
            cluster.AdditionalStorageAccounts.Add(new WabStorageAccountConfiguration(TestCredentials.Environments[0].AdditionalStorageAccounts[0].Name,
                                                                                  TestCredentials.Environments[0].AdditionalStorageAccounts[0].Key));
            cluster.OozieMetastore = new Metastore(TestCredentials.Environments[0].OozieStores[0].SqlServer,
                                                            TestCredentials.Environments[0].OozieStores[0].Database,
                                                            TestCredentials.AzureUserName,
                                                            TestCredentials.AzurePassword.Replace("-", ""));
            cluster.HiveMetastore = new Metastore(TestCredentials.Environments[0].HiveStores[0].SqlServer,
                                                           TestCredentials.Environments[0].HiveStores[0].Database,
                                                           TestCredentials.AzureUserName,
                                                           TestCredentials.AzurePassword.Replace("-", ""));

            this.TestClusterEndToEndOldAPI(cluster, getClusters, getCluster, createCluster, deleteCluster);
        }

        internal static ClusterDetails GetHttpAccessEnabledCluster()
        {
            return GetHttpAccessEnabledCluster(true);
        }

        private static volatile ClusterDetails httpEnabledCluster = null;
        private static object lockObject = new object();

        internal static ClusterDetails GetHttpAccessEnabledCluster(bool reEnable)
        {
            // creates the client
            if (httpEnabledCluster == null)
            {
                lock (lockObject)
                {
                    if (httpEnabledCluster == null)
                    {
                        var credentials = IntegrationTestBase.GetValidCredentials();
                        var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
                        var randomCluster = GetRandomCluster();
                        randomCluster.UserName = IntegrationTestBase.TestCredentials.AzureUserName;
                        randomCluster.Password = IntegrationTestBase.TestCredentials.AzurePassword;
                        httpEnabledCluster = client.CreateCluster(randomCluster);
                    }
                }
            }
            return httpEnabledCluster;
            //var clusters = client.ListClusters();
            //if (reEnable)
            //{
            //    var clusterWithHttpAccessDisabled = clusters.FirstOrDefault(cluster => string.IsNullOrEmpty(cluster.HttpUserName));
            //    if (clusterWithHttpAccessDisabled == null)
            //    {
            //        // if http access is enabled, disable it on the last cluster in the list.
            //        clusterWithHttpAccessDisabled = clusters.Last();
            //        client.DisableHttp(clusterWithHttpAccessDisabled.Name, clusterWithHttpAccessDisabled.Location);
            //    }

            //    client.EnableHttp(
            //        clusterWithHttpAccessDisabled.Name,
            //        clusterWithHttpAccessDisabled.Location,
            //        IntegrationTestBase.TestCredentials.AzureUserName,
            //        IntegrationTestBase.TestCredentials.AzurePassword);

            //    testCluster = client.GetCluster(clusterWithHttpAccessDisabled.Name);
            //}
            //else
            //{
            //    testCluster = clusters.FirstOrDefault(cluster => !string.IsNullOrEmpty(cluster.HttpUserName));
            //    if (testCluster == null)
            //    {
            //        testCluster = GetHttpAccessEnabledCluster(true);
            //    }
            //}

            //testCluster.ConnectionUrl = GatewayUriResolver.GetGatewayUri(testCluster.ConnectionUrl).AbsoluteUri;
            //Debug.WriteLine(string.Format("Searched for Http Enabled Cluster, Returning '{0}'", testCluster.Name));
            //return testCluster;
        }

        private static volatile ClusterDetails httpDisabledCluster = null;

        internal static ClusterDetails GetHttpAccessDisabledCluster()
        {
            if (httpDisabledCluster == null)
            {
                lock (lockObject)
                {
                    if (httpDisabledCluster == null)
                    {
                        var credentials = IntegrationTestBase.GetValidCredentials();
                        var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
                        var randomCluster = GetRandomCluster();
                        randomCluster.UserName = IntegrationTestBase.TestCredentials.AzureUserName;
                        randomCluster.Password = IntegrationTestBase.TestCredentials.AzurePassword;
                        var cluster = client.CreateCluster(randomCluster);
                        client.DisableHttp(cluster.Name, cluster.Location);
                        cluster = client.GetCluster(cluster.Name);
                        httpDisabledCluster = cluster;
                    }
                }
            }
            return httpDisabledCluster;
            // Creates the client
            //var credentials = IntegrationTestBase.GetValidCredentials();
            //var client = HDInsightClient.Connect(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));
            //client.DisableHttp(IntegrationTestBase.TestCredentials.WellKnownCluster.DnsName, IntegrationTestBase.TestCredentials.Environments[0].Location);
            //var testCluster = client.GetCluster(IntegrationTestBase.TestCredentials.WellKnownCluster.DnsName);
            //return testCluster;
        }

        private void TestClusterEndToEnd(ClusterCreateParametersV2 cluster, Func<ICollection<ClusterDetails>> getClusters, Func<string, ClusterDetails> getCluster, Func<ClusterCreateParametersV2, ClusterDetails> createCluster, Action<string> deleteCluster)
        {
            // TODO: DROP ALL THE TABLES IN THE METASTORE TABLES

            // Verifies it doesn't exist
            var listResult = getClusters();
            int matchingContainers = listResult.Count(container => container.Name.Equals(cluster.Name));
            Assert.AreEqual(0, matchingContainers);

            // Creates the cluster
            var result = createCluster(cluster);
            Assert.IsNotNull(result);
            Assert.IsNotNull(getCluster(cluster.Name));

            //validate that we get the storage accounts back from the service.
            var defaultStorageAccount = result.DefaultStorageAccount;
            Assert.IsNotNull(defaultStorageAccount, cluster.DefaultStorageAccountName);
            Assert.AreEqual(cluster.DefaultStorageAccountKey, defaultStorageAccount.Key);
            Assert.AreEqual(cluster.DefaultStorageContainer, defaultStorageAccount.Container);
            // TODO: USE HADOOP SDK TO LAUNCH A JOB USING BOTH STORAGE ACCOUNTS

            // TODO: QUERY SQL METASTORES TO SEE THAT THE DATABASES GOT INITIALIZED

            // Deletes the cluster
            deleteCluster(cluster.Name);

            // Verifies it doesn't exist
            Assert.IsNull(getCluster(cluster.Name));
        }

        private void TestClusterEndToEndOldAPI(ClusterCreateParameters cluster, Func<ICollection<ClusterDetails>> getClusters, Func<string, ClusterDetails> getCluster, Func<ClusterCreateParameters, ClusterDetails> createCluster, Action<string> deleteCluster)
        {
            // TODO: DROP ALL THE TABLES IN THE METASTORE TABLES

            // Verifies it doesn't exist
            var listResult = getClusters();
            int matchingContainers = listResult.Count(container => container.Name.Equals(cluster.Name));
            Assert.AreEqual(0, matchingContainers);

            // Creates the cluster
            var result = createCluster(cluster);
            Assert.IsNotNull(result);
            Assert.IsNotNull(getCluster(cluster.Name));

            //validate that we get the storage accounts back from the service.
            var defaultStorageAccount = result.DefaultStorageAccount;
            Assert.IsNotNull(defaultStorageAccount, cluster.DefaultStorageAccountName);
            Assert.AreEqual(cluster.DefaultStorageAccountKey, defaultStorageAccount.Key);
            Assert.AreEqual(cluster.DefaultStorageContainer, defaultStorageAccount.Container);
            // TODO: USE HADOOP SDK TO LAUNCH A JOB USING BOTH STORAGE ACCOUNTS

            // TODO: QUERY SQL METASTORES TO SEE THAT THE DATABASES GOT INITIALIZED

            // Deletes the cluster
            deleteCluster(cluster.Name);

            // Verifies it doesn't exist
            Assert.IsNull(getCluster(cluster.Name));
        }

        // Negative tests mocking the Create\List\Delete poco layers and making sure I don't get AggregateExceptions with WaitForResult or await

        // Negative tests mocking the Create\List\Delete poco layers and making sure I don't get AggregateExceptions

        internal static JobList GetJobHistory(string clusterEndpoint)
        {
            string clusterGatewayUri = JobSubmission.GatewayUriResolver.GetGatewayUri(clusterEndpoint).AbsoluteUri.ToUpperInvariant();
            var manager = ServiceLocator.Instance.Locate<IServiceLocationSimulationManager>();
            if (manager.MockingLevel == ServiceLocationMockingLevel.ApplyFullMocking)
            {
                if (HadoopJobSubmissionPocoSimulatorClientFactory.pocoSimulators.ContainsKey(clusterGatewayUri))
                {
                    return HadoopJobSubmissionPocoSimulatorClientFactory.pocoSimulators[clusterGatewayUri].ListJobs().WaitForResult();
                }
            }

            return new JobList()
            {
                ErrorCode = HttpStatusCode.NotFound.ToString()
            };
        }
    }
}