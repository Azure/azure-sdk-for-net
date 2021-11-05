// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class LengthTokenFilter
    {
        /// <summary>
        /// Gets the minimum length in characters. Default is 0. Maximum is 300. Must be less than the value of <see cref="MinLength"/>.
        /// </summary>
        [CodeGenMember("min")]
        public int? MinLength { get; set; }

        /// <summary>
        /// Gets the maximum length in characters. Default and maximum is 300.
        /// </summary>
        [CodeGenMember("max")]
        public int? MaxLength { get; set; }
    }
}
