using System;
using System.Net;
using Xunit;
using Microsoft.Azure.Management.BatchAI;
using Microsoft.Azure.Management.BatchAI.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;


namespace BatchAI.Tests
{
    public class CreateJobTests
    {
        /* Tests simple scenario for a job - submit, check results, delete. */
        [Fact]
        public void TestJobCreationAndDeletion()
        {
            string workspaceName = "testjobcreationanddeletion_workspace";
            string clusterName = "testjobcreationanddeletion_cluster";
            string expName = "testjobcreationanddeletion_experiment";
            string jobName = "testjobcreationanddeletion_testjob";

            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = Helpers.GetBatchAIClient(context, handler1);

                var rgClient = Helpers.GetResourceManagementClient(context, handler2);

                string rgName = Helpers.CreateResourceGroup(rgClient);

                var clusterCreateParams = new ClusterCreateParameters()
                {
                    ScaleSettings = new ScaleSettings()
                    {
                        Manual = new ManualScaleSettings()
                        {
                            TargetNodeCount = 1
                        }
                    },
                    VmSize = "STANDARD_D1",
                    UserAccountSettings = new UserAccountSettings()
                    {
                        AdminUserName = Helpers.ADMIN_USER_NAME,
                        AdminUserPassword = Helpers.ADMIN_USER_PASSWORD,
                    },
                };

                var workspaceCreateParams = new WorkspaceCreateParameters()
                {
                    Location = Helpers.LOCATION,
                };

                Workspace workspace = client.Workspaces.Create(rgName, workspaceName, workspaceCreateParams);

                Cluster cluster = client.Clusters.Create(rgName, workspaceName, clusterName, clusterCreateParams);

                Helpers.WaitAllNodesToBeIdle(client, rgName, workspaceName, clusterName);

                Experiment experiment = client.Experiments.Create(rgName, workspaceName, expName);

                var jobCreateParams = new JobCreateParameters()
                {
                    Cluster = new ResourceId(cluster.Id),
                    NodeCount = 1,
                    CustomToolkitSettings = new CustomToolkitSettings()
                    {
                        CommandLine = "echo Hello"
                    },

                    StdOutErrPathPrefix = "$AZ_BATCHAI_JOB_TEMP",
                };

                client.Jobs.Create(rgName, workspaceName, expName, jobName, jobCreateParams);
                Helpers.WaitJobSucceeded(client, rgName, workspaceName, expName, jobName);
                client.Clusters.Delete(rgName, workspaceName, clusterName);
                client.Jobs.Delete(rgName, workspaceName, expName, jobName);
            }
        }
    }
}
