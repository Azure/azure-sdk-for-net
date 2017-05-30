using System.Net;
using Xunit;
using HDInsight.Tests.Helpers;
using Microsoft.Azure.Management.HDInsight;
using Microsoft.Azure.Management.HDInsight.Models;


namespace HDInsight.Tests
{
    public class OMSOnRunningCluster
    {
        public OMSOnRunningCluster()
        {
            HyakTestUtilities.SetHttpMockServerMatcher();
        }

        [Fact]
        public void TestOMSOnRunningCluster()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = HyakMockContext.Start(this.GetType().FullName))
            {
                var client = HDInsightManagementTestUtilities.GetHDInsightManagementClient(context, handler);
                var resourceManagementClient = HDInsightManagementTestUtilities.GetResourceManagementClient(context, handler);

                var resourceGroup = HDInsightManagementTestUtilities.CreateResourceGroup(resourceManagementClient);

                // need to use static name, so tests work in playback mode
                var dnsName = "hdioms733a2822-b098-443f-95b8-2e35f261a5c2";

                try
                {
                    var clusterCreateParams = CreateClusterToValidateOMSSetup(resourceGroup, dnsName, client);

					// enable monitoring on the cluster
                    ClusterMonitoringRequest clusterMonitoringParams = new ClusterMonitoringRequest
                    {
                        WorkspaceId = "",
                        PrimaryKey = ""
                    };
                    var response = client.Clusters.EnableMonitoring(resourceGroup, dnsName, clusterMonitoringParams);
                    Assert.Equal(AsyncOperationState.Succeeded, response.State);

					// validate that monitoring is enabled
                    var enablemon = client.Clusters.GetMonitoringStatus(resourceGroup, dnsName);
                    Assert.True(enablemon.ClusterMonitoringEnabled.Contains(clusterMonitoringParams.WorkspaceId), "The OMS workspace was not enabled properly");

					// disable monitoring on the cluster
                    response = client.Clusters.DisableMonitoring(resourceGroup, dnsName);
                    Assert.Equal(AsyncOperationState.Succeeded, response.State);

					// validate that monitoring is disabled
                    var disablemon = client.Clusters.GetMonitoringStatus(resourceGroup, dnsName);
                    Assert.True(disablemon.ClusterMonitoringEnabled.Contains("false"), "The OMS workspace was not disabled properly");
                }
                finally
                {
                    //cleanup 
                    client.Clusters.Delete(resourceGroup, dnsName);
                }
            }
        }

        private ClusterCreateParameters CreateClusterToValidateOMSSetup(string resourceGroup, string dnsName, HDInsightManagementClient client)
        {
            var clusterCreateParams = GetClusterSpecHelpers.GetCustomCreateParametersIaas();
            clusterCreateParams.Version = "3.6";
            clusterCreateParams.ClusterType = "Spark";

            client.Clusters.Create(resourceGroup, dnsName, clusterCreateParams);

            HDInsightManagementTestUtilities.WaitForClusterToMoveToRunning(resourceGroup, dnsName, client);

            return clusterCreateParams;
        }
    }
}
