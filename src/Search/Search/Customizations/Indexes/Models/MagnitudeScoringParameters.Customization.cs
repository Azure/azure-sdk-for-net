// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Newtonsoft.Json;

    public partial class MagnitudeScoringParameters
    {
        /// <summary>
        /// Optional. Gets or sets a value indicating whether to apply a
        /// constant boost for field values beyond the range end value;
        /// default is false.
        /// </summary>
        [JsonIgnore]
        public bool ShouldBoostBeyondRangeByConstant
        {
            get { return this.ConstantBoostBeyondRange.GetValueOrDefault(); }
            set { this.ConstantBoostBeyondRange = value; }
        }
    }
}
