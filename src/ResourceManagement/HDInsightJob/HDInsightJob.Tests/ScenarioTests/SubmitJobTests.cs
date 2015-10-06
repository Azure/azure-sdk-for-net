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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Hyak.Common;
using Microsoft.Azure.Management.HDInsight.Job;
using Microsoft.Azure.Management.HDInsight.Job.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace HDInsightJob.Tests
{
    public class SubmitJobTests
    {
        [Fact]
        public void KillMapReduceStreamingJob()
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

                var defines = new Dictionary<string, string>
                {
                    {"mapreduce.map.maxattempts", "10"},
                    {"mapreduce.reduce.maxattempts", "10"},
                    {"mapreduce.task.timeout", "60000"}
                };
                var args = new List<string> { "10", "1000" };

                var parameters = new MapReduceJobSubmissionParameters
                {
                    UserName = username,
                    JarFile = "/example/jars/hadoop-mapreduce-examples.jar",
                    JarClass = "pi",
                    Defines = ConvertDefinesToString(defines),
                    Arguments = ConvertArgsToString(args)
                };

                var jobid = client.JobManagement.SubmitMapReduceJob(parameters).JobSubmissionJsonResponse.Id;

                var response = client.JobManagement.GetJob(jobid);
                Assert.NotNull(response);
                Assert.Equal(response.StatusCode, HttpStatusCode.OK);

                var job = client.JobManagement.KillJob(jobid);
                Assert.NotNull(job);
                Assert.Equal(job.JobDetail.Status.State, "KILLED");
            }
        }

        [Fact]
        public void SubmitHiveJob()
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

                var defines = new Dictionary<string, string>
                {
                    {"hive.execution.engine", "ravi"},
                    {"hive.exec.reducers.max", "1"}
                };
                var args = new List<string> {"argA", "argB"};

                var parameters = new HiveJobSubmissionParameters
                {
                    UserName = username,
                    Query = "SHOW TABLES;",
                    Defines = ConvertDefinesToString(defines),
                    Arguments = ConvertArgsToString(args)
                };

                var response = client.JobManagement.SubmitHiveJob(parameters);
                Assert.NotNull(response);
                Assert.Equal(response.StatusCode, HttpStatusCode.OK);

                Assert.Contains("job_", response.JobSubmissionJsonResponse.Id, StringComparison.InvariantCulture);
            }
        }

        [Fact]
        public void SubmitMapReduceJob()
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

                var defines = new Dictionary<string, string>
                {
                    {"mapreduce.map.maxattempts", "10"},
                    {"mapreduce.reduce.maxattempts", "10"},
                    {"mapreduce.task.timeout", "60000"}
                };
                var args = new List<string> {"10", "1000"};

                var parameters = new MapReduceJobSubmissionParameters
                {
                    UserName = username,
                    JarFile = "/example/jars/hadoop-mapreduce-examples.jar",
                    JarClass = "pi",
                    Defines = ConvertDefinesToString(defines),
                    Arguments = ConvertArgsToString(args)
                };

                var response = client.JobManagement.SubmitMapReduceJob(parameters);
                Assert.NotNull(response);
                Assert.Equal(response.StatusCode, HttpStatusCode.OK);

                Assert.Contains("job_", response.JobSubmissionJsonResponse.Id, StringComparison.InvariantCulture);
            }
        }

       [Fact]
        public void SubmitMapReduceStreamingJob()
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

                var parameters = new MapReduceStreamingJobSubmissionParameters
                {
                    UserName = username,
                    Mapper = "cat.exe",
                    Reducer = "wc.exe",
                    Input = "/example/data/gutenberg/davinci.txt",
                    Output = "/example/data/gutenberg/wcout"
                };

                var response = client.JobManagement.SubmitMapReduceStreamingJob(parameters);
                Assert.NotNull(response);
                Assert.Equal(response.StatusCode, HttpStatusCode.OK);

                Assert.Contains("job_", response.JobSubmissionJsonResponse.Id, StringComparison.InvariantCulture);
            }
        }

        [Fact]
        public void SubmitPigJob()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();

                var username = TestUtils.UserName;
                var password = TestUtils.Password;
                var clustername = TestUtils.ClusterName;

                var credentials = new BasicAuthenticationCloudCredentials()
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

                var response = client.JobManagement.SubmitPigJob(parameters);
                Assert.NotNull(response);
                Assert.Equal(response.StatusCode, HttpStatusCode.OK);

                Assert.Contains("job_", response.JobSubmissionJsonResponse.Id, StringComparison.InvariantCulture);
            }
        }

        public static string ConvertDefinesToString(Dictionary<string, string> defines)
        {
            return defines.Count == 0 ? null : string.Join("&define=", defines.Select(x => x.Key + "%3D" + x.Value).ToArray());
        }

        public static string ConvertArgsToString(List<string> args)
        {
            return args.Count == 0 ? null : string.Join("&arg=", args.ToArray());
        }
    }
}
