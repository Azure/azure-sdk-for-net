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
namespace Microsoft.Hadoop.Client.HadoopJobSubmissionPocoClient
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a HadoopJobSubmissionPocoClient.
    /// </summary>
    internal interface IHadoopJobSubmissionPocoClient
    {
        /// <summary>
        /// Retruns the UserAgent string to use for all submissions by this client.
        /// </summary>
        /// <returns>Custom useragent string if present.</returns>
        string GetUserAgentString();

        /// <summary>
        /// Lists the jobs on a Hadoop server.
        /// </summary>
        /// <returns>
        /// The list of jobs.
        /// </returns>
        Task<JobList> ListJobs();

        /// <summary>
        /// Returns the pigJobCreateParameters about a single jobDetails.
        /// </summary>
        /// <param name="jobId">
        ///     The JobId.
        /// </param>
        /// <returns>
        /// The pigJobCreateParameters of a jobDetails.
        /// </returns>
        Task<JobDetails> GetJob(string jobId);

        /// <summary>
        /// Submits a Map Reduce jobDetails to the server.
        /// </summary>
        /// <param name="details">
        ///     The pigJobCreateParameters for the Map/Reduce jobDetails.
        /// </param>
        /// <returns>
        /// The result of the jobDetails submission.
        /// </returns>
        Task<JobCreationResults> SubmitMapReduceJob(MapReduceJobCreateParameters details);

        /// <summary>
        /// Submits a Hive jobDetails to the server.
        /// </summary>
        /// <param name="details">
        ///     The pigJobCreateParameters for the Hive jobDetails.
        /// </param>
        /// <returns>
        /// The result of the jobDetails submission.
        /// </returns>
        Task<JobCreationResults> SubmitHiveJob(HiveJobCreateParameters details);

        /// <summary>
        /// Submits a Pig jobDetails to the server.
        /// </summary>
        /// <param name="pigJobCreateParameters">
        ///     The pigJobCreateParameters for the Pig jobDetails.
        /// </param>
        /// <returns>
        /// The result of the jobDetails submission.
        /// </returns>
        Task<JobCreationResults> SubmitPigJob(PigJobCreateParameters pigJobCreateParameters);

        /// <summary>
        /// Submits a Sqoop jobDetails to the server.
        /// </summary>
        /// <param name="sqoopJobCreateParameters">
        ///     The sqoopJobCreateParameters for the Pig jobDetails.
        /// </param>
        /// <returns>
        /// The result of the jobDetails submission.
        /// </returns>
        Task<JobCreationResults> SubmitSqoopJob(SqoopJobCreateParameters sqoopJobCreateParameters);

        /// <summary>
        /// Submits a Streaming jobDetails to the server.
        /// </summary>
        /// <param name="pigJobCreateParameters">
        ///     The pigJobCreateParameters for the Streaming jobDetails.
        /// </param>
        /// <returns>
        /// The result of the jobDetails submission.
        /// </returns>
        Task<JobCreationResults> SubmitStreamingJob(StreamingMapReduceJobCreateParameters pigJobCreateParameters);

        /// <summary>
        /// Stops the execution of a running jobDetails.
        /// </summary>
        /// <param name="jobId">The JobId.</param>
        /// <returns>The pigJobCreateParameters of the jobDetails after it is stopped.</returns>
        Task<JobDetails> StopJob(string jobId);
    }
}
