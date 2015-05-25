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

using System.Linq;
using Hyak.Common;
using Microsoft.WindowsAzure.Management.SiteRecovery;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;
using Microsoft.Azure.Test;
using System.Net;
using Xunit;


namespace SiteRecovery.Tests
{
    public class JobOperationTests : SiteRecoveryTestsBase
    {
        [Fact]
        public void GetJobTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);
                JobQueryParameter jqp = new JobQueryParameter();
                var responseJobs = client.Jobs.List(jqp, RequestHeaders);
                string jobId = responseJobs.Jobs[0].ID;
                var response = client.Jobs.Get(jobId, RequestHeaders);

                Assert.NotNull(response.Job);
                Assert.NotNull(response.Job.ID);
                Assert.NotNull(response.Job.StartTime);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void EnumerateJobsTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                JobQueryParameter jqp = new JobQueryParameter();
                var response = client.Jobs.List(jqp, RequestHeaders);

                jqp.ObjectId = response.Jobs[0].TargetObjectId;
                response = client.Jobs.List(jqp, RequestHeaders);

                Assert.True(response.Jobs.Count > 0, "No Asr jobs found.");
                Assert.True(response.Jobs.All(job => !string.IsNullOrEmpty(job.ID)), "Job ID can't be null or empty");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public void RestartFailedJobTest()
        {
            RestartJobTest("Failed");
        }

        public void RestartSucceededJobTest()
        {
            RestartJobTest("Succeeded");
        }

        private void RestartJobTest(string state)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();    
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var requestHeaders = RequestHeaders;
                requestHeaders.AgentAuthenticationHeader = 
                    GenerateAgentAuthenticationHeader(requestHeaders.ClientRequestId);

                JobQueryParameter jqp = new JobQueryParameter();
                var responseJobs = client.Jobs.List(jqp, RequestHeaders);
                JobResponse response = null;
                try
                {
                    foreach (var job in responseJobs.Jobs)
                    {
                        if (job.State == state)
                        {
                            response = client.Jobs.Restart(job.ID, requestHeaders);
                        }
                    }
                }
                catch (CloudException cloudEx)
                {
                    if (cloudEx.Error.Code == "CannotRemediateSucceededWorkflow" ||
                        cloudEx.Error.Code == "CannotRemediateUnfinishedWorkflow" ||
                        cloudEx.Error.Code == "FeatureNotAllowed")
                    {
                        // Request was submitted but failed initial validation.
                        // But our scenario of restart job request was accepted, so test succeeded.
                        return;
                    }
                }

                Assert.NotNull(response.Job);
                Assert.NotNull(response.Job.ID);
                Assert.NotNull(response.Job.StartTime);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public void CancelJobTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var requestHeaders = RequestHeaders;
                requestHeaders.AgentAuthenticationHeader =
                    GenerateAgentAuthenticationHeader(requestHeaders.ClientRequestId);

                JobQueryParameter jqp = new JobQueryParameter();
                var responseJobs = client.Jobs.List(jqp, requestHeaders);
                var response = client.Jobs.Cancel(responseJobs.Jobs[0].ID, RequestHeaders);

                Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            }
        }
    }
}
