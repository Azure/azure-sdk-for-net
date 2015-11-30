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

namespace Microsoft.Azure.Management.DataFactories.Registration.Models
{
    public class AdfSchemaProperty : BaseAdfSchemaProperty
    {
        /// <summary>
        /// Items for array property type. 
        /// </summary>
        public BaseAdfSchemaProperty Items { get; set; }

        /// <summary>
        /// Maximum number of items for array property type. 
        /// </summary>
        public int? MaxItems { get; set; }

        /// <summary>
        /// Minimum number of items for array property type. 
        /// </summary>
        public int? MinItems { get; set; }

        /// <summary>
        /// Unique number of items for array property type. 
        /// </summary>
        public bool? UniqueItems { get; set; }

        /// <summary>
        /// Nested properties of this property (only valid for object types). 
        /// </summary>
        public IDictionary<string, AdfSchemaProperty> Properties { get; set; }

        /// <summary>
        /// Name of the required properties for the type.
        /// </summary>
        public IList<string> Required { get; set; }
    }
}
