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
#if ADF_INTERNAL
    public class AdfSchemaProperty
    {
        /// <summary>
        /// Nested properties of this property (only valid for object types). 
        /// </summary>
        public IDictionary<string, AdfSchemaProperty> Properties { get; set; }

        /// <summary>
        /// Name of the required properties for the type.
        /// </summary>
        public IList<string> Required { get; set; }

        /// <summary>
        /// Description of the schema property.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Type of the JSON property.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Default value of the JSON property.
        /// </summary>
        public object Default { get; set; }

        /// <summary>
        /// Regular expression pattern for string property types.
        /// </summary>
        public string Pattern { get; set; }

        /// <summary>
        /// Minimum allowed value for numeric property types.
        /// </summary>
        public double? Minimum { get; set; }

        /// <summary>
        /// Maximum allowed value for numeric property types. 
        /// </summary>
        public double? Maximum { get; set; }

        /// <summary>
        /// The property is reference to a Linked Service (only valid for string types). 
        /// </summary>
        public bool? LinkedServiceReference { get; set; }

        /// <summary>
        /// The value of the property will be some sensitive value and should be 
        /// masked when returned from a GET call (only valid for string types).  
        /// </summary>
        public bool? SecureString { get; set; }
    }
#endif
}
