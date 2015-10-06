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

using System.IO;
using System.Net;
using Hyak.Common;
using Microsoft.Azure.Management.HDInsight.Job;
using Microsoft.Azure.Management.HDInsight.Job.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace HDInsightJob.Tests
{
    public class StorageHelperTests
    {
        //[Fact]
        public void GetJobOutput()
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
                    StatusDir = "jobstatus"
                };

                var response = client.JobManagement.SubmitHiveJob(parameters);
                Assert.NotNull(response);
                Assert.Equal(response.StatusCode, HttpStatusCode.OK);

                var job = client.JobManagement.GetJob(response.JobSubmissionJsonResponse.Id);
                var output = client.JobManagement.GetJobOutput(job.JobDetail.Id,
                    TestUtils.StorageAccountName, TestUtils.StorageAccountKey, TestUtils.DefaultContainer);
                Assert.NotNull(output);
                var outputStr = Convert(output);
                Assert.NotNull(outputStr);
            }
        }

        //[Fact]
        public void GetJobError()
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
                    Query = "FAKEQUERY;",
                    StatusDir = "jobstatus"
                };

                var response = client.JobManagement.SubmitHiveJob(parameters);
                Assert.NotNull(response);
                Assert.Equal(response.StatusCode, HttpStatusCode.OK);

                var job = client.JobManagement.GetJob(response.JobSubmissionJsonResponse.Id);
                var output = client.JobManagement.GetJobErrorLogs(job.JobDetail.Id,
                    TestUtils.StorageAccountName, TestUtils.StorageAccountKey, TestUtils.DefaultContainer);
                Assert.NotNull(output);
                Assert.True(output.Length > 0);
                var outputStr = Convert(output);
                Assert.NotNull(outputStr);
            }
        }

        private static string Convert(Stream stream)
        {
            var reader = new StreamReader(stream);
            var text = reader.ReadToEnd();
            return text;
        }
    }
}
