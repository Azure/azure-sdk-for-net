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
using System.Linq;

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// The List pipeline operation response.
    /// </summary>
    public class PipelineListResponse : AzureOperationResponse
    {
        /// <summary>
        /// A list of the returned pipeline instances.
        /// </summary>
        public IList<Pipeline> Pipelines { get; set; }

        /// <summary>
        /// The link (url) to the next page of results.
        /// </summary>
        public string NextLink { get; set; }

        public PipelineListResponse()
        {
        }

        internal PipelineListResponse(
            Core.Models.PipelineListResponse internalResponse,
            DataFactoryManagementClient client)
            : this()
        {
            Ensure.IsNotNull(internalResponse, "internalResponse");
            Ensure.IsNotNull(internalResponse.Pipelines, "internalResponse.Pipelines");

            DataFactoryOperationUtilities.CopyRuntimeProperties(internalResponse, this);
            this.NextLink = internalResponse.NextLink;
            this.Pipelines = internalResponse.Pipelines.Select(
                    internalPipeline => ((PipelineOperations)client.Pipelines).Converter.ToWrapperType(internalPipeline))
                    .ToList();
        }
    }
}
