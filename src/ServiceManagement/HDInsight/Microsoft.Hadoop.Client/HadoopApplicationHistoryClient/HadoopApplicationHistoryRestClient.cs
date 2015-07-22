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
    using System.Net;
    using System.Net.Http;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.Retries;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.CustomMessageHandlers;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;

    /// <summary>
    /// Represents a remote rest request to get application history.
    /// </summary>
    internal class HadoopApplicationHistoryRestClient : IHadoopApplicationHistoryRestClient
    {
        private readonly IHadoopApplicationHistoryRestReadClient readProxy;

        /// <summary>
        /// Initializes a new instance of the HadoopApplicationHistoryRestClient class.
        /// </summary>
        /// <param name="readProxy">
        /// The REST read client to use for performing requests.
        /// </param>
        public HadoopApplicationHistoryRestClient(IHadoopApplicationHistoryRestReadClient readProxy)
        {
            Contract.AssertArgNotNull(readProxy, "readProxy");

            this.readProxy = readProxy;
        }

        public async Task<IEnumerable<ApplicationDetails>> ListCompletedApplicationsAsync()
        {
            return await ListCompletedApplicationsAsync(DateTime.MinValue, DateTime.Now);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ApplicationDetails>> ListCompletedApplicationsAsync(DateTime submittedAfterInUtc, DateTime submittedBeforeInUtc)
        {
            long submittedTimeBegin = ConvertDateTimeToUnixEpoch(submittedAfterInUtc);
            long submittedTimeEnd = ConvertDateTimeToUnixEpoch(submittedBeforeInUtc);
            ApplicationListResult result = await this.readProxy.ListCompletedApplicationsAsync(submittedTimeBegin.ToString(), submittedTimeEnd.ToString());

            ApplicationList applications = new ApplicationList(result);

            return applications.Applications;
        }

        /// <inheritdoc />
        public async Task<ApplicationDetails> GetApplicationDetailsAsync(string applicationId)
        {
            ApplicationGetResult applicationResult = await this.readProxy.GetApplicationDetailsAsync(applicationId);

            ApplicationDetails application = new ApplicationDetails(applicationResult);

            return application;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ApplicationAttemptDetails>> ListApplicationAttemptsAsync(ApplicationDetails application)
        {
            ApplicationAttemptListResult attemptListResult = await this.readProxy.ListApplicationAttemptsAsync(application.ApplicationId);

            ApplicationAttemptList attempts = new ApplicationAttemptList(attemptListResult, application);

            return attempts.ApplicationAttempts;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ApplicationContainerDetails>> ListApplicationContainersAsync(ApplicationAttemptDetails applicationAttempt)
        {
            ApplicationContainerListResult containerListResult = await this.readProxy.ListApplicationContainersAsync(applicationAttempt.ParentApplication.ApplicationId, applicationAttempt.ApplicationAttemptId);

            ApplicationContainerList containers = new ApplicationContainerList(containerListResult, applicationAttempt);

            return containers.Containers;
        }

        private static long ConvertDateTimeToUnixEpoch(DateTime dateTime)
        {
            long epoch = Convert.ToInt64((dateTime - Constants.UnixEpoch).TotalMilliseconds);
            
            if (epoch < 0)
            {
                epoch = 0;
            }

            return epoch;
        }
    }
}
