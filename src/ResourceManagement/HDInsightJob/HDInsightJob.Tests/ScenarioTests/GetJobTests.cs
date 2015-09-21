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

namespace HDInsightJob.Tests
{
    public class GetJobTests
    {
        [Fact]
        public void ListJobs()
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

                var response = client.JobManagement.ListJobs();
                Assert.NotNull(response);
                Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Fact]
        public void GetHiveJob()
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

                var parameters = new HiveJobSubmissionParameters
                {
                    UserName = username,
                    Query = "SHOW TABLES;",
                    Arguments = "arg1",
                    Defines = "def1"
                };

                var jobid = client.JobManagement.SubmitHiveJob(parameters).JobSubmissionJsonResponse.Id;

                var response = client.JobManagement.GetJob(jobid);
                Assert.NotNull(response);
                Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Fact]
        public void GetSqoopJob()
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

                var parameters = new SqoopJobSubmissionParameters
                {
                    UserName = username,
                    Command = "some command",
                    StatusDir = "sqoopstatus",
                };

                var jobid = client.JobManagement.SubmitSqoopJob(parameters).JobSubmissionJsonResponse.Id;

                var response = client.JobManagement.GetJob(jobid);
                Assert.NotNull(response);
                Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Fact]
        public void GetPigJob()
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

                var parameters = new PigJobSubmissionParameters()
                {
                    UserName = username,
                    Query = "records = LOAD '/example/pig/sahara-paleo-fauna.txt' AS (DateBP:int, Loc:chararray, Coordinates:chararray, Samples:chararray, Country:chararray, Laboratory:chararray);" +
                            "filtered_records = FILTER records by Country == 'Egypt' OR Country == 'Morocco';" +
                            "grouped_records = GROUP filtered_records BY Country;" +
                            "DUMP grouped_records;"
                };

                var jobid = client.JobManagement.SubmitPigJob(parameters).JobSubmissionJsonResponse.Id;

                var response = client.JobManagement.GetJob(jobid);
                Assert.NotNull(response);
                Assert.Equal(response.StatusCode, HttpStatusCode.OK);
            }
        }
    }
}
