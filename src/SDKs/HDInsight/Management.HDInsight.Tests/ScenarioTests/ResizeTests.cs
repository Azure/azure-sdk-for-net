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
    using System.Linq;
    using System;

    [Collection("ScenarioTests")]
    public class ResizeTests
    {
        [Fact]
        public void TestResizeCluster()
        {
            string clusterName = "hdisdk-clusterresize";
            string testName = "TestResizeCluster";
            string suiteName = GetType().FullName;
            ClusterCreateParameters createParams = ClusterCreateParametersHelpers.GetCustomCreateParametersIaas(testName);

            HDInsightManagementTestUtilities.CreateClusterInNewResourceGroupAndRunTest(suiteName, testName, clusterName, createParams, (client, rgName) =>
            {
                Cluster cluster = client.Clusters.Get(rgName, clusterName);
                Assert.Equal(createParams.ClusterSizeInNodes, cluster.Properties.ComputeProfile.Roles.First(r => r.Name.Equals("workernode", StringComparison.OrdinalIgnoreCase)).TargetInstanceCount);

                client.Clusters.Resize(rgName, clusterName, createParams.ClusterSizeInNodes + 1);
                cluster = client.Clusters.Get(rgName, clusterName);
                Assert.Equal(createParams.ClusterSizeInNodes + 1, cluster.Properties.ComputeProfile.Roles.First(r => r.Name.Equals("workernode", StringComparison.OrdinalIgnoreCase)).TargetInstanceCount);

            });
        }
    }
}
