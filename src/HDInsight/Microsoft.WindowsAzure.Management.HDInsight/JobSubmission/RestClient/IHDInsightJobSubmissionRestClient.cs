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
namespace Microsoft.WindowsAzure.Management.HDInsight.JobSubmission.RestClient
{
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;

    /// <summary>
    /// Represents a rest call to the server.
    /// </summary>
    internal interface IHDInsightJobSubmissionRestClient : IQueryDisposable
    {
        /// <summary>
        /// Creates a jobDetails on the cluster.
        /// </summary>
        /// <param name="containerName">
        /// The container name.
        /// </param>
        /// <param name="location">
        /// The geo location of the container.
        /// </param>
        /// <param name="payload">
        /// The payload representing the request.
        /// </param>
        /// <returns>
        /// A task representing the jobDetails creation.
        /// </returns>
        Task<IHttpResponseMessageAbstraction> CreateJob(string containerName, string location, string payload);

        /// <summary>
        /// Lists the jobDetails on a cluster.
        /// </summary>
        /// <param name="containerName">
        /// The container name.
        /// </param>
        /// <param name="location">
        /// The geo location of the container.
        /// </param>
        /// <returns>
        /// A task representing the jobDetails creation.
        /// </returns>
        Task<IHttpResponseMessageAbstraction> ListJobs(string containerName, string location);

        /// <summary>
        /// Returns jobDetails details for a given jobDetails.
        /// </summary>
        /// <param name="containerName">
        /// The container name.
        /// </param>
        /// <param name="location">
        /// The geo location of the container.
        /// </param>
        /// <param name="id">
        /// The id of the jobDetails to retrieve.
        /// </param>
        /// <returns>
        /// A task representing the jobDetails creation.
        /// </returns>
        Task<IHttpResponseMessageAbstraction> GetJobDetail(string containerName, string location, string id);
    }
}
