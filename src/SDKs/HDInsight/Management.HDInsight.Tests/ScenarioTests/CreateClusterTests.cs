// 
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Management.HDInsight.Tests
{
    using Xunit;
    using Microsoft.Azure.Management.HDInsight;
    using Microsoft.Azure.Management.HDInsight.Models;
    using System.Collections.Generic;
    using Microsoft.Rest.Azure;
    using System.Net;

    public class CreateClusterTests
    {
        [Fact]
        public void TestCreateHumboldtClusterWithPremiumTier()
        {
            ClusterCreateParameters parameters = ClusterCreateParametersHelpers.GetCustomCreateParametersIaas();
            parameters.ClusterTier = Tier.Premium;

            RunCreateClusterTestInNewResourceGroup(GetType().FullName, "TestCreateHumboldtClusterWithPremiumTier", "hdisdk-premium", parameters);
        }

        [Fact]
        public void TestCreateHumboldtCluster()
        {
            ClusterCreateParameters parameters = ClusterCreateParametersHelpers.GetCustomCreateParametersIaas();

            RunCreateClusterTestInNewResourceGroup(GetType().FullName, "TestCreateHumboldtCluster", "hdisdk-humboldt", parameters);
        }

        [Fact]
        public void TestCreateWithEmptyExtendedParameters()
        {
            string clusterName = "hdisdk-cluster";

            HDInsightManagementTestUtilities.RunTestInNewResourceGroup(GetType().FullName, "TestCreateWithEmptyExtendedParameters",
                (resClient, client, rgName) =>
            {
                CloudException ex = Assert.Throws<CloudException>(() => client.Clusters.Create(rgName, clusterName, new ClusterCreateParametersExtended()));
                Assert.Equal(HttpStatusCode.BadRequest, ex.Response.StatusCode);
            });
        }

        [Fact]
        public void TestCreateWithEmptyParameters()
        {
            string clusterName = "hdisdk-cluster";

            HDInsightManagementTestUtilities.RunTestInNewResourceGroup(GetType().FullName, "TestCreateWithEmptyParameters",
                (resClient, client, rgName) =>
            {
                CloudException ex = Assert.Throws<CloudException>(() => client.Clusters.Create(rgName, clusterName, new ClusterCreateParameters()));
                Assert.Equal(HttpStatusCode.BadRequest, ex.Response.StatusCode);
            });
        }

        [Fact]
        public void TestCreateHumboldtClusterWithCustomVMSizes()
        {
            ClusterCreateParameters parameters = ClusterCreateParametersHelpers.GetCustomCreateParametersIaas();
            parameters.HeadNodeSize = "ExtraLarge";
            parameters.ZookeeperNodeSize = "Medium";

            RunCreateClusterTestInNewResourceGroup(GetType().FullName, "TestCreateHumboldtClusterWithCustomVMSizes",
                "hdisdk-customvmsizes", parameters);
        }

        [Fact]
        public void TestCreateLinuxSparkClusterWithComponentVersion()
        {
            ClusterCreateParameters parameters = ClusterCreateParametersHelpers.GetCustomCreateParametersIaas();
            parameters.ClusterType = "Spark";
            parameters.ComponentVersion.Add("Spark", "2.0");

            RunCreateClusterTestInNewResourceGroup(GetType().FullName, "TestCreateLinuxSparkClusterWithComponentVersion",
                "hdisdk-sparkcomponentversions", parameters);
        }

        [Fact]
        public void TestCreateKafkaClusterWithManagedDisks()
        {
            ClusterCreateParameters parameters = ClusterCreateParametersHelpers.GetCustomCreateParametersIaas();
            parameters.ClusterType = "Kafka";
            parameters.WorkerNodeDataDisksGroups = new List<DataDisksGroups>
            {
                new DataDisksGroups
                {
                     DisksPerNode = 8
                }
            };

            RunCreateClusterTestInNewResourceGroup(GetType().FullName, "TestCreateKafkaClusterWithManagedDisks",
                "hdisdk-kafka", parameters);
        }

        [Fact]
        public void TestCreateWithDataLakeStorage()
        {
            ClusterCreateParameters parameters = ClusterCreateParametersHelpers.GetCustomCreateParametersForAdl();

            RunCreateClusterTestInNewResourceGroup(GetType().FullName, "TestCreateWithDataLakeStorage", "hdisdk-adl", parameters);
        }

        private static void RunCreateClusterTestInNewResourceGroup(string suiteName, string testName, string clusterName,
            ClusterCreateParameters createParams)
        {
            HDInsightManagementTestUtilities.CreateClusterInNewResourceGroupAndRunTest(suiteName, testName, clusterName, createParams, (client, rgName)=>
            {
                Cluster cluster = client.Clusters.Get(rgName, clusterName);
                Assert.NotNull(cluster);
                HDInsightManagementTestUtilities.ValidateCluster(createParams, cluster, clusterName);
            });
        }
    }
}