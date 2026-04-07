// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.HDInsight.Job
{
    using Microsoft.Azure.HDInsight.Job.Models;
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Operations for managing jobs against HDInsight clusters.
    /// </summary>
    public partial class JobOperationsExtensions
    {
        /// <summary>
        /// Submits a Hive job to an HDInsight cluster.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.HDInsight.Job.IJobOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. Hive job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        public static JobSubmissionJsonResponse SubmitHiveJob(this IJobOperations operations, HiveJobSubmissionParameters parameters)
        {
            return SubmitHiveJobAsync(operations, parameters).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Submits a Hive job to an HDInsight cluster.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.HDInsight.Job.IJobOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. Hive job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        public static async Task<JobSubmissionJsonResponse> SubmitHiveJobAsync(this IJobOperations operations, HiveJobSubmissionParameters parameters, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.SubmitHiveJobWithHttpMessagesAsync(parameters, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Submits a MapReduce job to an HDInsight cluster.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.HDInsight.Job.IJobOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. MapReduce job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        public static JobSubmissionJsonResponse SubmitMapReduceJob(this IJobOperations operations, MapReduceJobSubmissionParameters parameters)
        {
            return operations.SubmitMapReduceJobAsync(parameters).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Submits a MapReduce job to an HDInsight cluster.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.HDInsight.Job.IJobOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. MapReduce job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        public static async Task<JobSubmissionJsonResponse> SubmitMapReduceJobAsync(this IJobOperations operations, MapReduceJobSubmissionParameters parameters, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.SubmitMapReduceJobWithHttpMessagesAsync(parameters, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Submits a MapReduce streaming job to an HDInsight cluster.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.HDInsight.Job.IJobOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. MapReduce job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        public static JobSubmissionJsonResponse SubmitMapReduceStreamingJob(this IJobOperations operations, MapReduceStreamingJobSubmissionParameters parameters)
        {
            return operations.SubmitMapReduceStreamingJobAsync(parameters).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Submits a MapReduce streaming job to an HDInsight cluster.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.HDInsight.Job.IJobOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. MapReduce job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        public static async Task<JobSubmissionJsonResponse> SubmitMapReduceStreamingJobAsync(this IJobOperations operations, MapReduceStreamingJobSubmissionParameters parameters, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.SubmitMapReduceStreamingJobWithHttpMessagesAsync(parameters, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Submits a Pig job to an HDInsight cluster.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.HDInsight.Job.IJobOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. Pig job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        public static JobSubmissionJsonResponse SubmitPigJob(this IJobOperations operations, PigJobSubmissionParameters parameters)
        {
            return operations.SubmitPigJobAsync(parameters).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Submits a Pig job to an HDInsight cluster.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.HDInsight.Job.IJobOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. Pig job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        public static async Task<JobSubmissionJsonResponse> SubmitPigJobAsync(this IJobOperations operations, PigJobSubmissionParameters parameters, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.SubmitPigJobWithHttpMessagesAsync(parameters, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Submits a Sqoop job to an HDInsight cluster.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.HDInsight.Job.IJobOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. Sqoop job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        public static JobSubmissionJsonResponse SubmitSqoopJob(this IJobOperations operations, SqoopJobSubmissionParameters parameters)
        {
            return operations.SubmitSqoopJobAsync(parameters).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Submits a Sqoop job to an HDInsight cluster.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.HDInsight.Job.IJobOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. Sqoop job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        public static async Task<JobSubmissionJsonResponse> SubmitSqoopJobAsync(this IJobOperations operations, SqoopJobSubmissionParameters parameters, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.SubmitSqoopJobWithHttpMessagesAsync(parameters, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Gets the output from the execution of an individual jobDetails.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.HDInsight.Job.IJobOperations.
        /// </param>
        /// <param name="jobId">
        /// Required. The id of the job.
        /// </param>
        /// <param name="storageAccess">
        /// Required. The storage account object of type IStorageAccess.
        /// </param>
        /// <returns>
        /// The output of an individual jobDetails by jobId.
        /// </returns>
        public static Stream GetJobOutput(this IJobOperations operations, string jobId, IStorageAccess storageAccess)
        {
            return Task.Factory.StartNew(
                (object s) =>
                ((IJobOperations)s).GetJobOutputAsync(jobId, storageAccess), operations,
                CancellationToken.None,
                TaskCreationOptions.None, TaskScheduler.Default)
                .Unwrap()
                .GetAwaiter()
                .GetResult();
        }

        /// <summary>
        /// Gets the output from the execution of an individual jobDetails.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.HDInsight.Job.IJobOperations.
        /// </param>
        /// <param name="jobId">
        /// Required. The id of the job.
        /// </param>
        /// <param name="storageAccess">
        /// Required. The storage account object of type IStorageAccess.
        /// </param>
        /// <returns>
        /// The output of an individual jobDetails by jobId.
        /// </returns>
        public static Task<Stream> GetJobOutputAsync(this IJobOperations operations, string jobId,
            IStorageAccess storageAccess)
        {
            return operations.GetJobOutputAsync(jobId, storageAccess, CancellationToken.None);
        }

        /// <summary>
        /// Gets the error logs from the execution of an individual jobDetails.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.HDInsight.Job.IJobOperations.
        /// </param>
        /// <param name="jobId">
        /// Required. The id of the job.
        /// </param>
        /// <param name="storageAccess">
        /// Required. The storage account object of type IStorageAccess.
        /// </param>
        /// <returns>
        /// The error logs of an individual jobDetails by jobId.
        /// </returns>
        public static Stream GetJobErrorLogs(this IJobOperations operations, string jobId,
            IStorageAccess storageAccess)
        {
            return Task.Factory.StartNew(
                (object s) =>
                    ((IJobOperations)s).GetJobErrorLogsAsync(jobId, storageAccess), operations,
                CancellationToken.None,
                TaskCreationOptions.None, TaskScheduler.Default)
                .Unwrap()
                .GetAwaiter()
                .GetResult();
        }

        /// <summary>
        /// Gets the error logs from the execution of an individual jobDetails.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.HDInsight.Job.IJobOperations.
        /// </param>
        /// <param name="jobId">
        /// Required. The id of the job.
        /// </param>
        /// <param name="storageAccess">
        /// Required. The storage account object of type IStorageAccess.
        /// </param>
        /// <returns>
        /// The error logs of an individual jobDetails by jobId.
        /// </returns>
        public static Task<Stream> GetJobErrorLogsAsync(this IJobOperations operations, string jobId,
            IStorageAccess storageAccess)
        {
            return operations.GetJobErrorLogsAsync(jobId, storageAccess, CancellationToken.None);
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
        public static JobDetailRootJsonObject WaitForJobCompletion(this IJobOperations operations, string jobId, TimeSpan? duration = null, TimeSpan? waitInterval = null)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IJobOperations)s).WaitForJobCompletionAsync(jobId, duration, waitInterval);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
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
        public static async Task<JobDetailRootJsonObject> WaitForJobCompletionAsync(this IJobOperations operations, string jobId, TimeSpan? duration = null, TimeSpan? waitInterval = null)
        {
            using (var _result = await operations.WaitForJobCompletionWithHttpMessagesAsync(jobId, duration, waitInterval).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
    }
}
