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
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides Asynchronous operations against a Hadoop cluster.
    /// </summary>
    public interface IJobSubmissionAsyncClient : IJobSubmissionClientBase
    {
        /// <summary>
        /// Event that is fired when the client provisions a cluster.
        /// </summary>
        event EventHandler<WaitJobStatusEventArgs> JobStatusEvent;

        /// <summary>
        /// Used to handle the notification events during waiting.
        /// </summary>
        /// <param name="jobDetails">
        /// The jobDetails in its current state.
        /// </param>
        void HandleClusterWaitNotifyEvent(JobDetails jobDetails);

        /// <summary>
        /// Lists the jobs currently on the server.
        /// </summary>
        /// <returns>
        /// The list of jobs.
        /// </returns>
        Task<JobList> ListJobsAsync();

        /// <summary>
        /// Gets the pigJobCreateParameters about an individual jobDetails.
        /// </summary>
        /// <param name="jobId">
        /// The jobId.
        /// </param>
        /// <returns>
        /// The pigJobCreateParameters of an individual jobDetails by jobId.
        /// </returns>
        Task<JobDetails> GetJobAsync(string jobId);

        /// <summary>
        /// Creates a Mapreduce jobDetails on the server.
        /// </summary>
        /// <param name="mapReduceJobCreateParameters">The Mapreduce jobDetails to create.</param>
        /// <returns>The pigJobCreateParameters of the jobDetails after it is created.</returns>
        Task<JobCreationResults> CreateMapReduceJobAsync(MapReduceJobCreateParameters mapReduceJobCreateParameters);

        /// <summary>
        /// Creates a streaming Mapreduce jobDetails on the server.
        /// </summary>
        /// <param name="streamingMapReduceJobCreateParameters">The streaming Mapreduce jobDetails to create.</param>
        /// <returns>The pigJobCreateParameters of the job after it is created.</returns>
        Task<JobCreationResults> CreateStreamingJobAsync(StreamingMapReduceJobCreateParameters streamingMapReduceJobCreateParameters);

        /// <summary>
        /// Creates a Hive jobDetails on the server.
        /// </summary>
        /// <param name="hiveJobCreateParameters">The Hive jobDetails to create.</param>
        /// <returns>The pigJobCreateParameters of the jobDetails after it is created.</returns>
        Task<JobCreationResults> CreateHiveJobAsync(HiveJobCreateParameters hiveJobCreateParameters);

        /// <summary>
        /// Creates a Pig jobDetails on the server.
        /// </summary>
        /// <param name="pigJobCreateParameters">The Pig jobDetails to create.</param>
        /// <returns>The pigJobCreateParameters of the jobDetails after it is created.</returns>
        Task<JobCreationResults> CreatePigJobAsync(PigJobCreateParameters pigJobCreateParameters);

        /// <summary>
        /// Creates a Sqoop jobDetails on the server.
        /// </summary>
        /// <param name="sqoopJobCreateParameters">The Sqoop jobDetails to create.</param>
        /// <returns>The pigJobCreateParameters of the jobDetails after it is created.</returns>
        Task<JobCreationResults> CreateSqoopJobAsync(SqoopJobCreateParameters sqoopJobCreateParameters);

        /// <summary>
        /// Stops the execution of a running jobDetails.
        /// </summary>
        /// <param name="jobId">The JobId.</param>
        /// <returns>A task to track the cancellation of the jobDetails.</returns>
        Task<JobDetails> StopJobAsync(string jobId);

        /// <summary>
        /// Gets the output from execution of a jobDetails.
        /// </summary>
        /// <param name="jobId">The JobId.</param>
        /// <returns>The output from execution of a jobDetails.</returns>
        Task<Stream> GetJobOutputAsync(string jobId);

        /// <summary>
        /// Gets the error logs from execution of a jobDetails.
        /// </summary>
        /// <param name="jobId">The JobId.</param>
        /// <returns>The output from execution of a jobDetails.</returns>
        Task<Stream> GetJobErrorLogsAsync(string jobId);

        /// <summary>
        /// Gets the task log summary from execution of a jobDetails.
        /// </summary>
        /// <param name="jobId">The JobId.</param>
        /// <returns>
        /// The task logs of an individual jobDetails by jobId.
        /// </returns>
        Task<Stream> GetJobTaskLogSummaryAsync(string jobId);

        /// <summary>
        /// Gets the task log summary from execution of a jobDetails.
        /// </summary>
        /// <param name="jobId">The JobId.</param>
        /// <param name="targetDirectory">The target directory to download the jobDetails logs to.</param>
        /// <returns>
        /// The task logs of an individual jobDetails by jobId.
        /// </returns>
        Task DownloadJobTaskLogsAsync(string jobId, string targetDirectory);
    }
}
