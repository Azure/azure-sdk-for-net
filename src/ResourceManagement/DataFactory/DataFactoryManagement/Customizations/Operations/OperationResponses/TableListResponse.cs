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

using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// The List tables operation response.
    /// </summary>
    public class TableListResponse : AzureOperationResponse
    {
        /// <summary>
        /// Required. The link (url) to the next page of results.
        /// </summary>
        public string NextLink { get; set; }

        /// <summary>
        /// A list of the returned table instances.
        /// </summary>
        public IList<Table> Tables { get; set; }

        /// <summary>
        /// Initializes a new instance of the TableListResponse class.
        /// </summary>
        public TableListResponse()
        {
            this.Tables = new List<Table>();
        }

        /// <summary>
        /// Initializes a new instance of the TableListResponse class
        /// with required arguments.
        /// </summary>
        public TableListResponse(string nextLink)
            : this()
        {
            Ensure.IsNotNull(nextLink, "nextLink");
            this.NextLink = nextLink;
        }

        internal TableListResponse(Core.Models.TableListResponse internalResponse, DataFactoryManagementClient client)
        {
            Ensure.IsNotNull(internalResponse, "internalResponse");
            Ensure.IsNotNull(internalResponse.Tables, "internalResponse.Tables");

            DataFactoryUtilities.CopyRuntimeProperties(internalResponse, this);
            this.NextLink = internalResponse.NextLink;
            this.Tables = internalResponse.Tables.Select(
                    internalTable => ((TableOperations)client.Tables).Converter.ToWrapperType(internalTable)).ToList();
        }
    }
}
