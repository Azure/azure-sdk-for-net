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
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.PocoClient;

namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.HadoopClientTests
{
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.Hadoop.Client.WebHCatRest;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities.RestSimulator;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities.ServerDataObjects;

    [TestClass]
    public class DuplicateDnsNameTests : IntegrationTestBase
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

        internal IRetryPolicy GetRetryPolicy()
        {
            return RetryPolicyFactory.CreateExponentialRetryPolicy(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1), TimeSpan.FromMilliseconds(100), 3, 0.2);
        }
        

        [TestMethod]
        [TestCategory(TestRunMode.CheckIn)]
        [Timeout(20000)]
        public void ICanCreateClustersWithSameNameInDifferentRegionsAndDeleteThem()
        {
            // If this test fails due to a timeout then it means there is an infinite loop in the DeleteCluster
            // code path when 2 clusters with same DnsName in 2 different regions exists. Try to see if increasing the
            // timeout to 2 minutes helps else investigate the infinite wait.
            this.EnableHttpSpy();
            var credentials = GetValidCredentials();
            var client = ServiceLocator.Instance.Locate<IHDInsightClientFactory>().Create(new HDInsightCertificateCredential(credentials.SubscriptionId, credentials.Certificate));

            var cluster = GetRandomCluster();
            var cluster2 = GetRandomCluster();
            cluster2.Name = cluster.Name;
            cluster2.Location = "East US";

            try
            {
                client.CreateCluster(cluster);
                client.CreateCluster(cluster2);

                var clusters = client.ListClusters().Where(c => c.Name == cluster.Name || c.Name == cluster2.Name).ToList();

                Assert.AreEqual(2, clusters.Count, "Count doesnt match");
                Assert.AreEqual(clusters[0].Name, cluster.Name, "Name doesnt match");
                Assert.AreEqual(clusters[1].Name, cluster.Name, "Name doesnt match");
                Assert.AreEqual(clusters[0].Location, cluster.Location, "Location doesnt match");
                Assert.AreEqual(clusters[1].Location, cluster2.Location, "Location doesnt match");
            }
            finally
            {
                try
                {
                    client.DeleteCluster(cluster.Name, cluster.Location);
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                    // Ignore exception
                }
                try
                {
                    client.DeleteCluster(cluster2.Name, cluster2.Location);
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                    // Ignore exception
                }
            }

        }
    }
}
