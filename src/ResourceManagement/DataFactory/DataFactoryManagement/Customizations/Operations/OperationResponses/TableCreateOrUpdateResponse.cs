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
    /// The CreateOrUpdate table operation response.
    /// </summary>
    public class TableCreateOrUpdateResponse : AzureOperationResponse
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
        /// The table instance.
        /// </summary>
        public Table Table { get; set; }

        public TableCreateOrUpdateResponse()
        {
        }

        internal TableCreateOrUpdateResponse(
            Core.Models.TableCreateOrUpdateResponse internalResponse,
            DataFactoryManagementClient client)
            : this()
        {
            Ensure.IsNotNull(internalResponse, "internalResponse");
            Ensure.IsNotNull(internalResponse.Table, "internalResponse.Table");

            DataFactoryOperationUtilities.CopyRuntimeProperties(internalResponse, this);
            this.Table = ((TableOperations)client.Tables).Converter.ToWrapperType(internalResponse.Table);
            this.Location = internalResponse.Location;
            this.Status = internalResponse.Status;
        }
    }
}
