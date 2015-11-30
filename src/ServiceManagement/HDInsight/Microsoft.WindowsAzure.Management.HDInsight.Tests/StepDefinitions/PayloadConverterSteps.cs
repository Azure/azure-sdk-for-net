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
namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.StepDefinitions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using Microsoft.Hadoop.Client;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.JobSubmission.Data;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities.ServerDataObjects;
    using TechTalk.SpecFlow;

    [Binding]
    public class PayloadConverterSteps
    {
        private object transferObject;
        private string serializedForm;

        public void BeforeScenario()
        {

        }

        public void AfterScenario()
        {

        }

        [Given(@"I have a job list object")]
        public void GivenIHaveAListOfJobIds()
        {
            var list = new JobList();
            list.HttpStatusCode = HttpStatusCode.Accepted;
            list.ErrorCode = string.Empty;
            this.transferObject = list;
        }

        [Given(@"I have a job details object")]
        public void GivenIHaveAJobDetailsObject()
        {
            var job = new Hadoop.Client.JobDetails();
            job.ErrorCode = string.Empty;
            job.ErrorOutputPath = string.Empty;
            job.ExitCode = 0;
            job.HttpStatusCode = HttpStatusCode.Accepted;
            job.JobId = string.Empty;
            job.LogicalOutputPath = string.Empty;
            job.Name = string.Empty;
            job.PhysicalOutputPath = "http://output";
            job.Query = string.Empty;
            job.StatusCode = Hadoop.Client.JobStatusCode.Unknown;
            job.SubmissionTime = DateTime.UtcNow;
            this.transferObject = job;
        }


        [Given(@"I have a job details object with a callback")]
        public void GivenIHaveAJobDetailsWithCallbackObject()
        {
            var job = new Hadoop.Client.JobDetails();
            job.ErrorCode = string.Empty;
            job.ErrorOutputPath = string.Empty;
            job.ExitCode = 0;
            job.HttpStatusCode = HttpStatusCode.Accepted;
            job.JobId = string.Empty;
            job.LogicalOutputPath = string.Empty;
            job.Name = string.Empty;
            job.PhysicalOutputPath = "http://output";
            job.Query = string.Empty;
            job.StatusCode = Hadoop.Client.JobStatusCode.Unknown;
            job.SubmissionTime = DateTime.UtcNow;
            job.Callback = "http://some.url";
            this.transferObject = job;
        }

        [Given(@"I have a map reduce job request object")]
        public void GivenIHaveAMapReduceJobRequestObject()
        {
            var request = new MapReduceJobCreateParameters();
            request.ClassName = string.Empty;
            request.JarFile = string.Empty;
            request.JobName = string.Empty;
            request.StatusFolder = string.Empty;
            this.transferObject = request;
        }

        [Given(@"I have a hive job request object")]
        public void GivenIHaveAHiveJobRequestObject()
        {
            var request = new HiveJobCreateParameters();
            request.JobName = string.Empty;
            request.Query = string.Empty;
            request.StatusFolder = string.Empty;
            this.transferObject = request;
        }

        [Given(@"I add the following argument ""(.*)""")]
        public void GivenIAddTheFollowingArgument(string argument)
        {
            ((MapReduceJobCreateParameters)this.transferObject).Arguments.Add(argument);
        }

        [Given(@"I add the following parameter ""(.*)"" with a value of ""(.*)""")]
        public void IAddTheFollowingParameter_key_WithAValueOf_value(string key, string value)
        {
            var asMapreduceJob = this.transferObject as MapReduceJobCreateParameters;
            var asHiveJob = this.transferObject as HiveJobCreateParameters;
            if (asMapreduceJob.IsNotNull())
            {
                asMapreduceJob.Defines.Add(key, value);
            }
            else if (asHiveJob.IsNotNull())
            {
                asHiveJob.Defines.Add(key, value);
            }
        }

        [Given(@"I add the following resource ""(.*)""")]
        public void IAddTheFollowingResource_key_WithAValueOf_value(string resource)
        {
            ((JobCreateParameters)this.transferObject).Files.Add(resource);
        }

        [Given(@"I set the job name as ""(.*)""")]
        public void GivenISetTheJobNameAs(string name)
        {
            var asHiveJob = this.transferObject as HiveJobCreateParameters;
            var asMapReduceJob = this.transferObject as MapReduceJobCreateParameters;
            if (asHiveJob.IsNotNull())
            {
                asHiveJob.JobName = name;
            }
            else if (asMapReduceJob.IsNotNull())
            {
                asMapReduceJob.JobName = name;
            }
        }

        [Given(@"I set the class name as ""(.*)""")]
        public void GivenISetTheClassNameAs_name(string name)
        {
            ((MapReduceJobCreateParameters)this.transferObject).ClassName = name;
        }

        [Given(@"I set the Jar file as ""(.*)""")]
        public void GivenISetTheJarFileAs_jarFile(string jarFile)
        {
            ((MapReduceJobCreateParameters)this.transferObject).JarFile = jarFile;
        }

        [Given(@"I set the Output Storage Location as ""(.*)""")]
        public void GivenISetTheOutputStorageLocationAs_outputStorageLocation(string outputStorageLocation)
        {
            ((JobCreateParameters)this.transferObject).StatusFolder = outputStorageLocation;
        }

        [Given(@"I set the Query to the following:")]
        public void GivenISetTheQueryToTheFollowing_query(string query)
        {
            ((HiveJobCreateParameters)this.transferObject).Query = query;
        }

        [Given(@"the request will return the http status code ""(.*)""")]
        public void GivenTheJobRequestWillReturnTheStatusCode_httpStatusCode(HttpStatusCode code)
        {
            this.transferObject.GetType().GetProperty("HttpStatusCode").SetValue(this.transferObject, code);
        }

        [Given(@"the jobId ""(.*)"" is added to the list of jobIds")]
        public void GivenTheJobId_jobId_IsAddedToTheListOfJobIds(string jobId)
        {
            ((JobList)this.transferObject).Jobs.Add(new Hadoop.Client.JobDetails() { JobId = jobId });
        }

        [Given(@"the request will return the error id ""(.*)""")]
        public void GivenIHaveTheError_error(string error)
        {
            this.transferObject.GetType().GetProperty("ErrorCode").SetValue(this.transferObject, error);
        }

        [Given(@"the job has the name ""(.*)""")]
        public void GivenTheJobHasTheName_name(string name)
        {
            ((Hadoop.Client.JobDetails)this.transferObject).Name = name;
        }

        [When(@"I serialize the object")]
        public void WhenISerializeTheListOfJobIds()
        {
            var serverConverter = new JobPayloadServerConverter();
            var clientConverter = new JobPayloadConverter();
            var asList = this.transferObject.As<JobList>();
            if (asList.IsNotNull())
            {
                this.serializedForm = serverConverter.SerializeJobList(asList);
                return;
            }
            var asDetail = this.transferObject.As<Hadoop.Client.JobDetails>();
            if (asDetail.IsNotNull())
            {
                this.serializedForm = serverConverter.SerializeJobDetails(asDetail);
                return;
            }
            var asRequest = this.transferObject.As<JobCreateParameters>();
            if (asRequest.IsNotNull())
            {
                this.serializedForm = clientConverter.SerializeJobCreationDetails(asRequest);
                return;
            }
            Assert.Fail("Unable to recognize the object type.");
        }

        [Then(@"the value of the serialized output should be equivalent with the original")]
        public void TheValueOfTheSerializedOutputShouldBeEquivalentWithTheOrignal()
        {
            var clientConverter = new JobPayloadConverter();
            var serverConverter = new JobPayloadServerConverter();
            JobList asList = this.transferObject.As<JobList>();
            if (asList.IsNotNull())
            {
                JobList actual = clientConverter.DeserializeJobList(this.serializedForm);
                Assert.AreEqual(asList.ErrorCode, actual.ErrorCode);
                Assert.AreEqual(asList.HttpStatusCode, actual.HttpStatusCode);
                Assert.IsTrue(asList.Jobs.Select(j => j.JobId).SequenceEqual(actual.Jobs.Select(j => j.JobId)));
                return;
            }
            var asJob = this.transferObject.As<Hadoop.Client.JobDetails>();
            if (asJob.IsNotNull())
            {
                var actual = clientConverter.DeserializeJobDetails(this.serializedForm, asJob.JobId);
                Assert.AreEqual(asJob.ErrorCode, actual.ErrorCode);
                Assert.AreEqual(asJob.HttpStatusCode, actual.HttpStatusCode);
                Assert.AreEqual(asJob.ErrorOutputPath, actual.ErrorOutputPath);
                Assert.AreEqual(asJob.ExitCode, actual.ExitCode);
                Assert.AreEqual(asJob.JobId, actual.JobId);
                Assert.AreEqual(asJob.LogicalOutputPath, actual.LogicalOutputPath);
                Assert.AreEqual(asJob.Name, actual.Name);
                Assert.AreEqual(new Uri(asJob.PhysicalOutputPath), new Uri(actual.PhysicalOutputPath));
                Assert.AreEqual(asJob.Query, actual.Query);
                Assert.AreEqual(asJob.StatusCode, actual.StatusCode);
                Assert.AreEqual(asJob.SubmissionTime, actual.SubmissionTime);
                Assert.AreEqual(asJob.Callback, actual.Callback);
                return;
            }
            var asMapReduce = this.transferObject.As<MapReduceJobCreateParameters>();
            if (asMapReduce.IsNotNull())
            {
                MapReduceJobCreateParameters actual = serverConverter.DeserializeMapReduceJobCreationDetails(this.serializedForm);
                Assert.AreEqual(asMapReduce.ClassName, actual.ClassName);
                Assert.IsTrue(asMapReduce.Arguments.SequenceEqual(actual.Arguments));
                Assert.AreEqual(asMapReduce.JarFile, actual.JarFile);
                Assert.AreEqual(asMapReduce.JobName, actual.JobName);
                Assert.AreEqual(asMapReduce.StatusFolder, actual.StatusFolder);
                Assert.IsTrue(asMapReduce.Defines.SequenceEqual(actual.Defines));
                Assert.IsTrue(asMapReduce.Files.SequenceEqual(actual.Files));
                return;
            }
            var asHive = this.transferObject.As<HiveJobCreateParameters>();
            if (asHive.IsNotNull())
            {
                HiveJobCreateParameters actual = serverConverter.DeserializeHiveJobCreationDetails(this.serializedForm);
                Assert.AreEqual(asHive.JobName, actual.JobName);
                Assert.AreEqual(asHive.StatusFolder, actual.StatusFolder);
                Assert.IsTrue(asHive.Defines.SequenceEqual(actual.Defines));
                Assert.AreEqual(asHive.Query, actual.Query);
                Assert.IsTrue(asHive.Files.SequenceEqual(actual.Files));
                return;
            }
            Assert.Fail("Unable to recognize the object type.");
        }

        [Given(@"the job has the Error Output Path ""(.*)""")]
        public void GivenTheJobHasTheErrorOutputPath_path(string path)
        {
            ((Hadoop.Client.JobDetails)this.transferObject).ErrorOutputPath = path;
        }

        [Given(@"the job has an Exit Code of (\d+)")]
        public void GivenTheJobHasTheExitCode_exitCode(int exitCode)
        {
            ((Hadoop.Client.JobDetails)this.transferObject).ExitCode = exitCode;
        }

        [Given(@"the job has a Job Id of ""(.*)""")]
        public void GivenTheJobHasTheJobId_jobId(string jobId)
        {
            ((Hadoop.Client.JobDetails)this.transferObject).JobId = jobId;
        }

        [Given(@"the job has the Logical Output Path ""(.*)""")]
        public void GivenTheJobHasTheLogicalOutputPath_logicalOutputPath(string logicalOutputPath)
        {
            ((Hadoop.Client.JobDetails)this.transferObject).LogicalOutputPath = logicalOutputPath;
        }

        [Given(@"the job has the Physical Output Path ""(.*)""")]
        public void GivenTheJobHasThePhysicalOutputPath_physicalOutputPath(string physicalOutputPath)
        {
            ((Hadoop.Client.JobDetails)this.transferObject).PhysicalOutputPath = physicalOutputPath;
        }

        [Given(@"the job has the following query:")]
        public void GivenTheJobHasTheFollowingQuery_query(string query)
        {
            ((Hadoop.Client.JobDetails)this.transferObject).Query = query;
        }

        [Given(@"the job has the Status Code ""(.*)""")]
        public void GivenTheJobHasTheStatusCode(string statusCode)
        {
            var status = Hadoop.Client.JobStatusCode.Unknown;
            Assert.IsTrue(Hadoop.Client.JobStatusCode.TryParse(statusCode, true, out status));
            ((Hadoop.Client.JobDetails)this.transferObject).StatusCode = status;
        }

        [Given(@"the job has was submitted on ""(.*)""")]
        public void GivenTheJobWasSubmitedOnt_date(DateTime date)
        {
            ((Hadoop.Client.JobDetails)this.transferObject).SubmissionTime = date;
        }

    }
}