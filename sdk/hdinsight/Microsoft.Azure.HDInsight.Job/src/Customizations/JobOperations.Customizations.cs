// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.HDInsight.Job
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.HDInsight.Job.Models;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Operations for managing jobs against HDInsight clusters.
    /// </summary>
    internal partial class JobOperations : IServiceOperations<HDInsightJobClient>, IJobOperations
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
        public async Task<AzureOperationResponse<JobSubmissionJsonResponse>> SubmitHiveJobWithHttpMessagesAsync(HiveJobSubmissionParameters parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var requestContents = new MemoryStream(Encoding.UTF8.GetBytes(parameters.GetJobPostRequestContent())))
            {
                return await SubmitHiveJobWithHttpMessagesAsync(requestContents, customHeaders, cancellationToken).ConfigureAwait(false);
            }
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
        public async Task<AzureOperationResponse<JobSubmissionJsonResponse>> SubmitMapReduceJobWithHttpMessagesAsync(MapReduceJobSubmissionParameters parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var requestContents = new MemoryStream(Encoding.UTF8.GetBytes(parameters.GetJobPostRequestContent())))
            {
                return await SubmitMapReduceJobWithHttpMessagesAsync(requestContents, customHeaders, cancellationToken).ConfigureAwait(false);
            }
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
        public async Task<AzureOperationResponse<JobSubmissionJsonResponse>> SubmitMapReduceStreamingJobWithHttpMessagesAsync(MapReduceStreamingJobSubmissionParameters parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var requestContents = new MemoryStream(Encoding.UTF8.GetBytes(parameters.GetJobPostRequestContent())))
            {
                return await SubmitMapReduceStreamingJobWithHttpMessagesAsync(requestContents, customHeaders, cancellationToken).ConfigureAwait(false);
            }
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
        public async Task<AzureOperationResponse<JobSubmissionJsonResponse>> SubmitPigJobWithHttpMessagesAsync(PigJobSubmissionParameters parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var requestContents = new MemoryStream(Encoding.UTF8.GetBytes(parameters.GetJobPostRequestContent())))
            {
                return await SubmitPigJobWithHttpMessagesAsync(requestContents, customHeaders, cancellationToken).ConfigureAwait(false);
            }
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
        public async Task<AzureOperationResponse<JobSubmissionJsonResponse>> SubmitSqoopJobWithHttpMessagesAsync(SqoopJobSubmissionParameters parameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var requestContents = new MemoryStream(Encoding.UTF8.GetBytes(parameters.GetJobPostRequestContent())))
            {
                return await SubmitSqoopJobWithHttpMessagesAsync(requestContents, customHeaders, cancellationToken).ConfigureAwait(false);
            }
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
            var blobReferencePath = await GetJobStatusDirectory(jobId, "stdout").ConfigureAwait(false);
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
            var blobReferencePath = await GetJobStatusDirectory(jobId, "stderr").ConfigureAwait(false);
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
        public async Task<AzureOperationResponse<JobDetailRootJsonObject>> WaitForJobCompletionWithHttpMessagesAsync(string jobId, TimeSpan? duration = null, TimeSpan? waitInterval = null)
        {
            var appId = GetAppIdFromJobId(jobId);
            var startTime = DateTime.UtcNow;
            bool waitTimeOut = false;

            if (waitInterval == null)
            {
                waitInterval = HDInsightJobClient.DefaultPollInterval;
            }

            // We poll Yarn for application status until application run is finished. If the application is
            // in finished state then we poll templeton to get completed job details.
            AzureOperationResponse<JobDetailRootJsonObject> jobDetail = null;

            // If duration is null means we need to keep retry until job is complete.
            while (duration == null || !(waitTimeOut = ((DateTime.UtcNow - startTime) > duration)))
            {
                try
                {
                    var jobState = await this.GetAppStateAsync(appId, CancellationToken.None).ConfigureAwait(false);

                    var appState = jobState.State;
                    if (appState == ApplicationState.FINISHED || appState == ApplicationState.FAILED || appState == ApplicationState.KILLED)
                    {
                        // Get the job finished details now and keep checking if Job is complete from Templeton 
                        // as history server may not have picked up the completed job.
                        using (jobDetail = await this.GetWithHttpMessagesAsync(jobId).ConfigureAwait(false))
                        {
                            if (jobDetail.Body.Status.JobComplete == true)
                            {
                                break;
                            }
                        }
                    }
                }
                catch (CloudException ex)
                {
                    // If transient error then keep retry until user specified duration.
                    if (IsTransientError(ex.Response.StatusCode))
                    {
                        LogMessages(ex.Message);
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
                    LogMessages(ex.Message);
                }

                ModelHelper.Delay(waitInterval.Value);
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
            var jobDetail = await this.GetAsync(jobId).ConfigureAwait(false);
            var statusDir = GetStatusFolder(jobDetail);

            if (statusDir == null)
            {
                throw new CloudException(string.Format("Job {0} was not created with a status folder and therefore no logs were saved.", jobDetail.Id));
            }

            return string.Format("user/{0}/{1}/{2}", jobDetail.User, statusDir, file);
        }

        private static string GetStatusFolder(JobDetailRootJsonObject job)
        {
            return job.Userargs.Statusdir == null ? null : job.Userargs.Statusdir.ToString();
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

        private static void LogMessages(string message)
        {
            if (ServiceClientTracing.IsEnabled)
            {
                ServiceClientTracing.Information(message);
            }
        }
    }
}
