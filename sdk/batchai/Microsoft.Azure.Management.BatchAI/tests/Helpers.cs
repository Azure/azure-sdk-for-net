using System;
using System.Net;
using Microsoft.Azure.Management.BatchAI;
using Microsoft.Azure.Management.BatchAI.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Threading;
using Xunit;

namespace BatchAI.Tests
{
    public class Helpers
    {
        // User name and password for admin user configured on compute cluster and file servers.
        public static string ADMIN_USER_NAME = "demoUser";
        public static string ADMIN_USER_PASSWORD = "Dem0Pa$$w0rd";
        // Location to run tests.
        public static string LOCATION = "eastus";

        public static BatchAIManagementClient GetBatchAIClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<BatchAIManagementClient>(handlers : handler);
            return client;
        }

        public static string CreateResourceGroup(ResourceManagementClient resourcesClient)
        {
            const string testPrefix = "BatchAIResourceGroup";
            var rgname = TestUtilities.GenerateName(testPrefix);

            var resourceGroupDefinition = new ResourceGroup
            {
                Location = LOCATION
            };
            resourcesClient.ResourceGroups.CreateOrUpdate(rgname, resourceGroupDefinition);
            return rgname;
        }
    
        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            ResourceManagementClient resourcesClient = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
            return resourcesClient;
        }

        public static void WaitAllNodesToBeIdle(BatchAIManagementClient client, string rgName, string wsName, string clusterName)
        {
            while (true)
            {
                Cluster cluster = client.Clusters.Get(rgName, wsName, clusterName);
                if (cluster.CurrentNodeCount == cluster.ScaleSettings.Manual.TargetNodeCount &&
                    cluster.CurrentNodeCount == cluster.NodeStateCounts.IdleNodeCount)
                {
                    return;
                }
                TestUtilities.Wait(TimeSpan.FromSeconds(5));
            }
        }

        public static void VerifyClusterProperties(String clusterName, ClusterCreateParameters createParams, Cluster cluster)
        {
            Assert.Equal(cluster.Name, clusterName);
            Assert.Equal(cluster.VmSize, createParams.VmSize);
            Assert.Equal(cluster.ScaleSettings.Manual.TargetNodeCount, createParams.ScaleSettings.Manual.TargetNodeCount);
        }
        
        public static void WaitJobSucceeded(BatchAIManagementClient client, string rgName, string wsName, string expName, String jobName)
        {
            while (true)
            {
                Job job = client.Jobs.Get(rgName, wsName, expName, jobName);
                if (job.ExecutionState == ExecutionState.Succeeded ||
                    job.ExecutionState == ExecutionState.Failed)
                {
                    Assert.Equal(job.ExecutionState, ExecutionState.Succeeded);
                    return;
                }
                else
                {
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));
                }
            }
        }


    }
}
