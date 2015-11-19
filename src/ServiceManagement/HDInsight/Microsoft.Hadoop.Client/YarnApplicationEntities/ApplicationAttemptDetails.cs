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
    /// Represents generic information about YARN Application Attempts.
    /// </summary>
    public class ApplicationAttemptDetails
    {
        /// <summary>
        /// Initializes a new instance of the ApplicationAttemptDetails class.
        /// </summary>
        /// <param name="attemptResult">
        /// Result of a REST call, containing details about an application's attempt.
        /// </param>
        /// <param name="application">
        /// The application with which this attempt is associated.
        /// </param>
        internal ApplicationAttemptDetails(ApplicationAttemptGetResult attemptResult, ApplicationDetails application)
        {
            if (attemptResult == null)
            {
                throw new ArgumentNullException("attemptResult");
            }

            if (application == null)
            {
                throw new ArgumentNullException("application");
            }

            this.ApplicationAttemptId = attemptResult.ApplicationAttemptId;
            this.Host = attemptResult.Host;
            this.State = attemptResult.State;
            this.ApplicationMasterContainerId = attemptResult.ApplicationMasterContainerId;
            this.DiagnosticInfo = attemptResult.DiagnosticInfo;

            this.ParentApplication = application;
        }

        /// <summary>
        /// Gets the application attempt Id.
        /// </summary>
        public string ApplicationAttemptId { get; private set; }

        /// <summary>
        /// Gets the host on which this attempt was initiated.
        /// </summary>
        public string Host { get; private set; }

        /// <summary>
        /// Gets the state of the attempt.
        /// </summary>
        public string State { get; private set; }

        /// <summary>
        /// Gets the container id of the application master initiating the attempt.
        /// </summary>
        public string ApplicationMasterContainerId { get; private set; }

        /// <summary>
        /// Gets diagnostic information on this attempt.
        /// </summary>
        public string DiagnosticInfo { get; private set; }

        /// <summary>
        /// Gets the parent application for this attempt.
        /// </summary>
        public ApplicationDetails ParentApplication { get; private set; }

        /// <summary>
        /// Gets the application' state as an enum.
        /// </summary>
        /// <returns>
        /// Returns the application attempt' state as an enum.
        /// </returns>
        public ApplicationAttemptState GetApplicationAttemptStateAsEnum()
        {
            ApplicationAttemptState state;
            if (!Enum.TryParse(this.State, true, out state))
            {
                state = ApplicationAttemptState.Unknown;
            }

            return state;
        }
    }
}