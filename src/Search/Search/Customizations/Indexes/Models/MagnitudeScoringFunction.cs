// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines a function that boosts scores based on the magnitude of a
    /// numeric field.
    /// </summary>
    [JsonObject("magnitude")]
    public class MagnitudeScoringFunction : ScoringFunction
    {
        /// <summary>
        /// Initializes a new instance of the MagnitudeScoringFunction class.
        /// </summary>
        public MagnitudeScoringFunction() { }

        /// <summary>
        /// Initializes a new instance of the MagnitudeScoringFunction class.
        /// </summary>
        public MagnitudeScoringFunction(string fieldName, double boost, MagnitudeScoringParameters parameters, ScoringFunctionInterpolation? interpolation = default(ScoringFunctionInterpolation?))
            : base(fieldName, boost, interpolation)
        {
            Parameters = parameters;
        }

        /// <summary>
        /// Initializes a new instance of the MagnitudeScoringFunction class.
        /// </summary>
        public MagnitudeScoringFunction(
            string fieldName, 
            double boost, 
            double boostingRangeStart, 
            double boostingRangeEnd, 
            bool? shouldBoostBeyondRangeByConstant = default(bool?), 
            ScoringFunctionInterpolation? interpolation = default(ScoringFunctionInterpolation?))
            : this(
                fieldName, 
                boost, 
                new MagnitudeScoringParameters(boostingRangeStart, boostingRangeEnd, shouldBoostBeyondRangeByConstant), 
                interpolation) { }

        /// <summary>
        /// Gets parameter values for the magnitude scoring function.
        /// </summary>
        [JsonProperty(PropertyName = "magnitude")]
        public MagnitudeScoringParameters Parameters { get; set; }

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
