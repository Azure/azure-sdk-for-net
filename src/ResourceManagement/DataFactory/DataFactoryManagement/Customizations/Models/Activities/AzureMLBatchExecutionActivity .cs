﻿//
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
    /// Azure ML Batch Execution Service activity.
    /// </summary>
    [AdfTypeName("AzureMLBatchExecution")]
    public class AzureMLBatchExecutionActivity : ActivityTypeProperties
    {
        /// <summary>
        /// Optional. Key,Value pairs to be passed to the Azure ML Batch Execution Service Endpoint. 
        /// Keys must match the names of web service parameters defined in the published Azure ML web service. 
        /// Values may include Azure Data Factory functions to be resolved at each slice execution time 
        /// (See http://go.microsoft.com/fwlink/?LinkId=823697). 
        /// Values will be passed in the GlobalParameters property of the Azure ML batch execution request.
        /// </summary>
        public IDictionary<string, string> GlobalParameters { get; set; }

        /// <summary>
        /// Optional. Key, Value pairs mapping the names of Azure ML web service outputs to names of Data Factory datasets.
        /// The batch execution output is written to these datasets.
        /// This information will be passed in the WebServiceOutputs property of the Azure ML batch execution request.
        /// Mapped datasets must be included in the Activity's outputs.
        /// </summary>
        public IDictionary<string, string> WebServiceOutputs { get; set; }

        /// <summary>
        /// Optional. Name of Data Factory dataset giving the input to the batch execution. 
        /// This information will be passed in the WebServiceInput property of the Azure ML batch execution request. 
        /// WebServiceInput cannot be used simultaneously with WebServiceInputs.
        /// </summary>
        public string WebServiceInput { get; set; }

        /// <summary>
        /// Optional. Key, Value pairs mapping the names of Azure ML web service inputs to names of Data Factory datasets.
        /// The batch execution input is stored in these datasets.
        /// This information will be passed in the WebServiceInputs property of the Azure ML batch execution request.
        /// Mapped datasets must be included in the Activity's inputs. 
        /// WebServiceInputs cannot be used simultaneously with WebServiceInput.
        /// </summary>
        public IDictionary<string, string> WebServiceInputs { get; set; }

        public AzureMLBatchExecutionActivity()
        {
        }
    }
}