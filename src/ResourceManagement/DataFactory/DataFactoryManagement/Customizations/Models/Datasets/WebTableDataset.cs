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
    /// A web table.
    /// </summary>
    [AdfTypeName("WebTable")]
    public class WebTableDataset : DatasetTypeProperties
    {
        /// <summary>
        /// The zero-based index of the table in the web page.
        /// </summary>
        [AdfRequired]
        public uint Index { get; set; }

        /// <summary>
        /// The relative URL to the web page from the linked service URL.
        /// </summary>
        public string Path { get; set; }
        
        /// <summary>
        /// The partitions to be used by the path.
        /// </summary>
        public IList<Partition> PartitionedBy { get; set; }
    }
}
