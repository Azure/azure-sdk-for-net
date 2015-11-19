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
using Hyak.Common;

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// The List data factory linkedServices operation response.
    /// </summary>
    public class LinkedServiceListResponse : AzureOperationResponse
    {
        /// <summary>
        /// Optional. All the data factory linkedService instances.
        /// </summary>
        public IList<LinkedService> LinkedServices { get; set; }

        /// <summary>
        /// Required. The link (url) to the next page of results.
        /// </summary>
        public string NextLink { get; set; }

        /// <summary>
        /// Initializes a new instance of the LinkedServiceListResponse class.
        /// </summary>
        public LinkedServiceListResponse()
        {
            this.LinkedServices = new LazyList<LinkedService>();
        }

        /// <summary>
        /// Initializes a new instance of the LinkedServiceListResponse class
        /// with required arguments.
        /// </summary>
        public LinkedServiceListResponse(string nextLink)
            : this()
        {
            Ensure.IsNotNull(nextLink, "nextLink");
            this.NextLink = nextLink;
        }

        internal LinkedServiceListResponse(
            Core.Models.LinkedServiceListResponse internalResponse,
            DataFactoryManagementClient client)
        {
            Ensure.IsNotNull(internalResponse, "internalResponse");
            Ensure.IsNotNull(internalResponse.LinkedServices, "internalResponse.LinkedServices");

            DataFactoryOperationUtilities.CopyRuntimeProperties(internalResponse, this);
            this.NextLink = internalResponse.NextLink;
            this.LinkedServices = internalResponse.LinkedServices.Select(
                    internalLinkedService =>
                    ((LinkedServiceOperations)client.LinkedServices).Converter.ToWrapperType(internalLinkedService))
                    .ToList();
        }
    }
}