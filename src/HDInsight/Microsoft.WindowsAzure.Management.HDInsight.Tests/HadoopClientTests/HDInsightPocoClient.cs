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
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.Hadoop.Client.HadoopJobSubmissionPocoClient;
    using Microsoft.Hadoop.Client.HadoopJobSubmissionPocoClient.RemoteHadoop;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.JobSubmission;
    using Microsoft.WindowsAzure.Management.HDInsight.JobSubmission.PocoClient;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;
    using Moq;

    [TestClass]
    public class HDInsightPocoClient : IntegrationTestBase
    {
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

        internal class MockRemotePoco : IHadoopJobSubmissionPocoClient
        {
            public string JobId { get; set; }
            public JobDetails JobDetails { get; set; }

            public bool ListJobsCalled = false;
            public bool GetJobCalled = false;
            public bool SubmitMapReduceJobCalled = false;
            public bool SubmitHiveJobCalled = false;
            public bool SubmitSqoopJobCalled  = false;
            public string UserAgentString = "Mock Poco";
            public string GetUserAgentString()
            {
                return UserAgentString;
            }

            public Task<JobList> ListJobs()
            {
                this.ListJobsCalled = true;
                var jobList = new JobList();
                jobList.Jobs.Add(this.JobDetails);
                return Task.Run(() => jobList);
            }

            public Task<JobDetails> GetJob(string jobId)
            {
                this.GetJobCalled = true;
                this.JobId = jobId;
                return Task.Run(() => this.JobDetails);
            }

            public Task<JobCreationResults> SubmitMapReduceJob(MapReduceJobCreateParameters details)
            {
                this.SubmitMapReduceJobCalled = true;
                var job = new JobCreationResults() { JobId = JobId };
                return Task.Run(() => job);
            }

            public Task<JobCreationResults> SubmitHiveJob(HiveJobCreateParameters details)
            {
                this.SubmitHiveJobCalled = true;
                var job = new JobCreationResults() { JobId = JobId };
                return Task.Run(() => job);
            }

            public Task<JobCreationResults> SubmitPigJob(PigJobCreateParameters pigJobCreateParameters)
            {
                throw new System.NotImplementedException();
            }

            public Task<JobCreationResults> SubmitSqoopJob(SqoopJobCreateParameters sqoopJobCreateParameters)
            {
                this.SubmitSqoopJobCalled = true;
                var job = new JobCreationResults() { JobId = JobId };
                return Task.Run(() => job);
            }

            public Task<JobCreationResults> SubmitStreamingJob(StreamingMapReduceJobCreateParameters pigJobCreateParameters)
            {
                throw new System.NotImplementedException();
            }

            public Task<JobDetails> StopJob(string jobId)
            {
                throw new NotImplementedException();
            }
        }

        internal class MockRemotePocoLayerFactory : IRemoteHadoopJobSubmissionPocoClientFactory
        {
            public MockRemotePoco Mock { get; set; }


            public IHadoopJobSubmissionPocoClient Create(IJobSubmissionClientCredential credentials, IAbstractionContext context, bool ignoreSslErrors, string userAgentString)
            {
                return Mock;
            }
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanSubmitAHiveJob()
        {
            var factory = new MockRemotePocoLayerFactory();
            var pocoMock = new MockRemotePoco();
            pocoMock.JobId = "1234";
            factory.Mock = pocoMock;

            ServiceLocator.Instance.Locate<IServiceLocationIndividualTestManager>().Override<IRemoteHadoopJobSubmissionPocoClientFactory>(factory);

            // var creds = new JobSubmissionCertificateCredential(Guid.NewGuid(), null, "someCluster");
            var creds = new BasicAuthCredential()
            {
                Password = "somePassword",
                Server = new Uri("http://somewhere"),
                UserName = "someone"
            };

            var poco = new HDInsightJobSubmissionPocoClient(creds, GetAbstractionContext(), false, pocoMock.GetUserAgentString());
            var task = poco.SubmitHiveJob(new HiveJobCreateParameters() { JobName = "myJob", Query = "someQuery" });
            task.Wait();

            Assert.AreEqual("1234", task.Result.JobId);
            Assert.IsTrue(pocoMock.SubmitHiveJobCalled);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanSubmitAMapReduceJob()
        {
            var factory = new MockRemotePocoLayerFactory();
            var pocoMock = new MockRemotePoco();
            pocoMock.JobId = "54321";
            factory.Mock = pocoMock;

            ServiceLocator.Instance.Locate<IServiceLocationIndividualTestManager>().Override<IRemoteHadoopJobSubmissionPocoClientFactory>(factory);

            // var creds = new JobSubmissionCertificateCredential(Guid.NewGuid(), null, "someCluster");
            var creds = new BasicAuthCredential()
            {
                Password = "somePassword",
                Server = new Uri("http://somewhere"),
                UserName = "someone"
            };

            var poco = new HDInsightJobSubmissionPocoClient(creds, GetAbstractionContext(), false, pocoMock.GetUserAgentString());
            var task = poco.SubmitMapReduceJob(new MapReduceJobCreateParameters() { JobName = "myJob", ClassName = "someApp", JarFile = "someFile" });
            task.Wait();

            Assert.AreEqual("54321", task.Result.JobId);
            Assert.IsTrue(pocoMock.SubmitMapReduceJobCalled);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanSubmitASqoopJob()
        {
            var factory = new MockRemotePocoLayerFactory();
            var pocoMock = new MockRemotePoco();
            pocoMock.JobId = "54321";
            factory.Mock = pocoMock;

            ServiceLocator.Instance.Locate<IServiceLocationIndividualTestManager>().Override<IRemoteHadoopJobSubmissionPocoClientFactory>(factory);

            // var creds = new JobSubmissionCertificateCredential(Guid.NewGuid(), null, "someCluster");
            var creds = new BasicAuthCredential()
            {
                Password = "somePassword",
                Server = new Uri("http://somewhere"),
                UserName = "someone"
            };

            var poco = new HDInsightJobSubmissionPocoClient(creds, GetAbstractionContext(), false, pocoMock.GetUserAgentString());
            var task = poco.SubmitSqoopJob(new SqoopJobCreateParameters() { Command = "load remote;" });
            task.Wait();

            Assert.AreEqual("54321", task.Result.JobId);
            Assert.IsTrue(pocoMock.SubmitSqoopJobCalled);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanGetAJob()
        {
            var expectedJob = new JobDetails() { ExitCode = 12, Name = "some jobDetails", StatusCode = Hadoop.Client.JobStatusCode.Completed, JobId = "2345" };

            var factory = new MockRemotePocoLayerFactory();
            var pocoMock = new MockRemotePoco { JobId = string.Empty, JobDetails = expectedJob };
            factory.Mock = pocoMock;

            ServiceLocator.Instance.Locate<IServiceLocationIndividualTestManager>().Override<IRemoteHadoopJobSubmissionPocoClientFactory>(factory);

            var creds = new BasicAuthCredential()
            {
                Password = "somePassword",
                Server = new Uri("http://somewhere"),
                UserName = "someone"
            };

            var poco = new HDInsightJobSubmissionPocoClient(creds, GetAbstractionContext(), false, pocoMock.GetUserAgentString());
            var task = poco.GetJob("2345");
            task.Wait();

            Assert.AreEqual("2345", task.Result.JobId);
            Assert.IsTrue(pocoMock.GetJobCalled);
            Assert.AreEqual(expectedJob, task.Result);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void ICanListJobs()
        {
            var expectedJob = new JobDetails() { ExitCode = 12, Name = "some jobDetails", StatusCode = JobStatusCode.Completed, JobId = "2345" };

            var factory = new MockRemotePocoLayerFactory();
            var pocoMock = new MockRemotePoco { JobId = string.Empty, JobDetails = expectedJob };
            factory.Mock = pocoMock;

            ServiceLocator.Instance.Locate<IServiceLocationIndividualTestManager>().Override<IRemoteHadoopJobSubmissionPocoClientFactory>(factory);

            // var creds = new JobSubmissionCertificateCredential(Guid.NewGuid(), null, "someCluster");
            var creds = new BasicAuthCredential()
            {
                Password = "somePassword",
                Server = new Uri("http://somewhere"),
                UserName = "someone"
            };

            var poco = new HDInsightJobSubmissionPocoClient(creds, GetAbstractionContext(), false, pocoMock.GetUserAgentString());
            var task = poco.ListJobs();
            task.Wait();

            Assert.IsNotNull(task.Result);
            Assert.IsTrue(pocoMock.ListJobsCalled);
            Assert.AreEqual(1, task.Result.Jobs.Count);

            var job = task.Result.Jobs.First();
            Assert.AreEqual("2345", job.JobId);
            Assert.AreEqual(expectedJob, job);
        }


    }
}
