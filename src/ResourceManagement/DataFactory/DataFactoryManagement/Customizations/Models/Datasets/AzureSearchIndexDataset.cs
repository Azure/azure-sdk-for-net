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
    /// An Index in an Azure Search service.
    /// </summary>
    [AdfTypeName("AzureSearchIndex")]
    public class AzureSearchIndexDataset : DatasetTypeProperties
    {
        /// <summary>
        /// The name of the Azure Search Index.
        /// </summary>
        [AdfRequired]
        public string IndexName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureSearchIndexDataset" /> class.
        /// </summary>
        public AzureSearchIndexDataset()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureSearchIndexDataset" />
        /// class with required arguments.
        /// </summary>
        public AzureSearchIndexDataset(string indexName)
        {
            Ensure.IsNotNullOrEmpty(indexName, "indexName");
            this.IndexName = indexName;
        }
    }
}

