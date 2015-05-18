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
    /// SQL stored procedure parameter.
    /// </summary>
    public class StoredProcedureParameter
    {
        /// <summary>
        /// Stored procedure parameter value.
        /// </summary>
        [AdfRequired]
        public string Value { get; set; }

        /// <summary>
        /// Stored procedure parameter type. Should be one of <see cref="StoredProcedureParameterType"/>.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Initializes a new instance of the StoredProcedureParameter class.
        /// </summary>
        public StoredProcedureParameter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the StoredProcedureParameter class
        /// with required arguments.
        /// </summary>
        public StoredProcedureParameter(string value)
            : this()
        {
            Ensure.IsNotNullOrEmpty(value, "value");
            this.Value = value;
        }
    }
}
