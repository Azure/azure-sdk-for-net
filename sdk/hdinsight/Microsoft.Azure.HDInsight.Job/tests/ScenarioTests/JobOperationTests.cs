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

namespace Microsoft.Azure.HDInsight.Job.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.IO;
    using Microsoft.Azure.Test.HttpRecorder;
    using Xunit;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.Azure.HDInsight.Job;
    using Microsoft.Azure.HDInsight.Job.Models;
    using System.Linq;

    public class JobOperationTests : TestBase, IClassFixture<CommonTestsFixture> 
    {
        public CommonTestsFixture CommonData { get; set; }

        public JobOperationTests(CommonTestsFixture commonData)
        {
            this.CommonData = commonData;
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
            using (var context = MockContext.Start(this.GetType()))
            using (var client = this.CommonData.GetHDInsightJobClient(context))
            {
                var parameters = GetMapReduceJobParameters();

                var jobId = client.Job.SubmitMapReduceJob(parameters).Id;

                var response = client.Job.GetWithHttpMessagesAsync(jobId).GetAwaiter().GetResult();
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.Response.StatusCode);

                var job = client.Job.Kill(jobId);
                Assert.NotNull(job);
                Assert.Equal("KILLED", job.Status.State);
            }
        }

        [Fact]
        public void MapReduceJobTimeOut()
        {
            if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
            {
                using (var context = MockContext.Start(this.GetType()))
                using (var client = this.CommonData.GetHDInsightJobClient(context))
                {
                    var parameters = GetMapReduceJobParameters();

                    var jobId = client.Job.SubmitMapReduceJob(parameters).Id;

                    string exceptionMessage = string.Empty;
                    var startTime = DateTime.UtcNow;

                    try
                    {
                        // Generate Cloud Exception due to timeout and check if Job is killed.
                        client.Job.WaitForJobCompletion(jobId, duration: TimeSpan.FromSeconds(10), waitInterval: TimeSpan.FromSeconds(10));
                    }
                    catch (TimeoutException ex)
                    {
                        exceptionMessage = ex.Message;
                    }

                    var duration = (DateTime.UtcNow - startTime).Seconds;

                    Assert.True(duration >= 10);
                    Assert.Contains("The requested task failed to complete in the allotted time", exceptionMessage);
                }
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
        public void SubmitHiveJobLargeQuery()
        {
            var query = string.Empty;

            // Maximum input string size Uri.EscapeDataString can accept is 65520.
            while (query.Length < 65520)
            {
                query += "select 1.0000000001 + 0.00001 limit 1;";
            }

            var parameters = new HiveJobSubmissionParameters
            {
                Query = query
            };

            SubmitHiveJobAndValidateOutput(parameters, "1.0000100001");
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

            SubmitHiveJobAndValidateOutput(parameters, "15.92", runAyncAPI: true);
        }

        private void SubmitHiveJobAndValidateOutput(HiveJobSubmissionParameters parameters, string expectedOutputPart, bool runAyncAPI = false)
        {
            using (var context = MockContext.Start(this.GetType()))
            using (var client = this.CommonData.GetHDInsightJobClient(context))
            {
                var response = runAyncAPI ? client.Job.SubmitHiveJobAsync(parameters).Result
                                    : client.Job.SubmitHiveJob(parameters);
                Assert.NotNull(response);

                var jobId = response.Id;
                Assert.Contains("job_", jobId, StringComparison.InvariantCulture);

                var jobStatus = client.Job.WaitForJobCompletion(jobId, this.CommonData.JobWaitInterval, this.CommonData.JobPollInterval);

                var storageAccess = GetStorageAccessObject();

                if (jobStatus.ExitValue == 0)
                {
                    if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
                    {
                        // Retrieve Job Output
                        var output = client.Job.GetJobOutput(jobId, storageAccess);
                        string textOutput = Convert(output);
                        Assert.Contains(expectedOutputPart, textOutput);
                    }
                }
                else
                {
                    if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
                    {
                        var output = client.Job.GetJobErrorLogs(jobId, storageAccess);
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
            SubmitMapReduceJobAndValidateOutput(runAyncAPI: true);
        }

        private void SubmitMapReduceJobAndValidateOutput(bool runAyncAPI = false)
        {
            using (var context = MockContext.Start(this.GetType()))
            using (var client = this.CommonData.GetHDInsightJobClient(context))
            {
                var parameters = GetMapReduceJobParameters();

                var response = runAyncAPI ? client.Job.SubmitMapReduceJobAsync(parameters).Result
                                : client.Job.SubmitMapReduceJob(parameters);

                Assert.NotNull(response);

                var jobId = response.Id;
                Assert.Contains("job_", jobId, StringComparison.InvariantCulture);

                var jobStatus = client.Job.WaitForJobCompletion(jobId, this.CommonData.JobWaitInterval, this.CommonData.JobPollInterval);

                var storageAccess = GetStorageAccessObject();

                if (jobStatus.ExitValue == 0)
                {
                    if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
                    {
                        // Retrieve Job Output
                        var output = client.Job.GetJobOutput(jobId, storageAccess);
                        string textOutput = Convert(output);
                        Assert.Contains("Estimated value of Pi is 3.14", textOutput);
                    }
                }
                else
                {
                    if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
                    {
                        var output = client.Job.GetJobErrorLogs(jobId, storageAccess);
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

            SubmitMapReduceStreamingJobAndValidateOutput(parameters, runAyncAPI: true);
        }

        public MapReduceStreamingJobSubmissionParameters GetMRStreamingJobSubmissionParameters()
        {
            var parameters = new MapReduceStreamingJobSubmissionParameters
            {
                Mapper = "cat",
                Reducer = "wc",
                Input = "/example/data/gutenberg/davinci.txt",
                Output = "/example/data/gutenberg/wcount/" + Guid.NewGuid()
            };

            return parameters;
        }

        private void SubmitMapReduceStreamingJobAndValidateOutput(MapReduceStreamingJobSubmissionParameters parameters, bool runAyncAPI = false)
        {
            using (var context = MockContext.Start(this.GetType()))
            using (var client = this.CommonData.GetHDInsightJobClient(context))
            {
                var response = runAyncAPI ? client.Job.SubmitMapReduceStreamingJobAsync(parameters).Result
                    : client.Job.SubmitMapReduceStreamingJob(parameters);

                Assert.NotNull(response);

                var jobId = response.Id;
                Assert.Contains("job_", jobId, StringComparison.InvariantCulture);

                var jobStatus = client.Job.WaitForJobCompletion(jobId, this.CommonData.JobWaitInterval, this.CommonData.JobPollInterval);

                var storageAccess = GetStorageAccessObject();

                if (jobStatus.ExitValue == 0)
                {
                    if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
                    {
                        // Retrieve Job Output
                        var output = client.Job.GetJobOutput(jobId, storageAccess);
                        string textOutput = Convert(output);
                        Assert.True(textOutput.Length > 0);
                    }
                }
                else
                {
                    if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
                    {
                        var output = client.Job.GetJobErrorLogs(jobId, storageAccess);
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
            SubmitPigJobAndValidateOutput(parameters, runAyncAPI: true);
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

        private void SubmitPigJobAndValidateOutput(PigJobSubmissionParameters parameters, bool runAyncAPI = false)
        {
            using (var context = MockContext.Start(this.GetType()))
            using (var client = this.CommonData.GetHDInsightJobClient(context))
            {
                var response = runAyncAPI ? client.Job.SubmitPigJobAsync(parameters).Result
                    : client.Job.SubmitPigJob(parameters);

                Assert.NotNull(response);

                var jobId = response.Id;
                Assert.Contains("job_", jobId, StringComparison.InvariantCulture);

                var jobStatus = client.Job.WaitForJobCompletion(jobId, this.CommonData.JobWaitInterval, this.CommonData.JobPollInterval);

                var storageAccess = GetStorageAccessObject();

                if (jobStatus.ExitValue == 0)
                {
                    // Retrieve Job Output
                    if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
                    {
                        var output = client.Job.GetJobOutput(jobId, storageAccess);
                        string textOutput = Convert(output);
                        Assert.Contains("(DEBUG,", textOutput);
                    }
                }
                else
                {
                    if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
                    {
                        var output = client.Job.GetJobErrorLogs(jobId, storageAccess);
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

        public SqoopJobSubmissionParameters GetSqoopJobSubmissionParameters()
        {
            var parameters = new SqoopJobSubmissionParameters
            {
                Command = "import --connect " + this.CommonData.SQLServerJdbcConnectionString + " --table " + this.CommonData.SQLServerTableName
                    + " --warehouse-dir /user/admin/sqoop/" + Guid.NewGuid().ToString()
                    + " --hive-import -m 1 --hive-table " + this.CommonData.SQLServerTableName + Guid.NewGuid().ToString().Replace("-",""),
                StatusDir = "SqoopStatus",
            };
            
            return parameters;
        }

        private void SubmitSqoopJobAndValidateOutput(SqoopJobSubmissionParameters parameters, bool runAyncAPI = false)
        {
            using (var context = MockContext.Start(this.GetType()))
            using (var client = this.CommonData.GetHDInsightJobClient(context))
            {
                var response = runAyncAPI ? client.Job.SubmitSqoopJobAsync(parameters).Result
                                : client.Job.SubmitSqoopJob(parameters);

                Assert.NotNull(response);

                var jobId = response.Id;
                Assert.Contains("job_", jobId, StringComparison.InvariantCulture);

                var jobStatus = client.Job.WaitForJobCompletion(jobId, this.CommonData.JobWaitInterval, this.CommonData.JobPollInterval);

                var storageAccess = GetStorageAccessObject();

                if (jobStatus.ExitValue == 0)
                {
                    if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
                    {
                        // Retrieve Job Output
                        var output = client.Job.GetJobOutput(jobId, storageAccess);
                        string textOutput = Convert(output);
                        Assert.True(textOutput.Length > 0);
                    }
                }
                else
                {
                    if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
                    {
                        var output = client.Job.GetJobErrorLogs(jobId, storageAccess);
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
            using (var context = MockContext.Start(this.GetType()))
            using (var client = this.CommonData.GetHDInsightJobClient(context))
            {
                var parameters = new HiveJobSubmissionParameters
                {
                    Query = "FAKEQUERY;",
                    StatusDir = "jobstatus"
                };

                var response = client.Job.SubmitHiveJob(parameters);
                Assert.NotNull(response);

                var jobId = response.Id;
                Assert.Contains("job_", jobId, StringComparison.InvariantCulture);

                var jobStatus = client.Job.WaitForJobCompletionAsync(jobId, this.CommonData.JobWaitInterval, this.CommonData.JobPollInterval).Result;

                Assert.True(jobStatus.ExitValue > 0);

                var storageAccess = GetStorageAccessObject();

                if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
                {
                    var output = client.Job.GetJobErrorLogs(jobId, storageAccess);
                    Assert.NotNull(output);
                    Assert.True(output.Length > 0);
                    string errorTextOutput = Convert(output);
                    Assert.True(!string.IsNullOrEmpty(errorTextOutput));
                }
            }
        }

        [Fact]
        public void ListJobs()
        {
            using (var context = MockContext.Start(this.GetType()))
            using (var client = this.CommonData.GetHDInsightJobClient(context))
            {
                var response = client.Job.List();
                Assert.NotNull(response);
                int originalJobCount = response.Count;

                var parameters = new HiveJobSubmissionParameters
                {
                    Query = @"select querydwelltime+2 from hivesampletable where clientid = 8"
                };

                var submitResponse = client.Job.SubmitHiveJob(parameters);
                Assert.NotNull(submitResponse);

                response = client.Job.List();
                Assert.NotNull(response);
                Assert.Equal(originalJobCount + 1, response.Count);
            }
        }

        [Fact]
        public void GetJobsPagination()
        {
            using (var context = MockContext.Start(this.GetType()))
            using (var client = this.CommonData.GetHDInsightJobClient(context))
            {
                var parameters = new HiveJobSubmissionParameters
                {
                    Query = @"select querydwelltime+2 from hivesampletable where clientid = 8"
                };

                // Prepare job data
                var submitResponse = client.Job.SubmitHiveJob(parameters);
                Assert.NotNull(submitResponse);
                submitResponse = client.Job.SubmitHiveJob(parameters);
                Assert.NotNull(submitResponse);
                submitResponse = client.Job.SubmitHiveJob(parameters);
                Assert.NotNull(submitResponse);
                submitResponse = client.Job.SubmitHiveJob(parameters);
                Assert.NotNull(submitResponse);

                var allJobs = client.Job.List();
                Assert.True(allJobs.Count > 0);

                int numOfEntries = 3;
                int index = 0;
                string jobid = string.Empty;
                while (true)
                {
                    var t = client.Job.ListAfterJobId(jobid, numOfEntries);
                    jobid = t.Last().Id;
                    index += t.Count;

                    var expectedJobId = allJobs.ElementAt(index - 1).Id;
                    Assert.Equal(expectedJobId, jobid);

                    if (t.Count != numOfEntries || allJobs.Count <= index)
                    {
                        break;
                    }
                }
            }
        }

        [Fact]
        public void GetJobWithInvalidId()
        {
            using (var context = MockContext.Start(this.GetType()))
            using (var client = this.CommonData.GetHDInsightJobClient(context))
            {
                string jobId = "invalid_job_id";
                var ex = Assert.Throws<JobOperationsErrorResponseException>(() => client.Job.Get(jobId));
                Assert.Equal(HttpStatusCode.InternalServerError, ex.Response.StatusCode);
                Assert.Equal($"org.apache.hive.hcatalog.templeton.BadParam: JobId string : {jobId} is not properly formed", ex.Body.Error);
            }
        }

        private static string Convert(Stream stream)
        {
            var reader = new StreamReader(stream);
            var text = reader.ReadToEnd();
            return text;
        }

        private IStorageAccess GetStorageAccessObject()
        {
            return new AzureStorageAccess(this.CommonData.StorageAccountName, this.CommonData.StorageAccountAccessKey, this.CommonData.ContainerName);
        }
    }
}
