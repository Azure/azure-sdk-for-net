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
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents an instance of Hadoop against which jobs can be submitted (synchronously).
    /// </summary>
    public interface IJobSubmissionSyncClient : IJobSubmissionClientBase
    {
        /// <summary>
        /// Lists the jobs currently on the server.
        /// </summary>
        /// <returns>
        /// The list of jobs.
        /// </returns>
        JobList ListJobs();

        /// <summary>
        /// Gets the pigJobCreateParameters about an individual jobDetails.
        /// </summary>
        /// <param name="jobId">
        /// The jobId.
        /// </param>
        /// <returns>
        /// The pigJobCreateParameters of an individual jobDetails by jobId.
        /// </returns>
        JobDetails GetJob(string jobId);

        /// <summary>
        /// Creates a Mapreduce jobDetails on the server.
        /// </summary>
        /// <param name="mapReduceJobCreateParameters">The Mapreduce jobDetails to create.</param>
        /// <returns>The pigJobCreateParameters of the jobDetails after it is created.</returns>
        JobCreationResults CreateMapReduceJob(MapReduceJobCreateParameters mapReduceJobCreateParameters);

        /// <summary>
        /// Creates a streaming Mapreduce jobDetails on the server.
        /// </summary>
        /// <param name="streamingMapReduceJobCreateParameters">The streaming Mapreduce jobDetails to create.</param>
        /// <returns>The pigJobCreateParameters of the job after it is created.</returns>
        JobCreationResults CreateStreamingJob(StreamingMapReduceJobCreateParameters streamingMapReduceJobCreateParameters);

        /// <summary>
        /// Creates a Hive jobDetails on the server.
        /// </summary>
        /// <param name="hiveJobCreateParameters">The Hive jobDetails to create.</param>
        /// <returns>The pigJobCreateParameters of the jobDetails after it is created.</returns>
        JobCreationResults CreateHiveJob(HiveJobCreateParameters hiveJobCreateParameters);

        /// <summary>
        /// Creates a Pig jobDetails on the server.
        /// </summary>
        /// <param name="pigJobCreateParameters">The Pig jobDetails to create.</param>
        /// <returns>The pigJobCreateParameters of the jobDetails after it is created.</returns>
        JobCreationResults CreatePigJob(PigJobCreateParameters pigJobCreateParameters);

        /// <summary>
        /// Creates a Sqoop jobDetails on the server.
        /// </summary>
        /// <param name="sqoopJobCreateParameters">The Sqoop jobDetails to create.</param>
        /// <returns>The sqoopJobCreateParameters of the jobDetails after it is created.</returns>
        JobCreationResults CreateSqoopJob(SqoopJobCreateParameters sqoopJobCreateParameters);

        /// <summary>
        /// Stops the execution of a running jobDetails.
        /// </summary>
        /// <param name="jobId">The JobId.</param>
        /// <returns>The pigJobCreateParameters of the jobDetails after it is stopped.</returns>
        JobDetails StopJob(string jobId);

        /// <summary>
        /// Gets the output from the execution of an individual jobDetails.
        /// </summary>
        /// <param name="jobId">
        /// The jobId.
        /// </param>
        /// <returns>
        /// The output of an individual jobDetails by jobId.
        /// </returns>
        Stream GetJobOutput(string jobId);

        /// <summary>
        /// Gets the error logs from the execution of an individual jobDetails.
        /// </summary>
        /// <param name="jobId">
        /// The jobId.
        /// </param>
        /// <returns>
        /// The error logs of an individual jobDetails by jobId.
        /// </returns>
        Stream GetJobErrorLogs(string jobId);

        /// <summary>
        /// Gets the task logs from the execution of an individual jobDetails.
        /// </summary>
        /// <param name="jobId">
        /// The jobId.
        /// </param>
        /// <returns>
        /// The task logs of an individual jobDetails by jobId.
        /// </returns>
        Stream GetJobTaskLogSummary(string jobId);

        /// <summary>
        /// Gets the task log summary from execution of a jobDetails.
        /// </summary>
        /// <param name="jobId">The JobId.</param>
        /// <param name="targetDirectory">The target directory to download the jobDetails logs to.</param>
        void DownloadJobTaskLogs(string jobId, string targetDirectory);
    }
}
