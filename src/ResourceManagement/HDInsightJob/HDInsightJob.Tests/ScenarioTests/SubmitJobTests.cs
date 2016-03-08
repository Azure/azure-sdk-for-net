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
using System.Net;
using System.IO;
using System.Threading;
using Hyak.Common;
using Microsoft.Azure.Management.HDInsight.Job;
using Microsoft.Azure.Management.HDInsight.Job.Models;
using Microsoft.Azure.Test;
using Xunit;
using Microsoft.Azure.Test.HttpRecorder;

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
                    JarFile = "/example/jars/hadoop-mapreduce-examples.jar",
                    JarClass = "pi",
                    Defines = defines,
                    Arguments = args
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
        public void SubmitHiveJob_Defines()
        {
            var defines = new Dictionary<string, string>
                {
                    { "hive.execution.engine", "ravi" },
                    { "hive.exec.reducers.max", "1" },
                    { "time", "10" },
                    { "rows", "20" } 
                };

            var parameters = new HiveJobSubmissionParameters
            {
                Query = @"select * from hivesampletable where querydwelltime > ${hiveconf:time} limit ${hiveconf:rows}",
                Defines = defines
            };

            SubmitHiveJobAndValidateOutput(parameters, "Massachusetts	United States");
        }

        [Fact]
        public void SubmitHiveJob()
        {
            var parameters = new HiveJobSubmissionParameters
            {
                Query = @"select querydwelltime+2 from hivesampletable where clientid = 8"
            };

            SubmitHiveJobAndValidateOutput(parameters, "15.92");
        }

        public void SubmitHiveJobAndValidateOutput(HiveJobSubmissionParameters parameters, string expectedOutputPart)
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

                var response = client.JobManagement.SubmitHiveJob(parameters);
                Assert.NotNull(response);
                Assert.Equal(response.StatusCode, HttpStatusCode.OK);

                var jobId = response.JobSubmissionJsonResponse.Id;
                Assert.Contains("job_", jobId, StringComparison.InvariantCulture);

                var jobStatus = GetJobFinalStatus(client, jobId);

                var storageAccess = GetStorageAccessObject();

                if (jobStatus.JobDetail.ExitValue == 0)
                {
                    if (HttpMockServer.Mode == HttpRecorderMode.Record)
                    {
                        // Retrieve Job Output
                        var output = client.JobManagement.GetJobOutput(jobId, storageAccess);
                        string textOutput = Convert(output);
                        Assert.True(textOutput.Contains(expectedOutputPart));
                    }
                }
                else
                {
                    if (HttpMockServer.Mode == HttpRecorderMode.Record)
                    {
                        var output = client.JobManagement.GetJobErrorLogs(jobId, storageAccess);
                        string errorTextOutput = Convert(output);
                        Assert.NotNull(errorTextOutput);
                    }

                    Assert.True(false);
                }
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
                var args = new List<string> { "10", "1000" };

                var parameters = new MapReduceJobSubmissionParameters
                {
                    JarFile = "/example/jars/hadoop-mapreduce-examples.jar",
                    JarClass = "pi",
                    Defines = defines,
                    Arguments = args
                };

                var response = client.JobManagement.SubmitMapReduceJob(parameters);
                Assert.NotNull(response);
                Assert.Equal(response.StatusCode, HttpStatusCode.OK);

                var jobId = response.JobSubmissionJsonResponse.Id;
                Assert.Contains("job_", jobId, StringComparison.InvariantCulture);

                var jobStatus = GetJobFinalStatus(client, jobId);

                var storageAccess = GetStorageAccessObject();

                if (jobStatus.JobDetail.ExitValue == 0)
                {
                    if (HttpMockServer.Mode == HttpRecorderMode.Record)
                    {
                        // Retrieve Job Output
                        var output = client.JobManagement.GetJobOutput(jobId, storageAccess);
                        string textOutput = Convert(output);
                        Assert.True(textOutput.Contains("Estimated value of Pi is 3.14"));
                    }
                }
                else
                {
                    if (HttpMockServer.Mode == HttpRecorderMode.Record)
                    {
                        var output = client.JobManagement.GetJobErrorLogs(jobId, storageAccess);
                        string errorTextOutput = Convert(output);
                        Assert.NotNull(errorTextOutput);
                    }

                    Assert.True(false);
                }
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
                    Mapper = "cat",
                    Reducer = "wc",
                    Input = "/example/data/gutenberg/davinci.txt",
                    Output = "/example/data/gutenberg/wcount"
                };

                var response = client.JobManagement.SubmitMapReduceStreamingJob(parameters);
                Assert.NotNull(response);
                Assert.Equal(response.StatusCode, HttpStatusCode.OK);

                var jobId = response.JobSubmissionJsonResponse.Id;
                Assert.Contains("job_", jobId, StringComparison.InvariantCulture);

                var jobStatus = GetJobFinalStatus(client, jobId);

                var storageAccess = GetStorageAccessObject();

                if (jobStatus.JobDetail.ExitValue == 0)
                {
                    if (HttpMockServer.Mode == HttpRecorderMode.Record)
                    {
                        // Retrieve Job Output
                        var output = client.JobManagement.GetJobOutput(jobId, storageAccess);
                        string textOutput = Convert(output);
                        Assert.True(textOutput.Length > 0);
                    }
                }
                else
                {
                    if (HttpMockServer.Mode == HttpRecorderMode.Record)
                    {
                        var output = client.JobManagement.GetJobErrorLogs(jobId, storageAccess);
                        string errorTextOutput = Convert(output);
                        Assert.NotNull(errorTextOutput);
                    }

                    Assert.True(false);
                }
            }
        }

        [Fact]
        [Trait("Category","Windows")]
        public void SubmitMapReduceStreamingJobWithFilesParam()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();

                var username = TestUtils.WinUserName;
                var password = TestUtils.WinPassword;
                var clustername = TestUtils.WinClusterName;

                var credentials = new BasicAuthenticationCloudCredentials
                {
                    Username = username,
                    Password = password
                };

                var client = TestUtils.GetHDInsightJobManagementClient(clustername, credentials);

                var parameters = new MapReduceStreamingJobSubmissionParameters
                {
                    Mapper = "cat.exe",
                    Reducer = "wc.exe",
                    Input = "/example/data/gutenberg/davinci.txt",
                    Output = "/example/data/gutenberg/wcount",
                    Files = new List<string> { "/example/apps/wc.exe", "/example/apps/cat.exe" }
                };

                var response = client.JobManagement.SubmitMapReduceStreamingJob(parameters);
                Assert.NotNull(response);
                Assert.Equal(response.StatusCode, HttpStatusCode.OK);

                var jobId = response.JobSubmissionJsonResponse.Id;
                Assert.Contains("job_", jobId, StringComparison.InvariantCulture);

                var jobStatus = GetJobFinalStatus(client, jobId);

                var storageAccess = new AzureStorageAccess(TestUtils.WinStorageAccountName, TestUtils.WinStorageAccountKey, TestUtils.WinDefaultContainer);

                if (jobStatus.JobDetail.ExitValue == 0)
                {
                    if (HttpMockServer.Mode == HttpRecorderMode.Record)
                    {
                        // Retrieve Job Output
                        var output = client.JobManagement.GetJobOutput(jobId, storageAccess);
                        string textOutput = Convert(output);
                        Assert.True(textOutput.Length > 0);
                    }
                }
                else
                {
                    if (HttpMockServer.Mode == HttpRecorderMode.Record)
                    {
                        var output = client.JobManagement.GetJobErrorLogs(jobId, storageAccess);
                        string errorTextOutput = Convert(output);
                        Assert.NotNull(errorTextOutput);
                    }

                    Assert.True(false);
                }
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
                    Query = "LOGS = LOAD 'wasb:///example/data/sample.log';" +
                                    "LEVELS = foreach LOGS generate REGEX_EXTRACT($0, '(TRACE|DEBUG|INFO|WARN|ERROR|FATAL)', 1)  as LOGLEVEL;" +
                                    "FILTEREDLEVELS = FILTER LEVELS by LOGLEVEL is not null;" +
                                    "GROUPEDLEVELS = GROUP FILTEREDLEVELS by LOGLEVEL;" +
                                    "FREQUENCIES = foreach GROUPEDLEVELS generate group as LOGLEVEL, COUNT(FILTEREDLEVELS.LOGLEVEL) as COUNT;" +
                                    "RESULT = order FREQUENCIES by COUNT desc;" +
                                    "DUMP RESULT;"
                };

                var response = client.JobManagement.SubmitPigJob(parameters);
                Assert.NotNull(response);
                Assert.Equal(response.StatusCode, HttpStatusCode.OK);

                var jobId = response.JobSubmissionJsonResponse.Id;
                Assert.Contains("job_", jobId, StringComparison.InvariantCulture);

                var jobStatus = GetJobFinalStatus(client, jobId);

                var storageAccess = GetStorageAccessObject();

                if (jobStatus.JobDetail.ExitValue == 0)
                {
                    // Retrieve Job Output
                    if (HttpMockServer.Mode == HttpRecorderMode.Record)
                    {
                        var output = client.JobManagement.GetJobOutput(jobId, storageAccess);
                        string textOutput = Convert(output);
                        Assert.True(textOutput.Contains("(DEBUG,"));
                    }
                }
                else
                {
                    if (HttpMockServer.Mode == HttpRecorderMode.Record)
                    {
                        var output = client.JobManagement.GetJobErrorLogs(jobId, storageAccess);
                        string errorTextOutput = Convert(output);
                        Assert.NotNull(errorTextOutput);
                    }

                    Assert.True(false);
                }
            }
        }

        [Fact]
        public void SubmitSqoopJob()
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

                // Before we run this test in Record mode, we should run following commands on cluster
                // hdfs dfs -mkdir /user/hcat/lib
                // hadoop fs -copyFromLocal -f /usr/share/java/sqljdbc_4.1/enu/sqljdbc41.jar /user/hcat/lib
                // Generate sqoopcommand.txt using content
                // --connect
                // <Connection string to DB which has table dept.>
                // --table
                // dept
                // Keep these in separate lines otherwise, sqoop command will fail. Copy the sqoopcommand.txt
                // hdfs dfs -mkdir /example/data/sqoop/
                // hadoop fs -copyFromLocal -f sqoopcommand.txt /example/data/sqoop/

                var parameters = new SqoopJobSubmissionParameters
                {
                    LibDir = "/user/hcat/lib",
                    Files = new List<string>{"/example/data/sqoop/sqoopcommand.txt"},
                    Command = "import --options-file sqoopcommand.txt --hive-import -m 1",
                    StatusDir = "sqoopstatus",
                };

                var response = client.JobManagement.SubmitSqoopJob(parameters);
                Assert.NotNull(response);
                Assert.Equal(response.StatusCode, HttpStatusCode.OK);

                var jobId = response.JobSubmissionJsonResponse.Id;
                Assert.Contains("job_", jobId, StringComparison.InvariantCulture);

                var jobStatus = GetJobFinalStatus(client, jobId);

                var storageAccess = GetStorageAccessObject();

                if (jobStatus.JobDetail.ExitValue == 0)
                {
                    if (HttpMockServer.Mode == HttpRecorderMode.Record)
                    {
                        // Retrieve Job Output
                        var output = client.JobManagement.GetJobOutput(jobId, storageAccess);
                        string textOutput = Convert(output);
                        Assert.True(textOutput.Length > 0);
                    }
                }
                else
                {
                    if (HttpMockServer.Mode == HttpRecorderMode.Record)
                    {
                        var output = client.JobManagement.GetJobErrorLogs(jobId, storageAccess);
                        string errorTextOutput = Convert(output);
                        Assert.NotNull(errorTextOutput);
                    }

                    Assert.True(false);
                }
            }
        }

        [Fact]
        public void SubmitHiveJobError()
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
                    Query = "FAKEQUERY;",
                    StatusDir = "jobstatus"
                };

                var response = client.JobManagement.SubmitHiveJob(parameters);
                Assert.NotNull(response);
                Assert.Equal(response.StatusCode, HttpStatusCode.OK);

                var jobId = response.JobSubmissionJsonResponse.Id;
                Assert.Contains("job_", jobId, StringComparison.InvariantCulture);

                var jobStatus = GetJobFinalStatus(client, jobId);

                Assert.True(jobStatus.JobDetail.ExitValue > 0);

                var storageAccess = GetStorageAccessObject();

                if (HttpMockServer.Mode == HttpRecorderMode.Record)
                {
                    var output = client.JobManagement.GetJobErrorLogs(jobId, storageAccess);
                    Assert.NotNull(output);
                    Assert.True(output.Length > 0);
                    string errorTextOutput = Convert(output);
                    Assert.True(!string.IsNullOrEmpty(errorTextOutput));
                }
            }
        }

        private static string Convert(Stream stream)
        {
            var reader = new StreamReader(stream);
            var text = reader.ReadToEnd();
            return text;
        }

        private JobGetResponse GetJobFinalStatus(HDInsightJobManagementClient client, string jobId)
        {
            var jobStatus = client.JobManagement.GetJob(jobId);

            while (!jobStatus.JobDetail.Status.JobComplete)
            {
                jobStatus = client.JobManagement.GetJob(jobId);

                // Optional to sleep here. Sleep for 1 sec instead of keep pooling. 
                Thread.Sleep(1000);
            }

            return jobStatus;
        }

        private IStorageAccess GetStorageAccessObject()
        {
            return new AzureStorageAccess(TestUtils.StorageAccountName, TestUtils.StorageAccountKey, TestUtils.DefaultContainer);
        }
    }
}
