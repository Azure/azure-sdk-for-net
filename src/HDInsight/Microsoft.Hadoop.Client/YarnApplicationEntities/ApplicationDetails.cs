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

    /// <summary>
    /// Represents generic information about YARN Applications.
    /// </summary>
    public class ApplicationDetails
    {
        /// <summary>
        /// Initializes a new instance of the ApplicationDetails class.
        /// </summary>
        /// <param name="applicationResult">
        /// Result of a REST call, containing details about an application.
        /// </param>
        internal ApplicationDetails(ApplicationGetResult applicationResult)
        {
            if (applicationResult == null)
            {
                throw new ArgumentNullException("applicationResult");
            }

            this.ApplicationId = applicationResult.ApplicationId;
            this.LatestApplicationAttemptId = applicationResult.ApplicationAttemptId;
            this.Name = applicationResult.Name;
            this.User = applicationResult.User;
            this.ApplicationType = applicationResult.ApplicationType;
            this.State = applicationResult.State;
            this.FinalStatus = applicationResult.FinalStatus;
            this.SubmissionTimeInUtc = Constants.UnixEpoch.AddMilliseconds(applicationResult.SubmissionTimeInMillisecondsSinceUnixEpoch);
            this.StartTimeInUtc = Constants.UnixEpoch.AddMilliseconds(applicationResult.StartTimeInMillisecondsSinceUnixEpoch);
            this.FinishTimeInUtc = Constants.UnixEpoch.AddMilliseconds(applicationResult.FinishTimeInMillisecondsSinceUnixEpoch);
        }

        /// <summary>
        /// Gets the application Id.
        /// </summary>
        public string ApplicationId { get; private set; }

        /// <summary>
        /// Gets the latest application attempt Id.
        /// </summary>
        public string LatestApplicationAttemptId { get; private set; }

        /// <summary>
        /// Gets the application name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the user who started the application.
        /// </summary>
        public string User { get; private set; }

        /// <summary>
        /// Gets the type of this application (example: MAPREDUCE).
        /// </summary>
        public string ApplicationType { get; private set; }

        /// <summary>
        /// Gets the application state.
        /// </summary>
        public string State { get; private set; }

        /// <summary>
        /// Gets the final application status.
        /// </summary>
        public string FinalStatus { get; private set; }

        /// <summary>
        /// Gets the application submission time in UTC.
        /// </summary>
        public DateTime SubmissionTimeInUtc { get; private set; }

        /// <summary>
        /// Gets the application start time in UTC.
        /// </summary>
        public DateTime StartTimeInUtc { get; private set; }

        /// <summary>
        /// Gets the application finish time in UTC.
        /// </summary>
        public DateTime FinishTimeInUtc { get; private set; }

        /// <summary>
        /// Gets the application' state as an enum.
        /// </summary>
        /// <returns>
        /// Returns the application' state as an enum.
        /// </returns>
        public ApplicationState GetApplicationStateAsEnum()
        {
            ApplicationState state;
            if (!Enum.TryParse(this.State, true, out state))
            {
                state = ApplicationState.Unknown;
            }

            return state;
        }

        /// <summary>
        /// Gets the application' final status as an enum.
        /// </summary>
        /// <returns>
        /// Returns the application' final status as an enum.
        /// </returns>
        public ApplicationFinalStatus GetApplicationFinalStatusAsEnum()
        {
            ApplicationFinalStatus finalStatus;
            if (!Enum.TryParse(this.FinalStatus, true, out finalStatus))
            {
                finalStatus = ApplicationFinalStatus.Unknown;
            }

            return finalStatus;
        }
    }
}