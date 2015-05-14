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
    /// The Get table operation response.
    /// </summary>
    public class TableGetResponse : AzureOperationResponse
    {
        /// <summary>
        /// The table instance.
        /// </summary>
        public Table Table { get; set; }

        internal TableGetResponse(Core.Models.TableGetResponse internalResponse, DataFactoryManagementClient client)
        {
            Ensure.IsNotNull(internalResponse, "internalResponse");
            Ensure.IsNotNull(internalResponse.Table, "internalResponse.Table");

            DataFactoryUtilities.CopyRuntimeProperties(internalResponse, this);
            this.Table = client.Tables.Converter.ToWrapperType(internalResponse.Table);
        }
    }
}
