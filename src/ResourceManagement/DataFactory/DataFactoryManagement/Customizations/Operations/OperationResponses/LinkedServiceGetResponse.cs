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
    /// The Get data factory linkedService operation response.
    /// </summary>
    public class LinkedServiceGetResponse : AzureOperationResponse
    {
        /// <summary>
        /// Optional. The data factory linkedService instance.
        /// </summary>
        public LinkedService LinkedService { get; set; }

        public LinkedServiceGetResponse()
        {
        }

        internal LinkedServiceGetResponse(
            Core.Models.LinkedServiceGetResponse internalResponse,
            DataFactoryManagementClient client)
            : this()
        {
            Ensure.IsNotNull(internalResponse, "internalResponse");
            Ensure.IsNotNull(internalResponse.LinkedService, "internalResponse.LinkedService");

            DataFactoryOperationUtilities.CopyRuntimeProperties(internalResponse, this);
            this.LinkedService =
                ((LinkedServiceOperations)client.LinkedServices).Converter.ToWrapperType(internalResponse.LinkedService);
        }
    }
}