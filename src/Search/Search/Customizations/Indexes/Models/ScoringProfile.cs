// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;
    using Microsoft.Rest;
    using Newtonsoft.Json;

    public class ScoringProfile
    {
        /// <summary>
        /// Initializes a new instance of the ScoringProfile class.
        /// </summary>
        public ScoringProfile() { }

        /// <summary>
        /// Initializes a new instance of the ScoringProfile class.
        /// </summary>
        public ScoringProfile(string name, TextWeights textWeights = default(TextWeights), IList<ScoringFunction> functions = default(IList<ScoringFunction>), ScoringFunctionAggregation? functionAggregation = default(ScoringFunctionAggregation?))
        {
            Name = name;
            TextWeights = textWeights;
            Functions = functions;
            FunctionAggregation = functionAggregation;
        }

        /// <summary>
        /// Gets or sets the name of the scoring profile.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets parameters that boost scoring based on text matches
        /// in certain index fields.
        /// </summary>
        [JsonProperty(PropertyName = "text")]
        public TextWeights TextWeights { get; set; }

        /// <summary>
        /// Gets the collection of functions that influence the scoring of
        /// documents.
        /// </summary>
        [JsonProperty(PropertyName = "functions")]
        public IList<ScoringFunction> Functions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating how the results of individual
        /// scoring functions should be combined. Defaults to "Sum". Ignored
        /// if there are no scoring functions. Possible values for this
        /// property include: 'sum', 'average', 'minimum', 'maximum',
        /// 'firstMatching'.
        /// </summary>
        [JsonProperty(PropertyName = "functionAggregation")]
        public ScoringFunctionAggregation? FunctionAggregation { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (Name == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Name");
            }
            if (this.TextWeights != null)
            {
                this.TextWeights.Validate();
            }
            if (this.Functions != null)
            {
                foreach (var element in this.Functions)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
        }
    }
}
