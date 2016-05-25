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
    /// PolyBase Reject Type. A property of <see cref="PolyBaseSettings"/>.
    /// Indicates whether RejectValue is specified as a literal value or a percentage.
    /// </summary>
    public static class PolyBaseRejectType
    {
        /// <summary>
        /// Indicates the RejectValue property in PolyBase settings is specified as a literal value.
        /// </summary>
        public const string Value = "Value";

        /// <summary>
        /// Indicates the RejectValue property in PolyBase settings is specified as a percentage.
        /// </summary>
        public const string Percentage = "Percentage";
    }
}
