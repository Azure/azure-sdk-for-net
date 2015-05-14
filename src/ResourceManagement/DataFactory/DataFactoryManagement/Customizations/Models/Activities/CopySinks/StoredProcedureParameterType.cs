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
    /// Stored procedure parameter type.
    /// </summary>
    public static class StoredProcedureParameterType
    {
        /// <summary>
        /// String type.
        /// </summary>
        public const string String = "String";

        /// <summary>
        /// Integer type.
        /// </summary>
        public const string Int = "Int";

        /// <summary>
        /// Decimal type.
        /// </summary>
        public const string Decimal = "Decimal";

        /// <summary>
        /// Guid type.
        /// </summary>
        public const string Guid = "Guid";

        /// <summary>
        /// Boolean type.
        /// </summary>
        public const string Boolean = "Boolean";

        /// <summary>
        /// DateTime type.
        /// </summary>
        public const string Date = "Date";
    }
}
