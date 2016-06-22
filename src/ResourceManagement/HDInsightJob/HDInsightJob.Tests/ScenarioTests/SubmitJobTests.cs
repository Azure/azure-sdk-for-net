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
using System.Globalization;
using System.Net;
using System.IO;
using Hyak.Common;
using Microsoft.Azure.Management.HDInsight.Job;
using Microsoft.Azure.Management.HDInsight.Job.Models;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Xunit;
using System.Threading;
using System.Net.Http;

namespace HDInsightJob.Tests
{
    public class SubmitJobTests
    {
        public SubmitJobTests()
        {
            if (HttpMockServer.GetCurrentMode() != HttpRecorderMode.Record)
            {
                MockSupport.RunningMocked = true;
            }
        }

        [Fact]
        public void CheckEmptySdkVersion()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = TestUtils.GetHDInsightJobManagementClient();
                Assert.NotEmpty(client.SdkUserAgent);
            }
        }

        [Fact]
        public void CheckValidJobUserName()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();

                var credentials = new BasicAuthenticationCloudCredentials
                {
                    Username = "Admin",
                    Password = ""
                };

                var client = new HDInsightJobManagementClient("TestCluster", credentials);
                Assert.Equal(credentials.Username.ToLower(CultureInfo.CurrentCulture), client.UserName);

                client = new HDInsightJobManagementClient("TestCluster", credentials, new HttpClient());
                Assert.Equal(credentials.Username.ToLower(CultureInfo.CurrentCulture), client.UserName);
            }
        }

        [Fact]
        public void KillEmptyNameJob()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = TestUtils.GetHDInsightJobManagementClient();
                var exceptionMessage = string.Empty;

                try
                {
                    var job = client.JobManagement.KillJob(string.Empty);
                }
                catch (ArgumentException ex)
                {
                    exceptionMessage = ex.Message;
                }

                Assert.Equal(exceptionMessage, "jobId cannot be empty.");
            }
        }

        private MapReduceJobSubmissionParameters GetMapReduceJobParameters()
        {
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

            return parameters;
        }

        [Fact]
        public void KillMapReduceStreamingJob()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = TestUtils.GetHDInsightJobManagementClient();

                var parameters = GetMapReduceJobParameters();

                var jobId = client.JobManagement.SubmitMapReduceJob(parameters).JobSubmissionJsonResponse.Id;

                var response = client.JobManagement.GetJob(jobId);
                Assert.NotNull(response);
                Assert.Equal(response.StatusCode, HttpStatusCode.OK);

                var job = client.JobManagement.KillJob(jobId);
                Assert.NotNull(job);
                Assert.Equal(job.JobDetail.Status.State, "KILLED");
            }
        }

        [Fact]
        public void MapReduceJobTimeOut()
        {
            if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
            {
                using (var context = UndoContext.Current)
                {
                    context.Start();

                    var client = TestUtils.GetHDInsightJobManagementClient();

                    var parameters = GetMapReduceJobParameters();

                    var jobId = client.JobManagement.SubmitMapReduceJob(parameters).JobSubmissionJsonResponse.Id;

                    string exceptionMessage = string.Empty;
                    var startTime = DateTime.UtcNow;

                    try
                    {
                        // Generate Cloud Exception due to timeout and check if Job is killed.
                        client.JobManagement.WaitForJobCompletion(jobId, duration: TimeSpan.FromSeconds(10), waitInterval: TimeSpan.FromSeconds(10));
                    }
                    catch (TimeoutException ex)
                    {
                        exceptionMessage = ex.Message;
                    }

                    var duration = (DateTime.UtcNow - startTime).Seconds;

                    Assert.True(duration >= 10);
                    Assert.True(exceptionMessage.Contains("The requested task failed to complete in the allotted time"));
                }
            }
        }

        [Fact]
        public void ValidateJobClientHttpTimeOut()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = TestUtils.GetHDInsightJobManagementClient();

                Assert.True(TimeSpan.Compare(client.HttpClient.Timeout, TimeSpan.FromMinutes(8)) == 0);
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

        [Fact]
        public void SubmitHiveJobAsync()
        {
            var parameters = new HiveJobSubmissionParameters
            {
                Query = @"select querydwelltime+2 from hivesampletable where clientid = 8"
            };

            SubmitHiveJobAndValidateOutput(parameters, "15.92", runAyncAPI : true);
        }

        [Fact]
        [Trait("Category", "Windows")]
        public void SubmitHiveJob_Windows()
        {
            var parameters = new HiveJobSubmissionParameters
            {
                Query = @"select querydwelltime+2 from hivesampletable where clientid = 8"
            };

            SubmitHiveJobAndValidateOutput(parameters, "15.92", runAyncAPI: false, isWindowsCluster : true);
        }

        [Fact]
        [Trait("Category", "Windows")]
        public void SubmitHiveJobAsync_Windows()
        {
            var parameters = new HiveJobSubmissionParameters
            {
                Query = @"select querydwelltime+2 from hivesampletable where clientid = 8"
            };

            SubmitHiveJobAndValidateOutput(parameters, "15.92", runAyncAPI: true, isWindowsCluster : true);
        }

        public void SubmitHiveJobAndValidateOutput(HiveJobSubmissionParameters parameters, string expectedOutputPart, bool runAyncAPI = false, bool isWindowsCluster = false)
        {
            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = TestUtils.GetHDInsightJobManagementClient(isWindowsCluster);

                var response = runAyncAPI ? client.JobManagement.SubmitHiveJobAsync(parameters).Result
                                    : client.JobManagement.SubmitHiveJob(parameters);
                Assert.NotNull(response);
                Assert.Equal(response.StatusCode, HttpStatusCode.OK);

                var jobId = response.JobSubmissionJsonResponse.Id;
                Assert.Contains("job_", jobId, StringComparison.InvariantCulture);

                var jobStatus = client.JobManagement.WaitForJobCompletion(jobId, TestUtils.JobWaitInterval, TestUtils.JobPollInterval);

                var storageAccess = GetStorageAccessObject(isWindowsCluster);

                if (jobStatus.JobDetail.ExitValue == 0)
                {
                    if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
                    {
                        // Retrieve Job Output
                        var output = client.JobManagement.GetJobOutput(jobId, storageAccess);
                        string textOutput = Convert(output);
                        Assert.True(textOutput.Contains(expectedOutputPart));
                    }
                }
                else
                {
                    if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
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
            SubmitMapReduceJobAndValidateOutput();
        }

        [Fact]
        public void SubmitMapReduceJobAsync()
        {
            SubmitMapReduceJobAndValidateOutput(runAyncAPI : true);
        }

        [Fact]
        [Trait("Category", "Windows")]
        public void SubmitMapReduceJob_Windows()
        {
            SubmitMapReduceJobAndValidateOutput(runAyncAPI: false, isWindowsCluster : true);
        }

        [Fact]
        [Trait("Category", "Windows")]
        public void SubmitMapReduceJobAsync_Windows()
        {
            SubmitMapReduceJobAndValidateOutput(runAyncAPI: true, isWindowsCluster : true);
        }

        public void SubmitMapReduceJobAndValidateOutput(bool runAyncAPI = false, bool isWindowsCluster = false)
        {
            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = TestUtils.GetHDInsightJobManagementClient(isWindowsCluster);

                var parameters = GetMapReduceJobParameters();

                var response = runAyncAPI ? client.JobManagement.SubmitMapReduceJobAsync(parameters).Result
                                : client.JobManagement.SubmitMapReduceJob(parameters);

                Assert.NotNull(response);
                Assert.Equal(response.StatusCode, HttpStatusCode.OK);

                var jobId = response.JobSubmissionJsonResponse.Id;
                Assert.Contains("job_", jobId, StringComparison.InvariantCulture);

                var jobStatus = client.JobManagement.WaitForJobCompletion(jobId, TestUtils.JobWaitInterval, TestUtils.JobPollInterval);

                var storageAccess = GetStorageAccessObject(isWindowsCluster);

                if (jobStatus.JobDetail.ExitValue == 0)
                {
                    if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
                    {
                        // Retrieve Job Output
                        var output = client.JobManagement.GetJobOutput(jobId, storageAccess);
                        string textOutput = Convert(output);
                        Assert.True(textOutput.Contains("Estimated value of Pi is 3.14"));
                    }
                }
                else
                {
                    if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
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
            var parameters = GetMRStreamingJobSubmissionParameters();

            SubmitMapReduceStreamingJobAndValidateOutput(parameters);
        }

        [Fact]
        public void SubmitMapReduceStreamingJobAsync()
        {
            var parameters = GetMRStreamingJobSubmissionParameters();

            SubmitMapReduceStreamingJobAndValidateOutput(parameters, runAyncAPI : true);
        }

        [Fact]
        [Trait("Category", "Windows")]
        public void SubmitMapReduceStreamingJobWithFilesParam()
        {
            var parameters = GetMRStreamingJobSubmissionParameters(true);

            SubmitMapReduceStreamingJobAndValidateOutput(parameters, runAyncAPI: false, isWindowsCluster : true);
        }

        [Fact]
        [Trait("Category", "Windows")]
        public void SubmitMapReduceStreamingJobWithFilesParamAsync()
        {
            var parameters = GetMRStreamingJobSubmissionParameters(true);

            SubmitMapReduceStreamingJobAndValidateOutput(parameters, runAyncAPI: true, isWindowsCluster : true);
        }

        public MapReduceStreamingJobSubmissionParameters GetMRStreamingJobSubmissionParameters(bool isWindowsCluster = false)
        {
            var parameters = new MapReduceStreamingJobSubmissionParameters
            {
                Mapper = isWindowsCluster ? "cat.exe" : "cat",
                Reducer = isWindowsCluster ? "wc.exe" : "wc",
                Input = "/example/data/gutenberg/davinci.txt",
                Output = "/example/data/gutenberg/wcount/" + Guid.NewGuid()
            };

            if (isWindowsCluster)
            {
                parameters.Files = new List<string> { "/example/apps/wc.exe", "/example/apps/cat.exe" };
            }

            return parameters;
        }

        public void SubmitMapReduceStreamingJobAndValidateOutput(MapReduceStreamingJobSubmissionParameters parameters, bool runAyncAPI = false, bool isWindowsCluster = false)
        {
            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = TestUtils.GetHDInsightJobManagementClient(isWindowsCluster);

                var response = runAyncAPI ? client.JobManagement.SubmitMapReduceStreamingJobAsync(parameters).Result
                    : client.JobManagement.SubmitMapReduceStreamingJob(parameters);

                Assert.NotNull(response);
                Assert.Equal(response.StatusCode, HttpStatusCode.OK);

                var jobId = response.JobSubmissionJsonResponse.Id;
                Assert.Contains("job_", jobId, StringComparison.InvariantCulture);

                var jobStatus = client.JobManagement.WaitForJobCompletion(jobId, TestUtils.JobWaitInterval, TestUtils.JobPollInterval);

                var storageAccess = GetStorageAccessObject(isWindowsCluster);

                if (jobStatus.JobDetail.ExitValue == 0)
                {
                    if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
                    {
                        // Retrieve Job Output
                        var output = client.JobManagement.GetJobOutput(jobId, storageAccess);
                        string textOutput = Convert(output);
                        Assert.True(textOutput.Length > 0);
                    }
                }
                else
                {
                    if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
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
            var parameters = GetPigJobSubmissionParameters();
            SubmitPigJobAndValidateOutput(parameters);
        }

        [Fact]
        public void SubmitPigJobAsync()
        {
            var parameters = GetPigJobSubmissionParameters();
            SubmitPigJobAndValidateOutput(parameters, runAyncAPI : true);
        }

        [Fact]
        [Trait("Category", "Windows")]
        public void SubmitPigJob_Windows()
        {
            var parameters = GetPigJobSubmissionParameters();
            SubmitPigJobAndValidateOutput(parameters, runAyncAPI: false, isWindowsCluster : true);
        }

        [Fact]
        [Trait("Category", "Windows")]
        public void SubmitPigJobAsync_Windows()
        {
            var parameters = GetPigJobSubmissionParameters();
            SubmitPigJobAndValidateOutput(parameters, runAyncAPI: true, isWindowsCluster: true);
        }

        public PigJobSubmissionParameters GetPigJobSubmissionParameters()
        {
            return new PigJobSubmissionParameters()
            {
                Query = "LOGS = LOAD 'wasb:///example/data/sample.log';" +
                                "LEVELS = foreach LOGS generate REGEX_EXTRACT($0, '(TRACE|DEBUG|INFO|WARN|ERROR|FATAL)', 1)  as LOGLEVEL;" +
                                "FILTEREDLEVELS = FILTER LEVELS by LOGLEVEL is not null;" +
                                "GROUPEDLEVELS = GROUP FILTEREDLEVELS by LOGLEVEL;" +
                                "FREQUENCIES = foreach GROUPEDLEVELS generate group as LOGLEVEL, COUNT(FILTEREDLEVELS.LOGLEVEL) as COUNT;" +
                                "RESULT = order FREQUENCIES by COUNT desc;" +
                                "DUMP RESULT;"
            };
        }

        public void SubmitPigJobAndValidateOutput(PigJobSubmissionParameters parameters, bool runAyncAPI = false, bool isWindowsCluster = false)
        {
            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = TestUtils.GetHDInsightJobManagementClient(isWindowsCluster);

                var response = runAyncAPI ? client.JobManagement.SubmitPigJobAsync(parameters).Result
                    : client.JobManagement.SubmitPigJob(parameters);

                Assert.NotNull(response);
                Assert.Equal(response.StatusCode, HttpStatusCode.OK);

                var jobId = response.JobSubmissionJsonResponse.Id;
                Assert.Contains("job_", jobId, StringComparison.InvariantCulture);

                var jobStatus = client.JobManagement.WaitForJobCompletion(jobId, TestUtils.JobWaitInterval, TestUtils.JobPollInterval);

                var storageAccess = GetStorageAccessObject(isWindowsCluster);

                if (jobStatus.JobDetail.ExitValue == 0)
                {
                    // Retrieve Job Output
                    if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
                    {
                        var output = client.JobManagement.GetJobOutput(jobId, storageAccess);
                        string textOutput = Convert(output);
                        Assert.True(textOutput.Contains("(DEBUG,"));
                    }
                }
                else
                {
                    if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
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
            var parameters = GetSqoopJobSubmissionParameters();
            SubmitSqoopJobAndValidateOutput(parameters);
        }

        [Fact]
        public void SubmitSqoopJobAsync()
        {
            var parameters = GetSqoopJobSubmissionParameters();
            SubmitSqoopJobAndValidateOutput(parameters, runAyncAPI : true);
        }

        [Fact]
        [Trait("Category", "Windows")]
        public void SubmitSqoopJob_Windows()
        {
            var parameters = GetSqoopJobSubmissionParameters(true);
            SubmitSqoopJobAndValidateOutput(parameters, runAyncAPI: false, isWindowsCluster : true);
        }

        [Fact]
        [Trait("Category", "Windows")]
        public void SubmitSqoopJobAsync_Windows()
        {
            var parameters = GetSqoopJobSubmissionParameters(true);
            SubmitSqoopJobAndValidateOutput(parameters, runAyncAPI: true, isWindowsCluster : true);
        }

        public SqoopJobSubmissionParameters GetSqoopJobSubmissionParameters(bool isWindowsCluster = false)
        {
            var parameters = new SqoopJobSubmissionParameters
            {
                Command = "import --connect " + TestUtils.SQLServerConnectionString + " --table " + TestUtils.SQLServerTableName
                    + " --warehouse-dir /user/admin/sqoop/" + Guid.NewGuid().ToString()
                    + " --hive-import -m 1 --hive-table " + TestUtils.SQLServerTableName + Guid.NewGuid().ToString().Replace("-",""),
                StatusDir = "SqoopStatus",
            };
            
            return parameters;
        }

        public void SubmitSqoopJobAndValidateOutput(SqoopJobSubmissionParameters parameters, bool runAyncAPI = false, bool isWindowsCluster = false)
        {
            using (var context = UndoContext.Current)
            {
                context.Start();

                var client = TestUtils.GetHDInsightJobManagementClient(isWindowsCluster);

                var response = runAyncAPI ? client.JobManagement.SubmitSqoopJobAsync(parameters).Result
                                : client.JobManagement.SubmitSqoopJob(parameters);

                Assert.NotNull(response);
                Assert.Equal(response.StatusCode, HttpStatusCode.OK);

                var jobId = response.JobSubmissionJsonResponse.Id;
                Assert.Contains("job_", jobId, StringComparison.InvariantCulture);

                var jobStatus = client.JobManagement.WaitForJobCompletion(jobId, TestUtils.JobWaitInterval, TestUtils.JobPollInterval);

                var storageAccess = GetStorageAccessObject(isWindowsCluster);

                if (jobStatus.JobDetail.ExitValue == 0)
                {
                    if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
                    {
                        // Retrieve Job Output
                        var output = client.JobManagement.GetJobOutput(jobId, storageAccess);
                        string textOutput = Convert(output);
                        Assert.True(textOutput.Length > 0);
                    }
                }
                else
                {
                    if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
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

                var client = TestUtils.GetHDInsightJobManagementClient();

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

                var jobStatus = client.JobManagement.WaitForJobCompletionAsync(jobId).Result;

                Assert.True(jobStatus.JobDetail.ExitValue > 0);

                var storageAccess = GetStorageAccessObject();

                if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
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

        private IStorageAccess GetStorageAccessObject(bool IsWindowsCluster = false)
        {
            return new AzureStorageAccess(IsWindowsCluster ? TestUtils.WinStorageAccountName : TestUtils.StorageAccountName,
                                    IsWindowsCluster ? TestUtils.WinStorageAccountKey : TestUtils.StorageAccountKey,
                                    IsWindowsCluster ? TestUtils.WinDefaultContainer : TestUtils.DefaultContainer);
        }
    }
}
