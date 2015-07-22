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

    /// <summary>
    /// strongly typed request object for Hive Jobs.
    /// </summary>
    public class HiveJobRequest : JobRequest
    {
        public string Query { get; set; }


        public HiveJobRequest()
        {
            this.Query = string.Empty;
        }

        public HiveJobRequest(ClientJobRequest request)
            : base(request)
        {
            this.Query = request.Query;
        }

        public static bool TryParse(ClientJobRequest request, out JobRequest output)
        {
            try
            {
                output = new HiveJobRequest(request);
                return true;
            }
            catch (Exception)
            {
                output = null;
                return false;
            }
        }
    }
}