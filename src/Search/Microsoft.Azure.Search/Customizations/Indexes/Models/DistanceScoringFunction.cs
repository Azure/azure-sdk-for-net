// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines a function that boosts scores based on distance from a
    /// geographic location.
    /// </summary>
    [JsonObject("distance")]
    public class DistanceScoringFunction : ScoringFunction
    {
        /// <summary>
        /// Initializes a new instance of the DistanceScoringFunction class.
        /// </summary>
        public DistanceScoringFunction() { }

        /// <summary>
        /// Initializes a new instance of the DistanceScoringFunction class.
        /// </summary>
        public DistanceScoringFunction(string fieldName, double boost, DistanceScoringParameters parameters, ScoringFunctionInterpolation? interpolation = default(ScoringFunctionInterpolation?))
            : base(fieldName, boost, interpolation)
        {
            Parameters = parameters;
        }

        /// <summary>
        /// Initializes a new instance of the DistanceScoringFunction class.
        /// </summary>
        public DistanceScoringFunction(
            string fieldName, 
            double boost, 
            string referencePointParameter, 
            double boostingDistance, 
            ScoringFunctionInterpolation? interpolation = default(ScoringFunctionInterpolation?))
            : this(
                fieldName, 
                boost, 
                new DistanceScoringParameters(referencePointParameter, boostingDistance), 
                interpolation) { }

        /// <summary>
        /// Gets parameter values for the distance scoring function.
        /// </summary>
        [JsonProperty(PropertyName = "distance")]
        public DistanceScoringParameters Parameters { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            if (Parameters == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Parameters");
            }
            if (this.Parameters != null)
            {
                this.Parameters.Validate();
            }
        }
    }
}
