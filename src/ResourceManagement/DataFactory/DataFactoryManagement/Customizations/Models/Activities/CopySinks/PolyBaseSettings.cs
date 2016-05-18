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
    /// Polybase settings.
    /// </summary>
    public class PolyBaseSettings
    {
        /// <summary>
        /// Optional. Indicates whether RejectValue is specified as a literal value or a percentage.
        /// Must be one of <see cref="PolyBaseRejectType"/>.
        /// Default value is <see cref="PolyBaseRejectType.Value" />.
        /// </summary>
        public string RejectType { get; set; }

        /// <summary>
        /// Optional. Specifies the value or the percentage of rows that can be rejected before the query fails.
        /// Default value is 0.
        /// </summary>
        public double? RejectValue { get; set; }

        /// <summary>
        /// Optional. Determines the number of rows to attempt to retrieve before PolyBase recalculates the percentage of rejected rows.
        /// Required when RejectType is <see cref="PolyBaseRejectType.Percentage" />.
        /// </summary>
        public ulong? RejectSampleValue { get; set; }

        /// <summary>
        /// Optional. Specifies how to handle missing values in delimited text files when PolyBase retrieves data from the text file.
        /// Default value is false.
        /// </summary>
        public bool? UseTypeDefault { get; set; }
    }
}
