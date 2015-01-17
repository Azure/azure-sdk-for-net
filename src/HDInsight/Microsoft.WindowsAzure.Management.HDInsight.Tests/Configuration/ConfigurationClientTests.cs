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
namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.Configuration
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.Configuration;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;

    [TestClass]
    public class ConfigurationClientTests : IntegrationTestBase
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
        [TestCategory("Integration")]
        [TestCategory("Manual")]
        public async Task CanDownloadComponentAddresses()
        {
            var remoteCreds = GetRemoteCredentials();
            var ambariClient = new AzureHDInsightClusterConfigurationAccessor(remoteCreds);
            var componentSettingsAddress = await ambariClient.GetComponentSettingAddress();
            Assert.IsNotNull(componentSettingsAddress);
            Assert.IsNotNull(componentSettingsAddress.Core);
            Assert.IsNotNull(componentSettingsAddress.Hdfs);
            Assert.IsNotNull(componentSettingsAddress.MapReduce);
            Assert.IsNotNull(componentSettingsAddress.Hive);
            Assert.IsNotNull(componentSettingsAddress.Oozie);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("Manual")]
        public async Task CanDownloadCoreConfiguration()
        {
            var remoteCreds = GetRemoteCredentials();
            var ambariClient = new AzureHDInsightClusterConfigurationAccessor(remoteCreds);
            var coreConfiguration = await ambariClient.GetCoreServiceConfiguration();
            Assert.IsNotNull(coreConfiguration);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("Manual")]
        public async Task CanDownloadHdfsConfiguration()
        {
            var remoteCreds = GetRemoteCredentials();
            var ambariClient = new AzureHDInsightClusterConfigurationAccessor(remoteCreds);
            var coreConfiguration = await ambariClient.GetCoreServiceConfiguration();
            Assert.IsNotNull(coreConfiguration);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("Manual")]
        public async Task CanDownloadMapReduceConfiguration()
        {
            var remoteCreds = GetRemoteCredentials();
            var ambariClient = new AzureHDInsightClusterConfigurationAccessor(remoteCreds);
            var coreConfiguration = await ambariClient.GetMapReduceServiceConfiguration();
            Assert.IsNotNull(coreConfiguration);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("Manual")]
        public async Task CanDownloadHiveConfiguration()
        {
            var remoteCreds = GetRemoteCredentials();
            var ambariClient = new AzureHDInsightClusterConfigurationAccessor(remoteCreds);
            var coreConfiguration = await ambariClient.GetHiveServiceConfiguration();
            Assert.IsNotNull(coreConfiguration);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("Manual")]
        public async Task CanDownloadOozieConfiguration()
        {
            var remoteCreds = GetRemoteCredentials();
            var ambariClient = new AzureHDInsightClusterConfigurationAccessor(remoteCreds);
            var coreConfiguration = await ambariClient.GetOozieServiceConfiguration();
            Assert.IsNotNull(coreConfiguration);
        }

        private BasicAuthCredential GetRemoteCredentials()
        {
            var creds = IntegrationTestBase.GetValidCredentials();
            var client = Help.SafeCreate(() => new HDInsightClient(creds));
            var ambariV2Clusters = from cluster in client.ListClusters()
                                   where cluster.VersionNumber.Major >= 1 && cluster.VersionNumber.Minor >= 6
                                   select cluster;

            var testCluster = ambariV2Clusters.FirstOrDefault();
            Assert.IsNotNull(testCluster);
            return new BasicAuthCredential()
            {
                Server = new Uri(testCluster.Name),
                UserName = testCluster.HttpUserName,
                Password = testCluster.HttpPassword
            };
        }
    }
}
