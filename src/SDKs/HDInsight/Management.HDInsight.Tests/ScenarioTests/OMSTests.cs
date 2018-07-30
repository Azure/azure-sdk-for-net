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

    [Collection("ScenarioTests")]
    public class OMSTests
    {
        private const string WorkspaceId = "1d364e89-bb71-4503-aa3d-a23535aea7bd";
        private const string PrimaryKey = "";
        
        [Fact]
        public void TestOMSOnRunningCluster()
        {
            string clusterName = "hdisdk-oms";
            string testName = "TestOMSOnRunningCluster";
            string suiteName = GetType().FullName;

            ClusterCreateParameters createParams = ClusterCreateParametersHelpers.GetCustomCreateParametersIaas(testName);
            createParams.Version = "3.6";
            createParams.ClusterType = "Spark";

            HDInsightManagementTestUtilities.CreateClusterInNewResourceGroupAndRunTest(suiteName, testName, clusterName, createParams, (client, rgName) =>
            {
                ClusterMonitoringRequest request = new ClusterMonitoringRequest
                {
                    WorkspaceId = WorkspaceId,
                    PrimaryKey = PrimaryKey
                };

                client.Extension.EnableMonitoring(rgName, clusterName, request);
                ClusterMonitoringResponse monitoringStatus = client.Extension.GetMonitoringStatus(rgName, clusterName);
                Assert.True(monitoringStatus.ClusterMonitoringEnabled);
                Assert.Equal(monitoringStatus.WorkspaceId, WorkspaceId);

                client.Extension.DisableMonitoring(rgName, clusterName);
                monitoringStatus = client.Extension.GetMonitoringStatus(rgName, clusterName);
                Assert.False(monitoringStatus.ClusterMonitoringEnabled);
                Assert.Null(monitoringStatus.WorkspaceId);
            });
        }
    }
}
