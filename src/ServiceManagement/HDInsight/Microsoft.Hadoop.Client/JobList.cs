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
    using System.Collections.Generic;

    /// <summary>
    /// Represents a list of jobs on an HDInsight cluster.
    /// </summary>
    public sealed class JobList : JobCreateHttpResponse
    {
        /// <summary>
        /// Initializes a new instance of the JobList class.
        /// </summary>
        public JobList()
        {
            this.Jobs = new List<JobDetails>();
        }

        /// <summary>
        /// Gets or sets the continuation token returned by the request (if any).
        /// </summary>
        public string ContinuationToken { get; set; }

        /// <summary>
        /// Gets the jobIds returned by the request.
        /// </summary>
        public ICollection<JobDetails> Jobs { get; private set; }
    }
}
