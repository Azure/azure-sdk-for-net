//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.Collections.Generic;

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// AzureML Web Service batch scoring activity.
    /// </summary>
    [AdfTypeName("AzureMLBatchScoring")]
    public class AzureMLBatchScoringActivity : ActivityTypeProperties
    {
        /// <summary>
        /// Key,Value pairs to be passed to the AzureML Batch Execution Service Endpoint 
        /// (these are also referred to as GlobalParameters). Keys must match the names of web service
        /// parameters defined in published the AzureML web service. Values may include ADF macros to be
        /// resolved at each slice execution time.
        /// </summary>
        public IDictionary<string, string> WebServiceParameters { get; set; }

        public AzureMLBatchScoringActivity()
        {
            this.WebServiceParameters = new Dictionary<string, string>();
        }

        public AzureMLBatchScoringActivity(IDictionary<string, string> webServiceParameters)
            : this()
        {
            this.WebServiceParameters = webServiceParameters;
        }
    }
}