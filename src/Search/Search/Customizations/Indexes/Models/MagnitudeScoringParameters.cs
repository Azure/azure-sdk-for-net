// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Newtonsoft.Json;

    public class MagnitudeScoringParameters
    {
        /// <summary>
        /// Initializes a new instance of the MagnitudeScoringParameters class.
        /// </summary>
        public MagnitudeScoringParameters() { }

        /// <summary>
        /// Initializes a new instance of the MagnitudeScoringParameters class.
        /// </summary>
        public MagnitudeScoringParameters(double boostingRangeStart, double boostingRangeEnd, bool? shouldBoostBeyondRangeByConstant = default(bool?))
        {
            BoostingRangeStart = boostingRangeStart;
            BoostingRangeEnd = boostingRangeEnd;
            ShouldBoostBeyondRangeByConstant = shouldBoostBeyondRangeByConstant;
        }

        /// <summary>
        /// Gets or sets the field value at which boosting starts.
        /// </summary>
        [JsonProperty(PropertyName = "boostingRangeStart")]
        public double BoostingRangeStart { get; set; }

        /// <summary>
        /// Gets or sets the field value at which boosting ends.
        /// </summary>
        [JsonProperty(PropertyName = "boostingRangeEnd")]
        public double BoostingRangeEnd { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to apply a constant boost
        /// for field values beyond the range end value; default is false.
        /// </summary>
        [JsonProperty(PropertyName = "constantBoostBeyondRange")]
        public bool? ShouldBoostBeyondRangeByConstant { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
        }
    }
}
