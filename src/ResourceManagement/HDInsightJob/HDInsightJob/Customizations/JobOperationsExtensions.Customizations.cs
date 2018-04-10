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
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.HDInsight.Job.Models;

namespace Microsoft.Azure.Management.HDInsight.Job
{
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
        /// Microsoft.Azure.Management.HDInsight.Job.IJobOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. Hive job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        public static JobSubmissionResponse SubmitHiveJob(this IJobOperations operations, HiveJobSubmissionParameters parameters)
        {
            return operations.SubmitHiveJob(new JobSubmissionParameters { Content = parameters.GetJobPostRequestContent() });
        }

        /// <summary>
        /// Submits a Hive job to an HDInsight cluster.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.HDInsight.Job.IJobOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. Hive job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        public static Task<JobSubmissionResponse> SubmitHiveJobAsync(this IJobOperations operations, HiveJobSubmissionParameters parameters)
        {
            return operations.SubmitHiveJobAsync(parameters);
        }

        /// <summary>
        /// Submits a MapReduce job to an HDInsight cluster.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.HDInsight.Job.IJobOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. MapReduce job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        public static JobSubmissionResponse SubmitMapReduceJob(this IJobOperations operations, MapReduceJobSubmissionParameters parameters)
        {
            return operations.SubmitMapReduceJob(new JobSubmissionParameters { Content = parameters.GetJobPostRequestContent() });
        }

        /// <summary>
        /// Submits a MapReduce job to an HDInsight cluster.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.HDInsight.Job.IJobOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. MapReduce job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        public static Task<JobSubmissionResponse> SubmitMapReduceJobAsync(this IJobOperations operations, MapReduceJobSubmissionParameters parameters)
        {
            return operations.SubmitMapReduceJobAsync(parameters);
        }

        /// <summary>
        /// Submits a MapReduce streaming job to an HDInsight cluster.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.HDInsight.Job.IJobOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. MapReduce job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        public static JobSubmissionResponse SubmitMapReduceStreamingJob(this IJobOperations operations, MapReduceStreamingJobSubmissionParameters parameters)
        {
            return operations.SubmitMapReduceStreamingJob(new JobSubmissionParameters { Content = parameters.GetJobPostRequestContent() });
        }

        /// <summary>
        /// Submits a MapReduce streaming job to an HDInsight cluster.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.HDInsight.Job.IJobOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. MapReduce job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        public static Task<JobSubmissionResponse> SubmitMapReduceStreamingJobAsync(this IJobOperations operations, MapReduceStreamingJobSubmissionParameters parameters)
        {
            return operations.SubmitMapReduceStreamingJobAsync(parameters);
        }

        /// <summary>
        /// Submits a Pig job to an HDInsight cluster.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.HDInsight.Job.IJobOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. Pig job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        public static JobSubmissionResponse SubmitPigJob(this IJobOperations operations, PigJobSubmissionParameters parameters)
        {
            return operations.SubmitPigJob(new JobSubmissionParameters { Content = parameters.GetJobPostRequestContent() });
        }

        /// <summary>
        /// Submits a Pig job to an HDInsight cluster.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.HDInsight.Job.IJobOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. Pig job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        public static Task<JobSubmissionResponse> SubmitPigJobAsync(this IJobOperations operations, PigJobSubmissionParameters parameters)
        {
            return operations.SubmitPigJobAsync(parameters);
        }

        /// <summary>
        /// Submits a Sqoop job to an HDInsight cluster.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.HDInsight.Job.IJobOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. Sqoop job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        public static JobSubmissionResponse SubmitSqoopJob(this IJobOperations operations, SqoopJobSubmissionParameters parameters)
        {
            return operations.SubmitSqoopJob(new JobSubmissionParameters { Content = parameters.GetJobPostRequestContent() });
        }

        /// <summary>
        /// Submits a Sqoop job to an HDInsight cluster.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.HDInsight.Job.IJobOperations.
        /// </param>
        /// <param name='parameters'>
        /// Required. Sqoop job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        public static Task<JobSubmissionResponse> SubmitSqoopJobAsync(this IJobOperations operations, SqoopJobSubmissionParameters parameters)
        {
            return operations.SubmitSqoopJobAsync(parameters);
        }

        /// <summary>
        /// Gets the output from the execution of an individual jobDetails.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.Azure.Management.HDInsight.Job.IJobOperations.
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
        /// Microsoft.Azure.Management.HDInsight.Job.IJobOperations.
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
        /// Microsoft.Azure.Management.HDInsight.Job.IJobOperations.
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
        /// Microsoft.Azure.Management.HDInsight.Job.IJobOperations.
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
        public static JobGetResponse WaitForJobCompletion(this IJobOperations operations, string jobId, TimeSpan? duration = null, TimeSpan? waitInterval = null)
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
        public static Task<JobGetResponse> WaitForJobCompletionAsync(this IJobOperations operations, string jobId, TimeSpan? duration = null, TimeSpan? waitInterval = null)
        {
            return operations.WaitForJobCompletionAsync(jobId, duration, waitInterval);
        }
    }
}
