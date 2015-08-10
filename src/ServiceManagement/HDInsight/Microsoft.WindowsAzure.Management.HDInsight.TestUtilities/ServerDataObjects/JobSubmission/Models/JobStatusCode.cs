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
namespace Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.JobSubmission.Models
{
    /// <summary>
    /// Enum for the possible jobDetails states. These values are tied/sourced from Tempelton. 
    /// DO NOT UPDATE/CHANGE unless the values returned from Tempelton have changed. 
    /// </summary>
    public enum JobStatusCode
    {
        /// <summary>
        /// Indicates the jobDetails is running.
        /// </summary>
        Initializing = 0,

        /// <summary>
        /// Indicates the jobDetails is running.
        /// </summary>
        Running = 1,

        /// <summary>
        /// Indicates the jobDetails has completed.
        /// </summary>
        Completed = 2,

        /// <summary>
        /// Indicates that the jobDetails has failed.
        /// </summary>
        Failed = 3,

        /// <summary>
        /// Indicates that the jobDetails is in an unknown state.
        /// </summary>
        Unknown = 4,

        /// <summary>
        /// Indicates that the jobDetails is canceled.
        /// </summary>
        Canceled = 5
    }
}