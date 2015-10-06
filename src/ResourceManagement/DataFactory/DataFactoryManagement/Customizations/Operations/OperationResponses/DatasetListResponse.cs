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
    /// The List Datasets operation response.
    /// </summary>
    public class DatasetListResponse : AzureOperationResponse
    {
        /// <summary>
        /// Required. The link (url) to the next page of results.
        /// </summary>
        public string NextLink { get; set; }

        /// <summary>
        /// A list of the returned Dataset instances.
        /// </summary>
        public IList<Dataset> Datasets { get; set; }

        /// <summary>
        /// Initializes a new instance of the DatasetListResponse class.
        /// </summary>
        public DatasetListResponse()
        {
            this.Datasets = new List<Dataset>();
        }

        /// <summary>
        /// Initializes a new instance of the DatasetListResponse class
        /// with required arguments.
        /// </summary>
        public DatasetListResponse(string nextLink)
            : this()
        {
            Ensure.IsNotNull(nextLink, "nextLink");
            this.NextLink = nextLink;
        }

        internal DatasetListResponse(Core.Models.DatasetListResponse internalResponse, DataFactoryManagementClient client)
        {
            Ensure.IsNotNull(internalResponse, "internalResponse");
            Ensure.IsNotNull(internalResponse.Datasets, "internalResponse.Datasets");

            DataFactoryOperationUtilities.CopyRuntimeProperties(internalResponse, this);
            this.NextLink = internalResponse.NextLink;
            this.Datasets = internalResponse.Datasets.Select(
                    internalDataset => ((DatasetOperations)client.Datasets).Converter.ToWrapperType(internalDataset)).ToList();
        }
    }
}
