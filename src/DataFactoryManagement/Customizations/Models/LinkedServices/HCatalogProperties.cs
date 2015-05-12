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
    /// HCatalog properties.
    /// </summary>
    public class HCatalogProperties
    {
        /// <summary>
        /// The name of Azure SQL linked service.
        /// </summary>
        public string LinkedServiceName { get; set; }

        /// <summary>
        /// Flag to indicate to recover partitions.
        /// </summary>
        public bool RecoverPartitions { get; set; }

        /// <summary>
        /// Flag to indicate if alter schema should be performed.
        /// </summary>
        public bool AlterSchema { get; set; }
    }
}
