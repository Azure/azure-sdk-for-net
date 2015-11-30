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
    using System.Linq;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Strongly typed base class for all jobDetails requests.
    /// </summary>
    public abstract class JobRequest
    {
        public string Name { get; set; }
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly",
            Justification = "Brought in from services team for testing.  NOT OUR CODE. [tgs]")]
        public IDictionary<string,string> Parameters { get; set; }
        public IEnumerable<string> Resources { get; set; }
        public string OutputStorageAccount { get; set; }

        protected JobRequest()
        {
            this.Parameters = new Dictionary<string, string>();
            this.Resources = new List<string>();
        }

        protected JobRequest(ClientJobRequest request)
        {
            this.Resources = request.Resources.Select(p => p.Value.ToString()).ToList();
            this.Parameters = request.Parameters.ToDictionary(i => i.Key, e => e.Value.ToString());
            this.Name = request.JobName;
            this.Parameters.Add(new KeyValuePair<string, string>(JobSubmissionConstants.JobNameDefine,request.JobName));
            this.OutputStorageAccount = request.OutputStorageLocation;
        }
    }
}