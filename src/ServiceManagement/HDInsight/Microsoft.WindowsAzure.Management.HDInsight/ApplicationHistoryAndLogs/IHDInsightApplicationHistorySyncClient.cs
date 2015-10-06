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
    using Microsoft.Hadoop.Client;

    /// <summary>
    /// Represents the HDInsight Application History sync client.
    /// </summary>
    public interface IHDInsightApplicationHistorySyncClient
    {
        /// <summary>
        /// Lists completed applications.
        /// </summary>
        /// <returns>
        /// Returns a list of Application Details.
        /// </returns>
        IEnumerable<ApplicationDetails> ListCompletedApplications();

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
        /// Returns an enumeration of ApplicationDetails.
        /// </returns>
        IEnumerable<ApplicationDetails> ListCompletedApplications(DateTime submittedAfterInUtc, DateTime submittedBeforeInUtc);

        /// <summary>
        /// Lists attempts made to complete the specified application.
        /// </summary>
        /// <param name="application">
        /// The application for which attempts need to be obtained.
        /// </param>
        /// <returns>
        /// Returns an enumeration of ApplicationAttemptDetails.
        /// </returns>
        IEnumerable<ApplicationAttemptDetails> ListApplicationAttempts(ApplicationDetails application);

        /// <summary>
        /// Lists containers associated with the specified application run on the specified cluster.
        /// </summary>
        /// <param name="applicationAttempt">
        /// The application's attempt for which containers need to be obtained.
        /// </param>
        /// <returns>
        /// Returns a list of ApplicationContainerDetails.
        /// </returns>
        IEnumerable<ApplicationContainerDetails> ListApplicationContainers(ApplicationAttemptDetails applicationAttempt);

        /// <summary>
        /// Get details on the specified application.
        /// </summary>
        /// <param name="applicationId">
        /// The application' unique identifier.
        /// </param>
        /// <returns>
        /// Returns details about the specified application.
        /// </returns>
        ApplicationDetails GetApplicationDetails(string applicationId);

        /// <summary>
        /// Downloads application logs for the specified application. Logs will be downloaded to the specified download location.
        /// </summary>
        /// <param name="application">
        /// The application for which logs are needed.
        /// </param>
        /// <param name="targetDirectory">
        /// The location on local disk to download the application logs.
        /// </param>
        void DownloadApplicationLogs(ApplicationDetails application, string targetDirectory);

        /// <summary>
        /// Downloads application logs for the specified application. Logs will be downloaded to the specified download location.
        /// </summary>
        /// <param name="application">
        /// The application for which logs are needed.
        /// </param>
        /// <param name="targetDirectory">
        /// The location on local disk to download the application logs.
        /// </param>
        /// <param name="timeout">
        /// Time to wait for completion of the operation.
        /// </param>
        void DownloadApplicationLogs(ApplicationDetails application, string targetDirectory, TimeSpan timeout);

        /// <summary>
        /// Downloads logs for a specific container within a YARN application. Logs will be downloaded to the specified download location.
        /// </summary>
        /// <param name="applicationContainer">
        /// An application' container for which logs are needed.
        /// </param>
        /// <param name="targetDirectory">
        /// The location on local disk to download the application logs.
        /// </param>
        void DownloadApplicationLogs(ApplicationContainerDetails applicationContainer, string targetDirectory);

        /// <summary>
        /// Downloads logs for a specific container within a YARN application. Logs will be downloaded to the specified download location.
        /// </summary>
        /// <param name="applicationContainer">
        /// An application' container for which logs are needed.
        /// </param>
        /// <param name="targetDirectory">
        /// The location on local disk to download the application logs.
        /// </param>
        /// <param name="timeout">
        /// Time to wait for completion of the operation.
        /// </param>
        void DownloadApplicationLogs(ApplicationContainerDetails applicationContainer, string targetDirectory, TimeSpan timeout);
    }
}