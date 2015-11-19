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
namespace Microsoft.WindowsAzure.Management.HDInsight
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;

    /// <summary>
    /// Represents the HDInsight Application History Async client.
    /// </summary>
    public interface IHDInsightApplicationHistoryAsyncClient
    {
        /// <summary>
        /// Lists completed applications.
        /// </summary>
        /// <returns>
        /// A task object that can be awaited. The result is a list of Application Details.
        /// </returns>
        Task<IEnumerable<ApplicationDetails>> ListCompletedApplicationsAsync();

        /// <summary>
        /// Lists completed applications that were submitted within the specified time window.
        /// </summary>
        /// <param name="submittedAfterInUtc">
        /// Get applications that were submitted after this time.
        /// </param>
        /// <param name="submittedBeforeInUtc">
        /// Get applications that were submitted before this time.
        /// </param>
        /// <returns>
        /// A task object that can be awaited. The result is a list of Application Details.
        /// </returns>
        Task<IEnumerable<ApplicationDetails>> ListCompletedApplicationsAsync(DateTime submittedAfterInUtc, DateTime submittedBeforeInUtc);

        /// <summary>
        /// Lists attempts made to complete the specified application.
        /// </summary>
        /// <param name="application">
        /// The application for which attempts need to be obtained.
        /// </param>
        /// <returns>
        /// A task object that can be awaited. The result is a list of Application Attempt Details.
        /// </returns>
        Task<IEnumerable<ApplicationAttemptDetails>> ListApplicationAttemptsAsync(ApplicationDetails application);

        /// <summary>
        /// Lists containers associated with the specified application run on the specified cluster.
        /// </summary>
        /// <param name="applicationAttempt">
        /// The application's attempt for which containers need to be obtained.
        /// </param>
        /// <returns>
        /// A task object that can be awaited. The result is a list of Application Container Details.
        /// </returns>
        Task<IEnumerable<ApplicationContainerDetails>> ListApplicationContainersAsync(ApplicationAttemptDetails applicationAttempt);

        /// <summary>
        /// Get details on the specified application.
        /// </summary>
        /// <param name="applicationId">
        /// The application' unique identifier.
        /// </param>
        /// <returns>
        /// A task object that can be awaited. Returns details about the specified application.
        /// </returns>
        Task<ApplicationDetails> GetApplicationDetailsAsync(string applicationId);

        /// <summary>
        /// Downloads application logs for the specified application. Logs will be downloaded to the specified download location.
        /// </summary>
        /// <param name="application">
        /// The application for which logs are needed.
        /// </param>
        /// <param name="targetDirectory">
        /// The location on local disk to download the application logs.
        /// </param>
        /// <returns>
        /// A task object that can be awaited to download application logs.
        /// </returns>
        Task DownloadApplicationLogsAsync(ApplicationDetails application, string targetDirectory);

        /// <summary>
        /// Downloads logs for a specific container within a YARN application. Logs will be downloaded to the specified download location.
        /// </summary>
        /// <param name="applicationContainer">
        /// An application' container for which logs are needed.
        /// </param>
        /// <param name="targetDirectory">
        /// The location on local disk to download the application logs.
        /// </param>
        /// <returns>
        /// A task object that can be awaited to download container logs.
        /// </returns>
        Task DownloadApplicationLogsAsync(ApplicationContainerDetails applicationContainer, string targetDirectory);
    }
}