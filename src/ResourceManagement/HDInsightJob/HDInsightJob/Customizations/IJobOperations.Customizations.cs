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

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System;
using Microsoft.Azure.Management.HDInsight.Job.Models;

namespace Microsoft.Azure.Management.HDInsight.Job
{
    /// <summary>
    /// Operations for managing jobs against HDInsight clusters.
    /// </summary>
    public partial interface IJobOperations
    {
        /// <summary>
        /// Submits a Hive job to an HDInsight cluster.
        /// </summary>
        /// <param name='parameters'>
        /// Required. Hive job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        Task<JobSubmissionResponse> SubmitHiveJobAsync(HiveJobSubmissionParameters parameters);

        /// <summary>
        /// Submits a MapReduce job to an HDInsight cluster.
        /// </summary>
        /// <param name='parameters'>
        /// Required. MapReduce job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        Task<JobSubmissionResponse> SubmitMapReduceJobAsync(MapReduceJobSubmissionParameters parameters);

        /// <summary>
        /// Submits a MapReduce streaming job to an HDInsight cluster.
        /// </summary>
        /// <param name='parameters'>
        /// Required. MapReduce job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        Task<JobSubmissionResponse> SubmitMapReduceStreamingJobAsync(MapReduceStreamingJobSubmissionParameters parameters);

        /// <summary>
        /// Submits a Pig job to an HDInsight cluster.
        /// </summary>
        /// <param name='parameters'>
        /// Required. Pig job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        Task<JobSubmissionResponse> SubmitPigJobAsync(PigJobSubmissionParameters parameters);

        /// <summary>
        /// Submits a Sqoop job to an HDInsight cluster.
        /// </summary>
        /// <param name='parameters'>
        /// Required. Sqoop job parameters.
        /// </param>
        /// <returns>
        /// The Create Job operation response.
        /// </returns>
        Task<JobSubmissionResponse> SubmitSqoopJobAsync(SqoopJobSubmissionParameters parameters);

        /// <summary>
        /// Gets the output from the execution of an individual jobDetails.
        /// </summary>
        /// <param name="jobId">
        /// Required. The id of the job.
        /// </param>
        /// <param name="storageAccess">
        /// Required. The storage account object of type IStorageAccess.
        /// </param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// The output of an individual jobDetails by jobId.
        /// </returns>
        Task<Stream> GetJobOutputAsync(string jobId, IStorageAccess storageAccess, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the error logs from the execution of an individual jobDetails.
        /// </summary>
        /// <param name="jobId">
        /// Required. The id of the job.
        /// </param>
        /// <param name="storageAccess">
        /// Required. The storage account object of type IStorageAccess.
        /// </param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        /// The error logs of an individual jobDetails by jobId.
        /// </returns>
        Task<Stream> GetJobErrorLogsAsync(string jobId, IStorageAccess storageAccess, CancellationToken cancellationToken);

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
        Task<JobGetResponse> WaitForJobCompletionAsync(string jobId, TimeSpan? duration, TimeSpan? waitInterval);
    }
}
