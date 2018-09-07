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

    [Collection("ScenarioTests")]
    public class CreateClusterTests
    {
        [Fact]
        public void TestCreateHumboldtClusterWithPremiumTier()
        {
            string testName = "TestCreateHumboldtClusterWithPremiumTier";

            ClusterCreateParameters parameters = ClusterCreateParametersHelpers.GetCustomCreateParametersIaas(testName);
            parameters.ClusterTier = Tier.Premium;

            RunCreateClusterTestInNewResourceGroup(GetType().FullName, testName, "hdisdk-premium", parameters);
        }

        [Fact]
        public void TestCreateHumboldtCluster()
        {
            string testName = "TestCreateHumboldtCluster";
            ClusterCreateParameters parameters = ClusterCreateParametersHelpers.GetCustomCreateParametersIaas(testName);

            RunCreateClusterTestInNewResourceGroup(GetType().FullName, testName, "hdisdk-humboldt", parameters);
        }

        [Fact]
        public void TestCreateWithEmptyExtendedParameters()
        {
            string clusterName = "hdisdk-cluster";

            HDInsightManagementTestUtilities.RunTestInNewResourceGroup(GetType().FullName, "TestCreateWithEmptyExtendedParameters",
                (resClient, client, rgName) =>
            {
                ErrorResponseException ex = Assert.Throws<ErrorResponseException>(() => client.Clusters.Create(rgName, clusterName, new ClusterCreateParametersExtended()));
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
                ErrorResponseException ex = Assert.Throws<ErrorResponseException>(() => client.Clusters.Create(rgName, clusterName, new ClusterCreateParameters()));
                Assert.Equal(HttpStatusCode.BadRequest, ex.Response.StatusCode);
            });
        }

        [Fact]
        public void TestCreateHumboldtClusterWithCustomVMSizes()
        {
            string testName = "TestCreateHumboldtClusterWithCustomVMSizes";
            ClusterCreateParameters parameters = ClusterCreateParametersHelpers.GetCustomCreateParametersIaas(testName);
            parameters.HeadNodeSize = "ExtraLarge";
            parameters.ZookeeperNodeSize = "Medium";

            RunCreateClusterTestInNewResourceGroup(GetType().FullName, testName, "hdisdk-customvmsizes", parameters);
        }

        [Fact]
        public void TestCreateLinuxSparkClusterWithComponentVersion()
        {
            string testName = "TestCreateLinuxSparkClusterWithComponentVersion";
            ClusterCreateParameters parameters = ClusterCreateParametersHelpers.GetCustomCreateParametersIaas(testName);
            parameters.ClusterType = "Spark";
            parameters.ComponentVersion.Add("Spark", "2.2");

            RunCreateClusterTestInNewResourceGroup(GetType().FullName, testName, "hdisdk-sparkcomponentversions", parameters);
        }

        [Fact]
        public void TestCreateKafkaClusterWithManagedDisks()
        {
            string testName = "TestCreateKafkaClusterWithManagedDisks";
            ClusterCreateParameters parameters = ClusterCreateParametersHelpers.GetCustomCreateParametersIaas(testName);
            parameters.ClusterType = "Kafka";
            parameters.WorkerNodeDataDisksGroups = new List<DataDisksGroups>
            {
                new DataDisksGroups
                {
                     DisksPerNode = 8
                }
            };

            RunCreateClusterTestInNewResourceGroup(GetType().FullName, testName, "hdisdk-kafka", parameters);
        }

        [Fact]
        public void TestCreateWithDataLakeStorage()
        {
            string testName = "TestCreateWithDataLakeStorage";
            ClusterCreateParameters parameters = ClusterCreateParametersHelpers.GetCustomCreateParametersForAdl(testName);

            RunCreateClusterTestInNewResourceGroup(GetType().FullName, testName, "hdisdk-adl", parameters);
        }

        [Fact]
        public void TestCreateRServerCluster()
        {
            string testName = "TestCreateRServerCluster";
            ClusterCreateParameters parameters = ClusterCreateParametersHelpers.GetCustomCreateParametersIaas(testName);
            parameters.ClusterType = "RServer";

            RunCreateClusterTestInNewResourceGroup(GetType().FullName, testName, "hdisdk-rserver", parameters);
        }

        [Fact]
        public void TestCreateMLServicesCluster()
        {
            string testName = "TestCreateMLServicesCluster";
            ClusterCreateParameters parameters = ClusterCreateParametersHelpers.GetCustomCreateParametersIaas(testName);
            parameters.Version = "3.6";
            parameters.ClusterType = "MLServices";

            RunCreateClusterTestInNewResourceGroup(GetType().FullName, testName, "hdisdk-mlservices", parameters);
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