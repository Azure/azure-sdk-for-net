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

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// The create or update pipeline operation response.
    /// </summary>
    public class PipelineCreateOrUpdateResponse : AzureOperationResponse
    {
        /// <summary>
        /// The pipeline instance.
        /// </summary>
        public Pipeline Pipeline { get; set; }

        /// <summary>
        /// The location url for the get request.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Status of the operation.
        /// </summary>
        public OperationStatus Status { get; set; }

        public PipelineCreateOrUpdateResponse()
        {
        }

        internal PipelineCreateOrUpdateResponse(
            Core.Models.PipelineCreateOrUpdateResponse internalResponse,
            DataFactoryManagementClient client)
            : this() 
        {
            Ensure.IsNotNull(internalResponse, "internalResponse");
            Ensure.IsNotNull(internalResponse.Pipeline, "internalResponse.Pipeline");

            DataFactoryOperationUtilities.CopyRuntimeProperties(internalResponse, this);
            this.Pipeline = ((PipelineOperations)client.Pipelines).Converter.ToWrapperType(internalResponse.Pipeline);
            this.Location = internalResponse.Location;
            this.Status = internalResponse.Status;
        }
    }
}
