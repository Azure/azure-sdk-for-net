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

namespace Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.Common.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.JobSubmission.Models;

    /// <summary>
    /// Class that represents a response to a passthrough request.
    /// </summary>
    [KnownType(typeof(List<string>))]
    [KnownType(typeof(JobDetails))]
    public class PassthroughResponse
    {
        public PassthroughErrorResponse Error { get; set; }
        public object Data { get; set; }
    }
}