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
namespace Microsoft.Hadoop.Client
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client.ClientLayer;
    using Microsoft.Hadoop.Client.HadoopJobSubmissionPocoClient;
    using Microsoft.Hadoop.Client.HadoopJobSubmissionPocoClient.RemoteHadoop;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Logging;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;

    /// <summary>
    /// Represents a Hadoop client that can be used to submit jobs to an Hadoop cluster.
    /// </summary>
    internal class RemoteHadoopClient : ClientBase, IJobSubmissionClient, IHadoopApplicationHistoryClient
    {
        private BasicAuthCredential credentials;
        private const string SDKVersionUserAgentString = "HDInsight .NET SDK/{0} {1}";

        private string userAgentString;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Need so that we dont fail instantiations.")]
        internal RemoteHadoopClient(BasicAuthCredential credentials, string userAgentString)
        {
            this.credentials = credentials;
            userAgentString = userAgentString ?? string.Empty;
            var assemblyVersion = "NA";
            try
            {
                assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString(4);
            }
            catch 
            {
            }

            this.userAgentString = string.Format(
                CultureInfo.InvariantCulture,
                SDKVersionUserAgentString,
                assemblyVersion,
                userAgentString);
        }

        public event EventHandler<WaitJobStatusEventArgs> JobStatusEvent;

        internal void RaiseJobStatusEvent(object sender, WaitJobStatusEventArgs e)
        {
        }

        /// <inheritdoc />
        public void HandleClusterWaitNotifyEvent(JobDetails jobDetails)
        {
            var handler = this.JobStatusEvent;
            if (handler.IsNotNull())
            {
                handler(this, new WaitJobStatusEventArgs(jobDetails));
            }
        }

        /// <inheritdoc />
        public async Task<JobList> ListJobsAsync()
        {
            var factory = ServiceLocator.Instance.Locate<IRemoteHadoopJobSubmissionPocoClientFactory>();
            var pocoClient = factory.Create(this.credentials, this.Context, this.IgnoreSslErrors, this.userAgentString);
            var jobList = await pocoClient.ListJobs();
            return jobList;
        }

        /// <inheritdoc />
        public Task<JobDetails> GetJobAsync(string jobId)
        {
            var factory = ServiceLocator.Instance.Locate<IRemoteHadoopJobSubmissionPocoClientFactory>();
            var pocoClient = factory.Create(this.credentials, this.Context, this.IgnoreSslErrors, this.userAgentString);
            return pocoClient.GetJob(jobId);
        }

        /// <inheritdoc />
        public async Task<JobCreationResults> CreateMapReduceJobAsync(MapReduceJobCreateParameters mapReduceJobCreateParameters)
        {
            var factory = ServiceLocator.Instance.Locate<IRemoteHadoopJobSubmissionPocoClientFactory>();
            var pocoClient = factory.Create(this.credentials, this.Context, this.IgnoreSslErrors, this.userAgentString);
            return await pocoClient.SubmitMapReduceJob(mapReduceJobCreateParameters);
        }

        /// <inheritdoc />
        public Task<JobCreationResults> CreateHiveJobAsync(HiveJobCreateParameters hiveJobCreateParameters)
        {
            var factory = ServiceLocator.Instance.Locate<IRemoteHadoopJobSubmissionPocoClientFactory>();
            var pocoClient = factory.Create(this.credentials, this.Context, this.IgnoreSslErrors, this.userAgentString);
            hiveJobCreateParameters = this.PrepareQueryJob(hiveJobCreateParameters);
            return pocoClient.SubmitHiveJob(hiveJobCreateParameters);
        }

        /// <inheritdoc />
        public Task<JobCreationResults> CreatePigJobAsync(PigJobCreateParameters pigJobCreateParameters)
        {
            var factory = ServiceLocator.Instance.Locate<IRemoteHadoopJobSubmissionPocoClientFactory>();
            var pocoClient = factory.Create(this.credentials, this.Context, this.IgnoreSslErrors, this.userAgentString);
            pigJobCreateParameters = this.PrepareQueryJob(pigJobCreateParameters);
            return pocoClient.SubmitPigJob(pigJobCreateParameters);
        }

        public Task<JobCreationResults> CreateSqoopJobAsync(SqoopJobCreateParameters sqoopJobCreateParameters)
        {
            var factory = ServiceLocator.Instance.Locate<IRemoteHadoopJobSubmissionPocoClientFactory>();
            var pocoClient = factory.Create(this.credentials, this.Context, this.IgnoreSslErrors, this.userAgentString);
            sqoopJobCreateParameters = this.PrepareQueryJob(sqoopJobCreateParameters);
            return pocoClient.SubmitSqoopJob(sqoopJobCreateParameters);
        }

        /// <inheritdoc />
        public Task<JobDetails> StopJobAsync(string jobId)
        {
            var factory = ServiceLocator.Instance.Locate<IRemoteHadoopJobSubmissionPocoClientFactory>();
            var pocoClient = factory.Create(this.credentials, this.Context, this.IgnoreSslErrors, this.userAgentString);
            return pocoClient.StopJob(jobId);
        }

        /// <inheritdoc />
        public Task<Stream> GetJobOutputAsync(string jobId)
        {
            throw new NotSupportedException("Access to cluster resources requires Subscription details.");
        }

        /// <inheritdoc />
        public Task<Stream> GetJobErrorLogsAsync(string jobId)
        {
            throw new NotSupportedException("Access to cluster resources requires Subscription details.");
        }

        public Task<Stream> GetJobTaskLogSummaryAsync(string jobId)
        {
            throw new NotSupportedException("Access to cluster resources requires Subscription details.");
        }

        /// <inheritdoc />
        public Task DownloadJobTaskLogsAsync(string jobId, string targetDirectory)
        {
            throw new NotSupportedException("Access to cluster resources requires Subscription details.");
        }

        public string GetCustomUserAgent()
        {
            return this.userAgentString;
        }

        /// <inheritdoc />
        public Task<JobCreationResults> CreateStreamingJobAsync(StreamingMapReduceJobCreateParameters streamingMapReduceJobCreateParameters)
        {
            var factory = ServiceLocator.Instance.Locate<IRemoteHadoopJobSubmissionPocoClientFactory>();
            var pocoClient = factory.Create(this.credentials, this.Context, this.IgnoreSslErrors, this.GetCustomUserAgent());
            return pocoClient.SubmitStreamingJob(streamingMapReduceJobCreateParameters);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ApplicationDetails>> ListCompletedApplicationsAsync(DateTime submittedAfterInUtc, DateTime submittedBeforeInUtc)
        {
            var factory = ServiceLocator.Instance.Locate<IHadoopApplicationHistoryRestClientFactory>();
            var applicationHistoryRestClient = factory.Create(this.credentials, this.Context, this.IgnoreSslErrors);
            var applicationHistory = await applicationHistoryRestClient.ListCompletedApplicationsAsync(submittedAfterInUtc, submittedBeforeInUtc);
            return applicationHistory;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ApplicationDetails>> ListCompletedApplicationsAsync()
        {
            return await this.ListCompletedApplicationsAsync(DateTime.MinValue, DateTime.UtcNow);
        }

        /// <inheritdoc />
        public IEnumerable<ApplicationDetails> ListCompletedApplications(DateTime submittedAfterInUtc, DateTime submittedBeforeInUtc)
        {
            return this.ListCompletedApplicationsAsync(submittedAfterInUtc, submittedBeforeInUtc).WaitForResult();
        }

        /// <inheritdoc />
        public IEnumerable<ApplicationDetails> ListCompletedApplications()
        {
            return this.ListCompletedApplicationsAsync().WaitForResult();
        }

        /// <inheritdoc />
        public async Task<ApplicationDetails> GetApplicationDetailsAsync(string applicationId)
        {
            var factory = ServiceLocator.Instance.Locate<IHadoopApplicationHistoryRestClientFactory>();
            var applicationHistoryRestClient = factory.Create(this.credentials, this.Context, this.IgnoreSslErrors);
            var applicationDetails = await applicationHistoryRestClient.GetApplicationDetailsAsync(applicationId);
            return applicationDetails;
        }

        /// <inheritdoc />
        public ApplicationDetails GetApplicationDetails(string applicationId)
        {
            return this.GetApplicationDetailsAsync(applicationId).WaitForResult();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ApplicationAttemptDetails>> ListApplicationAttemptsAsync(ApplicationDetails application)
        {
            var factory = ServiceLocator.Instance.Locate<IHadoopApplicationHistoryRestClientFactory>();
            var applicationHistoryRestClient = factory.Create(this.credentials, this.Context, this.IgnoreSslErrors);
            var attempts = await applicationHistoryRestClient.ListApplicationAttemptsAsync(application);
            return attempts;
        }

        /// <inheritdoc />
        public IEnumerable<ApplicationAttemptDetails> ListApplicationAttempts(ApplicationDetails application)
        {
            return this.ListApplicationAttemptsAsync(application).WaitForResult();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ApplicationContainerDetails>> ListApplicationContainersAsync(ApplicationAttemptDetails applicationAttempt)
        {
            var factory = ServiceLocator.Instance.Locate<IHadoopApplicationHistoryRestClientFactory>();
            var applicationHistoryRestClient = factory.Create(this.credentials, this.Context, this.IgnoreSslErrors);
            var containers = await applicationHistoryRestClient.ListApplicationContainersAsync(applicationAttempt);
            return containers;
        }

        /// <inheritdoc />
        public IEnumerable<ApplicationContainerDetails> ListApplicationContainers(ApplicationAttemptDetails applicationAttempt)
        {
            return this.ListApplicationContainersAsync(applicationAttempt).WaitForResult();
        }

        /// <inheritdoc />
        public JobList ListJobs()
        {
            return this.ListJobsAsync().WaitForResult();
        }

        /// <inheritdoc />
        public JobDetails GetJob(string jobId)
        {
            return this.GetJobAsync(jobId).WaitForResult();
        }

        /// <inheritdoc />
        public JobCreationResults CreateMapReduceJob(MapReduceJobCreateParameters mapReduceJobCreateParameters)
        {
            return this.CreateMapReduceJobAsync(mapReduceJobCreateParameters).WaitForResult();
        }

        /// <inheritdoc />
        public JobCreationResults CreateStreamingJob(StreamingMapReduceJobCreateParameters streamingMapReduceJobCreateParameters)
        {
            return this.CreateStreamingJobAsync(streamingMapReduceJobCreateParameters).WaitForResult();
        }

        /// <inheritdoc />
        public JobCreationResults CreateHiveJob(HiveJobCreateParameters hiveJobCreateParameters)
        {
            hiveJobCreateParameters = this.PrepareQueryJob(hiveJobCreateParameters);
            return this.CreateHiveJobAsync(hiveJobCreateParameters).WaitForResult();
        }

        /// <inheritdoc />
        public JobCreationResults CreatePigJob(PigJobCreateParameters pigJobCreateParameters)
        {
            pigJobCreateParameters = this.PrepareQueryJob(pigJobCreateParameters);
            return this.CreatePigJobAsync(pigJobCreateParameters).WaitForResult();
        }

        /// <inheritdoc />
        public JobCreationResults CreateSqoopJob(SqoopJobCreateParameters sqoopJobCreateParameters)
        {
            sqoopJobCreateParameters = this.PrepareQueryJob(sqoopJobCreateParameters);
            return this.CreateSqoopJobAsync(sqoopJobCreateParameters).WaitForResult();
        }

        /// <inheritdoc />
        public JobDetails StopJob(string jobId)
        {
            return this.StopJobAsync(jobId).WaitForResult();
        }

        /// <inheritdoc />
        public Stream GetJobOutput(string jobId)
        {
            return this.GetJobOutputAsync(jobId).WaitForResult();
        }

        /// <inheritdoc />
        public Stream GetJobErrorLogs(string jobId)
        {
            return this.GetJobErrorLogsAsync(jobId).WaitForResult();
        }

        /// <inheritdoc />
        public Stream GetJobTaskLogSummary(string jobId)
        {
            return this.GetJobTaskLogSummaryAsync(jobId).WaitForResult();
        }

        /// <inheritdoc />
        public void DownloadJobTaskLogs(string jobId, string targetDirectory)
        {
            this.DownloadJobTaskLogsAsync(jobId, targetDirectory).WaitForResult();
        }

        /// <inheritdoc />
        internal override TJobType UploadQueryFile<TJobType>(TJobType queryJob, string queryText)
        {
            throw new NotSupportedException("Cannot upload query file, access to cluster resources requires Subscription details.");
        }
    }
}