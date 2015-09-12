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
    using System;

    public class JobDetails
    {
        /// <summary>
        /// Status Code that represents the jobs state in templelton.
        /// </summary>
        public JobStatusCode StatusCode { get; set; }

        /// <summary>
        /// The "friendly" name for this jobDetails.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The time when the jobDetails was submitted, in UTC ticks.
        /// </summary>
        public string SubmissionTime;

        /// <summary>
        /// The physical http path to the results file for this jobDetails. 
        /// </summary>
        public Uri PhysicalOutputPath { get; set; }

        /// <summary>
        /// The logical (ASV) path to the output file. 
        /// </summary>
        public string LogicalOutputPath { get; set; }

        /// <summary>
        /// The physical (http) path to the error output.
        /// </summary>
        public string ErrorOutputPath { get; set; }

        /// <summary>
        /// The exit code of the jobDetails. 
        /// </summary>
        public int? ExitCode { get; set; }

        /// <summary>
        /// The Hive query that was used for the jobDetails (if applicable).
        /// </summary>
        public string Query { get; set; }
    }

}