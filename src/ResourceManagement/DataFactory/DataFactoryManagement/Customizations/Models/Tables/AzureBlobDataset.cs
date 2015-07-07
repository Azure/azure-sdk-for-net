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
    /// The Azure blob storage.
    /// </summary>
    [AdfTypeName("AzureBlob")]
    public class AzureBlobDataset : TableTypeProperties
    {
        /// <summary>
        /// The path of the Azure blob storage.
        /// </summary>
        public string FolderPath { get; set; }

        /// <summary>
        /// The root of blob path.
        /// </summary>
        public string TableRootLocation { get; set; }

        /// <summary>
        /// The name of the Azure blob.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The partitions to be used by the path.
        /// </summary>
        public IList<Partition> PartitionedBy { get; set; }

        /// <summary>
        /// The format of the Azure blob storage.
        /// </summary>
        public StorageFormat Format { get; set; }

        /// <summary>
        /// The data compression method used for the blob storage.
        /// </summary>
        public Compression Compression { get; set; }
    }
}
