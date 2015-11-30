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
namespace Microsoft.Hadoop.Client.WebHCatRest
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;

    /// <summary>
    /// Provides REST implementation of a remote Hadoop client.
    /// </summary>
    internal interface IHadoopJobSubmissionRestClient
    {
        /// <summary>
        /// Retruns the UserAgent string to use for all submissions by this client.
        /// </summary>
        /// <returns>Custom user agent.</returns>
        string GetUserAgentString();

        /// <summary>
        /// Lists all jobs on the system.
        /// </summary>
        /// <returns>
        /// A list of all jobs on the system.
        /// </returns>
        Task<IHttpResponseMessageAbstraction> ListJobs();

        /// <summary>
        /// Returns the details of a specific jobDetails.
        /// </summary>
        /// <param name="jobId">
        /// The jobId for the jobDetails to return.
        /// </param>
        /// <returns>
        /// The jobDetails details.
        /// </returns>
        Task<IHttpResponseMessageAbstraction> GetJob(string jobId);

        /// <summary>
        /// Submits a Map Reduce jobDetails to the server.
        /// </summary>
        /// <param name="payload">
        /// The payload of the jobDetails to submit.
        /// </param>
        /// <returns>
        /// The response of the jobDetails submission request.
        /// </returns>
        Task<IHttpResponseMessageAbstraction> SubmitMapReduceJob(string payload);

        /// <summary>
        /// Submits a HiveJob to the server.
        /// </summary>
        /// <param name="payload">
        /// The payload of the jobDetails to submit.
        /// </param>
        /// <returns>
        /// The response of the jobDetails submission request.
        /// </returns>
        Task<IHttpResponseMessageAbstraction> SubmitHiveJob(string payload);

        /// <summary>
        /// Submits a Streaming Map Reduce jobDetails to the server.
        /// </summary>
        /// <param name="payload">
        /// The payload of the jobDetails to submit.
        /// </param>
        /// <returns>
        /// The response of the job submission request.
        /// </returns>
        Task<IHttpResponseMessageAbstraction> SubmitStreamingMapReduceJob(string payload);

        /// <summary>
        /// Submits a Pig jobDetails to the server.
        /// </summary>
        /// <param name="payload">
        /// The payload of the jobDetails to submit.
        /// </param>
        /// <returns>
        /// The response of the jobDetails submission request.
        /// </returns>
        Task<IHttpResponseMessageAbstraction> SubmitPigJob(string payload);

        /// <summary>
        /// Submits a Sqoop_ jobDetails to the server.
        /// </summary>
        /// <param name="payload">
        /// The payload of the jobDetails to submit.
        /// </param>
        /// <returns>
        /// The response of the jobDetails submission request.
        /// </returns>
        Task<IHttpResponseMessageAbstraction> SubmitSqoopJob(string payload);

        /// <summary>
        /// Stops the execution of a running jobDetails.
        /// </summary>
        /// <param name="jobId">The JobId.</param>
        /// <returns>
        /// The response of the jobDetails cancellation request.
        /// </returns>
        Task<IHttpResponseMessageAbstraction> StopJob(string jobId);
    }
}
