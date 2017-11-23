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
            string clusterName = "testjobcreationanddeletion_cluster";
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
                    Location = Helpers.LOCATION,
                };
                
                Cluster cluster = client.Clusters.Create(rgName, clusterName, clusterCreateParams);

                Helpers.WaitAllNodesToBeIdle(client, rgName, clusterName);

                var jobCreateParams = new JobCreateParameters()
                {
                    Cluster = new ResourceId(cluster.Id),
                    NodeCount = 1,
                    CustomToolkitSettings = new CustomToolkitSettings()
                    {
                        CommandLine = "echo Hello"
                    },

                    StdOutErrPathPrefix = "$AZ_BATCHAI_JOB_TEMP",
                    Location = Helpers.LOCATION,
                };

                client.Jobs.Create(rgName, jobName, jobCreateParams);
                Helpers.WaitJobSucceeded(client, rgName, jobName);
                client.Clusters.Delete(rgName, clusterName);
                client.Jobs.Delete(rgName, jobName);
            }
        }
    }
}
