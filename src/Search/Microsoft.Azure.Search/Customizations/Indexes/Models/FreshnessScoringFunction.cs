// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using Microsoft.Rest;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines a function that boosts scores based on the value of a
    /// date-time field.
    /// </summary>
    [JsonObject("freshness")]
    public class FreshnessScoringFunction : ScoringFunction
    {
        /// <summary>
        /// Initializes a new instance of the FreshnessScoringFunction class.
        /// </summary>
        public FreshnessScoringFunction() { }

        /// <summary>
        /// Initializes a new instance of the FreshnessScoringFunction class.
        /// </summary>
        public FreshnessScoringFunction(string fieldName, double boost, FreshnessScoringParameters parameters, ScoringFunctionInterpolation? interpolation = default(ScoringFunctionInterpolation?))
            : base(fieldName, boost, interpolation)
        {
            Parameters = parameters;
        }

        /// <summary>
        /// Initializes a new instance of the FreshnessScoringFunction class.
        /// </summary>
        public FreshnessScoringFunction(
            string fieldName, 
            double boost, 
            TimeSpan boostingDuration, 
            ScoringFunctionInterpolation? interpolation = default(ScoringFunctionInterpolation?))
            : this(fieldName, boost, new FreshnessScoringParameters(boostingDuration), interpolation) { }

        /// <summary>
        /// Gets parameter values for the freshness scoring function.
        /// </summary>
        [JsonProperty(PropertyName = "freshness")]
        public FreshnessScoringParameters Parameters { get; set; }

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
