// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines a function that boosts scores of documents with string values
    /// matching a given list of tags.
    /// </summary>
    [JsonObject("tag")]
    public class TagScoringFunction : ScoringFunction
    {
        /// <summary>
        /// Initializes a new instance of the TagScoringFunction class.
        /// </summary>
        public TagScoringFunction() { }

        /// <summary>
        /// Initializes a new instance of the TagScoringFunction class.
        /// </summary>
        public TagScoringFunction(string fieldName, double boost, TagScoringParameters parameters, ScoringFunctionInterpolation? interpolation = default(ScoringFunctionInterpolation?))
            : base(fieldName, boost, interpolation)
        {
            Parameters = parameters;
        }

        /// <summary>
        /// Initializes a new instance of the TagScoringFunction class.
        /// </summary>
        public TagScoringFunction(
            string fieldName, 
            double boost, 
            string tagsParameter, 
            ScoringFunctionInterpolation? interpolation = default(ScoringFunctionInterpolation?))
            : this(fieldName, boost, new TagScoringParameters(tagsParameter), interpolation) { }

        /// <summary>
        /// Gets parameter values for the tag scoring function.
        /// </summary>
        [JsonProperty(PropertyName = "tag")]
        public TagScoringParameters Parameters { get; set; }

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
