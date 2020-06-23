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

    public class LivyOperationTests : TestBase, IClassFixture<SparkJobTestsFixture>
    {
        public SparkJobTestsFixture CommonData { get; set; }

        public LivyOperationTests(SparkJobTestsFixture commonData)
        {
            this.CommonData = commonData;
        }

        [Fact]
        public void ListJobsSparkBatch()
        {
            using (var context = MockContext.Start(this.GetType()))
            using (var client = this.CommonData.GetHDInsightSparkJobClient(context))
            {
                var originalResponse = client.Job.ListSparkBatchJob();
                Assert.NotNull(originalResponse);

                SparkBatchJobRequest createRequest = new SparkBatchJobRequest
                {
                    File = "wasbs:///spark-examples.jar",
                    ClassName = "org.apache.spark.examples.SparkPi",
                    Arguments = new List<string>() { "10" }
                };
                var createResponse = client.Job.SubmitSparkBatchJob(createRequest);
                Assert.NotNull(createResponse);
                Assert.Equal("starting", createResponse.State);

                var checkResponse = client.Job.ListSparkBatchJob();
                Assert.NotNull(checkResponse);
                Assert.Equal(originalResponse.Total + 1, checkResponse.Total);

                var specifySizeResponse = originalResponse = client.Job.ListSparkBatchJob(1, 0);
                Assert.NotNull(checkResponse);
                Assert.Equal(1, specifySizeResponse.FromProperty);
                Assert.Equal(0, specifySizeResponse.Sessions.Count);
            }
        }

        [Fact]
        public void GetJobsSparkBatch()
        {
            using (var context = MockContext.Start(this.GetType()))
            using (var client = this.CommonData.GetHDInsightSparkJobClient(context))
            {
                SparkBatchJobRequest createRequest = new SparkBatchJobRequest
                {
                    File = "wasbs:///spark-examples.jar",
                    ClassName = "org.apache.spark.examples.SparkPi",
                    Arguments = new List<string>() { "10" }
                };
                var createResponse = client.Job.SubmitSparkBatchJob(createRequest);
                Assert.NotNull(createResponse);
                Assert.Equal("starting", createResponse.State);

                var response = client.Job.GetSparkBatchJob((int)createResponse.Id);
                Assert.NotNull(response);
            }
        }

        [Fact]
        public void OperationJobsSparkBatch()
        {
            using (var context = MockContext.Start(this.GetType()))
            using (var client = this.CommonData.GetHDInsightSparkJobClient(context))
            {
                SparkBatchJobRequest createRequest = new SparkBatchJobRequest
                {
                    File = "wasbs:///spark-examples.jar",
                    ClassName = "org.apache.spark.examples.SparkPi",
                    Arguments = new List<string>() { "10" }
                };
                var createResponse = client.Job.SubmitSparkBatchJob(createRequest);
                Assert.NotNull(createResponse);
                Assert.Equal("starting", createResponse.State);

                var originalResponse = client.Job.ListSparkBatchJob();
                Assert.NotNull(originalResponse);

                client.Job.DeleteSparkBatchJob((int)createResponse.Id);

                var checkResponse = client.Job.ListSparkBatchJob();
                Assert.NotNull(checkResponse);
                Assert.Equal(originalResponse.Total - 1, checkResponse.Total);
            }
        }

        [Fact]
        public void ListJobsSparkSession()
        {
            using (var context = MockContext.Start(this.GetType()))
            using (var client = this.CommonData.GetHDInsightSparkJobClient(context))
            {
                var originalResponse = client.Job.ListSparkSessionJob();
                Assert.NotNull(originalResponse);

                SparkSessionJobRequest createRequest = new SparkSessionJobRequest
                {
                    Kind = SessionJobKind.Spark
                };

                var createResponse = client.Job.SubmitSparkSessionJob(createRequest);
                Assert.NotNull(createResponse);
                Assert.Equal("starting", createResponse.State);
                TestUtilities.Wait(10000);

                var checkResponse = client.Job.ListSparkSessionJob();
                Assert.NotNull(checkResponse);
                Assert.Equal(originalResponse.Total + 1, checkResponse.Total);

                var specifySizeResponse = client.Job.ListSparkSessionJob(1, 0);
                Assert.NotNull(checkResponse);
                Assert.Equal(1, specifySizeResponse.FromProperty);
                Assert.Equal(0, specifySizeResponse.Sessions.Count);

                client.Job.DeleteSparkSessionJob((int)createResponse.Id);
            }
        }

        [Fact]
        public void GetJobsSparkSession()
        {
            using (var context = MockContext.Start(this.GetType()))
            using (var client = this.CommonData.GetHDInsightSparkJobClient(context))
            {
                SparkSessionJobRequest createRequest = new SparkSessionJobRequest
                {
                    Kind = SessionJobKind.Spark
                };
                var createResponse = client.Job.SubmitSparkSessionJob(createRequest);
                Assert.NotNull(createResponse);
                Assert.Equal("starting", createResponse.State);
                TestUtilities.Wait(10000);

                var response = client.Job.GetSparkSessionJob((int)createResponse.Id);
                Assert.NotNull(response);

                client.Job.DeleteSparkSessionJob((int)createResponse.Id);
            }
        }

        [Fact]
        public void OpeartionJobsSparkSession()
        {
            using (var context = MockContext.Start(this.GetType()))
            using (var client = this.CommonData.GetHDInsightSparkJobClient(context))
            {
                //create session
                SparkSessionJobRequest createRequest = new SparkSessionJobRequest
                {
                    Kind = SessionJobKind.Spark
                };
                var createResponse = client.Job.SubmitSparkSessionJob(createRequest);
                Assert.NotNull(createResponse);
                Assert.Equal("starting", createResponse.State);

                var originalResponse = client.Job.ListSparkSessionJob();
                Assert.NotNull(originalResponse);

                //delete session
                client.Job.DeleteSparkSessionJob((int)createResponse.Id);

                var checkResponse = client.Job.ListSparkSessionJob();
                Assert.NotNull(checkResponse);
                Assert.Equal(originalResponse.Total - 1, checkResponse.Total);
            }
        }

        [Fact]
        public void OperationJobsSparkSessionStatments()
        {
            using (var context = MockContext.Start(this.GetType()))
            using (var client = this.CommonData.GetHDInsightSparkJobClient(context))
            {
                //create session
                SparkSessionJobRequest createRequest = new SparkSessionJobRequest
                {
                    Kind = SessionJobKind.Spark
                };

                var createResponse = client.Job.SubmitSparkSessionJob(createRequest);
                Assert.NotNull(createResponse);
                Assert.Equal("starting", createResponse.State);
                TestUtilities.Wait(10000);

                var originalResponse = client.Job.ListSparkStatementJob((int)createResponse.Id);
                Assert.NotNull(originalResponse);

                //create statements
                SparkStatementRequest statementRequest = new SparkStatementRequest
                {
                    Code = "1+1"
                };

                var statementResponse = client.Job.SubmitSparkStatementJob((int)createResponse.Id, statementRequest);
                Assert.NotNull(statementResponse);
                Assert.Equal("waiting", statementResponse.State);

                var checkcreateResponse = client.Job.ListSparkStatementJob((int)createResponse.Id);
                Assert.NotNull(checkcreateResponse);
                Assert.Equal(originalResponse.Statements.Count + 1, checkcreateResponse.Statements.Count);
                TestUtilities.Wait(10000);

                //delete statements
                var cancelResponse = client.Job.DeleteSparkStatementJob((int)createResponse.Id, (int)statementResponse.Id);
                Assert.Equal("canceled", cancelResponse.CancelMessage);

                //delete session
                client.Job.DeleteSparkSessionJob((int)createResponse.Id);
            }
        }
    }
}
