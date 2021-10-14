// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using static Management.HDInsight.Tests.HDInsightManagementTestUtilities;

namespace Management.HDInsight.Tests
{
    public class ExtensionOperationTests : HDInsightManagementTestBase
    {
        [Fact]
        public void TestOMSOnRunningCluster()
        {
            TestInitialize();

            string clusterName = TestUtilities.GenerateName("hdisdk-oms");
            var createParams = CommonData.PrepareClusterCreateParamsForWasb();
            createParams.Properties.ClusterDefinition.Kind = "Spark";
            createParams.Properties.ClusterVersion = "3.6";
            var cluster = HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, createParams);
            ValidateCluster(clusterName, createParams, cluster);

            var request = new ClusterMonitoringRequest
            {
                WorkspaceId = CommonData.WorkspaceId,
                PrimaryKey = "primarykey"
            };

            HDInsightClient.Extensions.EnableMonitoring(CommonData.ResourceGroupName, clusterName, request);
            var monitoringStatus = HDInsightClient.Extensions.GetMonitoringStatus(CommonData.ResourceGroupName, clusterName);
            Assert.True(monitoringStatus.ClusterMonitoringEnabled);
            Assert.Equal(request.WorkspaceId, monitoringStatus.WorkspaceId);

            HDInsightClient.Extensions.DisableMonitoring(CommonData.ResourceGroupName, clusterName);
            monitoringStatus = HDInsightClient.Extensions.GetMonitoringStatus(CommonData.ResourceGroupName, clusterName);
            Assert.False(monitoringStatus.ClusterMonitoringEnabled);
            Assert.Null(monitoringStatus.WorkspaceId);
        }

        [Fact]
        public void TestAzureMonitorOnRunningCluster()
        {
            TestInitialize();
            CommonData.Location = "South Central US";

            string clusterName = TestUtilities.GenerateName("hdisdk-azuremonitor");
            var createParams = CommonData.PrepareClusterCreateParamsForWasb();
            createParams.Properties.ClusterDefinition.Kind = "Spark";
            createParams.Properties.ClusterVersion = "3.6";

            var cluster = HDInsightClient.Clusters.Create(CommonData.ResourceGroupName, clusterName, createParams);
            ValidateCluster(clusterName, createParams, cluster);

            var request = new AzureMonitorRequest
            {
                WorkspaceId = "00000000-0000-0000-0000-000000000000",
                PrimaryKey = "primarykey"
            };

            HDInsightClient.Extensions.EnableAzureMonitor(CommonData.ResourceGroupName, clusterName, request);
            var azureMonitorStatus = HDInsightClient.Extensions.GetAzureMonitorStatus(CommonData.ResourceGroupName, clusterName);
            Assert.True(azureMonitorStatus.ClusterMonitoringEnabled);
            Assert.Equal(request.WorkspaceId, azureMonitorStatus.WorkspaceId);

            HDInsightClient.Extensions.DisableAzureMonitor(CommonData.ResourceGroupName, clusterName);
            azureMonitorStatus = HDInsightClient.Extensions.GetAzureMonitorStatus(CommonData.ResourceGroupName, clusterName);
            Assert.False(azureMonitorStatus.ClusterMonitoringEnabled);
            Assert.Null(azureMonitorStatus.WorkspaceId);
        }
    }
}
