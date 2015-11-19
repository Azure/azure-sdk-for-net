// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.HadoopClientTests
{
    using System;
    using System.Linq;
    using System.Runtime.Serialization;
    using Microsoft.Hadoop.Client;
    using Microsoft.Hadoop.Client.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;

    [TestClass]
    public class PayloadConverterTests : IntegrationTestBase
    {
        private readonly DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanDeserializeJobSubmissionResultFromRawJson()
        {
            var converter = new PayloadConverter();
            var jobId = converter.DeserializeJobSubmissionResponse(RawJobSubmissionResultsPayload);

            Assert.AreEqual("job_001", jobId);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanDeserializeJobSubmissionResultFromJsonWithErrorMessage()
        {
            var converter = new PayloadConverter();
            try
            {
                converter.DeserializeJobSubmissionResponse(RawJobSubmissionResultsPayloadWithError);
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("some error", ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void ICanDeserializeJobSubmissionResultWithBadJson()
        {
            var converter = new PayloadConverter();
            converter.DeserializeJobSubmissionResponse(BadJson);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void ICanDeserializeJobSubmissionResultWithEmptyJsonObject()
        {
            var converter = new PayloadConverter();
            converter.DeserializeJobSubmissionResponse(EmptyJsonObject);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(SerializationException))]
        public void ICanDeserializeJobSubmissionResultWithNonJsonObject()
        {
            var converter = new PayloadConverter();
            converter.DeserializeJobSubmissionResponse(EmptyJsonArray);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ICanDeserializeJobSubmissionResultWithMissingId()
        {
            var converter = new PayloadConverter();
            converter.DeserializeJobSubmissionResponse(JobSubmissionResultsPayloadMissingIdAndError);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanDeserializeJobListWithOneItemFromRawJson()
        {
            var converter = new PayloadConverter();
            var jobList = converter.DeserializeListJobResult(RawAllFieldsListJobsPayloadWithOneItem);

            Assert.AreEqual(1, jobList.Jobs.Count);
            var jobDetails = jobList.Jobs.First();
            Assert.AreEqual("job_002", jobDetails.JobId);
            Assert.AreEqual(0, jobDetails.ExitCode);
            Assert.AreEqual(unixEpoch.AddMilliseconds(1375484358898).ToLocalTime(), jobDetails.SubmissionTime);
            Assert.AreEqual("TestJob1", jobDetails.Name);
            Assert.AreEqual(JobStatusCode.Completed, jobDetails.StatusCode);
            Assert.AreEqual("/some/place", jobDetails.StatusDirectory);
            Assert.AreEqual("some query", jobDetails.Query);
            Assert.AreEqual("map 100% reduce 100%", jobDetails.PercentComplete);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanDeserializeJobListWithListJobsPayloadWithMultipleItemsOneValidOnePartial()
        {
            var converter = new PayloadConverter();
            var jobList = converter.DeserializeListJobResult(ListJobsPayloadWithMultipleItemsOneValidOnePartial);

            Assert.IsNotNull(jobList);
            Assert.IsNotNull(jobList.Jobs);
            var jobs = jobList.Jobs.ToList();

            Assert.AreEqual(2, jobs.Count);

            var firstJob = jobs[0];
            Assert.AreEqual("job_002", firstJob.JobId);
            Assert.AreEqual(0, firstJob.ExitCode);
            Assert.AreEqual(unixEpoch.AddMilliseconds(1375484358898).ToLocalTime(), firstJob.SubmissionTime);
            Assert.AreEqual("TestJob1", firstJob.Name);
            Assert.AreEqual(JobStatusCode.Completed, firstJob.StatusCode);
            Assert.AreEqual("/some/place", firstJob.StatusDirectory);
            Assert.AreEqual("some query", firstJob.Query);

            var secondJob = jobs[1];
            Assert.AreEqual("job_004", secondJob.JobId);
            Assert.AreEqual(0, secondJob.ExitCode);
            Assert.AreEqual(unixEpoch.AddMilliseconds(1475484358898).ToLocalTime(), secondJob.SubmissionTime);
            Assert.AreEqual("TestJob2", secondJob.Name);
            Assert.AreEqual(JobStatusCode.Unknown, secondJob.StatusCode);
            Assert.AreEqual(string.Empty, secondJob.StatusDirectory);
            Assert.AreEqual("some query", secondJob.Query);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanDeserializeEmptyJobList()
        {
            var converter = new PayloadConverter();
            var jobList = converter.DeserializeListJobResult(EmptyJsonArray);

            Assert.IsNotNull(jobList);
            Assert.IsNotNull(jobList.Jobs);
            var jobs = jobList.Jobs.ToList();

            Assert.AreEqual(0, jobs.Count);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanDeserializeJobListWithListJobsPayloadWithOneValidAndOneEmptyObject()
        {
            var converter = new PayloadConverter();
            var jobList = converter.DeserializeListJobResult(ValidAllFieldsListJobsPayloadWithOneValidAndOneEmptyObject);

            Assert.IsNotNull(jobList);
            Assert.IsNotNull(jobList.Jobs);
            var jobs = jobList.Jobs.ToList();

            Assert.AreEqual(1, jobs.Count);

            var firstJob = jobs[0];
            Assert.AreEqual("job_002", firstJob.JobId);
            Assert.AreEqual(0, firstJob.ExitCode);
            Assert.AreEqual(unixEpoch.AddMilliseconds(1375484358898).ToLocalTime(), firstJob.SubmissionTime);
            Assert.AreEqual("TestJob1", firstJob.Name);
            Assert.AreEqual(JobStatusCode.Completed, firstJob.StatusCode);
            Assert.AreEqual("/some/place", firstJob.StatusDirectory);
            Assert.AreEqual("some query", firstJob.Query);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanDeserializeJobListWithListJobsPayloadWithMultipleItemsOneValidOneInvalid()
        {
            var converter = new PayloadConverter();
            var jobList = converter.DeserializeListJobResult(ListJobsPayloadWithMultipleItemsOneValidOneInvalid);

            Assert.IsNotNull(jobList);
            Assert.IsNotNull(jobList.Jobs);
            var jobs = jobList.Jobs.ToList();

            Assert.AreEqual(1, jobs.Count);

            var firstJob = jobs[0];
            Assert.AreEqual("job_002", firstJob.JobId);
            Assert.AreEqual(0, firstJob.ExitCode);
            Assert.AreEqual(unixEpoch.AddMilliseconds(1375484358898).ToLocalTime(), firstJob.SubmissionTime);
            Assert.AreEqual("TestJob1", firstJob.Name);
            Assert.AreEqual(JobStatusCode.Completed, firstJob.StatusCode);
            Assert.AreEqual("/some/place", firstJob.StatusDirectory);
            Assert.AreEqual("some query", firstJob.Query);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanDeserializeJobListWithMultipleItems()
        {
            var converter = new PayloadConverter();
            var jobList = converter.DeserializeListJobResult(ValidAllFieldsListJobsPayloadWithMultipleItems);

            Assert.IsNotNull(jobList);
            Assert.IsNotNull(jobList.Jobs);
            var jobs = jobList.Jobs.ToList();

            Assert.AreEqual(2, jobs.Count);

            var firstJob = jobs[0];
            Assert.AreEqual("job_002", firstJob.JobId);
            Assert.AreEqual(0, firstJob.ExitCode);
            Assert.AreEqual(unixEpoch.AddMilliseconds(1375484358898).ToLocalTime(), firstJob.SubmissionTime);
            Assert.AreEqual("TestJob1", firstJob.Name);
            Assert.AreEqual(JobStatusCode.Completed, firstJob.StatusCode);
            Assert.AreEqual("/some/place", firstJob.StatusDirectory);
            Assert.AreEqual("some query", firstJob.Query);

            var secondJob = jobs[1];
            Assert.AreEqual("job_004", secondJob.JobId);
            Assert.AreEqual(0, secondJob.ExitCode);
            Assert.AreEqual(unixEpoch.AddMilliseconds(1475484358898).ToLocalTime(), secondJob.SubmissionTime);
            Assert.AreEqual("TestJob2", secondJob.Name);
            Assert.AreEqual(JobStatusCode.Completed, secondJob.StatusCode);
            Assert.AreEqual("/some/place", secondJob.StatusDirectory);
            Assert.AreEqual("some query", secondJob.Query);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanDeserializeJobListWithNoValidJobDetails()
        {
            var converter = new PayloadConverter();
            var jobList = converter.DeserializeListJobResult(JobListWithNoValidJobDetails);

            Assert.IsNotNull(jobList);
            Assert.IsNotNull(jobList.Jobs);
            var jobs = jobList.Jobs.ToList();

            Assert.AreEqual(0, jobs.Count);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanDeserializeJobDetails()
        {
            var converter = new PayloadConverter();
            var jobDetails = converter.DeserializeJobDetails(ValidjobDetailsPayload);

            Assert.AreEqual("job_001", jobDetails.JobId);
            Assert.AreEqual(0, jobDetails.ExitCode);
            Assert.AreEqual(unixEpoch.AddMilliseconds(1375484358898), jobDetails.SubmissionTime);
            Assert.AreEqual("TestJob1", jobDetails.Name);
            Assert.AreEqual(JobStatusCode.Completed, jobDetails.StatusCode);
            Assert.AreEqual("/some/place", jobDetails.StatusDirectory);
            Assert.AreEqual("some query", jobDetails.Query);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanDeserializeJobDetailsWithMissingStatusCode()
        {
            var converter = new PayloadConverter();
            var jobDetails = converter.DeserializeJobDetails(JobDetailsPayloadWithMissingStatusCode);

            Assert.AreEqual("job_001", jobDetails.JobId);
            Assert.AreEqual(0, jobDetails.ExitCode);
            Assert.AreEqual(unixEpoch.AddMilliseconds(1375484358898), jobDetails.SubmissionTime);
            Assert.AreEqual("TestJob1", jobDetails.Name);
            Assert.AreEqual(JobStatusCode.Unknown, jobDetails.StatusCode);
            Assert.AreEqual("/some/place", jobDetails.StatusDirectory);
            Assert.AreEqual("some query", jobDetails.Query);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanDeserializeJobDetailsWithMissingExecuteProperty()
        {
            var converter = new PayloadConverter();
            var jobDetails = converter.DeserializeJobDetails(JobDetailsPayloadWithMissingExecuteProperty);

            Assert.AreEqual("job_001", jobDetails.JobId);
            Assert.AreEqual(0, jobDetails.ExitCode);
            Assert.AreEqual(unixEpoch.AddMilliseconds(1375484358898), jobDetails.SubmissionTime);
            Assert.AreEqual("TestJob1", jobDetails.Name);
            Assert.AreEqual(JobStatusCode.Completed, jobDetails.StatusCode);
            Assert.AreEqual("/some/place", jobDetails.StatusDirectory);
            Assert.AreEqual(string.Empty, jobDetails.Query);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanDeserializeJobDetailsWithMissingStatusObject()
        {
            var converter = new PayloadConverter();
            var jobDetails = converter.DeserializeJobDetails(JobDetailsPayloadWithMissingStatusObject);

            Assert.AreEqual("job_001", jobDetails.JobId);
            Assert.AreEqual(0, jobDetails.ExitCode);
            Assert.AreEqual(DateTime.MinValue, jobDetails.SubmissionTime);
            Assert.AreEqual("TestJob1", jobDetails.Name);
            Assert.AreEqual(JobStatusCode.Unknown, jobDetails.StatusCode);
            Assert.AreEqual("/some/place", jobDetails.StatusDirectory);
            Assert.AreEqual("some query", jobDetails.Query);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanDeserializeJobDetailsWithMissingUserArgsObject()
        {
            var converter = new PayloadConverter();
            var jobDetails = converter.DeserializeJobDetails(JobDetailsPayloadWithMissingUserArgsObject);

            Assert.AreEqual("job_001", jobDetails.JobId);
            Assert.AreEqual(0, jobDetails.ExitCode);
            Assert.AreEqual(unixEpoch.AddMilliseconds(1375484358898), jobDetails.SubmissionTime);
            Assert.AreEqual(JobStatusCode.Completed, jobDetails.StatusCode);
            Assert.AreEqual(string.Empty, jobDetails.Name);
            Assert.AreEqual(string.Empty, jobDetails.StatusDirectory);
            Assert.AreEqual(string.Empty, jobDetails.Query);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanDeserializeJobDetailsWithMissingStatusDirectory()
        {
            var converter = new PayloadConverter();
            var jobDetails = converter.DeserializeJobDetails(JobDetailsPayloadWithMissingStatusDirectory);

            Assert.AreEqual("job_001", jobDetails.JobId);
            Assert.AreEqual(0, jobDetails.ExitCode);
            Assert.AreEqual(unixEpoch.AddMilliseconds(1375484358898), jobDetails.SubmissionTime);
            Assert.AreEqual(JobStatusCode.Completed, jobDetails.StatusCode);
            Assert.AreEqual("TestJob1", jobDetails.Name);
            Assert.AreEqual(string.Empty, jobDetails.StatusDirectory);
            Assert.AreEqual("some query", jobDetails.Query);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanDeserializeJobDetailsWithMissingDefinesArray()
        {
            var converter = new PayloadConverter();
            var jobDetails = converter.DeserializeJobDetails(JobDetailsPayloadWithMissingDefineArray);

            Assert.AreEqual("job_001", jobDetails.JobId);
            Assert.AreEqual(0, jobDetails.ExitCode);
            Assert.AreEqual(unixEpoch.AddMilliseconds(1375484358898), jobDetails.SubmissionTime);
            Assert.AreEqual(JobStatusCode.Completed, jobDetails.StatusCode);
            Assert.AreEqual(string.Empty, jobDetails.Name);
            Assert.AreEqual("/some/place", jobDetails.StatusDirectory);
            Assert.AreEqual("some query", jobDetails.Query);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanDeserializeJobDetailsWithMissingExitValue()
        {
            var converter = new PayloadConverter();
            var jobDetails = converter.DeserializeJobDetails(JobDetailsPayloadWithMissingExitValue);

            Assert.AreEqual("job_001", jobDetails.JobId);
            Assert.IsNull(jobDetails.ExitCode);
            Assert.AreEqual(unixEpoch.AddMilliseconds(1375484358898), jobDetails.SubmissionTime);
            Assert.AreEqual(JobStatusCode.Completed, jobDetails.StatusCode);
            Assert.AreEqual("TestJob1", jobDetails.Name);
            Assert.AreEqual("some query", jobDetails.Query);
            Assert.AreEqual("/some/place", jobDetails.StatusDirectory);
        }


        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanDeserializeJobDetailsWithNullExitValue()
        {
            var converter = new PayloadConverter();
            var jobDetails = converter.DeserializeJobDetails(JobDetailsPayloadWithNullExitValue);

            Assert.AreEqual("job_001", jobDetails.JobId);
            Assert.IsNull(jobDetails.ExitCode);
            Assert.AreEqual(unixEpoch.AddMilliseconds(1375484358898), jobDetails.SubmissionTime);
            Assert.AreEqual(JobStatusCode.Completed, jobDetails.StatusCode);
            Assert.AreEqual("TestJob1", jobDetails.Name);
            Assert.AreEqual("some query", jobDetails.Query);
            Assert.AreEqual("/some/place", jobDetails.StatusDirectory);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanDeserializeJobDetailsWithMissingStartTime()
        {
            var converter = new PayloadConverter();
            var jobDetails = converter.DeserializeJobDetails(JobDetailsPayloadWithMissingStartTime);

            Assert.AreEqual("job_001", jobDetails.JobId);
            Assert.AreEqual(0, jobDetails.ExitCode);
            Assert.AreEqual(DateTime.MinValue, jobDetails.SubmissionTime);
            Assert.AreEqual(JobStatusCode.Completed, jobDetails.StatusCode);
            Assert.AreEqual("TestJob1", jobDetails.Name);
            Assert.AreEqual("some query", jobDetails.Query);
            Assert.AreEqual("/some/place", jobDetails.StatusDirectory);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ICanDeserializeJobDetailsWithMissingJobId()
        {
            var converter = new PayloadConverter();
            converter.DeserializeJobDetails(JobDetailsPayloadWithMissingJobId);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanDeserializeJobDetailsWithParentIdAndMissingJobId()
        {
            var converter = new PayloadConverter();
            var jobDetails = converter.DeserializeJobDetails(JobDetailsPayloadWithParentIdAndMissingJobId);
            Assert.AreEqual("job_000", jobDetails.JobId);
            Assert.AreEqual(0, jobDetails.ExitCode);
            Assert.AreEqual(unixEpoch.AddMilliseconds(1375484358898), jobDetails.SubmissionTime);
            Assert.AreEqual(JobStatusCode.Completed, jobDetails.StatusCode);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DeserializeFailsWithInvalidJobDetailsJson()
        {
            var converter = new PayloadConverter();
            converter.DeserializeJobDetails(InvalidJobDetailsJson);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DeserializeFailsWithMalformedobDetailsJson()
        {
            var converter = new PayloadConverter();
            converter.DeserializeJobDetails(MalformedJobDetailsJson);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DeserializeFailsWithEmptyJobDetailsJson()
        {
            var converter = new PayloadConverter();
            converter.DeserializeJobDetails(EmptyJsonObject);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanDeserializeJobDetailsWithJobNameInArgumentProperty()
        {
            var converter = new PayloadConverter();
            var jobDetails = converter.DeserializeJobDetails(JobDetailsPayloadWithNameInArgsProperty);
            Assert.AreEqual("Pig: records = LOAD '/sah", jobDetails.Name);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanDeserializeJobDetailsWithCommandInUserArgs()
        {
            var converter = new PayloadConverter();
            var jobDetails = converter.DeserializeJobDetails(JobDetailsPayloadWithCommandProperty);
            Assert.AreEqual("show tables", jobDetails.Query);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanDeserializeJobDetailsWithEmptyJobNameInArgumentProperty()
        {
            var converter = new PayloadConverter();
            var jobDetails = converter.DeserializeJobDetails(JobDetailsPayloadWithEmptyNameInArgsProperty);
            Assert.AreEqual(string.Empty, jobDetails.Name);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanDeserializeJobDetailsWithJobNameInArgumentAndDefineProperty()
        {
            var converter = new PayloadConverter();
            var jobDetails = converter.DeserializeJobDetails(JobDetailsPayloadWithNameInArgsAnDefinesProperty);
            Assert.AreEqual("Name In Define", jobDetails.Name);
        }

        private const string RawJobSubmissionResultsPayload = @"{""id"":""job_001""}";

        private const string RawJobSubmissionResultsPayloadWithError = @"{""error"":""some error""}";

        private const string JobSubmissionResultsPayloadMissingIdAndError = @"{""property"":""value""}";

        private const string BadJson = "{{}],";

        private const string RawAllFieldsListJobsPayloadWithOneItem = @"[
 {
   ""id"":""job_001"",
   ""detail"":
      {
         ""status"":
            {
              ""startTime"":1375484358898,
              ""jobPriority"":""NORMAL"",
              ""jobID"":
                 {
                    ""jtIdentifier"":""201307101453"",
                    ""id"":002
                 },
              ""runState"":2,
              ""jobId"":""job_002"",
              ""username"":""hadoop"",
              ""schedulingInfo"":""0 running map tasks using 0 map slots. 0 additional slots reserved. 1 running reduce tasks using 1 reduce slots. 0 additional slots reserved."",
              ""failureInfo"":""NA"",
              ""jobACLs"":{},
              ""jobComplete"":true
           },
        ""profile"":
           {
              ""url"":""http://localhost:50030/jobdetails.jsp?jobid=job_002"",
              ""user"":""hadoop"",
              ""jobName"":""PiEstimator"",
              ""queueName"":""default"",
              ""jobID"":
                 {
                    ""jtIdentifier"":""201307101453"",
                    ""id"":002
                 },
              ""jobId"":""job_002"",
              ""jobFile"":""hdfs://localhost:8020/hadoop/hdfs/tmp/mapred/staging/hadoop/.staging/job_002/jobDetails.xml""
           },
        ""id"":""job_002"",
        ""parentId"":""job_001"",
        ""percentComplete"":""map 100% reduce 100%"",
        ""exitValue"":0,
        ""user"":""hadoop"",
        ""callback"":null,
        ""completed"":""done"",
        ""userargs"":
           {
              ""statusdir"":""/some/place"",
              ""define"":[""hdInsightJobName=TestJob1""],
              ""execute"":""some query"", 
              ""arg"":[""pi"",""16"",""10000000""],
              ""files"":null,
              ""enablelog"":""false"",
              ""libjars"":null,
              ""user.name"":""hadoop"",""jar"":""/templetonJobFiles/f34000dc-1140-4e9b-b9d8-ca5ba6b1ceab/PiEstimator"",
              ""callback"":null,
              ""class"":""""
           }
     }
  }
]";

        private const string ValidAllFieldsListJobsPayloadWithMultipleItems = @"[
 {
   ""id"":""job_001"",
   ""detail"":
      {
         ""status"":
            {
              ""startTime"":1375484358898,
              ""runState"":2,
           },
        ""id"":""job_002"",
        ""exitValue"":0,
        ""userargs"":
           {
              ""statusdir"":""/some/place"",
              ""define"":[""hdInsightJobName=TestJob1""],
              ""execute"":""some query"" 
           }
     }
  },
{
   ""id"":""job_003"",
   ""detail"":
      {
         ""status"":
            {
              ""startTime"":1475484358898,
              ""runState"":2,
           },
        ""id"":""job_004"",
        ""exitValue"":0,
        ""userargs"":
           {
              ""statusdir"":""/some/place"",
              ""define"":[""hdInsightJobName=TestJob2""],
              ""execute"":""some query"" 
           }
     }
  }
]";
        
        private const string ValidAllFieldsListJobsPayloadWithOneValidAndOneEmptyObject = @"[
 {
   ""id"":""job_001"",
   ""detail"":
      {
         ""status"":
            {
              ""startTime"":1375484358898,
              ""runState"":2,
           },
        ""id"":""job_002"",
        ""exitValue"":0,
        ""userargs"":
           {
              ""statusdir"":""/some/place"",
              ""define"":[""hdInsightJobName=TestJob1""],
              ""execute"":""some query"" 
           }
     }
  }, {}
]";

        private const string ListJobsPayloadWithMultipleItemsOneValidOneInvalid = @"[
 {
   ""id"":""job_001"",
   ""detail"":
      {
         ""status"":
            {
              ""startTime"":1375484358898,
              ""runState"":2,
           },
        ""id"":""job_002"",
        ""exitValue"":0,
        ""userargs"":
           {
              ""statusdir"":""/some/place"",
              ""define"":[""hdInsightJobName=TestJob1""],
              ""execute"":""some query"" 
           }
     }
  },
{
   ""id"":""job_003"",
   ""detail"":
      {
         ""status"":
            {
              ""startTime"":1475484358898,
              ""runState"":2,
           },
        ""exitValue"":0,
        ""userargs"":
           {
              ""statusdir"":""/some/place"",
              ""define"":[""hdInsightJobName=TestJob2""],
              ""execute"":""some query"" 
           }
     }
  }
]";

        private const string ListJobsPayloadWithMultipleItemsOneValidOnePartial = @"[
{
   ""id"":""job_003"",
   ""detail"":
      {
         ""status"":
            {
              ""startTime"":1475484358898,
           },
        ""id"":""job_004"",
        ""exitValue"":0,
        ""userargs"":
           {
              ""define"":[""hdInsightJobName=TestJob2""],
              ""execute"":""some query"" 
           }
     }
  },
 {
   ""id"":""job_001"",
   ""detail"":
      {
         ""status"":
            {
              ""startTime"":1375484358898,
              ""runState"":2,
           },
        ""id"":""job_002"",
        ""exitValue"":0,
        ""userargs"":
           {
              ""statusdir"":""/some/place"",
              ""define"":[""hdInsightJobName=TestJob1""],
              ""execute"":""some query"" 
           }
     }
  }
]";

        private const string ValidjobDetailsPayload = @"{
   ""status"":
      {
         ""startTime"":1375484358898,
         ""jobPriority"":""NORMAL"",
         ""jobID"":
            {
               ""jtIdentifier"":""201307101453"",
               ""id"":118
            },
         ""runState"":2,
         ""jobId"":""job_001"",
         ""username"":""hadoop"",
         ""schedulingInfo"":""0 running map tasks using 0 map slots. 0 additional slots reserved. 1 running reduce tasks using 1 reduce slots. 0 additional slots reserved."",
         ""failureInfo"":""NA"",
         ""jobACLs"":{},
         ""jobComplete"":true
      },
   ""profile"":
      {
         ""url"":""http://localhost:50030/jobdetails.jsp?jobid=job_201307101453_0118"",
         ""user"":""hadoop"",
         ""jobName"":""PiEstimator"",
         ""queueName"":""default"",
         ""jobID"":
            {
               ""jtIdentifier"":""201307101453"",
               ""id"":118
            },
         ""jobId"":""job_001"",
         ""jobFile"":""hdfs://localhost:8020/hadoop/hdfs/tmp/mapred/staging/hadoop/.staging/job_201307101453_0118/jobDetails.xml""
      },
   ""id"":""job_001"",
   ""parentId"":""job_000"",
   ""percentComplete"":""map 100% reduce 100%"",
   ""exitValue"":0,
   ""user"":""hadoop"",
   ""callback"":null,
   ""completed"":""done"",
   ""userargs"":
      {
         ""statusdir"":""/some/place"",
         ""define"":[""hdInsightJobName=TestJob1""],
         ""execute"":""some query"",
         ""arg"":[""pi"",""16"",""10000000""],
         ""files"":null,
         ""enablelog"":""false"",
         ""libjars"":null,
         ""user.name"":""hadoop"",
         ""jar"":""/templetonJobFiles/f34000dc-1140-4e9b-b9d8-ca5ba6b1ceab/PiEstimator"",
         ""callback"":null,
         ""class"":""""
      }
}";
        private const string JobDetailsPayloadWithMissingStatusCode = @"{
   ""status"":
      {
         ""startTime"":1375484358898,
         ""jobId"":""job_001""
      },
   ""id"":""job_001"",
   ""parentId"":""job_000"",
   ""exitValue"":0,
   ""userargs"":
      {
         ""statusdir"":""/some/place"",
         ""define"":[""hdInsightJobName=TestJob1""],
         ""execute"":""some query"" 
      }
}";
        private const string JobDetailsPayloadWithNameInArgsProperty = @"{
   ""status"":
      {
         ""startTime"":1375484358898,
         ""jobId"":""job_001""
      },
   ""id"":""job_001"",
   ""parentId"":""job_000"",
   ""exitValue"":0,
   ""userargs"":
      {
         ""arg"":[""hdInsightJobName=Pig: records = LOAD '/sah""],
         ""statusdir"":""/some/place"",
         ""execute"":""some query"" 
      }
}";

        private const string JobDetailsPayloadWithEmptyNameInArgsProperty = @"{
   ""status"":
      {
         ""startTime"":1375484358898,
         ""jobId"":""job_001""
      },
   ""id"":""job_001"",
   ""parentId"":""job_000"",
   ""exitValue"":0,
   ""userargs"":
      {
         ""arg"":[""hdInsightJobName=""],
         ""statusdir"":""/some/place"",
         ""execute"":""some query"" 
      }
}";

        private const string JobDetailsPayloadWithNameInArgsAnDefinesProperty = @"{
   ""status"":
      {
         ""startTime"":1375484358898,
         ""jobId"":""job_001""
      },
   ""id"":""job_001"",
   ""parentId"":""job_000"",
   ""exitValue"":0,
   ""userargs"":
      {
         ""arg"":[""hdInsightJobName=Name In Arg""],
          ""define"":[""hdInsightJobName=Name In Define""],
         ""statusdir"":""/some/place"",
         ""execute"":""some query"" 
      }
}";

        private const string JobDetailsPayloadWithMissingExecuteProperty = @"{
   ""status"":
      {
         ""startTime"":1375484358898,
         ""runState"":2,
         ""jobId"":""job_001""
      },
   ""id"":""job_001"",
   ""parentId"":""job_000"",
   ""exitValue"":0,
   ""userargs"":
      {
         ""statusdir"":""/some/place"",
         ""define"":[""hdInsightJobName=TestJob1""]
      }
}";

        private const string JobDetailsPayloadWithCommandProperty = @"{
   ""status"":
      {
         ""startTime"":1375484358898,
         ""runState"":2,
         ""jobId"":""job_001""
      },
   ""id"":""job_001"",
   ""parentId"":""job_000"",
   ""exitValue"":0,
   ""userargs"":
      {
         ""statusdir"":""/some/place"",
        ""command"":""show tables"",
         ""define"":[""hdInsightJobName=TestJob1""]
      }
}";

        private const string JobDetailsPayloadWithMissingStatusObject = @"{
   ""id"":""job_001"",
   ""parentId"":""job_000"",
   ""exitValue"":0,
   ""userargs"":
      {
         ""statusdir"":""/some/place"",
         ""define"":[""hdInsightJobName=TestJob1""],
         ""execute"":""some query"" 
      }
}";

        private const string JobDetailsPayloadWithMissingUserArgsObject = @"{
   ""status"":
      {
         ""startTime"":1375484358898,
         ""runState"":2,
         ""jobId"":""job_001""
      },
   ""id"":""job_001"",
   ""parentId"":""job_000"",
   ""exitValue"":0
}";

        private const string JobDetailsPayloadWithMissingStartTime = @"{
   ""status"":
      {
         ""runState"":2,
         ""jobId"":""job_001""
      },
   ""id"":""job_001"",
   ""parentId"":""job_000"",
   ""exitValue"":0,
   ""userargs"":
      {
         ""statusdir"":""/some/place"",
         ""define"":[""hdInsightJobName=TestJob1""],
         ""execute"":""some query"" 
      }
}";

        private const string JobDetailsPayloadWithMissingExitValue = @"{
   ""status"":
      {
         ""startTime"":1375484358898,
         ""runState"":2,
         ""jobId"":""job_001""
      },
   ""id"":""job_001"",
   ""parentId"":""job_000"",
   ""userargs"":
      {
         ""statusdir"":""/some/place"",
         ""define"":[""hdInsightJobName=TestJob1""],
         ""execute"":""some query"" 
      }
}";

        private const string JobDetailsPayloadWithNullExitValue = @"{
   ""status"":
      {
         ""startTime"":1375484358898,
         ""runState"":2,
         ""jobId"":""job_001""
      },
   ""id"":""job_001"",
    ""exitValue"":null,
   ""parentId"":""job_000"",
   ""userargs"":
      {
         ""statusdir"":""/some/place"",
         ""define"":[""hdInsightJobName=TestJob1""],
         ""execute"":""some query"" 
      }
}";

        private const string JobDetailsPayloadWithMissingStatusDirectory = @"{
   ""status"":
      {
         ""startTime"":1375484358898,
         ""runState"":2,
         ""jobId"":""job_001""
      },
   ""id"":""job_001"",
   ""parentId"":""job_000"",
   ""exitValue"":0,
   ""userargs"":
      {
         ""define"":[""hdInsightJobName=TestJob1""],
         ""execute"":""some query"" 
      }
}";

        private const string JobDetailsPayloadWithMissingDefineArray = @"{
   ""status"":
      {
         ""startTime"":1375484358898,
         ""runState"":2,
         ""jobId"":""job_001""
      },
   ""id"":""job_001"",
   ""parentId"":""job_000"",
   ""exitValue"":0,
   ""userargs"":
      {
         ""statusdir"":""/some/place"",
         ""execute"":""some query"" 
      }
}";

        private const string JobDetailsPayloadWithParentIdAndMissingJobId = @"{
""status"":
      {
         ""startTime"":1375484358898,
         ""jobPriority"":""NORMAL"",
         ""runState"":2,
         ""jobComplete"":true
      },
   ""parentId"":""job_000"",
   ""percentComplete"":""map 100% reduce 100%"",
   ""exitValue"":0
    }
}";

        private const string JobDetailsPayloadWithMissingJobId = @"{
   ""status"":
      {
         ""startTime"":1375484358898,
         ""runState"":2
      },
   ""exitValue"":0,
   ""userargs"":
      {
         ""statusdir"":""/some/place"",
         ""define"":[""hdInsightJobName=TestJob1""],
         ""execute"":""some query"" 
      }
}";
        //extra opening brace.
        private const string MalformedJobDetailsJson = @"{ {
   ""status"":
      {
         ""startTime"":1375484358898,
         ""runState"":2,
         ""jobId"":""job_001""
      },
   ""parentId"":""job_000"",
   ""exitValue"":0,
   ""userargs"":
      {
         ""statusdir"":""/some/place"",
         ""define"":[""hdInsightJobName=TestJob1""],
         ""execute"":""some query"" 
      }
}";

        private const string EmptyJsonObject = @"{ }";

        private const string EmptyJsonArray = @"[]";

        private const string JobListWithNoValidJobDetails = @"[{},{}]";

        private const string InvalidJobDetailsJson = @"This is not Json, and is invalid.";


    }
}
