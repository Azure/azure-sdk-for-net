// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;

    /// <summary>
    /// Abstract base class for functions that can modify document scores
    /// during ranking.
    /// </summary>
    public class ScoringFunction
    {
        /// <summary>
        /// Initializes a new instance of the ScoringFunction class.
        /// </summary>
        public ScoringFunction() { }

        /// <summary>
        /// Initializes a new instance of the ScoringFunction class.
        /// </summary>
        public ScoringFunction(string fieldName, double boost, ScoringFunctionInterpolation? interpolation = default(ScoringFunctionInterpolation?))
        {
            FieldName = fieldName;
            Boost = boost;
            Interpolation = interpolation;
        }

        /// <summary>
        /// Gets or sets the name of the field used as input to the scoring
        /// function.
        /// </summary>
        [JsonProperty(PropertyName = "fieldName")]
        public string FieldName { get; set; }

        /// <summary>
        /// Gets or sets a multiplier for the raw score. Must be a positive
        /// number not equal to 1.0.
        /// </summary>
        [JsonProperty(PropertyName = "boost")]
        public double Boost { get; set; }

        /// <summary>
        /// Gets or sets a value indicating how boosting will be interpolated
        /// across document scores; defaults to "Linear". Possible values for
        /// this property include: 'linear', 'constant', 'quadratic',
        /// 'logarithmic'.
        /// </summary>
        [JsonProperty(PropertyName = "interpolation")]
        public ScoringFunctionInterpolation? Interpolation { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (FieldName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "FieldName");
            }
        }
    }
}
