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

namespace Microsoft.Azure.Management.DataFactories.Registration.Models
{
    public class AdfSchemaPropertyType
    {
        /// <summary>
        /// Array type.
        /// </summary>
        public const string Array = "array";

        /// <summary>
        /// Boolean type.
        /// </summary>
        public const string Boolean = "boolean";

        /// <summary>
        /// Integer type.
        /// </summary>
        public const string Integer = "integer";

        /// <summary>
        /// Number type (includes integer).
        /// </summary>
        public const string Number = "number";

        /// <summary>
        /// Object type.
        /// </summary>
        public const string Object = "object";

        /// <summary>
        /// String type.
        /// </summary>
        public const string String = "string";
    }
}
