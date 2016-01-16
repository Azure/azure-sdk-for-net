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

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// Azure Data Lake Store dataset.
    /// </summary>
    [AdfTypeName("AzureDataLakeStore")]
    public class AzureDataLakeStoreDataset : DatasetTypeProperties
    {
        /// <summary>
        /// Required. Path to the folder in the Azure Data Lake Store.
        /// </summary>
        [AdfRequired]
        public string FolderPath { get; set; }

        /// <summary>
        /// Optional. The name of the file in the Azure Data Lake Store.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Optional. Specify a dynamic path and filename for time series data.
        /// </summary>
        public IList<Partition> PartitionedBy { get; set; }

        /// <summary>
        /// Optional. The format of the Data Lake Store.
        /// </summary>
        public StorageFormat Format { get; set; }

        /// <summary>
        /// Optional. The data compression method used for the item(s) in the Azure Data Lake Store.
        /// </summary>
        public Compression Compression { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureDataLakeStoreDataset"/> class.
        /// </summary>
        public AzureDataLakeStoreDataset()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureDataLakeStoreDataset"/>
        /// class with required arguments.
        /// </summary>
        public AzureDataLakeStoreDataset(string folderPath)
            : this()
        {
            Ensure.IsNotNullOrEmpty(folderPath, "folderPath");
            this.FolderPath = folderPath;
        }
    }
}
