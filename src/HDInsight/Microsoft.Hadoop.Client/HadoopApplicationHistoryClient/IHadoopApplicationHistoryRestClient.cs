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
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;

    /// <summary>
    /// Provides REST implementation of a remote Hadoop Application History client.
    /// </summary>
    internal interface IHadoopApplicationHistoryRestClient
    {
        /// <summary>
        /// Lists completed applications.
        /// </summary>
        /// <returns>
        /// A task that will provide an enumeration of completed applications.
        /// </returns>
        Task<IEnumerable<ApplicationDetails>> ListCompletedApplicationsAsync();

        /// <summary>
        /// Lists completed applications.
        /// </summary>
        /// <param name="submittedAfterInUtc">
        /// Time in UTC after which a qualified application must have been submitted.
        /// </param>
        /// <param name="submittedBeforeInUtc">
        /// Time in UTC before which a qualified application must have been submitted.
        /// </param>
        /// <returns>
        /// A task that will provide an enumeration of completed applications.
        /// </returns>
        Task<IEnumerable<ApplicationDetails>> ListCompletedApplicationsAsync(DateTime submittedAfterInUtc, DateTime submittedBeforeInUtc);

        /// <summary>
        /// Gets details on the specified application.
        /// </summary>
        /// <param name="applicationId">
        /// The application' identifier.
        /// </param>
        /// <returns>
        /// A task which when completed, will provide details on the specified application.
        /// </returns>
        Task<ApplicationDetails> GetApplicationDetailsAsync(string applicationId);

        /// <summary>
        /// Lists attempts made for the specified application.
        /// </summary>
        /// <param name="application">
        /// The application for which attempts need to be listed.
        /// </param>
        /// <returns>
        /// A task that will provide an enumeration of attempts made to run the specified application.
        /// </returns>
        Task<IEnumerable<ApplicationAttemptDetails>> ListApplicationAttemptsAsync(ApplicationDetails application);

        /// <summary>
        /// Lists containers for the specified application attempt.
        /// </summary>
        /// <param name="applicationAttempt">
        /// The application attempt for which containers need to be listed.
        /// </param>
        /// <returns>
        /// A task that will provide an enumeration of containers associated with the specified application attempt.
        /// </returns>
        Task<IEnumerable<ApplicationContainerDetails>> ListApplicationContainersAsync(ApplicationAttemptDetails applicationAttempt);
    }
}
