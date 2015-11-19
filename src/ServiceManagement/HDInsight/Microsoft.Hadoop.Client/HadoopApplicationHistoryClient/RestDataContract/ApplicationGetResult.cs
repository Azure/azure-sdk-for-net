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
    using System.Runtime.Serialization;

    /// <summary>
    /// Represents the result of a get application REST call against a Hadoop cluster.
    /// </summary>
    [DataContract]
    internal class ApplicationGetResult
    {
        /// <summary>
        /// Gets or sets the application ID.
        /// </summary>
        [DataMember(Name = "appId")]
        public string ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the application attempt ID.
        /// </summary>
        [DataMember(Name = "currentAppAttemptId")]
        public string ApplicationAttemptId { get; set; }

        /// <summary>
        /// Gets or sets the application name.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the application user.
        /// </summary>
        [DataMember(Name = "user")]
        public string User { get; set; }

        /// <summary>
        /// Gets or sets the application type.
        /// </summary>
        [DataMember(Name = "type")]
        public string ApplicationType { get; set; }

        /// <summary>
        /// Gets or sets the application state.
        /// </summary>
        [DataMember(Name = "appState")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the application status.
        /// </summary>
        [DataMember(Name = "finalAppStatus")]
        public string FinalStatus { get; set; }

        /// <summary>
        /// Gets or sets the application submission time in milliseconds since unix epoch.
        /// </summary>
        [DataMember(Name = "submittedTime")]
        public long SubmissionTimeInMillisecondsSinceUnixEpoch { get; set; }

        /// <summary>
        /// Gets or sets the application start time in milliseconds since unix epoch.
        /// </summary>
        [DataMember(Name = "startedTime")]
        public long StartTimeInMillisecondsSinceUnixEpoch { get; set; }

        /// <summary>
        /// Gets or sets the application finish time in milliseconds since unix epoch.
        /// </summary>
        [DataMember(Name = "finishedTime")]
        public long FinishTimeInMillisecondsSinceUnixEpoch { get; set; }
    }
}