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
    /// The CreateOrUpdate Dataset operation response.
    /// </summary>
    public class DatasetCreateOrUpdateResponse : AzureOperationResponse
    {
        /// <summary>
        /// The location url for the get request.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Status of the operation.
        /// </summary>
        public OperationStatus Status { get; set; }

        /// <summary>
        /// The Dataset instance.
        /// </summary>
        public Dataset Dataset { get; set; }

        public DatasetCreateOrUpdateResponse()
        {
        }

        internal DatasetCreateOrUpdateResponse(
            Core.Models.DatasetCreateOrUpdateResponse internalResponse,
            DataFactoryManagementClient client)
            : this()
        {
            Ensure.IsNotNull(internalResponse, "internalResponse");
            Ensure.IsNotNull(internalResponse.Dataset, "internalResponse.Dataset");

            DataFactoryOperationUtilities.CopyRuntimeProperties(internalResponse, this);
            this.Dataset = ((DatasetOperations)client.Datasets).Converter.ToWrapperType(internalResponse.Dataset);
            this.Location = internalResponse.Location;
            this.Status = internalResponse.Status;
        }
    }
}
