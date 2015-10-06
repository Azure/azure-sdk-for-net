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
    /// AzureML Batch Execution Service activity.
    /// </summary>
    [AdfTypeName("AzureMLBatchExecution")]
    public class AzureMLBatchExecutionActivity : ActivityTypeProperties
    {
        /// <summary>
        /// Optional. Key,Value pairs to be passed to the AzureML Batch Execution Service Endpoint 
        /// Keys must match the names of web service parameters defined in the published AzureML web service. 
        /// Values may include ADF functions to be resolved at each slice execution time 
        /// (See https://msdn.microsoft.com/en-us/library/azure/dn835056.aspx). 
        /// Values will be passed in the GlobalParameters property of the AzureML batch execution request.
        /// </summary>
        public IDictionary<string, string> GlobalParameters { get; set; }

        /// <summary>
        /// Optional. Key,Value pairs mapping the AzureML endpoint's Web Service Output names to names of ADF Blob
        /// Datasets where the batch execution output should be written. This information will be passed in the 
        /// WebServiceOutputs property of the AzureML batch execution request.
        /// Mapped Datasets must be included in the Activity's Outputs.
        /// </summary>
        public IDictionary<string, string> WebServiceOutputs { get; set; }

        /// <summary>
        /// Optional. Name of ADF Blob Dataset giving the input to the batch execution. This information will be passed
        /// in the WebServiceInput property of the AzureML batch execution request.
        /// </summary>
        public string WebServiceInput { get; set; }

        public AzureMLBatchExecutionActivity()
        {
        }
    }
}