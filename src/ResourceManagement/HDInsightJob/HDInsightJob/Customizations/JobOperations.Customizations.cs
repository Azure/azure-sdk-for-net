// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Management.HDInsight.Job.Models;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Management.HDInsight.Job
{
    /// <summary>
    /// Operations for managing jobs against HDInsight clusters.
    /// </summary>
    internal partial class JobOperations : IServiceOperations<HDInsightJobManagementClient>, IJobOperations
    {
        private static string jobPrefix = "job_";
        private static string appPrefix = "application_";

        /// <summary>
        /// Submits a Hive job to an HDInsight cluster.
        /// </summary>
        /// <param name='parameters'>
        /// Required. Hive job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        public async Task<JobSubmissionResponse> SubmitHiveJobAsync(HiveJobSubmissionParameters parameters)
        {
            return await SubmitHiveJobAsync(new JobSubmissionParameters { Content = parameters.GetJobPostRequestContent() }, CancellationToken.None);
        }

        /// <summary>
        /// Submits a MapReduce job to an HDInsight cluster.
        /// </summary>
        /// <param name='parameters'>
        /// Required. MapReduce job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        public async Task<JobSubmissionResponse> SubmitMapReduceJobAsync(MapReduceJobSubmissionParameters parameters)
        {
            return await SubmitMapReduceJobAsync(new JobSubmissionParameters { Content = parameters.GetJobPostRequestContent() }, CancellationToken.None);
        }

        /// <summary>
        /// Submits a MapReduce streaming job to an HDInsight cluster.
        /// </summary>
        /// <param name='parameters'>
        /// Required. MapReduce job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        public async Task<JobSubmissionResponse> SubmitMapReduceStreamingJobAsync(MapReduceStreamingJobSubmissionParameters parameters)
        {
            return await SubmitMapReduceStreamingJobAsync(new JobSubmissionParameters { Content = parameters.GetJobPostRequestContent() }, CancellationToken.None);
        }

        /// <summary>
        /// Submits a Pig job to an HDInsight cluster.
        /// </summary>
        /// <param name='parameters'>
        /// Required. Pig job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        public async Task<JobSubmissionResponse> SubmitPigJobAsync(PigJobSubmissionParameters parameters)
        {
            return await SubmitPigJobAsync(new JobSubmissionParameters { Content = parameters.GetJobPostRequestContent() }, CancellationToken.None);
        }

        /// <summary>
        /// Submits a Sqoop job to an HDInsight cluster.
        /// </summary>
        /// <param name='parameters'>
        /// Required. Sqoop job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        public async Task<JobSubmissionResponse> SubmitSqoopJobAsync(SqoopJobSubmissionParameters parameters)
        {
            return await SubmitSqoopJobAsync(new JobSubmissionParameters { Content = parameters.GetJobPostRequestContent() }, CancellationToken.None);
        }

        /// <summary>
        /// Gets the job output content as memory stream.
        /// </summary>
        /// <param name='jobId'>
        /// Required. The id of the job.
        /// </param>
        /// <param name="storageAccess">
        /// Required. The storage account object of type IStorageAccess.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The job output content as memory stream.
        /// </returns>
        public async Task<Stream> GetJobOutputAsync(string jobId, IStorageAccess storageAccess, CancellationToken cancellationToken)
        {
            var blobReferencePath = await GetJobStatusDirectory(jobId, "stdout");
            return storageAccess.GetFileContent(blobReferencePath);
        }

        /// <summary>
        /// Gets the job error output content as memory stream.
        /// </summary>
        /// <param name='jobId'>
        /// Required. The id of the job.
        /// </param>
        /// <param name="storageAccess">
        /// Required. The storage account object of type IStorageAccess.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The job error output content as memory stream when job fails to run successfully.
        /// </returns>
        public async Task<Stream> GetJobErrorLogsAsync(string jobId, IStorageAccess storageAccess, CancellationToken cancellationToken)
        {
            var blobReferencePath = await GetJobStatusDirectory(jobId, "stderr");
            return storageAccess.GetFileContent(blobReferencePath);
        }

        /// <summary>
        /// Wait for completion of a Job. 
        /// </summary>
        /// <param name='jobId'>
        /// Required. The id of the job.
        /// </param>
        /// <param name='duration'>
        /// Optional. The maximum duration to wait for completion of job before returning to client. If not passed then wait till job is completed.
        /// </param>
        /// <param name='waitInterval'>
        /// Optional. The interval to poll for job status. The default value is set from DefaultPollInterval property of HDInsight job management client.
        /// </param>
        /// <exception cref="TimeoutException">
        /// Thrown when waiting for job completion exceeds the maximum duration specified by parameter duration.
        /// </exception>
        public async Task<JobGetResponse> WaitForJobCompletionAsync(string jobId, TimeSpan? duration = null, TimeSpan? waitInterval = null)
        {
            var appId = GetAppIdFromJobId(jobId);
            var startTime = DateTime.UtcNow;
            bool waitTimeOut = false;

            if (waitInterval == null)
            {
                waitInterval = HDInsightJobManagementClient.DefaultPollInterval;
            }

            // We poll Yarn for application status until application run is finished. If the application is
            // in finished state then we poll templeton to get completed job details.
            JobGetResponse jobDetail = null;

            // If duration is null means we need to keep retry until job is complete.
            while (duration == null || !(waitTimeOut = ((DateTime.UtcNow - startTime) > duration)))
            {
                try
                {
                    var jobState = await GetAppStateAsync(appId, CancellationToken.None);

                    ApplicationState appState = jobState.GetState();
                    if (appState == ApplicationState.Finished || appState == ApplicationState.Failed || appState == ApplicationState.Killed)
                    {
                        // Get the job finished details now and keep checking if Job is complete from Templeton 
                        // as history server may not have picked up the completed job.
                        jobDetail = await this.GetJobAsync(jobId);

                        if (jobDetail.JobDetail.Status.JobComplete)
                        {
                            break;
                        }
                    }
                }
                catch (CloudException ex)
                {
                    // If transient error then keep retry until user specified duration.
                    if (IsTransientError(ex.Response.StatusCode))
                    {
                        LogMessage(ex.Message);
                    }
                    else
                    {
                        // Throw the same exception back to client.
                        throw ex;
                    }
                }
                catch (HttpRequestException ex)
                {
                    // For any other Http exceptions we keep retry.
                    LogMessage(ex.Message);
                }

                MockSupport.Delay(waitInterval.Value);
            }

            if (waitTimeOut)
            {
                // If user specified duration exceeded then raise a time out exception and kill the job if requested.
                throw new TimeoutException(string.Format(CultureInfo.InvariantCulture, "The requested task failed to complete in the allotted time ({0})", duration));
            }

            return jobDetail;
        }

        private async Task<string> GetJobStatusDirectory(string jobId, string file)
        {
            var job = await this.GetJobAsync(jobId);
            var statusDir = GetStatusFolder(job);

            if (statusDir == null)
            {
                throw new CloudException(string.Format("Job {0} was not created with a status folder and therefore no logs were saved.", job.JobDetail.Id));
            }

            return string.Format("user/{0}/{1}/{2}", job.JobDetail.User, statusDir, file);
        }

        private static string GetStatusFolder(JobGetResponse job)
        {
            return job.JobDetail.Userargs.Statusdir == null ? null : job.JobDetail.Userargs.Statusdir.ToString();
        }

        private static string GetAppIdFromJobId(string jobId)
        {
            // Validate Job Id
            if (string.IsNullOrWhiteSpace(jobId) || !jobId.StartsWith(jobPrefix))
            {
                throw new CloudException(String.Format("Invalid job id {0}", jobId));
            }

            return appPrefix + jobId.Substring(jobPrefix.Length);
        }

        private static bool IsTransientError(HttpStatusCode status)
        {
            return status == HttpStatusCode.RequestTimeout ||
                        (status >= HttpStatusCode.InternalServerError &&
                        status != HttpStatusCode.NotImplemented &&
                        status != HttpStatusCode.HttpVersionNotSupported);
        }

        private static void LogMessage(string message)
        {
            if (TracingAdapter.IsEnabled)
            {
                TracingAdapter.Information(message);
            }
        }
    }
}
