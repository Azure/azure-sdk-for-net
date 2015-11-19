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
    using System.Collections.Generic;

    /// <summary>
    /// Class that represents a jobDetails request from the end user (AUX/RDFE in this case).
    /// </summary>
    public class ClientJobRequest
    {
        public string JobName { get; set; }
        public JobType JobType { get; set; }
        public IEnumerable<JobRequestParameter> Parameters { get; set; }
        public IEnumerable<JobRequestParameter> Resources { get; set; }
        public IEnumerable<string> Arguments { get; set; }
        public string JarFile { get; set; }
        public string ApplicationName { get; set; }
        public string OutputStorageLocation { get; set; }
        public string Query { get; set; } 

        public ClientJobRequest()
        {
            this.Parameters = new List<JobRequestParameter>();
            this.Resources = new List<JobRequestParameter>();
            this.Arguments = new List<string>();
        }
    }

    /// <summary>
    /// Class that is used to represent a request parameter (JSON cannot serialize generic dictionaries).
    /// </summary>
    public class JobRequestParameter
    {
        public string Key { get; set; }
        public object Value { get; set; }
    }

    /// <summary>
    /// The type of jobDetails being requested. Used in validation and parsing.
    /// </summary>
    public enum JobType
    {
        Hive = 0,
        MapReduce = 1
    }
}