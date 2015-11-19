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
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client.WebHCatRest;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;

    /// <summary>
    /// Extends an instance of Hadoop against which jobs can be submitted.
    /// </summary>
    public static class IHadoopClientExtensions
    {
        internal static Func<int> GetPollingInterval = () => Constants.PollingInterval;

        /// <summary>
        /// Method that waits for a jobDetails to complete.
        /// </summary>
        /// <param name="client">The Hadoop client to use.</param>
        /// <param name="job">The jobDetails to wait for.</param>
        /// <param name="duration">The duration to wait before timing out.</param>
        /// <param name="cancellationToken">
        /// The Cancellation Token for the request.
        /// </param>
        /// <returns>An awaitable task that represents the action.</returns>
        public static async Task<JobDetails> WaitForJobCompletionAsync(
            this IJobSubmissionClient client, JobCreationResults job, TimeSpan duration, CancellationToken cancellationToken)
        {
            client.ArgumentNotNull("client");
            job.ArgumentNotNull("jobDetails");

            return await client.WaitForJobCompletionAsync(job.JobId, duration, cancellationToken);
        }

        /// <summary>
        /// Method that waits for a jobDetails to complete.
        /// </summary>
        /// <param name="client">The Hadoop client to use.</param>
        /// <param name="jobId">The id of the job to wait for.</param>
        /// <param name="duration">The duration to wait before timing out.</param>
        /// <param name="cancellationToken">
        /// The Cancellation Token for the request.
        /// </param>
        /// <returns>An awaitable task that represents the action.</returns>
        public static async Task<JobDetails> WaitForJobCompletionAsync(
            this IJobSubmissionClient client, string jobId, TimeSpan duration, CancellationToken cancellationToken)
        {
            client.ArgumentNotNull("client");
            jobId.ArgumentNotNull("jobId");
            JobDetails jobDetailsResults = new JobDetails() { JobId = jobId, StatusCode = JobStatusCode.Unknown };
            var pollingInterval = GetPollingInterval();
            var startTime = DateTime.UtcNow;
            var endTime = DateTime.UtcNow;

            while (jobDetailsResults.IsNotNull() && ((endTime = DateTime.UtcNow) - startTime) < duration &&
                   !(jobDetailsResults.StatusCode == JobStatusCode.Completed || jobDetailsResults.StatusCode == JobStatusCode.Failed ||
                     jobDetailsResults.StatusCode == JobStatusCode.Canceled))
            {
                client.HandleClusterWaitNotifyEvent(jobDetailsResults);
                if (jobDetailsResults.StatusCode == JobStatusCode.Completed || jobDetailsResults.StatusCode == JobStatusCode.Failed)
                {
                    break;
                }
                Thread.Sleep(pollingInterval);
                jobDetailsResults = await GetJobWithRetry(client, jobId, cancellationToken);
            }

            if (jobDetailsResults.StatusCode != JobStatusCode.Completed && jobDetailsResults.StatusCode != JobStatusCode.Failed &&
                jobDetailsResults.StatusCode != JobStatusCode.Canceled && (endTime - startTime) >= duration)
            {
                throw new TimeoutException(string.Format(CultureInfo.InvariantCulture, "The requested task failed to complete in the allotted time ({0}).", duration));
            }

            return jobDetailsResults;
        }

        /// <summary>
        /// Method that waits for a jobDetails to complete.
        /// </summary>
        /// <param name="client">The Hadoop client to use.</param>
        /// <param name="job">The jobDetails to wait for.</param>
        /// <param name="duration">The duration to wait before timing out.</param>
        /// <param name="cancellationToken">
        /// The Cancellation Token for the request.
        /// </param>
        /// <returns>The jobDetails's pigJobCreateParameters.</returns>
        public static JobDetails WaitForJobCompletion(
            this IJobSubmissionClient client, JobCreationResults job, TimeSpan duration, CancellationToken cancellationToken)
        {
            return WaitForJobCompletionAsync(client, job, duration, cancellationToken).WaitForResult();
        }

        private static async Task<JobDetails> GetJobWithRetry(IJobSubmissionClient client, string jobId, CancellationToken cancellationToken)
        {
            JobDetails jobDetailsResults = null;
            var pollingInterval = GetPollingInterval();
            int retryCount = 0;
            while (jobDetailsResults.IsNull())
            {
                try
                {
                    jobDetailsResults = await client.GetJobAsync(jobId);
                    break;
                }
                catch (HttpLayerException)
                {
                    if (retryCount >= Constants.RetryCount)
                    {
                        throw;
                    }
                    cancellationToken.WaitForInterval(TimeSpan.FromMilliseconds(pollingInterval));
                    retryCount++;
                }
            }
            return jobDetailsResults;
        }
    }
}
