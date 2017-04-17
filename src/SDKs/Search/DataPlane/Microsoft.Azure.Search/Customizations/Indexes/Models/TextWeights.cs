// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Defines weights on index fields for which matches should boost scoring
    /// in search queries.
    /// </summary>
    public partial class TextWeights
    {
        /// <summary>
        /// Initializes a new instance of the TextWeights class.
        /// </summary>
        public TextWeights() { }

        /// <summary>
        /// Initializes a new instance of the TextWeights class.
        /// </summary>
        public TextWeights(IDictionary<string, double> weights)
        {
            Weights = weights;
        }

        /// <summary>
        /// Gets the dictionary of per-field weights to boost document
        /// scoring. The keys are field names and the values are the weights
        /// for each field.
        /// </summary>
        [JsonProperty(PropertyName = "weights")]
        public IDictionary<string, double> Weights { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (Weights == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Weights");
            }
        }
    }
}
