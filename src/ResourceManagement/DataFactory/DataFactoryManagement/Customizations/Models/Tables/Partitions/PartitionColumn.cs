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
    /// The partition column information.
    /// </summary>
    public class PartitionColumn
    {
        /// <summary>
        /// Name of the partition column.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Macro value of the partition column.
        /// </summary>
        public string ValueMacro { get; set; }

        /// <summary>
        /// Type of the partition column. 
        /// Should be one of the constant values of 
        /// <see cref="Microsoft.Azure.Management.DataFactories.Common.Models.PropertyDataType"/>.
        /// </summary>
        public string Type { get; set; }
    }
}
