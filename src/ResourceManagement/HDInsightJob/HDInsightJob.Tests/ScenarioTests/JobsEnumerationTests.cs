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

using System.Net;
using Hyak.Common;
using Microsoft.Azure.Management.HDInsight.Job;
using Microsoft.Azure.Management.HDInsight.Job.Models;
using Microsoft.Azure.Test;
using Xunit;
using System.Linq;

namespace HDInsightJob.Tests.ScenarioTests
{
    public class JobsEnumerationTests
    {
        [Fact]
        public void GetJobsPagination()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();

                var username = TestUtils.UserName;
                var password = TestUtils.Password;
                var clustername = TestUtils.ClusterName;

                var credentials = new BasicAuthenticationCloudCredentials
                {
                    Username = username,
                    Password = password
                };

                var client = TestUtils.GetHDInsightJobManagementClient(clustername, credentials);

                var allJobsResp = client.JobManagement.ListJobs();
                Assert.NotNull(allJobsResp);
                Assert.Equal(allJobsResp.StatusCode, HttpStatusCode.OK);

                Assert.NotNull(allJobsResp);
                Assert.Equal(allJobsResp.StatusCode, HttpStatusCode.OK);
                Assert.True(allJobsResp.JobList.Count > 0);

                int numOfEntries = 3;
                int index = -1;
                string jobid = string.Empty;
                while(true)
                {
                    var t = client.JobManagement.ListJobsAfterJobId(jobid, numOfEntries);
                    jobid = t.JobList.Last().Id;
                    index += t.JobList.Count;

                    var expectedJobId = allJobsResp.JobList.ElementAt(index).Id;
                    Assert.Equal(expectedJobId, jobid);

                    if (t.JobList.Count != numOfEntries)
                    {
                        break;
                    }
                }
            }
        }
    }
}
