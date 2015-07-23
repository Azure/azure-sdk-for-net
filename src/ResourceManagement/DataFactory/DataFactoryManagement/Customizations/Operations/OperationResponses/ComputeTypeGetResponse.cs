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

using CoreRegistrationModel = Microsoft.Azure.Management.DataFactories.Core.Registration.Models;

namespace Microsoft.Azure.Management.DataFactories.Registration.Models
{
    /// <summary>
    /// The Get ComputeType operation response.
    /// </summary>
    public class ComputeTypeGetResponse : AzureOperationResponse
    {
        /// <summary>
        /// Optional. The ComputeType instance.
        /// </summary>
        public ComputeType ComputeType { get; set; }

        public ComputeTypeGetResponse()
        {
        }

        internal ComputeTypeGetResponse(
            CoreRegistrationModel.ComputeTypeGetResponse internalResponse,
            DataFactoryManagementClient client)
            : this()
        {
            DataFactoryOperationUtilities.CopyRuntimeProperties(internalResponse, this);
            this.ComputeType = ((ComputeTypeOperations)client.ComputeTypes).Converter.ToWrapperType(internalResponse.ComputeType);
        }
    }
}
